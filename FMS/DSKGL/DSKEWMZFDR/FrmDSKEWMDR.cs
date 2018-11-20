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
using System.Configuration;
using System.IO;
using NPOI.SS.Util;
using NPOI.HSSF.UserModel;
using FMS.CWGL.YBFNHDR;
using System.Data.SqlClient;
using JYPubFiles.Classes;
using System.Collections;
using NPOI.SS.UserModel;
using System.Web;

#endregion

namespace FMS.DSKGL.DSKEWMZFDR
{
    public partial class FrmDSKEWMDR : UserControl
    {
        private ClsG ObjG;
        private string PriConStr;
        private string PriConStrKj;
        private int PriSpjgid;
        private DataTable PriTydColsDescription;
        private string PriFilePath;//�ļ�·��
        private HSSFWorkbook Hssfworkbook;
        private string[] PriExtention = { ".xls" };//�����ϴ����ļ�����չ����
        List<string> LstFiles = new List<string>();
        private List<string> PriListFln;//����
        private List<string> PriListFlsm;//��˵��
        private int PriSucceed; //��¼ƥ��ɹ�����
        private int PriFailure;//��¼ʧ������
        List<string> lstErrors;//��¼�д���
        private string ScolName;//�����洢Excel����
        private DataRow[] PriDrs;
        private DSDKSEWMZFDR.VdskewmdrpcRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as DSDKSEWMZFDR.VdskewmdrpcRow;
                }
            }
        }

        public FrmDSKEWMDR()
        {
            InitializeComponent();
        }

        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            PriConStr = ClsGlobals.CntStrTMS;
            PriConStrKj = ClsGlobals.CntStrKj;
            PriSpjgid = ObjG.Jigou.id;
            CmbZtlx.SelectedIndex = 0;
            //��ñ��˵����ֵ��DataTable
            PriTydColsDescription = ClsRWMSSQLDb.GetColDescription("Tfmsdskewmdrmx", PriConStr);
            //����ļ���·��
            PriFilePath = Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), ClsOptions.WebCfg.DSKDWKNHFilePath + DateTime.Now.ToString("yyyyMM"));
            if (!Directory.Exists(PriFilePath))
                Directory.CreateDirectory(PriFilePath);
            //��ָ��·���µ��ļ���ʾ��ListBox��
            ImportFileToDgv(PriFilePath);
            //�Զ����ϴ��ļ�·��,�����Զ���ؼ����Prepare����
            //PriUploadFoldr = ClsOptions.WebCfg.PosXlsFilePath + DateTime.Now.ToString("yyyyMM");
            ctrlUploadFile1.Prepare(PriFilePath, PriExtention, false, "�����ļ�");
            ImportFileToDgv(PriFilePath);
            ctrlUploadFile1.PrepareA(new JY.CtrlPub.ImportToDB(DgvAddFile));
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

        #region �������ݿ�
        private void BtnToData_Click(object sender, EventArgs e)
        {
            if (Dgv.SelectedRows != null && Dgv.Rows.Count != 0)
            {
                string flName = Dgv.CurrentRow.Cells[0].Value.ToString();
                //ExcelToDatatable(PriFilePath + @"\" + flName);
                ExcelToDatatable(PriFilePath + @"\" + flName);
            }
        }

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
                        comm.CommandText = string.Format("insert into Tfmsdskewmdrpc (fln,inssj,insczyid,insczyxm,zt)" +
                     "  values ('{0}','{1}','{2}','{3}','{4}');SELECT SCOPE_IDENTITY()", Dgv.CurrentRow.Cells[0].Value, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.xm, "0");
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
                            HSSFRow headerRow = (HSSFRow)hssfsheet.GetRow(0);
                            HSSFRow row = (HSSFRow)hssfsheet.GetRow(0);
                            GetFldLst(row);
                            if (PriListFln.Count == 0)
                            {
                                lstErrors.Add(sheetsName + "�ļ���ͷ��ʽ����");
                                continue;
                            }
                            StringBuilder sb = new StringBuilder();
                            //ѭ������Excel�г��˵ڶ���֮�������������
                            for (int i = hssfsheet.FirstRowNum + 1; i <= hssfsheet.LastRowNum; i++)
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
                                sb.Append(" Insert into Tfmsdskewmdrmx " + names + " values " + values);
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

        #region GetFldLst() Excel
        private void GetFldLst(HSSFRow headerRow)
        {
            PriListFlsm = new List<string>();
            PriListFln = new List<string>();
            //ʹ��foreach�������м���Dictionary
            foreach (HSSFCell c in headerRow.Cells)
            {
                ScolName = c.StringCellValue.ToString().Trim();
                if (!string.IsNullOrEmpty(ScolName))
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
                    if (alist[i].Equals("���"))
                    {
                        double aJyje;
                        if (double.TryParse(sValue, out aJyje))
                            LstValue.Add(ClsQ.Q1(aJyje.ToString()));
                    }
                    else if (alist[i].Equals("֧��ʱ��"))
                    {
                        DateTime date;
                        if (sValue.Length < 8)
                        {
                            LstValue.Add("NULL");
                        }
                        else
                        {
                            sValue = sValue.Substring(0, 10).Replace("-", "").ToString();
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
        #endregion �������ݿ�

        #region �ϴ��ļ�ɾ��
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Dgv.SelectedRows != null && Dgv.Rows.Count != 0)
            {
                ClsMsgBox.YesNo("ȷ��ɾ��" + Dgv.CurrentRow.Cells[0].Value + "��", new EventHandler(DeleteFile));
            }
        }

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
        #endregion �ϴ��ļ�ɾ��

        #region ��ѯ
        private void BtnQuiry_Click(object sender, EventArgs e)
        {
            string where = " where  inssj >= '" + DtpStart.Value.Date + "' and inssj < '" + DtpStop.Value.AddDays(1) + "'";
            where += " and zt = " + CmbZtlx.SelectedIndex;
            VdskewmdrpcTableAdapter1.FillByWhere(Dsdksewmzfdr1.Vdskewmdrpc, where);
        }
        #endregion ��ѯ

        #region ��֤
        private void Btn_Chk_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
            {
                ClsMsgBox.Ts("��ѡ��Ҫ��֤����Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            DSDKSEWMZFDR.VdskewmdrpcRow RowCurrent = ((DataRowView)Bds.Current).Row as DSDKSEWMZFDR.VdskewmdrpcRow;
            if (RowCurrent.zt != 0)
            {
                ClsMsgBox.Ts("����Ϣ�Ѿ���֤����", ObjG.CustomMsgBox, this);
                return;
            }
            try
            {
                string cmdText = "Pdr_dskewmzf_jc";
                int mxCounts; int RowsCounts;
                ArrayList alst = new ArrayList();
                alst.Add(new SqlParameter("@pcid", RowCurrent.id));
                alst.Add(new SqlParameter("@mxCounts", SqlDbType.Int, 4));
                alst.Add(new SqlParameter("@RowsCounts", SqlDbType.Int, 4));
                ((SqlParameter)alst[1]).Direction = ParameterDirection.Output;
                ((SqlParameter)alst[2]).Direction = ParameterDirection.Output;
                ClsRWMSSQLDb.ExecuteCmd(cmdText, PriConStr, alst, true);
                if (!int.TryParse(((SqlParameter)alst[1]).Value.ToString(), out mxCounts))
                    mxCounts = 0;
                if (!int.TryParse(((SqlParameter)alst[2]).Value.ToString(), out RowsCounts))
                    RowsCounts = 0;
                ClsMsgBox.Ts(string.Format("�˴���֤��{0}��,���гɹ���鹲{1}���������쳣��{2}����", mxCounts, mxCounts - RowsCounts, RowsCounts), ObjG.CustomMsgBox, this);

                Bds.RemoveCurrent();
            }
            catch (Exception ex)
            {
                ClsMsgBox.Ts("��֤�쳣��ԭ��" + ex.Message, ObjG.CustomMsgBox, this);
            }
        }
        #endregion ��֤

        #region ƥ��
        private void DGVDRxx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 3)
                return;
            if (e.ColumnIndex == 3)
            {
                DSDKSEWMZFDR.VdskewmdrpcRow row = ((DataRowView)Bds.Current).Row as DSDKSEWMZFDR.VdskewmdrpcRow;
                if (row.zt < 2)
                {
                    ClsMsgBox.Ts("ֻ����֤ͨ���Ĳ��ܽ���ƥ�䣡", ObjG.CustomMsgBox, this);
                    return;
                }
                if (row.zt == 3)
                {
                    ClsMsgBox.Ts("����Ϣ��ƥ�䣡", ObjG.CustomMsgBox, this);
                    return;
                }
                else if (row.zt == 2)
                    PosMatching();
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
                    DSDKSEWMZFDR.VdskewmdrpcRow pcrow = ((DataRowView)Bds.Current).Row as DSDKSEWMZFDR.VdskewmdrpcRow;
                    //TfmsdskewmdrhzTableAdapter1.FillByPcid(Dsdksewmzfdr1.Tfmsdskewmdrhz, pcrow.id);
                    TfmsdskewmdrmxTableAdapter1.FillByPcId(Dsdksewmzfdr1.Tfmsdskewmdrmx, pcrow.id);
                    //����jgid��ѯδ��ˡ���ά��֧����ϵͳδƥ����ձ������������ա�����ʽ��������
                    DataTable dtrb = ClsRWMSSQLDb.GetDataTable(string.Format(@"SELECT a.id,b.ydid,dkje FROM dbo.Tfmsdskjkpc AS a INNER JOIN tfmsdskjkmx AS b ON a.id=b.pcid INNER JOIN tfmsdskewmdrmx AS c ON b.ydid=c.ydid AND c.pcid={0} WHERE a.zt=10 AND a.zflx=2 AND xtppzt=0 AND  spjgid={1}", pcrow.id, ObjG.Jigou.id), PriConStr);
                    int rbgs = dtrb.Rows.Count;
                    if (rbgs == 0)
                    {
                        ClsMsgBox.Ts("���ձ�����ƥ�䣡");
                        return;
                    }
                    com.CommandText = "UPDATE dbo.Tfmsdskewmdrpc SET zt=3 WHERE id=" + pcrow.id;
                    com.ExecuteNonQuery();
                    foreach (DSDKSEWMZFDR.TfmsdskewmdrmxRow row in Dsdksewmzfdr1.Tfmsdskewmdrmx)
                    {
                        decimal je = row.dskje;//Ҫƥ��Ľ������
                        int ydid = row.ydid;   //Ҫƥ����˵�
                        //ѭ����ѯ���ƥ�䣬�޸�ƥ�������ͽ�������ϸ
                        for (int i = dtrb.Rows.Count - 1; i >= 0; i--)
                        {
                            decimal dkje = Convert.ToDecimal(dtrb.Rows[i]["dkje"]);//�ձ����
                            int rbid = Convert.ToInt32(dtrb.Rows[i]["id"]);        //�ձ���Id
                            int rbydid = Convert.ToInt32(dtrb.Rows[i]["ydid"]);    //�ձ���Ӧ�˵�
                            if (ydid == rbydid)//�ҵ��˵���Ӧ�ձ�
                            {
                                if (je == dkje)
                                {
                                    com.CommandText = string.Format(@"INSERT INTO dbo.Tfmsdskewmppmx(hzid,rbpcid,rbje,zt)VALUES({0},{1},{2},{3})", row.id, rbid, dkje, 1);
                                    com.CommandText += string.Format(@"UPDATE Tfmsdskjkpc SET xtppzt=5 WHERE id={0}", rbid);
                                    PriSucceed++;
                                }
                                else
                                {
                                    com.CommandText = string.Format(@"INSERT INTO dbo.Tfmsdskewmppmx(hzid,rbpcid,rbje,zt)VALUES({0},{1},{2},{3})", row.id, rbid, dkje, 0);
                                    com.CommandText += string.Format(@"UPDATE Tfmsdskjkpc SET xtppzt=10 WHERE id={0}", rbid);
                                }
                                com.ExecuteNonQuery();
                                break;
                            }
                        }
                    }
                    //����7500Ԫ������ѯ��1���ձ�������ƥ��ɹ�0��
                    ClsMsgBox.Ts("����" + Dsdksewmzfdr1.Tfmsdskewmdrmx.Sum(p => p.dskje) + "Ԫ������ѯ��" + rbgs + "���ձ�������ƥ��ɹ�" + PriSucceed + "����ʧ��" + (rbgs - PriSucceed) + "��", ObjG.CustomMsgBox, this);
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
        #endregion ƥ��

        #region ɾ��
        private void Btn_Del_Click(object sender, EventArgs e)
        {
            if (DGVDRxx.SelectedRows != null && DGVDRxx.Rows.Count != 0)
            {
                ClsMsgBox.YesNo("ȷ��ɾ��" + DGVDRxx.CurrentRow.Cells[0].Value + "��", new EventHandler(Delete));
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            FrmMsgBox frm = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult != DialogResult.Yes)
            {
                return;
            }
            else
            {
                int pcid = Convert.ToInt32(DGVDRxx.CurrentRow.Cells[DgvColTxtPcid.Name].Value);
                string SqlStr = string.Format(" DELETE FROM tfmsdskewmppmx WHERE hzid IN(SELECT id FROM Tfmsdskewmdrmx WHERE pcid={0}); DELETE FROM Tfmsdskewmdrmx WHERE pcid={0};UPDATE dbo.Tfmsdskewmdrpc SET zt=4 WHERE id={0}", pcid);
                try
                {
                    ClsRWMSSQLDb.ExecuteCmd(SqlStr, ClsGlobals.CntStrTMS);
                    ClsMsgBox.Ts("ɾ���ɹ���", frm, this);
                    BtnQuiry.PerformClick();
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("ɾ��ʧ�ܣ�", ex, frm, this);
                }
            }
        }
        #endregion ɾ��

        #region ����
        private void Bnt_dc_Click(object sender, EventArgs e)
        {
            if (DGVDRxx.RowCount == 0)
                return;
            ClsExcel.CreatExcel(DGVDRxx, "������Ϣ", this.ctrlDownLoad1);
        }
        #endregion ����

        #region ������֤��Ϣ
        private void Btn_DcYzxx_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            DSDKSEWMZFDR.VdskewmdrpcRow RowCurrent = ((DataRowView)Bds.Current).Row as DSDKSEWMZFDR.VdskewmdrpcRow;
            List<string> LsCell = new List<string>();//��ͷ
            LsCell.Add("����");
            LsCell.Add("������");
            LsCell.Add("����");
            LsCell.Add("���տ���");
            LsCell.Add("֧����ʽ");
            LsCell.Add("֧��ʱ��");
            LsCell.Add("��������");
            string SQLStr = "SELECT dqmc,jgmc,dh,dskje,zflx,zfsj,cw FROM dbo.Tfmsdskewmdrmx WHERE pcid=" + RowCurrent.id;
            DataTable dt = ClsRWMSSQLDb.GetDataTable(SQLStr, ClsGlobals.CntStrTMS);
            if (dt.Rows.Count > 0)
            {
                CreatExcel_Data(dt, LsCell, "��֤�����Ϣ", ctrlDownLoad1);
            }

        }
        #endregion ������֤��Ϣ

        private void CreatExcel_Data(DataTable Dt, List<string> Dt_List, string FileName, JY.CtrlPub.CtrlDownLoad DownLoad)
        {
            string PriFln = FileName + DateTime.Now.ToString("yyyyMMddHHmmssmm") + ".xls";//�ļ�����     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
            //д������
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.DefaultColumnWidth = 17;
            try
            {
                //�����ĵ�����
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                LieFont.FontHeightInPoints = 10;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.SetFont(LieFont);
                HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                HSSFCellStyle cellStyle2 = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle2.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                HSSFCellStyle cellStyle3 = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle3.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00%");
                for (int i = 0; i < Dt_List.Count; i++)
                {
                    row0.CreateCell(i).SetCellValue(Dt_List[i].ToString());
                    row0.Cells[i].CellStyle = styleRow;
                }
                int roowIndex = 1;
                //�������
                foreach (DataRow row in Dt.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    for (int i = 0; i < Dt.Columns.Count; i++)
                    {
                        if (!String.IsNullOrEmpty(row[i].ToString()))
                        {
                            double j;
                            if (row[i].ToString().Contains("%"))
                            {
                                hssfrow.CreateCell(i).SetCellValue(row[i].ToString());
                                hssfrow.Cells[i].CellStyle = cellStyle3;
                                //hssfrow.Cells[i - m].SetCellValue(Row.Cells[i].Value);
                            }
                            else if (double.TryParse(row[i].ToString(), out j))
                            {
                                if (row[i].ToString().Contains("."))
                                {
                                    hssfrow.CreateCell(i).SetCellValue(Convert.ToDouble(row[i].ToString()));
                                    hssfrow.Cells[i].CellStyle = cellStyle;
                                }
                                else
                                {
                                    hssfrow.CreateCell(i).SetCellValue(Convert.ToDouble(row[i].ToString()));
                                    hssfrow.Cells[i].CellStyle = cellStyle2;
                                }
                            }
                            else
                            {
                                hssfrow.CreateCell(i).SetCellValue(row[i].ToString());
                            }
                        }
                        else
                        {
                            hssfrow.CreateCell(i).SetCellValue("");
                        }
                    }
                    roowIndex++;
                }
                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
                file.Dispose();
                DownLoad.download(PriFlp, true);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("����Excelʧ��", ex);
            }
            finally
            {
                sheet1.Dispose();
                hssfworkbook.Dispose();

            }
        }

        #region ����ƥ����
        private void BntDcskrbb_Click(object sender, EventArgs e)
        {

            if (PriRow == null)
            {
                ClsMsgBox.Ts("��ѡ��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "���տ��ά�뵼��ƥ����";//�ļ�����    
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
                //DataTable dt = ClsRWMSSQLDb.GetDataTable(@"SELECT c.dqmc,d.mc AS jgmc,je,'��ά��֧��' as zflx,b.rbje,CASE WHEN b.zt=0 THEN '�����' WHEN b.zt=1 THEN '���' END AS zts,a.id,a.rbgs FROM dbo.Tfmsdskewmdrhz AS a INNER JOIN dbo.Tfmsdskewmppmx AS b ON b.hzid = a.id INNER JOIN jyjckj.dbo.Vdqjigou AS c ON c.dqid=a.dqid INNER JOIN jyjckj.dbo.tjigou AS d ON d.id=a.jgid where a.pcid=" + PriRow.id + " order by a.id", ClsGlobals.CntStrTMS);
                DataTable dt = ClsRWMSSQLDb.GetDataTable("SELECT dqmc,jgmc,dh,dskje,ydbh,rbje,CASE WHEN b.zt=1 THEN '���' WHEN b.zt=0 THEN '�����' ELSE '���ձ�' END  AS ppzt,d.zfsj  FROM tfmsdskewmdrmx AS a LEFT JOIN tfmsdskewmppmx AS b ON a.id=b.hzid LEFT JOIN tfmsdskjkpc AS c ON b.rbpcid=c.id LEFT JOIN tfmsdsk AS d ON a.ydid=d.ydid WHERE a.pcid=" + PriRow.id, ClsGlobals.CntStrTMS);
                decimal SumJzje = dt.AsEnumerable().Sum(r => r.Field<decimal>("dskje"));
                decimal SumXfje=dt.AsEnumerable().Where(r=>r.Field<string>("ppzt").Equals("���")).Sum(r=>r.Field<decimal>("rbje"));
                //ģ��·��
                string priModel = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath + @"App_Data\ModelExcel\FMS", "DskEwmdr.xls");
                //����ģ���ȡIO��
                FileStream fileStreamRead = new FileStream(priModel, FileMode.Open, FileAccess.Read);
                //����������XLS����
                HSSFWorkbook hssfwork = new HSSFWorkbook(fileStreamRead);
                HSSFSheet hssfSheet = hssfwork.GetSheetAt(0) as HSSFSheet;
                HSSFRow hssfRow = hssfSheet.GetRow(0) as HSSFRow;
                HSSFCell hssfCell = hssfRow.GetCell(0) as HSSFCell;

                #region ��ʽ
                #region ������ʽ
                HSSFCellStyle cellStyle1 = (HSSFCellStyle)hssfwork.CreateCellStyle();
                cellStyle1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                cellStyle1.BorderBottom = CellBorderType.THIN;
                cellStyle1.BorderTop = CellBorderType.THIN;
                cellStyle1.BorderLeft = CellBorderType.THIN;
                cellStyle1.BorderRight = CellBorderType.THIN;
                #endregion
                #region ˫��������
                HSSFCellStyle cellStyle2 = (HSSFCellStyle)hssfwork.CreateCellStyle();
                cellStyle2.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                cellStyle2.BorderBottom = CellBorderType.THIN;
                cellStyle2.BorderTop = CellBorderType.THIN;
                cellStyle2.BorderLeft = CellBorderType.THIN;
                cellStyle2.BorderRight = CellBorderType.THIN;
                #endregion

                #endregion

                HSSFRow row = (HSSFRow)hssfSheet.CreateRow(0);
                row.CreateCell(0).SetCellValue(DateTime.Now.ToString("yyyy��MM��dd��") + "��³��������֧������");
                row.Cells[0].CellStyle = cellStyle1;
                /**�������**/
                int rowIndex = 2;
                //int hzid = 0, rbsl = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //int ahzid = Convert.ToInt32(dt.Rows[i]["id"]);
                    //int arbsl = Convert.ToInt32(dt.Rows[i]["rbgs"]);
                    //if (hzid == ahzid)
                    //{
                    //    rbsl = rbsl - 1;
                    //}
                    //else
                    //{
                    //    hzid = ahzid;
                    //    rbsl = arbsl;
                    //}
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
                    c0.SetCellValue(dt.Rows[i]["dqmc"].ToString());
                    c0.CellStyle = cellStyle1;
                    c1.SetCellValue(dt.Rows[i]["jgmc"].ToString());
                    c1.CellStyle = cellStyle1;
                    c2.SetCellValue(dt.Rows[i]["dh"].ToString());
                    c2.CellStyle = cellStyle1;
                    c3.SetCellValue(Convert.ToDouble(dt.Rows[i]["dskje"].ToString()));
                    c3.CellStyle = cellStyle2;
                    c4.SetCellValue(dt.Rows[i]["ydbh"].ToString());
                    c4.CellStyle = cellStyle1;
                    if (!string.IsNullOrEmpty(dt.Rows[i]["rbje"].ToString()))
                    {
                        c5.SetCellValue(Convert.ToDouble(dt.Rows[i]["rbje"].ToString()));
                        c5.CellStyle = cellStyle2;
                    }
                    c6.SetCellValue(dt.Rows[i]["ppzt"].ToString());
                    c6.CellStyle = cellStyle1;
                    c7.SetCellValue(dt.Rows[i]["zfsj"].ToString());
                    c7.CellStyle = cellStyle1;
                    rowIndex++;
                }
                //�ϼ�   
                HSSFRow hj = (HSSFRow)hssfSheet.CreateRow(rowIndex);
                hssfSheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 0, 2));
                Cell Hjc0 = hj.CreateCell(0);
                Cell Hjc3 = hj.CreateCell(3);
                Cell Hjc4 = hj.CreateCell(4);
                Cell Hjc5 = hj.CreateCell(5);
                Hjc0.SetCellValue("���˺ϼƣ�");
                Hjc0.CellStyle = cellStyle1;
                hj.CreateCell(1).CellStyle = cellStyle1;
                hj.CreateCell(2).CellStyle = cellStyle1;
                hj.CreateCell(6).CellStyle = cellStyle1;
                hj.CreateCell(7).CellStyle = cellStyle1;
                Hjc3.SetCellValue(SumJzje.ToString());
                Hjc3.CellStyle = cellStyle2;
                Hjc4.SetCellValue("����ϼƣ�");
                Hjc4.CellStyle = cellStyle1;
                Hjc5.SetCellValue(SumXfje.ToString());
                Hjc5.CellStyle = cellStyle2;
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
        #endregion ��������ƥ����

    }
}
