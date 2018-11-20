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

namespace FMS.CWGL.YQZLMM
{
    public partial class FrmYBFPWD : Form
    {
        private ClsG ObjG;
        private string priConStr;
        private string PriPwd;
        //private DSJGGL.vrenyuanRow PriCurRow;
        public FrmYBFPWD()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["objG"];
            priConStr = ClsGlobals.CntStrKj;
            txtOldPass.MaxLength = ClsOptions.WebCfg.MaxPasswordLen;
            txtNewPass.MaxLength = ClsOptions.WebCfg.MaxPasswordLen;
            txtNewPass2.MaxLength = ClsOptions.WebCfg.MaxPasswordLen;
            lblLoginName.Text = string.Format("账户: {0}", ObjG.Renyuan.loginName);
            DataRow Row = ClsRWMSSQLDb.GetDataRow(string.Format("SELECT ybfyqzlpwd FROM dbo.trenyuan WHERE id ={0}", ObjG.Renyuan.id), priConStr);
            if (Row != null)
                PriPwd = Row[0].ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    ((TextBox)(control)).Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PriPwd) && string.IsNullOrEmpty(txtOldPass.Text))
            {
                ClsMsgBox.Ts("原密码不能为空！", this, txtOldPass, ObjG.CustomMsgBox);
                return;
            }
            string sOldPass = txtOldPass.Text.Trim();
            txtOldPass.Text = sOldPass;
            if (!string.IsNullOrEmpty(PriPwd) && sOldPass.Length < ClsOptions.WebCfg.MinPasswordLen)
            {
                ClsMsgBox.Cw(string.Format("原密码长度为零或不足{0}!", ClsOptions.WebCfg.MinPasswordLen));
                return;
            }
            else if (!string.IsNullOrEmpty(PriPwd) && PriPwd.CompareTo(hcdMD5.getMD5Str(sOldPass, ObjG.Renyuan.loginName)) != 0)
            {
                ClsMsgBox.Ts("原密码不正确!", this, txtOldPass, ObjG.CustomMsgBox);
                return;
            }
            string sNewPass = txtNewPass.Text.Trim();
            txtNewPass.Text = sNewPass;
            if (sNewPass.Length < ClsOptions.WebCfg.MinPasswordLen)
            {
                ClsMsgBox.Cw(string.Format("新密码为空或长度不足{0}!", ClsOptions.WebCfg.MinPasswordLen));
                return;
            }
            if (this.ObjG.Renyuan.password.CompareTo(hcdMD5.getMD5Str(sNewPass, ObjG.Renyuan.loginName)) == 0)
            {
                ClsMsgBox.Ts("新密码不能与登录密码相同！", this, txtNewPass, ObjG.CustomMsgBox);
                return;
            }
            if (ClsRegEx.IsPwdNumber(txtNewPass.Text.Trim()))
            {
                ClsMsgBox.Ts("密码不能全为数字！", this, txtNewPass, ObjG.CustomMsgBox);
                return;
            }
            if (ClsRegEx.IsPwdLetter(txtNewPass.Text.Trim()))
            {
                ClsMsgBox.Ts("密码不能全为字母！", this, txtNewPass, ObjG.CustomMsgBox);
                return;
            }
            if (ClsRegEx.IsPwdChar(txtNewPass.Text.Trim()))
            {
                ClsMsgBox.Ts("密码不能全为字符！", this, txtNewPass, ObjG.CustomMsgBox);
                return;
            }
            if (sNewPass != txtNewPass2.Text.Trim())
            {
                ClsMsgBox.Ts("新密码两次输入不一致!", this, txtNewPass2, ObjG.CustomMsgBox);
                return;
            }
            if (sNewPass == sOldPass)
            {
                ClsMsgBox.Ts("新密码与原密码相同!", this, txtNewPass2, ObjG.CustomMsgBox);
                return;
            }
            string newPassword = hcdMD5.getMD5Str(sNewPass, ObjG.Renyuan.loginName);
            PriPwd = newPassword;
            try
            {
                int RowCont = ClsRWMSSQLDb.ExecuteCmd(string.Format(" update trenyuan set ybfyqzlpwd='{0}' where id ={1} ", PriPwd, ObjG.Renyuan.id), priConStr);

                if (RowCont == 1)
                {
                    ClsMsgBox.Ts("保存成功！", ObjG.CustomMsgBox, this);
                    this.Close();
                }
                else
                    ClsMsgBox.Ts("保存失败！", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("保存遇到错误！", ex, ObjG.CustomMsgBox, this);
                return;
            }


        }
    }
}