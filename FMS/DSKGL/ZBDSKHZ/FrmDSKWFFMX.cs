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
    public partial class FrmDSKWFFMX : Form
    {
        public FrmDSKWFFMX()
        {
            InitializeComponent();
        }
        public void Prepare(string aSj, int azt)
        {
            this.VfmsZBDSKHZDSKMX2TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            string aStr = "";
            string aWhere = " ";
            DateTime aSjKs = Convert.ToDateTime(aSj).Date;
            DateTime aSjTop = aSjKs.AddDays(1);
         
            if (azt == 5)
            {
                this.Text = "未发代收款明细查询";
                aStr = "select DISTINCT bh,slsj,sljg,sldq,qssj,qsjg,fwkh,dsk from  VfmsZBDSKHZDSKMX2 WHERE ((zt=1 AND yksj>='" + aSjTop + "') OR (zt=0 AND jysj<'" + aSjKs + "' AND dskyk=0) OR (zt IS NULL) AND shsj<'" + aSjTop + "') AND (ffdskzt=0 or (ffdskzt>0 and ffsj>='" + aSjTop + "'))";
            }
            else
            {
                this.Text = "压款代收款明细查询";
                aStr = " select DISTINCT bh,slsj,sljg,sldq,qssj,qsjg,fwkh,dsk from VfmsZBDSKHZDSKMX2 where zt in (0,1)  and  ((jysj is null and yksj<'" + aSjTop + "') or (yksj<'" 
                    + aSjTop + "' and jysj>'" + aSjTop + "') )";
            }
            this.VfmsZBDSKHZDSKMX2TableAdapter1.FillByWhere(this.DSZBDSKHZ1.VfmsZBDSKHZDSKMX2, aWhere, aStr);
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
            int[] Rows = new int[] { 7 };
            ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1, Rows);   
        }
    }
}