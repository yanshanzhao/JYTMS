using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.DSKFWKWGCX
    {
    partial class FrmDSKFWKWGCXMX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.PnlDgv = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtFhr = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtPs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtLxfs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSljgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DataSet1 = new System.Data.DataSet();
            this.DSCX = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.LblFwkh = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.ctrlDownLoad2 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.dataColumn5 = new System.Data.DataColumn();
            this.DgvColTxtSjgid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.DgvColLnk = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.PnlMain.SuspendLayout();
            this.PnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSCX)).BeginInit();
            this.PnlBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.PnlDgv);
            this.PnlMain.Controls.Add(this.PnlBtns);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(568, 354);
            this.PnlMain.TabIndex = 0;
            // 
            // PnlDgv
            // 
            this.PnlDgv.Controls.Add(this.Dgv);
            this.PnlDgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlDgv.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlDgv.Location = new System.Drawing.Point(0, 51);
            this.PnlDgv.Name = "PnlDgv";
            this.PnlDgv.Size = new System.Drawing.Size(568, 303);
            this.PnlDgv.TabIndex = 1;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
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
            this.DgvColTxtFhr,
            this.DgvColTxtPs,
            this.DgvColTxtLxfs,
            this.DgvColTxtSljgmc,
            this.DgvColLnk,
            this.DgvColTxtSjgid});
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
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
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
            this.Dgv.Size = new System.Drawing.Size(568, 303);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // DgvColTxtFhr
            // 
            this.DgvColTxtFhr.DataPropertyName = "fhr";
            this.DgvColTxtFhr.HeaderText = "发货人";
            this.DgvColTxtFhr.Name = "DgvColTxtFhr";
            this.DgvColTxtFhr.ReadOnly = true;
            // 
            // DgvColTxtPs
            // 
            this.DgvColTxtPs.DataPropertyName = "ps";
            this.DgvColTxtPs.HeaderText = "票数";
            this.DgvColTxtPs.Name = "DgvColTxtPs";
            this.DgvColTxtPs.ReadOnly = true;
            // 
            // DgvColTxtLxfs
            // 
            this.DgvColTxtLxfs.DataPropertyName = "lxfs";
            this.DgvColTxtLxfs.HeaderText = "联系方式";
            this.DgvColTxtLxfs.Name = "DgvColTxtLxfs";
            this.DgvColTxtLxfs.ReadOnly = true;
            // 
            // DgvColTxtSljgmc
            // 
            this.DgvColTxtSljgmc.DataPropertyName = "sljgmc";
            this.DgvColTxtSljgmc.HeaderText = "受理机构";
            this.DgvColTxtSljgmc.Name = "DgvColTxtSljgmc";
            this.DgvColTxtSljgmc.ReadOnly = true;
            this.DgvColTxtSljgmc.Width = 150;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "NewDataSet";
            this.DataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.DSCX});
            // 
            // DSCX
            // 
            this.DSCX.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6});
            this.DSCX.TableName = "DSCX";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "fhr";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "ps";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "lxfs";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "sljgmc";
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.LblFwkh);
            this.PnlBtns.Controls.Add(this.label1);
            this.PnlBtns.Controls.Add(this.ctrlDownLoad2);
            this.PnlBtns.Controls.Add(this.BtnExl);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(568, 51);
            this.PnlBtns.TabIndex = 0;
            // 
            // LblFwkh
            // 
            this.LblFwkh.AutoSize = true;
            this.LblFwkh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFwkh.ForeColor = System.Drawing.Color.Blue;
            this.LblFwkh.Location = new System.Drawing.Point(80, 18);
            this.LblFwkh.Name = "LblFwkh";
            this.LblFwkh.Size = new System.Drawing.Size(35, 13);
            this.LblFwkh.TabIndex = 7;
            this.LblFwkh.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "服务卡号";
            // 
            // ctrlDownLoad2
            // 
            this.ctrlDownLoad2.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad2.Location = new System.Drawing.Point(370, 12);
            this.ctrlDownLoad2.Name = "ctrlDownLoad1";
            this.ctrlDownLoad2.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad2.TabIndex = 5;
            this.ctrlDownLoad2.Text = "CtrlDownLoad";
            this.ctrlDownLoad2.Visible = false;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(463, 13);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 6;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(448, 16);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 5;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "sljgid";
            // 
            // DgvColTxtSjgid
            // 
            this.DgvColTxtSjgid.DataPropertyName = "sljgid";
            this.DgvColTxtSjgid.HeaderText = "机构ID[隐藏]";
            this.DgvColTxtSjgid.Name = "DgvColTxtSjgid";
            this.DgvColTxtSjgid.ReadOnly = true;
            this.DgvColTxtSjgid.Visible = false;
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "cz";
            // 
            // DgvColLnk
            // 
            this.DgvColLnk.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColLnk.ClientMode = false;
            this.DgvColLnk.DataPropertyName = "cz";
            this.DgvColLnk.HeaderText = "操作";
            this.DgvColLnk.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.SystemDefault;
            this.DgvColLnk.LinkColor = System.Drawing.Color.Empty;
            this.DgvColLnk.Name = "DgvColLnk";
            this.DgvColLnk.ReadOnly = true;
            this.DgvColLnk.TrackVisitedState = false;
            this.DgvColLnk.Url = "";
            this.DgvColLnk.VisitedLinkColor = System.Drawing.Color.Empty;
            // 
            // FrmDSKFWKWGCXMX
            // 
            this.Controls.Add(this.PnlMain);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(568, 354);
            this.Text = "服务卡号违规查询明细";
            this.PnlMain.ResumeLayout(false);
            this.PnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSCX)).EndInit();
            this.PnlBtns.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private Panel PnlMain;
        private Panel PnlDgv;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtFhr;
        private DataGridViewTextBoxColumn DgvColTxtPs;
        private DataGridViewTextBoxColumn DgvColTxtSljgmc;
        private Panel PnlBtns;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExl;
        private DataGridViewTextBoxColumn DgvColTxtLxfs;
        private System.Data.DataTable DSCX;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataSet DataSet1;
        private System.Data.DataColumn dataColumn4;
        private Label LblFwkh;
        private Label label1;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad2;
        private DataGridViewTextBoxColumn DgvColTxtSjgid;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private DataGridViewLinkColumn DgvColLnk;


        }
    }