using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKDKJSL
{
    partial class FrmDSKDKJSL
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.PnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.BtnElse = new Gizmox.WebGUI.Forms.Button();
            this.BtnQr = new Gizmox.WebGUI.Forms.Button();
            this.DtpDkStop = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.LblSJ = new Gizmox.WebGUI.Forms.Label();
            this.DtpDkStart = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.Dgv = new Gizmox.WebGUI.Forms.DataGridView();
            this.DgvColTxtlx = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtDsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtjsdsk = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColTxtBl = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DgvColLnkxx = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.ctrlDownLoad1);
            this.PnlTop.Controls.Add(this.BtnElse);
            this.PnlTop.Controls.Add(this.BtnQr);
            this.PnlTop.Controls.Add(this.DtpDkStop);
            this.PnlTop.Controls.Add(this.label5);
            this.PnlTop.Controls.Add(this.LblSJ);
            this.PnlTop.Controls.Add(this.DtpDkStart);
            this.PnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(743, 80);
            this.PnlTop.TabIndex = 0;
            // 
            // BtnElse
            // 
            this.BtnElse.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnElse.CustomStyle = "F";
            this.BtnElse.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnElse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnElse.Location = new System.Drawing.Point(118, 46);
            this.BtnElse.Name = "BtnElse";
            this.BtnElse.Size = new System.Drawing.Size(75, 23);
            this.BtnElse.TabIndex = 9;
            this.BtnElse.Text = "导出";
            this.BtnElse.Click += new System.EventHandler(this.BtnElse_Click);
            // 
            // BtnQr
            // 
            this.BtnQr.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnQr.CustomStyle = "F";
            this.BtnQr.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQr.Location = new System.Drawing.Point(21, 46);
            this.BtnQr.Name = "BtnQr";
            this.BtnQr.Size = new System.Drawing.Size(75, 23);
            this.BtnQr.TabIndex = 8;
            this.BtnQr.Text = "查询";
            this.BtnQr.Click += new System.EventHandler(this.BtnQr_Click);
            // 
            // DtpDkStop
            // 
            this.DtpDkStop.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpDkStop.Checked = false;
            this.DtpDkStop.CustomFormat = "yyyy.MM.dd";
            this.DtpDkStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDkStop.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpDkStop.Location = new System.Drawing.Point(234, 13);
            this.DtpDkStop.Name = "DtpDkStop";
            this.DtpDkStop.Size = new System.Drawing.Size(133, 21);
            this.DtpDkStop.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(213, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "到";
            // 
            // LblSJ
            // 
            this.LblSJ.AutoSize = true;
            this.LblSJ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSJ.Location = new System.Drawing.Point(19, 17);
            this.LblSJ.Name = "LblSJ";
            this.LblSJ.Size = new System.Drawing.Size(53, 12);
            this.LblSJ.TabIndex = 0;
            this.LblSJ.Text = "打款时间";
            // 
            // DtpDkStart
            // 
            this.DtpDkStart.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpDkStart.Checked = false;
            this.DtpDkStart.CustomFormat = "yyyy.MM.dd";
            this.DtpDkStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDkStart.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpDkStart.Location = new System.Drawing.Point(76, 13);
            this.DtpDkStart.Name = "DtpDkStart";
            this.DtpDkStart.Size = new System.Drawing.Size(133, 21);
            this.DtpDkStart.TabIndex = 6;
            // 
            // Dgv
            // 
            this.Dgv.AllowDrag = false;
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
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
            this.DgvColTxtlx,
            this.DgvColTxtDsk,
            this.DgvColTxtjsdsk,
            this.DgvColTxtBl,
            this.DgvColLnkxx});
            this.Dgv.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            dataGridViewCellStyle7.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle7;
            this.Dgv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Dgv.EditMode = Gizmox.WebGUI.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv.Location = new System.Drawing.Point(0, 80);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.Dgv.RowHeadersWidth = 10;
            this.Dgv.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.Dgv.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(743, 480);
            this.Dgv.TabIndex = 1;
            this.Dgv.CellMouseDown += new Gizmox.WebGUI.Forms.DataGridViewCellMouseEventHandler(this.Dgv_CellMouseDown);
            // 
            // DgvColTxtlx
            // 
            this.DgvColTxtlx.DataPropertyName = "lx";
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtlx.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvColTxtlx.HeaderText = "类别";
            this.DgvColTxtlx.Name = "DgvColTxtlx";
            this.DgvColTxtlx.ReadOnly = true;
            this.DgvColTxtlx.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvColTxtlx.Width = 80;
            // 
            // DgvColTxtDsk
            // 
            this.DgvColTxtDsk.DataPropertyName = "dsk";
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtDsk.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvColTxtDsk.HeaderText = "总金额";
            this.DgvColTxtDsk.Name = "DgvColTxtDsk";
            this.DgvColTxtDsk.ReadOnly = true;
            this.DgvColTxtDsk.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtjsdsk
            // 
            this.DgvColTxtjsdsk.DataPropertyName = "jsdsk";
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtjsdsk.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvColTxtjsdsk.HeaderText = "及时发放金额";
            this.DgvColTxtjsdsk.Name = "DgvColTxtjsdsk";
            this.DgvColTxtjsdsk.ReadOnly = true;
            this.DgvColTxtjsdsk.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvColTxtBl
            // 
            this.DgvColTxtBl.DataPropertyName = "Bl";
            dataGridViewCellStyle5.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColTxtBl.DefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.DgvColLnkxx.DefaultCellStyle = dataGridViewCellStyle6;
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
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(215, 44);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 10;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // FrmDSKDKJSL
            // 
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(743, 560);
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PnlTop;
        //private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnElse;
        private Button BtnQr;
        private DateTimePicker DtpDkStop;
        private Label label5;
        private Label LblSJ;
        private DateTimePicker DtpDkStart;
        private DataGridView Dgv; 
        private DataGridViewTextBoxColumn DgvColTxtDsk;
        private DataGridViewTextBoxColumn DgvColTxtjsdsk;
        private DataGridViewTextBoxColumn DgvColTxtBl;
        private DataGridViewLinkColumn DgvColLnkxx;
        private DataGridViewTextBoxColumn DgvColTxtlx;
        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1; 


    }
}