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

namespace FMS.DSKGL.DSKJKRB.ZZYCMX
{
    public partial class FrmZZYCDSKMX : UserControl
    {
        public FrmZZYCDSKMX()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            CmbFkfs.SelectedIndex = 0;
            CbmDskbz.SelectedIndex = 0;
        }

        private void BtnTj_Click(object sender, EventArgs e)
        {
            FrmZZYCDSKTJ f = new FrmZZYCDSKTJ();
            f.ShowDialog();
            f.Prepare();
        }        

        private void BtnExlhz_Click(object sender, EventArgs e)
        {

        }

        private void BtnExlmx_Click(object sender, EventArgs e)
        {

        }
    }
}