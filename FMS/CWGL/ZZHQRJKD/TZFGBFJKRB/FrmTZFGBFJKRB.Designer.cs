using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.ZZHQRJKD.TZFGBFJKRB
{
    partial class FrmTZFGBFJKRB
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
            this.LblSum = new Gizmox.WebGUI.Forms.Label();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.LblRowCount = new Gizmox.WebGUI.Forms.Label();
            this.BtnJk = new Gizmox.WebGUI.Forms.Button();
            this.LblJsrq = new Gizmox.WebGUI.Forms.Label();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.LblKsrq = new Gizmox.WebGUI.Forms.Label();
            this.CmbLx = new Gizmox.WebGUI.Forms.ComboBox();
            this.LblYwqy = new Gizmox.WebGUI.Forms.Label();
            this.BtnSearch = new Gizmox.WebGUI.Forms.Button();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.PanlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.Dstfmsxtsr1 = new FMS.CWGL.ZZHQRJKD.TZFGBFJKRB.DSTFMSXTSR();
            this.DgvColTxtDqmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJzjg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJzlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtBh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJzsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJzje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.VfmsxtsrTableAdapter1 = new FMS.CWGL.ZZHQRJKD.TZFGBFJKRB.DSTFMSXTSRTableAdapters.vfmsxtsrTableAdapter();
            this.PnlBtns.SuspendLayout();
            this.PanlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dstfmsxtsr1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblSum
            // 
            this.LblSum.BackColor = System.Drawing.SystemColors.Window;
            this.LblSum.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblSum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSum.ForeColor = System.Drawing.Color.Blue;
            this.LblSum.Location = new System.Drawing.Point(394, 46);
            this.LblSum.Name = "LblSum";
            this.LblSum.Size = new System.Drawing.Size(180, 21);
            this.LblSum.TabIndex = 18;
            this.LblSum.Text = "已存0.00元  未存0.00元";
            this.LblSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(200, 46);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 10;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // LblRowCount
            // 
            this.LblRowCount.BackColor = System.Drawing.SystemColors.Window;
            this.LblRowCount.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblRowCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRowCount.ForeColor = System.Drawing.Color.Blue;
            this.LblRowCount.Location = new System.Drawing.Point(286, 46);
            this.LblRowCount.Name = "LblRowCount";
            this.LblRowCount.Size = new System.Drawing.Size(93, 21);
            this.LblRowCount.TabIndex = 18;
            this.LblRowCount.Text = "共有0条数据";
            this.LblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnJk
            // 
            this.BtnJk.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnJk.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnJk.CustomStyle = "F";
            this.BtnJk.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJk.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnJk.Location = new System.Drawing.Point(107, 46);
            this.BtnJk.Name = "BtnJk";
            this.BtnJk.Size = new System.Drawing.Size(75, 23);
            this.BtnJk.TabIndex = 9;
            this.BtnJk.Text = "缴款";
            this.BtnJk.Click += new System.EventHandler(this.BtnJk_Click);
            // 
            // LblJsrq
            // 
            this.LblJsrq.AutoSize = true;
            this.LblJsrq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJsrq.Location = new System.Drawing.Point(362, 14);
            this.LblJsrq.Name = "LblJsrq";
            this.LblJsrq.Size = new System.Drawing.Size(53, 12);
            this.LblJsrq.TabIndex = 0;
            this.LblJsrq.Text = "结束日期";
            // 
            // DtpStop
            // 
            this.DtpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStop.Checked = false;
            this.DtpStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStop.CustomFormat = "yyyy.MM.dd";
            this.DtpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStop.Location = new System.Drawing.Point(415, 10);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.ShowCheckBox = true;
            this.DtpStop.Size = new System.Drawing.Size(130, 21);
            this.DtpStop.TabIndex = 7;
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(221, 8);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(130, 21);
            this.DtpStart.TabIndex = 6;
            // 
            // LblKsrq
            // 
            this.LblKsrq.AutoSize = true;
            this.LblKsrq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblKsrq.Location = new System.Drawing.Point(167, 12);
            this.LblKsrq.Name = "LblKsrq";
            this.LblKsrq.Size = new System.Drawing.Size(53, 12);
            this.LblKsrq.TabIndex = 0;
            this.LblKsrq.Text = "开始日期";
            // 
            // CmbLx
            // 
            this.CmbLx.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.CmbLx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbLx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLx.FormattingEnabled = true;
            this.CmbLx.Location = new System.Drawing.Point(53, 8);
            this.CmbLx.Name = "CmbLx";
            this.CmbLx.Size = new System.Drawing.Size(98, 20);
            this.CmbLx.TabIndex = 0;
            // 
            // LblYwqy
            // 
            this.LblYwqy.AutoSize = true;
            this.LblYwqy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYwqy.Location = new System.Drawing.Point(12, 12);
            this.LblYwqy.Name = "LblYwqy";
            this.LblYwqy.Size = new System.Drawing.Size(53, 12);
            this.LblYwqy.TabIndex = 0;
            this.LblYwqy.Text = "类型";
            // 
            // BtnSearch
            // 
            this.BtnSearch.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnSearch.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSearch.CustomStyle = "F";
            this.BtnSearch.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(14, 46);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 8;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.LblSum);
            this.PnlBtns.Controls.Add(this.BtnExl);
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.LblRowCount);
            this.PnlBtns.Controls.Add(this.BtnJk);
            this.PnlBtns.Controls.Add(this.LblJsrq);
            this.PnlBtns.Controls.Add(this.DtpStop);
            this.PnlBtns.Controls.Add(this.DtpStart);
            this.PnlBtns.Controls.Add(this.LblKsrq);
            this.PnlBtns.Controls.Add(this.CmbLx);
            this.PnlBtns.Controls.Add(this.LblYwqy);
            this.PnlBtns.Controls.Add(this.BtnSearch);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(712, 82);
            this.PnlBtns.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(717, 63);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 19;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // PanlMain
            // 
            this.PanlMain.Controls.Add(this.Dgv);
            this.PanlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PanlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanlMain.Location = new System.Drawing.Point(0, 82);
            this.PanlMain.Name = "PanlMain";
            this.PanlMain.Size = new System.Drawing.Size(712, 559);
            this.PanlMain.TabIndex = 1;
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
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(712, 559);
            this.Dgv.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "lxbhs";
            this.dataGridViewTextBoxColumn4.HeaderText = "记账类型";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "dqmc";
            this.dataGridViewTextBoxColumn6.HeaderText = "记账大区";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "mc";
            this.dataGridViewTextBoxColumn8.HeaderText = "记账机构";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "bh";
            this.dataGridViewTextBoxColumn5.HeaderText = "编号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "je";
            this.dataGridViewTextBoxColumn9.HeaderText = "记账金额";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "inssj";
            this.dataGridViewTextBoxColumn10.HeaderText = "记账时间";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // Bds
            // 
            this.Bds.DataMember = "vfmsxtsr";
            this.Bds.DataSource = this.Dstfmsxtsr1;
            // 
            // Dstfmsxtsr1
            // 
            this.Dstfmsxtsr1.DataSetName = "DSTFMSXTSR";
            this.Dstfmsxtsr1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DgvColTxtDqmc
            // 
            this.DgvColTxtDqmc.DataPropertyName = "dqmc";
            this.DgvColTxtDqmc.HeaderText = "记账大区";
            this.DgvColTxtDqmc.Name = "DgvColTxtDqmc";
            // 
            // DgvColTxtJzjg
            // 
            this.DgvColTxtJzjg.DataPropertyName = "mc";
            this.DgvColTxtJzjg.HeaderText = "记账机构";
            this.DgvColTxtJzjg.Name = "DgvColTxtJzjg";
            // 
            // DgvColTxtJzlx
            // 
            this.DgvColTxtJzlx.DataPropertyName = "lxbhs";
            this.DgvColTxtJzlx.HeaderText = "记账类型";
            this.DgvColTxtJzlx.Name = "DgvColTxtJzlx";
            // 
            // DgvColTxtBh
            // 
            this.DgvColTxtBh.DataPropertyName = "bh";
            this.DgvColTxtBh.HeaderText = "编号";
            this.DgvColTxtBh.Name = "DgvColTxtBh";
            // 
            // DgvColTxtJzsj
            // 
            this.DgvColTxtJzsj.DataPropertyName = "inssj";
            this.DgvColTxtJzsj.HeaderText = "记账时间";
            this.DgvColTxtJzsj.Name = "DgvColTxtJzsj";
            // 
            // DgvColTxtJzje
            // 
            this.DgvColTxtJzje.DataPropertyName = "je";
            this.DgvColTxtJzje.HeaderText = "记账金额";
            this.DgvColTxtJzje.Name = "DgvColTxtJzje";
            // 
            // VfmsxtsrTableAdapter1
            // 
            this.VfmsxtsrTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmTZFGBFJKRB
            // 
            this.Controls.Add(this.PanlMain);
            this.Controls.Add(this.PnlBtns);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(712, 641);
            this.Text = "调整费和工本费缴款";
            this.PnlBtns.ResumeLayout(false);
            this.PanlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dstfmsxtsr1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label LblSum;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Label LblRowCount;
        private Button BtnJk;
        private Label LblJsrq;
        private DateTimePicker DtpStop;
        private DateTimePicker DtpStart;
        private Label LblKsrq;
        private ComboBox CmbLx;
        private Label LblYwqy;
        private Button BtnSearch;
        private Panel PnlBtns;
        private Panel PanlMain;
        private DataGridView Dgv;
        private BindingSource Bds;
        private DSTFMSXTSR Dstfmsxtsr1;
        private DSTFMSXTSRTableAdapters.vfmsxtsrTableAdapter VfmsxtsrTableAdapter1;
        private DataGridViewTextBoxColumn DgvColTxtDqmc;
        private DataGridViewTextBoxColumn DgvColTxtJzjg;
        private DataGridViewTextBoxColumn DgvColTxtJzlx;
        private DataGridViewTextBoxColumn DgvColTxtBh;
        private DataGridViewTextBoxColumn DgvColTxtJzsj;
        private DataGridViewTextBoxColumn DgvColTxtJzje;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;



    }
}