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

namespace FMS.ZYGL.ZJDB.YQZLDP
{
     
    public partial class FrmJe : Form
    {
        #region 成员变量
         private ClsG ObjG;
         private decimal Prije=0;
        #endregion
        public FrmJe()
        {
            InitializeComponent();
        }
        public void Prepare(decimal aje)
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            Prije = aje;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            TxtJe.Text = TxtJe.Text.Trim(); 
            if (string.IsNullOrEmpty(TxtJe.Text))
            {
                ClsMsgBox.Ts("请输入转账金额！", this, TxtJe, ObjG.CustomMsgBox);
                return;
            }
            decimal n;
            if (!decimal.TryParse(TxtJe.Text,out n))
            {
                ClsMsgBox.Ts("转账金额输入格式不正确，请重新输入！", this, TxtJe, ObjG.CustomMsgBox);
                TxtJe.Clear();
                return;
            }
            n=Convert.ToDecimal(TxtJe.Text);
            if (n != Prije)
            {
                ClsMsgBox.Ts("转账金额输入不正确，请重新输入！", this, TxtJe, ObjG.CustomMsgBox);
                TxtJe.Clear();
                return;
            }
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void TxtJe_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            BtnSave.PerformClick();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
