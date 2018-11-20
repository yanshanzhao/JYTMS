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
using JY.Pub;
using System.Data.SqlClient;
#endregion

namespace FMS.DSKGL.DSKDKJSL
{
    public partial class Frmdqxx : Form
    {
        private ClsG ObjG;
        private string Prilx="";
        private string Pristrdtp = "";
        private string Pristrend = "";
        private string Prilb = "";
        public Frmdqxx()
        {
            InitializeComponent();
        }
        public void Prepare(DataRow row, string astrdtp, string astrend)
        {
            ObjG = Session["ObjG"] as ClsG;
            Prilx = row["lx"].ToString();
            Pristrdtp = astrdtp;
            Pristrend = astrend;
            Prilb = Prilx.Substring(0, 1);
            DtpDkStart.Value = Convert.ToDateTime(astrdtp);
            DtpDkStop.Value = Convert.ToDateTime(astrend).AddDays(-1);
            LblLb.Text = Prilx;
            LblZje.Text = row["dsk"].ToString();
            LblJsffje.Text = row["jsdsk"].ToString();
            string aStr = " SELECT  dqmc,ISNULL(SUM(dsk),0) AS dsk,ISNULL(SUM(jsdsk),0) AS jsdsk, (select convert (nvarchar(50),(select convert (decimal(15,2),(select convert(decimal(15,4),(ISNULL(SUM(jsdsk),0)*1.0/ISNULL(SUM(dsk),1)))))*100))) +'%'AS Bl,'详细信息'  AS xx,dqid FROM vfmsdskdkjsl WHERE lx=" + Prilb + "  and ffsj >='" + Pristrdtp + "' and ffsj<'" + Pristrend + "' GROUP BY dqmc,dqid";
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = new SqlCommand();
                    sda.SelectCommand.Connection = conn;
                    sda.SelectCommand.CommandText = aStr;
                    conn.Open();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Dgv.DataSource = dt;
                    sda.Dispose();
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("查询失败", ex, ObjG.CustomMsgBox, this);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }       
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 4)
            {
            if (Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtDsk.Name].Value.ToString()) == 0)
                {
                ClsMsgBox.Ts("没有要查询的信息", ObjG.CustomMsgBox, this);
                return;
                }
                FrmJgxx f = new FrmJgxx();
                DataRow row = ((DataRowView)Dgv.CurrentRow.DataBoundItem).Row as DataRow;
                f.Prepare(Prilb, Pristrdtp, Pristrend, row);
                f.ShowDialog();
            }
        }

        private void BtnElse_Click(object sender, EventArgs e)
        {
            int[] lst = { 1, 2};
            ClsExcel.CreatExcel(Dgv, "代收款打款及时率大区明细", ctrlDownLoad1, lst, false);
        }

        private void BtnQr_Click(object sender, EventArgs e)
        {

        }

    }
}
