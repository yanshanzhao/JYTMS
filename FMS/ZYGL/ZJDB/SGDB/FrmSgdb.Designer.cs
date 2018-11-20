using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.ZJDB.SGDB
{
    partial class FrmSgdb
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
            this.BtnSearch = new Gizmox.WebGUI.Forms.Button();
            this.BtnDelete = new Gizmox.WebGUI.Forms.Button();
            this.BtnEdit = new Gizmox.WebGUI.Forms.Button();
            this.BtnNew = new Gizmox.WebGUI.Forms.Button();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.DtpSlStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.DtpSlStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtZczh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZczhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZcyhlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZczhlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZzje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZrzh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZrzhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZryhlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZrzhlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtLx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtInssj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSSGDB1 = new FMS.ZYGL.ZJDB.SGDB.DSSGDB();
            this.VzzlogTableAdapter1 = new FMS.ZYGL.ZJDB.SGDB.DSSGDBTableAdapters.VzzlogTableAdapter();
            this.PnlBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSSGDB1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSearch
            // 
            this.BtnSearch.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnSearch.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSearch.CustomStyle = "F";
            this.BtnSearch.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(13, 37);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 6;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnDelete.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDelete.CustomStyle = "F";
            this.BtnDelete.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.Location = new System.Drawing.Point(286, 37);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 9;
            this.BtnDelete.Text = "删除";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnEdit.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnEdit.CustomStyle = "F";
            this.BtnEdit.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.Location = new System.Drawing.Point(197, 37);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 8;
            this.BtnEdit.Text = "编辑";
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnNew.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnNew.CustomStyle = "F";
            this.BtnNew.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnNew.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.Location = new System.Drawing.Point(108, 37);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(75, 23);
            this.BtnNew.TabIndex = 7;
            this.BtnNew.Text = "新增";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.label4);
            this.PnlBtns.Controls.Add(this.DtpSlStart);
            this.PnlBtns.Controls.Add(this.label8);
            this.PnlBtns.Controls.Add(this.DtpSlStop);
            this.PnlBtns.Controls.Add(this.BtnSearch);
            this.PnlBtns.Controls.Add(this.BtnDelete);
            this.PnlBtns.Controls.Add(this.BtnEdit);
            this.PnlBtns.Controls.Add(this.BtnNew);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(948, 71);
            this.PnlBtns.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "手工调拨时间";
            // 
            // DtpSlStart
            // 
            this.DtpSlStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpSlStart.Checked = false;
            this.DtpSlStart.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpSlStart.CustomFormat = "yyyy.MM.dd";
            this.DtpSlStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSlStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpSlStart.Location = new System.Drawing.Point(89, 7);
            this.DtpSlStart.Name = "DtpSlStart";
            this.DtpSlStart.ShowCheckBox = true;
            this.DtpSlStart.Size = new System.Drawing.Size(134, 21);
            this.DtpSlStart.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(224, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "至";
            // 
            // DtpSlStop
            // 
            this.DtpSlStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpSlStop.Checked = false;
            this.DtpSlStop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpSlStop.CustomFormat = "yyyy.MM.dd";
            this.DtpSlStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSlStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpSlStop.Location = new System.Drawing.Point(241, 7);
            this.DtpSlStop.Name = "DtpSlStop";
            this.DtpSlStop.ShowCheckBox = true;
            this.DtpSlStop.Size = new System.Drawing.Size(134, 21);
            this.DtpSlStop.TabIndex = 5;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
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
            this.DgvColTxtZczh,
            this.DgvColTxtZczhmc,
            this.DgvColTxtZcyhlx,
            this.DgvColTxtZczhlx,
            this.DgvColTxtZzje,
            this.DgvColTxtZrzh,
            this.DgvColTxtZrzhmc,
            this.DgvColTxtZryhlx,
            this.DgvColTxtZrzhlx,
            this.DgvColTxtLx,
            this.DgvColTxtInssj});
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
            this.Dgv.Location = new System.Drawing.Point(0, 71);
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
            this.Dgv.Size = new System.Drawing.Size(948, 498);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColTxtZczh
            // 
            this.DgvColTxtZczh.DataPropertyName = "zczh";
            this.DgvColTxtZczh.HeaderText = "转出账户";
            this.DgvColTxtZczh.Name = "DgvColTxtZczh";
            this.DgvColTxtZczh.ReadOnly = true;
            this.DgvColTxtZczh.Width = 150;
            // 
            // DgvColTxtZczhmc
            // 
            this.DgvColTxtZczhmc.DataPropertyName = "zczhmc";
            this.DgvColTxtZczhmc.HeaderText = "转出账户名称";
            this.DgvColTxtZczhmc.Name = "DgvColTxtZczhmc";
            this.DgvColTxtZczhmc.ReadOnly = true;
            this.DgvColTxtZczhmc.Width = 150;
            // 
            // DgvColTxtZcyhlx
            // 
            this.DgvColTxtZcyhlx.DataPropertyName = "zcyhlx";
            this.DgvColTxtZcyhlx.HeaderText = "转出银行类型";
            this.DgvColTxtZcyhlx.Name = "DgvColTxtZcyhlx";
            this.DgvColTxtZcyhlx.ReadOnly = true;
            // 
            // DgvColTxtZczhlx
            // 
            this.DgvColTxtZczhlx.DataPropertyName = "zczhlxmc";
            this.DgvColTxtZczhlx.HeaderText = "转出账户类型";
            this.DgvColTxtZczhlx.Name = "DgvColTxtZczhlx";
            this.DgvColTxtZczhlx.ReadOnly = true;
            // 
            // DgvColTxtZzje
            // 
            this.DgvColTxtZzje.DataPropertyName = "zze";
            this.DgvColTxtZzje.HeaderText = "转账金额";
            this.DgvColTxtZzje.Name = "DgvColTxtZzje";
            this.DgvColTxtZzje.ReadOnly = true;
            // 
            // DgvColTxtZrzh
            // 
            this.DgvColTxtZrzh.DataPropertyName = "zrzh";
            this.DgvColTxtZrzh.HeaderText = "转入账户";
            this.DgvColTxtZrzh.Name = "DgvColTxtZrzh";
            this.DgvColTxtZrzh.ReadOnly = true;
            this.DgvColTxtZrzh.Width = 150;
            // 
            // DgvColTxtZrzhmc
            // 
            this.DgvColTxtZrzhmc.DataPropertyName = "zrzhmc";
            this.DgvColTxtZrzhmc.HeaderText = "转入账户名称";
            this.DgvColTxtZrzhmc.Name = "DgvColTxtZrzhmc";
            this.DgvColTxtZrzhmc.ReadOnly = true;
            this.DgvColTxtZrzhmc.Width = 150;
            // 
            // DgvColTxtZryhlx
            // 
            this.DgvColTxtZryhlx.DataPropertyName = "zryhlxmc";
            this.DgvColTxtZryhlx.HeaderText = "转入银行类型";
            this.DgvColTxtZryhlx.Name = "DgvColTxtZryhlx";
            this.DgvColTxtZryhlx.ReadOnly = true;
            // 
            // DgvColTxtZrzhlx
            // 
            this.DgvColTxtZrzhlx.DataPropertyName = "zrzhlxmc";
            this.DgvColTxtZrzhlx.HeaderText = "转入账户类型";
            this.DgvColTxtZrzhlx.Name = "DgvColTxtZrzhlx";
            this.DgvColTxtZrzhlx.ReadOnly = true;
            // 
            // DgvColTxtLx
            // 
            this.DgvColTxtLx.DataPropertyName = "lxs";
            this.DgvColTxtLx.HeaderText = "类型";
            this.DgvColTxtLx.Name = "DgvColTxtLx";
            this.DgvColTxtLx.ReadOnly = true;
            // 
            // DgvColTxtInssj
            // 
            this.DgvColTxtInssj.DataPropertyName = "inssj";
            this.DgvColTxtInssj.HeaderText = "转入时间";
            this.DgvColTxtInssj.Name = "DgvColTxtInssj";
            this.DgvColTxtInssj.ReadOnly = true;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vzzlog";
            this.Bds.DataSource = this.DSSGDB1;
            // 
            // DSSGDB1
            // 
            this.DSSGDB1.DataSetName = "DSSGDB";
            this.DSSGDB1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VzzlogTableAdapter1
            // 
            this.VzzlogTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmSgdb
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlBtns);
            this.Size = new System.Drawing.Size(948, 569);
            this.Text = "FrmSgdb";
            this.PnlBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSSGDB1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnSearch;
        private Button BtnDelete;
        private Button BtnEdit;
        private Button BtnNew;
        private Panel PnlBtns;
        private Label label4;
        private DateTimePicker DtpSlStart;
        private Label label8;
        private DateTimePicker DtpSlStop;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtZczh;
        private DataGridViewTextBoxColumn DgvColTxtZczhmc;
        private DataGridViewTextBoxColumn DgvColTxtZcyhlx;
        private DataGridViewTextBoxColumn DgvColTxtZczhlx;
        private DataGridViewTextBoxColumn DgvColTxtZrzh;
        private DataGridViewTextBoxColumn DgvColTxtZrzhmc;
        private DataGridViewTextBoxColumn DgvColTxtZryhlx;
        private DataGridViewTextBoxColumn DgvColTxtZrzhlx;
        private DataGridViewTextBoxColumn DgvColTxtLx;
        private DataGridViewTextBoxColumn DgvColTxtInssj;
        private BindingSource Bds;
        private DSSGDB DSSGDB1;
        private DSSGDBTableAdapters.VzzlogTableAdapter VzzlogTableAdapter1;
        private DataGridViewTextBoxColumn DgvColTxtZzje;


    }
}