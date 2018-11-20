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
using FMS.SeleFrm;

#endregion

namespace FMS.CWGL.XTWSR
{
    public partial class FrmXtwDkcx : UserControl
    {
        private ClsG ObjG;
        public FrmXtwDkcx()
        {
            InitializeComponent();
        }

        public void Prepare()
        {
            //银行类型
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable("SELECT -1 id, '全部' jc   UNION  SELECT id,jc FROM  tyhlx WHERE id>=43   ", ClsGlobals.CntStrTMS);
            this.CmbYhlx.DataSource = dtYhlx;
            this.CmbYhlx.DisplayMember = "jc";
            this.CmbYhlx.ValueMember = "id";
            this.CmbYhlx.SelectedIndex = 0;
            CmbZt.SelectedIndex = 0;
            this.VfmsxtwpcTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;

        }

        private void BtnJG_Click(object sender, EventArgs e)
        {
            FrmSelectJg f = new FrmSelectJg();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtJg.Text = f.PubDictAttrs["mc"];
                this.TxtJg.Tag = f.PubDictAttrs["id"];
            }
        }

        private void BtnSel_Click(object sender, EventArgs e)
        {
            string where = "  where inssj>='" + DtpStart.Value.Date + "' and inssj<'" + DtpStop.Value.Date.AddDays(1) + "'  ";
            if (!string.IsNullOrEmpty(TxtJg.Text.Trim()))
            {
                where += " and zzjgid= " + TxtJg.Tag;
            }
            if (CmbYhlx.SelectedIndex > 0)
                where += " and yhlxid= " + CmbYhlx.SelectedValue;
            if (CmbZt.SelectedIndex < 2)
                where += " and zts='" + CmbZt.Text + "'";
            this.VfmsxtwpcTableAdapter1.FillByWhere(DSXtDKxz1.Vfmsxtwpc, where);

        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "系统代扣查询", this.ctrlDownLoad1, new int[] { 2 });
        }


    }
}