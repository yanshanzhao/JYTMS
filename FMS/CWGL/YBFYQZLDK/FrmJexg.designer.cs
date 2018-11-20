using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.CWGL.YBFYQZLDK
{
    partial class FrmJexg
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
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.TxtOldJe = new Gizmox.WebGUI.Forms.TextBox();
            //this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            //this.DSDSKDK1 = new FMS.DSKGL.DSKDK.DSDSKDK();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.TxtNewJe = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnCancel = new Gizmox.WebGUI.Forms.Button();
            //this.TfmsdskdkjeTableAdapter1 = new FMS.DSKGL.DSKDK.DSDSKDKTableAdapters.TfmsdskdkjeTableAdapter();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            //((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.DSDSKDK1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "原代扣金额";
            // 
            // TxtOldJe
            // 
            this.TxtOldJe.AllowDrag = false;
            this.TxtOldJe.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOldJe.Location = new System.Drawing.Point(87, 12);
            this.TxtOldJe.Name = "TxtOldJe";
            this.TxtOldJe.ReadOnly = true;
            this.TxtOldJe.Size = new System.Drawing.Size(152, 21);
            this.TxtOldJe.TabIndex = 1;
            //// 
            //// Bds
            //// 
            //this.Bds.DataMember = "Tfmsdskdkje";
            //this.Bds.DataSource = this.DSDSKDK1;
            //// 
            //// DSDSKDK1
            //// 
            //this.DSDSKDK1.DataSetName = "DSDSKDK";
            //this.DSDSKDK1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "修改后金额";
            // 
            // TxtNewJe
            // 
            this.TxtNewJe.AllowDrag = false;
            this.TxtNewJe.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNewJe.Location = new System.Drawing.Point(87, 45);
            this.TxtNewJe.Name = "TxtNewJe";
            this.TxtNewJe.Size = new System.Drawing.Size(152, 21);
            this.TxtNewJe.TabIndex = 1;
            // 
            // BtnSave
            // 
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(32, 80);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.CustomStyle = "F";
            this.BtnCancel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.Location = new System.Drawing.Point(164, 80);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TfmsdskdkjeTableAdapter1
            // 
            //this.TfmsdskdkjeTableAdapter1.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(242, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "*";
            // 
            // FrmJexg
            // 
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtNewJe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtOldJe);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(271, 118);
            this.Text = "代扣金额修改";
            //((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.DSDSKDK1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private TextBox TxtOldJe;
        private Label label2;
        private TextBox TxtNewJe;
        private Button BtnSave;
        private Button BtnCancel;
        //private DSDSKDK DSDSKDK1;
        //private DSDSKDKTableAdapters.TfmsdskdkjeTableAdapter TfmsdskdkjeTableAdapter1;
        //private BindingSource Bds;
        private Label label3;


    }
}