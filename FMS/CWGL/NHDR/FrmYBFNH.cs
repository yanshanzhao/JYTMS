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
#endregion

namespace FMS.CWGL.NHDR
{
    public partial class FrmYBFNH : UserControl
    {
        #region 成员变量
        private string PriConStr;
        private string PriConStrKj;
        private ClsG ObjG;
        private string PriFilePath;//文件路径
        private string[] PriExtention = { ".xls" };//允许上传的文件的扩展类型
        //private string PriUploadFoldr;//文件上传到的目的文件夹
        List<string> LstFiles = new List<string>();
        private HSSFWorkbook Hssfworkbook;
        private DataTable PriTydColsDescription;
        private string ScolName;//用来存储Excel列名
        private DataRow[] PriDrs;
        private List<string> PriListFln;//列名
        private List<string> PriListFlsm;//列说明
        List<string> lstErrors;//记录行错误
        private int PriSucceed; //记录匹配成功条数
        private int PriFailure;//记录失败条数
        private string PriName;
        private List<string> Prirbid = new List<string>();
        private DSNHDR.VfmsybfdrpcRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as DSNHDR.VfmsybfdrpcRow;
                }
            }
        }
        #endregion
        public FrmYBFNH()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            PriConStr = ClsGlobals.CntStrTMS;
            PriConStrKj = ClsGlobals.CntStrKj;
            //获得表的说明赋值给DataTable
            PriTydColsDescription = ClsRWMSSQLDb.GetColDescription("tfmsybfnhdrmx", PriConStr);
            //获得文件的路径
            PriFilePath = Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), ClsOptions.WebCfg.YBFNHXlsFilePath + DateTime.Now.ToString("yyyyMM"));
            if (!Directory.Exists(PriFilePath))
                Directory.CreateDirectory(PriFilePath);
            //将指定路径下的文件显示在ListBox中
            ImportFileToDgv(PriFilePath);
            //自定义上传文件路径,调用自定义控件里的Prepare方法
            //PriUploadFoldr = ClsOptions.WebCfg.PosXlsFilePath + DateTime.Now.ToString("yyyyMM");
            ctrlUploadFile1.Prepare(PriFilePath, PriExtention, false, "导入文件");
            ImportFileToDgv(PriFilePath);
            ctrlUploadFile1.PrepareA(new JY.CtrlPub.ImportToDB(DgvAddFile));
            CmbZtlx.SelectedIndex = 0; 
            this.VfmsybfdrpcTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }
        #region 将存放上传文件的文件夹里的文件名存入DataGridview中
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
        #region  增加新增的文件并选中
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
                ClsMsgBox.Cw("导入错误！", ex);
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
                    // 插入批次信息，获得pcid
                    string cmdText = string.Format("insert into tfmsybfdrpc (fln,inssj,insczyid,insczyxm,zt,lx)" +
                        "  values ('{0}','{1}','{2}','{3}','{4}','N');SELECT SCOPE_IDENTITY()", Dgv.CurrentRow.Cells[0].Value, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.xm, "0");
                    comm.CommandText = cmdText;
                    Pcid = Convert.ToInt32(comm.ExecuteScalar());
                    int sheets = Hssfworkbook.NumberOfSheets;//获取有多少个sheet
                    for (int n = 0; n < sheets; n++)
                    {
                        DirCellName.Clear();
                        string names = "";
                        //获取Excel的第一个sheet
                        HSSFSheet hssfsheet = (HSSFSheet)Hssfworkbook.GetSheetAt(n);
                        string sheetsName = hssfsheet.SheetName;
                        if (hssfsheet.LastRowNum < 1)
                            break;
                        //获取Excel的首行，即第二行
                        HSSFRow headerRow = (HSSFRow)hssfsheet.GetRow(1);
                        HSSFRow row = (HSSFRow)hssfsheet.GetRow(1);
                        GetFldLst(row);
                        if (PriListFln.Count == 0)
                        {
                            lstErrors.Add(sheetsName + "文件表头格式错误！");
                            continue;
                        }
                        StringBuilder sb = new StringBuilder();
                        //循环遍历Excel中除了第二行之外的所有数据行
                        for (int i = hssfsheet.FirstRowNum + 2; i <= hssfsheet.LastRowNum; i++)
                        {
                            row = (HSSFRow)hssfsheet.GetRow(i);
                            List<string> LstValues = RowToValue(row, PriListFlsm);
                            //文件有空值或值的格式不正确 将跳出循环
                            if (LstValues.Count == 0)
                            {
                                lstErrors.Add(sheetsName + "导入文件有空值或格式错误！");
                                break;
                            }
                            //根据存入List中的Excel的表头信息来构建Insert语句中要出入的列的字符串
                            names = ClsQ.Q0("pcid,zt," + string.Join(",", PriListFln), '(');
                            string values = ClsQ.Q0(Pcid + ",'0'," + string.Join(",", LstValues), '(') + ";";
                            sb.Append(" Insert into Tfmsybfnhdrmx " + names + " values " + values);
                        }
                        //如果出现异常 将跳出循环 不再执行
                        if (lstErrors.Count > 0)
                            break;
                        try
                        {
                            comm.CommandText = sb.ToString();
                            comm.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            lstErrors.Add(sheetsName + "写入数据库错误" + ex.Message);
                            continue;
                        }
                    }
                    //如果有多个sheet  有一个出错就全部回滚
                    if (lstErrors.Count > 0)
                    {
                        trans.Rollback();
                        ClsMsgBox.Ts(string.Join("\n", lstErrors), ObjG.CustomMsgBox, this);
                    }
                    else
                    {
                        trans.Commit();
                        ClsMsgBox.Ts("导入成功！", ObjG.CustomMsgBox, this);
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
        //public void TxtToDatatable(string filePath)
        //{
        //    SqlDataAdapter adapter;
        //    int ts1 = 0;
        //    int ts2 = 0;
        //    List<int> LstFwkhid = new List<int>();
        //    //声明一个变量Id来存储批次的Id
        //    int id = 0;
        //    //声明一个变量来存储SQL语句
        //    string cmdText;
        //    //声明一个List集合来存储错误信息
        //    List<string> lstErrors = new List<string>();
        //    List<string> lstCfcw = new List<string>();

        //    //实例化这个ClsCheckAYDRow类
        //    ClsCheckAYDRows aCheckRow = new ClsCheckAYDRows();
        //    using (TextReader tr = new StreamReader(filePath, Encoding.Default))
        //    {
        //        CsvStream csv = new CsvStream(tr);
        //        string[] row = csv.GetNextRow();
        //        Dictionary<int, string> FldHeaderLst = GetFldHeaderLst(row);
        //        Dictionary<int, string> FldLst = new Dictionary<int, string>();
        //        FldLst = GetFldLst(row);
        //        DataTable Dtcfyd = new DataTable();
        //        DataTable DtcTrbmx = new DataTable();
        //        SqlDataAdapter sda = new SqlDataAdapter();
        //        PriName = string.Join(",", FldLst.Values.ToArray<string>());
        //        using (SqlConnection conn = new SqlConnection(PriConStr))
        //        {
        //            try
        //            {
        //                conn.Open();
        //                SqlTransaction trans = conn.BeginTransaction();
        //                SqlCommand comm = new SqlCommand();
        //                comm.CommandTimeout = 2000;
        //                comm.Connection = conn;
        //                comm.Transaction = trans;
        //                string[] row1;
        //                List<string> LstValues = new List<string>();
        //                int i = 0;
        //                string names;
        //                while (true)
        //                {
        //                    names = PriName;
        //                    i++;
        //                    row1 = csv.GetNextRow();
        //                    #region 返回非NULL信息
        //                    if (row1 != null)
        //                    {
        //                        List<string> list = new List<string>();
        //                        list = row1.ToList();
        //                        if (row.Length != row1.Length)
        //                        {
        //                            list.Add("null");
        //                        }
        //                        LstValues = aCheckRow.RowToValues(list, FldHeaderLst, "QS");
        //                        if (LstValues != null)
        //                        {
        //                            string values = "";
        //                            values = string.Join(",", LstValues.ToArray());
        //                            string cmdtext = "Insert into thdsj (" + names + ") values(" + values + ")";
        //                            comm.CommandText = cmdtext;
        //                            try
        //                            {
        //                                comm.ExecuteNonQuery();
        //                                ts1++;
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                aCheckRow.lstErrors.Add("写入数据库错误:" + ex.Message);
        //                            }
        //                            if (aCheckRow.lstErrors.Count > 0)
        //                            {
        //                                lstErrors.Add("第" + (i + 1) + "行错误:" + string.Join(",", aCheckRow.lstErrors));
        //                            }
        //                            //if (lstErrors.Count == Convert.ToInt32(this.TxtCw.Text))
        //                            //    break;
        //                        }
        //                        else
        //                        {
        //                            if (!string.IsNullOrEmpty(aCheckRow.PubCfbz))
        //                                lstCfcw.Add("第" + (i + 1) + "行错误:" + aCheckRow.PubCfbz);
        //                        }
        //                    }
        //                    #endregion
        //                    else
        //                    {
        //                        break;
        //                    }
        //                }
        //                //处理事务
        //                if (lstErrors.Count > 0)
        //                {
        //                    trans.Rollback();
        //                }
        //                else
        //                {
        //                    trans.Commit();
        //                    ClsMsgBox.Ts("导入成功,共导入" + ts1 + "条,重复数据" + ts2 + "条！");
        //                }
        //            }
        //            finally
        //            {
        //                tr.Close();
        //                conn.Close();
        //            }
        //        }
        //    }//using TextReader
        //}
        #endregion

        #region GetFldHeaderLst Txt
        private Dictionary<int, string> GetFldHeaderLst(string[] str)
        {
            int i = 0;
            Dictionary<int, string> flds = new Dictionary<int, string>();
            //使用foreach遍历首行加入Dictionary
            foreach (string c in str)
            {
                ScolName = c;
                if (!string.IsNullOrEmpty(ScolName))
                {
                    PriDrs = PriTydColsDescription.Select("flsm  like '" + ScolName + "：%'");
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
            //使用foreach遍历首行加入Dictionary
            foreach (string c in str)
            {
                ScolName = c;
                if (!string.IsNullOrEmpty(ScolName))
                {
                    if (ScolName.Equals("受理机构") || ScolName.Equals("终到机构") || ScolName.Equals("签收机构所属大区"))
                    {
                        continue;
                    }
                    else
                    {
                        PriDrs = PriTydColsDescription.Select("flsm  like '" + ScolName + "：%'");
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
            //使用foreach遍历首行加入Dictionary
            foreach (HSSFCell c in headerRow.Cells)
            {
                ScolName = c.StringCellValue;
                if (!string.IsNullOrEmpty(ScolName))
                {
                    PriDrs = PriTydColsDescription.Select("flsm  like '" + ScolName + "：%'");
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
                    if (alist[i].Equals("交易金额"))
                    {
                        double aJyje;
                        if (double.TryParse(sValue, out aJyje))
                            LstValue.Add(ClsQ.Q1(aJyje.ToString()));
                    }
                    else if (alist[i].Equals("交易状态"))
                    {
                        if (sValue.LastIndexOf("成功") > 0)
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
                ClsMsgBox.YesNo("确认删除" + Dgv.CurrentRow.Cells[0].Value + "吗？", new EventHandler(DeleteFile));
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
            string where = " where lx='N' and inssj >= '" + DtpStart.Value.Date + "' and inssj < '" + DtpStop.Value.AddDays(1) + "'";
            where += " and zt = " + CmbZtlx.SelectedIndex; 
            VfmsybfdrpcTableAdapter1.FillByWhere(DSNHDR1.Vfmsybfdrpc, where);
        }
        private void PosMatching()
        {
            if (Bds.Current == null)
            {
                ClsMsgBox.Ts("请选择要匹配的信息！", ObjG.CustomMsgBox, this);
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
                    PriSucceed = 0;//成功条数
                    PriFailure = 0;//记录失败条数
                    DataTable table_rbpc = ClsRWMSSQLDb.GetDataTable("  SELECT a.id,b.zh,b.zhmc,a.dkje FROM dbo.Tfmsrbpc AS a  INNER JOIN  tfmsyhzh AS b ON a.jgid=b.jgid   WHERE a.zt=0 AND a.ckbz=1 AND  b.yhlxid=241  AND b.zhlxid=1 AND b.zt=0   ORDER BY a.inssj DESC", ClsGlobals.CntStrTMS);
                  
                    DSNHDR.VfmsybfdrpcRow pcrow = ((DataRowView)Bds.Current).Row as DSNHDR.VfmsybfdrpcRow;
                    TfmsybfnhdrmxTableAdapter1.FillByNHDR(DSNHDR1.Tfmsybfnhdrmx, pcrow.id);
                    com.CommandText+= " Update Tfmsybfdrpc set zt = 1 where id =" + pcrow.id + " ;";
                    com.ExecuteNonQuery(); 
                    foreach(DSNHDR.TfmsybfnhdrmxRow row in DSNHDR1.Tfmsybfnhdrmx)
                    {
                        int count = 0;//记录是否有匹配的
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
                                    com.CommandText = "Update Tfmsrbpc set wydkzt = 10 where id =" + id + " ;";
                                    com.CommandText += " Update Tfmsybfnhdrmx set zt = 5,rbpcid =" + id + " where id =" + row.id + " ;";
                                }
                                else if (row.jyzt == 10)
                                {
                                    com.CommandText = " Update Tfmsybfnhdrmx set zt = 10,rbpcid =" + id + " where id =" + row.id + " ;";
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
                            com.CommandText = " Update Tfmsybfnhdrmx set zt = 10 where id =" + row.id;
                            com.ExecuteNonQuery();
                            PriFailure++;
                        }
                        continue;
                    }
                    Bds.RemoveCurrent();
                    trans.Commit();
                    ClsMsgBox.Ts("共" + DSNHDR1.Tfmsybfnhdrmx.Rows.Count + "条，匹配成功" + PriSucceed + "条，失败" + PriFailure + "条！", ObjG.CustomMsgBox, this);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    ClsMsgBox.Cw("匹配失败！", ex, ObjG.CustomMsgBox, this);
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
            ClsExcel.CreatExcel(DGVDRxx, "农行银行代扣匹配信息", this.ctrlDownLoad1);
        }

        private void BtnElxrb_Click(object sender, EventArgs e)
        {
            //if (PriRow == null)
            //{
            //    ClsMsgBox.Ts("请选择要导出的信息！", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //string PriFln = "代收货款收款日报表";//文件名称    
            //PriFln = PriFln + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            //string PriFlp = System.IO.Path.Combine(System.Configuration.ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
            ////创建数据库连接对接对象
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TMSConnectionString"].ToString());
            ////打开数据库连接
            //conn.Open();
            //SqlCommand com = new SqlCommand();
            //com.Connection = conn;
            //try
            //{
            //    SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
            //    DataTable dt = ClsRWMSSQLDb.GetDataTable(" SELECT b.mc,a.posbh,a.bs,a.je,a.sxf,(CASE WHEN a.zt=0 THEN '未匹配' WHEN a.zt=5 THEN '不符'  WHEN a.zt=10 THEN '相符'end)AS zts,a.zt FROM Tfmsposmx AS a LEFT JOIN jyjckj.dbo.tjigou AS b ON a.posbh=b.posbh where a.pcid=" + PriRow.id + " order by a.zt desc , b.mc  ", ClsGlobals.CntStrTMS);
            //    int SumBs = dt.AsEnumerable().Sum(r => r.Field<int>("bs"));
            //    decimal SumDSKje = dt.AsEnumerable().Sum(r => r.Field<decimal>("je"));
            //    decimal SumSxf = dt.AsEnumerable().Sum(r => r.Field<decimal>("sxf"));
            //    decimal SumXfje = dt.AsEnumerable().Where(r => r.Field<Byte>("zt") == 10).Sum(r => r.Field<decimal>("je"));
            //    decimal SumBfje = dt.AsEnumerable().Where(r => r.Field<Byte>("zt") == 5).Sum(r => r.Field<decimal>("je")); ;
            //    int CountXf = dt.AsEnumerable().Where(r => r.Field<Byte>("zt") == 10).Count();
            //    int CountBf = dt.AsEnumerable().Where(r => r.Field<Byte>("zt") == 5).Count();
            //    //模板路径
            //    string priModel = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath + @"App_Data\ModelExcel\FMS", "DskskrbMode.xls");
            //    //生成模板读取IO流
            //    FileStream fileStreamRead = new FileStream(priModel, FileMode.Open, FileAccess.Read);
            //    //创建工作簿XLS对象
            //    HSSFWorkbook hssfwork = new HSSFWorkbook(fileStreamRead);
            //    HSSFSheet hssfSheet = hssfwork.GetSheetAt(0) as HSSFSheet;
            //    HSSFRow hssfRow = hssfSheet.GetRow(1) as HSSFRow;
            //    HSSFCell hssfCell = hssfRow.GetCell(0) as HSSFCell;

            //    #region 样式
            //    #region 居中样式
            //    HSSFCellStyle cellStyle1 = (HSSFCellStyle)hssfwork.CreateCellStyle();
            //    cellStyle1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            //    #endregion
            //    #region 双浮点数据
            //    HSSFCellStyle cellStyle2 = (HSSFCellStyle)hssfwork.CreateCellStyle();
            //    cellStyle2.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
            //    #endregion

            //    #endregion

            //    /**报表制作日期：  年  月  日**/
            //    HSSFRow row = (HSSFRow)hssfSheet.CreateRow(1);
            //    row.CreateCell(0).SetCellValue("报表制作日期:" + PriRow.inssj.ToShortDateString());
            //    row.Cells[0].CellStyle = cellStyle1;
            //    row.CreateCell(3).SetCellValue("收款类型：银联代收POS机收款:");
            //    row.Cells[1].CellStyle = cellStyle1;
            //    /**填充数据**/
            //    int rowIndex = 3;
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        HSSFRow r = (HSSFRow)hssfSheet.CreateRow(rowIndex);
            //        Cell c0 = r.CreateCell(0);
            //        Cell c1 = r.CreateCell(1);
            //        Cell c2 = r.CreateCell(2);
            //        Cell c3 = r.CreateCell(3);
            //        Cell c4 = r.CreateCell(4);
            //        Cell c5 = r.CreateCell(5);
            //        Cell c6 = r.CreateCell(6);
            //        //填充数据和设置样式
            //        c0.SetCellValue(i + 1);
            //        c0.CellStyle = cellStyle1;
            //        c1.SetCellValue(dt.Rows[i]["mc"].ToString());
            //        c2.SetCellValue(dt.Rows[i]["posbh"].ToString());
            //        c3.SetCellValue(Convert.ToInt32(dt.Rows[i]["bs"].ToString()));
            //        c4.SetCellValue(Convert.ToDouble(dt.Rows[i]["je"].ToString()));
            //        c4.CellStyle = cellStyle2;
            //        c5.SetCellValue(Convert.ToDouble(dt.Rows[i]["sxf"].ToString()));
            //        c5.CellStyle = cellStyle2;
            //        c6.SetCellValue(dt.Rows[i]["zts"].ToString());
            //        c6.CellStyle = cellStyle1;
            //        rowIndex++;
            //    }
            //    //合计   
            //    HSSFRow hj = (HSSFRow)hssfSheet.CreateRow(rowIndex);
            //    Cell Hjc0 = hj.CreateCell(0);
            //    Cell Hjc3 = hj.CreateCell(3);
            //    Cell Hjc4 = hj.CreateCell(4);
            //    Cell Hjc5 = hj.CreateCell(5);
            //    Cell Hjc6 = hj.CreateCell(6);
            //    Hjc0.SetCellValue("合计：");
            //    Hjc3.SetCellValue(SumBs);
            //    Hjc4.SetCellValue(SumDSKje.ToString());
            //    hj.Cells[2].CellStyle = cellStyle2;
            //    Hjc5.SetCellValue(SumSxf.ToString());
            //    hj.Cells[3].CellStyle = cellStyle2;
            //    Hjc6.SetCellValue((SumDSKje - Math.Abs(SumSxf)).ToString());
            //    hj.Cells[4].CellStyle = cellStyle2;
            //    //统计
            //    rowIndex++;
            //    HSSFRow hj0 = (HSSFRow)hssfSheet.CreateRow(rowIndex);
            //    Cell Hjc1 = hj0.CreateCell(0);
            //    Hjc1.SetCellValue("匹配状态统计：相符金额：" + SumXfje + " 相符个数：" + CountXf + " 不符金额：" + SumBfje + " 不符个数" + CountBf + "。");
            //    int firstRow = rowIndex ;
            //    int lastRow = rowIndex ;
            //    int firstCol = 0;
            //    int lastCol = 6;
            //    hssfSheet.AddMergedRegion(new CellRangeAddress(firstRow, lastRow, firstCol, lastCol));

            //    rowIndex++;
            //    //     月     日     系统实收代收金额           元       核对差异 ：
            //    HSSFRow Tj = (HSSFRow)hssfSheet.CreateRow(rowIndex );
            //    Cell Tj0 = Tj.CreateCell(0);
            //    Hjc1.SetCellValue("     月     日     系统实收代收金额           元       核对差异 ：");

            //    FileStream file = new FileStream(PriFlp, FileMode.Create);
            //    hssfwork.Write(file);
            //    file.Close();
            //    ctrlDownLoad1.download(PriFlp, true);
            //}
            //catch (Exception ex)
            //{
            //    ClsMsgBox.Ts("遇到错误！" + ex.ToString(), ObjG.CustomMsgBox, this);
            //    return;
            //}
            //finally
            //{
            //    conn.Close();
            //}
        }

        private void DGVDRxx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 4)
                return;
            if (e.ColumnIndex == 4)
            {
                
                DSNHDR.VfmsybfdrpcRow row = ((DataRowView)Bds.Current).Row as DSNHDR.VfmsybfdrpcRow;
                if (row.zt == 1)
                {
                    ClsMsgBox.Ts("该农行信息已匹配！", ObjG.CustomMsgBox, this);
                    return;
                }
                else
                    PosMatching();
            }
            else
            {

                //FrmYHMX f = new FrmYHMX();
                //f.Prepare(PriRow.id);
                //f.ShowDialog();
            }
        }
    }
}