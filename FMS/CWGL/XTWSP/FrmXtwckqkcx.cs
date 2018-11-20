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
using TMS.SelectFrm;

#endregion

namespace FMS.CWGL.XTWSP
{
    public partial class FrmXtwckqkcx : UserControl
    {
        private ClsG ObjG;
        private string PriConStr;
        public FrmXtwckqkcx()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriConStr = ClsGlobals.CntStrTMS;
            this.Vfmsxtw_jgckTableAdapter1.Connection.ConnectionString = PriConStr;
            CmbCkqk.SelectedIndex = 0;
            DataTable dt = ClsRWMSSQLDb.GetDataTable("SELECT -1 id, '全部' name,-1 sort FROM dbo.Tfmsxtwsr_lx UNION  SELECT id,name,sort FROM dbo.Tfmsxtwsr_lx  ORDER BY sort ", ClsGlobals.CntStrTMS);
            this.CmbLx.DataSource = dt;
            this.CmbLx.DisplayMember = "name";
            this.CmbLx.ValueMember = "id";
            this.CmbLx.SelectedIndex = 0;
            TxtJg.Text = ObjG.Jigou.mc;
            TxtJg.Tag = ObjG.Jigou.id.ToString();
            TxtSqdq.Tag = "0";
            TxtSqdq.Text = "";
        }

        private void BtnJg_Click(object sender, EventArgs e)
        {
            FrmSelectJG frm = new FrmSelectJG();
            frm.ShowDialog();
            frm.Preapre();
            frm.FormClosed += new Form.FormClosedEventHandler(frmJg_FormClosed);
        }
        private void frmJg_FormClosed(object sender, EventArgs e)
        {
            FrmSelectJG f = sender as FrmSelectJG;
            if (f.DialogResult == DialogResult.OK)
            {
                TxtJg.Text = f.PubDictAttrs["mc"];
                TxtJg.Tag = f.PubDictAttrs["id"];
            }
            else
            {
                TxtJg.Text = "";
                TxtJg.Tag = "0";
            }
        }

        private void BtnSel_Click(object sender, EventArgs e)
        {
            if (TxtJg.Text == "")
            {
                ClsMsgBox.Ts("请选择要查询的机构!");
                return;
            }
            string where = "  where jgid in (select id from jyjckj.dbo.tjigou where parentLst like '%," + TxtJg.Tag + ",%')  ";


            if (DtpSpStop.Checked)
                where += "  and inssj>='" + DtpSpStop.Value.Date + "' ";

            if (DtpSpStart.Checked)
                where += "  and inssj<'" + DtpSpStart.Value.Date.AddDays(1) + "' ";

            if (CmbCkqk.SelectedIndex > 0)
                where += " and zts='" + CmbCkqk.Text + "' ";

            if (CmbLx.SelectedIndex > 0)
                where += " and lxmc='" + CmbLx.Text + "' ";

            if (TxtSqdq.Text.Length > 0)
                where += " and dqmc='" + TxtSqdq.Text + "' ";


            Vfmsxtw_jgckTableAdapter1.FillByWhere(DSSP1.Vfmsxtw_jgck, where);
            if (Bds.Count == 0)
                ClsMsgBox.Ts("没有查询到信息，请重新选择查询条件！");

        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "系统外机构存款情况查询", this.ctrlDownLoad1, new int[] { 4 });
        }

        private void BtnSqdq_Click(object sender, EventArgs e)
        {
            FMS.SelectFrm.FrmSelectDq f = new FMS.SelectFrm.FrmSelectDq();
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(fsqdq_FormClosing);
        }
        void fsqdq_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FMS.SelectFrm.FrmSelectDq f = sender as FMS.SelectFrm.FrmSelectDq)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    TxtSqdq.Text = f.PubDictAttrs["dqmc"].ToString();
                    TxtSqdq.Tag = f.PubDictAttrs["dqid"].ToString();
                }
                else
                {
                    TxtSqdq.Text = "";
                    TxtSqdq.Tag = "0";
                }
            }

        }
    }
}