using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.YBFNHDR
{
    partial class FrmYBNYHDR
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.BtnToData = new Gizmox.WebGUI.Forms.Button();
            this.BtnDelete = new Gizmox.WebGUI.Forms.Button();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSYBFDR1 = new FMS.CWGL.YBFNHDR.DSYBFDR();
            this.BtnElxrb = new Gizmox.WebGUI.Forms.Button();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.BtnQuiry = new Gizmox.WebGUI.Forms.Button();
            this.BtnElse = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.LblSJ = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.CmbZtlx = new Gizmox.WebGUI.Forms.ComboBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.ctrlUploadFile1 = new JY.CtrlPub.CtrlUploadFile();
            this.PnlFill = new Gizmox.WebGUI.Forms.Panel();
            this.DGVDRxx = new Gizmox.WebGUI.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColVlcCz = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColVlcXx = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtMc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtDx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlLeft = new Gizmox.WebGUI.Forms.Panel();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.TfmsybfnhdrmxTableAdapter1 = new FMS.CWGL.YBFNHDR.DSYBFDRTableAdapters.TfmsybfnhdrmxTableAdapter();
            this.VfmsybfdrpcTableAdapter1 = new FMS.CWGL.YBFNHDR.DSYBFDRTableAdapters.VfmsybfdrpcTableAdapter();
            this.PnlBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSYBFDR1)).BeginInit();
            this.PnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDRxx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.PnlLeft.SuspendLayout();
            this.PnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnToData
            // 
            this.BtnToData.CustomStyle = "F";
            this.BtnToData.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnToData.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnToData.Location = new System.Drawing.Point(106, 48);
            this.BtnToData.Name = "BtnToData";
            this.BtnToData.Size = new System.Drawing.Size(89, 22);
            this.BtnToData.TabIndex = 1;
            this.BtnToData.Text = "导入数据库";
            this.BtnToData.Click += new System.EventHandler(this.BtnToData_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.CustomStyle = "F";
            this.BtnDelete.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.Location = new System.Drawing.Point(213, 48);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(89, 22);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "上传文件删除";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.BtnElxrb);
            this.PnlBtns.Controls.Add(this.label3);
            this.PnlBtns.Controls.Add(this.label2);
            this.PnlBtns.Controls.Add(this.BtnQuiry);
            this.PnlBtns.Controls.Add(this.BtnElse);
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.DtpStart);
            this.PnlBtns.Controls.Add(this.LblSJ);
            this.PnlBtns.Controls.Add(this.label5);
            this.PnlBtns.Controls.Add(this.DtpStop);
            this.PnlBtns.Controls.Add(this.CmbZtlx);
            this.PnlBtns.Controls.Add(this.label1);
            this.PnlBtns.Controls.Add(this.ctrlUploadFile1);
            this.PnlBtns.Controls.Add(this.BtnToData);
            this.PnlBtns.Controls.Add(this.BtnDelete);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(1040, 76);
            this.PnlBtns.TabIndex = 1;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsybfdrpc";
            this.Bds.DataSource = this.DSYBFDR1;
            // 
            // DSYBFDR1
            // 
            this.DSYBFDR1.DataSetName = "DSYBFDR";
            this.DSYBFDR1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BtnElxrb
            // 
            this.BtnElxrb.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnElxrb.CustomStyle = "F";
            this.BtnElxrb.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnElxrb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnElxrb.Location = new System.Drawing.Point(530, 46);
            this.BtnElxrb.Name = "BtnElxrb";
            this.BtnElxrb.Size = new System.Drawing.Size(116, 23);
            this.BtnElxrb.TabIndex = 15;
            this.BtnElxrb.Text = "导出收款日报表";
            this.BtnElxrb.Click += new System.EventHandler(this.BtnElxrb_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(660, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "若为更高版本请另存为2003版本，请将数据存放在sheet1工作表中";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(660, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "此模块仅支持excel2003版本";
            // 
            // BtnQuiry
            // 
            this.BtnQuiry.CustomStyle = "F";
            this.BtnQuiry.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQuiry.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuiry.Location = new System.Drawing.Point(350, 46);
            this.BtnQuiry.Name = "BtnQuiry";
            this.BtnQuiry.Size = new System.Drawing.Size(75, 23);
            this.BtnQuiry.TabIndex = 0;
            this.BtnQuiry.Text = "查询";
            this.BtnQuiry.Click += new System.EventHandler(this.BtnQuiry_Click);
            // 
            // BtnElse
            // 
            this.BtnElse.CustomStyle = "F";
            this.BtnElse.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnElse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnElse.Location = new System.Drawing.Point(440, 46);
            this.BtnElse.Name = "BtnElse";
            this.BtnElse.Size = new System.Drawing.Size(75, 23);
            this.BtnElse.TabIndex = 9;
            this.BtnElse.Text = "导出";
            this.BtnElse.Click += new System.EventHandler(this.BtnElse_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(714, 44);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 12;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Checked = false;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(64, 14);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(133, 21);
            this.DtpStart.TabIndex = 6;
            // 
            // LblSJ
            // 
            this.LblSJ.AutoSize = true;
            this.LblSJ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSJ.Location = new System.Drawing.Point(7, 18);
            this.LblSJ.Name = "LblSJ";
            this.LblSJ.Size = new System.Drawing.Size(53, 12);
            this.LblSJ.TabIndex = 0;
            this.LblSJ.Text = "导入时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(201, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "到";
            // 
            // DtpStop
            // 
            this.DtpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStop.Checked = false;
            this.DtpStop.CustomFormat = "yyyy.MM.dd";
            this.DtpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStop.Location = new System.Drawing.Point(222, 14);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.Size = new System.Drawing.Size(133, 21);
            this.DtpStop.TabIndex = 7;
            // 
            // CmbZtlx
            // 
            this.CmbZtlx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbZtlx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbZtlx.FormattingEnabled = true;
            this.CmbZtlx.Items.AddRange(new object[] {
            "未匹配",
            "已匹配"});
            this.CmbZtlx.Location = new System.Drawing.Point(440, 13);
            this.CmbZtlx.Name = "CmbZtlx";
            this.CmbZtlx.Size = new System.Drawing.Size(121, 20);
            this.CmbZtlx.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "匹配状态";
            // 
            // ctrlUploadFile1
            // 
            this.ctrlUploadFile1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlUploadFile1.Location = new System.Drawing.Point(19, 48);
            this.ctrlUploadFile1.Name = "ctrlUploadFile1";
            this.ctrlUploadFile1.Size = new System.Drawing.Size(69, 22);
            this.ctrlUploadFile1.TabIndex = 3;
            this.ctrlUploadFile1.Text = "CtrlUploadFile";
            // 
            // PnlFill
            // 
            this.PnlFill.Controls.Add(this.DGVDRxx);
            this.PnlFill.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlFill.Location = new System.Drawing.Point(326, 0);
            this.PnlFill.Name = "PnlFill";
            this.PnlFill.Size = new System.Drawing.Size(714, 417);
            this.PnlFill.TabIndex = 1;
            // 
            // DGVDRxx
            // 
            this.DGVDRxx.AllowDrag = false;
            this.DGVDRxx.AllowDragTargetsPropagation = false;
            this.DGVDRxx.AllowUserToAddRows = false;
            this.DGVDRxx.AllowUserToDeleteRows = false;
            this.DGVDRxx.AllowUserToResizeColumns = false;
            this.DGVDRxx.AllowUserToResizeRows = false;
            this.DGVDRxx.AutoGenerateColumns = false;
            this.DGVDRxx.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.DGVDRxx.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVDRxx.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDRxx.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn11,
            this.DgvColVlcCz,
            this.DgvColVlcXx});
            this.DGVDRxx.DataSource = this.Bds;
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.DGVDRxx.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGVDRxx.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.DGVDRxx.Location = new System.Drawing.Point(0, 0);
            this.DGVDRxx.Name = "DGVDRxx";
            this.DGVDRxx.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.DGVDRxx.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVDRxx.RowHeadersWidth = 10;
            this.DGVDRxx.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DGVDRxx.Size = new System.Drawing.Size(714, 417);
            this.DGVDRxx.TabIndex = 0;
            this.DGVDRxx.CellContentClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.DGVDRxx_CellContentClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "fln";
            this.dataGridViewTextBoxColumn4.HeaderText = "文件名称";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "inssj";
            this.dataGridViewTextBoxColumn6.HeaderText = "导入时间";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "zts";
            this.dataGridViewTextBoxColumn7.HeaderText = "匹配状态";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "lxs";
            this.dataGridViewTextBoxColumn11.HeaderText = "银行类型";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // DgvColVlcCz
            // 
            this.DgvColVlcCz.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColVlcCz.ClientMode = false;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle2.NullValue = "匹配";
            this.DgvColVlcCz.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColVlcCz.HeaderText = "操作";
            this.DgvColVlcCz.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvColVlcCz.LinkColor = System.Drawing.Color.Empty;
            this.DgvColVlcCz.Name = "DgvColVlcCz";
            this.DgvColVlcCz.ReadOnly = true;
            this.DgvColVlcCz.TrackVisitedState = false;
            this.DgvColVlcCz.Url = "";
            this.DgvColVlcCz.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvColVlcXx
            // 
            this.DgvColVlcXx.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColVlcXx.ClientMode = false;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle3.NullValue = "详细信息";
            this.DgvColVlcXx.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColVlcXx.HeaderText = "详细";
            this.DgvColVlcXx.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvColVlcXx.LinkColor = System.Drawing.Color.Empty;
            this.DgvColVlcXx.Name = "DgvColVlcXx";
            this.DgvColVlcXx.ReadOnly = true;
            this.DgvColVlcXx.TrackVisitedState = false;
            this.DgvColVlcXx.Url = "";
            this.DgvColVlcXx.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "fln";
            this.dataGridViewTextBoxColumn2.HeaderText = "文件名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "inssj";
            this.dataGridViewTextBoxColumn3.HeaderText = "导入时间";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 140;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "zts";
            this.dataGridViewTextBoxColumn5.HeaderText = "匹配状态";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowDragTargetsPropagation = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvColTxtMc,
            this.DgvColTxtDx});
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
            this.Dgv.Location = new System.Drawing.Point(0, 0);
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
            this.Dgv.Size = new System.Drawing.Size(326, 417);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColTxtMc
            // 
            this.DgvColTxtMc.HeaderText = "文件名称";
            this.DgvColTxtMc.Name = "DgvColTxtMc";
            this.DgvColTxtMc.ReadOnly = true;
            this.DgvColTxtMc.Width = 200;
            // 
            // DgvColTxtDx
            // 
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtDx.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvColTxtDx.HeaderText = "文件大小(KB)";
            this.DgvColTxtDx.Name = "DgvColTxtDx";
            this.DgvColTxtDx.ReadOnly = true;
            // 
            // PnlLeft
            // 
            this.PnlLeft.Controls.Add(this.Dgv);
            this.PnlLeft.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.PnlLeft.Location = new System.Drawing.Point(0, 0);
            this.PnlLeft.Name = "PnlLeft";
            this.PnlLeft.Size = new System.Drawing.Size(326, 417);
            this.PnlLeft.TabIndex = 0;
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.PnlFill);
            this.PnlMain.Controls.Add(this.PnlLeft);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 76);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1040, 417);
            this.PnlMain.TabIndex = 2;
            // 
            // TfmsybfnhdrmxTableAdapter1
            // 
            this.TfmsybfnhdrmxTableAdapter1.ClearBeforeFill = true;
            // 
            // VfmsybfdrpcTableAdapter1
            // 
            this.VfmsybfdrpcTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmYBNYHDR
            // 
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlBtns);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(1040, 493);
            this.Text = "FrmYHDR";
            this.PnlBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSYBFDR1)).EndInit();
            this.PnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDRxx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.PnlLeft.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnToData;
        //private JY.CtrlPub.CtrlUploadFile ctrlUploadFile1;
        private Button BtnDelete;
        private Panel PnlBtns;
        private Panel PnlFill;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtMc;
        private DataGridViewTextBoxColumn DgvColTxtDx;
        private Panel PnlLeft;
        private Panel PnlMain;
        private JY.CtrlPub.CtrlUploadFile ctrlUploadFile1;
        private DateTimePicker DtpStart;
        private Label LblSJ;
        private Label label5;
        private DateTimePicker DtpStop;
        private ComboBox CmbZtlx;
        private Label label1;
        private Button BtnQuiry;
        private Button BtnElse;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        //private DataGridViewTextBoxColumn DgvColTxtflnmc;
        //private DataGridViewTextBoxColumn DgvColTxtsj;
        //private DataGridViewTextBoxColumn DgvColTxtzt;
        //private DataGridViewTextBoxColumn DgvColTxtid;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Label label2;
        private Label label3;
        private Button BtnElxrb;
        private DataGridView DGVDRxx;
        //private DataGridViewTextBoxColumn DgvColTxtWjmc;
        //private DataGridViewTextBoxColumn DgvColTxtInssj;
        //private DataGridViewTextBoxColumn DgvColTxtZts;
        //private DataGridViewTextBoxColumn DgvColTxtYHlx;
        private DataGridViewLinkColumn DgvColVlcCz;
        private DataGridViewLinkColumn DgvColVlcXx;
        private CWGL.YBFNHDR.DSYBFDR DSYBFDR1;
        private CWGL.YBFNHDR.DSYBFDRTableAdapters.TfmsybfnhdrmxTableAdapter TfmsybfnhdrmxTableAdapter1;
        private BindingSource Bds;
        private CWGL.YBFNHDR.DSYBFDRTableAdapters.VfmsybfdrpcTableAdapter VfmsybfdrpcTableAdapter1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;


    }
}