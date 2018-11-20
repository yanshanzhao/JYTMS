using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.ZSFJHFCX
    {
    partial class FrmZSFJHFCX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.LblTs = new Gizmox.WebGUI.Forms.Label();
            this.LblHj = new Gizmox.WebGUI.Forms.Label();
            this.TxtJg = new Gizmox.WebGUI.Forms.TextBox();
            this.LblCkjg = new Gizmox.WebGUI.Forms.Label();
            this.ChkBJg = new Gizmox.WebGUI.Forms.CheckBox();
            this.BtnJgSearch = new Gizmox.WebGUI.Forms.Button();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.BtnExcel = new Gizmox.WebGUI.Forms.Button();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.BtnSearch = new Gizmox.WebGUI.Forms.Button();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtJgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJhf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZsf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtHj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvLnk = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtJgid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DZsf_JhfCx = new System.Data.DataSet();
            this.DSCX = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.Jgid = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.PnlBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DZsf_JhfCx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSCX)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.LblTs);
            this.PnlBtns.Controls.Add(this.LblHj);
            this.PnlBtns.Controls.Add(this.TxtJg);
            this.PnlBtns.Controls.Add(this.LblCkjg);
            this.PnlBtns.Controls.Add(this.ChkBJg);
            this.PnlBtns.Controls.Add(this.BtnJgSearch);
            this.PnlBtns.Controls.Add(this.DtpStart);
            this.PnlBtns.Controls.Add(this.BtnExcel);
            this.PnlBtns.Controls.Add(this.DtpStop);
            this.PnlBtns.Controls.Add(this.BtnSearch);
            this.PnlBtns.Controls.Add(this.label4);
            this.PnlBtns.Controls.Add(this.label3);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(935, 86);
            this.PnlBtns.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(704, 27);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(75, 23);
            this.ctrlDownLoad1.TabIndex = 4;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // LblTs
            // 
            this.LblTs.AutoSize = true;
            this.LblTs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTs.ForeColor = System.Drawing.Color.Green;
            this.LblTs.Location = new System.Drawing.Point(14, 38);
            this.LblTs.Name = "LblTs";
            this.LblTs.Size = new System.Drawing.Size(557, 12);
            this.LblTs.TabIndex = 27;
            this.LblTs.Text = "缴款机构后面的复选框选中，表示只查询选中机构本机构的信息，反之查询选中机构及其下属机构信息！";
            // 
            // LblHj
            // 
            this.LblHj.BackColor = System.Drawing.SystemColors.Window;
            this.LblHj.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblHj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHj.ForeColor = System.Drawing.Color.Blue;
            this.LblHj.Location = new System.Drawing.Point(303, 58);
            this.LblHj.Name = "LblHj";
            this.LblHj.Size = new System.Drawing.Size(313, 21);
            this.LblHj.TabIndex = 18;
            this.LblHj.Text = "接货费：0 ；直送费：0 ；合计：0";
            this.LblHj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtJg
            // 
            this.TxtJg.AllowDrag = false;
            this.TxtJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJg.Location = new System.Drawing.Point(44, 12);
            this.TxtJg.Name = "TxtJg";
            this.TxtJg.ReadOnly = true;
            this.TxtJg.Size = new System.Drawing.Size(162, 20);
            this.TxtJg.TabIndex = 0;
            // 
            // LblCkjg
            // 
            this.LblCkjg.AutoSize = true;
            this.LblCkjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCkjg.Location = new System.Drawing.Point(12, 16);
            this.LblCkjg.Name = "LblCkjg";
            this.LblCkjg.Size = new System.Drawing.Size(29, 12);
            this.LblCkjg.TabIndex = 0;
            this.LblCkjg.Text = "机构";
            // 
            // ChkBJg
            // 
            this.ChkBJg.AutoSize = true;
            this.ChkBJg.Checked = true;
            this.ChkBJg.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.ChkBJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBJg.Location = new System.Drawing.Point(243, 15);
            this.ChkBJg.Name = "ChkBJg";
            this.ChkBJg.Size = new System.Drawing.Size(15, 14);
            this.ChkBJg.TabIndex = 25;
            // 
            // BtnJgSearch
            // 
            this.BtnJgSearch.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnJgSearch.CustomStyle = "F";
            this.BtnJgSearch.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJgSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnJgSearch.Location = new System.Drawing.Point(209, 12);
            this.BtnJgSearch.Name = "BtnJgSearch";
            this.BtnJgSearch.Size = new System.Drawing.Size(20, 20);
            this.BtnJgSearch.TabIndex = 1;
            this.BtnJgSearch.Text = "》";
            this.BtnJgSearch.Click += new System.EventHandler(this.BtnJgSearch_Click);
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(320, 12);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(100, 21);
            this.DtpStart.TabIndex = 3;
            // 
            // BtnExcel
            // 
            this.BtnExcel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExcel.CustomStyle = "F";
            this.BtnExcel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcel.Location = new System.Drawing.Point(214, 58);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnExcel.TabIndex = 13;
            this.BtnExcel.Text = "导出";
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // DtpStop
            // 
            this.DtpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStop.CustomFormat = "yyyy.MM.dd";
            this.DtpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStop.Location = new System.Drawing.Point(437, 12);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.Size = new System.Drawing.Size(100, 21);
            this.DtpStop.TabIndex = 4;
            // 
            // BtnSearch
            // 
            this.BtnSearch.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnSearch.CustomStyle = "F";
            this.BtnSearch.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(18, 58);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 9;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(420, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "一";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(267, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "记账日期";
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
            this.DgvColTxtJgmc,
            this.DgvColTxtJhf,
            this.DgvColTxtZsf,
            this.DgvColTxtHj,
            this.DgvLnk,
            this.DgvColTxtJgid});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataMember = "Table1";
            this.Dgv.DataSource = this.DZsf_JhfCx;
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
            this.Dgv.Location = new System.Drawing.Point(0, 86);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(935, 532);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // DgvColTxtJgmc
            // 
            this.DgvColTxtJgmc.DataPropertyName = "jgmc";
            this.DgvColTxtJgmc.HeaderText = "机构名称";
            this.DgvColTxtJgmc.Name = "DgvColTxtJgmc";
            this.DgvColTxtJgmc.ReadOnly = true;
            this.DgvColTxtJgmc.Width = 150;
            // 
            // DgvColTxtJhf
            // 
            this.DgvColTxtJhf.DataPropertyName = "jhf";
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtJhf.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColTxtJhf.HeaderText = "接货费";
            this.DgvColTxtJhf.Name = "DgvColTxtJhf";
            this.DgvColTxtJhf.ReadOnly = true;
            // 
            // DgvColTxtZsf
            // 
            this.DgvColTxtZsf.DataPropertyName = "zsf";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtZsf.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtZsf.HeaderText = "直送费";
            this.DgvColTxtZsf.Name = "DgvColTxtZsf";
            this.DgvColTxtZsf.ReadOnly = true;
            // 
            // DgvColTxtHj
            // 
            this.DgvColTxtHj.DataPropertyName = "hj";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtHj.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtHj.HeaderText = "金额";
            this.DgvColTxtHj.Name = "DgvColTxtHj";
            this.DgvColTxtHj.ReadOnly = true;
            // 
            // DgvLnk
            // 
            this.DgvLnk.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvLnk.ClientMode = false;
            this.DgvLnk.DataPropertyName = "xx";
            this.DgvLnk.HeaderText = "详细信息";
            this.DgvLnk.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvLnk.LinkColor = System.Drawing.Color.Empty;
            this.DgvLnk.Name = "DgvLnk";
            this.DgvLnk.ReadOnly = true;
            this.DgvLnk.TrackVisitedState = false;
            this.DgvLnk.Url = "";
            this.DgvLnk.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvColTxtJgid
            // 
            this.DgvColTxtJgid.DataPropertyName = "jgid";
            this.DgvColTxtJgid.HeaderText = "机构Id[隐藏]";
            this.DgvColTxtJgid.Name = "DgvColTxtJgid";
            this.DgvColTxtJgid.ReadOnly = true;
            this.DgvColTxtJgid.Visible = false;
            // 
            // DZsf_JhfCx
            // 
            this.DZsf_JhfCx.DataSetName = "NewDataSet";
            this.DZsf_JhfCx.Tables.AddRange(new System.Data.DataTable[] {
            this.DSCX});
            // 
            // DSCX
            // 
            this.DSCX.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.Jgid,
            this.dataColumn5});
            this.DSCX.TableName = "Table1";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "jgmc";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "jgid";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "zsf";
            this.dataColumn3.DataType = typeof(decimal);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "jhf";
            this.dataColumn4.DataType = typeof(decimal);
            // 
            // Jgid
            // 
            this.Jgid.ColumnName = "hj";
            this.Jgid.DataType = typeof(decimal);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "xx";
            // 
            // FrmZSFJHFCX
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlBtns);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(935, 618);
            this.Text = "FrmZSFJHFCX";
            this.PnlBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DZsf_JhfCx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSCX)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion

        private Panel PnlBtns;
        private TextBox TxtJg;
        private Button BtnJgSearch;
        private Label LblCkjg;
        private Label label3;
        private Label label4;
        private DateTimePicker DtpStop;
        private DateTimePicker DtpStart;
        private Button BtnSearch;
        private Button BtnExcel;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtJgmc;
        private DataGridViewTextBoxColumn DgvColTxtHj;
        private CheckBox ChkBJg;
        private Label LblTs;
        private Label LblHj;
        private System.Data.DataSet DZsf_JhfCx;
        private System.Data.DataTable DSCX;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn Jgid;
        private System.Data.DataColumn dataColumn5;
        private DataGridViewTextBoxColumn DgvColTxtJgid;
        private DataGridViewTextBoxColumn DgvColTxtJhf;
        private DataGridViewTextBoxColumn DgvColTxtZsf;
        private DataGridViewLinkColumn DgvLnk;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;


        }
    }