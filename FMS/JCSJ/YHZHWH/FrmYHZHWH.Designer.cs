using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.JCSJ.YHZHWH
{
    partial class FrmYHZHWH
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSYHZHWH1 = new FMS.JCSJ.YHZHWH.DSYHZHWH();
            this.PnlTree = new Gizmox.WebGUI.Forms.Panel();
            this.TrV = new Gizmox.WebGUI.Forms.TreeView();
            this.PnlTreeTop = new Gizmox.WebGUI.Forms.Panel();
            this.BtnSelect = new Gizmox.WebGUI.Forms.Button();
            this.TxtCZ = new Gizmox.WebGUI.Forms.TextBox();
            this.CTxtMnu1 = new Gizmox.WebGUI.Forms.ContextMenu();
            this.MnuNew = new Gizmox.WebGUI.Forms.MenuItem();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnSx = new Gizmox.WebGUI.Forms.Button();
            this.BtnDel = new Gizmox.WebGUI.Forms.Button();
            this.BtnEdit = new Gizmox.WebGUI.Forms.Button();
            this.BtnNew = new Gizmox.WebGUI.Forms.Button();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtzhlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtyhlxmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzhxzmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtkhh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtDqmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtyhlxid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.VyhzhTableAdapter1 = new FMS.JCSJ.YHZHWH.DSYHZHWHTableAdapters.VyhzhTableAdapter();
            this.TjigouTableAdapter1 = new FMS.JCSJ.YHZHWH.DSYHZHWHTableAdapters.tjigouTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSYHZHWH1)).BeginInit();
            this.PnlTree.SuspendLayout();
            this.PnlTreeTop.SuspendLayout();
            this.PnlBtns.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vyhzh";
            this.Bds.DataSource = this.DSYHZHWH1;
            // 
            // DSYHZHWH1
            // 
            this.DSYHZHWH1.DataSetName = "DSYHZHWH";
            this.DSYHZHWH1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PnlTree
            // 
            this.PnlTree.Controls.Add(this.TrV);
            this.PnlTree.Controls.Add(this.PnlTreeTop);
            this.PnlTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.PnlTree.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTree.Location = new System.Drawing.Point(0, 0);
            this.PnlTree.Name = "PnlTree";
            this.PnlTree.Size = new System.Drawing.Size(260, 522);
            this.PnlTree.TabIndex = 2;
            // 
            // TrV
            // 
            this.TrV.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.LightBlue);
            this.TrV.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.TrV.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrV.Location = new System.Drawing.Point(0, 37);
            this.TrV.Name = "TrV";
            this.TrV.SelectOnRightClick = true;
            this.TrV.Size = new System.Drawing.Size(260, 485);
            this.TrV.TabIndex = 0;
            this.TrV.AfterSelect += new Gizmox.WebGUI.Forms.TreeViewEventHandler(this.TrV_AfterSelect);
            // 
            // PnlTreeTop
            // 
            this.PnlTreeTop.Controls.Add(this.BtnSelect);
            this.PnlTreeTop.Controls.Add(this.TxtCZ);
            this.PnlTreeTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTreeTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTreeTop.Name = "PnlTreeTop";
            this.PnlTreeTop.Size = new System.Drawing.Size(260, 37);
            this.PnlTreeTop.TabIndex = 1;
            // 
            // BtnSelect
            // 
            this.BtnSelect.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSelect.CustomStyle = "F";
            this.BtnSelect.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSelect.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSelect.Location = new System.Drawing.Point(182, 7);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(67, 21);
            this.BtnSelect.TabIndex = 0;
            this.BtnSelect.Text = "查找";
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // TxtCZ
            // 
            this.TxtCZ.AllowDrag = false;
            this.TxtCZ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCZ.Location = new System.Drawing.Point(12, 8);
            this.TxtCZ.Name = "TxtCZ";
            this.TxtCZ.Size = new System.Drawing.Size(158, 21);
            this.TxtCZ.TabIndex = 4;
            // 
            // CTxtMnu1
            // 
            this.CTxtMnu1.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.MnuNew});
            // 
            // MnuNew
            // 
            this.MnuNew.Index = 0;
            this.MnuNew.Text = "新增账户";
            this.MnuNew.Click += new System.EventHandler(this.MnuNew_Click);
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.BtnExl);
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.BtnSx);
            this.PnlBtns.Controls.Add(this.BtnDel);
            this.PnlBtns.Controls.Add(this.BtnEdit);
            this.PnlBtns.Controls.Add(this.BtnNew);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(1027, 37);
            this.PnlBtns.TabIndex = 0;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(356, 7);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 4;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(556, 5);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 5;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnSx
            // 
            this.BtnSx.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSx.CustomStyle = "F";
            this.BtnSx.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSx.Location = new System.Drawing.Point(677, 7);
            this.BtnSx.Name = "BtnSx";
            this.BtnSx.Size = new System.Drawing.Size(75, 23);
            this.BtnSx.TabIndex = 3;
            this.BtnSx.Text = "刷新";
            this.BtnSx.Visible = false;
            this.BtnSx.Click += new System.EventHandler(this.BtnSx_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDel.CustomStyle = "F";
            this.BtnDel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDel.Location = new System.Drawing.Point(247, 7);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(75, 23);
            this.BtnDel.TabIndex = 2;
            this.BtnDel.Text = "删除";
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnEdit.CustomStyle = "F";
            this.BtnEdit.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.Location = new System.Drawing.Point(144, 7);
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
            this.BtnNew.Location = new System.Drawing.Point(41, 7);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(75, 23);
            this.BtnNew.TabIndex = 0;
            this.BtnNew.Text = "新增";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Controls.Add(this.PnlBtns);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(260, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1027, 522);
            this.PnlMain.TabIndex = 1;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowDrop = true;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.AutoGenerateColumns = false;
            this.Dgv.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvColTxtzhlx,
            this.DgvColTxtyhlxmc,
            this.DgvColTxtzhmc,
            this.DgvColTxtzh,
            this.DgvColTxtzhxzmc,
            this.DgvColTxtkhh,
            this.DgvColTxtzt,
            this.DgvColTxtDqmc,
            this.DgvColTxtyhlxid});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
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
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 37);
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
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(1027, 485);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellContentDoubleClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellContentDoubleClick);
            // 
            // DgvColTxtzhlx
            // 
            this.DgvColTxtzhlx.DataPropertyName = "zhlxmc";
            this.DgvColTxtzhlx.FillWeight = 119.3254F;
            this.DgvColTxtzhlx.Frozen = true;
            this.DgvColTxtzhlx.HeaderText = "账户类型";
            this.DgvColTxtzhlx.Name = "DgvColTxtzhlx";
            this.DgvColTxtzhlx.ReadOnly = true;
            this.DgvColTxtzhlx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtyhlxmc
            // 
            this.DgvColTxtyhlxmc.DataPropertyName = "yhlxmc";
            this.DgvColTxtyhlxmc.FillWeight = 150F;
            this.DgvColTxtyhlxmc.Frozen = true;
            this.DgvColTxtyhlxmc.HeaderText = "银行名称";
            this.DgvColTxtyhlxmc.Name = "DgvColTxtyhlxmc";
            this.DgvColTxtyhlxmc.ReadOnly = true;
            this.DgvColTxtyhlxmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtzhmc
            // 
            this.DgvColTxtzhmc.DataPropertyName = "zhmc";
            this.DgvColTxtzhmc.FillWeight = 150F;
            this.DgvColTxtzhmc.Frozen = true;
            this.DgvColTxtzhmc.HeaderText = "户名";
            this.DgvColTxtzhmc.Name = "DgvColTxtzhmc";
            this.DgvColTxtzhmc.ReadOnly = true;
            this.DgvColTxtzhmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtzhmc.Width = 150;
            // 
            // DgvColTxtzh
            // 
            this.DgvColTxtzh.DataPropertyName = "zh";
            this.DgvColTxtzh.FillWeight = 150F;
            this.DgvColTxtzh.HeaderText = "账号";
            this.DgvColTxtzh.Name = "DgvColTxtzh";
            this.DgvColTxtzh.ReadOnly = true;
            this.DgvColTxtzh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtzh.Width = 150;
            // 
            // DgvColTxtzhxzmc
            // 
            this.DgvColTxtzhxzmc.DataPropertyName = "zhxzmc";
            this.DgvColTxtzhxzmc.FillWeight = 40F;
            this.DgvColTxtzhxzmc.HeaderText = "性质";
            this.DgvColTxtzhxzmc.Name = "DgvColTxtzhxzmc";
            this.DgvColTxtzhxzmc.ReadOnly = true;
            this.DgvColTxtzhxzmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtzhxzmc.Width = 60;
            // 
            // DgvColTxtkhh
            // 
            this.DgvColTxtkhh.DataPropertyName = "khh";
            this.DgvColTxtkhh.FillWeight = 98.76278F;
            this.DgvColTxtkhh.HeaderText = "开户行";
            this.DgvColTxtkhh.Name = "DgvColTxtkhh";
            this.DgvColTxtkhh.ReadOnly = true;
            this.DgvColTxtkhh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtzt
            // 
            this.DgvColTxtzt.DataPropertyName = "ztmc";
            this.DgvColTxtzt.FillWeight = 40F;
            this.DgvColTxtzt.HeaderText = "状态";
            this.DgvColTxtzt.Name = "DgvColTxtzt";
            this.DgvColTxtzt.ReadOnly = true;
            this.DgvColTxtzt.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtzt.Width = 60;
            // 
            // DgvColTxtDqmc
            // 
            this.DgvColTxtDqmc.DataPropertyName = "dqmc";
            this.DgvColTxtDqmc.HeaderText = "大区名称";
            this.DgvColTxtDqmc.Name = "DgvColTxtDqmc";
            this.DgvColTxtDqmc.ReadOnly = true;
            // 
            // DgvColTxtyhlxid
            // 
            this.DgvColTxtyhlxid.DataPropertyName = "yhlxid";
            this.DgvColTxtyhlxid.HeaderText = "yhlxid";
            this.DgvColTxtyhlxid.Name = "DgvColTxtyhlxid";
            this.DgvColTxtyhlxid.ReadOnly = true;
            this.DgvColTxtyhlxid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtyhlxid.Visible = false;
            // 
            // VyhzhTableAdapter1
            // 
            this.VyhzhTableAdapter1.ClearBeforeFill = true;
            // 
            // TjigouTableAdapter1
            // 
            this.TjigouTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmYHZHWH
            // 
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTree);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(-131, 0);
            this.Size = new System.Drawing.Size(1287, 522);
            this.Text = "FrmYHZHWH";
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSYHZHWH1)).EndInit();
            this.PnlTree.ResumeLayout(false);
            this.PnlTreeTop.ResumeLayout(false);
            this.PnlBtns.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BindingSource Bds; 
        private Panel PnlTree;
        private TreeView TrV;
        private ContextMenu CTxtMnu1;
        private MenuItem MnuNew;
        private Panel PnlBtns;
        private Button BtnDel;
        private Button BtnEdit;
        private Button BtnNew;
        private Panel PnlMain;
        private DataGridView Dgv;
        //private DataGridViewTextBoxColumn DgvColTxtwybm;
        //private DataGridViewTextBoxColumn DgvColTxtywlxmc;
        //private DataGridViewTextBoxColumn DgvColTxtyhmc;
        //private DataGridViewTextBoxColumn DgvColTxtzhxz;
        //private DataGridViewTextBoxColumn DgvColTxtzh;
        //private DataGridViewTextBoxColumn DgvColTxtzhmc;
        //private DataGridViewTextBoxColumn DgvColTxtkhh;
        //private DataGridViewTextBoxColumn DgvColTxtkhhdm;
        //private DataGridViewTextBoxColumn DgvColTxtye;
        private DSYHZHWHTableAdapters.VyhzhTableAdapter VyhzhTableAdapter1;
        private DataGridViewTextBoxColumn DgvColTxtyhlxmc;
        private DataGridViewTextBoxColumn DgvColTxtzhxzmc;
        private DataGridViewTextBoxColumn DgvColTxtzh;
        private DataGridViewTextBoxColumn DgvColTxtzhmc;
        private DataGridViewTextBoxColumn DgvColTxtkhh;
        private DataGridViewTextBoxColumn DgvColTxtzt;
        private DSYHZHWH DSYHZHWH1;
        private DSYHZHWHTableAdapters.tjigouTableAdapter TjigouTableAdapter1;
        private DataGridViewTextBoxColumn DgvColTxtzhlx;
        private DataGridViewTextBoxColumn DgvColTxtyhlxid;
        private Button BtnSx;
        private Button BtnSelect;
        private TextBox TxtCZ;
        private Panel PnlTreeTop;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private DataGridViewTextBoxColumn DgvColTxtDqmc;
        //private ListBox listBox1; 
    }
}