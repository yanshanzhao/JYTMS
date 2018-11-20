using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.WFKDSKCX
    {
    partial class FrmYDWFKDSK
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.BtnEls1 = new Gizmox.WebGUI.Forms.Button();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.LblJgmc = new Gizmox.WebGUI.Forms.Label();
            this.LblZj = new Gizmox.WebGUI.Forms.Label();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtdqmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxthydh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtsljg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtslsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtqsd = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtmdd = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtqsjg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtfhf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtsfh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtddsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtyqts = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtdsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtFkfs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSjzt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSjsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSWFKDSKCX1 = new FMS.CXTJ.WFKDSKCX.DSWFKDSKCX();
            this.VfmswfkdskcxTableAdapter1 = new FMS.CXTJ.WFKDSKCX.DSWFKDSKCXTableAdapters.VfmswfkdskcxTableAdapter();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSWFKDSKCX1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnEls1);
            this.PnlTop.Controls.Add(this.BtnExl);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.LblJgmc);
            this.PnlTop.Controls.Add(this.LblZj);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(940, 44);
            this.PnlTop.TabIndex = 0;
            // 
            // BtnEls1
            // 
            this.BtnEls1.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnEls1.CustomStyle = "F";
            this.BtnEls1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnEls1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEls1.Location = new System.Drawing.Point(701, 9);
            this.BtnEls1.Name = "BtnEls1";
            this.BtnEls1.Size = new System.Drawing.Size(75, 23);
            this.BtnEls1.TabIndex = 4;
            this.BtnEls1.Text = "导出";
            this.BtnEls1.Visible = false;
            this.BtnEls1.Click += new System.EventHandler(this.BtnEls1_Click);
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(453, 9);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 3;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(555, 9);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 2;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // LblJgmc
            // 
            this.LblJgmc.AutoSize = true;
            this.LblJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJgmc.Location = new System.Drawing.Point(15, 15);
            this.LblJgmc.Name = "LblJgmc";
            this.LblJgmc.Size = new System.Drawing.Size(35, 13);
            this.LblJgmc.TabIndex = 0;
            this.LblJgmc.Text = "连锁店名称";
            // 
            // LblZj
            // 
            this.LblZj.AutoSize = true;
            this.LblZj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZj.Location = new System.Drawing.Point(268, 15);
            this.LblZj.Name = "LblZj";
            this.LblZj.Size = new System.Drawing.Size(35, 13);
            this.LblZj.TabIndex = 1;
            this.LblZj.Text = "金额";
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
            this.DgvColTxtdqmc,
            this.DgvColTxthydh,
            this.DgvColTxtsljg,
            this.DgvColTxtslsj,
            this.DgvColTxtqsd,
            this.DgvColTxtmdd,
            this.DgvColTxtqsjg,
            this.DgvColTxtfhf,
            this.DgvColTxtsfh,
            this.DgvColTxtddsj,
            this.DgvColTxtyqts,
            this.DgvColTxtlx,
            this.DgvColTxtdsk,
            this.DgvColTxtFkfs,
            this.DgvColTxtSjzt,
            this.DgvColTxtSjsj});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 44);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv.RowHeadersWidth = 10;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(940, 518);
            this.Dgv.TabIndex = 1;
            // 
            // DgvColTxtdqmc
            // 
            this.DgvColTxtdqmc.DataPropertyName = "dqmc";
            this.DgvColTxtdqmc.HeaderText = "所属大区";
            this.DgvColTxtdqmc.Name = "DgvColTxtdqmc";
            this.DgvColTxtdqmc.ReadOnly = true;
            this.DgvColTxtdqmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxthydh
            // 
            this.DgvColTxthydh.DataPropertyName = "bh";
            this.DgvColTxthydh.HeaderText = "货运单号";
            this.DgvColTxthydh.Name = "DgvColTxthydh";
            this.DgvColTxthydh.ReadOnly = true;
            this.DgvColTxthydh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtsljg
            // 
            this.DgvColTxtsljg.DataPropertyName = "sljgmc";
            this.DgvColTxtsljg.HeaderText = "受理机构";
            this.DgvColTxtsljg.Name = "DgvColTxtsljg";
            this.DgvColTxtsljg.ReadOnly = true;
            this.DgvColTxtsljg.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtslsj
            // 
            this.DgvColTxtslsj.DataPropertyName = "slsj";
            this.DgvColTxtslsj.HeaderText = "受理时间";
            this.DgvColTxtslsj.Name = "DgvColTxtslsj";
            this.DgvColTxtslsj.ReadOnly = true;
            this.DgvColTxtslsj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // DgvColTxtqsjg
            // 
            this.DgvColTxtqsjg.DataPropertyName = "qsjgmc";
            this.DgvColTxtqsjg.HeaderText = "签收机构";
            this.DgvColTxtqsjg.Name = "DgvColTxtqsjg";
            this.DgvColTxtqsjg.ReadOnly = true;
            this.DgvColTxtqsjg.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtfhf
            // 
            this.DgvColTxtfhf.DataPropertyName = "fhf";
            this.DgvColTxtfhf.HeaderText = "发货方";
            this.DgvColTxtfhf.Name = "DgvColTxtfhf";
            this.DgvColTxtfhf.ReadOnly = true;
            this.DgvColTxtfhf.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtsfh
            // 
            this.DgvColTxtsfh.DataPropertyName = "shlxr";
            this.DgvColTxtsfh.HeaderText = "收货方";
            this.DgvColTxtsfh.Name = "DgvColTxtsfh";
            this.DgvColTxtsfh.ReadOnly = true;
            this.DgvColTxtsfh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtddsj
            // 
            this.DgvColTxtddsj.DataPropertyName = "ddsj";
            this.DgvColTxtddsj.HeaderText = "签收时间";
            this.DgvColTxtddsj.Name = "DgvColTxtddsj";
            this.DgvColTxtddsj.ReadOnly = true;
            this.DgvColTxtddsj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtyqts
            // 
            this.DgvColTxtyqts.DataPropertyName = "yqts";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtyqts.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtyqts.HeaderText = "逾期天数";
            this.DgvColTxtyqts.Name = "DgvColTxtyqts";
            this.DgvColTxtyqts.ReadOnly = true;
            this.DgvColTxtyqts.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtlx
            // 
            this.DgvColTxtlx.DataPropertyName = "lx";
            this.DgvColTxtlx.HeaderText = "类别";
            this.DgvColTxtlx.Name = "DgvColTxtlx";
            this.DgvColTxtlx.ReadOnly = true;
            this.DgvColTxtlx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtdsk
            // 
            this.DgvColTxtdsk.DataPropertyName = "dsk";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtdsk.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtdsk.HeaderText = "代收款";
            this.DgvColTxtdsk.Name = "DgvColTxtdsk";
            this.DgvColTxtdsk.ReadOnly = true;
            this.DgvColTxtdsk.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtFkfs
            // 
            this.DgvColTxtFkfs.DataPropertyName = "fkfs";
            this.DgvColTxtFkfs.HeaderText = "付款方式";
            this.DgvColTxtFkfs.Name = "DgvColTxtFkfs";
            this.DgvColTxtFkfs.ReadOnly = true;
            this.DgvColTxtFkfs.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtSjzt
            // 
            this.DgvColTxtSjzt.DataPropertyName = "sjzt";
            this.DgvColTxtSjzt.HeaderText = "上缴状态";
            this.DgvColTxtSjzt.Name = "DgvColTxtSjzt";
            this.DgvColTxtSjzt.ReadOnly = true;
            this.DgvColTxtSjzt.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtSjsj
            // 
            this.DgvColTxtSjsj.DataPropertyName = "sjsj";
            this.DgvColTxtSjsj.HeaderText = "上缴时间";
            this.DgvColTxtSjsj.Name = "DgvColTxtSjsj";
            this.DgvColTxtSjsj.ReadOnly = true;
            this.DgvColTxtSjsj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmswfkdskcx";
            this.Bds.DataSource = this.DSWFKDSKCX1;
            // 
            // DSWFKDSKCX1
            // 
            this.DSWFKDSKCX1.DataSetName = "DSWFKDSKCX";
            this.DSWFKDSKCX1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmswfkdskcxTableAdapter1
            // 
            this.VfmswfkdskcxTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmYDWFKDSK
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(940, 562);
            this.Text = "机构未返款代收信息";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSWFKDSKCX1)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion

        private Panel PnlTop;
        private Label LblJgmc;
        private Label LblZj;
        private DataGridView Dgv;
        //private DataGridViewTextBoxColumn DgvColTxtssdq;
        //private DataGridViewTextBoxColumn DgvColTxtBh;
        //private DataGridViewTextBoxColumn DgvColTxtsljg;
        //private DataGridViewTextBoxColumn DgvColTxtslsj;
        //private DataGridViewTextBoxColumn DgvColTxtqsd;
        //private DataGridViewTextBoxColumn DgvColTxtmdd;
        //private DataGridViewTextBoxColumn DgvColTxtqsjg;
        //private DataGridViewTextBoxColumn DgvColTxtfhf;
        //private DataGridViewTextBoxColumn DgvColTxtshf;
        //private DataGridViewTextBoxColumn DgvColTxtddsj;
        //private DataGridViewTextBoxColumn DgvColTxtyqts;
        //private DataGridViewTextBoxColumn DgvColTxtlb;
        //private DataGridViewTextBoxColumn DgvColTxtdsk;
        private BindingSource Bds;
        private DSWFKDSKCX DSWFKDSKCX1;
        private DSWFKDSKCXTableAdapters.VfmswfkdskcxTableAdapter VfmswfkdskcxTableAdapter1;
        private DataGridViewTextBoxColumn DgvColTxtdqmc;
        private DataGridViewTextBoxColumn DgvColTxthydh;
        private DataGridViewTextBoxColumn DgvColTxtsljg;
        private DataGridViewTextBoxColumn DgvColTxtslsj;
        private DataGridViewTextBoxColumn DgvColTxtqsd;
        private DataGridViewTextBoxColumn DgvColTxtmdd;
        private DataGridViewTextBoxColumn DgvColTxtqsjg;
        private DataGridViewTextBoxColumn DgvColTxtfhf;
        private DataGridViewTextBoxColumn DgvColTxtsfh;
        private DataGridViewTextBoxColumn DgvColTxtddsj;
        private DataGridViewTextBoxColumn DgvColTxtyqts;
        private DataGridViewTextBoxColumn DgvColTxtlx;
        private DataGridViewTextBoxColumn DgvColTxtdsk;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnEls1;
        private DataGridViewTextBoxColumn DgvColTxtFkfs;
        private DataGridViewTextBoxColumn DgvColTxtSjzt;
        private DataGridViewTextBoxColumn DgvColTxtSjsj;


        }
    }
