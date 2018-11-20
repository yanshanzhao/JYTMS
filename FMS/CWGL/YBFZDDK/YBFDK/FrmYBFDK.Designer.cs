using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.YBFZDDK.YBFDK
    {
    partial class FrmYBFDK
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
            this.BtnCheck = new Gizmox.WebGUI.Forms.Button();
            this.LblCheckCount = new Gizmox.WebGUI.Forms.Label();
            this.DgvColTxtscje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.CmbYHlx = new Gizmox.WebGUI.Forms.ComboBox();
            this.TxtJgmc = new Gizmox.WebGUI.Forms.TextBox();
            this.DgvColTxtyhzhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.DgvColTxtJkrb = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.menuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            this.ChkB = new Gizmox.WebGUI.Forms.CheckBox();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColCbm = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.DgvColTxtCkdq = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJkjg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtCksj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtRbdh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYhzh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSck = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZzje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYck = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYhlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtrbid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYhlxid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZczhid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSybfdk1 = new FMS.CWGL.YBFZDDK.YBFDK.DSYBFDK();
            this.BtnSh = new Gizmox.WebGUI.Forms.Button();
            this.LblZzqq = new Gizmox.WebGUI.Forms.Label();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.LblZzzq = new Gizmox.WebGUI.Forms.Label();
            this.BtnSearch = new Gizmox.WebGUI.Forms.Button();
            this.LblYwqy = new Gizmox.WebGUI.Forms.Label();
            this.CmbYwqy = new Gizmox.WebGUI.Forms.ComboBox();
            this.LblZt = new Gizmox.WebGUI.Forms.Label();
            this.CmbZt = new Gizmox.WebGUI.Forms.ComboBox();
            this.TxtJg = new Gizmox.WebGUI.Forms.TextBox();
            this.LblJgcx = new Gizmox.WebGUI.Forms.Label();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.BtnClear1 = new Gizmox.WebGUI.Forms.Button();
            this.PnlJgcx = new Gizmox.WebGUI.Forms.Panel();
            this.LstV = new Gizmox.WebGUI.Forms.ListView();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.LblJgid = new Gizmox.WebGUI.Forms.Label();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.menuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
            this.VfmsYbfdkTableAdapter1 = new FMS.CWGL.YBFZDDK.YBFDK.DSYBFDKTableAdapters.VfmsYbfdkTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSybfdk1)).BeginInit();
            this.PnlBtns.SuspendLayout();
            this.PnlJgcx.SuspendLayout();
            this.PnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCheck
            // 
            this.BtnCheck.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnCheck.CustomStyle = "F";
            this.BtnCheck.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnCheck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCheck.Location = new System.Drawing.Point(110, 64);
            this.BtnCheck.Name = "BtnCheck";
            this.BtnCheck.Size = new System.Drawing.Size(75, 23);
            this.BtnCheck.TabIndex = 9;
            this.BtnCheck.Text = "本页全选";
            this.BtnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // LblCheckCount
            // 
            this.LblCheckCount.BackColor = System.Drawing.SystemColors.Window;
            this.LblCheckCount.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblCheckCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCheckCount.ForeColor = System.Drawing.Color.Blue;
            this.LblCheckCount.Location = new System.Drawing.Point(398, 66);
            this.LblCheckCount.Name = "LblCheckCount";
            this.LblCheckCount.Size = new System.Drawing.Size(249, 21);
            this.LblCheckCount.TabIndex = 18;
            this.LblCheckCount.Text = "共选中0行,选中代扣金额共0.00元";
            this.LblCheckCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvColTxtscje
            // 
            this.DgvColTxtscje.DataPropertyName = "sjsc";
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtscje.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvColTxtscje.HeaderText = "实存金额(元)";
            this.DgvColTxtscje.Name = "DgvColTxtscje";
            this.DgvColTxtscje.ReadOnly = true;
            this.DgvColTxtscje.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CmbYHlx
            // 
            this.CmbYHlx.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.CmbYHlx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbYHlx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYHlx.FormattingEnabled = true;
            this.CmbYHlx.Items.AddRange(new object[] {
            "建设银行"});
            this.CmbYHlx.Location = new System.Drawing.Point(347, 9);
            this.CmbYHlx.Name = "CmbYHlx";
            this.CmbYHlx.Size = new System.Drawing.Size(133, 20);
            this.CmbYHlx.TabIndex = 3;
            // 
            // TxtJgmc
            // 
            this.TxtJgmc.AllowDrag = false;
            this.TxtJgmc.Enabled = false;
            this.TxtJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJgmc.Location = new System.Drawing.Point(130, 9);
            this.TxtJgmc.Name = "TxtJgmc";
            this.TxtJgmc.Size = new System.Drawing.Size(121, 20);
            this.TxtJgmc.TabIndex = 1;
            // 
            // DgvColTxtyhzhmc
            // 
            this.DgvColTxtyhzhmc.DataPropertyName = "zhmc";
            this.DgvColTxtyhzhmc.HeaderText = "银行账户名称";
            this.DgvColTxtyhzhmc.Name = "DgvColTxtyhzhmc";
            this.DgvColTxtyhzhmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(294, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "银行类型";
            // 
            // DgvColTxtJkrb
            // 
            this.DgvColTxtJkrb.DataPropertyName = "rbdh";
            this.DgvColTxtJkrb.HeaderText = "缴款日报号";
            this.DgvColTxtJkrb.Name = "DgvColTxtJkrb";
            this.DgvColTxtJkrb.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // menuItem1
            // 
            this.menuItem1.Index = -1;
            this.menuItem1.Text = "Excel报表";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = -1;
            this.menuItem2.Text = "建行网银";
            // 
            // ChkB
            // 
            this.ChkB.AutoSize = true;
            this.ChkB.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.ChkB.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkB.Location = new System.Drawing.Point(56, 98);
            this.ChkB.Name = "ChkB";
            this.ChkB.Size = new System.Drawing.Size(15, 14);
            this.ChkB.TabIndex = 2;
            this.ChkB.CheckedChanged += new System.EventHandler(this.ChkB_CheckedChanged);
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
            this.DgvColCbm,
            this.DgvColTxtCkdq,
            this.DgvColTxtJkjg,
            this.DgvColTxtCksj,
            this.DgvColTxtRbdh,
            this.DgvColTxtYhzh,
            this.DgvColTxtZhmc,
            this.DgvColTxtSck,
            this.DgvColTxtZzje,
            this.DgvColTxtYck,
            this.DgvColTxtYhlx,
            this.DgvColTxtrbid,
            this.DgvColTxtYhlxid,
            this.DgvColTxtZczhid});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.Bds;
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
            this.Dgv.ItemsPerPage = 20;
            this.Dgv.Location = new System.Drawing.Point(0, 93);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
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
            this.Dgv.Size = new System.Drawing.Size(881, 339);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // DgvColCbm
            // 
            this.DgvColCbm.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.DgvColCbm.Frozen = true;
            this.DgvColCbm.HeaderText = "全选";
            this.DgvColCbm.Name = "DgvColCbm";
            this.DgvColCbm.ReadOnly = true;
            this.DgvColCbm.Width = 60;
            // 
            // DgvColTxtCkdq
            // 
            this.DgvColTxtCkdq.DataPropertyName = "dqmc";
            this.DgvColTxtCkdq.Frozen = true;
            this.DgvColTxtCkdq.HeaderText = "存款大区";
            this.DgvColTxtCkdq.Name = "DgvColTxtCkdq";
            this.DgvColTxtCkdq.ReadOnly = true;
            this.DgvColTxtCkdq.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtJkjg
            // 
            this.DgvColTxtJkjg.DataPropertyName = "jgmc";
            this.DgvColTxtJkjg.Frozen = true;
            this.DgvColTxtJkjg.HeaderText = "缴款机构";
            this.DgvColTxtJkjg.Name = "DgvColTxtJkjg";
            this.DgvColTxtJkjg.ReadOnly = true;
            this.DgvColTxtJkjg.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtJkjg.Width = 140;
            // 
            // DgvColTxtCksj
            // 
            this.DgvColTxtCksj.DataPropertyName = "cksj";
            this.DgvColTxtCksj.HeaderText = "存款时间";
            this.DgvColTxtCksj.Name = "DgvColTxtCksj";
            this.DgvColTxtCksj.ReadOnly = true;
            this.DgvColTxtCksj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtRbdh
            // 
            this.DgvColTxtRbdh.DataPropertyName = "rbdh";
            this.DgvColTxtRbdh.HeaderText = "缴款日报号";
            this.DgvColTxtRbdh.Name = "DgvColTxtRbdh";
            this.DgvColTxtRbdh.ReadOnly = true;
            this.DgvColTxtRbdh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtYhzh
            // 
            this.DgvColTxtYhzh.DataPropertyName = "zh";
            this.DgvColTxtYhzh.HeaderText = "银行账户";
            this.DgvColTxtYhzh.Name = "DgvColTxtYhzh";
            this.DgvColTxtYhzh.ReadOnly = true;
            this.DgvColTxtYhzh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtZhmc
            // 
            this.DgvColTxtZhmc.DataPropertyName = "zhmc";
            this.DgvColTxtZhmc.HeaderText = "银行账户名称";
            this.DgvColTxtZhmc.Name = "DgvColTxtZhmc";
            this.DgvColTxtZhmc.ReadOnly = true;
            this.DgvColTxtZhmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtSck
            // 
            this.DgvColTxtSck.DataPropertyName = "sjsc";
            this.DgvColTxtSck.HeaderText = "实存金额(元)";
            this.DgvColTxtSck.Name = "DgvColTxtSck";
            this.DgvColTxtSck.ReadOnly = true;
            this.DgvColTxtSck.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtZzje
            // 
            this.DgvColTxtZzje.DataPropertyName = "zzje";
            this.DgvColTxtZzje.HeaderText = "坐支金额";
            this.DgvColTxtZzje.Name = "DgvColTxtZzje";
            this.DgvColTxtZzje.ReadOnly = true;
            this.DgvColTxtZzje.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtYck
            // 
            this.DgvColTxtYck.DataPropertyName = "sjyc";
            this.DgvColTxtYck.HeaderText = "实际应存(元)";
            this.DgvColTxtYck.Name = "DgvColTxtYck";
            this.DgvColTxtYck.ReadOnly = true;
            this.DgvColTxtYck.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtYhlx
            // 
            this.DgvColTxtYhlx.DataPropertyName = "jc";
            this.DgvColTxtYhlx.HeaderText = "银行类型";
            this.DgvColTxtYhlx.Name = "DgvColTxtYhlx";
            this.DgvColTxtYhlx.ReadOnly = true;
            this.DgvColTxtYhlx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtrbid
            // 
            this.DgvColTxtrbid.DataPropertyName = "ybfrbpcid";
            this.DgvColTxtrbid.HeaderText = "日报ID[隐藏]";
            this.DgvColTxtrbid.Name = "DgvColTxtrbid";
            this.DgvColTxtrbid.ReadOnly = true;
            this.DgvColTxtrbid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtrbid.Visible = false;
            // 
            // DgvColTxtYhlxid
            // 
            this.DgvColTxtYhlxid.DataPropertyName = "yhlxid";
            this.DgvColTxtYhlxid.HeaderText = "yhlxid[隐藏]";
            this.DgvColTxtYhlxid.Name = "DgvColTxtYhlxid";
            this.DgvColTxtYhlxid.ReadOnly = true;
            this.DgvColTxtYhlxid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtYhlxid.Visible = false;
            // 
            // DgvColTxtZczhid
            // 
            this.DgvColTxtZczhid.DataPropertyName = "zczhid";
            this.DgvColTxtZczhid.HeaderText = "zczhid[隐藏]";
            this.DgvColTxtZczhid.Name = "DgvColTxtZczhid";
            this.DgvColTxtZczhid.ReadOnly = true;
            this.DgvColTxtZczhid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtZczhid.Visible = false;
            // 
            // Bds
            // 
            this.Bds.DataMember = "VfmsYbfdk";
            this.Bds.DataSource = this.DSybfdk1;
            // 
            // DSybfdk1
            // 
            this.DSybfdk1.DataSetName = "DSYBFDK";
            this.DSybfdk1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BtnSh
            // 
            this.BtnSh.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnSh.CustomStyle = "F";
            this.BtnSh.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSh.Location = new System.Drawing.Point(206, 64);
            this.BtnSh.Name = "BtnSh";
            this.BtnSh.Size = new System.Drawing.Size(75, 23);
            this.BtnSh.TabIndex = 10;
            this.BtnSh.Text = "代扣";
            this.BtnSh.Click += new System.EventHandler(this.BtnSh_Click);
            // 
            // LblZzqq
            // 
            this.LblZzqq.AutoSize = true;
            this.LblZzqq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZzqq.Location = new System.Drawing.Point(294, 41);
            this.LblZzqq.Name = "LblZzqq";
            this.LblZzqq.Size = new System.Drawing.Size(53, 12);
            this.LblZzqq.TabIndex = 0;
            this.LblZzqq.Text = "开始日期";
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(347, 37);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(133, 21);
            this.DtpStart.TabIndex = 6;
            // 
            // DtpStop
            // 
            this.DtpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStop.CustomFormat = "yyyy.MM.dd";
            this.DtpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStop.Location = new System.Drawing.Point(534, 37);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.Size = new System.Drawing.Size(133, 21);
            this.DtpStop.TabIndex = 7;
            // 
            // LblZzzq
            // 
            this.LblZzzq.AutoSize = true;
            this.LblZzzq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZzzq.Location = new System.Drawing.Point(480, 41);
            this.LblZzzq.Name = "LblZzzq";
            this.LblZzzq.Size = new System.Drawing.Size(53, 12);
            this.LblZzzq.TabIndex = 0;
            this.LblZzzq.Text = "结束日期";
            // 
            // BtnSearch
            // 
            this.BtnSearch.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnSearch.CustomStyle = "F";
            this.BtnSearch.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(14, 64);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 8;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // LblYwqy
            // 
            this.LblYwqy.AutoSize = true;
            this.LblYwqy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYwqy.Location = new System.Drawing.Point(14, 41);
            this.LblYwqy.Name = "LblYwqy";
            this.LblYwqy.Size = new System.Drawing.Size(53, 12);
            this.LblYwqy.TabIndex = 0;
            this.LblYwqy.Text = "业务区域";
            // 
            // CmbYwqy
            // 
            this.CmbYwqy.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.CmbYwqy.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbYwqy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYwqy.FormattingEnabled = true;
            this.CmbYwqy.Location = new System.Drawing.Point(70, 37);
            this.CmbYwqy.Name = "CmbYwqy";
            this.CmbYwqy.Size = new System.Drawing.Size(181, 20);
            this.CmbYwqy.TabIndex = 5;
            // 
            // LblZt
            // 
            this.LblZt.AutoSize = true;
            this.LblZt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZt.Location = new System.Drawing.Point(502, 13);
            this.LblZt.Name = "LblZt";
            this.LblZt.Size = new System.Drawing.Size(29, 12);
            this.LblZt.TabIndex = 0;
            this.LblZt.Text = "状态";
            // 
            // CmbZt
            // 
            this.CmbZt.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.CmbZt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbZt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbZt.FormattingEnabled = true;
            this.CmbZt.Items.AddRange(new object[] {
            "未代扣",
            "代扣失败",
            "代扣成功 "});
            this.CmbZt.Location = new System.Drawing.Point(534, 9);
            this.CmbZt.Name = "CmbZt";
            this.CmbZt.Size = new System.Drawing.Size(133, 20);
            this.CmbZt.TabIndex = 4;
            // 
            // TxtJg
            // 
            this.TxtJg.AllowDrag = false;
            this.TxtJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJg.Location = new System.Drawing.Point(70, 9);
            this.TxtJg.Name = "TxtJg";
            this.TxtJg.Size = new System.Drawing.Size(58, 20);
            this.TxtJg.TabIndex = 0;
            this.TxtJg.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.TxtJg_EnterKeyDown_1);
            // 
            // LblJgcx
            // 
            this.LblJgcx.AutoSize = true;
            this.LblJgcx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJgcx.Location = new System.Drawing.Point(14, 13);
            this.LblJgcx.Name = "LblJgcx";
            this.LblJgcx.Size = new System.Drawing.Size(53, 12);
            this.LblJgcx.TabIndex = 0;
            this.LblJgcx.Text = "缴款机构";
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.BtnClear1);
            this.PnlBtns.Controls.Add(this.PnlJgcx);
            this.PnlBtns.Controls.Add(this.BtnExl);
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.LblJgid);
            this.PnlBtns.Controls.Add(this.BtnCheck);
            this.PnlBtns.Controls.Add(this.LblCheckCount);
            this.PnlBtns.Controls.Add(this.CmbYHlx);
            this.PnlBtns.Controls.Add(this.label1);
            this.PnlBtns.Controls.Add(this.TxtJgmc);
            this.PnlBtns.Controls.Add(this.BtnSh);
            this.PnlBtns.Controls.Add(this.LblZzqq);
            this.PnlBtns.Controls.Add(this.DtpStart);
            this.PnlBtns.Controls.Add(this.DtpStop);
            this.PnlBtns.Controls.Add(this.LblZzzq);
            this.PnlBtns.Controls.Add(this.BtnSearch);
            this.PnlBtns.Controls.Add(this.LblYwqy);
            this.PnlBtns.Controls.Add(this.CmbYwqy);
            this.PnlBtns.Controls.Add(this.LblZt);
            this.PnlBtns.Controls.Add(this.CmbZt);
            this.PnlBtns.Controls.Add(this.TxtJg);
            this.PnlBtns.Controls.Add(this.LblJgcx);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(881, 93);
            this.PnlBtns.TabIndex = 0;
            // 
            // BtnClear1
            // 
            this.BtnClear1.CustomStyle = "F";
            this.BtnClear1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnClear1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear1.Location = new System.Drawing.Point(253, 9);
            this.BtnClear1.Name = "BtnClear1";
            this.BtnClear1.Size = new System.Drawing.Size(26, 21);
            this.BtnClear1.TabIndex = 2;
            this.BtnClear1.Text = "清";
            this.BtnClear1.Click += new System.EventHandler(this.BtnClear1_Click);
            // 
            // PnlJgcx
            // 
            this.PnlJgcx.Controls.Add(this.LstV);
            this.PnlJgcx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlJgcx.Location = new System.Drawing.Point(70, 32);
            this.PnlJgcx.Name = "PnlJgcx";
            this.PnlJgcx.Size = new System.Drawing.Size(250, 226);
            this.PnlJgcx.TabIndex = 22;
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
            this.LstV.Size = new System.Drawing.Size(250, 226);
            this.LstV.TabIndex = 0;
            this.LstV.KeyPress += new Gizmox.WebGUI.Forms.KeyPressEventHandler(this.LstV_KeyPress);
            this.LstV.LostFocus += new System.EventHandler(this.LstV_LostFocus);
            this.LstV.DoubleClick += new System.EventHandler(this.LstV_DoubleClick);
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(302, 64);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 11;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(668, 62);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 23;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // LblJgid
            // 
            this.LblJgid.AutoSize = true;
            this.LblJgid.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJgid.Location = new System.Drawing.Point(811, 81);
            this.LblJgid.Name = "LblJgid";
            this.LblJgid.Size = new System.Drawing.Size(29, 12);
            this.LblJgid.TabIndex = 0;
            this.LblJgid.Visible = false;
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.ChkB);
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Controls.Add(this.PnlBtns);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(881, 432);
            this.PnlMain.TabIndex = 0;
            // 
            // menuItem3
            // 
            this.menuItem3.Index = -1;
            this.menuItem3.Text = "农行网银";
            // 
            // VfmsYbfdkTableAdapter1
            // 
            this.VfmsYbfdkTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmYBFDK
            // 
            this.Controls.Add(this.PnlMain);
            this.Size = new System.Drawing.Size(881, 432);
            this.Text = "FrmYBFDK";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSybfdk1)).EndInit();
            this.PnlBtns.ResumeLayout(false);
            this.PnlJgcx.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private Button BtnCheck;
        private Label LblCheckCount;
        private DataGridViewTextBoxColumn DgvColTxtscje;
        private ComboBox CmbYHlx;
        private TextBox TxtJgmc;
        private DataGridViewTextBoxColumn DgvColTxtyhzhmc;
        private Label label1;
        private DataGridViewTextBoxColumn DgvColTxtJkrb;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private CheckBox ChkB;
        private DataGridView Dgv;
     
        private Button BtnSh;
        private Label LblZzqq;
        private DateTimePicker DtpStart;
        private DateTimePicker DtpStop;
        private Label LblZzzq;
        private Button BtnSearch;
        private Label LblYwqy;
        private ComboBox CmbYwqy;
        private Label LblZt;
        private ComboBox CmbZt;
        private TextBox TxtJg;
        private Label LblJgcx;
        private Panel PnlBtns;
        private Panel PnlMain;
        private MenuItem menuItem3;
        private Panel PnlJgcx;
        private BindingSource Bds;
        private DSYBFDK DSybfdk1;
        private DSYBFDKTableAdapters.VfmsYbfdkTableAdapter VfmsYbfdkTableAdapter1;
        private DataGridViewTextBoxColumn DgvColTxtCkdq;
        private DataGridViewTextBoxColumn DgvColTxtJkjg;
        private DataGridViewTextBoxColumn DgvColTxtCksj;
        private DataGridViewTextBoxColumn DgvColTxtRbdh;
        private DataGridViewTextBoxColumn DgvColTxtYhzh;
        private DataGridViewTextBoxColumn DgvColTxtZhmc;
        private DataGridViewTextBoxColumn DgvColTxtYck;
        private DataGridViewTextBoxColumn DgvColTxtZzje;
        private DataGridViewTextBoxColumn DgvColTxtSck;
        private DataGridViewTextBoxColumn DgvColTxtYhlx;
        private DataGridViewTextBoxColumn DgvColTxtrbid;
        private Label LblJgid;
        private DataGridViewCheckBoxColumn DgvColCbm;
        private DataGridViewTextBoxColumn DgvColTxtYhlxid;
        private DataGridViewTextBoxColumn DgvColTxtZczhid;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private ListView LstV;
        private Button BtnClear1;


        }
    }
