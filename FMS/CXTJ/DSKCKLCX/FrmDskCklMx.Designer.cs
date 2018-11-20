using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.DSKCKLCX
{
    partial class FrmDskCklMx
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.ctrlDownLoad2 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.LblJsl = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.LblBysc = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.LblByyc = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.LblLjwc = new Gizmox.WebGUI.Forms.Label();
            this.LblDqmc = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtJgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtLjwc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtByyc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtBysc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJsl = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.ctrlDownLoad2);
            this.PnlTop.Controls.Add(this.BtnExl);
            this.PnlTop.Controls.Add(this.label10);
            this.PnlTop.Controls.Add(this.LblJsl);
            this.PnlTop.Controls.Add(this.label8);
            this.PnlTop.Controls.Add(this.LblBysc);
            this.PnlTop.Controls.Add(this.label6);
            this.PnlTop.Controls.Add(this.LblByyc);
            this.PnlTop.Controls.Add(this.label4);
            this.PnlTop.Controls.Add(this.LblLjwc);
            this.PnlTop.Controls.Add(this.LblDqmc);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(632, 79);
            this.PnlTop.TabIndex = 0;
            // 
            // ctrlDownLoad2
            // 
            this.ctrlDownLoad2.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad2.Location = new System.Drawing.Point(532, 43);
            this.ctrlDownLoad2.Name = "ctrlDownLoad2";
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
            this.BtnExl.Location = new System.Drawing.Point(444, 43);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 6;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(455, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "及时率：";
            // 
            // LblJsl
            // 
            this.LblJsl.AutoSize = true;
            this.LblJsl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJsl.ForeColor = System.Drawing.Color.Blue;
            this.LblJsl.Location = new System.Drawing.Point(508, 21);
            this.LblJsl.Name = "LblJsl";
            this.LblJsl.Size = new System.Drawing.Size(35, 13);
            this.LblJsl.TabIndex = 0;
            this.LblJsl.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(263, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "本月回存金额：";
            // 
            // LblBysc
            // 
            this.LblBysc.AutoSize = true;
            this.LblBysc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBysc.ForeColor = System.Drawing.Color.Blue;
            this.LblBysc.Location = new System.Drawing.Point(351, 48);
            this.LblBysc.Name = "LblBysc";
            this.LblBysc.Size = new System.Drawing.Size(35, 13);
            this.LblBysc.TabIndex = 0;
            this.LblBysc.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "本月应存金额：";
            // 
            // LblByyc
            // 
            this.LblByyc.AutoSize = true;
            this.LblByyc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblByyc.ForeColor = System.Drawing.Color.Blue;
            this.LblByyc.Location = new System.Drawing.Point(105, 48);
            this.LblByyc.Name = "LblByyc";
            this.LblByyc.Size = new System.Drawing.Size(35, 13);
            this.LblByyc.TabIndex = 0;
            this.LblByyc.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(263, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "期末未存金额：";
            // 
            // LblLjwc
            // 
            this.LblLjwc.AutoSize = true;
            this.LblLjwc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLjwc.ForeColor = System.Drawing.Color.Blue;
            this.LblLjwc.Location = new System.Drawing.Point(351, 21);
            this.LblLjwc.Name = "LblLjwc";
            this.LblLjwc.Size = new System.Drawing.Size(35, 13);
            this.LblLjwc.TabIndex = 0;
            this.LblLjwc.Text = "0";
            // 
            // LblDqmc
            // 
            this.LblDqmc.AutoSize = true;
            this.LblDqmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDqmc.ForeColor = System.Drawing.Color.Blue;
            this.LblDqmc.Location = new System.Drawing.Point(105, 21);
            this.LblDqmc.Name = "LblDqmc";
            this.LblDqmc.Size = new System.Drawing.Size(35, 13);
            this.LblDqmc.TabIndex = 0;
            this.LblDqmc.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "大区名称：";
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
            this.DgvColTxtJgmc,
            this.DgvColTxtLjwc,
            this.DgvColTxtByyc,
            this.DgvColTxtBysc,
            this.DgvColTxtJsl});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataMember = "DSCX";
            this.Dgv.DataSource = this.DataSet1;
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 79);
            this.Dgv.Name = "Dgv";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(632, 385);
            this.Dgv.TabIndex = 1;
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
            this.DgvColTxtLjwc.HeaderText = "期末未存金额";
            this.DgvColTxtLjwc.Name = "DgvColTxtLjwc";
            this.DgvColTxtLjwc.ReadOnly = true;
            this.DgvColTxtLjwc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtByyc
            // 
            this.DgvColTxtByyc.DataPropertyName = "byyc";
            this.DgvColTxtByyc.HeaderText = "本月应存金额";
            this.DgvColTxtByyc.Name = "DgvColTxtByyc";
            this.DgvColTxtByyc.ReadOnly = true;
            this.DgvColTxtByyc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.dataColumn3.DataType = typeof(decimal);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "byyc";
            this.dataColumn4.DataType = typeof(decimal);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "bysc";
            this.dataColumn5.DataType = typeof(decimal);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "jsl";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "xx";
            // 
            // FrmDskCklMx
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(632, 464);
            this.Text = "代收款存款率明细";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtJgmc;
        private DataGridViewTextBoxColumn DgvColTxtLjwc;
        private DataGridViewTextBoxColumn DgvColTxtByyc;
        private DataGridViewTextBoxColumn DgvColTxtBysc;
        private DataGridViewTextBoxColumn DgvColTxtJsl;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataSet DataSet1;
        private Label label10;
        private Label LblJsl;
        private Label label8;
        private Label LblBysc;
        private Label label6;
        private Label LblByyc;
        private Label label4;
        private Label LblLjwc;
        private Label LblDqmc;
        private Label label1;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad2;
        private Button BtnExl;


    }
}