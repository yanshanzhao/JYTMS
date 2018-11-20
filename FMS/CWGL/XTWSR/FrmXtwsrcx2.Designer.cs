using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.XTWSR
{
    partial class FrmXtwsrcx2
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
            this.CmbLx = new Gizmox.WebGUI.Forms.ComboBox();
            this.BtnExecel = new Gizmox.WebGUI.Forms.Button();
            this.BtnSel = new Gizmox.WebGUI.Forms.Button();
            this.LblLx = new Gizmox.WebGUI.Forms.Label();
            this.Lbl = new Gizmox.WebGUI.Forms.Label();
            this.LblSj = new Gizmox.WebGUI.Forms.Label();
            this.DtpQrStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpQrStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.label24 = new Gizmox.WebGUI.Forms.Label();
            this.Txtsqjg = new Gizmox.WebGUI.Forms.TextBox();
            this.Btnsldq = new Gizmox.WebGUI.Forms.Button();
            this.BtnSqdq = new Gizmox.WebGUI.Forms.Button();
            this.TxtSqdq = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.CmbShbz = new Gizmox.WebGUI.Forms.ComboBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.CmbJkzt = new Gizmox.WebGUI.Forms.ComboBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.DSXTWSR1 = new FMS.CWGL.XTWSR.DSXTWSR();
            this.VfmsxtwsrcxTableAdapter1 = new FMS.CWGL.XTWSR.DSXTWSRTableAdapters.VfmsxtwsrcxTableAdapter();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DSXTWSR1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbLx
            // 
            this.CmbLx.AllowDrag = false;
            this.CmbLx.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            this.CmbLx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbLx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLx.FormattingEnabled = true;
            this.CmbLx.Location = new System.Drawing.Point(63, 38);
            this.CmbLx.Name = "CmbLx";
            this.CmbLx.Size = new System.Drawing.Size(121, 20);
            this.CmbLx.TabIndex = 17;
            // 
            // BtnExecel
            // 
            this.BtnExecel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExecel.CustomStyle = "F";
            this.BtnExecel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExecel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExecel.Location = new System.Drawing.Point(107, 70);
            this.BtnExecel.Name = "BtnExecel";
            this.BtnExecel.Size = new System.Drawing.Size(75, 23);
            this.BtnExecel.TabIndex = 16;
            this.BtnExecel.Text = "导出";
            this.BtnExecel.Click += new System.EventHandler(this.BtnExecel_Click);
            // 
            // BtnSel
            // 
            this.BtnSel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSel.CustomStyle = "F";
            this.BtnSel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSel.Location = new System.Drawing.Point(14, 70);
            this.BtnSel.Name = "BtnSel";
            this.BtnSel.Size = new System.Drawing.Size(75, 23);
            this.BtnSel.TabIndex = 16;
            this.BtnSel.Text = "查询";
            this.BtnSel.Click += new System.EventHandler(this.BtnSel_Click);
            // 
            // LblLx
            // 
            this.LblLx.AutoSize = true;
            this.LblLx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLx.Location = new System.Drawing.Point(12, 43);
            this.LblLx.Name = "LblLx";
            this.LblLx.Size = new System.Drawing.Size(35, 13);
            this.LblLx.TabIndex = 13;
            this.LblLx.Text = "类型名称";
            // 
            // Lbl
            // 
            this.Lbl.AutoSize = true;
            this.Lbl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl.Location = new System.Drawing.Point(163, 17);
            this.Lbl.Name = "Lbl";
            this.Lbl.Size = new System.Drawing.Size(20, 13);
            this.Lbl.TabIndex = 12;
            this.Lbl.Text = "-";
            // 
            // LblSj
            // 
            this.LblSj.AutoSize = true;
            this.LblSj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSj.Location = new System.Drawing.Point(12, 14);
            this.LblSj.Name = "LblSj";
            this.LblSj.Size = new System.Drawing.Size(35, 13);
            this.LblSj.TabIndex = 11;
            this.LblSj.Text = "记账时间";
            // 
            // DtpQrStop
            // 
            this.DtpQrStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpQrStop.Checked = false;
            this.DtpQrStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpQrStop.CustomFormat = "yyyy.MM.dd";
            this.DtpQrStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpQrStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpQrStop.Location = new System.Drawing.Point(174, 11);
            this.DtpQrStop.Name = "DtpQrStop";
            this.DtpQrStop.Size = new System.Drawing.Size(104, 21);
            this.DtpQrStop.TabIndex = 10;
            // 
            // DtpQrStart
            // 
            this.DtpQrStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpQrStart.Checked = false;
            this.DtpQrStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpQrStart.CustomFormat = "yyyy.MM.dd";
            this.DtpQrStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpQrStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpQrStart.Location = new System.Drawing.Point(65, 11);
            this.DtpQrStart.Name = "DtpQrStart";
            this.DtpQrStart.Size = new System.Drawing.Size(98, 21);
            this.DtpQrStart.TabIndex = 8;
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.label24);
            this.PnlTop.Controls.Add(this.Txtsqjg);
            this.PnlTop.Controls.Add(this.Btnsldq);
            this.PnlTop.Controls.Add(this.BtnSqdq);
            this.PnlTop.Controls.Add(this.TxtSqdq);
            this.PnlTop.Controls.Add(this.label3);
            this.PnlTop.Controls.Add(this.CmbShbz);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.CmbJkzt);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Controls.Add(this.CmbLx);
            this.PnlTop.Controls.Add(this.BtnExecel);
            this.PnlTop.Controls.Add(this.BtnSel);
            this.PnlTop.Controls.Add(this.LblLx);
            this.PnlTop.Controls.Add(this.Lbl);
            this.PnlTop.Controls.Add(this.LblSj);
            this.PnlTop.Controls.Add(this.DtpQrStop);
            this.PnlTop.Controls.Add(this.DtpQrStart);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(932, 99);
            this.PnlTop.TabIndex = 0;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(313, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 12);
            this.label24.TabIndex = 2;
            this.label24.Text = "记账机构";
            // 
            // Txtsqjg
            // 
            this.Txtsqjg.AllowDrag = false;
            this.Txtsqjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txtsqjg.Location = new System.Drawing.Point(369, 6);
            this.Txtsqjg.Name = "Txtsqjg";
            this.Txtsqjg.Size = new System.Drawing.Size(131, 21);
            this.Txtsqjg.TabIndex = 3;
            // 
            // Btnsldq
            // 
            this.Btnsldq.CustomStyle = "F";
            this.Btnsldq.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.Btnsldq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btnsldq.Location = new System.Drawing.Point(501, 5);
            this.Btnsldq.Name = "Btnsldq";
            this.Btnsldq.Size = new System.Drawing.Size(26, 21);
            this.Btnsldq.TabIndex = 4;
            this.Btnsldq.Text = "》";
            this.Btnsldq.Click += new System.EventHandler(this.Btnsldq_Click);
            // 
            // BtnSqdq
            // 
            this.BtnSqdq.CustomStyle = "F";
            this.BtnSqdq.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSqdq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSqdq.Location = new System.Drawing.Point(727, 4);
            this.BtnSqdq.Name = "BtnSqdq";
            this.BtnSqdq.Size = new System.Drawing.Size(26, 21);
            this.BtnSqdq.TabIndex = 4;
            this.BtnSqdq.Text = "》";
            this.BtnSqdq.Click += new System.EventHandler(this.BtnSqdq_Click);
            // 
            // TxtSqdq
            // 
            this.TxtSqdq.AllowDrag = false;
            this.TxtSqdq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtSqdq.Location = new System.Drawing.Point(595, 5);
            this.TxtSqdq.Name = "TxtSqdq";
            this.TxtSqdq.Size = new System.Drawing.Size(131, 21);
            this.TxtSqdq.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(539, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "记账大区";
            // 
            // CmbShbz
            // 
            this.CmbShbz.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbShbz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbShbz.FormattingEnabled = true;
            this.CmbShbz.Items.AddRange(new object[] {
            "--全部--",
            "未审核",
            "审核通过",
            "审核不通过"});
            this.CmbShbz.Location = new System.Drawing.Point(441, 36);
            this.CmbShbz.Name = "CmbShbz";
            this.CmbShbz.Size = new System.Drawing.Size(121, 20);
            this.CmbShbz.TabIndex = 19;
            this.CmbShbz.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(388, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "审核标志";
            this.label2.Visible = false;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(195, 68);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 20;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // CmbJkzt
            // 
            this.CmbJkzt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbJkzt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbJkzt.FormattingEnabled = true;
            this.CmbJkzt.Items.AddRange(new object[] {
            "--全部--",
            "未存",
            "已交"});
            this.CmbJkzt.Location = new System.Drawing.Point(257, 37);
            this.CmbJkzt.Name = "CmbJkzt";
            this.CmbJkzt.Size = new System.Drawing.Size(121, 20);
            this.CmbJkzt.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(198, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "交款状态";
            // 
            // DSXTWSR1
            // 
            this.DSXTWSR1.DataSetName = "DSXTWSR";
            this.DSXTWSR1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmsxtwsrcxTableAdapter1
            // 
            this.VfmsxtwsrcxTableAdapter1.ClearBeforeFill = true;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsxtwsrcx";
            this.Bds.DataSource = this.DSXTWSR1;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowDragTargetsPropagation = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn9});
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
            this.Dgv.Location = new System.Drawing.Point(0, 99);
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
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.Size = new System.Drawing.Size(932, 353);
            this.Dgv.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "dqmc";
            this.dataGridViewTextBoxColumn8.HeaderText = "记账大区";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "jgmc";
            this.dataGridViewTextBoxColumn6.HeaderText = "记账机构";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "bh";
            this.dataGridViewTextBoxColumn1.HeaderText = "系统外单号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "inssj";
            this.dataGridViewTextBoxColumn2.HeaderText = "记账时间";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "lxmc";
            this.dataGridViewTextBoxColumn3.HeaderText = "类型名称";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "je";
            this.dataGridViewTextBoxColumn5.HeaderText = "金额";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "zts";
            this.dataGridViewTextBoxColumn7.HeaderText = "状态";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "spzts";
            this.dataGridViewTextBoxColumn4.HeaderText = "审核标志";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "jksj";
            this.dataGridViewTextBoxColumn9.HeaderText = "缴款时间";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // FrmXtwsrcx2
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Size = new System.Drawing.Size(932, 452);
            this.Text = "FrmXtwsrcx2";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DSXTWSR1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox CmbLx;
        private Button BtnExecel;
        private Button BtnSel;
        private Label LblLx;
        private Label Lbl;
        private Label LblSj;
        private DateTimePicker DtpQrStop;
        private DateTimePicker DtpQrStart;
        private Panel PnlTop;
        private ComboBox CmbJkzt;
        private Label label1;
        private DSXTWSR DSXTWSR1;
        private DSXTWSRTableAdapters.VfmsxtwsrcxTableAdapter VfmsxtwsrcxTableAdapter1;
        private BindingSource Bds;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Label label2;
        private ComboBox CmbShbz;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private Label label24;
        private TextBox Txtsqjg;
        private Button Btnsldq;
        private Button BtnSqdq;
        private TextBox TxtSqdq;
        private Label label3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;


    }
}