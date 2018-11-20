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
    public partial class FrmJgxx : Form
    {
        private ClsG ObjG;
        public FrmJgxx()
        {
            InitializeComponent();
        }
        public void Prepare(string alx, string astrdtp, string astrend, DataRow row)
        {
            ObjG = Session["ObjG"] as ClsG;
            DtpDkStart.Value = Convert.ToDateTime(astrdtp);
            DtpDkStop.Value = Convert.ToDateTime(astrend).AddDays(-1);
            LblLb.Text = alx+"天";
            LblZje.Text = row["dsk"].ToString();
            LblJsffje.Text = row["jsdsk"].ToString();
            LblDqmc.Text = row["dqmc"].ToString();
            string aStr = " SELECT  jgmc,ISNULL(SUM(dsk),0) AS dsk,ISNULL(SUM(jsdsk),0) AS jsdsk, (select convert (nvarchar(50),(select convert (decimal(15,2),(select convert(decimal(15,4),(ISNULL(SUM(jsdsk),0)*1.0/ISNULL(SUM(dsk),1)))))*100))) +'%'AS Bl,'详细信息'  AS xx FROM vfmsdskdkjsl WHERE lx=" + alx + "  and ffsj >='" + astrdtp + "' and ffsj<'" + astrend + "' and dqid=" + row["dqid"].ToString() + " GROUP BY jgmc";
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

        private void BtnElse_Click(object sender, EventArgs e)
        {
            int[] lst = { 1, 2 };
            ClsExcel.CreatExcel(Dgv, "代收款打款及时率机构明细", ctrlDownLoad1, lst, false);
        }
    }
}
