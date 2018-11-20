using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.YQZLPWD
{
    partial class FrmYQZLPWD
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.lblLoginName = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.txtOldPass = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNewPass = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNewPass2 = new Gizmox.WebGUI.Forms.TextBox();
            this.btnClear = new Gizmox.WebGUI.Forms.Button();
            this.btnSave = new Gizmox.WebGUI.Forms.Button();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSJGGL = new DSJGGL();
            this.VrenyuanTableAdapter1 = new DSJGGLTableAdapters.vrenyuanTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSJGGL)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(213, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(213, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(213, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "*";
            // 
            // lblLoginName
            // 
            this.lblLoginName.AutoSize = true;
            this.lblLoginName.Font = new System.Drawing.Font("宋体", 9F);
            this.lblLoginName.ForeColor = System.Drawing.Color.Blue;
            this.lblLoginName.Location = new System.Drawing.Point(36, 8);
            this.lblLoginName.Name = "lblLoginName";
            this.lblLoginName.Size = new System.Drawing.Size(57, 14);
            this.lblLoginName.TabIndex = 0;
            this.lblLoginName.Text = "账户：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(24, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "原密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(24, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "新密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "确认密码：";
            // 
            // txtOldPass
            // 
            this.txtOldPass.AllowDrag = false;
            this.txtOldPass.Font = new System.Drawing.Font("宋体", 9F);
            this.txtOldPass.Location = new System.Drawing.Point(75, 36);
            this.txtOldPass.MaxLength = 20;
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PasswordChar = '*';
            this.txtOldPass.Size = new System.Drawing.Size(135, 21);
            this.txtOldPass.TabIndex = 6;
            // 
            // txtNewPass
            // 
            this.txtNewPass.AllowDrag = false;
            this.txtNewPass.Font = new System.Drawing.Font("宋体", 9F);
            this.txtNewPass.Location = new System.Drawing.Point(75, 66);
            this.txtNewPass.MaxLength = 20;
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(135, 21);
            this.txtNewPass.TabIndex = 7;
            // 
            // txtNewPass2
            // 
            this.txtNewPass2.AllowDrag = false;
            this.txtNewPass2.Font = new System.Drawing.Font("宋体", 9F);
            this.txtNewPass2.Location = new System.Drawing.Point(75, 98);
            this.txtNewPass2.MaxLength = 20;
            this.txtNewPass2.Name = "txtNewPass2";
            this.txtNewPass2.PasswordChar = '*';
            this.txtNewPass2.Size = new System.Drawing.Size(135, 21);
            this.txtNewPass2.TabIndex = 8;
            // 
            // btnClear
            // 
            this.btnClear.CustomStyle = "F";
            this.btnClear.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("宋体", 9F);
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(244, 39);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "清除";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.CustomStyle = "F";
            this.btnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(244, 96);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Bds
            // 
            this.Bds.DataMember = "vrenyuan";
            this.Bds.DataSource = this.DSJGGL;
            // 
            // DSJGGL
            // 
            this.DSJGGL.DataSetName = "DSJGGL";
            this.DSJGGL.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VrenyuanTableAdapter1
            // 
            this.VrenyuanTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmYQZLPWD
            // 
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtNewPass2);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLoginName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(328, 142);
            this.Text = "银企直连密码修改";
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSJGGL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label11;
        private Label label10;
        private Label label5;
        private Label lblLoginName;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtOldPass;
        private TextBox txtNewPass;
        private TextBox txtNewPass2;
        private Button btnClear;
        private Button btnSave;
        private BindingSource Bds;
        private DSJGGL DSJGGL;
        private DSJGGLTableAdapters.vrenyuanTableAdapter VrenyuanTableAdapter1;


    }
}