using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.ZJDB.SGDB
{
    partial class FrmSGDBMX
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
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.TxtZzje = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.TxtBz = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnCancell = new Gizmox.WebGUI.Forms.Button();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.TxtQrzzje = new Gizmox.WebGUI.Forms.TextBox();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.LblZCZHMC = new Gizmox.WebGUI.Forms.Label();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.LblZCYHMC = new Gizmox.WebGUI.Forms.Label();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.LblZRZHMC = new Gizmox.WebGUI.Forms.Label();
            this.LblZRYHMC = new Gizmox.WebGUI.Forms.Label();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.VzzlogTableAdapter1 = new FMS.ZYGL.ZJDB.SGDB.DSSGDBTableAdapters.VzzlogTableAdapter();
            this.CmbZRZH = new Gizmox.WebGUI.Forms.ComboBox();
            this.CmbZCZH = new Gizmox.WebGUI.Forms.ComboBox();
            this.LblZCZH = new Gizmox.WebGUI.Forms.Label();
            this.LblZRZH = new Gizmox.WebGUI.Forms.Label();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.label15 = new Gizmox.WebGUI.Forms.Label();
            this.lalzczhlx = new Gizmox.WebGUI.Forms.Label();
            this.label17 = new Gizmox.WebGUI.Forms.Label();
            this.lalzrzhlx = new Gizmox.WebGUI.Forms.Label();
            this.label19 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(301, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "转入账户";
            // 
            // TxtZzje
            // 
            this.TxtZzje.AllowDrag = false;
            this.TxtZzje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtZzje.Location = new System.Drawing.Point(85, 117);
            this.TxtZzje.MaxLength = 15;
            this.TxtZzje.Name = "TxtZzje";
            this.TxtZzje.Size = new System.Drawing.Size(187, 21);
            this.TxtZzje.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "转出账户";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "转账金额";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "备注";
            // 
            // TxtBz
            // 
            this.TxtBz.AllowDrag = false;
            this.TxtBz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBz.Location = new System.Drawing.Point(85, 144);
            this.TxtBz.MaxLength = 30;
            this.TxtBz.Name = "TxtBz";
            this.TxtBz.Size = new System.Drawing.Size(469, 21);
            this.TxtBz.TabIndex = 2;
            // 
            // BtnSave
            // 
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(347, 179);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "转账";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancell
            // 
            this.BtnCancell.CustomStyle = "F";
            this.BtnCancell.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnCancell.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancell.Location = new System.Drawing.Point(454, 179);
            this.BtnCancell.Name = "BtnCancell";
            this.BtnCancell.Size = new System.Drawing.Size(75, 23);
            this.BtnCancell.TabIndex = 3;
            this.BtnCancell.Text = "取消";
            this.BtnCancell.Click += new System.EventHandler(this.BtnCancell_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(252, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(521, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(275, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(287, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "确认转账金额";
            // 
            // TxtQrzzje
            // 
            this.TxtQrzzje.AllowDrag = false;
            this.TxtQrzzje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQrzzje.Location = new System.Drawing.Point(367, 117);
            this.TxtQrzzje.MaxLength = 15;
            this.TxtQrzzje.Name = "TxtQrzzje";
            this.TxtQrzzje.Size = new System.Drawing.Size(187, 20);
            this.TxtQrzzje.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "转出账户名称";
            // 
            // LblZCZHMC
            // 
            this.LblZCZHMC.BackColor = System.Drawing.SystemColors.Window;
            this.LblZCZHMC.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblZCZHMC.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZCZHMC.ForeColor = System.Drawing.Color.Blue;
            this.LblZCZHMC.Location = new System.Drawing.Point(85, 63);
            this.LblZCZHMC.Name = "LblZCZHMC";
            this.LblZCZHMC.Size = new System.Drawing.Size(187, 20);
            this.LblZCZHMC.TabIndex = 4;
            this.LblZCZHMC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "转出银行名称";
            // 
            // LblZCYHMC
            // 
            this.LblZCYHMC.BackColor = System.Drawing.SystemColors.Window;
            this.LblZCYHMC.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblZCYHMC.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZCYHMC.ForeColor = System.Drawing.Color.Blue;
            this.LblZCYHMC.Location = new System.Drawing.Point(85, 90);
            this.LblZCYHMC.Name = "LblZCYHMC";
            this.LblZCYHMC.Size = new System.Drawing.Size(187, 20);
            this.LblZCYHMC.TabIndex = 6;
            this.LblZCYHMC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(287, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "转入账户名称";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(287, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "转入银行名称";
            // 
            // LblZRZHMC
            // 
            this.LblZRZHMC.BackColor = System.Drawing.SystemColors.Window;
            this.LblZRZHMC.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblZRZHMC.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZRZHMC.ForeColor = System.Drawing.Color.Blue;
            this.LblZRZHMC.Location = new System.Drawing.Point(367, 63);
            this.LblZRZHMC.Name = "LblZRZHMC";
            this.LblZRZHMC.Size = new System.Drawing.Size(187, 20);
            this.LblZRZHMC.TabIndex = 3;
            this.LblZRZHMC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblZRYHMC
            // 
            this.LblZRYHMC.BackColor = System.Drawing.SystemColors.Window;
            this.LblZRYHMC.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblZRYHMC.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZRYHMC.ForeColor = System.Drawing.Color.Blue;
            this.LblZRYHMC.Location = new System.Drawing.Point(367, 90);
            this.LblZRYHMC.Name = "LblZRYHMC";
            this.LblZRYHMC.Size = new System.Drawing.Size(187, 20);
            this.LblZRYHMC.TabIndex = 5;
            this.LblZRYHMC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(557, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "*";
            // 
            // VzzlogTableAdapter1
            // 
            this.VzzlogTableAdapter1.ClearBeforeFill = true;
            // 
            // CmbZRZH
            // 
            this.CmbZRZH.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbZRZH.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbZRZH.FormattingEnabled = true;
            this.CmbZRZH.Location = new System.Drawing.Point(367, 8);
            this.CmbZRZH.Name = "CmbZRZH";
            this.CmbZRZH.Size = new System.Drawing.Size(187, 20);
            this.CmbZRZH.TabIndex = 1;
            // 
            // CmbZCZH
            // 
            this.CmbZCZH.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbZCZH.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbZCZH.FormattingEnabled = true;
            this.CmbZCZH.Location = new System.Drawing.Point(85, 8);
            this.CmbZCZH.Name = "CmbZCZH";
            this.CmbZCZH.Size = new System.Drawing.Size(187, 20);
            this.CmbZCZH.TabIndex = 0;
            // 
            // LblZCZH
            // 
            this.LblZCZH.AutoSize = true;
            this.LblZCZH.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZCZH.Location = new System.Drawing.Point(29, 12);
            this.LblZCZH.Name = "LblZCZH";
            this.LblZCZH.Size = new System.Drawing.Size(65, 12);
            this.LblZCZH.TabIndex = 0;
            this.LblZCZH.Text = "转出帐号";
            // 
            // LblZRZH
            // 
            this.LblZRZH.AutoSize = true;
            this.LblZRZH.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZRZH.Location = new System.Drawing.Point(311, 12);
            this.LblZRZH.Name = "LblZRZH";
            this.LblZRZH.Size = new System.Drawing.Size(65, 12);
            this.LblZRZH.TabIndex = 0;
            this.LblZRZH.Text = "转入帐号";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(275, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(557, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "*";
            // 
            // lalzczhlx
            // 
            this.lalzczhlx.BackColor = System.Drawing.SystemColors.Window;
            this.lalzczhlx.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.lalzczhlx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lalzczhlx.ForeColor = System.Drawing.Color.Blue;
            this.lalzczhlx.Location = new System.Drawing.Point(85, 35);
            this.lalzczhlx.Name = "lalzczhlx";
            this.lalzczhlx.Size = new System.Drawing.Size(187, 20);
            this.lalzczhlx.TabIndex = 4;
            this.lalzczhlx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(5, 39);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "转出账户类型";
            // 
            // lalzrzhlx
            // 
            this.lalzrzhlx.BackColor = System.Drawing.SystemColors.Window;
            this.lalzrzhlx.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.lalzrzhlx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lalzrzhlx.ForeColor = System.Drawing.Color.Blue;
            this.lalzrzhlx.Location = new System.Drawing.Point(367, 35);
            this.lalzrzhlx.Name = "lalzrzhlx";
            this.lalzrzhlx.Size = new System.Drawing.Size(187, 20);
            this.lalzrzhlx.TabIndex = 4;
            this.lalzrzhlx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(287, 39);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "转入账户类型";
            // 
            // FrmSGDBMX
            // 
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lalzrzhlx);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lalzczhlx);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.LblZRZH);
            this.Controls.Add(this.LblZCZH);
            this.Controls.Add(this.CmbZCZH);
            this.Controls.Add(this.CmbZRZH);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.LblZRYHMC);
            this.Controls.Add(this.LblZRZHMC);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.LblZCYHMC);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LblZCZHMC);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtQrzzje);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnCancell);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtBz);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtZzje);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(571, 225);
            this.Text = "手工调拨明细";
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private TextBox TxtZzje;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox TxtBz;
        private Button BtnSave;
        private Button BtnCancell;
        private Label label5;
        private Label label6;
        private Label label7;
        private DSSGDBTableAdapters.VzzlogTableAdapter VzzlogTableAdapter1;
        private Label label8;
        private TextBox TxtQrzzje;
        private Label label9;
        private Label LblZCZHMC;
        private Label label10;
        private Label LblZCYHMC;
        private Label label11;
        private Label label12;
        private Label LblZRZHMC;
        private Label LblZRYHMC;
        private Label label13;
        private ComboBox CmbZRZH;
        private ComboBox CmbZCZH;
        private Label LblZCZH;
        private Label LblZRZH;
        private Label label14;
        private Label label15;
        private Label lalzczhlx;
        private Label label17;
        private Label lalzrzhlx;
        private Label label19;


    }
}