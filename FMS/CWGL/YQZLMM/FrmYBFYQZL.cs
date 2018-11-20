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
#endregion

namespace FMS.CWGL.YQZLMM
{
    public partial class FrmYBFYQZL : UserControl
    {

        private ClsG ObjG;
        public FrmYBFYQZL()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
        }

        private void BtnEditPwd_Click(object sender, EventArgs e)
        {
            FrmYBFPWD f = new FrmYBFPWD();
            f.ShowDialog();
            f.Prepare();
        }
    }
}