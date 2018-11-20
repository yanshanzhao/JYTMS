using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.FBDSKHZ
{
    partial class FrmZBDSKHZXX
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
            this.components = new System.ComponentModel.Container();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnClose = new Gizmox.WebGUI.Forms.Button();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtbh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtfksj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtqsd = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtmdd = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtfhf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtshf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtdsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtsxf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSFBDSKHZ1 = new FMS.DSKGL.FBDSKHZ.DSFBDSKHZ();
            this.Vfmsfbdskhz2TableAdapter1 = new FMS.DSKGL.FBDSKHZ.DSFBDSKHZTableAdapters.Vfmsfbdskhz2TableAdapter();
            this.PnlTop.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSFBDSKHZ1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnExl);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnClose);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(732, 45);
            this.PnlTop.TabIndex = 0;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(110, 9);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 1;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(211, 7);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 1;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnClose.CustomStyle = "F";
            this.BtnClose.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Location = new System.Drawing.Point(9, 9);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 0;
            this.BtnClose.Text = "返回";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 41);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(732, 353);
            this.PnlMain.TabIndex = 1;
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
            this.DgvColTxtbh,
            this.DgvColTxtfksj,
            this.DgvColTxtqsd,
            this.DgvColTxtmdd,
            this.DgvColTxtfhf,
            this.DgvColTxtshf,
            this.DgvColTxtdsk,
            this.DgvColTxtsxf});
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(732, 353);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColTxtbh
            // 
            this.DgvColTxtbh.DataPropertyName = "bh";
            this.DgvColTxtbh.HeaderText = "货运单号";
            this.DgvColTxtbh.Name = "DgvColTxtbh";
            this.DgvColTxtbh.ReadOnly = true;
            this.DgvColTxtbh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtfksj
            // 
            this.DgvColTxtfksj.DataPropertyName = "fksj";
            this.DgvColTxtfksj.HeaderText = "发款日期";
            this.DgvColTxtfksj.Name = "DgvColTxtfksj";
            this.DgvColTxtfksj.ReadOnly = true;
            this.DgvColTxtfksj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtqsd
            // 
            this.DgvColTxtqsd.DataPropertyName = "qsd";
            this.DgvColTxtqsd.HeaderText = "起始地";
            this.DgvColTxtqsd.Name = "DgvColTxtqsd";
            this.DgvColTxtqsd.ReadOnly = true;
            this.DgvColTxtqsd.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtmdd
            // 
            this.DgvColTxtmdd.DataPropertyName = "mdd";
            this.DgvColTxtmdd.HeaderText = "目的地";
            this.DgvColTxtmdd.Name = "DgvColTxtmdd";
            this.DgvColTxtmdd.ReadOnly = true;
            this.DgvColTxtmdd.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtfhf
            // 
            this.DgvColTxtfhf.DataPropertyName = "fhf";
            this.DgvColTxtfhf.FillWeight = 80F;
            this.DgvColTxtfhf.HeaderText = "发货方";
            this.DgvColTxtfhf.Name = "DgvColTxtfhf";
            this.DgvColTxtfhf.ReadOnly = true;
            this.DgvColTxtfhf.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtfhf.Width = 80;
            // 
            // DgvColTxtshf
            // 
            this.DgvColTxtshf.DataPropertyName = "shf";
            this.DgvColTxtshf.FillWeight = 80F;
            this.DgvColTxtshf.HeaderText = "收货方";
            this.DgvColTxtshf.Name = "DgvColTxtshf";
            this.DgvColTxtshf.ReadOnly = true;
            this.DgvColTxtshf.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtshf.Width = 80;
            // 
            // DgvColTxtdsk
            // 
            this.DgvColTxtdsk.DataPropertyName = "dsk";
            this.DgvColTxtdsk.FillWeight = 80F;
            this.DgvColTxtdsk.HeaderText = "代收款";
            this.DgvColTxtdsk.Name = "DgvColTxtdsk";
            this.DgvColTxtdsk.ReadOnly = true;
            this.DgvColTxtdsk.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtdsk.Width = 80;
            // 
            // DgvColTxtsxf
            // 
            this.DgvColTxtsxf.DataPropertyName = "sxf";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtsxf.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtsxf.FillWeight = 80F;
            this.DgvColTxtsxf.HeaderText = "手续费";
            this.DgvColTxtsxf.Name = "DgvColTxtsxf";
            this.DgvColTxtsxf.ReadOnly = true;
            this.DgvColTxtsxf.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtsxf.Width = 80;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsfbdskhz2";
            this.Bds.DataSource = this.DSFBDSKHZ1;
            // 
            // DSFBDSKHZ1
            // 
            this.DSFBDSKHZ1.DataSetName = "DSFBDSKHZ";
            this.DSFBDSKHZ1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Vfmsfbdskhz2TableAdapter1
            // 
            this.Vfmsfbdskhz2TableAdapter1.ClearBeforeFill = true;
            // 
            // FrmZBDSKHZXX
            // 
            this.AcceptButton = this.BtnClose;
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(732, 398);
            this.Text = "总部直接发放金额详细信息";
            this.PnlTop.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSFBDSKHZ1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private Panel PnlMain;
        private Button BtnClose;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtbh;
        private DataGridViewTextBoxColumn DgvColTxtfksj;
        private DataGridViewTextBoxColumn DgvColTxtqsd;
        private DataGridViewTextBoxColumn DgvColTxtmdd;
        private DataGridViewTextBoxColumn DgvColTxtfhf;
        private DataGridViewTextBoxColumn DgvColTxtshf;
        private DataGridViewTextBoxColumn DgvColTxtdsk;
        private DataGridViewTextBoxColumn DgvColTxtsxf;
        private BindingSource Bds;
        private DSFBDSKHZ DSFBDSKHZ1;
        private DSFBDSKHZTableAdapters.Vfmsfbdskhz2TableAdapter Vfmsfbdskhz2TableAdapter1;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;


    }
}