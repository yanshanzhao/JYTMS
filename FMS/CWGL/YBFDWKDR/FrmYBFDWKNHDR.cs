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
using FMS.CWGL.YBFNHDR;
using System.Threading;
#endregion
namespace FMS.CWGL.YBFDWKDR
{
    public partial class FrmYBFDWKNHDR : UserControl
    {
        public FrmYBFDWKNHDR()
        {
            InitializeComponent();
        }
        #region ��Ա����
        private string PriFilePath;//�ļ�·��
        private HSSFWorkbook Hssfworkbook;
        private string[] PriExtention = { ".xls" };//�����ϴ����ļ�����չ����
        List<string> lstErrors;//��¼�д���
        private string PriConStr;
        List<string> LstFiles = new List<string>();
        private List<string> PriListFln;//����
        private List<string> PriListFlsm;//��˵��
        private ClsG ObjG;
        private int PriSucceed; //��¼ƥ��ɹ�����
        private int PriFailure;//��¼ʧ������
        private DataTable PriTydColsDescription;
        private string ScolName;//�����洢Excel����
        private DataRow[] PriDrs;
        private string PriConStrKj;
        private int PriSpjgid = 0;
        private YBFDWKDR.DSYBFDWKDR.VybfdwkdrpcRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as YBFDWKDR.DSYBFDWKDR.VybfdwkdrpcRow;
                }
            }
        }
        #endregion
        #region ��ʼ��
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            PriConStr = ClsGlobals.CntStrTMS;
            PriConStrKj = ClsGlobals.CntStrKj;
            PriSpjgid = ObjG.Jigou.id;
            //��ñ��˵����ֵ��DataTable
            PriTydColsDescription = ClsRWMSSQLDb.GetColDescription("Tfmsybfdwknhdr", PriConStr);
            //����ļ���·��
            PriFilePath = Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), ClsOptions.WebCfg.YBFDWKNHFilePath + DateTime.Now.ToString("yyyyMM"));
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
            VybfdwkdrpcTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            TfmsybfdwknhdrTableAdapter.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }
        #endregion
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
        #region ��ѯ
        private void BtnQuiry_Click(object sender, EventArgs e)
        {
            string where = " where lx='N' and  inssj >= '" + DtpStart.Value.Date + "' and inssj < '" + DtpStop.Value.AddDays(1) + "'";
            where += " and zt = " + CmbZtlx.SelectedIndex;
            VybfdwkdrpcTableAdapter1.FillByWhere(DSYBFDWKDR.Vybfdwkdrpc, where);
        }
        #endregion
        #region ExcelToDatatable
        public void ExcelToDatatable(string filePath)
        {
            //ʵ�������ClsCheckAYDRow��
            ClsChecRows aCheckRow = new ClsChecRows();
            using (TextReader tr = new StreamReader(filePath, Encoding.Default))
            {
                int Pcid = 0;
                List<string> CatList = new List<string>();
                Dictionary<int, string> DirCellName = new Dictionary<int, string>();
                try
                {
                    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    Hssfworkbook = new NPOI.HSSF.UserModel.HSSFWorkbook(fs);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("�������", ex);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(PriConStr))
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    try
                    {
                        lstErrors = new List<string>();
                        SqlCommand comm = new SqlCommand();
                        comm.CommandTimeout = 2000;
                        comm.Connection = conn;
                        comm.Transaction = trans;
                        comm.CommandText = string.Format("insert into Tfmsybfdwkdrpc (fln,inssj,insczyid,insczyxm,zt,lx)" +
                     "  values ('{0}','{1}','{2}','{3}','{4}','N');SELECT SCOPE_IDENTITY()", Dgv.CurrentRow.Cells[0].Value, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.xm, "0");
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
                                    lstErrors.Add(sheetsName + "�����ļ��п�ֵ���ʽ����");
                                    break;
                                }
                                //���ݴ���List�е�Excel�ı�ͷ��Ϣ������Insert�����Ҫ������е��ַ���
                                names = ClsQ.Q0("pcid," + string.Join(",", PriListFln), '(');
                                string values = ClsQ.Q0(Pcid + "," + string.Join(",", LstValues), '(') + ";";
                                sb.Append(" Insert into Tfmsybfdwknhdr " + names + " values " + values);
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
                        //����ж��sheet  ��һ�������ȫ���ع�
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
        }
        #endregion
        #region �ļ��ϴ�
        private void BtnToData_Click(object sender, EventArgs e)
        {
            if (Dgv.SelectedRows != null && Dgv.Rows.Count != 0)
            {
                string flName = Dgv.CurrentRow.Cells[0].Value.ToString();
                //ExcelToDatatable(PriFilePath + @"\" + flName);
                ExcelToDatatable(PriFilePath + @"\" + flName);
            }
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
                ScolName = c.StringCellValue.ToString().Trim();
                if (ScolName == "")
                    ScolName = "���۽��";
                if (ScolName != "ƾ֤����" && ScolName != "��ҵ��ˮ��")
                {
                    if (!string.IsNullOrEmpty(ScolName))
                    {
                        PriDrs = PriTydColsDescription.Select("flsm='" + ScolName + "'");
                        if (PriDrs.Length == 1)
                        {
                            PriListFln.Add(PriDrs[0]["fln"].ToString());
                            PriListFlsm.Add(ScolName);
                        }
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
                    LstValue.Add(ClsQ.Q1(null));
                }
                else
                {
                    sValue = c.ToString().Trim();
                    if (alist[i].Equals("���׽��"))
                    {
                        double aJyje;
                        if (double.TryParse(sValue, out aJyje))
                            LstValue.Add(ClsQ.Q1(aJyje.ToString()));
                    }
                    else if (alist[i].Equals("����״̬"))
                    {
                        if (sValue == "�ɹ�")
                            LstValue.Add(ClsQ.Q1("0"));
                        else
                            LstValue.Add(ClsQ.Q1("10"));
                    }
                    else if (alist[i].Equals("����ʱ��"))
                    {
                        DateTime date;
                        if (sValue.Length < 8)
                        {
                            LstValue.Add("NULL");
                        }
                        else
                        {
                            sValue = sValue.Substring(0, 8).ToString();
                            if (DateTime.TryParseExact(sValue,
                                        "yyyyMMdd",
                                       System.Globalization.CultureInfo.InvariantCulture,
                                       System.Globalization.DateTimeStyles.None,
                                       out date))
                            {

                                LstValue.Add(ClsQ.Q1(sValue));
                            }
                            else
                                LstValue.Add("NULL");
                        }
                    }
                    else
                    {
                        LstValue.Add(ClsQ.Q1(sValue.Replace(",", "")));
                    }
                }
            }
            return LstValue;
        }
        #endregion
        #region �ļ�ɾ��
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Dgv.SelectedRows != null && Dgv.Rows.Count != 0)
            {
                ClsMsgBox.YesNo("ȷ��ɾ��" + Dgv.CurrentRow.Cells[0].Value + "��", new EventHandler(DeleteFile));
            }
        }
        #endregion
        #region DeleteFile
        private void DeleteFile(object sender, EventArgs e)
        {
            Form p = sender as Form;
            if (p.DialogResult == DialogResult.Yes)
            {
                File.Delete(PriFilePath + @"\" + Dgv.CurrentRow.Cells[0].Value);
                ImportFileToDgv(PriFilePath);
            }
        }
        #endregion
        #region ����
        private void Bnt_dc_Click_1(object sender, EventArgs e)
        {
            if (DGVDRxx.RowCount == 0)
                return;
            ClsExcel.CreatExcel(DGVDRxx, "�˱��ѵ�λ��ƥ����Ϣ", this.ctrlDownLoad1);
        }
        #endregion
        #region ƥ���¼�
        private void DGVDRxx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 4)
                return;
            if (e.ColumnIndex == 4)
            {
                YBFDWKDR.DSYBFDWKDR.VybfdwkdrpcRow row = ((DataRowView)Bds.Current).Row as YBFDWKDR.DSYBFDWKDR.VybfdwkdrpcRow;
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

                FrmYBFDWKMX f = new FrmYBFDWKMX();
                f.Prepare(PriRow.id, "N");
                f.ShowDialog();
            }
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
                    YBFDWKDR.DSYBFDWKDR.VybfdwkdrpcRow pcrow = ((DataRowView)Bds.Current).Row as YBFDWKDR.DSYBFDWKDR.VybfdwkdrpcRow;
                    //���ݻ�ȡ�Ļ�����Ϣ��ѯδ���(zt)δƥ��(ppzt)���ձ���Ϣ,����ʱ��(��������)�ͽ��(��������)��������
                    DataTable table_rbpcs = ClsRWMSSQLDb.GetDataTable(" SELECT a.id,b.zh,b.zhmc,a.ckbz,a.dkje,a.inssj,convert(int,convert(nvarchar(20),a.inssj,112)) as sj FROM dbo.Tfmsrbpc AS a INNER JOIN  tfmsyhzh AS b ON a.jgid=b.jgid WHERE a.zt=0 AND a.ppzt=0 AND  b.yhlxid=241 AND b.zhlxid=1 AND b.zt=0 and a.spjgid=" + PriSpjgid + " and b.zh in( SELECT jyyt  FROM dbo.Tfmsybfdwknhdr WHERE pcid= " + pcrow.id + ")  ORDER BY sj asc,a.dkje  desc", ClsGlobals.CntStrTMS);
                    TfmsybfdwknhdrTableAdapter.FillByPCid(DSYBFDWKDR.Tfmsybfdwknhdr, pcrow.id);
                    com.CommandText += " Update Tfmsybfdwkdrpc set zt = 1 where id =" + pcrow.id + " ;";
                    com.ExecuteNonQuery();
                    foreach (YBFDWKDR.DSYBFDWKDR.TfmsybfdwknhdrRow row in DSYBFDWKDR.Tfmsybfdwknhdr)
                    {
                        if (!row.IsjysjNull())
                        {
                            if (row.IssrjeNull())
                            {
                                com.CommandText = " Update Tfmsybfdwknhdr set zt = 10 where id =" + row.id;
                                com.ExecuteNonQuery();
                                PriFailure++;
                            }
                            else
                            {
                                if (row.srje == 0)
                                {
                                    com.CommandText = " Update Tfmsybfdwknhdr set zt = 10 where id =" + row.id;
                                    com.ExecuteNonQuery();
                                    PriFailure++;
                                }
                                else
                                {
                                    //���������˺ţ�״̬��Чzt����������yjlx���˺�����zhlxid��Ѱ�һ�����Ϣ�����ݻ�ȡ�Ļ�����Ϣ��ѯδ���(zt)δƥ��(ppzt)���ձ���Ϣ,����ʱ��(��������)�ͽ��(��������)��������
                                    decimal d = Convert.ToDecimal(row.srje);
                                    //�жϽ�������֮ǰ�Ƿ��з��ϵĽɿ��ձ�,����н����߼�����(ƥ����߼��Ǹ���Tfmsybfdwknhdr���е�rbpcid,dkje,cyje��zt������Tfmsrbpc��ppztһ��) 
                                    DataRow[] rows_rbpc = table_rbpcs.Select(string.Format(" sj<{0} and dkje<={1}  and zh='{2}' ", Convert.ToInt32(row.jysj.ToString("yyyyMMdd")), row.srje, row.jyyt));
                                    decimal Pricyje = 0;
                                    int rowCouts = rows_rbpc.Length;
                                    bool abool = true;
                                    if (rowCouts > 0)
                                    {
                                        int count = 0;//��¼�Ƿ���ƥ��� 
                                        DataRow rows_top = rows_rbpc[0];
                                        int rbpcid = Convert.ToInt32(rows_top["id"].ToString());
                                        decimal dkje = Convert.ToDecimal(rows_top["dkje"].ToString());//���۽��
                                        Pricyje = Convert.ToDecimal(d - dkje);
                                        com.CommandText = "Update Tfmsrbpc set ppzt = 5 where id =" + rbpcid + " ;"; //�޸��ձ�����ƥ��״̬Ϊƥ��ɹ�
                                        com.CommandText += " Update  Tfmsybfdwknhdr set zt = 5,dkje=" + dkje + ",cyje=" + Pricyje + ",rbpcid =" + rbpcid + " where id =" + row.id + " ;";
                                        com.ExecuteNonQuery();
                                        PriSucceed++;
                                        count++;
                                    }
                                    //���û�����жϵ����Ƿ��з��ϵĽɿ��ձ���ƥ����߼��Ǹ���Tfmsybfdwknhdr���е�rbpcid,dkje,cyje��zt������Tfmsrbpc��ppztһ�У�
                                    else
                                    {

                                        string datejysq = row.jysj.AddDays(1).ToString("yyyyMMdd");
                                        rows_rbpc = table_rbpcs.Select(string.Format(" sj>='{0}'  and sj<'{2}' and dkje<={1} and zh='{3}' ", Convert.ToInt32(row.jysj.ToString("yyyyMMdd")), row.srje, Convert.ToInt32(datejysq), row.jyyt));
                                        rowCouts = rows_rbpc.Length;
                                        if (rowCouts > 0)
                                        {
                                            int count = 0;//��¼�Ƿ���ƥ���
                                            DataRow rows_top = rows_rbpc[0];
                                            int rbpcid = Convert.ToInt32(rows_top["id"].ToString());
                                            decimal dkje = Convert.ToDecimal(rows_top["dkje"].ToString());//���۽��
                                            Pricyje = Convert.ToDecimal(d - dkje);
                                            com.CommandText = "Update Tfmsrbpc set ppzt = 5 where id =" + rbpcid + " ;"; //�޸��ձ�����ƥ��״̬Ϊƥ��ɹ� 
                                            com.CommandText += " Update  Tfmsybfdwknhdr set zt = 5,dkje=" + dkje + ",cyje=" + Pricyje + ",rbpcid =" + rbpcid + " where id =" + row.id + " ;";
                                            com.ExecuteNonQuery();
                                            PriSucceed++;
                                            count++;
                                        }
                                        //�������û��ֻ����  Tfmsybfdwknhdr���е�zt
                                        else
                                        {
                                            com.CommandText = " Update Tfmsybfdwknhdr set zt = 10 where id =" + row.id;
                                            com.ExecuteNonQuery();
                                            PriFailure++;
                                            abool = false;
                                        }
                                    }
                                    if (abool)
                                        table_rbpcs.Rows.Remove(rows_rbpc[0]);
                                }
                            }
                        }
                        else
                        {
                            com.CommandText = " Update Tfmsybfdwknhdr set zt = 10 where id =" + row.id;
                            com.ExecuteNonQuery();
                            PriFailure++;
                        }
                    }
                    ClsMsgBox.Ts("��" + DSYBFDWKDR.Tfmsybfdwknhdr.Rows.Count + "����ƥ��ɹ�" + PriSucceed + "����ʧ��" + PriFailure + "����", ObjG.CustomMsgBox, this);
                    Bds.RemoveCurrent();
                    trans.Commit();
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
        #endregion
        #region �����տ��ձ���
        private void BntDcskrbb_Click(object sender, EventArgs e)
        {
            if (PriRow == null)
            {
                ClsMsgBox.Ts("��ѡ��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "�˱��ѵ�λ���տ��ձ���";//�ļ�����    
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
                DataTable dt = ClsRWMSSQLDb.GetDataTable(@"SELECT  DISTINCT c.dqmc,c.jgmc,a.jyyt,a.dfhm,a.jysj,a.srje,a.dkje,a.cyje,(CASE WHEN a.zt=0 THEN 'δƥ��' WHEN a.zt=5 THEN '���' 
WHEN a.zt=10 THEN '����'end)AS zts,a.zt,a.id FROM dbo.Tfmsybfdwknhdr AS a Left JOIN Tfmsrbpc  AS b 
  ON   a.rbpcid=b.id left JOIN vfmsyhzh AS c ON b.jgid=c.jgid   where a.pcid=" + PriRow.id + "  order by a.zt desc , c.jgmc", ClsGlobals.CntStrTMS);

                decimal SumDSKje = dt.AsEnumerable().Sum(r => r.Field<decimal>("srje"));
                //ģ��·��
                string priModel = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath + @"App_Data\ModelExcel\FMS", "YbfDwknhdr.xls");
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
                string jysj = "";
                string dqmc = "";
                string jgmc = "";
                string dfzh = "";
                double srje = 0;
                string dkje = "";
                string cyje = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    jysj = dt.Rows[i]["jysj"].ToString();
                    dqmc = dt.Rows[i]["dqmc"].ToString(); 
                    jgmc = dt.Rows[i]["jgmc"].ToString();
                    dfzh = dt.Rows[i]["jyyt"].ToString();
                    srje = Convert.ToDouble(dt.Rows[i]["srje"].ToString());
                    dkje = dt.Rows[i]["dkje"].ToString();
                    cyje = dt.Rows[i]["cyje"].ToString();
                    HSSFRow r = (HSSFRow)hssfSheet.CreateRow(rowIndex);
                    Cell c0 = r.CreateCell(0);
                    Cell c1 = r.CreateCell(1);
                    Cell c2 = r.CreateCell(2);
                    Cell c3 = r.CreateCell(3);
                    Cell c4 = r.CreateCell(4);
                    Cell c5 = r.CreateCell(5);
                    Cell c6 = r.CreateCell(6);
                    Cell c7 = r.CreateCell(7);
                    //������ݺ�������ʽ
                    c0.SetCellValue(i + 1);
                    c0.CellStyle = cellStyle1;
                    
                    c1.SetCellValue(jysj);
                    c2.SetCellValue(dqmc);
                    c3.SetCellValue(jgmc);
                    c4.SetCellValue(srje);
                    c5.SetCellValue(dfzh); 
                    c6.SetCellValue(dkje);
                    c7.SetCellValue(cyje);
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
                //     ��     ��     ϵͳʵ�˱��ѽ��           Ԫ       �˶Բ��� ��
                HSSFRow Tj = (HSSFRow)hssfSheet.CreateRow(rowIndex);
                Cell Tj0 = Tj.CreateCell(0);
                Hjc1.SetCellValue("     ��     ��     ϵͳʵ�˱��ѽ��           Ԫ       �˶Բ��� ��");
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
        #endregion
    }
}
