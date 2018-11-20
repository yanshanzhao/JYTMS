using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.DSKCKLCX_FKFS
{
    partial class FrmDSKCKLSelect_FKFS
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.DgvColTxtByyc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.CmbMonth = new Gizmox.WebGUI.Forms.ComboBox();
            this.BtnQuery = new Gizmox.WebGUI.Forms.Button();
            this.lblCXYF = new Gizmox.WebGUI.Forms.Label();
            this.lblJG = new Gizmox.WebGUI.Forms.Label();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.PnlBottom = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtJgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtLjwc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtBysc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJsl = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvLnkXx = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtJgid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.lb3 = new Gizmox.WebGUI.Forms.Label();
            this.lbl2 = new Gizmox.WebGUI.Forms.Label();
            this.lbl1 = new Gizmox.WebGUI.Forms.Label();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad2 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnClear = new Gizmox.WebGUI.Forms.Button();
            this.TxtJgmc = new Gizmox.WebGUI.Forms.TextBox();
            this.TxtJg = new Gizmox.WebGUI.Forms.TextBox();
            this.PnlJgcx = new Gizmox.WebGUI.Forms.Panel();
            this.LstV = new Gizmox.WebGUI.Forms.ListView();
            this.CmbYear = new Gizmox.WebGUI.Forms.ComboBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.CmbFKFS = new Gizmox.WebGUI.Forms.ComboBox();
            this.PnlMain.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.PnlBtns.SuspendLayout();
            this.PnlJgcx.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvColTxtByyc
            // 
            this.DgvColTxtByyc.DataPropertyName = "byyc";
            this.DgvColTxtByyc.HeaderText = "本月应存金额";
            this.DgvColTxtByyc.Name = "DgvColTxtByyc";
            this.DgvColTxtByyc.ReadOnly = true;
            this.DgvColTxtByyc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CmbMonth
            // 
            this.CmbMonth.AllowDrag = false;
            this.CmbMonth.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbMonth.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmbMonth.FormattingEnabled = true;
            this.CmbMonth.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.CmbMonth.Location = new System.Drawing.Point(500, 16);
            this.CmbMonth.Name = "CmbMonth";
            this.CmbMonth.Size = new System.Drawing.Size(92, 20);
            this.CmbMonth.TabIndex = 5;
            // 
            // BtnQuery
            // 
            this.BtnQuery.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnQuery.CustomStyle = "F";
            this.BtnQuery.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnQuery.Location = new System.Drawing.Point(16, 44);
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Size = new System.Drawing.Size(75, 23);
            this.BtnQuery.TabIndex = 4;
            this.BtnQuery.Text = "查询";
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // lblCXYF
            // 
            this.lblCXYF.AutoSize = true;
            this.lblCXYF.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCXYF.Location = new System.Drawing.Point(471, 20);
            this.lblCXYF.Name = "lblCXYF";
            this.lblCXYF.Size = new System.Drawing.Size(29, 12);
            this.lblCXYF.TabIndex = 3;
            this.lblCXYF.Text = "月份";
            // 
            // lblJG
            // 
            this.lblJG.AutoSize = true;
            this.lblJG.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblJG.Location = new System.Drawing.Point(14, 20);
            this.lblJG.Name = "lblJG";
            this.lblJG.Size = new System.Drawing.Size(29, 12);
            this.lblJG.TabIndex = 0;
            this.lblJG.Text = "机构";
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.PnlBottom);
            this.PnlMain.Controls.Add(this.PnlBtns);
            this.PnlMain.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(782, 505);
            this.PnlMain.TabIndex = 0;
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.Dgv);
            this.PnlBottom.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlBottom.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBottom.Location = new System.Drawing.Point(0, 124);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(782, 381);
            this.PnlBottom.TabIndex = 3;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToOrderColumns = true;
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
            this.DgvColTxtJgmc,
            this.DgvColTxtLjwc,
            this.DgvColTxtByyc,
            this.DgvColTxtBysc,
            this.DgvColTxtJsl,
            this.DgvLnkXx,
            this.DgvColTxtJgid});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataMember = "DSCX";
            this.Dgv.DataSource = this.DataSet1;
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
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
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
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
            this.Dgv.Size = new System.Drawing.Size(782, 381);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // DgvColTxtJgmc
            // 
            this.DgvColTxtJgmc.DataPropertyName = "jgmc";
            this.DgvColTxtJgmc.HeaderText = "大区";
            this.DgvColTxtJgmc.Name = "DgvColTxtJgmc";
            this.DgvColTxtJgmc.ReadOnly = true;
            this.DgvColTxtJgmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtLjwc
            // 
            this.DgvColTxtLjwc.DataPropertyName = "ljwc";
            this.DgvColTxtLjwc.HeaderText = "期初未存金额";
            this.DgvColTxtLjwc.Name = "DgvColTxtLjwc";
            this.DgvColTxtLjwc.ReadOnly = true;
            this.DgvColTxtLjwc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtBysc
            // 
            this.DgvColTxtBysc.DataPropertyName = "bysc";
            this.DgvColTxtBysc.HeaderText = "本月回存金额";
            this.DgvColTxtBysc.Name = "DgvColTxtBysc";
            this.DgvColTxtBysc.ReadOnly = true;
            this.DgvColTxtBysc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtJsl
            // 
            this.DgvColTxtJsl.DataPropertyName = "jsl";
            this.DgvColTxtJsl.HeaderText = "及时率";
            this.DgvColTxtJsl.Name = "DgvColTxtJsl";
            this.DgvColTxtJsl.ReadOnly = true;
            this.DgvColTxtJsl.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvLnkXx
            // 
            this.DgvLnkXx.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvLnkXx.ClientMode = false;
            this.DgvLnkXx.DataPropertyName = "xx";
            this.DgvLnkXx.HeaderText = "详细";
            this.DgvLnkXx.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvLnkXx.LinkColor = System.Drawing.Color.Empty;
            this.DgvLnkXx.Name = "DgvLnkXx";
            this.DgvLnkXx.TrackVisitedState = false;
            this.DgvLnkXx.Url = "";
            this.DgvLnkXx.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvColTxtJgid
            // 
            this.DgvColTxtJgid.DataPropertyName = "Jgid";
            this.DgvColTxtJgid.HeaderText = "机构Id[隐藏]";
            this.DgvColTxtJgid.Name = "DgvColTxtJgid";
            this.DgvColTxtJgid.Visible = false;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "NewDataSet";
            this.DataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7});
            this.dataTable1.TableName = "DSCX";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Jgid";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "jgmc";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "ljwc";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "byyc";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "bysc";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "jsl";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "xx";
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.CmbFKFS);
            this.PnlBtns.Controls.Add(this.label2);
            this.PnlBtns.Controls.Add(this.lb3);
            this.PnlBtns.Controls.Add(this.lbl2);
            this.PnlBtns.Controls.Add(this.lbl1);
            this.PnlBtns.Controls.Add(this.BtnExl);
            this.PnlBtns.Controls.Add(this.ctrlDownLoad2);
            this.PnlBtns.Controls.Add(this.BtnClear);
            this.PnlBtns.Controls.Add(this.TxtJgmc);
            this.PnlBtns.Controls.Add(this.TxtJg);
            this.PnlBtns.Controls.Add(this.PnlJgcx);
            this.PnlBtns.Controls.Add(this.CmbYear);
            this.PnlBtns.Controls.Add(this.label1);
            this.PnlBtns.Controls.Add(this.lblJG);
            this.PnlBtns.Controls.Add(this.lblCXYF);
            this.PnlBtns.Controls.Add(this.CmbMonth);
            this.PnlBtns.Controls.Add(this.BtnQuery);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(782, 124);
            this.PnlBtns.TabIndex = 2;
            // 
            // lb3
            // 
            this.lb3.AutoSize = true;
            this.lb3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb3.ForeColor = System.Drawing.Color.Green;
            this.lb3.Location = new System.Drawing.Point(18, 105);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(35, 13);
            this.lb3.TabIndex = 12;
            this.lb3.Text = "3、本月应存金额指本月签收代收款金额；本月回存金额指本月被审核通过代收款日报金额；";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.Green;
            this.lbl2.Location = new System.Drawing.Point(18, 89);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(35, 13);
            this.lbl2.TabIndex = 11;
            this.lbl2.Text = "2、期末未存金额=期初未存金额+本月应存金额-本月回存金额";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.Green;
            this.lbl1.Location = new System.Drawing.Point(18, 73);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(305, 12);
            this.lbl1.TabIndex = 10;
            this.lbl1.Text = "1、及时率=本月回存金额/(期初未存金额+本月应存金额)";
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(112, 44);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 6;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // ctrlDownLoad2
            // 
            this.ctrlDownLoad2.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad2.Location = new System.Drawing.Point(455, 40);
            this.ctrlDownLoad2.Name = "ctrlDownLoad2";
            this.ctrlDownLoad2.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad2.TabIndex = 5;
            this.ctrlDownLoad2.Text = "CtrlDownLoad";
            this.ctrlDownLoad2.Visible = false;
            // 
            // BtnClear
            // 
            this.BtnClear.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnClear.CustomStyle = "F";
            this.BtnClear.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnClear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnClear.Location = new System.Drawing.Point(280, 15);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(23, 23);
            this.BtnClear.TabIndex = 4;
            this.BtnClear.Text = "清";
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // TxtJgmc
            // 
            this.TxtJgmc.AllowDrag = false;
            this.TxtJgmc.Enabled = false;
            this.TxtJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJgmc.Location = new System.Drawing.Point(122, 16);
            this.TxtJgmc.Name = "TxtJgmc";
            this.TxtJgmc.Size = new System.Drawing.Size(155, 21);
            this.TxtJgmc.TabIndex = 9;
            // 
            // TxtJg
            // 
            this.TxtJg.AllowDrag = false;
            this.TxtJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJg.Location = new System.Drawing.Point(46, 16);
            this.TxtJg.Name = "TxtJg";
            this.TxtJg.Size = new System.Drawing.Size(70, 21);
            this.TxtJg.TabIndex = 8;
            this.TxtJg.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.TxtJg_EnterKeyDown);
            // 
            // PnlJgcx
            // 
            this.PnlJgcx.Controls.Add(this.LstV);
            this.PnlJgcx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlJgcx.Location = new System.Drawing.Point(46, 40);
            this.PnlJgcx.Name = "PnlJgcx";
            this.PnlJgcx.Size = new System.Drawing.Size(231, 215);
            this.PnlJgcx.TabIndex = 7;
            // 
            // LstV
            // 
            this.LstV.AutoGenerateColumns = true;
            this.LstV.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.LstV.DataMember = null;
            this.LstV.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.LstV.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstV.ItemsPerPage = 20;
            this.LstV.Location = new System.Drawing.Point(0, 0);
            this.LstV.Name = "LstV";
            this.LstV.ShowItemToolTips = false;
            this.LstV.Size = new System.Drawing.Size(231, 215);
            this.LstV.TabIndex = 0;
            this.LstV.KeyUp += new Gizmox.WebGUI.Forms.KeyEventHandler(this.LstV_KeyUp);
            this.LstV.LostFocus += new System.EventHandler(this.LstV_LostFocus);
            this.LstV.DoubleClick += new System.EventHandler(this.LstV_DoubleClick);
            // 
            // CmbYear
            // 
            this.CmbYear.AllowDrag = false;
            this.CmbYear.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbYear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmbYear.FormattingEnabled = true;
            this.CmbYear.Location = new System.Drawing.Point(351, 16);
            this.CmbYear.Name = "CmbYear";
            this.CmbYear.Size = new System.Drawing.Size(95, 20);
            this.CmbYear.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(322, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "年份";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(596, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "付款方式";
            // 
            // CmbFKFS
            // 
            this.CmbFKFS.AllowDrag = false;
            this.CmbFKFS.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.CmbFKFS.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmbFKFS.FormattingEnabled = true;
            this.CmbFKFS.Items.AddRange(new object[] {
            "现金",
            "POS",
            "全部"});
            this.CmbFKFS.Location = new System.Drawing.Point(659, 16);
            this.CmbFKFS.Name = "CmbFKFS";
            this.CmbFKFS.Size = new System.Drawing.Size(92, 20);
            this.CmbFKFS.TabIndex = 5;
            // 
            // FrmDSKCKLSelect_FKFS
            // 
            this.Controls.Add(this.PnlMain);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(782, 505);
            this.Text = "FrmDSKFLCX1";
            this.PnlMain.ResumeLayout(false);
            this.PnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.PnlBtns.ResumeLayout(false);
            this.PnlJgcx.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewTextBoxColumn DgvColTxtByyc;
        private ComboBox CmbMonth;
        private Button BtnQuery;
        private Label lblCXYF;
        private Label lblJG;
        private Panel PnlMain;
        private DataGridViewTextBoxColumn DgvColTxtJsl;
        private DataGridViewTextBoxColumn DgvColTxtLjwc;
        private DataGridViewTextBoxColumn DgvColTxtJgmc;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtBysc;
        private Label label1;
        private ComboBox CmbYear;
        private System.Data.DataSet DataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private DataGridViewLinkColumn DgvLnkXx;
        private DataGridViewTextBoxColumn DgvColTxtJgid;
        private System.Data.DataColumn dataColumn7;
        private Panel PnlBtns;
        private Panel PnlBottom;
        private Panel PnlJgcx;
        private ListView LstV;
        private TextBox TxtJgmc;
        private TextBox TxtJg;
        private Button BtnClear;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad2;
        private Label lbl1;
        private Label lbl2;
        private Label lb3;
        private Label label2;
        private ComboBox CmbFKFS;


    }
}