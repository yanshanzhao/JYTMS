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
using NPOI.HSSF.UserModel;
using System.IO;
using System.Configuration;
#endregion
namespace FMS.DSKGL.QRYCDSKMX
{
    public partial class FrmQRYCDSKMXLL : Form
    {
        #region 成员变量
        private ClsG ObjG;
        #endregion
        public FrmQRYCDSKMXLL()
        {
            InitializeComponent();
        }
        public void Prepare(string aRbdh, string aCkjg, string aCksj, string aDsk, string aYdcounts, string aDskbz, int aId, string aDkje)
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            this.LblRBDH.Text = aRbdh;
            this.LblCKJG.Text = aCkjg;
            this.LblCKSj.Text = aCksj;
            this.LblDSK.Text = aDsk;
            this.LblYDCOUNTS.Text = aYdcounts;
            this.LblYDBZ.Text = aDskbz;
            this.LblDkje.Text = aDkje;
            this.VfmsqrycdskmxxxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.VfmsqrycdskmxxxTableAdapter1.FillByPcid(DSQRYCDSK1.Vfmsqrycdskmxxx, aId);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息!", ObjG.CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(this.Dgv, "代收款信息（" + LblCKJG.Text + "--" + LblCKSj.Text + "存", this.ctrlDownLoad1, new int[] { 1, 2, 3 });         
        }
    }
}