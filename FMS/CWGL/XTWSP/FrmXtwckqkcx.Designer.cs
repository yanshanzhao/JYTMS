using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.XTWSP
{
    partial class FrmXtwckqkcx
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
            this.BtnSqdq = new Gizmox.WebGUI.Forms.Button();
            this.TxtSqdq = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.DtpSpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpSpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.BtnExcel = new Gizmox.WebGUI.Forms.Button();
            this.BtnSel = new Gizmox.WebGUI.Forms.Button();
            this.CmbLx = new Gizmox.WebGUI.Forms.ComboBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.CmbCkqk = new Gizmox.WebGUI.Forms.ComboBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.BtnJg = new Gizmox.WebGUI.Forms.Button();
            this.TxtJg = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSSP1 = new FMS.CWGL.XTWSP.DSSP();
            this.Vfmsxtw_jgckTableAdapter1 = new FMS.CWGL.XTWSP.DSSPTableAdapters.Vfmsxtw_jgckTableAdapter();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSSP1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnSqdq);
            this.PnlTop.Controls.Add(this.TxtSqdq);
            this.PnlTop.Controls.Add(this.label6);
            this.PnlTop.Controls.Add(this.label3);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.DtpSpStart);
            this.PnlTop.Controls.Add(this.DtpSpStop);
            this.PnlTop.Controls.Add(this.BtnExcel);
            this.PnlTop.Controls.Add(this.BtnSel);
            this.PnlTop.Controls.Add(this.CmbLx);
            this.PnlTop.Controls.Add(this.label5);
            this.PnlTop.Controls.Add(this.CmbCkqk);
            this.PnlTop.Controls.Add(this.label4);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.BtnJg);
            this.PnlTop.Controls.Add(this.TxtJg);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(815, 105);
            this.PnlTop.TabIndex = 0;
            // 
            // BtnSqdq
            // 
            this.BtnSqdq.CustomStyle = "F";
            this.BtnSqdq.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSqdq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSqdq.Location = new System.Drawing.Point(439, 14);
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
            this.TxtSqdq.Location = new System.Drawing.Point(305, 14);
            this.TxtSqdq.Name = "TxtSqdq";
            this.TxtSqdq.Size = new System.Drawing.Size(131, 21);
            this.TxtSqdq.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(249, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "申请大区";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(637, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "-";
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(182, 72);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 11;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // DtpSpStart
            // 
            this.DtpSpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpSpStart.Checked = false;
            this.DtpSpStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpSpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpSpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpSpStart.Location = new System.Drawing.Point(653, 14);
            this.DtpSpStart.Name = "DtpSpStart";
            this.DtpSpStart.ShowCheckBox = true;
            this.DtpSpStart.Size = new System.Drawing.Size(98, 21);
            this.DtpSpStart.TabIndex = 8;
            // 
            // DtpSpStop
            // 
            this.DtpSpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpSpStop.Checked = false;
            this.DtpSpStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpSpStop.CustomFormat = "yyyy.MM.dd";
            this.DtpSpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpSpStop.Location = new System.Drawing.Point(533, 14);
            this.DtpSpStop.Name = "DtpSpStop";
            this.DtpSpStop.ShowCheckBox = true;
            this.DtpSpStop.Size = new System.Drawing.Size(104, 21);
            this.DtpSpStop.TabIndex = 10;
            // 
            // BtnExcel
            // 
            this.BtnExcel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExcel.CustomStyle = "F";
            this.BtnExcel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcel.Location = new System.Drawing.Point(102, 72);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnExcel.TabIndex = 10;
            this.BtnExcel.Text = "导出";
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // BtnSel
            // 
            this.BtnSel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSel.CustomStyle = "F";
            this.BtnSel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSel.Location = new System.Drawing.Point(22, 72);
            this.BtnSel.Name = "BtnSel";
            this.BtnSel.Size = new System.Drawing.Size(75, 23);
            this.BtnSel.TabIndex = 9;
            this.BtnSel.Text = "查询";
            this.BtnSel.Click += new System.EventHandler(this.BtnSel_Click);
            // 
            // CmbLx
            // 
            this.CmbLx.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.CmbLx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbLx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLx.FormattingEnabled = true;
            this.CmbLx.Location = new System.Drawing.Point(60, 41);
            this.CmbLx.Name = "CmbLx";
            this.CmbLx.Size = new System.Drawing.Size(138, 20);
            this.CmbLx.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "类型名称";
            // 
            // CmbCkqk
            // 
            this.CmbCkqk.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.CmbCkqk.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbCkqk.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCkqk.FormattingEnabled = true;
            this.CmbCkqk.Items.AddRange(new object[] {
            "全部",
            "已存",
            "未存"});
            this.CmbCkqk.Location = new System.Drawing.Point(305, 41);
            this.CmbCkqk.Name = "CmbCkqk";
            this.CmbCkqk.Size = new System.Drawing.Size(131, 20);
            this.CmbCkqk.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(250, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "存款情况";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(476, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "记账日期";
            // 
            // BtnJg
            // 
            this.BtnJg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnJg.CustomStyle = "F";
            this.BtnJg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnJg.Location = new System.Drawing.Point(201, 12);
            this.BtnJg.Name = "BtnJg";
            this.BtnJg.Size = new System.Drawing.Size(42, 23);
            this.BtnJg.TabIndex = 2;
            this.BtnJg.Text = ">>";
            this.BtnJg.Click += new System.EventHandler(this.BtnJg_Click);
            // 
            // TxtJg
            // 
            this.TxtJg.AllowDrag = false;
            this.TxtJg.Enabled = false;
            this.TxtJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJg.Location = new System.Drawing.Point(60, 14);
            this.TxtJg.Name = "TxtJg";
            this.TxtJg.Size = new System.Drawing.Size(138, 21);
            this.TxtJg.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "申请机构";
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowDragTargetsPropagation = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
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
            this.Dgv.Location = new System.Drawing.Point(0, 105);
            this.Dgv.Name = "Dgv";
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
            this.Dgv.Size = new System.Drawing.Size(815, 499);
            this.Dgv.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "dqmc";
            this.dataGridViewTextBoxColumn1.HeaderText = "大区名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "jgmc";
            this.dataGridViewTextBoxColumn2.HeaderText = "机构名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "bh";
            this.dataGridViewTextBoxColumn4.HeaderText = "业务单号";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "inssj";
            this.dataGridViewTextBoxColumn5.HeaderText = "记账日期";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "je";
            this.dataGridViewTextBoxColumn6.HeaderText = "金额";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "zts";
            this.dataGridViewTextBoxColumn7.HeaderText = "存款情况";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "lxmc";
            this.dataGridViewTextBoxColumn8.HeaderText = "类型";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsxtw_jgck";
            this.Bds.DataSource = this.DSSP1;
            // 
            // DSSP1
            // 
            this.DSSP1.DataSetName = "DSSP";
            this.DSSP1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Vfmsxtw_jgckTableAdapter1
            // 
            this.Vfmsxtw_jgckTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmXtwckqkcx
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Size = new System.Drawing.Size(815, 604);
            this.Text = "FrmXtwckqkcx";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSSP1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private DataGridView Dgv;
        private ComboBox CmbLx;
        private Label label5;
        private ComboBox CmbCkqk;
        private Label label4;
        private Label label2;
        private Button BtnJg;
        private TextBox TxtJg;
        private Label label1;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExcel;
        private Button BtnSel;
        private Label label3;
        private DateTimePicker DtpSpStart;
        private DateTimePicker DtpSpStop;
        private DSSP DSSP1;
        private DSSPTableAdapters.Vfmsxtw_jgckTableAdapter Vfmsxtw_jgckTableAdapter1;
        private BindingSource Bds;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private Button BtnSqdq;
        private TextBox TxtSqdq;
        private Label label6;


    }
}
