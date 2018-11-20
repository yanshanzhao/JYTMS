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
using System.Data.SqlClient;
#endregion

namespace FMS.DSKGL.DSKDKJSL
    {
    public partial class FrmDSKDKJSL : UserControl
        {
        #region 成员变量
        private ClsG ObjG;
        string Pristrdtp = "";
        string Pristrend = "";
        #endregion
        public FrmDSKDKJSL()
            {
            InitializeComponent();
            }
        public void Prepare()
            {
            ObjG = Session["ObjG"] as ClsG;
            }
        private void BtnQr_Click(object sender, EventArgs e)
            {
            Pristrdtp = DtpDkStart.Value.Date.ToString();
            Pristrend = DtpDkStop.Value.AddDays(1).Date.ToString();
            //string aStr = " SELECT '1天' AS lx,ISNULL(SUM(dsk),0) AS dsk,ISNULL(SUM(jsdsk),0) AS jsdsk, (select convert (nvarchar(50),(select convert (decimal(15,2),(select convert(decimal(15,4),(ISNULL(SUM(jsdsk),0)*1.0/ISNULL(SUM(dsk),1)))))*100))) +'%'AS Bl,'详细信息'  AS xx FROM vfmsdskdkjsl WHERE lx='1'  and ffsj >='" + Pristrdtp + "' and ffsj<'" + Pristrend + "'";
            //aStr += " UNION ALL  SELECT '3天' AS lx,ISNULL(SUM(dsk),0) AS  dsk,ISNULL(SUM(jsdsk),0) AS jsdsk,(select convert (nvarchar(50),(select convert (decimal(15,2),(select convert(decimal(15,4),(ISNULL(SUM(jsdsk),0)*1.0/ISNULL(SUM(dsk),1)))))*100)))+'%' AS Bl,'详细信息'  AS xx FROM vfmsdskdkjsl WHERE lx='3'  and ffsj >='" + Pristrdtp + "' and ffsj<'" + Pristrend + "'";
            //aStr += " UNION ALL    SELECT '7天' AS lx,ISNULL(SUM(dsk),0) AS dsk,ISNULL(SUM(jsdsk),0) AS jsdsk,(select convert (nvarchar(50),(select convert (decimal(15,2),(select convert(decimal(15,4),(ISNULL(SUM(jsdsk),0)*1.0/ISNULL(SUM(dsk),1)))))*100)))+'%' AS Bl,'详细信息'  AS xx FROM vfmsdskdkjsl WHERE lx='7' and ffsj >='" + Pristrdtp + "' and ffsj<'" + Pristrend + "'";
            string aStr = string.Format("SELECT CASE dsffsj WHEN 'A' THEN '1天' WHEN 'B' THEN '3天' WHEN 'C' THEN '7天' END AS lx,ISNULL(SUM(dsk),0) AS dsk,ISNULL(SUM(jsdsk),0) AS jsdsk,convert(VARCHAR(10),convert(decimal(15,2),(convert(decimal(15,2),(ISNULL(SUM(jsdsk),0)))/(CONVERT(DECIMAL(15,2),ISNULL(SUM(dsk),1))))*100)) +'%'AS Bl,'详细信息'  AS xx FROM vfmsdskdkjsl WHERE ffsj >='{0}' and ffsj<'{1}' GROUP BY dsffsj ORDER BY lx", Pristrdtp, Pristrend);
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
            if (Dgv.Rows.Count == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "代收货款打款及时率", this.ctrlDownLoad1, new int[] { 1, 2 });
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
                Frmdqxx f = new Frmdqxx();
                DataRow row = ((DataRowView)Dgv.CurrentRow.DataBoundItem).Row as DataRow;
                f.Prepare(row, Pristrdtp, Pristrend);
                f.ShowDialog();
                }
            }
        }
    }
