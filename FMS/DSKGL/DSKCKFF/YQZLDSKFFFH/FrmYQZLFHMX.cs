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
        #region ��Ա����
        private ClsG ObjG;
        private DSYQZLFFFH.VfmsYQZLDSKFFRow PriRow;
        private List<int> ListMXid = new List<int>();//��¼��ϸ���е�id
        private List<int> ListDskid = new List<int>();//tfmsDsk���е�id
        private List<string> ListYhzh = new List<string>();//��¼�����˻�
        private List<string> ListXm = new List<string>();//��¼�����˻�������
        private List<decimal> ListJe = new List<decimal>();//��¼�����˻��Ľ��
        private Dictionary<string, string> PriDic;// = ClsRWDBOptions.GetDic(ClsGlobals.CntStrKj);
        private string PriServerKhhStr;// = ClsRWDBOptions.GetStr("JY_KHH", ClsGlobals.CntStrKj);//���пͻ���
        private string PriServerPwdStr;// = ClsRWDBOptions.GetStr("JY_DLMM", ClsGlobals.CntStrKj);//��������
        private string PriServerCZYH;// = ClsRWDBOptions.GetStr("JY_CZYH", ClsGlobals.CntStrKj);//���в���Ա��
        private string PriServerDFBH;// = ClsRWDBOptions.GetStr("JY_DFBH", ClsGlobals.CntStrKj);//���д������
        private string PriServerDFYTBH;// = ClsRWDBOptions.GetStr("JY_DFYTPH", ClsGlobals.CntStrKj);//���д�����;���
        private string PriDgzh; //�Թ��˻�
        private string PriYcInset = "";//�쳣��Ϣ����
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
                ClsMsgBox.Ts("�����ܽ���ʽ����ȷ��", this, TxtZje, ObjG.CustomMsgBox);
                return;
            }
            if (!ClsRegEx.IsInt1(TxtBs.Text.Trim()))
            {
                ClsMsgBox.Ts("���˱�����ʽ����ȷ��", this, TxtBs, ObjG.CustomMsgBox);
                return;
            }
            string sqltxt = string.Format("SELECT SUM(dsk)-SUM(sxf) as  zje,COUNT(id) bs FROM dbo.tfmsdskckffmx WHERE pcid ={0}  GROUP BY pcid", PriRow.id);
            DataRow dr = ClsRWMSSQLDb.GetDataRow(sqltxt, ClsGlobals.CntStrTMS);
            if (dr == null)
            {
                ClsMsgBox.Ts("û�з�����ϸ��Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            if (Convert.ToDecimal(dr["zje"]) != Convert.ToDecimal(TxtZje.Text.Trim()))
            {
                ClsMsgBox.Ts("ʵ�ʷ����ܽ���뷢����ϸ�ܽ�����", this, TxtZje, ObjG.CustomMsgBox);
                return;
            }
            if (Convert.ToDecimal(dr["bs"]) != Convert.ToDecimal(TxtBs.Text.Trim()))
            {
                ClsMsgBox.Ts("���ű����뷢����ϸ������һ�£�", this, TxtBs, ObjG.CustomMsgBox);
                return;
            }
            if (PriRow.IsfilepathNull())
            {
                ClsMsgBox.Ts("�ļ�·��Ϊ�գ�����д��տ�����ֱ����", ObjG.CustomMsgBox, this);
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
                        #region �жϷ��͵ı����Ƿ񷵻���Ϣ
                        if (LstValues.Count > 0)
                        {
                            #region �ļ��Ƿ��ϴ��ɹ�
                            if (LstValues[0] == "000000")
                            {
                                //��������ϴ��ɹ����ϴ�״̬����ϴ��ɹ���ͬʱ���״̬���20�������У�
                                //comm.CommandText = string.Format(" SET NOCOUNT OFF update tfmsdskckffpc set zt=20,sczt=0 where id={0} and zt=10 and fhzt = 10;update tfmsdskckfflog set sczt = 0,zt = 20 where id =( select TOP(1)id from tfmsdskckfflog where ffpcid={0} ORDER BY id DESC) ", PriRow.id);
                                //if (comm.ExecuteNonQuery() == 0)
                                //{
                                //    Trans.Rollback();
                                //    ClsMsgBox.Ts("������������ˢ�����ݺ����²�����", ObjG.CustomMsgBox, this);
                                //    return;
                                //}
                                string FhwjMc = LstValues[1];
                                string[] strNameDk = new string[] { "RETURN_CODE", "RETURN_MSG", "SUCCESS_AMOUNT", "SUCCESS_NUM" };
                                string Qqxlh = GetXlh("F").ToString();
                                decimal aSfZje =Convert.ToDecimal(dr["zje"].ToString());
                                XML_MXValues = new string[] { Qqxlh, PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W2104", "CN", xlh6w2102.ToString(), "" };  
                                string recive = ClsSockets.sendStr(XML_MXValues, "6W2104.xml");
                                List<string> LstDfValues = new List<string>(ClsGetXML.GetListStr(strNameDk, recive));
                                #region �����Ƿ��з�����Ϣ
                                if (LstDfValues.Count > 0)
                                {
                                    #region �Ƿ�ɹ�
                                    if (LstDfValues[0] == "000000")
                                    {
                                        comm.CommandText = "update  tfmsdskckffmx set zt=20 where id in (" + string.Join(",", ListMXid) + ") and pcid=" + PriRow.id + "; ";
                                        comm.CommandText += string.Format(" update tfmsdskckffpc set ffsj=GETDATE(),ffsczyid={0},ffsczyxm='{1}',ffsczyzh='{2}' ,jgid={3},xlh={4} where id={5};update tfmsdskckfflog set qqxlh={4} where id =( select TOP(1)id from tfmsdskckfflog where ffpcid={5} ORDER BY id DESC)", ObjG.Renyuan.id, ObjG.Renyuan.xm, ObjG.Renyuan.loginName, ObjG.Jigou.id, Qqxlh, PriRow.id);
                                        comm.ExecuteNonQuery();
                                        Trans.Commit();
                                        this.Close();
                                        ClsMsgBox.Ts("���������ɹ�����ͨ������ֱ�����Ų�ѯ����ȷ�ϣ�\n�����ܽ�" + LstDfValues[2].ToString() + "\n�����ܱ�����" + LstDfValues[3].ToString(), ObjG.CustomMsgBox, this);
                                        PriBds.RemoveCurrent();
                                    }
                                    else
                                    {
                                        comm.CommandText = "update  tfmsdskckffmx set zt=20 where id in (" + string.Join(",", ListMXid) + ") and pcid=" + PriRow.id + "; ";
                                        comm.CommandText += string.Format(" update tfmsdskckffpc set zt= 40,ffsj=GETDATE(),ffsczyid={0},ffsczyxm='{1}',ffsczyzh='{2}' ,jgid={3},xlh={4} where id={5};update tfmsdskckfflog set zt=40 where id =( select TOP(1)id from tfmsdskckfflog where ffpcid={5} ORDER BY id DESC)", ObjG.Renyuan.id, ObjG.Renyuan.xm, ObjG.Renyuan.loginName, ObjG.Jigou.id, Qqxlh, PriRow.id);
                                        comm.ExecuteNonQuery();
                                        WriteLog(ClsGetXML.GetStrXML(XML_MXValues, "6W2100.xml"));
                                        WriteLog(recive);
                                        ClsMsgBox.Ts("�ϴ���������ʧ��!" + LstDfValues[1].ToString(), ObjG.CustomMsgBox, this);
                                        Trans.Commit();
                                    }
                                    #endregion �Ƿ�ɹ�
                                }
                                #endregion �Ƿ��з�����Ϣ
                            }
                            else
                            {
                                //���ʧ�ܣ��ϴ�״̬Ϊʧ�ܣ����״̬���䣨����10��
                                comm.CommandText = string.Format(" SET NOCOUNT OFF update tfmsdskckffpc set sczt=10,zt =25 where id={0} and zt=20 and fhzt = 10 and sczt = 0;update tfmsdskckfflog set sczt = 10,zt = 10 where id =( select TOP(1)id from tfmsdskckfflog where ffpcid={0} ORDER BY id DESC) ", PriRow.id);
                                if (comm.ExecuteNonQuery() != 1)
                                {
                                    Trans.Rollback();
                                    return;
                                }
                                //Bds.RemoveAt(Bds.Find("id", PriPcId));
                                Trans.Commit();
                                ClsMsgBox.Ts("���ʹ����ļ��ϴ�ʧ��!", ObjG.CustomMsgBox, this);
                            }
                            #endregion �ļ��Ƿ����ϴ��ɹ�
                        }
                        else
                        {
                            Trans.Rollback();
                            ClsMsgBox.Ts("���ʹ����ļ��ϴ�ʧ��!", ObjG.CustomMsgBox, this);
                        }
                        #endregion  ���͵ı����Ƿ��з�����Ϣ
                    }
                    catch (Exception ex)
                    {
                        Trans.Rollback();
                        ClsMsgBox.Cw("����ʧ�ܣ�", ex,ObjG.CustomMsgBox,this);
                    }
                }
                catch (Exception ex)
                {
                    Trans.Rollback();
                    ClsMsgBox.Cw("����ʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
                }
                finally
                {
                    conn.Close();
                }
            }
            #endregion
        }
        /// <summary>
        /// ��¼��־�ļ�
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
            //�쳣��dataTable���� �տ��ʺ� �տ��ʺ����� ���  �쳣��Ϣ
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
                        if (azzje == aycje)//�쳣��Ϣ��װ
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
        #region ��װ��־
        /// <summary>
        /// ��װ��־
        /// </summary>
        /// <param name="aDskid">dsk��id</param>
        /// <param name="aYhzh">�����˻�</param>
        /// <param name="aXm">�����˻�����</param>
        /// <param name="aje">�������</param>
        /// <param name="aje">���к�</param>
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