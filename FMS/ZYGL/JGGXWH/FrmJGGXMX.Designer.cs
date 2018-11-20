using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.JGGXWH
{
    partial class FrmJGGXMX
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
            this.BtnGxjg = new Gizmox.WebGUI.Forms.Button();
            this.BtnYjg = new Gizmox.WebGUI.Forms.Button();
            this.TxtGxjg = new Gizmox.WebGUI.Forms.TextBox();
            this.LblGxjg = new Gizmox.WebGUI.Forms.Label();
            this.TxtYjg = new Gizmox.WebGUI.Forms.TextBox();
            this.LblYjg = new Gizmox.WebGUI.Forms.Label();
            this.LblGxzl = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnCancel = new Gizmox.WebGUI.Forms.Button();
            this.CmbGxzl = new Gizmox.WebGUI.Forms.ComboBox();
            this.label7.SuspendLayout();
            this.label2.SuspendLayout();
            this.label4.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnGxjg
            // 
            this.BtnGxjg.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnGxjg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnGxjg.CustomStyle = "F";
            this.BtnGxjg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnGxjg.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnGxjg.Location = new System.Drawing.Point(509, 12);
            this.BtnGxjg.Name = "BtnGxjg";
            this.BtnGxjg.Size = new System.Drawing.Size(26, 21);
            this.BtnGxjg.TabIndex = 3;
            this.BtnGxjg.Text = "》";
            this.BtnGxjg.Click += new System.EventHandler(this.BtnGxjg_Click);
            // 
            // BtnYjg
            // 
            this.BtnYjg.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnYjg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnYjg.CustomStyle = "F";
            this.BtnYjg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnYjg.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnYjg.Location = new System.Drawing.Point(235, 12);
            this.BtnYjg.Name = "BtnYjg";
            this.BtnYjg.Size = new System.Drawing.Size(26, 21);
            this.BtnYjg.TabIndex = 1;
            this.BtnYjg.Text = "》";
            this.BtnYjg.Click += new System.EventHandler(this.BtnYjg_Click);
            // 
            // TxtGxjg
            // 
            this.TxtGxjg.AllowDrag = false;
            this.TxtGxjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGxjg.Location = new System.Drawing.Point(327, 12);
            this.TxtGxjg.Name = "TxtGxjg";
            this.TxtGxjg.ReadOnly = true;
            this.TxtGxjg.Size = new System.Drawing.Size(166, 21);
            this.TxtGxjg.TabIndex = 2;
            // 
            // LblGxjg
            // 
            this.LblGxjg.AutoSize = true;
            this.LblGxjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGxjg.Location = new System.Drawing.Point(271, 16);
            this.LblGxjg.Name = "LblGxjg";
            this.LblGxjg.Size = new System.Drawing.Size(35, 13);
            this.LblGxjg.TabIndex = 0;
            this.LblGxjg.Text = "关系机构";
            // 
            // TxtYjg
            // 
            this.TxtYjg.AllowDrag = false;
            this.TxtYjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtYjg.Location = new System.Drawing.Point(57, 12);
            this.TxtYjg.Name = "TxtYjg";
            this.TxtYjg.ReadOnly = true;
            this.TxtYjg.Size = new System.Drawing.Size(166, 21);
            this.TxtYjg.TabIndex = 0;
            // 
            // LblYjg
            // 
            this.LblYjg.AutoSize = true;
            this.LblYjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYjg.Location = new System.Drawing.Point(13, 16);
            this.LblYjg.Name = "LblYjg";
            this.LblYjg.Size = new System.Drawing.Size(35, 13);
            this.LblYjg.TabIndex = 0;
            this.LblYjg.Text = "源机构";
            // 
            // LblGxzl
            // 
            this.LblGxzl.AutoSize = true;
            this.LblGxzl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGxzl.Location = new System.Drawing.Point(4, 49);
            this.LblGxzl.Name = "LblGxzl";
            this.LblGxzl.Size = new System.Drawing.Size(35, 13);
            this.LblGxzl.TabIndex = 0;
            this.LblGxzl.Text = "关系种类";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(-12, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Controls.Add(this.label8);
            this.label7.Font = new System.Drawing.Font("宋体", 9F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(224, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(-12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Controls.Add(this.label1);
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(496, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(-12, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Controls.Add(this.label3);
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(224, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "*";
            // 
            // BtnSave
            // 
            this.BtnSave.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnSave.Location = new System.Drawing.Point(302, 78);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnCancel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnCancel.CustomStyle = "F";
            this.BtnCancel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnCancel.Location = new System.Drawing.Point(418, 78);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // CmbGxzl
            // 
            this.CmbGxzl.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbGxzl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbGxzl.FormattingEnabled = true;
            this.CmbGxzl.Location = new System.Drawing.Point(57, 45);
            this.CmbGxzl.Name = "CmbGxzl";
            this.CmbGxzl.Size = new System.Drawing.Size(166, 20);
            this.CmbGxzl.TabIndex = 4;
            // 
            // FrmJGGXMX
            // 
            this.AcceptButton = this.BtnSave;
            this.Controls.Add(this.CmbGxzl);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LblGxzl);
            this.Controls.Add(this.LblYjg);
            this.Controls.Add(this.TxtYjg);
            this.Controls.Add(this.LblGxjg);
            this.Controls.Add(this.TxtGxjg);
            this.Controls.Add(this.BtnYjg);
            this.Controls.Add(this.BtnGxjg);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(545, 114);
            this.Text = "机构关系明细";
            this.label7.ResumeLayout(false);
            this.label2.ResumeLayout(false);
            this.label4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnGxjg;
        private Button BtnYjg;
        private TextBox TxtGxjg;
        private Label LblGxjg;
        private TextBox TxtYjg;
        private Label LblYjg;
        private Label LblGxzl;
        private Label label8;
        private Label label7;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button BtnSave;
        private Button BtnCancel;
        private ComboBox CmbGxzl;


    }
}