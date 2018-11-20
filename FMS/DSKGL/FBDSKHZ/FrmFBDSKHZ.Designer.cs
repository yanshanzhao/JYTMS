using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.FBDSKHZ
{
    partial class FrmFBDSKHZ
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnJg = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.TxtBJgmc = new Gizmox.WebGUI.Forms.TextBox();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.PlnMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtdsk = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtffje = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtsxf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtyswfdsk = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtwqsdsk = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtsljgid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSFBDSKHZ1 = new FMS.DSKGL.FBDSKHZ.DSFBDSKHZ();
            this.Vfmsfbdskhz1TableAdapter1 = new FMS.DSKGL.FBDSKHZ.DSFBDSKHZTableAdapters.Vfmsfbdskhz1TableAdapter();
            this.PnlTop.SuspendLayout();
            this.PlnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSFBDSKHZ1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnExl);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnJg);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.label3);
            this.PnlTop.Controls.Add(this.BtnSave);
            this.PnlTop.Controls.Add(this.TxtBJgmc);
            this.PnlTop.Controls.Add(this.DtpStart);
            this.PnlTop.Controls.Add(this.DtpStop);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(765, 72);
            this.PnlTop.TabIndex = 0;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(128, 41);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 5;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(516, 44);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 18;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnJg
            // 
            this.BtnJg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnJg.CustomStyle = "F";
            this.BtnJg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnJg.Location = new System.Drawing.Point(208, 14);
            this.BtnJg.Name = "BtnJg";
            this.BtnJg.Size = new System.Drawing.Size(24, 21);
            this.BtnJg.TabIndex = 1;
            this.BtnJg.Text = "》";
            this.BtnJg.Click += new System.EventHandler(this.BtnJg_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "起始时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(438, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "结束时间";
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(15, 41);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "查询";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
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
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Checked = false;
            this.DtpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(296, 14);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(134, 21);
            this.DtpStart.TabIndex = 2;
            // 
            // DtpStop
            // 
            this.DtpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStop.Checked = false;
            this.DtpStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStop.CustomFormat = "yyyy.MM.dd";
            this.DtpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStop.Location = new System.Drawing.Point(493, 14);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.Size = new System.Drawing.Size(134, 21);
            this.DtpStop.TabIndex = 3;
            // 
            // PlnMain
            // 
            this.PlnMain.Controls.Add(this.Dgv);
            this.PlnMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PlnMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlnMain.Location = new System.Drawing.Point(0, 72);
            this.PlnMain.Name = "PlnMain";
            this.PlnMain.Size = new System.Drawing.Size(765, 552);
            this.PlnMain.TabIndex = 1;
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
            this.DgvColTxtsj,
            this.DgvColTxtdsk,
            this.DgvColTxtffje,
            this.DgvColTxtsxf,
            this.DgvColTxtyswfdsk,
            this.DgvColTxtwqsdsk,
            this.DgvColTxtsljgid});
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle10.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle10;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.ItemsPerPage = 40;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(765, 552);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellMouseDown += new Gizmox.WebGUI.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseDown);
            // 
            // DgvColTxtsj
            // 
            this.DgvColTxtsj.DataPropertyName = "sj";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtsj.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtsj.HeaderText = "日期";
            this.DgvColTxtsj.Name = "DgvColTxtsj";
            this.DgvColTxtsj.ReadOnly = true;
            this.DgvColTxtsj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtdsk
            // 
            this.DgvColTxtdsk.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtdsk.ClientMode = false;
            this.DgvColTxtdsk.DataPropertyName = "dsk";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtdsk.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtdsk.HeaderText = "本店发生额";
            this.DgvColTxtdsk.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtdsk.Name = "DgvColTxtdsk";
            this.DgvColTxtdsk.ReadOnly = true;
            this.DgvColTxtdsk.TrackVisitedState = false;
            this.DgvColTxtdsk.Url = "";
            this.DgvColTxtdsk.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvColTxtffje
            // 
            this.DgvColTxtffje.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtffje.ClientMode = false;
            this.DgvColTxtffje.DataPropertyName = "ffje";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtffje.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColTxtffje.FillWeight = 110F;
            this.DgvColTxtffje.HeaderText = "总部直接发放金额";
            this.DgvColTxtffje.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtffje.Name = "DgvColTxtffje";
            this.DgvColTxtffje.ReadOnly = true;
            this.DgvColTxtffje.TrackVisitedState = false;
            this.DgvColTxtffje.Url = "";
            this.DgvColTxtffje.VisitedLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtffje.Width = 110;
            // 
            // DgvColTxtsxf
            // 
            this.DgvColTxtsxf.DataPropertyName = "sxf";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtsxf.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvColTxtsxf.FillWeight = 120F;
            this.DgvColTxtsxf.HeaderText = "直接发放手续费";
            this.DgvColTxtsxf.Name = "DgvColTxtsxf";
            this.DgvColTxtsxf.ReadOnly = true;
            this.DgvColTxtsxf.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtsxf.Width = 120;
            // 
            // DgvColTxtyswfdsk
            // 
            this.DgvColTxtyswfdsk.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtyswfdsk.ClientMode = false;
            this.DgvColTxtyswfdsk.DataPropertyName = "yswfdsk";
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtyswfdsk.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvColTxtyswfdsk.FillWeight = 140F;
            this.DgvColTxtyswfdsk.HeaderText = "已签收未发放代收款";
            this.DgvColTxtyswfdsk.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtyswfdsk.Name = "DgvColTxtyswfdsk";
            this.DgvColTxtyswfdsk.ReadOnly = true;
            this.DgvColTxtyswfdsk.TrackVisitedState = false;
            this.DgvColTxtyswfdsk.Url = "";
            this.DgvColTxtyswfdsk.Visible = false;
            this.DgvColTxtyswfdsk.VisitedLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtyswfdsk.Width = 140;
            // 
            // DgvColTxtwqsdsk
            // 
            this.DgvColTxtwqsdsk.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtwqsdsk.ClientMode = false;
            this.DgvColTxtwqsdsk.DataPropertyName = "wqsdsk";
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtwqsdsk.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvColTxtwqsdsk.HeaderText = "未签收代收款";
            this.DgvColTxtwqsdsk.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtwqsdsk.Name = "DgvColTxtwqsdsk";
            this.DgvColTxtwqsdsk.ReadOnly = true;
            this.DgvColTxtwqsdsk.TrackVisitedState = false;
            this.DgvColTxtwqsdsk.Url = "";
            this.DgvColTxtwqsdsk.Visible = false;
            this.DgvColTxtwqsdsk.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvColTxtsljgid
            // 
            this.DgvColTxtsljgid.DataPropertyName = "sljgid";
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtsljgid.DefaultCellStyle = dataGridViewCellStyle9;
            this.DgvColTxtsljgid.HeaderText = "sljgid[隐藏]";
            this.DgvColTxtsljgid.Name = "DgvColTxtsljgid";
            this.DgvColTxtsljgid.ReadOnly = true;
            this.DgvColTxtsljgid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtsljgid.Visible = false;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsfbdskhz1";
            this.Bds.DataSource = this.DSFBDSKHZ1;
            // 
            // DSFBDSKHZ1
            // 
            this.DSFBDSKHZ1.DataSetName = "DSFBDSKHZ";
            this.DSFBDSKHZ1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Vfmsfbdskhz1TableAdapter1
            // 
            this.Vfmsfbdskhz1TableAdapter1.ClearBeforeFill = true;
            // 
            // FrmFBDSKHZ
            // 
            this.Controls.Add(this.PlnMain);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(765, 624);
            this.Text = "FrmFBDSKHZ";
            this.PnlTop.ResumeLayout(false);
            this.PlnMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSFBDSKHZ1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private Panel PlnMain;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button BtnSave;
        private TextBox TxtBJgmc;
        private DateTimePicker DtpStart;
        private DateTimePicker DtpStop;
        private Button BtnJg;
        private DSFBDSKHZ DSFBDSKHZ1;
        private DSFBDSKHZTableAdapters.Vfmsfbdskhz1TableAdapter Vfmsfbdskhz1TableAdapter1;
        private BindingSource Bds;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtsj;
        private DataGridViewTextBoxColumn DgvColTxtsxf;
        private DataGridViewTextBoxColumn DgvColTxtsljgid;
        private DataGridViewLinkColumn DgvColTxtdsk;
        private DataGridViewLinkColumn DgvColTxtffje;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private DataGridViewLinkColumn DgvColTxtyswfdsk;
        private DataGridViewLinkColumn DgvColTxtwqsdsk;


    }
}