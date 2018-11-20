using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.ZBYCKCX
{
    partial class FrmZBYSKCX
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.BtnQery = new Gizmox.WebGUI.Forms.Button();
            this.DtpQrStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtjgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtffje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxttf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtychj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSZBYCKCX1 = new FMS.CXTJ.ZBYCKCX.DSZBYCKCX();
            this.VfmszbyckcxTableAdapter1 = new FMS.CXTJ.ZBYCKCX.DSZBYCKCXTableAdapters.VfmszbyckcxTableAdapter();
            this.PnlTop.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSZBYCKCX1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnExl);
            this.PnlTop.Controls.Add(this.BtnQery);
            this.PnlTop.Controls.Add(this.DtpQrStop);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(499, 69);
            this.PnlTop.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(379, 36);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 19;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(127, 38);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 2;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // BtnQery
            // 
            this.BtnQery.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnQery.CustomStyle = "F";
            this.BtnQery.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQery.Location = new System.Drawing.Point(11, 38);
            this.BtnQery.Name = "BtnQery";
            this.BtnQery.Size = new System.Drawing.Size(75, 23);
            this.BtnQery.TabIndex = 1;
            this.BtnQery.Text = "查询";
            this.BtnQery.Click += new System.EventHandler(this.BtnQery_Click);
            // 
            // DtpQrStop
            // 
            this.DtpQrStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpQrStop.Checked = false;
            this.DtpQrStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpQrStop.CustomFormat = "yyyy.MM.dd";
            this.DtpQrStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpQrStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpQrStop.Location = new System.Drawing.Point(83, 14);
            this.DtpQrStop.Name = "DtpQrStop";
            this.DtpQrStop.Size = new System.Drawing.Size(130, 21);
            this.DtpQrStop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "截止时间";
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 69);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(499, 435);
            this.PnlMain.TabIndex = 1;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvColTxtjgmc,
            this.DgvColTxtffje,
            this.DgvColTxttf,
            this.DgvColTxtzf,
            this.DgvColTxtychj});
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle8;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(499, 435);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColTxtjgmc
            // 
            this.DgvColTxtjgmc.DataPropertyName = "jgmc";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjgmc.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtjgmc.FillWeight = 160F;
            this.DgvColTxtjgmc.HeaderText = "机构名称";
            this.DgvColTxtjgmc.Name = "DgvColTxtjgmc";
            this.DgvColTxtjgmc.ReadOnly = true;
            this.DgvColTxtjgmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjgmc.Width = 160;
            // 
            // DgvColTxtffje
            // 
            this.DgvColTxtffje.DataPropertyName = "ffje";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtffje.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtffje.FillWeight = 80F;
            this.DgvColTxtffje.HeaderText = "发付应存";
            this.DgvColTxtffje.Name = "DgvColTxtffje";
            this.DgvColTxtffje.ReadOnly = true;
            this.DgvColTxtffje.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtffje.Width = 80;
            // 
            // DgvColTxttf
            // 
            this.DgvColTxttf.DataPropertyName = "tfje";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxttf.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColTxttf.FillWeight = 80F;
            this.DgvColTxttf.HeaderText = "提付应存";
            this.DgvColTxttf.Name = "DgvColTxttf";
            this.DgvColTxttf.ReadOnly = true;
            this.DgvColTxttf.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxttf.Width = 80;
            // 
            // DgvColTxtzf
            // 
            this.DgvColTxtzf.DataPropertyName = "zfje";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtzf.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvColTxtzf.FillWeight = 80F;
            this.DgvColTxtzf.HeaderText = "账付应存";
            this.DgvColTxtzf.Name = "DgvColTxtzf";
            this.DgvColTxtzf.ReadOnly = true;
            this.DgvColTxtzf.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtzf.Width = 80;
            // 
            // DgvColTxtychj
            // 
            this.DgvColTxtychj.DataPropertyName = "ycje";
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtychj.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvColTxtychj.FillWeight = 80F;
            this.DgvColTxtychj.HeaderText = "应存合计";
            this.DgvColTxtychj.Name = "DgvColTxtychj";
            this.DgvColTxtychj.ReadOnly = true;
            this.DgvColTxtychj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtychj.Width = 80;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmszbyckcx";
            this.Bds.DataSource = this.DSZBYCKCX1;
            // 
            // DSZBYCKCX1
            // 
            this.DSZBYCKCX1.DataSetName = "DSZBYCKCX";
            this.DSZBYCKCX1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmszbyckcxTableAdapter1
            // 
            this.VfmszbyckcxTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmZBYSKCX
            // 
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(499, 504);
            this.Text = "FrmZBYSKCX";
            this.PnlTop.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSZBYCKCX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private Panel PnlMain;
        private Label label1;
        private DateTimePicker DtpQrStop;
        private Button BtnExl;
        private Button BtnQery;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private DataGridView Dgv;
        private DSZBYCKCX DSZBYCKCX1;
        private DSZBYCKCXTableAdapters.VfmszbyckcxTableAdapter VfmszbyckcxTableAdapter1;
        private BindingSource Bds;
        private DataGridViewTextBoxColumn DgvColTxtjgmc;
        private DataGridViewTextBoxColumn DgvColTxtffje;
        private DataGridViewTextBoxColumn DgvColTxttf;
        private DataGridViewTextBoxColumn DgvColTxtzf;
        private DataGridViewTextBoxColumn DgvColTxtychj;


    }
}