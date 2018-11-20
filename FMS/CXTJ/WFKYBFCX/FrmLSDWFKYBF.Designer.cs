using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.WFKYBFCX
    {
    partial class FrmLSDWFKYBF
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtjgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtTs1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtTs2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtTs3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtts999 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColLclHj = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtJgid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExcel = new Gizmox.WebGUI.Forms.Button();
            this.LblJe = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.LblJgmc = new Gizmox.WebGUI.Forms.Label();
            this.DgvColTxtTs0 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.PnlBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Controls.Add(this.PnlBtns);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(744, 433);
            this.PnlMain.TabIndex = 0;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.AutoGenerateColumns = false;
            this.Dgv.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.DgvColTxtjgmc,
            this.DgvColTxtTs0,
            this.DgvColTxtTs1,
            this.DgvColTxtTs2,
            this.DgvColTxtTs3,
            this.DgvColTxtts999,
            this.DgvColLclHj,
            this.DgvColTxtJgid});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
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
            this.Dgv.Location = new System.Drawing.Point(0, 45);
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
            this.Dgv.Size = new System.Drawing.Size(744, 388);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // DgvColTxtjgmc
            // 
            this.DgvColTxtjgmc.DataPropertyName = "jgmc";
            this.DgvColTxtjgmc.FillWeight = 114.7541F;
            this.DgvColTxtjgmc.HeaderText = "机构";
            this.DgvColTxtjgmc.Name = "DgvColTxtjgmc";
            this.DgvColTxtjgmc.ReadOnly = true;
            this.DgvColTxtjgmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtTs1
            // 
            this.DgvColTxtTs1.DataPropertyName = "ts1";
            this.DgvColTxtTs1.FillWeight = 102.0268F;
            this.DgvColTxtTs1.HeaderText = "逾期1天";
            this.DgvColTxtTs1.Name = "DgvColTxtTs1";
            this.DgvColTxtTs1.ReadOnly = true;
            this.DgvColTxtTs1.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtTs2
            // 
            this.DgvColTxtTs2.DataPropertyName = "ts2";
            this.DgvColTxtTs2.FillWeight = 102.0268F;
            this.DgvColTxtTs2.HeaderText = "逾期2天";
            this.DgvColTxtTs2.Name = "DgvColTxtTs2";
            this.DgvColTxtTs2.ReadOnly = true;
            this.DgvColTxtTs2.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtTs3
            // 
            this.DgvColTxtTs3.DataPropertyName = "ts3";
            this.DgvColTxtTs3.FillWeight = 102.0268F;
            this.DgvColTxtTs3.HeaderText = "逾期3天";
            this.DgvColTxtTs3.Name = "DgvColTxtTs3";
            this.DgvColTxtTs3.ReadOnly = true;
            this.DgvColTxtTs3.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtts999
            // 
            this.DgvColTxtts999.DataPropertyName = "ts999";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtts999.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtts999.FillWeight = 102.0268F;
            this.DgvColTxtts999.HeaderText = "逾期3天以上";
            this.DgvColTxtts999.Name = "DgvColTxtts999";
            this.DgvColTxtts999.ReadOnly = true;
            this.DgvColTxtts999.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColLclHj
            // 
            this.DgvColLclHj.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColLclHj.ClientMode = false;
            this.DgvColLclHj.DataPropertyName = "hj";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColLclHj.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColLclHj.FillWeight = 75.11177F;
            this.DgvColLclHj.HeaderText = "合计";
            this.DgvColLclHj.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvColLclHj.LinkColor = System.Drawing.Color.Empty;
            this.DgvColLclHj.Name = "DgvColLclHj";
            this.DgvColLclHj.ReadOnly = true;
            this.DgvColLclHj.TrackVisitedState = false;
            this.DgvColLclHj.Url = "";
            this.DgvColLclHj.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // DgvColTxtJgid
            // 
            this.DgvColTxtJgid.DataPropertyName = "jgid";
            this.DgvColTxtJgid.HeaderText = "机构Id[隐藏]";
            this.DgvColTxtJgid.Name = "DgvColTxtJgid";
            this.DgvColTxtJgid.ReadOnly = true;
            this.DgvColTxtJgid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtJgid.Visible = false;
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.BtnExcel);
            this.PnlBtns.Controls.Add(this.LblJe);
            this.PnlBtns.Controls.Add(this.label1);
            this.PnlBtns.Controls.Add(this.label2);
            this.PnlBtns.Controls.Add(this.LblJgmc);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(744, 45);
            this.PnlBtns.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(536, 8);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 3;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnExcel
            // 
            this.BtnExcel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExcel.CustomStyle = "F";
            this.BtnExcel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcel.Location = new System.Drawing.Point(633, 8);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnExcel.TabIndex = 2;
            this.BtnExcel.Text = "导出";
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // LblJe
            // 
            this.LblJe.AutoSize = true;
            this.LblJe.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJe.ForeColor = System.Drawing.Color.Blue;
            this.LblJe.Location = new System.Drawing.Point(314, 13);
            this.LblJe.Name = "LblJe";
            this.LblJe.Size = new System.Drawing.Size(29, 12);
            this.LblJe.TabIndex = 1;
            this.LblJe.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "大区名称:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(285, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "金额";
            // 
            // LblJgmc
            // 
            this.LblJgmc.AutoSize = true;
            this.LblJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJgmc.ForeColor = System.Drawing.Color.Blue;
            this.LblJgmc.Location = new System.Drawing.Point(93, 13);
            this.LblJgmc.Name = "LblJgmc";
            this.LblJgmc.Size = new System.Drawing.Size(35, 13);
            this.LblJgmc.TabIndex = 0;
            // 
            // DgvColTxtTs0
            // 
            this.DgvColTxtTs0.DataPropertyName = "ts0";
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtTs0.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColTxtTs0.FillWeight = 102.0268F;
            this.DgvColTxtTs0.HeaderText = "逾期0天";
            this.DgvColTxtTs0.Name = "DgvColTxtTs0";
            this.DgvColTxtTs0.ReadOnly = true;
            // 
            // FrmLSDWFKYBF
            // 
            this.AcceptButton = this.BtnExcel;
            this.Controls.Add(this.PnlMain);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(744, 433);
            this.Text = "连锁店未返款运保费";
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.PnlBtns.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private Panel PnlMain;
        private Panel PnlBtns;
        private Label label2;
        private Label LblJgmc;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtjgmc;
        private DataGridViewLinkColumn DgvColLclHj;
        private DataGridViewTextBoxColumn DgvColTxtTs3;
        private DataGridViewTextBoxColumn DgvColTxtTs2;
        private DataGridViewTextBoxColumn DgvColTxtTs1;
        private DataGridViewTextBoxColumn DgvColTxtts999;
        private DataGridViewTextBoxColumn DgvColTxtJgid;
        private Label label1;
        private Label LblJe;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExcel;
        private DataGridViewTextBoxColumn DgvColTxtTs0;


        }
    }