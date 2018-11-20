using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.ZBDSKHZ
{
    partial class FrmZBDSKHZ
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtrq = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtysdak = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtzdfk = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtsxf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtye = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtwffje = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtyk = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtsxfzj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSZBDSKHZ1 = new FMS.DSKGL.ZBDSKHZ.DSZBDSKHZ();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.TxtBJgmc = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.VfmszbdskhzTableAdapter1 = new FMS.DSKGL.ZBDSKHZ.DSZBDSKHZTableAdapters.VfmszbdskhzTableAdapter();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSZBDSKHZ1)).BeginInit();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 117);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(794, 429);
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
            this.DgvColTxtrq,
            this.DgvColTxtysdak,
            this.DgvColTxtzdfk,
            this.DgvColTxtsxf,
            this.DgvColTxtye,
            this.DgvColTxtwffje,
            this.DgvColTxtyk,
            this.DgvColTxtsxfzj});
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle11.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle11;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.ItemsPerPage = 40;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(794, 429);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellMouseDown += new Gizmox.WebGUI.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseDown);
            // 
            // DgvColTxtrq
            // 
            this.DgvColTxtrq.DataPropertyName = "sj";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtrq.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtrq.FillWeight = 140F;
            this.DgvColTxtrq.HeaderText = "日期";
            this.DgvColTxtrq.Name = "DgvColTxtrq";
            this.DgvColTxtrq.ReadOnly = true;
            this.DgvColTxtrq.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtrq.Width = 140;
            // 
            // DgvColTxtysdak
            // 
            this.DgvColTxtysdak.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtysdak.ClientMode = false;
            this.DgvColTxtysdak.DataPropertyName = "ysdsk";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtysdak.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtysdak.FillWeight = 90F;
            this.DgvColTxtysdak.HeaderText = "已收代收款";
            this.DgvColTxtysdak.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtysdak.Name = "DgvColTxtysdak";
            this.DgvColTxtysdak.ReadOnly = true;
            this.DgvColTxtysdak.TrackVisitedState = false;
            this.DgvColTxtysdak.Url = "";
            this.DgvColTxtysdak.VisitedLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtysdak.Width = 90;
            // 
            // DgvColTxtzdfk
            // 
            this.DgvColTxtzdfk.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtzdfk.ClientMode = false;
            this.DgvColTxtzdfk.DataPropertyName = "zjfk";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtzdfk.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColTxtzdfk.FillWeight = 90F;
            this.DgvColTxtzdfk.HeaderText = "直接发款";
            this.DgvColTxtzdfk.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtzdfk.Name = "DgvColTxtzdfk";
            this.DgvColTxtzdfk.ReadOnly = true;
            this.DgvColTxtzdfk.TrackVisitedState = false;
            this.DgvColTxtzdfk.Url = "";
            this.DgvColTxtzdfk.VisitedLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtzdfk.Width = 90;
            // 
            // DgvColTxtsxf
            // 
            this.DgvColTxtsxf.DataPropertyName = "sxf";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtsxf.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvColTxtsxf.FillWeight = 80F;
            this.DgvColTxtsxf.HeaderText = "手续费";
            this.DgvColTxtsxf.Name = "DgvColTxtsxf";
            this.DgvColTxtsxf.ReadOnly = true;
            this.DgvColTxtsxf.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtsxf.Width = 80;
            // 
            // DgvColTxtye
            // 
            this.DgvColTxtye.DataPropertyName = "ye";
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtye.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvColTxtye.FillWeight = 80F;
            this.DgvColTxtye.HeaderText = "余额";
            this.DgvColTxtye.Name = "DgvColTxtye";
            this.DgvColTxtye.ReadOnly = true;
            this.DgvColTxtye.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtye.Width = 80;
            // 
            // DgvColTxtwffje
            // 
            this.DgvColTxtwffje.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtwffje.ClientMode = false;
            this.DgvColTxtwffje.DataPropertyName = "wffje";
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtwffje.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvColTxtwffje.FillWeight = 90F;
            this.DgvColTxtwffje.HeaderText = "未发代收款";
            this.DgvColTxtwffje.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtwffje.Name = "DgvColTxtwffje";
            this.DgvColTxtwffje.ReadOnly = true;
            this.DgvColTxtwffje.TrackVisitedState = false;
            this.DgvColTxtwffje.Url = "";
            this.DgvColTxtwffje.VisitedLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtwffje.Width = 90;
            // 
            // DgvColTxtyk
            // 
            this.DgvColTxtyk.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtyk.ClientMode = false;
            this.DgvColTxtyk.DataPropertyName = "ykje";
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtyk.DefaultCellStyle = dataGridViewCellStyle9;
            this.DgvColTxtyk.FillWeight = 90F;
            this.DgvColTxtyk.HeaderText = "压款金额";
            this.DgvColTxtyk.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtyk.Name = "DgvColTxtyk";
            this.DgvColTxtyk.ReadOnly = true;
            this.DgvColTxtyk.TrackVisitedState = false;
            this.DgvColTxtyk.Url = "";
            this.DgvColTxtyk.VisitedLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtyk.Width = 90;
            // 
            // DgvColTxtsxfzj
            // 
            this.DgvColTxtsxfzj.DataPropertyName = "sxfzj";
            dataGridViewCellStyle10.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtsxfzj.DefaultCellStyle = dataGridViewCellStyle10;
            this.DgvColTxtsxfzj.FillWeight = 80F;
            this.DgvColTxtsxfzj.HeaderText = "利润";
            this.DgvColTxtsxfzj.Name = "DgvColTxtsxfzj";
            this.DgvColTxtsxfzj.ReadOnly = true;
            this.DgvColTxtsxfzj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtsxfzj.Width = 80;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmszbdskhz";
            this.Bds.DataSource = this.DSZBDSKHZ1;
            // 
            // DSZBDSKHZ1
            // 
            this.DSZBDSKHZ1.DataSetName = "DSZBDSKHZ";
            this.DSZBDSKHZ1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.label4);
            this.PnlTop.Controls.Add(this.label9);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnExl);
            this.PnlTop.Controls.Add(this.DtpStop);
            this.PnlTop.Controls.Add(this.DtpStart);
            this.PnlTop.Controls.Add(this.TxtBJgmc);
            this.PnlTop.Controls.Add(this.BtnSave);
            this.PnlTop.Controls.Add(this.label3);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(794, 117);
            this.PnlTop.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(15, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "*未发代收款金额+压款金额=余额";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Red);
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(15, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(251, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "*已收代收款累计-直接发款累计=余额";
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(525, 41);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 18;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(118, 41);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 4;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // DtpStop
            // 
            this.DtpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStop.Checked = false;
            this.DtpStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStop.CustomFormat = "yyyy.MM.dd";
            this.DtpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStop.Location = new System.Drawing.Point(471, 14);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.Size = new System.Drawing.Size(134, 21);
            this.DtpStop.TabIndex = 2;
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Checked = false;
            this.DtpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(274, 14);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(134, 21);
            this.DtpStart.TabIndex = 1;
            // 
            // TxtBJgmc
            // 
            this.TxtBJgmc.AllowDrag = false;
            this.TxtBJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBJgmc.Location = new System.Drawing.Point(71, 14);
            this.TxtBJgmc.Name = "TxtBJgmc";
            this.TxtBJgmc.ReadOnly = true;
            this.TxtBJgmc.Size = new System.Drawing.Size(134, 21);
            this.TxtBJgmc.TabIndex = 0;
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(17, 41);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "查询";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(416, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "结束时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(218, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "起始时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "机构名称";
            // 
            // VfmszbdskhzTableAdapter1
            // 
            this.VfmszbdskhzTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmZBDSKHZ
            // 
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(794, 546);
            this.Text = "总部代收款汇总";
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSZBDSKHZ1)).EndInit();
            this.PnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlMain;
        private Panel PnlTop;
        private TextBox TxtBJgmc;
        private Button BtnSave;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker DtpStop;
        private DateTimePicker DtpStart;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtrq;
        private DataGridViewTextBoxColumn DgvColTxtsxf;
        private DataGridViewTextBoxColumn DgvColTxtye;
        private BindingSource Bds;
        private DSZBDSKHZ DSZBDSKHZ1;
        private DSZBDSKHZTableAdapters.VfmszbdskhzTableAdapter VfmszbdskhzTableAdapter1;
        private DataGridViewLinkColumn DgvColTxtysdak;
        private DataGridViewLinkColumn DgvColTxtzdfk;
        private DataGridViewLinkColumn DgvColTxtwffje;
        private DataGridViewLinkColumn DgvColTxtyk;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExl;
        private DataGridViewTextBoxColumn DgvColTxtsxfzj;
        private Label label9;
        private Label label4; 


    }
}