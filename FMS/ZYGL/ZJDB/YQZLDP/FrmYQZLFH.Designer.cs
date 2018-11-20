using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.ZJDB.YQZLDB
{
    partial class FrmYQZLFH
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
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.Cmbzt = new Gizmox.WebGUI.Forms.ComboBox();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnSelDpjg = new Gizmox.WebGUI.Forms.Button();
            this.BtnElse = new Gizmox.WebGUI.Forms.Button();
            this.BtnQr = new Gizmox.WebGUI.Forms.Button();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.LblSJ = new Gizmox.WebGUI.Forms.Label();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.BtnFh = new Gizmox.WebGUI.Forms.Button();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtzczh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzczhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzczhyh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzrzh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzrzhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzrzhyh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtsjzze = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzzzt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtXx = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtId = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSYQZL1 = new FMS.ZYGL.ZJDB.YQZLDP.DSYQZL();
            this.VfmsyqzlfhTableAdapter1 = new FMS.ZYGL.ZJDB.YQZLDP.DSYQZLTableAdapters.VfmsyqzlfhTableAdapter();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSYQZL1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Controls.Add(this.Cmbzt);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnSelDpjg);
            this.PnlTop.Controls.Add(this.BtnElse);
            this.PnlTop.Controls.Add(this.BtnQr);
            this.PnlTop.Controls.Add(this.DtpStop);
            this.PnlTop.Controls.Add(this.label5);
            this.PnlTop.Controls.Add(this.LblSJ);
            this.PnlTop.Controls.Add(this.DtpStart);
            this.PnlTop.Controls.Add(this.BtnFh);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(800, 82);
            this.PnlTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(410, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "转账状态";
            // 
            // Cmbzt
            // 
            this.Cmbzt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.Cmbzt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmbzt.FormattingEnabled = true;
            this.Cmbzt.Items.AddRange(new object[] {
            "全部",
            "未复核",
            "转账中",
            "成功",
            "失败"});
            this.Cmbzt.Location = new System.Drawing.Point(476, 12);
            this.Cmbzt.Name = "Cmbzt";
            this.Cmbzt.Size = new System.Drawing.Size(69, 20);
            this.Cmbzt.TabIndex = 16;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(413, 42);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 15;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnSelDpjg
            // 
            this.BtnSelDpjg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSelDpjg.CustomStyle = "F";
            this.BtnSelDpjg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSelDpjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSelDpjg.Location = new System.Drawing.Point(205, 44);
            this.BtnSelDpjg.Name = "BtnSelDpjg";
            this.BtnSelDpjg.Size = new System.Drawing.Size(97, 23);
            this.BtnSelDpjg.TabIndex = 14;
            this.BtnSelDpjg.Text = "调拨结果查询";
            this.BtnSelDpjg.Click += new System.EventHandler(this.BtnSelDpjg_Click);
            // 
            // BtnElse
            // 
            this.BtnElse.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnElse.CustomStyle = "F";
            this.BtnElse.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnElse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnElse.Location = new System.Drawing.Point(320, 45);
            this.BtnElse.Name = "BtnElse";
            this.BtnElse.Size = new System.Drawing.Size(75, 22);
            this.BtnElse.TabIndex = 9;
            this.BtnElse.Text = "导出";
            this.BtnElse.Click += new System.EventHandler(this.BtnElse_Click);
            // 
            // BtnQr
            // 
            this.BtnQr.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnQr.CustomStyle = "F";
            this.BtnQr.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQr.Location = new System.Drawing.Point(19, 45);
            this.BtnQr.Name = "BtnQr";
            this.BtnQr.Size = new System.Drawing.Size(75, 22);
            this.BtnQr.TabIndex = 8;
            this.BtnQr.Text = "查询";
            this.BtnQr.Click += new System.EventHandler(this.BtnQr_Click);
            // 
            // DtpStop
            // 
            this.DtpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStop.Checked = false;
            this.DtpStop.CustomFormat = "yyyy.MM.dd";
            this.DtpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStop.Location = new System.Drawing.Point(258, 12);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.Size = new System.Drawing.Size(133, 21);
            this.DtpStop.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(237, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "到";
            // 
            // LblSJ
            // 
            this.LblSJ.AutoSize = true;
            this.LblSJ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSJ.Location = new System.Drawing.Point(17, 16);
            this.LblSJ.Name = "LblSJ";
            this.LblSJ.Size = new System.Drawing.Size(53, 12);
            this.LblSJ.TabIndex = 0;
            this.LblSJ.Text = "操作时间";
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Checked = false;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(100, 12);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(133, 21);
            this.DtpStart.TabIndex = 6;
            // 
            // BtnFh
            // 
            this.BtnFh.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnFh.CustomStyle = "F";
            this.BtnFh.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnFh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFh.Location = new System.Drawing.Point(112, 45);
            this.BtnFh.Name = "BtnFh";
            this.BtnFh.Size = new System.Drawing.Size(75, 22);
            this.BtnFh.TabIndex = 13;
            this.BtnFh.Text = "复核";
            this.BtnFh.Click += new System.EventHandler(this.BtnFh_Click);
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
            this.DgvColTxtzczh,
            this.DgvColTxtzczhmc,
            this.DgvColTxtzczhyh,
            this.DgvColTxtzrzh,
            this.DgvColTxtzrzhmc,
            this.DgvColTxtzrzhyh,
            this.DgvColTxtsjzze,
            this.DgvColTxtzzzt,
            this.DgvColTxtXx,
            this.DgvColTxtId,
            this.DgvColTxtlx});
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
            this.Dgv.Location = new System.Drawing.Point(0, 82);
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
            this.Dgv.Size = new System.Drawing.Size(800, 332);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellContentClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellContentClick);
            // 
            // DgvColTxtzczh
            // 
            this.DgvColTxtzczh.DataPropertyName = "zczh";
            this.DgvColTxtzczh.HeaderText = "转出帐号";
            this.DgvColTxtzczh.Name = "DgvColTxtzczh";
            this.DgvColTxtzczh.ReadOnly = true;
            this.DgvColTxtzczh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtzczh.Width = 150;
            // 
            // DgvColTxtzczhmc
            // 
            this.DgvColTxtzczhmc.DataPropertyName = "zczhmc";
            this.DgvColTxtzczhmc.HeaderText = "转出帐号名称";
            this.DgvColTxtzczhmc.Name = "DgvColTxtzczhmc";
            this.DgvColTxtzczhmc.ReadOnly = true;
            this.DgvColTxtzczhmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtzczhmc.Width = 150;
            // 
            // DgvColTxtzczhyh
            // 
            this.DgvColTxtzczhyh.DataPropertyName = "zczhyh";
            this.DgvColTxtzczhyh.HeaderText = "转出帐号银行";
            this.DgvColTxtzczhyh.Name = "DgvColTxtzczhyh";
            this.DgvColTxtzczhyh.ReadOnly = true;
            this.DgvColTxtzczhyh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtzczhyh.Width = 120;
            // 
            // DgvColTxtzrzh
            // 
            this.DgvColTxtzrzh.DataPropertyName = "zrzh";
            this.DgvColTxtzrzh.HeaderText = "转入帐号";
            this.DgvColTxtzrzh.Name = "DgvColTxtzrzh";
            this.DgvColTxtzrzh.ReadOnly = true;
            this.DgvColTxtzrzh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtzrzh.Width = 150;
            // 
            // DgvColTxtzrzhmc
            // 
            this.DgvColTxtzrzhmc.DataPropertyName = "zrzhmc";
            this.DgvColTxtzrzhmc.HeaderText = "转入帐号名称";
            this.DgvColTxtzrzhmc.Name = "DgvColTxtzrzhmc";
            this.DgvColTxtzrzhmc.ReadOnly = true;
            this.DgvColTxtzrzhmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtzrzhmc.Width = 150;
            // 
            // DgvColTxtzrzhyh
            // 
            this.DgvColTxtzrzhyh.DataPropertyName = "zrzhyh";
            this.DgvColTxtzrzhyh.HeaderText = "转入帐号银行";
            this.DgvColTxtzrzhyh.Name = "DgvColTxtzrzhyh";
            this.DgvColTxtzrzhyh.ReadOnly = true;
            this.DgvColTxtzrzhyh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtzrzhyh.Width = 120;
            // 
            // DgvColTxtsjzze
            // 
            this.DgvColTxtsjzze.DataPropertyName = "sjzze";
            this.DgvColTxtsjzze.HeaderText = "实际转账额";
            this.DgvColTxtsjzze.Name = "DgvColTxtsjzze";
            this.DgvColTxtsjzze.ReadOnly = true;
            this.DgvColTxtsjzze.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtzzzt
            // 
            this.DgvColTxtzzzt.DataPropertyName = "zzzt";
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtzzzt.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColTxtzzzt.HeaderText = "转账状态";
            this.DgvColTxtzzzt.Name = "DgvColTxtzzzt";
            this.DgvColTxtzzzt.ReadOnly = true;
            // 
            // DgvColTxtXx
            // 
            this.DgvColTxtXx.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtXx.ClientMode = false;
            this.DgvColTxtXx.DataPropertyName = "xx";
            this.DgvColTxtXx.HeaderText = "详细";
            this.DgvColTxtXx.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvColTxtXx.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtXx.Name = "DgvColTxtXx";
            this.DgvColTxtXx.ReadOnly = true;
            this.DgvColTxtXx.TrackVisitedState = false;
            this.DgvColTxtXx.Url = "";
            this.DgvColTxtXx.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvColTxtId
            // 
            this.DgvColTxtId.DataPropertyName = "id";
            this.DgvColTxtId.HeaderText = "id";
            this.DgvColTxtId.Name = "DgvColTxtId";
            this.DgvColTxtId.ReadOnly = true;
            this.DgvColTxtId.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtId.Visible = false;
            // 
            // DgvColTxtlx
            // 
            this.DgvColTxtlx.DataPropertyName = "lx";
            this.DgvColTxtlx.HeaderText = "lx";
            this.DgvColTxtlx.Name = "DgvColTxtlx";
            this.DgvColTxtlx.ReadOnly = true;
            this.DgvColTxtlx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtlx.Visible = false;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsyqzlfh";
            this.Bds.DataSource = this.DSYQZL1;
            // 
            // DSYQZL1
            // 
            this.DSYQZL1.DataSetName = "DSYQZL";
            this.DSYQZL1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmsyqzlfhTableAdapter1
            // 
            this.VfmsyqzlfhTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmYQZLFH
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(800, 414);
            this.Text = "银企直连复核";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSYQZL1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private Button BtnElse;
        private Button BtnQr;
        private DateTimePicker DtpStop;
        private Label label5;
        private Label LblSJ;
        private DateTimePicker DtpStart;
        private Button BtnFh;
        private DataGridView Dgv;
        //private DataGridViewTextBoxColumn DgvColTxtzczh;
        //private DataGridViewTextBoxColumn DgvColTxtJzczhmc;
        //private DataGridViewTextBoxColumn DgvColTxtzczhzy;
        //private DataGridViewTextBoxColumn DgvColTxtzrzh;
        //private DataGridViewTextBoxColumn DgvColTxtzrzhmc;
        //private DataGridViewTextBoxColumn DgvColTxtzrzhyh;
        //private DataGridViewTextBoxColumn DgvColTxtsjzze;
        //private DataGridViewLinkColumn DgvColTxtxx;
        //private DataGridViewTextBoxColumn DgvColTxtid;
        //private DataGridViewTextBoxColumn DgvColTxtlx;
        private BindingSource Bds;
        private YQZLDP.DSYQZL DSYQZL1;
        private YQZLDP.DSYQZLTableAdapters.VfmsyqzlfhTableAdapter VfmsyqzlfhTableAdapter1;
        private DataGridViewTextBoxColumn DgvColTxtzczh;
        private DataGridViewTextBoxColumn DgvColTxtzczhmc;
        private DataGridViewTextBoxColumn DgvColTxtzczhyh;
        private DataGridViewTextBoxColumn DgvColTxtzrzh;
        private DataGridViewTextBoxColumn DgvColTxtzrzhmc;
        private DataGridViewTextBoxColumn DgvColTxtzrzhyh;
        private DataGridViewTextBoxColumn DgvColTxtsjzze;
        private DataGridViewLinkColumn DgvColTxtXx;
        private DataGridViewTextBoxColumn DgvColTxtId;
        private DataGridViewTextBoxColumn DgvColTxtlx;
        private Button BtnSelDpjg;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Label label1;
        private ComboBox Cmbzt;
        private DataGridViewTextBoxColumn DgvColTxtzzzt;


    }
}