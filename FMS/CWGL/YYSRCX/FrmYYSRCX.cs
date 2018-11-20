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
#endregion

namespace FMS.CWGL.YYSRCX
{
    public partial class FrmYYSRCX : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private int PriJgid = 0;
        private int PriYwqyIndx = 0;
        private DateTime PriStartSj = DateTime.Now;
        private DateTime PriStopSj = DateTime.Now;
        #endregion
        public FrmYYSRCX()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            this.VfmsyysrcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS; 
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj); 
            this.CmbYwqy.SelectedIndex = 0;
            PnlMain.Controls.Add(PnlJgcx);
            PnlJgcx.Visible = false;
           PriJgid = ObjG.Jigou.id;
           TxtJgmc.Text = ObjG.Jigou.mc;
        }
        #region ������ѯ
        private void TxtJg_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            PnlJgcx.Visible = true;
            string CmdText = "select mc,pym ,id from jyjckj.dbo.tjigou where parentLst like '%," + ObjG.Jigou.id + ",%' and (pym like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%' or  mc like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%')";
            PriJgDt = ClsRWMSSQLDb.GetDataTable(CmdText, ClsGlobals.CntStrTMS);
            LstV.DataSource = PriJgDt;
            LstV.Columns[0].Text = "��������";
            LstV.Columns[1].Text = "ƴ����";
            LstV.Columns[2].Text = "jgid";
            LstV.Columns[2].Visible = false;
            LstV.Columns[0].Width = 120;
            LstV.Focus();
            //DgvJgcx.DataSource = PriJgDt;
            //DgvJgcx.Focus();
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
        //private void DgvJgcx_LostFocus(object sender, EventArgs e)
        //{
        //    PnlJgcx.Visible = false;
        //    PriJgDt.Dispose();
        //}
        //private void DgvJgcx_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    this.TxtJgmc.Text = DgvJgcx.CurrentRow.Cells[DgvColTxtJgmc.Name].Value.ToString();
        //    PriJgid = Convert.ToInt32(DgvJgcx.CurrentRow.Cells["DgvColTxtjgid"].Value.ToString());
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
        #endregion
        #region ��ѯ
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (PriJgid == 0)
            {
                ClsMsgBox.Ts("��ѡ���ѯ�Ļ�����", ObjG.CustomMsgBox, this);
                return;
            }
            LblHj.Text = "�ϼƣ�0Ԫ";
            string aWhere = " where    inssj >= '" + DtpQrStart.Value.Date + "' and inssj<  '" + DtpQrStop.Value.AddDays(1).Date + "'  and  sljgid in(select ID from jyjckj.dbo.tjigou where parentlst like '%," + PriJgid + ",%') ";
            if (CmbYwqy.SelectedIndex != 0)
                aWhere = aWhere + " and ywqy='" + CmbYwqy.Text + "'";
            PriYwqyIndx = CmbYwqy.SelectedIndex;
            PriStartSj = DtpQrStart.Value;
            PriStopSj = DtpQrStop.Value;
            this.VfmsyysrcxTableAdapter1.FillByWhere(this.DSYYSRCX1.Vfmsyysrcx, aWhere);
            if (Dgv.RowCount == 1)
                ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ��", ObjG.CustomMsgBox, this);
            DataTable dt = DSYYSRCX1.Vfmsyysrcx.DataSet.Tables[1];
            DataRow dr = dt.NewRow();
            dr["jzlx"] = "�ϼƣ�";
            dr["fhxf"] = dt.Compute("sum(fhxf)","");
            dr["tf"] = dt.Compute("sum(tf)", "");
            dr["fzf"] = dt.Compute("sum(fzf)", "");
            dr["tzf"] = dt.Compute("sum(tzf)", "");
            dr["hf"] = dt.Compute("sum(hf)", "");
            dr["dsfzf"] = dt.Compute("sum(dsfzf)", "");
            dr["bfxf"] = dt.Compute("sum(bfxf)", "");
            dr["bfdf"] = dt.Compute("sum(bfdf)", "");
            dr["bffzf"] = dt.Compute("sum(bffzf)", "");
            dr["bftzf"] = dt.Compute("sum(bftzf)", "");
            dr["bfdzfzf"] = dt.Compute("sum(bfdzfzf)", "");
            dr["jezj"] = dt.Compute("sum(jezj)", "");
            dt.Rows.Add(dr);
            LblHj.Text = "�ϼƣ�" + dr["jezj"].ToString() + "Ԫ";
        }
        #endregion
        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "Ӫҵ�����ѯ" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
            //д������
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
            //д�����
            HSSFRow titRow = sheet1.CreateRow(0) as HSSFRow;
            HSSFCell titCell = titRow.CreateCell(0) as HSSFCell;
            titRow.Height = 30 * 20;
            titCell.SetCellValue("Ӫҵ������ϸ");
            //���ñ�����ʽ
            HSSFCellStyle style = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
            //�����������
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//�м����
            //�����������ʽ
            HSSFFont font = hssfworkbook.CreateFont() as HSSFFont;
            font.FontName = "����";
            font.FontHeightInPoints = 20;
            font.Boldweight = 700;
            style.SetFont(font);
            titCell.CellStyle = style;
            //�ϲ�������
            sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, Dgv.ColumnCount - 4));
            try
            {
                //�����ĵ�����
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
                //��������
                HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                HSSFCellStyle cellStyle1 = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle1.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                foreach (DataGridViewRow Row in Dgv.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    for (int i = 0; i < Dgv.ColumnCount - 3; i++)
                    {
                        if (i >= 3)
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
                ClsMsgBox.Cw("����Ӫҵ�����ѯʧ��", ex);
            }
        }
        #endregion
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex < 0 ||e.ColumnIndex!=15)
                return;
            if (e.ColumnIndex == 15)//����
            {
                FrmYCZW f = new FrmYCZW();
                f.ShowDialog();
                string aBh = Dgv.Rows[e.RowIndex].Cells[DgvColTxtywdh.Name].Value.ToString();
                string aSj = Dgv.Rows[e.RowIndex].Cells[DgvColTxtsj.Name].Value.ToString();
                string aFkfs = Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value.ToString();
                f.Prepare(PriJgid, TxtJgmc.Text, aBh, PriYwqyIndx, aSj, PriStartSj, PriStopSj, aFkfs);
            }
        }

        private void BtnClear1_Click(object sender, EventArgs e)
        {
            this.TxtJgmc.Clear();
            PriJgid = 0;
        } 

    }
}