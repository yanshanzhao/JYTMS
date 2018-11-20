using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.ZJDB.YQZLDB
{
    partial class FrmYQZLDB
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
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnDel = new Gizmox.WebGUI.Forms.Button();
            this.BtnZr = new Gizmox.WebGUI.Forms.Button();
            this.BtnZc = new Gizmox.WebGUI.Forms.Button();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.LblSJ = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.BtnQr = new Gizmox.WebGUI.Forms.Button();
            this.BtnElse = new Gizmox.WebGUI.Forms.Button();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtzczh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJzczhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzczhzy = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzrzh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzrzhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzrzhyh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtsjzze = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtxx = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
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
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnDel);
            this.PnlTop.Controls.Add(this.BtnZr);
            this.PnlTop.Controls.Add(this.BtnZc);
            this.PnlTop.Controls.Add(this.DtpStart);
            this.PnlTop.Controls.Add(this.LblSJ);
            this.PnlTop.Controls.Add(this.label5);
            this.PnlTop.Controls.Add(this.DtpStop);
            this.PnlTop.Controls.Add(this.BtnQr);
            this.PnlTop.Controls.Add(this.BtnElse);
            this.PnlTop.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(796, 78);
            this.PnlTop.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(514, 46);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 14;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnDel
            // 
            this.BtnDel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDel.CustomStyle = "F";
            this.BtnDel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDel.Location = new System.Drawing.Point(318, 48);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(75, 23);
            this.BtnDel.TabIndex = 13;
            this.BtnDel.Text = "删除";
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // BtnZr
            // 
            this.BtnZr.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnZr.CustomStyle = "F";
            this.BtnZr.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnZr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnZr.Location = new System.Drawing.Point(122, 48);
            this.BtnZr.Name = "BtnZr";
            this.BtnZr.Size = new System.Drawing.Size(75, 23);
            this.BtnZr.TabIndex = 12;
            this.BtnZr.Text = "转入资金池";
            this.BtnZr.Click += new System.EventHandler(this.BtnZr_Click);
            // 
            // BtnZc
            // 
            this.BtnZc.CustomStyle = "F";
            this.BtnZc.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnZc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnZc.Location = new System.Drawing.Point(220, 48);
            this.BtnZc.Name = "BtnZc";
            this.BtnZc.Size = new System.Drawing.Size(75, 23);
            this.BtnZc.TabIndex = 11;
            this.BtnZc.Text = "资金池转出";
            this.BtnZc.Click += new System.EventHandler(this.BtnZz_Click);
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.Checked = false;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(105, 15);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(133, 21);
            this.DtpStart.TabIndex = 6;
            // 
            // LblSJ
            // 
            this.LblSJ.AutoSize = true;
            this.LblSJ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSJ.Location = new System.Drawing.Point(22, 19);
            this.LblSJ.Name = "LblSJ";
            this.LblSJ.Size = new System.Drawing.Size(53, 12);
            this.LblSJ.TabIndex = 0;
            this.LblSJ.Text = "新增操作时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(242, 19);
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
            this.DtpStop.Location = new System.Drawing.Point(263, 15);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.Size = new System.Drawing.Size(133, 21);
            this.DtpStop.TabIndex = 7;
            // 
            // BtnQr
            // 
            this.BtnQr.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnQr.CustomStyle = "F";
            this.BtnQr.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQr.Location = new System.Drawing.Point(24, 48);
            this.BtnQr.Name = "BtnQr";
            this.BtnQr.Size = new System.Drawing.Size(75, 23);
            this.BtnQr.TabIndex = 8;
            this.BtnQr.Text = "查询";
            this.BtnQr.Click += new System.EventHandler(this.BtnQr_Click);
            // 
            // BtnElse
            // 
            this.BtnElse.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnElse.CustomStyle = "F";
            this.BtnElse.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnElse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnElse.Location = new System.Drawing.Point(416, 48);
            this.BtnElse.Name = "BtnElse";
            this.BtnElse.Size = new System.Drawing.Size(75, 23);
            this.BtnElse.TabIndex = 9;
            this.BtnElse.Text = "导出";
            this.BtnElse.Click += new System.EventHandler(this.BtnElse_Click);
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
            this.DgvColTxtJzczhmc,
            this.DgvColTxtzczhzy,
            this.DgvColTxtzrzh,
            this.DgvColTxtzrzhmc,
            this.DgvColTxtzrzhyh,
            this.DgvColTxtsjzze,
            this.DgvColTxtxx,
            this.DgvColTxtid,
            this.DgvColTxtlx});
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
            this.Dgv.Location = new System.Drawing.Point(0, 78);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(796, 428);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellContentClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellContentClick);
            
            // 
            // DgvColTxtzczh
            // 
            this.DgvColTxtzczh.DataPropertyName = "zczh";
            this.DgvColTxtzczh.HeaderText = "转出帐号";
            this.DgvColTxtzczh.Name = "DgvColTxtzczh";
            this.DgvColTxtzczh.ReadOnly = true;
            this.DgvColTxtzczh.Width = 150;
            // 
            // DgvColTxtJzczhmc
            // 
            this.DgvColTxtJzczhmc.DataPropertyName = "zczhmc";
            this.DgvColTxtJzczhmc.HeaderText = "转出帐号名称";
            this.DgvColTxtJzczhmc.Name = "DgvColTxtJzczhmc";
            this.DgvColTxtJzczhmc.ReadOnly = true;
            this.DgvColTxtJzczhmc.Width = 150;
            // 
            // DgvColTxtzczhzy
            // 
            this.DgvColTxtzczhzy.DataPropertyName = "zczhyh";
            this.DgvColTxtzczhzy.HeaderText = "转出帐号银行";
            this.DgvColTxtzczhzy.Name = "DgvColTxtzczhzy";
            this.DgvColTxtzczhzy.ReadOnly = true;
            this.DgvColTxtzczhzy.Width = 110;
            // 
            // DgvColTxtzrzh
            // 
            this.DgvColTxtzrzh.DataPropertyName = "zrzh";
            this.DgvColTxtzrzh.HeaderText = "转入帐号";
            this.DgvColTxtzrzh.Name = "DgvColTxtzrzh";
            this.DgvColTxtzrzh.ReadOnly = true;
            this.DgvColTxtzrzh.Width = 150;
            // 
            // DgvColTxtzrzhmc
            // 
            this.DgvColTxtzrzhmc.DataPropertyName = "zrzhmc";
            this.DgvColTxtzrzhmc.HeaderText = "转入帐号名称";
            this.DgvColTxtzrzhmc.Name = "DgvColTxtzrzhmc";
            this.DgvColTxtzrzhmc.ReadOnly = true;
            this.DgvColTxtzrzhmc.Width = 150;
            // 
            // DgvColTxtzrzhyh
            // 
            this.DgvColTxtzrzhyh.DataPropertyName = "zrzhyh";
            this.DgvColTxtzrzhyh.HeaderText = "转入帐号银行";
            this.DgvColTxtzrzhyh.Name = "DgvColTxtzrzhyh";
            this.DgvColTxtzrzhyh.ReadOnly = true;
            this.DgvColTxtzrzhyh.Width = 120;
            // 
            // DgvColTxtsjzze
            // 
            this.DgvColTxtsjzze.DataPropertyName = "sjzze";
            this.DgvColTxtsjzze.HeaderText = "实际转账额";
            this.DgvColTxtsjzze.Name = "DgvColTxtsjzze";
            this.DgvColTxtsjzze.ReadOnly = true;
            // 
            // DgvColTxtxx
            // 
            this.DgvColTxtxx.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtxx.ClientMode = false;
            this.DgvColTxtxx.DataPropertyName = "xx";
            this.DgvColTxtxx.HeaderText = "详细";
            this.DgvColTxtxx.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvColTxtxx.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtxx.Name = "DgvColTxtxx";
            this.DgvColTxtxx.ReadOnly = true;
            this.DgvColTxtxx.TrackVisitedState = false;
            this.DgvColTxtxx.Url = "";
            this.DgvColTxtxx.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvColTxtid
            // 
            this.DgvColTxtid.DataPropertyName = "id";
            this.DgvColTxtid.HeaderText = "id";
            this.DgvColTxtid.Name = "DgvColTxtid";
            this.DgvColTxtid.ReadOnly = true;
            this.DgvColTxtid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtid.Visible = false;
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
            // FrmYQZLDB
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Size = new System.Drawing.Size(796, 506);
            this.Text = "FrmYQZLDP";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSYQZL1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private DateTimePicker DtpStart;
        private Label LblSJ;
        private Label label5;
        private DateTimePicker DtpStop;
        private Button BtnQr;
        private Button BtnElse;
        //private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private DataGridView Dgv;
        private Button BtnZc;
        private Button BtnZr;
        //private JY.CtrlPub.CtrlDownLoad ctrlDownLoad2;
        private Button BtnDel;
        //private JY.CtrlPub.CtrlDownLoad ctrlDownLoad3;
        private YQZLDP.DSYQZL DSYQZL1;
        private YQZLDP.DSYQZLTableAdapters.VfmsyqzlfhTableAdapter VfmsyqzlfhTableAdapter1;
        private BindingSource Bds;
        private DataGridViewTextBoxColumn DgvColTxtzczh;
        private DataGridViewTextBoxColumn DgvColTxtJzczhmc;
        private DataGridViewTextBoxColumn DgvColTxtzczhzy;
        private DataGridViewTextBoxColumn DgvColTxtzrzh;
        private DataGridViewTextBoxColumn DgvColTxtzrzhmc;
        private DataGridViewTextBoxColumn DgvColTxtzrzhyh;
        private DataGridViewTextBoxColumn DgvColTxtsjzze;
        private DataGridViewTextBoxColumn DgvColTxtid;
        private DataGridViewTextBoxColumn DgvColTxtlx;
        private DataGridViewLinkColumn DgvColTxtxx;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;


    }
}