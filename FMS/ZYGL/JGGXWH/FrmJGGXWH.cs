#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pri;
using JY.Pub;
using JYPubFiles.Classes;
using FMS.SeleFrm;

#endregion

namespace FMS.ZYGL.JGGXWH
{
    public partial class FrmJGGXWH : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private FrmSelectJg PriFrmSelectJg;
        private DSJGGXWH.VfmsjggxRow PriJggxRow
        {
            get
            {
                if (Bds.Current == null)
                    return null;
                return ((DataRowView)Bds.Current).Row as DSJGGXWH.VfmsjggxRow;
            }
            set
            {
                PriJggxRow = value;
            }
        }
        private string PriWhere;
        #endregion
        public FrmJGGXWH()
        {
            InitializeComponent();
        }
        #region ��ʼ������
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            VfmsjggxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            ClsPopulateCmbDsS.PopuFMS_Jggx(CmbGxzl);
        }
        #endregion

        #region ����
        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmJGGXMX f = new FrmJGGXMX();
            f.Prepare(Bds, EnumNEDD.New);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmJGGXMX f = sender as FrmJGGXMX;
            if (f.DialogResult != DialogResult.OK && f.PubEnumNEDD == EnumNEDD.New)
            {
                this.Bds.RemoveCurrent();
                this.Bds.CancelEdit();
            }
            else if (f.DialogResult != DialogResult.OK)
            {
                this.Bds.CancelEdit();
            }
            DSjggxwh1.RejectChanges();
            TxtJl.Text = "����" + Bds.Count + "����Ϣ";
        }
        #endregion

        #region �༭
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (PriJggxRow == null)
            {
                ClsMsgBox.Ts("û�пɱ༭����Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            FrmJGGXMX f = new FrmJGGXMX();
            f.Prepare(Bds, EnumNEDD.Edit);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }
        #endregion

        #region ɾ��
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (PriJggxRow == null)
            {
                ClsMsgBox.Ts("û��Ҫɾ������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            ClsMsgBox.YesNo("ȷ��Ҫɾ���û�����ϵ��", new EventHandler(JGGX_Delete), ObjG.CustomMsgBox, this);
        }
        public void JGGX_Delete(object sender, EventArgs e)
        {
            Form f = sender as Form;
            FrmMsgBox frm = new FrmMsgBox();
            if (f.DialogResult == DialogResult.Yes)
            {
                try
                {
                    VfmsjggxTableAdapter1.DeleteById(PriJggxRow.id);
                    Bds.RemoveCurrent();
                    DSjggxwh1.AcceptChanges();
                    ClsMsgBox.Ts("ɾ���ɹ���", frm, this);
                    ClsD.TurnToBdsPosPage(Dgv);
                    TxtJl.Text = "����" + Bds.Count + "����Ϣ";
                }
                catch (Exception ex)
                {
                    string ExStr = ex.Message;
                    if (ExStr.LastIndexOf("REFERENCE") > 0)
                        ClsMsgBox.Ts(PriJggxRow.jgmc + "����ʹ�ã�����ɾ��", frm, this);
                    else
                        ClsMsgBox.Cw("ɾ��ʧ�ܣ�", ex, frm, this);
                }
            }
        }
        #endregion

        #region ����ѡ��
        private void BtnYjg_Click(object sender, EventArgs e)
        {
            PriFrmSelectJg = new FrmSelectJg();
            PriFrmSelectJg.Prepare();
            PriFrmSelectJg.ShowDialog();
            PriFrmSelectJg.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmJGCX1_FormClosed);
        }
        private void FrmJGCX1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
                this.TxtYjg.Text = f.PubDictAttrs["mc"];
            else if (f.DialogResult == DialogResult.No)
                this.TxtYjg.Text = "";
            f.Dispose();
        }

        private void BtnGxjg_Click(object sender, EventArgs e)
        {
            PriFrmSelectJg = new FrmSelectJg();
            PriFrmSelectJg.Prepare();
            PriFrmSelectJg.ShowDialog();
            PriFrmSelectJg.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmJGCX2_FormClosed);
        }
        private void FrmJGCX2_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (FrmSelectJg f = sender as FrmSelectJg)
            {
                if (f.DialogResult == DialogResult.OK)
                    this.TxtGxjg.Text = f.PubDictAttrs["mc"];
                else if (f.DialogResult == DialogResult.No)
                    this.TxtGxjg.Text = "";
            }
        }
        #endregion

        #region ��ѯ
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PriWhere = "  ";
            PriWhere += CmbGxzl.SelectedIndex == 0 ? "" : " and gxzl='" + CmbGxzl.SelectedValue + "'";
            PriWhere += string.IsNullOrEmpty(TxtYjg.Text.Trim()) ? "" : " and jgmc like '%" + TxtYjg.Text.Trim() + "%'";
            PriWhere += string.IsNullOrEmpty(TxtGxjg.Text.Trim()) ? "" : " and tojgmc like '%" + TxtGxjg.Text.Trim() + "%'";
            PriWhere = PriWhere.Trim();
            if (PriWhere.Length > 0)
                PriWhere = " where " + PriWhere.Remove(0, 3);
          
            try
            {
                VfmsjggxTableAdapter1.FillByWhere(DSjggxwh1.Vfmsjggx, PriWhere);
                TxtJl.Text = "����" + Bds.Count + "����Ϣ";
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ��Ϣʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion
        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��",ObjG.CustomMsgBox,this);
                return;
            }
            ClsExcel.CreatExcel(Dgv,"������ϵ",this.ctrlDownLoad1);            

        }
        #endregion

    }
}