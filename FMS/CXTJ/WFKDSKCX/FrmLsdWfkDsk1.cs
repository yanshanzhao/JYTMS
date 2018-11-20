#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pri;
using System.Data.SqlClient;
using System.Collections;
using JY.Pub;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Configuration;

#endregion

namespace FMS.CXTJ.WFKDSKCX
{
    public partial class FrmLsdWfkDsk1 : Form
    {
        #region 成员变量
        private ClsG ObjG;
        private int PriDays;
        private int PriJgid = 0;
        private int PriLx1 = 0;
        private int PriLx2 = 0;
        private int fklx = 0;
        private DateTime sjXx = DateTime.Now;
        private DateTime sj = DateTime.Now;
        #endregion
        public FrmLsdWfkDsk1()
        {
            InitializeComponent();
        }
        public void Prepare(string ajgmc, int ajgid, decimal azj, int aLevel, int aLx1, DateTime asj, int afklx, DateTime asjXx)
        {
            sj = asj;
            fklx = afklx;
            sjXx = asjXx;
            PriLx1 = aLx1;
            this.LblJgmc.Text = this.LblJgmc.Text + ": " + ajgmc;
            this.LblZj.Text = this.LblZj.Text + ": " + azj.ToString() + "元";
            PriJgid = ajgid;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                conn.Open();
                DataTable dt = new DataTable();
                ArrayList als = new ArrayList();
                als.Add(new SqlParameter("@jgid", PriJgid));
                als.Add(new SqlParameter("@lx", aLx1));
                als.Add(new SqlParameter("@sj", sj.Date));
                als.Add(new SqlParameter("@fklx", afklx));
                als.Add(new SqlParameter("@sjXx", asjXx));
                using (SqlCommand cmd = new SqlCommand("P_dskwfkcx4"))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(als.ToArray(typeof(SqlParameter)));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["jgmc"] = "合计";
                        dr["yqts0"] = dt.Compute("sum(yqts0)", "").ToString();
                        dr["yqts1"] = dt.Compute("sum(yqts1)", "").ToString();
                        dr["yqts2"] = dt.Compute("sum(yqts2)", "").ToString();
                        dr["yqts3"] = dt.Compute("sum(yqts3)", "").ToString();
                        dr["yqts4"] = dt.Compute("sum(yqts4)", "").ToString();
                        dr["zj"] = dt.Compute("sum(zj)", "").ToString();
                        dr["level"] = 3;
                        dr["jgid"] = PriJgid;
                        dt.Rows.Add(dr);
                    }
                    else
                        ClsMsgBox.Ts("根据条件未查询到信息");
                    Dgv.DataSource = dt;
                }
                conn.Close();
            }
        }
        //public void Prepare(int ajgid, DateTime Endsj, int Lx)
        //{
        //    PriLx1 = Lx;
        //    DateTime PriSj = Endsj;
        //    PriJgid = ajgid;

        //    this.LblJgmc.Visible = false;
        //    this.LblZj.Visible = false;
        //    ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
        //    using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
        //    {
        //        conn.Open();
        //        DataTable dt = new DataTable();
        //        ArrayList als = new ArrayList();
        //        als.Add(new SqlParameter("@jgid", PriJgid));
        //        als.Add(new SqlParameter("@sj", PriSj));
        //        als.Add(new SqlParameter("@lx", Lx));
        //        using (SqlCommand cmd = new SqlCommand("P_dskwfkcx4"))
        //        {
        //            cmd.Connection = conn;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddRange(als.ToArray(typeof(SqlParameter)));
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            da.Fill(dt);
        //            Dgv.DataSource = dt;
        //        }
        //        conn.Close();
        //    }
        //}
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex != 6)
                return;
            decimal zje = 0;
            if (!decimal.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtzj.Name].Value.ToString(), out zje))
            {
                ClsMsgBox.Ts("查询出现异常!", ObjG.CustomMsgBox, this);
                return;
            }
            else if (zje <= 0)
            {
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int aJgId = 0;
            if (!Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgId.Name].Value.ToString(), out aJgId))
            {
                ClsMsgBox.Ts("查询出现异常!", ObjG.CustomMsgBox, this);
                return;
            }
            string ajgmc = Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgmc.Name].Value.ToString();
            FrmYdWfkDsk1 f = new FrmYdWfkDsk1();
            f.ShowDialog();
            f.Prepare(ajgmc, aJgId, zje, PriDays, PriLx1, PriLx2, fklx, sjXx, sj);
        }
        private void BtnExl1_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "未返款代收款查询" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
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
                for (int i = 0; i < Dgv.ColumnCount - 2; i++)
                {
                    row0.CreateCell(i).SetCellValue(Dgv.Columns[i].HeaderText);
                    row0.Cells[i].CellStyle = styleRow;
                }
                int roowIndex = 1;
                //数据添加
                foreach (DataGridViewRow Row in Dgv.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    for (int i = 0; i < Dgv.ColumnCount - 2; i++)
                    {
                        if (i > 0)
                        {
                            double n;
                            double je = 0;
                            if (Double.TryParse(Row.Cells[i].Value.ToString(), out n))
                            {
                                je = Convert.ToDouble(Row.Cells[i].Value.ToString());
                                hssfrow.CreateCell(i).SetCellValue(je);
                                hssfrow.Cells[i].CellStyle = cellStyle;
                            }
                        }
                        else
                        {
                            hssfrow.CreateCell(i).SetCellValue(Convert.ToString(Row.Cells[i].Value));
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
                ClsMsgBox.Cw("导出Excel失败", ex);
            }
        }
    }
}