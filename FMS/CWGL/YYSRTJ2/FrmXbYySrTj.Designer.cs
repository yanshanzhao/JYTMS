using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.YYSRTJ2
{
    partial class FrmXbYySrTj
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.LblHj = new Gizmox.WebGUI.Forms.Label();
            this.BtnClear1 = new Gizmox.WebGUI.Forms.Button();
            this.DtpQrStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpQrStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.TxtJg = new Gizmox.WebGUI.Forms.TextBox();
            this.TxtJgmc = new Gizmox.WebGUI.Forms.TextBox();
            this.CmbYwqy = new Gizmox.WebGUI.Forms.ComboBox();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.LstV = new Gizmox.WebGUI.Forms.ListView();
            this.PnlJgcx = new Gizmox.WebGUI.Forms.Panel();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtjzjg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtywqy = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtyf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtbf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtjehj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColXx = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColSljgid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZzl = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZtj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJfzl = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlJgcx.SuspendLayout();
            this.PnlTop.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // LblHj
            // 
            this.LblHj.BackColor = System.Drawing.SystemColors.Window;
            this.LblHj.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblHj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHj.ForeColor = System.Drawing.Color.Blue;
            this.LblHj.Location = new System.Drawing.Point(193, 55);
            this.LblHj.Name = "LblHj";
            this.LblHj.Size = new System.Drawing.Size(161, 21);
            this.LblHj.TabIndex = 3;
            this.LblHj.Text = "合计：0元";
            this.LblHj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnClear1
            // 
            this.BtnClear1.CustomStyle = "F";
            this.BtnClear1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnClear1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear1.Location = new System.Drawing.Point(446, 2);
            this.BtnClear1.Name = "BtnClear1";
            this.BtnClear1.Size = new System.Drawing.Size(26, 21);
            this.BtnClear1.TabIndex = 3;
            this.BtnClear1.Text = "清";
            this.BtnClear1.Click += new System.EventHandler(this.BtnClear1_Click);
            // 
            // DtpQrStart
            // 
            this.DtpQrStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpQrStart.Checked = false;
            this.DtpQrStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpQrStart.CustomFormat = "yyyy.MM.dd";
            this.DtpQrStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpQrStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpQrStart.Location = new System.Drawing.Point(60, 28);
            this.DtpQrStart.Name = "DtpQrStart";
            this.DtpQrStart.Size = new System.Drawing.Size(130, 21);
            this.DtpQrStart.TabIndex = 4;
            // 
            // DtpQrStop
            // 
            this.DtpQrStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpQrStop.Checked = false;
            this.DtpQrStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpQrStop.CustomFormat = "yyyy.MM.dd";
            this.DtpQrStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpQrStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpQrStop.Location = new System.Drawing.Point(249, 26);
            this.DtpQrStop.Name = "DtpQrStop";
            this.DtpQrStop.Size = new System.Drawing.Size(130, 21);
            this.DtpQrStop.TabIndex = 5;
            // 
            // TxtJg
            // 
            this.TxtJg.AllowDrag = false;
            this.TxtJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJg.Location = new System.Drawing.Point(260, 3);
            this.TxtJg.Name = "TxtJg";
            this.TxtJg.Size = new System.Drawing.Size(58, 20);
            this.TxtJg.TabIndex = 1;
            this.TxtJg.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.TxtJg_EnterKeyDown);
            // 
            // TxtJgmc
            // 
            this.TxtJgmc.AllowDrag = false;
            this.TxtJgmc.Enabled = false;
            this.TxtJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJgmc.Location = new System.Drawing.Point(322, 3);
            this.TxtJgmc.Name = "TxtJgmc";
            this.TxtJgmc.Size = new System.Drawing.Size(121, 20);
            this.TxtJgmc.TabIndex = 2;
            // 
            // CmbYwqy
            // 
            this.CmbYwqy.AllowDrag = false;
            this.CmbYwqy.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbYwqy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYwqy.FormattingEnabled = true;
            this.CmbYwqy.Location = new System.Drawing.Point(67, 3);
            this.CmbYwqy.Name = "CmbYwqy";
            this.CmbYwqy.Size = new System.Drawing.Size(130, 20);
            this.CmbYwqy.TabIndex = 0;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(96, 54);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 7;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(4, 54);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "查询";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(196, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "结束时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "开始时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(205, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "查询机构";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "业务区域";
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
            this.LstV.Size = new System.Drawing.Size(209, 206);
            this.LstV.TabIndex = 0;
            this.LstV.KeyPress += new Gizmox.WebGUI.Forms.KeyPressEventHandler(this.LstV_KeyPress);
            this.LstV.LostFocus += new System.EventHandler(this.LstV_LostFocus);
            this.LstV.DoubleClick += new System.EventHandler(this.LstV_DoubleClick);
            // 
            // PnlJgcx
            // 
            this.PnlJgcx.Controls.Add(this.LstV);
            this.PnlJgcx.Location = new System.Drawing.Point(260, 22);
            this.PnlJgcx.Name = "PnlJgcx";
            this.PnlJgcx.Size = new System.Drawing.Size(209, 206);
            this.PnlJgcx.TabIndex = 17;
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.LblHj);
            this.PnlTop.Controls.Add(this.BtnClear1);
            this.PnlTop.Controls.Add(this.DtpQrStart);
            this.PnlTop.Controls.Add(this.DtpQrStop);
            this.PnlTop.Controls.Add(this.TxtJg);
            this.PnlTop.Controls.Add(this.TxtJgmc);
            this.PnlTop.Controls.Add(this.CmbYwqy);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnExl);
            this.PnlTop.Controls.Add(this.BtnSave);
            this.PnlTop.Controls.Add(this.label6);
            this.PnlTop.Controls.Add(this.label5);
            this.PnlTop.Controls.Add(this.label4);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Controls.Add(this.PnlJgcx);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(791, 85);
            this.PnlTop.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(682, 4);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 8;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Controls.Add(this.PnlTop);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(791, 425);
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
            this.DgvColTxtjzjg,
            this.DgvColTxtywqy,
            this.DgvColTxtyf,
            this.DgvColTxtbf,
            this.DgvColTxtjehj,
            this.DgvColTxtZzl,
            this.DgvColTxtZtj,
            this.DgvColTxtJfzl,
            this.DgvColXx,
            this.DgvColSljgid});
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
            this.Dgv.Location = new System.Drawing.Point(0, 85);
            this.Dgv.Name = "Dgv";
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
            this.Dgv.Size = new System.Drawing.Size(791, 340);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellMouseDown += new Gizmox.WebGUI.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseDown);
            // 
            // DgvColTxtjzjg
            // 
            this.DgvColTxtjzjg.DataPropertyName = "mc";
            this.DgvColTxtjzjg.FillWeight = 80F;
            this.DgvColTxtjzjg.HeaderText = "记账机构";
            this.DgvColTxtjzjg.Name = "DgvColTxtjzjg";
            // 
            // DgvColTxtywqy
            // 
            this.DgvColTxtywqy.DataPropertyName = "ywqy";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtywqy.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtywqy.FillWeight = 70F;
            this.DgvColTxtywqy.HeaderText = "业务区域";
            this.DgvColTxtywqy.Name = "DgvColTxtywqy";
            this.DgvColTxtywqy.ReadOnly = true;
            this.DgvColTxtywqy.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtywqy.Width = 80;
            // 
            // DgvColTxtyf
            // 
            this.DgvColTxtyf.DataPropertyName = "fhxf";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtyf.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtyf.FillWeight = 80F;
            this.DgvColTxtyf.HeaderText = "运费(元)";
            this.DgvColTxtyf.Name = "DgvColTxtyf";
            this.DgvColTxtyf.ReadOnly = true;
            this.DgvColTxtyf.Width = 80;
            // 
            // DgvColTxtbf
            // 
            this.DgvColTxtbf.DataPropertyName = "bf";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtbf.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColTxtbf.FillWeight = 60F;
            this.DgvColTxtbf.HeaderText = "保价费(元)";
            this.DgvColTxtbf.Name = "DgvColTxtbf";
            this.DgvColTxtbf.ReadOnly = true;
            this.DgvColTxtbf.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtbf.Width = 80;
            // 
            // DgvColTxtjehj
            // 
            this.DgvColTxtjehj.DataPropertyName = "jezj";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjehj.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvColTxtjehj.FillWeight = 80F;
            this.DgvColTxtjehj.HeaderText = "金额合计(元)";
            this.DgvColTxtjehj.Name = "DgvColTxtjehj";
            this.DgvColTxtjehj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjehj.Width = 120;
            // 
            // DgvColXx
            // 
            this.DgvColXx.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColXx.ClientMode = false;
            this.DgvColXx.DataPropertyName = "cz";
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColXx.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvColXx.HeaderText = "操作";
            this.DgvColXx.LinkColor = System.Drawing.Color.Empty;
            this.DgvColXx.Name = "DgvColXx";
            this.DgvColXx.Text = "详细";
            this.DgvColXx.TrackVisitedState = false;
            this.DgvColXx.Url = "";
            this.DgvColXx.VisitedLinkColor = System.Drawing.Color.Empty;
            this.DgvColXx.Width = 80;
            // 
            // DgvColSljgid
            // 
            this.DgvColSljgid.DataPropertyName = "sljgid";
            this.DgvColSljgid.HeaderText = "受理机构ID";
            this.DgvColSljgid.Name = "DgvColSljgid";
            this.DgvColSljgid.Visible = false;
            // 
            // DgvColTxtZzl
            // 
            this.DgvColTxtZzl.DataPropertyName = "zzl";
            this.DgvColTxtZzl.HeaderText = "总重量";
            this.DgvColTxtZzl.Name = "DgvColTxtZzl";
            // 
            // DgvColTxtZtj
            // 
            this.DgvColTxtZtj.DataPropertyName = "ztj";
            this.DgvColTxtZtj.HeaderText = "总体积";
            this.DgvColTxtZtj.Name = "DgvColTxtZtj";
            // 
            // DgvColTxtJfzl
            // 
            this.DgvColTxtJfzl.DataPropertyName = "jfzl";
            this.DgvColTxtJfzl.HeaderText = "总计费重量";
            this.DgvColTxtJfzl.Name = "DgvColTxtJfzl";
            // 
            // FrmXbYySrTj
            // 
            this.Controls.Add(this.PnlMain);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(791, 425);
            this.Text = "FrmYySrTj";
            this.PnlJgcx.ResumeLayout(false);
            this.PnlTop.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label LblHj;
        private Button BtnClear1;
        private DateTimePicker DtpQrStart;
        private DateTimePicker DtpQrStop;
        private TextBox TxtJg;
        private TextBox TxtJgmc;
        private ComboBox CmbYwqy;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExl;
        private Button BtnSave;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label1;
        private ListView LstV;
        private Panel PnlJgcx;
        private Panel PnlTop;
        private Panel PnlMain;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtjzjg;
        private DataGridViewTextBoxColumn DgvColTxtywqy;
        private DataGridViewTextBoxColumn DgvColTxtyf;
        private DataGridViewTextBoxColumn DgvColTxtbf;
        private DataGridViewTextBoxColumn DgvColTxtjehj;
        private DataGridViewLinkColumn DgvColXx;
        private DataGridViewTextBoxColumn DgvColSljgid;
        private DataGridViewTextBoxColumn DgvColTxtZzl;
        private DataGridViewTextBoxColumn DgvColTxtZtj;
        private DataGridViewTextBoxColumn DgvColTxtJfzl;




    }
}