using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.XTWSRLX
{
    partial class FrmXTWSRMX
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
            this.Lbl3 = new Gizmox.WebGUI.Forms.Label();
            this.TxtJe = new Gizmox.WebGUI.Forms.TextBox();
            this.lbl5 = new Gizmox.WebGUI.Forms.Label();
            this.TxtBz = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnQuXiao = new Gizmox.WebGUI.Forms.Button();
            this.CmbLx = new Gizmox.WebGUI.Forms.ComboBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.TxtGzjg = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.BtnSeleJG = new Gizmox.WebGUI.Forms.Button();
            this.Lbl2 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.TxtYwdh = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.lblSpjg = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // Lbl3
            // 
            this.Lbl3.AutoSize = true;
            this.Lbl3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl3.Location = new System.Drawing.Point(8, 38);
            this.Lbl3.Name = "Lbl3";
            this.Lbl3.Size = new System.Drawing.Size(35, 13);
            this.Lbl3.TabIndex = 0;
            this.Lbl3.Text = "申请挂账金额";
            // 
            // TxtJe
            // 
            this.TxtJe.AllowDrag = false;
            this.TxtJe.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJe.Location = new System.Drawing.Point(88, 35);
            this.TxtJe.Name = "TxtJe";
            this.TxtJe.Size = new System.Drawing.Size(117, 21);
            this.TxtJe.TabIndex = 2;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Location = new System.Drawing.Point(8, 66);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(35, 13);
            this.lbl5.TabIndex = 0;
            this.lbl5.Text = "申请项目备注";
            // 
            // TxtBz
            // 
            this.TxtBz.AllowDrag = false;
            this.TxtBz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBz.Location = new System.Drawing.Point(88, 62);
            this.TxtBz.Name = "TxtBz";
            this.TxtBz.Size = new System.Drawing.Size(398, 21);
            this.TxtBz.TabIndex = 3;
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(299, 195);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnQuXiao
            // 
            this.BtnQuXiao.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnQuXiao.CustomStyle = "F";
            this.BtnQuXiao.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQuXiao.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuXiao.Location = new System.Drawing.Point(396, 195);
            this.BtnQuXiao.Name = "BtnQuXiao";
            this.BtnQuXiao.Size = new System.Drawing.Size(75, 23);
            this.BtnQuXiao.TabIndex = 6;
            this.BtnQuXiao.Text = "取消";
            this.BtnQuXiao.Click += new System.EventHandler(this.BtnQuXiao_Click);
            // 
            // CmbLx
            // 
            this.CmbLx.AllowDrag = false;
            this.CmbLx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbLx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLx.FormattingEnabled = true;
            this.CmbLx.Location = new System.Drawing.Point(302, 9);
            this.CmbLx.Name = "CmbLx";
            this.CmbLx.Size = new System.Drawing.Size(187, 20);
            this.CmbLx.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(208, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "*";
            // 
            // TxtGzjg
            // 
            this.TxtGzjg.AllowDrag = false;
            this.TxtGzjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGzjg.Location = new System.Drawing.Point(88, 9);
            this.TxtGzjg.Name = "TxtGzjg";
            this.TxtGzjg.ReadOnly = true;
            this.TxtGzjg.Size = new System.Drawing.Size(117, 21);
            this.TxtGzjg.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "申请挂账机构";
            // 
            // BtnSeleJG
            // 
            this.BtnSeleJG.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSeleJG.CustomStyle = "F";
            this.BtnSeleJG.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSeleJG.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSeleJG.ForeColor = System.Drawing.Color.Red;
            this.BtnSeleJG.Location = new System.Drawing.Point(211, 9);
            this.BtnSeleJG.Name = "BtnSeleJG";
            this.BtnSeleJG.Size = new System.Drawing.Size(28, 20);
            this.BtnSeleJG.TabIndex = 0;
            this.BtnSeleJG.Text = "》";
            this.BtnSeleJG.Click += new System.EventHandler(this.BtnSeleJG_Click);
            // 
            // Lbl2
            // 
            this.Lbl2.AutoSize = true;
            this.Lbl2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl2.Location = new System.Drawing.Point(252, 44);
            this.Lbl2.Name = "Lbl2";
            this.Lbl2.Size = new System.Drawing.Size(35, 12);
            this.Lbl2.TabIndex = 0;
            this.Lbl2.Text = "申请类型";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "申请挂账金额";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(246, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "申请类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "业务单号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(489, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "*";
            // 
            // TxtYwdh
            // 
            this.TxtYwdh.AllowDrag = false;
            this.TxtYwdh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtYwdh.Location = new System.Drawing.Point(88, 89);
            this.TxtYwdh.MaxLength = 400;
            this.TxtYwdh.Multiline = true;
            this.TxtYwdh.Name = "TxtYwdh";
            this.TxtYwdh.Size = new System.Drawing.Size(401, 91);
            this.TxtYwdh.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(246, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "收款机构";
            // 
            // lblSpjg
            // 
            this.lblSpjg.AutoSize = true;
            this.lblSpjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpjg.ForeColor = System.Drawing.Color.Blue;
            this.lblSpjg.Location = new System.Drawing.Point(302, 38);
            this.lblSpjg.Name = "lblSpjg";
            this.lblSpjg.Size = new System.Drawing.Size(35, 13);
            this.lblSpjg.TabIndex = 8;
            // 
            // FrmXTWSRMX
            // 
            this.Controls.Add(this.lblSpjg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtYwdh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnSeleJG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtGzjg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbLx);
            this.Controls.Add(this.BtnQuXiao);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtBz);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.TxtJe);
            this.Controls.Add(this.Lbl3);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(508, 238);
            this.Text = "系统外收入";
            this.ResumeLayout(false);

        }

        #endregion

        private Label Lbl3;
        private TextBox TxtJe;
        private Label lbl5;
        private TextBox TxtBz;
        private Button BtnSave;
        private Button BtnQuXiao;
        private ComboBox CmbLx;
        private Label label1;
        private TextBox TxtGzjg;
        private Label label2;
        private Button BtnSeleJG;
        private Label Lbl2;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label3;
        private TextBox TxtYwdh;
        private Label label4;
        private Label lblSpjg;


    }
}