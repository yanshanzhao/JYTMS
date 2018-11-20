using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.ZBJKRBCX
    {
    partial class FrmZBJKRBCX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtXh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtXm = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYhzh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJe = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtDqmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtLsdmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DsZbjkrbcx = new System.Data.DataSet();
            this.DSCX = new System.Data.DataTable();
            this.xm = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.cmblx = new Gizmox.WebGUI.Forms.ComboBox();
            this.类型 = new Gizmox.WebGUI.Forms.Label();
            this.CmbRblx = new Gizmox.WebGUI.Forms.ComboBox();
            this.BtnClear1 = new Gizmox.WebGUI.Forms.Button();
            this.PnlJgcx = new Gizmox.WebGUI.Forms.Panel();
            this.LstV = new Gizmox.WebGUI.Forms.ListView();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExcel = new Gizmox.WebGUI.Forms.Button();
            this.CmbZt = new Gizmox.WebGUI.Forms.ComboBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.CmbYhlx = new Gizmox.WebGUI.Forms.ComboBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.BtnQery = new Gizmox.WebGUI.Forms.Button();
            this.TxtJgmc = new Gizmox.WebGUI.Forms.TextBox();
            this.TxtJg = new Gizmox.WebGUI.Forms.TextBox();
            this.LblJgcx = new Gizmox.WebGUI.Forms.Label();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsZbjkrbcx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSCX)).BeginInit();
            this.PnlBtns.SuspendLayout();
            this.PnlJgcx.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Controls.Add(this.PnlBtns);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(784, 468);
            this.PnlMain.TabIndex = 0;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
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
            this.DgvColTxtXh,
            this.DgvColTxtXm,
            this.DgvColTxtYhzh,
            this.DgvColTxtJe,
            this.DgvColTxtDqmc,
            this.DgvColTxtLsdmc,
            this.DgvColTxtZt});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataMember = "DSCX";
            this.Dgv.DataSource = this.DsZbjkrbcx;
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
            this.Dgv.Location = new System.Drawing.Point(0, 94);
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
            this.Dgv.RowHeadersWidth = 15;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(784, 374);
            this.Dgv.TabIndex = 1;
            // 
            // DgvColTxtXh
            // 
            this.DgvColTxtXh.DataPropertyName = "xh";
            this.DgvColTxtXh.HeaderText = "序号";
            this.DgvColTxtXh.Name = "DgvColTxtXh";
            this.DgvColTxtXh.ReadOnly = true;
            // 
            // DgvColTxtXm
            // 
            this.DgvColTxtXm.DataPropertyName = "zhmc";
            this.DgvColTxtXm.HeaderText = "姓名";
            this.DgvColTxtXm.Name = "DgvColTxtXm";
            this.DgvColTxtXm.ReadOnly = true;
            // 
            // DgvColTxtYhzh
            // 
            this.DgvColTxtYhzh.DataPropertyName = "zh";
            this.DgvColTxtYhzh.HeaderText = "卡号";
            this.DgvColTxtYhzh.Name = "DgvColTxtYhzh";
            this.DgvColTxtYhzh.ReadOnly = true;
            // 
            // DgvColTxtJe
            // 
            this.DgvColTxtJe.DataPropertyName = "je";
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtJe.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColTxtJe.HeaderText = "金额";
            this.DgvColTxtJe.Name = "DgvColTxtJe";
            this.DgvColTxtJe.ReadOnly = true;
            // 
            // DgvColTxtDqmc
            // 
            this.DgvColTxtDqmc.DataPropertyName = "dqmc";
            this.DgvColTxtDqmc.HeaderText = "大区";
            this.DgvColTxtDqmc.Name = "DgvColTxtDqmc";
            this.DgvColTxtDqmc.ReadOnly = true;
            this.DgvColTxtDqmc.Width = 120;
            // 
            // DgvColTxtLsdmc
            // 
            this.DgvColTxtLsdmc.DataPropertyName = "jgmc";
            this.DgvColTxtLsdmc.HeaderText = "连锁店";
            this.DgvColTxtLsdmc.Name = "DgvColTxtLsdmc";
            this.DgvColTxtLsdmc.ReadOnly = true;
            this.DgvColTxtLsdmc.Width = 150;
            // 
            // DgvColTxtZt
            // 
            this.DgvColTxtZt.DataPropertyName = "zts";
            this.DgvColTxtZt.HeaderText = "状态";
            this.DgvColTxtZt.Name = "DgvColTxtZt";
            this.DgvColTxtZt.ReadOnly = true;
            // 
            // DsZbjkrbcx
            // 
            this.DsZbjkrbcx.DataSetName = "NewDataSet";
            this.DsZbjkrbcx.Tables.AddRange(new System.Data.DataTable[] {
            this.DSCX});
            // 
            // DSCX
            // 
            this.DSCX.Columns.AddRange(new System.Data.DataColumn[] {
            this.xm,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn1,
            this.dataColumn6});
            this.DSCX.TableName = "DSCX";
            // 
            // xm
            // 
            this.xm.ColumnName = "zhmc";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "zh";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "je";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "dqmc";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "jgmc";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "zts";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "xh";
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.label5);
            this.PnlBtns.Controls.Add(this.cmblx);
            this.PnlBtns.Controls.Add(this.类型);
            this.PnlBtns.Controls.Add(this.CmbRblx);
            this.PnlBtns.Controls.Add(this.BtnClear1);
            this.PnlBtns.Controls.Add(this.PnlJgcx);
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.BtnExcel);
            this.PnlBtns.Controls.Add(this.CmbZt);
            this.PnlBtns.Controls.Add(this.label4);
            this.PnlBtns.Controls.Add(this.DtpStop);
            this.PnlBtns.Controls.Add(this.DtpStart);
            this.PnlBtns.Controls.Add(this.CmbYhlx);
            this.PnlBtns.Controls.Add(this.label3);
            this.PnlBtns.Controls.Add(this.label2);
            this.PnlBtns.Controls.Add(this.label1);
            this.PnlBtns.Controls.Add(this.BtnQery);
            this.PnlBtns.Controls.Add(this.TxtJgmc);
            this.PnlBtns.Controls.Add(this.TxtJg);
            this.PnlBtns.Controls.Add(this.LblJgcx);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(784, 94);
            this.PnlBtns.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(525, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "日报类型";
            // 
            // cmblx
            // 
            this.cmblx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmblx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmblx.FormattingEnabled = true;
            this.cmblx.Items.AddRange(new object[] {
            "全部",
            "应收账款",
            "应收款"});
            this.cmblx.Location = new System.Drawing.Point(579, 40);
            this.cmblx.Name = "cmblx";
            this.cmblx.Size = new System.Drawing.Size(121, 20);
            this.cmblx.TabIndex = 6;
            // 
            // 类型
            // 
            this.类型.AutoSize = true;
            this.类型.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.类型.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.类型.Location = new System.Drawing.Point(363, 44);
            this.类型.Name = "类型";
            this.类型.Size = new System.Drawing.Size(35, 13);
            this.类型.TabIndex = 6;
            this.类型.Text = "状态";
            // 
            // CmbRblx
            // 
            this.CmbRblx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbRblx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbRblx.FormattingEnabled = true;
            this.CmbRblx.Items.AddRange(new object[] {
            "未审核",
            "审核通过",
            "全部"});
            this.CmbRblx.Location = new System.Drawing.Point(393, 40);
            this.CmbRblx.Name = "CmbRblx";
            this.CmbRblx.Size = new System.Drawing.Size(121, 20);
            this.CmbRblx.TabIndex = 6;
            // 
            // BtnClear1
            // 
            this.BtnClear1.CustomStyle = "F";
            this.BtnClear1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnClear1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear1.Location = new System.Drawing.Point(250, 9);
            this.BtnClear1.Name = "BtnClear1";
            this.BtnClear1.Size = new System.Drawing.Size(26, 21);
            this.BtnClear1.TabIndex = 2;
            this.BtnClear1.Text = "清";
            this.BtnClear1.Click += new System.EventHandler(this.BtnClear1_Click);
            // 
            // PnlJgcx
            // 
            this.PnlJgcx.Controls.Add(this.LstV);
            this.PnlJgcx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlJgcx.Location = new System.Drawing.Point(91, 40);
            this.PnlJgcx.Name = "PnlJgcx";
            this.PnlJgcx.Size = new System.Drawing.Size(222, 230);
            this.PnlJgcx.TabIndex = 1;
            // 
            // LstV
            // 
            this.LstV.AutoGenerateColumns = true;
            this.LstV.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.LstV.DataMember = null;
            this.LstV.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.LstV.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstV.FullRowSelect = true;
            this.LstV.GridLines = true;
            this.LstV.ItemsPerPage = 20;
            this.LstV.Location = new System.Drawing.Point(0, 0);
            this.LstV.Name = "LstV";
            this.LstV.ShowGroups = false;
            this.LstV.ShowItemToolTips = false;
            this.LstV.Size = new System.Drawing.Size(222, 230);
            this.LstV.TabIndex = 0;
            this.LstV.KeyPress += new Gizmox.WebGUI.Forms.KeyPressEventHandler(this.LstV_KeyPress);
            this.LstV.LostFocus += new System.EventHandler(this.LstV_LostFocus);
            this.LstV.DoubleClick += new System.EventHandler(this.LstV_DoubleClick);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            this.ctrlDownLoad1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDownLoad1.Location = new System.Drawing.Point(206, 64);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 14;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnExcel
            // 
            this.BtnExcel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExcel.CustomStyle = "F";
            this.BtnExcel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcel.Location = new System.Drawing.Point(111, 66);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnExcel.TabIndex = 8;
            this.BtnExcel.Text = "导出";
            this.BtnExcel.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbZt
            // 
            this.CmbZt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbZt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbZt.FormattingEnabled = true;
            this.CmbZt.Items.AddRange(new object[] {
            "未审核",
            "审核通过",
            "全部"});
            this.CmbZt.Location = new System.Drawing.Point(229, 40);
            this.CmbZt.Name = "CmbZt";
            this.CmbZt.Size = new System.Drawing.Size(121, 20);
            this.CmbZt.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(200, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "状态";
            // 
            // DtpStop
            // 
            this.DtpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStop.Checked = false;
            this.DtpStop.CustomFormat = "yyyy年MM月dd日";
            this.DtpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStop.Location = new System.Drawing.Point(484, 10);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.Size = new System.Drawing.Size(129, 21);
            this.DtpStop.TabIndex = 4;
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.CustomFormat = "yyyy年MM月dd日";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(337, 10);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(126, 21);
            this.DtpStart.TabIndex = 3;
            // 
            // CmbYhlx
            // 
            this.CmbYhlx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbYhlx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYhlx.FormattingEnabled = true;
            this.CmbYhlx.Location = new System.Drawing.Point(66, 40);
            this.CmbYhlx.Name = "CmbYhlx";
            this.CmbYhlx.Size = new System.Drawing.Size(121, 20);
            this.CmbYhlx.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(464, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "一";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(280, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "保存时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "银行类型";
            // 
            // BtnQery
            // 
            this.BtnQery.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnQery.CustomStyle = "F";
            this.BtnQery.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQery.Location = new System.Drawing.Point(16, 66);
            this.BtnQery.Name = "BtnQery";
            this.BtnQery.Size = new System.Drawing.Size(75, 23);
            this.BtnQery.TabIndex = 7;
            this.BtnQery.Text = "查询";
            this.BtnQery.Click += new System.EventHandler(this.BtnQery_Click);
            // 
            // TxtJgmc
            // 
            this.TxtJgmc.AllowDrag = false;
            this.TxtJgmc.Enabled = false;
            this.TxtJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJgmc.Location = new System.Drawing.Point(126, 10);
            this.TxtJgmc.Name = "TxtJgmc";
            this.TxtJgmc.Size = new System.Drawing.Size(121, 20);
            this.TxtJgmc.TabIndex = 1;
            // 
            // TxtJg
            // 
            this.TxtJg.AllowDrag = false;
            this.TxtJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJg.Location = new System.Drawing.Point(66, 10);
            this.TxtJg.Name = "TxtJg";
            this.TxtJg.Size = new System.Drawing.Size(58, 20);
            this.TxtJg.TabIndex = 0;
            this.TxtJg.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.TxtJg_EnterKeyDown);
            // 
            // LblJgcx
            // 
            this.LblJgcx.AutoSize = true;
            this.LblJgcx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJgcx.Location = new System.Drawing.Point(10, 14);
            this.LblJgcx.Name = "LblJgcx";
            this.LblJgcx.Size = new System.Drawing.Size(53, 12);
            this.LblJgcx.TabIndex = 0;
            this.LblJgcx.Text = "缴款机构";
            // 
            // FrmZBJKRBCX
            // 
            this.Controls.Add(this.PnlMain);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(784, 468);
            this.Text = "总部缴款日报查询";
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsZbjkrbcx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSCX)).EndInit();
            this.PnlBtns.ResumeLayout(false);
            this.PnlJgcx.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private Panel PnlMain;
        private Panel PnlBtns;
        private TextBox TxtJgmc;
        private TextBox TxtJg;
        private Label LblJgcx;
        private ComboBox CmbZt;
        private Label label4;
        private DateTimePicker DtpStop;
        private DateTimePicker DtpStart;
        private ComboBox CmbYhlx;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button BtnQery;
        private DataGridView Dgv;
        private Button BtnExcel;
        private Panel PnlJgcx;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private ListView LstV;
        private Button BtnClear1;
        private Label 类型;
        private ComboBox CmbRblx;
        private DataGridViewTextBoxColumn DgvColTxtXm;
        private DataGridViewTextBoxColumn DgvColTxtYhzh;
        private DataGridViewTextBoxColumn DgvColTxtJe;
        private DataGridViewTextBoxColumn DgvColTxtDqmc;
        private DataGridViewTextBoxColumn DgvColTxtLsdmc;
        private DataGridViewTextBoxColumn DgvColTxtZt;
        private System.Data.DataSet DsZbjkrbcx;
        private System.Data.DataTable DSCX;
        private System.Data.DataColumn xm;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn1;
        private DataGridViewTextBoxColumn DgvColTxtXh;
        private System.Data.DataColumn dataColumn6;
        private Label label5;
        private ComboBox cmblx;


        }
    }