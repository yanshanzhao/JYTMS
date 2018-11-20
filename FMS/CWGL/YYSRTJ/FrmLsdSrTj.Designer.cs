using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.YYSRTJ
{
    partial class FrmLsdSrTj
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.LblHj = new Gizmox.WebGUI.Forms.Label();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnExl = new Gizmox.WebGUI.Forms.Button();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtjzlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtjzjg = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtywqy = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtywdh = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtyf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtbf = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtjehj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColfkfs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtcz = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtsj = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtfkfs = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // LblHj
            // 
            this.LblHj.BackColor = System.Drawing.SystemColors.Window;
            this.LblHj.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblHj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHj.ForeColor = System.Drawing.Color.Blue;
            this.LblHj.Location = new System.Drawing.Point(95, 9);
            this.LblHj.Name = "LblHj";
            this.LblHj.Size = new System.Drawing.Size(161, 21);
            this.LblHj.TabIndex = 3;
            this.LblHj.Text = "合计：0元";
            this.LblHj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(700, 9);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 8;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnExl
            // 
            this.BtnExl.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnExl.CustomStyle = "F";
            this.BtnExl.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnExl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExl.Location = new System.Drawing.Point(8, 7);
            this.BtnExl.Name = "BtnExl";
            this.BtnExl.Size = new System.Drawing.Size(75, 23);
            this.BtnExl.TabIndex = 7;
            this.BtnExl.Text = "导出";
            this.BtnExl.Click += new System.EventHandler(this.BtnExl_Click);
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.LblHj);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnExl);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(806, 46);
            this.PnlTop.TabIndex = 0;
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
            this.DgvColTxtjzlx,
            this.DgvColTxtjzjg,
            this.DgvColTxtywqy,
            this.DgvColTxtywdh,
            this.DgvColTxtyf,
            this.DgvColTxtbf,
            this.DgvColTxtjehj,
            this.DgvColfkfs,
            this.DgvColTxtcz,
            this.DgvColTxtsj,
            this.DgvColTxtfkfs});
            dataGridViewCellStyle11.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle11;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 46);
            this.Dgv.Name = "Dgv";
            dataGridViewCellStyle12.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(806, 424);
            this.Dgv.TabIndex = 0;
            this.Dgv.CellMouseDown += new Gizmox.WebGUI.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseDown);
            // 
            // DgvColTxtjzlx
            // 
            this.DgvColTxtjzlx.DataPropertyName = "jzlx";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjzlx.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtjzlx.FillWeight = 80F;
            this.DgvColTxtjzlx.HeaderText = "记账类型";
            this.DgvColTxtjzlx.Name = "DgvColTxtjzlx";
            this.DgvColTxtjzlx.ReadOnly = true;
            this.DgvColTxtjzlx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjzlx.Width = 80;
            // 
            // DgvColTxtjzjg
            // 
            this.DgvColTxtjzjg.DataPropertyName = "mc";
            this.DgvColTxtjzjg.FillWeight = 80F;
            this.DgvColTxtjzjg.HeaderText = "记账机构";
            this.DgvColTxtjzjg.Name = "DgvColTxtjzjg";
            // 
            // DgvColTxtywqy
            // 
            this.DgvColTxtywqy.DataPropertyName = "ywqys";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtywqy.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtywqy.FillWeight = 70F;
            this.DgvColTxtywqy.HeaderText = "业务区域";
            this.DgvColTxtywqy.Name = "DgvColTxtywqy";
            this.DgvColTxtywqy.ReadOnly = true;
            this.DgvColTxtywqy.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtywqy.Width = 80;
            // 
            // DgvColTxtywdh
            // 
            this.DgvColTxtywdh.DataPropertyName = "bh";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtywdh.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvColTxtywdh.FillWeight = 70F;
            this.DgvColTxtywdh.HeaderText = "业务单号";
            this.DgvColTxtywdh.Name = "DgvColTxtywdh";
            this.DgvColTxtywdh.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtyf
            // 
            this.DgvColTxtyf.DataPropertyName = "fhxf";
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtyf.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvColTxtyf.FillWeight = 80F;
            this.DgvColTxtyf.HeaderText = "运费(元)";
            this.DgvColTxtyf.Name = "DgvColTxtyf";
            this.DgvColTxtyf.ReadOnly = true;
            this.DgvColTxtyf.Width = 80;
            // 
            // DgvColTxtbf
            // 
            this.DgvColTxtbf.DataPropertyName = "bf";
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtbf.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvColTxtbf.FillWeight = 60F;
            this.DgvColTxtbf.HeaderText = "保价费(元)";
            this.DgvColTxtbf.Name = "DgvColTxtbf";
            this.DgvColTxtbf.ReadOnly = true;
            this.DgvColTxtbf.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtbf.Width = 80;
            // 
            // DgvColTxtjehj
            // 
            this.DgvColTxtjehj.DataPropertyName = "jezj";
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjehj.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvColTxtjehj.FillWeight = 80F;
            this.DgvColTxtjehj.HeaderText = "金额合计(元)";
            this.DgvColTxtjehj.Name = "DgvColTxtjehj";
            this.DgvColTxtjehj.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtjehj.Width = 120;
            // 
            // DgvColfkfs
            // 
            this.DgvColfkfs.DataPropertyName = "fzf";
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColfkfs.DefaultCellStyle = dataGridViewCellStyle9;
            this.DgvColfkfs.FillWeight = 60F;
            this.DgvColfkfs.HeaderText = "付款方式";
            this.DgvColfkfs.Name = "DgvColfkfs";
            this.DgvColfkfs.ReadOnly = true;
            this.DgvColfkfs.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColfkfs.Width = 80;
            // 
            // DgvColTxtcz
            // 
            this.DgvColTxtcz.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtcz.ClientMode = false;
            this.DgvColTxtcz.DataPropertyName = "cz";
            dataGridViewCellStyle10.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtcz.DefaultCellStyle = dataGridViewCellStyle10;
            this.DgvColTxtcz.FillWeight = 80F;
            this.DgvColTxtcz.HeaderText = "操作";
            this.DgvColTxtcz.LinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtcz.Name = "DgvColTxtcz";
            this.DgvColTxtcz.TrackVisitedState = false;
            this.DgvColTxtcz.Url = "";
            this.DgvColTxtcz.VisitedLinkColor = System.Drawing.Color.Empty;
            this.DgvColTxtcz.Width = 80;
            // 
            // DgvColTxtsj
            // 
            this.DgvColTxtsj.DataPropertyName = "inssj";
            this.DgvColTxtsj.Name = "DgvColTxtsj";
            this.DgvColTxtsj.Visible = false;
            // 
            // DgvColTxtfkfs
            // 
            this.DgvColTxtfkfs.DataPropertyName = "fkfs";
            this.DgvColTxtfkfs.Name = "DgvColTxtfkfs";
            this.DgvColTxtfkfs.Visible = false;
            // 
            // FrmLsdSrTj
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(806, 470);
            this.Text = "连锁店收入统计";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label LblHj;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnExl;
        private Panel PnlTop;
        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtjzlx;
        private DataGridViewTextBoxColumn DgvColTxtjzjg;
        private DataGridViewTextBoxColumn DgvColTxtywqy;
        private DataGridViewTextBoxColumn DgvColTxtywdh;
        private DataGridViewTextBoxColumn DgvColTxtyf;
        private DataGridViewTextBoxColumn DgvColTxtbf;
        private DataGridViewTextBoxColumn DgvColTxtjehj;
        private DataGridViewTextBoxColumn DgvColfkfs;
        private DataGridViewLinkColumn DgvColTxtcz;
        private DataGridViewTextBoxColumn DgvColTxtsj;
        private DataGridViewTextBoxColumn DgvColTxtfkfs;


    }
}