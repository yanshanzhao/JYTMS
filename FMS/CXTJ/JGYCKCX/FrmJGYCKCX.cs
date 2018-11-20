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

namespace FMS.CXTJ.JGYCKCX
{
    public partial class FrmJGYCKCX : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private FrmSelectJg PriFrmSelectJg;
        public int jgid;
        #endregion
        public FrmJGYCKCX()
        {
            InitializeComponent();
        }
        #region ��ʼ������
        public void Prepare()
        {
            ObjG=(ClsG)VWGContext.Current.Session["OBjG"];
            VfmsjgyckcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            CmbZt.SelectedIndex = 1;
            jgid = ObjG.Jigou.id;
            TxtJg.Text = ObjG.Jigou.mc;
        }
        #endregion
        #region ������ѯ
        private void BtnJg_Click(object sender, EventArgs e)
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
                jgid = Convert.ToInt32(f.PubDictAttrs["id"]);
                this.TxtJg.Text = f.PubDictAttrs["mc"];
                
            f.Dispose();
        }
        #endregion

        #region ����
        private void BtnDc_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            int[] CellIndex = { 5};
            ClsExcel.CreatExcel(Dgv, "����Ӧ�����ϸ", this.ctrlDownLoad1, CellIndex);
        }
        #endregion 

        #region  ��ѯ
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            this.LblHj.Text = "���ϼƣ�0.00Ԫ";
            try
            {                
                string where = " where  je<>0 ";
                if (CmbZt.SelectedIndex == 0)
                    where += " and zt='�Ѵ�' ";
                if (CmbZt.SelectedIndex == 1)
                    where += " and zt='δ��' ";
                
                where += string.IsNullOrEmpty(TxtJg.Text) ? "" : " and jsjgid in (select id from jyjckj.dbo.tjigou where parentLst like '%," + jgid + ",%')";
                
                if (DtpStart.Checked)
                    where += " and inssj >='" + DtpStart.Value.Date.ToString("yyyy-MM-dd") + "'";
                if (DtpEnd.Checked)
                    where +=" and inssj <'" + DtpEnd.Value.Date.AddDays(1).ToString("yyyy-MM-dd") + "' ";
                //where += " and inssj >='" + DtpStart.Value.Date.ToString("yyyy-MM-dd") + "' and inssj <'" + DtpEnd.Value.Date.AddDays(1).ToString("yyyy-MM-dd") + "' ";
                VfmsjgyckcxTableAdapter1.FillByWhere(DSJGYCKCX1.Vfmsjgyckcx, where);
                if (Bds.Count == 0)
                    ClsMsgBox.Ts("û�в�ѯ����Ӧ��Ϣ����˶Բ�ѯ������",ObjG.CustomMsgBox,this);
                else
                    this.LblHj.Text = "���ϼƣ�" + this.DSJGYCKCX1.Vfmsjgyckcx.Compute("sum(je)", "").ToString() + "Ԫ";
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ��Ϣʧ�ܣ�",ex,ObjG.CustomMsgBox,this);
            }

        }
        #endregion
    }
}