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
    public partial class FrmYBFDWKZSDR : UserControl
    {
        public FrmYBFDWKZSDR()
        {
            InitializeComponent();
        }
        #region 成员变量
        private string PriFilePath;//文件路径
        private HSSFWorkbook Hssfworkbook;
        private string[] PriExtention = { ".xls" };//允许上传的文件的扩展类型
        List<string> lstErrors;//记录行错误
        private string PriConStr;
        List<string> LstFiles = new List<string>();
        private List<string> PriListFln;//列名
        private List<string> PriListFlsm;//列说明
        private ClsG ObjG;
        private int PriSucceed; //记录匹配成功条数
        private int PriFailure;//记录失败条数
        private DataTable PriTydColsDescription;
        private string ScolName;//用来存储Excel列名
        private DataRow[] PriDrs;
        private string PriConStrKj;
        private int PriSpjgid = 0;
        private DSYBFDWKDR.VybfdwkdrpcRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as DSYBFDWKDR.VybfdwkdrpcRow;
                }
            }
        }

        #endregion
        #region 初始化
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            PriConStr = ClsGlobals.CntStrTMS;
            PriConStrKj = ClsGlobals.CntStrKj;
            PriSpjgid = ObjG.Jigou.id;
            //获得表的说明赋值给DataTable
            PriTydColsDescription = ClsRWMSSQLDb.GetColDescription("Tfmsybfdwkzsdr", PriConStr);
            //获得文件的路径
            PriFilePath = Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), ClsOptions.WebCfg.YBFDWKFilePath + DateTime.Now.ToString("yyyyMM"));
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
            VybfdwkdrpcTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            TfmsybfdwkzsdrTableAdapter.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }

        #endregion
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
        #region 查询
        private void BtnQuiry_Click(object sender, EventArgs e)
        {
            string where = " where lx='Z' and  inssj >= '" + DtpStart.Value.Date + "' and inssj < '" + DtpStop.Value.AddDays(1) + "'";
            where += " and zt = " + CmbZtlx.SelectedIndex;
            VybfdwkdrpcTableAdapter1.FillByWhere(DSYBFDWKDR1.Vybfdwkdrpc, where);
        }

        #endregion
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
                    SqlTransaction trans = conn.BeginTransaction();
                    try
                    {
                        lstErrors = new List<string>();
                        SqlCommand comm = new SqlCommand();
                        comm.CommandTimeout = 2000;
                        comm.Connection = conn;
                        comm.Transaction = trans;
                        comm.CommandText = string.Format("insert into Tfmsybfdwkdrpc (fln,inssj,insczyid,insczyxm,zt,lx)" +
                     "  values ('{0}','{1}','{2}','{3}','{4}','Z');SELECT SCOPE_IDENTITY()", Dgv.CurrentRow.Cells[0].Value, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.xm, "0");
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
                            HSSFRow row = (HSSFRow)hssfsheet.GetRow(5);
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
                                sb.Append(" Insert into Tfmsybfdwkzsdr " + names + " values " + values);
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
                if (ScolName == "")
                    ScolName = "代扣金额";
                if (ScolName != "凭证种类" && ScolName != "企业流水号")
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
                    if (alist[i].Equals("交易金额"))
                    {
                        double aJyje;
                        if (double.TryParse(sValue, out aJyje))
                            LstValue.Add(ClsQ.Q1(aJyje.ToString()));
                        else
                            LstValue.Add(ClsQ.Q1("0"));
                    }
                    else if (alist[i].Equals("借"))
                    {
                        double aje;
                        if (double.TryParse(sValue, out aje))
                            LstValue.Add(ClsQ.Q1(aje.ToString()));
                        else
                            LstValue.Add(ClsQ.Q1("0"));
                    }
                    else if (alist[i].Equals("余额"))
                    {
                        double aje;
                        if (double.TryParse(sValue, out aje))
                            LstValue.Add(ClsQ.Q1(aje.ToString()));
                        else
                            LstValue.Add(ClsQ.Q1("0"));
                    }
                    else if (alist[i].Equals("交易状态"))
                    {
                        if (sValue == "成功")
                            LstValue.Add(ClsQ.Q1("0"));
                        else
                            LstValue.Add(ClsQ.Q1("10"));
                    }
                    else if (alist[i].Equals("交易日期"))
                    {
                        DateTime date;
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
                    else
                    {
                        LstValue.Add(ClsQ.Q1(sValue.Replace(",", "")));
                    }
                }
            }
            return LstValue;
        }
        #endregion
        #region 文件删除
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Dgv.SelectedRows != null && Dgv.Rows.Count != 0)
            {
                ClsMsgBox.YesNo("确认删除" + Dgv.CurrentRow.Cells[0].Value + "吗？", new EventHandler(DeleteFile));
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
        #region 导出
        private void BtnElse_Click(object sender, EventArgs e)
        {
            if (DGVDRxx.RowCount == 0)
                return;
            ClsExcel.CreatExcel(DGVDRxx, "运保费单位卡匹配信息", this.ctrlDownLoad1);
        }
        #endregion
        #region 导出收款日报表
        private void BtnElxrb_Click(object sender, EventArgs e)
        {
            if (PriRow == null)
            {
                ClsMsgBox.Ts("请选择要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "运保费单位卡招商收款日报表";//文件名称    
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
                DataTable dt = ClsRWMSSQLDb.GetDataTable(@" 
 SELECT  DISTINCT c.dqmc,c.jgmc,a.sfzh,a.sfmc,a.jysq,a.d,a.dkje,a.cyje,(CASE WHEN a.zt=0 THEN '未匹配' WHEN a.zt=5 THEN '相符'   
  WHEN a.zt=10 THEN '不符'end)AS zts,a.zt,a.id FROM dbo.Tfmsybfdwkzsdr AS a Left JOIN Tfmsrbpc  AS b 
    ON   a.rbpcid=b.id left JOIN vfmsyhzh AS c ON b.jgid=c.jgid  where a.pcid=" + PriRow.id + "  order by a.zt desc , c.jgmc ", ClsGlobals.CntStrTMS);

                decimal SumDSKje = dt.AsEnumerable().Sum(r => r.Field<decimal>("d"));
                //模板路径
                string priModel = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath + @"App_Data\ModelExcel\FMS", "YbfDwknhdr.xls");
                //生成模板读取IO流
                FileStream fileStreamRead = new FileStream(priModel, FileMode.Open, FileAccess.Read);
                //创建工作簿XLS对象
                HSSFWorkbook hssfwork = new HSSFWorkbook(fileStreamRead);
                HSSFSheet hssfSheet = hssfwork.GetSheetAt(0) as HSSFSheet;
                HSSFRow hssfRow = hssfSheet.GetRow(1) as HSSFRow;
                HSSFCell hssfCell = hssfRow.GetCell(0) as HSSFCell;

                #region 样式
                #region 居中样式
                HSSFCellStyle cellStyle1 = (HSSFCellStyle)hssfwork.CreateCellStyle();
                cellStyle1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                #endregion
                #region 双浮点数据
                HSSFCellStyle cellStyle2 = (HSSFCellStyle)hssfwork.CreateCellStyle();
                cellStyle2.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                #endregion

                #endregion

                /**报表制作日期：  年  月  日**/
                HSSFRow row = (HSSFRow)hssfSheet.CreateRow(1);
                row.CreateCell(0).SetCellValue("报表制作日期:" + PriRow.inssj.ToShortDateString());
                row.Cells[0].CellStyle = cellStyle1;
                row.CreateCell(3).SetCellValue("收款类型：银联代收招行");
                row.Cells[1].CellStyle = cellStyle1;
                /**填充数据**/
                int rowIndex = 3;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    HSSFRow r = (HSSFRow)hssfSheet.CreateRow(rowIndex);
                    Cell c0 = r.CreateCell(0);
                    Cell c11 = r.CreateCell(1);
                    Cell c1 = r.CreateCell(2);
                    Cell c2 = r.CreateCell(3);
                    Cell c3 = r.CreateCell(4);
                    Cell c4 = r.CreateCell(5);
                    Cell c5 = r.CreateCell(6);
                    Cell c6 = r.CreateCell(7);
                    //填充数据和设置样式
                    c0.SetCellValue(i + 1);
                    c0.CellStyle = cellStyle1;
                    c11.SetCellValue(dt.Rows[i]["jysq"].ToString());
                    c1.SetCellValue(dt.Rows[i]["dqmc"].ToString());
                    c2.SetCellValue(dt.Rows[i]["jgmc"].ToString());
                    c3.SetCellValue(Convert.ToDouble(dt.Rows[i]["d"].ToString()));
                    c4.SetCellValue(dt.Rows[i]["sfzh"].ToString());
                    //c4.CellStyle = cellStyle2;
                    c5.SetCellValue(dt.Rows[i]["dkje"].ToString());
                    c6.SetCellValue(dt.Rows[i]["cyje"].ToString());
                    rowIndex++;
                }
                //合计   
                HSSFRow hj = (HSSFRow)hssfSheet.CreateRow(rowIndex);
                Cell Hjc0 = hj.CreateCell(0);
                Cell Hjc3 = hj.CreateCell(3);
                Cell Hjc4 = hj.CreateCell(4);
                Hjc0.SetCellValue("合计：");
                Hjc4.SetCellValue(SumDSKje.ToString());
                Hjc4.CellStyle = cellStyle2;
                //统计
                rowIndex++;
                HSSFRow hj0 = (HSSFRow)hssfSheet.CreateRow(rowIndex);
                Cell Hjc1 = hj0.CreateCell(0);
                int firstRow = rowIndex;
                int lastRow = rowIndex;
                int firstCol = 0;
                int lastCol = 6;
                hssfSheet.AddMergedRegion(new CellRangeAddress(firstRow, lastRow, firstCol, lastCol));
                rowIndex++;
                //     月     日     系统实收代收金额           元       核对差异 ：
                HSSFRow Tj = (HSSFRow)hssfSheet.CreateRow(rowIndex);
                Cell Tj0 = Tj.CreateCell(0);
                Hjc1.SetCellValue("     月     日     系统实运保费金额           元       核对差异 ：");
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
        #endregion
        #region 匹配事件

        private void DGVDRxx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 4)
                return;
            if (e.ColumnIndex == 4)
            {
                YBFDWKDR.DSYBFDWKDR.VybfdwkdrpcRow row = ((DataRowView)Bds.Current).Row as YBFDWKDR.DSYBFDWKDR.VybfdwkdrpcRow;
                if (row.zt == 1)
                {
                    ClsMsgBox.Ts("该招商信息已匹配！", ObjG.CustomMsgBox, this);
                    return;
                }
                else
                    PosMatching();
            }
            else
            {
                FrmYBFDWKMX f = new FrmYBFDWKMX();
                f.Prepare(PriRow.id, "Z");
                f.ShowDialog();
            }
        }
        //赵宝宝  20170918
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
                    YBFDWKDR.DSYBFDWKDR.VybfdwkdrpcRow pcrow = ((DataRowView)Bds.Current).Row as YBFDWKDR.DSYBFDWKDR.VybfdwkdrpcRow;
                    //根据获取的机构信息查询未审核(zt)未匹配(ppzt)的日报信息,根据时间(正向排序)和金额(反向排序)进行排序
                    DataTable table_rbpcs = ClsRWMSSQLDb.GetDataTable(" SELECT a.id,b.zh,b.zhmc,a.ckbz,a.dkje,a.inssj,convert(int,convert(nvarchar(20),a.inssj,112)) as sj FROM dbo.Tfmsrbpc AS a INNER JOIN  tfmsyhzh AS b ON a.jgid=b.jgid WHERE a.zt=0 AND a.ppzt=0 AND  b.yhlxid=49 AND b.zhlxid=1 AND b.zt=0 and a.spjgid=" + PriSpjgid + " and b.zh in( SELECT gsykth  FROM dbo.Tfmsybfdwkzsdr WHERE pcid= " + pcrow.id + ")  ORDER BY sj asc,a.dkje  desc", ClsGlobals.CntStrTMS);
                    TfmsybfdwkzsdrTableAdapter.FillByPcid(DSYBFDWKDR1.Tfmsybfdwkzsdr, pcrow.id);
                    com.CommandText += " Update Tfmsybfdwkdrpc set zt = 1 where id =" + pcrow.id + " ;";
                    com.ExecuteNonQuery();
                    foreach (YBFDWKDR.DSYBFDWKDR.TfmsybfdwkzsdrRow row in DSYBFDWKDR1.Tfmsybfdwkzsdr)
                    {
                        if (row.jysq.ToString().Length > 0)
                        {
                            //根据银行账号（状态有效zt、银行类型yjlx和账号类型zhlxid）寻找机构信息，根据获取的机构信息查询未审核(zt)未匹配(ppzt)的日报信息,根据时间(正向排序)和金额(反向排序)进行排序
                            decimal d = Convert.ToDecimal(row.d);
                            if (d != 0)
                            {
                                //判断交易日期之前是否有符合的缴款日报,如果有进行逻辑操作(匹配的逻辑是更改Tfmsybfdwkzsdr表中的rbpcid,dkje,cyje和zt。更新Tfmsrbpc的ppzt一列) 
                                DataRow[] rows_rbpc = table_rbpcs.Select(string.Format(" sj<{0} and dkje<={1}  and zh='{2}' ", Convert.ToInt32(row.jysq.ToString()), row.d, row.gsykth));
                                decimal Pricyje = 0;
                                int rowCouts = rows_rbpc.Length;
                                bool abool = true;
                                if (rowCouts > 0)
                                {
                                    int count = 0;//记录是否有匹配的
                                    DataRow rows_top = rows_rbpc[0];
                                    int rbpcid = Convert.ToInt32(rows_top["id"].ToString());
                                    decimal dkje = Convert.ToDecimal(rows_top["dkje"].ToString());//代扣金额
                                    Pricyje = Convert.ToDecimal(d - dkje);
                                    com.CommandText = "Update Tfmsrbpc set ppzt = 5 where id =" + rbpcid + " ;"; //修改日报批次匹配状态为匹配成功
                                    com.CommandText += " Update  Tfmsybfdwkzsdr set zt = 5,dkje=" + dkje + ",cyje=" + Pricyje + ",rbpcid =" + rbpcid + " where id =" + row.id + " ;";
                                    com.ExecuteNonQuery();
                                    PriSucceed++;
                                    count++;
                                }
                                //如果没有则判断当日是否有符合的缴款日报（匹配的逻辑是更改Tfmsybfdwkzsdr表中的rbpcid,dkje,cyje和zt。更新Tfmsrbpc的ppzt一列）
                                else
                                {
                                    DateTime date = DateTime.ParseExact(row.jysq.ToString(), "yyyyMMdd", Thread.CurrentThread.CurrentCulture);
                                    string datejysq = (date.AddDays(1)).ToString("yyyyMMdd");
                                    rows_rbpc = table_rbpcs.Select(string.Format(" sj>={0}  and sj<{2} and dkje<={1} and zh='{3}' ", Convert.ToInt32(row.jysq.ToString()), row.d, Convert.ToInt32(datejysq), row.gsykth));
                                    rowCouts = rows_rbpc.Length;
                                    if (rowCouts > 0)
                                    {
                                        int count = 0;//记录是否有匹配的
                                        DataRow rows_top = rows_rbpc[0];
                                        int rbpcid = Convert.ToInt32(rows_top["id"].ToString());
                                        decimal dkje = Convert.ToDecimal(rows_top["dkje"].ToString());//代扣金额
                                        Pricyje = Convert.ToDecimal(d - dkje);
                                        com.CommandText = "Update Tfmsrbpc set ppzt = 5 where id =" + rbpcid + " ;"; //修改日报批次匹配状态为匹配成功
                                        com.CommandText += " Update  Tfmsybfdwkzsdr set zt = 5,dkje=" + dkje + ",cyje=" + Pricyje + ",rbpcid =" + rbpcid + " where id =" + row.id + " ;";
                                        com.ExecuteNonQuery();
                                        PriSucceed++;
                                        count++;
                                    }
                                    //如果还是没有只更新  Tfmsybfdwkzsdr表中的zt
                                    else
                                    {
                                        com.CommandText = " Update Tfmsybfdwkzsdr set zt = 10 where id =" + row.id;
                                        com.ExecuteNonQuery();
                                        PriFailure++;
                                        abool = false;
                                    }
                                }
                                if (abool)
                                    table_rbpcs.Rows.Remove(rows_rbpc[0]);
                            }
                            else
                            {
                                com.CommandText = " Update Tfmsybfdwkzsdr set zt = 10 where id =" + row.id;
                                com.ExecuteNonQuery();
                                PriFailure++;
                            }
                        }
                        else
                        {
                            com.CommandText = " Update Tfmsybfdwkzsdr set zt = 10 where id =" + row.id;
                            com.ExecuteNonQuery();
                            PriFailure++;
                        }
                    }
                    ClsMsgBox.Ts("共" + DSYBFDWKDR1.Tfmsybfdwkzsdr.Rows.Count + "条，匹配成功" + PriSucceed + "条，失败" + PriFailure + "条！", ObjG.CustomMsgBox, this);
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
        #endregion
    }
}
