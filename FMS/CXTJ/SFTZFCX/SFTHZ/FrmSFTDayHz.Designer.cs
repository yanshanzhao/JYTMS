using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.SFTZFCX.SFTHZ
{
    partial class FrmSFTDayHz
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
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExcel = new Gizmox.WebGUI.Forms.Button();
            this.BtnSele = new Gizmox.WebGUI.Forms.Button();
            this.DtimEnd = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.DtimBegin = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DsSfthz1 = new FMS.CXTJ.SFTZFCX.SFTHZ.DSSfthz();
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.VfmssftzhmxTableAdapter1 = new FMS.CXTJ.SFTZFCX.SFTHZ.DSSfthzTableAdapters.VfmssftzhmxTableAdapter();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvLnksj = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvTxtje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtcgbs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtcgje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtsbbs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtsbje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsSfthz1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnExcel);
            this.PnlTop.Controls.Add(this.BtnSele);
            this.PnlTop.Controls.Add(this.DtimEnd);
            this.PnlTop.Controls.Add(this.DtimBegin);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.PnlTop.CustomStyle = "yyyy.MM.dd";
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(835, 66);
            this.PnlTop.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(688, 16);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 5;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnExcel
            // 
            this.BtnExcel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExcel.CustomStyle = "F";
            this.BtnExcel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcel.Location = new System.Drawing.Point(130, 38);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnExcel.TabIndex = 4;
            this.BtnExcel.Text = "导出";
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // BtnSele
            // 
            this.BtnSele.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSele.CustomStyle = "F";
            this.BtnSele.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSele.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSele.Location = new System.Drawing.Point(27, 38);
            this.BtnSele.Name = "BtnSele";
            this.BtnSele.Size = new System.Drawing.Size(75, 23);
            this.BtnSele.TabIndex = 3;
            this.BtnSele.Text = "查询";
            this.BtnSele.Click += new System.EventHandler(this.BtnSele_Click);
            // 
            // DtimEnd
            // 
            this.DtimEnd.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtimEnd.CustomFormat = "yyyy.MM.dd";
            this.DtimEnd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtimEnd.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtimEnd.Location = new System.Drawing.Point(275, 11);
            this.DtimEnd.Name = "DtimEnd";
            this.DtimEnd.Size = new System.Drawing.Size(138, 21);
            this.DtimEnd.TabIndex = 2;
            // 
            // DtimBegin
            // 
            this.DtimBegin.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.DtimBegin.CustomFormat = "yyyy.MM.dd";
            this.DtimBegin.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtimBegin.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtimBegin.Location = new System.Drawing.Point(72, 11);
            this.DtimBegin.Name = "DtimBegin";
            this.DtimBegin.Size = new System.Drawing.Size(138, 16);
            this.DtimBegin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(212, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "结束时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间：";
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmssftzhmx";
            this.Bds.DataSource = this.DsSfthz1;
            // 
            // DsSfthz1
            // 
            this.DsSfthz1.DataSetName = "DSSfthz";
            this.DsSfthz1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // VfmssftzhmxTableAdapter1
            // 
            this.VfmssftzhmxTableAdapter1.ClearBeforeFill = true;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.AutoGenerateColumns = false;
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
            this.DgvLnksj,
            this.DgvTxtje,
            this.DgvTxtcgbs,
            this.DgvTxtcgje,
            this.DgvTxtsbbs,
            this.DgvTxtsbje});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
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
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 66);
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
            this.Dgv.Size = new System.Drawing.Size(835, 484);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellDoubleClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellDoubleClick);
            // 
            // DgvLnksj
            // 
            this.DgvLnksj.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvLnksj.ClientMode = false;
            this.DgvLnksj.DataPropertyName = "sj";
            this.DgvLnksj.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvLnksj.HeaderText = "日期";
            this.DgvLnksj.LinkColor = System.Drawing.Color.Empty;
            this.DgvLnksj.Name = "DgvLnksj";
            this.DgvLnksj.ReadOnly = true;
            this.DgvLnksj.TrackVisitedState = false;
            this.DgvLnksj.Url = "";
            this.DgvLnksj.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvTxtje
            // 
            this.DgvTxtje.DataPropertyName = "je";
            this.DgvTxtje.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvTxtje.HeaderText = "代收款汇总";
            this.DgvTxtje.Name = "DgvTxtje";
            this.DgvTxtje.ReadOnly = true;
            this.DgvTxtje.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvTxtcgbs
            // 
            this.DgvTxtcgbs.DataPropertyName = "cgbs";
            this.DgvTxtcgbs.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvTxtcgbs.FillWeight = 140F;
            this.DgvTxtcgbs.HeaderText = "成功代收款笔数";
            this.DgvTxtcgbs.Name = "DgvTxtcgbs";
            this.DgvTxtcgbs.ReadOnly = true;
            this.DgvTxtcgbs.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvTxtcgbs.Width = 140;
            // 
            // DgvTxtcgje
            // 
            this.DgvTxtcgje.DataPropertyName = "cgje";
            this.DgvTxtcgje.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvTxtcgje.FillWeight = 140F;
            this.DgvTxtcgje.HeaderText = "成功代收款金额";
            this.DgvTxtcgje.Name = "DgvTxtcgje";
            this.DgvTxtcgje.ReadOnly = true;
            this.DgvTxtcgje.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvTxtcgje.Width = 140;
            // 
            // DgvTxtsbbs
            // 
            this.DgvTxtsbbs.DataPropertyName = "sbbs";
            this.DgvTxtsbbs.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvTxtsbbs.FillWeight = 140F;
            this.DgvTxtsbbs.HeaderText = "异常代收款笔数";
            this.DgvTxtsbbs.Name = "DgvTxtsbbs";
            this.DgvTxtsbbs.ReadOnly = true;
            this.DgvTxtsbbs.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvTxtsbbs.Width = 140;
            // 
            // DgvTxtsbje
            // 
            this.DgvTxtsbje.DataPropertyName = "sbje";
            this.DgvTxtsbje.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvTxtsbje.FillWeight = 140F;
            this.DgvTxtsbje.HeaderText = "异常代收款金额";
            this.DgvTxtsbje.Name = "DgvTxtsbje";
            this.DgvTxtsbje.ReadOnly = true;
            this.DgvTxtsbje.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvTxtsbje.Width = 140;
            // 
            // FrmSFTDayHz
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Size = new System.Drawing.Size(835, 550);
            this.Text = "FrmSFTDayHz";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsSfthz1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private Label label1;
        private Label label2;
        private DateTimePicker DtimEnd;
        private DateTimePicker DtimBegin;
        private Button BtnExcel;
        private Button BtnSele;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DSSfthz DsSfthz1;
        private BindingSource Bds;
        private DSSfthzTableAdapters.VfmssftzhmxTableAdapter VfmssftzhmxTableAdapter1;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvTxtje;
        private DataGridViewTextBoxColumn DgvTxtcgbs;
        private DataGridViewTextBoxColumn DgvTxtcgje;
        private DataGridViewTextBoxColumn DgvTxtsbbs;
        private DataGridViewTextBoxColumn DgvTxtsbje;
        private DataGridViewLinkColumn DgvLnksj;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;


    }
}