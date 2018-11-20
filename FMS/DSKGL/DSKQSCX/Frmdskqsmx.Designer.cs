using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKQSCX
{
    partial class Frmdskqsmx
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.Pnltop = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.Btndc = new Gizmox.WebGUI.Forms.Button();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.dtpend = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.Dtpstar = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtjgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzps = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzyf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtdskps = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtdskf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtpsbl = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtjebl = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Pnltop.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnltop
            // 
            this.Pnltop.Controls.Add(this.ctrlDownLoad1);
            this.Pnltop.Controls.Add(this.Btndc);
            this.Pnltop.Controls.Add(this.label2);
            this.Pnltop.Controls.Add(this.label1);
            this.Pnltop.Controls.Add(this.dtpend);
            this.Pnltop.Controls.Add(this.Dtpstar);
            this.Pnltop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.Pnltop.Location = new System.Drawing.Point(0, 0);
            this.Pnltop.Name = "Pnltop";
            this.Pnltop.Size = new System.Drawing.Size(1005, 94);
            this.Pnltop.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(814, 36);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 4;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // Btndc
            // 
            this.Btndc.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Btndc.CustomStyle = "F";
            this.Btndc.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.Btndc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btndc.Location = new System.Drawing.Point(418, 36);
            this.Btndc.Name = "Btndc";
            this.Btndc.Size = new System.Drawing.Size(75, 23);
            this.Btndc.TabIndex = 3;
            this.Btndc.Text = "导出";
            this.Btndc.Click += new System.EventHandler(this.Btndc_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(252, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "受理日期：";
            // 
            // dtpend
            // 
            this.dtpend.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtpend.CustomFormat = "";
            this.dtpend.Enabled = false;
            this.dtpend.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpend.Location = new System.Drawing.Point(275, 37);
            this.dtpend.Name = "dtpend";
            this.dtpend.Size = new System.Drawing.Size(128, 21);
            this.dtpend.TabIndex = 1;
            // 
            // Dtpstar
            // 
            this.Dtpstar.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.Dtpstar.CustomFormat = "";
            this.Dtpstar.Enabled = false;
            this.Dtpstar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtpstar.Location = new System.Drawing.Point(113, 37);
            this.Dtpstar.Name = "Dtpstar";
            this.Dtpstar.Size = new System.Drawing.Size(124, 21);
            this.Dtpstar.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Dgv);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1005, 485);
            this.panel2.TabIndex = 1;
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
            this.Dgv.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle10.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.DgvColTxtjgmc,
            this.DgvColTxtzps,
            this.DgvColTxtzyf,
            this.DgvColTxtdskps,
            this.DgvColTxtdskf,
            this.DgvColTxtpsbl,
            this.DgvColTxtjebl});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            dataGridViewCellStyle17.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle17;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(1005, 485);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColTxtjgmc
            // 
            this.DgvColTxtjgmc.DataPropertyName = "jgmc";
            this.DgvColTxtjgmc.HeaderText = "机构名称";
            this.DgvColTxtjgmc.Name = "DgvColTxtjgmc";
            this.DgvColTxtjgmc.ReadOnly = true;
            this.DgvColTxtjgmc.Width = 160;
            // 
            // DgvColTxtzps
            // 
            this.DgvColTxtzps.DataPropertyName = "zps";
            dataGridViewCellStyle11.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtzps.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvColTxtzps.HeaderText = "受理零担运单总票数";
            this.DgvColTxtzps.Name = "DgvColTxtzps";
            this.DgvColTxtzps.ReadOnly = true;
            this.DgvColTxtzps.Width = 160;
            // 
            // DgvColTxtzyf
            // 
            this.DgvColTxtzyf.DataPropertyName = "zyf";
            dataGridViewCellStyle12.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtzyf.DefaultCellStyle = dataGridViewCellStyle12;
            this.DgvColTxtzyf.HeaderText = "受理零担运费金额";
            this.DgvColTxtzyf.Name = "DgvColTxtzyf";
            this.DgvColTxtzyf.ReadOnly = true;
            this.DgvColTxtzyf.Width = 130;
            // 
            // DgvColTxtdskps
            // 
            this.DgvColTxtdskps.DataPropertyName = "dskps";
            dataGridViewCellStyle13.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtdskps.DefaultCellStyle = dataGridViewCellStyle13;
            this.DgvColTxtdskps.HeaderText = "受理代收款票数";
            this.DgvColTxtdskps.Name = "DgvColTxtdskps";
            this.DgvColTxtdskps.ReadOnly = true;
            this.DgvColTxtdskps.Width = 130;
            // 
            // DgvColTxtdskf
            // 
            this.DgvColTxtdskf.DataPropertyName = "dskf";
            dataGridViewCellStyle14.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtdskf.DefaultCellStyle = dataGridViewCellStyle14;
            this.DgvColTxtdskf.HeaderText = "受理代收款金额";
            this.DgvColTxtdskf.Name = "DgvColTxtdskf";
            this.DgvColTxtdskf.ReadOnly = true;
            this.DgvColTxtdskf.Width = 120;
            // 
            // DgvColTxtpsbl
            // 
            this.DgvColTxtpsbl.DataPropertyName = "psbl";
            dataGridViewCellStyle15.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtpsbl.DefaultCellStyle = dataGridViewCellStyle15;
            this.DgvColTxtpsbl.HeaderText = "票数比例";
            this.DgvColTxtpsbl.Name = "DgvColTxtpsbl";
            this.DgvColTxtpsbl.ReadOnly = true;
            // 
            // DgvColTxtjebl
            // 
            this.DgvColTxtjebl.DataPropertyName = "jebl";
            dataGridViewCellStyle16.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjebl.DefaultCellStyle = dataGridViewCellStyle16;
            this.DgvColTxtjebl.HeaderText = "金额比例";
            this.DgvColTxtjebl.Name = "DgvColTxtjebl";
            this.DgvColTxtjebl.ReadOnly = true;
            // 
            // Frmdskqsmx
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Pnltop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(1005, 579);
            this.Text = "代收款收入趋势明细";
            this.Pnltop.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel Pnltop;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpend;
        private DateTimePicker Dtpstar;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtjgmc;
        private DataGridViewTextBoxColumn DgvColTxtzps;
        private DataGridViewTextBoxColumn DgvColTxtzyf;
        private DataGridViewTextBoxColumn DgvColTxtdskps;
        private DataGridViewTextBoxColumn DgvColTxtdskf;
        private DataGridViewTextBoxColumn DgvColTxtpsbl;
        private DataGridViewTextBoxColumn DgvColTxtjebl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button Btndc;


    }
}