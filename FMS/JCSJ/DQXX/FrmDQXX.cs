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

namespace FMS.JCSJ.DQXX
{
    public partial class FrmDQXX : UserControl
    {
        #region ��Ա����
        private string PriConStr; //���ݿ������ַ���
        private ClsG ObjG;
        #endregion
        public FrmDQXX()
        {
            InitializeComponent();
        }
        private DSQSXX.TdqRow PriId
        {
            get
            {
                if (Bds.Current == null)
                    return null;
                else
                {
                    return (DSQSXX.TdqRow)(((DataRowView)Bds.Current).Row);
                }
            }
        }
        public void Prepare()
        {
            PnlBtns.BackColor = ClsOptions.WebCfg.PnlBtnsColor;
            PriConStr = ClsGlobals.CntStrTMS;
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            TdqTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            TdqTableAdapter1.Fill(DSQSXX1.Tdq);
           
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmDQXXMX f = new FrmDQXXMX();
            f.Prepare(-1, EnumNEDD.New, this.Bds);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmDQXXMX f = sender as FrmDQXXMX;
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
            FrmDQXXMX f = new FrmDQXXMX();
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
                    

                    TdqTableAdapter1.DeleteById(PriId.id);
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
            ClsExcel.CreatExcel(Dgv, "������Ϣ", this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, "���տ������ѷ���", this.ctrlDownLoad1);
        }
    }
}