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

namespace FMS.DSKGL.DSKFFCGCX
{
    public partial class FrmDSKFFCGCX : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        #endregion
        public FrmDSKFFCGCX()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            CmbDszl.SelectedIndex = 0;
            ObjG = (ClsG)Session["ObjG"];
            VfmsdskffcgcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            ClsPopulateCmbDsS.PopuFMSDSKZZ_dszl(CmbDszl);
            CmbDszl.SelectedIndex = 0;
            
            ClsPopulateCmbDsS.PopuFMSDSKZZ_dskxl(CmbLX);
            ClsPopulateCmbDsS.PopuYd_dshksqfss(CmbZffs);
            ClsPopulateCmbDsS.PopuFmsDskffsj(CmbCplx);
            CmbZffs.SelectedIndex = 0;
            CmbLX.SelectedIndex = 0;
            CmbCplx.SelectedIndex = 0;
        }
        #region 时间的控件设置
        private void DtpQsStop_CheckedChanged(object sender, EventArgs e)
        {
            if (DtpQsStop.Checked)
                this.DtpQsStart.Checked = true;
        }
        private void DtpFfStop_CheckedChanged(object sender, EventArgs e)
        {
            if (DtpFfStop.Checked)
                this.DtpFfStart.Checked = true;
        }
        #endregion
        #region 查询
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            string aWhere = " where 1=1 ";
            if (TxtBFwkh.Text.Trim().Length > 0)
                aWhere = aWhere + " and fwkh='" + TxtBFwkh.Text.Trim().ToString() + "' ";
            if (TxtBSkr.Text.Trim().Length > 0)
                aWhere = aWhere + " and skr='" + TxtBSkr.Text.Trim().ToString() + "' ";
            if (CmbDszl.SelectedIndex != 0)
                aWhere = aWhere + " and dszl='" + CmbDszl.SelectedValue + "' ";
            if (CmbZffs.SelectedIndex != 0)
                aWhere = aWhere + " and zffs='" + CmbZffs.SelectedValue + "' ";
            if (CmbLX.SelectedIndex != 0)
            {
                if (CmbLX.SelectedIndex == 2)
                {
                    aWhere = aWhere + " and lx='Y' ";
                }
                else if (CmbLX.SelectedIndex == 1)
                {
                    aWhere = aWhere + " and lx<>'Y' ";
                }
            }
            if (CmbCplx.SelectedIndex > 0)
                aWhere = aWhere + " and cplx='" + CmbCplx.Text + "'";
            if (DtpQsStart.Checked && !DtpQsStop.Checked)
                aWhere = aWhere + " and qssj between '" + DtpQsStart.Value.ToString("yyyy-MM-dd") + "'  and  '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            else if (DtpQsStart.Checked && DtpQsStop.Checked)
                aWhere = aWhere + " and qssj between '" + DtpQsStart.Value.ToString("yyyy-MM-dd") + "' and dateadd(dd,0,'" + DtpQsStop.Value.ToString("yyyy-MM-dd") + "')";

            if (DtpFfStart.Checked && !DtpFfStop.Checked)
                aWhere = aWhere + " and jssj between '" + DtpFfStart.Value.ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            else if (DtpFfStart.Checked && DtpFfStop.Checked)
                aWhere = aWhere + " and jssj between '" + DtpFfStart.Value.ToString("yyyy-MM-dd") + "' and dateadd(dd,0,'" + DtpFfStop.Value.ToString("yyyy-MM-dd") + "')";


            this.VfmsdskffcgcxTableAdapter1.FillByWhere(this.Dsdskffcgcx1.Vfmsdskffcgcx, aWhere, "SELECT ROW_NUMBER() OVER(order by sljg) as xh,slsj, dqmc, sljg, qsjg, dddq, bh, fwkh, skr, skflxfs, khh, fhlxdh, yhzh, zffss, zffs, dsk, sfje, sxf, zdwz, khzt, dszls, dszl, qssj, qsr, zjlx, qsrzjh, dlqsr, dlqsrzjlx, dlqsrzjh, lx1, lx,jssj,cplx FROM dbo.Vfmsdskffcgcx");
            if (Dgv.RowCount == 0) 
                ClsMsgBox.Ts("没有查询的信息！",ObjG.CustomMsgBox,this); 
        }
        #endregion

        private void BtnExp_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 14,15,16};
            ClsExcel.CreatExcel(Dgv, "代收款发放成功查询", this.ctrlDownLoad1, Rows);    
        }
    }
}