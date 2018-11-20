using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.THBJ
    {
    partial class FrmDSKTHCX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.LblSljg = new Gizmox.WebGUI.Forms.Label();
            this.TxtSQjg = new Gizmox.WebGUI.Forms.TextBox();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.LblSksj = new Gizmox.WebGUI.Forms.Label();
            this.LblYkzt = new Gizmox.WebGUI.Forms.Label();
            this.CmbThydzt = new Gizmox.WebGUI.Forms.ComboBox();
            this.BtnJg = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.CmbDsk = new Gizmox.WebGUI.Forms.ComboBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.DtpBzStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpBzStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.CmbQszt = new Gizmox.WebGUI.Forms.ComboBox();
            this.BtnExlmx = new Gizmox.WebGUI.Forms.Button();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnQuery = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtjgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtjgid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtdskzps = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtdsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtychj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtycdsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblSljg);
            this.panel1.Controls.Add(this.TxtSQjg);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.DtpStop);
            this.panel1.Controls.Add(this.DtpStart);
            this.panel1.Controls.Add(this.LblSksj);
            this.panel1.Controls.Add(this.LblYkzt);
            this.panel1.Controls.Add(this.CmbThydzt);
            this.panel1.Controls.Add(this.BtnJg);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbDsk);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.DtpBzStart);
            this.panel1.Controls.Add(this.DtpBzStop);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.CmbQszt);
            this.panel1.Controls.Add(this.BtnExlmx);
            this.panel1.Controls.Add(this.BtnExl);
            this.panel1.Controls.Add(this.ctrlDownLoad1);
            this.panel1.Controls.Add(this.BtnQuery);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 142);
            this.panel1.TabIndex = 0;
            // 
            // LblSljg
            // 
            this.LblSljg.AutoSize = true;
            this.LblSljg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSljg.Location = new System.Drawing.Point(6, 22);
            this.LblSljg.Name = "LblSljg";
            this.LblSljg.Size = new System.Drawing.Size(53, 12);
            this.LblSljg.TabIndex = 0;
            this.LblSljg.Text = "申请退货机构";
            // 
            // TxtSQjg
            // 
            this.TxtSQjg.AllowDrag = false;
            this.TxtSQjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSQjg.Location = new System.Drawing.Point(83, 19);
            this.TxtSQjg.Name = "TxtSQjg";
            this.TxtSQjg.ReadOnly = true;
            this.TxtSQjg.Size = new System.Drawing.Size(143, 20);
            this.TxtSQjg.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(469, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "到";
            // 
            // DtpStop
            // 
            this.DtpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStop.Checked = false;
            this.DtpStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStop.CustomFormat = "yyyy.MM.dd";
            this.DtpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStop.Location = new System.Drawing.Point(490, 18);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.ShowCheckBox = true;
            this.DtpStop.Size = new System.Drawing.Size(140, 21);
            this.DtpStop.TabIndex = 3;
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Checked = false;
            this.DtpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(337, 18);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.ShowCheckBox = true;
            this.DtpStart.Size = new System.Drawing.Size(130, 21);
            this.DtpStart.TabIndex = 2;
            // 
            // LblSksj
            // 
            this.LblSksj.AutoSize = true;
            this.LblSksj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSksj.Location = new System.Drawing.Point(251, 22);
            this.LblSksj.Name = "LblSksj";
            this.LblSksj.Size = new System.Drawing.Size(53, 12);
            this.LblSksj.TabIndex = 0;
            this.LblSksj.Text = "退货申请日期";
            // 
            // LblYkzt
            // 
            this.LblYkzt.AutoSize = true;
            this.LblYkzt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYkzt.Location = new System.Drawing.Point(6, 51);
            this.LblYkzt.Name = "LblYkzt";
            this.LblYkzt.Size = new System.Drawing.Size(35, 13);
            this.LblYkzt.TabIndex = 0;
            this.LblYkzt.Text = "退货新运单状态";
            // 
            // CmbThydzt
            // 
            this.CmbThydzt.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.CmbThydzt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbThydzt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbThydzt.FormattingEnabled = true;
            this.CmbThydzt.Items.AddRange(new object[] {
            "全部",
            "未压款",
            "已压款"});
            this.CmbThydzt.Location = new System.Drawing.Point(95, 46);
            this.CmbThydzt.Name = "CmbThydzt";
            this.CmbThydzt.Size = new System.Drawing.Size(131, 20);
            this.CmbThydzt.TabIndex = 4;
            // 
            // BtnJg
            // 
            this.BtnJg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnJg.CustomStyle = "F";
            this.BtnJg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnJg.Location = new System.Drawing.Point(229, 19);
            this.BtnJg.Name = "BtnJg";
            this.BtnJg.Size = new System.Drawing.Size(18, 20);
            this.BtnJg.TabIndex = 1;
            this.BtnJg.Text = "》";
            this.BtnJg.Click += new System.EventHandler(this.BtnJg_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "有代收款";
            // 
            // CmbDsk
            // 
            this.CmbDsk.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbDsk.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDsk.FormattingEnabled = true;
            this.CmbDsk.Items.AddRange(new object[] {
            "全部",
            "是",
            "否"});
            this.CmbDsk.Location = new System.Drawing.Point(69, 73);
            this.CmbDsk.Name = "CmbDsk";
            this.CmbDsk.Size = new System.Drawing.Size(79, 20);
            this.CmbDsk.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "签收状态";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "备注时间";
            // 
            // DtpBzStart
            // 
            this.DtpBzStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpBzStart.Checked = false;
            this.DtpBzStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpBzStart.CustomFormat = "yyyy.MM.dd";
            this.DtpBzStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpBzStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpBzStart.Location = new System.Drawing.Point(337, 42);
            this.DtpBzStart.Name = "DtpBzStart";
            this.DtpBzStart.ShowCheckBox = true;
            this.DtpBzStart.Size = new System.Drawing.Size(130, 21);
            this.DtpBzStart.TabIndex = 2;
            // 
            // DtpBzStop
            // 
            this.DtpBzStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpBzStop.Checked = false;
            this.DtpBzStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpBzStop.CustomFormat = "yyyy.MM.dd";
            this.DtpBzStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpBzStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpBzStop.Location = new System.Drawing.Point(490, 42);
            this.DtpBzStop.Name = "DtpBzStop";
            this.DtpBzStop.ShowCheckBox = true;
            this.DtpBzStop.Size = new System.Drawing.Size(140, 21);
            this.DtpBzStop.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(469, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "到";
            // 
            // CmbQszt
            // 
            this.CmbQszt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbQszt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbQszt.FormattingEnabled = true;
            this.CmbQszt.Items.AddRange(new object[] {
            "异常",
            "正常"});
            this.CmbQszt.Location = new System.Drawing.Point(233, 71);
            this.CmbQszt.Name = "CmbQszt";
            this.CmbQszt.Size = new System.Drawing.Size(70, 20);
            this.CmbQszt.TabIndex = 30;
            // 
            // BtnExlmx
            // 
            this.BtnExlmx.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExlmx.CustomStyle = "F";
            this.BtnExlmx.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExlmx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExlmx.Location = new System.Drawing.Point(200, 102);
            this.BtnExlmx.Name = "BtnExlmx";
            this.BtnExlmx.Size = new System.Drawing.Size(75, 23);
            this.BtnExlmx.TabIndex = 8;
            this.BtnExlmx.Text = "导出明细";
            this.BtnExlmx.Click += new System.EventHandler(this.BtnExlmx_Click);
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(106, 102);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 6;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(286, 102);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 5;
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
            this.BtnQuery.Location = new System.Drawing.Point(11, 102);
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Size = new System.Drawing.Size(75, 23);
            this.BtnQuery.TabIndex = 4;
            this.BtnQuery.Text = "查询";
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Dgv);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(837, 382);
            this.panel2.TabIndex = 1;
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
            this.DgvColTxtjgmc,
            this.DgvColTxtdskzps,
            this.DgvColTxtdsk,
            this.DgvColTxtychj,
            this.DgvColTxtycdsk,
            this.DgvColTxtjgid});
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
            this.Dgv.ItemsPerPage = 25;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv.RowHeadersWidth = 10;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(837, 382);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellDoubleClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellDoubleClick);
            // 
            // DgvColTxtjgmc
            // 
            this.DgvColTxtjgmc.DataPropertyName = "jgmc";
            this.DgvColTxtjgmc.FillWeight = 120F;
            this.DgvColTxtjgmc.HeaderText = "机构";
            this.DgvColTxtjgmc.Name = "DgvColTxtjgmc";
            this.DgvColTxtjgmc.ReadOnly = true;
            this.DgvColTxtjgmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjgmc.Width = 120;
            // 
            // DgvColTxtjgid
            // 
            this.DgvColTxtjgid.DataPropertyName = "jgid";
            this.DgvColTxtjgid.FillWeight = 40F;
            this.DgvColTxtjgid.HeaderText = "jgid";
            this.DgvColTxtjgid.Name = "DgvColTxtjgid";
            this.DgvColTxtjgid.ReadOnly = true;
            this.DgvColTxtjgid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjgid.Visible = false;
            this.DgvColTxtjgid.Width = 40;
            // 
            // DgvColTxtdskzps
            // 
            this.DgvColTxtdskzps.DataPropertyName = "thhj";
            this.DgvColTxtdskzps.FillWeight = 140F;
            this.DgvColTxtdskzps.HeaderText = "退货代收款总票数";
            this.DgvColTxtdskzps.Name = "DgvColTxtdskzps";
            this.DgvColTxtdskzps.ReadOnly = true;
            this.DgvColTxtdskzps.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtdskzps.Width = 140;
            // 
            // DgvColTxtdsk
            // 
            this.DgvColTxtdsk.DataPropertyName = "dsk";
            this.DgvColTxtdsk.FillWeight = 140F;
            this.DgvColTxtdsk.HeaderText = "退货代收款总金额";
            this.DgvColTxtdsk.Name = "DgvColTxtdsk";
            this.DgvColTxtdsk.ReadOnly = true;
            this.DgvColTxtdsk.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtdsk.Width = 140;
            // 
            // DgvColTxtychj
            // 
            this.DgvColTxtychj.DataPropertyName = "ychj";
            this.DgvColTxtychj.FillWeight = 140F;
            this.DgvColTxtychj.HeaderText = "签收状态异常票数";
            this.DgvColTxtychj.Name = "DgvColTxtychj";
            this.DgvColTxtychj.ReadOnly = true;
            this.DgvColTxtychj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtychj.Width = 140;
            // 
            // DgvColTxtycdsk
            // 
            this.DgvColTxtycdsk.DataPropertyName = "ycdsk";
            this.DgvColTxtycdsk.FillWeight = 160F;
            this.DgvColTxtycdsk.HeaderText = "签收状态异常代收款金额";
            this.DgvColTxtycdsk.Name = "DgvColTxtycdsk";
            this.DgvColTxtycdsk.ReadOnly = true;
            this.DgvColTxtycdsk.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtycdsk.Width = 160;
            // 
            // FrmDSKTHCX
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(837, 524);
            this.Text = "FrmDSKCKJSXCX";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button BtnQuery;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtjgmc;
        private DataGridViewTextBoxColumn DgvColTxtjgid;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExlmx;
        private Label LblSljg;
        private TextBox TxtSQjg;
        private Label label10;
        private DateTimePicker DtpStop;
        private DateTimePicker DtpStart;
        private Label LblSksj;
        private Label LblYkzt;
        private ComboBox CmbThydzt;
        private Button BtnJg;
        private Label label1;
        private ComboBox CmbDsk;
        private Label label2;
        private Label label3;
        private DateTimePicker DtpBzStart;
        private DateTimePicker DtpBzStop;
        private Label label4;
        private ComboBox CmbQszt;
        private DataGridViewTextBoxColumn DgvColTxtdskzps;
        private DataGridViewTextBoxColumn DgvColTxtdsk;
        private DataGridViewTextBoxColumn DgvColTxtychj;
        private DataGridViewTextBoxColumn DgvColTxtycdsk;


        }
    }