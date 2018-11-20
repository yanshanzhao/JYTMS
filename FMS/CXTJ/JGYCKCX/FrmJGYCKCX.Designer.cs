using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.JGYCKCX
{
    partial class FrmJGYCKCX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.LblHj = new Gizmox.WebGUI.Forms.Label();
            this.BtnDc = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnQuery = new Gizmox.WebGUI.Forms.Button();
            this.CmbZt = new Gizmox.WebGUI.Forms.ComboBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.DtpEnd = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.BtnJg = new Gizmox.WebGUI.Forms.Button();
            this.TxtJg = new Gizmox.WebGUI.Forms.TextBox();
            this.Label1 = new Gizmox.WebGUI.Forms.Label();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtSjjg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJgmd = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYdbh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJe = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtFkfs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtbczt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYwlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSJGYCKCX1 = new FMS.CXTJ.JGYCKCX.DSJGYCKCX();
            this.VfmsjgyckcxTableAdapter1 = new FMS.CXTJ.JGYCKCX.DSJGYCKCXTableAdapters.VfmsjgyckcxTableAdapter();
            this.PnlTop.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSJGYCKCX1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.LblHj);
            this.PnlTop.Controls.Add(this.BtnDc);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnQuery);
            this.PnlTop.Controls.Add(this.CmbZt);
            this.PnlTop.Controls.Add(this.label4);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.DtpStart);
            this.PnlTop.Controls.Add(this.label3);
            this.PnlTop.Controls.Add(this.DtpEnd);
            this.PnlTop.Controls.Add(this.BtnJg);
            this.PnlTop.Controls.Add(this.TxtJg);
            this.PnlTop.Controls.Add(this.Label1);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(955, 69);
            this.PnlTop.TabIndex = 0;
            // 
            // LblHj
            // 
            this.LblHj.BackColor = System.Drawing.SystemColors.Window;
            this.LblHj.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblHj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHj.ForeColor = System.Drawing.Color.Blue;
            this.LblHj.Location = new System.Drawing.Point(285, 44);
            this.LblHj.Name = "LblHj";
            this.LblHj.Size = new System.Drawing.Size(150, 21);
            this.LblHj.TabIndex = 18;
            this.LblHj.Text = "金额合计：0.00元";
            this.LblHj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnDc
            // 
            this.BtnDc.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnDc.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDc.CustomStyle = "F";
            this.BtnDc.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDc.Location = new System.Drawing.Point(104, 43);
            this.BtnDc.Name = "BtnDc";
            this.BtnDc.Size = new System.Drawing.Size(75, 23);
            this.BtnDc.TabIndex = 6;
            this.BtnDc.Text = "导出";
            this.BtnDc.Click += new System.EventHandler(this.BtnDc_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(191, 41);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 7;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnQuery
            // 
            this.BtnQuery.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnQuery.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnQuery.CustomStyle = "F";
            this.BtnQuery.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuery.Location = new System.Drawing.Point(17, 43);
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Size = new System.Drawing.Size(75, 23);
            this.BtnQuery.TabIndex = 5;
            this.BtnQuery.Text = "查询";
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // CmbZt
            // 
            this.CmbZt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbZt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbZt.FormattingEnabled = true;
            this.CmbZt.Items.AddRange(new object[] {
            "已存",
            "未存",
            "全部"});
            this.CmbZt.Location = new System.Drawing.Point(658, 17);
            this.CmbZt.Name = "CmbZt";
            this.CmbZt.Size = new System.Drawing.Size(75, 20);
            this.CmbZt.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(602, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "存款情况";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(248, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "记账日期范围";
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Checked = false;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(329, 17);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.ShowCheckBox = true;
            this.DtpStart.Size = new System.Drawing.Size(123, 20);
            this.DtpStart.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(454, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "一";
            // 
            // DtpEnd
            // 
            this.DtpEnd.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpEnd.Checked = false;
            this.DtpEnd.CustomFormat = "yyyy.MM.dd";
            this.DtpEnd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpEnd.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpEnd.Location = new System.Drawing.Point(475, 17);
            this.DtpEnd.Name = "DtpEnd";
            this.DtpEnd.ShowCheckBox = true;
            this.DtpEnd.Size = new System.Drawing.Size(123, 20);
            this.DtpEnd.TabIndex = 3;
            // 
            // BtnJg
            // 
            this.BtnJg.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnJg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnJg.CustomStyle = "F";
            this.BtnJg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJg.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnJg.Location = new System.Drawing.Point(219, 17);
            this.BtnJg.Name = "BtnJg";
            this.BtnJg.Size = new System.Drawing.Size(21, 21);
            this.BtnJg.TabIndex = 1;
            this.BtnJg.Text = "》";
            this.BtnJg.Click += new System.EventHandler(this.BtnJg_Click);
            // 
            // TxtJg
            // 
            this.TxtJg.AllowDrag = false;
            this.TxtJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJg.Location = new System.Drawing.Point(48, 17);
            this.TxtJg.Name = "TxtJg";
            this.TxtJg.ReadOnly = true;
            this.TxtJg.Size = new System.Drawing.Size(166, 21);
            this.TxtJg.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(15, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(35, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "机构";
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 69);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(955, 478);
            this.PnlMain.TabIndex = 0;
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
            this.Dgv.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
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
            this.DgvColTxtSjjg,
            this.DgvColTxtJgmd,
            this.DgvColTxtYdbh,
            this.DgvColTxtSj,
            this.DgvColTxtzt,
            this.DgvColTxtJe,
            this.DgvColTxtFkfs,
            this.DgvColTxtbczt,
            this.DgvColTxtYwlx});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.RowHeadersWidth = 10;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(955, 478);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColTxtSjjg
            // 
            this.DgvColTxtSjjg.DataPropertyName = "sjjg";
            this.DgvColTxtSjjg.HeaderText = "上级机构";
            this.DgvColTxtSjjg.Name = "DgvColTxtSjjg";
            this.DgvColTxtSjjg.ReadOnly = true;
            this.DgvColTxtSjjg.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtSjjg.Width = 150;
            // 
            // DgvColTxtJgmd
            // 
            this.DgvColTxtJgmd.DataPropertyName = "jsjgmc";
            this.DgvColTxtJgmd.HeaderText = "机构名称";
            this.DgvColTxtJgmd.Name = "DgvColTxtJgmd";
            this.DgvColTxtJgmd.ReadOnly = true;
            this.DgvColTxtJgmd.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtJgmd.Width = 180;
            // 
            // DgvColTxtYdbh
            // 
            this.DgvColTxtYdbh.DataPropertyName = "bh";
            this.DgvColTxtYdbh.HeaderText = "货运单号";
            this.DgvColTxtYdbh.Name = "DgvColTxtYdbh";
            this.DgvColTxtYdbh.ReadOnly = true;
            this.DgvColTxtYdbh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtYdbh.Width = 80;
            // 
            // DgvColTxtSj
            // 
            this.DgvColTxtSj.DataPropertyName = "inssj";
            this.DgvColTxtSj.HeaderText = "记账日期";
            this.DgvColTxtSj.Name = "DgvColTxtSj";
            this.DgvColTxtSj.ReadOnly = true;
            this.DgvColTxtSj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtSj.Width = 80;
            // 
            // DgvColTxtzt
            // 
            this.DgvColTxtzt.DataPropertyName = "zt";
            this.DgvColTxtzt.HeaderText = "存款情况";
            this.DgvColTxtzt.Name = "DgvColTxtzt";
            this.DgvColTxtzt.ReadOnly = true;
            this.DgvColTxtzt.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtzt.Width = 80;
            // 
            // DgvColTxtJe
            // 
            this.DgvColTxtJe.DataPropertyName = "je";
            this.DgvColTxtJe.HeaderText = "金额";
            this.DgvColTxtJe.Name = "DgvColTxtJe";
            this.DgvColTxtJe.ReadOnly = true;
            this.DgvColTxtJe.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtJe.Width = 80;
            // 
            // DgvColTxtFkfs
            // 
            this.DgvColTxtFkfs.DataPropertyName = "fkfs";
            this.DgvColTxtFkfs.HeaderText = "付款方式";
            this.DgvColTxtFkfs.Name = "DgvColTxtFkfs";
            this.DgvColTxtFkfs.ReadOnly = true;
            this.DgvColTxtFkfs.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtFkfs.Width = 80;
            // 
            // DgvColTxtbczt
            // 
            this.DgvColTxtbczt.DataPropertyName = "zts";
            this.DgvColTxtbczt.HeaderText = "保存状态";
            this.DgvColTxtbczt.Name = "DgvColTxtbczt";
            this.DgvColTxtbczt.ReadOnly = true;
            this.DgvColTxtbczt.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtbczt.Width = 80;
            // 
            // DgvColTxtYwlx
            // 
            this.DgvColTxtYwlx.DataPropertyName = "ywlx";
            this.DgvColTxtYwlx.HeaderText = "业务类型";
            this.DgvColTxtYwlx.Name = "DgvColTxtYwlx";
            this.DgvColTxtYwlx.ReadOnly = true;
            this.DgvColTxtYwlx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsjgyckcx";
            this.Bds.DataSource = this.DSJGYCKCX1;
            // 
            // DSJGYCKCX1
            // 
            this.DSJGYCKCX1.DataSetName = "DSJGYCKCX";
            this.DSJGYCKCX1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmsjgyckcxTableAdapter1
            // 
            this.VfmsjgyckcxTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmJGYCKCX
            // 
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTop);
            this.Size = new System.Drawing.Size(955, 547);
            this.Text = "FrmJGYCKCX";
            this.PnlTop.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSJGYCKCX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private Panel PnlMain;
        private DataGridView Dgv; 
        private BindingSource Bds;
        private DSJGYCKCX DSJGYCKCX1;
        private Label Label1;
        private TextBox TxtJg;
        private Button BtnJg;
        private Label label2;
        private DateTimePicker DtpStart;
        private Label label3;
        private DateTimePicker DtpEnd;
        private DSJGYCKCXTableAdapters.VfmsjgyckcxTableAdapter VfmsjgyckcxTableAdapter1;
        private Label label4;
        private ComboBox CmbZt;
        private Button BtnQuery;
        private Button BtnDc;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1; 
        private Label LblHj; 
        private DataGridViewTextBoxColumn DgvColTxtbczt;
        private DataGridViewTextBoxColumn DgvColTxtYwlx;
        private DataGridViewTextBoxColumn DgvColTxtSjjg;
        private DataGridViewTextBoxColumn DgvColTxtJgmd;
        private DataGridViewTextBoxColumn DgvColTxtYdbh;
        private DataGridViewTextBoxColumn DgvColTxtSj;
        private DataGridViewTextBoxColumn DgvColTxtzt;
        private DataGridViewTextBoxColumn DgvColTxtJe;
        private DataGridViewTextBoxColumn DgvColTxtFkfs;


    }
}
