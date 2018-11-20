using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.WFKYBFCX
    {
    partial class FrmYDWFKYBF
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.BtnExcel = new Gizmox.WebGUI.Forms.Button();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.LblZje = new Gizmox.WebGUI.Forms.Label();
            this.LblJgmc = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtDqmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJzjg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtBh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtFkfs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZyf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtTs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSlsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtQsd = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZdwz = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtFhkhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtShkhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtQssj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.BtnExcel);
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.LblZje);
            this.PnlBtns.Controls.Add(this.LblJgmc);
            this.PnlBtns.Controls.Add(this.label1);
            this.PnlBtns.Controls.Add(this.label2);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(744, 51);
            this.PnlBtns.TabIndex = 0;
            // 
            // BtnExcel
            // 
            this.BtnExcel.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExcel.CustomStyle = "F";
            this.BtnExcel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcel.Location = new System.Drawing.Point(611, 14);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnExcel.TabIndex = 2;
            this.BtnExcel.Text = "导出";
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(511, 14);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 3;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // LblZje
            // 
            this.LblZje.AutoSize = true;
            this.LblZje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZje.ForeColor = System.Drawing.Color.Blue;
            this.LblZje.Location = new System.Drawing.Point(386, 19);
            this.LblZje.Name = "LblZje";
            this.LblZje.Size = new System.Drawing.Size(35, 13);
            this.LblZje.TabIndex = 1;
            this.LblZje.Text = "0";
            // 
            // LblJgmc
            // 
            this.LblJgmc.AutoSize = true;
            this.LblJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJgmc.ForeColor = System.Drawing.Color.Blue;
            this.LblJgmc.Location = new System.Drawing.Point(79, 19);
            this.LblJgmc.Name = "LblJgmc";
            this.LblJgmc.Size = new System.Drawing.Size(35, 13);
            this.LblJgmc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "机构名称:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "总金额:";
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
            this.DgvColTxtDqmc,
            this.DgvColTxtJzjg,
            this.DgvColTxtBh,
            this.DgvColTxtFkfs,
            this.DgvColTxtZyf,
            this.DgvColTxtTs,
            this.DgvColTxtSlsj,
            this.DgvColTxtQsd,
            this.DgvColTxtZdwz,
            this.DgvColTxtFhkhmc,
            this.DgvColTxtShkhmc,
            this.DgvColTxtQssj});
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
            this.Dgv.Location = new System.Drawing.Point(0, 51);
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
            this.Dgv.Size = new System.Drawing.Size(744, 382);
            this.Dgv.TabIndex = 1;
            // 
            // DgvColTxtDqmc
            // 
            this.DgvColTxtDqmc.DataPropertyName = "dqmc";
            this.DgvColTxtDqmc.Frozen = true;
            this.DgvColTxtDqmc.HeaderText = "所属大区";
            this.DgvColTxtDqmc.Name = "DgvColTxtDqmc";
            this.DgvColTxtDqmc.ReadOnly = true;
            this.DgvColTxtDqmc.Width = 80;
            // 
            // DgvColTxtJzjg
            // 
            this.DgvColTxtJzjg.DataPropertyName = "jgmc";
            this.DgvColTxtJzjg.Frozen = true;
            this.DgvColTxtJzjg.HeaderText = "记账机构";
            this.DgvColTxtJzjg.Name = "DgvColTxtJzjg";
            this.DgvColTxtJzjg.ReadOnly = true;
            this.DgvColTxtJzjg.Width = 120;
            // 
            // DgvColTxtBh
            // 
            this.DgvColTxtBh.DataPropertyName = "Bh";
            this.DgvColTxtBh.Frozen = true;
            this.DgvColTxtBh.HeaderText = "货运单号";
            this.DgvColTxtBh.Name = "DgvColTxtBh";
            this.DgvColTxtBh.ReadOnly = true;
            this.DgvColTxtBh.Width = 80;
            // 
            // DgvColTxtFkfs
            // 
            this.DgvColTxtFkfs.DataPropertyName = "fkfs";
            this.DgvColTxtFkfs.HeaderText = "付款方式";
            this.DgvColTxtFkfs.Name = "DgvColTxtFkfs";
            this.DgvColTxtFkfs.ReadOnly = true;
            this.DgvColTxtFkfs.Width = 80;
            // 
            // DgvColTxtZyf
            // 
            this.DgvColTxtZyf.DataPropertyName = "zj";
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtZyf.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColTxtZyf.HeaderText = "总运费";
            this.DgvColTxtZyf.Name = "DgvColTxtZyf";
            this.DgvColTxtZyf.ReadOnly = true;
            this.DgvColTxtZyf.Width = 80;
            // 
            // DgvColTxtTs
            // 
            this.DgvColTxtTs.DataPropertyName = "ts";
            this.DgvColTxtTs.HeaderText = "逾期天数";
            this.DgvColTxtTs.Name = "DgvColTxtTs";
            this.DgvColTxtTs.ReadOnly = true;
            this.DgvColTxtTs.Width = 80;
            // 
            // DgvColTxtSlsj
            // 
            this.DgvColTxtSlsj.DataPropertyName = "slsj";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle3.NullValue = null;
            this.DgvColTxtSlsj.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtSlsj.HeaderText = "受理时间";
            this.DgvColTxtSlsj.Name = "DgvColTxtSlsj";
            this.DgvColTxtSlsj.ReadOnly = true;
            this.DgvColTxtSlsj.Width = 80;
            // 
            // DgvColTxtQsd
            // 
            this.DgvColTxtQsd.DataPropertyName = "qsd";
            this.DgvColTxtQsd.HeaderText = "起始地";
            this.DgvColTxtQsd.Name = "DgvColTxtQsd";
            this.DgvColTxtQsd.ReadOnly = true;
            // 
            // DgvColTxtZdwz
            // 
            this.DgvColTxtZdwz.DataPropertyName = "zdwz";
            this.DgvColTxtZdwz.HeaderText = "目的地";
            this.DgvColTxtZdwz.Name = "DgvColTxtZdwz";
            this.DgvColTxtZdwz.ReadOnly = true;
            // 
            // DgvColTxtFhkhmc
            // 
            this.DgvColTxtFhkhmc.DataPropertyName = "fhkhmc";
            this.DgvColTxtFhkhmc.HeaderText = "发货方";
            this.DgvColTxtFhkhmc.Name = "DgvColTxtFhkhmc";
            this.DgvColTxtFhkhmc.ReadOnly = true;
            this.DgvColTxtFhkhmc.Width = 80;
            // 
            // DgvColTxtShkhmc
            // 
            this.DgvColTxtShkhmc.DataPropertyName = "shkhmc";
            this.DgvColTxtShkhmc.HeaderText = "收货方";
            this.DgvColTxtShkhmc.Name = "DgvColTxtShkhmc";
            this.DgvColTxtShkhmc.ReadOnly = true;
            this.DgvColTxtShkhmc.Width = 80;
            // 
            // DgvColTxtQssj
            // 
            this.DgvColTxtQssj.DataPropertyName = "qssj";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle4.NullValue = null;
            this.DgvColTxtQssj.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtQssj.HeaderText = "到达时间";
            this.DgvColTxtQssj.Name = "DgvColTxtQssj";
            this.DgvColTxtQssj.ReadOnly = true;
            this.DgvColTxtQssj.Width = 80;
            // 
            // FrmYDWFKYBF
            // 
            this.AcceptButton = this.BtnExcel;
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlBtns);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(744, 433);
            this.Text = "未返款运保费运单明细";
            this.PnlBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion

        private Panel PnlBtns;
        private Label label1;
        private Label label2;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtDqmc;
        private DataGridViewTextBoxColumn DgvColTxtBh;
        private DataGridViewTextBoxColumn DgvColTxtJzjg;
        private DataGridViewTextBoxColumn DgvColTxtSlsj;
        private DataGridViewTextBoxColumn DgvColTxtQsd;
        private DataGridViewTextBoxColumn DgvColTxtZdwz;
        private DataGridViewTextBoxColumn DgvColTxtFkfs;
        private DataGridViewTextBoxColumn DgvColTxtFhkhmc;
        private DataGridViewTextBoxColumn DgvColTxtShkhmc;
        private DataGridViewTextBoxColumn DgvColTxtQssj;
        private DataGridViewTextBoxColumn DgvColTxtTs;
        private DataGridViewTextBoxColumn DgvColTxtZyf;
        private Label LblZje;
        private Label LblJgmc;
        private Button BtnExcel;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;


        }
    }
