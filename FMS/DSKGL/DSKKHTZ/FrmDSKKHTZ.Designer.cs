using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKKHTZ
{
    partial class FrmDSKKHTZ
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.LblTs = new Gizmox.WebGUI.Forms.Label();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.TxtDh = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtbh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtfhkhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtfwkh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtdsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtdskzt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtUpd = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtId = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSDSKKHZT1 = new FMS.DSKGL.DSKKHTZ.DSDSKKHZT();
            this.Vfmsdskkhzt1TableAdapter1 = new FMS.DSKGL.DSKKHTZ.DSDSKKHZTTableAdapters.Vfmsdskkhzt1TableAdapter();
            this.PnlTop.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDSKKHZT1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.LblTs);
            this.PnlTop.Controls.Add(this.BtnExl);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.BtnSave);
            this.PnlTop.Controls.Add(this.TxtDh);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(633, 69);
            this.PnlTop.TabIndex = 0;
            // 
            // LblTs
            // 
            this.LblTs.AutoSize = true;
            this.LblTs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTs.ForeColor = System.Drawing.Color.Green;
            this.LblTs.Location = new System.Drawing.Point(214, 14);
            this.LblTs.Name = "LblTs";
            this.LblTs.Size = new System.Drawing.Size(35, 13);
            this.LblTs.TabIndex = 23;
            this.LblTs.Text = "只能对已签收未发放的运单进行调整";
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(137, 39);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 2;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(259, 37);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 4;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(203, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "*";
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(15, 39);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "查询";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtDh
            // 
            this.TxtDh.AllowDrag = false;
            this.TxtDh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDh.Location = new System.Drawing.Point(76, 11);
            this.TxtDh.Name = "TxtDh";
            this.TxtDh.Size = new System.Drawing.Size(124, 21);
            this.TxtDh.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "货运单号";
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 69);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(633, 499);
            this.PnlMain.TabIndex = 1;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowDragTargetsPropagation = true;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.DgvColTxtbh,
            this.DgvColTxtfhkhmc,
            this.DgvColTxtfwkh,
            this.DgvColTxtdsk,
            this.DgvColTxtdskzt,
            this.DgvColTxtUpd,
            this.DgvColTxtId,
            this.DgvColTxtzt});
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle9;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(633, 499);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellMouseDown += new Gizmox.WebGUI.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseDown);
            // 
            // DgvColTxtbh
            // 
            this.DgvColTxtbh.DataPropertyName = "bh";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtbh.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtbh.HeaderText = "货运单号";
            this.DgvColTxtbh.Name = "DgvColTxtbh";
            this.DgvColTxtbh.ReadOnly = true;
            this.DgvColTxtbh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtfhkhmc
            // 
            this.DgvColTxtfhkhmc.DataPropertyName = "fhkhmc";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtfhkhmc.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtfhkhmc.HeaderText = "发货客户名称";
            this.DgvColTxtfhkhmc.Name = "DgvColTxtfhkhmc";
            this.DgvColTxtfhkhmc.ReadOnly = true;
            this.DgvColTxtfhkhmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtfwkh
            // 
            this.DgvColTxtfwkh.DataPropertyName = "fwkh";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtfwkh.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColTxtfwkh.HeaderText = "服务卡号";
            this.DgvColTxtfwkh.Name = "DgvColTxtfwkh";
            this.DgvColTxtfwkh.ReadOnly = true;
            this.DgvColTxtfwkh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtdsk
            // 
            this.DgvColTxtdsk.DataPropertyName = "dsk";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtdsk.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvColTxtdsk.HeaderText = "代收款";
            this.DgvColTxtdsk.Name = "DgvColTxtdsk";
            this.DgvColTxtdsk.ReadOnly = true;
            this.DgvColTxtdsk.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtdskzt
            // 
            this.DgvColTxtdskzt.DataPropertyName = "dskzt";
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtdskzt.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvColTxtdskzt.HeaderText = "代收款状态";
            this.DgvColTxtdskzt.Name = "DgvColTxtdskzt";
            this.DgvColTxtdskzt.ReadOnly = true;
            this.DgvColTxtdskzt.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtUpd
            // 
            this.DgvColTxtUpd.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtUpd.ClientMode = false;
            this.DgvColTxtUpd.DataPropertyName = "Upd";
            this.DgvColTxtUpd.HeaderText = "修改";
            this.DgvColTxtUpd.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvColTxtUpd.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtUpd.Name = "DgvColTxtUpd";
            this.DgvColTxtUpd.ReadOnly = true;
            this.DgvColTxtUpd.TrackVisitedState = false;
            this.DgvColTxtUpd.Url = "";
            this.DgvColTxtUpd.VisitedLinkColor = System.Drawing.Color.Empty;
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
            // DgvColTxtzt
            // 
            this.DgvColTxtzt.DataPropertyName = "zt";
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtzt.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvColTxtzt.HeaderText = "zt[隐藏]";
            this.DgvColTxtzt.Name = "DgvColTxtzt";
            this.DgvColTxtzt.ReadOnly = true;
            this.DgvColTxtzt.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtzt.Visible = false;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsdskkhzt1";
            this.Bds.DataSource = this.DSDSKKHZT1;
            // 
            // DSDSKKHZT1
            // 
            this.DSDSKKHZT1.DataSetName = "DSDSKKHZT";
            this.DSDSKKHZT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Vfmsdskkhzt1TableAdapter1
            // 
            this.Vfmsdskkhzt1TableAdapter1.ClearBeforeFill = true;
            // 
            // FrmDSKKHTZ
            // 
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(633, 568);
            this.Text = "代收款卡号调整";
            this.PnlTop.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDSKKHZT1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private Button BtnSave;
        private TextBox TxtDh;
        private Label label1;
        private Panel PnlMain;
        private Label label2;
        private DataGridView Dgv;
        private DSDSKKHZT DSDSKKHZT1;
        private DSDSKKHZTTableAdapters.Vfmsdskkhzt1TableAdapter Vfmsdskkhzt1TableAdapter1;
        private BindingSource Bds;
        private DataGridViewTextBoxColumn DgvColTxtbh;
        private DataGridViewTextBoxColumn DgvColTxtfhkhmc;
        private DataGridViewTextBoxColumn DgvColTxtfwkh;
        private DataGridViewTextBoxColumn DgvColTxtdsk;
        private DataGridViewTextBoxColumn DgvColTxtdskzt;
        private DataGridViewLinkColumn DgvColTxtUpd;
        private DataGridViewTextBoxColumn DgvColTxtId;
        private DataGridViewTextBoxColumn DgvColTxtzt;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Label LblTs;


    }
}
