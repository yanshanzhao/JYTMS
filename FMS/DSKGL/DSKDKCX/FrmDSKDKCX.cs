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
        private string PriServerKhhStr;// = ClsRWDBOptions.GetStr("JY_KHH", ClsGlobals.CntStrKj);//建行客户号
        private string PriServerPwdStr;// = ClsRWDBOptions.GetStr("JY_DLMM", ClsGlobals.CntStrKj);//建行密码
        private string PriServerCZYH;// = ClsRWDBOptions.GetStr("JY_CZYH", ClsGlobals.CntStrKj);//建行操作员号
        private string PriServerDFBH;// = ClsRWDBOptions.GetStr("JY_DKBH", ClsGlobals.CntStrKj);//建行代发编号
        private string PriServerDFYTBH;// = ClsRWDBOptions.GetStr("JY_DKYTPH", ClsGlobals.CntStrKj);//建行代发用途编号
        private int PriXlh;//序列号
        string[] XML_TXValues;
        private List<string> LstValues = new List<string>();
        private List<string> LstError = new List<string>();
        public FrmDSKDKCX()
        {
            InitializeComponent();
        }

        #region 成员变量
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

        #region 导出
        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] cellindex = { 3 };
            ClsExcel.CreatExcel(Dgv, "代收款代扣查询", this.ctrlDownLoad1, cellindex);
        }
        #endregion

        #region 查询
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                Where = " where  inssj >= '" + DtpCjStart.Value.Date + "' and inssj <'" + DtpCjStop.Value.AddDays(1).Date + "'";
                //if (this.CmbZt.Text != "全部")
                if (CmbZt.SelectedIndex == 1)
                    Where += " and zt=10";
                if (CmbZt.SelectedIndex == 2)
                    Where += " and zt = 20";
                if (!string.IsNullOrEmpty(this.TxtJgmc.Text))
                    Where += " and jgid=" + PriJg;
                vfmsdskdkcxTableAdapter1.FillByWhere(Dsdskdkcx1.Vfmsdskdkcx, Where);
                LblRowCount.Text = "共有" + BdsDskdkcx.Count.ToString() + "条数据" + "成功" + Dsdskdkcx1.Vfmsdskdkcx.Compute("sum(zze)", "zts='成功'").ToString() + "元，失败" + Dsdskdkcx1.Vfmsdskdkcx.Compute("sum(zze)", "zts='失败'").ToString() + "元，代扣中" + Dsdskdkcx1.Vfmsdskdkcx.Compute("sum(zze)", "zts='代扣中'").ToString() + "元";
                if (BdsDskdkcx.Count == 0)
                    ClsMsgBox.Ts("没有要查询的数据", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("查询信息失败", ex, ObjG.CustomMsgBox, this);
            }
            finally
            {
            }
        }
        #endregion

        #region 机构选择
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
            LstV.Columns[0].Text = "机构名称";
            LstV.Columns[1].Text = "拼音码";

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

        #region 代扣查询
        private void BtnDksbcx_Click(object sender, EventArgs e)
        {
            PriDic = new Dictionary<string, string>();
            PriDic = ClsRWDBOptions.GetDic(ClsGlobals.CntStrKj);
            PriServerKhhStr = PriDic["JY_KHH"];
            PriServerPwdStr = PriDic["JY_DLMM"];
            PriServerCZYH = PriDic["JY_CZYH"];
            PriServerDFBH = PriDic["JY_DKBH"];
            PriServerDFYTBH = PriDic["JY_DKYTPH"];
            //Tfmsdskjkpc 代扣状态：0-未代扣,5-代扣中，10-代扣成功,20-代扣失败
            List<string> UncertaintyLst = new List<string>();
            vfmsdskdkcxTableAdapter1.FillByWhere(Dsdskdkcx1.Vfmsdskdkcx, " where zt = 5");
            LblRowCount.Text = "共有" + BdsDskdkcx.Count.ToString() + "条数据";
            foreach (DSDSKDKCX.VfmsdskdkcxRow row in Dsdskdkcx1.Vfmsdskdkcx)
            {
                PriXlh = GetXlh("Z");//代收款代扣序列号
                string[] strName = new string[] { "RETURN_CODE", "DEAL_RESULT", "MESSAGE" };
                XML_TXValues = new string[] { PriXlh.ToString(), PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W1503", "CN", "15006" };
                string recvStr = ClsSockets.sendStr(XML_TXValues, "6W1503.xml");
                if (!ClsGetXML.IsXml(recvStr))
                {
                    ClsMsgBox.Ts("查询错误！\n" + recvStr, ObjG.CustomMsgBox, this);
                    break;
                }
                LstValues = ClsGetXML.GetListStr(strName, recvStr);
                //Socket(row.qqxlh);
                if (LstValues.Count > 0)
                {
                    if (LstValues[0] == "000000")
                    {
                        if (LstValues[1].ToString().Equals("4"))//成功
                        {
                            ClsRWMSSQLDb.ExecuteCmd(string.Format("Update Tfmsdskjkpc set dkzt = 10 where id ={0} and dkzt = 5;Update tfmskjlog set zt = 10 where id = {1} and zt = 5", row.dskjkpcid, row.id), ClsGlobals.CntStrTMS);
                            row.zts = "成功";
                        }
                        else if (LstValues[1].ToString().Equals("3"))//失败
                        {
                            ClsRWMSSQLDb.ExecuteCmd(string.Format("Update Tfmsdskjkpc set dkzt = 20 where id ={0} and dkzt = 5;Update tfmskjlog set zt = 20,zy='{1}' where id = {2} and zt = 5", row.dskjkpcid, LstValues[1] + LstValues[2], row.id), ClsGlobals.CntStrTMS);
                            row.zts = "失败";
                        }
                        else
                        {
                            ClsRWMSSQLDb.ExecuteCmd(string.Format("Update tfmskjlog set zy = '{0}' where id = {1} and zt = 5", LstValues[1] + LstValues[2], row.id), ClsGlobals.CntStrTMS);
                            row.zts = "代扣中";
                        }
                    }
                    else if (LstValues[0] == "0130Z110BB22")
                    {
                        ClsRWMSSQLDb.ExecuteCmd(string.Format("Update Tfmsdskjkpc set dkzt = 20 where id ={0} and dkzt = 5;Update tfmskjlog set zt = 20,zy='查询外联记录为空' where id = {1} and zt = 5", row.dskjkpcid, row.id), ClsGlobals.CntStrTMS);
                        row.zts = "失败";
                        row.zy = "查询外联记录为空";
                    }
                    else
                    {
                        UncertaintyLst.Add(row.rbdh);
                        continue;
                    }
                }
            }
            if (UncertaintyLst.Count > 0)
                ClsMsgBox.Ts(string.Join("\n", UncertaintyLst) + "\n没有不确定结果的交易流水:查询外联记录为空!请联系管理员!", ObjG.CustomMsgBox, this);
            LstValues.Clear();
        }
        #endregion

        /// <summary>
        /// 组装并发送报文，得到代扣结果
        /// </summary>
        /// <param name="aYhzh">代扣银行帐号</param>
        /// <param name="aZhmc">代扣帐号名称</param>
        /// <param name="aJe">代扣金额</param>
        private void Socket(int aOldXlh)
        {
            try
            {
                PriXlh = GetXlh("Z");//代收款代扣序列号
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
        /// 请求序列号
        /// </summary>
        /// <param name="aType"></param>
        /// <returns></returns>
        private int GetXlh(string aType)
        {
            return ClsRWMSSQLDb.GetInt(string.Format("Insert into Tfmsxlh values('{0}',getdate());Select SCOPE_IDENTITY()", aType), ClsGlobals.CntStrTMS);
        }
    }
}
