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
using FMS.ZYGL.ZJDB.YQZLDP;

#endregion

namespace FMS.ZYGL.ZJDB.YQZLDB
{
    public partial class FrmPwd2 : Form
    {
        private ClsG ObjG;
        private DSYQZL.VfmsyqzlfhRow PriRow;
        public FrmPwd2()
        {
            InitializeComponent();
        }
        public void Prepare(DSYQZL.VfmsyqzlfhRow aRow)
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriRow = aRow;
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
            //FrmZzCz f1 = new FrmZzCz();
            //f1.Prepare(PriRow);
            //f1.ShowDialog();
            //f1.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
        FrmZzCz f2 = new FrmZzCz();
            if(f2.DialogResult==DialogResult.Yes)
        this.DialogResult = DialogResult.Yes;
             
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