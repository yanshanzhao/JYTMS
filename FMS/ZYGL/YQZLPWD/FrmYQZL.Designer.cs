using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.YQZLPWD
{
    partial class FrmYQZL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GrpYQZLPWD = new Gizmox.WebGUI.Forms.GroupBox();
            this.BtnEditPwd = new Gizmox.WebGUI.Forms.Button();
            this.GrpYQZLPWD.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpYQZLPWD
            // 
            this.GrpYQZLPWD.Controls.Add(this.BtnEditPwd);
            this.GrpYQZLPWD.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.GrpYQZLPWD.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpYQZLPWD.Location = new System.Drawing.Point(40, 26);
            this.GrpYQZLPWD.Name = "GrpYQZLPWD";
            this.GrpYQZLPWD.Size = new System.Drawing.Size(117, 91);
            this.GrpYQZLPWD.TabIndex = 0;
            this.GrpYQZLPWD.TabStop = false;
            this.GrpYQZLPWD.Text = "银企直连密码修改";
            // 
            // BtnEditPwd
            // 
            this.BtnEditPwd.CustomStyle = "F";
            this.BtnEditPwd.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnEditPwd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditPwd.Location = new System.Drawing.Point(22, 36);
            this.BtnEditPwd.Name = "BtnEditPwd";
            this.BtnEditPwd.Size = new System.Drawing.Size(75, 23);
            this.BtnEditPwd.TabIndex = 0;
            this.BtnEditPwd.Text = "修改密码";
            this.BtnEditPwd.Click += new System.EventHandler(this.BtnEditPwd_Click);
            // 
            // FrmYQZL
            // 
            this.Controls.Add(this.GrpYQZLPWD);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(639, 507);
            this.Text = "FrmYQZLPWD";
            this.GrpYQZLPWD.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox GrpYQZLPWD;
        private Button BtnEditPwd;


    }
}