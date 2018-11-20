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

namespace FMS.CWGL.XTWSR
{
    public partial class FrmXtwsrcx2 : UserControl
    {
        public FrmXtwsrcx2()
        {
            InitializeComponent();
        }
        private ClsG ObjG;
        private DateTime PriDptStart = DateTime.Now;
        private DateTime PriDptEnd = DateTime.Now;
        public void Prepare()
        {
            this.VfmsxtwsrcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            DSXTWSR1.EnforceConstraints = false;
            DataTable dt = ClsRWMSSQLDb.GetDataTable("  SELECT -1 id,'-全部-'name,0  sort    UNION ALL   SELECT id,name ,sort FROM dbo.Tfmsxtwsr_lx  where   zt=0  ORDER BY sort ", ClsGlobals.CntStrTMS);
            this.CmbLx.DataSource = dt;
            this.CmbLx.DisplayMember = "name";
            this.CmbLx.ValueMember = "id";
            this.CmbLx.SelectedIndex = 0;
            CmbShbz.SelectedIndex = 0;
            CmbJkzt.SelectedIndex = 0;
        }
        private void BtnSel_Click(object sender, EventArgs e)
        {
            string aWhere = " where inssj> '" + DtpQrStart.Value.Date + "' and inssj<='" + DtpQrStop.Value.Date.AddDays(1) + "'  and jgid   in (SELECT id FROM jyjckj.dbo.tjigou WHERE parentLst LIKE '%," + ObjG.Jigou.id + ",%' )   ";
            if (CmbLx.SelectedIndex != 0)
                aWhere += " and lxmc='" + CmbLx.Text.ToString() + "' ";
            if (CmbJkzt.SelectedIndex > 0)
                aWhere += " and zts='" + CmbJkzt.Text + "' ";
            if (CmbShbz.SelectedIndex > 0)
                aWhere += " and spzts='" + CmbShbz.Text + "' ";
            if (Txtsqjg.Text.Length>0)
                aWhere += " and jgmc='" + Txtsqjg.Text + "' ";
            if (TxtSqdq.Text.Length > 0)
                aWhere += " and dqmc='" + TxtSqdq.Text + "' ";
            //aWhere += " and inssj> '" + DtpQrStart.Value.Date + "' and inssj<='" + DtpQrStop.Value.Date.AddDays(1) + "'";
            this.VfmsxtwsrcxTableAdapter1.FillByWhere(DSXTWSR1.Vfmsxtwsrcx, aWhere);
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
            }
        }

        private void BtnExecel_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "系统外收入查询", this.ctrlDownLoad1, new int[] { 5 });
        }

        private void Btnsldq_Click(object sender, EventArgs e)
        {
            FrmSelectJG f = new FrmSelectJG();

            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(fsqjg_FormClosing);
        }
        void fsqjg_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FrmSelectJG f = sender as FrmSelectJG)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    Txtsqjg.Text = f.PubDictAttrs["mc"].ToString();
                    Txtsqjg.Tag = f.PubDictAttrs["id"].ToString();
                }
                else
                {
                    Txtsqjg.Text = "";
                    Txtsqjg.Tag = "0";
                }
            }
        }

        private void BtnSqdq_Click(object sender, EventArgs e)
        {
            TMS.SelectFrm.FrmSelectDq f = new TMS.SelectFrm.FrmSelectDq();
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(fsqdq_FormClosing);
        }
        void fsqdq_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (TMS.SelectFrm.FrmSelectDq f = sender as TMS.SelectFrm.FrmSelectDq)
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