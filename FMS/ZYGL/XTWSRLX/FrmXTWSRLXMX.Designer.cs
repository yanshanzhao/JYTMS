using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.XTWSRLX
{
    partial class FrmXTWSRLXMX
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
            this.Lblbh = new Gizmox.WebGUI.Forms.Label();
            this.TxtBh = new Gizmox.WebGUI.Forms.TextBox();
            this.LblName = new Gizmox.WebGUI.Forms.Label();
            this.TxtName = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnQX = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // Lblbh
            // 
            this.Lblbh.AutoSize = true;
            this.Lblbh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblbh.Location = new System.Drawing.Point(36, 28);
            this.Lblbh.Name = "Lblbh";
            this.Lblbh.Size = new System.Drawing.Size(35, 13);
            this.Lblbh.TabIndex = 0;
            this.Lblbh.Text = "编号:";
            // 
            // TxtBh
            // 
            this.TxtBh.AllowDrag = false;
            this.TxtBh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBh.Location = new System.Drawing.Point(74, 25);
            this.TxtBh.Name = "TxtBh";
            this.TxtBh.Size = new System.Drawing.Size(127, 21);
            this.TxtBh.TabIndex = 1;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.Location = new System.Drawing.Point(219, 28);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(35, 13);
            this.LblName.TabIndex = 0;
            this.LblName.Text = "名称:";
            // 
            // TxtName
            // 
            this.TxtName.AllowDrag = false;
            this.TxtName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtName.Location = new System.Drawing.Point(257, 25);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(127, 21);
            this.TxtName.TabIndex = 1;
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(221, 80);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnQX
            // 
            this.BtnQX.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnQX.CustomStyle = "F";
            this.BtnQX.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnQX.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQX.Location = new System.Drawing.Point(321, 80);
            this.BtnQX.Name = "BtnQX";
            this.BtnQX.Size = new System.Drawing.Size(75, 23);
            this.BtnQX.TabIndex = 2;
            this.BtnQX.Text = "取消";
            this.BtnQX.Click += new System.EventHandler(this.BtnQX_Click);
            // 
            // FrmXTWSRLXMX
            // 
            this.Controls.Add(this.BtnQX);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.TxtBh);
            this.Controls.Add(this.Lblbh);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(417, 116);
            this.Text = "系统外收入类型新增";
            this.ResumeLayout(false);

        }

        #endregion

        private Label Lblbh;
        private TextBox TxtBh;
        private Label LblName;
        private TextBox TxtName;
        private Button BtnSave;
        private Button BtnQX;


    }
}