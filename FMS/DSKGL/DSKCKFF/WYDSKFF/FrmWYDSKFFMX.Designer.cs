using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKCKFF.WYDSKFF
{
    partial class FrmWYDSKFFMX
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
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.LblBs = new Gizmox.WebGUI.Forms.Label();
            this.LblSfje = new Gizmox.WebGUI.Forms.Label();
            this.LblSxf = new Gizmox.WebGUI.Forms.Label();
            this.LblZje = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtBh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtFwkh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYhzh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZhmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtFfje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtSxf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtZje = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtQssj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtYhlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSwydskff1 = new FMS.DSKGL.DSKCKFF.WYDSKFF.DSWYDSKFF();
            this.VfmswydskffmxTableAdapter1 = new FMS.DSKGL.DSKCKFF.WYDSKFF.DSWYDSKFFTableAdapters.VfmswydskffmxTableAdapter();
            this.PnlBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSwydskff1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlBtns
            // 
            this.PnlBtns.Controls.Add(this.ctrlDownLoad1);
            this.PnlBtns.Controls.Add(this.BtnExl);
            this.PnlBtns.Controls.Add(this.LblBs);
            this.PnlBtns.Controls.Add(this.LblSfje);
            this.PnlBtns.Controls.Add(this.LblSxf);
            this.PnlBtns.Controls.Add(this.LblZje);
            this.PnlBtns.Controls.Add(this.label4);
            this.PnlBtns.Controls.Add(this.label3);
            this.PnlBtns.Controls.Add(this.label2);
            this.PnlBtns.Controls.Add(this.label1);
            this.PnlBtns.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlBtns.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlBtns.ForeColor = System.Drawing.Color.Blue;
            this.PnlBtns.Location = new System.Drawing.Point(0, 0);
            this.PnlBtns.Name = "PnlBtns";
            this.PnlBtns.Size = new System.Drawing.Size(832, 47);
            this.PnlBtns.TabIndex = 0;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(747, 5);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 2;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(672, 7);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 1;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // LblBs
            // 
            this.LblBs.BackColor = System.Drawing.SystemColors.Window;
            this.LblBs.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblBs.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            this.LblBs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBs.ForeColor = System.Drawing.Color.Blue;
            this.LblBs.Location = new System.Drawing.Point(580, 9);
            this.LblBs.Name = "LblBs";
            this.LblBs.Size = new System.Drawing.Size(72, 21);
            this.LblBs.TabIndex = 0;
            this.LblBs.Text = "0";
            this.LblBs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblSfje
            // 
            this.LblSfje.BackColor = System.Drawing.SystemColors.Window;
            this.LblSfje.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblSfje.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            this.LblSfje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSfje.ForeColor = System.Drawing.Color.Blue;
            this.LblSfje.Location = new System.Drawing.Point(433, 9);
            this.LblSfje.Name = "LblSfje";
            this.LblSfje.Size = new System.Drawing.Size(72, 21);
            this.LblSfje.TabIndex = 0;
            this.LblSfje.Text = "0";
            this.LblSfje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblSxf
            // 
            this.LblSxf.BackColor = System.Drawing.SystemColors.Window;
            this.LblSxf.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblSxf.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            this.LblSxf.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSxf.ForeColor = System.Drawing.Color.Blue;
            this.LblSxf.Location = new System.Drawing.Point(249, 9);
            this.LblSxf.Name = "LblSxf";
            this.LblSxf.Size = new System.Drawing.Size(72, 21);
            this.LblSxf.TabIndex = 0;
            this.LblSxf.Text = "0";
            this.LblSxf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblZje
            // 
            this.LblZje.BackColor = System.Drawing.SystemColors.Window;
            this.LblZje.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblZje.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            this.LblZje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZje.ForeColor = System.Drawing.Color.Blue;
            this.LblZje.Location = new System.Drawing.Point(77, 9);
            this.LblZje.Name = "LblZje";
            this.LblZje.Size = new System.Drawing.Size(84, 21);
            this.LblZje.TabIndex = 0;
            this.LblZje.Text = "0";
            this.LblZje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(539, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "笔数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(368, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "实发金额：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(196, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "手续费：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "总金额：";
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
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
            this.DgvColTxtBh,
            this.DgvColTxtFwkh,
            this.DgvColTxtYhzh,
            this.DgvColTxtZhmc,
            this.DgvColTxtFfje,
            this.DgvColTxtSxf,
            this.DgvColTxtZje,
            this.DgvColTxtQssj,
            this.DgvColTxtYhlx});
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
            this.Dgv.Location = new System.Drawing.Point(0, 47);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(832, 375);
            this.Dgv.TabIndex = 1;
            // 
            // DgvColTxtBh
            // 
            this.DgvColTxtBh.DataPropertyName = "bh";
            this.DgvColTxtBh.HeaderText = "货运编号";
            this.DgvColTxtBh.Name = "DgvColTxtBh";
            this.DgvColTxtBh.ReadOnly = true;
            // 
            // DgvColTxtFwkh
            // 
            this.DgvColTxtFwkh.DataPropertyName = "dskkhbh";
            this.DgvColTxtFwkh.HeaderText = "服务卡号";
            this.DgvColTxtFwkh.Name = "DgvColTxtFwkh";
            this.DgvColTxtFwkh.ReadOnly = true;
            // 
            // DgvColTxtYhzh
            // 
            this.DgvColTxtYhzh.DataPropertyName = "yhzh";
            this.DgvColTxtYhzh.HeaderText = "银行帐号";
            this.DgvColTxtYhzh.Name = "DgvColTxtYhzh";
            this.DgvColTxtYhzh.ReadOnly = true;
            // 
            // DgvColTxtZhmc
            // 
            this.DgvColTxtZhmc.DataPropertyName = "mc";
            this.DgvColTxtZhmc.HeaderText = "账户名称";
            this.DgvColTxtZhmc.Name = "DgvColTxtZhmc";
            this.DgvColTxtZhmc.ReadOnly = true;
            // 
            // DgvColTxtFfje
            // 
            this.DgvColTxtFfje.DataPropertyName = "sfje";
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtFfje.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColTxtFfje.HeaderText = "发放金额";
            this.DgvColTxtFfje.Name = "DgvColTxtFfje";
            this.DgvColTxtFfje.ReadOnly = true;
            // 
            // DgvColTxtSxf
            // 
            this.DgvColTxtSxf.DataPropertyName = "sxf";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtSxf.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtSxf.HeaderText = "手续费";
            this.DgvColTxtSxf.Name = "DgvColTxtSxf";
            this.DgvColTxtSxf.ReadOnly = true;
            // 
            // DgvColTxtZje
            // 
            this.DgvColTxtZje.DataPropertyName = "zje";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtZje.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtZje.HeaderText = "总金额";
            this.DgvColTxtZje.Name = "DgvColTxtZje";
            this.DgvColTxtZje.ReadOnly = true;
            // 
            // DgvColTxtQssj
            // 
            this.DgvColTxtQssj.DataPropertyName = "qssj";
            this.DgvColTxtQssj.HeaderText = "签收时间";
            this.DgvColTxtQssj.Name = "DgvColTxtQssj";
            this.DgvColTxtQssj.ReadOnly = true;
            // 
            // DgvColTxtYhlx
            // 
            this.DgvColTxtYhlx.DataPropertyName = "jc";
            this.DgvColTxtYhlx.HeaderText = "银行类型";
            this.DgvColTxtYhlx.Name = "DgvColTxtYhlx";
            this.DgvColTxtYhlx.ReadOnly = true;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Vfmswydskffmx";
            this.Bds.DataSource = this.DSwydskff1;
            // 
            // DSwydskff1
            // 
            this.DSwydskff1.DataSetName = "DSWYDSKFF";
            this.DSwydskff1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmswydskffmxTableAdapter1
            // 
            this.VfmswydskffmxTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmWYDSKFFMX
            // 
            this.AcceptButton = this.BtnExl;
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlBtns);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(832, 422);
            this.Text = "网银代收款发放明细";
            this.PnlBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSwydskff1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlBtns;
        private DataGridView Dgv;

        private BindingSource Bds;
        private DSWYDSKFFTableAdapters.VfmswydskffmxTableAdapter VfmswydskffmxTableAdapter1;
        private DSWYDSKFF DSwydskff1;
        private DataGridViewTextBoxColumn DgvColTxtBh;
        private DataGridViewTextBoxColumn DgvColTxtFwkh;
        private DataGridViewTextBoxColumn DgvColTxtYhzh;
        private DataGridViewTextBoxColumn DgvColTxtZhmc;
        private DataGridViewTextBoxColumn DgvColTxtZje;
        private DataGridViewTextBoxColumn DgvColTxtQssj;
        private DataGridViewTextBoxColumn DgvColTxtYhlx;
        private DataGridViewTextBoxColumn DgvColTxtFfje;
        private DataGridViewTextBoxColumn DgvColTxtSxf;
        private Label LblBs;
        private Label LblSfje;
        private Label LblSxf;
        private Label LblZje;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExl;


    }
}