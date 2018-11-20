using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.XTWSR
{
    partial class FrmXTWSRSP
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.CmbZt = new Gizmox.WebGUI.Forms.ComboBox();
            this.BtnDel = new Gizmox.WebGUI.Forms.Button();
            this.BtnOK = new Gizmox.WebGUI.Forms.Button();
            this.BtnSel = new Gizmox.WebGUI.Forms.Button();
            this.LblLx = new Gizmox.WebGUI.Forms.Label();
            this.Lbl = new Gizmox.WebGUI.Forms.Label();
            this.LblSj = new Gizmox.WebGUI.Forms.Label();
            this.DtpQrStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpQrStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.CmbLx = new Gizmox.WebGUI.Forms.ComboBox();
            this.DtpSpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpSpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.Dsxtwsr1 = new FMS.CWGL.XTWSR.DSXTWSR();
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.vfmsxtwsrTableAdapter1 = new FMS.CWGL.XTWSR.DSXTWSRTableAdapters.VfmsxtwsrTableAdapter();
            this.dataGridViewTextBoxColumn7 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dsxtwsr1)).BeginInit();
            this.PnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbZt
            // 
            this.CmbZt.AllowDrag = false;
            this.CmbZt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbZt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbZt.FormattingEnabled = true;
            this.CmbZt.Items.AddRange(new object[] {
            "申请中",
            "审批通过",
            "审批不通过"});
            this.CmbZt.Location = new System.Drawing.Point(605, 12);
            this.CmbZt.Name = "CmbZt";
            this.CmbZt.Size = new System.Drawing.Size(121, 20);
            this.CmbZt.TabIndex = 17;
            // 
            // BtnDel
            // 
            this.BtnDel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDel.CustomStyle = "F";
            this.BtnDel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDel.Location = new System.Drawing.Point(203, 41);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(75, 23);
            this.BtnDel.TabIndex = 16;
            this.BtnDel.Text = "导出";
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnOK.CustomStyle = "F";
            this.BtnOK.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnOK.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Location = new System.Drawing.Point(108, 41);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 16;
            this.BtnOK.Text = "审批";
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnSel
            // 
            this.BtnSel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSel.CustomStyle = "F";
            this.BtnSel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSel.Location = new System.Drawing.Point(15, 41);
            this.BtnSel.Name = "BtnSel";
            this.BtnSel.Size = new System.Drawing.Size(75, 23);
            this.BtnSel.TabIndex = 16;
            this.BtnSel.Text = "查询";
            this.BtnSel.Click += new System.EventHandler(this.BtnSel_Click);
            // 
            // LblLx
            // 
            this.LblLx.AutoSize = true;
            this.LblLx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLx.Location = new System.Drawing.Point(574, 16);
            this.LblLx.Name = "LblLx";
            this.LblLx.Size = new System.Drawing.Size(35, 13);
            this.LblLx.TabIndex = 13;
            this.LblLx.Text = "状态";
            // 
            // Lbl
            // 
            this.Lbl.AutoSize = true;
            this.Lbl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl.Location = new System.Drawing.Point(163, 17);
            this.Lbl.Name = "Lbl";
            this.Lbl.Size = new System.Drawing.Size(20, 13);
            this.Lbl.TabIndex = 12;
            this.Lbl.Text = "-";
            // 
            // LblSj
            // 
            this.LblSj.AutoSize = true;
            this.LblSj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSj.Location = new System.Drawing.Point(12, 14);
            this.LblSj.Name = "LblSj";
            this.LblSj.Size = new System.Drawing.Size(35, 13);
            this.LblSj.TabIndex = 11;
            this.LblSj.Text = "申请时间";
            // 
            // DtpQrStop
            // 
            this.DtpQrStop.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.DtpQrStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpQrStop.Checked = false;
            this.DtpQrStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpQrStop.CustomFormat = "yyyy.MM.dd";
            this.DtpQrStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpQrStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpQrStop.Location = new System.Drawing.Point(174, 11);
            this.DtpQrStop.Name = "DtpQrStop";
            this.DtpQrStop.ShowCheckBox = true;
            this.DtpQrStop.Size = new System.Drawing.Size(104, 21);
            this.DtpQrStop.TabIndex = 10;
            // 
            // DtpQrStart
            // 
            this.DtpQrStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpQrStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpQrStart.CustomFormat = "yyyy.MM.dd";
            this.DtpQrStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpQrStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpQrStart.Location = new System.Drawing.Point(65, 11);
            this.DtpQrStart.Name = "DtpQrStart";
            this.DtpQrStart.ShowCheckBox = true;
            this.DtpQrStart.Size = new System.Drawing.Size(98, 21);
            this.DtpQrStart.TabIndex = 8;
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.CmbLx);
            this.PnlTop.Controls.Add(this.DtpSpStart);
            this.PnlTop.Controls.Add(this.DtpSpStop);
            this.PnlTop.Controls.Add(this.label3);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.CmbZt);
            this.PnlTop.Controls.Add(this.BtnDel);
            this.PnlTop.Controls.Add(this.BtnOK);
            this.PnlTop.Controls.Add(this.BtnSel);
            this.PnlTop.Controls.Add(this.LblLx);
            this.PnlTop.Controls.Add(this.Lbl);
            this.PnlTop.Controls.Add(this.LblSj);
            this.PnlTop.Controls.Add(this.DtpQrStop);
            this.PnlTop.Controls.Add(this.DtpQrStart);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(923, 74);
            this.PnlTop.TabIndex = 0;
            // 
            // CmbLx
            // 
            this.CmbLx.AllowDrag = false;
            this.CmbLx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbLx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLx.FormattingEnabled = true;
            this.CmbLx.Items.AddRange(new object[] {
            "申请中",
            "审批通过",
            "审批不通过"});
            this.CmbLx.Location = new System.Drawing.Point(792, 11);
            this.CmbLx.Name = "CmbLx";
            this.CmbLx.Size = new System.Drawing.Size(121, 20);
            this.CmbLx.TabIndex = 17;
            // 
            // DtpSpStart
            // 
            this.DtpSpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpSpStart.Checked = false;
            this.DtpSpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpSpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpSpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpSpStart.Location = new System.Drawing.Point(344, 12);
            this.DtpSpStart.Name = "DtpSpStart";
            this.DtpSpStart.ShowCheckBox = true;
            this.DtpSpStart.Size = new System.Drawing.Size(98, 21);
            this.DtpSpStart.TabIndex = 8;
            // 
            // DtpSpStop
            // 
            this.DtpSpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpSpStop.Checked = false;
            this.DtpSpStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpSpStop.CustomFormat = "yyyy.MM.dd";
            this.DtpSpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpSpStop.Location = new System.Drawing.Point(453, 12);
            this.DtpSpStop.Name = "DtpSpStop";
            this.DtpSpStop.ShowCheckBox = true;
            this.DtpSpStop.Size = new System.Drawing.Size(104, 21);
            this.DtpSpStop.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(291, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "审批时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(442, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(737, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "业务类型";
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(293, 41);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 8;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowDragTargetsPropagation = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn2});
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
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
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
            this.Dgv.Size = new System.Drawing.Size(923, 417);
            this.Dgv.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "lsh";
            this.dataGridViewTextBoxColumn5.HeaderText = "流水号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "lxs";
            this.dataGridViewTextBoxColumn23.HeaderText = "收入类型";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "je";
            this.dataGridViewTextBoxColumn12.HeaderText = "挂账金额";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "ywdh";
            this.dataGridViewTextBoxColumn18.HeaderText = "业务单号";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "inssj";
            this.dataGridViewTextBoxColumn17.HeaderText = "申请时间";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "zzjg";
            this.dataGridViewTextBoxColumn8.HeaderText = "申请机构";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "sqr";
            this.dataGridViewTextBoxColumn11.HeaderText = "申请人";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "spsj";
            this.dataGridViewTextBoxColumn6.HeaderText = "审批时间";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "spjg";
            this.dataGridViewTextBoxColumn20.HeaderText = "审批机构";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "spr";
            this.dataGridViewTextBoxColumn21.HeaderText = "审批人";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "bz";
            this.dataGridViewTextBoxColumn16.HeaderText = "备注";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn2.HeaderText = "id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsxtwsr";
            this.Bds.DataSource = this.Dsxtwsr1;
            // 
            // Dsxtwsr1
            // 
            this.Dsxtwsr1.DataSetName = "DSXTWSR";
            this.Dsxtwsr1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "lsh";
            this.dataGridViewTextBoxColumn3.HeaderText = "流水号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "lxs";
            this.dataGridViewTextBoxColumn4.HeaderText = "类型";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "je";
            this.dataGridViewTextBoxColumn13.HeaderText = "金额";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "bz";
            this.dataGridViewTextBoxColumn14.HeaderText = "备注";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "inssj";
            this.dataGridViewTextBoxColumn15.HeaderText = "新增时间";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 74);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(923, 417);
            this.PnlMain.TabIndex = 1;
            // 
            // vfmsxtwsrTableAdapter1
            // 
            this.vfmsxtwsrTableAdapter1.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "zts";
            this.dataGridViewTextBoxColumn7.HeaderText = "审批状态";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // FrmXTWSRSP
            // 
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTop);
            this.Size = new System.Drawing.Size(923, 491);
            this.Text = "FrmXTWSRSP";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dsxtwsr1)).EndInit();
            this.PnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox CmbZt;
        private Button BtnDel;
        private Button BtnOK;
        private Button BtnSel;
        private Label LblLx;
        private Label Lbl;
        private Label LblSj;
        private DateTimePicker DtpQrStop;
        private DateTimePicker DtpQrStart;
        private Panel PnlTop;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private Panel PnlMain;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private BindingSource Bds;
        private DSXTWSR Dsxtwsr1;
        private DSXTWSRTableAdapters.VfmsxtwsrTableAdapter vfmsxtwsrTableAdapter1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private ComboBox CmbLx;
        private DateTimePicker DtpSpStart;
        private DateTimePicker DtpSpStop;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;


    }
}