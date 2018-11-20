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
        #region ��Ա����
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
                ClsMsgBox.Ts("û��Ҫ��������Ϣ!", ObjG.CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(this.Dgv, "���տ���Ϣ��" + LblCKJG.Text + "--" + LblCKSj.Text + "��", this.ctrlDownLoad1, new int[] { 1, 2, 3 });         
        }
    }
}