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
    public partial class FrmXTWSRCX : UserControl
    {
        private ClsG ObjG;
        public FrmXTWSRCX()
        {
            InitializeComponent();
        }

        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            DataTable dt = ClsRWMSSQLDb.GetDataTable("SELECT -1 id,'全部' name FROM dbo.Tfmsxtwsr_lx union SELECT id,name FROM dbo.Tfmsxtwsr_lx", ClsGlobals.CntStrTMS);
            this.CmbLX.DataSource = dt;
            this.CmbLX.DisplayMember = "name";
            this.CmbLX.ValueMember = "id";
            this.CmbLX.SelectedIndex = 0;
            VfmsxtwpcTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }

        private void BtnSel_Click(object sender, EventArgs e)
        {
            try
            {

                if (DtpSqStart.Checked == false && DtpSqStop.Checked == false && DtpSpStart.Checked == false && DtpSpStop.Checked == false)
                {
                    ClsMsgBox.Ts("申请时间或审批时间至少选择一个！", ObjG.CustomMsgBox, this);
                    return;
                }
                string SWhere = " WHERE 1=1 ";

                if (DtpSqStart.Checked == false && DtpSqStop.Checked == true)
                    SWhere += " AND inssj<='" + DtpSqStop.Value.Date.AddDays(1) + "'";
                else if (DtpSqStart.Checked == true && DtpSqStop.Checked == false)
                    SWhere += " AND inssj>='" + DtpSqStart.Value.Date + "'";
                else if (DtpSqStart.Checked == true && DtpSqStop.Checked == true)
                    SWhere += " AND inssj>='" + DtpSqStart.Value.Date + "' AND inssj<'" + DtpSpStop.Value.Date.AddDays(1) + "'";

                else if (DtpSpStart.Checked == false && DtpSpStop.Checked == true)
                    SWhere += " AND spsj<='" + DtpSpStop.Value.Date.AddDays(1) + "'";
                else if (DtpSpStart.Checked == true && DtpSpStop.Checked == false)
                    SWhere += " AND spsj>='" + DtpSpStart.Value.Date + "'";
                else if (DtpSpStart.Checked == true && DtpSpStop.Checked == true)
                    SWhere += " AND spsj>='" + DtpSpStart.Value.Date + "' AND spsj<'" + DtpSpStop.Value.Date.AddDays(1) + "'";

                if (!string.IsNullOrEmpty(TxtSqJg.Text))
                    SWhere += " AND zzjgid in (select id from jyjckj.dbo.tjigou where parentLst like '%," + TxtSqJg.Tag + ",%') ";
                if (!string.IsNullOrEmpty(TxtSpJg.Text))
                    SWhere += " AND spjgid in (select id from jyjckj.dbo.tjigou where parentLst like '%," + TxtSpJg.Tag + ",%') ";

                if (!string.IsNullOrEmpty(TxtLsh.Text))
                    SWhere += " AND lsh='" + TxtLsh.Text + "'";
                if (!string.IsNullOrEmpty(TxtYwdh.Text))
                    SWhere += " AND ywdh='" + TxtYwdh.Text + "'";
                if (CmbLX.SelectedIndex != 0)
                    SWhere += " AND lxid=" + CmbLX.SelectedValue;
                VfmsxtwpcTableAdapter1.FillByWhere(Dsxtwsr1.Vfmsxtwpc, SWhere);
                if (Dgv.Rows.Count == 0)
                    ClsMsgBox.Ts("没有查询出符合条件的信息，请重新确认查询条件！", ObjG.CustomMsgBox, this);
            }
            catch (Exception)
            {
                
                throw;
            }


        }

        private void BtnSeleSQ_Click(object sender, EventArgs e)
        {
            FrmSelectJg1 f = new FrmSelectJg1();
            f.ShowDialog();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg1 f = sender as FrmSelectJg1;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtSqJg.Text = f.PubDictAttrs["mc"];
                this.TxtSqJg.Tag = f.PubDictAttrs["id"];
            }
            else
            {
                this.TxtSqJg.Text = "";
                this.TxtSqJg.Tag = "";
            }
        }

        private void BtnSeleSP_Click(object sender, EventArgs e)
        {
            FrmSelectJg1 frm = new FrmSelectJg1();
            frm.ShowDialog();
            frm.Prepare();
            frm.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(frm_FormClosed);
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg1 f = sender as FrmSelectJg1;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtSpJg.Text = f.PubDictAttrs["mc"];
                this.TxtSpJg.Tag = f.PubDictAttrs["id"];
            }
            else
            {
                this.TxtSqJg.Text = "";
                this.TxtSqJg.Tag = "";
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.Rows.Count > 60000)
            {
                ClsMsgBox.Ts("不允许导出大于60000条的数据!", (Session["ObjG"] as ClsG).CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(Dgv, "系统外收入查询", ctrlDownLoad1);
        }
         
    }
}
