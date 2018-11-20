#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pub;
using JY.Pri;
using FMS.ZYGL.ZJDB.YQZLDB;
#endregion

namespace FMS.ZYGL.ZJDB.YQZLDP
{
    public partial class FrmZzCz : Form
    {
        #region 成员变量
        private DSYQZL.VfmsyqzlfhRow PriRow;
        private Dictionary<string, string> PriDic;
        private string PriServerKhhStr;
        private string PriServerPwdStr;
        private string PriServerCZYH;
        private string PriConStr; //数据库连接字符串
        private ClsG ObjG;
        private DataTable PriDt;
        private char PriIsOk;
        public List<string> list;
        private string Prizhmc;
        private string Prikhh;
        private string Prilhh;
        private string Prijgh;
        #endregion
        public FrmZzCz()
        {
            InitializeComponent();
        }
        public void Prepare(DSYQZL.VfmsyqzlfhRow aRow)
        {
            PriDic = new Dictionary<string, string>();
            PriDic = ClsRWDBOptions.GetDic(ClsGlobals.CntStrKj);
            PriServerKhhStr = PriDic["JY_KHH"];
            PriServerPwdStr = PriDic["JY_DLMM"];
            PriServerCZYH = PriDic["JY_CZYH"];
            PriRow = aRow;
            LblZczh1.Text = aRow.zczh;
            LblZCZHMC.Text = aRow.zczhmc;
            LblZCYHMC.Text = aRow.zczhyh;
            Lblsjzzje.Text = aRow.sjzze.ToString();
            LblZrZh1.Text = aRow.zrzh;
            LblZRZHMC.Text = aRow.zrzhmc;
            LblZRYHMC.Text = aRow.zrzhyh;
            LblZzje.Text = aRow.zze.ToString();
            LblBz.Text = aRow.bz;
            ObjG = Session["ObjG"] as ClsG;
            PriConStr = ClsGlobals.CntStrTMS;
        }

        private void BtnZZ_Click(object sender, EventArgs e)
        {
            FrmJe f = new FrmJe();
            f.Prepare(PriRow.sjzze);
            f.ShowDialog();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmJe f = sender as FrmJe;
            string azt1 = "";
            string aStr = "";
            string aTs = "";
            if (f.DialogResult == DialogResult.Yes)
            {
                try
                {
                    #region   同行转账
                    string Xml6W80Str = "";
                    string sqlText = "insert into Tfmsxlh values('Z',getdate()) Select SCOPE_IDENTITY() ";
                    string aXlh;
                    if (LblZCYHMC.Text.Equals(LblZRYHMC.Text))
                    {
                        aXlh = ClsRWMSSQLDb.GetStr("insert into Tfmsxlh values('Z',getdate()) Select SCOPE_IDENTITY()", PriConStr);
                        string[] Xml6W0101 = { aXlh, PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W0101", "CN", "370000000", LblZrZh1.Text, LblZczh1.Text };
                        string[] XmlCold = { "RETURN_CODE", "RETURN_MSG", "ACC_NAME", "OPENACC_DEPT", "UBANK_NO", "COUNTER_NO", "EXCHANGE_NO" };
                        //返回有用信息
                        string Xml6W0101Str = ClsSockets.sendStr(Xml6W0101, "6W0101.xml");
                        if (ClsGetXML.IsXml(Xml6W0101Str))
                        {
                            list = ClsGetXML.GetListStr(XmlCold, Xml6W0101Str);
                            if (list[0] != "000000")//查询账户信息失败
                            {
                                this.DialogResult = DialogResult.No;
                                aTs = "查询账户信息失败！具体原因：" + list[1];
                            }
                            else
                            {
                                aXlh = ClsRWMSSQLDb.GetStr("insert into Tfmsxlh values('Z',getdate()) Select SCOPE_IDENTITY()", PriConStr);
                                string[] Xml6W8010 = { aXlh, PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W8010", "CN", LblZczh1.Text, LblZrZh1.Text, list[4], list[2], list[3], aXlh, list[5], Lblsjzzje.Text, "01", aXlh, "备注1", "备注2", "", "" };
                                list.Clear();

                                Xml6W80Str = ClsSockets.sendStr(Xml6W8010, "6W8010.xml");
                                if (ClsGetXML.IsXml(Xml6W80Str))
                                {
                                    string[] reciveStr = { "RETURN_CODE", "RETURN_MSG" };
                                    list = ClsGetXML.GetListStr(reciveStr, Xml6W80Str);
                                    DataTable dt = ClsRWMSSQLDb.GetDataTable("Select RETURN_CODE from tcode where lx ='Z'", ClsGlobals.CntStrTMS);
                                    if (list[0] == "000000")
                                    {
                                        this.DialogResult = DialogResult.Yes;
                                        azt1 = "10";
                                        aTs = "转账成功！";
                                    }
                                    else if (dt.Select("RETURN_CODE = '" + list[0] + "'").Length > 0)
                                    {
                                        this.DialogResult = DialogResult.No;
                                        azt1 = "20";
                                        aTs = "转账失败！";
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.No;
                                        azt1 = "5";
                                        aTs = "转账中,请通过调拨结果查询查看转账结果！";
                                    }
                                    aStr = string.Format(" update Tzzlog set zt='{0}' ,fhsj=getdate(),fhczyid='{1}',fhczyxm='{2}',xlh={3}  where id ={4}; ", azt1, ObjG.Renyuan.id, ObjG.Renyuan.xm, aXlh, PriRow.id);
                                    if (PriRow.lx == "C" && azt1 == "10")
                                        aStr = aStr + string.Format(" update tfmsdskckffpc set zzzt='10' where id in (select ffpcid from Tzzlogmx where pcid='{0}'  ) ", PriRow.id);
                                    ClsRWMSSQLDb.ExecuteCmd(aStr, ClsGlobals.CntStrTMS);
                                    this.DialogResult = DialogResult.Yes;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.No;
                                    aTs = "银企直联功能异常,请联系管理员！";
                                }
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.No;
                            aTs = "银企直联功能异常,请联系管理员！";
                        }
                    }
                    #endregion
                    #region 跨行
                    else
                    {
                        string Xlh;
                        Xlh = ClsRWMSSQLDb.GetStr("insert into Tfmsxlh values('Z',getdate()) Select SCOPE_IDENTITY()", PriConStr);
                        aXlh = Xlh;
                        DataRow dr = ClsRWMSSQLDb.GetDataRow(" select khh,lhh from tfmsyhzh WHERE zh='" + PriRow.zrzh + "'", ClsGlobals.CntStrTMS);
                        //跨行转账
                        if (dr == null || dr["khh"].ToString().Length == 0 || dr["lhh"].ToString().Length == 0)
                        {
                            this.DialogResult = DialogResult.No;
                            aTs = "请联系银行管理员，维护" + PriRow.zrzh + "的开户行机构或联行号！";
                        }
                        else
                        {
                            string[] Xml6W8020 = { aXlh, PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W8020", "CN", LblZczh1.Text, LblZrZh1.Text, LblZRZHMC.Text, dr["khh"].ToString(), dr["lhh"].ToString(), Lblsjzzje.Text, "01", aXlh, LblBz.Text, "备注2", "", "" };
                            Xml6W80Str = ClsSockets.sendStr(Xml6W8020, "6W8020.xml");
                            if (ClsGetXML.IsXml(Xml6W80Str))
                            {
                                string[] reciveStr = { "RETURN_CODE", "RETURN_MSG", "DEAL_TYPE" };
                                list = ClsGetXML.GetListStr(reciveStr, Xml6W80Str);
                                DataTable dt = ClsRWMSSQLDb.GetDataTable("Select RETURN_CODE from tcode where lx ='Z'", ClsGlobals.CntStrTMS);
                                if (list[0] == "000000")
                                {
                                    int n;
                                    if (!Int32.TryParse(list[2].ToString(), out n))
                                    {
                                        if (list[2].ToString() == "A")
                                        {
                                            this.DialogResult = DialogResult.No;
                                            azt1 = "20";
                                            aTs = "转账失败！";
                                        }
                                        else
                                        {
                                            this.DialogResult = DialogResult.No;
                                            azt1 = "5";
                                            aTs = "转账中,请通过调拨结果查询查看转账结果！";
                                        }
                                    }
                                    else if (n == 9)
                                    {
                                        list.Clear();
                                        sqlText = "insert into Tfmsxlh values('Z',getdate()) Select SCOPE_IDENTITY() ";
                                        aXlh = ClsRWMSSQLDb.GetStr(sqlText, PriConStr);
                                        string[] Xml6W0600 = { aXlh, PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W0600", "CN", Xlh };
                                        string Xml6W0600Str = ClsSockets.sendStr(Xml6W0600, "6W0600.xml");
                                        if (ClsGetXML.IsXml(Xml6W80Str))
                                        {
                                            string[] reciveStr6W0600 = { "RETURN_CODE", "DEAL_RESULT", };
                                            list = ClsGetXML.GetListStr(reciveStr6W0600, Xml6W0600Str);
                                            if (list[0] == "000000")
                                            {
                                                if (list[0] == "2" || list[0] == "3" || list[0] == "4")
                                                {
                                                    this.DialogResult = DialogResult.Yes;
                                                    aTs = "转账成功";
                                                    azt1 = "10";
                                                }
                                                else if (list[0] == "5")
                                                {
                                                    this.DialogResult = DialogResult.No;
                                                    azt1 = "20";
                                                    aTs = "转账失败！";
                                                }
                                                else
                                                {
                                                    this.DialogResult = DialogResult.No;
                                                    azt1 = "5";
                                                    aTs = "转账中,请通过调拨结果查询查看转账结果！";
                                                }
                                            }
                                            else
                                            {
                                                this.DialogResult = DialogResult.No;
                                                azt1 = "5";
                                                aTs = "转账中,请通过调拨结果查询查看转账结果！";
                                            }
                                        }
                                        else
                                        {
                                            this.DialogResult = DialogResult.No;
                                            aTs = "银企直联功能异常,请联系管理员！";
                                        }
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.No;
                                        azt1 = "5";
                                        aTs = "转账中,请通过调拨结果查询查看转账结果！";
                                    }
                                }
                                else if (dt.Select("RETURN_CODE = '" + list[0] + "'").Length > 0)
                                {
                                    this.DialogResult = DialogResult.No;
                                    azt1 = "20";
                                    aTs = "转账失败！";
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.No;
                                    azt1 = "5";
                                    aTs = "转账中,请通过调拨结果查询查看转账结果！";
                                }
                                if (azt1 != "")
                                {
                                    aStr = string.Format(" update Tzzlog set zt='{0}' ,fhsj=getdate(),fhczyid='{1}',fhczyxm='{2}',xlh={3}  where id ={4}; ", azt1, ObjG.Renyuan.id, ObjG.Renyuan.xm, aXlh, PriRow.id);
                                }
                                if (PriRow.lx == "C" && azt1 == "10")
                                    aStr = aStr + string.Format(" update tfmsdskckffpc set zzzt='10' where id in (select ffpcid from Tzzlogmx where pcid={0}  ) ", PriRow.id);
                                ClsRWMSSQLDb.ExecuteCmd(aStr, ClsGlobals.CntStrTMS);
                                this.DialogResult = DialogResult.Yes;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.No;
                                aTs = "银企直联功能异常,请联系管理员！";
                            }
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    this.DialogResult = DialogResult.No;
                    aTs = "出现异常,具体信息：" + ex.Message;
                }
                finally
                {
                    this.Close();
                    ClsMsgBox.Ts(aTs, ObjG.CustomMsgBox, this);
                }

            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
