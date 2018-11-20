#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pri;
using JY.Pub;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Configuration;
using FMS.CWGL.YYSRCX;
using FMS.SelectFrm;
#endregion


namespace FMS.CWGL.YYSRCX2
{
    public partial class FrmYYSRCX2 : UserControl
    {
        public FrmYYSRCX2()
        {
            InitializeComponent();
        }
        #region 成员变量
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private int PriJgid = 0;
        private int PriYwqyIndx = 0;
        private DateTime PriStartSj = DateTime.Now;
        private DateTime PriStopSj = DateTime.Now;
        #endregion

        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG; 
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            this.CmbYwqy.SelectedIndex = 0;
            PnlMain.Controls.Add(PnlJgcx);
            PnlJgcx.Visible = false;
            PriJgid = ObjG.Jigou.id;
            TxtJgmc.Text = ObjG.Jigou.mc;
            CmbJzlx.SelectedIndex = 0;
            ClsPopulateCmbDsS.PopuYd_ywxz(CmbYwxz, ClsGlobals.CntStrKj);

            DataTable dtDqxx = ClsRWMSSQLDb.GetDataTable(" SELECT 0 AS dqid,'--全部--' dqmc,'' sybid  UNION SELECT dqid,dqmc,sybid  FROM jyjckj.dbo.Vdqjigou   WHERE  dqid<>jgid GROUP BY dqid,dqmc,sybid ORDER BY sybid,dqid ", ClsGlobals.CntStrKj);
            Txtdq.Tag = "0";

        }
        private void BtnClear1_Click(object sender, EventArgs e)
        {
            this.TxtJgmc.Clear();
            PriJgid = 0;
        }

        private void TxtJg_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            PnlJgcx.Visible = true;
            string CmdText = "select mc,pym ,id from jyjckj.dbo.tjigou where parentLst like '%," + ObjG.Jigou.id + ",%' and (pym like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%' or  mc like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%')";
            PriJgDt = ClsRWMSSQLDb.GetDataTable(CmdText, ClsGlobals.CntStrTMS);
            LstV.DataSource = PriJgDt;
            LstV.Columns[0].Text = "机构名称";
            LstV.Columns[1].Text = "拼音码";
            LstV.Columns[2].Text = "jgid";
            LstV.Columns[2].Visible = false;
            LstV.Columns[0].Width = 120;
            LstV.Focus();
            //DgvJgcx.DataSource = PriJgDt;
            //DgvJgcx.Focus();
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "营业收入查询" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
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
            //sheet1.SetColumnWidth(7, 25 * 120);
            //sheet1.SetColumnWidth(8, 25 * 120);
            //sheet1.SetColumnWidth(9, 25 * 120);
            //sheet1.SetColumnWidth(10, 25 * 120);
            //sheet1.SetColumnWidth(11, 25 * 120);
            //sheet1.SetColumnWidth(12, 25 * 120);
            //sheet1.SetColumnWidth(13, 25 * 120);
            //sheet1.SetColumnWidth(14, 25 * 120);
            //sheet1.SetColumnWidth(15, 25 * 120);
            //写入标题
            HSSFRow titRow = sheet1.CreateRow(0) as HSSFRow;
            HSSFCell titCell = titRow.CreateCell(0) as HSSFCell;
            titRow.Height = 30 * 20;
            titCell.SetCellValue("营业收入明细");
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
            sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, Dgv.ColumnCount - 4));
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
                for (int i = 0; i < Dgv.ColumnCount - 3; i++)
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
                    for (int i = 0; i < Dgv.ColumnCount - 3; i++)
                    {
                        if (i > 5 && i <= 8)
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
                            if (Row.Cells[i].Value != null)
                            {
                                hssfrow.CreateCell(i).SetCellValue(Row.Cells[i].Value.ToString());
                                hssfrow.Cells[i].CellStyle = styleRow1;
                            }
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
                ClsMsgBox.Cw("导出营业收入查询失败", ex);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (PriJgid == 0)
            {
                ClsMsgBox.Ts("请选择查询的机构！", ObjG.CustomMsgBox, this);
                return;
            }
            LblHj.Text = "合计：0元";
            string aWhere = " where EXISTS (SELECT id FROM jyjckj.dbo.tjigou WHERE parentlst like '%," + PriJgid + ",%' AND id=sljgid) and  inssj >= '" + DtpQrStart.Value + "' and inssj< DateAdd(dd,+1, '" + DtpQrStop.Value + "')";
            if (CmbJzlx.SelectedIndex != 0)
            {
                aWhere += " and  fzf='" + CmbJzlx.Text + "' ";
            }
            if (CmbYwqy.SelectedIndex != 0)
                aWhere = aWhere + " and ywqys='" + CmbYwqy.Text + "'";
            if (Txtdq.Tag.ToString() != "0")
                aWhere = aWhere + " and dqid = " + Txtdq.Tag.ToString();
            if (CmbYwxz.SelectedIndex != 0)
                aWhere = aWhere + " and ywxz = '" + CmbYwxz.SelectedValue.ToString() + "'";
            aWhere += " and jezj<> 0.00 ";
            PriYwqyIndx = CmbYwqy.SelectedIndex;
            PriStartSj = DtpQrStart.Value;
            PriStopSj = DtpQrStop.Value;
            DataTable dt = ClsRWMSSQLDb.GetDataTable(" select mc,ydid,inssj,sljgid,jzlx,ywqys,bh,fhxf,bf,jezj,fzf,cz,fkfs,dqmc,ywxzs from Vfmsyysrcx2  " + aWhere, ClsGlobals.CntStrTMS);
            //this.VfmsyysrcxTableAdapter1.FillByWhere(this.DSYYSRCX1.Vfmsyysrcx, aWhere);

            //DataTable dt = DSYYSRCX1.Vfmsyysrcx.DataSet.Tables[1];
            DataRow dr = dt.NewRow();
            dr["jzlx"] = "合计：";
            dr["fhxf"] = dt.Compute("sum(fhxf)", "");
            dr["bf"] = dt.Compute("sum(bf)", "");
            ////dr["fzf"] = dt.Compute("sum(fzf)", "");
            ////dr["tzf"] = dt.Compute("sum(tzf)", "");
            ////dr["hf"] = dt.Compute("sum(hf)", "")
            ////dr["dsfzf"] = dt.Compute("sum(dsfzf)", "");
            ////dr["bfxf"] = dt.Compute("sum(bfxf)", "");
            ////dr["bfdf"] = dt.Compute("sum(bfdf)", "");
            ////dr["bffzf"] = dt.Compute("sum(bffzf)", "");
            ////dr["bftzf"] = dt.Compute("sum(bftzf)", "");
            ////dr["bfdzfzf"] = dt.Compute("sum(bfdzfzf)", "");
            dr["jezj"] = dt.Compute("sum(jezj)", "");
            dt.Rows.Add(dr);
            Dgv.DataSource = dt;
            if (Dgv.RowCount == 1)
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
            LblHj.Text = "合计：" + dr["jezj"].ToString() + "元";
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
                    this.PnlJgcx.Visible = false;
                    PriJgDt.Dispose();

                }
            }
        }

        private void LstV_LostFocus(object sender, EventArgs e)
        {
            PnlJgcx.Visible = false;
            PriJgDt.Dispose();
        }

        private void LstV_DoubleClick(object sender, EventArgs e)
        {
            this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
            PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
            this.PnlJgcx.Visible = false;
            PriJgDt.Dispose();
        }

        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex < 0 || e.ColumnIndex != 10)
                return;
            if (e.ColumnIndex == 10)//连接
            {
                FrmYCZW f = new FrmYCZW();
                f.ShowDialog();
                string aBh = Dgv.Rows[e.RowIndex].Cells[DgvColTxtywdh.Name].Value.ToString();
                string aSj = Dgv.Rows[e.RowIndex].Cells[DgvColTxtsj.Name].Value.ToString();
                string aFkfs = Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value.ToString();
                f.Prepare(PriJgid, TxtJgmc.Text, aBh, PriYwqyIndx, aSj, PriStartSj, PriStopSj, aFkfs);
            }
        }

        private void Btndq_Click(object sender, EventArgs e)
        {
            FrmSelectDq f = new FrmSelectDq();
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(fsl_FormClosing);
        }
        void fsl_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FrmSelectDq f = sender as FrmSelectDq)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    Txtdq.Text = f.PubDictAttrs["dqmc"].ToString();
                    Txtdq.Tag = f.PubDictAttrs["dqid"].ToString();
                }
                else
                {
                    Txtdq.Text = "";
                    Txtdq.Tag = "0";
                }
            }
        }

        private void Dgv_Click(object sender, EventArgs e)
        {

        }
    }
}