using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.DSKGL.DSKFFSJ
{
    partial class FrmDskffsjmx
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
            this.TxtBh = new Gizmox.WebGUI.Forms.TextBox();
            this.TxtMc = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.TxtSort = new Gizmox.WebGUI.Forms.TextBox();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.BtnClose = new Gizmox.WebGUI.Forms.Button();
            this.TxtDay = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.TdskffsjTableAdapter1 = new FMS.DSKGL.DSKFFSJ.DSDSKFFSJTableAdapters.TdskffsjTableAdapter();
            this.DSDSKFFSJ1 = new FMS.DSKGL.DSKFFSJ.DSDSKFFSJ();
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.CHbYx = new Gizmox.WebGUI.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DSDSKFFSJ1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "编号";
            // 
            // TxtBh
            // 
            this.TxtBh.AllowDrag = false;
            this.TxtBh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBh.Location = new System.Drawing.Point(59, 12);
            this.TxtBh.Name = "TxtBh";
            this.TxtBh.Size = new System.Drawing.Size(116, 21);
            this.TxtBh.TabIndex = 1;
            // 
            // TxtMc
            // 
            this.TxtMc.AllowDrag = false;
            this.TxtMc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMc.Location = new System.Drawing.Point(59, 39);
            this.TxtMc.Name = "TxtMc";
            this.TxtMc.Size = new System.Drawing.Size(116, 21);
            this.TxtMc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "排序";
            // 
            // TxtSort
            // 
            this.TxtSort.AllowDrag = false;
            this.TxtSort.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSort.Location = new System.Drawing.Point(59, 66);
            this.TxtSort.Name = "TxtSort";
            this.TxtSort.ReadOnly = true;
            this.TxtSort.Size = new System.Drawing.Size(116, 21);
            this.TxtSort.TabIndex = 1;
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(29, 147);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnClose.CustomStyle = "F";
            this.BtnClose.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Location = new System.Drawing.Point(124, 147);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 6;
            this.BtnClose.Text = "关闭";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // TxtDay
            // 
            this.TxtDay.AllowDrag = false;
            this.TxtDay.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDay.Location = new System.Drawing.Point(59, 93);
            this.TxtDay.Name = "TxtDay";
            this.TxtDay.Size = new System.Drawing.Size(116, 21);
            this.TxtDay.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "发放天数";
            // 
            // TdskffsjTableAdapter1
            // 
            this.TdskffsjTableAdapter1.ClearBeforeFill = true;
            // 
            // DSDSKFFSJ1
            // 
            this.DSDSKFFSJ1.DataSetName = "DSDSKFFSJ";
            this.DSDSKFFSJ1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Bds
            // 
            this.Bds.DataMember = "Tdskffsj";
            this.Bds.DataSource = this.DSDSKFFSJ1;
            // 
            // CHbYx
            // 
            this.CHbYx.AutoSize = true;
            this.CHbYx.Checked = true;
            this.CHbYx.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.CHbYx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHbYx.Location = new System.Drawing.Point(59, 124);
            this.CHbYx.Name = "CHbYx";
            this.CHbYx.Size = new System.Drawing.Size(48, 16);
            this.CHbYx.TabIndex = 7;
            this.CHbYx.Text = "有效";
            // 
            // FrmDskffsjmx
            // 
            this.Controls.Add(this.CHbYx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtDay);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtSort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtMc);
            this.Controls.Add(this.TxtBh);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(217, 179);
            this.Text = "发放时间明细";
            ((System.ComponentModel.ISupportInitialize)(this.DSDSKFFSJ1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private TextBox TxtBh;
        private TextBox TxtMc;
        private Label label2;
        private Label label3;
        private TextBox TxtSort;
        private Button BtnSave;
        private Button BtnClose;
        private DSDSKFFSJTableAdapters.TdskffsjTableAdapter TdskffsjTableAdapter1;
        private DSDSKFFSJ DSDSKFFSJ1;
        private BindingSource Bds;
        private TextBox TxtDay;
        private Label label4;
        private CheckBox CHbYx;


    }
}