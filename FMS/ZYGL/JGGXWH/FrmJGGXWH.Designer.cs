using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.JGGXWH
{
    partial class FrmJGGXWH
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
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.BtnGxjg = new Gizmox.WebGUI.Forms.Button();
            this.BtnYjg = new Gizmox.WebGUI.Forms.Button();
            this.CmbGxzl = new Gizmox.WebGUI.Forms.ComboBox();
            this.LblGxzl = new Gizmox.WebGUI.Forms.Label();
            this.TxtGxjg = new Gizmox.WebGUI.Forms.TextBox();
            this.LblGxjg = new Gizmox.WebGUI.Forms.Label();
            this.TxtYjg = new Gizmox.WebGUI.Forms.TextBox();
            this.LblYjg = new Gizmox.WebGUI.Forms.Label();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.LblTs = new Gizmox.WebGUI.Forms.Label();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.TxtJl = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSearch = new Gizmox.WebGUI.Forms.Button();
            this.BtnDelete = new Gizmox.WebGUI.Forms.Button();
            this.BtnEdit = new Gizmox.WebGUI.Forms.Button();
            this.BtnNew = new Gizmox.WebGUI.Forms.Button();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtJgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtGxjgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtGxzl = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtId = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSjggxwh1 = new FMS.ZYGL.JGGXWH.DSJGGXWH();
            this.PnlDgv = new Gizmox.WebGUI.Forms.Panel();
            this.VfmsjggxTableAdapter1 = new FMS.ZYGL.JGGXWH.DSJGGXWHTableAdapters.VfmsjggxTableAdapter();
            this.PnlTop.SuspendLayout();
            this.PnlBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSjggxwh1)).BeginInit();
            this.PnlDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnGxjg);
            this.PnlTop.Controls.Add(this.BtnYjg);
            this.PnlTop.Controls.Add(this.CmbGxzl);
            this.PnlTop.Controls.Add(this.LblGxzl);
            this.PnlTop.Controls.Add(this.TxtGxjg);
            this.PnlTop.Controls.Add(this.LblGxjg);
            this.PnlTop.Controls.Add(this.TxtYjg);
            this.PnlTop.Controls.Add(this.LblYjg);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(825, 32);
            this.PnlTop.TabIndex = 0;
            // 
            // BtnGxjg
            // 
            this.BtnGxjg.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnGxjg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnGxjg.CustomStyle = "F";
            this.BtnGxjg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnGxjg.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnGxjg.Location = new System.Drawing.Point(498, 8);
            this.BtnGxjg.Name = "BtnGxjg";
            this.BtnGxjg.Size = new System.Drawing.Size(26, 21);
            this.BtnGxjg.TabIndex = 4;
            this.BtnGxjg.Text = "》";
            this.BtnGxjg.Click += new System.EventHandler(this.BtnGxjg_Click);
            // 
            // BtnYjg
            // 
            this.BtnYjg.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnYjg.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnYjg.CustomStyle = "F";
            this.BtnYjg.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnYjg.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnYjg.Location = new System.Drawing.Point(228, 9);
            this.BtnYjg.Name = "BtnYjg";
            this.BtnYjg.Size = new System.Drawing.Size(26, 21);
            this.BtnYjg.TabIndex = 2;
            this.BtnYjg.Text = "》";
            this.BtnYjg.Click += new System.EventHandler(this.BtnYjg_Click);
            // 
            // CmbGxzl
            // 
            this.CmbGxzl.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbGxzl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbGxzl.FormattingEnabled = true;
            this.CmbGxzl.Location = new System.Drawing.Point(607, 9);
            this.CmbGxzl.Name = "CmbGxzl";
            this.CmbGxzl.Size = new System.Drawing.Size(121, 20);
            this.CmbGxzl.TabIndex = 5;
            // 
            // LblGxzl
            // 
            this.LblGxzl.AutoSize = true;
            this.LblGxzl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGxzl.Location = new System.Drawing.Point(554, 13);
            this.LblGxzl.Name = "LblGxzl";
            this.LblGxzl.Size = new System.Drawing.Size(35, 13);
            this.LblGxzl.TabIndex = 0;
            this.LblGxzl.Text = "关系种类";
            // 
            // TxtGxjg
            // 
            this.TxtGxjg.AllowDrag = false;
            this.TxtGxjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGxjg.Location = new System.Drawing.Point(329, 9);
            this.TxtGxjg.Name = "TxtGxjg";
            this.TxtGxjg.Size = new System.Drawing.Size(166, 21);
            this.TxtGxjg.TabIndex = 3;
            // 
            // LblGxjg
            // 
            this.LblGxjg.AutoSize = true;
            this.LblGxjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGxjg.Location = new System.Drawing.Point(273, 13);
            this.LblGxjg.Name = "LblGxjg";
            this.LblGxjg.Size = new System.Drawing.Size(35, 13);
            this.LblGxjg.TabIndex = 0;
            this.LblGxjg.Text = "关系机构";
            // 
            // TxtYjg
            // 
            this.TxtYjg.AllowDrag = false;
            this.TxtYjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtYjg.Location = new System.Drawing.Point(59, 9);
            this.TxtYjg.Name = "TxtYjg";
            this.TxtYjg.Size = new System.Drawing.Size(166, 21);
            this.TxtYjg.TabIndex = 1;
            // 
            // LblYjg
            // 
            this.LblYjg.AutoSize = true;
            this.LblYjg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYjg.Location = new System.Drawing.Point(15, 13);
            this.LblYjg.Name = "LblYjg";
            this.LblYjg.Size = new System.Drawing.Size(35, 13);
            this.LblYjg.TabIndex = 0;
            this.LblYjg.Text = "源机构";
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.LblTs);
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.BtnExl);
            this.PnlBtns.Controls.Add(this.TxtJl);
            this.PnlBtns.Controls.Add(this.BtnSearch);
            this.PnlBtns.Controls.Add(this.BtnDelete);
            this.PnlBtns.Controls.Add(this.BtnEdit);
            this.PnlBtns.Controls.Add(this.BtnNew);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 32);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(825, 61);
            this.PnlBtns.TabIndex = 1;
            // 
            // LblTs
            // 
            this.LblTs.AutoSize = true;
            this.LblTs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTs.ForeColor = System.Drawing.Color.Green;
            this.LblTs.Location = new System.Drawing.Point(18, 3);
            this.LblTs.Name = "LblTs";
            this.LblTs.Size = new System.Drawing.Size(35, 13);
            this.LblTs.TabIndex = 12;
            this.LblTs.Text = "1)维护机构之间运保费与代收款的审核关系\r\n2)对于具有双向结算关系的机构，通过本模块将源机构与关系机构维护两条记录的方式实现";
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(623, 32);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 11;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(374, 34);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 10;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // TxtJl
            // 
            this.TxtJl.AllowDrag = false;
            this.TxtJl.Font = new System.Drawing.Font("宋体", 9F);
            this.TxtJl.ForeColor = System.Drawing.Color.Blue;
            this.TxtJl.Location = new System.Drawing.Point(463, 34);
            this.TxtJl.MaxLength = 4;
            this.TxtJl.Name = "TxtJl";
            this.TxtJl.ReadOnly = true;
            this.TxtJl.Size = new System.Drawing.Size(120, 21);
            this.TxtJl.TabIndex = 1;
            this.TxtJl.Text = "共有0条信息";
            // 
            // BtnSearch
            // 
            this.BtnSearch.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnSearch.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSearch.CustomStyle = "F";
            this.BtnSearch.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(285, 34);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 6;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnDelete.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDelete.CustomStyle = "F";
            this.BtnDelete.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.Location = new System.Drawing.Point(196, 34);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 9;
            this.BtnDelete.Text = "删除";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnEdit.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnEdit.CustomStyle = "F";
            this.BtnEdit.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.Location = new System.Drawing.Point(107, 34);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 8;
            this.BtnEdit.Text = "编辑";
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnNew.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnNew.CustomStyle = "F";
            this.BtnNew.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnNew.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.Location = new System.Drawing.Point(18, 34);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(75, 23);
            this.BtnNew.TabIndex = 7;
            this.BtnNew.Text = "新增";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.AutoGenerateColumns = false;
            this.Dgv.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvColTxtJgmc,
            this.DgvColTxtGxjgmc,
            this.DgvColTxtGxzl,
            this.DgvColTxtId});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(825, 339);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColTxtJgmc
            // 
            this.DgvColTxtJgmc.DataPropertyName = "jgmc";
            this.DgvColTxtJgmc.HeaderText = "源机构";
            this.DgvColTxtJgmc.Name = "DgvColTxtJgmc";
            this.DgvColTxtJgmc.ReadOnly = true;
            this.DgvColTxtJgmc.Width = 150;
            // 
            // DgvColTxtGxjgmc
            // 
            this.DgvColTxtGxjgmc.DataPropertyName = "tojgmc";
            this.DgvColTxtGxjgmc.HeaderText = "关系机构";
            this.DgvColTxtGxjgmc.Name = "DgvColTxtGxjgmc";
            this.DgvColTxtGxjgmc.ReadOnly = true;
            this.DgvColTxtGxjgmc.Width = 150;
            // 
            // DgvColTxtGxzl
            // 
            this.DgvColTxtGxzl.DataPropertyName = "gxzls";
            this.DgvColTxtGxzl.HeaderText = "关系种类";
            this.DgvColTxtGxzl.Name = "DgvColTxtGxzl";
            this.DgvColTxtGxzl.ReadOnly = true;
            // 
            // DgvColTxtId
            // 
            this.DgvColTxtId.DataPropertyName = "id";
            this.DgvColTxtId.HeaderText = "Id[隐藏]";
            this.DgvColTxtId.Name = "DgvColTxtId";
            this.DgvColTxtId.ReadOnly = true;
            this.DgvColTxtId.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtId.Visible = false;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsjggx";
            this.Bds.DataSource = this.DSjggxwh1;
            // 
            // DSjggxwh1
            // 
            this.DSjggxwh1.DataSetName = "DSJGGXWH";
            this.DSjggxwh1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PnlDgv
            // 
            this.PnlDgv.Controls.Add(this.Dgv);
            this.PnlDgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlDgv.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlDgv.Location = new System.Drawing.Point(0, 93);
            this.PnlDgv.Name = "PnlDgv";
            this.PnlDgv.Size = new System.Drawing.Size(825, 339);
            this.PnlDgv.TabIndex = 1;
            // 
            // VfmsjggxTableAdapter1
            // 
            this.VfmsjggxTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmJGGXWH
            // 
            this.Controls.Add(this.PnlDgv);
            this.Controls.Add(this.PnlBtns);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(825, 432);
            this.Text = "FrmJGGXWH";
            this.PnlTop.ResumeLayout(false);
            this.PnlBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSjggxwh1)).EndInit();
            this.PnlDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private Panel PnlBtns;
        private DataGridView Dgv;
        private BindingSource Bds;
        private Panel PnlDgv;
        private Label LblYjg;
        private Label LblGxzl;
        private TextBox TxtGxjg;
        private Label LblGxjg;
        private TextBox TxtYjg;
        private ComboBox CmbGxzl;
        private Button BtnNew;
        private Button BtnGxjg;
        private Button BtnYjg;
        private Button BtnEdit;
        private DataGridViewTextBoxColumn DgvColTxtId;
        private DataGridViewTextBoxColumn DgvColTxtJgmc;
        private DataGridViewTextBoxColumn DgvColTxtGxjgmc;
        private DataGridViewTextBoxColumn DgvColTxtGxzl;
        private DSJGGXWH DSjggxwh1;
        private DSJGGXWHTableAdapters.VfmsjggxTableAdapter VfmsjggxTableAdapter1;
        private Button BtnDelete;
        private Button BtnSearch;
        private TextBox TxtJl;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Label LblTs;


    }
}