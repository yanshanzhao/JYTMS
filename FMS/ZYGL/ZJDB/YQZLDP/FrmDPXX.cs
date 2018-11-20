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

namespace FMS.ZYGL.ZJDB.YQZLDP
{
    public partial class FrmDPXX : Form
    {
        public FrmDPXX()
        {
            InitializeComponent();
        }
        public void Prepare(DSYQZL.VfmsyqzlfhRow aRow)
        {
            LblZczh1.Text = aRow.zczh;
            LblZczhmc1.Text = aRow.zczhmc;
            LblZcyhlx1.Text = aRow.zczhyh;
            LblSjzzje1.Text = aRow.sjzze.ToString();
            LblZrzh1.Text = aRow.zrzh;
            LblZrzhmc1.Text = aRow.zrzhmc;
            LblZrzhlx1.Text = aRow.zrzhyh;
            LblZZje1.Text = aRow.zze.ToString();
            LblBz1.Text = aRow.bz;
            this.VfmsyqzlfhmxTableAdapter.FillByWhere(this.DSYQZL1.Vfmsyqzlfhmx, " where pcid="+aRow.id);
        }

        private void BtnEls_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            ClsExcel.CreatExcel(this.Dgv, "银企直联调拨信息", this.ctrlDownLoad1,new int[]{0,2} );
        }
    }
}