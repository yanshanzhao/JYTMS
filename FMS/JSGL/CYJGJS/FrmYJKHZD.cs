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
using FMS.SeleFrm;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Configuration;
using FMS.SelectFrm;
#endregion

namespace FMS.JSGL.CYJGJS
{
    public partial class FrmYJKHZD : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        #endregion
        public FrmYJKHZD()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            this.VfmsyjkhzdTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
        }

        private void BtnJg_Click(object sender, EventArgs e)
        {
            FrmSelectJg f = new FrmSelectJg();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtbJGmc.Text = f.PubDictAttrs["mc"];
                this.lblJgid.Text = f.PubDictAttrs["id"];
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtbJGmc.Text = "";
                this.lblJgid.Text = "0";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DSYJKHZD1.EnforceConstraints = false;
            string Where = " where 1=1 ";
            if (TxtbJGmc.Text.Trim().Length > 0)
            {
                Where += " and jsjgid='" + lblJgid.Text + "'";
            }
            if (TxtDqmc.Text.Trim().Length > 0)
            {
                Where += " and sldqmc='" + TxtDqmc.Text.Trim() + "'";
            }
            if (TxtBKhbh.Text.Trim().Length > 0)
            {
                Where = Where + " and khbh = '" + TxtBKhbh.Text.Trim().ToString() + "'";
            }
            //if (this.DtpStart.Value > this.DtpStop.Value)
            //{
            //    ClsMsgBox.Ts("开始时间不能大于结束时间！");
            //    return;
            //}
            Where = Where + "  and jzsj >='" + DtpStart.Value + "'and jzsj < DateAdd(dd,+1, '" + DtpStop.Value + "')";
            this.VfmsyjkhzdTableAdapter1.FillByWhere(DSYJKHZD1.Vfmsyjkhzd, Where);

            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);

            }
            else
            {
                DataRow dr = DSYJKHZD1.Vfmsyjkhzd.NewRow();
                dr["zjs"] = DSYJKHZD1.Vfmsyjkhzd.Compute("SUM(zjs)", null);
                dr["zzl"] = DSYJKHZD1.Vfmsyjkhzd.Compute("SUM(zzl)", null);
                dr["fhyj"] = DSYJKHZD1.Vfmsyjkhzd.Compute("SUM(fhyj)", null);
                dr["thyj"] = DSYJKHZD1.Vfmsyjkhzd.Compute("SUM(thyj)", null);
                dr["dsfyj"] = DSYJKHZD1.Vfmsyjkhzd.Compute("SUM(dsfyj)", null);
                dr["bf"] = DSYJKHZD1.Vfmsyjkhzd.Compute("SUM(bf)", null);
                dr["dsk"] = DSYJKHZD1.Vfmsyjkhzd.Compute("SUM(dsk)", null);
                dr["zyf"] = DSYJKHZD1.Vfmsyjkhzd.Compute("SUM(zyf)", null);
                dr["khbh"] = "合计";
                DSYJKHZD1.Vfmsyjkhzd.Rows.Add(dr);
            }
                
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            else
            {
                string PriFln = "月结客户账单" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
                string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
                HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
                //写入数据
                HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
                sheet1.DefaultColumnWidth = 17;
                sheet1.SetColumnWidth(0, 25 * 120);
                sheet1.SetColumnWidth(1, 25 * 120);
                sheet1.SetColumnWidth(2, 25 * 120);
                sheet1.SetColumnWidth(3, 25 * 120);
                sheet1.SetColumnWidth(4, 25 * 120);
                sheet1.SetColumnWidth(5, 25 * 120);
                sheet1.SetColumnWidth(6, 25 * 120);
                sheet1.SetColumnWidth(7, 25 * 120);
                sheet1.SetColumnWidth(8, 25 * 120);
                sheet1.SetColumnWidth(9, 25 * 120);
                sheet1.SetColumnWidth(10, 25 * 120);
                sheet1.SetColumnWidth(11, 25 * 120);
                sheet1.SetColumnWidth(12, 25 * 120);
                sheet1.SetColumnWidth(13, 25 * 120);
                sheet1.SetColumnWidth(14, 25 * 120);
                sheet1.SetColumnWidth(15, 25 * 120);
                sheet1.SetColumnWidth(16, 25 * 120);
                sheet1.SetColumnWidth(17, 25 * 120);
                sheet1.SetColumnWidth(18, 25 * 120);
                //写入标题
                HSSFRow titRow = sheet1.CreateRow(0) as HSSFRow;
                HSSFCell titCell = titRow.CreateCell(0) as HSSFCell;
                titRow.Height = 30 * 20;
                titCell.SetCellValue("月结客户发货情况统计表");
                //设置标题样式
                HSSFCellStyle style = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                //对其相关设置
                style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//中间对齐
                //设置字体的样式
                HSSFFont font = hssfworkbook.CreateFont() as HSSFFont;
                font.FontName = "宋体";
                font.FontHeightInPoints = 20;
                font.Boldweight = 700;
                style.SetFont(font);
                titCell.CellStyle = style;
                //合并标题行
                sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, Dgv.ColumnCount - 1));
                try
                {
                    //行名的的设置
                    HSSFRow row0 = (HSSFRow)sheet1.CreateRow(1);
                    HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                    LieFont.FontHeightInPoints = 10;
                    LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                    styleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    styleRow.SetFont(LieFont);
                    for (int i = 0; i < Dgv.ColumnCount; i++)
                    {
                        if (i == 0)
                            row0.CreateCell(i).SetCellValue("签约客户编码");
                        else
                            row0.CreateCell(i).SetCellValue(Dgv.Columns[i].HeaderText);
                        row0.Cells[i].CellStyle = styleRow;

                    }
                    int roowIndex = 2;
                    HSSFCellStyle styleRow1 = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    HSSFFont LieFont1 = (HSSFFont)hssfworkbook.CreateFont();
                    LieFont1.FontHeightInPoints = 9;
                    styleRow1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    styleRow1.SetFont(LieFont1);
                    //数据添加
                    HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                    HSSFCellStyle cellStyle1 = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    cellStyle1.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                    foreach (DataGridViewRow Row in Dgv.Rows)
                    {
                        HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                        for (int i = 0; i < Dgv.ColumnCount; i++)
                        {
                            if (i >= 14)
                            {
                                double n;
                                double m = 0;
                                if (double.TryParse(Row.Cells[i].Value.ToString(), out n))
                                {
                                    m = Convert.ToDouble(Row.Cells[i].Value.ToString());
                                }
                                hssfrow.CreateCell(i).SetCellValue(m);
                                hssfrow.Cells[i].CellStyle = cellStyle;
                            }
                            else if (i == 13)
                            {
                                int n;
                                int m = 0;
                                if (Int32.TryParse(Row.Cells[i].Value.ToString(), out n))
                                {
                                    m = Convert.ToInt32(Row.Cells[i].Value.ToString());
                                }
                                hssfrow.CreateCell(i).SetCellValue(m);
                                hssfrow.Cells[i].CellStyle = cellStyle1;
                            }
                            else
                            {
                                hssfrow.CreateCell(i).SetCellValue(Row.Cells[i].Value.ToString());
                                hssfrow.Cells[i].CellStyle = styleRow1;
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
                    ClsMsgBox.Cw("导出汇总报表失败", ex);
                }
            }
        }

        private void BtnDq_Click(object sender, EventArgs e)
        {
            FrmSelectDq fdq = new FrmSelectDq();
            fdq.Preapre();
            fdq.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(fdq_FormClosed);
            fdq.Show();
        }

        void fdq_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectDq f = sender as FrmSelectDq;
            if (f.DialogResult == DialogResult.OK)
            {
                TxtDqmc.Text = f.PubDictAttrs["dqmc"];
                TxtDqmc.Tag = f.PubDictAttrs["dqid"];
            }
            else
            {
                TxtDqmc.Text = "";
                TxtDqmc.Tag = 0;
            }
        }
    }
}
