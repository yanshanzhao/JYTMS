using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.ZZHQRJKD
{
    partial class FrmJKRB
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtJzlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYwqy = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYwdh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtBf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZyf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.LblSum = new Gizmox.WebGUI.Forms.Label();
            this.BtnClear1 = new Gizmox.WebGUI.Forms.Button();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.LblRowCount = new Gizmox.WebGUI.Forms.Label();
            this.BtnJk = new Gizmox.WebGUI.Forms.Button();
            this.LblJzlx = new Gizmox.WebGUI.Forms.Label();
            this.CmbJzlx = new Gizmox.WebGUI.Forms.ComboBox();
            this.PnlJgcx = new Gizmox.WebGUI.Forms.Panel();
            this.LstV = new Gizmox.WebGUI.Forms.ListView();
            this.CmbSfyc = new Gizmox.WebGUI.Forms.ComboBox();
            this.LblSfyc = new Gizmox.WebGUI.Forms.Label();
            this.LblJsrq = new Gizmox.WebGUI.Forms.Label();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.LblKsrq = new Gizmox.WebGUI.Forms.Label();
            this.CmbYwqy = new Gizmox.WebGUI.Forms.ComboBox();
            this.LblYwqy = new Gizmox.WebGUI.Forms.Label();
            this.BtnSearch = new Gizmox.WebGUI.Forms.Button();
            this.LblJgcx = new Gizmox.WebGUI.Forms.Label();
            this.TxtJg = new Gizmox.WebGUI.Forms.TextBox();
            this.TxtJgmc = new Gizmox.WebGUI.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtJgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSjkrb1 = new FMS.CWGL.ZZHQRJKD.JKRB.DSJKRB();
            this.vfmsjkrbTableAdapter1 = new FMS.CWGL.ZZHQRJKD.JKRB.DSJKRBTableAdapters.VfmsjkrbTableAdapter();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.PnlBtns.SuspendLayout();
            this.PnlJgcx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSjkrb1)).BeginInit();
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
            this.PnlMain.Size = new System.Drawing.Size(897, 517);
            this.PnlMain.TabIndex = 0;
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
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.DgvColTxtYf,
            this.DgvColTxtBf,
            this.DgvColTxtZyf,
            this.DgvColTxtZt});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 93);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(897, 424);
            this.Dgv.TabIndex = 1;
            // 
            // DgvColTxtJzlx
            // 
            this.DgvColTxtJzlx.DataPropertyName = "jzlxs";
            this.DgvColTxtJzlx.Frozen = true;
            this.DgvColTxtJzlx.HeaderText = "记账类型";
            this.DgvColTxtJzlx.Name = "DgvColTxtJzlx";
            this.DgvColTxtJzlx.ReadOnly = true;
            this.DgvColTxtJzlx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtJzlx.Width = 80;
            // 
            // DgvColTxtYwqy
            // 
            this.DgvColTxtYwqy.DataPropertyName = "ywqys";
            this.DgvColTxtYwqy.Frozen = true;
            this.DgvColTxtYwqy.HeaderText = "业务区域";
            this.DgvColTxtYwqy.Name = "DgvColTxtYwqy";
            this.DgvColTxtYwqy.ReadOnly = true;
            this.DgvColTxtYwqy.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtYwqy.Width = 80;
            // 
            // DgvColTxtYwdh
            // 
            this.DgvColTxtYwdh.DataPropertyName = "bh";
            this.DgvColTxtYwdh.Frozen = true;
            this.DgvColTxtYwdh.HeaderText = "业务单号";
            this.DgvColTxtYwdh.Name = "DgvColTxtYwdh";
            this.DgvColTxtYwdh.ReadOnly = true;
            this.DgvColTxtYwdh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtYf
            // 
            this.DgvColTxtYf.DataPropertyName = "yf";
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtYf.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColTxtYf.FillWeight = 80F;
            this.DgvColTxtYf.HeaderText = "运费";
            this.DgvColTxtYf.Name = "DgvColTxtYf";
            this.DgvColTxtYf.ReadOnly = true;
            this.DgvColTxtYf.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtYf.Width = 70;
            // 
            // DgvColTxtBf
            // 
            this.DgvColTxtBf.DataPropertyName = "bf";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtBf.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtBf.FillWeight = 80F;
            this.DgvColTxtBf.HeaderText = "保价费";
            this.DgvColTxtBf.Name = "DgvColTxtBf";
            this.DgvColTxtBf.ReadOnly = true;
            this.DgvColTxtBf.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtBf.Width = 70;
            // 
            // DgvColTxtZyf
            // 
            this.DgvColTxtZyf.DataPropertyName = "zyf";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtZyf.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtZyf.FillWeight = 80F;
            this.DgvColTxtZyf.HeaderText = "总运费";
            this.DgvColTxtZyf.Name = "DgvColTxtZyf";
            this.DgvColTxtZyf.ReadOnly = true;
            this.DgvColTxtZyf.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtZyf.Width = 70;
            // 
            // DgvColTxtZt
            // 
            this.DgvColTxtZt.DataPropertyName = "zts";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtZt.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColTxtZt.HeaderText = "状态";
            this.DgvColTxtZt.Name = "DgvColTxtZt";
            this.DgvColTxtZt.ReadOnly = true;
            this.DgvColTxtZt.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtZt.Width = 70;
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.LblSum);
            this.PnlBtns.Controls.Add(this.BtnClear1);
            this.PnlBtns.Controls.Add(this.BtnExl);
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.LblRowCount);
            this.PnlBtns.Controls.Add(this.BtnJk);
            this.PnlBtns.Controls.Add(this.LblJzlx);
            this.PnlBtns.Controls.Add(this.CmbJzlx);
            this.PnlBtns.Controls.Add(this.PnlJgcx);
            this.PnlBtns.Controls.Add(this.CmbSfyc);
            this.PnlBtns.Controls.Add(this.LblSfyc);
            this.PnlBtns.Controls.Add(this.LblJsrq);
            this.PnlBtns.Controls.Add(this.DtpStop);
            this.PnlBtns.Controls.Add(this.DtpStart);
            this.PnlBtns.Controls.Add(this.LblKsrq);
            this.PnlBtns.Controls.Add(this.CmbYwqy);
            this.PnlBtns.Controls.Add(this.LblYwqy);
            this.PnlBtns.Controls.Add(this.BtnSearch);
            this.PnlBtns.Controls.Add(this.LblJgcx);
            this.PnlBtns.Controls.Add(this.TxtJg);
            this.PnlBtns.Controls.Add(this.TxtJgmc);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(897, 93);
            this.PnlBtns.TabIndex = 0;
            // 
            // LblSum
            // 
            this.LblSum.BackColor = System.Drawing.SystemColors.Window;
            this.LblSum.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblSum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSum.ForeColor = System.Drawing.Color.Blue;
            this.LblSum.Location = new System.Drawing.Point(430, 65);
            this.LblSum.Name = "LblSum";
            this.LblSum.Size = new System.Drawing.Size(180, 21);
            this.LblSum.TabIndex = 18;
            this.LblSum.Text = "已存0.00元  未存0.00元";
            this.LblSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnClear1
            // 
            this.BtnClear1.CustomStyle = "F";
            this.BtnClear1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnClear1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear1.Location = new System.Drawing.Point(250, 35);
            this.BtnClear1.Name = "BtnClear1";
            this.BtnClear1.Size = new System.Drawing.Size(26, 21);
            this.BtnClear1.TabIndex = 5;
            this.BtnClear1.Text = "清";
            this.BtnClear1.Click += new System.EventHandler(this.BtnClear1_Click);
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.SizeNESW;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(200, 63);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 10;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // LblRowCount
            // 
            this.LblRowCount.BackColor = System.Drawing.SystemColors.Window;
            this.LblRowCount.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblRowCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRowCount.ForeColor = System.Drawing.Color.Blue;
            this.LblRowCount.Location = new System.Drawing.Point(322, 65);
            this.LblRowCount.Name = "LblRowCount";
            this.LblRowCount.Size = new System.Drawing.Size(93, 21);
            this.LblRowCount.TabIndex = 18;
            this.LblRowCount.Text = "共有0条数据";
            this.LblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnJk
            // 
            this.BtnJk.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnJk.CustomStyle = "F";
            this.BtnJk.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJk.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnJk.Location = new System.Drawing.Point(107, 63);
            this.BtnJk.Name = "BtnJk";
            this.BtnJk.Size = new System.Drawing.Size(75, 23);
            this.BtnJk.TabIndex = 9;
            this.BtnJk.Text = "缴款";
            this.BtnJk.Click += new System.EventHandler(this.BtnJk_Click);
            // 
            // LblJzlx
            // 
            this.LblJzlx.AutoSize = true;
            this.LblJzlx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJzlx.Location = new System.Drawing.Point(494, 12);
            this.LblJzlx.Name = "LblJzlx";
            this.LblJzlx.Size = new System.Drawing.Size(53, 12);
            this.LblJzlx.TabIndex = 0;
            this.LblJzlx.Text = "记账类型";
            // 
            // CmbJzlx
            // 
            this.CmbJzlx.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.CmbJzlx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbJzlx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbJzlx.FormattingEnabled = true;
            this.CmbJzlx.Items.AddRange(new object[] {
            "全部",
            "发货",
            "到货",
            "账结"});
            this.CmbJzlx.Location = new System.Drawing.Point(548, 9);
            this.CmbJzlx.Name = "CmbJzlx";
            this.CmbJzlx.Size = new System.Drawing.Size(130, 20);
            this.CmbJzlx.TabIndex = 2;
            // 
            // PnlJgcx
            // 
            this.PnlJgcx.Controls.Add(this.LstV);
            this.PnlJgcx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlJgcx.Location = new System.Drawing.Point(66, 58);
            this.PnlJgcx.Name = "PnlJgcx";
            this.PnlJgcx.Size = new System.Drawing.Size(209, 208);
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
            this.LstV.Size = new System.Drawing.Size(209, 208);
            this.LstV.TabIndex = 0;
            this.LstV.KeyUp += new Gizmox.WebGUI.Forms.KeyEventHandler(this.LstV_KeyUp);
            this.LstV.LostFocus += new System.EventHandler(this.LstV_LostFocus);
            this.LstV.DoubleClick += new System.EventHandler(this.LstV_DoubleClick);
            // 
            // CmbSfyc
            // 
            this.CmbSfyc.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.CmbSfyc.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbSfyc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSfyc.FormattingEnabled = true;
            this.CmbSfyc.Items.AddRange(new object[] {
            "全部",
            "否",
            "是"});
            this.CmbSfyc.Location = new System.Drawing.Point(336, 8);
            this.CmbSfyc.Name = "CmbSfyc";
            this.CmbSfyc.Size = new System.Drawing.Size(130, 20);
            this.CmbSfyc.TabIndex = 1;
            // 
            // LblSfyc
            // 
            this.LblSfyc.AutoSize = true;
            this.LblSfyc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSfyc.Location = new System.Drawing.Point(284, 11);
            this.LblSfyc.Name = "LblSfyc";
            this.LblSfyc.Size = new System.Drawing.Size(53, 12);
            this.LblSfyc.TabIndex = 0;
            this.LblSfyc.Text = "是否已存";
            // 
            // LblJsrq
            // 
            this.LblJsrq.AutoSize = true;
            this.LblJsrq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJsrq.Location = new System.Drawing.Point(495, 37);
            this.LblJsrq.Name = "LblJsrq";
            this.LblJsrq.Size = new System.Drawing.Size(53, 12);
            this.LblJsrq.TabIndex = 0;
            this.LblJsrq.Text = "结束日期";
            // 
            // DtpStop
            // 
            this.DtpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStop.CustomFormat = "yyyy.MM.dd";
            this.DtpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStop.Location = new System.Drawing.Point(548, 33);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.Size = new System.Drawing.Size(130, 21);
            this.DtpStop.TabIndex = 7;
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(336, 35);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(130, 21);
            this.DtpStart.TabIndex = 6;
            // 
            // LblKsrq
            // 
            this.LblKsrq.AutoSize = true;
            this.LblKsrq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblKsrq.Location = new System.Drawing.Point(282, 39);
            this.LblKsrq.Name = "LblKsrq";
            this.LblKsrq.Size = new System.Drawing.Size(53, 12);
            this.LblKsrq.TabIndex = 0;
            this.LblKsrq.Text = "开始日期";
            // 
            // CmbYwqy
            // 
            this.CmbYwqy.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.CmbYwqy.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbYwqy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYwqy.FormattingEnabled = true;
            this.CmbYwqy.Location = new System.Drawing.Point(66, 7);
            this.CmbYwqy.Name = "CmbYwqy";
            this.CmbYwqy.Size = new System.Drawing.Size(181, 20);
            this.CmbYwqy.TabIndex = 0;
            // 
            // LblYwqy
            // 
            this.LblYwqy.AutoSize = true;
            this.LblYwqy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYwqy.Location = new System.Drawing.Point(12, 11);
            this.LblYwqy.Name = "LblYwqy";
            this.LblYwqy.Size = new System.Drawing.Size(53, 12);
            this.LblYwqy.TabIndex = 0;
            this.LblYwqy.Text = "业务区域";
            // 
            // BtnSearch
            // 
            this.BtnSearch.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnSearch.CustomStyle = "F";
            this.BtnSearch.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(14, 63);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 8;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // LblJgcx
            // 
            this.LblJgcx.AutoSize = true;
            this.LblJgcx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJgcx.Location = new System.Drawing.Point(12, 39);
            this.LblJgcx.Name = "LblJgcx";
            this.LblJgcx.Size = new System.Drawing.Size(53, 12);
            this.LblJgcx.TabIndex = 0;
            this.LblJgcx.Text = "查询机构";
            // 
            // TxtJg
            // 
            this.TxtJg.AllowDrag = false;
            this.TxtJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJg.Location = new System.Drawing.Point(66, 35);
            this.TxtJg.Name = "TxtJg";
            this.TxtJg.Size = new System.Drawing.Size(58, 20);
            this.TxtJg.TabIndex = 3;
            this.TxtJg.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.TxtZDWZ_EnterKeyDown_1);
            // 
            // TxtJgmc
            // 
            this.TxtJgmc.AllowDrag = false;
            this.TxtJgmc.Enabled = false;
            this.TxtJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJgmc.Location = new System.Drawing.Point(126, 35);
            this.TxtJgmc.Name = "TxtJgmc";
            this.TxtJgmc.Size = new System.Drawing.Size(121, 20);
            this.TxtJgmc.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "fkfs";
            this.dataGridViewTextBoxColumn1.HeaderText = "记账类型";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "bh";
            this.dataGridViewTextBoxColumn5.HeaderText = "业务单号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // DgvTxtJgmc
            // 
            this.DgvTxtJgmc.DataPropertyName = "jgmc";
            this.DgvTxtJgmc.HeaderText = "jgmc";
            this.DgvTxtJgmc.Name = "DgvTxtJgmc";
            this.DgvTxtJgmc.ReadOnly = true;
            this.DgvTxtJgmc.Visible = false;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(717, 63);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 19;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsjkrb";
            this.Bds.DataSource = this.DSjkrb1;
            // 
            // DSjkrb1
            // 
            this.DSjkrb1.DataSetName = "DSJKRB";
            this.DSjkrb1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vfmsjkrbTableAdapter1
            // 
            this.vfmsjkrbTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmJKRB
            // 
            this.Controls.Add(this.PnlMain);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(897, 517);
            this.Text = "缴款日报";
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.PnlBtns.ResumeLayout(false);
            this.PnlJgcx.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSjkrb1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlMain;
        private DataGridView Dgv;
        private Panel PnlBtns;
        private Panel PnlJgcx;
        private Label LblJgcx;
        private TextBox TxtJg;
        private TextBox TxtJgmc;
        private Button BtnSearch;
        //private DSJKRB DSjkrb1;
        //private DSJKRBTableAdapters.tjigouTableAdapter TjigouTableAdapter1;
        private ComboBox CmbYwqy;
        private Label LblYwqy;
        private Button BtnJk;
        private Label LblJzlx;
        private ComboBox CmbJzlx;
        private ComboBox CmbSfyc;
        private Label LblSfyc;
        private Label LblJsrq;
        private DateTimePicker DtpStop;
        private DateTimePicker DtpStart;
        private Label LblKsrq;
        private JKRB.DSJKRB DSjkrb1;
        private DataGridViewTextBoxColumn DgvColTxtJzlx;
        private DataGridViewTextBoxColumn DgvColTxtYwqy;
        private DataGridViewTextBoxColumn DgvColTxtYwdh;
        private DataGridViewTextBoxColumn DgvColTxtYf;
        private DataGridViewTextBoxColumn DgvColTxtBf;
        private DataGridViewTextBoxColumn DgvColTxtZyf;
        private DataGridViewTextBoxColumn DgvColTxtZt;
        private BindingSource Bds;
        private Label LblRowCount;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private ListView LstV;
        private Button BtnClear1;
        private Label LblSum;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn DgvTxtJgid;
        private JKRB.DSJKRBTableAdapters.VfmsjkrbTableAdapter vfmsjkrbTableAdapter1;
        private DataGridViewTextBoxColumn DgvTxtJgmc;


    }
}