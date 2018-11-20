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
using JY.Pri;
using JY.Pub;
#endregion

namespace FMS.DSKGL.ZZYCDSKMX
{
    public partial class FrmDSKRBLL : Form
    {

        public FrmDSKRBLL()
        {
            InitializeComponent();
        }
        public void Prepare(string aRbdh,string aSkjg,string aDsk,string aSxf,string aYdcounts,int aId )
        {
            this.LblRBDH.Text = aRbdh;
            this.LblSKJG.Text = aSkjg;
            this.LblDSK.Text = aDsk;
            this.LblSXF.Text = aSxf;
            this.LblYDCOUNTS.Text = aYdcounts;
            this.VfmsdskrbxxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.VfmsdskrbxxTableAdapter1.FillByPcid(this.DSZZYCMX1.Vfmsdskrbxx, aId);           
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
            int[] Rows = new int[] { 4, 5 };
            ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1, Rows); 
            //ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1); 
        }
    }
}