using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.XTWSR
{
    partial class FrmXTWSRSPMX
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
            this.TxtLsh = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.Lbl3 = new Gizmox.WebGUI.Forms.Label();
            this.TxtJe = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnQuXiao = new Gizmox.WebGUI.Forms.Button();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.TxtBz = new Gizmox.WebGUI.Forms.TextBox();
            this.lbl5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.CmbShbz = new Gizmox.WebGUI.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TxtLsh
            // 
            this.TxtLsh.AllowDrag = false;
            this.TxtLsh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLsh.Location = new System.Drawing.Point(93, 11);
            this.TxtLsh.Name = "TxtLsh";
            this.TxtLsh.ReadOnly = true;
            this.TxtLsh.Size = new System.Drawing.Size(375, 21);
            this.TxtLsh.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "收入流水号";
            // 
            // Lbl3
            // 
            this.Lbl3.AutoSize = true;
            this.Lbl3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl3.Location = new System.Drawing.Point(13, 41);
            this.Lbl3.Name = "Lbl3";
            this.Lbl3.Size = new System.Drawing.Size(35, 13);
            this.Lbl3.TabIndex = 0;
            this.Lbl3.Text = "申请挂账金额";
            // 
            // TxtJe
            // 
            this.TxtJe.AllowDrag = false;
            this.TxtJe.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJe.Location = new System.Drawing.Point(93, 39);
            this.TxtJe.Name = "TxtJe";
            this.TxtJe.ReadOnly = true;
            this.TxtJe.Size = new System.Drawing.Size(375, 21);
            this.TxtJe.TabIndex = 2;
            // 
            // BtnQuXiao
            // 
            this.BtnQuXiao.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnQuXiao.CustomStyle = "F";
            this.BtnQuXiao.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQuXiao.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuXiao.Location = new System.Drawing.Point(433, 116);
            this.BtnQuXiao.Name = "BtnQuXiao";
            this.BtnQuXiao.Size = new System.Drawing.Size(75, 23);
            this.BtnQuXiao.TabIndex = 6;
            this.BtnQuXiao.Text = "取消";
            this.BtnQuXiao.Click += new System.EventHandler(this.BtnQuXiao_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(336, 116);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtBz
            // 
            this.TxtBz.AllowDrag = false;
            this.TxtBz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBz.Location = new System.Drawing.Point(93, 72);
            this.TxtBz.Name = "TxtBz";
            this.TxtBz.ReadOnly = true;
            this.TxtBz.Size = new System.Drawing.Size(375, 21);
            this.TxtBz.TabIndex = 4;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Location = new System.Drawing.Point(13, 76);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(35, 13);
            this.lbl5.TabIndex = 0;
            this.lbl5.Text = "申请项目备注";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "审核标志";
            // 
            // CmbShbz
            // 
            this.CmbShbz.AllowDrag = false;
            this.CmbShbz.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbShbz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbShbz.FormattingEnabled = true;
            this.CmbShbz.Items.AddRange(new object[] {
            "审核通过",
            "审核不通过"});
            this.CmbShbz.Location = new System.Drawing.Point(90, 104);
            this.CmbShbz.Name = "CmbShbz";
            this.CmbShbz.Size = new System.Drawing.Size(187, 20);
            this.CmbShbz.TabIndex = 1;
            // 
            // FrmXTWSRSPMX
            // 
            this.Controls.Add(this.CmbShbz);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.TxtBz);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnQuXiao);
            this.Controls.Add(this.TxtJe);
            this.Controls.Add(this.Lbl3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtLsh);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(523, 150);
            this.Text = "审批明细";
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox TxtLsh;
        private Label label5;
        private Label Lbl3;
        private TextBox TxtJe;
        private Button BtnQuXiao;
        private Button BtnSave;
        private TextBox TxtBz;
        private Label lbl5;
        private Label label6;
        private ComboBox CmbShbz;


    }
}
