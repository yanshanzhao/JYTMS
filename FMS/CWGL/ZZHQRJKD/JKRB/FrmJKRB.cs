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
using FMS.CWGL.ZZHQRJKD.JKRB;

#endregion

namespace FMS.CWGL.ZZHQRJKD
{
    public partial class FrmJKRB : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private string Where;
        private DataTable PriJgDt;
        #endregion
        public FrmJKRB()
        {
            InitializeComponent();
        }
        public void Prepare() 
        {
            ObjG = (ClsG)Session["ObjG"];
            //vfmsfyjyd1TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            vfmsjkrbTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            PnlMain.Controls.Add(PnlJgcx);
            PnlJgcx.Visible = false; 
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            //ClsPopulateCmbDsS.PopuFMS_Jzlx(CmbJzlx);
            CmbSfyc.SelectedIndex = 0;
            CmbJzlx.SelectedIndex = 0;
        }

        #region  ������ѯ
        private void TxtZDWZ_EnterKeyDown_1(object objSender, KeyEventArgs objArgs)
        {
            PnlJgcx.Visible = true;
            string CmdText = "select mc,pym from tjigou where parentLst like '%," + ObjG.Jigou.id + ",%' and (pym like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%' or mc like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%')";
            PriJgDt = ClsRWMSSQLDb.GetDataTable(CmdText, ClsGlobals.CntStrKj);
            LstV.DataSource = PriJgDt;
            LstV.Columns[0].Text = "��������";
            LstV.Columns[1].Text = "ƴ����";
            LstV.Columns[0].Width = 120;
            //DgvJgcx.DataSource = PriJgDt;
           
            //DgvJgcx.Focus();
            LstV.Focus();
        }
        private void LstV_LostFocus(object sender, EventArgs e)
        {
            PnlJgcx.Visible = false;

            PriJgDt.Dispose();
        }
        private void LstV_DoubleClick(object sender, EventArgs e)
        {
            this.TxtJgmc.Text = LstV.SelectedItems[0].Text;
            this.PnlJgcx.Visible = false;
            PriJgDt.Dispose();
            TxtJg.Focus();
        }

        private void LstV_KeyUp(object objSender, KeyEventArgs objArgs)
        {
            if (Convert.ToInt32(objArgs.KeyCode)==8)
            {
                if (TxtJg.Text.Trim().Length != 0)
                    TxtJg.Text = TxtJg.Text.Trim().Substring(0, TxtJg.Text.Trim().Length - 1);
                TxtJg.SelectionStart = TxtJg.Text.Length;
                TxtJg.Focus();
                PnlJgcx.Visible = false;
                PriJgDt.Dispose();
            }
            if (LstV.Items.Count > 0)
            {
                if (Convert.ToInt32(objArgs.KeyCode) == 13)
                {
                    this.TxtJgmc.Text = LstV.SelectedItems[0].Text;
                    this.PnlJgcx.Visible = false;
                    PriJgDt.Dispose();
                    TxtJg.Focus();
                }
            }
        }
        //private void DgvJgcx_LostFocus(object sender, EventArgs e)
        //{
        //    PnlJgcx.Visible=false;
         
        //    PriJgDt.Dispose();
        //}
        //private void DgvJgcx_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    this.TxtJgmc.Text = DgvJgcx.CurrentRow.Cells[DgvColTxtJgmc.Name].Value.ToString();
        //    this.PnlJgcx.Visible = false;
        //    PriJgDt.Dispose();
        //}
        //private void DgvJgcx_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 8) 
        //    {
        //        if (TxtJg.Text.Trim().Length != 0)
        //            TxtJg.Text = TxtJg.Text.Trim().Substring(0, TxtJg.Text.Trim().Length - 1);
        //        TxtJg.SelectionStart = TxtJg.Text.Length;
        //        TxtJg.Focus();
        //        PnlJgcx.Visible = false;
        //        PriJgDt.Dispose();
        //    }
        //}
        #endregion

        #region �����ɿ�
        private void BtnJk_Click(object sender, EventArgs e)
        {
            FrmJKRBMX f = new FrmJKRBMX();
            f.ShowDialog();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
           
            
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmJKRBMX f = sender as FrmJKRBMX;
            
        }
        #endregion

        #region ��ѯ
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Where = " where 1=1 ";
                Where += string.IsNullOrEmpty(TxtJgmc.Text.Trim()) ? " and jgid =" + ObjG.Jigou.id : " and jgmc = '" + TxtJgmc.Text.Trim() + "'";
                Where += CmbYwqy.SelectedIndex == 0 ? "" : " and ywqy='" + CmbYwqy.SelectedValue + "'";
                if (CmbSfyc.SelectedIndex == 1)
                    Where += " and (zt=0 )";
                else if (CmbSfyc.SelectedIndex == 2)
                    Where += " and zt>0 ";
                Where += CmbJzlx.SelectedIndex == 0 ? "" : " and fkfs='" + CmbJzlx.Text + "'";
                Where += " and inssj> '" + DtpStart.Value.Date + "' and inssj<='" + DtpStop.Value.Date.AddDays(1) + "'";
                vfmsjkrbTableAdapter1.FillByWhere(DSjkrb1.Vfmsjkrb, Where);
                //vfmsfyjyd1TableAdapter1.FillByWhere(DSjkrb1.Vfmsfyjyd1, Where);
                LblRowCount.Text = "����"+Bds.Count.ToString()+"������";
                if (Bds.Count == 0)
                {
                    this.LblSum.Text = "�Ѵ�0.00Ԫ  δ��0.00Ԫ";
                    ClsMsgBox.Ts("�޲�ѯ��Ϣ����˶Բ�ѯ������", ObjG.CustomMsgBox, this);
                }
                else
                {
                    this.LblSum.Text = "�Ѵ�" + DSjkrb1.Vfmsjkrb.Compute("sum(zyf)", "zt>0") + "Ԫ  δ��" + DSjkrb1.Vfmsjkrb.Compute("sum(zyf)", "zt=0") + "Ԫ";
                }
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ��Ϣʧ�ܣ�",ex,ObjG.CustomMsgBox,this);
            }
            
        }
        #endregion

        #region ����Excel
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0) 
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            if (Bds.Count > 60000)
            {
                ClsMsgBox.Ts("������������60000��������!", ObjG.CustomMsgBox, this);
                return;
            }
            int[] CellIndex = { 3,4,5,6,7,8,9,10,11,12,13,14,15,16};
            ClsExcel.CreatExcel(Dgv,"Ӧ�����ϸ", this.ctrlDownLoad1,CellIndex);
        }
        #endregion

        private void BtnClear1_Click(object sender, EventArgs e)
        {
            this.TxtJgmc.Clear();
        }  
    }
}