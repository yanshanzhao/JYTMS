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

namespace FMS.ZYGL.YQZLPWD
    {
    public partial class FrmYQZLPWD : Form
        {
        private ClsG ObjG;
        private string priConStr;
        private DSJGGL.vrenyuanRow PriCurRow;
        public FrmYQZLPWD()
            {
            InitializeComponent();
            }
        public void Prepare()
            {
            ObjG = (ClsG)VWGContext.Current.Session["objG"];
            priConStr = ClsGlobals.CntStrKj;
            VrenyuanTableAdapter1.FillByRyId(DSJGGL.vrenyuan, ObjG.Renyuan.id);
            txtOldPass.MaxLength = ClsOptions.WebCfg.MaxPasswordLen;
            txtNewPass.MaxLength = ClsOptions.WebCfg.MaxPasswordLen;
            txtNewPass2.MaxLength = ClsOptions.WebCfg.MaxPasswordLen;
            lblLoginName.Text = string.Format("�˻�: {0}", ObjG.Renyuan.loginName);
            PriCurRow = ((DataRowView)Bds.Current).Row as DSJGGL.vrenyuanRow;
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
            if (!PriCurRow.IsyqzlpwdNull() && string.IsNullOrEmpty(txtOldPass.Text))
                {
                ClsMsgBox.Ts("ԭ���벻��Ϊ�գ�", this, txtOldPass, ObjG.CustomMsgBox);
                return;
                }
            //Check Old Password
            string sOldPass = txtOldPass.Text.Trim();
            txtOldPass.Text = sOldPass;
            if (!PriCurRow.IsyqzlpwdNull() && sOldPass.Length < ClsOptions.WebCfg.MinPasswordLen)
                {
                ClsMsgBox.Cw(string.Format("ԭ���볤��Ϊ�����{0}!", ClsOptions.WebCfg.MinPasswordLen));
                return;
                }
            else if (!PriCurRow.IsyqzlpwdNull() && PriCurRow.yqzlpwd.CompareTo(hcdMD5.getMD5Str(sOldPass, ObjG.Renyuan.loginName)) != 0)
                {
                ClsMsgBox.Ts("ԭ���벻��ȷ!", this, txtOldPass, ObjG.CustomMsgBox);
                return;
                }
            //Check New Password
            string sNewPass = txtNewPass.Text.Trim();
            txtNewPass.Text = sNewPass;
            if (sNewPass.Length < ClsOptions.WebCfg.MinPasswordLen)
                {
                ClsMsgBox.Cw(string.Format("������Ϊ�ջ򳤶Ȳ���{0}!", ClsOptions.WebCfg.MinPasswordLen));
                return;
                }
            if (PriCurRow.password.CompareTo(hcdMD5.getMD5Str(sNewPass, ObjG.Renyuan.loginName)) == 0)
                {
                ClsMsgBox.Ts("�����벻�����¼������ͬ��", this, txtNewPass, ObjG.CustomMsgBox);
                return;
                }
            if (ClsRegEx.IsPwdNumber(txtNewPass.Text.Trim()))
                {
                ClsMsgBox.Ts("���벻��ȫΪ���֣�", this, txtNewPass, ObjG.CustomMsgBox);
                return;
                }
            if (ClsRegEx.IsPwdLetter(txtNewPass.Text.Trim()))
                {
                ClsMsgBox.Ts("���벻��ȫΪ��ĸ��", this, txtNewPass, ObjG.CustomMsgBox);
                return;
                }
            if (ClsRegEx.IsPwdChar(txtNewPass.Text.Trim()))
                {
                ClsMsgBox.Ts("���벻��ȫΪ�ַ���", this, txtNewPass, ObjG.CustomMsgBox);
                return;
                }
            if (sNewPass != txtNewPass2.Text.Trim())
                {
                ClsMsgBox.Ts("�������������벻һ��!", this, txtNewPass2, ObjG.CustomMsgBox);
                return;
                }
            if (sNewPass == sOldPass)
                {
                ClsMsgBox.Ts("��������ԭ������ͬ!", this, txtNewPass2, ObjG.CustomMsgBox);
                return;
                }
            string newPassword = hcdMD5.getMD5Str(sNewPass, ObjG.Renyuan.loginName);
            PriCurRow.yqzlpwd = newPassword;

            try
                {
                Bds.EndEdit();
                int count = VrenyuanTableAdapter1.Update(PriCurRow);
                ObjG.Renyuan.yqzlpwd = newPassword;
                }
            catch (Exception ex)
                {
                ClsMsgBox.Cw("������������", ex, ObjG.CustomMsgBox, this);
                return;
                }
            this.Close();
            ClsMsgBox.Ts("����ɹ���", ObjG.CustomMsgBox, this);
            }
        }
    }