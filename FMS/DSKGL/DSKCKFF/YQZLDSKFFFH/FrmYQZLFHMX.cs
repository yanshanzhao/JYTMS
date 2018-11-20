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
using JY.Pri;
using JY.Pub;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

#endregion

namespace FMS.DSKGL.DSKCKFF.YQZLDSKFFFH
{
    public partial class FrmYQZLFHMX : Form
    {
        #region 成员变量
        private ClsG ObjG;
        private DSYQZLFFFH.VfmsYQZLDSKFFRow PriRow;
        private List<int> ListMXid = new List<int>();//记录明细表中的id
        private List<int> ListDskid = new List<int>();//tfmsDsk表中的id
        private List<string> ListYhzh = new List<string>();//记录银行账户
        private List<string> ListXm = new List<string>();//记录发放账户的姓名
        private List<decimal> ListJe = new List<decimal>();//记录发放账户的金额
        private Dictionary<string, string> PriDic;// = ClsRWDBOptions.GetDic(ClsGlobals.CntStrKj);
        private string PriServerKhhStr;// = ClsRWDBOptions.GetStr("JY_KHH", ClsGlobals.CntStrKj);//建行客户号
        private string PriServerPwdStr;// = ClsRWDBOptions.GetStr("JY_DLMM", ClsGlobals.CntStrKj);//建行密码
        private string PriServerCZYH;// = ClsRWDBOptions.GetStr("JY_CZYH", ClsGlobals.CntStrKj);//建行操作员号
        private string PriServerDFBH;// = ClsRWDBOptions.GetStr("JY_DFBH", ClsGlobals.CntStrKj);//建行代发编号
        private string PriServerDFYTBH;// = ClsRWDBOptions.GetStr("JY_DFYTPH", ClsGlobals.CntStrKj);//建行代发用途编号
        private string PriDgzh; //对公账户
        private string PriYcInset = "";//异常信息插入
        private string PriLogName;
        private string PriRyXm;
        private int PriRyId;
        private string[] XML_TXValues;
        private string[] XML_MXValues;
        private string[] Xml_CXValues;
        private string[] Xml_CXYCValues;
        private List<int> PriLogMxLst;
        private BindingSource PriBds;
        #endregion

        public FrmYQZLFHMX()
        {
            InitializeComponent();
        }
        public void Prepare(DSYQZLFFFH.VfmsYQZLDSKFFRow row, BindingSource aBds)
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriBds = aBds;
            PriRow = row;
            PriLogName = ObjG.Renyuan.loginName;
            PriRyXm = ObjG.Renyuan.xm;
            PriRyId = ObjG.Renyuan.id;
            PriDic = new Dictionary<string, string>();
            PriDic = ClsRWDBOptions.GetDic(ClsGlobals.CntStrKj);
            PriServerKhhStr = PriDic["JY_KHH"];
            PriServerPwdStr = PriDic["JY_DLMM"];
            PriServerCZYH = PriDic["JY_CZYH"];
            PriServerDFBH = PriDic["JY_DFBH"];
            PriServerDFYTBH = PriDic["JY_DFYTPH"];
            VfmsYQZLDSKFFMxTableAdapter1.FillByPcid(DSYQZLFFFH1.VfmsYQZLDSKFFMx, row.id);
            foreach (DSYQZLFFFH.VfmsYQZLDSKFFMxRow dr in DSYQZLFFFH1.VfmsYQZLDSKFFMx)
            {
                ListMXid.Add(dr.id);
                ListDskid.Add(dr.dskid);
                ListYhzh.Add(dr.yhzh);
                ListXm.Add(dr.mc);
                ListJe.Add(dr.dsk);
            }
            DataRow dtYhzh = ClsRWMSSQLDb.GetDataRow("  select id,zh from Tfmsyhzh where  zhlxid=59 and zhxz='G'  and yhlxid=63  and zt=0 ", ClsGlobals.CntStrTMS);
            if (dtYhzh != null)
                PriDgzh = dtYhzh[1].ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ClsRegEx.IsDecimal(TxtZje.Text.Trim()))
            {
                ClsMsgBox.Ts("复核总金额格式不正确！", this, TxtZje, ObjG.CustomMsgBox);
                return;
            }
            if (!ClsRegEx.IsInt1(TxtBs.Text.Trim()))
            {
                ClsMsgBox.Ts("复核笔数格式不正确！", this, TxtBs, ObjG.CustomMsgBox);
                return;
            }
            string sqltxt = string.Format("SELECT SUM(dsk)-SUM(sxf) as  zje,COUNT(id) bs FROM dbo.tfmsdskckffmx WHERE pcid ={0}  GROUP BY pcid", PriRow.id);
            DataRow dr = ClsRWMSSQLDb.GetDataRow(sqltxt, ClsGlobals.CntStrTMS);
            if (dr == null)
            {
                ClsMsgBox.Ts("没有发放明细信息！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Convert.ToDecimal(dr["zje"]) != Convert.ToDecimal(TxtZje.Text.Trim()))
            {
                ClsMsgBox.Ts("实际发放总金额与发放明细总金额不符！", this, TxtZje, ObjG.CustomMsgBox);
                return;
            }
            if (Convert.ToDecimal(dr["bs"]) != Convert.ToDecimal(TxtBs.Text.Trim()))
            {
                ClsMsgBox.Ts("发放笔数与发放明细笔数不一致！", this, TxtBs, ObjG.CustomMsgBox);
                return;
            }
            if (PriRow.IsfilepathNull())
            {
                ClsMsgBox.Ts("文件路径为空，请进行代收款银企直连打款！", ObjG.CustomMsgBox, this);
                return;
            }
            #region using
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                conn.Open();
                SqlTransaction Trans = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand();
                try
                {
                    comm.Connection = conn;
                    comm.Transaction = Trans;
                    try
                    {
                        int xlh6w2102=GetXlh("F");
                        comm.CommandText = string.Format("Update tfmsdskckffpc set fhzt=10,zt=20,sczt =0,xlh={1} where id={0} and fhzt = 0;", PriRow.id, xlh6w2102);
                        comm.CommandText += string.Format("update tfmsdskckfflog set sczt = 0,zt = 20,fhczyid={0},fhczyxm = '{1}',fhsj =GETDATE() where id =( select TOP(1)id from tfmsdskckfflog where ffpcid={2} ORDER BY id DESC);", ObjG.Renyuan.id, ObjG.Renyuan.xm, PriRow.id);
                        comm.CommandText += string.Format("");
                        comm.CommandText += " update tfmsDsk set ffdskzt=30 where id in (" + string.Join(",", ListDskid) + ")";
                        comm.ExecuteNonQuery();
                        string[] strName = new string[] { "RETURN_CODE", "SEND_FILE" };
                        XML_TXValues = new string[] { xlh6w2102.ToString(), PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W2102", "CN", PriRow.filepath };
                        string reciveStr = ClsSockets.sendStr(XML_TXValues, "6W2102.xml");
                        List<string> LstValues = new List<string>(ClsGetXML.GetListStr(strName, reciveStr));
                        //LstValues = ClsGetXML.GetListStr(strName, ClsSockets.sendStr(XML_TXValues, "6W2102.xml"));
                        #region 判断发送的报文是否返回信息
                        if (LstValues.Count > 0)
                        {
                            #region 文件是否上传成功
                            if (LstValues[0] == "000000")
                            {
                                //如果报文上传成功，上传状态变成上传成功，同时打款状态变成20（打款处理中）
                                //comm.CommandText = string.Format(" SET NOCOUNT OFF update tfmsdskckffpc set zt=20,sczt=0 where id={0} and zt=10 and fhzt = 10;update tfmsdskckfflog set sczt = 0,zt = 20 where id =( select TOP(1)id from tfmsdskckfflog where ffpcid={0} ORDER BY id DESC) ", PriRow.id);
                                //if (comm.ExecuteNonQuery() == 0)
                                //{
                                //    Trans.Rollback();
                                //    ClsMsgBox.Ts("并发操作，请刷新数据后重新操作！", ObjG.CustomMsgBox, this);
                                //    return;
                                //}
                                string FhwjMc = LstValues[1];
                                string[] strNameDk = new string[] { "RETURN_CODE", "RETURN_MSG", "SUCCESS_AMOUNT", "SUCCESS_NUM" };
                                string Qqxlh = GetXlh("F").ToString();
                                decimal aSfZje =Convert.ToDecimal(dr["zje"].ToString());
                                XML_MXValues = new string[] { Qqxlh, PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W2104", "CN", xlh6w2102.ToString(), "" };  
                                string recive = ClsSockets.sendStr(XML_MXValues, "6W2104.xml");
                                List<string> LstDfValues = new List<string>(ClsGetXML.GetListStr(strNameDk, recive));
                                #region 交易是否有返回信息
                                if (LstDfValues.Count > 0)
                                {
                                    #region 是否成功
                                    if (LstDfValues[0] == "000000")
                                    {
                                        comm.CommandText = "update  tfmsdskckffmx set zt=20 where id in (" + string.Join(",", ListMXid) + ") and pcid=" + PriRow.id + "; ";
                                        comm.CommandText += string.Format(" update tfmsdskckffpc set ffsj=GETDATE(),ffsczyid={0},ffsczyxm='{1}',ffsczyzh='{2}' ,jgid={3},xlh={4} where id={5};update tfmsdskckfflog set qqxlh={4} where id =( select TOP(1)id from tfmsdskckfflog where ffpcid={5} ORDER BY id DESC)", ObjG.Renyuan.id, ObjG.Renyuan.xm, ObjG.Renyuan.loginName, ObjG.Jigou.id, Qqxlh, PriRow.id);
                                        comm.ExecuteNonQuery();
                                        Trans.Commit();
                                        this.Close();
                                        ClsMsgBox.Ts("批量待发成功，请通过银企直连发放查询进行确认！\n交易总金额：" + LstDfValues[2].ToString() + "\n交易总笔数：" + LstDfValues[3].ToString(), ObjG.CustomMsgBox, this);
                                        PriBds.RemoveCurrent();
                                    }
                                    else
                                    {
                                        comm.CommandText = "update  tfmsdskckffmx set zt=20 where id in (" + string.Join(",", ListMXid) + ") and pcid=" + PriRow.id + "; ";
                                        comm.CommandText += string.Format(" update tfmsdskckffpc set zt= 40,ffsj=GETDATE(),ffsczyid={0},ffsczyxm='{1}',ffsczyzh='{2}' ,jgid={3},xlh={4} where id={5};update tfmsdskckfflog set zt=40 where id =( select TOP(1)id from tfmsdskckfflog where ffpcid={5} ORDER BY id DESC)", ObjG.Renyuan.id, ObjG.Renyuan.xm, ObjG.Renyuan.loginName, ObjG.Jigou.id, Qqxlh, PriRow.id);
                                        comm.ExecuteNonQuery();
                                        WriteLog(ClsGetXML.GetStrXML(XML_MXValues, "6W2100.xml"));
                                        WriteLog(recive);
                                        ClsMsgBox.Ts("上传批量代发失败!" + LstDfValues[1].ToString(), ObjG.CustomMsgBox, this);
                                        Trans.Commit();
                                    }
                                    #endregion 是否成功
                                }
                                #endregion 是否有返回信息
                            }
                            else
                            {
                                //如果失败，上传状态为失败，打款状态不变（保持10）
                                comm.CommandText = string.Format(" SET NOCOUNT OFF update tfmsdskckffpc set sczt=10,zt =25 where id={0} and zt=20 and fhzt = 10 and sczt = 0;update tfmsdskckfflog set sczt = 10,zt = 10 where id =( select TOP(1)id from tfmsdskckfflog where ffpcid={0} ORDER BY id DESC) ", PriRow.id);
                                if (comm.ExecuteNonQuery() != 1)
                                {
                                    Trans.Rollback();
                                    return;
                                }
                                //Bds.RemoveAt(Bds.Find("id", PriPcId));
                                Trans.Commit();
                                ClsMsgBox.Ts("发送代发文件上传失败!", ObjG.CustomMsgBox, this);
                            }
                            #endregion 文件是否已上传成功
                        }
                        else
                        {
                            Trans.Rollback();
                            ClsMsgBox.Ts("发送代发文件上传失败!", ObjG.CustomMsgBox, this);
                        }
                        #endregion  发送的报文是否有返回信息
                    }
                    catch (Exception ex)
                    {
                        Trans.Rollback();
                        ClsMsgBox.Cw("操作失败！", ex,ObjG.CustomMsgBox,this);
                    }
                }
                catch (Exception ex)
                {
                    Trans.Rollback();
                    ClsMsgBox.Cw("保存失败！", ex, ObjG.CustomMsgBox, this);
                }
                finally
                {
                    conn.Close();
                }
            }
            #endregion
        }
        /// <summary>
        /// 记录日志文件
        /// </summary>
        /// <param name="mess"></param>
        private static void WriteLog(string mess)
        {
            ClsG objG = (ClsG)VWGContext.Current.Session["objG"];
            string[] logMsg = new string[] {DateTime.Now.ToString(), objG.Renyuan.loginName,
                mess};
            string logMsgs = string.Join(",", logMsg);
            string fln = Path.Combine(ConfigurationManager.AppSettings.Get("LogFilePath"), DateTime.Now.ToString("yyyyMMdd") + ".log");
            ClsJYFuncs.AppendFile(fln, logMsgs);
        }
        private int GetLogmx(DSYQZLFFFH.VfmsdskckffmxlogDataTable adt, string XmlValues)
        {
            PriLogMxLst = new List<int>();
            DataTable aDtYc = ClsGetXML.GetItemTable(XmlValues, Xml_CXYCValues, "FAIL_LIST");
            foreach (DSYQZLFFFH.VfmsdskckffmxlogRow row in DSYQZLFFFH1.Vfmsdskckffmxlog)
            {
                for (int j = 0; j < aDtYc.Rows.Count; j++)
                {
                    if (row.yhzh.Trim() == aDtYc.Rows[j][0].ToString().Trim() && row.je.ToString().Trim() == aDtYc.Rows[j][1].ToString().Trim())
                    {
                        PriLogMxLst.Add(row.id);
                    }
                }
            }
            return PriLogMxLst.Count;
        }

        private void GetBfYcmx(DataTable adt, string XmlValues)
        {
            //异常的dataTable的列 收款帐号 收款帐号名称 金额  异常信息
            //yhzh,mc,sfje,id,dskid,dsk
            PriYcInset = "";
            DataTable aDtYc = ClsGetXML.GetItemTable(XmlValues, Xml_CXYCValues, "FAIL_LIST");
            for (int i = 0; i < adt.Rows.Count; i++)
            {
                for (int j = 0; j < aDtYc.Rows.Count; j++)
                {
                    if (adt.Rows[i][0].ToString().Trim() == aDtYc.Rows[j][0].ToString().Trim() && adt.Rows[i][1].ToString().Trim() == aDtYc.Rows[j][1].ToString().Trim())
                    {
                        double n;
                        double m;
                        double azzje = 0;
                        double aycje = 0;
                        if (double.TryParse(adt.Rows[i][2].ToString(), out n))
                        {
                            azzje = Convert.ToDouble(adt.Rows[i][2].ToString());
                        }
                        if (double.TryParse(aDtYc.Rows[j][2].ToString(), out m))
                        {
                            azzje = Convert.ToDouble(aDtYc.Rows[j][2].ToString());
                        }
                        if (azzje == aycje)//异常信息组装
                        {
                            if (PriYcInset.Length == 0)
                            {
                                PriYcInset = "(" + adt.Rows[i][3] + "," + adt.Rows[i][4] + "," + aDtYc.Rows[j][3].ToString() + "," + adt.Rows[i][4] + "," + adt.Rows[i][6] + ",'0','" + DateTime.Now.ToString() + "','" + PriLogName + "','" + PriRyXm + "'," + PriRyId + ",'10')";
                            }
                            else
                            {
                                PriYcInset = PriYcInset + ",(" + adt.Rows[i][3] + "," + adt.Rows[i][4] + "," + aDtYc.Rows[j][3].ToString() + "," + adt.Rows[i][4] + "," + adt.Rows[i][6] + ",'0','" + DateTime.Now.ToString() + "','" + PriLogName + "','" + PriRyXm + "'," + PriRyId + ",'10')";
                            }
                            break;
                        }
                    }
                }
            }
        }
        private void GetQbYcmx(DataTable adt, string aycxx)
        {
            PriYcInset = "";
            for (int i = 0; i < adt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    PriYcInset = "(" + adt.Rows[i][3] + "," + adt.Rows[i][4] + "," + aycxx + "," + adt.Rows[i][4] + "," + adt.Rows[i][6] + ",'0','" + DateTime.Now.ToString() + "','" + PriLogName + "','" + PriRyXm + "'," + PriRyId + ",'10')";
                }
                else
                {
                    PriYcInset = PriYcInset + ",(" + adt.Rows[i][3] + "," + adt.Rows[i][4] + "," + aycxx + "," + adt.Rows[i][4] + "," + adt.Rows[i][6] + ",'0','" + DateTime.Now.ToString() + "','" + PriLogName + "','" + PriRyXm + "'," + PriRyId + ",'10')";
                }
            }
        }
        #region 组装日志
        /// <summary>
        /// 组装日志
        /// </summary>
        /// <param name="aDskid">dsk的id</param>
        /// <param name="aYhzh">银行账户</param>
        /// <param name="aXm">银行账户名称</param>
        /// <param name="aje">代发金额</param>
        /// <param name="aje">序列号</param>
        /// <returns></returns>
        //private string GetInsert(List<int> aDskid, List<string> aYhzh, List<string> aXm, List<decimal> aje, string axlh)
        //{
        //    string InsertSql = "";
        //    for (int i = 0; i < aDskid.Count; i++)
        //    {
        //        if (i == 0)
        //            InsertSql = " INSERT INTO  Tfmsdklog(dskid,yhzh,xm,je ,xlh,scsj ,scczyzh,scczyxm,sczyid) VALUES(" + aDskid[i] + ",'" + aYhzh[i] + "','" + aXm[i] + "'," + aje[i] + "," + axlh + ",GetDate(),'" + PriLogName + "','" + PriRyXm + "'," + PriRyId + ") ";
        //        else
        //            InsertSql = InsertSql + ",(" + aDskid[i] + ",'" + aYhzh[i] + "','" + aXm[i] + "'," + aje[i] + "," + axlh + ",GetDate(),'" + PriLogName + "','" + PriRyXm + "'," + PriRyId + ") ";
        //    }
        //    return InsertSql;
        //}
        #endregion

        private int GetXlh(string aType)
        {
            return ClsRWMSSQLDb.GetInt(string.Format("Insert into Tfmsxlh values('{0}',getdate());Select SCOPE_IDENTITY()", aType), ClsGlobals.CntStrTMS);
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}