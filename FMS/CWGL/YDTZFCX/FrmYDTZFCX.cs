#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using FMS.SeleFrm;
using JY.Pri;
using JY.Pub;

#endregion

namespace FMS.CWGL.YDTZFCX
{
    public partial class FrmYDTZFCX : UserControl
    {
        private ClsG ObjG;
        public FrmYDTZFCX()
        {
            InitializeComponent();
        }

        public void Prepare()
        {

            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            TxtSqdq.Text = "";
            TxtSqdq.Tag = "0";
            CmbSflx.SelectedIndex = 1; 
        }

        private void BtnSel_Click(object sender, EventArgs e)
        {
            FrmSelectJg1 f = new FrmSelectJg1();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg1 frm = sender as FrmSelectJg1;
            if (frm.DialogResult == DialogResult.OK)
            {
                TxtSqjg.Text = frm.PubDictAttrs["mc"];
                TxtSqjg.Tag = frm.PubDictAttrs["id"];
            }
            else if (frm.DialogResult == DialogResult.No)
            {
                this.TxtSqjg.Text = "";
                this.TxtSqjg.Tag = "";
            }
        }

        private void BtnSea_Click(object sender, EventArgs e)
        {
            FrmSelectJg frm = new FrmSelectJg();
            frm.Prepare();
            frm.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(frm_FormClosed);
            frm.ShowDialog();
        }
        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg frm = sender as FrmSelectJg;
            if (frm.DialogResult == DialogResult.OK)
            {
                TxtSljg.Text = frm.PubDictAttrs["mc"];
                TxtSljg.Tag = frm.PubDictAttrs["id"];
            }
            else if (frm.DialogResult == DialogResult.No)
            {
                this.TxtSljg.Text = "";
                this.TxtSljg.Tag = "";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.DtpSqStart.Checked == false && this.DtpSqStop.Checked == false && this.DtpSpStart.Checked == false && this.DtpSpStop.Checked == false)
            {
                ClsMsgBox.Ts("申请时间或审批时间必须选则一个！", ObjG.CustomMsgBox, this);
                return;
            }
            string SWhere = " WHERE 1=1 AND sflx='tzf'";
            if (DtpSqStart.Checked)
                SWhere += " AND sqsj>='" + DtpSqStart.Value.Date + "'";
            if (DtpSpStop.Checked)
                SWhere += " AND sqsj<'" + DtpSqStop.Value.Date.AddDays(1) + "'";
            if (DtpSpStart.Checked)
                SWhere += " AND spsj>='" + DtpSpStart.Value.Date + "'";
            if (DtpSpStop.Checked)
                SWhere += " AND spsj<'" + DtpSpStop.Value.Date.AddDays(1) + "'";
            if (!string.IsNullOrEmpty(TxtSqjg.Text))
                SWhere += " AND jgid=" + TxtSqjg.Tag;
            if (!string.IsNullOrEmpty(TxtSljg.Text))
                SWhere += " AND sljgid=" + TxtSljg.Tag;
            if (!string.IsNullOrEmpty(TxtSqdq.Text))
                SWhere += " AND dqid=" + TxtSqdq.Tag;
            VfmsxtsrcxTableAdapter1.FillByWhere(Dsxtsrcx1.vfmsxtsrcx, SWhere);
        }

        private void BtnDaoChu_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.RowCount > 60000)
            {
                ClsMsgBox.Ts("数据超过6000条无法导出！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 3, 4, 5 };
            ClsExcel.CreatExcel(this.Dgv, "运单调整费", this.ctrlDownLoad1, Rows);
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