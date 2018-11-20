using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.ZJDB.YQZLDP
{
    partial class FrmJe
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
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnCancel = new Gizmox.WebGUI.Forms.Button();
            this.LblJgcx = new Gizmox.WebGUI.Forms.Label();
            this.TxtJe = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(22, 51);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "确定";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.CustomStyle = "F";
            this.BtnCancel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.Location = new System.Drawing.Point(134, 51);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblJgcx
            // 
            this.LblJgcx.AutoSize = true;
            this.LblJgcx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJgcx.Location = new System.Drawing.Point(14, 20);
            this.LblJgcx.Name = "LblJgcx";
            this.LblJgcx.Size = new System.Drawing.Size(53, 12);
            this.LblJgcx.TabIndex = 0;
            this.LblJgcx.Text = "输入转账金额";
            // 
            // TxtJe
            // 
            this.TxtJe.AllowDrag = false;
            this.TxtJe.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJe.Location = new System.Drawing.Point(108, 16);
            this.TxtJe.Name = "TxtJe";
            this.TxtJe.Size = new System.Drawing.Size(144, 21);
            this.TxtJe.TabIndex = 0;
            this.TxtJe.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.TxtJe_EnterKeyDown);
            // 
            // FrmJe
            // 
            this.Controls.Add(this.TxtJe);
            this.Controls.Add(this.LblJgcx);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(264, 93);
            this.Text = "转账金额";
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnSave;
        private Button BtnCancel;
        private Label LblJgcx;
        private TextBox TxtJe;


    }
}
