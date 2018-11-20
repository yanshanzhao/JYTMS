using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKDKJSL
{
    partial class Frmdqxx
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtDqmc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtDsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtjsdsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtBl = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColLnkxx = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.DgvColTxtDqid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnElse = new Gizmox.WebGUI.Forms.Button();
            this.LblSJ = new Gizmox.WebGUI.Forms.Label();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.DtpDkStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.DtpDkStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.LblLb = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.LblZje = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.LblJsffje = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.AutoGenerateColumns = false;
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.Dgv.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DgvColTxtDqmc,
            this.DgvColTxtDsk,
            this.DgvColTxtjsdsk,
            this.DgvColTxtBl,
            this.DgvColLnkxx,
            this.DgvColTxtDqid});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            dataGridViewCellStyle15.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle15;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 63);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(643, 434);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellMouseDown += new Gizmox.WebGUI.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseDown);
            // 
            // DgvColTxtDqmc
            // 
            this.DgvColTxtDqmc.DataPropertyName = "dqmc";
            dataGridViewCellStyle10.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtDqmc.DefaultCellStyle = dataGridViewCellStyle10;
            this.DgvColTxtDqmc.HeaderText = "大区名称";
            this.DgvColTxtDqmc.Name = "DgvColTxtDqmc";
            this.DgvColTxtDqmc.ReadOnly = true;
            this.DgvColTxtDqmc.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtDsk
            // 
            this.DgvColTxtDsk.DataPropertyName = "dsk";
            dataGridViewCellStyle11.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtDsk.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvColTxtDsk.HeaderText = "总金额";
            this.DgvColTxtDsk.Name = "DgvColTxtDsk";
            this.DgvColTxtDsk.ReadOnly = true;
            this.DgvColTxtDsk.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtjsdsk
            // 
            this.DgvColTxtjsdsk.DataPropertyName = "jsdsk";
            dataGridViewCellStyle12.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjsdsk.DefaultCellStyle = dataGridViewCellStyle12;
            this.DgvColTxtjsdsk.HeaderText = "及时发放金额";
            this.DgvColTxtjsdsk.Name = "DgvColTxtjsdsk";
            this.DgvColTxtjsdsk.ReadOnly = true;
            this.DgvColTxtjsdsk.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtBl
            // 
            this.DgvColTxtBl.DataPropertyName = "Bl";
            dataGridViewCellStyle13.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtBl.DefaultCellStyle = dataGridViewCellStyle13;
            this.DgvColTxtBl.HeaderText = "打款及时率";
            this.DgvColTxtBl.Name = "DgvColTxtBl";
            this.DgvColTxtBl.ReadOnly = true;
            this.DgvColTxtBl.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColLnkxx
            // 
            this.DgvColLnkxx.ActiveLinkColor = System.Drawing.Color.Empty;
            this.DgvColLnkxx.ClientMode = false;
            this.DgvColLnkxx.DataPropertyName = "xx";
            dataGridViewCellStyle14.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColLnkxx.DefaultCellStyle = dataGridViewCellStyle14;
            this.DgvColLnkxx.HeaderText = "操作";
            this.DgvColLnkxx.LinkBehavior = Gizmox.WebGUI.Forms.LinkBehavior.AlwaysUnderline;
            this.DgvColLnkxx.LinkColor = System.Drawing.Color.Empty;
            this.DgvColLnkxx.Name = "DgvColLnkxx";
            this.DgvColLnkxx.ReadOnly = true;
            this.DgvColLnkxx.TrackVisitedState = false;
            this.DgvColLnkxx.Url = "";
            this.DgvColLnkxx.VisitedLinkColor = System.Drawing.Color.Empty;
            this.DgvColLnkxx.Width = 80;
            // 
            // DgvColTxtDqid
            // 
            this.DgvColTxtDqid.DataPropertyName = "dqid";
            this.DgvColTxtDqid.HeaderText = "jgid";
            this.DgvColTxtDqid.Name = "DgvColTxtDqid";
            this.DgvColTxtDqid.ReadOnly = true;
            this.DgvColTxtDqid.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtDqid.Visible = false;
            this.DgvColTxtDqid.Width = 60;
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(301, 31);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 10;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnElse
            // 
            this.BtnElse.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnElse.CustomStyle = "F";
            this.BtnElse.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnElse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnElse.Location = new System.Drawing.Point(212, 33);
            this.BtnElse.Name = "BtnElse";
            this.BtnElse.Size = new System.Drawing.Size(75, 23);
            this.BtnElse.TabIndex = 9;
            this.BtnElse.Text = "导出";
            this.BtnElse.Click += new System.EventHandler(this.BtnElse_Click);
            // 
            // LblSJ
            // 
            this.LblSJ.AutoSize = true;
            this.LblSJ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSJ.Location = new System.Drawing.Point(6, 11);
            this.LblSJ.Name = "LblSJ";
            this.LblSJ.Size = new System.Drawing.Size(53, 12);
            this.LblSJ.TabIndex = 0;
            this.LblSJ.Text = "打款时间";
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.LblJsffje);
            this.PnlTop.Controls.Add(this.label6);
            this.PnlTop.Controls.Add(this.LblZje);
            this.PnlTop.Controls.Add(this.label3);
            this.PnlTop.Controls.Add(this.LblLb);
            this.PnlTop.Controls.Add(this.label2);
            this.PnlTop.Controls.Add(this.DtpDkStart);
            this.PnlTop.Controls.Add(this.label5);
            this.PnlTop.Controls.Add(this.DtpDkStop);
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnElse);
            this.PnlTop.Controls.Add(this.LblSJ);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(643, 63);
            this.PnlTop.TabIndex = 0;
            // 
            // DtpDkStart
            // 
            this.DtpDkStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpDkStart.Checked = false;
            this.DtpDkStart.CustomFormat = "yyyy.MM.dd";
            this.DtpDkStart.Enabled = false;
            this.DtpDkStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDkStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpDkStart.Location = new System.Drawing.Point(65, 7);
            this.DtpDkStart.Name = "DtpDkStart";
            this.DtpDkStart.Size = new System.Drawing.Size(101, 21);
            this.DtpDkStart.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(169, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "到";
            // 
            // DtpDkStop
            // 
            this.DtpDkStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpDkStop.Checked = false;
            this.DtpDkStop.CustomFormat = "yyyy.MM.dd";
            this.DtpDkStop.Enabled = false;
            this.DtpDkStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDkStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpDkStop.Location = new System.Drawing.Point(188, 7);
            this.DtpDkStop.Name = "DtpDkStop";
            this.DtpDkStop.Size = new System.Drawing.Size(101, 21);
            this.DtpDkStop.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(299, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "类别";
            // 
            // LblLb
            // 
            this.LblLb.BackColor = System.Drawing.Color.White;
            this.LblLb.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblLb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLb.ForeColor = System.Drawing.Color.Blue;
            this.LblLb.Location = new System.Drawing.Point(332, 8);
            this.LblLb.Name = "LblLb";
            this.LblLb.Size = new System.Drawing.Size(70, 19);
            this.LblLb.TabIndex = 0;
            this.LblLb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(408, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "总金额";
            // 
            // LblZje
            // 
            this.LblZje.BackColor = System.Drawing.Color.White;
            this.LblZje.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblZje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZje.ForeColor = System.Drawing.Color.Blue;
            this.LblZje.Location = new System.Drawing.Point(454, 8);
            this.LblZje.Name = "LblZje";
            this.LblZje.Size = new System.Drawing.Size(100, 19);
            this.LblZje.TabIndex = 0;
            this.LblZje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "及时发放金额";
            // 
            // LblJsffje
            // 
            this.LblJsffje.BackColor = System.Drawing.Color.White;
            this.LblJsffje.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.LblJsffje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJsffje.ForeColor = System.Drawing.Color.Blue;
            this.LblJsffje.Location = new System.Drawing.Point(93, 35);
            this.LblJsffje.Name = "LblJsffje";
            this.LblJsffje.Size = new System.Drawing.Size(100, 19);
            this.LblJsffje.TabIndex = 0;
            this.LblJsffje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frmdqxx
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(643, 497);
            this.Text = "大区代收款打款及时率";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.PnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView Dgv;
        private DataGridViewTextBoxColumn DgvColTxtDqmc;
        private DataGridViewTextBoxColumn DgvColTxtDsk;
        private DataGridViewTextBoxColumn DgvColTxtjsdsk;
        private DataGridViewTextBoxColumn DgvColTxtBl;
        private DataGridViewLinkColumn DgvColLnkxx;
        private DataGridViewTextBoxColumn DgvColTxtDqid;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnElse;
        private Label LblSJ;
        private Panel PnlTop;
        private DateTimePicker DtpDkStart;
        private Label label5;
        private DateTimePicker DtpDkStop;
        private Label LblZje;
        private Label label3;
        private Label LblLb;
        private Label label2;
        private Label LblJsffje;
        private Label label6;


    }
}