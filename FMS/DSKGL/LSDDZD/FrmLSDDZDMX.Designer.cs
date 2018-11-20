using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.LSDDZD
{
    partial class FrmLSDDZDMX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtDqmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJgmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYdbh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJzje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtRbje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtPpzt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtShzt = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bnt_dc = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.PnlBtn = new Gizmox.WebGUI.Forms.Panel();
            this.PnlMain = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.PnlBtn.SuspendLayout();
            this.PnlMain.SuspendLayout();
            this.SuspendLayout();
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
            this.DgvColTxtDqmc,
            this.DgvColTxtJgmc,
            this.DgvColTxtYdbh,
            this.DgvColTxtJzje,
            this.DgvColTxtRbje,
            this.DgvColTxtPpzt,
            this.DgvColTxtShzt});
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
            this.Dgv.Location = new System.Drawing.Point(0, 0);
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
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(746, 338);
            this.Dgv.TabIndex = 1;
            // 
            // DgvColTxtDqmc
            // 
            this.DgvColTxtDqmc.DataPropertyName = "dqmc";
            this.DgvColTxtDqmc.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtDqmc.HeaderText = "大区";
            this.DgvColTxtDqmc.Name = "DgvColTxtDqmc";
            this.DgvColTxtDqmc.ReadOnly = true;
            // 
            // DgvColTxtJgmc
            // 
            this.DgvColTxtJgmc.DataPropertyName = "jgmc";
            this.DgvColTxtJgmc.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtJgmc.HeaderText = "连锁店";
            this.DgvColTxtJgmc.Name = "DgvColTxtJgmc";
            this.DgvColTxtJgmc.ReadOnly = true;
            // 
            // DgvColTxtYdbh
            // 
            this.DgvColTxtYdbh.DataPropertyName = "ydbh";
            this.DgvColTxtYdbh.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColTxtYdbh.HeaderText = "运单号";
            this.DgvColTxtYdbh.Name = "DgvColTxtYdbh";
            this.DgvColTxtYdbh.ReadOnly = true;
            // 
            // DgvColTxtJzje
            // 
            this.DgvColTxtJzje.DataPropertyName = "jzje";
            this.DgvColTxtJzje.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvColTxtJzje.HeaderText = "代收款记账金额";
            this.DgvColTxtJzje.Name = "DgvColTxtJzje";
            this.DgvColTxtJzje.ReadOnly = true;
            this.DgvColTxtJzje.Width = 120;
            // 
            // DgvColTxtRbje
            // 
            this.DgvColTxtRbje.DataPropertyName = "rbje";
            this.DgvColTxtRbje.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvColTxtRbje.HeaderText = "日报金额";
            this.DgvColTxtRbje.Name = "DgvColTxtRbje";
            this.DgvColTxtRbje.ReadOnly = true;
            // 
            // DgvColTxtPpzt
            // 
            this.DgvColTxtPpzt.DataPropertyName = "ppzt";
            this.DgvColTxtPpzt.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvColTxtPpzt.HeaderText = "匹配情况";
            this.DgvColTxtPpzt.Name = "DgvColTxtPpzt";
            this.DgvColTxtPpzt.ReadOnly = true;
            // 
            // DgvColTxtShzt
            // 
            this.DgvColTxtShzt.DataPropertyName = "shzt";
            this.DgvColTxtShzt.DefaultCellStyle = dataGridViewCellStyle9;
            this.DgvColTxtShzt.HeaderText = "日报审核状态";
            this.DgvColTxtShzt.Name = "DgvColTxtShzt";
            this.DgvColTxtShzt.ReadOnly = true;
            // 
            // Bnt_dc
            // 
            this.Bnt_dc.CustomStyle = "F";
            this.Bnt_dc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bnt_dc.Location = new System.Drawing.Point(12, 11);
            this.Bnt_dc.Name = "Bnt_dc";
            this.Bnt_dc.Size = new System.Drawing.Size(75, 23);
            this.Bnt_dc.TabIndex = 1;
            this.Bnt_dc.Text = "导出";
            this.Bnt_dc.Click += new System.EventHandler(this.Bnt_dc_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(101, 9);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 2;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // PnlBtn
            // 
            this.PnlBtn.Controls.Add(this.Bnt_dc);
            this.PnlBtn.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtn.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtn.Location = new System.Drawing.Point(0, 0);
            this.PnlBtn.Name = "PnlBtn";
            this.PnlBtn.Size = new System.Drawing.Size(746, 43);
            this.PnlBtn.TabIndex = 3;
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.Dgv);
            this.PnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.PnlMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlMain.Location = new System.Drawing.Point(0, 43);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(746, 338);
            this.PnlMain.TabIndex = 3;
            // 
            // FrmLSDDZDMX
            // 
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlBtn);
            this.Size = new System.Drawing.Size(746, 381);
            this.Text = "账单明细";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.PnlBtn.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtDqmc;
        private DataGridViewTextBoxColumn DgvColTxtJgmc;
        private DataGridViewTextBoxColumn DgvColTxtYdbh;
        private DataGridViewTextBoxColumn DgvColTxtJzje;
        private DataGridViewTextBoxColumn DgvColTxtRbje;
        private DataGridViewTextBoxColumn DgvColTxtPpzt;
        private DataGridViewTextBoxColumn DgvColTxtShzt;
        private Button Bnt_dc;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Panel PnlBtn;
        private Panel PnlMain;


    }
}