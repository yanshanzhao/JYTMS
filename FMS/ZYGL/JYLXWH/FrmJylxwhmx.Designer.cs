using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.JYLXWH
{
    partial class FrmJylxwhmx
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
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnCancel = new Gizmox.WebGUI.Forms.Button();
            this.TxtAcitve = new Gizmox.WebGUI.Forms.CheckBox();
            this.lbljymc = new Gizmox.WebGUI.Forms.Label();
            this.TxtjyMc = new Gizmox.WebGUI.Forms.TextBox();
            this.Txtjybh = new Gizmox.WebGUI.Forms.TextBox();
            this.Lbljybh = new Gizmox.WebGUI.Forms.Label();
            this.lbljylx = new Gizmox.WebGUI.Forms.Label();
            this.cmbjylx = new Gizmox.WebGUI.Forms.ComboBox();
            this.DSJYLXWH1 = new FMS.ZYGL.JYLXWH.DSJYLXWH();
            this.TjylxTableAdapter1 = new FMS.ZYGL.JYLXWH.DSJYLXWHTableAdapters.tjylxTableAdapter();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.TxtSort = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DSJYLXWH1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(182, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "*";
            // 
            // BtnSave
            // 
            this.BtnSave.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnSave.Location = new System.Drawing.Point(96, 93);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 6;
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
            this.BtnCancel.Location = new System.Drawing.Point(269, 93);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TxtAcitve
            // 
            this.TxtAcitve.AutoSize = true;
            this.TxtAcitve.Checked = true;
            this.TxtAcitve.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.TxtAcitve.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAcitve.Location = new System.Drawing.Point(199, 82);
            this.TxtAcitve.Name = "TxtAcitve";
            this.TxtAcitve.Size = new System.Drawing.Size(48, 16);
            this.TxtAcitve.TabIndex = 5;
            this.TxtAcitve.Text = "有效";
            // 
            // lbljymc
            // 
            this.lbljymc.AutoSize = true;
            this.lbljymc.Font = new System.Drawing.Font("宋体", 9F);
            this.lbljymc.Location = new System.Drawing.Point(208, 17);
            this.lbljymc.Name = "lbljymc";
            this.lbljymc.Size = new System.Drawing.Size(53, 12);
            this.lbljymc.TabIndex = 0;
            this.lbljymc.Text = "交易名称";
            // 
            // TxtjyMc
            // 
            this.TxtjyMc.AllowDrag = false;
            this.TxtjyMc.Font = new System.Drawing.Font("宋体", 9F);
            this.TxtjyMc.ForeColor = System.Drawing.Color.Black;
            this.TxtjyMc.Location = new System.Drawing.Point(264, 12);
            this.TxtjyMc.MaxLength = 28;
            this.TxtjyMc.Name = "TxtjyMc";
            this.TxtjyMc.Size = new System.Drawing.Size(121, 21);
            this.TxtjyMc.TabIndex = 2;
            // 
            // Txtjybh
            // 
            this.Txtjybh.AllowDrag = false;
            this.Txtjybh.Font = new System.Drawing.Font("宋体", 9F);
            this.Txtjybh.ForeColor = System.Drawing.Color.Black;
            this.Txtjybh.Location = new System.Drawing.Point(60, 12);
            this.Txtjybh.MaxLength = 8;
            this.Txtjybh.Name = "Txtjybh";
            this.Txtjybh.Size = new System.Drawing.Size(121, 21);
            this.Txtjybh.TabIndex = 1;
            // 
            // Lbljybh
            // 
            this.Lbljybh.AutoSize = true;
            this.Lbljybh.Font = new System.Drawing.Font("宋体", 9F);
            this.Lbljybh.Location = new System.Drawing.Point(9, 17);
            this.Lbljybh.Name = "Lbljybh";
            this.Lbljybh.Size = new System.Drawing.Size(35, 13);
            this.Lbljybh.TabIndex = 0;
            this.Lbljybh.Text = "交易编号";
            // 
            // lbljylx
            // 
            this.lbljylx.AutoSize = true;
            this.lbljylx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbljylx.Location = new System.Drawing.Point(9, 58);
            this.lbljylx.Name = "lbljylx";
            this.lbljylx.Size = new System.Drawing.Size(35, 13);
            this.lbljylx.TabIndex = 7;
            this.lbljylx.Text = "交易类型";
            // 
            // cmbjylx
            // 
            this.cmbjylx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbjylx.FormattingEnabled = true;
            this.cmbjylx.Items.AddRange(new object[] {
            "代收款"});
            this.cmbjylx.Location = new System.Drawing.Point(60, 54);
            this.cmbjylx.Name = "cmbjylx";
            this.cmbjylx.Size = new System.Drawing.Size(121, 20);
            this.cmbjylx.TabIndex = 3;
            // 
            // DSJYLXWH1
            // 
            this.DSJYLXWH1.DataSetName = "DSJYLXWH";
            this.DSJYLXWH1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TjylxTableAdapter1
            // 
            this.TjylxTableAdapter1.ClearBeforeFill = true;
            // 
            // Bds
            // 
            this.Bds.DataSource = this.DSJYLXWH1;
            this.Bds.Position = 0;
            // 
            // TxtSort
            // 
            this.TxtSort.AllowDrag = false;
            this.TxtSort.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSort.Location = new System.Drawing.Point(264, 54);
            this.TxtSort.Name = "TxtSort";
            this.TxtSort.ReadOnly = true;
            this.TxtSort.Size = new System.Drawing.Size(121, 21);
            this.TxtSort.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(232, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "排序";
            // 
            // FrmJylxwhmx
            // 
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtSort);
            this.Controls.Add(this.cmbjylx);
            this.Controls.Add(this.lbljylx);
            this.Controls.Add(this.Lbljybh);
            this.Controls.Add(this.Txtjybh);
            this.Controls.Add(this.TxtjyMc);
            this.Controls.Add(this.lbljymc);
            this.Controls.Add(this.TxtAcitve);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(428, 138);
            this.Text = "交易类型明细";
            ((System.ComponentModel.ISupportInitialize)(this.DSJYLXWH1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label2;
        private Button BtnSave;
        private Button BtnCancel;
        private CheckBox TxtAcitve;
        private Label lbljymc;
        private TextBox TxtjyMc;
        private TextBox Txtjybh;
        private Label Lbljybh;
        private Label lbljylx;
        private ComboBox cmbjylx;
        private DSJYLXWH DSJYLXWH1;
        private DSJYLXWHTableAdapters.tjylxTableAdapter TjylxTableAdapter1;
        private BindingSource Bds;
        private TextBox TxtSort;
        private Label label3;


    }
}