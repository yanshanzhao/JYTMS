using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKYCDKHZ
{
    partial class FrmDSKYCHZ
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvLnkCzje = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColLiKjse = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColLiKqme = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSDSKYCHZ1 = new FMS.DSKGL.DSKYCDKHZ.DSDSKYCHZ();
            this.VfmsdskychzTableAdapter1 = new FMS.DSKGL.DSKYCDKHZ.DSDSKYCHZTableAdapters.VfmsdskychzTableAdapter();
            this.PnlTop.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDSKYCHZ1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Red);
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(15, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(251, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "*本日期末余额=前日期末余额+本日增加额-本日减少额";
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(415, 12);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 18;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(118, 41);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 4;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // DtpStop
            // 
            this.DtpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStop.Checked = false;
            this.DtpStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStop.CustomFormat = "yyyy.MM.dd";
            this.DtpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStop.Location = new System.Drawing.Point(267, 12);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.Size = new System.Drawing.Size(134, 21);
            this.DtpStop.TabIndex = 2;
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Checked = false;
            this.DtpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(70, 12);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(134, 21);
            this.DtpStart.TabIndex = 1;
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(17, 41);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "查询";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(212, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "结束时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "起始时间";
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.label9);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnExl);
            this.PnlTop.Controls.Add(this.DtpStop);
            this.PnlTop.Controls.Add(this.DtpStart);
            this.PnlTop.Controls.Add(this.BtnSave);
            this.PnlTop.Controls.Add(this.label3);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(675, 100);
            this.PnlTop.TabIndex = 1;
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 100);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(675, 364);
            this.PnlMain.TabIndex = 2;
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
            this.DgvColTxtsj,
            this.DgvLnkCzje,
            this.DgvColLiKjse,
            this.DgvColLiKqme});
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle7;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.ItemsPerPage = 40;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.Dgv.RowHeadersWidth = 10;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(675, 364);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellMouseDown += new Gizmox.WebGUI.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseDown);
            // 
            // DgvColTxtsj
            // 
            this.DgvColTxtsj.DataPropertyName = "sj";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtsj.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtsj.HeaderText = "日期";
            this.DgvColTxtsj.Name = "DgvColTxtsj";
            this.DgvColTxtsj.ReadOnly = true;
            this.DgvColTxtsj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvLnkCzje
            // 
            this.DgvLnkCzje.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvLnkCzje.ClientMode = false;
            this.DgvLnkCzje.DataPropertyName = "xzje";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvLnkCzje.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvLnkCzje.HeaderText = "本日增加额";
            this.DgvLnkCzje.LinkColor = System.Drawing.Color.Empty;
            this.DgvLnkCzje.Name = "DgvLnkCzje";
            this.DgvLnkCzje.ReadOnly = true;
            this.DgvLnkCzje.TrackVisitedState = false;
            this.DgvLnkCzje.Url = "";
            this.DgvLnkCzje.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvColLiKjse
            // 
            this.DgvColLiKjse.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColLiKjse.ClientMode = false;
            this.DgvColLiKjse.DataPropertyName = "ffje";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColLiKjse.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColLiKjse.HeaderText = "本日减少额";
            this.DgvColLiKjse.LinkColor = System.Drawing.Color.Empty;
            this.DgvColLiKjse.Name = "DgvColLiKjse";
            this.DgvColLiKjse.ReadOnly = true;
            this.DgvColLiKjse.TrackVisitedState = false;
            this.DgvColLiKjse.Url = "";
            this.DgvColLiKjse.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvColLiKqme
            // 
            this.DgvColLiKqme.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColLiKqme.ClientMode = false;
            this.DgvColLiKqme.DataPropertyName = "qm";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColLiKqme.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvColLiKqme.HeaderText = "本日期末余额";
            this.DgvColLiKqme.LinkColor = System.Drawing.Color.Empty;
            this.DgvColLiKqme.Name = "DgvColLiKqme";
            this.DgvColLiKqme.ReadOnly = true;
            this.DgvColLiKqme.TrackVisitedState = false;
            this.DgvColLiKqme.Url = "";
            this.DgvColLiKqme.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsdskychz";
            this.Bds.DataSource = this.DSDSKYCHZ1;
            // 
            // DSDSKYCHZ1
            // 
            this.DSDSKYCHZ1.DataSetName = "DSDSKYCHZ";
            this.DSDSKYCHZ1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmsdskychzTableAdapter1
            // 
            this.VfmsdskychzTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmDSKYCHZ
            // 
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(675, 464);
            this.Text = "FrmDSKYCHZ";
            this.PnlTop.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDSKYCHZ1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label9;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExl;
        private DateTimePicker DtpStop;
        private DateTimePicker DtpStart;
        private Button BtnSave;
        private Label label3;
        private Label label2;
        private Panel PnlTop;
        private Panel PnlMain;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtsj;
        private BindingSource Bds;
        private DSDSKYCHZ DSDSKYCHZ1;
        private DSDSKYCHZTableAdapters.VfmsdskychzTableAdapter VfmsdskychzTableAdapter1;
        private DataGridViewLinkColumn DgvLnkCzje;
        private DataGridViewLinkColumn DgvColLiKjse;
        private DataGridViewLinkColumn DgvColLiKqme;


    }
}