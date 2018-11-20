using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKDKCX
    {
    partial class FrmDSKDKCX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.BdsDskdkcx = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.Dsdskdkcx1 = new FMS.DSKGL.DSKDKCX.DSDSKDKCX();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.BtnExcel = new Gizmox.WebGUI.Forms.Button();
            this.BtnQuery = new Gizmox.WebGUI.Forms.Button();
            this.BtnDksbcx = new Gizmox.WebGUI.Forms.Button();
            this.PnlJgcx = new Gizmox.WebGUI.Forms.Panel();
            this.LstV = new Gizmox.WebGUI.Forms.ListView();
            this.LblRowCount = new Gizmox.WebGUI.Forms.Label();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.LblJgcx = new Gizmox.WebGUI.Forms.Label();
            this.TxtJg = new Gizmox.WebGUI.Forms.TextBox();
            this.TxtJgmc = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.CmbYhlx = new Gizmox.WebGUI.Forms.ComboBox();
            this.DtpCjStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpCjStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.CmbZt = new Gizmox.WebGUI.Forms.ComboBox();
            this.DgvColTxtdamc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzcje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtinssj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzy = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.vfmsdskdkcxTableAdapter1 = new FMS.DSKGL.DSKDKCX.DSDSKDKCXTableAdapters.VfmsdskdkcxTableAdapter();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BdsDskdkcx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dsdskdkcx1)).BeginInit();
            this.PnlBtns.SuspendLayout();
            this.PnlJgcx.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Controls.Add(this.PnlBtns);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(750, 433);
            this.PnlMain.TabIndex = 0;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.AutoGenerateColumns = false;
            this.Dgv.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
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
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn10});
            this.Dgv.DataSource = this.BdsDskdkcx;
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.Dgv.Location = new System.Drawing.Point(0, 100);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
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
            this.Dgv.Size = new System.Drawing.Size(750, 333);
            this.Dgv.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "dqmc";
            this.dataGridViewTextBoxColumn3.FillWeight = 100.0677F;
            this.dataGridViewTextBoxColumn3.HeaderText = "所属大区";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 105;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "jgmc";
            this.dataGridViewTextBoxColumn4.FillWeight = 100.0677F;
            this.dataGridViewTextBoxColumn4.HeaderText = "机构";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 106;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "rbdh";
            this.dataGridViewTextBoxColumn5.FillWeight = 100.0677F;
            this.dataGridViewTextBoxColumn5.HeaderText = "日报单号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 105;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "zze";
            this.dataGridViewTextBoxColumn6.FillWeight = 100.0677F;
            this.dataGridViewTextBoxColumn6.HeaderText = "转出金额";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 106;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "inssj";
            this.dataGridViewTextBoxColumn7.FillWeight = 100.0677F;
            this.dataGridViewTextBoxColumn7.HeaderText = "发生日期";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 105;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "zts";
            this.dataGridViewTextBoxColumn9.FillWeight = 100.0677F;
            this.dataGridViewTextBoxColumn9.HeaderText = "状态";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 106;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "zy";
            this.dataGridViewTextBoxColumn8.FillWeight = 99.5935F;
            this.dataGridViewTextBoxColumn8.HeaderText = "原因";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 200;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "jgid";
            this.dataGridViewTextBoxColumn10.HeaderText = "jgid(隐藏)";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // BdsDskdkcx
            // 
            this.BdsDskdkcx.DataMember = "Vfmsdskdkcx";
            this.BdsDskdkcx.DataSource = this.Dsdskdkcx1;
            // 
            // Dsdskdkcx1
            // 
            this.Dsdskdkcx1.DataSetName = "DSDSKDKCX";
            this.Dsdskdkcx1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.BtnExcel);
            this.PnlBtns.Controls.Add(this.BtnQuery);
            this.PnlBtns.Controls.Add(this.BtnDksbcx);
            this.PnlBtns.Controls.Add(this.PnlJgcx);
            this.PnlBtns.Controls.Add(this.LblRowCount);
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.LblJgcx);
            this.PnlBtns.Controls.Add(this.TxtJg);
            this.PnlBtns.Controls.Add(this.TxtJgmc);
            this.PnlBtns.Controls.Add(this.label1);
            this.PnlBtns.Controls.Add(this.label2);
            this.PnlBtns.Controls.Add(this.label3);
            this.PnlBtns.Controls.Add(this.CmbYhlx);
            this.PnlBtns.Controls.Add(this.DtpCjStart);
            this.PnlBtns.Controls.Add(this.DtpCjStop);
            this.PnlBtns.Controls.Add(this.label4);
            this.PnlBtns.Controls.Add(this.CmbZt);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(750, 100);
            this.PnlBtns.TabIndex = 0;
            // 
            // BtnExcel
            // 
            this.BtnExcel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExcel.CustomStyle = "F";
            this.BtnExcel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcel.Location = new System.Drawing.Point(215, 71);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnExcel.TabIndex = 7;
            this.BtnExcel.Text = "导出";
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // BtnQuery
            // 
            this.BtnQuery.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnQuery.CustomStyle = "F";
            this.BtnQuery.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuery.Location = new System.Drawing.Point(13, 71);
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Size = new System.Drawing.Size(75, 23);
            this.BtnQuery.TabIndex = 6;
            this.BtnQuery.Text = "查询";
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // BtnDksbcx
            // 
            this.BtnDksbcx.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDksbcx.CustomStyle = "F";
            this.BtnDksbcx.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDksbcx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDksbcx.Location = new System.Drawing.Point(101, 71);
            this.BtnDksbcx.Name = "BtnDksbcx";
            this.BtnDksbcx.Size = new System.Drawing.Size(101, 23);
            this.BtnDksbcx.TabIndex = 6;
            this.BtnDksbcx.Text = "代扣结果确认";
            this.BtnDksbcx.Click += new System.EventHandler(this.BtnDksbcx_Click);
            // 
            // PnlJgcx
            // 
            this.PnlJgcx.Controls.Add(this.LstV);
            this.PnlJgcx.Location = new System.Drawing.Point(66, 68);
            this.PnlJgcx.Name = "PnlJgcx";
            this.PnlJgcx.Size = new System.Drawing.Size(233, 207);
            this.PnlJgcx.TabIndex = 16;
            // 
            // LstV
            // 
            this.LstV.AutoGenerateColumns = true;
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
            this.LstV.Size = new System.Drawing.Size(233, 207);
            this.LstV.TabIndex = 0;
            this.LstV.KeyPress += new Gizmox.WebGUI.Forms.KeyPressEventHandler(this.LstV_KeyPress);
            this.LstV.LostFocus += new System.EventHandler(this.LstV_LostFocus);
            this.LstV.DoubleClick += new System.EventHandler(this.LstV_DoubleClick);
            // 
            // LblRowCount
            // 
            this.LblRowCount.BackColor = System.Drawing.SystemColors.Window;
            this.LblRowCount.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblRowCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRowCount.ForeColor = System.Drawing.Color.Blue;
            this.LblRowCount.Location = new System.Drawing.Point(299, 72);
            this.LblRowCount.Name = "LblRowCount";
            this.LblRowCount.Size = new System.Drawing.Size(352, 22);
            this.LblRowCount.TabIndex = 15;
            this.LblRowCount.Text = "共有0条数据";
            this.LblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(651, 71);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 14;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // LblJgcx
            // 
            this.LblJgcx.AutoSize = true;
            this.LblJgcx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJgcx.Location = new System.Drawing.Point(10, 49);
            this.LblJgcx.Name = "LblJgcx";
            this.LblJgcx.Size = new System.Drawing.Size(53, 12);
            this.LblJgcx.TabIndex = 0;
            this.LblJgcx.Text = "缴款机构";
            // 
            // TxtJg
            // 
            this.TxtJg.AllowDrag = false;
            this.TxtJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJg.Location = new System.Drawing.Point(66, 46);
            this.TxtJg.Name = "TxtJg";
            this.TxtJg.Size = new System.Drawing.Size(58, 20);
            this.TxtJg.TabIndex = 4;
            this.TxtJg.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.TxtJg_EnterKeyDown);
            // 
            // TxtJgmc
            // 
            this.TxtJgmc.AllowDrag = false;
            this.TxtJgmc.Enabled = false;
            this.TxtJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJgmc.Location = new System.Drawing.Point(126, 46);
            this.TxtJgmc.Name = "TxtJgmc";
            this.TxtJgmc.Size = new System.Drawing.Size(173, 20);
            this.TxtJgmc.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "银行类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(220, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "代扣时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(406, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "至";
            // 
            // CmbYhlx
            // 
            this.CmbYhlx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbYhlx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYhlx.FormattingEnabled = true;
            this.CmbYhlx.Items.AddRange(new object[] {
            "建设银行"});
            this.CmbYhlx.Location = new System.Drawing.Point(66, 16);
            this.CmbYhlx.Name = "CmbYhlx";
            this.CmbYhlx.Size = new System.Drawing.Size(121, 20);
            this.CmbYhlx.TabIndex = 0;
            // 
            // DtpCjStart
            // 
            this.DtpCjStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpCjStart.CustomFormat = "yyyy.MM.dd";
            this.DtpCjStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpCjStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpCjStart.Location = new System.Drawing.Point(282, 16);
            this.DtpCjStart.Name = "DtpCjStart";
            this.DtpCjStart.Size = new System.Drawing.Size(123, 21);
            this.DtpCjStart.TabIndex = 1;
            // 
            // DtpCjStop
            // 
            this.DtpCjStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpCjStop.Checked = false;
            this.DtpCjStop.CustomFormat = "yyyy.MM.dd";
            this.DtpCjStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpCjStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpCjStop.Location = new System.Drawing.Point(424, 16);
            this.DtpCjStop.Name = "DtpCjStop";
            this.DtpCjStop.Size = new System.Drawing.Size(123, 21);
            this.DtpCjStop.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(565, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "状态";
            // 
            // CmbZt
            // 
            this.CmbZt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbZt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbZt.FormattingEnabled = true;
            this.CmbZt.Items.AddRange(new object[] {
            "全部",
            "成功",
            "失败"});
            this.CmbZt.Location = new System.Drawing.Point(610, 16);
            this.CmbZt.Name = "CmbZt";
            this.CmbZt.Size = new System.Drawing.Size(121, 20);
            this.CmbZt.TabIndex = 3;
            // 
            // DgvColTxtdamc
            // 
            this.DgvColTxtdamc.DataPropertyName = "dqmc";
            this.DgvColTxtdamc.HeaderText = "所属大区";
            this.DgvColTxtdamc.Name = "DgvColTxtdamc";
            this.DgvColTxtdamc.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "jgmc";
            this.dataGridViewTextBoxColumn2.HeaderText = "机构";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "rbdh";
            this.dataGridViewTextBoxColumn1.HeaderText = "日报单号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // DgvColTxtzcje
            // 
            this.DgvColTxtzcje.DataPropertyName = "zze";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtzcje.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColTxtzcje.HeaderText = "转出金额";
            this.DgvColTxtzcje.Name = "DgvColTxtzcje";
            this.DgvColTxtzcje.ReadOnly = true;
            // 
            // DgvColTxtinssj
            // 
            this.DgvColTxtinssj.DataPropertyName = "inssj";
            this.DgvColTxtinssj.HeaderText = "发生日期";
            this.DgvColTxtinssj.Name = "DgvColTxtinssj";
            this.DgvColTxtinssj.ReadOnly = true;
            // 
            // DgvColTxtzy
            // 
            this.DgvColTxtzy.DataPropertyName = "zy";
            this.DgvColTxtzy.FillWeight = 120F;
            this.DgvColTxtzy.HeaderText = "原因";
            this.DgvColTxtzy.Name = "DgvColTxtzy";
            this.DgvColTxtzy.ReadOnly = true;
            this.DgvColTxtzy.Width = 170;
            // 
            // vfmsdskdkcxTableAdapter1
            // 
            this.vfmsdskdkcxTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmDSKDKCX
            // 
            this.Controls.Add(this.PnlMain);
            this.Size = new System.Drawing.Size(750, 433);
            this.Text = "FrmDSKDKCX";
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BdsDskdkcx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dsdskdkcx1)).EndInit();
            this.PnlBtns.ResumeLayout(false);
            this.PnlJgcx.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private Panel PnlMain;
        private Panel PnlBtns;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox CmbYhlx;
        private DateTimePicker DtpCjStart;
        private DateTimePicker DtpCjStop;
        private Label label4;
        private ComboBox CmbZt;
        private Button BtnQuery;
        private Button BtnExcel;
        private Label LblJgcx;
        private TextBox TxtJg;
        private TextBox TxtJgmc;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtdamc;
        private DataGridViewTextBoxColumn DgvColTxtzcje;
        private DataGridViewTextBoxColumn DgvColTxtinssj;
        private DataGridViewTextBoxColumn DgvColTxtzy;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private DSDSKDKCX Dsdskdkcx1;
        private BindingSource BdsDskdkcx;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DSDSKDKCXTableAdapters.VfmsdskdkcxTableAdapter vfmsdskdkcxTableAdapter1;
        private Label LblRowCount;
        private Panel PnlJgcx;
        private ListView LstV;
        private Button BtnDksbcx;



        }
    }