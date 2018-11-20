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

namespace FMS.CWGL.LSDWCKCX
{
    public partial class FrmLSDWCKCX : UserControl
    {
        public FrmLSDWCKCX()
        {
            InitializeComponent();
        }
        private ClsG ObjG;
        private int PriJgid = 0;
        private string PriJgmc = "";
        private DateTime PriStartSj = DateTime.Now;
        private DateTime PriStopSj = DateTime.Now;
        public void Prepare()
        {

            this.VfmslsdwckcxTableAdapter.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            this.Cmbzt.SelectedIndex = 0;

        }

        private void BtnSave_Click_1(object sender, EventArgs e)
        {
          
           
            DSLSDWCKCX.EnforceConstraints = false;
            
            string aWhere = " where  inssj> '" + DtpQrStart.Value.Date + "' and inssj<='" + DtpQrStop.Value.Date.AddDays(1) + "'";
            if (this.TxtJg.Text.Trim().Length > 0)
            {
                aWhere += " and jgmc='" + TxtJg.Text.Trim() + "' ";
            }
            if (Cmbzt.SelectedIndex != 0)
            {
                aWhere += " and dkzts='" + Cmbzt.Text + "' ";
            }
          
            this.VfmslsdwckcxTableAdapter.FillByWhere(DSLSDWCKCX.Vfmslsdwckcx, aWhere);
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
            }
        }

        private void BtnJG_Click(object sender, EventArgs e)
        {
            FrmSelectJg1 f = new FrmSelectJg1();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
	}

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg1 f =sender as FrmSelectJg1;
            if (f.DialogResult==DialogResult.OK)
            {
                this.TxtJg.Text = f.PubDictAttrs["mc"];
                this.PriJgmc = TxtJg.Text;
                PriJgid = Convert.ToInt32(f.PubDictAttrs["id"]);
            }
            else if(f.DialogResult==DialogResult.No)
            {
                this.TxtJg.Text = "";
                PriJgid = 0;
                PriJgmc = "";
            }
        }

        private void BtnDaoChu_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.RowCount > 6000)
            {
                ClsMsgBox.Ts("数据过大超过6000，无法导出！", ObjG.CustomMsgBox, this);

            }
            int[] Rows = new int[] { 3, 4, 5 };
            ClsExcel.CreatExcel(this.Dgv, "连锁店未存款查询", ctrlDownLoad1, Rows);
        }
        
    }
}