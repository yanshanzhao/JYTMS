#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pub;
using JY.Pri;
using System.Data.SqlClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using JYPubFiles.Classes;
using Gizmox.WebGUI.Common.Interfaces;
using System.Configuration;
#endregion
namespace FMS.DSKGL.ZZYCDSKMX
{
    public partial class FrmZZYCDSKMX : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private int PriJgid;
        private string PriWhere;
        private string PriConStr;
        private DataTable PriData = new DataTable();
        private int PriRowIndex = 0;
        private int PriRowIndexId = 0;
        private int PriRowIndexCounts = 0;
        private FrmMsgBox Box = new FrmMsgBox();
        #endregion
        public FrmZZYCDSKMX()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            CmbFkfs.SelectedIndex = 0;
            CbmDskbz.SelectedIndex = 0;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriJgid = ObjG.Jigou.id;
            PriConStr = ClsGlobals.CntStrTMS;
            this.VfmszzycdskmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }
        #region 统计
        private void BtnTj_Click(object sender, EventArgs e)
        {
            int n = ClsRWMSSQLDb.GetInt(" SELECT  jgid  FROM dbo.Tfmsyhzh  WHERE (zhlxid = 50) AND (zt = 0) AND jgid = " + ObjG.Jigou.id, PriConStr);
            if (n <= 0)
            {
                JGts("系统未维护银行账户信息，请与代收款部联系电话：0531-58681288", new EventHandler(OpenFrm), Box, this);
                return;
            }
            FrmZZYCDSKTJ f = new FrmZZYCDSKTJ();
            f.ShowDialog();
            f.Prepare();
        }
        private void OpenFrm(object sender, EventArgs e)
        {
            FrmMsgBox c = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.OK)
            {
                FrmZZYCDSKTJ f1 = new FrmZZYCDSKTJ();
                f1.ShowDialog();
                f1.Prepare();
            }
        }
        private static void InvokeFocusCommand(Control objControl, Control aControl = null)
        {
            if (aControl == null)
                return;
            IApplicationContext objApplicationContext = aControl.Context as IApplicationContext;
            if (objApplicationContext != null)
                objApplicationContext.SetFocused(objControl, true);
        }
        public static void JGts(string mess, EventHandler hdl, FrmMsgBox aMsgBox = null, Control aParControl = null, float aFontsize = 14)
        {
            aMsgBox.Text = "警告";
            aMsgBox.LblMess.Text = mess;
            aMsgBox.LblMess.Font = new System.Drawing.Font("黑体", aFontsize, System.Drawing.FontStyle.Bold);
            aMsgBox.LblMess.ForeColor = System.Drawing.Color.Red;
            aMsgBox.Btn1.Text = "确定";
            aMsgBox.Btn1.AutoSize = true;
            aMsgBox.Btn1.DialogResult = DialogResult.OK;
            aMsgBox.Btn1.TabStop = true;
            aMsgBox.Tag = null;
            aMsgBox.Btn2.Text = "取消";
            aMsgBox.Btn2.AutoSize = true;
            aMsgBox.Btn2.DialogResult = DialogResult.Cancel;
            aMsgBox.Btn2.Visible = true;
            aMsgBox.ShowDialog();
            aMsgBox.FrmCloseHdl = hdl;
            InvokeFocusCommand(aMsgBox, aParControl);
        }
        #endregion
        #region 导出汇总
        private void BtnExlhz_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息!", ObjG.CustomMsgBox, this);
                return;
            }
            else
            {
                string RowTiems = "";
                if (DtpStart.Checked && DtpStop.Checked)
                {
                    RowTiems = DtpStart.Value.ToString("yyyy-MM-dd") + "~" + DtpStop.Value.ToString("yyyy-MM-dd");
                }
                else if (DtpStart.Checked && !DtpStop.Checked)
                {
                    RowTiems = DtpStart.Value.ToString("yyyy-MM-dd") + "~" + DateTime.Now.ToString("yyyy-MM-dd");
                }
                else if (!DtpStart.Checked && DtpStop.Checked)
                {
                    RowTiems = DateTime.Now.ToString("yyyy-MM-dd") + "~" + DtpStop.Value.ToString("yyyy-MM-dd");
                }
                string PriFln = "制作应存代收款明细导出汇总" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
                string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
                HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
                //写入数据
                HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
                sheet1.DefaultColumnWidth = 17;
                sheet1.SetColumnWidth(1, 25 * 100);
                //写入标题
                HSSFRow titRow = sheet1.CreateRow(0) as HSSFRow;
                HSSFCell titCell = titRow.CreateCell(0) as HSSFCell;
                titRow.Height = 30 * 20;
                titCell.SetCellValue("代收款应存明细");
                //设置标题样式
                HSSFCellStyle style = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                //对其相关设置
                style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//中间对齐
                //设置字体的样式
                HSSFFont font = hssfworkbook.CreateFont() as HSSFFont;
                font.FontName = "宋体";
                font.FontHeightInPoints = 14;
                font.Boldweight = 700;
                style.SetFont(font);
                titCell.CellStyle = style;
                //合并标题行
                sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 6));
                #region 写入时间和机构
                //写入时间和机构
                HSSFCellStyle styleCell = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                styleCell.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
                HSSFRow timeRow = sheet1.CreateRow(1) as HSSFRow;
                HSSFCell timeCell = timeRow.CreateCell(0) as HSSFCell;
                timeCell.SetCellValue("制单机构:");
                timeCell.CellStyle = styleCell;
                HSSFCell timeCell2 = timeRow.CreateCell(1) as HSSFCell;
                timeCell2.SetCellValue(ObjG.Jigou.mc);
                HSSFRow timeRow1 = sheet1.CreateRow(2) as HSSFRow;
                HSSFCell timeCell3 = timeRow1.CreateCell(0) as HSSFCell;
                timeCell3.SetCellValue("制单日期:");
                timeCell3.CellStyle = styleCell;
                HSSFCell timeCell4 = timeRow1.CreateCell(1) as HSSFCell;
                timeCell4.SetCellValue(RowTiems);
                sheet1.AddMergedRegion(new CellRangeAddress(1, 1, 1, 6));
                sheet1.AddMergedRegion(new CellRangeAddress(2, 2, 1, 6));
                #endregion
                ///设置单元格样式(数量居中显示粗体)
                HSSFCellStyle cellStyleC = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
                cellStyleC.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
                HSSFFont font1 = hssfworkbook.CreateFont() as HSSFFont;
                font1.FontHeightInPoints = 10;
                font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                cellStyleC.SetFont(font1);
                try
                {
                    //行名的的设置
                    HSSFRow row0 = (HSSFRow)sheet1.CreateRow(3);
                    HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                    LieFont.FontHeightInPoints = 12;
                    LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                    styleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    styleRow.SetFont(LieFont);
                    for (int i = 0; i < 7; i++)
                    {
                        if (i == 4)
                        {
                            row0.CreateCell(i).SetCellValue("POS机编号");
                            row0.Cells[i].CellStyle = styleRow;
                        }
                        else if (i == 5)
                        {
                            row0.CreateCell(i).SetCellValue("代收款金额");
                            row0.Cells[i].CellStyle = styleRow;
                        }
                        else if (i == 6)
                        {
                            row0.CreateCell(i).SetCellValue("付款方式");
                            row0.Cells[i].CellStyle = styleRow;
                        }
                        else
                        {
                            row0.CreateCell(i).SetCellValue(Dgv.Columns[i + 1].HeaderText);
                            row0.Cells[i].CellStyle = styleRow;
                        }

                    }
                    int roowIndex = 4;
                    double sum = 0;
                    //数据添加
                    HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                    foreach (DataGridViewRow Row in Dgv.Rows)
                    {
                        HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                        double dsk = 0;
                        for (int i = 0; i < 7; i++)
                        {
                            if (i == 4)
                                hssfrow.CreateCell(i).SetCellValue(" ");
                            else if (i == 5)
                            {
                                dsk = Convert.ToDouble(Row.Cells[i].Value);
                                sum += dsk;
                                hssfrow.CreateCell(i).SetCellValue(dsk);
                                hssfrow.Cells[i].CellStyle = cellStyle;
                            }
                            else if (i == 6)
                                hssfrow.CreateCell(i).SetCellValue(Row.Cells[13].Value.ToString());
                            else
                                hssfrow.CreateCell(i).SetCellValue(Row.Cells[i + 1].Value.ToString());
                        }
                        roowIndex++;
                    }
                    HSSFRow hssfrowSum = (HSSFRow)sheet1.CreateRow(roowIndex);
                    hssfrowSum.CreateCell(0).SetCellValue("总计");
                    hssfrowSum.CreateCell(5).SetCellValue(sum);
                    FileStream file = new FileStream(PriFlp, FileMode.Create);
                    hssfworkbook.Write(file);
                    file.Close();
                    this.ctrlDownLoad1.download(PriFlp, true);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("导出汇总报表失败", ex);
                }
            }
        }
        #endregion
        #region 导出明细
        private void BtnExlmx_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息!", ObjG.CustomMsgBox, this);
                return;
            }
            else
            {
                GetDataYdmx();
                string PriFln = "制作应存代收款明细导出明细" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
                string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
                HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
                //写入数据
                HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
                sheet1.DefaultColumnWidth = 17;
                sheet1.SetColumnWidth(1, 25 * 100);
                //写入标题
                HSSFRow titRow = sheet1.CreateRow(0) as HSSFRow;
                HSSFCell titCell = titRow.CreateCell(0) as HSSFCell;
                titRow.Height = 30 * 20;
                titCell.SetCellValue("代收款应存明细运单明细");
                //设置标题样式
                HSSFCellStyle style = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                //对其相关设置
                style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//中间对齐
                //设置字体的样式
                HSSFFont font = hssfworkbook.CreateFont() as HSSFFont;
                font.FontName = "宋体";
                font.FontHeightInPoints = 14;
                font.Boldweight = 700;
                style.SetFont(font);
                titCell.CellStyle = style;
                //合并标题行
                sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 6));
                ///设置单元格样式(数量居中显示粗体)
                HSSFCellStyle cellStyleC = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
                cellStyleC.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
                HSSFFont font1 = hssfworkbook.CreateFont() as HSSFFont;
                font1.FontHeightInPoints = 10;
                font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                cellStyleC.SetFont(font1);
                try
                {
                    //行名的的设置
                    HSSFRow row0 = (HSSFRow)sheet1.CreateRow(1);
                    HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                    LieFont.FontHeightInPoints = 12;
                    LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                    styleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    styleRow.SetFont(LieFont);
                    row0.CreateCell(0).SetCellValue("受理日期");
                    row0.Cells[0].CellStyle = styleRow;
                    row0.CreateCell(1).SetCellValue("受理大区");
                    row0.Cells[1].CellStyle = styleRow;
                    row0.CreateCell(2).SetCellValue("受理机构");
                    row0.Cells[2].CellStyle = styleRow;
                    row0.CreateCell(3).SetCellValue("到达大区");
                    row0.Cells[3].CellStyle = styleRow;
                    row0.CreateCell(4).SetCellValue("到达站");
                    row0.Cells[4].CellStyle = styleRow;
                    row0.CreateCell(5).SetCellValue("发货方");
                    row0.Cells[5].CellStyle = styleRow;
                    row0.CreateCell(6).SetCellValue("收货方");
                    row0.Cells[6].CellStyle = styleRow;
                    row0.CreateCell(7).SetCellValue("货运单号");
                    row0.Cells[7].CellStyle = styleRow;
                    row0.CreateCell(8).SetCellValue("代收款金额");
                    row0.Cells[8].CellStyle = styleRow;
                    row0.CreateCell(9).SetCellValue("实发金额");
                    row0.Cells[9].CellStyle = styleRow;
                    row0.CreateCell(10).SetCellValue("结算方式");
                    row0.Cells[10].CellStyle = styleRow;
                    row0.CreateCell(11).SetCellValue("发款日期");
                    row0.Cells[11].CellStyle = styleRow;
                    row0.CreateCell(12).SetCellValue("服务卡号");
                    row0.Cells[12].CellStyle = styleRow;
                    row0.CreateCell(13).SetCellValue("代收种类");
                    row0.Cells[13].CellStyle = styleRow;
                    row0.CreateCell(14).SetCellValue("签收日期");
                    row0.Cells[14].CellStyle = styleRow;
                    row0.CreateCell(15).SetCellValue("签收人");
                    row0.Cells[15].CellStyle = styleRow;
                    row0.CreateCell(16).SetCellValue("签收人证件种类");
                    row0.Cells[16].CellStyle = styleRow;
                    row0.CreateCell(17).SetCellValue("签收人证件号");
                    row0.Cells[17].CellStyle = styleRow;
                    row0.CreateCell(18).SetCellValue("委托人签名");
                    row0.Cells[18].CellStyle = styleRow;
                    row0.CreateCell(19).SetCellValue("委托人证件号码");
                    row0.Cells[19].CellStyle = styleRow;
                    row0.CreateCell(20).SetCellValue("委托证件类型");
                    row0.Cells[20].CellStyle = styleRow;
                    row0.CreateCell(21).SetCellValue("制单日期");
                    row0.Cells[21].CellStyle = styleRow;
                    row0.CreateCell(22).SetCellValue("审核日期");
                    row0.Cells[22].CellStyle = styleRow;
                    int roowIndex = 2;
                    //数据添加
                    HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                    HSSFCellStyle cellStyleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    cellStyleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    for (int m = 0; m < PriData.Rows.Count; m++)
                    {
                        HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                        for (int i = 0; i < 23; i++)
                        {
                            if (i == 0 || i == 11 || i == 14)
                            {

                                DateTime dTime;
                                if (DateTime.TryParse(PriData.Rows[m][i].ToString(), out dTime))
                                {
                                    hssfrow.CreateCell(i).SetCellValue(Convert.ToDateTime(PriData.Rows[m][i]).ToString("yyyy-MM-dd"));
                                    hssfrow.Cells[i].CellStyle = cellStyleRow;
                                }
                                else
                                {
                                    hssfrow.CreateCell(i).SetCellValue(PriData.Rows[m][i].ToString());
                                    hssfrow.Cells[i].CellStyle = cellStyleRow;
                                }
                            }
                            else if (i == 8 || i == 9)
                            {
                                double n;
                                if (double.TryParse(PriData.Rows[m][i].ToString(), out n))
                                {
                                    hssfrow.CreateCell(i).SetCellValue(Convert.ToDouble(PriData.Rows[m][i]));
                                    hssfrow.Cells[i].CellStyle = cellStyle;
                                }
                                else
                                {
                                    hssfrow.CreateCell(i).SetCellValue(PriData.Rows[m][i].ToString());
                                    hssfrow.Cells[i].CellStyle = cellStyleRow;
                                }
                            }
                            else
                            {
                                hssfrow.CreateCell(i).SetCellValue(PriData.Rows[m][i].ToString());
                                hssfrow.Cells[i].CellStyle = cellStyleRow;
                            }
                        }
                        roowIndex++;
                    }
                    FileStream file = new FileStream(PriFlp, FileMode.Create);
                    hssfworkbook.Write(file);
                    file.Close();
                    this.ctrlDownLoad1.download(PriFlp, true);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("导出制作应存代收款明细导出明细报表失败", ex);
                }
            }
        }
        #endregion
        #region 查询
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                PriWhere = " where    jgid=" + PriJgid + " and zt<> '0' and zt<>'5'   ";
                PriWhere += string.IsNullOrEmpty(TxtBRbdh.Text.Trim()) ? "  " : " and rbdh like '%" + TxtBRbdh.Text.Trim() + "%'";
                if (CbmDskbz.SelectedIndex != 0)
                    PriWhere = PriWhere + " and ztmc='" + CbmDskbz.Text + "'";
                if (CmbFkfs.SelectedIndex != 0)
                    PriWhere = PriWhere + " and zffsmc='" + CmbFkfs.Text + "'";
                if (DtpStart.Checked && DtpStop.Checked)
                {
                    PriWhere = PriWhere + "  and zdsj between'" + DtpStart.Value + "'and DateAdd(dd,+1, '" + DtpStop.Value + "')";
                }
                else if (DtpStart.Checked && !DtpStop.Checked)
                {
                    PriWhere = PriWhere + "  and zdsj between'" + DtpStart.Value + "'and DateAdd(dd,+1, '" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                }
                else if (!DtpStart.Checked && DtpStop.Checked)
                {
                    PriWhere = PriWhere + "   and zdsj <='" + DtpStop.Value + "'";
                }
                if (Txthydh.Text.Trim().Length > 0)
                {
                    int apcid = GetPcid();
                    if (apcid > 0)
                        PriWhere = PriWhere + " and id= " + apcid;
                }
                Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select id,rbdh,zh,zhmc,yhlx,tojgmc,dsk,sxf,zdsj,ztmc,zffsmc,khh,'详细信息' as Xq,'删除' as Del,cnt,jgzh,jgzhmc,jgmc from Vfmszzycdskmx  " + PriWhere, PriConStr);
                //VfmszzycdskmxTableAdapter1.FillByWhere(DSZZYCMX1.Vfmszzycdskmx, PriWhere);
                if (Dgv.RowCount == 0)
                    ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("查询异常！", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion
        #region 鼠标单选
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1)
                return;
            if (e.ColumnIndex == 14)//详细
            {
                string aRhdh = Dgv.Rows[e.RowIndex].Cells[DgvColTxtrbdh.Name].Value.ToString();
                string aSkjg = Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgmc.Name].Value.ToString();
                string aDsk = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString();
                string aSxf = Dgv.Rows[e.RowIndex].Cells[DgvColTxtsxf.Name].Value.ToString();
                int n;
                int aCouts = 0;
                if (Int32.TryParse(Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtCounts.Name].Value), out n))
                {
                    aCouts = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtCounts"].Value);
                }
                int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtId"].Value);
                FrmDSKRBLL f = new FrmDSKRBLL();
                f.Prepare(aRhdh, aSkjg, aDsk, aSxf, aCouts.ToString(), aId);
                f.ShowDialog();

            }
            if (e.ColumnIndex == 15)//删除
            {
                string aZtmc = Dgv.Rows[e.RowIndex].Cells["DgvColTxtdskbz"].Value.ToString();

                if (aZtmc != "已提交")
                {
                    ClsMsgBox.Ts("该代收款日报已经审核或已导出,无发删除！", ObjG.CustomMsgBox, this);
                    return;
                }

                else
                {
                    int n;
                    int aCouts = 0;
                    PriRowIndexCounts = 0; PriRowIndex = 0;
                    if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtCounts.Name].Value.ToString(), out n))
                    {
                        aCouts = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtCounts"].Value);//有问题
                    }
                    PriRowIndexId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtId"].Value);
                    PriRowIndexCounts = aCouts;
                    PriRowIndex = e.RowIndex;
                    ClsMsgBox.YesNo("是否删除已提交代收款日报", new EventHandler(DelYh), ObjG.CustomMsgBox, this);
                    //GetRowLing(aId, aCouts);
                }
            }
        }
        private void DelYh(object sender, EventArgs e)
        {
            FrmMsgBox c = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {
                //sjdskzt(上缴代收款状态)：默认值为0-未缴款；15:可删除  10-已保存；20-已提交；30-已缴款 
                using (SqlConnection conn = new SqlConnection(PriConStr))
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    SqlCommand comm = new SqlCommand();
                    try
                    {
                        comm.Connection = conn;
                        comm.Transaction = trans;
                        string cmdText = "";
                        cmdText = " update tfmsdsk set sjdskzt='15' where id in(select dskid from Tfmsdskjkmx where pcid=" + PriRowIndexId + ");";
                        comm.CommandText = cmdText;
                        int influenceSum = comm.ExecuteNonQuery();
                        cmdText = " update Tfmsdskjkpc set  zt='5' where id=" + PriRowIndexId;
                        comm.CommandText = cmdText;
                        influenceSum = influenceSum + comm.ExecuteNonQuery();
                        if (influenceSum == PriRowIndexCounts + 1)
                        {
                            //提交事物
                            ClsMsgBox.Ts("删除成功！", c, this);
                            trans.Commit();
                            Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select id,rbdh,zh,zhmc,yhlx,tojgmc,dsk,sxf,zdsj,ztmc,zffsmc,khh,'详细信息' as Xq,'删除' as Del,cnt from Vfmszzycdskmx  " + PriWhere, PriConStr);
                        }
                        else
                        {
                            //回滚事物
                            ClsMsgBox.Ts("删除失败！", c, this);
                            trans.Rollback();
                        }
                    }
                    catch
                    {
                        //回滚事物
                        try
                        {
                            ClsMsgBox.Cw("删除异常！", c, this);
                            trans.Rollback();
                        }
                        catch (SqlException ex1)
                        {
                            if (trans.Connection != null)
                                ClsMsgBox.Cw("回滚失败! 异常类型:" + ex1.GetType(), ex1, c, this);
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        #endregion
        //#region 修改确认的日报
        //private void GetRowLing(int aId, int aCounts)
        //{
        //    //sjdskzt(上缴代收款状态)：默认值为0-未缴款；15:可删除  10-已保存；20-已提交；30-已缴款 
        //    using (SqlConnection conn = new SqlConnection(PriConStr))
        //    {
        //        conn.Open();
        //        SqlTransaction trans = conn.BeginTransaction();
        //        SqlCommand comm = new SqlCommand();
        //        try
        //        {
        //            comm.Connection = conn;
        //            comm.Transaction = trans;
        //            string cmdText = "";
        //            cmdText = " update tfmsdsk set sjdskzt='10' where id in(select dskid from Tfmsdskjkmx where pcid=" + aId + ");";
        //            comm.CommandText = cmdText;
        //            int influenceSum = comm.ExecuteNonQuery();
        //            cmdText = " update Tfmsdskjkpc set  zt='0' where id=" + aId;
        //            comm.CommandText = cmdText;
        //            influenceSum = influenceSum + comm.ExecuteNonQuery();
        //            if (influenceSum == aCounts + 1)
        //            {
        //                //提交事物
        //                ClsMsgBox.Ts("删除成功！", ObjG.CustomMsgBox, this);
        //                trans.Commit();
        //                Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select id,rbdh,zh,zhmc,yhlx,tojgmc,dsk,sxf,zdsj,ztmc,zffsmc,khh,'详细信息' as Xq,'删除' as Del,cnt from Vfmszzycdskmx  " + PriWhere, PriConStr);
        //            }
        //            else
        //            {
        //                //回滚事物
        //                ClsMsgBox.Ts("删除失败！", ObjG.CustomMsgBox, this);
        //                trans.Rollback();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            //回滚事物
        //            try
        //            {
        //                ClsMsgBox.Cw("删除异常！", ex, ObjG.CustomMsgBox, this);
        //                trans.Rollback();
        //            }
        //            catch (SqlException ex1)
        //            {
        //                if (trans.Connection != null)
        //                    ClsMsgBox.Cw("回滚失败! 异常类型:" + ex1.GetType(), ex1, ObjG.CustomMsgBox, this);
        //            }
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //}
        //#endregion
        private void GetDataYdmx()
        {
            PriData.Clear();
            List<int> ListPCid = new List<int>();
            for (int i = 0; i < Dgv.RowCount; i++)
            {
                int aPcid = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtId"].Value);
                ListPCid.Add(aPcid);
            }
            PriData = ClsRWMSSQLDb.GetDataTable(" SELECT [inssj],[sldqmc],[sljgmc],[zddqmc],[zdjgmc],[fhlxr],[dhlxr],[bh],[dsk],[sfje],[jfsf],[dskffcgsj],[fwkh],[dslxmc],[qssj],[qsr],[zjlxmc],[qsrzjh],[dlqsr],[dlqsrzjlxmc],[dlqsrzjh],[zdsj],[shsj] FROM  [Vfmsdskycydmx] where pcid in (" + string.Join(",", ListPCid) + ")", PriConStr);
        }
        private int GetPcid()
        {
            int apcid = 0;
            DataRow dr = ClsRWMSSQLDb.GetDataRow(" select pcid from Vfmsdskrbxx where bh='" + Txthydh.Text.Trim().ToString() + "' ", ClsGlobals.CntStrTMS);
            if (dr != null)
            {
                int n;
                if (Int32.TryParse(dr[0].ToString(), out n))
                {
                    apcid = Convert.ToInt32(dr[0]);
                }
            }
            return apcid;
        }
    }
}
