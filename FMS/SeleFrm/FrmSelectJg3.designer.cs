using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using FMS.SeleFrm;

namespace FMS.SeleFrm
{
 partial class FrmSelectJg3
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.TxtJGMC = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnQuery = new Gizmox.WebGUI.Forms.Button();
            this.BtnClear = new Gizmox.WebGUI.Forms.Button();
            this.BtnClose = new Gizmox.WebGUI.Forms.Button();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtPym = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJGMC = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtJGBH = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtLevel = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.DSJG1 = new FMS.SeleFrm.DSJG();
            this.VjigouTableAdapter1 = new FMS.SeleFrm.DSJGTableAdapters.vjigouTableAdapter();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSJG1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "机构名称";
            // 
            // TxtJGMC
            // 
            this.TxtJGMC.AllowDrag = false;
            this.TxtJGMC.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJGMC.Location = new System.Drawing.Point(71, 12);
            this.TxtJGMC.Name = "TxtJGMC";
            this.TxtJGMC.Size = new System.Drawing.Size(186, 21);
            this.TxtJGMC.TabIndex = 1;
            this.TxtJGMC.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.TxtJGMC_EnterKeyDown);
            // 
            // BtnQuery
            // 
            this.BtnQuery.CustomStyle = "F";
            this.BtnQuery.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuery.Location = new System.Drawing.Point(15, 36);
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Size = new System.Drawing.Size(75, 23);
            this.BtnQuery.TabIndex = 2;
            this.BtnQuery.Text = "查询";
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.CustomStyle = "F";
            this.BtnClear.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnClear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear.Location = new System.Drawing.Point(108, 36);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(75, 23);
            this.BtnClear.TabIndex = 4;
            this.BtnClear.Text = "清除";
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.CustomStyle = "F";
            this.BtnClose.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Location = new System.Drawing.Point(201, 36);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 4;
            this.BtnClose.Text = "关闭";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnClose);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Controls.Add(this.BtnClear);
            this.PnlTop.Controls.Add(this.TxtJGMC);
            this.PnlTop.Controls.Add(this.BtnQuery);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(313, 67);
            this.PnlTop.TabIndex = 5;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToOrderColumns = true;
            this.Dgv.AllowUserToResizeColumns = false;
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
            this.DgvColTxtPym,
            this.DgvColTxtJGMC,
            this.DgvColTxtJGBH,
            this.DgvColTxtLevel});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.Dgv.DataSource = this.Bds;
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 67);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv.RowHeadersWidth = 10;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(313, 383);
            this.Dgv.TabIndex = 3;
            this.Dgv.CellDoubleClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.Dgv_CellDoubleClick);
            this.Dgv.KeyPress += new Gizmox.WebGUI.Forms.KeyPressEventHandler(this.Dgv_KeyPress);
            // 
            // DgvColTxtPym
            // 
            this.DgvColTxtPym.DataPropertyName = "pym";
            this.DgvColTxtPym.HeaderText = "拼音码";
            this.DgvColTxtPym.Name = "DgvColTxtPym";
            this.DgvColTxtPym.ReadOnly = true;
            this.DgvColTxtPym.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtPym.Width = 80;
            // 
            // DgvColTxtJGMC
            // 
            this.DgvColTxtJGMC.DataPropertyName = "mc";
            this.DgvColTxtJGMC.HeaderText = "机构名称";
            this.DgvColTxtJGMC.Name = "DgvColTxtJGMC";
            this.DgvColTxtJGMC.ReadOnly = true;
            this.DgvColTxtJGMC.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtJGMC.Width = 180;
            // 
            // DgvColTxtJGBH
            // 
            this.DgvColTxtJGBH.DataPropertyName = "id";
            this.DgvColTxtJGBH.HeaderText = "编号";
            this.DgvColTxtJGBH.Name = "DgvColTxtJGBH";
            this.DgvColTxtJGBH.ReadOnly = true;
            this.DgvColTxtJGBH.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtJGBH.Visible = false;
            this.DgvColTxtJGBH.Width = 60;
            // 
            // DgvColTxtLevel
            // 
            this.DgvColTxtLevel.DataPropertyName = "level";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtLevel.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtLevel.HeaderText = "Level[隐藏]";
            this.DgvColTxtLevel.Name = "DgvColTxtLevel";
            this.DgvColTxtLevel.ReadOnly = true;
            this.DgvColTxtLevel.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtLevel.Width = 152;
            // 
            // Bds
            // 
            this.Bds.DataMember = "vjigou";
            this.Bds.DataSource = this.DSJG1;
            // 
            // DSJG1
            // 
            this.DSJG1.DataSetName = "DSJG";
            this.DSJG1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VjigouTableAdapter1
            // 
            this.VjigouTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmSelectJg3
            // 
            this.AcceptButton = this.BtnQuery;
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(313, 450);
            this.Text = "机构查询";
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSJG1)).EndInit();
            this.ResumeLayout(false);

            }

            #endregion

            private Label label1;
            private TextBox TxtJGMC;
            private Button BtnQuery;
            private Button BtnClear;
            private Button BtnClose;
            private Panel PnlTop;

            private DataGridView Dgv;
            private DSJG DSJG1;
            private FMS.SeleFrm.DSJGTableAdapters.vjigouTableAdapter VjigouTableAdapter1;
            private BindingSource Bds;
            private DataGridViewTextBoxColumn DgvColTxtJGBH;
            private DataGridViewTextBoxColumn DgvColTxtJGMC;
            private DataGridViewTextBoxColumn DgvColTxtPym;
            private DataGridViewTextBoxColumn DgvColTxtLevel;


        }
    }
