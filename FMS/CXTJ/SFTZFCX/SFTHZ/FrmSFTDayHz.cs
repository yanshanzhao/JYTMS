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

#endregion

namespace FMS.CXTJ.SFTZFCX.SFTHZ
{
    public partial class FrmSFTDayHz : UserControl
    {
        public FrmSFTDayHz()
        {
            InitializeComponent();
        }

        public void Prepare()
        {
            this.VfmssftzhmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.DsSfthz1.EnforceConstraints = false;
        }

        private void BtnSele_Click(object sender, EventArgs e)
        {
            string SqlStr = string.Format(" SELECT  sj,SUM(cgbs) cgbs,SUM(cgje) AS cgje,SUM(sbbs) sbbs,SUM(sbje) sbje,SUM(je) je FROM (SELECT  sj,   cgbs,  cgje,  sbbs,  sbje, je FROM  Vfmssftzhmx WHERE sj>='{0}' AND sj<'{1}'   ) a  GROUP BY a.sj ", DtimBegin.Value.Date, DtimEnd.Value.AddDays(1).Date);
            this.VfmssftzhmxTableAdapter1.FillByWhere(this.DsSfthz1.Vfmssftzhmx, "", 1, SqlStr);
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (this.Dgv.RowCount == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "善付通每日汇总", this.ctrlDownLoad1);
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

        }
    }
}