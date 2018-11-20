#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pub;
using JY.Pri;
using JYPubFiles.Classes;
#endregion

namespace FMS.DSKGL.DSKSXFFL
{
    public partial class FrmDSKSXFFLWH : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private FrmMsgBox frm;
        private DSDSKSXFFL.VfmssxfflpcRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as DSDSKSXFFL.VfmssxfflpcRow;
                }
            }
        }
        #endregion
        public FrmDSKSXFFLWH()
        {
            InitializeComponent();
        }
        #region  ��ʼ������
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            this.VfmssxfflpcTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.VfmssxfflpcTableAdapter1.Fill(this.DSDSKSXFFL1.Vfmssxfflpc);
        }
        #endregion
        #region ���� �༭
        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmDSKSXFFLMXWH f = new FrmDSKSXFFLMXWH();
            f.Prepare(-1, EnumNEDD.New);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            VfmssxfflpcTableAdapter1.Dispose();
            VfmssxfflpcTableAdapter1.Fill(this.DSDSKSXFFL1.Vfmssxfflpc);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FrmDSKSXFFLMXWH f = new FrmDSKSXFFLMXWH();
            f.Prepare(PriRow.id, EnumNEDD.Edit);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }
        #endregion

        #region ɾ��
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
            {
                ClsMsgBox.Ts("û����Ҫɾ������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            ClsMsgBox.YesNo("ȷ��Ҫɾ����", new EventHandler(DeleteFl), ObjG.CustomMsgBox, this);
        }
        void DeleteFl(object sender, EventArgs e)
        {
            int? Ret=0;
            frm = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {
                try
                {
                    VfmssxfflpcTableAdapter1.P_DelSxffl(PriRow.id, ref Ret);
                    if (Ret == 2 || Ret==0)
                    {
                        ClsMsgBox.Ts("ɾ������ʧ�ܣ�",frm,this);
                        return;
                    }
                    Bds.RemoveCurrent();
                    if(Ret==1)
                        ClsMsgBox.Ts("ɾ���ɹ���", frm, this);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("ɾ������ʧ�ܣ�", ex, frm, this);
                }
            }
        }
        #endregion

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv.Rows.Count <= 0)
            {
                ClsMsgBox.Ts("û����Ҫ�༭����Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            BtnEdit.PerformClick();
        }
    }
}