using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.WFKYBFCX
    {
    partial class FrmWFKYBFCX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtjgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtTs1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtTs2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtTs3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtTs999 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColLclHj = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtJgid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExcel = new Gizmox.WebGUI.Forms.Button();
            this.LblCkjg = new Gizmox.WebGUI.Forms.Label();
            this.BtnJG = new Gizmox.WebGUI.Forms.Button();
            this.LblKsrq = new Gizmox.WebGUI.Forms.Label();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.TxtCkjg = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSearch = new Gizmox.WebGUI.Forms.Button();
            this.DgvColTxtTs0 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.PnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.Dgv);
            this.PnlTop.Controls.Add(this.PnlMain);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(765, 514);
            this.PnlTop.TabIndex = 0;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
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
            this.DgvColTxtjgmc,
            this.DgvColTxtTs0,
            this.DgvColTxtTs1,
            this.DgvColTxtTs2,
            this.DgvColTxtTs3,
            this.DgvColTxtTs999,
            this.DgvColLclHj,
            this.DgvColTxtJgid});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
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
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 67);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
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
            this.Dgv.Size = new System.Drawing.Size(765, 447);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // DgvColTxtjgmc
            // 
            this.DgvColTxtjgmc.DataPropertyName = "jgmc";
            this.DgvColTxtjgmc.HeaderText = "机构";
            this.DgvColTxtjgmc.Name = "DgvColTxtjgmc";
            this.DgvColTxtjgmc.ReadOnly = true;
            this.DgvColTxtjgmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjgmc.Width = 120;
            // 
            // DgvColTxtTs1
            // 
            this.DgvColTxtTs1.DataPropertyName = "ts1";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtTs1.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtTs1.HeaderText = "逾期1天";
            this.DgvColTxtTs1.Name = "DgvColTxtTs1";
            this.DgvColTxtTs1.ReadOnly = true;
            this.DgvColTxtTs1.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtTs2
            // 
            this.DgvColTxtTs2.DataPropertyName = "ts2";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtTs2.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtTs2.HeaderText = "逾期2天";
            this.DgvColTxtTs2.Name = "DgvColTxtTs2";
            this.DgvColTxtTs2.ReadOnly = true;
            this.DgvColTxtTs2.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtTs3
            // 
            this.DgvColTxtTs3.DataPropertyName = "ts3";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtTs3.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColTxtTs3.HeaderText = "逾期3天";
            this.DgvColTxtTs3.Name = "DgvColTxtTs3";
            this.DgvColTxtTs3.ReadOnly = true;
            this.DgvColTxtTs3.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtTs999
            // 
            this.DgvColTxtTs999.DataPropertyName = "ts999";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtTs999.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvColTxtTs999.HeaderText = "逾期3天以上";
            this.DgvColTxtTs999.Name = "DgvColTxtTs999";
            this.DgvColTxtTs999.ReadOnly = true;
            this.DgvColTxtTs999.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColLclHj
            // 
            this.DgvColLclHj.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColLclHj.ClientMode = false;
            this.DgvColLclHj.DataPropertyName = "hj";
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColLclHj.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvColLclHj.HeaderText = "合计";
            this.DgvColLclHj.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvColLclHj.LinkColor = System.Drawing.Color.Empty;
            this.DgvColLclHj.Name = "DgvColLclHj";
            this.DgvColLclHj.ReadOnly = true;
            this.DgvColLclHj.TrackVisitedState = false;
            this.DgvColLclHj.Url = "";
            this.DgvColLclHj.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvColTxtJgid
            // 
            this.DgvColTxtJgid.DataPropertyName = "jgid";
            this.DgvColTxtJgid.HeaderText = "机构ID[隐藏]";
            this.DgvColTxtJgid.Name = "DgvColTxtJgid";
            this.DgvColTxtJgid.ReadOnly = true;
            this.DgvColTxtJgid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtJgid.Visible = false;
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.ctrlDownLoad1);
            this.PnlMain.Controls.Add(this.BtnExcel);
            this.PnlMain.Controls.Add(this.LblCkjg);
            this.PnlMain.Controls.Add(this.BtnJG);
            this.PnlMain.Controls.Add(this.LblKsrq);
            this.PnlMain.Controls.Add(this.DtpStart);
            this.PnlMain.Controls.Add(this.TxtCkjg);
            this.PnlMain.Controls.Add(this.BtnSearch);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(765, 67);
            this.PnlMain.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(206, 34);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 3;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnExcel
            // 
            this.BtnExcel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExcel.CustomStyle = "F";
            this.BtnExcel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcel.Location = new System.Drawing.Point(105, 36);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnExcel.TabIndex = 4;
            this.BtnExcel.Text = "导出";
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // LblCkjg
            // 
            this.LblCkjg.AutoSize = true;
            this.LblCkjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCkjg.Location = new System.Drawing.Point(5, 16);
            this.LblCkjg.Name = "LblCkjg";
            this.LblCkjg.Size = new System.Drawing.Size(53, 12);
            this.LblCkjg.TabIndex = 0;
            this.LblCkjg.Text = "存款机构";
            // 
            // BtnJG
            // 
            this.BtnJG.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnJG.CustomStyle = "F";
            this.BtnJG.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJG.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnJG.Location = new System.Drawing.Point(225, 13);
            this.BtnJG.Name = "BtnJG";
            this.BtnJG.Size = new System.Drawing.Size(26, 20);
            this.BtnJG.TabIndex = 1;
            this.BtnJG.Text = "》";
            this.BtnJG.Click += new System.EventHandler(this.BtnJG_Click);
            // 
            // LblKsrq
            // 
            this.LblKsrq.AutoSize = true;
            this.LblKsrq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblKsrq.Location = new System.Drawing.Point(271, 16);
            this.LblKsrq.Name = "LblKsrq";
            this.LblKsrq.Size = new System.Drawing.Size(53, 12);
            this.LblKsrq.TabIndex = 0;
            this.LblKsrq.Text = "截止日期";
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(327, 12);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(130, 21);
            this.DtpStart.TabIndex = 2;
            // 
            // TxtCkjg
            // 
            this.TxtCkjg.AllowDrag = false;
            this.TxtCkjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCkjg.Location = new System.Drawing.Point(58, 13);
            this.TxtCkjg.Name = "TxtCkjg";
            this.TxtCkjg.ReadOnly = true;
            this.TxtCkjg.Size = new System.Drawing.Size(162, 20);
            this.TxtCkjg.TabIndex = 0;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSearch.CustomStyle = "F";
            this.BtnSearch.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(7, 36);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 3;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // DgvColTxtTs0
            // 
            this.DgvColTxtTs0.DataPropertyName = "ts0";
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtTs0.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColTxtTs0.HeaderText = "逾期0天";
            this.DgvColTxtTs0.Name = "DgvColTxtTs0";
            this.DgvColTxtTs0.ReadOnly = true;
            // 
            // FrmWFKYBFCX
            // 
            this.Controls.Add(this.PnlTop);
            this.Size = new System.Drawing.Size(765, 514);
            this.Text = "FrmWFKYBFCX";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.PnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private Panel PnlTop;
        private Panel PnlMain;
        private Button BtnJG;
        private Label LblKsrq;
        private DateTimePicker DtpStart;
        private TextBox TxtCkjg;
        private Button BtnSearch;
        private Label LblCkjg;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtjgmc;
        private DataGridViewTextBoxColumn DgvColTxtJgid;
        private DataGridViewTextBoxColumn DgvColTxtTs1;
        private DataGridViewTextBoxColumn DgvColTxtTs2;
        private DataGridViewTextBoxColumn DgvColTxtTs3;
        private DataGridViewTextBoxColumn DgvColTxtTs999;
        private DataGridViewLinkColumn DgvColLclHj;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExcel;
        private DataGridViewTextBoxColumn DgvColTxtTs0;


        }
    }