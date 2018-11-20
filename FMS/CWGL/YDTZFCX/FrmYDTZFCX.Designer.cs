using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.YDTZFCX
{
    partial class FrmYDTZFCX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.Dsxtsrcx1 = new FMS.CWGL.YDTZFCX.DSXTSRCX();
            this.VfmsxtsrcxTableAdapter1 = new FMS.CWGL.YDTZFCX.DSXTSRCXTableAdapters.vfmsxtsrcxTableAdapter();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnDaoChu = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.CmbSflx = new Gizmox.WebGUI.Forms.ComboBox();
            this.BtnSea = new Gizmox.WebGUI.Forms.Button();
            this.BtnSel = new Gizmox.WebGUI.Forms.Button();
            this.TxtSljg = new Gizmox.WebGUI.Forms.TextBox();
            this.TxtSqjg = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.DtpSpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpSpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpSqStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpSqStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtBh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSqsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSqjg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSljg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSkje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSqdq = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.TxtSqdq = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSqdq = new Gizmox.WebGUI.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dsxtsrcx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            this.PnlTop.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Dsxtsrcx1
            // 
            this.Dsxtsrcx1.DataSetName = "DSXTSRCX";
            this.Dsxtsrcx1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmsxtsrcxTableAdapter1
            // 
            this.VfmsxtsrcxTableAdapter1.ClearBeforeFill = true;
            // 
            // Bds
            // 
            this.Bds.DataMember = "vfmsxtsrcx";
            this.Bds.DataSource = this.Dsxtsrcx1;
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnSqdq);
            this.PnlTop.Controls.Add(this.TxtSqdq);
            this.PnlTop.Controls.Add(this.label8);
            this.PnlTop.Controls.Add(this.BtnSave);
            this.PnlTop.Controls.Add(this.BtnDaoChu);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.label7);
            this.PnlTop.Controls.Add(this.CmbSflx);
            this.PnlTop.Controls.Add(this.BtnSea);
            this.PnlTop.Controls.Add(this.BtnSel);
            this.PnlTop.Controls.Add(this.TxtSljg);
            this.PnlTop.Controls.Add(this.TxtSqjg);
            this.PnlTop.Controls.Add(this.label6);
            this.PnlTop.Controls.Add(this.label5);
            this.PnlTop.Controls.Add(this.label4);
            this.PnlTop.Controls.Add(this.label3);
            this.PnlTop.Controls.Add(this.DtpSpStop);
            this.PnlTop.Controls.Add(this.DtpSpStart);
            this.PnlTop.Controls.Add(this.DtpSqStop);
            this.PnlTop.Controls.Add(this.DtpSqStart);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(856, 100);
            this.PnlTop.TabIndex = 0;
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(229, 68);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 11;
            this.BtnSave.Text = "查询";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnDaoChu
            // 
            this.BtnDaoChu.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDaoChu.CustomStyle = "F";
            this.BtnDaoChu.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDaoChu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDaoChu.Location = new System.Drawing.Point(318, 68);
            this.BtnDaoChu.Name = "BtnDaoChu";
            this.BtnDaoChu.Size = new System.Drawing.Size(75, 23);
            this.BtnDaoChu.TabIndex = 11;
            this.BtnDaoChu.Text = "导出";
            this.BtnDaoChu.Click += new System.EventHandler(this.BtnDaoChu_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDownLoad1.Location = new System.Drawing.Point(408, 68);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 22;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "收费类型";
            // 
            // CmbSflx
            // 
            this.CmbSflx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbSflx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSflx.FormattingEnabled = true;
            this.CmbSflx.Items.AddRange(new object[] {
            "全部",
            "调整费"});
            this.CmbSflx.Location = new System.Drawing.Point(74, 70);
            this.CmbSflx.Name = "CmbSflx";
            this.CmbSflx.Size = new System.Drawing.Size(141, 20);
            this.CmbSflx.TabIndex = 1;
            // 
            // BtnSea
            // 
            this.BtnSea.CustomStyle = "F";
            this.BtnSea.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSea.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSea.Location = new System.Drawing.Point(565, 37);
            this.BtnSea.Name = "BtnSea";
            this.BtnSea.Size = new System.Drawing.Size(26, 21);
            this.BtnSea.TabIndex = 5;
            this.BtnSea.Text = "》";
            this.BtnSea.Click += new System.EventHandler(this.BtnSea_Click);
            // 
            // BtnSel
            // 
            this.BtnSel.CustomStyle = "F";
            this.BtnSel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSel.Location = new System.Drawing.Point(565, 11);
            this.BtnSel.Name = "BtnSel";
            this.BtnSel.Size = new System.Drawing.Size(26, 21);
            this.BtnSel.TabIndex = 5;
            this.BtnSel.Text = "》";
            this.BtnSel.Click += new System.EventHandler(this.BtnSel_Click);
            // 
            // TxtSljg
            // 
            this.TxtSljg.AllowDrag = false;
            this.TxtSljg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSljg.Location = new System.Drawing.Point(442, 38);
            this.TxtSljg.Name = "TxtSljg";
            this.TxtSljg.Size = new System.Drawing.Size(120, 20);
            this.TxtSljg.TabIndex = 3;
            // 
            // TxtSqjg
            // 
            this.TxtSqjg.AllowDrag = false;
            this.TxtSqjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSqjg.Location = new System.Drawing.Point(442, 12);
            this.TxtSqjg.Name = "TxtSqjg";
            this.TxtSqjg.Size = new System.Drawing.Size(120, 20);
            this.TxtSqjg.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(386, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "受理机构";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(386, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "申请机构";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(217, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(217, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "-";
            // 
            // DtpSpStop
            // 
            this.DtpSpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpSpStop.Checked = false;
            this.DtpSpStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpSpStop.CustomFormat = "yyyy.MM.dd";
            this.DtpSpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpSpStop.Location = new System.Drawing.Point(230, 38);
            this.DtpSpStop.Name = "DtpSpStop";
            this.DtpSpStop.ShowCheckBox = true;
            this.DtpSpStop.Size = new System.Drawing.Size(141, 21);
            this.DtpSpStop.TabIndex = 1;
            // 
            // DtpSpStart
            // 
            this.DtpSpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpSpStart.Checked = false;
            this.DtpSpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpSpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpSpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpSpStart.Location = new System.Drawing.Point(74, 38);
            this.DtpSpStart.Name = "DtpSpStart";
            this.DtpSpStart.ShowCheckBox = true;
            this.DtpSpStart.Size = new System.Drawing.Size(141, 21);
            this.DtpSpStart.TabIndex = 1;
            // 
            // DtpSqStop
            // 
            this.DtpSqStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpSqStop.Checked = false;
            this.DtpSqStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpSqStop.CustomFormat = "yyyy.MM.dd";
            this.DtpSqStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSqStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpSqStop.Location = new System.Drawing.Point(230, 11);
            this.DtpSqStop.Name = "DtpSqStop";
            this.DtpSqStop.ShowCheckBox = true;
            this.DtpSqStop.Size = new System.Drawing.Size(141, 21);
            this.DtpSqStop.TabIndex = 1;
            // 
            // DtpSqStart
            // 
            this.DtpSqStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpSqStart.Checked = false;
            this.DtpSqStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpSqStart.CustomFormat = "yyyy.MM.dd";
            this.DtpSqStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSqStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpSqStart.Location = new System.Drawing.Point(74, 11);
            this.DtpSqStart.Name = "DtpSqStart";
            this.DtpSqStart.ShowCheckBox = true;
            this.DtpSqStart.Size = new System.Drawing.Size(141, 21);
            this.DtpSqStart.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "审批时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "申请时间";
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 100);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(856, 508);
            this.PnlMain.TabIndex = 1;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv.AutoGenerateColumns = false;
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvColTxtBh,
            this.DgvColTxtSqsj,
            this.DgvColTxtSqjg,
            this.DgvColTxtSqdq,
            this.DgvColTxtSljg,
            this.DgvColTxtSkje});
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle7;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(856, 508);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColTxtBh
            // 
            this.DgvColTxtBh.DataPropertyName = "bh";
            this.DgvColTxtBh.HeaderText = "编号";
            this.DgvColTxtBh.Name = "DgvColTxtBh";
            // 
            // DgvColTxtSqsj
            // 
            this.DgvColTxtSqsj.DataPropertyName = "sqsj";
            this.DgvColTxtSqsj.HeaderText = "申请时间";
            this.DgvColTxtSqsj.Name = "DgvColTxtSqsj";
            this.DgvColTxtSqsj.Width = 150;
            // 
            // DgvColTxtSqjg
            // 
            this.DgvColTxtSqjg.DataPropertyName = "sqjg";
            this.DgvColTxtSqjg.HeaderText = "申请机构";
            this.DgvColTxtSqjg.Name = "DgvColTxtSqjg";
            this.DgvColTxtSqjg.Width = 150;
            // 
            // DgvColTxtSljg
            // 
            this.DgvColTxtSljg.DataPropertyName = "sljg";
            this.DgvColTxtSljg.HeaderText = "受理机构";
            this.DgvColTxtSljg.Name = "DgvColTxtSljg";
            this.DgvColTxtSljg.Width = 150;
            // 
            // DgvColTxtSkje
            // 
            this.DgvColTxtSkje.DataPropertyName = "je";
            this.DgvColTxtSkje.HeaderText = "收款金额";
            this.DgvColTxtSkje.Name = "DgvColTxtSkje";
            // 
            // DgvColTxtSqdq
            // 
            this.DgvColTxtSqdq.DataPropertyName = "dqmc";
            this.DgvColTxtSqdq.HeaderText = "申请大区";
            this.DgvColTxtSqdq.Name = "DgvColTxtSqdq";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(593, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "申请大区";
            this.label8.Visible = false;
            // 
            // TxtSqdq
            // 
            this.TxtSqdq.AllowDrag = false;
            this.TxtSqdq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtSqdq.Location = new System.Drawing.Point(649, 11);
            this.TxtSqdq.Name = "TxtSqdq";
            this.TxtSqdq.Size = new System.Drawing.Size(131, 21);
            this.TxtSqdq.TabIndex = 3;
            this.TxtSqdq.Visible = false;
            // 
            // BtnSqdq
            // 
            this.BtnSqdq.CustomStyle = "F";
            this.BtnSqdq.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSqdq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSqdq.Location = new System.Drawing.Point(783, 11);
            this.BtnSqdq.Name = "BtnSqdq";
            this.BtnSqdq.Size = new System.Drawing.Size(26, 21);
            this.BtnSqdq.TabIndex = 4;
            this.BtnSqdq.Text = "》";
            this.BtnSqdq.Visible = false;
            this.BtnSqdq.Click += new System.EventHandler(this.BtnSqdq_Click);
            // 
            // FrmYDTZFCX
            // 
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(856, 608);
            this.Text = "运单调整费查询";
            ((System.ComponentModel.ISupportInitialize)(this.Dsxtsrcx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            this.PnlTop.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DSXTSRCX Dsxtsrcx1;
        private DSXTSRCXTableAdapters.vfmsxtsrcxTableAdapter VfmsxtsrcxTableAdapter1;
        private BindingSource Bds;
        private Panel PnlTop;
        private Panel PnlMain;
        private DataGridView Dgv;
        private Label label4;
        private Label label3;
        private DateTimePicker DtpSpStop;
        private DateTimePicker DtpSpStart;
        private DateTimePicker DtpSqStop;
        private DateTimePicker DtpSqStart;
        private Label label2;
        private Label label1;
        private Label label6;
        private Label label5;
        private TextBox TxtSljg;
        private TextBox TxtSqjg;
        private Button BtnSea;
        private Button BtnSel;
        private Label label7;
        private ComboBox CmbSflx;
        private Button BtnSave;
        private Button BtnDaoChu;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private DataGridViewTextBoxColumn DgvColTxtBh;
        private DataGridViewTextBoxColumn DgvColTxtSqsj;
        private DataGridViewTextBoxColumn DgvColTxtSqjg;
        private DataGridViewTextBoxColumn DgvColTxtSljg;
        private DataGridViewTextBoxColumn DgvColTxtSkje;
        private DataGridViewTextBoxColumn DgvColTxtSqdq;
        private Button BtnSqdq;
        private TextBox TxtSqdq;
        private Label label8;
    }
}