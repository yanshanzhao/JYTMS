using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKKHFLWH
    {
    partial class FrmKHFLBJ
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
            this.label66 = new Gizmox.WebGUI.Forms.Label();
            this.lbLhh = new Gizmox.WebGUI.Forms.Label();
            this.TxtLhh = new Gizmox.WebGUI.Forms.TextBox();
            this.TxtBh = new Gizmox.WebGUI.Forms.TextBox();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.TxtMc = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnQery = new Gizmox.WebGUI.Forms.Button();
            this.BtnClose = new Gizmox.WebGUI.Forms.Button();
            this.CmbFl = new Gizmox.WebGUI.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label66.Location = new System.Drawing.Point(221, 53);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(35, 13);
            this.label66.TabIndex = 1;
            this.label66.Text = "费率";
            // 
            // lbLhh
            // 
            this.lbLhh.AutoSize = true;
            this.lbLhh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLhh.Location = new System.Drawing.Point(11, 53);
            this.lbLhh.Name = "lbLhh";
            this.lbLhh.Size = new System.Drawing.Size(35, 13);
            this.lbLhh.TabIndex = 1;
            this.lbLhh.Text = "联行号";
            // 
            // TxtLhh
            // 
            this.TxtLhh.AllowDrag = false;
            this.TxtLhh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtLhh.Location = new System.Drawing.Point(52, 50);
            this.TxtLhh.Name = "TxtLhh";
            this.TxtLhh.Size = new System.Drawing.Size(148, 21);
            this.TxtLhh.TabIndex = 2;
            // 
            // TxtBh
            // 
            this.TxtBh.AllowDrag = false;
            this.TxtBh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtBh.Location = new System.Drawing.Point(52, 15);
            this.TxtBh.Name = "TxtBh";
            this.TxtBh.ReadOnly = true;
            this.TxtBh.Size = new System.Drawing.Size(148, 21);
            this.TxtBh.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(11, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "编号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(221, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "名称";
            // 
            // TxtMc
            // 
            this.TxtMc.AllowDrag = false;
            this.TxtMc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtMc.Location = new System.Drawing.Point(253, 15);
            this.TxtMc.Name = "TxtMc";
            this.TxtMc.ReadOnly = true;
            this.TxtMc.Size = new System.Drawing.Size(148, 21);
            this.TxtMc.TabIndex = 1;
            // 
            // BtnQery
            // 
            this.BtnQery.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnQery.CustomStyle = "F";
            this.BtnQery.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQery.Location = new System.Drawing.Point(214, 83);
            this.BtnQery.Name = "BtnQery";
            this.BtnQery.Size = new System.Drawing.Size(75, 23);
            this.BtnQery.TabIndex = 4;
            this.BtnQery.Text = "保存";
            this.BtnQery.Click += new System.EventHandler(this.BtnQery_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnClose.CustomStyle = "F";
            this.BtnClose.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Location = new System.Drawing.Point(317, 83);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 5;
            this.BtnClose.Text = "取消";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // CmbFl
            // 
            this.CmbFl.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbFl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFl.FormattingEnabled = true;
            this.CmbFl.Location = new System.Drawing.Point(253, 50);
            this.CmbFl.Name = "CmbFl";
            this.CmbFl.Size = new System.Drawing.Size(148, 20);
            this.CmbFl.TabIndex = 3;
            // 
            // FrmKHFLBJ
            // 
            this.AcceptButton = this.BtnQery;
            this.Controls.Add(this.CmbFl);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnQery);
            this.Controls.Add(this.TxtMc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtBh);
            this.Controls.Add(this.TxtLhh);
            this.Controls.Add(this.lbLhh);
            this.Controls.Add(this.label66);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(415, 114);
            this.Text = "客户费率修改";
            this.ResumeLayout(false);

            }

        #endregion

        private Label label66;
        private Label lbLhh;
        private TextBox TxtLhh;
        private TextBox TxtBh;
        private Label label9;
        private Label label1;
        private TextBox TxtMc;
        private Button BtnQery;
        private Button BtnClose;
        private ComboBox CmbFl;


        }
    }