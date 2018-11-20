using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.WFKDSKCX
    {
    partial class FrmLSDWFKDSK
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtjgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColLiKDays0 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColLiKDays1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColLiKDays2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColLiKDays3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColLiKDays4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtzj = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtjgId = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtlevel = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.BtnExl1 = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.LblZj = new Gizmox.WebGUI.Forms.Label();
            this.LblJgmc = new Gizmox.WebGUI.Forms.Label();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Controls.Add(this.PnlTop);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(758, 431);
            this.PnlMain.TabIndex = 0;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
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
            this.DgvColTxtjgmc,
            this.DgvColLiKDays0,
            this.DgvColLiKDays1,
            this.DgvColLiKDays2,
            this.DgvColLiKDays3,
            this.DgvColLiKDays4,
            this.DgvColTxtzj,
            this.DgvColTxtjgId,
            this.DgvColTxtlevel});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            dataGridViewCellStyle10.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle10;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 45);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.Dgv.RowHeadersWidth = 10;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(758, 386);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellMouseDown += new Gizmox.WebGUI.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseDown);
            // 
            // DgvColTxtjgmc
            // 
            this.DgvColTxtjgmc.DataPropertyName = "Jgmc";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjgmc.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtjgmc.FillWeight = 140F;
            this.DgvColTxtjgmc.HeaderText = "机构";
            this.DgvColTxtjgmc.Name = "DgvColTxtjgmc";
            this.DgvColTxtjgmc.ReadOnly = true;
            this.DgvColTxtjgmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjgmc.Width = 140;
            // 
            // DgvColLiKDays0
            // 
            this.DgvColLiKDays0.DataPropertyName = "yqts0";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColLiKDays0.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColLiKDays0.FillWeight = 80F;
            this.DgvColLiKDays0.HeaderText = "逾期0天";
            this.DgvColLiKDays0.Name = "DgvColLiKDays0";
            this.DgvColLiKDays0.ReadOnly = true;
            this.DgvColLiKDays0.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColLiKDays1
            // 
            this.DgvColLiKDays1.DataPropertyName = "yqts1";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColLiKDays1.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColLiKDays1.FillWeight = 80F;
            this.DgvColLiKDays1.HeaderText = "逾期1天";
            this.DgvColLiKDays1.Name = "DgvColLiKDays1";
            this.DgvColLiKDays1.ReadOnly = true;
            this.DgvColLiKDays1.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColLiKDays1.Width = 80;
            // 
            // DgvColLiKDays2
            // 
            this.DgvColLiKDays2.DataPropertyName = "yqts2";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColLiKDays2.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvColLiKDays2.FillWeight = 80F;
            this.DgvColLiKDays2.HeaderText = "逾期2天";
            this.DgvColLiKDays2.Name = "DgvColLiKDays2";
            this.DgvColLiKDays2.ReadOnly = true;
            this.DgvColLiKDays2.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColLiKDays2.Width = 80;
            // 
            // DgvColLiKDays3
            // 
            this.DgvColLiKDays3.DataPropertyName = "yqts3";
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColLiKDays3.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvColLiKDays3.FillWeight = 80F;
            this.DgvColLiKDays3.HeaderText = "逾期3天";
            this.DgvColLiKDays3.Name = "DgvColLiKDays3";
            this.DgvColLiKDays3.ReadOnly = true;
            this.DgvColLiKDays3.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColLiKDays3.Width = 80;
            // 
            // DgvColLiKDays4
            // 
            this.DgvColLiKDays4.DataPropertyName = "yqts4";
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColLiKDays4.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvColLiKDays4.FillWeight = 80F;
            this.DgvColLiKDays4.HeaderText = "逾期3天以上";
            this.DgvColLiKDays4.Name = "DgvColLiKDays4";
            this.DgvColLiKDays4.ReadOnly = true;
            this.DgvColLiKDays4.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColLiKDays4.Width = 120;
            // 
            // DgvColTxtzj
            // 
            this.DgvColTxtzj.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtzj.ClientMode = false;
            this.DgvColTxtzj.DataPropertyName = "zj";
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtzj.DefaultCellStyle = dataGridViewCellStyle9;
            this.DgvColTxtzj.FillWeight = 80F;
            this.DgvColTxtzj.HeaderText = "总计";
            this.DgvColTxtzj.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvColTxtzj.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtzj.Name = "DgvColTxtzj";
            this.DgvColTxtzj.ReadOnly = true;
            this.DgvColTxtzj.TrackVisitedState = false;
            this.DgvColTxtzj.Url = "";
            this.DgvColTxtzj.VisitedLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtzj.Width = 80;
            // 
            // DgvColTxtjgId
            // 
            this.DgvColTxtjgId.DataPropertyName = "Jgid";
            this.DgvColTxtjgId.FillWeight = 90F;
            this.DgvColTxtjgId.HeaderText = "Jgid[隐藏]";
            this.DgvColTxtjgId.Name = "DgvColTxtjgId";
            this.DgvColTxtjgId.ReadOnly = true;
            this.DgvColTxtjgId.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjgId.Visible = false;
            this.DgvColTxtjgId.Width = 90;
            // 
            // DgvColTxtlevel
            // 
            this.DgvColTxtlevel.DataPropertyName = "Level";
            this.DgvColTxtlevel.HeaderText = "Level[隐藏]";
            this.DgvColTxtlevel.Name = "DgvColTxtlevel";
            this.DgvColTxtlevel.ReadOnly = true;
            this.DgvColTxtlevel.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtlevel.Visible = false;
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnExl1);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.LblZj);
            this.PnlTop.Controls.Add(this.LblJgmc);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(758, 45);
            this.PnlTop.TabIndex = 0;
            // 
            // BtnExl1
            // 
            this.BtnExl1.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl1.CustomStyle = "F";
            this.BtnExl1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl1.Location = new System.Drawing.Point(512, 9);
            this.BtnExl1.Name = "BtnExl1";
            this.BtnExl1.Size = new System.Drawing.Size(75, 23);
            this.BtnExl1.TabIndex = 5;
            this.BtnExl1.Text = "导出";
            this.BtnExl1.Click += new System.EventHandler(this.BtnExl1_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(411, 9);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 3;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // LblZj
            // 
            this.LblZj.AutoSize = true;
            this.LblZj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZj.Location = new System.Drawing.Point(215, 13);
            this.LblZj.Name = "LblZj";
            this.LblZj.Size = new System.Drawing.Size(35, 13);
            this.LblZj.TabIndex = 1;
            this.LblZj.Text = "金额";
            // 
            // LblJgmc
            // 
            this.LblJgmc.AutoSize = true;
            this.LblJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJgmc.Location = new System.Drawing.Point(30, 13);
            this.LblJgmc.Name = "LblJgmc";
            this.LblJgmc.Size = new System.Drawing.Size(35, 13);
            this.LblJgmc.TabIndex = 0;
            this.LblJgmc.Text = "大区名称";
            // 
            // FrmLSDWFKDSK
            // 
            this.Controls.Add(this.PnlMain);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(758, 431);
            this.Text = "大区未返款代收款信息";
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.PnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private Panel PnlMain;
        private Panel PnlTop;
        private Label LblZj;
        private Label LblJgmc;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtjgmc;
        private DataGridViewLinkColumn DgvColTxtzj;
        private DataGridViewTextBoxColumn DgvColLiKDays1;
        private DataGridViewTextBoxColumn DgvColLiKDays2;
        private DataGridViewTextBoxColumn DgvColLiKDays3;
        private DataGridViewTextBoxColumn DgvColLiKDays4;
        private DataGridViewTextBoxColumn DgvColTxtjgId;
        private DataGridViewTextBoxColumn DgvColTxtlevel;
        private Button BtnExl1;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private DataGridViewTextBoxColumn DgvColLiKDays0;


        }
    }