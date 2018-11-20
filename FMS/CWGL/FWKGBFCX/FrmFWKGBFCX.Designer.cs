using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.FWKGBFCX
{
    partial class FrmFWKGBFCX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnDaoChu = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnSel = new Gizmox.WebGUI.Forms.Button();
            this.TxtJg = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.DtpSqStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpSqStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtBh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSqsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSqjg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSkje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.dsxtsrcx1 = new FMS.CWGL.YDTZFCX.DSXTSRCX();
            this.vfmsxtsrcxTableAdapter1 = new FMS.CWGL.YDTZFCX.DSXTSRCXTableAdapters.vfmsxtsrcxTableAdapter();
            this.DgvColTxtsqdq = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.BtnSqdq = new Gizmox.WebGUI.Forms.Button();
            this.TxtSqdq = new Gizmox.WebGUI.Forms.TextBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.PnlTop.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsxtsrcx1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.label8);
            this.PnlTop.Controls.Add(this.TxtSqdq);
            this.PnlTop.Controls.Add(this.BtnSqdq);
            this.PnlTop.Controls.Add(this.BtnSave);
            this.PnlTop.Controls.Add(this.BtnDaoChu);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnSel);
            this.PnlTop.Controls.Add(this.TxtJg);
            this.PnlTop.Controls.Add(this.label3);
            this.PnlTop.Controls.Add(this.DtpSqStop);
            this.PnlTop.Controls.Add(this.DtpSqStart);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(882, 87);
            this.PnlTop.TabIndex = 0;
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(21, 48);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 11;
            this.BtnSave.Text = "查询";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnDaoChu
            // 
            this.BtnDaoChu.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDaoChu.CustomStyle = "F";
            this.BtnDaoChu.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDaoChu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDaoChu.Location = new System.Drawing.Point(110, 48);
            this.BtnDaoChu.Name = "BtnDaoChu";
            this.BtnDaoChu.Size = new System.Drawing.Size(75, 23);
            this.BtnDaoChu.TabIndex = 11;
            this.BtnDaoChu.Text = "导出";
            this.BtnDaoChu.Click += new System.EventHandler(this.BtnDaoChu_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDownLoad1.Location = new System.Drawing.Point(526, 46);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 22;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnSel
            // 
            this.BtnSel.CustomStyle = "F";
            this.BtnSel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSel.Location = new System.Drawing.Point(552, 16);
            this.BtnSel.Name = "BtnSel";
            this.BtnSel.Size = new System.Drawing.Size(26, 21);
            this.BtnSel.TabIndex = 5;
            this.BtnSel.Text = "》";
            this.BtnSel.Click += new System.EventHandler(this.BtnSel_Click);
            // 
            // TxtJg
            // 
            this.TxtJg.AllowDrag = false;
            this.TxtJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJg.Location = new System.Drawing.Point(395, 17);
            this.TxtJg.Name = "TxtJg";
            this.TxtJg.Size = new System.Drawing.Size(151, 20);
            this.TxtJg.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "-";
            // 
            // DtpSqStop
            // 
            this.DtpSqStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpSqStop.Checked = false;
            this.DtpSqStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpSqStop.CustomFormat = "yyyy.MM.dd";
            this.DtpSqStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSqStop.Location = new System.Drawing.Point(206, 17);
            this.DtpSqStop.Name = "DtpSqStop";
            this.DtpSqStop.ShowCheckBox = true;
            this.DtpSqStop.Size = new System.Drawing.Size(122, 21);
            this.DtpSqStop.TabIndex = 1;
            // 
            // DtpSqStart
            // 
            this.DtpSqStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpSqStart.Checked = false;
            this.DtpSqStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpSqStart.CustomFormat = "yyyy.MM.dd";
            this.DtpSqStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSqStart.Location = new System.Drawing.Point(72, 17);
            this.DtpSqStart.Name = "DtpSqStart";
            this.DtpSqStart.ShowCheckBox = true;
            this.DtpSqStart.Size = new System.Drawing.Size(122, 21);
            this.DtpSqStart.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "申请机构";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "申请时间";
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 87);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(882, 490);
            this.PnlMain.TabIndex = 1;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.Dgv.AutoGenerateColumns = false;
            dataGridViewCellStyle10.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvColTxtBh,
            this.DgvColTxtSqsj,
            this.DgvColTxtsqdq,
            this.DgvColTxtSqjg,
            this.DgvColTxtSkje});
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle11.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle11;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            dataGridViewCellStyle12.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(882, 490);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColTxtBh
            // 
            this.DgvColTxtBh.DataPropertyName = "bh";
            this.DgvColTxtBh.HeaderText = "编号";
            this.DgvColTxtBh.Name = "DgvColTxtBh";
            // 
            // DgvColTxtSqsj
            // 
            this.DgvColTxtSqsj.DataPropertyName = "sqsj";
            this.DgvColTxtSqsj.HeaderText = "申请时间";
            this.DgvColTxtSqsj.Name = "DgvColTxtSqsj";
            this.DgvColTxtSqsj.Width = 150;
            // 
            // DgvColTxtSqjg
            // 
            this.DgvColTxtSqjg.DataPropertyName = "sqjg";
            this.DgvColTxtSqjg.HeaderText = "申请机构";
            this.DgvColTxtSqjg.Name = "DgvColTxtSqjg";
            this.DgvColTxtSqjg.Width = 150;
            // 
            // DgvColTxtSkje
            // 
            this.DgvColTxtSkje.DataPropertyName = "je";
            this.DgvColTxtSkje.HeaderText = "收款金额";
            this.DgvColTxtSkje.Name = "DgvColTxtSkje";
            // 
            // Bds
            // 
            this.Bds.DataMember = "vfmsxtsrcx";
            this.Bds.DataSource = this.dsxtsrcx1;
            // 
            // dsxtsrcx1
            // 
            this.dsxtsrcx1.DataSetName = "DSXTSRCX";
            this.dsxtsrcx1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vfmsxtsrcxTableAdapter1
            // 
            this.vfmsxtsrcxTableAdapter1.ClearBeforeFill = true;
            // 
            // DgvColTxtsqdq
            // 
            this.DgvColTxtsqdq.DataPropertyName = "dqmc";
            this.DgvColTxtsqdq.HeaderText = "申请大区";
            this.DgvColTxtsqdq.Name = "DgvColTxtsqdq";
            // 
            // BtnSqdq
            // 
            this.BtnSqdq.CustomStyle = "F";
            this.BtnSqdq.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSqdq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSqdq.Location = new System.Drawing.Point(771, 16);
            this.BtnSqdq.Name = "BtnSqdq";
            this.BtnSqdq.Size = new System.Drawing.Size(26, 21);
            this.BtnSqdq.TabIndex = 4;
            this.BtnSqdq.Text = "》";
            this.BtnSqdq.Visible = false;
            this.BtnSqdq.Click += new System.EventHandler(this.BtnSqdq_Click);
            // 
            // TxtSqdq
            // 
            this.TxtSqdq.AllowDrag = false;
            this.TxtSqdq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtSqdq.Location = new System.Drawing.Point(637, 16);
            this.TxtSqdq.Name = "TxtSqdq";
            this.TxtSqdq.Size = new System.Drawing.Size(131, 21);
            this.TxtSqdq.TabIndex = 3;
            this.TxtSqdq.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(581, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "申请大区";
            this.label8.Visible = false;
            // 
            // FrmFWKGBFCX
            // 
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(882, 577);
            this.Text = "FrmFWKGBFCX";
            this.PnlTop.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsxtsrcx1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private DateTimePicker DtpSqStart;
        private Label label2;
        private Label label1;
        private Panel PnlMain;
        private DateTimePicker DtpSqStop;
        private Label label3;
        private Button BtnSel;
        private TextBox TxtJg;
        private Button BtnSave;
        private Button BtnDaoChu;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private BindingSource Bds;
        private YDTZFCX.DSXTSRCX dsxtsrcx1;
        private YDTZFCX.DSXTSRCXTableAdapters.vfmsxtsrcxTableAdapter vfmsxtsrcxTableAdapter1;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn DgvColTxtSqsj;
        private DataGridViewTextBoxColumn DgvColTxtSqjg;
        private DataGridViewTextBoxColumn DgvColTxtSkje;
        private DataGridViewTextBoxColumn DgvColTxtBh;
        private DataGridViewTextBoxColumn DgvColTxtsqdq;
        private Label label8;
        private TextBox TxtSqdq;
        private Button BtnSqdq;


    }
}