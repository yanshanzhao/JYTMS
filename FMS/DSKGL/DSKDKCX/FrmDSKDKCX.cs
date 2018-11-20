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
using FMS.DSKGL.DSKDKCX;
#endregion

namespace FMS.DSKGL.DSKDKCX
{
    public partial class FrmDSKDKCX : UserControl
    {
        private Dictionary<string, string> PriDic;
        private string PriServerKhhStr;// = ClsRWDBOptions.GetStr("JY_KHH", ClsGlobals.CntStrKj);//���пͻ���
        private string PriServerPwdStr;// = ClsRWDBOptions.GetStr("JY_DLMM", ClsGlobals.CntStrKj);//��������
        private string PriServerCZYH;// = ClsRWDBOptions.GetStr("JY_CZYH", ClsGlobals.CntStrKj);//���в���Ա��
        private string PriServerDFBH;// = ClsRWDBOptions.GetStr("JY_DKBH", ClsGlobals.CntStrKj);//���д������
        private string PriServerDFYTBH;// = ClsRWDBOptions.GetStr("JY_DKYTPH", ClsGlobals.CntStrKj);//���д�����;���
        private int PriXlh;//���к�
        string[] XML_TXValues;
        private List<string> LstValues = new List<string>();
        private List<string> LstError = new List<string>();
        public FrmDSKDKCX()
        {
            InitializeComponent();
        }

        #region ��Ա����
        private string PriSql;
        private int PriJg;
        private string Where;
        private ClsG ObjG;
        private DataTable PriDt = new DataTable();
        private DataRow PriJgRow;
        //private DSDSKDKCX.VfmsdskdkcxRow PriRow;
        #endregion

        #region Prepare
        public void Prepare()
        {
            ObjG = (ClsG)Session["ObjG"];
            vfmsdskdkcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            //VfmsdskdkTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            ClsPopulateCmbDsS.PopuDSKYqzl_yhlx(CmbYhlx);
            CmbYhlx.SelectedIndex = 1;
            CmbZt.SelectedIndex = 0;
            PnlMain.Controls.Add(PnlJgcx);
            PnlJgcx.Visible = false;
            this.Dsdskdkcx1.EnforceConstraints = false;
            //PriJg = ObjG.Jigou.id;
        }
        #endregion

        #region ����
        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            int[] cellindex = { 3 };
            ClsExcel.CreatExcel(Dgv, "���տ���۲�ѯ", this.ctrlDownLoad1, cellindex);
        }
        #endregion

        #region ��ѯ
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                Where = " where  inssj >= '" + DtpCjStart.Value.Date + "' and inssj <'" + DtpCjStop.Value.AddDays(1).Date + "'";
                //if (this.CmbZt.Text != "ȫ��")
                if (CmbZt.SelectedIndex == 1)
                    Where += " and zt=10";
                if (CmbZt.SelectedIndex == 2)
                    Where += " and zt = 20";
                if (!string.IsNullOrEmpty(this.TxtJgmc.Text))
                    Where += " and jgid=" + PriJg;
                vfmsdskdkcxTableAdapter1.FillByWhere(Dsdskdkcx1.Vfmsdskdkcx, Where);
                LblRowCount.Text = "����" + BdsDskdkcx.Count.ToString() + "������" + "�ɹ�" + Dsdskdkcx1.Vfmsdskdkcx.Compute("sum(zze)", "zts='�ɹ�'").ToString() + "Ԫ��ʧ��" + Dsdskdkcx1.Vfmsdskdkcx.Compute("sum(zze)", "zts='ʧ��'").ToString() + "Ԫ��������" + Dsdskdkcx1.Vfmsdskdkcx.Compute("sum(zze)", "zts='������'").ToString() + "Ԫ";
                if (BdsDskdkcx.Count == 0)
                    ClsMsgBox.Ts("û��Ҫ��ѯ������", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ��Ϣʧ��", ex, ObjG.CustomMsgBox, this);
            }
            finally
            {
            }
        }
        #endregion

        #region ����ѡ��
        private void TxtJg_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            PnlJgcx.Visible = true;
            //PriSql = "select '0' as id,null as mc,'' as pym union select id,mc,pym from jyjckj.dbo.tjigou where (mc like '%" + TxtJg.Text.Trim() + "%' or pym like '%" + TxtJg.Text.Trim() + "%') and id>1";
            PriSql = "select mc,convert(varchar(30),pym) as pym,id from jyjckj.dbo.tjigou where (mc like '%" + TxtJg.Text.Trim() + "%' or pym like '%" + TxtJg.Text.Trim() + "%') and id>1";
            PriDt = ClsRWMSSQLDb.GetDataTable(PriSql, ClsGlobals.CntStrKj);
            //this.LstJG.DataSource = PriDt;
            //this.LstJG.DisplayMember = "mc";
            //this.LstJG.ValueMember = "id";
            //LstJG.Visible = true;
            //LstJG.Focus();
            //LstJG.SelectedIndex = 0;
            LstV.DataSource = PriDt;
            LstV.Columns[0].Text = "��������";
            LstV.Columns[1].Text = "ƴ����";

            LstV.Columns[2].Visible = false;
            LstV.Columns[0].Width = 120;
            LstV.Focus();
        }
        private void LstV_LostFocus(object sender, EventArgs e)
        {

            PnlJgcx.Visible = false;

            PriDt.Dispose();
        }


        private void LstV_DoubleClick(object sender, EventArgs e)
        {
            this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
            PriJg = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
            this.PnlJgcx.Visible = false;
            PriDt.Dispose();
            TxtJg.Focus();
        }

        private void LstV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
                PriJg = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
                this.PnlJgcx.Visible = false;
                PriDt.Dispose();
                TxtJg.Focus();
            }
            else if (e.KeyChar == 8)
            {
                if (TxtJg.Text.Trim().Length != 0)
                    TxtJg.Text = TxtJg.Text.Trim().Substring(0, TxtJg.Text.Trim().Length - 1);
                TxtJg.SelectionStart = TxtJg.Text.Length;
                TxtJg.Focus();
                PnlJgcx.Visible = false;
                PriDt.Dispose();
            }
        }
        #endregion

        #region ���۲�ѯ
        private void BtnDksbcx_Click(object sender, EventArgs e)
        {
            PriDic = new Dictionary<string, string>();
            PriDic = ClsRWDBOptions.GetDic(ClsGlobals.CntStrKj);
            PriServerKhhStr = PriDic["JY_KHH"];
            PriServerPwdStr = PriDic["JY_DLMM"];
            PriServerCZYH = PriDic["JY_CZYH"];
            PriServerDFBH = PriDic["JY_DKBH"];
            PriServerDFYTBH = PriDic["JY_DKYTPH"];
            //Tfmsdskjkpc ����״̬��0-δ����,5-�����У�10-���۳ɹ�,20-����ʧ��
            List<string> UncertaintyLst = new List<string>();
            vfmsdskdkcxTableAdapter1.FillByWhere(Dsdskdkcx1.Vfmsdskdkcx, " where zt = 5");
            LblRowCount.Text = "����" + BdsDskdkcx.Count.ToString() + "������";
            foreach (DSDSKDKCX.VfmsdskdkcxRow row in Dsdskdkcx1.Vfmsdskdkcx)
            {
                PriXlh = GetXlh("Z");//���տ�������к�
                string[] strName = new string[] { "RETURN_CODE", "DEAL_RESULT", "MESSAGE" };
                XML_TXValues = new string[] { PriXlh.ToString(), PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W1503", "CN", "15006" };
                string recvStr = ClsSockets.sendStr(XML_TXValues, "6W1503.xml");
                if (!ClsGetXML.IsXml(recvStr))
                {
                    ClsMsgBox.Ts("��ѯ����\n" + recvStr, ObjG.CustomMsgBox, this);
                    break;
                }
                LstValues = ClsGetXML.GetListStr(strName, recvStr);
                //Socket(row.qqxlh);
                if (LstValues.Count > 0)
                {
                    if (LstValues[0] == "000000")
                    {
                        if (LstValues[1].ToString().Equals("4"))//�ɹ�
                        {
                            ClsRWMSSQLDb.ExecuteCmd(string.Format("Update Tfmsdskjkpc set dkzt = 10 where id ={0} and dkzt = 5;Update tfmskjlog set zt = 10 where id = {1} and zt = 5", row.dskjkpcid, row.id), ClsGlobals.CntStrTMS);
                            row.zts = "�ɹ�";
                        }
                        else if (LstValues[1].ToString().Equals("3"))//ʧ��
                        {
                            ClsRWMSSQLDb.ExecuteCmd(string.Format("Update Tfmsdskjkpc set dkzt = 20 where id ={0} and dkzt = 5;Update tfmskjlog set zt = 20,zy='{1}' where id = {2} and zt = 5", row.dskjkpcid, LstValues[1] + LstValues[2], row.id), ClsGlobals.CntStrTMS);
                            row.zts = "ʧ��";
                        }
                        else
                        {
                            ClsRWMSSQLDb.ExecuteCmd(string.Format("Update tfmskjlog set zy = '{0}' where id = {1} and zt = 5", LstValues[1] + LstValues[2], row.id), ClsGlobals.CntStrTMS);
                            row.zts = "������";
                        }
                    }
                    else if (LstValues[0] == "0130Z110BB22")
                    {
                        ClsRWMSSQLDb.ExecuteCmd(string.Format("Update Tfmsdskjkpc set dkzt = 20 where id ={0} and dkzt = 5;Update tfmskjlog set zt = 20,zy='��ѯ������¼Ϊ��' where id = {1} and zt = 5", row.dskjkpcid, row.id), ClsGlobals.CntStrTMS);
                        row.zts = "ʧ��";
                        row.zy = "��ѯ������¼Ϊ��";
                    }
                    else
                    {
                        UncertaintyLst.Add(row.rbdh);
                        continue;
                    }
                }
            }
            if (UncertaintyLst.Count > 0)
                ClsMsgBox.Ts(string.Join("\n", UncertaintyLst) + "\nû�в�ȷ������Ľ�����ˮ:��ѯ������¼Ϊ��!����ϵ����Ա!", ObjG.CustomMsgBox, this);
            LstValues.Clear();
        }
        #endregion

        /// <summary>
        /// ��װ�����ͱ��ģ��õ����۽��
        /// </summary>
        /// <param name="aYhzh">���������ʺ�</param>
        /// <param name="aZhmc">�����ʺ�����</param>
        /// <param name="aJe">���۽��</param>
        private void Socket(int aOldXlh)
        {
            try
            {
                PriXlh = GetXlh("Z");//���տ�������к�
                string[] strName = new string[] { "RETURN_CODE", "DEAL_RESULT", "MESSAGE" };
                XML_TXValues = new string[] { PriXlh.ToString(), PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W1503", "CN", aOldXlh.ToString() };
                string recvStr = ClsSockets.sendStr(XML_TXValues, "6W1503.xml");
                LstValues = ClsGetXML.GetListStr(strName, recvStr);
            }
            catch (Exception ex)
            {
                LstError.Add(ex.Message);
            }
        }
        /// <summary>
        /// �������к�
        /// </summary>
        /// <param name="aType"></param>
        /// <returns></returns>
        private int GetXlh(string aType)
        {
            return ClsRWMSSQLDb.GetInt(string.Format("Insert into Tfmsxlh values('{0}',getdate());Select SCOPE_IDENTITY()", aType), ClsGlobals.CntStrTMS);
        }
    }
}
