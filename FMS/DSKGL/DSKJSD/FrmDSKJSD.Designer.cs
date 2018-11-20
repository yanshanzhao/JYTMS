using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKJSD
{
    partial class FrmDSKJSD
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
            this.ctrlDownLoad1 = new JY.CtrlPub.CtrlDownLoad();
            this.BtnElse = new Gizmox.WebGUI.Forms.Button();
            this.DtpSj = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlDownLoad1
            // 
            this.ctrlDownLoad1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlDownLoad1.Location = new System.Drawing.Point(358, 9);
            this.ctrlDownLoad1.Name = "ctrlDownLoad1";
            this.ctrlDownLoad1.Size = new System.Drawing.Size(80, 25);
            this.ctrlDownLoad1.TabIndex = 0;
            this.ctrlDownLoad1.Text = "CtrlDownLoad";
            this.ctrlDownLoad1.Visible = false;
            // 
            // BtnElse
            // 
            this.BtnElse.CustomStyle = "F";
            this.BtnElse.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnElse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnElse.Location = new System.Drawing.Point(168, 33);
            this.BtnElse.Name = "BtnElse";
            this.BtnElse.Size = new System.Drawing.Size(75, 23);
            this.BtnElse.TabIndex = 1;
            this.BtnElse.Text = "导出";
            this.BtnElse.Click += new System.EventHandler(this.BtnElse_Click);
            // 
            // DtpSj
            // 
            this.DtpSj.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.DtpSj.CustomFormat = "yyyy/MM/dd";
            this.DtpSj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSj.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.DtpSj.Location = new System.Drawing.Point(15, 33);
            this.DtpSj.Name = "DtpSj";
            this.DtpSj.Size = new System.Drawing.Size(131, 21);
            this.DtpSj.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtpSj);
            this.groupBox1.Controls.Add(this.BtnElse);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(45, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 122);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导出代收款结算单";
            // 
            // FrmDSKJSD
            // 
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlDownLoad1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(454, 243);
            this.Text = "FrmDSKJSD";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private JY.CtrlPub.CtrlDownLoad ctrlDownLoad1;
        private Button BtnElse;
        private DateTimePicker DtpSj;
        private GroupBox groupBox1;


    }
}