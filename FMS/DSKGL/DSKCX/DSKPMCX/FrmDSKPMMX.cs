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
#endregion

namespace FMS.DSKGL.DSKCX.DSKPMCX
{
    public partial class FrmDSKPMMX : Form
    {
        private ClsG ObjG;
        public FrmDSKPMMX()
        {
            InitializeComponent();
        }
        public void Prepare(DataGridViewRow aDr, string aStart, string aEnd)
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            VDskpmmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            LabFwkh.Text = aDr.Cells["DgvClsTxtFwkh"].Value.ToString();
            LabFwkh.Text = aDr.Cells["DgvClsTxtFwkh"].Value.ToString();
            LabPm.Text = aDr.Cells["DgvClsTxtMc"].Value.ToString();
            LabStartsj.Text = aStart.ToString();
            LabEndsj.Text = aEnd.ToString();
            VDskpmmxTableAdapter1.FillByWhere(DSDSKPMMX1.VDskpmmx,
                " where fwkh='" + aDr.Cells["DgvClsTxtFwkh"].Value.ToString()
                + "' and inssj between '" + aStart.ToString()
                + "' and '" + aEnd.ToString() + "'");
        }


        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 4 };
            ClsExcel.CreatExcel(Dgv, "代收款排名明细", this.ctrlDownLoad1, Rows, true);
            //ClsExcel.CreatExcel(Dgv, "代收款排名明细", this.ctrlDownLoad1);   
        }
        #endregion

    }
}