using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKKHFLWH
    {
    partial class FrmDSKKHFLWH
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtfwkh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtlhh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtfllx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvLnkCCz = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtId = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSDSKKHFLWH1 = new FMS.DSKGL.DSKKHFLWH.DSDSKKHFLWH();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.LblTs = new Gizmox.WebGUI.Forms.Label();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.TxtFwkh = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.VfmsdskkhflwhTableAdapter1 = new FMS.DSKGL.DSKKHFLWH.DSDSKKHFLWHTableAdapters.VfmsdskkhflwhTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDSKKHFLWH1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Dgv);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 473);
            this.panel1.TabIndex = 0;
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
            this.DgvColTxtfwkh,
            this.DgvColTxtmc,
            this.DgvColTxtlhh,
            this.DgvColTxtfllx,
            this.DgvLnkCCz,
            this.DgvColTxtId});
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle8;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 78);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(815, 395);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellContentDoubleClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellContentDoubleClick);
            this.Dgv.CellMouseDown += new Gizmox.WebGUI.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseDown);
            // 
            // DgvColTxtfwkh
            // 
            this.DgvColTxtfwkh.DataPropertyName = "bh";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtfwkh.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtfwkh.HeaderText = "服务卡号";
            this.DgvColTxtfwkh.Name = "DgvColTxtfwkh";
            this.DgvColTxtfwkh.ReadOnly = true;
            this.DgvColTxtfwkh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtmc
            // 
            this.DgvColTxtmc.DataPropertyName = "mc";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtmc.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtmc.HeaderText = "名称";
            this.DgvColTxtmc.Name = "DgvColTxtmc";
            this.DgvColTxtmc.ReadOnly = true;
            this.DgvColTxtmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtlhh
            // 
            this.DgvColTxtlhh.DataPropertyName = "lhh";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtlhh.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColTxtlhh.HeaderText = "联行号";
            this.DgvColTxtlhh.Name = "DgvColTxtlhh";
            this.DgvColTxtlhh.ReadOnly = true;
            this.DgvColTxtlhh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtfllx
            // 
            this.DgvColTxtfllx.DataPropertyName = "fllx";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtfllx.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvColTxtfllx.HeaderText = "费率类型";
            this.DgvColTxtfllx.Name = "DgvColTxtfllx";
            this.DgvColTxtfllx.ReadOnly = true;
            this.DgvColTxtfllx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvLnkCCz
            // 
            this.DgvLnkCCz.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvLnkCCz.ClientMode = false;
            this.DgvLnkCCz.DataPropertyName = "cz";
            this.DgvLnkCCz.HeaderText = "操作";
            this.DgvLnkCCz.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvLnkCCz.LinkColor = System.Drawing.Color.Empty;
            this.DgvLnkCCz.Name = "DgvLnkCCz";
            this.DgvLnkCCz.ReadOnly = true;
            this.DgvLnkCCz.TrackVisitedState = false;
            this.DgvLnkCCz.Url = "";
            this.DgvLnkCCz.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvColTxtId
            // 
            this.DgvColTxtId.DataPropertyName = "id";
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtId.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvColTxtId.HeaderText = "Id[隐藏]";
            this.DgvColTxtId.Name = "DgvColTxtId";
            this.DgvColTxtId.ReadOnly = true;
            this.DgvColTxtId.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtId.Visible = false;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmsdskkhflwh";
            this.Bds.DataSource = this.DSDSKKHFLWH1;
            // 
            // DSDSKKHFLWH1
            // 
            this.DSDSKKHFLWH1.DataSetName = "DSDSKKHFLWH";
            this.DSDSKKHFLWH1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LblTs);
            this.panel2.Controls.Add(this.BtnSave);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.TxtFwkh);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(815, 78);
            this.panel2.TabIndex = 0;
            // 
            // LblTs
            // 
            this.LblTs.AutoSize = true;
            this.LblTs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTs.ForeColor = System.Drawing.Color.Green;
            this.LblTs.Location = new System.Drawing.Point(107, 48);
            this.LblTs.Name = "LblTs";
            this.LblTs.Size = new System.Drawing.Size(35, 13);
            this.LblTs.TabIndex = 12;
            this.LblTs.Text = "通过本模块可维护指定代收款客户的费率和联行号";
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(14, 43);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "查询";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(174, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "*";
            // 
            // TxtFwkh
            // 
            this.TxtFwkh.AllowDrag = false;
            this.TxtFwkh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFwkh.Location = new System.Drawing.Point(71, 16);
            this.TxtFwkh.Name = "TxtFwkh";
            this.TxtFwkh.Size = new System.Drawing.Size(100, 21);
            this.TxtFwkh.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务卡号";
            // 
            // VfmsdskkhflwhTableAdapter1
            // 
            this.VfmsdskkhflwhTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmDSKKHFLWH
            // 
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(815, 473);
            this.Text = "FrmDSKKHFLWH";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDSKKHFLWH1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TextBox TxtFwkh;
        private Label label1;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtfwkh;
        private DataGridViewTextBoxColumn DgvColTxtmc;
        private DataGridViewTextBoxColumn DgvColTxtlhh;
        private DataGridViewTextBoxColumn DgvColTxtfllx;
        private Button BtnSave;
        private Label label2;
        private DataGridViewLinkColumn DgvLnkCCz;
        private DataGridViewTextBoxColumn DgvColTxtId;
        private BindingSource Bds;
        private DSDSKKHFLWH DSDSKKHFLWH1;
        private DSDSKKHFLWHTableAdapters.VfmsdskkhflwhTableAdapter VfmsdskkhflwhTableAdapter1;
        private Label LblTs;


        }
    }