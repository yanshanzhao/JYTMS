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

namespace FMS.CWGL.FWKGBFCX
{
    public partial class FrmFWKGBFCX : UserControl
    {
        private ClsG ObjG;
        public FrmFWKGBFCX()
        {
            InitializeComponent();
        }

        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            TxtSqdq.Text = "";
            TxtSqdq.Tag = "0";
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
                TxtJg.Text = frm.PubDictAttrs["mc"];
                TxtJg.Tag = frm.PubDictAttrs["id"];
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string SWhere = " WHERE 1=1 AND sflx='gbf'";
            if (DtpSqStart.Checked)
                SWhere += " AND sqsj>='" + DtpSqStart.Value.Date + "'";
            if (DtpSqStop.Checked)
                SWhere += " AND sqsj<'" + DtpSqStop.Value.Date.AddDays(1) + "'";
            if (!string.IsNullOrEmpty(TxtJg.Text))
                SWhere += " AND jgid=" + TxtJg.Tag;
            if (!string.IsNullOrEmpty(TxtSqdq.Text))
                SWhere += " AND dqid=" + TxtSqdq.Tag;
            vfmsxtsrcxTableAdapter1.FillByWhere(dsxtsrcx1.vfmsxtsrcx, SWhere);
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
            ClsExcel.CreatExcel(this.Dgv, "服务卡工本费", this.ctrlDownLoad1, Rows);
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