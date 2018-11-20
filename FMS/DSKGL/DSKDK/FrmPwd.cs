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
using HCD.Gen;

#endregion

namespace FMS.DSKGL.DSKDK
{
    public partial class FrmPwd : Form
    {
        private ClsG ObjG;
        public FrmPwd()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            TxtPwd.Text = TxtPwd.Text.Trim();
            if (ObjG.Renyuan.IsyqzlpwdNull())
            {
                ClsMsgBox.Ts("还没有维护代扣密码，请联系管理员！", ObjG.CustomMsgBox, this);
                return;
            }
            if (string.IsNullOrEmpty(TxtPwd.Text))
            {
                ClsMsgBox.Ts("请输入代扣密码！", this, TxtPwd, ObjG.CustomMsgBox);
                return;
            }
            if (ObjG.Renyuan.yqzlpwd.CompareTo(hcdMD5.getMD5Str(TxtPwd.Text, ObjG.Renyuan.loginName)) != 0)
            {
                ClsMsgBox.Ts("密码输入不正确，请重新输入！", this, TxtPwd, ObjG.CustomMsgBox);
                TxtPwd.Clear();
                return;
            }
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtPwd_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            BtnSave.PerformClick();
        }
    }
}