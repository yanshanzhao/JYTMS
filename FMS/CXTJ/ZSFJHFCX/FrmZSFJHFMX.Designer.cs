using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CXTJ.ZSFJHFCX
    {
    partial class FrmZSFJHFMX
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlBtns = new Gizmox.WebGUI.Forms.Panel();
            this.LblStop = new Gizmox.WebGUI.Forms.Label();
            this.LblStart = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.LblJgmc = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.LblJg = new Gizmox.WebGUI.Forms.Label();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtBh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSljg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSlsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtMdd = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtQssj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJhf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZsf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtHj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DsZsf_JhfCx1 = new FMS.CXTJ.ZSFJHFCX.DsZsf_JhfCx();
            this.VfmsZsf_JhfCxTableAdapter1 = new FMS.CXTJ.ZSFJHFCX.DsZsf_JhfCxTableAdapters.VfmsZsf_JhfCxTableAdapter();
            this.PnlBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsZsf_JhfCx1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.LblStop);
            this.PnlBtns.Controls.Add(this.LblStart);
            this.PnlBtns.Controls.Add(this.label3);
            this.PnlBtns.Controls.Add(this.LblJgmc);
            this.PnlBtns.Controls.Add(this.label4);
            this.PnlBtns.Controls.Add(this.LblJg);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(717, 50);
            this.PnlBtns.TabIndex = 0;
            // 
            // LblStop
            // 
            this.LblStop.BackColor = System.Drawing.Color.White;
            this.LblStop.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStop.ForeColor = System.Drawing.Color.Blue;
            this.LblStop.Location = new System.Drawing.Point(432, 9);
            this.LblStop.Name = "LblStop";
            this.LblStop.Size = new System.Drawing.Size(127, 21);
            this.LblStop.TabIndex = 5;
            this.LblStop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblStart
            // 
            this.LblStart.BackColor = System.Drawing.Color.White;
            this.LblStart.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStart.ForeColor = System.Drawing.Color.Blue;
            this.LblStart.Location = new System.Drawing.Point(288, 9);
            this.LblStart.Name = "LblStart";
            this.LblStart.Size = new System.Drawing.Size(127, 21);
            this.LblStart.TabIndex = 5;
            this.LblStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(234, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "记账日期";
            // 
            // LblJgmc
            // 
            this.LblJgmc.BackColor = System.Drawing.Color.White;
            this.LblJgmc.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJgmc.ForeColor = System.Drawing.Color.Blue;
            this.LblJgmc.Location = new System.Drawing.Point(43, 9);
            this.LblJgmc.Name = "LblJgmc";
            this.LblJgmc.Size = new System.Drawing.Size(156, 21);
            this.LblJgmc.TabIndex = 5;
            this.LblJgmc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(415, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "一";
            // 
            // LblJg
            // 
            this.LblJg.AutoSize = true;
            this.LblJg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJg.Location = new System.Drawing.Point(13, 13);
            this.LblJg.Name = "LblJg";
            this.LblJg.Size = new System.Drawing.Size(29, 12);
            this.LblJg.TabIndex = 0;
            this.LblJg.Text = "机构";
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
            this.DgvColTxtMdd,
            this.DgvColTxtQssj,
            this.DgvColTxtJhf,
            this.DgvColTxtZsf,
            this.DgvColTxtHj});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.Bds;
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
            this.Dgv.ItemsPerPage =20;
            this.Dgv.Location = new System.Drawing.Point(0, 50);
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
            this.Dgv.Size = new System.Drawing.Size(717, 368);
            this.Dgv.TabIndex = 0;
            // 
            // DgvColTxtBh
            // 
            this.DgvColTxtBh.DataPropertyName = "bh";
            this.DgvColTxtBh.HeaderText = "货运单号";
            this.DgvColTxtBh.Name = "DgvColTxtBh";
            this.DgvColTxtBh.ReadOnly = true;
            this.DgvColTxtBh.Width = 80;
            // 
            // DgvColTxtSljg
            // 
            this.DgvColTxtSljg.DataPropertyName = "sljgmc";
            this.DgvColTxtSljg.HeaderText = "受理机构";
            this.DgvColTxtSljg.Name = "DgvColTxtSljg";
            this.DgvColTxtSljg.ReadOnly = true;
            this.DgvColTxtSljg.Width = 140;
            // 
            // DgvColTxtSlsj
            // 
            this.DgvColTxtSlsj.DataPropertyName = "slsj";
            this.DgvColTxtSlsj.HeaderText = "受理日期";
            this.DgvColTxtSlsj.Name = "DgvColTxtSlsj";
            this.DgvColTxtSlsj.ReadOnly = true;
            this.DgvColTxtSlsj.Width = 80;
            // 
            // DgvColTxtMdd
            // 
            this.DgvColTxtMdd.DataPropertyName = "zdwz";
            this.DgvColTxtMdd.HeaderText = "目的地";
            this.DgvColTxtMdd.Name = "DgvColTxtMdd";
            this.DgvColTxtMdd.ReadOnly = true;
            this.DgvColTxtMdd.Width = 110;
            // 
            // DgvColTxtQssj
            // 
            this.DgvColTxtQssj.DataPropertyName = "qssj";
            this.DgvColTxtQssj.HeaderText = "签收日期";
            this.DgvColTxtQssj.Name = "DgvColTxtQssj";
            this.DgvColTxtQssj.ReadOnly = true;
            this.DgvColTxtQssj.Width = 80;
            // 
            // DgvColTxtJhf
            // 
            this.DgvColTxtJhf.DataPropertyName = "jhf";
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtJhf.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColTxtJhf.HeaderText = "接货费";
            this.DgvColTxtJhf.Name = "DgvColTxtJhf";
            this.DgvColTxtJhf.ReadOnly = true;
            this.DgvColTxtJhf.Width = 70;
            // 
            // DgvColTxtZsf
            // 
            this.DgvColTxtZsf.DataPropertyName = "zsf";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtZsf.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtZsf.HeaderText = "直送费";
            this.DgvColTxtZsf.Name = "DgvColTxtZsf";
            this.DgvColTxtZsf.ReadOnly = true;
            this.DgvColTxtZsf.Width = 70;
            // 
            // DgvColTxtHj
            // 
            this.DgvColTxtHj.DataPropertyName = "hj";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtHj.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtHj.HeaderText = "合计";
            this.DgvColTxtHj.Name = "DgvColTxtHj";
            this.DgvColTxtHj.ReadOnly = true;
            this.DgvColTxtHj.Width = 70;
            // 
            // Bds
            // 
            this.Bds.DataMember = "VfmsZsf_JhfCx";
            this.Bds.DataSource = this.DsZsf_JhfCx1;
            // 
            // DsZsf_JhfCx1
            // 
            this.DsZsf_JhfCx1.DataSetName = "DsZsf_JhfCx";
            this.DsZsf_JhfCx1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmsZsf_JhfCxTableAdapter1
            // 
            this.VfmsZsf_JhfCxTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmZSFJHFMX
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlBtns);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(717, 418);
            this.Text = "直送费接货费明细";
            this.PnlBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsZsf_JhfCx1)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion

        private Panel PnlBtns;
        private Label LblJgmc;
        private Label LblJg;
        private Label label4;
        private Label label3;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtBh;
        private DataGridViewTextBoxColumn DgvColTxtSljg;
        private DataGridViewTextBoxColumn DgvColTxtSlsj;
        private DataGridViewTextBoxColumn DgvColTxtMdd;
        private DataGridViewTextBoxColumn DgvColTxtQssj;
        private DataGridViewTextBoxColumn DgvColTxtHj;
        private Label LblStop;
        private Label LblStart;
        private DataGridViewTextBoxColumn DgvColTxtJhf;
        private DataGridViewTextBoxColumn DgvColTxtZsf;
        private BindingSource Bds;
        private DsZsf_JhfCx DsZsf_JhfCx1;
        private DsZsf_JhfCxTableAdapters.VfmsZsf_JhfCxTableAdapter VfmsZsf_JhfCxTableAdapter1;


        }
    }
