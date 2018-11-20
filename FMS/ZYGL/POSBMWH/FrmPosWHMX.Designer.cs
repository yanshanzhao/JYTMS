using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.ZYGL.POSBMWH
{
    partial class FrmPosWHMX
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
            this.TxtPosBh = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.TxtJgmc = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnCanCell = new Gizmox.WebGUI.Forms.Button();
            this.DSPOSWH1 = new FMS.ZYGL.POSBMWH.DSPOSWH();
            this.TjigouTableAdapter1 = new FMS.ZYGL.POSBMWH.DSPOSWHTableAdapters.tjigouTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DSPOSWH1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtPosBh
            // 
            this.TxtPosBh.AllowDrag = false;
            this.TxtPosBh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPosBh.Location = new System.Drawing.Point(67, 41);
            this.TxtPosBh.MaxLength = 20;
            this.TxtPosBh.Name = "TxtPosBh";
            this.TxtPosBh.Size = new System.Drawing.Size(167, 21);
            this.TxtPosBh.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "POS编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "机构名称";
            // 
            // TxtJgmc
            // 
            this.TxtJgmc.AllowDrag = false;
            this.TxtJgmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJgmc.Location = new System.Drawing.Point(67, 7);
            this.TxtJgmc.Name = "TxtJgmc";
            this.TxtJgmc.ReadOnly = true;
            this.TxtJgmc.Size = new System.Drawing.Size(167, 21);
            this.TxtJgmc.TabIndex = 5;
            // 
            // BtnSave
            // 
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(39, 77);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCanCell
            // 
            this.BtnCanCell.CustomStyle = "F";
            this.BtnCanCell.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnCanCell.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCanCell.Location = new System.Drawing.Point(159, 77);
            this.BtnCanCell.Name = "BtnCanCell";
            this.BtnCanCell.Size = new System.Drawing.Size(75, 23);
            this.BtnCanCell.TabIndex = 3;
            this.BtnCanCell.Text = "取消";
            this.BtnCanCell.Click += new System.EventHandler(this.BtnCanCell_Click);
            // 
            // DSPOSWH1
            // 
            this.DSPOSWH1.DataSetName = "DSPOSWH";
            this.DSPOSWH1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TjigouTableAdapter1
            // 
            this.TjigouTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmPosWHMX
            // 
            this.Controls.Add(this.BtnCanCell);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtJgmc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtPosBh);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(264, 110);
            this.Text = "POS维护明细";
            ((System.ComponentModel.ISupportInitialize)(this.DSPOSWH1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox TxtPosBh;
        private Label label1;
        private Label label2;
        private TextBox TxtJgmc;
        private Button BtnSave;
        private Button BtnCanCell;
        private DSPOSWH DSPOSWH1;
        private DSPOSWHTableAdapters.tjigouTableAdapter TjigouTableAdapter1;


    }
}