using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.YYSRCX
{
    partial class FrmYCZW
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnClose = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.BtnJg = new Gizmox.WebGUI.Forms.Button();
            this.TxtBJgmc = new Gizmox.WebGUI.Forms.TextBox();
            this.CmbJglx = new Gizmox.WebGUI.Forms.ComboBox();
            this.CmbYwqy = new Gizmox.WebGUI.Forms.ComboBox();
            this.CmbJzlx = new Gizmox.WebGUI.Forms.ComboBox();
            this.DtpQrStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpQrStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtjzjg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtjzlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtywqy = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtjzsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtywdh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtfymc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtfkfs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtsr = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtlsjg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtckjg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSYYSRCX1 = new FMS.CWGL.YYSRCX.DSYYSRCX();
            this.VfmsyysrcxmxTableAdapter1 = new FMS.CWGL.YYSRCX.DSYYSRCXTableAdapters.VfmsyysrcxmxTableAdapter();
            this.PnlTop.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSYYSRCX1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnSave);
            this.PnlTop.Controls.Add(this.BtnClose);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.label3);
            this.PnlTop.Controls.Add(this.label4);
            this.PnlTop.Controls.Add(this.label5);
            this.PnlTop.Controls.Add(this.label6);
            this.PnlTop.Controls.Add(this.BtnJg);
            this.PnlTop.Controls.Add(this.TxtBJgmc);
            this.PnlTop.Controls.Add(this.CmbJglx);
            this.PnlTop.Controls.Add(this.CmbYwqy);
            this.PnlTop.Controls.Add(this.CmbJzlx);
            this.PnlTop.Controls.Add(this.DtpQrStart);
            this.PnlTop.Controls.Add(this.DtpQrStop);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(980, 85);
            this.PnlTop.TabIndex = 0;
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(12, 58);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 7;
            this.BtnSave.Text = "查询";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnClose.CustomStyle = "F";
            this.BtnClose.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Location = new System.Drawing.Point(119, 58);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 8;
            this.BtnClose.Text = "关闭";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "查询机构";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "机构类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(427, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "业务区域";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "记账类型";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(226, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "开始时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(430, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "结束时间";
            // 
            // BtnJg
            // 
            this.BtnJg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnJg.CustomStyle = "F";
            this.BtnJg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnJg.Location = new System.Drawing.Point(203, 3);
            this.BtnJg.Name = "BtnJg";
            this.BtnJg.Size = new System.Drawing.Size(19, 21);
            this.BtnJg.TabIndex = 1;
            this.BtnJg.Text = "》";
            this.BtnJg.Click += new System.EventHandler(this.BtnJg_Click);
            // 
            // TxtBJgmc
            // 
            this.TxtBJgmc.AllowDrag = false;
            this.TxtBJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBJgmc.Location = new System.Drawing.Point(65, 4);
            this.TxtBJgmc.Name = "TxtBJgmc";
            this.TxtBJgmc.ReadOnly = true;
            this.TxtBJgmc.Size = new System.Drawing.Size(135, 21);
            this.TxtBJgmc.TabIndex = 0;
            // 
            // CmbJglx
            // 
            this.CmbJglx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbJglx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbJglx.FormattingEnabled = true;
            this.CmbJglx.Items.AddRange(new object[] {
            "记账机构",
            "列收机构",
            "存款机构"});
            this.CmbJglx.Location = new System.Drawing.Point(281, 7);
            this.CmbJglx.Name = "CmbJglx";
            this.CmbJglx.Size = new System.Drawing.Size(135, 20);
            this.CmbJglx.TabIndex = 2;
            // 
            // CmbYwqy
            // 
            this.CmbYwqy.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbYwqy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYwqy.FormattingEnabled = true;
            this.CmbYwqy.Location = new System.Drawing.Point(485, 7);
            this.CmbYwqy.Name = "CmbYwqy";
            this.CmbYwqy.Size = new System.Drawing.Size(135, 20);
            this.CmbYwqy.TabIndex = 3;
            // 
            // CmbJzlx
            // 
            this.CmbJzlx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbJzlx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbJzlx.FormattingEnabled = true;
            this.CmbJzlx.Items.AddRange(new object[] {
            "全部",
            "发货",
            "到货",
            "账结"});
            this.CmbJzlx.Location = new System.Drawing.Point(65, 32);
            this.CmbJzlx.Name = "CmbJzlx";
            this.CmbJzlx.Size = new System.Drawing.Size(135, 20);
            this.CmbJzlx.TabIndex = 4;
            // 
            // DtpQrStart
            // 
            this.DtpQrStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpQrStart.Checked = false;
            this.DtpQrStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpQrStart.CustomFormat = "yyyy.MM.dd";
            this.DtpQrStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpQrStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpQrStart.Location = new System.Drawing.Point(281, 31);
            this.DtpQrStart.Name = "DtpQrStart";
            this.DtpQrStart.Size = new System.Drawing.Size(135, 21);
            this.DtpQrStart.TabIndex = 5;
            // 
            // DtpQrStop
            // 
            this.DtpQrStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpQrStop.Checked = false;
            this.DtpQrStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpQrStop.CustomFormat = "yyyy.MM.dd";
            this.DtpQrStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpQrStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpQrStop.Location = new System.Drawing.Point(485, 31);
            this.DtpQrStop.Name = "DtpQrStop";
            this.DtpQrStop.Size = new System.Drawing.Size(135, 21);
            this.DtpQrStop.TabIndex = 6;
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 85);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(980, 430);
            this.PnlMain.TabIndex = 1;
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
            this.DgvColTxtjzjg,
            this.DgvColTxtjzlx,
            this.DgvColTxtywqy,
            this.DgvColTxtjzsj,
            this.DgvColTxtywdh,
            this.DgvColTxtfymc,
            this.DgvColTxtfkfs,
            this.DgvColTxtsr,
            this.DgvColTxtlsjg,
            this.DgvColTxtckjg});
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(980, 430);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColTxtjzjg
            // 
            this.DgvColTxtjzjg.DataPropertyName = "jzlg";
            this.DgvColTxtjzjg.FillWeight = 120F;
            this.DgvColTxtjzjg.HeaderText = "记账机构";
            this.DgvColTxtjzjg.Name = "DgvColTxtjzjg";
            this.DgvColTxtjzjg.ReadOnly = true;
            this.DgvColTxtjzjg.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjzjg.Width = 120;
            // 
            // DgvColTxtjzlx
            // 
            this.DgvColTxtjzlx.DataPropertyName = "jzlx";
            this.DgvColTxtjzlx.FillWeight = 70F;
            this.DgvColTxtjzlx.HeaderText = "记账类型";
            this.DgvColTxtjzlx.Name = "DgvColTxtjzlx";
            this.DgvColTxtjzlx.ReadOnly = true;
            this.DgvColTxtjzlx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjzlx.Width = 70;
            // 
            // DgvColTxtywqy
            // 
            this.DgvColTxtywqy.DataPropertyName = "ywqy";
            this.DgvColTxtywqy.FillWeight = 70F;
            this.DgvColTxtywqy.HeaderText = "业务区域";
            this.DgvColTxtywqy.Name = "DgvColTxtywqy";
            this.DgvColTxtywqy.ReadOnly = true;
            this.DgvColTxtywqy.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtywqy.Width = 70;
            // 
            // DgvColTxtjzsj
            // 
            this.DgvColTxtjzsj.DataPropertyName = "jzsj";
            this.DgvColTxtjzsj.FillWeight = 80F;
            this.DgvColTxtjzsj.HeaderText = "记账时间";
            this.DgvColTxtjzsj.Name = "DgvColTxtjzsj";
            this.DgvColTxtjzsj.ReadOnly = true;
            this.DgvColTxtjzsj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjzsj.Width = 80;
            // 
            // DgvColTxtywdh
            // 
            this.DgvColTxtywdh.DataPropertyName = "bh";
            this.DgvColTxtywdh.FillWeight = 80F;
            this.DgvColTxtywdh.HeaderText = "业务单号";
            this.DgvColTxtywdh.Name = "DgvColTxtywdh";
            this.DgvColTxtywdh.ReadOnly = true;
            this.DgvColTxtywdh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtywdh.Width = 80;
            // 
            // DgvColTxtfymc
            // 
            this.DgvColTxtfymc.DataPropertyName = "fymc";
            this.DgvColTxtfymc.FillWeight = 70F;
            this.DgvColTxtfymc.HeaderText = "费用名称";
            this.DgvColTxtfymc.Name = "DgvColTxtfymc";
            this.DgvColTxtfymc.ReadOnly = true;
            this.DgvColTxtfymc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtfymc.Width = 70;
            // 
            // DgvColTxtfkfs
            // 
            this.DgvColTxtfkfs.DataPropertyName = "fkfs";
            this.DgvColTxtfkfs.FillWeight = 80F;
            this.DgvColTxtfkfs.HeaderText = "付款方式";
            this.DgvColTxtfkfs.Name = "DgvColTxtfkfs";
            this.DgvColTxtfkfs.ReadOnly = true;
            this.DgvColTxtfkfs.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtfkfs.Width = 80;
            // 
            // DgvColTxtsr
            // 
            this.DgvColTxtsr.DataPropertyName = "sr";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtsr.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtsr.FillWeight = 60F;
            this.DgvColTxtsr.HeaderText = "收入";
            this.DgvColTxtsr.Name = "DgvColTxtsr";
            this.DgvColTxtsr.ReadOnly = true;
            this.DgvColTxtsr.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtsr.Width = 60;
            // 
            // DgvColTxtlsjg
            // 
            this.DgvColTxtlsjg.DataPropertyName = "lsjg";
            this.DgvColTxtlsjg.FillWeight = 120F;
            this.DgvColTxtlsjg.HeaderText = "列收机构";
            this.DgvColTxtlsjg.Name = "DgvColTxtlsjg";
            this.DgvColTxtlsjg.ReadOnly = true;
            this.DgvColTxtlsjg.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtlsjg.Width = 120;
            // 
            // DgvColTxtckjg
            // 
            this.DgvColTxtckjg.DataPropertyName = "ckjg";
            this.DgvColTxtckjg.FillWeight = 120F;
            this.DgvColTxtckjg.HeaderText = "存款机构";
            this.DgvColTxtckjg.Name = "DgvColTxtckjg";
            this.DgvColTxtckjg.ReadOnly = true;
            this.DgvColTxtckjg.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtckjg.Width = 120;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsyysrcxmx";
            this.Bds.DataSource = this.DSYYSRCX1;
            // 
            // DSYYSRCX1
            // 
            this.DSYYSRCX1.DataSetName = "DSYYSRCX";
            this.DSYYSRCX1.EnforceConstraints = false;
            this.DSYYSRCX1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmsyysrcxmxTableAdapter1
            // 
            this.VfmsyysrcxmxTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmYCZW
            // 
            this.AcceptButton = this.BtnSave;
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(980, 515);
            this.Text = "营业收入详细";
            this.PnlTop.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSYYSRCX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private Panel PnlMain;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button BtnJg;
        private TextBox TxtBJgmc;
        private ComboBox CmbJglx;
        private ComboBox CmbYwqy;
        private ComboBox CmbJzlx;
        private DateTimePicker DtpQrStart;
        private DateTimePicker DtpQrStop;
        private Button BtnSave;
        private Button BtnClose;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtjzjg;
        private DataGridViewTextBoxColumn DgvColTxtjzlx;
        private DataGridViewTextBoxColumn DgvColTxtywqy;
        private DataGridViewTextBoxColumn DgvColTxtjzsj;
        private DataGridViewTextBoxColumn DgvColTxtywdh;
        private DataGridViewTextBoxColumn DgvColTxtfymc;
        private DataGridViewTextBoxColumn DgvColTxtfkfs;
        private DataGridViewTextBoxColumn DgvColTxtsr;
        private DataGridViewTextBoxColumn DgvColTxtlsjg;
        private DataGridViewTextBoxColumn DgvColTxtckjg;
        private BindingSource Bds;
        private DSYYSRCX DSYYSRCX1;
        private DSYYSRCXTableAdapters.VfmsyysrcxmxTableAdapter VfmsyysrcxmxTableAdapter1;


    }
}
