using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace FMS.WDXXWH
{
    partial class FrmWDXXMX
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
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.splitContainer1 = new Gizmox.WebGUI.Forms.SplitContainer();
            this.FrmTrv = new JYPubFiles.CtrlPub.FrmTreeView();
            this.BtnCal = new Gizmox.WebGUI.Forms.Button();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.RBtnWx = new Gizmox.WebGUI.Forms.RadioButton();
            this.RBtnYx = new Gizmox.WebGUI.Forms.RadioButton();
            this.TxtWdbz = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.TxtDqmc = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.BtnSeleDq = new Gizmox.WebGUI.Forms.Button();
            this.TxtWdmc = new Gizmox.WebGUI.Forms.TextBox();
            this.LblFL = new Gizmox.WebGUI.Forms.Label();
            this.v_wdTableAdapter1 = new FMS.JCSJ.WDXXWH.DSWDXXTableAdapters.v_wdTableAdapter();
            this.dswdxx1 = new FMS.JCSJ.WDXXWH.DSWDXX();
            this.twdmxTableAdapter1 = new FMS.JCSJ.WDXXWH.DSWDXXTableAdapters.TwdmxTableAdapter();
            this.BdsMx = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.Bds = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.radioButton1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.tableAdapterManager1 = new FMS.JCSJ.WDXXWH.DSWDXXTableAdapters.TableAdapterManager();
            this.twdTableAdapter1 = new FMS.JCSJ.WDXXWH.DSWDXXTableAdapters.TwdTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dswdxx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BdsMx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(364, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 489);
            // 
            // splitContainer1
            // 
            this.splitContainer1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.splitContainer1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AllowDrag = false;
            this.splitContainer1.Panel1.AllowDragTargetsPropagation = false;
            this.splitContainer1.Panel1.AllowDrop = true;
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.FrmTrv);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Panel1MinSize = 235;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.BtnCal);
            this.splitContainer1.Panel2.Controls.Add(this.BtnSave);
            this.splitContainer1.Panel2.Controls.Add(this.RBtnWx);
            this.splitContainer1.Panel2.Controls.Add(this.RBtnYx);
            this.splitContainer1.Panel2.Controls.Add(this.TxtWdbz);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.TxtDqmc);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.BtnSeleDq);
            this.splitContainer1.Panel2.Controls.Add(this.TxtWdmc);
            this.splitContainer1.Panel2.Controls.Add(this.LblFL);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Size = new System.Drawing.Size(624, 489);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 0;
            // 
            // FrmTrv
            // 
            this.FrmTrv.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.FrmTrv.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(10);
            this.FrmTrv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.FrmTrv.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrmTrv.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.FrmTrv.Location = new System.Drawing.Point(0, 0);
            this.FrmTrv.Name = "FrmTrv";
            this.FrmTrv.Size = new System.Drawing.Size(235, 489);
            this.FrmTrv.TabIndex = 1;
            this.FrmTrv.Text = "FrmTreeView";
            // 
            // BtnCal
            // 
            this.BtnCal.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnCal.CustomStyle = "F";
            this.BtnCal.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnCal.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCal.Location = new System.Drawing.Point(173, 267);
            this.BtnCal.Name = "BtnCal";
            this.BtnCal.Size = new System.Drawing.Size(75, 23);
            this.BtnCal.TabIndex = 7;
            this.BtnCal.Text = "取消";
            this.BtnCal.Click += new System.EventHandler(this.BtnCal_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSave.CustomStyle = "F";
            this.BtnSave.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(63, 267);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // RBtnWx
            // 
            this.RBtnWx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RBtnWx.Location = new System.Drawing.Point(170, 137);
            this.RBtnWx.Name = "RBtnWx";
            this.RBtnWx.Size = new System.Drawing.Size(53, 17);
            this.RBtnWx.TabIndex = 4;
            this.RBtnWx.Text = "无效";
            // 
            // RBtnYx
            // 
            this.RBtnYx.Checked = true;
            this.RBtnYx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBtnYx.Location = new System.Drawing.Point(98, 137);
            this.RBtnYx.Name = "RBtnYx";
            this.RBtnYx.Size = new System.Drawing.Size(62, 17);
            this.RBtnYx.TabIndex = 3;
            this.RBtnYx.Text = "有效";
            // 
            // TxtWdbz
            // 
            this.TxtWdbz.AllowDrag = false;
            this.TxtWdbz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtWdbz.Location = new System.Drawing.Point(97, 178);
            this.TxtWdbz.Name = "TxtWdbz";
            this.TxtWdbz.Size = new System.Drawing.Size(151, 21);
            this.TxtWdbz.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "网点备注";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "网点状态";
            // 
            // TxtDqmc
            // 
            this.TxtDqmc.AllowDrag = false;
            this.TxtDqmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDqmc.Location = new System.Drawing.Point(97, 87);
            this.TxtDqmc.Name = "TxtDqmc";
            this.TxtDqmc.Size = new System.Drawing.Size(151, 21);
            this.TxtDqmc.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "大区名称";
            // 
            // BtnSeleDq
            // 
            this.BtnSeleDq.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.BtnSeleDq.CustomStyle = "F";
            this.BtnSeleDq.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.BtnSeleDq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSeleDq.Location = new System.Drawing.Point(251, 87);
            this.BtnSeleDq.Name = "BtnSeleDq";
            this.BtnSeleDq.Size = new System.Drawing.Size(20, 20);
            this.BtnSeleDq.TabIndex = 3;
            this.BtnSeleDq.Text = "》";
            this.BtnSeleDq.Click += new System.EventHandler(this.BtnSeleDq_Click);
            // 
            // TxtWdmc
            // 
            this.TxtWdmc.AllowDrag = false;
            this.TxtWdmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtWdmc.Location = new System.Drawing.Point(97, 42);
            this.TxtWdmc.Name = "TxtWdmc";
            this.TxtWdmc.Size = new System.Drawing.Size(151, 21);
            this.TxtWdmc.TabIndex = 0;
            // 
            // LblFL
            // 
            this.LblFL.AutoSize = true;
            this.LblFL.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFL.Location = new System.Drawing.Point(41, 45);
            this.LblFL.Name = "LblFL";
            this.LblFL.Size = new System.Drawing.Size(59, 12);
            this.LblFL.TabIndex = 0;
            this.LblFL.Text = "网点名称";
            // 
            // v_wdTableAdapter1
            // 
            this.v_wdTableAdapter1.ClearBeforeFill = true;
            // 
            // dswdxx1
            // 
            this.dswdxx1.DataSetName = "DSWDXX";
            this.dswdxx1.EnforceConstraints = false;
            this.dswdxx1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // twdmxTableAdapter1
            // 
            this.twdmxTableAdapter1.ClearBeforeFill = true;
            // 
            // BdsMx
            // 
            this.BdsMx.AllowNew = true;
            this.BdsMx.DataMember = "FK_v_wd_Twdmx";
            this.BdsMx.DataSource = this.Bds;
            // 
            // Bds
            // 
            this.Bds.DataMember = "v_wd";
            this.Bds.DataSource = this.dswdxx1;
            // 
            // radioButton1
            // 
            this.radioButton1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(88, 107);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(62, 17);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.Text = "有效";
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.TwdmxTableAdapter = this.twdmxTableAdapter1;
            this.tableAdapterManager1.TwdTableAdapter = this.twdTableAdapter1;
            this.tableAdapterManager1.UpdateOrder = FMS.JCSJ.WDXXWH.DSWDXXTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager1.v_wdTableAdapter = this.v_wdTableAdapter1;
            // 
            // twdTableAdapter1
            // 
            this.twdTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmWDXXMX
            // 
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(624, 489);
            this.Text = "网点信息明细";
            ((System.ComponentModel.ISupportInitialize)(this.dswdxx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BdsMx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private SplitContainer splitContainer1;
        private JCSJ.WDXXWH.DSWDXXTableAdapters.v_wdTableAdapter v_wdTableAdapter1;
        private JCSJ.WDXXWH.DSWDXX dswdxx1;
        private JCSJ.WDXXWH.DSWDXXTableAdapters.TableAdapterManager tableAdapterManager1;
        private JCSJ.WDXXWH.DSWDXXTableAdapters.TwdmxTableAdapter twdmxTableAdapter1;
        private BindingSource Bds;
        private BindingSource BdsMx;
        private RadioButton radioButton1;
        private JYPubFiles.CtrlPub.FrmTreeView FrmTrv;
        private Button BtnCal;
        private Button BtnSave;
        private RadioButton RBtnWx;
        private RadioButton RBtnYx;
        private TextBox TxtWdbz;
        private Label label3;
        private Label label2;
        private TextBox TxtDqmc;
        private Label label1;
        private Button BtnSeleDq;
        private TextBox TxtWdmc;
        private Label LblFL;
        private JCSJ.WDXXWH.DSWDXXTableAdapters.TwdTableAdapter twdTableAdapter1;


    }
}