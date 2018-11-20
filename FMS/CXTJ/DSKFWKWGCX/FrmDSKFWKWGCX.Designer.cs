using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.DSKFWKWGCX
    {
    partial class FrmDSKFWKWGCX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtFwkh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtFhrs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColLnkXx = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DataSet1 = new System.Data.DataSet();
            this.DSCX = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.BtnDC = new Gizmox.WebGUI.Forms.Button();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.BtnQuery = new Gizmox.WebGUI.Forms.Button();
            this.TxtRs = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.TxtFwkh = new Gizmox.WebGUI.Forms.TextBox();
            this.Label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.DtpStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.DtpEnd = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.TxtHwmc = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.dataColumn4 = new System.Data.DataColumn();
            this.DgvColTxtHwzl = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSCX)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 411);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Dgv);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(688, 318);
            this.panel3.TabIndex = 1;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
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
            this.DgvColTxtFwkh,
            this.DgvColTxtFhrs,
            this.DgvColTxtHwzl,
            this.DgvColLnkXx});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataMember = "DSCX";
            this.Dgv.DataSource = this.DataSet1;
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
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
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
            this.Dgv.Size = new System.Drawing.Size(688, 318);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // DgvColTxtFwkh
            // 
            this.DgvColTxtFwkh.DataPropertyName = "fwkh";
            this.DgvColTxtFwkh.HeaderText = "服务卡号";
            this.DgvColTxtFwkh.Name = "DgvColTxtFwkh";
            this.DgvColTxtFwkh.ReadOnly = true;
            // 
            // DgvColTxtFhrs
            // 
            this.DgvColTxtFhrs.DataPropertyName = "rs";
            this.DgvColTxtFhrs.HeaderText = "发货人数";
            this.DgvColTxtFhrs.Name = "DgvColTxtFhrs";
            this.DgvColTxtFhrs.ReadOnly = true;
            // 
            // DgvColLnkXx
            // 
            this.DgvColLnkXx.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColLnkXx.ClientMode = false;
            this.DgvColLnkXx.DataPropertyName = "xx";
            this.DgvColLnkXx.HeaderText = "详细";
            this.DgvColLnkXx.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvColLnkXx.LinkColor = System.Drawing.Color.Empty;
            this.DgvColLnkXx.Name = "DgvColLnkXx";
            this.DgvColLnkXx.ReadOnly = true;
            this.DgvColLnkXx.TrackVisitedState = false;
            this.DgvColLnkXx.Url = "";
            this.DgvColLnkXx.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "NewDataSet";
            this.DataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.DSCX});
            // 
            // DSCX
            // 
            this.DSCX.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4});
            this.DSCX.TableName = "DSCX";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "fwkh";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "rs";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "xx";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.TxtHwmc);
            this.panel2.Controls.Add(this.BtnDC);
            this.panel2.Controls.Add(this.BtnExl);
            this.panel2.Controls.Add(this.ctrlDownLoad1);
            this.panel2.Controls.Add(this.BtnQuery);
            this.panel2.Controls.Add(this.TxtRs);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.TxtFwkh);
            this.panel2.Controls.Add(this.Label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.DtpStart);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.DtpEnd);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(688, 93);
            this.panel2.TabIndex = 0;
            // 
            // BtnDC
            // 
            this.BtnDC.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDC.CustomStyle = "F";
            this.BtnDC.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDC.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDC.Location = new System.Drawing.Point(101, 61);
            this.BtnDC.Name = "BtnDC";
            this.BtnDC.Size = new System.Drawing.Size(75, 23);
            this.BtnDC.TabIndex = 6;
            this.BtnDC.Text = "导出";
            this.BtnDC.Click += new System.EventHandler(this.BtnDC_Click);
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(185, 61);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 6;
            this.BtnExl.Text = "导出明细";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // BtnQuery
            // 
            this.BtnQuery.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnQuery.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnQuery.CustomStyle = "F";
            this.BtnQuery.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuery.Location = new System.Drawing.Point(16, 61);
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Size = new System.Drawing.Size(75, 23);
            this.BtnQuery.TabIndex = 4;
            this.BtnQuery.Text = "查询";
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // TxtRs
            // 
            this.TxtRs.AllowDrag = false;
            this.TxtRs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRs.Location = new System.Drawing.Point(99, 37);
            this.TxtRs.Name = "TxtRs";
            this.TxtRs.Size = new System.Drawing.Size(127, 21);
            this.TxtRs.TabIndex = 0;
            this.TxtRs.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "发货人数≥";
            // 
            // TxtFwkh
            // 
            this.TxtFwkh.AllowDrag = false;
            this.TxtFwkh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFwkh.Location = new System.Drawing.Point(99, 9);
            this.TxtFwkh.Name = "TxtFwkh";
            this.TxtFwkh.Size = new System.Drawing.Size(127, 21);
            this.TxtFwkh.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(16, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(35, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "服务卡号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(243, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "受理日期";
            // 
            // DtpStart
            // 
            this.DtpStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpStart.CustomFormat = "yyyy.MM.dd";
            this.DtpStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpStart.Location = new System.Drawing.Point(305, 8);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(123, 20);
            this.DtpStart.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(435, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "一";
            // 
            // DtpEnd
            // 
            this.DtpEnd.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpEnd.CustomFormat = "yyyy.MM.dd";
            this.DtpEnd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpEnd.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpEnd.Location = new System.Drawing.Point(455, 8);
            this.DtpEnd.Name = "DtpEnd";
            this.DtpEnd.Size = new System.Drawing.Size(123, 20);
            this.DtpEnd.TabIndex = 3;
            // 
            // TxtHwmc
            // 
            this.TxtHwmc.AllowDrag = false;
            this.TxtHwmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHwmc.Location = new System.Drawing.Point(329, 37);
            this.TxtHwmc.Name = "TxtHwmc";
            this.TxtHwmc.Size = new System.Drawing.Size(127, 21);
            this.TxtHwmc.TabIndex = 0;
            this.TxtHwmc.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(237, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "货物名称数量≥";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "hwzl";
            // 
            // DgvColTxtHwzl
            // 
            this.DgvColTxtHwzl.DataPropertyName = "hwzl";
            this.DgvColTxtHwzl.HeaderText = "货物名称数量";
            this.DgvColTxtHwzl.Name = "DgvColTxtHwzl";
            this.DgvColTxtHwzl.ReadOnly = true;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(595, 4);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 5;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // FrmDSKFWKWGCX
            // 
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(688, 411);
            this.Text = "FrmDSKFWKWGCX";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSCX)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Label label2;
        private DateTimePicker DtpStart;
        private Label label3;
        private DateTimePicker DtpEnd;
        private TextBox TxtFwkh;
        private Label Label1;
        private TextBox TxtRs;
        private Label label4;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtFwkh;
        private DataGridViewTextBoxColumn DgvColTxtFhrs;
        private Button BtnQuery;
        private System.Data.DataSet DataSet1;
        private System.Data.DataTable DSCX;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private DataGridViewLinkColumn DgvColLnkXx;
        private System.Data.DataColumn dataColumn3;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnDC;
        private Label label5;
        private TextBox TxtHwmc;
        private DataGridViewTextBoxColumn DgvColTxtHwzl;
        private System.Data.DataColumn dataColumn4;


        }
    }