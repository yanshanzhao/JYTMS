using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.SFTZFCX.SFTHZ
{
    partial class FrmSFTDayDqHz
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DsSfthz1 = new FMS.CXTJ.SFTZFCX.SFTHZ.DSSfthz();
            this.VfmssftzhmxTableAdapter1 = new FMS.CXTJ.SFTZFCX.SFTHZ.DSSfthzTableAdapters.VfmssftzhmxTableAdapter();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvTxtdqmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtjgmc = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvTxtssj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtcbbs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtcgje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtsbbs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtsbje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvTxtjgid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.BtnExcel = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsSfthz1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
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
            dataGridViewCellStyle13.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvTxtdqmc,
            this.DgvTxtjgmc,
            this.DgvTxtssj,
            this.DgvTxtje,
            this.DgvTxtcbbs,
            this.DgvTxtcgje,
            this.DgvTxtsbbs,
            this.DgvTxtsbje,
            this.DgvTxtjgid});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle23.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle23;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 57);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(1120, 502);
            this.Dgv.TabIndex = 1;
            // 
            // DgvTxtdqmc
            // 
            this.DgvTxtdqmc.DataPropertyName = "dqmc";
            this.DgvTxtdqmc.DefaultCellStyle = dataGridViewCellStyle14;
            this.DgvTxtdqmc.HeaderText = "大区名称";
            this.DgvTxtdqmc.Name = "DgvTxtdqmc";
            this.DgvTxtdqmc.ReadOnly = true;
            this.DgvTxtdqmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvTxtjgmc
            // 
            this.DgvTxtjgmc.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvTxtjgmc.ClientMode = false;
            this.DgvTxtjgmc.DefaultCellStyle = dataGridViewCellStyle15;
            this.DgvTxtjgmc.HeaderText = "机构名称";
            this.DgvTxtjgmc.LinkColor = System.Drawing.Color.Empty;
            this.DgvTxtjgmc.Name = "DgvTxtjgmc";
            this.DgvTxtjgmc.ReadOnly = true;
            this.DgvTxtjgmc.TrackVisitedState = false;
            this.DgvTxtjgmc.Url = "";
            this.DgvTxtjgmc.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvTxtssj
            // 
            this.DgvTxtssj.DataPropertyName = "sj";
            this.DgvTxtssj.DefaultCellStyle = dataGridViewCellStyle16;
            this.DgvTxtssj.HeaderText = "日期";
            this.DgvTxtssj.Name = "DgvTxtssj";
            this.DgvTxtssj.ReadOnly = true;
            this.DgvTxtssj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvTxtje
            // 
            this.DgvTxtje.DataPropertyName = "je";
            this.DgvTxtje.DefaultCellStyle = dataGridViewCellStyle17;
            this.DgvTxtje.FillWeight = 140F;
            this.DgvTxtje.HeaderText = "代收款金额";
            this.DgvTxtje.Name = "DgvTxtje";
            this.DgvTxtje.ReadOnly = true;
            this.DgvTxtje.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvTxtje.Width = 140;
            // 
            // DgvTxtcbbs
            // 
            this.DgvTxtcbbs.DataPropertyName = "cgbs";
            this.DgvTxtcbbs.DefaultCellStyle = dataGridViewCellStyle18;
            this.DgvTxtcbbs.FillWeight = 140F;
            this.DgvTxtcbbs.HeaderText = "成功代收款笔数";
            this.DgvTxtcbbs.Name = "DgvTxtcbbs";
            this.DgvTxtcbbs.ReadOnly = true;
            this.DgvTxtcbbs.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvTxtcbbs.Width = 140;
            // 
            // DgvTxtcgje
            // 
            this.DgvTxtcgje.DataPropertyName = "cgje";
            this.DgvTxtcgje.DefaultCellStyle = dataGridViewCellStyle19;
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
            this.DgvTxtsbbs.DefaultCellStyle = dataGridViewCellStyle20;
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
            this.DgvTxtsbje.DefaultCellStyle = dataGridViewCellStyle21;
            this.DgvTxtsbje.FillWeight = 140F;
            this.DgvTxtsbje.HeaderText = "异常代收款金额";
            this.DgvTxtsbje.Name = "DgvTxtsbje";
            this.DgvTxtsbje.ReadOnly = true;
            this.DgvTxtsbje.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvTxtsbje.Width = 140;
            // 
            // DgvTxtjgid
            // 
            this.DgvTxtjgid.DataPropertyName = "jgid";
            this.DgvTxtjgid.DefaultCellStyle = dataGridViewCellStyle22;
            this.DgvTxtjgid.HeaderText = "jgid";
            this.DgvTxtjgid.Name = "DgvTxtjgid";
            this.DgvTxtjgid.ReadOnly = true;
            this.DgvTxtjgid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvTxtjgid.Visible = false;
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnExcel);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(1120, 57);
            this.PnlTop.TabIndex = 2;
            // 
            // BtnExcel
            // 
            this.BtnExcel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExcel.CustomStyle = "F";
            this.BtnExcel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcel.Location = new System.Drawing.Point(9, 18);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnExcel.TabIndex = 0;
            this.BtnExcel.Text = "导出";
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(108, 15);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 1;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // FrmSFTDayDqHz
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(1120, 559);
            this.Text = "善付通每日大区汇总";
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsSfthz1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.PnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BindingSource Bds;
        private DSSfthz DsSfthz1;
        private DSSfthzTableAdapters.VfmssftzhmxTableAdapter VfmssftzhmxTableAdapter1;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvTxtdqmc;
        private DataGridViewLinkColumn DgvTxtjgmc;
        private DataGridViewTextBoxColumn DgvTxtssj;
        private DataGridViewTextBoxColumn DgvTxtje;
        private DataGridViewTextBoxColumn DgvTxtcbbs;
        private DataGridViewTextBoxColumn DgvTxtcgje;
        private DataGridViewTextBoxColumn DgvTxtsbbs;
        private DataGridViewTextBoxColumn DgvTxtsbje;
        private DataGridViewTextBoxColumn DgvTxtjgid;
        private Panel PnlTop;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExcel;


    }
}