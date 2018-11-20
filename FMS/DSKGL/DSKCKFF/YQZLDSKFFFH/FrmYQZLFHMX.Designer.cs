using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKCKFF.YQZLDSKFFFH
{
    partial class FrmYQZLFHMX
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
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.TxtZje = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.TxtBs = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnCancel = new Gizmox.WebGUI.Forms.Button();
            this.DSYQZLFFFH1 = new FMS.DSKGL.DSKCKFF.YQZLDSKFFFH.DSYQZLFFFH();
            this.VfmsYQZLDSKFFMxTableAdapter1 = new FMS.DSKGL.DSKCKFF.YQZLDSKFFFH.DSYQZLFFFHTableAdapters.VfmsYQZLDSKFFMxTableAdapter();
            this.VfmsdskckffmxlogTableAdapter1 = new FMS.DSKGL.DSKCKFF.YQZLDSKFFFH.DSYQZLFFFHTableAdapters.VfmsdskckffmxlogTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DSYQZLFFFH1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "实际发放总金额";
            // 
            // TxtZje
            // 
            this.TxtZje.AllowDrag = false;
            this.TxtZje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtZje.Location = new System.Drawing.Point(90, 12);
            this.TxtZje.Name = "TxtZje";
            this.TxtZje.Size = new System.Drawing.Size(163, 21);
            this.TxtZje.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "发放总笔数";
            // 
            // TxtBs
            // 
            this.TxtBs.AllowDrag = false;
            this.TxtBs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBs.Location = new System.Drawing.Point(90, 40);
            this.TxtBs.Name = "TxtBs";
            this.TxtBs.Size = new System.Drawing.Size(163, 21);
            this.TxtBs.TabIndex = 1;
            // 
            // BtnSave
            // 
            this.BtnSave.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(58, 72);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "确定";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.ButtonStyle = Gizmox.WebGUI.Forms.ButtonStyle.Custom;
            this.BtnCancel.CustomStyle = "F";
            this.BtnCancel.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.Location = new System.Drawing.Point(178, 72);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // DSYQZLFFFH1
            // 
            this.DSYQZLFFFH1.DataSetName = "DSYQZLFFFH";
            this.DSYQZLFFFH1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VfmsYQZLDSKFFMxTableAdapter1
            // 
            this.VfmsYQZLDSKFFMxTableAdapter1.ClearBeforeFill = true;
            // 
            // VfmsdskckffmxlogTableAdapter1
            // 
            this.VfmsdskckffmxlogTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmYQZLFHMX
            // 
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtBs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtZje);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(267, 124);
            this.Text = "银企直连复核明细";
            ((System.ComponentModel.ISupportInitialize)(this.DSYQZLFFFH1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private TextBox TxtZje;
        private Label label2;
        private TextBox TxtBs;
        private Button BtnSave;
        private Button BtnCancel;
        private DSYQZLFFFH DSYQZLFFFH1;
        private DSYQZLFFFHTableAdapters.VfmsYQZLDSKFFMxTableAdapter VfmsYQZLDSKFFMxTableAdapter1;
        private DSYQZLFFFHTableAdapters.VfmsdskckffmxlogTableAdapter VfmsdskckffmxlogTableAdapter1;


    }
}