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
using FMS.SeleFrm;
using System.Data.SqlClient;
using System.IO;
using System.Web;
#endregion

namespace FMS.CXTJ.DSKCKJSXCX
{
    public partial class FrmDSKCKJSXCX : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private int Prijgid = 0;
        private string PriStp = "";
        private string PriEnd = "";
        private int PriLevel = 0;
        private int PriLx;
        private int PriQsfs;
        #endregion
        public FrmDSKCKJSXCX()
        {
            InitializeComponent();
        }
        public void Prepare(int alx)
        {
            ObjG = Session["ObjG"] as ClsG;
            DtpStart.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
            Prijgid = ObjG.Jigou.id;
            TxtJg.Text = ObjG.Jigou.mc;
            PriLx = alx;
            PriLevel = ObjG.Jigou.level;
            Cmbqsfs.SelectedIndex = 0;
        }
        #region 查询
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (Prijgid == 0)
            {
                ClsMsgBox.Ts("请选择要查询的机构！", ObjG.CustomMsgBox, this);
                return;
            }

            //PriDt.Clear();
            PriStp = DtpStart.Value.Date.AddHours(-PriLx).ToString();
            TimeSpan dt = DateTime.Now - DtpEnd.Value;
            int days = dt.Days;
            if (days >= 2)
                PriEnd = DtpEnd.Value.Date.AddDays(1).AddHours(-PriLx).ToString();
            else
                PriEnd = DateTime.Now.Date.AddDays(-1).AddHours(-PriLx).ToString();

            PriQsfs = Cmbqsfs.SelectedIndex;

            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                conn.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                DataTable PriDt = new DataTable();
                if (PriLevel >= 4)
                {
                    com.CommandText = "P_Dskckjsx_jg";
                }
                else
                {
                    com.CommandText = "P_Dskckjsx";
                }
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@st", PriStp));
                com.Parameters.Add(new SqlParameter("@et", PriEnd));
                com.Parameters.Add(new SqlParameter("@jgid", Prijgid));
                com.Parameters.Add(new SqlParameter("@lx1", PriQsfs));
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(PriDt);
                #region 补充信息
                foreach (DataRow dr in PriDt.Rows)
                {
                    decimal qsps = Convert.ToDecimal(dr["qsps"]);
                    decimal qsdsk = Convert.ToDecimal(dr["qsdsk"]);
                    decimal jsps = Convert.ToDecimal(dr["jsps"]);
                    decimal jsdsk = Convert.ToDecimal(dr["jsdsk"]);
                    decimal posje = Convert.ToDecimal(dr["posje"]);
                    //decimal posbs = Convert.ToDecimal(dr["posps"]);
                    dr["psbfb"] = (jsps * 100 / qsps).ToString("0.00") + "%";
                    dr["dskbfb"] = (jsdsk * 100 / qsdsk).ToString("0.00") + "%";
                    dr["posbfb"] = (posje * 100 / qsdsk).ToString("0.00") + "%";
                    //decimal qsfs = Convert.ToDecimal(dr["lx1"]); 
                }
                DataRow DR = PriDt.NewRow();

                if (PriDt.Compute("sum(qsps)", "") is DBNull)
                {
                    DR["psbfb"] = PriDt.Compute("0", "");
                    DR["psbfb"] = DR["psbfb"] + "%";
                }
                else
                {
                    DR["psbfb"] = Math.Round(Convert.ToDecimal(PriDt.Compute(" SUM(jsps)*1.00/SUM(qsps)*100", "")), 2);
                    DR["psbfb"] = DR["psbfb"] + "%";

                }
                if (PriDt.Compute("sum(qsdsk)", "") is DBNull)
                {
                    DR["dskbfb"] = PriDt.Compute("0", "");
                    DR["dskbfb"] = DR["dskbfb"] + "%";
                }
                else
                {
                    DR["dskbfb"] = Math.Round(Convert.ToDecimal(PriDt.Compute("SUM(jsdsk)*1.00/SUM(qsdsk)*100", "")), 2);
                    DR["dskbfb"] = DR["dskbfb"] + "%";
                }

                if (PriDt.Compute("sum(posje)", "") is DBNull)
                {
                    DR["posbfb"] = PriDt.Compute("0", "");
                    DR["posbfb"] = DR["posbfb"] + "%";
                }
                else
                {
                    DR["posbfb"] = Math.Round(Convert.ToDecimal(PriDt.Compute("SUM(posje)*1.00/SUM(qsdsk)*100", "")), 2);
                    DR["posbfb"] = DR["posbfb"] + "%";
                }

                DR["jsdsk"] = PriDt.Compute("sum(jsdsk)", "");
                DR["qsps"] = PriDt.Compute("sum(qsps)", "");
                DR["jsps"] = PriDt.Compute("sum(jsps)", "");
                DR["qsdsk"] = PriDt.Compute("sum(qsdsk)", "");
                DR["posje"] = PriDt.Compute("sum(posje)", "");
                DR["jgmc"] = "合计";
                PriDt.Rows.Add(DR);
                #endregion
                Dgv.DataSource = PriDt;
                conn.Close();
                conn.Dispose();
                da.Dispose();
                com.Dispose();
                if (Dgv.Rows.Count == 0)
                    ClsMsgBox.Ts("没有要查询的信息，请核对查询条件！", ObjG.CustomMsgBox, this);
            }

        }
        #endregion

        #region 机构查询
        private void BtnJg_Click(object sender, EventArgs e)
        {
            FrmSelectJg2 PriFrmSelectJg = new FrmSelectJg2();
            PriFrmSelectJg.Prepare();
            PriFrmSelectJg.ShowDialog();
            PriFrmSelectJg.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmJGCX1_FormClosed);
        }
        private void FrmJGCX1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg2 f = sender as FrmSelectJg2;
            if (f.DialogResult == DialogResult.OK)
            {
                Prijgid = Convert.ToInt32(f.PubDictAttrs["id"]);
                this.TxtJg.Text = f.PubDictAttrs["mc"];
                PriLevel = Convert.ToInt32(f.PubDictAttrs["level"]);
            }
            else if (f.DialogResult == DialogResult.None)
            {
                return;
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtJg.Text = "";
                Prijgid = 0;
                PriLevel = -1;
            }
            f.Dispose();
        }
        #endregion

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == Dgv.RowCount - 1)
                return;
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            int ajgid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgid.Name].Value.ToString());
            if (PriLevel >= 4)
            {
                FrmDSKCKJSXMX f = new FrmDSKCKJSXMX();
                f.ShowDialog();
                f.Prepare(ajgid, PriStp, PriEnd, PriQsfs);
            }
            else
            {
                FrmDSKCKJSXX f = new FrmDSKCKJSXX();
                f.ShowDialog();
                f.Prepare(ajgid, PriStp, PriEnd, PriQsfs);
            }
        }
        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            //string filehead = "机构\t已签收代收款票数\t已签收代收款金额\t及时的代收款票数\t及时的代收款金额\t票数的及时率\t金额的及时率\t签收方式";
            int[] Rows = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            ClsExcel.CreatExcel(Dgv, "代收款存款及时性查询", this.ctrlDownLoad1, Rows);
            //ClsExcelTxt.CreatExcel(Dgv, filehead, "代收款存款及时性查询" + DateTime.Now.ToString("yyyyMMddHHmmss"), this.ctrlDownLoad1, Rows);
        }
        #endregion

        private void BtnExlmx_Click(object sender, EventArgs e)
        {
            FrmDSKCKJSXMX f = new FrmDSKCKJSXMX();
            f.Prepare(Prijgid, PriStp, PriEnd, PriQsfs, true);
            f.BtnExl_Click(null, null);
        }

        private void BtnExcelMx_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                conn.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                DataTable PriDt = new DataTable();
                com.CommandText = "P_Dskckjsx_jg_dc";
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@st", PriStp));
                com.Parameters.Add(new SqlParameter("@et", PriEnd));
                com.Parameters.Add(new SqlParameter("@jgid", Prijgid));
                com.Parameters.Add(new SqlParameter("@lx1", PriQsfs));
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(PriDt);
                #region 补充信息
                foreach (DataRow dr in PriDt.Rows)
                {
                    decimal qsps = Convert.ToDecimal(dr["qsps"]);
                    decimal qsdsk = Convert.ToDecimal(dr["qsdsk"]);
                    decimal jsps = Convert.ToDecimal(dr["jsps"]);
                    decimal jsdsk = Convert.ToDecimal(dr["jsdsk"]);
                    decimal posje = Convert.ToDecimal(dr["posje"]);
                    dr["psbfb"] = (jsps * 100 / qsps).ToString("0.00") + "%";
                    dr["dskbfb"] = (jsdsk * 100 / qsdsk).ToString("0.00") + "%";
                    dr["posbfb"] = (posje * 100 / qsdsk).ToString("0.00") + "%";

                }
                DataRow DR = PriDt.NewRow();

                if (PriDt.Compute("sum(qsps)", "") is DBNull)
                {
                    DR["psbfb"] = PriDt.Compute("0", "");
                    DR["psbfb"] = DR["psbfb"] + "%";
                }
                else
                {
                    DR["psbfb"] = Math.Round(Convert.ToDecimal(PriDt.Compute(" SUM(jsps)*1.00/SUM(qsps)*100", "")), 2);
                    DR["psbfb"] = DR["psbfb"] + "%";

                }
                if (PriDt.Compute("sum(qsdsk)", "") is DBNull)
                {
                    DR["dskbfb"] = PriDt.Compute("0", "");
                    DR["dskbfb"] = DR["dskbfb"] + "%";
                }
                else
                {
                    DR["dskbfb"] = Math.Round(Convert.ToDecimal(PriDt.Compute("SUM(jsdsk)*1.00/SUM(qsdsk)*100", "")), 2);

                    DR["dskbfb"] = DR["dskbfb"] + "%";
                }
                if (PriDt.Compute("sum(posje)", "") is DBNull)
                {
                    DR["posbfb"] = PriDt.Compute("0", "");
                    DR["posbfb"] = DR["posbfb"] + "%";
                }
                else
                {
                    DR["posbfb"] = Math.Round(Convert.ToDecimal(PriDt.Compute("SUM(posje)*1.00/SUM(qsdsk)*100", "")), 2);
                    DR["posbfb"] = DR["posbfb"] + "%";
                }
                DR["jsdsk"] = PriDt.Compute("sum(jsdsk)", "");
                DR["qsps"] = PriDt.Compute("sum(qsps)", "");
                DR["jsps"] = PriDt.Compute("sum(jsps)", "");
                DR["qsdsk"] = PriDt.Compute("sum(qsdsk)", "");
                DR["posje"] = PriDt.Compute("sum(posje)", "");
                DR["jgmc"] = "合计";
                //DR["lx1"] = PriDt.Compute("lx1","");
                PriDt.Rows.Add(DR);
                #endregion
                //Dgv.DataSource = PriDt;
                conn.Close();
                conn.Dispose();
                da.Dispose();
                com.Dispose();
                //if (Dgv.Rows.Count == 0)
                //    ClsMsgBox.Ts("没有要查询的信息，请核对查询条件！", ObjG.CustomMsgBox, this);
                if (PriDt.Rows.Count > 60000)
                {
                    ClsMsgBox.Ts("不允许导出超过60000条的数据");
                    return;
                }
                else
                {
                    ClsExcel.CreatExcel_Data("代收款存款及时性查询_连锁店明细.xls", this.ctrlDownLoad1, PriDt, Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath + @"App_Data\ModelExcel", "dskckjsxcx.xls"), 1, new int[] { 2, 3, 4, 5 });
                }
            }
        }

        private void Dgv_Click(object sender, EventArgs e)
        {

        }

    }
}
