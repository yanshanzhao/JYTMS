#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pub;
using JY.Pri;
using FMS.ZYGL.XTWSRLX;

#endregion

namespace FMS.CWGL.XTWSR
{
    public partial class FrmXTWSRSP : UserControl
    {
        private ClsG ObjG;
        private string PriConStr;
        private DSXTWSR.VfmsxtwsrRow PriRow;
        public FrmXTWSRSP()
        {
            InitializeComponent();
        }

        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriConStr = ClsGlobals.CntStrTMS;
            vfmsxtwsrTableAdapter1.Connection.ConnectionString = PriConStr;
            CmbZt.SelectedIndex = 0;
            DataTable dt = ClsRWMSSQLDb.GetDataTable("SELECT -1 id, '全部' name,-1 sort FROM dbo.Tfmsxtwsr_lx UNION  SELECT id,name,sort FROM dbo.Tfmsxtwsr_lx  ORDER BY sort ", ClsGlobals.CntStrTMS);
            this.CmbLx.DataSource = dt;
            this.CmbLx.DisplayMember = "name";
            this.CmbLx.ValueMember = "id";
            this.CmbLx.SelectedIndex = 0;
        }
        private void BtnSel_Click(object sender, EventArgs e)
        {
            if (DtpQrStart.Checked == false && DtpQrStop.Checked == false && DtpSpStart.Checked == false && DtpSpStop.Checked == false)
            {
                ClsMsgBox.Ts("申请时间或审批时间必须选中一个！", ObjG.CustomMsgBox, this);
                return;
            }
            if (CmbZt.Text == "申请中" && (DtpSpStart.Checked == true || DtpSpStop.Checked == true))
            {
                ClsMsgBox.Ts("申请中的收入不能选则审批时间！", ObjG.CustomMsgBox, this);
                return;
            }
            string SWhere = " WHERE spjgid=" + ObjG.Jigou.id;
            if (DtpQrStart.Checked == true)
                SWhere += " AND inssj>= ' " + DtpQrStart.Value.Date + "' ";
            if (DtpQrStop.Checked == true)
                SWhere += " AND inssj<='" + DtpQrStop.Value.Date.AddDays(1) + "' ";
            if (DtpSpStart.Checked == true)
                SWhere += " AND spsj>= ' " + DtpSpStart.Value.Date + "' ";
            if (DtpSpStop.Checked == true)
                SWhere += " AND spsj<='" + DtpSpStop.Value.Date.AddDays(1) + "' ";
            if (CmbZt.SelectedIndex == 0)
                SWhere += " AND zt=0 ";
            else if (CmbZt.SelectedIndex == 1)
                SWhere += " AND zt=1 ";
            else
                SWhere += " AND zt=2 ";
            if (CmbLx.SelectedIndex != 0)
                SWhere += " AND lxs='" + CmbLx.Text + "'";
            vfmsxtwsrTableAdapter1.FillByWhere(Dsxtwsr1.Vfmsxtwsr, SWhere);
            if (Dgv.Rows.Count == 0)
                ClsMsgBox.Ts("没有查询到信息，请重新确认查询条件！", ObjG.CustomMsgBox, this);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
            {
                ClsMsgBox.Ts("请至少审核一条收入信息！", ObjG.CustomMsgBox, this);
                return;
            }
            PriRow = (DSXTWSR.VfmsxtwsrRow)((DataRowView)(Bds.Current)).Row;
            if (PriRow.zt > 0)
            {
                ClsMsgBox.Ts("该信息已经审核过无法审核！", ObjG.CustomMsgBox, this);
                return;
            }
            SPJG();
        }
        private void SPJG()
        {

            try
            {

                FrmXTWSRSPMX f = new FrmXTWSRSPMX();
                f.ShowDialog();
                f.Prepare(PriRow);
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("审批失败！", ex, ObjG.CustomMsgBox, this);
            }
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmXTWSRSPMX f = sender as FrmXTWSRSPMX;
            if (f.DialogResult == DialogResult.OK)
            {
                Bds.RemoveCurrent();
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
            ClsExcel.CreatExcel(Dgv, "系统外收入审批", ctrlDownLoad1, new int[] { 2 });
        }
    }
}