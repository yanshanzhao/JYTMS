using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.XTWSR
{
    partial class FrmXtwDkcx
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
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.CmbYhlx = new Gizmox.WebGUI.Forms.ComboBox();
            this.BtnExcel = new Gizmox.WebGUI.Forms.Button();
            this.BtnSel = new Gizmox.WebGUI.Forms.Button();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.CmbZt = new Gizmox.WebGUI.Forms.ComboBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtpStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.TxtJg = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.BtnJG = new Gizmox.WebGUI.Forms.Button();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvTxtZhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtZh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtJe = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtDqmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtzzjg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtZt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSXtDKxz1 = new FMS.CWGL.XTWSR.DSXtDKxz();
            this.VfmsxtwpcTableAdapter1 = new FMS.CWGL.XTWSR.DSXtDKxzTableAdapters.VfmsxtwpcTableAdapter();
            this.DgvTxtywlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSXtDKxz1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.label6);
            this.PnlTop.Controls.Add(this.CmbYhlx);
            this.PnlTop.Controls.Add(this.BtnExcel);
            this.PnlTop.Controls.Add(this.BtnSel);
            this.PnlTop.Controls.Add(this.label4);
            this.PnlTop.Controls.Add(this.CmbZt);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.label3);
            this.PnlTop.Controls.Add(this.DtpStart);
            this.PnlTop.Controls.Add(this.DtpStop);
            this.PnlTop.Controls.Add(this.TxtJg);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Controls.Add(this.BtnJG);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(754, 100);
            this.PnlTop.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(222, 62);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 14;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(269, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "状态";
            // 
            // CmbYhlx
            // 
            this.CmbYhlx.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbYhlx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYhlx.FormattingEnabled = true;
            this.CmbYhlx.Location = new System.Drawing.Point(82, 30);
            this.CmbYhlx.Name = "CmbYhlx";
            this.CmbYhlx.Size = new System.Drawing.Size(121, 20);
            this.CmbYhlx.TabIndex = 12;
            // 
            // BtnExcel
            // 
            this.BtnExcel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExcel.CustomStyle = "F";
            this.BtnExcel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExcel.Location = new System.Drawing.Point(123, 64);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnExcel.TabIndex = 9;
            this.BtnExcel.Text = "导出";
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // BtnSel
            // 
            this.BtnSel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSel.CustomStyle = "F";
            this.BtnSel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSel.Location = new System.Drawing.Point(26, 65);
            this.BtnSel.Name = "BtnSel";
            this.BtnSel.Size = new System.Drawing.Size(75, 23);
            this.BtnSel.TabIndex = 8;
            this.BtnSel.Text = "查询";
            this.BtnSel.Click += new System.EventHandler(this.BtnSel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "银行类型";
            // 
            // CmbZt
            // 
            this.CmbZt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbZt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmbZt.FormattingEnabled = true;
            this.CmbZt.Items.AddRange(new object[] {
            "未审核",
            "审核通过",
            "全部"});
            this.CmbZt.Location = new System.Drawing.Point(311, 31);
            this.CmbZt.Name = "CmbZt";
            this.CmbZt.Size = new System.Drawing.Size(121, 20);
            this.CmbZt.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(280, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "保存时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(464, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "一";
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.CustomFormat = "yyyy年MM月dd日";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(337, 6);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(126, 16);
            this.DtpStart.TabIndex = 3;
            // 
            // DtpStop
            // 
            this.DtpStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStop.Checked = false;
            this.DtpStop.CustomFormat = "yyyy年MM月dd日";
            this.DtpStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStop.Location = new System.Drawing.Point(484, 6);
            this.DtpStop.Name = "DtpStop";
            this.DtpStop.Size = new System.Drawing.Size(129, 16);
            this.DtpStop.TabIndex = 4;
            // 
            // TxtJg
            // 
            this.TxtJg.AllowDrag = false;
            this.TxtJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtJg.Location = new System.Drawing.Point(82, 6);
            this.TxtJg.Name = "TxtJg";
            this.TxtJg.Size = new System.Drawing.Size(137, 21);
            this.TxtJg.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "制作机构";
            // 
            // BtnJG
            // 
            this.BtnJG.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnJG.CustomStyle = "F";
            this.BtnJG.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJG.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnJG.Location = new System.Drawing.Point(222, 4);
            this.BtnJG.Name = "BtnJG";
            this.BtnJG.Size = new System.Drawing.Size(41, 23);
            this.BtnJG.TabIndex = 0;
            this.BtnJG.Text = "》》";
            this.BtnJG.Click += new System.EventHandler(this.BtnJG_Click);
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
            this.DgvTxtZhmc,
            this.DgvTxtZh,
            this.DgvTxtJe,
            this.DgvTxtywlx,
            this.DgvTxtDqmc,
            this.DgvTxtzzjg,
            this.DgvTxtZt});
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
            this.Dgv.Location = new System.Drawing.Point(0, 100);
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
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.Size = new System.Drawing.Size(754, 376);
            this.Dgv.TabIndex = 1;
            // 
            // DgvTxtZhmc
            // 
            this.DgvTxtZhmc.DataPropertyName = "zhmc";
            this.DgvTxtZhmc.HeaderText = "姓名";
            this.DgvTxtZhmc.Name = "DgvTxtZhmc";
            // 
            // DgvTxtZh
            // 
            this.DgvTxtZh.DataPropertyName = "zh";
            this.DgvTxtZh.HeaderText = "卡号";
            this.DgvTxtZh.Name = "DgvTxtZh";
            // 
            // DgvTxtJe
            // 
            this.DgvTxtJe.DataPropertyName = "je";
            this.DgvTxtJe.HeaderText = "金额";
            this.DgvTxtJe.Name = "DgvTxtJe";
            // 
            // DgvTxtDqmc
            // 
            this.DgvTxtDqmc.DataPropertyName = "dqmc";
            this.DgvTxtDqmc.HeaderText = "大区名称";
            this.DgvTxtDqmc.Name = "DgvTxtDqmc";
            // 
            // DgvTxtzzjg
            // 
            this.DgvTxtzzjg.DataPropertyName = "zzjg";
            this.DgvTxtzzjg.HeaderText = "连锁店";
            this.DgvTxtzzjg.Name = "DgvTxtzzjg";
            // 
            // DgvTxtZt
            // 
            this.DgvTxtZt.DataPropertyName = "zts";
            this.DgvTxtZt.HeaderText = "状态";
            this.DgvTxtZt.Name = "DgvTxtZt";
            this.DgvTxtZt.ReadOnly = true;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsxtwpc";
            this.Bds.DataSource = this.DSXtDKxz1;
            // 
            // DSXtDKxz1
            // 
            this.DSXtDKxz1.DataSetName = "DSXtDKxz";
            this.DSXtDKxz1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmsxtwpcTableAdapter1
            // 
            this.VfmsxtwpcTableAdapter1.ClearBeforeFill = true;
            // 
            // DgvTxtywlx
            // 
            this.DgvTxtywlx.DataPropertyName = "lxs";
            this.DgvTxtywlx.HeaderText = "业务类型";
            this.DgvTxtywlx.Name = "DgvTxtywlx";
            // 
            // FrmXtwDkcx
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Size = new System.Drawing.Size(754, 476);
            this.Text = "FrmXtwDkcx";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSXtDKxz1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private DataGridView Dgv;
        private TextBox TxtJg;
        private Label label1;
        private Button BtnJG;
        private Label label2;
        private Label label3;
        private DateTimePicker DtpStart;
        private DateTimePicker DtpStop;
        //private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExcel;
        private Button BtnSel;
        private Label label4;
        private ComboBox CmbZt;
        private ComboBox CmbYhlx;
        private Label label6;
        private DSXtDKxz DSXtDKxz1;
        private DSXtDKxzTableAdapters.VfmsxtwpcTableAdapter VfmsxtwpcTableAdapter1;
        private BindingSource Bds;
        private DataGridViewTextBoxColumn DgvTxtZh;
        private DataGridViewTextBoxColumn DgvTxtZhmc;
        private DataGridViewTextBoxColumn DgvTxtDqmc;
        private DataGridViewTextBoxColumn DgvTxtzzjg;
        private DataGridViewTextBoxColumn DgvTxtZt;
        private DataGridViewTextBoxColumn DgvTxtJe;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private DataGridViewTextBoxColumn DgvTxtywlx;


    }
}