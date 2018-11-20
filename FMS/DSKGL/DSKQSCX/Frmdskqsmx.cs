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
    public partial class Frmdskqsmx : Form
    {
        public Frmdskqsmx()
        {
            InitializeComponent();
        }
        private ClsG ObjG;
        private int id;
        public void Prepare(string strdtp, string strend, int dqid)
        {
            ObjG = Session["ObjG"] as ClsG;
            Dtpstar.Value = Convert.ToDateTime(strdtp);
            dtpend.Value = Convert.ToDateTime(strend).AddDays(-1);
            id = dqid;
            chaxun();
        }
        private void chaxun()
        {
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = new SqlCommand();
                    sda.SelectCommand.Connection = conn;
                    //  sda.SelectCommand.CommandType=CommandType.StoredProcedure;
                    //sda.SelectCommand.CommandText = @"select  d.jgmc,COUNT(t.id)as zps,sum(t.yf) as zyf,COUNT(case when t.dsk>0 then t.dsk END) as dskps,sum(t.dsk) as dskf,CONVERT(decimal(15,2),ISNULL(((COUNT(case when t.dsk>0 then t.dsk END)*1.0 / nullif(COUNT(t.id),0))),0)) as psbl,CONVERT(varchar,CONVERT(decimal(15,2), (CASE when SUM(t.dsk)<>0 then sum(t.dsk)/sum(t.yf)  ELSE '0' end )))as jebl from Tyd as t left join jyjckj.dbo.Vdqjigou as d ON t.sljgid =d.jgid where  d.dqid='" + id + "' and t.inssj >='" + Dtpstar.Value.ToString() + " 'and t.inssj<'" + dtpend.Value.AddDays(1).ToString() + "' group BY  d.jgmc   union ALL select '合计', COUNT(t.id)as zps, isnull(sum(t.yf),0) as zyf, COUNT(case when t.dsk>0 then t.dsk END) as dskps, isnull(sum(t.dsk),0) as dskf, CONVERT(decimal(15,2),ISNULL(((COUNT(case when t.dsk>0 then t.dsk END)*1.0 / nullif(COUNT(t.id),0))),0)) as psbl, CONVERT(varchar,CONVERT(decimal(15,2), (CASE when SUM(t.dsk)<>0 then sum(t.dsk)/sum(t.yf)  ELSE '0' end )))as jebl from Tyd as t left join jyjckj.dbo.Vdqjigou as d  ON t.sljgid =d.jgid where  d.dqid='" + id + "'  and t.inssj >='" + Dtpstar.Value.ToString() + "' and t.inssj<'" + dtpend.Value.AddDays(1).ToString() + "'";
                    //sda.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    //sda.SelectCommand.Parameters.Add("@qssj", SqlDbType.VarChar, 30).Value = Dtpstar.Value.ToString();
                    //sda.SelectCommand.Parameters.Add("@jssj", SqlDbType.VarChar, 30).Value = dtpend.Value.ToString();
                    sda.SelectCommand.CommandText = string.Format("select  d.jgmc,COUNT(t.id)as zps,sum(t.yf) as zyf,COUNT(case when t.dsk>0 then t.dsk END) as dskps,sum(t.dsk) as dskf,'100%' as psbl,'100%' as jebl from Tyd as t left join jyjckj.dbo.Vdqjigou as d ON t.sljgid =d.jgid where  t.inssj >='{0}' and t.inssj<'{1}' and d.dqid={2} group BY  d.jgmc", Dtpstar.Value.Date.ToString(), dtpend.Value.Date.AddDays(1).ToString(), id);
                    conn.Open();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    DataRow dr = dt.NewRow();
                    dr["jgmc"] = "合计";
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
                        dr2["psbl"] = (dskps * 100 / zps).ToString("0.00") + "%";
                        if (zyf == 0)
                            dr2["jebl"] = "0.00%";
                        else
                            dr2["jebl"] = (dskf * 100 / zyf).ToString("0.00") + "%";
                    }
                    Dgv.DataSource = dt;
                    //conn.Open();
                    //DsDskqsmx.Tables[0].Clear();
                    //sda.Fill(DsDskqsmx.Tables[0]);
                    //Dgv.DataSource = DsDskqsmx.Tables[0];
                    //sda.Dispose();
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

        private void Btndc_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(Dgv, "代收款收入趋势查询", ctrlDownLoad1, new int[] { 1, 2, 3, 4, 5, 6 });
        }
    }
}