using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.POSBMWH
{
    partial class FrmPosBmwh
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
            this.TrV = new Gizmox.WebGUI.Forms.TreeView();
            this.BtnSelect = new Gizmox.WebGUI.Forms.Button();
            this.TxtCZ = new Gizmox.WebGUI.Forms.TextBox();
            this.PnlTreeTop = new Gizmox.WebGUI.Forms.Panel();
            this.PnlTree = new Gizmox.WebGUI.Forms.Panel();
            this.BtnDel = new Gizmox.WebGUI.Forms.Button();
            this.BtnEdit = new Gizmox.WebGUI.Forms.Button();
            this.BtnNew = new Gizmox.WebGUI.Forms.Button();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnElse = new Gizmox.WebGUI.Forms.Button();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtJgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtPosBh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSPOSWH1 = new FMS.ZYGL.POSBMWH.DSPOSWH();
            this.TjigouTableAdapter1 = new FMS.ZYGL.POSBMWH.DSPOSWHTableAdapters.tjigouTableAdapter();
            this.PnlTreeTop.SuspendLayout();
            this.PnlTree.SuspendLayout();
            this.PnlBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPOSWH1)).BeginInit();
            this.SuspendLayout();
            // 
            // TrV
            // 
            this.TrV.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.LightBlue);
            this.TrV.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.TrV.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrV.Location = new System.Drawing.Point(0, 37);
            this.TrV.Name = "TrV";
            this.TrV.SelectOnRightClick = true;
            this.TrV.Size = new System.Drawing.Size(260, 526);
            this.TrV.TabIndex = 0;
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
            // PnlTree
            // 
            this.PnlTree.Controls.Add(this.TrV);
            this.PnlTree.Controls.Add(this.PnlTreeTop);
            this.PnlTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.PnlTree.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTree.Location = new System.Drawing.Point(0, 0);
            this.PnlTree.Name = "PnlTree";
            this.PnlTree.Size = new System.Drawing.Size(260, 563);
            this.PnlTree.TabIndex = 2;
            // 
            // BtnDel
            // 
            this.BtnDel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnDel.CustomStyle = "F";
            this.BtnDel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDel.Location = new System.Drawing.Point(261, 7);
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
            this.BtnEdit.Location = new System.Drawing.Point(151, 7);
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
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.BtnElse);
            this.PnlBtns.Controls.Add(this.BtnDel);
            this.PnlBtns.Controls.Add(this.BtnEdit);
            this.PnlBtns.Controls.Add(this.BtnNew);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(260, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(750, 37);
            this.PnlBtns.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(481, 3);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 4;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnElse
            // 
            this.BtnElse.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnElse.CustomStyle = "F";
            this.BtnElse.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnElse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnElse.Location = new System.Drawing.Point(371, 7);
            this.BtnElse.Name = "BtnElse";
            this.BtnElse.Size = new System.Drawing.Size(75, 23);
            this.BtnElse.TabIndex = 3;
            this.BtnElse.Text = "导出";
            this.BtnElse.Click += new System.EventHandler(this.BtnElse_Click);
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
            this.DgvColTxtPosBh});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
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
            this.Dgv.Location = new System.Drawing.Point(260, 37);
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
            this.Dgv.Size = new System.Drawing.Size(750, 526);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColTxtJgmc
            // 
            this.DgvColTxtJgmc.DataPropertyName = "mc";
            this.DgvColTxtJgmc.HeaderText = "机构名称";
            this.DgvColTxtJgmc.Name = "DgvColTxtJgmc";
            this.DgvColTxtJgmc.ReadOnly = true;
            this.DgvColTxtJgmc.Width = 180;
            // 
            // DgvColTxtPosBh
            // 
            this.DgvColTxtPosBh.DataPropertyName = "posbh";
            this.DgvColTxtPosBh.HeaderText = "POS编号";
            this.DgvColTxtPosBh.Name = "DgvColTxtPosBh";
            this.DgvColTxtPosBh.ReadOnly = true;
            this.DgvColTxtPosBh.Width = 150;
            // 
            // Bds
            // 
            this.Bds.DataMember = "tjigou";
            this.Bds.DataSource = this.DSPOSWH1;
            // 
            // DSPOSWH1
            // 
            this.DSPOSWH1.DataSetName = "DSPOSWH";
            this.DSPOSWH1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TjigouTableAdapter1
            // 
            this.TjigouTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmPosBmwh
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlBtns);
            this.Controls.Add(this.PnlTree);
            this.Size = new System.Drawing.Size(1010, 563);
            this.Text = "FrmPosBmwh";
            this.PnlTreeTop.ResumeLayout(false);
            this.PnlTree.ResumeLayout(false);
            this.PnlBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPOSWH1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TreeView TrV;
        private Button BtnSelect;
        private TextBox TxtCZ;
        private Panel PnlTreeTop;
        private Panel PnlTree;
        
        private Button BtnDel;
        private Button BtnEdit;
        private Button BtnNew;
        private Panel PnlBtns;
        private DataGridView Dgv;
        private DSPOSWH DSPOSWH1;
        private DSPOSWHTableAdapters.tjigouTableAdapter TjigouTableAdapter1;
        private BindingSource Bds;
       
        private DataGridViewTextBoxColumn DgvColTxtJgmc;
        private DataGridViewTextBoxColumn DgvColTxtPosBh;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnElse;



    }
}