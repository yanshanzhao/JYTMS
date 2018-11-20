using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKEWMZFXZ
{
    partial class FrmDSKEWMZFXZ
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
            this.BtnTS = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnTS
            // 
            this.BtnTS.CustomStyle = "F";
            this.BtnTS.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnTS.Font = new System.Drawing.Font("ÀŒÃÂ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTS.Location = new System.Drawing.Point(43, 42);
            this.BtnTS.Name = "BtnTS";
            this.BtnTS.Size = new System.Drawing.Size(75, 23);
            this.BtnTS.TabIndex = 0;
            this.BtnTS.Text = "œ¬‘ÿ";
            this.BtnTS.Click += new System.EventHandler(this.BtnTS_Click);
            // 
            // FrmDSKEWMZFXZ
            // 
            this.Controls.Add(this.BtnTS);
            this.Size = new System.Drawing.Size(684, 419);
            this.Text = "FrmDSKEWMZFXZ";
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnTS;


    }
}