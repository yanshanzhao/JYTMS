#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pri;
using JY.Pub;
using FMS.SelectFrm;
using FMS.SeleFrm;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Configuration;

#endregion

namespace FMS.DSKGL.LSDDZD
{
    public partial class FrmLSDDZD : UserControl
    {
        private ClsG ObjG;
        private string PirConStrTMS;
        string SWHER;
        public FrmLSDDZD()
        {
            InitializeComponent();
        }


        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            PirConStrTMS = ClsGlobals.CntStrTMS;
            CmbZsfs.SelectedIndex = 0;
            this.DtpStart.Value = DateTime.Now.AddDays(-1);
        }

        #region 查询
        private void BtnSearch_Click_1(object sender, EventArgs e)
        {
            SWHER = " WHERE jzje>0 and zfsj>='" + DtpStart.Value + "' and zfsj<='" + DtpStop.Value.AddDays(1) + "'";
            if (!string.IsNullOrEmpty(TxtDq.Text.Trim()))
                SWHER += " and dqid=" + TxtDq.Tag;
            if (!string.IsNullOrEmpty(TxtLsd.Text.Trim()))
                SWHER += " and jgid=" + TxtLsd.Tag;
            if (!string.IsNullOrEmpty(TxtMin.Text.Trim()) && string.IsNullOrEmpty(TxtMax.Text.Trim()))
                SWHER += " and dsk=" + TxtMin.Text;
            else if (!string.IsNullOrEmpty(TxtMax.Text.Trim()) && string.IsNullOrEmpty(TxtMin.Text.Trim()))
                SWHER += " and dsk=" + TxtMax.Text;
            else if (!string.IsNullOrEmpty(TxtMin.Text) && !string.IsNullOrEmpty(TxtMax.Text))
                SWHER += " and dsk>" + TxtMin.Text + " and dsk<" + TxtMax.Text;
            //if (CmbZsfs.SelectedIndex > 0)
            //    SWHER += " and zflxid=" + CmbZsfs.SelectedIndex;
            string SqlStr = "SELECT dqmc,jgid,jgmc,SUM(jzje) AS jzje,SUM(rbje) AS rbje,'详细' as xx FROM dbo.VLsddzd" + SWHER;
            SqlStr += " GROUP BY dqmc,jgid,jgmc";
            DataTable dt = ClsRWMSSQLDb.GetDataTable(SqlStr, PirConStrTMS);
            if (dt.Rows.Count > 0)
            {
                Dgv.AutoGenerateColumns = false;
                Dgv.DataSource = dt;
            }
            else
            {
                ClsMsgBox.Ts("没有查出符合条件的信息，请重新选择条件！", ObjG.CustomMsgBox, this);
            }



        }
        #endregion 查询

        #region 导出
        private void BtnExlym_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有可导出的数据！");
                return;
            }
            int[] Rows = new int[] { 2, 3 };
            ClsExcel.CreatExcel(Dgv, "连锁店对账单信息", this.ctrlDownLoad1, Rows);
        }
        #endregion 导出

        #region 导出明细
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有可导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            List<int> lsid = new List<int>();
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                lsid.Add(Convert.ToInt32(row.Cells[DgvColTxtJgid.Name].Value));
            }
            string SqlStr = "SELECT dqmc,jgmc,ydbh,jzje,rbje,ppzt,shzt FROM dbo.VLsddzd " + SWHER;
            DataTable dt = ClsRWMSSQLDb.GetDataTable(SqlStr, PirConStrTMS);
            List<string> CellValue = new List<string>();
            CellValue.Add("大区");
            CellValue.Add("连锁店");
            CellValue.Add("运单号");
            CellValue.Add("代收款进账金额");
            CellValue.Add("日报金额");
            CellValue.Add("匹配情况");
            CellValue.Add("日报审核情状态");
            CreatExcel_Data(dt, CellValue, "连锁店对账单明细", ctrlDownLoad1);
        }
        #endregion 导出明细
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
        #region 详细事件
        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 4)
            {
                return;
            }
            if (e.ColumnIndex == 4)
            {
                int jgid = Convert.ToInt32(Dgv.SelectedRows[0].Cells[DgvColTxtJgid.Name].Value);
                string where = " WHERE jgid=" + jgid + " and zfsj>='" + DtpStart.Value + "' and zfsj<='" + DtpStop.Value.AddDays(1) + "'";
                FrmLSDDZDMX f = new FrmLSDDZDMX();
                f.Prepare(where);
                f.ShowDialog();
            }
        }
        #endregion 详细事件

        #region 查询大区和连锁店
        private void BtnDq_Click(object sender, EventArgs e)
        {
            FrmSelectDq f = new FrmSelectDq();
            f.Preapre();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.Show();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectDq f = sender as FrmSelectDq;
            if (f.DialogResult == DialogResult.OK)
            {
                TxtDq.Text = f.PubDictAttrs["dqmc"];
                TxtDq.Tag = f.PubDictAttrs["dqid"];
            }
            else
            {
                TxtDq.Text = "";
                TxtDq.Tag = "";
            }
        }

        private void BtnJg_Click_1(object sender, EventArgs e)
        {
            FrmSelectJg frm = new FrmSelectJg();
            frm.Prepare();
            frm.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(frm_FormClosed);
            frm.Show();
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
            {
                TxtLsd.Text = f.PubDictAttrs["mc"];
                TxtLsd.Tag = f.PubDictAttrs["id"];
            }
            else
            {
                TxtLsd.Text = "";
                TxtLsd.Tag = "";
            }
        }
        #endregion 查询大区和连锁店

    }
}
