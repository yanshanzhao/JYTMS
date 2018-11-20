using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKSFTHZ
{
    partial class FrmDSKSftHz
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
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnMxExcel = new Gizmox.WebGUI.Forms.Button();
            this.BtnExcel = new Gizmox.WebGUI.Forms.Button();
            this.BtnSel = new Gizmox.WebGUI.Forms.Button();
            this.label16 = new Gizmox.WebGUI.Forms.Label();
            this.DptEnd = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DptStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.TxtJg = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSeleJG = new Gizmox.WebGUI.Forms.Button();
            this.BtnSeleDQ = new Gizmox.WebGUI.Forms.Button();
            this.TxtDq = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvTxtDqmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtjgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtgs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtdsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtxx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtjgid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSDskhz1 = new FMS.DSKGL.DSKSFTHZ.DSDskhz();
            this.VfmssftcxTableAdapter1 = new FMS.DSKGL.DSKSFTHZ.DSDskhzTableAdapters.VfmssftcxTableAdapter();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDskhz1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnMxExcel);
            this.PnlTop.Controls.Add(this.BtnExcel);
            this.PnlTop.Controls.Add(this.BtnSel);
            this.PnlTop.Controls.Add(this.label16);
            this.PnlTop.Controls.Add(this.DptEnd);
            this.PnlTop.Controls.Add(this.DptStart);
            this.PnlTop.Controls.Add(this.label14);
            this.PnlTop.Controls.Add(this.label8);
            this.PnlTop.Controls.Add(this.TxtJg);
            this.PnlTop.Controls.Add(this.BtnSeleJG);
            this.PnlTop.Controls.Add(this.BtnSeleDQ);
            this.PnlTop.Controls.Add(this.TxtDq);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(655, 108);
            this.PnlTop.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(292, 74);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 14;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnMxExcel
            // 
            this.BtnMxExcel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnMxExcel.CustomStyle = "F";
            this.BtnMxExcel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnMxExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMxExcel.Location = new System.Drawing.Point(197, 74);
            this.BtnMxExcel.Name = "BtnMxExcel";
            this.BtnMxExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnMxExcel.TabIndex = 13;
            this.BtnMxExcel.Text = "导出明细";
            this.BtnMxExcel.Click += new System.EventHandler(this.BtnMxExcel_Click);
            // 
            // BtnExcel
            // 
            this.BtnExcel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExcel.CustomStyle = "F";
            this.BtnExcel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcel.Location = new System.Drawing.Point(105, 74);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnExcel.TabIndex = 12;
            this.BtnExcel.Text = "导出";
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // BtnSel
            // 
            this.BtnSel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSel.CustomStyle = "F";
            this.BtnSel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSel.Location = new System.Drawing.Point(19, 74);
            this.BtnSel.Name = "BtnSel";
            this.BtnSel.Size = new System.Drawing.Size(75, 23);
            this.BtnSel.TabIndex = 11;
            this.BtnSel.Text = "查询";
            this.BtnSel.Click += new System.EventHandler(this.BtnSel_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 9F);
            this.label16.Location = new System.Drawing.Point(180, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "—";
            // 
            // DptEnd
            // 
            this.DptEnd.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DptEnd.CustomFormat = "yyyy.MM.dd";
            this.DptEnd.Font = new System.Drawing.Font("宋体", 9F);
            this.DptEnd.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DptEnd.Location = new System.Drawing.Point(197, 12);
            this.DptEnd.Name = "DptEnd";
            this.DptEnd.Size = new System.Drawing.Size(131, 21);
            this.DptEnd.TabIndex = 3;
            // 
            // DptStart
            // 
            this.DptStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DptStart.CustomFormat = "yyyy.MM.dd";
            this.DptStart.Font = new System.Drawing.Font("宋体", 9F);
            this.DptStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DptStart.Location = new System.Drawing.Point(64, 12);
            this.DptStart.Name = "DptStart";
            this.DptStart.Size = new System.Drawing.Size(116, 21);
            this.DptStart.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 9F);
            this.label14.Location = new System.Drawing.Point(9, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "支付日期";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(357, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "支付机构";
            // 
            // TxtJg
            // 
            this.TxtJg.AllowDrag = false;
            this.TxtJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtJg.Location = new System.Drawing.Point(412, 13);
            this.TxtJg.Name = "TxtJg";
            this.TxtJg.ReadOnly = true;
            this.TxtJg.Size = new System.Drawing.Size(142, 20);
            this.TxtJg.TabIndex = 1;
            this.TxtJg.Tag = "0";
            // 
            // BtnSeleJG
            // 
            this.BtnSeleJG.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSeleJG.CustomStyle = "F";
            this.BtnSeleJG.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSeleJG.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSeleJG.Location = new System.Drawing.Point(557, 13);
            this.BtnSeleJG.Name = "BtnSeleJG";
            this.BtnSeleJG.Size = new System.Drawing.Size(20, 20);
            this.BtnSeleJG.TabIndex = 10;
            this.BtnSeleJG.Text = "》";
            this.BtnSeleJG.Click += new System.EventHandler(this.BtnSeleJG_Click);
            // 
            // BtnSeleDQ
            // 
            this.BtnSeleDQ.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSeleDQ.CustomStyle = "F";
            this.BtnSeleDQ.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSeleDQ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSeleDQ.Location = new System.Drawing.Point(209, 43);
            this.BtnSeleDQ.Name = "BtnSeleDQ";
            this.BtnSeleDQ.Size = new System.Drawing.Size(20, 20);
            this.BtnSeleDQ.TabIndex = 10;
            this.BtnSeleDQ.Text = "》";
            this.BtnSeleDQ.Click += new System.EventHandler(this.BtnSeleDQ_Click);
            // 
            // TxtDq
            // 
            this.TxtDq.AllowDrag = false;
            this.TxtDq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtDq.Location = new System.Drawing.Point(64, 43);
            this.TxtDq.Name = "TxtDq";
            this.TxtDq.ReadOnly = true;
            this.TxtDq.Size = new System.Drawing.Size(142, 20);
            this.TxtDq.TabIndex = 1;
            this.TxtDq.Tag = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "支付大区";
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvTxtDqmc,
            this.DgvTxtjgmc,
            this.DgvTxtgs,
            this.DgvTxtdsk,
            this.DgvTxtxx,
            this.DgvTxtjgid});
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
            this.Dgv.Location = new System.Drawing.Point(0, 108);
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
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(655, 477);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // DgvTxtDqmc
            // 
            this.DgvTxtDqmc.DataPropertyName = "dqmc";
            this.DgvTxtDqmc.HeaderText = "大区名称";
            this.DgvTxtDqmc.Name = "DgvTxtDqmc";
            this.DgvTxtDqmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvTxtjgmc
            // 
            this.DgvTxtjgmc.DataPropertyName = "jgmc";
            this.DgvTxtjgmc.HeaderText = "机构名称";
            this.DgvTxtjgmc.Name = "DgvTxtjgmc";
            this.DgvTxtjgmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvTxtgs
            // 
            this.DgvTxtgs.DataPropertyName = "gs";
            this.DgvTxtgs.HeaderText = "支付票数成功";
            this.DgvTxtgs.Name = "DgvTxtgs";
            this.DgvTxtgs.ReadOnly = true;
            this.DgvTxtgs.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvTxtdsk
            // 
            this.DgvTxtdsk.DataPropertyName = "dsk";
            this.DgvTxtdsk.HeaderText = "支付成本代收款";
            this.DgvTxtdsk.Name = "DgvTxtdsk";
            this.DgvTxtdsk.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvTxtdsk.Width = 120;
            // 
            // DgvTxtxx
            // 
            this.DgvTxtxx.DataPropertyName = "xx";
            this.DgvTxtxx.HeaderText = "详细信息";
            this.DgvTxtxx.Name = "DgvTxtxx";
            this.DgvTxtxx.ReadOnly = true;
            this.DgvTxtxx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvTxtjgid
            // 
            this.DgvTxtjgid.DataPropertyName = "jgid";
            this.DgvTxtjgid.HeaderText = "jgid";
            this.DgvTxtjgid.Name = "DgvTxtjgid";
            this.DgvTxtjgid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvTxtjgid.Visible = false;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmssftcx";
            this.Bds.DataSource = this.DSDskhz1;
            // 
            // DSDskhz1
            // 
            this.DSDskhz1.DataSetName = "DSDskhz";
            this.DSDskhz1.EnforceConstraints = false;
            this.DSDskhz1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmssftcxTableAdapter1
            // 
            this.VfmssftcxTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmDSKSftHz
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Size = new System.Drawing.Size(655, 585);
            this.Text = "FrmDSKSftHz";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDskhz1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private Label label16;
        private DateTimePicker DptEnd;
        private DateTimePicker DptStart;
        private Label label14;
        private Label label8;
        private TextBox TxtJg;
        private Button BtnSeleJG;
        private Button BtnSeleDQ;
        private TextBox TxtDq;
        private Label label1;
        private Button BtnMxExcel;
        private Button BtnExcel;
        private Button BtnSel;
       
        private DataGridView Dgv;
       
        private DSDskhz DSDskhz1;
        private DSDskhzTableAdapters.VfmssftcxTableAdapter VfmssftcxTableAdapter1;
        private BindingSource Bds;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private DataGridViewTextBoxColumn DgvTxtDqmc;
        private DataGridViewTextBoxColumn DgvTxtjgid;
        private DataGridViewTextBoxColumn DgvTxtjgmc;
        private DataGridViewTextBoxColumn DgvTxtdsk;
        private DataGridViewTextBoxColumn DgvTxtxx;
        private DataGridViewTextBoxColumn DgvTxtgs;


    }
}