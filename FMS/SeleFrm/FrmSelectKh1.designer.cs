using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.SeleFrm
{
    partial class FrmSelectKh1
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.BtnClose = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.BtnClear = new Gizmox.WebGUI.Forms.Button();
            this.TxtKhmc = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnQuery = new Gizmox.WebGUI.Forms.Button();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.TxtKhbh = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtKhbh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtKhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtTel = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtDz = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtLxr = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtkhid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSkh1 = new FMS.SeleFrm.DSKH();
            this.DgvColTxtJGBH = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJGMC = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.TkhTableAdapter1 = new FMS.SeleFrm.DSKHTableAdapters.TkhTableAdapter();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSkh1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.CustomStyle = "F";
            this.BtnClose.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Location = new System.Drawing.Point(217, 45);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 5;
            this.BtnClose.Text = "关闭";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户名称";
            // 
            // BtnClear
            // 
            this.BtnClear.CustomStyle = "F";
            this.BtnClear.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnClear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear.Location = new System.Drawing.Point(114, 45);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(75, 23);
            this.BtnClear.TabIndex = 4;
            this.BtnClear.Text = "清除";
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // TxtKhmc
            // 
            this.TxtKhmc.AllowDrag = false;
            this.TxtKhmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtKhmc.Location = new System.Drawing.Point(67, 14);
            this.TxtKhmc.Name = "TxtKhmc";
            this.TxtKhmc.Size = new System.Drawing.Size(124, 21);
            this.TxtKhmc.TabIndex = 1;
            // 
            // BtnQuery
            // 
            this.BtnQuery.CustomStyle = "F";
            this.BtnQuery.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuery.Location = new System.Drawing.Point(11, 45);
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Size = new System.Drawing.Size(75, 23);
            this.BtnQuery.TabIndex = 3;
            this.BtnQuery.Text = "查询";
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.TxtKhbh);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.BtnClose);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Controls.Add(this.BtnClear);
            this.PnlTop.Controls.Add(this.TxtKhmc);
            this.PnlTop.Controls.Add(this.BtnQuery);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(514, 80);
            this.PnlTop.TabIndex = 5;
            // 
            // TxtKhbh
            // 
            this.TxtKhbh.AllowDrag = false;
            this.TxtKhbh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtKhbh.Location = new System.Drawing.Point(271, 14);
            this.TxtKhbh.Name = "TxtKhbh";
            this.TxtKhbh.Size = new System.Drawing.Size(124, 21);
            this.TxtKhbh.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(213, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "客户编号";
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToOrderColumns = true;
            this.Dgv.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.AutoGenerateColumns = false;
            this.Dgv.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
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
            this.DgvColTxtKhbh,
            this.DgvColTxtKhmc,
            this.DgvColTxtTel,
            this.DgvColTxtDz,
            this.DgvColTxtLxr,
            this.DgvColTxtkhid});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 80);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv.RowHeadersWidth = 10;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(514, 423);
            this.Dgv.TabIndex = 3;
            this.Dgv.CellDoubleClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellDoubleClick);
            // 
            // DgvColTxtKhbh
            // 
            this.DgvColTxtKhbh.DataPropertyName = "bh";
            this.DgvColTxtKhbh.HeaderText = "客户编号";
            this.DgvColTxtKhbh.Name = "DgvColTxtKhbh";
            this.DgvColTxtKhbh.ReadOnly = true;
            // 
            // DgvColTxtKhmc
            // 
            this.DgvColTxtKhmc.DataPropertyName = "mc";
            this.DgvColTxtKhmc.HeaderText = "客户名称";
            this.DgvColTxtKhmc.Name = "DgvColTxtKhmc";
            this.DgvColTxtKhmc.ReadOnly = true;
            // 
            // DgvColTxtTel
            // 
            this.DgvColTxtTel.DataPropertyName = "tel";
            this.DgvColTxtTel.HeaderText = "联系电话";
            this.DgvColTxtTel.Name = "DgvColTxtTel";
            this.DgvColTxtTel.ReadOnly = true;
            // 
            // DgvColTxtDz
            // 
            this.DgvColTxtDz.DataPropertyName = "address";
            this.DgvColTxtDz.HeaderText = "详细地址";
            this.DgvColTxtDz.Name = "DgvColTxtDz";
            this.DgvColTxtDz.ReadOnly = true;
            // 
            // DgvColTxtLxr
            // 
            this.DgvColTxtLxr.DataPropertyName = "lxr";
            this.DgvColTxtLxr.HeaderText = "联系人";
            this.DgvColTxtLxr.Name = "DgvColTxtLxr";
            this.DgvColTxtLxr.ReadOnly = true;
            // 
            // DgvColTxtkhid
            // 
            this.DgvColTxtkhid.DataPropertyName = "id";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtkhid.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtkhid.FillWeight = 80F;
            this.DgvColTxtkhid.HeaderText = "Id[隐藏]";
            this.DgvColTxtkhid.Name = "DgvColTxtkhid";
            this.DgvColTxtkhid.ReadOnly = true;
            this.DgvColTxtkhid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtkhid.Visible = false;
            this.DgvColTxtkhid.Width = 80;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Tkh";
            this.Bds.DataSource = this.DSkh1;
            // 
            // DSkh1
            // 
            this.DSkh1.DataSetName = "DSKH";
            this.DSkh1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DgvColTxtJGBH
            // 
            this.DgvColTxtJGBH.DataPropertyName = "id";
            this.DgvColTxtJGBH.HeaderText = "编号";
            this.DgvColTxtJGBH.Name = "DgvColTxtJGBH";
            // 
            // DgvColTxtJGMC
            // 
            this.DgvColTxtJGMC.DataPropertyName = "mc";
            this.DgvColTxtJGMC.HeaderText = "机构名称";
            this.DgvColTxtJGMC.Name = "DgvColTxtJGMC";
            this.DgvColTxtJGMC.Width = 200;
            // 
            // TkhTableAdapter1
            // 
            this.TkhTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmSelectKh1
            // 
            this.AcceptButton = this.BtnQuery;
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(514, 503);
            this.Text = "客户查询";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSkh1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnClose;
        private Label label1;
        private Button BtnClear;
        private TextBox TxtKhmc;
        private Button BtnQuery;
        private Panel PnlTop;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtJGBH;
        private DataGridViewTextBoxColumn DgvColTxtJGMC;
        private BindingSource Bds;
        private DataGridViewTextBoxColumn DgvColTxtKhbh;
        private DataGridViewTextBoxColumn DgvColTxtKhmc;
        private DataGridViewTextBoxColumn DgvColTxtTel;
        private DataGridViewTextBoxColumn DgvColTxtDz;
        private DataGridViewTextBoxColumn DgvColTxtLxr;
        private DSKH DSkh1;
        private DSKHTableAdapters.TkhTableAdapter TkhTableAdapter1;
        private TextBox TxtKhbh;
        private Label label2;
        private DataGridViewTextBoxColumn DgvColTxtkhid;


    }
}