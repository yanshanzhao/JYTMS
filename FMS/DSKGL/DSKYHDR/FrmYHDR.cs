#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pri;
using JY.Pub;
using System.IO;
using System.Collections;
using System.Data.SqlClient;
using NPOI.HSSF.UserModel;
using System.Text.RegularExpressions;
using System.Configuration;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
using System.Web;
using JYPubFiles.Classes;
#endregion

namespace FMS.DSKGL.DSKYH
{
    public partial class FrmYHDR : UserControl
    {
        #region ��Ա����
        private string PriConStr;
        private string PriConStrKj;
        private ClsG ObjG;
        private string PriFilePath;//�ļ�·��
        private string[] PriExtention = { ".xls" };//�����ϴ����ļ�����չ����
        //private string PriUploadFoldr;//�ļ��ϴ�����Ŀ���ļ���
        List<string> LstFiles = new List<string>();
        private HSSFWorkbook Hssfworkbook;
        private DataTable PriTydColsDescription;
        private string ScolName;//�����洢Excel����
        private DataRow[] PriDrs;
        private List<string> PriListFln;//����
        private List<string> PriListFlsm;//��˵��
        List<string> lstErrors;//��¼�д���
        private int PriSucceed; //��¼ƥ��ɹ�����
        private int PriFailure;//��¼ʧ������
        private string PriName;
        private List<string> Prirbid = new List<string>();
        private DSKYHDR.DSYHDR.VfmsdsknhpcRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as DSKYHDR.DSYHDR.VfmsdsknhpcRow;
                }
            }
        }
        #endregion
        public FrmYHDR()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            PriConStr = ClsGlobals.CntStrTMS;
            PriConStrKj = ClsGlobals.CntStrKj;
            //��ñ���˵����ֵ��DataTable
            PriTydColsDescription = ClsRWMSSQLDb.GetColDescription("tfmsdsknhdrmx", PriConStr);
            //����ļ���·��
            PriFilePath = Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), ClsOptions.WebCfg.NHXlsFilePath + DateTime.Now.ToString("yyyyMM"));
            if (!Directory.Exists(PriFilePath))
                Directory.CreateDirectory(PriFilePath);
            //��ָ��·���µ��ļ���ʾ��ListBox��
            ImportFileToDgv(PriFilePath);
            //�Զ����ϴ��ļ�·��,�����Զ���ؼ����Prepare����
            //PriUploadFoldr = ClsOptions.WebCfg.PosXlsFilePath + DateTime.Now.ToString("yyyyMM");
            ctrlUploadFile1.Prepare(PriFilePath, PriExtention, false, "�����ļ�");
            ImportFileToDgv(PriFilePath);
            ctrlUploadFile1.PrepareA(new JY.CtrlPub.ImportToDB(DgvAddFile));
            CmbZtlx.SelectedIndex = 0;
            VfmsdsknhpcTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }
        #region ������ϴ��ļ����ļ�������ļ�������DataGridview��
        private void ImportFileToDgv(string filePath)
        {
            Dgv.Rows.Clear();
            LstFiles.Clear();
            foreach (string str in Directory.GetFiles(PriFilePath, "*.xls"))
            {
                FileInfo f = new FileInfo(str);
                LstFiles.Add(Path.GetFileName(str).ToString());
                string[] str1 = { Path.GetFileName(str).ToString(), string.Format("{0:0.00}", f.Length / 1024) };
                Dgv.Rows.Add(str1);
            }
        }
        #endregion
        #region  �����������ļ���ѡ��
        public void DgvAddFile(string filepath)
        {
            foreach (string str in Directory.GetFiles(PriFilePath, "*.xls"))
            {
                FileInfo f = new FileInfo(str);
                string a = LstFiles.ToArray().FirstOrDefault(cx => string.Compare(Path.GetFileName(str).ToString(), cx.ToString()) == 0);
                if (string.IsNullOrEmpty(a))
                {
                    string[] str1 = { Path.GetFileName(str).ToString(), string.Format("{0:0.00}", f.Length / 1024) };
                    Dgv.Rows.Add(str1);
                    LstFiles.Add(Path.GetFileName(str).ToString());
                }
            }
            Dgv.CurrentCell = Dgv.Rows[Dgv.Rows.Count - 1].Cells[0];
            Dgv.BeginEdit(true);
        }
        #endregion
        private void BtnToData_Click(object sender, EventArgs e)
        
        {
            if (Dgv.SelectedRows != null && Dgv.Rows.Count != 0)
            {
                string flName = Dgv.CurrentRow.Cells[0].Value.ToString();
                ExcelToDatatable(PriFilePath + @"\" + flName);
                //TxtToDatatable(PriFilePath + @"\" + flName);
            }
        }
        #region ExcelToDataTable()
        public void ExcelToDatatable(string filePath)
        {
            int Pcid = 0;
            List<string> CatList = new List<string>();
            Dictionary<int, string> DirCellName = new Dictionary<int, string>();
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                Hssfworkbook = new HSSFWorkbook(fs);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("�������", ex);
                return;
            }
            using (SqlConnection conn = new SqlConnection(PriConStr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                SqlTransaction trans = conn.BeginTransaction();
                comm.Transaction = trans;
                comm.CommandTimeout = 300;
                try
                {
                    lstErrors = new List<string>();
                    // ����������Ϣ�����pcid
                    string cmdText = string.Format("insert into tfmsdsknhdrpc (fln,inssj,insczyid,insczyxm,zt,lx)" +
                        "  values ('{0}','{1}','{2}','{3}','{4}','N');SELECT SCOPE_IDENTITY()", Dgv.CurrentRow.Cells[0].Value, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.xm, "0");
                    comm.CommandText = cmdText;
                    Pcid = Convert.ToInt32(comm.ExecuteScalar());
                    int sheets = Hssfworkbook.NumberOfSheets;//��ȡ�ж��ٸ�sheet
                    for (int n = 0; n < sheets; n++)
                    {
                        DirCellName.Clear();
                        string names = "";
                        //��ȡExcel�ĵ�һ��sheet
                        HSSFSheet hssfsheet = (HSSFSheet)Hssfworkbook.GetSheetAt(n);
                        string sheetsName = hssfsheet.SheetName;
                        if (hssfsheet.LastRowNum < 1)
                            break;
                        //��ȡExcel�����У����ڶ���
                        HSSFRow headerRow = (HSSFRow)hssfsheet.GetRow(1);
                        HSSFRow row = (HSSFRow)hssfsheet.GetRow(1);
                        GetFldLst(row);
                        if (PriListFln.Count == 0)
                        {
                            lstErrors.Add(sheetsName + "�ļ���ͷ��ʽ����");
                            continue;
                        }
                        StringBuilder sb = new StringBuilder();
                        //ѭ������Excel�г��˵ڶ���֮�������������
                        for (int i = hssfsheet.FirstRowNum + 2; i <= hssfsheet.LastRowNum; i++)
                        {
                            row = (HSSFRow)hssfsheet.GetRow(i);
                            List<string> LstValues = RowToValue(row, PriListFlsm);
                            //�ļ��п�ֵ��ֵ�ĸ�ʽ����ȷ ������ѭ��
                            if (LstValues.Count == 0)
                            {
                                lstErrors.Add(sheetsName + "�����ļ��п�ֵ���ʽ����");                                 break;
                            }
                            //���ݴ���List�е�Excel�ı�ͷ��Ϣ������Insert�����Ҫ������е��ַ���
                            names = ClsQ.Q0("pcid,zt," + string.Join(",", PriListFln), '(');
                            string values = ClsQ.Q0(Pcid + ",'0'," + string.Join(",", LstValues), '(') + ";";
                            sb.Append(" Insert into tfmsdsknhdrmx " + names + " values " + values);
                        }
                        //��������쳣 ������ѭ�� ����ִ��
                        if (lstErrors.Count > 0)
                            break;
                        try
                        {
                            comm.CommandText = sb.ToString();
                            comm.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            lstErrors.Add(sheetsName + "д�����ݿ����" + ex.Message);
                            continue;
                        }
                    }
                    //����ж��sheet  ��һ��������ȫ���ع�
                    if (lstErrors.Count > 0)
                    {
                        trans.Rollback();
                        ClsMsgBox.Ts(string.Join("\n", lstErrors), ObjG.CustomMsgBox, this);
                    }
                    else
                    {
                        trans.Commit();
                        ClsMsgBox.Ts("����ɹ���", ObjG.CustomMsgBox, this);
                    }
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw(ex.Message, ObjG.CustomMsgBox, this);
                    trans.Rollback();
                    return;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region TxtToDatatable()
        public void TxtToDatatable(string filePath)
        {
            SqlDataAdapter adapter;
            int ts1 = 0;
            int ts2 = 0;
            List<int> LstFwkhid = new List<int>();
            //����һ������Id���洢���ε�Id
            int id = 0;
            //����һ���������洢SQL���
            string cmdText;
            //����һ��List�������洢������Ϣ
            List<string> lstErrors = new List<string>();
            List<string> lstCfcw = new List<string>();

            //ʵ�������ClsCheckAYDRow��
            ClsCheckAYDRows aCheckRow = new ClsCheckAYDRows();
            using (TextReader tr = new StreamReader(filePath, Encoding.Default))
            {
                CsvStream csv = new CsvStream(tr);
                string[] row = csv.GetNextRow();
                Dictionary<int, string> FldHeaderLst = GetFldHeaderLst(row);
                Dictionary<int, string> FldLst = new Dictionary<int, string>();
                FldLst = GetFldLst(row);
                DataTable Dtcfyd = new DataTable();
                DataTable DtcTrbmx = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                PriName = string.Join(",", FldLst.Values.ToArray<string>());
                using (SqlConnection conn = new SqlConnection(PriConStr))
                {
                    try
                    {
                        conn.Open();
                        SqlTransaction trans = conn.BeginTransaction();
                        SqlCommand comm = new SqlCommand();
                        comm.CommandTimeout = 2000;
                        comm.Connection = conn;
                        comm.Transaction = trans;
                        string[] row1;
                        List<string> LstValues = new List<string>();
                        int i = 0;
                        string names;
                        while (true)
                        {
                            names = PriName;
                            i++;
                            row1 = csv.GetNextRow();
                            #region ���ط�NULL��Ϣ
                            if (row1 != null)
                            {
                                List<string> list = new List<string>();
                                list = row1.ToList();
                                if (row.Length != row1.Length)
                                {
                                    list.Add("null");
                                }
                                LstValues = aCheckRow.RowToValues(list, FldHeaderLst, "QS");
                                if (LstValues != null)
                                {
                                    string values = "";
                                    values = string.Join(",", LstValues.ToArray());
                                    string cmdtext = "Insert into thdsj (" + names + ") values(" + values + ")";
                                    comm.CommandText = cmdtext;
                                    try
                                    {
                                        comm.ExecuteNonQuery();
                                        ts1++;
                                    }
                                    catch (Exception ex)
                                    {
                                        aCheckRow.lstErrors.Add("д�����ݿ����:" + ex.Message);
                                    }
                                    if (aCheckRow.lstErrors.Count > 0)
                                    {
                                        lstErrors.Add("��" + (i + 1) + "�д���:" + string.Join(",", aCheckRow.lstErrors));
                                    }
                                    //if (lstErrors.Count == Convert.ToInt32(this.TxtCw.Text))
                                    //    break;
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(aCheckRow.PubCfbz))
                                        lstCfcw.Add("��" + (i + 1) + "�д���:" + aCheckRow.PubCfbz);
                                }
                            }
                            #endregion
                            else
                            {
                                break;
                            }
                        }
                        //��������
                        if (lstErrors.Count > 0)
                        {
                            trans.Rollback();
                        }
                        else
                        {
                            trans.Commit();
                            ClsMsgBox.Ts("����ɹ�,������" + ts1 + "��,�ظ�����" + ts2 + "����");
                        }
                    }
                    finally
                    {
                        tr.Close();
                        conn.Close();
                    }
                }
            }//using TextReader
        }
        #endregion

        #region GetFldHeaderLst Txt
        private Dictionary<int, string> GetFldHeaderLst(string[] str)
        {
            int i = 0;
            Dictionary<int, string> flds = new Dictionary<int, string>();
            //ʹ��foreach�������м���Dictionary
            foreach (string c in str)
            {
                ScolName = c;
                if (!string.IsNullOrEmpty(ScolName))
                {
                    PriDrs = PriTydColsDescription.Select("flsm  like '" + ScolName + "��%'");
                    if (PriDrs.Count() == 1)
                    {
                        flds.Add(i, ScolName);
                        i++;
                    }
                }
            }
            return flds;
        }
        #endregion
        #region GetFldLst() Txt
        private Dictionary<int, string> GetFldLst(string[] str)
        {
            Dictionary<int, string> flds = new Dictionary<int, string>();
            int i = 0;
            //ʹ��foreach�������м���Dictionary
            foreach (string c in str)
            {
                ScolName = c;
                if (!string.IsNullOrEmpty(ScolName))
                {
                    if (ScolName.Equals("��������") || ScolName.Equals("�յ�����") || ScolName.Equals("ǩ�ջ�����������"))
                    {
                        continue;
                    }
                    else
                    {
                        PriDrs = PriTydColsDescription.Select("flsm  like '" + ScolName + "��%'");
                        if (PriDrs.Count() == 1)
                        {
                            flds.Add(i, PriDrs[0]["fln"].ToString());
                            i++;
                        }
                    }
                }
            }
            return flds;
        }
        #endregion







        #region GetFldLst() Excel
        private void GetFldLst(HSSFRow headerRow)
        {
            PriListFlsm = new List<string>();
            PriListFln = new List<string>();
            //ʹ��foreach�������м���Dictionary
            foreach (HSSFCell c in headerRow.Cells)
            {
                ScolName = c.StringCellValue;
                if (!string.IsNullOrEmpty(ScolName))
                {
                    PriDrs = PriTydColsDescription.Select("flsm  like '" + ScolName + "��%'");
                    if (PriDrs.Length == 1)
                    {
                        PriListFln.Add(PriDrs[0]["fln"].ToString());
                        PriListFlsm.Add(ScolName);
                    }
                }
            }
        }
        #endregion
        #region RowToValue()
        public List<string> RowToValue(HSSFRow aRow, List<string> alist)
        {
            HSSFCell c;
            string sValue;
            List<string> LstValue = new List<string>();
            for (int i = 0; i < alist.Count; i++)
            {
                c = (HSSFCell)aRow.Cells.Find(cx => cx.ColumnIndex == i);

                if (string.IsNullOrEmpty(c.ToString()) && i > 10)
                {
                    LstValue.Clear();
                    break;
                }
                else
                {
                    sValue = c.ToString().Trim();
                    if (alist[i].Equals("���"))
                    {
                        double aJyje;
                        if (double.TryParse(sValue, out aJyje))
                            LstValue.Add(ClsQ.Q1(aJyje.ToString()));
                    }
                    else if (alist[i].Equals("����״̬"))
                    {
                        if (sValue.LastIndexOf("�ɹ�") >= 0)
                            LstValue.Add(ClsQ.Q1("0"));
                        else
                            LstValue.Add(ClsQ.Q1("10"));
                    }
                    else
                    {
                        LstValue.Add(ClsQ.Q1(sValue));
                    }
                }
            }
            return LstValue;
        }
        #endregion
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Dgv.SelectedRows != null && Dgv.Rows.Count != 0)
            {
                ClsMsgBox.YesNo("ȷ��ɾ��" + Dgv.CurrentRow.Cells[0].Value + "��", new EventHandler(DeleteFile));
            }
        }
        private void DeleteFile(object sender, EventArgs e)
        {
            Form p = sender as Form;
            if (p.DialogResult == DialogResult.Yes)
            {
                File.Delete(PriFilePath + @"\" + Dgv.CurrentRow.Cells[0].Value);
                ImportFileToDgv(PriFilePath);
            }
        }
        private void BtnQuiry_Click(object sender, EventArgs e)
        {
            string where = " where inssj >= '" + DtpStart.Value.Date + "' and inssj < '" + DtpStop.Value.AddDays(1) + "'";
            where += " and zt = " + CmbZtlx.SelectedIndex;
            VfmsdsknhpcTableAdapter1.FillByWhere(DSYHDR1.Vfmsdsknhpc, where);
        }
        private void PosMatching()
        {
            if (Bds.Current == null)
            {
                ClsMsgBox.Ts("��ѡ��Ҫƥ�����Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                com.Transaction = trans;
                try
                {
                    PriSucceed = 0;//�ɹ�����
                    PriFailure = 0;//��¼ʧ������
                    DataTable table_rbpc = ClsRWMSSQLDb.GetDataTable("  SELECT a.id,b.zh,b.zhmc,a.dkje FROM Tfmsdskjkpc AS a INNER JOIN  tfmsyhzh AS b ON a.jgid=b.jgid    WHERE a.zt=15 AND a.zffs='X' AND a.yhzt=0 AND  b.yhlxid=241 AND b.zhlxid=50 AND b.zt=0   ORDER BY zdsj DESC", ClsGlobals.CntStrTMS);
                    DSKYHDR.DSYHDR.VfmsdsknhpcRow pcrow = ((DataRowView)Bds.Current).Row as DSKYHDR.DSYHDR.VfmsdsknhpcRow;
                    TfmsdsknhdrmxTableAdapter.FillByYHDR(this.DSYHDR1.Tfmsdsknhdrmx, pcrow.id);
                    com.CommandText += " Update Tfmsdsknhdrpc set zt = 1 where id =" + pcrow.id + " ;";
                    com.ExecuteNonQuery();
                    foreach (DSKYHDR.DSYHDR.TfmsdsknhdrmxRow row in DSYHDR1.Tfmsdsknhdrmx)
                    {
                        int count = 0;//��¼�Ƿ���ƥ���
                        for (int j = table_rbpc.Rows.Count - 1; j >= 0; j--)
                        {
                            string yhzh = table_rbpc.Rows[j]["zh"].ToString();
                            string yhzhmc = table_rbpc.Rows[j]["zhmc"].ToString();
                            decimal dkje = Convert.ToDecimal(table_rbpc.Rows[j]["dkje"]);
                            int id = Convert.ToInt32(table_rbpc.Rows[j]["id"]);
                            if (row.yhzh == yhzh && row.jyje == dkje && row.zhmc == yhzhmc)
                            {
                                if (row.jyzt == 0)
                                {
                                    com.CommandText = "Update Tfmsdskjkpc set yhzt = 1 where id =" + id + " ;";
                                    com.CommandText += " Update tfmsdsknhdrmx set zt = 5,rbpcid =" + id + " where id =" + row.id + " ;";
                                }
                                else if (row.jyzt == 10)
                                {
                                    com.CommandText = " Update tfmsdsknhdrmx set zt = 10,rbpcid =" + id + " where id =" + row.id + " ;";
                                }
                                com.ExecuteNonQuery();
                                table_rbpc.Rows.RemoveAt(j);
                                PriSucceed++;
                                count++;
                                break;
                            }
                        }
                        if (count == 0)
                        {
                            com.CommandText = " Update tfmsdsknhdrmx set zt = 10 where id =" + row.id;
                            com.ExecuteNonQuery();
                            PriFailure++;
                        }
                        continue;
                    }
                    Bds.RemoveCurrent();
                    trans.Commit();
                    ClsMsgBox.Ts("��" + DSYHDR1.Tfmsdsknhdrmx.Rows.Count + "����ƥ��ɹ�" + PriSucceed + "����ʧ��" + PriFailure + "����", ObjG.CustomMsgBox, this);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    ClsMsgBox.Cw("ƥ��ʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
                }
                finally
                {
                    conn.Close();
                    com.Dispose();
                }
            }
        }
        private void BtnElse_Click(object sender, EventArgs e)
        {
            if (DGVDRxx.RowCount == 0)
                return;
            ClsExcel.CreatExcel(DGVDRxx, "ũ�����д���ƥ����Ϣ", this.ctrlDownLoad1);
        }

        private void BtnElxrb_Click(object sender, EventArgs e)
        {
            if (PriRow == null)
            {
                ClsMsgBox.Ts("��ѡ��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "���ջ����տ��ձ���";//�ļ�����    
            PriFln = PriFln + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            string PriFlp = System.IO.Path.Combine(System.Configuration.ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
            //�������ݿ����ӶԽӶ���
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TMSConnectionString"].ToString());
            //�����ݿ�����
            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
                DataTable dt = ClsRWMSSQLDb.GetDataTable("  SELECT DISTINCT c.jgmc,a.yhzh,a.zhmc,a.jyje,(CASE WHEN a.zt=0 THEN 'δƥ��' WHEN a.zt=5 THEN '���'   WHEN a.zt=10 THEN '����'end)AS zts,a.zt,a.id FROM dbo.Tfmsdsknhdrmx AS a left JOIN Tfmsdskjkpc  AS b ON   a.rbpcid=b.id left JOIN vfmsyhzh AS c ON b.jgid=c.jgid where a.pcid= " + PriRow.id + "  order by a.zt desc , c.jgmc ", ClsGlobals.CntStrTMS);

                decimal SumDSKje = dt.AsEnumerable().Sum(r => r.Field<decimal>("jyje"));
                //ģ��·��
                string priModel = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath + @"App_Data\ModelExcel\FMS", "Dsknhdr.xls");
                //����ģ���ȡIO��
                FileStream fileStreamRead = new FileStream(priModel, FileMode.Open, FileAccess.Read);
                //����������XLS����
                HSSFWorkbook hssfwork = new HSSFWorkbook(fileStreamRead);
                HSSFSheet hssfSheet = hssfwork.GetSheetAt(0) as HSSFSheet;
                HSSFRow hssfRow = hssfSheet.GetRow(1) as HSSFRow;
                HSSFCell hssfCell = hssfRow.GetCell(0) as HSSFCell;

                #region ��ʽ
                #region ������ʽ
                HSSFCellStyle cellStyle1 = (HSSFCellStyle)hssfwork.CreateCellStyle();
                cellStyle1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                #endregion
                #region ˫��������
                HSSFCellStyle cellStyle2 = (HSSFCellStyle)hssfwork.CreateCellStyle();
                cellStyle2.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                #endregion

                #endregion

                /**�����������ڣ�  ��  ��  ��**/
                HSSFRow row = (HSSFRow)hssfSheet.CreateRow(1);
                row.CreateCell(0).SetCellValue("������������:" + PriRow.inssj.ToShortDateString());
                row.Cells[0].CellStyle = cellStyle1;
                row.CreateCell(3).SetCellValue("�տ����ͣ���������ũ��");
                row.Cells[1].CellStyle = cellStyle1;
                /**�������**/
                int rowIndex = 3;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HSSFRow r = (HSSFRow)hssfSheet.CreateRow(rowIndex);
                    Cell c0 = r.CreateCell(0);
                    Cell c1 = r.CreateCell(1);
                    Cell c2 = r.CreateCell(2);
                    Cell c3 = r.CreateCell(3);
                    Cell c4 = r.CreateCell(4);
                    Cell c5 = r.CreateCell(5);
                    //������ݺ�������ʽ
                    c0.SetCellValue(i + 1);
                    c0.CellStyle = cellStyle1;
                    c1.SetCellValue(dt.Rows[i]["jgmc"].ToString());
                    c2.SetCellValue(dt.Rows[i]["yhzh"].ToString());
                    c3.SetCellValue(dt.Rows[i]["zhmc"].ToString());
                    c4.SetCellValue(Convert.ToDouble(dt.Rows[i]["jyje"].ToString()));
                    c4.CellStyle = cellStyle2;
                    c5.SetCellValue(dt.Rows[i]["zts"].ToString());
                    rowIndex++;
                }
                //�ϼ�   
                HSSFRow hj = (HSSFRow)hssfSheet.CreateRow(rowIndex);
                Cell Hjc0 = hj.CreateCell(0);
                Cell Hjc3 = hj.CreateCell(3);
                Cell Hjc4 = hj.CreateCell(4);
                Hjc0.SetCellValue("�ϼƣ�");
                Hjc4.SetCellValue(SumDSKje.ToString());
                Hjc4.CellStyle = cellStyle2;
                //ͳ��
                rowIndex++;
                HSSFRow hj0 = (HSSFRow)hssfSheet.CreateRow(rowIndex);
                Cell Hjc1 = hj0.CreateCell(0);
                int firstRow = rowIndex;
                int lastRow = rowIndex;
                int firstCol = 0;
                int lastCol = 6;
                hssfSheet.AddMergedRegion(new CellRangeAddress(firstRow, lastRow, firstCol, lastCol));
                rowIndex++;
                //     ��     ��     ϵͳʵ�մ��ս��           Ԫ       �˶Բ��� ��
                HSSFRow Tj = (HSSFRow)hssfSheet.CreateRow(rowIndex);
                Cell Tj0 = Tj.CreateCell(0);
                Hjc1.SetCellValue("     ��     ��     ϵͳʵ�մ��ս��           Ԫ       �˶Բ��� ��");
                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfwork.Write(file);
                file.Close();
                ctrlDownLoad1.download(PriFlp, true);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Ts("��������" + ex.ToString(), ObjG.CustomMsgBox, this);
                return;
            }
            finally
            {
                conn.Close();
            }
        }

        private void DGVDRxx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 4)
                return;
            if (e.ColumnIndex == 4)
            {
                DSKYHDR.DSYHDR.VfmsdsknhpcRow row = ((DataRowView)Bds.Current).Row as DSKYHDR.DSYHDR.VfmsdsknhpcRow;
                if (row.zt == 1)
                {
                    ClsMsgBox.Ts("��ũ����Ϣ��ƥ�䣡", ObjG.CustomMsgBox, this);
                    return;
                }
                else
                    PosMatching();
            }
            else
            {

                FrmYHMX f = new FrmYHMX();
                f.Prepare(PriRow.id, "N");
                f.ShowDialog();
            }
        }

        private void BtnDelete2_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
            {
                ClsMsgBox.Ts("û��Ҫɾ������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            ClsMsgBox.YesNo("ȷ��Ҫɾ��������Ϣ��", new EventHandler(Delete), ObjG.CustomMsgBox, this);
        }
        public void Delete(object sender, EventArgs e)
        {
            Form f = sender as Form;
            //FrmMsgBox frm = new FrmMsgBox();
            if (f.DialogResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = conn;
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    com.Transaction = trans;
                    try
                    {
                     
                        DSKYHDR.DSYHDR.VfmsdsknhpcRow pcrow = ((DataRowView)Bds.Current).Row as DSKYHDR.DSYHDR.VfmsdsknhpcRow;
                        TfmsdsknhdrmxTableAdapter.FillByYHDR(this.DSYHDR1.Tfmsdsknhdrmx, pcrow.id);
                        com.CommandText += " delete from Tfmsdsknhdrmx where zt=0 and pcid =" + pcrow.id + " ;";
                        com.CommandText += " delete from Tfmsdsknhdrpc  where zt=0 and id =" + pcrow.id + " ;";
                        com.ExecuteNonQuery();
                        
                           
                            Bds.RemoveCurrent();
                            trans.Commit();
                            ClsMsgBox.Ts("ɾ���ɹ���");
                    }
                    catch (Exception cw)
                    {
                        trans.Rollback();
                        ClsMsgBox.Ts("ɾ��ʧ�ܣ�" + cw.ToString(), f, this);
                    }
                    finally
                    {
                        conn.Close();
                        com.Dispose();
                    }
                }

            }
        }
    }
}