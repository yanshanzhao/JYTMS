using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.JYLXWH
{
    partial class FrmSort
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
            this.LstB = new Gizmox.WebGUI.Forms.ListBox();
            this.BtnUp = new Gizmox.WebGUI.Forms.Button();
            this.BtnDown = new Gizmox.WebGUI.Forms.Button();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnCancel = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // LstB
            // 
            this.LstB.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstB.Location = new System.Drawing.Point(15, 19);
            this.LstB.Name = "LstB";
            this.LstB.Size = new System.Drawing.Size(192, 268);
            this.LstB.TabIndex = 0;
            // 
            // BtnUp
            // 
            this.BtnUp.CustomStyle = "F";
            this.BtnUp.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnUp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUp.Location = new System.Drawing.Point(216, 30);
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Size = new System.Drawing.Size(23, 48);
            this.BtnUp.TabIndex = 1;
            this.BtnUp.Text = "↑";
            this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // BtnDown
            // 
            this.BtnDown.CustomStyle = "F";
            this.BtnDown.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnDown.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDown.Location = new System.Drawing.Point(216, 100);
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Size = new System.Drawing.Size(23, 48);
            this.BtnDown.TabIndex = 1;
            this.BtnDown.Text = "↓";
            this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(15, 299);
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
            this.BtnCancel.Location = new System.Drawing.Point(132, 299);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmSort
            // 
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnDown);
            this.Controls.Add(this.BtnUp);
            this.Controls.Add(this.LstB);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(255, 341);
            this.Text = "收款顺序";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox LstB;
        private Button BtnUp;
        private Button BtnDown;
        private Button BtnSave;
        private Button BtnCancel;


    }
}