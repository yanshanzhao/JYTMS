using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using FMS.DSKGL.DSKYKGL;

namespace FMS.DSKGL.THBJ
{
    partial class FrmThDsk
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.CmbQszt = new Gizmox.WebGUI.Forms.ComboBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.DtpBzStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpBzStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.Cmbqsjgyc = new Gizmox.WebGUI.Forms.ComboBox();
            this.CmbDsk = new Gizmox.WebGUI.Forms.ComboBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lblykyy = new Gizmox.WebGUI.Forms.Label();
            this.Cmbbz = new Gizmox.WebGUI.Forms.ComboBox();
            this.LblTs = new Gizmox.WebGUI.Forms.Label();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.BtnCheck = new Gizmox.WebGUI.Forms.Button();
            this.BtnJg = new Gizmox.WebGUI.Forms.Button();
            this.BtnYk = new Gizmox.WebGUI.Forms.Button();
            this.BtnSearch = new Gizmox.WebGUI.Forms.Button();
            this.CmbThydzt = new Gizmox.WebGUI.Forms.ComboBox();
            this.LblYkzt = new Gizmox.WebGUI.Forms.Label();
            this.LblSksj = new Gizmox.WebGUI.Forms.Label();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.TxtYdbh = new Gizmox.WebGUI.Forms.TextBox();
            this.LblFwkh = new Gizmox.WebGUI.Forms.Label();
            this.LblBh = new Gizmox.WebGUI.Forms.Label();
            this.TxtSQjg = new Gizmox.WebGUI.Forms.TextBox();
            this.LblSljg = new Gizmox.WebGUI.Forms.Label();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColCbm = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.DgvColTxtysljgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtyqsjgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtybh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtdsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtybf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtsqsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtxbh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtxqsjg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtqsjgzc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtqszt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtthlxs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvCmb = new Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn();
            this.DgvColTxtbzsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSYDTH1 = new FMS.DSKGL.THBJ.DSYDTH();
            this.dataGridViewTextBoxColumn6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ChkB = new Gizmox.WebGUI.Forms.CheckBox();
            this.VfmsthdskTableAdapter1 = new FMS.DSKGL.THBJ.DSYDTHTableAdapters.VfmsthdskTableAdapter();
            this.PnlBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSYDTH1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.CmbQszt);
            this.PnlBtns.Controls.Add(this.label4);
            this.PnlBtns.Controls.Add(this.DtpBzStop);
            this.PnlBtns.Controls.Add(this.DtpBzStart);
            this.PnlBtns.Controls.Add(this.label3);
            this.PnlBtns.Controls.Add(this.label2);
            this.PnlBtns.Controls.Add(this.Cmbqsjgyc);
            this.PnlBtns.Controls.Add(this.CmbDsk);
            this.PnlBtns.Controls.Add(this.label1);
            this.PnlBtns.Controls.Add(this.lblykyy);
            this.PnlBtns.Controls.Add(this.Cmbbz);
            this.PnlBtns.Controls.Add(this.LblTs);
            this.PnlBtns.Controls.Add(this.BtnExl);
            this.PnlBtns.Controls.Add(this.BtnCheck);
            this.PnlBtns.Controls.Add(this.BtnJg);
            this.PnlBtns.Controls.Add(this.BtnYk);
            this.PnlBtns.Controls.Add(this.BtnSearch);
            this.PnlBtns.Controls.Add(this.CmbThydzt);
            this.PnlBtns.Controls.Add(this.LblYkzt);
            this.PnlBtns.Controls.Add(this.LblSksj);
            this.PnlBtns.Controls.Add(this.DtpStart);
            this.PnlBtns.Controls.Add(this.DtpStop);
            this.PnlBtns.Controls.Add(this.label10);
            this.PnlBtns.Controls.Add(this.TxtYdbh);
            this.PnlBtns.Controls.Add(this.LblFwkh);
            this.PnlBtns.Controls.Add(this.LblBh);
            this.PnlBtns.Controls.Add(this.TxtSQjg);
            this.PnlBtns.Controls.Add(this.LblSljg);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(889, 154);
            this.PnlBtns.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(394, 91);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 31;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // CmbQszt
            // 
            this.CmbQszt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbQszt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbQszt.FormattingEnabled = true;
            this.CmbQszt.Items.AddRange(new object[] {
            "异常",
            "正常"});
            this.CmbQszt.Location = new System.Drawing.Point(652, 58);
            this.CmbQszt.Name = "CmbQszt";
            this.CmbQszt.Size = new System.Drawing.Size(70, 20);
            this.CmbQszt.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(472, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "到";
            // 
            // DtpBzStop
            // 
            this.DtpBzStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpBzStop.Checked = false;
            this.DtpBzStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpBzStop.CustomFormat = "yyyy.MM.dd";
            this.DtpBzStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpBzStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpBzStop.Location = new System.Drawing.Point(493, 32);
            this.DtpBzStop.Name = "DtpBzStop";
            this.DtpBzStop.ShowCheckBox = true;
            this.DtpBzStop.Size = new System.Drawing.Size(140, 21);
            this.DtpBzStop.TabIndex = 3;
            // 
            // DtpBzStart
            // 
            this.DtpBzStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpBzStart.Checked = false;
            this.DtpBzStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpBzStart.CustomFormat = "yyyy.MM.dd";
            this.DtpBzStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpBzStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpBzStart.Location = new System.Drawing.Point(340, 32);
            this.DtpBzStart.Name = "DtpBzStart";
            this.DtpBzStart.ShowCheckBox = true;
            this.DtpBzStart.Size = new System.Drawing.Size(130, 21);
            this.DtpBzStart.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(276, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "备注时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(601, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "签收状态";
            // 
            // Cmbqsjgyc
            // 
            this.Cmbqsjgyc.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.Cmbqsjgyc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmbqsjgyc.FormattingEnabled = true;
            this.Cmbqsjgyc.Items.AddRange(new object[] {
            "全部",
            "是",
            "否"});
            this.Cmbqsjgyc.Location = new System.Drawing.Point(86, 56);
            this.Cmbqsjgyc.Name = "Cmbqsjgyc";
            this.Cmbqsjgyc.Size = new System.Drawing.Size(143, 20);
            this.Cmbqsjgyc.TabIndex = 27;
            // 
            // CmbDsk
            // 
            this.CmbDsk.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbDsk.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDsk.FormattingEnabled = true;
            this.CmbDsk.Items.AddRange(new object[] {
            "全部",
            "是",
            "否"});
            this.CmbDsk.Location = new System.Drawing.Point(510, 58);
            this.CmbDsk.Name = "CmbDsk";
            this.CmbDsk.Size = new System.Drawing.Size(79, 20);
            this.CmbDsk.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(449, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "有代收款";
            // 
            // lblykyy
            // 
            this.lblykyy.AutoSize = true;
            this.lblykyy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblykyy.Location = new System.Drawing.Point(21, 127);
            this.lblykyy.Name = "lblykyy";
            this.lblykyy.Size = new System.Drawing.Size(35, 13);
            this.lblykyy.TabIndex = 24;
            this.lblykyy.Text = "备注类型";
            // 
            // Cmbbz
            // 
            this.Cmbbz.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Cmbbz.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.Cmbbz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmbbz.FormattingEnabled = true;
            this.Cmbbz.Location = new System.Drawing.Point(80, 125);
            this.Cmbbz.Name = "Cmbbz";
            this.Cmbbz.Size = new System.Drawing.Size(120, 20);
            this.Cmbbz.TabIndex = 4;
            this.Cmbbz.SelectedIndexChanged += new System.EventHandler(this.CmbYkyy_SelectedIndexChanged);
            // 
            // LblTs
            // 
            this.LblTs.AutoSize = true;
            this.LblTs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTs.ForeColor = System.Drawing.Color.Green;
            this.LblTs.Location = new System.Drawing.Point(230, 125);
            this.LblTs.Name = "LblTs";
            this.LblTs.Size = new System.Drawing.Size(35, 13);
            this.LblTs.TabIndex = 23;
            this.LblTs.Text = "请选择要选择备注类型，在进行保存操作。";
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(283, 92);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 11;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // BtnCheck
            // 
            this.BtnCheck.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnCheck.CustomStyle = "F";
            this.BtnCheck.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnCheck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCheck.Location = new System.Drawing.Point(105, 92);
            this.BtnCheck.Name = "BtnCheck";
            this.BtnCheck.Size = new System.Drawing.Size(75, 23);
            this.BtnCheck.TabIndex = 8;
            this.BtnCheck.Text = "本页全选";
            this.BtnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // BtnJg
            // 
            this.BtnJg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnJg.CustomStyle = "F";
            this.BtnJg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnJg.Location = new System.Drawing.Point(232, 9);
            this.BtnJg.Name = "BtnJg";
            this.BtnJg.Size = new System.Drawing.Size(18, 20);
            this.BtnJg.TabIndex = 1;
            this.BtnJg.Text = "》";
            this.BtnJg.Click += new System.EventHandler(this.BtnJg_Click);
            // 
            // BtnYk
            // 
            this.BtnYk.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnYk.CustomStyle = "F";
            this.BtnYk.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnYk.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnYk.Location = new System.Drawing.Point(199, 92);
            this.BtnYk.Name = "BtnYk";
            this.BtnYk.Size = new System.Drawing.Size(75, 23);
            this.BtnYk.TabIndex = 9;
            this.BtnYk.Text = "保存";
            this.BtnYk.Click += new System.EventHandler(this.BtnYk_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnSearch.CustomStyle = "F";
            this.BtnSearch.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(11, 92);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 7;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // CmbThydzt
            // 
            this.CmbThydzt.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.CmbThydzt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbThydzt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbThydzt.FormattingEnabled = true;
            this.CmbThydzt.Items.AddRange(new object[] {
            "全部",
            "未压款",
            "已压款"});
            this.CmbThydzt.Location = new System.Drawing.Point(340, 58);
            this.CmbThydzt.Name = "CmbThydzt";
            this.CmbThydzt.Size = new System.Drawing.Size(91, 20);
            this.CmbThydzt.TabIndex = 4;
            // 
            // LblYkzt
            // 
            this.LblYkzt.AutoSize = true;
            this.LblYkzt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYkzt.Location = new System.Drawing.Point(242, 61);
            this.LblYkzt.Name = "LblYkzt";
            this.LblYkzt.Size = new System.Drawing.Size(35, 13);
            this.LblYkzt.TabIndex = 0;
            this.LblYkzt.Text = "退货新运单状态";
            // 
            // LblSksj
            // 
            this.LblSksj.AutoSize = true;
            this.LblSksj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSksj.Location = new System.Drawing.Point(254, 12);
            this.LblSksj.Name = "LblSksj";
            this.LblSksj.Size = new System.Drawing.Size(53, 12);
            this.LblSksj.TabIndex = 0;
            this.LblSksj.Text = "退货申请日期";
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Checked = false;
            this.DtpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(340, 8);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.ShowCheckBox = true;
            this.DtpStart.Size = new System.Drawing.Size(130, 21);
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
            this.DtpStop.Location = new System.Drawing.Point(493, 8);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.ShowCheckBox = true;
            this.DtpStop.Size = new System.Drawing.Size(140, 21);
            this.DtpStop.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(472, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "到";
            // 
            // TxtYdbh
            // 
            this.TxtYdbh.AllowDrag = false;
            this.TxtYdbh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtYdbh.Location = new System.Drawing.Point(86, 33);
            this.TxtYdbh.Name = "TxtYdbh";
            this.TxtYdbh.Size = new System.Drawing.Size(143, 20);
            this.TxtYdbh.TabIndex = 5;
            // 
            // LblFwkh
            // 
            this.LblFwkh.AutoSize = true;
            this.LblFwkh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFwkh.Location = new System.Drawing.Point(33, 36);
            this.LblFwkh.Name = "LblFwkh";
            this.LblFwkh.Size = new System.Drawing.Size(53, 12);
            this.LblFwkh.TabIndex = 0;
            this.LblFwkh.Text = "货运单号";
            // 
            // LblBh
            // 
            this.LblBh.AutoSize = true;
            this.LblBh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBh.Location = new System.Drawing.Point(9, 61);
            this.LblBh.Name = "LblBh";
            this.LblBh.Size = new System.Drawing.Size(53, 12);
            this.LblBh.TabIndex = 0;
            this.LblBh.Text = "签收机构异常";
            // 
            // TxtSQjg
            // 
            this.TxtSQjg.AllowDrag = false;
            this.TxtSQjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSQjg.Location = new System.Drawing.Point(86, 9);
            this.TxtSQjg.Name = "TxtSQjg";
            this.TxtSQjg.ReadOnly = true;
            this.TxtSQjg.Size = new System.Drawing.Size(143, 20);
            this.TxtSQjg.TabIndex = 0;
            // 
            // LblSljg
            // 
            this.LblSljg.AutoSize = true;
            this.LblSljg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSljg.Location = new System.Drawing.Point(9, 12);
            this.LblSljg.Name = "LblSljg";
            this.LblSljg.Size = new System.Drawing.Size(53, 12);
            this.LblSljg.TabIndex = 0;
            this.LblSljg.Text = "申请退货机构";
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
            this.DgvColCbm,
            this.DgvColTxtysljgmc,
            this.DgvColTxtyqsjgmc,
            this.DgvColTxtybh,
            this.DgvColTxtdsk,
            this.DgvColTxtybf,
            this.DgvColTxtsqsj,
            this.DgvColTxtxbh,
            this.DgvColTxtxqsjg,
            this.DgvColTxtqsjgzc,
            this.DgvColTxtqszt,
            this.DgvColTxtthlxs,
            this.DgvCmb,
            this.DgvColTxtbzsj,
            this.DgvColTxtid});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 154);
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
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(889, 360);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellMouseDown += new Gizmox.WebGUI.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseDown);
            // 
            // DgvColCbm
            // 
            this.DgvColCbm.FillWeight = 70F;
            this.DgvColCbm.Frozen = true;
            this.DgvColCbm.HeaderText = "全选";
            this.DgvColCbm.Name = "DgvColCbm";
            this.DgvColCbm.ReadOnly = true;
            this.DgvColCbm.Width = 70;
            // 
            // DgvColTxtysljgmc
            // 
            this.DgvColTxtysljgmc.DataPropertyName = "ysljgmc";
            this.DgvColTxtysljgmc.FillWeight = 120F;
            this.DgvColTxtysljgmc.HeaderText = "原单号受理机构";
            this.DgvColTxtysljgmc.Name = "DgvColTxtysljgmc";
            this.DgvColTxtysljgmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtysljgmc.Width = 120;
            // 
            // DgvColTxtyqsjgmc
            // 
            this.DgvColTxtyqsjgmc.DataPropertyName = "yqsjgmc";
            this.DgvColTxtyqsjgmc.FillWeight = 120F;
            this.DgvColTxtyqsjgmc.HeaderText = "原单号签收机构";
            this.DgvColTxtyqsjgmc.Name = "DgvColTxtyqsjgmc";
            this.DgvColTxtyqsjgmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtyqsjgmc.Width = 120;
            // 
            // DgvColTxtybh
            // 
            this.DgvColTxtybh.DataPropertyName = "ybh";
            this.DgvColTxtybh.HeaderText = "原货运单号";
            this.DgvColTxtybh.Name = "DgvColTxtybh";
            this.DgvColTxtybh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtdsk
            // 
            this.DgvColTxtdsk.DataPropertyName = "dsk";
            this.DgvColTxtdsk.HeaderText = "原代收款金额";
            this.DgvColTxtdsk.Name = "DgvColTxtdsk";
            this.DgvColTxtdsk.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtybf
            // 
            this.DgvColTxtybf.DataPropertyName = "yydfy";
            this.DgvColTxtybf.FillWeight = 140F;
            this.DgvColTxtybf.HeaderText = "原提付总运费金额";
            this.DgvColTxtybf.Name = "DgvColTxtybf";
            this.DgvColTxtybf.ReadOnly = true;
            this.DgvColTxtybf.Width = 140;
            // 
            // DgvColTxtsqsj
            // 
            this.DgvColTxtsqsj.DataPropertyName = "sqsj";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle2.NullValue = null;
            this.DgvColTxtsqsj.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColTxtsqsj.HeaderText = "退货申请时间";
            this.DgvColTxtsqsj.Name = "DgvColTxtsqsj";
            // 
            // DgvColTxtxbh
            // 
            this.DgvColTxtxbh.DataPropertyName = "xbh";
            this.DgvColTxtxbh.HeaderText = "新货运单号";
            this.DgvColTxtxbh.Name = "DgvColTxtxbh";
            this.DgvColTxtxbh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtxqsjg
            // 
            this.DgvColTxtxqsjg.DataPropertyName = "xqsjg";
            this.DgvColTxtxqsjg.FillWeight = 120F;
            this.DgvColTxtxqsjg.HeaderText = "新单号签收机构";
            this.DgvColTxtxqsjg.Name = "DgvColTxtxqsjg";
            this.DgvColTxtxqsjg.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtxqsjg.Width = 120;
            // 
            // DgvColTxtqsjgzc
            // 
            this.DgvColTxtqsjgzc.DataPropertyName = "qsjgzc";
            this.DgvColTxtqsjgzc.HeaderText = "签收机构正常";
            this.DgvColTxtqsjgzc.Name = "DgvColTxtqsjgzc";
            this.DgvColTxtqsjgzc.ReadOnly = true;
            this.DgvColTxtqsjgzc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtqszt
            // 
            this.DgvColTxtqszt.DataPropertyName = "qszt";
            this.DgvColTxtqszt.HeaderText = "签收状态";
            this.DgvColTxtqszt.Name = "DgvColTxtqszt";
            this.DgvColTxtqszt.ReadOnly = true;
            this.DgvColTxtqszt.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtthlxs
            // 
            this.DgvColTxtthlxs.DataPropertyName = "thlxs";
            this.DgvColTxtthlxs.HeaderText = "退货类型";
            this.DgvColTxtthlxs.Name = "DgvColTxtthlxs";
            this.DgvColTxtthlxs.ReadOnly = true;
            // 
            // DgvCmb
            // 
            this.DgvCmb.AutoComplete = false;
            this.DgvCmb.DataPropertyName = "thbz";
            this.DgvCmb.DisplayStyleForCurrentCellOnly = true;
            this.DgvCmb.HeaderText = "备注";
            this.DgvCmb.Name = "DgvCmb";
            // 
            // DgvColTxtbzsj
            // 
            this.DgvColTxtbzsj.DataPropertyName = "bzsj";
            this.DgvColTxtbzsj.HeaderText = "备注时间";
            this.DgvColTxtbzsj.Name = "DgvColTxtbzsj";
            // 
            // DgvColTxtid
            // 
            this.DgvColTxtid.DataPropertyName = "id";
            this.DgvColTxtid.FillWeight = 20F;
            this.DgvColTxtid.HeaderText = "id";
            this.DgvColTxtid.Name = "DgvColTxtid";
            this.DgvColTxtid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtid.Visible = false;
            this.DgvColTxtid.Width = 20;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsthdsk";
            this.Bds.DataSource = this.DSYDTH1;
            // 
            // DSYDTH1
            // 
            this.DSYDTH1.DataSetName = "DSYDTH";
            this.DSYDTH1.EnforceConstraints = false;
            this.DSYDTH1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "sljgmc";
            this.dataGridViewTextBoxColumn6.HeaderText = "受理机构";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "bh";
            this.dataGridViewTextBoxColumn7.HeaderText = "货运单号";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "dsk";
            this.dataGridViewTextBoxColumn8.HeaderText = "代收款金额";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "dskykzt";
            this.dataGridViewTextBoxColumn9.HeaderText = "押款状态";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // ChkB
            // 
            this.ChkB.AutoSize = true;
            this.ChkB.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkB.Location = new System.Drawing.Point(59, 158);
            this.ChkB.Name = "ChkB";
            this.ChkB.Size = new System.Drawing.Size(15, 14);
            this.ChkB.TabIndex = 2;
            this.ChkB.CheckedChanged += new System.EventHandler(this.ChkB_CheckedChanged);
            // 
            // VfmsthdskTableAdapter1
            // 
            this.VfmsthdskTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmThDsk
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.ChkB);
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlBtns);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(889, 514);
            this.Text = "代收款押款管理";
            this.PnlBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSYDTH1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlBtns;
        private DataGridView Dgv;
        private DataGridViewCheckBoxColumn DgvColCbm;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private TextBox TxtYdbh;
        private Label LblFwkh;
        private Label LblBh;
        private TextBox TxtSQjg;
        private Label LblSljg;
        private Label LblSksj;
        private DateTimePicker DtpStart;
        private DateTimePicker DtpStop;
        private Label label10;
        private ComboBox CmbThydzt;
        private Label LblYkzt;
        private Button BtnYk;
        private Button BtnSearch;
        private Button BtnJg;
        private Button BtnCheck;
        private CheckBox ChkB;
        //private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExl;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private Label LblTs;
        private Label lblykyy;
        private ComboBox Cmbbz;
        private Label label3;
        private Label label2;
        private ComboBox Cmbqsjgyc;
        private ComboBox CmbDsk;
        private Label label1;
        private Label label4;
        private DateTimePicker DtpBzStop;
        private DateTimePicker DtpBzStart;
        private ComboBox CmbQszt;
        //private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private DSYDTH DSYDTH1;
        private DSYDTHTableAdapters.VfmsthdskTableAdapter VfmsthdskTableAdapter1;
        private BindingSource Bds;
        private DataGridViewTextBoxColumn DgvColTxtysljgmc;
        private DataGridViewTextBoxColumn DgvColTxtyqsjgmc;
        private DataGridViewTextBoxColumn DgvColTxtybh;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private DataGridViewTextBoxColumn DgvColTxtsqsj;
        private DataGridViewTextBoxColumn DgvColTxtxbh;
        private DataGridViewTextBoxColumn DgvColTxtxqsjg;
        private DataGridViewTextBoxColumn DgvColTxtqsjgzc;
        private DataGridViewTextBoxColumn DgvColTxtqszt;
        private DataGridViewTextBoxColumn DgvColTxtbzsj;
        private DataGridViewTextBoxColumn DgvColTxtdsk;
        private DataGridViewComboBoxColumn DgvCmb;
        private DataGridViewTextBoxColumn DgvColTxtid;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private DataGridViewTextBoxColumn DgvColTxtybf;
        private DataGridViewTextBoxColumn DgvColTxtthlxs;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        //private DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
    }
}
