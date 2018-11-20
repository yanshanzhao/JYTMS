#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using JY.Pub;
using JY.Pri;

#endregion

namespace FMS.DSKGL.DSKSFTHZ
{
    public partial class FrmDSksftmx : Form
    {

        public FrmDSksftmx()
        {
            InitializeComponent();
        }
        public void Prepare(string awhere)
        {
            this.DSDskhz1.EnforceConstraints = false;
            this.VfmssftcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.VfmssftcxTableAdapter1.FillByWhere(DSDskhz1.Vfmssftcx, awhere);
        }

        public void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
                return;
            int[] RowIndex = { 3 };
            ClsExcel.CreatExcel(Dgv, "善付通支付结果明细", this.ctrlDownLoad1, RowIndex);
        }

    }
}