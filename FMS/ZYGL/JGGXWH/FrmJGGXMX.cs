#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pri;
using FMS.ZYGL.JGGXWH.DSJGGXWHTableAdapters;
using JY.CtrlPub;
using FMS.SeleFrm;
using JY.Pub;

#endregion

namespace FMS.ZYGL.JGGXWH
{
    public partial class FrmJGGXMX : Form
    {
        #region ��Ա����
        private BindingSource Bds;
        private FrmSelectJg PriFrmSelectJg;
        private ClsG ObjG;
        private DSJGGXWH.VfmsjggxRow PriCurJggxRow;
        private VfmsjggxTableAdapter VfmsjggxTableAdapter1;
        public EnumNEDD PubEnumNEDD;
        #endregion
        public FrmJGGXMX()
        {
            InitializeComponent();
        }
        #region ��ʼ������
        public void Prepare(BindingSource aBds, EnumNEDD aEnumNEDD)
        {
            Bds = aBds;
            ObjG = Session["ObjG"] as ClsG;
            PubEnumNEDD = aEnumNEDD;
            VfmsjggxTableAdapter1 = new VfmsjggxTableAdapter();
            Rebind();
            ClsPopulateCmbDsS.PopuFMS_Jggx(CmbGxzl);
            CmbGxzl.SelectedIndex = 1;
            if (aEnumNEDD == EnumNEDD.New)
                Bds.AddNew();
            PriCurJggxRow = ((DataRowView)Bds.Current).Row as DSJGGXWH.VfmsjggxRow;


        }
        #endregion
        #region  ���ݰ�
        private void Rebind()
        {
            this.TxtYjg.DataBindings.Clear();
            this.TxtYjg.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "jgmc", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtGxjg.DataBindings.Clear();
            this.TxtGxjg.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "tojgmc", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.CmbGxzl.DataBindings.Clear();
            this.CmbGxzl.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("SelectedValue", this.Bds, "gxzl", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
        }
        #endregion

        #region ����
        private void BtnSave_Click(object sender, EventArgs e)
        {
            #region ������֤
            if (string.IsNullOrEmpty(TxtYjg.Text.Trim()))
            {
                ClsMsgBox.Ts("Դ����������Ϊ�գ���ѡ��", this, TxtYjg, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtGxjg.Text.Trim()))
            {
                ClsMsgBox.Ts("��ϵ����������Ϊ�գ���ѡ��", this, TxtGxjg, ObjG.CustomMsgBox);
                return;
            }
            if (CmbGxzl.SelectedIndex == 0)
            {
                ClsMsgBox.Ts("��ѡ���ϵ���࣡", this, CmbGxzl, ObjG.CustomMsgBox);
                return;
            }
            if (TxtYjg.Text == TxtGxjg.Text)
            {
                ClsMsgBox.Ts("Դ�����͹�ϵ����������ͬ��", ObjG.CustomMsgBox, this);
                return;
            }
            #endregion
            try
            {
                Bds.EndEdit();
                VfmsjggxTableAdapter1.Update(PriCurJggxRow);
                this.DialogResult = DialogResult.OK;
                this.Close();
                ClsMsgBox.Ts("����" + TxtYjg.Text + "��" + TxtGxjg.Text + "��"+CmbGxzl.Text+"�ɹ���", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                string ExStr = ex.Message;
                if (ExStr.LastIndexOf("�ظ�") > 0)
                    ClsMsgBox.Ts("����ʧ�ܣ�" + TxtYjg.Text + "�����Ѿ�����" + CmbGxzl.Text, this, CmbGxzl, ObjG.CustomMsgBox);
                else
                    ClsMsgBox.Cw("����ʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }


        }
        #endregion
        #region ����ѡ��
        //Դ����
        private void BtnYjg_Click(object sender, EventArgs e)
        {
            PriFrmSelectJg = new FrmSelectJg();
            PriFrmSelectJg.Prepare();
            PriFrmSelectJg.ShowDialog();
            PriFrmSelectJg.FormClosed += new FormClosedEventHandler(FrmJGCX1_FormClosed);
        }
        private void FrmJGCX1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
            {
                PriCurJggxRow.jgmc = f.PubDictAttrs["mc"];
                PriCurJggxRow.jgid = Convert.ToInt16(f.PubDictAttrs["id"]);
                this.TxtYjg.Text = f.PubDictAttrs["mc"];
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtYjg.Text = "";
            }
            f.Dispose();
        }
        //��ϵ����
        private void BtnGxjg_Click(object sender, EventArgs e)
        {
            PriFrmSelectJg = new FrmSelectJg();
            PriFrmSelectJg.Prepare();
            PriFrmSelectJg.ShowDialog();
            PriFrmSelectJg.FormClosed += new FormClosedEventHandler(FrmJGCX2_FormClosed);
        }
        private void FrmJGCX2_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (FrmSelectJg f = sender as FrmSelectJg)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    PriCurJggxRow.tojgmc = f.PubDictAttrs["mc"];
                    PriCurJggxRow.tojgid = Convert.ToInt16(f.PubDictAttrs["id"]);
                    this.TxtGxjg.Text = f.PubDictAttrs["mc"];
                }
                else if (f.DialogResult == DialogResult.No)
                {
                    this.TxtGxjg.Text = "";
                }
            }
        }
        #endregion

        #region ȡ��
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}