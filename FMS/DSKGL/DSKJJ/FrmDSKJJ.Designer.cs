using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKJJ
{
    partial class FrmDSKJJ
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PmlTop = new Gizmox.WebGUI.Forms.Panel();
            this.LblTs = new Gizmox.WebGUI.Forms.Label();
            this.BtnKSXZ = new Gizmox.WebGUI.Forms.Button();
            this.TxtBh = new Gizmox.WebGUI.Forms.TextBox();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.CmbJjzt = new Gizmox.WebGUI.Forms.ComboBox();
            this.TxtFhflxfs = new Gizmox.WebGUI.Forms.TextBox();
            this.TxtBKhmc = new Gizmox.WebGUI.Forms.TextBox();
            this.TxtBFwkh = new Gizmox.WebGUI.Forms.TextBox();
            this.TxtBYdbh = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnEl = new Gizmox.WebGUI.Forms.Button();
            this.BtnQxjj = new Gizmox.WebGUI.Forms.Button();
            this.BtnJj = new Gizmox.WebGUI.Forms.Button();
            this.BtnByqx = new Gizmox.WebGUI.Forms.Button();
            this.BtnSel = new Gizmox.WebGUI.Forms.Button();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvChkBQx = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.DgvColTxtydbh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtDsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtFwkh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtKhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtyhlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtjjzt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSDSKJJ1 = new FMS.DSKGL.DSKJJ.DSDSKJJ();
            this.VfmsDskjjTableAdapter1 = new FMS.DSKGL.DSKJJ.DSDSKJJTableAdapters.VfmsDskjjTableAdapter();
            this.Check = new Gizmox.WebGUI.Forms.CheckBox();
            this.PmlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDSKJJ1)).BeginInit();
            this.SuspendLayout();
            // 
            // PmlTop
            // 
            this.PmlTop.Controls.Add(this.LblTs);
            this.PmlTop.Controls.Add(this.BtnKSXZ);
            this.PmlTop.Controls.Add(this.TxtBh);
            this.PmlTop.Controls.Add(this.ctrlDownLoad1);
            this.PmlTop.Controls.Add(this.CmbJjzt);
            this.PmlTop.Controls.Add(this.TxtFhflxfs);
            this.PmlTop.Controls.Add(this.TxtBKhmc);
            this.PmlTop.Controls.Add(this.TxtBFwkh);
            this.PmlTop.Controls.Add(this.TxtBYdbh);
            this.PmlTop.Controls.Add(this.BtnEl);
            this.PmlTop.Controls.Add(this.BtnQxjj);
            this.PmlTop.Controls.Add(this.BtnJj);
            this.PmlTop.Controls.Add(this.BtnByqx);
            this.PmlTop.Controls.Add(this.BtnSel);
            this.PmlTop.Controls.Add(this.label5);
            this.PmlTop.Controls.Add(this.label4);
            this.PmlTop.Controls.Add(this.label3);
            this.PmlTop.Controls.Add(this.label2);
            this.PmlTop.Controls.Add(this.label1);
            this.PmlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PmlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PmlTop.Location = new System.Drawing.Point(0, 0);
            this.PmlTop.Name = "PmlTop";
            this.PmlTop.Size = new System.Drawing.Size(814, 107);
            this.PmlTop.TabIndex = 0;
            // 
            // LblTs
            // 
            this.LblTs.AutoSize = true;
            this.LblTs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTs.ForeColor = System.Drawing.Color.Red;
            this.LblTs.Location = new System.Drawing.Point(734, 50);
            this.LblTs.Name = "LblTs";
            this.LblTs.Size = new System.Drawing.Size(53, 12);
            this.LblTs.TabIndex = 4;
            this.LblTs.Text = "提示";
            this.LblTs.Visible = false;
            // 
            // BtnKSXZ
            // 
            this.BtnKSXZ.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnKSXZ.CustomStyle = "F";
            this.BtnKSXZ.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnKSXZ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnKSXZ.Location = new System.Drawing.Point(529, 44);
            this.BtnKSXZ.Name = "BtnKSXZ";
            this.BtnKSXZ.Size = new System.Drawing.Size(75, 23);
            this.BtnKSXZ.TabIndex = 7;
            this.BtnKSXZ.Text = "快速选择";
            this.BtnKSXZ.Click += new System.EventHandler(this.BtnKSXZ_Click);
            // 
            // TxtBh
            // 
            this.TxtBh.AllowDrag = false;
            this.TxtBh.Location = new System.Drawing.Point(619, 45);
            this.TxtBh.Name = "TxtBh";
            this.TxtBh.Size = new System.Drawing.Size(100, 21);
            this.TxtBh.TabIndex = 18;
            this.TxtBh.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.TxtBh_EnterKeyDown);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(490, 73);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 17;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // CmbJjzt
            // 
            this.CmbJjzt.AllowDrag = false;
            this.CmbJjzt.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbJjzt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbJjzt.FormattingEnabled = true;
            this.CmbJjzt.Items.AddRange(new object[] {
            "不加急",
            "加急"});
            this.CmbJjzt.Location = new System.Drawing.Point(528, 16);
            this.CmbJjzt.Name = "CmbJjzt";
            this.CmbJjzt.Size = new System.Drawing.Size(76, 20);
            this.CmbJjzt.TabIndex = 15;
            // 
            // TxtFhflxfs
            // 
            this.TxtFhflxfs.AllowDrag = false;
            this.TxtFhflxfs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFhflxfs.Location = new System.Drawing.Point(331, 46);
            this.TxtFhflxfs.Name = "TxtFhflxfs";
            this.TxtFhflxfs.Size = new System.Drawing.Size(158, 21);
            this.TxtFhflxfs.TabIndex = 14;
            this.TxtFhflxfs.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.TxtFhflxfs_EnterKeyDown);
            // 
            // TxtBKhmc
            // 
            this.TxtBKhmc.AllowDrag = false;
            this.TxtBKhmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBKhmc.Location = new System.Drawing.Point(69, 46);
            this.TxtBKhmc.Name = "TxtBKhmc";
            this.TxtBKhmc.Size = new System.Drawing.Size(158, 21);
            this.TxtBKhmc.TabIndex = 13;
            this.TxtBKhmc.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.TxtBKhmc_EnterKeyDown);
            // 
            // TxtBFwkh
            // 
            this.TxtBFwkh.AllowDrag = false;
            this.TxtBFwkh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBFwkh.Location = new System.Drawing.Point(294, 17);
            this.TxtBFwkh.Name = "TxtBFwkh";
            this.TxtBFwkh.Size = new System.Drawing.Size(158, 21);
            this.TxtBFwkh.TabIndex = 12;
            this.TxtBFwkh.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.TxtBFwkh_EnterKeyDown);
            // 
            // TxtBYdbh
            // 
            this.TxtBYdbh.AllowDrag = false;
            this.TxtBYdbh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBYdbh.Location = new System.Drawing.Point(69, 17);
            this.TxtBYdbh.Name = "TxtBYdbh";
            this.TxtBYdbh.Size = new System.Drawing.Size(158, 21);
            this.TxtBYdbh.TabIndex = 11;
            this.TxtBYdbh.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.TxtBYdbh_EnterKeyDown);
            // 
            // BtnEl
            // 
            this.BtnEl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnEl.CustomStyle = "F";
            this.BtnEl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnEl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEl.Location = new System.Drawing.Point(396, 75);
            this.BtnEl.Name = "BtnEl";
            this.BtnEl.Size = new System.Drawing.Size(75, 23);
            this.BtnEl.TabIndex = 9;
            this.BtnEl.Text = "导出";
            this.BtnEl.Click += new System.EventHandler(this.BtnEl_Click);
            // 
            // BtnQxjj
            // 
            this.BtnQxjj.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnQxjj.CustomStyle = "F";
            this.BtnQxjj.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQxjj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQxjj.Location = new System.Drawing.Point(302, 75);
            this.BtnQxjj.Name = "BtnQxjj";
            this.BtnQxjj.Size = new System.Drawing.Size(75, 23);
            this.BtnQxjj.TabIndex = 8;
            this.BtnQxjj.Text = "取消加急";
            this.BtnQxjj.Click += new System.EventHandler(this.BtnQxjj_Click);
            // 
            // BtnJj
            // 
            this.BtnJj.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnJj.CustomStyle = "F";
            this.BtnJj.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnJj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnJj.Location = new System.Drawing.Point(208, 75);
            this.BtnJj.Name = "BtnJj";
            this.BtnJj.Size = new System.Drawing.Size(75, 23);
            this.BtnJj.TabIndex = 7;
            this.BtnJj.Text = "加急";
            this.BtnJj.Click += new System.EventHandler(this.BtnJj_Click);
            // 
            // BtnByqx
            // 
            this.BtnByqx.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnByqx.CustomStyle = "F";
            this.BtnByqx.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnByqx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnByqx.Location = new System.Drawing.Point(114, 75);
            this.BtnByqx.Name = "BtnByqx";
            this.BtnByqx.Size = new System.Drawing.Size(75, 23);
            this.BtnByqx.TabIndex = 6;
            this.BtnByqx.Text = "本页全选";
            this.BtnByqx.Click += new System.EventHandler(this.BtnByqx_Click);
            // 
            // BtnSel
            // 
            this.BtnSel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSel.CustomStyle = "F";
            this.BtnSel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSel.Location = new System.Drawing.Point(29, 75);
            this.BtnSel.Name = "BtnSel";
            this.BtnSel.Size = new System.Drawing.Size(75, 23);
            this.BtnSel.TabIndex = 5;
            this.BtnSel.Text = "查询";
            this.BtnSel.Click += new System.EventHandler(this.BtnSel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(471, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "加急状态";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(238, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "发货方联系方式";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "客户名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(238, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "服务卡号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "货运单号";
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowDragTargetsPropagation = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.AutoGenerateColumns = false;
            this.Dgv.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.DgvChkBQx,
            this.DgvColTxtydbh,
            this.DgvColTxtDsk,
            this.DgvColTxtFwkh,
            this.DgvColTxtKhmc,
            this.dgvtxtyhlx,
            this.DgvColTxtjjzt,
            this.DgvColTxtid});
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
            this.Dgv.Location = new System.Drawing.Point(0, 107);
            this.Dgv.Name = "Dgv";
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
            this.Dgv.Size = new System.Drawing.Size(814, 305);
            this.Dgv.TabIndex = 1;
            // 
            // DgvChkBQx
            // 
            this.DgvChkBQx.FillWeight = 60F;
            this.DgvChkBQx.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.DgvChkBQx.HeaderText = "选择";
            this.DgvChkBQx.Name = "DgvChkBQx";
            this.DgvChkBQx.Width = 60;
            // 
            // DgvColTxtydbh
            // 
            this.DgvColTxtydbh.DataPropertyName = "bh";
            this.DgvColTxtydbh.HeaderText = "货运单号";
            this.DgvColTxtydbh.Name = "DgvColTxtydbh";
            this.DgvColTxtydbh.ReadOnly = true;
            this.DgvColTxtydbh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtDsk
            // 
            this.DgvColTxtDsk.DataPropertyName = "dsk";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtDsk.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtDsk.HeaderText = "代收款金额";
            this.DgvColTxtDsk.Name = "DgvColTxtDsk";
            this.DgvColTxtDsk.ReadOnly = true;
            this.DgvColTxtDsk.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtFwkh
            // 
            this.DgvColTxtFwkh.DataPropertyName = "dskkhbh";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtFwkh.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtFwkh.HeaderText = "服务卡号";
            this.DgvColTxtFwkh.Name = "DgvColTxtFwkh";
            this.DgvColTxtFwkh.ReadOnly = true;
            this.DgvColTxtFwkh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtKhmc
            // 
            this.DgvColTxtKhmc.DataPropertyName = "mc";
            this.DgvColTxtKhmc.HeaderText = "客户名称";
            this.DgvColTxtKhmc.Name = "DgvColTxtKhmc";
            this.DgvColTxtKhmc.ReadOnly = true;
            this.DgvColTxtKhmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvtxtyhlx
            // 
            this.dgvtxtyhlx.DataPropertyName = "yhmc";
            this.dgvtxtyhlx.HeaderText = "银行类型";
            this.dgvtxtyhlx.Name = "dgvtxtyhlx";
            this.dgvtxtyhlx.Width = 130;
            // 
            // DgvColTxtjjzt
            // 
            this.DgvColTxtjjzt.DataPropertyName = "jjzt";
            this.DgvColTxtjjzt.HeaderText = "加急状态";
            this.DgvColTxtjjzt.Name = "DgvColTxtjjzt";
            this.DgvColTxtjjzt.ReadOnly = true;
            this.DgvColTxtjjzt.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtid
            // 
            this.DgvColTxtid.DataPropertyName = "id";
            this.DgvColTxtid.HeaderText = "id";
            this.DgvColTxtid.Name = "DgvColTxtid";
            this.DgvColTxtid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtid.Visible = false;
            // 
            // Bds
            // 
            this.Bds.DataMember = "VfmsDskjj";
            this.Bds.DataSource = this.DSDSKJJ1;
            // 
            // DSDSKJJ1
            // 
            this.DSDSKJJ1.DataSetName = "DSDSKJJ";
            this.DSDSKJJ1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmsDskjjTableAdapter1
            // 
            this.VfmsDskjjTableAdapter1.ClearBeforeFill = true;
            // 
            // Check
            // 
            this.Check.AutoSize = true;
            this.Check.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.Check.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Check.Location = new System.Drawing.Point(42, 110);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(15, 14);
            this.Check.TabIndex = 2;
            this.Check.CheckedChanged += new System.EventHandler(this.Check_CheckedChanged);
            // 
            // FrmDSKJJ
            // 
            this.Controls.Add(this.Check);
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PmlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(814, 412);
            this.Text = "FrmDSKJJ";
            this.PmlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDSKJJ1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PmlTop;
        private DataGridView Dgv;
        private ComboBox CmbJjzt;
        private TextBox TxtFhflxfs;
        private TextBox TxtBKhmc;
        private TextBox TxtBFwkh;
        private TextBox TxtBYdbh;
        private Button BtnEl;
        private Button BtnQxjj;
        private Button BtnJj;
        private Button BtnByqx;
        private Button BtnSel;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DSDSKJJ DSDSKJJ1;
        private DSDSKJJTableAdapters.VfmsDskjjTableAdapter VfmsDskjjTableAdapter1;
        private BindingSource Bds;
        private DataGridViewCheckBoxColumn DgvChkBQx;
        private DataGridViewTextBoxColumn DgvColTxtydbh;
        private DataGridViewTextBoxColumn DgvColTxtDsk;
        private DataGridViewTextBoxColumn DgvColTxtFwkh;
        private DataGridViewTextBoxColumn DgvColTxtKhmc;
        private DataGridViewTextBoxColumn DgvColTxtjjzt;
        private DataGridViewTextBoxColumn DgvColTxtid;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private CheckBox Check;
        private DataGridViewTextBoxColumn dgvtxtyhlx;
        private Label LblTs;
        private Button BtnKSXZ;
        private TextBox TxtBh;


    }
}