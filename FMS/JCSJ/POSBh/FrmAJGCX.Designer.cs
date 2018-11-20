using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.JCSJ.POSBh
{
    partial class FrmAJGCX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.BtnSave = new Gizmox.WebGUI.Forms.Panel();
            this.BtnSc = new Gizmox.WebGUI.Forms.Button();
            this.BtnBj = new Gizmox.WebGUI.Forms.Button();
            this.Btnxz = new Gizmox.WebGUI.Forms.Button();
            this.btncha = new Gizmox.WebGUI.Forms.Button();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.TxtbJGmc = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnJg = new Gizmox.WebGUI.Forms.Button();
            this.pnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.dqmcDataGridViewTextdqmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mcDataGridViewTextmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.posbhDataGridViewTextposbm = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.parentidDataGridViewTextparentid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSAJGCX = new FMS.JCSJ.POSBh.DSAJGCX1();
            this.DgvColTxtjzlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJZJG = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.VPosBhTableAdapter = new FMS.JCSJ.POSBh.DSAJGCX1TableAdapters.VPosBhTableAdapter();
            this.BtnEles = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnSave.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSAJGCX)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.Controls.Add(this.ctrlDownLoad1);
            this.BtnSave.Controls.Add(this.BtnEles);
            this.BtnSave.Controls.Add(this.BtnSc);
            this.BtnSave.Controls.Add(this.BtnBj);
            this.BtnSave.Controls.Add(this.Btnxz);
            this.BtnSave.Controls.Add(this.btncha);
            this.BtnSave.Controls.Add(this.label4);
            this.BtnSave.Controls.Add(this.TxtbJGmc);
            this.BtnSave.Controls.Add(this.BtnJg);
            this.BtnSave.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSave.Location = new System.Drawing.Point(0, 0);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(718, 76);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Tag = "";
            // 
            // BtnSc
            // 
            this.BtnSc.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSc.CustomStyle = "F";
            this.BtnSc.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSc.Location = new System.Drawing.Point(288, 41);
            this.BtnSc.Name = "BtnSc";
            this.BtnSc.Size = new System.Drawing.Size(75, 23);
            this.BtnSc.TabIndex = 14;
            this.BtnSc.Text = "删除";
            this.BtnSc.Click += new System.EventHandler(this.BtnSc_Click);
            // 
            // BtnBj
            // 
            this.BtnBj.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnBj.CustomStyle = "F";
            this.BtnBj.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnBj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBj.Location = new System.Drawing.Point(191, 41);
            this.BtnBj.Name = "BtnBj";
            this.BtnBj.Size = new System.Drawing.Size(75, 23);
            this.BtnBj.TabIndex = 13;
            this.BtnBj.Text = "编辑";
            this.BtnBj.Click += new System.EventHandler(this.BtnBj_Click);
            // 
            // Btnxz
            // 
            this.Btnxz.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Btnxz.CustomStyle = "F";
            this.Btnxz.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.Btnxz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnxz.Location = new System.Drawing.Point(98, 41);
            this.Btnxz.Name = "Btnxz";
            this.Btnxz.Size = new System.Drawing.Size(75, 23);
            this.Btnxz.TabIndex = 12;
            this.Btnxz.Text = "新增";
            this.Btnxz.Click += new System.EventHandler(this.Btnxz_Click);
            // 
            // btncha
            // 
            this.btncha.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.btncha.CustomStyle = "F";
            this.btncha.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btncha.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncha.Location = new System.Drawing.Point(10, 41);
            this.btncha.Name = "btncha";
            this.btncha.Size = new System.Drawing.Size(75, 23);
            this.btncha.TabIndex = 11;
            this.btncha.Text = "查询";
            this.btncha.Click += new System.EventHandler(this.btncha_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "查询机构";
            // 
            // TxtbJGmc
            // 
            this.TxtbJGmc.AllowDrag = false;
            this.TxtbJGmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtbJGmc.Location = new System.Drawing.Point(66, 16);
            this.TxtbJGmc.Name = "TxtbJGmc";
            this.TxtbJGmc.Size = new System.Drawing.Size(151, 20);
            this.TxtbJGmc.TabIndex = 3;
            // 
            // BtnJg
            // 
            this.BtnJg.CustomStyle = "F";
            this.BtnJg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnJg.Location = new System.Drawing.Point(220, 15);
            this.BtnJg.Name = "BtnJg";
            this.BtnJg.Size = new System.Drawing.Size(26, 21);
            this.BtnJg.TabIndex = 5;
            this.BtnJg.Text = "》》";
            this.BtnJg.Click += new System.EventHandler(this.BtnJg_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.Dgv);
            this.pnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 76);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(718, 545);
            this.pnlMain.TabIndex = 1;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle21.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.Dgv.AutoGenerateColumns = false;
            this.Dgv.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle22.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.dqmcDataGridViewTextdqmc,
            this.mcDataGridViewTextmc,
            this.posbhDataGridViewTextposbm,
            this.idDataGridViewTextid,
            this.parentidDataGridViewTextparentid});
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle27.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle27;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            dataGridViewCellStyle28.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle28.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(718, 545);
            this.Dgv.TabIndex = 0;
            // 
            // dqmcDataGridViewTextdqmc
            // 
            this.dqmcDataGridViewTextdqmc.DataPropertyName = "dqmc";
            dataGridViewCellStyle23.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle23.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.dqmcDataGridViewTextdqmc.DefaultCellStyle = dataGridViewCellStyle23;
            this.dqmcDataGridViewTextdqmc.FillWeight = 120F;
            this.dqmcDataGridViewTextdqmc.HeaderText = "大区名称";
            this.dqmcDataGridViewTextdqmc.Name = "dqmcDataGridViewTextdqmc";
            this.dqmcDataGridViewTextdqmc.ReadOnly = true;
            this.dqmcDataGridViewTextdqmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dqmcDataGridViewTextdqmc.Width = 140;
            // 
            // mcDataGridViewTextmc
            // 
            this.mcDataGridViewTextmc.DataPropertyName = "mc";
            dataGridViewCellStyle24.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle24.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.mcDataGridViewTextmc.DefaultCellStyle = dataGridViewCellStyle24;
            this.mcDataGridViewTextmc.FillWeight = 120F;
            this.mcDataGridViewTextmc.HeaderText = "机构名称";
            this.mcDataGridViewTextmc.Name = "mcDataGridViewTextmc";
            this.mcDataGridViewTextmc.ReadOnly = true;
            this.mcDataGridViewTextmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mcDataGridViewTextmc.Width = 140;
            // 
            // posbhDataGridViewTextposbm
            // 
            this.posbhDataGridViewTextposbm.DataPropertyName = "posbh";
            this.posbhDataGridViewTextposbm.FillWeight = 120F;
            this.posbhDataGridViewTextposbm.HeaderText = "Pos编码";
            this.posbhDataGridViewTextposbm.Name = "posbhDataGridViewTextposbm";
            this.posbhDataGridViewTextposbm.ReadOnly = true;
            this.posbhDataGridViewTextposbm.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.posbhDataGridViewTextposbm.Width = 150;
            // 
            // idDataGridViewTextid
            // 
            this.idDataGridViewTextid.DataPropertyName = "id";
            dataGridViewCellStyle25.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle25.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.idDataGridViewTextid.DefaultCellStyle = dataGridViewCellStyle25;
            this.idDataGridViewTextid.HeaderText = "id";
            this.idDataGridViewTextid.Name = "idDataGridViewTextid";
            this.idDataGridViewTextid.ReadOnly = true;
            this.idDataGridViewTextid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idDataGridViewTextid.Visible = false;
            // 
            // parentidDataGridViewTextparentid
            // 
            this.parentidDataGridViewTextparentid.DataPropertyName = "parentid";
            dataGridViewCellStyle26.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle26.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.parentidDataGridViewTextparentid.DefaultCellStyle = dataGridViewCellStyle26;
            this.parentidDataGridViewTextparentid.HeaderText = "parentid";
            this.parentidDataGridViewTextparentid.Name = "parentidDataGridViewTextparentid";
            this.parentidDataGridViewTextparentid.ReadOnly = true;
            this.parentidDataGridViewTextparentid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.parentidDataGridViewTextparentid.Visible = false;
            // 
            // Bds
            // 
            this.Bds.DataMember = "VPosBh";
            this.Bds.DataSource = this.DSAJGCX;
            this.Bds.CurrentChanged += new System.EventHandler(this.Bds_CurrentChanged);
            // 
            // DSAJGCX
            // 
            this.DSAJGCX.DataSetName = "DSAJGCX";
            this.DSAJGCX.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DgvColTxtjzlx
            // 
            this.DgvColTxtjzlx.DataPropertyName = "dqmc";
            dataGridViewCellStyle29.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjzlx.DefaultCellStyle = dataGridViewCellStyle29;
            this.DgvColTxtjzlx.FillWeight = 80F;
            this.DgvColTxtjzlx.HeaderText = "所属大区";
            this.DgvColTxtjzlx.Name = "DgvColTxtjzlx";
            this.DgvColTxtjzlx.ReadOnly = true;
            this.DgvColTxtjzlx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjzlx.Width = 80;
            // 
            // DgvColTxtJZJG
            // 
            this.DgvColTxtJZJG.DataPropertyName = "mc";
            dataGridViewCellStyle30.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtJZJG.DefaultCellStyle = dataGridViewCellStyle30;
            this.DgvColTxtJZJG.HeaderText = "记账机构";
            this.DgvColTxtJZJG.Name = "DgvColTxtJZJG";
            this.DgvColTxtJZJG.ReadOnly = true;
            this.DgvColTxtJZJG.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtJZJG.Width = 140;
            // 
            // VPosBhTableAdapter
            // 
            this.VPosBhTableAdapter.ClearBeforeFill = true;
            // 
            // BtnEles
            // 
            this.BtnEles.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnEles.CustomStyle = "F";
            this.BtnEles.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnEles.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEles.Location = new System.Drawing.Point(379, 41);
            this.BtnEles.Name = "BtnEles";
            this.BtnEles.Size = new System.Drawing.Size(75, 23);
            this.BtnEles.TabIndex = 15;
            this.BtnEles.Text = "导出";
            this.BtnEles.Click += new System.EventHandler(this.BtnEles_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(288, 10);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 16;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // FrmAJGCX
            // 
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.BtnSave);
            this.Size = new System.Drawing.Size(718, 621);
            this.Text = "FrmAJGCX";
            this.BtnSave.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSAJGCX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel BtnSave;
        private Panel pnlMain;
        private Label label4;
        private TextBox TxtbJGmc;
        private Button BtnJg;
        private Button btncha;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn mcDataGridViewTextmc;
        private DataGridViewTextBoxColumn dqmcDataGridViewTextdqmc;
        private DataGridViewTextBoxColumn posbhDataGridViewTextposbm;
        private DataGridViewTextBoxColumn idDataGridViewTextid;
        private DataGridViewTextBoxColumn parentidDataGridViewTextparentid;
        private BindingSource Bds;
        private DSAJGCX1 DSAJGCX;
        private DataGridViewTextBoxColumn DgvColTxtjzlx;
        private DataGridViewTextBoxColumn DgvColTxtJZJG;
        private DSAJGCX1TableAdapters.VPosBhTableAdapter VPosBhTableAdapter;
        private Button Btnxz;
        private Button BtnBj;
        private Button BtnSc;
        private Button BtnEles;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;


    }
}
