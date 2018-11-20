using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.WFKDSKCX
{
    partial class FrmWfkDskCx1
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.BtnExlym = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.CmbQsfs = new Gizmox.WebGUI.Forms.ComboBox();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.LblCkjg = new Gizmox.WebGUI.Forms.Label();
            this.BtnJG = new Gizmox.WebGUI.Forms.Button();
            this.LblKsrq = new Gizmox.WebGUI.Forms.Label();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.TxtCkjg = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSearch = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.CmbFklx = new Gizmox.WebGUI.Forms.ComboBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtjgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtyqts0 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtyqts1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtyq2t = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtyq3t = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtyq3tys = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzj = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtjgId = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtlevel = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExlym
            // 
            this.BtnExlym.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExlym.CustomStyle = "F";
            this.BtnExlym.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExlym.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExlym.Location = new System.Drawing.Point(102, 37);
            this.BtnExlym.Name = "BtnExlym";
            this.BtnExlym.Size = new System.Drawing.Size(75, 23);
            this.BtnExlym.TabIndex = 21;
            this.BtnExlym.Text = "导出";
            this.BtnExlym.Click += new System.EventHandler(this.BtnExlym_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(393, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "*截止日期为监控时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(471, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "签收方式";
            // 
            // CmbQsfs
            // 
            this.CmbQsfs.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbQsfs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbQsfs.FormattingEnabled = true;
            this.CmbQsfs.Items.AddRange(new object[] {
            "转单",
            "非转单",
            "全部"});
            this.CmbQsfs.Location = new System.Drawing.Point(524, 14);
            this.CmbQsfs.Name = "CmbQsfs";
            this.CmbQsfs.Size = new System.Drawing.Size(102, 20);
            this.CmbQsfs.TabIndex = 2;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(181, 37);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 3;
            this.BtnExl.Text = "导出明细";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // LblCkjg
            // 
            this.LblCkjg.AutoSize = true;
            this.LblCkjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCkjg.Location = new System.Drawing.Point(5, 17);
            this.LblCkjg.Name = "LblCkjg";
            this.LblCkjg.Size = new System.Drawing.Size(53, 12);
            this.LblCkjg.TabIndex = 0;
            this.LblCkjg.Text = "存款机构";
            // 
            // BtnJG
            // 
            this.BtnJG.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnJG.CustomStyle = "F";
            this.BtnJG.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJG.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnJG.Location = new System.Drawing.Point(224, 14);
            this.BtnJG.Name = "BtnJG";
            this.BtnJG.Size = new System.Drawing.Size(22, 20);
            this.BtnJG.TabIndex = 1;
            this.BtnJG.Text = "》";
            this.BtnJG.Click += new System.EventHandler(this.BtnJG_Click);
            // 
            // LblKsrq
            // 
            this.LblKsrq.AutoSize = true;
            this.LblKsrq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblKsrq.Location = new System.Drawing.Point(265, 17);
            this.LblKsrq.Name = "LblKsrq";
            this.LblKsrq.Size = new System.Drawing.Size(53, 12);
            this.LblKsrq.TabIndex = 0;
            this.LblKsrq.Text = "截止日期";
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStart.CustomFormat = "yyyy-MM-dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(321, 13);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(130, 21);
            this.DtpStart.TabIndex = 2;
            // 
            // TxtCkjg
            // 
            this.TxtCkjg.AllowDrag = false;
            this.TxtCkjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCkjg.Location = new System.Drawing.Point(57, 14);
            this.TxtCkjg.Name = "TxtCkjg";
            this.TxtCkjg.ReadOnly = true;
            this.TxtCkjg.Size = new System.Drawing.Size(162, 20);
            this.TxtCkjg.TabIndex = 0;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSearch.CustomStyle = "F";
            this.BtnSearch.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(8, 37);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 17;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CmbFklx);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.BtnExlym);
            this.panel2.Controls.Add(this.ctrlDownLoad1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.CmbQsfs);
            this.panel2.Controls.Add(this.BtnExl);
            this.panel2.Controls.Add(this.LblCkjg);
            this.panel2.Controls.Add(this.BtnJG);
            this.panel2.Controls.Add(this.LblKsrq);
            this.panel2.Controls.Add(this.DtpStart);
            this.panel2.Controls.Add(this.TxtCkjg);
            this.panel2.Controls.Add(this.BtnSearch);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(886, 68);
            this.panel2.TabIndex = 0;
            // 
            // CmbFklx
            // 
            this.CmbFklx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbFklx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFklx.FormattingEnabled = true;
            this.CmbFklx.Items.AddRange(new object[] {
            "POS",
            "现金",
            "全部"});
            this.CmbFklx.Location = new System.Drawing.Point(697, 15);
            this.CmbFklx.Name = "CmbFklx";
            this.CmbFklx.Size = new System.Drawing.Size(102, 20);
            this.CmbFklx.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(644, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "付款类型";
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(313, 39);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 20;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
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
            this.DgvColTxtyqts0,
            this.DgvColTxtyqts1,
            this.DgvColTxtyq2t,
            this.DgvColTxtyq3t,
            this.DgvColTxtyq3tys,
            this.DgvColTxtzj,
            this.DgvColTxtjgId,
            this.DgvColTxtlevel});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            dataGridViewCellStyle12.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle12;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 68);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(886, 303);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellContentClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellContentClick);
            // 
            // DgvColTxtjgmc
            // 
            this.DgvColTxtjgmc.DataPropertyName = "jgmc";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjgmc.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtjgmc.FillWeight = 140F;
            this.DgvColTxtjgmc.HeaderText = "机构";
            this.DgvColTxtjgmc.Name = "DgvColTxtjgmc";
            this.DgvColTxtjgmc.ReadOnly = true;
            this.DgvColTxtjgmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjgmc.Width = 140;
            // 
            // DgvColTxtyqts0
            // 
            this.DgvColTxtyqts0.DataPropertyName = "yqts0";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtyqts0.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtyqts0.HeaderText = "逾期0天";
            this.DgvColTxtyqts0.Name = "DgvColTxtyqts0";
            this.DgvColTxtyqts0.ReadOnly = true;
            this.DgvColTxtyqts0.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtyqts1
            // 
            this.DgvColTxtyqts1.DataPropertyName = "yqts1";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtyqts1.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColTxtyqts1.HeaderText = "逾期1天";
            this.DgvColTxtyqts1.Name = "DgvColTxtyqts1";
            this.DgvColTxtyqts1.ReadOnly = true;
            this.DgvColTxtyqts1.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtyqts1.Width = 80;
            // 
            // DgvColTxtyq2t
            // 
            this.DgvColTxtyq2t.DataPropertyName = "yqts2";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtyq2t.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvColTxtyq2t.HeaderText = "逾期2天";
            this.DgvColTxtyq2t.Name = "DgvColTxtyq2t";
            this.DgvColTxtyq2t.ReadOnly = true;
            this.DgvColTxtyq2t.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtyq2t.Width = 80;
            // 
            // DgvColTxtyq3t
            // 
            this.DgvColTxtyq3t.DataPropertyName = "yqts3";
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtyq3t.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvColTxtyq3t.HeaderText = "逾期3天";
            this.DgvColTxtyq3t.Name = "DgvColTxtyq3t";
            this.DgvColTxtyq3t.ReadOnly = true;
            this.DgvColTxtyq3t.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtyq3t.Width = 80;
            // 
            // DgvColTxtyq3tys
            // 
            this.DgvColTxtyq3tys.DataPropertyName = "yqts4";
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtyq3tys.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvColTxtyq3tys.HeaderText = "逾期3天以上";
            this.DgvColTxtyq3tys.Name = "DgvColTxtyq3tys";
            this.DgvColTxtyq3tys.ReadOnly = true;
            this.DgvColTxtyq3tys.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtyq3tys.Width = 120;
            // 
            // DgvColTxtzj
            // 
            this.DgvColTxtzj.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtzj.ClientMode = false;
            this.DgvColTxtzj.DataPropertyName = "zj";
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtzj.DefaultCellStyle = dataGridViewCellStyle9;
            this.DgvColTxtzj.FillWeight = 80F;
            this.DgvColTxtzj.HeaderText = "总计";
            this.DgvColTxtzj.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtzj.Name = "DgvColTxtzj";
            this.DgvColTxtzj.ReadOnly = true;
            this.DgvColTxtzj.TrackVisitedState = false;
            this.DgvColTxtzj.Url = "";
            this.DgvColTxtzj.VisitedLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtzj.Width = 80;
            // 
            // DgvColTxtjgId
            // 
            this.DgvColTxtjgId.DataPropertyName = "jgid";
            dataGridViewCellStyle10.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjgId.DefaultCellStyle = dataGridViewCellStyle10;
            this.DgvColTxtjgId.FillWeight = 90F;
            this.DgvColTxtjgId.HeaderText = "jgId[隐藏]";
            this.DgvColTxtjgId.Name = "DgvColTxtjgId";
            this.DgvColTxtjgId.ReadOnly = true;
            this.DgvColTxtjgId.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjgId.Visible = false;
            this.DgvColTxtjgId.Width = 90;
            // 
            // DgvColTxtlevel
            // 
            this.DgvColTxtlevel.DataPropertyName = "level";
            dataGridViewCellStyle11.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtlevel.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvColTxtlevel.HeaderText = "Level[隐藏]";
            this.DgvColTxtlevel.Name = "DgvColTxtlevel";
            this.DgvColTxtlevel.ReadOnly = true;
            this.DgvColTxtlevel.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtlevel.Visible = false;
            // 
            // FrmWfkDskCx1
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(886, 371);
            this.Text = "未返款代收款查询";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnExlym;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Label label1;
        private Label label2;
        private ComboBox CmbQsfs;
        private Button BtnExl;
        private Label LblCkjg;
        private Button BtnJG;
        private Label LblKsrq;
        private DateTimePicker DtpStart;
        private TextBox TxtCkjg;
        private Button BtnSearch;
        private Panel panel2;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtjgmc;
        private DataGridViewTextBoxColumn DgvColTxtyqts0;
        private DataGridViewTextBoxColumn DgvColTxtyqts1;
        private DataGridViewTextBoxColumn DgvColTxtyq2t;
        private DataGridViewTextBoxColumn DgvColTxtyq3t;
        private DataGridViewTextBoxColumn DgvColTxtyq3tys;
        private DataGridViewLinkColumn DgvColTxtzj;
        private DataGridViewTextBoxColumn DgvColTxtjgId;
        private DataGridViewTextBoxColumn DgvColTxtlevel;
        private ComboBox CmbFklx;
        private Label label3;


    }
}