using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.YBFJSXCX
    {
    partial class FrmYBFCKJSXMX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.dqmcDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.jgmcDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.bhDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ybfjeDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.yctsDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.inssjDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.shsjDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSYBF = new FMS.CWGL.YBFJSXCX.DSYBF();
            this.VybfjsxcxTableAdapter = new FMS.CWGL.YBFJSXCX.DSYBFTableAdapters.VybfjsxcxTableAdapter();
            this.PnlTop.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSYBF)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnExl);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(997, 54);
            this.PnlTop.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(141, 14);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 7;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnExl
            // 
            this.BtnExl.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(18, 14);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 0;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 54);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(997, 412);
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
            this.Dgv.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dqmcDataGridViewTextBoxColumn,
            this.jgmcDataGridViewTextBoxColumn,
            this.bhDataGridViewTextBoxColumn,
            this.ybfjeDataGridViewTextBoxColumn,
            this.yctsDataGridViewTextBoxColumn,
            this.inssjDataGridViewTextBoxColumn,
            this.shsjDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1});
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
            this.Dgv.Location = new System.Drawing.Point(0, 0);
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
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(997, 412);
            this.Dgv.TabIndex = 0;
            // 
            // dqmcDataGridViewTextBoxColumn
            // 
            this.dqmcDataGridViewTextBoxColumn.DataPropertyName = "dqmc";
            this.dqmcDataGridViewTextBoxColumn.HeaderText = "大区名称";
            this.dqmcDataGridViewTextBoxColumn.Name = "dqmcDataGridViewTextBoxColumn";
            this.dqmcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // jgmcDataGridViewTextBoxColumn
            // 
            this.jgmcDataGridViewTextBoxColumn.DataPropertyName = "jgmc";
            this.jgmcDataGridViewTextBoxColumn.HeaderText = "机构名称";
            this.jgmcDataGridViewTextBoxColumn.Name = "jgmcDataGridViewTextBoxColumn";
            this.jgmcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bhDataGridViewTextBoxColumn
            // 
            this.bhDataGridViewTextBoxColumn.DataPropertyName = "bh";
            this.bhDataGridViewTextBoxColumn.HeaderText = "单号";
            this.bhDataGridViewTextBoxColumn.Name = "bhDataGridViewTextBoxColumn";
            this.bhDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ybfjeDataGridViewTextBoxColumn
            // 
            this.ybfjeDataGridViewTextBoxColumn.DataPropertyName = "ybfje";
            this.ybfjeDataGridViewTextBoxColumn.HeaderText = "运保费金额";
            this.ybfjeDataGridViewTextBoxColumn.Name = "ybfjeDataGridViewTextBoxColumn";
            this.ybfjeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yctsDataGridViewTextBoxColumn
            // 
            this.yctsDataGridViewTextBoxColumn.DataPropertyName = "ycts";
            this.yctsDataGridViewTextBoxColumn.HeaderText = "延迟天数";
            this.yctsDataGridViewTextBoxColumn.Name = "yctsDataGridViewTextBoxColumn";
            this.yctsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // inssjDataGridViewTextBoxColumn
            // 
            this.inssjDataGridViewTextBoxColumn.DataPropertyName = "inssj";
            this.inssjDataGridViewTextBoxColumn.HeaderText = "记账日期";
            this.inssjDataGridViewTextBoxColumn.Name = "inssjDataGridViewTextBoxColumn";
            this.inssjDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shsjDataGridViewTextBoxColumn
            // 
            this.shsjDataGridViewTextBoxColumn.DataPropertyName = "shsj";
            this.shsjDataGridViewTextBoxColumn.HeaderText = "审批通过日期";
            this.shsjDataGridViewTextBoxColumn.Name = "shsjDataGridViewTextBoxColumn";
            this.shsjDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ywlx";
            this.dataGridViewTextBoxColumn1.HeaderText = "业务类型";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vybfjsxcx";
            this.Bds.DataSource = this.DSYBF;
            // 
            // DSYBF
            // 
            this.DSYBF.DataSetName = "DSYBF";
            this.DSYBF.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VybfjsxcxTableAdapter
            // 
            this.VybfjsxcxTableAdapter.ClearBeforeFill = true;
            // 
            // FrmYBFCKJSXMX
            // 
            this.AcceptButton = this.BtnExl;
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(997, 466);
            this.Text = "代收款存款及时性明细";
            this.PnlTop.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSYBF)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion

        private Panel PnlTop;
        private Panel PnlMain;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExl;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn dqmcDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jgmcDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bhDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ybfjeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn yctsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn inssjDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shsjDataGridViewTextBoxColumn;
        private BindingSource Bds;
        private DSYBF DSYBF;
        private DSYBFTableAdapters.VybfjsxcxTableAdapter VybfjsxcxTableAdapter;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        //private DSDSKCKJSXCX DSDSKCKJSXCX1;
            //private DSDSKCKJSXCXTableAdapters.VfmsdskckjsxcxmxTableAdapter VfmsdskckjsxcxmxTableAdapter1;


        }
    }