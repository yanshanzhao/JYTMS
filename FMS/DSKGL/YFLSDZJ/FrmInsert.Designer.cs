using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.YFLSDZJ
{
    partial class FrmInsert
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
            this.TxtYjje = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.TxtFlje = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.TxtSave = new Gizmox.WebGUI.Forms.Button();
            this.TxtQx = new Gizmox.WebGUI.Forms.Button();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.TxtJgmc = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSelectWz = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtYjje
            // 
            this.TxtYjje.AllowDrag = false;
            this.TxtYjje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtYjje.Location = new System.Drawing.Point(65, 41);
            this.TxtYjje.Name = "TxtYjje";
            this.TxtYjje.Size = new System.Drawing.Size(134, 21);
            this.TxtYjje.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "押金金额";
            // 
            // TxtFlje
            // 
            this.TxtFlje.AllowDrag = false;
            this.TxtFlje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFlje.Location = new System.Drawing.Point(65, 68);
            this.TxtFlje.Name = "TxtFlje";
            this.TxtFlje.Size = new System.Drawing.Size(134, 21);
            this.TxtFlje.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "返利金额";
            // 
            // TxtSave
            // 
            this.TxtSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.TxtSave.CustomStyle = "F";
            this.TxtSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.TxtSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSave.Location = new System.Drawing.Point(11, 102);
            this.TxtSave.Name = "TxtSave";
            this.TxtSave.Size = new System.Drawing.Size(75, 23);
            this.TxtSave.TabIndex = 6;
            this.TxtSave.Text = "保存";
            this.TxtSave.Click += new System.EventHandler(this.TxtSave_Click);
            // 
            // TxtQx
            // 
            this.TxtQx.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.TxtQx.CustomStyle = "F";
            this.TxtQx.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.TxtQx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQx.Location = new System.Drawing.Point(124, 102);
            this.TxtQx.Name = "TxtQx";
            this.TxtQx.Size = new System.Drawing.Size(75, 23);
            this.TxtQx.TabIndex = 6;
            this.TxtQx.Text = "取消";
            this.TxtQx.Click += new System.EventHandler(this.TxtQx_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "机构名称";
            // 
            // TxtJgmc
            // 
            this.TxtJgmc.AllowDrag = false;
            this.TxtJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJgmc.Location = new System.Drawing.Point(65, 12);
            this.TxtJgmc.Name = "TxtJgmc";
            this.TxtJgmc.ReadOnly = true;
            this.TxtJgmc.Size = new System.Drawing.Size(134, 21);
            this.TxtJgmc.TabIndex = 0;
            // 
            // BtnSelectWz
            // 
            this.BtnSelectWz.CustomStyle = "F";
            this.BtnSelectWz.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSelectWz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSelectWz.Location = new System.Drawing.Point(202, 10);
            this.BtnSelectWz.Name = "BtnSelectWz";
            this.BtnSelectWz.Size = new System.Drawing.Size(25, 23);
            this.BtnSelectWz.TabIndex = 4;
            this.BtnSelectWz.Text = "》";
            this.BtnSelectWz.Click += new System.EventHandler(this.BtnSelectWz_Click);
            // 
            // FrmInsert
            // 
            this.Controls.Add(this.BtnSelectWz);
            this.Controls.Add(this.TxtJgmc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtQx);
            this.Controls.Add(this.TxtSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtFlje);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtYjje);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(246, 144);
            this.Text = "应付连锁店资金维护";
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox TxtYjje;
        private Label label5;
        private TextBox TxtFlje;
        private Label label6;
        private Button TxtSave;
        private Button TxtQx;
        private Label label9;
        private TextBox TxtJgmc;
        private Button BtnSelectWz;


    }
}