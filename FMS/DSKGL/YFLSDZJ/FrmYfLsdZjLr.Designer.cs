using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.YFLSDZJ
{
    partial class FrmYfLsdZjLr
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColdamc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColjgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColyjje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColFlje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColyfkhj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColInsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColUpsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColId = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.BtnIn = new Gizmox.WebGUI.Forms.Button();
            this.DptUpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DptInStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.BtnQcDq = new Gizmox.WebGUI.Forms.Button();
            this.PnlDqcx = new Gizmox.WebGUI.Forms.Panel();
            this.LstVDq = new Gizmox.WebGUI.Forms.ListView();
            this.BtnYfkwh = new Gizmox.WebGUI.Forms.Button();
            this.TxtDq = new Gizmox.WebGUI.Forms.TextBox();
            this.DptInStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lbldq = new Gizmox.WebGUI.Forms.Label();
            this.BtnQcJg = new Gizmox.WebGUI.Forms.Button();
            this.TxtDqmc = new Gizmox.WebGUI.Forms.TextBox();
            this.DptUpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.TxtJgmc = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.TxtJg = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.PnlJgcx = new Gizmox.WebGUI.Forms.Panel();
            this.LstV = new Gizmox.WebGUI.Forms.ListView();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.BtnDel = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.PnlTop.SuspendLayout();
            this.PnlDqcx.SuspendLayout();
            this.PnlJgcx.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Controls.Add(this.PnlTop);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1018, 436);
            this.PnlMain.TabIndex = 1;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.Dgv.AutoGenerateColumns = false;
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvColdamc,
            this.DgvColjgmc,
            this.DgvColyjje,
            this.DgvColFlje,
            this.DgvColyfkhj,
            this.DgvColInsj,
            this.DgvColUpsj,
            this.DgvColId});
            dataGridViewCellStyle13.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle13;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 72);
            this.Dgv.Name = "Dgv";
            dataGridViewCellStyle14.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(1018, 364);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColdamc
            // 
            this.DgvColdamc.DataPropertyName = "dqmc";
            this.DgvColdamc.HeaderText = "所属大区";
            this.DgvColdamc.Name = "DgvColdamc";
            // 
            // DgvColjgmc
            // 
            this.DgvColjgmc.DataPropertyName = "jgmc";
            this.DgvColjgmc.HeaderText = "连锁店名称";
            this.DgvColjgmc.Name = "DgvColjgmc";
            // 
            // DgvColyjje
            // 
            this.DgvColyjje.DataPropertyName = "yjje";
            dataGridViewCellStyle10.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColyjje.DefaultCellStyle = dataGridViewCellStyle10;
            this.DgvColyjje.HeaderText = "押金金额";
            this.DgvColyjje.Name = "DgvColyjje";
            // 
            // DgvColFlje
            // 
            this.DgvColFlje.DataPropertyName = "flje";
            dataGridViewCellStyle11.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColFlje.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvColFlje.HeaderText = "返利金额";
            this.DgvColFlje.Name = "DgvColFlje";
            // 
            // DgvColyfkhj
            // 
            this.DgvColyfkhj.DataPropertyName = "yfkhj";
            dataGridViewCellStyle12.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColyfkhj.DefaultCellStyle = dataGridViewCellStyle12;
            this.DgvColyfkhj.HeaderText = "应付款合计";
            this.DgvColyfkhj.Name = "DgvColyfkhj";
            // 
            // DgvColInsj
            // 
            this.DgvColInsj.DataPropertyName = "insj";
            this.DgvColInsj.HeaderText = "创建时间";
            this.DgvColInsj.Name = "DgvColInsj";
            // 
            // DgvColUpsj
            // 
            this.DgvColUpsj.DataPropertyName = "upsj";
            this.DgvColUpsj.HeaderText = "修改时间";
            this.DgvColUpsj.Name = "DgvColUpsj";
            // 
            // DgvColId
            // 
            this.DgvColId.DataPropertyName = "id";
            this.DgvColId.HeaderText = "id";
            this.DgvColId.Name = "DgvColId";
            this.DgvColId.Visible = false;
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnDel);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnIn);
            this.PnlTop.Controls.Add(this.DptUpStop);
            this.PnlTop.Controls.Add(this.DptInStop);
            this.PnlTop.Controls.Add(this.BtnQcDq);
            this.PnlTop.Controls.Add(this.PnlDqcx);
            this.PnlTop.Controls.Add(this.BtnYfkwh);
            this.PnlTop.Controls.Add(this.TxtDq);
            this.PnlTop.Controls.Add(this.DptInStart);
            this.PnlTop.Controls.Add(this.lbldq);
            this.PnlTop.Controls.Add(this.BtnQcJg);
            this.PnlTop.Controls.Add(this.TxtDqmc);
            this.PnlTop.Controls.Add(this.DptUpStart);
            this.PnlTop.Controls.Add(this.TxtJgmc);
            this.PnlTop.Controls.Add(this.label4);
            this.PnlTop.Controls.Add(this.BtnExl);
            this.PnlTop.Controls.Add(this.TxtJg);
            this.PnlTop.Controls.Add(this.BtnSave);
            this.PnlTop.Controls.Add(this.PnlJgcx);
            this.PnlTop.Controls.Add(this.label6);
            this.PnlTop.Controls.Add(this.label5);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(1018, 72);
            this.PnlTop.TabIndex = 0;
            // 
            // BtnIn
            // 
            this.BtnIn.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnIn.CustomStyle = "F";
            this.BtnIn.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnIn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIn.Location = new System.Drawing.Point(107, 36);
            this.BtnIn.Name = "BtnIn";
            this.BtnIn.Size = new System.Drawing.Size(75, 23);
            this.BtnIn.TabIndex = 6;
            this.BtnIn.Text = "新增";
            this.BtnIn.Click += new System.EventHandler(this.BtnIn_Click);
            // 
            // DptUpStop
            // 
            this.DptUpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DptUpStop.Checked = false;
            this.DptUpStop.CustomFormat = "yyyy.MM.dd";
            this.DptUpStop.Font = new System.Drawing.Font("宋体", 9F);
            this.DptUpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DptUpStop.Location = new System.Drawing.Point(418, 6);
            this.DptUpStop.Name = "DptUpStop";
            this.DptUpStop.ShowCheckBox = true;
            this.DptUpStop.Size = new System.Drawing.Size(100, 21);
            this.DptUpStop.TabIndex = 0;
            // 
            // DptInStop
            // 
            this.DptInStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DptInStop.Checked = false;
            this.DptInStop.CustomFormat = "yyyy.MM.dd";
            this.DptInStop.Font = new System.Drawing.Font("宋体", 9F);
            this.DptInStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DptInStop.Location = new System.Drawing.Point(160, 6);
            this.DptInStop.Name = "DptInStop";
            this.DptInStop.ShowCheckBox = true;
            this.DptInStop.Size = new System.Drawing.Size(100, 21);
            this.DptInStop.TabIndex = 0;
            // 
            // BtnQcDq
            // 
            this.BtnQcDq.CustomStyle = "F";
            this.BtnQcDq.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQcDq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQcDq.Location = new System.Drawing.Point(988, 7);
            this.BtnQcDq.Name = "BtnQcDq";
            this.BtnQcDq.Size = new System.Drawing.Size(26, 21);
            this.BtnQcDq.TabIndex = 3;
            this.BtnQcDq.Text = "清";
            this.BtnQcDq.Click += new System.EventHandler(this.BtnQcDq_Click);
            // 
            // PnlDqcx
            // 
            this.PnlDqcx.Controls.Add(this.LstVDq);
            this.PnlDqcx.Location = new System.Drawing.Point(802, 28);
            this.PnlDqcx.Name = "PnlDqcx";
            this.PnlDqcx.Size = new System.Drawing.Size(209, 206);
            this.PnlDqcx.TabIndex = 17;
            // 
            // LstVDq
            // 
            this.LstVDq.AutoGenerateColumns = true;
            this.LstVDq.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.LstVDq.DataMember = null;
            this.LstVDq.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.LstVDq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstVDq.FullRowSelect = true;
            this.LstVDq.GridLines = true;
            this.LstVDq.ItemsPerPage = 20;
            this.LstVDq.Location = new System.Drawing.Point(0, 0);
            this.LstVDq.Name = "LstVDq";
            this.LstVDq.ShowGroups = false;
            this.LstVDq.ShowItemToolTips = false;
            this.LstVDq.Size = new System.Drawing.Size(209, 206);
            this.LstVDq.TabIndex = 0;
            this.LstVDq.KeyPress += new Gizmox.WebGUI.Forms.KeyPressEventHandler(this.LstVDq_KeyPress);
            this.LstVDq.LostFocus += new System.EventHandler(this.LstVDq_LostFocus);
            this.LstVDq.DoubleClick += new System.EventHandler(this.LstVDq_DoubleClick);
            // 
            // BtnYfkwh
            // 
            this.BtnYfkwh.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnYfkwh.CustomStyle = "F";
            this.BtnYfkwh.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnYfkwh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnYfkwh.Location = new System.Drawing.Point(197, 36);
            this.BtnYfkwh.Name = "BtnYfkwh";
            this.BtnYfkwh.Size = new System.Drawing.Size(75, 23);
            this.BtnYfkwh.TabIndex = 6;
            this.BtnYfkwh.Text = "应付款维护";
            this.BtnYfkwh.Click += new System.EventHandler(this.BtnYfkwh_Click);
            // 
            // TxtDq
            // 
            this.TxtDq.AllowDrag = false;
            this.TxtDq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDq.Location = new System.Drawing.Point(802, 9);
            this.TxtDq.Name = "TxtDq";
            this.TxtDq.Size = new System.Drawing.Size(58, 20);
            this.TxtDq.TabIndex = 1;
            this.TxtDq.TextChanged += new System.EventHandler(this.TxtDq_TextChanged);
            // 
            // DptInStart
            // 
            this.DptInStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DptInStart.Checked = false;
            this.DptInStart.CustomFormat = "yyyy.MM.dd";
            this.DptInStart.Font = new System.Drawing.Font("宋体", 9F);
            this.DptInStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DptInStart.Location = new System.Drawing.Point(58, 6);
            this.DptInStart.Name = "DptInStart";
            this.DptInStart.ShowCheckBox = true;
            this.DptInStart.Size = new System.Drawing.Size(100, 21);
            this.DptInStart.TabIndex = 0;
            // 
            // lbldq
            // 
            this.lbldq.AutoSize = true;
            this.lbldq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldq.Location = new System.Drawing.Point(773, 13);
            this.lbldq.Name = "lbldq";
            this.lbldq.Size = new System.Drawing.Size(53, 12);
            this.lbldq.TabIndex = 3;
            this.lbldq.Text = "大区";
            // 
            // BtnQcJg
            // 
            this.BtnQcJg.CustomStyle = "F";
            this.BtnQcJg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQcJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQcJg.Location = new System.Drawing.Point(740, 8);
            this.BtnQcJg.Name = "BtnQcJg";
            this.BtnQcJg.Size = new System.Drawing.Size(26, 21);
            this.BtnQcJg.TabIndex = 3;
            this.BtnQcJg.Text = "清";
            this.BtnQcJg.Click += new System.EventHandler(this.BtnQcJg_Click);
            // 
            // TxtDqmc
            // 
            this.TxtDqmc.AllowDrag = false;
            this.TxtDqmc.Enabled = false;
            this.TxtDqmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDqmc.Location = new System.Drawing.Point(864, 9);
            this.TxtDqmc.Name = "TxtDqmc";
            this.TxtDqmc.Size = new System.Drawing.Size(121, 20);
            this.TxtDqmc.TabIndex = 2;
            // 
            // DptUpStart
            // 
            this.DptUpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DptUpStart.Checked = false;
            this.DptUpStart.CustomFormat = "yyyy.MM.dd";
            this.DptUpStart.Font = new System.Drawing.Font("宋体", 9F);
            this.DptUpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DptUpStart.Location = new System.Drawing.Point(316, 6);
            this.DptUpStart.Name = "DptUpStart";
            this.DptUpStart.ShowCheckBox = true;
            this.DptUpStart.Size = new System.Drawing.Size(100, 21);
            this.DptUpStart.TabIndex = 0;
            // 
            // TxtJgmc
            // 
            this.TxtJgmc.AllowDrag = false;
            this.TxtJgmc.Enabled = false;
            this.TxtJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJgmc.Location = new System.Drawing.Point(616, 9);
            this.TxtJgmc.Name = "TxtJgmc";
            this.TxtJgmc.Size = new System.Drawing.Size(121, 20);
            this.TxtJgmc.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(523, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "机构";
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(377, 36);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 7;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // TxtJg
            // 
            this.TxtJg.AllowDrag = false;
            this.TxtJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJg.Location = new System.Drawing.Point(554, 9);
            this.TxtJg.Name = "TxtJg";
            this.TxtJg.Size = new System.Drawing.Size(58, 20);
            this.TxtJg.TabIndex = 1;
            this.TxtJg.TextChanged += new System.EventHandler(this.TxtJg_TextChanged);
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(17, 36);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "查询";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // PnlJgcx
            // 
            this.PnlJgcx.Controls.Add(this.LstV);
            this.PnlJgcx.Location = new System.Drawing.Point(554, 28);
            this.PnlJgcx.Name = "PnlJgcx";
            this.PnlJgcx.Size = new System.Drawing.Size(209, 206);
            this.PnlJgcx.TabIndex = 17;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(264, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "修改时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "创建时间";
            // 
            // BtnDel
            // 
            this.BtnDel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDel.CustomStyle = "F";
            this.BtnDel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDel.Location = new System.Drawing.Point(287, 36);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(75, 23);
            this.BtnDel.TabIndex = 6;
            this.BtnDel.Text = "删除";
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.ctrlDownLoad1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDownLoad1.Location = new System.Drawing.Point(467, 34);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 18;
            this.ctrlDownLoad1.Visible = false;
            // 
            // FrmYfLsdZjLr
            // 
            this.Controls.Add(this.PnlMain);
            this.Location = new System.Drawing.Point(-53, 0);
            this.Size = new System.Drawing.Size(1018, 436);
            this.Text = "FrmYfLsdZjLr";
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.PnlTop.ResumeLayout(false);
            this.PnlDqcx.ResumeLayout(false);
            this.PnlJgcx.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlMain;
        private Panel PnlTop;
        private Button BtnQcDq;
        private Panel PnlDqcx;
        private ListView LstVDq;
        private Button BtnYfkwh;
        private TextBox TxtDq;
        private DateTimePicker DptInStart;
        private Label lbldq;
        private Button BtnQcJg;
        private TextBox TxtDqmc;
        private DateTimePicker DptUpStart;
        private TextBox TxtJgmc;
        private Label label4;
        private Button BtnExl;
        private TextBox TxtJg;
        private Button BtnSave;
        private Panel PnlJgcx;
        private ListView LstV;
        private Label label6;
        private Label label5;
        private DateTimePicker DptUpStop;
        private DateTimePicker DptInStop;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColdamc;
        private DataGridViewTextBoxColumn DgvColjgmc;
        private DataGridViewTextBoxColumn DgvColyjje;
        private DataGridViewTextBoxColumn DgvColFlje;
        private DataGridViewTextBoxColumn DgvColyfkhj;
        private DataGridViewTextBoxColumn DgvColInsj;
        private DataGridViewTextBoxColumn DgvColUpsj;
        private Button BtnIn;
        private DataGridViewTextBoxColumn DgvColId;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnDel;


    }
}