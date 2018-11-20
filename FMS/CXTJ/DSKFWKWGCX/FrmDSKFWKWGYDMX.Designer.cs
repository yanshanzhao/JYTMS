using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.DSKFWKWGCX
{
    partial class FrmDSKFWKWGYDMX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.LblFwkh = new Gizmox.WebGUI.Forms.Label();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad2 = new JY.CtrlPub.CtrlDownLoad();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtBh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSljg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSlsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtFwkh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtHwmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtCkr = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZjs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtDsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DataSet1 = new System.Data.DataSet();
            this.DSCX = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSCX)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Controls.Add(this.LblFwkh);
            this.PnlTop.Controls.Add(this.BtnExl);
            this.PnlTop.Controls.Add(this.ctrlDownLoad2);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(717, 53);
            this.PnlTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "服务卡号";
            // 
            // LblFwkh
            // 
            this.LblFwkh.AutoSize = true;
            this.LblFwkh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFwkh.ForeColor = System.Drawing.Color.Blue;
            this.LblFwkh.Location = new System.Drawing.Point(90, 14);
            this.LblFwkh.Name = "LblFwkh";
            this.LblFwkh.Size = new System.Drawing.Size(35, 13);
            this.LblFwkh.TabIndex = 7;
            this.LblFwkh.Text = "0";
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(463, 9);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 6;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // ctrlDownLoad2
            // 
            this.ctrlDownLoad2.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad2.Location = new System.Drawing.Point(351, 9);
            this.ctrlDownLoad2.Name = "ctrlDownLoad2";
            this.ctrlDownLoad2.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad2.TabIndex = 5;
            this.ctrlDownLoad2.Text = "CtrlDownLoad";
            this.ctrlDownLoad2.Visible = false;
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
            this.DgvColTxtBh,
            this.DgvColTxtSljg,
            this.DgvColTxtSlsj,
            this.DgvColTxtFwkh,
            this.DgvColTxtDsk,
            this.DgvColTxtHwmc,
            this.DgvColTxtCkr,
            this.DgvColTxtZjs});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataMember = "DSCX";
            this.Dgv.DataSource = this.DataSet1;
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 53);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(717, 332);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColTxtBh
            // 
            this.DgvColTxtBh.DataPropertyName = "bh";
            this.DgvColTxtBh.Frozen = true;
            this.DgvColTxtBh.HeaderText = "货运编号";
            this.DgvColTxtBh.Name = "DgvColTxtBh";
            this.DgvColTxtBh.ReadOnly = true;
            this.DgvColTxtBh.Width = 120;
            // 
            // DgvColTxtSljg
            // 
            this.DgvColTxtSljg.DataPropertyName = "sljg";
            this.DgvColTxtSljg.Frozen = true;
            this.DgvColTxtSljg.HeaderText = "受理机构";
            this.DgvColTxtSljg.Name = "DgvColTxtSljg";
            this.DgvColTxtSljg.ReadOnly = true;
            this.DgvColTxtSljg.Width = 150;
            // 
            // DgvColTxtSlsj
            // 
            this.DgvColTxtSlsj.DataPropertyName = "slsj";
            this.DgvColTxtSlsj.HeaderText = "受理时间";
            this.DgvColTxtSlsj.Name = "DgvColTxtSlsj";
            this.DgvColTxtSlsj.ReadOnly = true;
            this.DgvColTxtSlsj.Width = 120;
            // 
            // DgvColTxtFwkh
            // 
            this.DgvColTxtFwkh.DataPropertyName = "fwkh";
            this.DgvColTxtFwkh.HeaderText = "服务卡号";
            this.DgvColTxtFwkh.Name = "DgvColTxtFwkh";
            this.DgvColTxtFwkh.ReadOnly = true;
            // 
            // DgvColTxtHwmc
            // 
            this.DgvColTxtHwmc.DataPropertyName = "hwmc";
            this.DgvColTxtHwmc.HeaderText = "货物名称";
            this.DgvColTxtHwmc.Name = "DgvColTxtHwmc";
            this.DgvColTxtHwmc.ReadOnly = true;
            // 
            // DgvColTxtCkr
            // 
            this.DgvColTxtCkr.DataPropertyName = "ckr";
            this.DgvColTxtCkr.HeaderText = "持卡人";
            this.DgvColTxtCkr.Name = "DgvColTxtCkr";
            this.DgvColTxtCkr.ReadOnly = true;
            // 
            // DgvColTxtZjs
            // 
            this.DgvColTxtZjs.DataPropertyName = "zjs";
            this.DgvColTxtZjs.HeaderText = "总件数";
            this.DgvColTxtZjs.Name = "DgvColTxtZjs";
            this.DgvColTxtZjs.ReadOnly = true;
            // 
            // DgvColTxtDsk
            // 
            this.DgvColTxtDsk.DataPropertyName = "dsk";
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtDsk.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColTxtDsk.HeaderText = "代收款";
            this.DgvColTxtDsk.Name = "DgvColTxtDsk";
            this.DgvColTxtDsk.ReadOnly = true;
            this.DgvColTxtDsk.Width = 150;
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
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8});
            this.DSCX.TableName = "DSCX";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "bh";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "slsj";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "dsk";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "sljg";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "fwkh";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "ckr";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "hwmc";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "zjs";
            // 
            // FrmDSKFWKWGYDMX
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(717, 385);
            this.Text = "服务卡号违规查询运单明细";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSCX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtBh;
        private DataGridViewTextBoxColumn DgvColTxtSlsj;
        private DataGridViewTextBoxColumn DgvColTxtSljg;
        private DataGridViewTextBoxColumn DgvColTxtDsk;
        private System.Data.DataTable DSCX;
        private System.Data.DataSet DataSet1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private Button BtnExl;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad2;
        private Label label1;
        private Label LblFwkh;
        private DataGridViewTextBoxColumn DgvColTxtFwkh;
        private DataGridViewTextBoxColumn DgvColTxtHwmc;
        private DataGridViewTextBoxColumn DgvColTxtCkr;
        private DataGridViewTextBoxColumn DgvColTxtZjs;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;


    }
}