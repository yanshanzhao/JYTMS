using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.XTWSP
{
    partial class FrmXTSRSPMX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.BtnSPgb = new Gizmox.WebGUI.Forms.Button();
            this.BtnSPBtg = new Gizmox.WebGUI.Forms.Button();
            this.BtnSPtg = new Gizmox.WebGUI.Forms.Button();
            this.Txtbz = new Gizmox.WebGUI.Forms.TextBox();
            this.Txtr = new Gizmox.WebGUI.Forms.TextBox();
            this.Txtje = new Gizmox.WebGUI.Forms.TextBox();
            this.Txtlx = new Gizmox.WebGUI.Forms.TextBox();
            this.Txtbh = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtBh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJe = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSSP1 = new FMS.CWGL.XTWSP.DSSP();
            this.TfmsxtwsrmxTableAdapter1 = new FMS.CWGL.XTWSP.DSSPTableAdapters.tfmsxtwsrmxTableAdapter();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSSP1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnSPgb);
            this.PnlTop.Controls.Add(this.BtnSPBtg);
            this.PnlTop.Controls.Add(this.BtnSPtg);
            this.PnlTop.Controls.Add(this.Txtbz);
            this.PnlTop.Controls.Add(this.Txtr);
            this.PnlTop.Controls.Add(this.Txtje);
            this.PnlTop.Controls.Add(this.Txtlx);
            this.PnlTop.Controls.Add(this.Txtbh);
            this.PnlTop.Controls.Add(this.label5);
            this.PnlTop.Controls.Add(this.label4);
            this.PnlTop.Controls.Add(this.label3);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(604, 119);
            this.PnlTop.TabIndex = 0;
            // 
            // BtnSPgb
            // 
            this.BtnSPgb.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSPgb.CustomStyle = "F";
            this.BtnSPgb.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSPgb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSPgb.Location = new System.Drawing.Point(440, 88);
            this.BtnSPgb.Name = "BtnSPgb";
            this.BtnSPgb.Size = new System.Drawing.Size(75, 23);
            this.BtnSPgb.TabIndex = 12;
            this.BtnSPgb.Text = "关闭";
            this.BtnSPgb.Click += new System.EventHandler(this.BtnSPgb_Click);
            // 
            // BtnSPBtg
            // 
            this.BtnSPBtg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSPBtg.CustomStyle = "F";
            this.BtnSPBtg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSPBtg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSPBtg.Location = new System.Drawing.Point(359, 88);
            this.BtnSPBtg.Name = "BtnSPBtg";
            this.BtnSPBtg.Size = new System.Drawing.Size(75, 23);
            this.BtnSPBtg.TabIndex = 11;
            this.BtnSPBtg.Text = "审批不通过";
            this.BtnSPBtg.Click += new System.EventHandler(this.BtnSPBtg_Click);
            // 
            // BtnSPtg
            // 
            this.BtnSPtg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSPtg.CustomStyle = "F";
            this.BtnSPtg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSPtg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSPtg.Location = new System.Drawing.Point(278, 88);
            this.BtnSPtg.Name = "BtnSPtg";
            this.BtnSPtg.Size = new System.Drawing.Size(75, 23);
            this.BtnSPtg.TabIndex = 10;
            this.BtnSPtg.Text = "审批通过";
            this.BtnSPtg.Click += new System.EventHandler(this.BtnSPtg_Click);
            // 
            // Txtbz
            // 
            this.Txtbz.AllowDrag = false;
            this.Txtbz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtbz.Location = new System.Drawing.Point(95, 64);
            this.Txtbz.Name = "Txtbz";
            this.Txtbz.ReadOnly = true;
            this.Txtbz.Size = new System.Drawing.Size(292, 21);
            this.Txtbz.TabIndex = 9;
            // 
            // Txtr
            // 
            this.Txtr.AllowDrag = false;
            this.Txtr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtr.Location = new System.Drawing.Point(335, 35);
            this.Txtr.Name = "Txtr";
            this.Txtr.ReadOnly = true;
            this.Txtr.Size = new System.Drawing.Size(152, 21);
            this.Txtr.TabIndex = 8;
            // 
            // Txtje
            // 
            this.Txtje.AllowDrag = false;
            this.Txtje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtje.Location = new System.Drawing.Point(95, 35);
            this.Txtje.Name = "Txtje";
            this.Txtje.ReadOnly = true;
            this.Txtje.Size = new System.Drawing.Size(143, 21);
            this.Txtje.TabIndex = 7;
            // 
            // Txtlx
            // 
            this.Txtlx.AllowDrag = false;
            this.Txtlx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtlx.Location = new System.Drawing.Point(335, 9);
            this.Txtlx.Name = "Txtlx";
            this.Txtlx.ReadOnly = true;
            this.Txtlx.Size = new System.Drawing.Size(152, 21);
            this.Txtlx.TabIndex = 6;
            // 
            // Txtbh
            // 
            this.Txtbh.AllowDrag = false;
            this.Txtbh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtbh.Location = new System.Drawing.Point(95, 9);
            this.Txtbh.Name = "Txtbh";
            this.Txtbh.ReadOnly = true;
            this.Txtbh.Size = new System.Drawing.Size(143, 21);
            this.Txtbh.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "申请备注";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(291, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "申请人";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "申请金额";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(279, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "申请类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "系统外收入编号";
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowDragTargetsPropagation = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.AutoGenerateColumns = false;
            this.Dgv.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.Dgv.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvColTxtBh,
            this.DgvColTxtJe});
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 119);
            this.Dgv.Name = "Dgv";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv.RowHeadersVisible = false;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.ShowCellErrors = false;
            this.Dgv.ShowCellToolTips = false;
            this.Dgv.ShowEditingIcon = false;
            this.Dgv.ShowRowErrors = false;
            this.Dgv.Size = new System.Drawing.Size(604, 215);
            this.Dgv.TabIndex = 1;
            // 
            // DgvColTxtBh
            // 
            this.DgvColTxtBh.DataPropertyName = "bh";
            this.DgvColTxtBh.HeaderText = "业务单号";
            this.DgvColTxtBh.Name = "DgvColTxtBh";
            // 
            // DgvColTxtJe
            // 
            this.DgvColTxtJe.DataPropertyName = "je";
            this.DgvColTxtJe.HeaderText = "金额";
            this.DgvColTxtJe.Name = "DgvColTxtJe";
            // 
            // Bds
            // 
            this.Bds.DataMember = "tfmsxtwsrmx";
            this.Bds.DataSource = this.DSSP1;
            // 
            // DSSP1
            // 
            this.DSSP1.DataSetName = "DSSP";
            this.DSSP1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TfmsxtwsrmxTableAdapter1
            // 
            this.TfmsxtwsrmxTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmXTSRSPMX
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(604, 334);
            this.Text = "系统外日报审核";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSSP1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private DataGridView Dgv;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox Txtbz;
        private TextBox Txtr;
        private TextBox Txtje;
        private TextBox Txtlx;
        private TextBox Txtbh;
        private Button BtnSPgb;
        private Button BtnSPBtg;
        private Button BtnSPtg;
        private DSSP DSSP1;
        private DSSPTableAdapters.tfmsxtwsrmxTableAdapter TfmsxtwsrmxTableAdapter1;
        private BindingSource Bds;
        private DataGridViewTextBoxColumn DgvColTxtBh;
        private DataGridViewTextBoxColumn DgvColTxtJe;


    }
}