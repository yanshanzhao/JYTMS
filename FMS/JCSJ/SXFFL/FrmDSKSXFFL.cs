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
using FMS.JCSJ.SXFFL;
using JYPubFiles.Classes;

#endregion

namespace FMS.JCSJ.DSKKHDA.DSKSXFFLGL
{
    public partial class FrmDSKSXFFL : UserControl
    {
        #region ��Ա����
        private string PriConStr; //���ݿ������ַ���
        private ClsG ObjG;
        #endregion
        public FrmDSKSXFFL()
        {
            InitializeComponent();
        }
        private DSDSKSXFFL.tdskflRow PriId
        {
            get
            {
                if (Bds.Current == null)
                    return null;
                else
                {
                    return (DSDSKSXFFL.tdskflRow)(((DataRowView)Bds.Current).Row);
                }
            }
        }
        public void Prepare()
        {
            //PnlBtns.BackColor = ClsOptions.WebCfg.PnlBtnsColor;
            PriConStr = ClsGlobals.CntStrTMS;
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            TdskflTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            TdskflTableAdapter1.Fill(DSDSKSXFFL1.tdskfl);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmDSKSXFFLMX f = new FrmDSKSXFFLMX();
            f.Prepare(-1, EnumNEDD.New, this.Bds);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmDSKSXFFLMX f = sender as FrmDSKSXFFLMX;
            if (f.DialogResult != DialogResult.OK)
            {
                if (f.PubEnumNEDD == EnumNEDD.New)
                    Bds.RemoveCurrent();
                else if (f.PubEnumNEDD == EnumNEDD.Edit)
                    Bds.CancelEdit();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FrmDSKSXFFLMX f = new FrmDSKSXFFLMX();
            if (Bds.Current == null)
                return;
            f.Prepare(PriId.id, EnumNEDD.Edit, this.Bds);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            ClsMsgBox.YesNo("�Ƿ�ɾ����", new EventHandler(DeleteFL), ObjG.CustomMsgBox, this);
        }
        private void DeleteFL(object sender, EventArgs e)
        {
            Form frm = sender as Form;
            FrmMsgBox f = new FrmMsgBox();
            try
            {
                if (frm.DialogResult == DialogResult.Yes)
                {
                    TdskflTableAdapter1.DeleteById(PriId.id);
                    Bds.RemoveCurrent();
                    ClsMsgBox.Ts("ɾ���ɹ���", f, this);
                }
            }
            catch (Exception ex)
            {
                string ExStr = ex.Message;
                if (ExStr.LastIndexOf("REFERENCE") > 0)
                    ClsMsgBox.Ts(PriId.mc + "��������ʹ�ã�����ɾ��", frm, this);
                else
                    ClsMsgBox.Cw("���������޷�ɾ����", f, this);
            }

        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            BtnEdit.PerformClick();
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 3, 4 };
            ClsExcel.CreatExcel(Dgv, "���տ������ѷ���", this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, "���տ������ѷ���", this.ctrlDownLoad1);
        }
    }
}