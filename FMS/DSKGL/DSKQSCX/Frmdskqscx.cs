#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using JY.Pri;
using JY.Pub;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Data.SqlClient;

#endregion

namespace FMS.DSKGL.DSKQSCX
{
    public partial class Frmdskqscx : UserControl
    {
        public Frmdskqscx()
        {
            InitializeComponent();
        }
        private ClsG ObjG;

        string strdtp = "";
        string strend = "";
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
        }

        private void btncx_Click(object sender, EventArgs e)
        {
            strdtp = Dtpstar.Value.Date.ToString();
            strend = DtpEnd.Value.Date.AddDays(1).ToString();
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = new SqlCommand();
                    sda.SelectCommand.Connection = conn;
                    //  sda.SelectCommand.CommandType=CommandType.StoredProcedure;
                    //                   sda.SelectCommand.CommandText =
                    //                       "select  d.dqmc,d.dqid,COUNT(t.id)as zps,sum(t.yf) as zyf,COUNT(case when t.dsk>0 then t.dsk END) as dskps,sum(t.dsk) as dskf,CONVERT(decimal(15,2),ISNULL(((COUNT(case when t.dsk>0 then t.dsk END)*1.0 / nullif(COUNT(t.id),0))),0)) as psbl,CONVERT(varchar,CONVERT(decimal(15,2), (CASE when SUM(t.dsk)<>0 then sum(t.dsk)/sum(t.yf) ELSE '0' end )))as jebl from Tyd as t left join jyjckj.dbo.Vdqjigou as d ON t.sljgid =d.jgid where  ywqy='L'  and t.inssj >='" + strdtp + "' and t.inssj<'" + strend + "' group BY  d.dqmc,d.dqid  union ALL select '合计','0', COUNT(t.id)as zps, isnull(sum(t.yf),0) as zyf, COUNT(case when t.dsk>0 then t.dsk END) as dskps, isnull(sum(t.dsk),0) as dskf, CONVERT(decimal(15,2),ISNULL(((COUNT(case when t.dsk>0 then t.dsk END)*1.0 / nullif(COUNT(t.id),0))),0)) as psbl, CONVERT(varchar,CONVERT(decimal(15,2), (CASE when SUM(t.dsk)<>0 then sum(t.dsk)/sum(t.yf) ELSE '0' end )))as jebl " +
                    //"from Tyd as t left join jyjckj.dbo.Vdqjigou as d  ON t.sljgid =d.jgid where   ywqy='L'   and t.inssj >='" + strdtp + "' and t.inssj<'" + strend + "'";

                    //sda.SelectCommand.Parameters.Add("@qssj", SqlDbType.VarChar, 30).Value = strdtp;
                    //sda.SelectCommand.Parameters.Add("@jssj", SqlDbType.VarChar, 30).Value = strend;
                    sda.SelectCommand.CommandText = string.Format("select  d.dqmc,d.dqid,COUNT(t.id)as zps,sum(t.yf) as zyf,COUNT(case when t.dsk>0 then t.dsk END) as dskps,sum(t.dsk) as dskf,'100%' as psbl,'100%' as jebl from Tyd as t left join jyjckj.dbo.Vdqjigou as d ON t.sljgid =d.jgid where t.inssj >='{0}' and t.inssj<'{1}' group BY  d.dqmc,d.dqid", strdtp, strend);
                    conn.Open();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    DataRow dr = dt.NewRow();
                    dr["dqmc"] = "合计";
                    dr["dqid"] = 0;
                    dr["zps"] = dt.Compute("sum(zps)", "");
                    dr["zyf"] = dt.Compute("sum(zyf)", "");
                    dr["dskps"] = dt.Compute("sum(dskps)", "");
                    dr["dskf"] = dt.Compute("sum(dskf)", "");
                    dt.Rows.Add(dr);
                    foreach (DataRow dr2 in dt.Rows)
                    {
                        decimal zps = Convert.ToDecimal(dr2["zps"]);
                        decimal dskps = Convert.ToDecimal(dr2["dskps"]);
                        decimal zyf = Convert.ToDecimal(dr2["zyf"]);
                        decimal dskf = Convert.ToDecimal(dr2["dskf"]);
                        if (zps == 0)
                            dr2["psbl"] = "0.00%";
                        else
                            dr2["psbl"] = (dskps * 100 / zps).ToString("0.00") + "%";
                        if (zyf == 0)
                            dr2["jebl"] = "0.00%";
                        else
                            dr2["jebl"] = (dskf * 100 / zyf).ToString("0.00") + "%";
                    }
                    dgv.DataSource = dt;
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

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            return;
        }

        private void BtnDC_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(dgv, "代收款收入趋势查询", ctrlDownLoad1, new int[] { 1, 2, 3, 4, 5, 6 });
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgv.Rows[e.RowIndex].Cells[7].Value.Equals("0"))
                return;
            //if (dgv.SelectedRows[0].Cells[7].Value.ToString().Equals("0"))
            //{
            //    ClsMsgBox.Ts("请选中行，再查看", ObjG.CustomMsgBox, this);
            //    return;
            //}
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells[7].Value);

            Frmdskqsmx qs = new Frmdskqsmx();
            qs.ShowDialog();
            qs.Prepare(strdtp, strend, id);
        }
    }
}