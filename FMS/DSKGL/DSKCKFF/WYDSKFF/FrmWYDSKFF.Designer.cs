using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKCKFF.WYDSKFF
{
    partial class FrmWYDSKFF
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.CmbDcgs = new Gizmox.WebGUI.Forms.ComboBox();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnSearch = new Gizmox.WebGUI.Forms.Button();
            this.LblQssj = new Gizmox.WebGUI.Forms.Label();
            this.DtpDkStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpDkStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.CmbZt = new Gizmox.WebGUI.Forms.ComboBox();
            this.CmbYhlx = new Gizmox.WebGUI.Forms.ComboBox();
            this.LblZffs = new Gizmox.WebGUI.Forms.Label();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.DtpFfStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpFfStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.LblSlsj = new Gizmox.WebGUI.Forms.Label();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtXh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSfje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSxf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtBs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYhlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtFfsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtDksj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZts = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtXx = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtCz = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtId = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtFkfs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYhlxid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtFfyhlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSwydskff1 = new FMS.DSKGL.DSKCKFF.WYDSKFF.DSWYDSKFF();
            this.VfmswydskffTableAdapter1 = new FMS.DSKGL.DSKCKFF.WYDSKFF.DSWYDSKFFTableAdapters.VfmswydskffTableAdapter();
            this.VfmswydskffmxTableAdapter1 = new FMS.DSKGL.DSKCKFF.WYDSKFF.DSWYDSKFFTableAdapters.VfmswydskffmxTableAdapter();
            this.Vfmswydskffmx_zxhwTableAdapter1 = new FMS.DSKGL.DSKCKFF.WYDSKFF.DSWYDSKFFTableAdapters.Vfmswydskffmx_zxhwTableAdapter();
            this.PnlBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSwydskff1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.label2);
            this.PnlBtns.Controls.Add(this.CmbDcgs);
            this.PnlBtns.Controls.Add(this.BtnExl);
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.BtnSearch);
            this.PnlBtns.Controls.Add(this.LblQssj);
            this.PnlBtns.Controls.Add(this.DtpDkStart);
            this.PnlBtns.Controls.Add(this.DtpDkStop);
            this.PnlBtns.Controls.Add(this.label1);
            this.PnlBtns.Controls.Add(this.label3);
            this.PnlBtns.Controls.Add(this.CmbZt);
            this.PnlBtns.Controls.Add(this.CmbYhlx);
            this.PnlBtns.Controls.Add(this.LblZffs);
            this.PnlBtns.Controls.Add(this.label10);
            this.PnlBtns.Controls.Add(this.DtpFfStop);
            this.PnlBtns.Controls.Add(this.DtpFfStart);
            this.PnlBtns.Controls.Add(this.LblSlsj);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(1067, 87);
            this.PnlBtns.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(381, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "导出格式";
            // 
            // CmbDcgs
            // 
            this.CmbDcgs.AllowDrag = false;
            this.CmbDcgs.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.CmbDcgs.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbDcgs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDcgs.FormattingEnabled = true;
            this.CmbDcgs.Location = new System.Drawing.Point(435, 33);
            this.CmbDcgs.Name = "CmbDcgs";
            this.CmbDcgs.Size = new System.Drawing.Size(121, 20);
            this.CmbDcgs.TabIndex = 6;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(104, 61);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 8;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(201, 61);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(75, 23);
            this.ctrlDownLoad1.TabIndex = 4;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnSearch
            // 
            this.BtnSearch.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnSearch.CustomStyle = "F";
            this.BtnSearch.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(22, 61);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 7;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // LblQssj
            // 
            this.LblQssj.AutoSize = true;
            this.LblQssj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblQssj.Location = new System.Drawing.Point(20, 37);
            this.LblQssj.Name = "LblQssj";
            this.LblQssj.Size = new System.Drawing.Size(53, 12);
            this.LblQssj.TabIndex = 0;
            this.LblQssj.Text = "打款日期";
            // 
            // DtpDkStart
            // 
            this.DtpDkStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpDkStart.Checked = false;
            this.DtpDkStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpDkStart.CustomFormat = "yyyy.MM.dd";
            this.DtpDkStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDkStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpDkStart.Location = new System.Drawing.Point(98, 33);
            this.DtpDkStart.Name = "DtpDkStart";
            this.DtpDkStart.ShowCheckBox = true;
            this.DtpDkStart.Size = new System.Drawing.Size(130, 21);
            this.DtpDkStart.TabIndex = 4;
            // 
            // DtpDkStop
            // 
            this.DtpDkStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpDkStop.Checked = false;
            this.DtpDkStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpDkStop.CustomFormat = "yyyy.MM.dd";
            this.DtpDkStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDkStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpDkStop.Location = new System.Drawing.Point(245, 33);
            this.DtpDkStop.Name = "DtpDkStop";
            this.DtpDkStop.ShowCheckBox = true;
            this.DtpDkStop.Size = new System.Drawing.Size(130, 21);
            this.DtpDkStop.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(228, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "一";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(559, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "状态";
            // 
            // CmbZt
            // 
            this.CmbZt.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.CmbZt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbZt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbZt.FormattingEnabled = true;
            this.CmbZt.Items.AddRange(new object[] {
            "未打款",
            "已打款",
            "全部"});
            this.CmbZt.Location = new System.Drawing.Point(590, 5);
            this.CmbZt.Name = "CmbZt";
            this.CmbZt.Size = new System.Drawing.Size(121, 20);
            this.CmbZt.TabIndex = 3;
            // 
            // CmbYhlx
            // 
            this.CmbYhlx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbYhlx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYhlx.FormattingEnabled = true;
            this.CmbYhlx.Items.AddRange(new object[] {
            "建行",
            "农行",
            "齐鲁银行",
            "全部"});
            this.CmbYhlx.Location = new System.Drawing.Point(435, 6);
            this.CmbYhlx.Name = "CmbYhlx";
            this.CmbYhlx.Size = new System.Drawing.Size(121, 20);
            this.CmbYhlx.TabIndex = 2;
            // 
            // LblZffs
            // 
            this.LblZffs.AutoSize = true;
            this.LblZffs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZffs.Location = new System.Drawing.Point(382, 10);
            this.LblZffs.Name = "LblZffs";
            this.LblZffs.Size = new System.Drawing.Size(53, 12);
            this.LblZffs.TabIndex = 0;
            this.LblZffs.Text = "银行类型";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(228, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "一";
            // 
            // DtpFfStop
            // 
            this.DtpFfStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpFfStop.Checked = false;
            this.DtpFfStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpFfStop.CustomFormat = "yyyy.MM.dd";
            this.DtpFfStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFfStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpFfStop.Location = new System.Drawing.Point(245, 6);
            this.DtpFfStop.Name = "DtpFfStop";
            this.DtpFfStop.ShowCheckBox = true;
            this.DtpFfStop.Size = new System.Drawing.Size(130, 21);
            this.DtpFfStop.TabIndex = 1;
            // 
            // DtpFfStart
            // 
            this.DtpFfStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpFfStart.Checked = false;
            this.DtpFfStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpFfStart.CustomFormat = "yyyy.MM.dd";
            this.DtpFfStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFfStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpFfStart.Location = new System.Drawing.Point(98, 6);
            this.DtpFfStart.Name = "DtpFfStart";
            this.DtpFfStart.ShowCheckBox = true;
            this.DtpFfStart.Size = new System.Drawing.Size(130, 21);
            this.DtpFfStart.TabIndex = 0;
            // 
            // LblSlsj
            // 
            this.LblSlsj.AutoSize = true;
            this.LblSlsj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSlsj.Location = new System.Drawing.Point(20, 10);
            this.LblSlsj.Name = "LblSlsj";
            this.LblSlsj.Size = new System.Drawing.Size(53, 12);
            this.LblSlsj.TabIndex = 0;
            this.LblSlsj.Text = "系统发放日期";
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.AutoGenerateColumns = false;
            this.Dgv.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
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
            this.DgvColTxtSfje,
            this.DgvColTxtSxf,
            this.DgvColTxtZje,
            this.DgvColTxtBs,
            this.DgvColTxtYhlx,
            this.DgvColTxtFfsj,
            this.DgvColTxtDksj,
            this.DgvColTxtZts,
            this.DgvColTxtXx,
            this.DgvColTxtCz,
            this.DgvColTxtId,
            this.DgvColTxtFkfs,
            this.DgvColTxtYhlxid,
            this.DgvColTxtZt,
            this.DgvColTxtFfyhlx});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 87);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(1067, 402);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // DgvColTxtXh
            // 
            this.DgvColTxtXh.HeaderText = "编号";
            this.DgvColTxtXh.Name = "DgvColTxtXh";
            this.DgvColTxtXh.ReadOnly = true;
            this.DgvColTxtXh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtSfje
            // 
            this.DgvColTxtSfje.DataPropertyName = "sfje";
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtSfje.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColTxtSfje.HeaderText = "发放金额";
            this.DgvColTxtSfje.Name = "DgvColTxtSfje";
            this.DgvColTxtSfje.ReadOnly = true;
            this.DgvColTxtSfje.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtSxf
            // 
            this.DgvColTxtSxf.DataPropertyName = "sxf";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtSxf.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtSxf.HeaderText = "手续费";
            this.DgvColTxtSxf.Name = "DgvColTxtSxf";
            this.DgvColTxtSxf.ReadOnly = true;
            this.DgvColTxtSxf.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtZje
            // 
            this.DgvColTxtZje.DataPropertyName = "je";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtZje.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtZje.HeaderText = "总金额";
            this.DgvColTxtZje.Name = "DgvColTxtZje";
            this.DgvColTxtZje.ReadOnly = true;
            this.DgvColTxtZje.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtBs
            // 
            this.DgvColTxtBs.DataPropertyName = "bs";
            this.DgvColTxtBs.HeaderText = "笔数";
            this.DgvColTxtBs.Name = "DgvColTxtBs";
            this.DgvColTxtBs.ReadOnly = true;
            this.DgvColTxtBs.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtYhlx
            // 
            this.DgvColTxtYhlx.DataPropertyName = "yhlx";
            this.DgvColTxtYhlx.HeaderText = "银行类型";
            this.DgvColTxtYhlx.Name = "DgvColTxtYhlx";
            this.DgvColTxtYhlx.ReadOnly = true;
            this.DgvColTxtYhlx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtFfsj
            // 
            this.DgvColTxtFfsj.DataPropertyName = "ffsj";
            this.DgvColTxtFfsj.HeaderText = "系统发放日期";
            this.DgvColTxtFfsj.Name = "DgvColTxtFfsj";
            this.DgvColTxtFfsj.ReadOnly = true;
            this.DgvColTxtFfsj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtDksj
            // 
            this.DgvColTxtDksj.DataPropertyName = "dksj";
            this.DgvColTxtDksj.HeaderText = "打款日期";
            this.DgvColTxtDksj.Name = "DgvColTxtDksj";
            this.DgvColTxtDksj.ReadOnly = true;
            this.DgvColTxtDksj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtZts
            // 
            this.DgvColTxtZts.DataPropertyName = "zts";
            this.DgvColTxtZts.HeaderText = "状态";
            this.DgvColTxtZts.Name = "DgvColTxtZts";
            this.DgvColTxtZts.ReadOnly = true;
            this.DgvColTxtZts.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtXx
            // 
            this.DgvColTxtXx.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtXx.ClientMode = false;
            this.DgvColTxtXx.DataPropertyName = "xx";
            this.DgvColTxtXx.HeaderText = "详细";
            this.DgvColTxtXx.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvColTxtXx.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtXx.Name = "DgvColTxtXx";
            this.DgvColTxtXx.ReadOnly = true;
            this.DgvColTxtXx.TrackVisitedState = false;
            this.DgvColTxtXx.Url = "";
            this.DgvColTxtXx.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvColTxtCz
            // 
            this.DgvColTxtCz.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtCz.ClientMode = false;
            this.DgvColTxtCz.DataPropertyName = "cz";
            this.DgvColTxtCz.HeaderText = "操作";
            this.DgvColTxtCz.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvColTxtCz.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtCz.Name = "DgvColTxtCz";
            this.DgvColTxtCz.ReadOnly = true;
            this.DgvColTxtCz.TrackVisitedState = false;
            this.DgvColTxtCz.Url = "";
            this.DgvColTxtCz.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvColTxtId
            // 
            this.DgvColTxtId.DataPropertyName = "id";
            this.DgvColTxtId.HeaderText = "Pcid[隐藏]";
            this.DgvColTxtId.Name = "DgvColTxtId";
            this.DgvColTxtId.ReadOnly = true;
            this.DgvColTxtId.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtId.Visible = false;
            // 
            // DgvColTxtFkfs
            // 
            this.DgvColTxtFkfs.DataPropertyName = "fkfs";
            this.DgvColTxtFkfs.HeaderText = "fkfs[隐藏]";
            this.DgvColTxtFkfs.Name = "DgvColTxtFkfs";
            this.DgvColTxtFkfs.ReadOnly = true;
            this.DgvColTxtFkfs.Visible = false;
            // 
            // DgvColTxtYhlxid
            // 
            this.DgvColTxtYhlxid.DataPropertyName = "yhlxid";
            this.DgvColTxtYhlxid.HeaderText = "Yhlxid[隐藏]";
            this.DgvColTxtYhlxid.Name = "DgvColTxtYhlxid";
            this.DgvColTxtYhlxid.ReadOnly = true;
            this.DgvColTxtYhlxid.Visible = false;
            // 
            // DgvColTxtZt
            // 
            this.DgvColTxtZt.DataPropertyName = "zt";
            this.DgvColTxtZt.HeaderText = "Zt[隐藏]";
            this.DgvColTxtZt.Name = "DgvColTxtZt";
            this.DgvColTxtZt.ReadOnly = true;
            this.DgvColTxtZt.Visible = false;
            // 
            // DgvColTxtFfyhlx
            // 
            this.DgvColTxtFfyhlx.DataPropertyName = "ffyhlx";
            this.DgvColTxtFfyhlx.HeaderText = "发放银行类型";
            this.DgvColTxtFfyhlx.Name = "DgvColTxtFfyhlx";
            this.DgvColTxtFfyhlx.ReadOnly = true;
            this.DgvColTxtFfyhlx.Visible = false;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmswydskff";
            this.Bds.DataSource = this.DSwydskff1;
            // 
            // DSwydskff1
            // 
            this.DSwydskff1.DataSetName = "DSWYDSKFF";
            this.DSwydskff1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmswydskffTableAdapter1
            // 
            this.VfmswydskffTableAdapter1.ClearBeforeFill = true;
            // 
            // VfmswydskffmxTableAdapter1
            // 
            this.VfmswydskffmxTableAdapter1.ClearBeforeFill = true;
            // 
            // Vfmswydskffmx_zxhwTableAdapter1
            // 
            this.Vfmswydskffmx_zxhwTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmWYDSKFF
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlBtns);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(1067, 489);
            this.Text = "总部代收款发放";
            this.PnlBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSwydskff1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlBtns;
        private Label label10;
        private DateTimePicker DtpFfStop;
        private DateTimePicker DtpFfStart;
        private Label LblSlsj;
        private ComboBox CmbYhlx;
        private Label LblZffs;
        private Label LblQssj;
        private DateTimePicker DtpDkStart;
        private DateTimePicker DtpDkStop;
        private Label label1;
        private Label label3;
        private ComboBox CmbZt;
        private Button BtnSearch;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtXh;
        private DataGridViewTextBoxColumn DgvColTxtSfje;
        private DataGridViewTextBoxColumn DgvColTxtBs;
        private DataGridViewTextBoxColumn DgvColTxtYhlx;
        private DataGridViewTextBoxColumn DgvColTxtFfsj;
        private DataGridViewTextBoxColumn DgvColTxtDksj;
        private DataGridViewTextBoxColumn DgvColTxtZts;
        private DataGridViewTextBoxColumn DgvColTxtSxf;
        private BindingSource Bds;
        private DataGridViewTextBoxColumn DgvColTxtId;
        private DSWYDSKFF DSwydskff1;
        private DSWYDSKFFTableAdapters.VfmswydskffTableAdapter VfmswydskffTableAdapter1;
        private DataGridViewTextBoxColumn DgvColTxtZje;
        private DataGridViewLinkColumn DgvColTxtXx;
        private DataGridViewLinkColumn DgvColTxtCz;
        private DataGridViewTextBoxColumn DgvColTxtFkfs;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private DSWYDSKFFTableAdapters.VfmswydskffmxTableAdapter VfmswydskffmxTableAdapter1;
        private DataGridViewTextBoxColumn DgvColTxtYhlxid;
        private DataGridViewTextBoxColumn DgvColTxtZt;
        private Button BtnExl;
        private Label label2;
        private ComboBox CmbDcgs;
        private DataGridViewTextBoxColumn DgvColTxtFfyhlx;
        private DSWYDSKFFTableAdapters.Vfmswydskffmx_zxhwTableAdapter Vfmswydskffmx_zxhwTableAdapter1;


    }
}