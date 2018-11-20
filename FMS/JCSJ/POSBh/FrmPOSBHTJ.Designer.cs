using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.JCSJ.POSBh
{
    partial class FrmPOSBHTJ
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
            this.labjg = new Gizmox.WebGUI.Forms.Label();
            this.labpos = new Gizmox.WebGUI.Forms.Label();
            this.Labzt = new Gizmox.WebGUI.Forms.Label();
            this.Txtjg = new Gizmox.WebGUI.Forms.TextBox();
            this.Txtpos = new Gizmox.WebGUI.Forms.TextBox();
            this.cmbzt = new Gizmox.WebGUI.Forms.ComboBox();
            this.Labyhlx = new Gizmox.WebGUI.Forms.Label();
            this.BtnAdd = new Gizmox.WebGUI.Forms.Button();
            this.Btnqx = new Gizmox.WebGUI.Forms.Button();
            this.cmbyhlx = new Gizmox.WebGUI.Forms.ComboBox();
            this.Btnjg = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // labjg
            // 
            this.labjg.AutoSize = true;
            this.labjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labjg.Location = new System.Drawing.Point(9, 27);
            this.labjg.Name = "labjg";
            this.labjg.Size = new System.Drawing.Size(35, 13);
            this.labjg.TabIndex = 0;
            this.labjg.Text = "选择机构";
            // 
            // labpos
            // 
            this.labpos.AutoSize = true;
            this.labpos.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labpos.Location = new System.Drawing.Point(229, 27);
            this.labpos.Name = "labpos";
            this.labpos.Size = new System.Drawing.Size(35, 13);
            this.labpos.TabIndex = 1;
            this.labpos.Text = "POS编码";
            // 
            // Labzt
            // 
            this.Labzt.AutoSize = true;
            this.Labzt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Labzt.Location = new System.Drawing.Point(229, 63);
            this.Labzt.Name = "Labzt";
            this.Labzt.Size = new System.Drawing.Size(35, 13);
            this.Labzt.TabIndex = 2;
            this.Labzt.Text = "状态";
            // 
            // Txtjg
            // 
            this.Txtjg.AllowDrag = false;
            this.Txtjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtjg.Location = new System.Drawing.Point(82, 18);
            this.Txtjg.Name = "Txtjg";
            this.Txtjg.Size = new System.Drawing.Size(100, 21);
            this.Txtjg.TabIndex = 3;
            // 
            // Txtpos
            // 
            this.Txtpos.AllowDrag = false;
            this.Txtpos.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtpos.Location = new System.Drawing.Point(294, 18);
            this.Txtpos.Name = "Txtpos";
            this.Txtpos.Size = new System.Drawing.Size(100, 21);
            this.Txtpos.TabIndex = 5;
            // 
            // cmbzt
            // 
            this.cmbzt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbzt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbzt.FormattingEnabled = true;
            this.cmbzt.Items.AddRange(new object[] {
            "可用",
            "不可用",
            "作废"});
            this.cmbzt.Location = new System.Drawing.Point(294, 55);
            this.cmbzt.Name = "cmbzt";
            this.cmbzt.Size = new System.Drawing.Size(100, 20);
            this.cmbzt.TabIndex = 6;
            // 
            // Labyhlx
            // 
            this.Labyhlx.AutoSize = true;
            this.Labyhlx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Labyhlx.Location = new System.Drawing.Point(9, 58);
            this.Labyhlx.Name = "Labyhlx";
            this.Labyhlx.Size = new System.Drawing.Size(35, 13);
            this.Labyhlx.TabIndex = 7;
            this.Labyhlx.Text = "银行类型";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnAdd.CustomStyle = "F";
            this.BtnAdd.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.Location = new System.Drawing.Point(231, 103);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 9;
            this.BtnAdd.Text = "保存";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // Btnqx
            // 
            this.Btnqx.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Btnqx.CustomStyle = "F";
            this.Btnqx.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.Btnqx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnqx.Location = new System.Drawing.Point(319, 103);
            this.Btnqx.Name = "Btnqx";
            this.Btnqx.Size = new System.Drawing.Size(75, 23);
            this.Btnqx.TabIndex = 10;
            this.Btnqx.Text = "取消";
            this.Btnqx.Click += new System.EventHandler(this.Btnqx_Click);
            // 
            // cmbyhlx
            // 
            this.cmbyhlx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbyhlx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbyhlx.FormattingEnabled = true;
            this.cmbyhlx.Location = new System.Drawing.Point(82, 54);
            this.cmbyhlx.Name = "cmbyhlx";
            this.cmbyhlx.Size = new System.Drawing.Size(100, 20);
            this.cmbyhlx.TabIndex = 11;
            // 
            // Btnjg
            // 
            this.Btnjg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Btnjg.CustomStyle = "F";
            this.Btnjg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.Btnjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnjg.Location = new System.Drawing.Point(185, 18);
            this.Btnjg.Name = "Btnjg";
            this.Btnjg.Size = new System.Drawing.Size(33, 23);
            this.Btnjg.TabIndex = 12;
            this.Btnjg.Text = ">>";
            this.Btnjg.Click += new System.EventHandler(this.Btnjg_Click);
            // 
            // FrmPOSBHTJ
            // 
            this.Controls.Add(this.Btnjg);
            this.Controls.Add(this.cmbyhlx);
            this.Controls.Add(this.Btnqx);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.Labyhlx);
            this.Controls.Add(this.cmbzt);
            this.Controls.Add(this.Txtpos);
            this.Controls.Add(this.Txtjg);
            this.Controls.Add(this.Labzt);
            this.Controls.Add(this.labpos);
            this.Controls.Add(this.labjg);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(414, 139);
            this.Text = "新增Pos编号";
            this.ResumeLayout(false);

        }

        #endregion

        private Label labjg;
        private Label labpos;
        private Label Labzt;
        private TextBox Txtjg;
        private TextBox Txtpos;
        private ComboBox cmbzt;
        private Label Labyhlx;
        private Button BtnAdd;
        private Button Btnqx;
        private ComboBox cmbyhlx;
        private Button Btnjg;


    }
}