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
using System.IO;
using NPOI.HSSF.UserModel;
using JYPubFiles.Classes;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;
#endregion

namespace FMS.DSKGL.DSKDK
{
    public partial class FrmDSKDK : UserControl
    {
        #region ��Ա����
        private Dictionary<string, string> PriDic;
        private string PriServerKhhStr;
        private string PriServerPwdStr;
        private string PriServerCZYH;
        private string PriServerDKBH;
        private string PriServerDKYTBH;
        private int PriXlh;//�������к�
        private string PriDgzh;//�Թ��˻�
        private string PriDgzhId;//�Թ��˻�ID
        private ClsG ObjG;
        private int PriJgid = 0;//��ѯ����ѡ�л���ID
        private string PrirecvStr;//������Ϣ
        private DataTable PriJgDt;
        private decimal PriSumDsk = 0;
        private decimal PriSumDk = 0;
        private string PriWhere;
        private int PriRowCount;
        string[] XML_TXValues;
        //private string CmdText;
        private List<DSDSKDK.VfmsdskdkRow> LstPcid = new List<DSDSKDK.VfmsdskdkRow>();
        private DSDSKDK.VfmsdskdkRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as DSDSKDK.VfmsdskdkRow;
                }
            }
        }
        #endregion
        public FrmDSKDK()
        {
            InitializeComponent();
        }

        #region  ��ʼ������
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PnlMain.Controls.Add(PnlJgcx);
            PnlJgcx.Visible = false;
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable(" select id,jc from tyhlx where  hdzt='Y' and id in(63,241)  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbYHlx, dtYhlx, "id", "jc");
            CmbYHlx.SelectedIndex = 0;
            CmbDkZt.SelectedIndex = 4;
            CmbDczt.SelectedIndex = 0;
            CmbFkfs.SelectedIndex = 0;
            this.CmbDjzt.SelectedIndex = 0;
            VfmsdskdkTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            DataTable dt = ClsRWMSSQLDb.GetDataTable("select id,zh from Tfmsyhzh where  zhlxid=53 and zhxz='G'   and yhlxid=63  and zt=0", ClsGlobals.CntStrTMS);
            if (dt.Rows.Count == 1)
            {
                PriDgzh = dt.Rows[0]["zh"].ToString();
                PriDgzhId = dt.Rows[0]["id"].ToString();
            }
        }
        #endregion

        #region ������ѯ

        private void TxtJg_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            PnlJgcx.Visible = true;
            string CmdText = "select mc as  Name,pym,id from  tjigou where( pym like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%' or  mc like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%') and id>1";
            PriJgDt = ClsRWMSSQLDb.GetDataTable(CmdText, ClsGlobals.CntStrKj);
            LstV.DataSource = PriJgDt;
            LstV.Columns[0].Text = "��������";
            LstV.Columns[1].Text = "ƴ����";
            LstV.Columns[2].Visible = false;
            LstV.Columns[0].Width = 120;
            LstV.Focus();
        }
        private void LstV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
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
                if (e.KeyChar == 13)
                {
                    this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;

                    PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
                    this.PnlJgcx.Visible = false;
                    PriJgDt.Dispose();
                    TxtJg.Focus();
                }
            }
        }

        private void LstV_LostFocus(object sender, EventArgs e)
        {
            PnlJgcx.Visible = false;
            PriJgDt.Dispose();
        }

        private void LstV_DoubleClick(object sender, EventArgs e)
        {
            this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
            PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
            this.PnlJgcx.Visible = false;
            PriJgDt.Dispose();
            TxtJg.Focus();
        }
        #endregion

        #region ��ѯ
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PriSumDk = 0;
            ClsD.TextBoxTrim(this);
            Clear();
            PriWhere = "  ";
            if (!string.IsNullOrEmpty(TxtJgmc.Text))
            {
                if (!ChkBJg.Checked)
                    PriWhere = PriWhere + " and jgid in(select id from jyjckj.dbo.tjigou where parentLst like '%," + PriJgid + ",%')";
                else
                    PriWhere = PriWhere + " and jgid =" + PriJgid;
            }
            PriWhere += " and yhlxid=" + CmbYHlx.SelectedValue;
            if (!CmbDkZt.Text.Trim().Equals("ȫ��"))
                PriWhere += " and dkzts='" + CmbDkZt.Text + "'";
            if (DtpStart.Checked)
                PriWhere += " and cksj>='" + DtpStart.Value.Date + "'";
            if (DtpStop.Checked)
                PriWhere += " and cksj<'" + DtpStop.Value.Date.AddDays(1) + "'";
            if (!(CmbDczt.SelectedIndex == 0))
            {
                PriWhere += " and zts='" + CmbDczt.Text + "'";
            }
            PriWhere += " and zffss='" + CmbFkfs.Text + "'";
            //PriWhere += "  and jdzt ='" + this.CmbDjzt.Text + "'";
            //if (CmbDjzt.SelectedIndex>0)
            PriWhere += "  and jdzt =" + this.CmbDjzt.SelectedIndex;
            PriWhere = PriWhere.Trim();
            if (PriWhere.Length > 0)
                PriWhere =  " where  " + PriWhere.Remove(0, 3);
            PriWhere += " order by px ,jgmc,cksj  ";
            VfmsdskdkTableAdapter1.FillByWhere1(DSdskdk1.Vfmsdskdk, PriWhere);
            //PriSumDk = Convert.ToDecimal(DSdskdk1.Vfmsdskdk.Compute("sum(dkje)", "1=1"));
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ��", ObjG.CustomMsgBox, this);
            }
            else
            {
                AddColor();
            }
            GetXx();

        }
        private void AddColor()
        {
            for (int i = 0; i < Dgv.Rows.Count; i++)
            {
                decimal dskje = Convert.ToDecimal(Dgv.Rows[i].Cells["DgvColTxtdsk"].Value);
                decimal dkje = string.IsNullOrEmpty(Dgv.Rows[i].Cells["DgvColTxtDkje"].Value.ToString()) ? 0 : Convert.ToDecimal(Dgv.Rows[i].Cells["DgvColTxtDkje"].Value);
                if (dskje != dkje)
                {
                    if (string.IsNullOrEmpty(Dgv.Rows[i].Cells["DgvColTxtDkje"].Value.ToString()))
                        continue;
                    Dgv.Rows[i].Cells["DgvColTxtDkje"].Style.ForeColor = Color.Red;
                }
            }
        }
        #endregion

        #region ��ҳȫѡ
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
                return;
            ///* ����������Ĵ����滻 CheckThisPage();����
            int curPageFirstIndex = (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;//��ȡ��ǰҳ�ĵ�һ�е�RowIndex
            int lastPageSize = Dgv.RowCount - (Dgv.TotalPages - 1) * Dgv.ItemsPerPage; //��ȡ���һҳ������
            int curPageSize = Dgv.CurrentPage != Dgv.TotalPages ? Dgv.ItemsPerPage : lastPageSize; //��ȡÿҳ���������������һҳ��
            int curRowIndex = curPageFirstIndex;
            while (curRowIndex < (curPageFirstIndex + curPageSize))
            {
                if (!Convert.ToBoolean(Dgv.Rows[curRowIndex].Cells[DgvColCbm.Name].Value).Equals(true))
                {
                    int dkzt = Convert.ToInt32(Dgv.Rows[curRowIndex].Cells[DgvColTxtDkzt.Name].Value);
                    if (dkzt == 10)
                    {
                        curRowIndex++;
                        continue;
                    }
                    if (dkzt == 5)
                    {
                        curRowIndex++;
                        continue;
                    }
                    PriRowCount++;
                    Dgv.Rows[curRowIndex].Cells[DgvColCbm.Name].Value = true;
                    PriSumDsk += Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtdsk.Name].Value);
                    PriSumDk += Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtDkje.Name].Value);
                }
                curRowIndex++;
            }
            GetXx();
        }
        /*
        public void CheckThisPage()
        {
            //һ���ж�����
            int rowcount = Convert.ToInt32(Dgv.RowCount);
            //��ǰ�ǵڼ�ҳ
            int currentpage = Convert.ToInt32(Dgv.CurrentPage);
            //һҳ�л���
            int pageSize = Convert.ToInt32(Dgv.ItemsPerPage);
            //һ���ж���ҳ
            int pageCount = (rowcount / pageSize);
            //�ϼƵ�ֵ
            decimal sum = 0;
            //�ж�һ���м�ҳ����û������
            //�������������ֻ���һҳ����������ָ������ʾ������
            if (rowcount % pageSize > 0)
            {
                pageCount++;
                //�ȼ���������һҳ�ĺϼ�
                if (currentpage < pageCount)
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                    {
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value))
                        {
                            PriRowCount++;
                            Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;
                            sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);

                        }
                    }
                    PriSumDsk += sum;
                }
                //�������һҳ��ֵ
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value))
                        {
                            PriRowCount++;
                            Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;
                            sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                        }
                    }
                    PriSumDsk += sum;
                }
            }
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value))
                    {
                        PriRowCount++;
                        Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;
                        sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);

                    }
                }
                PriSumDsk += sum;
            }
        }*/
        #endregion

        #region ȫѡ
        private void ChkB_CheckedChanged(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
                return;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (ChkB.Checked)
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                    {
                        int dkzt = Convert.ToInt32(row.Cells[DgvColTxtDkzt.Name].Value);
                        if (dkzt == 10)
                            continue;
                        if (dkzt == 5)
                            continue;
                        row.Cells[DgvColCbm.Name].Value = true;
                        PriRowCount++;
                        PriSumDsk += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                        PriSumDk += Convert.ToDecimal(row.Cells[DgvColTxtDkje.Name].Value);
                    }
                }
                else
                {
                    if (Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                    {
                        row.Cells[DgvColCbm.Name].Value = false;
                        PriRowCount--;
                        PriSumDsk -= Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                        PriSumDk -= Convert.ToDecimal(row.Cells[DgvColTxtDkje.Name].Value);
                    }
                }
            }
            GetXx();
        }
        #endregion

        #region ����ѡ��
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (PriRow == null)
                return;
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                if (PriRow.dkzt == 5)
                {
                    ClsMsgBox.Ts("�ñʴ��տ����ڴ����У������������", ObjG.CustomMsgBox, this);
                    return;
                }
                if (PriRow.dkzt == 10)
                {
                    ClsMsgBox.Ts("�ñʴ��տ��Ѿ����ۣ������������", ObjG.CustomMsgBox, this);
                    return;
                }
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    PriRowCount--;
                    PriSumDsk -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                    PriSumDk -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtDkje.Name].Value);
                }
                else
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    PriRowCount++;
                    PriSumDsk += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                    PriSumDk += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtDkje.Name].Value);
                }
            }
            GetXx();
        }
        #endregion

        #region Clear()
        private void Clear()
        {
            PriRowCount = 0;
            PriSumDsk = 0;
            PriSumDk = 0;
            GetXx();
        }
        #endregion

        #region GetXx()
        private void GetXx()
        {
            LblCheckCount.Text = "���۽�" + PriSumDk.ToString() + "Ԫ����ѡ��" + PriRowCount + "��";
        }
        #endregion

        #region ����
        private void BtnSh_Click(object sender, EventArgs e)
        {

            if (PriRowCount <= 0)
            {
                ClsMsgBox.Ts("��ѡ����Ҫ���۵���Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }

            if (string.IsNullOrEmpty(PriDgzh))
            {
                ClsMsgBox.Ts("û�жԹ��˻���Թ��˻�ά���ظ���", ObjG.CustomMsgBox, this);
                return;
            }
            if (Bds.Count == 0)
            {
                ClsMsgBox.Ts("���ѯ��Ҫ���۵���Ϣ!", ObjG.CustomMsgBox, this);
                return;
            }
            FrmPwd f = new FrmPwd();
            f.Prepare();
            f.ShowDialog();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPwd f = sender as FrmPwd;
            if (f.DialogResult == DialogResult.Yes)
            {
                ClsMsgBox.YesNo("�Ƿ���д��տ���ۣ�", new EventHandler(deduct), ObjG.CustomMsgBox, this);
            }
        }
        /// <summary>
        /// �������۹���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deduct(object sender, EventArgs e)
        {
            FrmMsgBox f = new FrmMsgBox();
            Form frm = sender as Form;
            if (frm.DialogResult != DialogResult.Yes)
                return;
            DSDSKDK.VfmsdskdkRow dkRow;
            string cmdText = string.Empty;
            PriDic = new Dictionary<string, string>();
            PriDic = ClsRWDBOptions.GetDic(ClsGlobals.CntStrKj);
            PriServerKhhStr = PriDic["JY_KHH"];
            PriServerPwdStr = PriDic["JY_DLMM"];
            PriServerCZYH = PriDic["JY_CZYH"];
            PriServerDKBH = PriDic["JY_DKBH"];
            PriServerDKYTBH = PriDic["JY_DKYTPH"];
            List<string> LstReturnV = new List<string>();//��¼���ķ�����Ϣ
            List<string> lstBfRbdh = new List<string>();//��¼�����ձ�����
            List<string> lstAccRbdh = new List<string>();//��¼�ɹ��ձ�����
            List<string> lstErrRbdh = new List<string>();//��¼ʧ���ձ�����
            List<string> lstNotTureRbdh = new List<string>();//��¼��ȷ���ձ�����
            List<int> lstRbid = new List<int>();//��¼��������Ϣ
            DataTable dt = ClsRWMSSQLDb.GetDataTable("Select RETURN_CODE from tcode where lx ='K'", ClsGlobals.CntStrTMS);
            foreach (DataGridViewRow Row in Dgv.Rows)
            {
                if (Convert.ToBoolean(Row.Cells[DgvColCbm.Name].Value))
                {
                    dkRow = ((DataRowView)Row.DataBoundItem).Row as DSDSKDK.VfmsdskdkRow;
                    /* ���ʹ�������޸Ĵ���״̬  
                     * tfmsjklog ״̬��5-�����У�10-���۳ɹ���20-����ʧ��
                     * tfmsdskjkpc ����״̬��0-δ����,5-�����У�10-���۳ɹ�,20-����ʧ��
                     * tfmsdskjkpc ״̬��0-����ת,5-����Ϣ������ϸ��ɾ��,10-���ύ,15-�ѵ���,20-���ͨ��
                    */
                    //�ȸ�д����״̬�ͼ�¼������־����ֹĳЩԭ���´�������ͳɹ���
                    //�������¼��־����δִ�е����������к�δ�ܼ�¼
                    if (dkRow.dkzt == 10 || dkRow.dkzt == 5)
                    {
                        lstBfRbdh.Add(dkRow.rbdh);
                        lstRbid.Add(dkRow.id);
                        continue;
                    }
                    PriXlh = GetXlh("Y");
                    cmdText = " update tfmsdskjkpc set dkzt=5  where id=" + dkRow.id + " and dkzt in(0,20) "; //δ���ۡ�����ʧ�ܿ����ٴδ���
                    if (ClsRWMSSQLDb.ExecuteCmd(cmdText, ClsGlobals.CntStrTMS) == 0) //��������������continue,����¼�ձ��ĵ���
                    {
                        lstBfRbdh.Add(dkRow.rbdh);
                        continue;
                    }
                    cmdText = " Insert  into TfmsKjlog (dskjkpcid,zczhid,zrzhid,zze,insczyid,insczyxm,insczyzh,qqxlh) values ";
                    cmdText += " (" + dkRow.id + "," + dkRow.zczhid + "," + PriDgzhId + "," + dkRow.dkje + "," + ObjG.Renyuan.id
                        + ",'" + ObjG.Renyuan.xm + "','" + ObjG.Renyuan.loginName + "','" + PriXlh + "')";
                    ClsRWMSSQLDb.ExecuteCmd(cmdText, ClsGlobals.CntStrTMS);
                    //���ʹ�������
                    string[] strName = new string[] { "RETURN_CODE", "RETURN_MSG" };
                    LstReturnV.Clear();
                    XML_TXValues = new string[] { PriXlh.ToString(), PriServerKhhStr, PriServerCZYH, 
                        PriServerPwdStr, "6W1303", "CN", PriDgzh, PriServerDKBH,dkRow.zh ,dkRow.zhmc,dkRow.dkje.ToString(), PriServerDKYTBH, "", "", "", "", "" };
                    //���������÷��ر��� 
                    PrirecvStr = ClsSockets.sendStr(XML_TXValues, "6W1303.xml");
                    //���ǣ�1������ʧ�� 2������ʧ�� 3�����ͳɹ�û�з���
                    bool isXml = ClsGetXML.IsXml(PrirecvStr);
                    if (isXml)
                    {
                        //����XML��Ϣ
                        LstReturnV = ClsGetXML.GetListStr(strName, PrirecvStr);
                        if (LstReturnV[0] == "000000")//�ɹ�
                        {
                            cmdText = string.Format(" Update Tfmskjlog set zt = 10,zy='{0}' where qqxlh='{1}' and zt = 5 ", LstReturnV[1], PriXlh);
                            cmdText += " update tfmsdskjkpc set dkzt=10,zt=15  where id=" + dkRow.id;
                            lstAccRbdh.Add(dkRow.rbdh);
                        }
                        else if (dt.Select("RETURN_CODE = '" + LstReturnV[0] + "'").Length > 0)
                        {
                            cmdText = string.Format(" Update Tfmskjlog set zt = 20,zy='{0}' where qqxlh='{1}' and zt = 5 ", LstReturnV[1], PriXlh);
                            cmdText += " update tfmsdskjkpc set dkzt=20,zt=15  where id=" + dkRow.id;
                            lstErrRbdh.Add(dkRow.rbdh);
                        }
                        else
                        {
                            cmdText = string.Format(" Update Tfmskjlog set zy='{1}' where qqxlh='{0}' and zt = 5 ", PriXlh, LstReturnV[1]);
                            lstNotTureRbdh.Add(dkRow.rbdh);
                        }
                    }
                    else
                    {
                        cmdText = string.Format(" Update Tfmskjlog set zy ='{0}' where qqxlh='{1}' and zt = 5 ", PrirecvStr, PriXlh);
                        lstNotTureRbdh.Add(dkRow.rbdh);


                    }
                    ClsRWMSSQLDb.ExecuteCmd(cmdText, ClsGlobals.CntStrTMS);
                    lstRbid.Add(dkRow.id);
                }
            }
            ClsMsgBox.Ts("������ɣ����۳ɹ�" + lstAccRbdh.Count + "��������ʧ��" + lstErrRbdh.Count + "��,δ����" + lstBfRbdh.Count + "��,������" + lstNotTureRbdh.Count + "����", f, this);
            foreach (int id in lstRbid)
            {
                Bds.RemoveAt(Bds.Find("dskrbpcid", id));
            }
            this.ChkB.Checked = false;
            Clear();
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
        #endregion


        #region ����
        /// <summary>
        /// ũ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem4_Click(object sender, EventArgs e)
        {

            try
            {
                LstPcid.Clear();
                string PriFln = "ũ�д��տ��" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";//�ļ�����     
                string path = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
                int PriNo = 1;
                FileStream fs1 = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs1, Encoding.UTF8);
                string str = "";
                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                        continue;
                    Bds.Position = row.Index;
                    DSDSKDK.VfmsdskdkRow Rows = ((DataRowView)Bds.Current).Row as DSDSKDK.VfmsdskdkRow;
                    Rows.zt = 15;
                    LstPcid.Add(Rows);
                    PriNo.ToString();
                    if (PriNo.ToString().Length == 1)
                        str += "00000" + PriNo;
                    else if (PriNo.ToString().Length == 2)
                        str += "0000" + PriNo;
                    else if (PriNo.ToString().Length == 3)
                        str += "000" + PriNo;
                    else if (PriNo.ToString().Length == 4)
                        str += "00" + PriNo;
                    else if (PriNo.ToString().Length == 5)
                        str += "0" + PriNo;
                    else
                        str += PriNo;
                    str += ",";

                    str += Convert.ToString(row.Cells[DgvColTxtYhzh.Name].Value);
                    str += ",";
                    str += row.Cells[DgvColTxtZhmc.Name].Value.ToString();
                    str += ",";
                    str += double.Parse(row.Cells[DgvColTxtDkje.Name].Value.ToString());
                    str += ",";


                    str += "����";
                    str += "\r\n";
                    PriNo++;

                }
                if (string.IsNullOrEmpty(str))
                {
                    ClsMsgBox.Ts("û����Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                    return;
                }
                str = str.Substring(0, str.LastIndexOf("\r\n"));
                sw.WriteLine(str);//Ҫд�����Ϣ�� 
                ctrlDownLoad1.download(path, true);
                sw.Close();
                fs1.Close();
                Bds.EndEdit();
                VfmsdskdkTableAdapter1.Update(LstPcid.ToArray());

                this.ChkB.Checked = false;

                Clear();
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("������Ϣʧ��", ex);
                return;
            }

        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem5_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("û����Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }

            LstPcid.Clear();
            string PriFln = "�ܲ����д��տ����ϸ" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ� 
            //д������
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.SetColumnWidth(0, 25 * 240);
            sheet1.SetColumnWidth(1, 25 * 120);
            HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
            cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
            try
            {

                int rowindex = 0;
                for (int i = 0; i < Dgv.Rows.Count; i++)
                {
                    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value))
                        continue;
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(rowindex);
                    Bds.Position = i;
                    DSDSKDK.VfmsdskdkRow Rows = ((DataRowView)Bds.Current).Row as DSDSKDK.VfmsdskdkRow;
                    Rows.zt = 15;
                    LstPcid.Add(Rows);
                    for (int m = 0; m < Dgv.Columns.Count; m++)
                    {
                        if (Dgv.Columns[m].Name.ToString().Equals("DgvColTxtDkje"))
                        {
                            hssfrow.CreateCell(2).SetCellValue(Convert.ToDouble(Dgv.Rows[i].Cells[m].Value));
                            hssfrow.Cells[2].CellStyle = cellStyle;
                        }
                        else if (Dgv.Columns[m].Name.ToString().Equals("DgvColTxtYhzh"))
                        {
                            hssfrow.CreateCell(0).SetCellValue(Convert.ToString(Dgv.Rows[i].Cells[m].Value));
                        }
                        else if (Dgv.Columns[m].Name.ToString().Equals("DgvColTxtZhmc"))
                        {
                            hssfrow.CreateCell(1).SetCellValue(Dgv.Rows[i].Cells[m].Value.ToString());
                        }
                    }
                    rowindex++;
                }
                if (LstPcid.Count == 0)
                {
                    ClsMsgBox.Ts("��ѡ����Ҫ�����Ĵ�����Ϣ��", ObjG.CustomMsgBox, this);
                    return;
                }
                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
                this.ctrlDownLoad1.download(PriFlp, true);
                Bds.EndEdit();
                VfmsdskdkTableAdapter1.Update(LstPcid.ToArray());

                this.ChkB.Checked = false;
                Clear();
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("������������ʧ�ܣ�", ex);
                return;
            }
        }
        #endregion

        private void menuItem6_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("û����Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.Rows.Count > 60000)
            {
                ClsMsgBox.Ts("������������60000�������ݣ�", ObjG.CustomMsgBox, this);
                return;
            }
            int[] RowIndex = { 6 };
            ClsExcel.CreatExcel(Dgv, "���տ����", ctrlDownLoad1, RowIndex);
        }

        #region ����
        private void BtnExl2_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("û����Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.Rows.Count > 60000)
            {
                ClsMsgBox.Ts("������������60000�������ݣ�", ObjG.CustomMsgBox, this);
                return;
            }
            int[] aCellIndex = { 6, 7 };
            ClsExcel.CreatExcel(Dgv, "�ܲ����д��տ����ϸ", ctrlDownLoad1, aCellIndex);

        }
        #endregion

        private void BtnClear1_Click(object sender, EventArgs e)
        {
            this.TxtJgmc.Clear();
            PriJgid = 0;
        }

        private void BtnDj_Click(object sender, EventArgs e)
        {
            GetDj(1);
        }

        private void BtnJd_Click(object sender, EventArgs e)
        {
            GetDj(0);
        }

        private void GetDj(byte azt)
        {
            LstPcid.Clear();
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (!Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                    continue;
                Bds.Position = row.Index;
                DSDSKDK.VfmsdskdkRow Rows = ((DataRowView)Bds.Current).Row as DSDSKDK.VfmsdskdkRow;
                if (Rows.jdzt == azt)
                    continue;
                Rows.jdzt = azt;
                LstPcid.Add(Rows);
            }
            if (LstPcid.Count == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            Bds.EndEdit();
            VfmsdskdkTableAdapter1.Update(LstPcid.ToArray());
            foreach (DSDSKDK.VfmsdskdkRow row in LstPcid)
            {
                Bds.RemoveAt(Bds.Find("dskrbpcid", row.dskrbpcid));
            }
            this.ChkB.Checked = false;
            Clear();
        }

        private void BtnDkje_Click(object sender, EventArgs e)
        {
            if (PriRow == null)
                return;
            if (PriRow.dkzt == 5)
            {
                ClsMsgBox.Ts("�ñʴ��տ����ڴ����У������������", ObjG.CustomMsgBox, this);
                return;
            }
            if (PriRow.dkzt == 10)
            {
                ClsMsgBox.Ts("�ñʴ��տ��Ѿ����ۣ������������", ObjG.CustomMsgBox, this);
                return;
            }
            FrmJexg f = new FrmJexg();
            f.Prepare(PriRow);
            f.ShowDialog();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed2);

        }
        void f_FormClosed2(object sender, FormClosedEventArgs e)
        {
            FrmPwd f = sender as FrmPwd;
            if (Dgv.CurrentRow.Cells["DgvColTxtDkje"].Value.ToString() != Dgv.CurrentRow.Cells["DgvColTxtdsk"].Value.ToString())
            {
                Dgv.CurrentRow.Cells["DgvColTxtDkje"].Style.ForeColor = Color.Red;
            }
        }



    }
}
