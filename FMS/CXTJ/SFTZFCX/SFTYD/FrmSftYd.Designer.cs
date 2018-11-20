using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.SFTZFCX.SFTYD
{
    partial class FrmSftYd
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvTxtbh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtjgid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtdqmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtqssj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtdsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtsftje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtzdsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtshzt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtshrq = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSsftyd1 = new FMS.CXTJ.SFTZFCX.SFTYD.DSsftyd();
            this.BtnSele = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExcel = new Gizmox.WebGUI.Forms.Button();
            this.DtimQsEnd = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtimQsBegin = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.DtimZdBegin = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtimZdEnd = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.Cmbshzt = new Gizmox.WebGUI.Forms.ComboBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.Btnqsjg = new Gizmox.WebGUI.Forms.Button();
            this.Txtqsjg = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.Txtydbh = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.vfmssftydcxTableAdapter1 = new FMS.CXTJ.SFTZFCX.SFTYD.DSsftydTableAdapters.VfmssftydcxTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSsftyd1)).BeginInit();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.AutoGenerateColumns = false;
            dataGridViewCellStyle14.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvTxtbh,
            this.DgvTxtjgid,
            this.DgvTxtdqmc,
            this.DgvTxtqssj,
            this.DgvTxtdsk,
            this.DgvTxtsftje,
            this.DgvTxtzdsj,
            this.DgvTxtshzt,
            this.DgvTxtshrq});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle24.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle24;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 114);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle25.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(920, 336);
            this.Dgv.TabIndex = 1;
            // 
            // DgvTxtbh
            // 
            this.DgvTxtbh.DataPropertyName = "ydbh";
            this.DgvTxtbh.DefaultCellStyle = dataGridViewCellStyle15;
            this.DgvTxtbh.HeaderText = "运单编号";
            this.DgvTxtbh.Name = "DgvTxtbh";
            this.DgvTxtbh.ReadOnly = true;
            this.DgvTxtbh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvTxtjgid
            // 
            this.DgvTxtjgid.DataPropertyName = "jgmc";
            this.DgvTxtjgid.DefaultCellStyle = dataGridViewCellStyle16;
            this.DgvTxtjgid.HeaderText = "签收机构";
            this.DgvTxtjgid.Name = "DgvTxtjgid";
            this.DgvTxtjgid.ReadOnly = true;
            this.DgvTxtjgid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvTxtdqmc
            // 
            this.DgvTxtdqmc.DataPropertyName = "dqmc";
            this.DgvTxtdqmc.DefaultCellStyle = dataGridViewCellStyle17;
            this.DgvTxtdqmc.HeaderText = "签收大区";
            this.DgvTxtdqmc.Name = "DgvTxtdqmc";
            this.DgvTxtdqmc.ReadOnly = true;
            this.DgvTxtdqmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvTxtqssj
            // 
            this.DgvTxtqssj.DataPropertyName = "qssj";
            this.DgvTxtqssj.DefaultCellStyle = dataGridViewCellStyle18;
            this.DgvTxtqssj.HeaderText = "签收时间";
            this.DgvTxtqssj.Name = "DgvTxtqssj";
            this.DgvTxtqssj.ReadOnly = true;
            // 
            // DgvTxtdsk
            // 
            this.DgvTxtdsk.DataPropertyName = "dsk";
            this.DgvTxtdsk.DefaultCellStyle = dataGridViewCellStyle19;
            this.DgvTxtdsk.HeaderText = "代收款金额";
            this.DgvTxtdsk.Name = "DgvTxtdsk";
            this.DgvTxtdsk.ReadOnly = true;
            this.DgvTxtdsk.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvTxtsftje
            // 
            this.DgvTxtsftje.DataPropertyName = "sftje";
            this.DgvTxtsftje.DefaultCellStyle = dataGridViewCellStyle20;
            this.DgvTxtsftje.HeaderText = "善付通金额";
            this.DgvTxtsftje.Name = "DgvTxtsftje";
            this.DgvTxtsftje.ReadOnly = true;
            this.DgvTxtsftje.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvTxtzdsj
            // 
            this.DgvTxtzdsj.DataPropertyName = "zdsj";
            this.DgvTxtzdsj.DefaultCellStyle = dataGridViewCellStyle21;
            this.DgvTxtzdsj.HeaderText = "制单日期";
            this.DgvTxtzdsj.Name = "DgvTxtzdsj";
            this.DgvTxtzdsj.ReadOnly = true;
            this.DgvTxtzdsj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvTxtshzt
            // 
            this.DgvTxtshzt.DataPropertyName = "shzt";
            this.DgvTxtshzt.DefaultCellStyle = dataGridViewCellStyle22;
            this.DgvTxtshzt.HeaderText = "审核状态";
            this.DgvTxtshzt.Name = "DgvTxtshzt";
            this.DgvTxtshzt.ReadOnly = true;
            this.DgvTxtshzt.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvTxtshrq
            // 
            this.DgvTxtshrq.DataPropertyName = "shsj";
            this.DgvTxtshrq.DefaultCellStyle = dataGridViewCellStyle23;
            this.DgvTxtshrq.HeaderText = "审核日期";
            this.DgvTxtshrq.Name = "DgvTxtshrq";
            this.DgvTxtshrq.ReadOnly = true;
            this.DgvTxtshrq.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmssftydcx";
            this.Bds.DataSource = this.DSsftyd1;
            // 
            // DSsftyd1
            // 
            this.DSsftyd1.DataSetName = "DSsftyd";
            this.DSsftyd1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BtnSele
            // 
            this.BtnSele.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSele.CustomStyle = "F";
            this.BtnSele.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSele.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSele.Location = new System.Drawing.Point(34, 80);
            this.BtnSele.Name = "BtnSele";
            this.BtnSele.Size = new System.Drawing.Size(75, 23);
            this.BtnSele.TabIndex = 3;
            this.BtnSele.Text = "查询";
            this.BtnSele.Click += new System.EventHandler(this.BtnSele_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(750, 18);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 5;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnExcel
            // 
            this.BtnExcel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExcel.CustomStyle = "F";
            this.BtnExcel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcel.Location = new System.Drawing.Point(137, 80);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnExcel.TabIndex = 4;
            this.BtnExcel.Text = "导出";
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // DtimQsEnd
            // 
            this.DtimQsEnd.Checked = false;
            this.DtimQsEnd.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtimQsEnd.CustomFormat = "yyyy.MM.dd";
            this.DtimQsEnd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtimQsEnd.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtimQsEnd.Location = new System.Drawing.Point(201, 46);
            this.DtimQsEnd.Name = "DtimQsEnd";
            this.DtimQsEnd.ShowCheckBox = true;
            this.DtimQsEnd.Size = new System.Drawing.Size(101, 21);
            this.DtimQsEnd.TabIndex = 2;
            // 
            // DtimQsBegin
            // 
            this.DtimQsBegin.Checked = false;
            this.DtimQsBegin.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtimQsBegin.CustomFormat = "yyyy.MM.dd";
            this.DtimQsBegin.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtimQsBegin.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtimQsBegin.Location = new System.Drawing.Point(75, 46);
            this.DtimQsBegin.Name = "DtimQsBegin";
            this.DtimQsBegin.ShowCheckBox = true;
            this.DtimQsBegin.Size = new System.Drawing.Size(101, 21);
            this.DtimQsBegin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(180, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "审核日期：";
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.label7);
            this.PnlTop.Controls.Add(this.label6);
            this.PnlTop.Controls.Add(this.DtimZdBegin);
            this.PnlTop.Controls.Add(this.DtimZdEnd);
            this.PnlTop.Controls.Add(this.Cmbshzt);
            this.PnlTop.Controls.Add(this.label5);
            this.PnlTop.Controls.Add(this.Btnqsjg);
            this.PnlTop.Controls.Add(this.Txtqsjg);
            this.PnlTop.Controls.Add(this.label4);
            this.PnlTop.Controls.Add(this.Txtydbh);
            this.PnlTop.Controls.Add(this.label3);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnExcel);
            this.PnlTop.Controls.Add(this.BtnSele);
            this.PnlTop.Controls.Add(this.DtimQsEnd);
            this.PnlTop.Controls.Add(this.DtimQsBegin);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.PnlTop.CustomStyle = "yyyy.MM.dd";
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(920, 114);
            this.PnlTop.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(356, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "制单日期：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(526, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "--";
            // 
            // DtimZdBegin
            // 
            this.DtimZdBegin.Checked = false;
            this.DtimZdBegin.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtimZdBegin.CustomFormat = "yyyy.MM.dd";
            this.DtimZdBegin.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtimZdBegin.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtimZdBegin.Location = new System.Drawing.Point(421, 45);
            this.DtimZdBegin.Name = "DtimZdBegin";
            this.DtimZdBegin.ShowCheckBox = true;
            this.DtimZdBegin.Size = new System.Drawing.Size(101, 21);
            this.DtimZdBegin.TabIndex = 2;
            // 
            // DtimZdEnd
            // 
            this.DtimZdEnd.Checked = false;
            this.DtimZdEnd.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtimZdEnd.CustomFormat = "yyyy.MM.dd";
            this.DtimZdEnd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtimZdEnd.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtimZdEnd.Location = new System.Drawing.Point(547, 45);
            this.DtimZdEnd.Name = "DtimZdEnd";
            this.DtimZdEnd.ShowCheckBox = true;
            this.DtimZdEnd.Size = new System.Drawing.Size(101, 21);
            this.DtimZdEnd.TabIndex = 2;
            // 
            // Cmbshzt
            // 
            this.Cmbshzt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.Cmbshzt.FormattingEnabled = true;
            this.Cmbshzt.Items.AddRange(new object[] {
            "--选择--",
            "已审核",
            "审核通过"});
            this.Cmbshzt.Location = new System.Drawing.Point(527, 17);
            this.Cmbshzt.Name = "Cmbshzt";
            this.Cmbshzt.Size = new System.Drawing.Size(121, 21);
            this.Cmbshzt.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(467, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "审核状态：";
            // 
            // Btnqsjg
            // 
            this.Btnqsjg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Btnqsjg.CustomStyle = "F";
            this.Btnqsjg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.Btnqsjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnqsjg.Location = new System.Drawing.Point(421, 17);
            this.Btnqsjg.Name = "Btnqsjg";
            this.Btnqsjg.Size = new System.Drawing.Size(33, 23);
            this.Btnqsjg.TabIndex = 10;
            this.Btnqsjg.Text = ">>";
            this.Btnqsjg.Click += new System.EventHandler(this.Btnqsjg_Click);
            // 
            // Txtqsjg
            // 
            this.Txtqsjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtqsjg.Location = new System.Drawing.Point(280, 18);
            this.Txtqsjg.Name = "Txtqsjg";
            this.Txtqsjg.ReadOnly = true;
            this.Txtqsjg.Size = new System.Drawing.Size(138, 20);
            this.Txtqsjg.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(218, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "签收日期：";
            // 
            // Txtydbh
            // 
            this.Txtydbh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtydbh.Location = new System.Drawing.Point(74, 18);
            this.Txtydbh.Name = "Txtydbh";
            this.Txtydbh.Size = new System.Drawing.Size(138, 20);
            this.Txtydbh.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "运单编号：";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // vfmssftydcxTableAdapter1
            // 
            this.vfmssftydcxTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmSftYd
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Size = new System.Drawing.Size(920, 450);
            this.Text = "FrmSftYd";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSsftyd1)).EndInit();
            this.PnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView Dgv;
        private BindingSource Bds;
        private Button BtnSele;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExcel;
        private DateTimePicker DtimQsEnd;
        private DateTimePicker DtimQsBegin;
        private Label label2;
        private Label label1;
        private Panel PnlTop;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DSsftyd DSsftyd1;
        private DataGridViewTextBoxColumn DgvTxtbh;
        private DSsftydTableAdapters.VfmssftydcxTableAdapter vfmssftydcxTableAdapter1;
        private DataGridViewTextBoxColumn DgvTxtjgid;
        private DataGridViewTextBoxColumn DgvTxtdqmc;
        private DataGridViewTextBoxColumn DgvTxtqssj;
        private DataGridViewTextBoxColumn DgvTxtdsk;
        private DataGridViewTextBoxColumn DgvTxtsftje;
        private DataGridViewTextBoxColumn DgvTxtzdsj;
        private DataGridViewTextBoxColumn DgvTxtshzt;
        private DataGridViewTextBoxColumn DgvTxtshrq;
        private Label label3;
        private TextBox Txtydbh;
        private Label label4;
        private TextBox Txtqsjg;
        private Button Btnqsjg;
        private Label label5;
        private ComboBox Cmbshzt;
        private Label label7;
        private Label label6;
        private DateTimePicker DtimZdBegin;
        private DateTimePicker DtimZdEnd;


    }
}