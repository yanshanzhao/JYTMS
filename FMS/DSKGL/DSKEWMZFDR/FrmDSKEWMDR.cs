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
        private string PriFilePath;//文件路径
        private HSSFWorkbook Hssfworkbook;
        private string[] PriExtention = { ".xls" };//允许上传的文件的扩展类型
        List<string> LstFiles = new List<string>();
        private List<string> PriListFln;//列名
        private List<string> PriListFlsm;//列说明
        private int PriSucceed; //记录匹配成功条数
        private int PriFailure;//记录失败条数
        List<string> lstErrors;//记录行错误
        private string ScolName;//用来存储Excel列名
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
            //获得表的说明赋值给DataTable
            PriTydColsDescription = ClsRWMSSQLDb.GetColDescription("Tfmsdskewmdrmx", PriConStr);
            //获得文件的路径
            PriFilePath = Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), ClsOptions.WebCfg.DSKDWKNHFilePath + DateTime.Now.ToString("yyyyMM"));
            if (!Directory.Exists(PriFilePath))
                Directory.CreateDirectory(PriFilePath);
            //将指定路径下的文件显示在ListBox中
            ImportFileToDgv(PriFilePath);
            //自定义上传文件路径,调用自定义控件里的Prepare方法
            //PriUploadFoldr = ClsOptions.WebCfg.PosXlsFilePath + DateTime.Now.ToString("yyyyMM");
            ctrlUploadFile1.Prepare(PriFilePath, PriExtention, false, "导入文件");
            ImportFileToDgv(PriFilePath);
            ctrlUploadFile1.PrepareA(new JY.CtrlPub.ImportToDB(DgvAddFile));
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

        #region 导入数据库
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
            //实例化这个ClsCheckAYDRow类
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
                    ClsMsgBox.Cw("导入错误！", ex);
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
                            HSSFRow headerRow = (HSSFRow)hssfsheet.GetRow(0);
                            HSSFRow row = (HSSFRow)hssfsheet.GetRow(0);
                            GetFldLst(row);
                            if (PriListFln.Count == 0)
                            {
                                lstErrors.Add(sheetsName + "文件表头格式错误！");
                                continue;
                            }
                            StringBuilder sb = new StringBuilder();
                            //循环遍历Excel中除了第二行之外的所有数据行
                            for (int i = hssfsheet.FirstRowNum + 1; i <= hssfsheet.LastRowNum; i++)
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
                                names = ClsQ.Q0("pcid," + string.Join(",", PriListFln), '(');
                                string values = ClsQ.Q0(Pcid + "," + string.Join(",", LstValues), '(') + ";";
                                sb.Append(" Insert into Tfmsdskewmdrmx " + names + " values " + values);
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
                    if (alist[i].Equals("金额"))
                    {
                        double aJyje;
                        if (double.TryParse(sValue, out aJyje))
                            LstValue.Add(ClsQ.Q1(aJyje.ToString()));
                    }
                    else if (alist[i].Equals("支付时间"))
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
        #endregion 导入数据库

        #region 上传文件删除
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Dgv.SelectedRows != null && Dgv.Rows.Count != 0)
            {
                ClsMsgBox.YesNo("确认删除" + Dgv.CurrentRow.Cells[0].Value + "吗？", new EventHandler(DeleteFile));
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
        #endregion 上传文件删除

        #region 查询
        private void BtnQuiry_Click(object sender, EventArgs e)
        {
            string where = " where  inssj >= '" + DtpStart.Value.Date + "' and inssj < '" + DtpStop.Value.AddDays(1) + "'";
            where += " and zt = " + CmbZtlx.SelectedIndex;
            VdskewmdrpcTableAdapter1.FillByWhere(Dsdksewmzfdr1.Vdskewmdrpc, where);
        }
        #endregion 查询

        #region 验证
        private void Btn_Chk_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
            {
                ClsMsgBox.Ts("请选择要验证的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            DSDKSEWMZFDR.VdskewmdrpcRow RowCurrent = ((DataRowView)Bds.Current).Row as DSDKSEWMZFDR.VdskewmdrpcRow;
            if (RowCurrent.zt != 0)
            {
                ClsMsgBox.Ts("该信息已经验证过！", ObjG.CustomMsgBox, this);
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
                ClsMsgBox.Ts(string.Format("此次验证共{0}条,其中成功检查共{1}条，存在异常共{2}条！", mxCounts, mxCounts - RowsCounts, RowsCounts), ObjG.CustomMsgBox, this);

                Bds.RemoveCurrent();
            }
            catch (Exception ex)
            {
                ClsMsgBox.Ts("验证异常！原因" + ex.Message, ObjG.CustomMsgBox, this);
            }
        }
        #endregion 验证

        #region 匹配
        private void DGVDRxx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 3)
                return;
            if (e.ColumnIndex == 3)
            {
                DSDKSEWMZFDR.VdskewmdrpcRow row = ((DataRowView)Bds.Current).Row as DSDKSEWMZFDR.VdskewmdrpcRow;
                if (row.zt < 2)
                {
                    ClsMsgBox.Ts("只有验证通过的才能进行匹配！", ObjG.CustomMsgBox, this);
                    return;
                }
                if (row.zt == 3)
                {
                    ClsMsgBox.Ts("该信息已匹配！", ObjG.CustomMsgBox, this);
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
                    DSDKSEWMZFDR.VdskewmdrpcRow pcrow = ((DataRowView)Bds.Current).Row as DSDKSEWMZFDR.VdskewmdrpcRow;
                    //TfmsdskewmdrhzTableAdapter1.FillByPcid(Dsdksewmzfdr1.Tfmsdskewmdrhz, pcrow.id);
                    TfmsdskewmdrmxTableAdapter1.FillByPcId(Dsdksewmzfdr1.Tfmsdskewmdrmx, pcrow.id);
                    //根据jgid查询未审核、二维码支付、系统未匹配的日报，根据年月日、金额格式正序排序
                    DataTable dtrb = ClsRWMSSQLDb.GetDataTable(string.Format(@"SELECT a.id,b.ydid,dkje FROM dbo.Tfmsdskjkpc AS a INNER JOIN tfmsdskjkmx AS b ON a.id=b.pcid INNER JOIN tfmsdskewmdrmx AS c ON b.ydid=c.ydid AND c.pcid={0} WHERE a.zt=10 AND a.zflx=2 AND xtppzt=0 AND  spjgid={1}", pcrow.id, ObjG.Jigou.id), PriConStr);
                    int rbgs = dtrb.Rows.Count;
                    if (rbgs == 0)
                    {
                        ClsMsgBox.Ts("无日报可以匹配！");
                        return;
                    }
                    com.CommandText = "UPDATE dbo.Tfmsdskewmdrpc SET zt=3 WHERE id=" + pcrow.id;
                    com.ExecuteNonQuery();
                    foreach (DSDKSEWMZFDR.TfmsdskewmdrmxRow row in Dsdksewmzfdr1.Tfmsdskewmdrmx)
                    {
                        decimal je = row.dskje;//要匹配的金额（导入金额）
                        int ydid = row.ydid;   //要匹配的运单
                        //循环查询结果匹配，修改匹配数量和金额，插入明细
                        for (int i = dtrb.Rows.Count - 1; i >= 0; i--)
                        {
                            decimal dkje = Convert.ToDecimal(dtrb.Rows[i]["dkje"]);//日报金额
                            int rbid = Convert.ToInt32(dtrb.Rows[i]["id"]);        //日报的Id
                            int rbydid = Convert.ToInt32(dtrb.Rows[i]["ydid"]);    //日报对应运单
                            if (ydid == rbydid)//找到运单对应日报
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
                    //导入7500元，工查询到1个日报，其中匹配成功0个
                    ClsMsgBox.Ts("导入" + Dsdksewmzfdr1.Tfmsdskewmdrmx.Sum(p => p.dskje) + "元，共查询到" + rbgs + "个日报，其中匹配成功" + PriSucceed + "个，失败" + (rbgs - PriSucceed) + "个", ObjG.CustomMsgBox, this);
                    Bds.RemoveCurrent();
                    trans.Commit();
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
        #endregion 匹配

        #region 删除
        private void Btn_Del_Click(object sender, EventArgs e)
        {
            if (DGVDRxx.SelectedRows != null && DGVDRxx.Rows.Count != 0)
            {
                ClsMsgBox.YesNo("确认删除" + DGVDRxx.CurrentRow.Cells[0].Value + "吗？", new EventHandler(Delete));
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
                    ClsMsgBox.Ts("删除成功！", frm, this);
                    BtnQuiry.PerformClick();
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("删除失败！", ex, frm, this);
                }
            }
        }
        #endregion 删除

        #region 导出
        private void Bnt_dc_Click(object sender, EventArgs e)
        {
            if (DGVDRxx.RowCount == 0)
                return;
            ClsExcel.CreatExcel(DGVDRxx, "导入信息", this.ctrlDownLoad1);
        }
        #endregion 导出

        #region 导出验证信息
        private void Btn_DcYzxx_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            DSDKSEWMZFDR.VdskewmdrpcRow RowCurrent = ((DataRowView)Bds.Current).Row as DSDKSEWMZFDR.VdskewmdrpcRow;
            List<string> LsCell = new List<string>();//表头
            LsCell.Add("大区");
            LsCell.Add("连锁店");
            LsCell.Add("单号");
            LsCell.Add("代收款金额");
            LsCell.Add("支付方式");
            LsCell.Add("支付时间");
            LsCell.Add("错误描述");
            string SQLStr = "SELECT dqmc,jgmc,dh,dskje,zflx,zfsj,cw FROM dbo.Tfmsdskewmdrmx WHERE pcid=" + RowCurrent.id;
            DataTable dt = ClsRWMSSQLDb.GetDataTable(SQLStr, ClsGlobals.CntStrTMS);
            if (dt.Rows.Count > 0)
            {
                CreatExcel_Data(dt, LsCell, "验证结果信息", ctrlDownLoad1);
            }

        }
        #endregion 导出验证信息

        private void CreatExcel_Data(DataTable Dt, List<string> Dt_List, string FileName, JY.CtrlPub.CtrlDownLoad DownLoad)
        {
            string PriFln = FileName + DateTime.Now.ToString("yyyyMMddHHmmssmm") + ".xls";//文件名称     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
            //写入数据
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.DefaultColumnWidth = 17;
            try
            {
                //行名的的设置
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
                //数据添加
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
                ClsMsgBox.Cw("导出Excel失败", ex);
            }
            finally
            {
                sheet1.Dispose();
                hssfworkbook.Dispose();

            }
        }

        #region 导出匹配结果
        private void BntDcskrbb_Click(object sender, EventArgs e)
        {

            if (PriRow == null)
            {
                ClsMsgBox.Ts("请选择要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "代收款二维码导入匹配结果";//文件名称    
            PriFln = PriFln + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            string PriFlp = System.IO.Path.Combine(System.Configuration.ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
            //创建数据库连接对接对象
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TMSConnectionString"].ToString());
            //打开数据库连接
            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
                //DataTable dt = ClsRWMSSQLDb.GetDataTable(@"SELECT c.dqmc,d.mc AS jgmc,je,'二维码支付' as zflx,b.rbje,CASE WHEN b.zt=0 THEN '不相符' WHEN b.zt=1 THEN '相符' END AS zts,a.id,a.rbgs FROM dbo.Tfmsdskewmdrhz AS a INNER JOIN dbo.Tfmsdskewmppmx AS b ON b.hzid = a.id INNER JOIN jyjckj.dbo.Vdqjigou AS c ON c.dqid=a.dqid INNER JOIN jyjckj.dbo.tjigou AS d ON d.id=a.jgid where a.pcid=" + PriRow.id + " order by a.id", ClsGlobals.CntStrTMS);
                DataTable dt = ClsRWMSSQLDb.GetDataTable("SELECT dqmc,jgmc,dh,dskje,ydbh,rbje,CASE WHEN b.zt=1 THEN '相符' WHEN b.zt=0 THEN '不相符' ELSE '无日报' END  AS ppzt,d.zfsj  FROM tfmsdskewmdrmx AS a LEFT JOIN tfmsdskewmppmx AS b ON a.id=b.hzid LEFT JOIN tfmsdskjkpc AS c ON b.rbpcid=c.id LEFT JOIN tfmsdsk AS d ON a.ydid=d.ydid WHERE a.pcid=" + PriRow.id, ClsGlobals.CntStrTMS);
                decimal SumJzje = dt.AsEnumerable().Sum(r => r.Field<decimal>("dskje"));
                decimal SumXfje=dt.AsEnumerable().Where(r=>r.Field<string>("ppzt").Equals("相符")).Sum(r=>r.Field<decimal>("rbje"));
                //模板路径
                string priModel = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath + @"App_Data\ModelExcel\FMS", "DskEwmdr.xls");
                //生成模板读取IO流
                FileStream fileStreamRead = new FileStream(priModel, FileMode.Open, FileAccess.Read);
                //创建工作簿XLS对象
                HSSFWorkbook hssfwork = new HSSFWorkbook(fileStreamRead);
                HSSFSheet hssfSheet = hssfwork.GetSheetAt(0) as HSSFSheet;
                HSSFRow hssfRow = hssfSheet.GetRow(0) as HSSFRow;
                HSSFCell hssfCell = hssfRow.GetCell(0) as HSSFCell;

                #region 样式
                #region 居中样式
                HSSFCellStyle cellStyle1 = (HSSFCellStyle)hssfwork.CreateCellStyle();
                cellStyle1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                cellStyle1.BorderBottom = CellBorderType.THIN;
                cellStyle1.BorderTop = CellBorderType.THIN;
                cellStyle1.BorderLeft = CellBorderType.THIN;
                cellStyle1.BorderRight = CellBorderType.THIN;
                #endregion
                #region 双浮点数据
                HSSFCellStyle cellStyle2 = (HSSFCellStyle)hssfwork.CreateCellStyle();
                cellStyle2.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                cellStyle2.BorderBottom = CellBorderType.THIN;
                cellStyle2.BorderTop = CellBorderType.THIN;
                cellStyle2.BorderLeft = CellBorderType.THIN;
                cellStyle2.BorderRight = CellBorderType.THIN;
                #endregion

                #endregion

                HSSFRow row = (HSSFRow)hssfSheet.CreateRow(0);
                row.CreateCell(0).SetCellValue(DateTime.Now.ToString("yyyy年MM月dd日") + "齐鲁银行线上支付进账");
                row.Cells[0].CellStyle = cellStyle1;
                /**填充数据**/
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
                    //填充数据和设置样式
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
                //合计   
                HSSFRow hj = (HSSFRow)hssfSheet.CreateRow(rowIndex);
                hssfSheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 0, 2));
                Cell Hjc0 = hj.CreateCell(0);
                Cell Hjc3 = hj.CreateCell(3);
                Cell Hjc4 = hj.CreateCell(4);
                Cell Hjc5 = hj.CreateCell(5);
                Hjc0.SetCellValue("进账合计：");
                Hjc0.CellStyle = cellStyle1;
                hj.CreateCell(1).CellStyle = cellStyle1;
                hj.CreateCell(2).CellStyle = cellStyle1;
                hj.CreateCell(6).CellStyle = cellStyle1;
                hj.CreateCell(7).CellStyle = cellStyle1;
                Hjc3.SetCellValue(SumJzje.ToString());
                Hjc3.CellStyle = cellStyle2;
                Hjc4.SetCellValue("相符合计：");
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
                ClsMsgBox.Ts("遇到错误！" + ex.ToString(), ObjG.CustomMsgBox, this);
                return;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion 导出订单匹配结果

    }
}
