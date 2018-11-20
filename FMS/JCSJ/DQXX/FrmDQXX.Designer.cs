using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using FMS.JCSJ.SXFFL;

namespace FMS.JCSJ.DQXX
{
    partial class FrmDQXX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.BtnDelete = new Gizmox.WebGUI.Forms.Button();
            this.BtnEdit = new Gizmox.WebGUI.Forms.Button();
            this.BtnNew = new Gizmox.WebGUI.Forms.Button();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.mcDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.bhDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ztDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.smDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSQSXX1 = new FMS.JCSJ.DQXX.DSQSXX();
            this.DgvColTxtmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtFL = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSxfsx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSxfxx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtBZ = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.TdqTableAdapter1 = new FMS.JCSJ.DQXX.DSQSXXTableAdapters.TdqTableAdapter();
            this.PnlBtns.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSQSXX1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.BtnExl);
            this.PnlBtns.Controls.Add(this.BtnDelete);
            this.PnlBtns.Controls.Add(this.BtnEdit);
            this.PnlBtns.Controls.Add(this.BtnNew);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(695, 50);
            this.PnlBtns.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(404, 11);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 23);
            this.ctrlDownLoad1.TabIndex = 1;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(305, 11);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 3;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDelete.CustomStyle = "F";
            this.BtnDelete.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.Location = new System.Drawing.Point(206, 11);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "删除";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnEdit.CustomStyle = "F";
            this.BtnEdit.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.Location = new System.Drawing.Point(107, 11);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 1;
            this.BtnEdit.Text = "编辑";
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnNew.CustomStyle = "F";
            this.BtnNew.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnNew.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.Location = new System.Drawing.Point(8, 11);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(75, 23);
            this.BtnNew.TabIndex = 0;
            this.BtnNew.Text = "新增";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 50);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(695, 392);
            this.PnlMain.TabIndex = 1;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
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
            this.mcDataGridViewTextBoxColumn,
            this.bhDataGridViewTextBoxColumn,
            this.ztDataGridViewTextBoxColumn,
            this.smDataGridViewTextBoxColumn});
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
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.RowHeadersWidth = 10;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(695, 392);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellDoubleClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellDoubleClick);
            // 
            // mcDataGridViewTextBoxColumn
            // 
            this.mcDataGridViewTextBoxColumn.DataPropertyName = "mc";
            this.mcDataGridViewTextBoxColumn.HeaderText = "名称";
            this.mcDataGridViewTextBoxColumn.Name = "mcDataGridViewTextBoxColumn";
            this.mcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bhDataGridViewTextBoxColumn
            // 
            this.bhDataGridViewTextBoxColumn.DataPropertyName = "bh";
            this.bhDataGridViewTextBoxColumn.HeaderText = "编号";
            this.bhDataGridViewTextBoxColumn.Name = "bhDataGridViewTextBoxColumn";
            this.bhDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ztDataGridViewTextBoxColumn
            // 
            this.ztDataGridViewTextBoxColumn.DataPropertyName = "zt";
            this.ztDataGridViewTextBoxColumn.HeaderText = "状态";
            this.ztDataGridViewTextBoxColumn.Name = "ztDataGridViewTextBoxColumn";
            this.ztDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // smDataGridViewTextBoxColumn
            // 
            this.smDataGridViewTextBoxColumn.DataPropertyName = "sm";
            this.smDataGridViewTextBoxColumn.HeaderText = "说明";
            this.smDataGridViewTextBoxColumn.Name = "smDataGridViewTextBoxColumn";
            this.smDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Tdq";
            this.Bds.DataSource = this.DSQSXX1;
            // 
            // DSQSXX1
            // 
            this.DSQSXX1.DataSetName = "DSQSXX";
            this.DSQSXX1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DgvColTxtmc
            // 
            this.DgvColTxtmc.DataPropertyName = "mc";
            this.DgvColTxtmc.HeaderText = "名称";
            this.DgvColTxtmc.Name = "DgvColTxtmc";
            this.DgvColTxtmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtFL
            // 
            this.DgvColTxtFL.DataPropertyName = "fl";
            this.DgvColTxtFL.HeaderText = "费率";
            this.DgvColTxtFL.Name = "DgvColTxtFL";
            this.DgvColTxtFL.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtSxfsx
            // 
            this.DgvColTxtSxfsx.DataPropertyName = "sxfsx";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtSxfsx.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColTxtSxfsx.HeaderText = "手续费上限";
            this.DgvColTxtSxfsx.Name = "DgvColTxtSxfsx";
            this.DgvColTxtSxfsx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtSxfxx
            // 
            this.DgvColTxtSxfxx.DataPropertyName = "sxfxx";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtSxfxx.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvColTxtSxfxx.HeaderText = "手续费下限";
            this.DgvColTxtSxfxx.Name = "DgvColTxtSxfxx";
            this.DgvColTxtSxfxx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtBZ
            // 
            this.DgvColTxtBZ.DataPropertyName = "bz";
            this.DgvColTxtBZ.HeaderText = "备注";
            this.DgvColTxtBZ.Name = "DgvColTxtBZ";
            this.DgvColTxtBZ.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TdqTableAdapter1
            // 
            this.TdqTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmDQXX
            // 
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlBtns);
            this.Size = new System.Drawing.Size(695, 442);
            this.Text = "FrmDSKSXFFL";
            this.PnlBtns.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSQSXX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlBtns;
        private Panel PnlMain;
        private Button BtnDelete;
        private Button BtnEdit;
        private Button BtnNew;
        private DataGridView Dgv;
        //private DSDSKSXFFL DSDSKSXFFL1;
        //private FMS.DSKKHGL.SXFFL.DSDSKSXFFLTableAdapters.tdskflTableAdapter TdskflTableAdapter1;
        private DataGridViewTextBoxColumn DgvColTxtFL;
        private DataGridViewTextBoxColumn DgvColTxtBZ;
        private DataGridViewTextBoxColumn DgvColTxtSxfsx;
        private DataGridViewTextBoxColumn DgvColTxtSxfxx;
        private DataGridViewTextBoxColumn DgvColTxtmc;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExl;
        private DataGridViewTextBoxColumn mcDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bhDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ztDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn smDataGridViewTextBoxColumn;
        private BindingSource Bds;
        private DSQSXX DSQSXX1;
        private DSQSXXTableAdapters.TdqTableAdapter TdqTableAdapter1;


    }
}