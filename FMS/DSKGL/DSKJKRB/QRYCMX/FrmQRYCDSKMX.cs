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

namespace FMS.DSKGL.DSKJKRB.QRYCMX
{
    public partial class FrmQRYCDSKMX : UserControl
    {
        public FrmQRYCDSKMX()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            CmbDskbz.SelectedIndex = 1;
            CmbZffs.SelectedIndex = 0;
            CmbCkjgkhh.SelectedIndex=0;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}