using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.ZZHQRJKD.TZFGBFJKRB
{
    partial class FrmTZFGBFJKMX
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

        #region Visual WebGui Form Designer generated code

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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.LblSum = new Gizmox.WebGUI.Forms.Label();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnJk = new Gizmox.WebGUI.Forms.Button();
            this.LblJsrq = new Gizmox.WebGUI.Forms.Label();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.LblKsrq = new Gizmox.WebGUI.Forms.Label();
            this.CmbLx = new Gizmox.WebGUI.Forms.ComboBox();
            this.LblYwqy = new Gizmox.WebGUI.Forms.Label();
            this.BtnSearch = new Gizmox.WebGUI.Forms.Button();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.Pnl = new Gizmox.WebGUI.Forms.Panel();
            this.ChkQx = new Gizmox.WebGUI.Forms.CheckBox();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtQx = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.DgvColTxtBh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtLx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJe = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJzsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtLxid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJgid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtId = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYdtzid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtKhid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.Dstfmsxtsr1 = new FMS.CWGL.ZZHQRJKD.TZFGBFJKRB.DSTFMSXTSR();
            this.dataGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            this.VfmsxtsrTableAdapter1 = new FMS.CWGL.ZZHQRJKD.TZFGBFJKRB.DSTFMSXTSRTableAdapters.vfmsxtsrTableAdapter();
            this.PnlBtns.SuspendLayout();
            this.Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dstfmsxtsr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblSum
            // 
            this.LblSum.BackColor = System.Drawing.SystemColors.Window;
            this.LblSum.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblSum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSum.ForeColor = System.Drawing.Color.Blue;
            this.LblSum.Location = new System.Drawing.Point(297, 46);
            this.LblSum.Name = "LblSum";
            this.LblSum.Size = new System.Drawing.Size(180, 21);
            this.LblSum.TabIndex = 18;
            this.LblSum.Text = "共选中0行，应存0.00元";
            this.LblSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(200, 46);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 10;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(505, 44);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 19;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnJk
            // 
            this.BtnJk.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnJk.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnJk.CustomStyle = "F";
            this.BtnJk.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJk.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnJk.Location = new System.Drawing.Point(107, 46);
            this.BtnJk.Name = "BtnJk";
            this.BtnJk.Size = new System.Drawing.Size(75, 23);
            this.BtnJk.TabIndex = 9;
            this.BtnJk.Text = "缴款";
            this.BtnJk.Click += new System.EventHandler(this.BtnJk_Click);
            // 
            // LblJsrq
            // 
            this.LblJsrq.AutoSize = true;
            this.LblJsrq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJsrq.Location = new System.Drawing.Point(362, 14);
            this.LblJsrq.Name = "LblJsrq";
            this.LblJsrq.Size = new System.Drawing.Size(53, 12);
            this.LblJsrq.TabIndex = 0;
            this.LblJsrq.Text = "结束日期";
            // 
            // DtpStop
            // 
            this.DtpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStop.Checked = false;
            this.DtpStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStop.CustomFormat = "yyyy.MM.dd";
            this.DtpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStop.Location = new System.Drawing.Point(415, 10);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.ShowCheckBox = true;
            this.DtpStop.Size = new System.Drawing.Size(130, 21);
            this.DtpStop.TabIndex = 7;
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Checked = false;
            this.DtpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(221, 8);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.ShowCheckBox = true;
            this.DtpStart.Size = new System.Drawing.Size(130, 21);
            this.DtpStart.TabIndex = 6;
            // 
            // LblKsrq
            // 
            this.LblKsrq.AutoSize = true;
            this.LblKsrq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblKsrq.Location = new System.Drawing.Point(167, 12);
            this.LblKsrq.Name = "LblKsrq";
            this.LblKsrq.Size = new System.Drawing.Size(53, 12);
            this.LblKsrq.TabIndex = 0;
            this.LblKsrq.Text = "开始日期";
            // 
            // CmbLx
            // 
            this.CmbLx.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.CmbLx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbLx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLx.FormattingEnabled = true;
            this.CmbLx.Location = new System.Drawing.Point(53, 8);
            this.CmbLx.Name = "CmbLx";
            this.CmbLx.Size = new System.Drawing.Size(98, 20);
            this.CmbLx.TabIndex = 0;
            // 
            // LblYwqy
            // 
            this.LblYwqy.AutoSize = true;
            this.LblYwqy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYwqy.Location = new System.Drawing.Point(12, 12);
            this.LblYwqy.Name = "LblYwqy";
            this.LblYwqy.Size = new System.Drawing.Size(53, 12);
            this.LblYwqy.TabIndex = 0;
            this.LblYwqy.Text = "类型";
            // 
            // BtnSearch
            // 
            this.BtnSearch.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnSearch.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSearch.CustomStyle = "F";
            this.BtnSearch.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(14, 46);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 8;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.LblSum);
            this.PnlBtns.Controls.Add(this.BtnExl);
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.BtnJk);
            this.PnlBtns.Controls.Add(this.LblJsrq);
            this.PnlBtns.Controls.Add(this.DtpStop);
            this.PnlBtns.Controls.Add(this.DtpStart);
            this.PnlBtns.Controls.Add(this.LblKsrq);
            this.PnlBtns.Controls.Add(this.CmbLx);
            this.PnlBtns.Controls.Add(this.LblYwqy);
            this.PnlBtns.Controls.Add(this.BtnSearch);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(726, 82);
            this.PnlBtns.TabIndex = 0;
            // 
            // Pnl
            // 
            this.Pnl.Controls.Add(this.ChkQx);
            this.Pnl.Controls.Add(this.Dgv);
            this.Pnl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Pnl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pnl.Location = new System.Drawing.Point(0, 82);
            this.Pnl.Name = "Pnl";
            this.Pnl.Size = new System.Drawing.Size(726, 517);
            this.Pnl.TabIndex = 1;
            // 
            // ChkQx
            // 
            this.ChkQx.AutoSize = true;
            this.ChkQx.Location = new System.Drawing.Point(59, 5);
            this.ChkQx.Name = "ChkQx";
            this.ChkQx.Size = new System.Drawing.Size(15, 14);
            this.ChkQx.TabIndex = 2;
            this.ChkQx.CheckedChanged += new System.EventHandler(this.ChkQx_CheckedChanged);
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
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
            this.DgvColTxtQx,
            this.DgvColTxtBh,
            this.DgvColTxtLx,
            this.DgvColTxtJe,
            this.DgvColTxtJzsj,
            this.DgvColTxtLxid,
            this.DgvColTxtJgid,
            this.DgvColTxtId,
            this.DgvColTxtYdtzid,
            this.DgvColTxtKhid});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(726, 517);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // DgvColTxtQx
            // 
            this.DgvColTxtQx.HeaderText = "全选";
            this.DgvColTxtQx.Name = "DgvColTxtQx";
            this.DgvColTxtQx.ReadOnly = true;
            this.DgvColTxtQx.Width = 65;
            // 
            // DgvColTxtBh
            // 
            this.DgvColTxtBh.DataPropertyName = "bh";
            this.DgvColTxtBh.HeaderText = "编号";
            this.DgvColTxtBh.Name = "DgvColTxtBh";
            // 
            // DgvColTxtLx
            // 
            this.DgvColTxtLx.DataPropertyName = "lxbhs";
            this.DgvColTxtLx.HeaderText = "类型";
            this.DgvColTxtLx.Name = "DgvColTxtLx";
            // 
            // DgvColTxtJe
            // 
            this.DgvColTxtJe.DataPropertyName = "je";
            this.DgvColTxtJe.HeaderText = "金额";
            this.DgvColTxtJe.Name = "DgvColTxtJe";
            // 
            // DgvColTxtJzsj
            // 
            this.DgvColTxtJzsj.DataPropertyName = "inssj";
            this.DgvColTxtJzsj.HeaderText = "记账时间";
            this.DgvColTxtJzsj.Name = "DgvColTxtJzsj";
            // 
            // DgvColTxtLxid
            // 
            this.DgvColTxtLxid.DataPropertyName = "lxid";
            this.DgvColTxtLxid.HeaderText = "lxid";
            this.DgvColTxtLxid.Name = "DgvColTxtLxid";
            this.DgvColTxtLxid.Visible = false;
            // 
            // DgvColTxtJgid
            // 
            this.DgvColTxtJgid.DataPropertyName = "jgid";
            this.DgvColTxtJgid.HeaderText = "jgid";
            this.DgvColTxtJgid.Name = "DgvColTxtJgid";
            this.DgvColTxtJgid.Visible = false;
            // 
            // DgvColTxtId
            // 
            this.DgvColTxtId.DataPropertyName = "id";
            this.DgvColTxtId.HeaderText = "id";
            this.DgvColTxtId.Name = "DgvColTxtId";
            this.DgvColTxtId.Visible = false;
            // 
            // DgvColTxtYdtzid
            // 
            this.DgvColTxtYdtzid.DataPropertyName = "ydtzid";
            this.DgvColTxtYdtzid.HeaderText = "ydtzid";
            this.DgvColTxtYdtzid.Name = "DgvColTxtYdtzid";
            this.DgvColTxtYdtzid.Visible = false;
            // 
            // DgvColTxtKhid
            // 
            this.DgvColTxtKhid.DataPropertyName = "khid";
            this.DgvColTxtKhid.HeaderText = "khid";
            this.DgvColTxtKhid.Name = "DgvColTxtKhid";
            this.DgvColTxtKhid.Visible = false;
            // 
            // Bds
            // 
            this.Bds.DataMember = "vfmsxtsr";
            this.Bds.DataSource = this.Dstfmsxtsr1;
            // 
            // Dstfmsxtsr1
            // 
            this.Dstfmsxtsr1.DataSetName = "DSTFMSXTSR";
            this.Dstfmsxtsr1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrag = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.dataGridView1.DataSource = this.Bds;
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.dataGridView1.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(726, 500);
            this.dataGridView1.TabIndex = 1;
            // 
            // VfmsxtsrTableAdapter1
            // 
            this.VfmsxtsrTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmTZFGBFJKMX
            // 
            this.Controls.Add(this.Pnl);
            this.Controls.Add(this.PnlBtns);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(726, 599);
            this.Text = "缴款明细";
            this.PnlBtns.ResumeLayout(false);
            this.Pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dstfmsxtsr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label LblSum;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnJk;
        private Label LblJsrq;
        private DateTimePicker DtpStop;
        private DateTimePicker DtpStart;
        private Label LblKsrq;
        private ComboBox CmbLx;
        private Label LblYwqy;
        private Button BtnSearch;
        private Panel PnlBtns;
        private Panel Pnl;
        private DataGridView Dgv;
        private DataGridView dataGridView1;
        private BindingSource Bds;
        private CheckBox ChkQx;
        private DataGridViewCheckBoxColumn DgvColTxtQx;
        private DataGridViewTextBoxColumn DgvColTxtBh;
        private DataGridViewTextBoxColumn DgvColTxtLx;
        private DataGridViewTextBoxColumn DgvColTxtJe;
        private DataGridViewTextBoxColumn DgvColTxtJzsj;
        private DataGridViewTextBoxColumn DgvColTxtLxid;
        private DataGridViewTextBoxColumn DgvColTxtJgid;
        private DataGridViewTextBoxColumn DgvColTxtId;
        private DataGridViewTextBoxColumn DgvColTxtYdtzid;
        private DataGridViewTextBoxColumn DgvColTxtKhid;
        private DSTFMSXTSR Dstfmsxtsr1;
        private DSTFMSXTSRTableAdapters.vfmsxtsrTableAdapter VfmsxtsrTableAdapter1;
    }
}