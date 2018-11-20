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
using System.Data.SqlClient;
using JYPubFiles.Classes;
#endregion

namespace FMS.DSKGL.Dxtz
{
    public partial class FrmDskDxtz : UserControl
    {
        #region ��ʼ����Ա����
        private ClsG ObjG;
        private List<int> PriYfsIds;
        private string PriLxdh = "";
        private bool PriBool = true;//�ж��Ƿ���״̬ѡ��Ϊȫ�� 

        private DataRow[] PriDxx = null;
        private int PriLx = 0;//����:0��ʾΪԭ����,1��ʾʹ�����µ�ģ����Ϣ
        private DataTable PriDt = null;
        private string Prizh = "";//�����˺�
        private string Primm = "";//����
        private string Pridxcpbh = "";//���Ų�Ʒ����
        private string Pricwdxcpbh = "";//���Ų�Ʒ����(����)
        private string Prigysbh = "";//��Ӧ�̱���
        private string Priurl = "";//��ַ
        private string Pridxffmc = "";//���ŷ�������
        private string Pricwffmc = "";//���ŷ�������(����)
        private string Prinr = "";//������Ϣ��ģ��
        private string PrinrCw = "";//������Ϣ��ģ��(����)
        private int Pricount = 0;//���ֵĴ���
        private int PricountDx = 0;//�Ƿ�ʹ�ö���
        private int PricountCW = 0;//�Ƿ�ʹ�ö���(����)
        private int Pridxmmid = 0;//����ģ��id
        private int Pricwmmid = 0;//����ģ��id(����)
        private string PriSyzt = "";//ʹ��״̬
        private int Prijgid;//����id


        private string PriHbzh = "";//�����˺�
        private string PriHbmm = "";//����
        private string PriHbdxcpbh = "";//���Ų�Ʒ����
        private string PriHbdxffmc = "";//���ŷ�������
        private string PriHbnr = "";//������Ϣ��ģ��
        private int PriHbdxmmid = 0;//����ģ��id
        private int PriHbcount = 0;//���ֵĴ���
        private int PricountHbDx = 0;//�Ƿ�ʹ�ö���
        #endregion

        public FrmDskDxtz()
        {
            InitializeComponent();
        }

        #region Prepare()
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            VfmsdskdxfsTableAdapter.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            CmbDxzt.SelectedIndex = 0;
            Cmbzt.SelectedIndex = 1;
            PriLxdh = System.Configuration.ConfigurationManager.AppSettings.Get("Dskdh");
            CmbTzlx.SelectedIndex = 0;
            CmbYHlx.SelectedIndex = 0;
            Prijgid = ObjG.Jigou.id;
            PriSyzt = System.Configuration.ConfigurationManager.AppSettings.Get("DXSYZT");
            PriDt = ClsCache.GetDxfsCache("KeyNameDxfs") as DataTable;
            if (PriSyzt == "1")
            {
                PriDxx = PriDt.Select(string.Format(" jgid={0}  and tzlx in(3,4,5) ", Prijgid));
                if (PriDxx.Length >= 2)
                {
                    PriLx = 1;
                    getDxx();
                }
            }
        }
        private void getDxx()
        {

            //Ѱ�����Ϊ001������Ϊ��������֪ͨ��ģ��
            DataRow[] dr = null;
            dr = PriDt.Select(string.Format(" jgid={0}  and tzlx=3  and xh='001' and yy=0 ", Prijgid));
            if (dr.Length > 0)//����
            {
                Pricount++;
                PricountDx++;
                //��ȡ��Ӧ�̱��롢�˺š�����͵�ַ
                Prigysbh = dr[0]["gysxh"].ToString();
                Prizh = dr[0]["zh"].ToString();
                Primm = dr[0]["mm"].ToString();
                Priurl = dr[0]["dz"].ToString();
                Prinr = dr[0]["nr"].ToString();
                Pridxmmid = Convert.ToInt32(dr[0]["mmid"].ToString());
                Pridxcpbh = dr[0]["cpbh"].ToString();
                Pridxffmc = dr[0]["mc"].ToString();

            }
            dr = PriDt.Select(string.Format(" jgid={0}  and tzlx=4  and xh='001' and yy=0 ", Prijgid));
            if (dr.Length > 0)//����(����)
            {
                Pricount++;
                PricountCW++;
                //��ȡ��Ӧ�̱��롢�˺š�����͵�ַ
                Pricwmmid = Convert.ToInt32(dr[0]["mmid"].ToString());
                Prigysbh = dr[0]["gysxh"].ToString();
                Prizh = dr[0]["zh"].ToString();
                Primm = dr[0]["mm"].ToString();
                Priurl = dr[0]["dz"].ToString();
                Pricwdxcpbh = dr[0]["cpbh"].ToString();
                Pricwffmc = dr[0]["mc"].ToString();
                PrinrCw = dr[0]["nr"].ToString();

            }
            dr = PriDt.Select(string.Format(" jgid={0}  and tzlx=5  and xh='001' and yy=0 ", Prijgid));
            if (dr.Length > 0)//����
            {
                Pricount++;
                PricountHbDx++;
                //��ȡ��Ӧ�̱��롢�˺š�����͵�ַ
                Prigysbh = dr[0]["gysxh"].ToString();
                Prizh = dr[0]["zh"].ToString();
                Primm = dr[0]["mm"].ToString();
                Priurl = dr[0]["dz"].ToString();
                PriHbnr = dr[0]["nr"].ToString();
                PriHbdxmmid = Convert.ToInt32(dr[0]["mmid"].ToString());
                PriHbdxcpbh = dr[0]["cpbh"].ToString();
                PriHbdxffmc = dr[0]["mc"].ToString();
            }

        }
        #endregion

        #region ��ѯ
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            PriBool = true;
            string where = string.Format(" where ffsj>='{0}' and ffsj<'{1}' ", DtpStart.Value.Date, DtpEnd.Value.Date.AddDays(1));
            if (!string.IsNullOrEmpty(TxtBh.Text.Trim()))
                where += " and bh='" + TxtBh.Text.Trim() + "'";
            if (CmbDxzt.SelectedIndex < 3)
                where += " and dskdxzts='" + CmbDxzt.SelectedItem.ToString() + "'";
            if (Cmbzt.SelectedIndex < 2)
                where += " and zts='" + Cmbzt.SelectedItem.ToString() + "'";
            if (!string.IsNullOrEmpty(TxtFwkh.Text.Trim()))
                where += " and fwkh like '%" + TxtFwkh.Text.Trim() + "%' ";
            if (!string.IsNullOrEmpty(TxtKhmc.Text.Trim()))
                where += " and mc like '%" + TxtKhmc.Text.Trim() + "%' ";
            if (CmbYHlx.SelectedIndex > 1)
                where += " and yhlx = '" + CmbYHlx.Text.Trim() + "' ";
            if (CmbYHlx.SelectedIndex == 1)
                where += " and yhid not in (63,241)";
            if (CmbTzlx.SelectedIndex != 2)
                where += " and tzlxs='" + CmbTzlx.Text.ToString() + "' ";
            where += " order by fwkh ";
            VfmsdskdxfsTableAdapter.FillByWhere(DsDxtz1.Vfmsdskdxfs, where);
            if (Cmbzt.SelectedIndex != 1)
                PriBool = false;
        }
        #endregion

        #region ���Ͷ���
        private void BtnFsdx_Click(object sender, EventArgs e)
        {
            if (!ClsOptions.WebCfg.DuaxinTzIsOpen)
            {
                ClsMsgBox.Ts("��ʱ�رն��Žӿ�", ObjG.CustomMsgBox, this);
                return;
            }
            #region ԭ���Ĳ���ʹ��
            //if (PriLx == 0)
            //{
            //    try
            //    {
            //        PriYfsIds = new List<int>();//�Ƴ����ͳɹ��е�list
            //        int Count = 0//ѡ�ж�����
            //            , accCount = 0//�ɹ�������
            //            , errCount = 0//ʧ�ܶ�����
            //            , errtelCount = 0;//���ͺ����쳣����;
            //        ClsDskmessage Dskmessage = new ClsDskmessage();
            //        foreach (DataGridViewRow row in Dgv.Rows)
            //        {
            //            if (Convert.ToBoolean(row.Cells[DgvColChkQx1.Name].Value))
            //            {
            //                Count++;
            //                #region ����

            //                DsDxtz.VfmsdskdxfsRow r = (DsDxtz.VfmsdskdxfsRow)((DataRowView)row.DataBoundItem).Row;
            //                if (!r.IstelNull() && r.tel != "" && ClsRegEx.IsShouJi(r.tel))
            //                {
            //                    Dskmessage.mobile = r.tel;//�ֻ��绰
            //                }
            //                else if (!r.IstelNull() && r.tel != "" && ClsRegEx.IsZuoJi(r.tel))
            //                {
            //                    //ClsMsgBox.Cw("�˵���Ϊ" + r.bh + "���˵����ŷ���ʧ�ܣ����鷢�ͺ����Ƿ���ȷ��", ObjG.CustomMsgBox, this);
            //                    errtelCount++;
            //                    continue;
            //                }
            //                else
            //                {
            //                    // ClsMsgBox.Cw("�˵���Ϊ" + r.bh + "���˵����ŷ���ʧ�ܣ����鷢�ͺ����Ƿ���ȷ��", ObjG.CustomMsgBox, this);
            //                    errtelCount++;
            //                    continue;
            //                }
            //                if (r.zt == 0)//ʧ�ܶ���
            //                    Dskmessage.msg = "�𾴵Ŀͻ���ã���ĵ���Ϊ" + r.bh + "���ջ�����" + r.ycxx + "ԭ��δ���š����ٵ��������������ر�������������������¼��������绰Ϊ" + PriLxdh + "�� ";
            //                else if (r.zt == 20)//�ɹ�����
            //                    Dskmessage.msg = "�𾴵Ŀͻ����ã���ĵ���Ϊ" + r.bh + "���ջ�����Ϊ" + r.sfje + "Ԫ�Ѵ��ɹ�����ע����ա�";
            //                #endregion
            //                int send = 0;
            //                if (ClsDskHttpSms.DdskDxSend(Dskmessage).Equals("1"))
            //                {
            //                    send = 1;
            //                    accCount++;
            //                    PriYfsIds.Add(r.ydid);
            //                }
            //                else
            //                    errCount++;
            //                VfmsdskdxfsTableAdapter.Pdskffdxtz(r.ydid, send, Prijgid, ObjG.Renyuan.id, ObjG.Renyuan.xm, r.zyf, r.sfje);

            //            }
            //        }
            //        if (accCount > 0)
            //        {
            //            foreach (int ydid in PriYfsIds)
            //                Bds.RemoveAt(Bds.Find("ydid", ydid));
            //        }
            //        if (Count == 0)
            //        {
            //            ClsMsgBox.Ts("��ѡ����Ҫ���Ͷ��ŵ��˵���", ObjG.CustomMsgBox, this);
            //        }
            //        else
            //        {
            //            ClsMsgBox.Ts("�����Ͷ���" + Count + "��.\n���к����쳣��" + errtelCount + "��.\n�ɹ�����" + accCount + "��.\n" + "����ʧ��" + errCount + "��", ObjG.CustomMsgBox, this);
            //            BtnQuery.PerformClick();
            //            CkbQx.Checked = false;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        ClsMsgBox.Cw("���ִ���,��ϸ��Ϣ:", ex, ObjG.CustomMsgBox, this);
            //    }
            //}
            #endregion ԭ���Ĳ���ʹ��
            //else
            //{
            if (Pricount == 0)
            {
                ClsMsgBox.Ts("�û��������õĶ�����Ϣ!", ObjG.CustomMsgBox, this);
                return;
            }
            else
            {

                PriYfsIds = new List<int>();
                int Count = 0, accCount = 0, errCount = 0;
                //    , InvalidCount = 0;
                //string InvalidBh = "";
                ClsDxWwtl smsmodel = new ClsDxWwtl();
                ClsXCKJ dxinfo = new ClsXCKJ();
                string strsmsg = "";
                if (Prigysbh == "01")
                {
                    smsmodel.user = Prizh;
                    smsmodel.pasword = Primm;
                    smsmodel.key = Prijgid.ToString();
                    smsmodel.url = Priurl;
                }
                //int bclx = 0;//���η��ͷ�ʽ  0--���� 1--����(����)
                int mmid = 0;//����ʹ�õ�ģ��id
                int fsydid = 0;//�˵�id
                string qt = "���տ����֪ͨ";

                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[DgvColChkQx1.Name].Value))
                    {
                        Count++;
                        #region ����

                        DsDxtz.VfmsdskdxfsRow r = (DsDxtz.VfmsdskdxfsRow)((DataRowView)row.DataBoundItem).Row;
                        if (!r.IstelNull() && r.tel != "" && ClsRegEx.IsShouJi(r.tel))
                        {
                            //bclx = 0;
                            if (Prigysbh == "01")
                                smsmodel.sdst = r.tel;//�ֻ��绰
                            else if (Prigysbh == "02")
                            {
                                dxinfo.username = Prizh;
                                dxinfo.password = Primm;
                                dxinfo.msgtype = "2";
                                dxinfo.veryCode = "jouo6c6yozwt";
                                dxinfo.tempid = Pridxcpbh;
                                dxinfo.mobile = r.tel;
                            }
                            fsydid = r.ydid;
                        }
                        else if (!r.IstelNull() && r.tel != "" && ClsRegEx.IsZuoJi(r.tel))
                        {

                            //ClsMsgBox.Cw("�˵���Ϊ" + r.bh + "���˵����ŷ���ʧ�ܣ����鷢�ͺ����Ƿ���ȷ��", ObjG.CustomMsgBox, this);
                            errCount++;
                            continue;
                        }
                        else
                        {
                            // ClsMsgBox.Cw("�˵���Ϊ" + r.bh + "���˵����ŷ���ʧ�ܣ����鷢�ͺ����Ƿ���ȷ��", ObjG.CustomMsgBox, this);
                            errCount++;
                            continue;
                        }
                        //��װ���͵���Ϣ 
                        if (r.zt == 0)//ʧ�ܶ���
                        {
                            //bclx = 1;
                            if (Prigysbh == "01")
                                strsmsg = string.Format(PrinrCw, r.bh, r.ycxx, PriLxdh);
                            else if (Prigysbh == "02")
                                strsmsg = string.Format("@1@={0},@2@={1},@3@={2}", r.bh, r.ycxx, PriLxdh);
                        }
                        else if (r.zt == 20)//�ɹ�����
                        {
                            //bclx = 0;
                            if (Prigysbh == "01")
                                strsmsg = string.Format(Prinr, r.bh, r.sfje);
                            else if (Prigysbh == "02")
                                strsmsg = string.Format("@1@={0},@2@={1}", r.bh, r.sfje);
                        }
                        if (Prigysbh == "01")
                        {
                            if (r.zt == 20)//����
                            {
                                smsmodel.cpbh = Pridxcpbh;
                                smsmodel.ffmc = Pridxffmc;
                                smsmodel.smsg = strsmsg;
                                mmid = Pridxmmid;
                            }
                            if (r.zt == 0)//���ţ�ʧ�ܣ�
                            {
                                smsmodel.cpbh = Pricwdxcpbh;
                                smsmodel.ffmc = Pricwffmc;
                                smsmodel.smsg = strsmsg;
                                mmid = Pricwmmid;
                            }
                            int send = 0;
                            if (ClsHttpSms.WwtlGoodsSend(smsmodel, out qt).Equals("0"))
                            {
                                send = 1;
                                accCount++;
                                PriYfsIds.Add(r.ydid);
                            }
                            else
                                errCount++;
                            VfmsdskdxfsTableAdapter.Pdskffdxtz_new(Prijgid, smsmodel.smsg, smsmodel.sdst, 0, mmid, qt, fsydid, send);
                        }
                        else if (Prigysbh == "02")
                        {
                            string serverUrl = "";
                            serverUrl = Priurl + Pridxffmc;
                            if (r.zt == 20)//����
                            {
                                dxinfo.content = strsmsg;
                                mmid = Pridxmmid;
                            }
                            if (r.zt == 0)//���ţ�ʧ�ܣ�
                            {
                                dxinfo.content = strsmsg;
                                mmid = Pricwmmid;
                            }
                            int send = 0;
                            if (ClsXCKJ.SendMes(dxinfo, serverUrl, out qt).Equals("0"))
                            {
                                send = 1;
                                accCount++;
                                PriYfsIds.Add(r.ydid);
                            }
                            else
                                errCount++;
                            VfmsdskdxfsTableAdapter.Pdskffdxtz_new(Prijgid, dxinfo.content, dxinfo.mobile, 0, mmid, qt, fsydid, send);
                        }

                        #endregion
                    }
                }
                if (accCount > 0)
                {
                    foreach (int ydid in PriYfsIds)
                        Bds.RemoveAt(Bds.Find("ydid", ydid));
                }
                if (Count == 0)
                {
                    ClsMsgBox.Ts("��ѡ����Ҫ���Ͷ��ŵ��˵���", ObjG.CustomMsgBox, this);
                }
                else
                {
                    ClsMsgBox.Ts("�����Ͷ���" + Count + "��.\n���к����쳣��" + errCount + "��.\n�ɹ�����" + accCount + "��.\n" + "����ʧ��" + errCount + "��", ObjG.CustomMsgBox, this);
                    BtnQuery.PerformClick();
                    CkbQx.Checked = false;
                }
                //}
            }
        }
        #endregion

        #region ȫѡ
        private void CkbQx_CheckedChanged(object sender, EventArgs e)
        {
            if (CkbQx.Checked)
            {
                foreach (DataGridViewRow dgvr in Dgv.Rows)
                {
                    dgvr.Cells[DgvColChkQx1.Name].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow dgvr in Dgv.Rows)
                {
                    dgvr.Cells[DgvColChkQx1.Name].Value = false;
                }
            }
        }
        #endregion

        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("û��Ҫ�������˵���Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.Rows.Count > 60000)
            {
                ClsMsgBox.Ts("������������60000��������!", ObjG.CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(Dgv, "���տ�Ŷ���֪ͨ", ctrlDownLoad1, new int[] { 6, 7, 9, 10 });
        }
        #endregion

        #region ���ͳɹ�
        private void BtnDxtz_Click(object sender, EventArgs e)
        {
            try
            {
                PriYfsIds = new List<int>();//�Ƴ����ͳɹ��е�list

                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[DgvColChkQx1.Name].Value))
                    {
                        DsDxtz.VfmsdskdxfsRow r = (DsDxtz.VfmsdskdxfsRow)((DataRowView)row.DataBoundItem).Row;
                        PriYfsIds.Add(r.ydid);
                    }
                }
                if (PriYfsIds.Count == 0)
                {
                    ClsMsgBox.Ts("��ѡ��Ҫ���͵��˵���Ϣ��", ObjG.CustomMsgBox, this);
                    return;
                }
                ClsRWMSSQLDb.GetInt(" update Tyd set dskdxzt=10 where  id  in (" + string.Join(",", PriYfsIds) + ")and dskdxzt<>10 ;", ClsGlobals.CntStrTMS);
                ClsMsgBox.Ts("���ͳɹ�" + PriYfsIds.Count + "��", ObjG.CustomMsgBox, this);
                BtnQuery.PerformClick();
                CkbQx.Checked = false;
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("���ִ���,��ϸ��Ϣ:", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion

        #region �ϲ����Ͷ���
        private void BtnDxhb_Click(object sender, EventArgs e)
        {
            if (!ClsOptions.WebCfg.DuaxinTzIsOpen)
            {
                ClsMsgBox.Ts("��ʱ�رն��Žӿ�", ObjG.CustomMsgBox, this);
                return;
            }

            if (!PriBool)
            {
                ClsMsgBox.Ts("ϵͳֻ�ܺϲ����ͳɹ��Ĵ��տ���Ϣ��������ѡ���ѯ������");
                return;
            }
            #region ԭ��Ӧ�̲���ʹ��
            //if (PriLx == 0)
            //{
            //    try
            //    {
            //        PriYfsIds = new List<int>();//�Ƴ����ͳɹ��е�list
            //        string fwkh = "";//���񿨺�
            //        int fwkhCounts = 0;//���񿨺Ŷ�Ӧ�Ĵ��տ����
            //        string fwkhStr = "";//���Ͷ����й��ڴ��տ���˵��ʹ��տ�������
            //        string fwkhSQL = "";//ִ��SQL���
            //        string fwkhTel = "";//���񿨺ŵ绰
            //        List<int> fwkhList = new List<int>();//���񿨺Ŷ�Ӧ���˵�id
            //        int Count = 0//ѡ�ж�����
            //            , accCount = 0//�ɹ�������
            //            , errCount = 0;//ʧ�ܶ����� 
            //        foreach (DataGridViewRow row in Dgv.Rows)
            //        {
            //            if (Convert.ToBoolean(row.Cells[DgvColChkQx1.Name].Value))
            //            {
            //                Count++;
            //                DsDxtz.VfmsdskdxfsRow r = (DsDxtz.VfmsdskdxfsRow)((DataRowView)row.DataBoundItem).Row;
            //                if (Count == 1 && !r.IstelNull() && r.tel != "" && ClsRegEx.IsShouJi(r.tel))
            //                {
            //                    fwkh = r.fwkh;
            //                    fwkhTel = r.tel;
            //                    fwkhCounts = 1;
            //                    fwkhStr = "����:" + r.bh + ",���տ���:" + r.dsk + ";";
            //                    fwkhList.Add(r.ydid);
            //                    fwkhSQL = "insert into Tdx (ydid,fsjgid,fsrid,fsrxm,zt,zyf,dsk,lx) values(" + r.ydid + ",'{0}','{1}','{2}','{3}'," + r.zyf + "," + r.dsk + ",'Y');";
            //                }
            //                else
            //                {
            //                    //����ͬһ������
            //                    if (fwkh == r.fwkh)
            //                    {
            //                        if (fwkhCounts == 4)
            //                        {
            //                            ClsDskmessage Dskmessage = new ClsDskmessage();
            //                            Dskmessage.msg = "�𾴵Ŀͻ�����:���ķ��񿨺�" + fwkh + ",��" + fwkhCounts + "Ʊ���տ��Ѿ����ɹ�," + fwkhStr + "��ע�����.��������";
            //                            Dskmessage.mobile = fwkhTel;
            //                            int send = 0;
            //                            if (ClsDskHttpSms.DdskDxSend(Dskmessage).Equals("1"))
            //                            {
            //                                send = 1;
            //                                fwkhTel = r.tel;
            //                                accCount = accCount + fwkhCounts;
            //                                PriYfsIds.AddRange(fwkhList);
            //                                fwkhSQL += "update Tyd set dskdxzt=10 where dskdxzt<>10 and id  in (" + string.Join(",", fwkhList) + ");";
            //                            }
            //                            else
            //                            {
            //                                errCount = errCount + fwkhCounts;
            //                            }
            //                            ClsRWMSSQLDb.GetInt(string.Format(fwkhSQL, Prijgid, ObjG.Renyuan.id, ObjG.Renyuan.xm, send), ClsGlobals.CntStrTMS);
            //                            fwkhList.Clear();
            //                            fwkhCounts = 0;
            //                            fwkhStr = "";
            //                        }
            //                        fwkhCounts++;
            //                        fwkhStr += "����:" + r.bh + ",���տ���:" + r.dsk;
            //                        fwkhList.Add(r.ydid);
            //                        fwkhSQL += "insert into Tdx (ydid,fsjgid,fsrid,fsrxm,zt,zyf,dsk,lx) values(" + r.ydid + ",'{0}','{1}','{2}','{3}'," + r.zyf + "," + r.dsk + ",'Y');";
            //                    }
            //                    else
            //                    {
            //                        ClsDskmessage Dskmessage = new ClsDskmessage();
            //                        Dskmessage.msg = "�𾴵Ŀͻ�����:���ķ��񿨺�" + fwkh + ",��" + fwkhCounts + "Ʊ���տ��Ѿ����ɹ�," + fwkhStr + "��ע�����.��������";
            //                        Dskmessage.mobile = fwkhTel;
            //                        int send = 0;
            //                        if (ClsDskHttpSms.DdskDxSend(Dskmessage).Equals("1"))
            //                        {
            //                            send = 1;
            //                            fwkhTel = r.tel;
            //                            accCount = accCount + fwkhCounts;
            //                            PriYfsIds.AddRange(fwkhList);
            //                            fwkhSQL += "update Tyd set dskdxzt=10 where dskdxzt<>10 and id  in (" + string.Join(",", fwkhList) + ");";
            //                        }
            //                        else
            //                        {
            //                            errCount = errCount + fwkhCounts;
            //                        }
            //                        ClsRWMSSQLDb.GetInt(string.Format(fwkhSQL, Prijgid, ObjG.Renyuan.id, ObjG.Renyuan.xm, send), ClsGlobals.CntStrTMS);
            //                        fwkhList.Clear();
            //                        fwkhStr = "";
            //                        fwkhCounts = 0;
            //                        fwkh = r.fwkh;
            //                        fwkhCounts++;
            //                        fwkhStr += "���ţ�" + r.bh + ",���տ��" + r.dsk + ";";
            //                        fwkhList.Add(r.ydid);
            //                        fwkhSQL = "insert into Tdx (ydid,fsjgid,fsrid,fsrxm,zt,zyf,dsk,lx) values(" + r.ydid + ",'{0}','{1}','{2}','{3}'," + r.zyf + "," + r.dsk + ",'Y');";
            //                    }
            //                }
            //            }
            //        }
            //        if (fwkhList.Count > 0)
            //        {
            //            ClsDskmessage Dskmessage = new ClsDskmessage();
            //            Dskmessage.mobile = fwkhTel;
            //            Dskmessage.msg = "�𾴵Ŀͻ�����:���ķ��񿨺�" + fwkh + ",��" + fwkhCounts + "Ʊ���տ��Ѿ����ɹ�," + fwkhStr + "��ע�����.��������";
            //            int send = 0;
            //            if (ClsDskHttpSms.DdskDxSend(Dskmessage).Equals("1"))
            //            {
            //                send = 1;
            //                accCount = accCount + fwkhCounts;
            //                PriYfsIds.AddRange(fwkhList);
            //                fwkhSQL += "update Tyd set dskdxzt=10 where dskdxzt<>10 and id  in (" + string.Join(",", fwkhList) + ");";
            //            }
            //            else
            //            {
            //                errCount = errCount + fwkhCounts;
            //            }
            //            ClsRWMSSQLDb.GetInt(string.Format(fwkhSQL, Prijgid, ObjG.Renyuan.id, ObjG.Renyuan.xm, send), ClsGlobals.CntStrTMS);
            //            fwkhList.Clear();
            //        }

            //        if (accCount > 0)
            //        {
            //            foreach (int ydid in PriYfsIds)
            //                Bds.RemoveAt(Bds.Find("ydid", ydid));
            //        }
            //        if (Count == 0)
            //        {
            //            ClsMsgBox.Ts("��ѡ����Ҫ���Ͷ��ŵ��˵���", ObjG.CustomMsgBox, this);
            //        }
            //        else
            //        {
            //            ClsMsgBox.Ts("���ͳɹ�" + accCount + "��.\n" + "����ʧ��" + errCount + "��", ObjG.CustomMsgBox, this);
            //            BtnQuery.PerformClick();
            //            CkbQx.Checked = false;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        ClsMsgBox.Cw("���ִ���,��ϸ��Ϣ:", ex, ObjG.CustomMsgBox, this);
            //    }
            //}
            #endregion ԭ��Ӧ�̲���ʹ��
            //else
            //{
            //�ϲ����ͳɹ��Ķ���   ʹ��΢��ͨ��    
            //�����ж��Ƿ�Ϊͬһ�����񿨺�  �����ͬһ�����񿨺ŵ�  �ڲ鿴�Ƿ��͵��˵������Ƿ�Ϊ4  ����������������ͷ��Ͷ��ŷ���Ͳ����Ͷ���
            //�����ж��Ƿ�Ϊͬһ�����񿨺�  �������ͬһ�����񿨺ŵ�  �ͷ���֮ǰ�ۼƵķ��Ͷ��ŵ���Ϣ ���ۼƱ��εĶ�����Ϣ 
            //2017-07-10 ֻ��Ҫ����ִ�е�SQL�ͷ��͵Ķ��Ź�Ӧ��
            try
            {
                PriYfsIds = new List<int>();//�Ƴ����ͳɹ��е�list
                string fwkh = "";//���񿨺�
                int fwkhCounts = 0;//���񿨺Ŷ�Ӧ�Ĵ��տ����
                string fwkhStr = "";//���Ͷ����й��ڴ��տ���˵��ʹ��տ�������
                string fwkhSQL = "", zxdxnrSQL = "";//ִ��SQL���
                string fwkhTel = "";//���񿨺ŵ绰
                List<int> fwkhList = new List<int>();//���񿨺Ŷ�Ӧ���˵�id
                int Count = 0//ѡ�ж�����
                    , accCount = 0//�ɹ�������
                    , errCount = 0;//ʧ�ܶ����� 
                ClsDxWwtl smsmodel = new ClsDxWwtl();
                ClsXCKJ dxinfo = new ClsXCKJ();
                if (Prigysbh == "01")
                {
                    smsmodel.user = Prizh;//�˺�
                    smsmodel.pasword = Primm;//����
                    smsmodel.cpbh = PriHbdxcpbh;//��Ʒ����
                    smsmodel.key = Prijgid.ToString();
                    smsmodel.url = Priurl;
                    smsmodel.ffmc = PriHbdxffmc;
                }
                else if (Prigysbh == "02")
                {
                    dxinfo.username = Prizh;
                    dxinfo.password = Primm;
                    dxinfo.msgtype = "2";
                    dxinfo.veryCode = "jouo6c6yozwt";
                }
                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[DgvColChkQx1.Name].Value))
                    {
                        Count++;
                        DsDxtz.VfmsdskdxfsRow r = (DsDxtz.VfmsdskdxfsRow)((DataRowView)row.DataBoundItem).Row;
                        if (Count == 1 && !r.IstelNull() && r.tel != "" && ClsRegEx.IsShouJi(r.tel))
                        {
                            fwkh = r.fwkh;
                            fwkhTel = r.tel;
                            fwkhCounts = 1;
                            fwkhStr = "����:" + r.bh + ",���տ���:" + r.dsk + ";";
                            fwkhList.Add(r.ydid);
                        }
                        else
                        {
                            //����ͬһ������
                            if (fwkh == r.fwkh)
                            {
                                if (fwkhCounts == 4)
                                {
                                    if (Prigysbh == "01")
                                    {
                                        smsmodel.sdst = fwkhTel;
                                        zxdxnrSQL = string.Format(PriHbnr, fwkh, fwkhCounts, fwkhStr);
                                        smsmodel.smsg = zxdxnrSQL;
                                        int send = 0;
                                        string qt;
                                        if (ClsHttpSms.WwtlGoodsSend(smsmodel, out qt).Equals("0"))
                                        {
                                            send = 1;
                                            //fwkhTel = r.tel;
                                            string liststring = string.Join(",", fwkhList);
                                            accCount = accCount + fwkhCounts;
                                            PriYfsIds.AddRange(fwkhList);
                                            fwkhSQL = "update Tyd set dskdxzt=10 where dskdxzt<>10 and id  in (" + string.Join(",", fwkhList) + ");";
                                            fwkhSQL += "INSERT INTO dbo.tdxnr( jgid , nr , inssj , tel , zt , lx , mbid ,qt ,ydidstr) VALUES(" + Prijgid + ",'" + zxdxnrSQL + "',getdate(),'" + fwkhTel + "',1,0," + PriHbdxmmid + ",'" + qt + "','" + @liststring + "')";
                                            ClsRWMSSQLDb.GetInt(fwkhSQL, ClsGlobals.CntStrTMS);
                                        }
                                        else
                                        {
                                            errCount = errCount + fwkhCounts;
                                        }
                                    }
                                    else if (Prigysbh == "02")
                                    {
                                        string serverUrl = Priurl + PriHbdxffmc;
                                        dxinfo.mobile = fwkhTel;
                                        dxinfo.tempid = PriHbdxcpbh;
                                        zxdxnrSQL = string.Format("@1@={0},@2@={1},@3@={2}", fwkh, fwkhCounts, fwkhStr);
                                        dxinfo.content = zxdxnrSQL;
                                        int send = 0;
                                        string qt;
                                        if (ClsXCKJ.SendMes(dxinfo, serverUrl, out qt).Equals("0"))
                                        {
                                            send = 1;
                                            //fwkhTel = r.tel;
                                            string liststring = string.Join(",", fwkhList);
                                            accCount = accCount + fwkhCounts;
                                            PriYfsIds.AddRange(fwkhList);
                                            fwkhSQL = "update Tyd set dskdxzt=10 where dskdxzt<>10 and id  in (" + string.Join(",", fwkhList) + ");";
                                            fwkhSQL += "INSERT INTO dbo.tdxnr( jgid , nr , inssj , tel , zt , lx , mbid ,qt ,ydidstr) VALUES(" + Prijgid + ",'" + zxdxnrSQL + "',getdate(),'" + fwkhTel + "',1,0," + PriHbdxmmid + ",'" + qt + "','" + @liststring + "')";
                                            ClsRWMSSQLDb.GetInt(fwkhSQL, ClsGlobals.CntStrTMS);
                                        }
                                        else
                                        {
                                            errCount = errCount + fwkhCounts;
                                        }
                                    }
                                    fwkhList.Clear();
                                    fwkhCounts = 0;
                                    fwkhStr = "";
                                }
                                fwkhCounts++;
                                fwkhStr += "����:" + r.bh + ",���տ���:" + r.dsk;
                                fwkhList.Add(r.ydid);
                            }
                            else
                            {
                                fwkhTel = r.tel;
                                if (Prigysbh == "01")
                                {
                                    smsmodel.sdst = fwkhTel;
                                    zxdxnrSQL = string.Format(PriHbnr, fwkh, fwkhCounts, fwkhStr);
                                    smsmodel.smsg = zxdxnrSQL;
                                    int send = 0;
                                    string qt;
                                    if (ClsHttpSms.WwtlGoodsSend(smsmodel, out qt).Equals("0"))
                                    {
                                        send = 1;
                                        accCount = accCount + fwkhCounts;
                                        PriYfsIds.AddRange(fwkhList);
                                        string liststr = string.Join(",", fwkhList);
                                        fwkhSQL = "update Tyd set dskdxzt=10 where dskdxzt<>10 and id  in (" + string.Join(",", fwkhList) + ");";
                                        fwkhSQL += "INSERT INTO dbo.tdxnr( jgid , nr , inssj , tel , zt , lx , mbid ,qt ,ydidstr) VALUES(" + Prijgid + ",'" + zxdxnrSQL + "',getdate(),'" + fwkhTel + "',1,0," + PriHbdxmmid + ",'" + qt + "','" + @liststr + "')";
                                        ClsRWMSSQLDb.GetInt(fwkhSQL, ClsGlobals.CntStrTMS);
                                    }
                                    else
                                    {
                                        errCount = errCount + fwkhCounts;
                                    }
                                }
                                else if (Prigysbh == "02")
                                {
                                    string serverUrl = Priurl + PriHbdxffmc;
                                    dxinfo.mobile = fwkhTel;
                                    dxinfo.tempid = PriHbdxcpbh;
                                    zxdxnrSQL = string.Format("@1@={0},@2@={1},@3@={2}", fwkh, fwkhCounts, fwkhStr);
                                    dxinfo.content = zxdxnrSQL;
                                    int send = 0;
                                    string qt;
                                    if (ClsXCKJ.SendMes(dxinfo, serverUrl, out qt).Equals("0"))
                                    {
                                        send = 1;
                                        //fwkhTel = r.tel;
                                        string liststring = string.Join(",", fwkhList);
                                        accCount = accCount + fwkhCounts;
                                        PriYfsIds.AddRange(fwkhList);
                                        fwkhSQL = "update Tyd set dskdxzt=10 where dskdxzt<>10 and id  in (" + string.Join(",", fwkhList) + ");";
                                        fwkhSQL += "INSERT INTO dbo.tdxnr( jgid , nr , inssj , tel , zt , lx , mbid ,qt ,ydidstr) VALUES(" + Prijgid + ",'" + zxdxnrSQL + "',getdate(),'" + fwkhTel + "',1,0," + PriHbdxmmid + ",'" + qt + "','" + @liststring + "')";
                                        ClsRWMSSQLDb.GetInt(fwkhSQL, ClsGlobals.CntStrTMS);
                                    }
                                    else
                                    {
                                        errCount = errCount + fwkhCounts;
                                    }
                                }
                                fwkhList.Clear();
                                fwkhCounts = 0;
                                fwkhStr = "";

                                fwkh = r.fwkh;
                                fwkhTel = r.tel;
                                fwkhCounts++;
                                fwkhStr += "���ţ�" + r.bh + ",���տ��" + r.dsk + ";";
                                fwkhList.Add(r.ydid);
                            }
                        }
                    }
                }
                if (fwkhList.Count > 0)
                {
                    if (Prigysbh == "01")
                    {
                        smsmodel.sdst = fwkhTel;
                        zxdxnrSQL = string.Format(PriHbnr, fwkh, fwkhCounts, fwkhStr);
                        smsmodel.smsg = zxdxnrSQL;
                        int send = 0;
                        string qt;
                        if (ClsHttpSms.WwtlGoodsSend(smsmodel, out qt).Equals("0"))
                        {
                            send = 1;
                            accCount = accCount + fwkhCounts;
                            PriYfsIds.AddRange(fwkhList);
                            string liststr = string.Join(",", fwkhList);
                            fwkhSQL = "update Tyd set dskdxzt=10 where dskdxzt<>10 and id  in (" + string.Join(",", fwkhList) + ");";
                            fwkhSQL += "INSERT INTO dbo.tdxnr( jgid , nr , inssj , tel , zt , lx , mbid ,qt ,ydidstr) VALUES(" + Prijgid + ",'" + zxdxnrSQL + "',getdate(),'" + fwkhTel + "',1,0," + PriHbdxmmid + ",'" + qt + "','" + @liststr + "')";
                            ClsRWMSSQLDb.GetInt(fwkhSQL, ClsGlobals.CntStrTMS);
                        }
                        else
                        {
                            errCount = errCount + fwkhCounts;
                        }
                    }
                    else if (Prigysbh == "02")
                    {
                        string serverUrl = Priurl + PriHbdxffmc;
                        dxinfo.mobile = fwkhTel;
                        dxinfo.tempid = PriHbdxcpbh;
                        zxdxnrSQL = string.Format("@1@={0},@2@={1},@3@={2}", fwkh, fwkhCounts, fwkhStr);
                        dxinfo.content = zxdxnrSQL;
                        int send = 0;
                        string qt;
                        if (ClsXCKJ.SendMes(dxinfo, serverUrl, out qt).Equals("0"))
                        {
                            send = 1;
                            accCount = accCount + fwkhCounts;
                            PriYfsIds.AddRange(fwkhList);
                            string liststr = string.Join(",", fwkhList);
                            fwkhSQL = "update Tyd set dskdxzt=10 where dskdxzt<>10 and id  in (" + string.Join(",", fwkhList) + ");";
                            fwkhSQL += "INSERT INTO dbo.tdxnr( jgid , nr , inssj , tel , zt , lx , mbid ,qt ,ydidstr) VALUES(" + Prijgid + ",'" + zxdxnrSQL + "',getdate(),'" + fwkhTel + "',1,0," + PriHbdxmmid + ",'" + qt + "','" + @liststr + "')";
                            ClsRWMSSQLDb.GetInt(fwkhSQL, ClsGlobals.CntStrTMS);
                        }
                        else
                        {
                            errCount = errCount + fwkhCounts;
                        }
                    }
                }
                if (accCount > 0)
                {
                    foreach (int ydid in PriYfsIds)
                        Bds.RemoveAt(Bds.Find("ydid", ydid));
                }
                if (Count == 0)
                {
                    ClsMsgBox.Ts("��ѡ����Ҫ���Ͷ��ŵ��˵���", ObjG.CustomMsgBox, this);
                }
                else
                {
                    ClsMsgBox.Ts("���ͳɹ�" + accCount + "��.\n" + "����ʧ��" + errCount + "��", ObjG.CustomMsgBox, this);
                    BtnQuery.PerformClick();
                    CkbQx.Checked = false;
                }
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("���ִ���,��ϸ��Ϣ:", ex, ObjG.CustomMsgBox, this);
            }
            //}
        }
        #endregion
    }
}
