#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pri;
using JY.Pub;
#endregion

namespace FMS.CXTJ.DSKCKJSXCX
{
    public partial class FrmDSKCKJSXX : Form
    {
        #region 成员变量
        private ClsG ObjG;
        private int Prijgid = 0;
        private string PriStp = "";
        private string PriEnd = "";
        private int  PriQsfs;
        #endregion
        public FrmDSKCKJSXX()
        {
            InitializeComponent();
        }

        public void Prepare(int ajgid, string aStop, string aEnd, int aQsfs)
        {
            ObjG = Session["ObjG"] as ClsG;
            PriStp = aStop;
            PriEnd = aEnd;
            Prijgid = ajgid;
            PriQsfs = aQsfs;
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                conn.Open();
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@st", PriStp));
                com.Parameters.Add(new SqlParameter("@et", PriEnd));
                com.Parameters.Add(new SqlParameter("@jgid", Prijgid));
                com.Parameters.Add(new SqlParameter("@lx1", PriQsfs));
                com.CommandTimeout = 3000;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable PriDt = new DataTable();
                com.CommandText = "P_Dskckjsx_jg";
                da.Fill(PriDt);
                #region 补充信息
                foreach (DataRow dr in PriDt.Rows)
                {
                    decimal qsps = Convert.ToDecimal(dr["qsps"]);
                    decimal qsdsk = Convert.ToDecimal(dr["qsdsk"]);
                    decimal jsps = Convert.ToDecimal(dr["jsps"]);
                    decimal jsdsk = Convert.ToDecimal(dr["jsdsk"]);
                    dr["psbfb"] = (jsps * 100 / qsps).ToString("0.00") + "%";
                    dr["dskbfb"] = (jsdsk * 100 / qsdsk).ToString("0.00") + "%";
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
                //   DR["dskbfb"] = PriDt.Compute("SUM(jsdsk)*1.0/SUM(qsdsk)*100" + "%", "");
                DR["jsdsk"] = PriDt.Compute("sum(jsdsk)", "");
                DR["qsps"] = PriDt.Compute("sum(qsps)", "");
                DR["jsps"] = PriDt.Compute("sum(jsps)", "");
                DR["qsdsk"] = PriDt.Compute("sum(qsdsk)", "");
                DR["jgmc"] = "合计";
                PriDt.Rows.Add(DR);
                #endregion
                Dgv.DataSource = PriDt;
                conn.Close();
                conn.Dispose();
                da.Dispose();
                com.Dispose();
            }
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 1, 2, 3, 4 };
            ClsExcel.CreatExcel(Dgv, "代收款存款及时性查询", this.ctrlDownLoad1, Rows);
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == Dgv.RowCount - 1)
                return;
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            int ajgid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgid.Name].Value.ToString());
            FrmDSKCKJSXMX f = new FrmDSKCKJSXMX();
            f.ShowDialog();
            f.Prepare(ajgid, PriStp,PriEnd,PriQsfs );
        }
    }
}