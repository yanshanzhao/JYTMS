using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKQSCX
{
    partial class Frmdskqscx
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.pnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnDC = new Gizmox.WebGUI.Forms.Button();
            this.btncx = new Gizmox.WebGUI.Forms.Button();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.DtpEnd = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.Dtpstar = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.Pnlfill = new Gizmox.WebGUI.Forms.Panel();
            this.dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvCloTxtdqmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvCloTxtzps = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvCloTxtzyf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvCloTxtdskps = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvCloTxtdskf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvCloTxtpsbl = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvCloTxtjebl = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dgvColTetid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            this.Pnlfill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.ctrlDownLoad1);
            this.pnlTop.Controls.Add(this.BtnDC);
            this.pnlTop.Controls.Add(this.btncx);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.DtpEnd);
            this.pnlTop.Controls.Add(this.Dtpstar);
            this.pnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(829, 76);
            this.pnlTop.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(662, 32);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 3;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnDC
            // 
            this.BtnDC.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDC.CustomStyle = "F";
            this.BtnDC.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDC.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDC.Location = new System.Drawing.Point(454, 34);
            this.BtnDC.Name = "BtnDC";
            this.BtnDC.Size = new System.Drawing.Size(75, 23);
            this.BtnDC.TabIndex = 2;
            this.BtnDC.Text = "导出";
            this.BtnDC.Click += new System.EventHandler(this.BtnDC_Click);
            // 
            // btncx
            // 
            this.btncx.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.btncx.CustomStyle = "F";
            this.btncx.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btncx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncx.Location = new System.Drawing.Point(365, 34);
            this.btncx.Name = "btncx";
            this.btncx.Size = new System.Drawing.Size(75, 23);
            this.btncx.TabIndex = 2;
            this.btncx.Text = "查询";
            this.btncx.Click += new System.EventHandler(this.btncx_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(212, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "受理日期:";
            // 
            // DtpEnd
            // 
            this.DtpEnd.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpEnd.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtpEnd.CustomFormat = "";
            this.DtpEnd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpEnd.Location = new System.Drawing.Point(228, 36);
            this.DtpEnd.Name = "DtpEnd";
            this.DtpEnd.Size = new System.Drawing.Size(123, 21);
            this.DtpEnd.TabIndex = 0;
            // 
            // Dtpstar
            // 
            this.Dtpstar.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.Dtpstar.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dtpstar.CustomFormat = "";
            this.Dtpstar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtpstar.Location = new System.Drawing.Point(83, 37);
            this.Dtpstar.Name = "Dtpstar";
            this.Dtpstar.Size = new System.Drawing.Size(123, 21);
            this.Dtpstar.TabIndex = 0;
            // 
            // Pnlfill
            // 
            this.Pnlfill.Controls.Add(this.dgv);
            this.Pnlfill.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Pnlfill.Location = new System.Drawing.Point(0, 76);
            this.Pnlfill.Name = "Pnlfill";
            this.Pnlfill.Size = new System.Drawing.Size(829, 433);
            this.Pnlfill.TabIndex = 1;
            // 
            // dgv
            // 
            this.dgv.AllowDrag = false;
            this.dgv.AllowDragTargetsPropagation = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvCloTxtdqmc,
            this.DgvCloTxtzps,
            this.DgvCloTxtzyf,
            this.DgvCloTxtdskps,
            this.DgvCloTxtdskf,
            this.DgvCloTxtpsbl,
            this.DgvCloTxtjebl,
            this.dgvColTetid});
            this.dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.dgv.DataMember = "Dskqs";
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.Yes;
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv.RowHeadersWidth = 10;
            this.dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(829, 433);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellDoubleClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // DgvCloTxtdqmc
            // 
            this.DgvCloTxtdqmc.DataPropertyName = "dqmc";
            this.DgvCloTxtdqmc.HeaderText = "大区名称";
            this.DgvCloTxtdqmc.Name = "DgvCloTxtdqmc";
            this.DgvCloTxtdqmc.ReadOnly = true;
            // 
            // DgvCloTxtzps
            // 
            this.DgvCloTxtzps.DataPropertyName = "zps";
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvCloTxtzps.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvCloTxtzps.HeaderText = "受理零担运单总票数";
            this.DgvCloTxtzps.Name = "DgvCloTxtzps";
            this.DgvCloTxtzps.ReadOnly = true;
            this.DgvCloTxtzps.Width = 140;
            // 
            // DgvCloTxtzyf
            // 
            this.DgvCloTxtzyf.DataPropertyName = "zyf";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvCloTxtzyf.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvCloTxtzyf.HeaderText = "受理零担运费金额";
            this.DgvCloTxtzyf.Name = "DgvCloTxtzyf";
            this.DgvCloTxtzyf.ReadOnly = true;
            this.DgvCloTxtzyf.Width = 130;
            // 
            // DgvCloTxtdskps
            // 
            this.DgvCloTxtdskps.DataPropertyName = "dskps";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvCloTxtdskps.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvCloTxtdskps.HeaderText = "受理代收款票数";
            this.DgvCloTxtdskps.Name = "DgvCloTxtdskps";
            this.DgvCloTxtdskps.ReadOnly = true;
            this.DgvCloTxtdskps.Width = 120;
            // 
            // DgvCloTxtdskf
            // 
            this.DgvCloTxtdskf.DataPropertyName = "dskf";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvCloTxtdskf.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvCloTxtdskf.HeaderText = "受理代收款金额";
            this.DgvCloTxtdskf.Name = "DgvCloTxtdskf";
            this.DgvCloTxtdskf.ReadOnly = true;
            this.DgvCloTxtdskf.Width = 120;
            // 
            // DgvCloTxtpsbl
            // 
            this.DgvCloTxtpsbl.DataPropertyName = "psbl";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvCloTxtpsbl.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvCloTxtpsbl.HeaderText = "票数比例";
            this.DgvCloTxtpsbl.Name = "DgvCloTxtpsbl";
            this.DgvCloTxtpsbl.ReadOnly = true;
            // 
            // DgvCloTxtjebl
            // 
            this.DgvCloTxtjebl.DataPropertyName = "jebl";
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvCloTxtjebl.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvCloTxtjebl.HeaderText = "金额比例";
            this.DgvCloTxtjebl.Name = "DgvCloTxtjebl";
            this.DgvCloTxtjebl.ReadOnly = true;
            // 
            // dgvColTetid
            // 
            this.dgvColTetid.DataPropertyName = "dqid";
            this.dgvColTetid.Name = "dgvColTetid";
            this.dgvColTetid.ReadOnly = true;
            this.dgvColTetid.Visible = false;
            // 
            // Frmdskqscx
            // 
            this.Controls.Add(this.Pnlfill);
            this.Controls.Add(this.pnlTop);
            this.Size = new System.Drawing.Size(829, 509);
            this.Text = "Frmdskqscx";
            this.pnlTop.ResumeLayout(false);
            this.Pnlfill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlTop;
        private Label label2;
        private Label label1;
        private DateTimePicker DtpEnd;
        private DateTimePicker Dtpstar;
        private Panel Pnlfill;
        private DataGridView dgv;
        private DataGridViewTextBoxColumn DgvCloTxtzps;
        private DataGridViewTextBoxColumn DgvCloTxtzyf;
        private DataGridViewTextBoxColumn DgvCloTxtdskps;
        private DataGridViewTextBoxColumn DgvCloTxtdskf;
        private DataGridViewTextBoxColumn DgvCloTxtpsbl;
        private DataGridViewTextBoxColumn DgvCloTxtjebl;
        private Button btncx;
        private DataGridViewTextBoxColumn DgvCloTxtdqmc;
        private DataGridViewTextBoxColumn dgvColTetid;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnDC;


    }
}