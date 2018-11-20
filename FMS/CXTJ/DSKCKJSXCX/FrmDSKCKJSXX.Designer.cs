using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.DSKCKJSXCX
{
    partial class FrmDSKCKJSXX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtyqsdskps = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtyqsdskje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtjsps = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtjsdsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtpspfb = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtjebfb = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtjgid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.Pnltop = new Gizmox.WebGUI.Forms.Panel();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.Pnltop.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 38);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(746, 447);
            this.PnlMain.TabIndex = 1;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowDragTargetsPropagation = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.AutoGenerateColumns = false;
            this.Dgv.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
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
            this.DgvColTxtmc,
            this.DgvColTxtyqsdskps,
            this.DgvColTxtyqsdskje,
            this.DgvColTxtjsps,
            this.DgvColTxtjsdsk,
            this.DgvColTxtpspfb,
            this.DgvColTxtjebfb,
            this.DgvColTxtjgid});
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
            this.Dgv.ReadOnly = true;
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
            this.Dgv.Size = new System.Drawing.Size(746, 447);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellDoubleClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellDoubleClick);
            // 
            // DgvColTxtmc
            // 
            this.DgvColTxtmc.DataPropertyName = "jgmc";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtmc.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtmc.FillWeight = 140F;
            this.DgvColTxtmc.HeaderText = "机构";
            this.DgvColTxtmc.Name = "DgvColTxtmc";
            this.DgvColTxtmc.ReadOnly = true;
            this.DgvColTxtmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtmc.Width = 140;
            // 
            // DgvColTxtyqsdskps
            // 
            this.DgvColTxtyqsdskps.DataPropertyName = "qsps";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtyqsdskps.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtyqsdskps.HeaderText = "已签收代收款票数";
            this.DgvColTxtyqsdskps.Name = "DgvColTxtyqsdskps";
            this.DgvColTxtyqsdskps.ReadOnly = true;
            // 
            // DgvColTxtyqsdskje
            // 
            this.DgvColTxtyqsdskje.DataPropertyName = "qsdsk";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtyqsdskje.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColTxtyqsdskje.HeaderText = "已签收代收款金额";
            this.DgvColTxtyqsdskje.Name = "DgvColTxtyqsdskje";
            this.DgvColTxtyqsdskje.ReadOnly = true;
            this.DgvColTxtyqsdskje.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtjsps
            // 
            this.DgvColTxtjsps.DataPropertyName = "jsps";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjsps.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvColTxtjsps.HeaderText = "及时的代收款票数";
            this.DgvColTxtjsps.Name = "DgvColTxtjsps";
            this.DgvColTxtjsps.ReadOnly = true;
            this.DgvColTxtjsps.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtjsdsk
            // 
            this.DgvColTxtjsdsk.DataPropertyName = "jsdsk";
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjsdsk.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvColTxtjsdsk.HeaderText = "及时的代收款金额";
            this.DgvColTxtjsdsk.Name = "DgvColTxtjsdsk";
            this.DgvColTxtjsdsk.ReadOnly = true;
            this.DgvColTxtjsdsk.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtpspfb
            // 
            this.DgvColTxtpspfb.DataPropertyName = "psbfb";
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtpspfb.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvColTxtpspfb.HeaderText = "票数的及时率";
            this.DgvColTxtpspfb.Name = "DgvColTxtpspfb";
            this.DgvColTxtpspfb.ReadOnly = true;
            this.DgvColTxtpspfb.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtjebfb
            // 
            this.DgvColTxtjebfb.DataPropertyName = "dskbfb";
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjebfb.DefaultCellStyle = dataGridViewCellStyle9;
            this.DgvColTxtjebfb.HeaderText = "金额的及时率";
            this.DgvColTxtjebfb.Name = "DgvColTxtjebfb";
            this.DgvColTxtjebfb.ReadOnly = true;
            this.DgvColTxtjebfb.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtjgid
            // 
            this.DgvColTxtjgid.DataPropertyName = "jgid";
            dataGridViewCellStyle10.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjgid.DefaultCellStyle = dataGridViewCellStyle10;
            this.DgvColTxtjgid.HeaderText = "jgid";
            this.DgvColTxtjgid.Name = "DgvColTxtjgid";
            this.DgvColTxtjgid.ReadOnly = true;
            this.DgvColTxtjgid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjgid.Visible = false;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(9, 9);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 6;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(104, 7);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 5;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // Pnltop
            // 
            this.Pnltop.Controls.Add(this.BtnExl);
            this.Pnltop.Controls.Add(this.ctrlDownLoad1);
            this.Pnltop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.Pnltop.Location = new System.Drawing.Point(0, 0);
            this.Pnltop.Name = "Pnltop";
            this.Pnltop.Size = new System.Drawing.Size(746, 38);
            this.Pnltop.TabIndex = 0;
            // 
            // FrmDSKCKJSXX
            // 
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.Pnltop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(746, 485);
            this.Text = "代收款存款及时性信息";
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.Pnltop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlMain;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Panel Pnltop;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtmc;
        private DataGridViewTextBoxColumn DgvColTxtyqsdskps;
        private DataGridViewTextBoxColumn DgvColTxtyqsdskje;
        private DataGridViewTextBoxColumn DgvColTxtjsps;
        private DataGridViewTextBoxColumn DgvColTxtjsdsk;
        private DataGridViewTextBoxColumn DgvColTxtpspfb;
        private DataGridViewTextBoxColumn DgvColTxtjebfb;
        private DataGridViewTextBoxColumn DgvColTxtjgid;


    }
}