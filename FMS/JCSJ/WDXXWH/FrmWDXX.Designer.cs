using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.WDXXWH
{
    partial class FrmWDXX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.BtnDelete = new Gizmox.WebGUI.Forms.Button();
            this.BtnEdit = new Gizmox.WebGUI.Forms.Button();
            this.BtnNew = new Gizmox.WebGUI.Forms.Button();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.BtnSeleDq = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.TxtDqmc = new Gizmox.WebGUI.Forms.TextBox();
            this.LblFL = new Gizmox.WebGUI.Forms.Label();
            this.TxtWdmc = new Gizmox.WebGUI.Forms.TextBox();
            this.Btn_Query = new Gizmox.WebGUI.Forms.Button();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtMc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtDq = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtBz = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.dswdxx1 = new FMS.JCSJ.WDXXWH.DSWDXX();
            this.ztDataGridViewTextBoxColumn = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.TableAdapterManager1 = new FMS.JCSJ.WDXXWH.DSWDXXTableAdapters.TableAdapterManager();
            this.TwdmxTableAdapter1 = new FMS.JCSJ.WDXXWH.DSWDXXTableAdapters.TwdmxTableAdapter();
            this.v_wdTableAdapter1 = new FMS.JCSJ.WDXXWH.DSWDXXTableAdapters.v_wdTableAdapter();
            this.BdsMx = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.frmZHGL1 = new TMS.zygl.zhgl.FrmZHGL();
            this.twdTableAdapter1 = new FMS.JCSJ.WDXXWH.DSWDXXTableAdapters.TwdTableAdapter();
            this.PnlBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dswdxx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BdsMx)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnDelete
            // 
            this.BtnDelete.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDelete.CustomStyle = "F";
            this.BtnDelete.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.Location = new System.Drawing.Point(323, 53);
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
            this.BtnEdit.Location = new System.Drawing.Point(220, 53);
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
            this.BtnNew.Location = new System.Drawing.Point(117, 53);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(75, 23);
            this.BtnNew.TabIndex = 0;
            this.BtnNew.Text = "新增";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.BtnSeleDq);
            this.PnlBtns.Controls.Add(this.label1);
            this.PnlBtns.Controls.Add(this.TxtDqmc);
            this.PnlBtns.Controls.Add(this.LblFL);
            this.PnlBtns.Controls.Add(this.TxtWdmc);
            this.PnlBtns.Controls.Add(this.Btn_Query);
            this.PnlBtns.Controls.Add(this.BtnDelete);
            this.PnlBtns.Controls.Add(this.BtnEdit);
            this.PnlBtns.Controls.Add(this.BtnNew);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(734, 93);
            this.PnlBtns.TabIndex = 0;
            // 
            // BtnSeleDq
            // 
            this.BtnSeleDq.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSeleDq.CustomStyle = "F";
            this.BtnSeleDq.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSeleDq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSeleDq.Location = new System.Drawing.Point(455, 15);
            this.BtnSeleDq.Name = "BtnSeleDq";
            this.BtnSeleDq.Size = new System.Drawing.Size(20, 20);
            this.BtnSeleDq.TabIndex = 10;
            this.BtnSeleDq.Text = "》";
            this.BtnSeleDq.Click += new System.EventHandler(this.BtnSeleDq_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(245, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "大区名称";
            // 
            // TxtDqmc
            // 
            this.TxtDqmc.AllowDrag = false;
            this.TxtDqmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDqmc.Location = new System.Drawing.Point(301, 15);
            this.TxtDqmc.Name = "TxtDqmc";
            this.TxtDqmc.Size = new System.Drawing.Size(151, 21);
            this.TxtDqmc.TabIndex = 0;
            // 
            // LblFL
            // 
            this.LblFL.AutoSize = true;
            this.LblFL.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFL.Location = new System.Drawing.Point(16, 18);
            this.LblFL.Name = "LblFL";
            this.LblFL.Size = new System.Drawing.Size(59, 12);
            this.LblFL.TabIndex = 0;
            this.LblFL.Text = "网点名称";
            // 
            // TxtWdmc
            // 
            this.TxtWdmc.AllowDrag = false;
            this.TxtWdmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtWdmc.Location = new System.Drawing.Point(72, 15);
            this.TxtWdmc.Name = "TxtWdmc";
            this.TxtWdmc.Size = new System.Drawing.Size(151, 21);
            this.TxtWdmc.TabIndex = 0;
            // 
            // Btn_Query
            // 
            this.Btn_Query.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Btn_Query.CustomStyle = "F";
            this.Btn_Query.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.Btn_Query.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Query.Location = new System.Drawing.Point(14, 53);
            this.Btn_Query.Name = "Btn_Query";
            this.Btn_Query.Size = new System.Drawing.Size(75, 23);
            this.Btn_Query.TabIndex = 0;
            this.Btn_Query.Text = "查询";
            this.Btn_Query.Click += new System.EventHandler(this.Btn_Query_Click);
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle19.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.Dgv.AutoGenerateColumns = false;
            dataGridViewCellStyle20.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvColTxtMc,
            this.DgvColTxtDq,
            this.DgvColTxtZt,
            this.DgvColTxtBz});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle25.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle25.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle25;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 93);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.RowHeadersWidth = 10;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle26.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.RowsDefaultCellStyle = dataGridViewCellStyle26;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(734, 406);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColTxtMc
            // 
            this.DgvColTxtMc.DataPropertyName = "wdmc";
            this.DgvColTxtMc.DefaultCellStyle = dataGridViewCellStyle21;
            this.DgvColTxtMc.HeaderText = "名称";
            this.DgvColTxtMc.Name = "DgvColTxtMc";
            this.DgvColTxtMc.ReadOnly = true;
            // 
            // DgvColTxtDq
            // 
            this.DgvColTxtDq.DataPropertyName = "mc";
            this.DgvColTxtDq.DefaultCellStyle = dataGridViewCellStyle22;
            this.DgvColTxtDq.HeaderText = "大区";
            this.DgvColTxtDq.Name = "DgvColTxtDq";
            this.DgvColTxtDq.ReadOnly = true;
            // 
            // DgvColTxtZt
            // 
            this.DgvColTxtZt.DataPropertyName = "zts";
            this.DgvColTxtZt.DefaultCellStyle = dataGridViewCellStyle23;
            this.DgvColTxtZt.HeaderText = "状态";
            this.DgvColTxtZt.Name = "DgvColTxtZt";
            this.DgvColTxtZt.ReadOnly = true;
            // 
            // DgvColTxtBz
            // 
            this.DgvColTxtBz.DataPropertyName = "bz";
            this.DgvColTxtBz.DefaultCellStyle = dataGridViewCellStyle24;
            this.DgvColTxtBz.HeaderText = "备注";
            this.DgvColTxtBz.Name = "DgvColTxtBz";
            this.DgvColTxtBz.ReadOnly = true;
            // 
            // Bds
            // 
            this.Bds.DataMember = "v_wd";
            this.Bds.DataSource = this.dswdxx1;
            // 
            // dswdxx1
            // 
            this.dswdxx1.DataSetName = "DSWDXX";
            this.dswdxx1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ztDataGridViewTextBoxColumn
            // 
            this.ztDataGridViewTextBoxColumn.DataPropertyName = "zt";
            this.ztDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle27;
            this.ztDataGridViewTextBoxColumn.HeaderText = "状态";
            this.ztDataGridViewTextBoxColumn.Name = "ztDataGridViewTextBoxColumn";
            // 
            // TableAdapterManager1
            // 
            this.TableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.TableAdapterManager1.TwdmxTableAdapter = this.TwdmxTableAdapter1;
            this.TableAdapterManager1.TwdTableAdapter = this.twdTableAdapter1;
            this.TableAdapterManager1.UpdateOrder = FMS.JCSJ.WDXXWH.DSWDXXTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.TableAdapterManager1.v_wdTableAdapter = this.v_wdTableAdapter1;
            // 
            // TwdmxTableAdapter1
            // 
            this.TwdmxTableAdapter1.ClearBeforeFill = true;
            // 
            // v_wdTableAdapter1
            // 
            this.v_wdTableAdapter1.ClearBeforeFill = true;
            // 
            // BdsMx
            // 
            this.BdsMx.DataMember = "FK_v_wd_Twdmx";
            this.BdsMx.DataSource = this.Bds;
            // 
            // frmZHGL1
            // 
            this.frmZHGL1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.frmZHGL1.Location = new System.Drawing.Point(0, 0);
            this.frmZHGL1.Name = "frmZHGL1";
            this.frmZHGL1.Size = new System.Drawing.Size(722, 654);
            this.frmZHGL1.Text = "FrmZHGL";
            // 
            // twdTableAdapter1
            // 
            this.twdTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmWDXX
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlBtns);
            this.Size = new System.Drawing.Size(734, 499);
            this.Text = "FrmWDXX";
            this.PnlBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dswdxx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BdsMx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnDelete;
        private Button BtnEdit;
        private Button BtnNew;
        private Panel PnlBtns;
        private Button Btn_Query;
        private Label label1;
        private TextBox TxtDqmc;
        private Label LblFL;
        private TextBox TxtWdmc;
        private Button BtnSeleDq;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn ztDataGridViewTextBoxColumn;
        private JCSJ.WDXXWH.DSWDXX dswdxx1;
        private JCSJ.WDXXWH.DSWDXXTableAdapters.TableAdapterManager TableAdapterManager1;
        private JCSJ.WDXXWH.DSWDXXTableAdapters.TwdmxTableAdapter TwdmxTableAdapter1;
        private BindingSource Bds;
        private BindingSource BdsMx;
        private DataGridViewTextBoxColumn DgvColTxtMc;
        private DataGridViewTextBoxColumn DgvColTxtDq;
        private DataGridViewTextBoxColumn DgvColTxtZt;
        private DataGridViewTextBoxColumn DgvColTxtBz;
        private JCSJ.WDXXWH.DSWDXXTableAdapters.v_wdTableAdapter v_wdTableAdapter1;
        private TMS.zygl.zhgl.FrmZHGL frmZHGL1;
        private JCSJ.WDXXWH.DSWDXXTableAdapters.TwdTableAdapter twdTableAdapter1;


    }
}