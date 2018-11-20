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
        #region 初始化成员变量
        private ClsG ObjG;
        private List<int> PriYfsIds;
        private string PriLxdh = "";
        private bool PriBool = true;//判断是否发送状态选择为全部 

        private DataRow[] PriDxx = null;
        private int PriLx = 0;//类型:0表示为原来的,1表示使用最新的模板信息
        private DataTable PriDt = null;
        private string Prizh = "";//短信账号
        private string Primm = "";//密码
        private string Pridxcpbh = "";//短信产品编码
        private string Pricwdxcpbh = "";//短信产品编码(错误)
        private string Prigysbh = "";//供应商编码
        private string Priurl = "";//地址
        private string Pridxffmc = "";//短信方法名称
        private string Pricwffmc = "";//短信方法名称(错误)
        private string Prinr = "";//发送信息的模板
        private string PrinrCw = "";//发送信息的模板(错误)
        private int Pricount = 0;//出现的次数
        private int PricountDx = 0;//是否使用短信
        private int PricountCW = 0;//是否使用短信(错误)
        private int Pridxmmid = 0;//短信模板id
        private int Pricwmmid = 0;//短信模板id(错误)
        private string PriSyzt = "";//使用状态
        private int Prijgid;//机构id


        private string PriHbzh = "";//短信账号
        private string PriHbmm = "";//密码
        private string PriHbdxcpbh = "";//短信产品编码
        private string PriHbdxffmc = "";//短信方法名称
        private string PriHbnr = "";//发送信息的模板
        private int PriHbdxmmid = 0;//短信模板id
        private int PriHbcount = 0;//出现的次数
        private int PricountHbDx = 0;//是否使用短信
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

            //寻找序号为001且类型为发货短信通知的模板
            DataRow[] dr = null;
            dr = PriDt.Select(string.Format(" jgid={0}  and tzlx=3  and xh='001' and yy=0 ", Prijgid));
            if (dr.Length > 0)//短信
            {
                Pricount++;
                PricountDx++;
                //获取供应商编码、账号、密码和地址
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
            if (dr.Length > 0)//短信(错误)
            {
                Pricount++;
                PricountCW++;
                //获取供应商编码、账号、密码和地址
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
            if (dr.Length > 0)//短信
            {
                Pricount++;
                PricountHbDx++;
                //获取供应商编码、账号、密码和地址
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

        #region 查询
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

        #region 发送短信
        private void BtnFsdx_Click(object sender, EventArgs e)
        {
            if (!ClsOptions.WebCfg.DuaxinTzIsOpen)
            {
                ClsMsgBox.Ts("暂时关闭短信接口", ObjG.CustomMsgBox, this);
                return;
            }
            #region 原来的不再使用
            //if (PriLx == 0)
            //{
            //    try
            //    {
            //        PriYfsIds = new List<int>();//移除发送成功行的list
            //        int Count = 0//选中多少行
            //            , accCount = 0//成功多少行
            //            , errCount = 0//失败多少行
            //            , errtelCount = 0;//发送号码异常个数;
            //        ClsDskmessage Dskmessage = new ClsDskmessage();
            //        foreach (DataGridViewRow row in Dgv.Rows)
            //        {
            //            if (Convert.ToBoolean(row.Cells[DgvColChkQx1.Name].Value))
            //            {
            //                Count++;
            //                #region 传参

            //                DsDxtz.VfmsdskdxfsRow r = (DsDxtz.VfmsdskdxfsRow)((DataRowView)row.DataBoundItem).Row;
            //                if (!r.IstelNull() && r.tel != "" && ClsRegEx.IsShouJi(r.tel))
            //                {
            //                    Dskmessage.mobile = r.tel;//手机电话
            //                }
            //                else if (!r.IstelNull() && r.tel != "" && ClsRegEx.IsZuoJi(r.tel))
            //                {
            //                    //ClsMsgBox.Cw("运单号为" + r.bh + "的运单短信发送失败，请检查发送号码是否正确！", ObjG.CustomMsgBox, this);
            //                    errtelCount++;
            //                    continue;
            //                }
            //                else
            //                {
            //                    // ClsMsgBox.Cw("运单号为" + r.bh + "的运单短信发送失败，请检查发送号码是否正确！", ObjG.CustomMsgBox, this);
            //                    errtelCount++;
            //                    continue;
            //                }
            //                if (r.zt == 0)//失败短信
            //                    Dskmessage.msg = "尊敬的客户你好：你的单号为" + r.bh + "代收货款因" + r.ycxx + "原因未发放。请速到受理网点办理相关变更手续，如有疑问请致佳怡物流电话为" + PriLxdh + "。 ";
            //                else if (r.zt == 20)//成功短信
            //                    Dskmessage.msg = "尊敬的客户您好：你的单号为" + r.bh + "代收货款金额为" + r.sfje + "元已打款成功，请注意查收。";
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
            //            ClsMsgBox.Ts("请选择需要发送短信的运单！", ObjG.CustomMsgBox, this);
            //        }
            //        else
            //        {
            //            ClsMsgBox.Ts("共发送短信" + Count + "条.\n其中号码异常有" + errtelCount + "条.\n成功发送" + accCount + "条.\n" + "发送失败" + errCount + "条", ObjG.CustomMsgBox, this);
            //            BtnQuery.PerformClick();
            //            CkbQx.Checked = false;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        ClsMsgBox.Cw("出现错误,详细信息:", ex, ObjG.CustomMsgBox, this);
            //    }
            //}
            #endregion 原来的不再使用
            //else
            //{
            if (Pricount == 0)
            {
                ClsMsgBox.Ts("该机构无配置的短信信息!", ObjG.CustomMsgBox, this);
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
                //int bclx = 0;//本次发送方式  0--短信 1--短信(错误)
                int mmid = 0;//本次使用的模板id
                int fsydid = 0;//运单id
                string qt = "代收款短信通知";

                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[DgvColChkQx1.Name].Value))
                    {
                        Count++;
                        #region 传参

                        DsDxtz.VfmsdskdxfsRow r = (DsDxtz.VfmsdskdxfsRow)((DataRowView)row.DataBoundItem).Row;
                        if (!r.IstelNull() && r.tel != "" && ClsRegEx.IsShouJi(r.tel))
                        {
                            //bclx = 0;
                            if (Prigysbh == "01")
                                smsmodel.sdst = r.tel;//手机电话
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

                            //ClsMsgBox.Cw("运单号为" + r.bh + "的运单短信发送失败，请检查发送号码是否正确！", ObjG.CustomMsgBox, this);
                            errCount++;
                            continue;
                        }
                        else
                        {
                            // ClsMsgBox.Cw("运单号为" + r.bh + "的运单短信发送失败，请检查发送号码是否正确！", ObjG.CustomMsgBox, this);
                            errCount++;
                            continue;
                        }
                        //组装发送的信息 
                        if (r.zt == 0)//失败短信
                        {
                            //bclx = 1;
                            if (Prigysbh == "01")
                                strsmsg = string.Format(PrinrCw, r.bh, r.ycxx, PriLxdh);
                            else if (Prigysbh == "02")
                                strsmsg = string.Format("@1@={0},@2@={1},@3@={2}", r.bh, r.ycxx, PriLxdh);
                        }
                        else if (r.zt == 20)//成功短信
                        {
                            //bclx = 0;
                            if (Prigysbh == "01")
                                strsmsg = string.Format(Prinr, r.bh, r.sfje);
                            else if (Prigysbh == "02")
                                strsmsg = string.Format("@1@={0},@2@={1}", r.bh, r.sfje);
                        }
                        if (Prigysbh == "01")
                        {
                            if (r.zt == 20)//短信
                            {
                                smsmodel.cpbh = Pridxcpbh;
                                smsmodel.ffmc = Pridxffmc;
                                smsmodel.smsg = strsmsg;
                                mmid = Pridxmmid;
                            }
                            if (r.zt == 0)//短信（失败）
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
                            if (r.zt == 20)//短信
                            {
                                dxinfo.content = strsmsg;
                                mmid = Pridxmmid;
                            }
                            if (r.zt == 0)//短信（失败）
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
                    ClsMsgBox.Ts("请选择需要发送短信的运单！", ObjG.CustomMsgBox, this);
                }
                else
                {
                    ClsMsgBox.Ts("共发送短信" + Count + "条.\n其中号码异常有" + errCount + "条.\n成功发送" + accCount + "条.\n" + "发送失败" + errCount + "条", ObjG.CustomMsgBox, this);
                    BtnQuery.PerformClick();
                    CkbQx.Checked = false;
                }
                //}
            }
        }
        #endregion

        #region 全选
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

        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("没有要导出的运单信息！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.Rows.Count > 60000)
            {
                ClsMsgBox.Ts("不允许导出大于60000条的数据!", ObjG.CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(Dgv, "代收款发放短信通知", ctrlDownLoad1, new int[] { 6, 7, 9, 10 });
        }
        #endregion

        #region 发送成功
        private void BtnDxtz_Click(object sender, EventArgs e)
        {
            try
            {
                PriYfsIds = new List<int>();//移除发送成功行的list

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
                    ClsMsgBox.Ts("请选择要发送的运单信息。", ObjG.CustomMsgBox, this);
                    return;
                }
                ClsRWMSSQLDb.GetInt(" update Tyd set dskdxzt=10 where  id  in (" + string.Join(",", PriYfsIds) + ")and dskdxzt<>10 ;", ClsGlobals.CntStrTMS);
                ClsMsgBox.Ts("发送成功" + PriYfsIds.Count + "条", ObjG.CustomMsgBox, this);
                BtnQuery.PerformClick();
                CkbQx.Checked = false;
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("出现错误,详细信息:", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion

        #region 合并发送短信
        private void BtnDxhb_Click(object sender, EventArgs e)
        {
            if (!ClsOptions.WebCfg.DuaxinTzIsOpen)
            {
                ClsMsgBox.Ts("暂时关闭短信接口", ObjG.CustomMsgBox, this);
                return;
            }

            if (!PriBool)
            {
                ClsMsgBox.Ts("系统只能合并发送成功的代收款信息！请重新选择查询条件！");
                return;
            }
            #region 原供应商不再使用
            //if (PriLx == 0)
            //{
            //    try
            //    {
            //        PriYfsIds = new List<int>();//移除发送成功行的list
            //        string fwkh = "";//服务卡号
            //        int fwkhCounts = 0;//服务卡号对应的代收款个数
            //        string fwkhStr = "";//发送短信中关于代收款的运单和代收款金额的语句
            //        string fwkhSQL = "";//执行SQL语句
            //        string fwkhTel = "";//服务卡号电话
            //        List<int> fwkhList = new List<int>();//服务卡号对应的运单id
            //        int Count = 0//选中多少行
            //            , accCount = 0//成功多少行
            //            , errCount = 0;//失败多少行 
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
            //                    fwkhStr = "单号:" + r.bh + ",代收款金额:" + r.dsk + ";";
            //                    fwkhList.Add(r.ydid);
            //                    fwkhSQL = "insert into Tdx (ydid,fsjgid,fsrid,fsrxm,zt,zyf,dsk,lx) values(" + r.ydid + ",'{0}','{1}','{2}','{3}'," + r.zyf + "," + r.dsk + ",'Y');";
            //                }
            //                else
            //                {
            //                    //对于同一个服务卡
            //                    if (fwkh == r.fwkh)
            //                    {
            //                        if (fwkhCounts == 4)
            //                        {
            //                            ClsDskmessage Dskmessage = new ClsDskmessage();
            //                            Dskmessage.msg = "尊敬的客户您好:您的服务卡号" + fwkh + ",有" + fwkhCounts + "票代收款已经打款成功," + fwkhStr + "请注意查收.佳怡物流";
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
            //                        fwkhStr += "单号:" + r.bh + ",代收款金额:" + r.dsk;
            //                        fwkhList.Add(r.ydid);
            //                        fwkhSQL += "insert into Tdx (ydid,fsjgid,fsrid,fsrxm,zt,zyf,dsk,lx) values(" + r.ydid + ",'{0}','{1}','{2}','{3}'," + r.zyf + "," + r.dsk + ",'Y');";
            //                    }
            //                    else
            //                    {
            //                        ClsDskmessage Dskmessage = new ClsDskmessage();
            //                        Dskmessage.msg = "尊敬的客户您好:您的服务卡号" + fwkh + ",有" + fwkhCounts + "票代收款已经打款成功," + fwkhStr + "请注意查收.佳怡物流";
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
            //                        fwkhStr += "单号：" + r.bh + ",代收款金额：" + r.dsk + ";";
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
            //            Dskmessage.msg = "尊敬的客户您好:您的服务卡号" + fwkh + ",有" + fwkhCounts + "票代收款已经打款成功," + fwkhStr + "请注意查收.佳怡物流";
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
            //            ClsMsgBox.Ts("请选择需要发送短信的运单！", ObjG.CustomMsgBox, this);
            //        }
            //        else
            //        {
            //            ClsMsgBox.Ts("发送成功" + accCount + "条.\n" + "发送失败" + errCount + "条", ObjG.CustomMsgBox, this);
            //            BtnQuery.PerformClick();
            //            CkbQx.Checked = false;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        ClsMsgBox.Cw("出现错误,详细信息:", ex, ObjG.CustomMsgBox, this);
            //    }
            //}
            #endregion 原供应商不再使用
            //else
            //{
            //合并发送成功的短信   使用微网通联    
            //首先判断是否为同一个服务卡号  如果是同一个服务卡号的  在查看是否发送的运单条数是否为4  如果符合以上条件就发送短信否则就不发送短信
            //首先判断是否为同一个服务卡号  如果不是同一个服务卡号的  就发送之前累计的发送短信的信息 在累计本次的短信信息 
            //2017-07-10 只需要更改执行的SQL和发送的短信供应商
            try
            {
                PriYfsIds = new List<int>();//移除发送成功行的list
                string fwkh = "";//服务卡号
                int fwkhCounts = 0;//服务卡号对应的代收款个数
                string fwkhStr = "";//发送短信中关于代收款的运单和代收款金额的语句
                string fwkhSQL = "", zxdxnrSQL = "";//执行SQL语句
                string fwkhTel = "";//服务卡号电话
                List<int> fwkhList = new List<int>();//服务卡号对应的运单id
                int Count = 0//选中多少行
                    , accCount = 0//成功多少行
                    , errCount = 0;//失败多少行 
                ClsDxWwtl smsmodel = new ClsDxWwtl();
                ClsXCKJ dxinfo = new ClsXCKJ();
                if (Prigysbh == "01")
                {
                    smsmodel.user = Prizh;//账号
                    smsmodel.pasword = Primm;//密码
                    smsmodel.cpbh = PriHbdxcpbh;//产品编码
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
                            fwkhStr = "单号:" + r.bh + ",代收款金额:" + r.dsk + ";";
                            fwkhList.Add(r.ydid);
                        }
                        else
                        {
                            //对于同一个服务卡
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
                                fwkhStr += "单号:" + r.bh + ",代收款金额:" + r.dsk;
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
                                fwkhStr += "单号：" + r.bh + ",代收款金额：" + r.dsk + ";";
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
                    ClsMsgBox.Ts("请选择需要发送短信的运单！", ObjG.CustomMsgBox, this);
                }
                else
                {
                    ClsMsgBox.Ts("发送成功" + accCount + "条.\n" + "发送失败" + errCount + "条", ObjG.CustomMsgBox, this);
                    BtnQuery.PerformClick();
                    CkbQx.Checked = false;
                }
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("出现错误,详细信息:", ex, ObjG.CustomMsgBox, this);
            }
            //}
        }
        #endregion
    }
}
