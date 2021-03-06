using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.JCSJ.DQXX
{
    partial class FrmDQXXMX
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
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.TxtBZ = new Gizmox.WebGUI.Forms.TextBox();
            this.LblYdbh = new Gizmox.WebGUI.Forms.Label();
            this.TxtFL = new Gizmox.WebGUI.Forms.TextBox();
            this.LblFL = new Gizmox.WebGUI.Forms.Label();
            this.BtnCancel = new Gizmox.WebGUI.Forms.Button();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.TxtSxfsx = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Controls.Add(this.label6);
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(200, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(-12, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "*";
            // 
            // TxtBZ
            // 
            this.TxtBZ.AllowDrag = false;
            this.TxtBZ.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Upper;
            this.TxtBZ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBZ.Location = new System.Drawing.Point(260, 12);
            this.TxtBZ.MaxLength = 18;
            this.TxtBZ.Name = "TxtBZ";
            this.TxtBZ.Size = new System.Drawing.Size(151, 21);
            this.TxtBZ.TabIndex = 4;
            // 
            // LblYdbh
            // 
            this.LblYdbh.AutoSize = true;
            this.LblYdbh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYdbh.Location = new System.Drawing.Point(222, 15);
            this.LblYdbh.Name = "LblYdbh";
            this.LblYdbh.Size = new System.Drawing.Size(41, 13);
            this.LblYdbh.TabIndex = 40;
            this.LblYdbh.Text = "说明";
            // 
            // TxtFL
            // 
            this.TxtFL.AllowDrag = false;
            this.TxtFL.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFL.Location = new System.Drawing.Point(46, 12);
            this.TxtFL.Name = "TxtFL";
            this.TxtFL.Size = new System.Drawing.Size(151, 21);
            this.TxtFL.TabIndex = 0;
            this.TxtFL.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // LblFL
            // 
            this.LblFL.AutoSize = true;
            this.LblFL.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFL.Location = new System.Drawing.Point(14, 15);
            this.LblFL.Name = "LblFL";
            this.LblFL.Size = new System.Drawing.Size(59, 12);
            this.LblFL.TabIndex = 0;
            this.LblFL.Text = "名称";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnCancel.CustomStyle = "F";
            this.BtnCancel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.Location = new System.Drawing.Point(362, 107);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(86, 23);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(244, 107);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(86, 23);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "编号";
            // 
            // TxtSxfsx
            // 
            this.TxtSxfsx.AllowDrag = false;
            this.TxtSxfsx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSxfsx.Location = new System.Drawing.Point(46, 49);
            this.TxtSxfsx.Name = "TxtSxfsx";
            this.TxtSxfsx.Size = new System.Drawing.Size(151, 21);
            this.TxtSxfsx.TabIndex = 2;
            this.TxtSxfsx.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(200, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "*";
            // 
            // FrmDQXXMX
            // 
            this.AcceptButton = this.BtnSave;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtSxfsx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.LblFL);
            this.Controls.Add(this.TxtFL);
            this.Controls.Add(this.LblYdbh);
            this.Controls.Add(this.TxtBZ);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(477, 144);
            this.Text = "代收款手续费费率";
            this.label8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label8;
        private TextBox TxtBZ;
        private Label LblYdbh;
        private TextBox TxtFL;
        private Label LblFL;
        private Button BtnCancel;
        private Button BtnSave;
        private Label label1;
        private TextBox TxtSxfsx;
        private Label label2;
        private Label label6;


    }
}