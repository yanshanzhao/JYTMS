using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.JCSJ.ZHLXGL
{
    partial class FrmNewZhlx
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
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.TxtMc = new Gizmox.WebGUI.Forms.TextBox();
            this.TxtMs = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnClose = new Gizmox.WebGUI.Forms.Button();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "描述";
            // 
            // TxtMc
            // 
            this.TxtMc.AllowDrag = false;
            this.TxtMc.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Upper;
            this.TxtMc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMc.Location = new System.Drawing.Point(52, 12);
            this.TxtMc.MaxLength = 30;
            this.TxtMc.Name = "TxtMc";
            this.TxtMc.Size = new System.Drawing.Size(246, 21);
            this.TxtMc.TabIndex = 0;
            // 
            // TxtMs
            // 
            this.TxtMs.AllowDrag = false;
            this.TxtMs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMs.Location = new System.Drawing.Point(52, 43);
            this.TxtMs.MaxLength = 50;
            this.TxtMs.Multiline = true;
            this.TxtMs.Name = "TxtMs";
            this.TxtMs.Size = new System.Drawing.Size(246, 61);
            this.TxtMs.TabIndex = 1;
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(130, 117);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnClose.CustomStyle = "F";
            this.BtnClose.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Location = new System.Drawing.Point(236, 116);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 3;
            this.BtnClose.Text = "关闭";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(300, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "*";
            // 
            // FrmNewZhlx
            // 
            this.AcceptButton = this.BtnSave;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtMs);
            this.Controls.Add(this.TxtMc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(334, 153);
            this.Text = "新增账户类型";
            this.ResumeLayout(false);

        }

        #endregion

        private Label label2;
        private Label label3;
        private TextBox TxtMc;
        private TextBox TxtMs;
        private Button BtnSave;
        private Button BtnClose;
        private Label label5;


    }
}