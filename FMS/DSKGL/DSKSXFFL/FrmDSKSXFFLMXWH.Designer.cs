using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKSXFFL
    {
    partial class FrmDSKSXFFLMXWH
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.TxtBz = new Gizmox.WebGUI.Forms.TextBox();
            this.TxtMc = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.chkB = new Gizmox.WebGUI.Forms.CheckBox();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.BtnEdit = new Gizmox.WebGUI.Forms.Button();
            this.BtnDel = new Gizmox.WebGUI.Forms.Button();
            this.BtnCancel = new Gizmox.WebGUI.Forms.Button();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnNew = new Gizmox.WebGUI.Forms.Button();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtFfsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtFl = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSxfsx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSxfxx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.BdsMX = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSdsksxffl1 = new FMS.DSKGL.DSKSXFFL.DSDSKSXFFL();
            this.TableAdapterManager1 = new FMS.DSKGL.DSKSXFFL.DSDSKSXFFLTableAdapters.TableAdapterManager();
            this.TfmssxfflpcTableAdapter1 = new FMS.DSKGL.DSKSXFFL.DSDSKSXFFLTableAdapters.TfmssxfflpcTableAdapter();
            this.VfmssxfflmxTableAdapter1 = new FMS.DSKGL.DSKSXFFL.DSDSKSXFFLTableAdapters.VfmssxfflmxTableAdapter();
            this.PnlTop.SuspendLayout();
            this.PnlBtns.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BdsMX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSdsksxffl1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Controls.Add(this.label7);
            this.PnlTop.Controls.Add(this.TxtBz);
            this.PnlTop.Controls.Add(this.TxtMc);
            this.PnlTop.Controls.Add(this.label6);
            this.PnlTop.Controls.Add(this.label5);
            this.PnlTop.Controls.Add(this.chkB);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(576, 65);
            this.PnlTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(186, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(9, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "点击“添加”按钮为费率增加详细条目，点击“删除”删除费率的详细条目，点击“保存”保存当前费率";
            // 
            // TxtBz
            // 
            this.TxtBz.AllowDrag = false;
            this.TxtBz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBz.Location = new System.Drawing.Point(255, 9);
            this.TxtBz.Name = "TxtBz";
            this.TxtBz.Size = new System.Drawing.Size(206, 21);
            this.TxtBz.TabIndex = 1;
            // 
            // TxtMc
            // 
            this.TxtMc.AllowDrag = false;
            this.TxtMc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMc.Location = new System.Drawing.Point(66, 9);
            this.TxtMc.Name = "TxtMc";
            this.TxtMc.Size = new System.Drawing.Size(117, 21);
            this.TxtMc.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(223, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "备注";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "名称";
            // 
            // chkB
            // 
            this.chkB.AutoSize = true;
            this.chkB.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkB.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkB.Location = new System.Drawing.Point(479, 12);
            this.chkB.Name = "chkB";
            this.chkB.Size = new System.Drawing.Size(48, 16);
            this.chkB.TabIndex = 6;
            this.chkB.Text = "默认";
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.BtnEdit);
            this.PnlBtns.Controls.Add(this.BtnDel);
            this.PnlBtns.Controls.Add(this.BtnCancel);
            this.PnlBtns.Controls.Add(this.BtnSave);
            this.PnlBtns.Controls.Add(this.BtnNew);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 65);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(576, 36);
            this.PnlBtns.TabIndex = 0;
            // 
            // BtnEdit
            // 
            this.BtnEdit.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnEdit.CustomStyle = "F";
            this.BtnEdit.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.Location = new System.Drawing.Point(123, 6);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 1;
            this.BtnEdit.Text = "编辑";
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDel.CustomStyle = "F";
            this.BtnDel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDel.Location = new System.Drawing.Point(228, 6);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(75, 23);
            this.BtnDel.TabIndex = 2;
            this.BtnDel.Text = "删除";
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnCancel.CustomStyle = "F";
            this.BtnCancel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.Location = new System.Drawing.Point(438, 6);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(333, 6);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnNew.CustomStyle = "F";
            this.BtnNew.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnNew.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.Location = new System.Drawing.Point(18, 6);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(75, 23);
            this.BtnNew.TabIndex = 0;
            this.BtnNew.Text = "新增";
            this.BtnNew.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 101);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(576, 365);
            this.PnlMain.TabIndex = 2;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv.AutoGenerateColumns = false;
            this.Dgv.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvColTxtFfsj,
            this.DgvColTxtFl,
            this.DgvColTxtSxfsx,
            this.DgvColTxtSxfxx});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.BdsMX;
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle7;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(576, 365);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellDoubleClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellDoubleClick);
            // 
            // DgvColTxtFfsj
            // 
            this.DgvColTxtFfsj.DataPropertyName = "dskffsjs";
            this.DgvColTxtFfsj.FillWeight = 106.9684F;
            this.DgvColTxtFfsj.HeaderText = "发放时间";
            this.DgvColTxtFfsj.Name = "DgvColTxtFfsj";
            this.DgvColTxtFfsj.ReadOnly = true;
            this.DgvColTxtFfsj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtFl
            // 
            this.DgvColTxtFl.DataPropertyName = "fl";
            this.DgvColTxtFl.FillWeight = 107.4501F;
            this.DgvColTxtFl.HeaderText = "费率";
            this.DgvColTxtFl.Name = "DgvColTxtFl";
            this.DgvColTxtFl.ReadOnly = true;
            this.DgvColTxtFl.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtSxfsx
            // 
            this.DgvColTxtSxfsx.DataPropertyName = "sxfsx";
            this.DgvColTxtSxfsx.FillWeight = 94.45206F;
            this.DgvColTxtSxfsx.HeaderText = "手续费上限";
            this.DgvColTxtSxfsx.Name = "DgvColTxtSxfsx";
            this.DgvColTxtSxfsx.ReadOnly = true;
            this.DgvColTxtSxfsx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtSxfxx
            // 
            this.DgvColTxtSxfxx.DataPropertyName = "sxfxx";
            this.DgvColTxtSxfxx.FillWeight = 97.15293F;
            this.DgvColTxtSxfxx.HeaderText = "手续费下限";
            this.DgvColTxtSxfxx.Name = "DgvColTxtSxfxx";
            this.DgvColTxtSxfxx.ReadOnly = true;
            this.DgvColTxtSxfxx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BdsMX
            // 
            this.BdsMX.DataMember = "FK_Tfmssxfflpc_Vfmssxfflmx";
            this.BdsMX.DataSource = this.Bds;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Tfmssxfflpc";
            this.Bds.DataSource = this.DSdsksxffl1;
            // 
            // DSdsksxffl1
            // 
            this.DSdsksxffl1.DataSetName = "DSDSKSXFFL";
            this.DSdsksxffl1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TableAdapterManager1
            // 
            this.TableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.TableAdapterManager1.TfmssxfflmxTableAdapter = null;
            this.TableAdapterManager1.TfmssxfflpcTableAdapter = this.TfmssxfflpcTableAdapter1;
            this.TableAdapterManager1.UpdateOrder = FMS.DSKGL.DSKSXFFL.DSDSKSXFFLTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.TableAdapterManager1.VfmssxfflmxTableAdapter = this.VfmssxfflmxTableAdapter1;
            // 
            // TfmssxfflpcTableAdapter1
            // 
            this.TfmssxfflpcTableAdapter1.ClearBeforeFill = true;
            // 
            // VfmssxfflmxTableAdapter1
            // 
            this.VfmssxfflmxTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmDSKSXFFLMXWH
            // 
            this.AcceptButton = this.BtnSave;
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlBtns);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(576, 466);
            this.Text = "手续费费率明细";
            this.PnlTop.ResumeLayout(false);
            this.PnlBtns.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BdsMX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSdsksxffl1)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion

        private Panel PnlTop;
        private Panel PnlBtns;
        private Panel PnlMain;
        private CheckBox chkB;
        private Button BtnCancel;
        private Button BtnSave;
        private Button BtnNew;
        private Button BtnDel;
        private DataGridView Dgv;
        private TextBox TxtBz;
        private TextBox TxtMc;
        private Label label6;
        private Label label5;
        private Label label7;
        private BindingSource BdsMX;
        private BindingSource Bds;
        private DataGridViewTextBoxColumn DgvColTxtFfsj;
        private DataGridViewTextBoxColumn DgvColTxtFl;
        private DataGridViewTextBoxColumn DgvColTxtSxfsx;
        private DataGridViewTextBoxColumn DgvColTxtSxfxx;
        private DSDSKSXFFL DSdsksxffl1;
        private DSDSKSXFFLTableAdapters.TableAdapterManager TableAdapterManager1;
        private DSDSKSXFFLTableAdapters.TfmssxfflpcTableAdapter TfmssxfflpcTableAdapter1;
        private DSDSKSXFFLTableAdapters.VfmssxfflmxTableAdapter VfmssxfflmxTableAdapter1;
        private Button BtnEdit;
        private Label label1;


        }
    }