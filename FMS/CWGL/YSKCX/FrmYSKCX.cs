#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Linq;
using JY.Pri;
using JY.Pub;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Configuration;
#endregion

namespace FMS.CWGL.YSKCX
{
    public partial class FrmYSKCX : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private int PriJgid = 0;
        private string PriJgmc = "";
        private int PriYwqyIndex = 0;
        private int PriJzlxIndex = 0;
        private int PriSfycIndex = 0;
        private DateTime PriStartSj = DateTime.Now;
        private DateTime PriStopSj = DateTime.Now;
        #endregion
        public FrmYSKCX()
        {
            InitializeComponent();
        }

        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG; 
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);

            this.CmbYwqy.SelectedIndex = 0;
            this.CmbSfyc.SelectedIndex = 0;
            this.CmbJzlx.SelectedIndex = 0;
            PnlMain.Controls.Add(PnlJgcx);
            PnlJgcx.Visible = false;
            VfmsyskcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.TxtJgmc.Text = ObjG.Jigou.mc;
            PriJgid = ObjG.Jigou.id;
        }
        #region 机构查询
        //private void DgvJgcx_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    this.TxtJgmc.Text = DgvJgcx.CurrentRow.Cells[DgvColTxtJgmc.Name].Value.ToString();
        //    PriJgid = Convert.ToInt32(DgvJgcx.CurrentRow.Cells["DgvColTxtjgid"].Value.ToString());
        //    PriJgmc = DgvJgcx.CurrentRow.Cells[DgvColTxtJgmc.Name].Value.ToString();
        //    this.PnlJgcx.Visible = false;
        //    PriJgDt.Dispose();
        //}
        //private void DgvJgcx_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 8)
        //    {
        //        if (TxtJg.Text.Trim().Length != 0)
        //            TxtJg.Text = TxtJg.Text.Trim().Substring(0, TxtJg.Text.Trim().Length - 1);
        //        TxtJg.SelectionStart = TxtJg.Text.Length;
        //        TxtJg.Focus();
        //        PnlJgcx.Visible = false;
        //        PriJgDt.Dispose();
        //    }
        //}
        //private void DgvJgcx_LostFocus(object sender, EventArgs e)
        //{
        //    PnlJgcx.Visible = false;
        //    PriJgDt.Dispose();
        //}
        private void TxtJg_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            PnlJgcx.Visible = true;
            string CmdText = "select mc,pym,id from jyjckj.dbo.tjigou where parentLst like '%," + ObjG.Jigou.id + ",%' and (pym like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%' or  mc like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%')";
            PriJgDt = ClsRWMSSQLDb.GetDataTable(CmdText, ClsGlobals.CntStrTMS);
            //DgvJgcx.DataSource = PriJgDt;
            //DgvJgcx.Focus();
            LstV.DataSource = PriJgDt;
            LstV.Columns[0].Text = "机构名称";
            LstV.Columns[1].Text = "拼音码";
            LstV.Columns[2].Text = "jgid";
            LstV.Columns[2].Visible = false;
            LstV.Columns[0].Width = 120;
            LstV.Focus();
        }
        private void LstV_LostFocus(object sender, EventArgs e)
        {
            PnlJgcx.Visible = false;
            PriJgDt.Dispose();

        }
        private void LstV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                if (TxtJg.Text.Trim().Length != 0)
                    TxtJg.Text = TxtJg.Text.Trim().Substring(0, TxtJg.Text.Trim().Length - 1);
                TxtJg.SelectionStart = TxtJg.Text.Length;
                TxtJg.Focus();
                PnlJgcx.Visible = false;
                PriJgDt.Dispose();
            }
            if (LstV.Items.Count > 0)
            {
                if (e.KeyChar == 13)
                {
                    this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
                    PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
                    PriJgmc = LstV.SelectedItems[0].SubItems[0].Text;
                    this.PnlJgcx.Visible = false;
                    PriJgDt.Dispose();
                }
            }
        }
        private void LstV_DoubleClick(object sender, EventArgs e)
        {
            this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
            PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
            PriJgmc = LstV.SelectedItems[0].SubItems[0].Text;
            this.PnlJgcx.Visible = false;
            PriJgDt.Dispose();
        }
        #endregion
        #region 查询
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (PriJgid == 0)
            {
                ClsMsgBox.Ts("请选择查询的机构！", ObjG.CustomMsgBox, this);
                return;
            }
            LblHj.Text = "合计：0元";
            string aWhere = " where   inssj >= '" + DtpQrStart.Value.Date + "' and inssj < '" + DtpQrStop.Value.AddDays(1).Date + "' and jsjgid in( select ID from jyjckj.dbo.tjigou where parentLst like '%," + PriJgid + ",%')";
            if (CmbYwqy.SelectedIndex != 0)
                aWhere = aWhere + " and ywqy='" + CmbYwqy.Text + "'";
            if (CmbSfyc.SelectedIndex != 0)
                aWhere = aWhere + " and sjzt='" + CmbSfyc.Text + "'";
            if (CmbJzlx.SelectedIndex != 0)
                aWhere = aWhere + " and jzlx='" + CmbJzlx.Text + "'";
            this.VfmsyskcxTableAdapter1.FillByWhere1(DSYSKCX1.Vfmsyskcx, aWhere);

            PriYwqyIndex = CmbYwqy.SelectedIndex;
            PriJzlxIndex = CmbJzlx.SelectedIndex;
            PriSfycIndex = CmbSfyc.SelectedIndex;
            PriStartSj = DtpQrStart.Value;
            PriStopSj = DtpQrStop.Value;

            if (Dgv.RowCount == 1)
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
            LblHj.Text = "合计：" + DSYSKCX1.Vfmsyskcx.AsEnumerable().Sum(s => s.Field<decimal>("jezj"))/2 + "元";
        }
        #endregion
        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "应收款查询" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
            //写入数据
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.DefaultColumnWidth = 17;
            sheet1.SetColumnWidth(0, 25 * 120);
            sheet1.SetColumnWidth(1, 25 * 120);
            sheet1.SetColumnWidth(2, 25 * 190);
            sheet1.SetColumnWidth(3, 25 * 120);
            sheet1.SetColumnWidth(4, 25 * 120);
            sheet1.SetColumnWidth(5, 25 * 120);
            sheet1.SetColumnWidth(6, 25 * 120);
            sheet1.SetColumnWidth(7, 25 * 120);
            sheet1.SetColumnWidth(8, 25 * 160);
            sheet1.SetColumnWidth(9, 25 * 160);
            sheet1.SetColumnWidth(10, 25 * 160);
            sheet1.SetColumnWidth(11, 25 * 160);
            sheet1.SetColumnWidth(12, 25 * 160);
            sheet1.SetColumnWidth(13, 25 * 180);
            sheet1.SetColumnWidth(14, 25 * 160);
            sheet1.SetColumnWidth(15, 25 * 160);
            sheet1.SetColumnWidth(16, 25 * 160);
            //写入标题
            HSSFRow titRow = sheet1.CreateRow(0) as HSSFRow;
            HSSFCell titCell = titRow.CreateCell(0) as HSSFCell;
            titRow.Height = 30 * 20;
            titCell.SetCellValue("应收款明细");
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
            sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, Dgv.ColumnCount - 3));
            try
            {
                //行名的的设置
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(1);
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                LieFont.FontHeightInPoints = 9;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                styleRow.SetFont(LieFont);
                for (int i = 0; i < Dgv.ColumnCount - 2; i++)
                {
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
                    for (int i = 0; i < Dgv.ColumnCount - 2; i++)
                    {
                        if (i >= 3 && i < Dgv.ColumnCount - 2)
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
                ClsMsgBox.Cw("导出应收款明细失败", ex);
            }
        }
        #endregion
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == 16)//连接
            {
                int aid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtid.Name].Value);
                FrmYCZW f = new FrmYCZW();
                f.ShowDialog();
                f.Prepare(PriJgid, PriJgmc, aid, PriYwqyIndex, PriJzlxIndex, PriStartSj, PriStopSj, PriSfycIndex);
            }
        }

        private void BtnClear1_Click(object sender, EventArgs e)
        {
            this.TxtJgmc.Clear();
            PriJgid = 0;
        }
    }
}
