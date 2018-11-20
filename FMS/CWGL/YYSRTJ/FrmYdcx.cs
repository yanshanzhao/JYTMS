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

namespace FMS.CWGL.YYSRTJ
{
    public partial class FrmYdcx : Form
    {
        public FrmYdcx()
        {
            InitializeComponent();
        }

        public void Prepare(string aBh, string aFkfs)
        {
            //T.提付F.发付Z.发月结D.提月结S.第三方月结
            if (aFkfs == "F")
                aFkfs = "发付";
            else if (aFkfs == "H")
                aFkfs = "回付";
            else if (aFkfs == "T")
                aFkfs = "提付";
            else if (aFkfs == "Z")
                aFkfs = "发月结";
            else if (aFkfs == "D")
                aFkfs = "提月结";
            else
                aFkfs = "第三方月结";
            this.VfmsyysrcxmxTableAdapter.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            string awhere = " where bh='" + aBh + "' and fkfs='" + aFkfs + "'";
            this.VfmsyysrcxmxTableAdapter.FillByWhere2(this.DSYYSRCX.Vfmsyysrcxmx, awhere);
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (this.Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的数据");
            }
            else
            {
                ClsExcel.CreatExcel(this.Dgv, " 运单详细信息 ", this.ctrlDownLoad1);
            }
        }
    }
}