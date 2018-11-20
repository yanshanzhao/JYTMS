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
using System.Collections;
using System.Data.SqlClient;

#endregion

namespace FMS.CWGL.ZZHQRJKD.TZFGBFJKRB
{
    public partial class FrmTZFGBFJKRB : UserControl
    {
        private ClsG ObjG;
        private string PriLsh;
        //private int Prilx = 0;
        public FrmTZFGBFJKRB()
        {
            InitializeComponent();
        }

        public void Prepare()
        {

            ObjG = (ClsG)Session["ObjG"];

            this.VfmsxtsrTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            string sql = "   SELECT -1 id,'-全部-'name,0  sort    UNION ALL  SELECT id,name ,sort FROM dbo.Tfmsxtwsr_lx   where  zt=0  ORDER BY sort ";
            //if (Prilx == 2)
            //    sql =sql+" where  bh in ('tzf','gbf') "; 
            DataTable dt = ClsRWMSSQLDb.GetDataTable(sql, ClsGlobals.CntStrTMS);
            this.CmbLx.DataSource = dt;
            this.CmbLx.DisplayMember = "name";
            this.CmbLx.ValueMember = "id";
            this.CmbLx.SelectedIndex = 0;


            //CmbLx.DataSource = dt1;
            //CmbLx.ValueMember = "id";
            //CmbLx.DisplayMember = "name";
            //CmbLx.SelectedIndex = 0;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string SWhere = " WHERE jgid=" + ObjG.Jigou.id + " AND zt=0 ";
            //SWhere += " AND lxbhs='" + CmbLx.Text + "'";
            if (CmbLx.SelectedIndex > 0)
            {
                SWhere += " AND lxbhs='" + CmbLx.Text.Trim().ToString() + "'";
            }
            if (DtpStart.Checked)
                SWhere += " AND inssj>='" + DtpStart.Value.Date + "'";
            if (DtpStop.Checked)
                SWhere += " AND inssj<'" + DtpStop.Value.Date.AddDays(1) + "'";
            VfmsxtsrTableAdapter1.FillByWhere(Dstfmsxtsr1.vfmsxtsr, SWhere);
            LblRowCount.Text = "共有" + Bds.Count.ToString() + "条数据";
            if (Dgv.Rows.Count == 0)
            {
                this.LblSum.Text = "应存0.00元";
            }
            else
            {
                this.LblSum.Text = "应存" + Dstfmsxtsr1.vfmsxtsr.Compute("sum(je)", "zt=0") + "元";
            }
        }

        private void BtnJk_Click(object sender, EventArgs e)
        {
            FrmTZFGBFJKMX f = new FrmTZFGBFJKMX();
            f.ShowDialog();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            BtnSearch.PerformClick();
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Bds.Count > 60000)
            {
                ClsMsgBox.Ts("不允许导出大于60000条的数据!", ObjG.CustomMsgBox, this);
                return;
            }
            int[] CellIndex = { 4 };
            ClsExcel.CreatExcel(Dgv, "运单调整或服务卡工本费明细", this.ctrlDownLoad1, CellIndex);
        }
    }
}
