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

namespace FMS.DSKGL.ZBDSKHZ
{
    public partial class FrmDSKMXCX : Form
    {
        public FrmDSKMXCX()
        {
            InitializeComponent();
        }
        public void Prepare(string aSj, int azt)
        {
            this.VfmsZBDSKHZDSKMX1TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            string aWhere = "";
            if (azt == 1)
            {
                this.Text = "已收代收款明细查询";
                //if (aRowCount > 0)
                aWhere =   "  where  zt=0  and  fksj='" + aSj + "' ";
                //else
                //    aWhere = aWhere + "  and zt=0  and  fksj<='" + aSj + "' ";
            }
            else
            {
                this.Text = "直接发款明细查询";
                //if (aRowCount > 0)
                aWhere =   " where  zt=1  and fksj='" + aSj + "'";
                //else
                //    aWhere = aWhere + " and zt=1  and fksj<='" + aSj + "'";

            }
            this.VfmsZBDSKHZDSKMX1TableAdapter1.FillByWhere1(this.DSZBDSKHZ1.VfmsZBDSKHZDSKMX1, aWhere);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！");
                return;
            }
            int[] Rows = new int[] { 3, 4 };
            ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1, Rows);
        }
    }
}