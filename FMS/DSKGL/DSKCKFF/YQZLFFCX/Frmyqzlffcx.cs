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

#endregion

namespace FMS.DSKGL.DSKCKFF.YQZLFFCX
{
    public partial class Frmyqzlffcx : UserControl
    {
        private ClsG ObjG;
        private Dictionary<string, string> PriDic;
        private string PriServerKhhStr;
        private string PriServerPwdStr;
        private string PriServerCZYH;
        private string PriServerDFBH;
        private string PriServerDFYTBH;
        //private string PriServerKhhStr = ClsRWDBOptions.GetStr("JY_KHH", ClsGlobals.CntStrKj);//建行客户号
        //private string PriServerPwdStr = ClsRWDBOptions.GetStr("JY_DLMM", ClsGlobals.CntStrKj);//建行密码
        //private string PriServerCZYH = ClsRWDBOptions.GetStr("JY_CZYH", ClsGlobals.CntStrKj);//建行操作员号
        //private string PriServerDFBH = ClsRWDBOptions.GetStr("JY_DFBH", ClsGlobals.CntStrKj);//建行代发编号
        //private string PriServerDFYTBH = ClsRWDBOptions.GetStr("JY_DFYTPH", ClsGlobals.CntStrKj);//建行代发用途编号
        private string PriLogName;
        private string PriRyXm;
        private int PriRyId;
        private string[] Xml_CXValues;
        private string[] Xml_CXYCValues;
        private List<int> PriLogMxLst;
        private List<string> PriErrorLst;
        private List<string> PriWinLst;
        private List<string> PriClLst;
        private string PrimxLog;//明细日志修改
        private string PriYcInset = "";//异常信息插入
        public Frmyqzlffcx()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            VyqzlcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            PriDic = new Dictionary<string, string>();
            PriDic = ClsRWDBOptions.GetDic(ClsGlobals.CntStrKj);
            PriServerKhhStr = PriDic["JY_KHH"];
            PriServerPwdStr = PriDic["JY_DLMM"];
            PriServerCZYH = PriDic["JY_CZYH"];
            PriServerDFBH = PriDic["JY_DFBH"];
            PriServerDFYTBH = PriDic["JY_DFYTPH"];
            PriLogName = ObjG.Renyuan.loginName;
            PriRyXm = ObjG.Renyuan.xm;
            PriRyId = ObjG.Renyuan.id;
            CmbDkzt.SelectedIndex = 0;

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //string where = string.Format(" where ffsj>='{0}' and ffsj<'{1}' and fhsj>='{2}' and fhsj<'{3}'", DtpDkStart.Value.Date, DtpFDkStop.Value.AddDays(1).Date, DtpFhsjStart.Value.Date, DtpFhsjEnd.Value.AddDays(1).Date);
            string where = "  ";
            if (DtpDkStart.Checked)
                where += string.Format(" and ffsj>='{0}' ", DtpDkStart.Value.Date);
            if (DtpFDkStop.Checked)
                where += string.Format(" andand ffsj<'{0}' ", DtpFDkStop.Value.AddDays(1).Date);
            if (DtpFhsjStart.Checked)
                where += string.Format(" and fhsj>='{0}' ", DtpFhsjStart.Value.Date);
            if (DtpFhsjEnd.Checked)
                where += string.Format(" and fhsj<'{0}' ", DtpFhsjEnd.Value.AddDays(1).Date);
            if (CmbDkzt.SelectedIndex == 1)
                where += " and zt = 10";
            else if (CmbDkzt.SelectedIndex == 2)
                where += " and zt = 20";
            else if (CmbDkzt.SelectedIndex == 3)
                where += " and zt = 30";
            where=where.Trim();
            if (where.Length > 0)
                where = " where " + where.Remove(0, 3);
            VyqzlcxTableAdapter1.FillByWhere(DSYQZLCX1.VYQZLCX, where);
        }
        private void GetBfYcmx(DataTable adt, string XmlValues)
        {
            //异常的dataTable的列 收款帐号 收款帐号名称 金额  异常信息
            //yhzh,mc,sfje,id,dskid,dsk
            PriYcInset = "";
            PrimxLog = "";
            DataTable aDtYc = ClsGetXML.GetItemTable(XmlValues, Xml_CXYCValues, "FAIL_LIST");
            for (int i = 0; i < aDtYc.Rows.Count; i++)
            {
                int oid = Convert.ToInt32(aDtYc.Rows[i][0]) - 1;//"OID", "RECV_ACCNO", "RECV_ACCNAME", "AMOUNT", "REMARK"
                string mc = aDtYc.Rows[i][2].ToString();
                string zh = aDtYc.Rows[i][1].ToString();
                decimal je = Convert.ToDecimal(aDtYc.Rows[i][3]);
                string remark = aDtYc.Rows[i][4].ToString();
                string amc = adt.Rows[oid]["mc"].ToString();
                string azh = adt.Rows[oid]["yhzh"].ToString();
                decimal aje = Convert.ToDecimal(adt.Rows[oid]["sfje"]);
                if (amc == mc && azh == zh && aje == je)
                {
                    PriYcInset += ",(" + adt.Rows[oid]["id"] + "," + adt.Rows[oid]["dskid"] + ",'" + remark + "'," + aje + ",0,'" + DateTime.Now.ToString() + "','" + PriLogName + "','" + PriRyXm + "'," + PriRyId + ",'10')";
                    PrimxLog += "," + adt.Rows[oid]["dskid"].ToString();
                }
            }
            PriYcInset = PriYcInset.Substring(1, PriYcInset.Length - 1);
            PrimxLog = PrimxLog.Substring(1, PrimxLog.Length - 1);
        }
        //private void GetQbYcmx(DataTable adt, string aycxx)
        //    {
        //    PriYcInset = "";
        //    for (int i = 0; i < adt.Rows.Count; i++)
        //        {
        //        if (i == 0)
        //            {
        //            PriYcInset = "(" + adt.Rows[i]["id"] + "," + adt.Rows[i]["dskid"] + ",'" + aycxx + "'," + adt.Rows[i]["dsk"] + ",'0','" + DateTime.Now.ToString() + "','" + PriLogName + "','" + PriRyXm + "'," + PriRyId + ",'10')";
        //            }
        //        else
        //            {
        //            PriYcInset = PriYcInset + ",(" + adt.Rows[i]["id"] + "," + adt.Rows[i]["dskid"] + ",'" + aycxx + "'," + adt.Rows[i]["dsk"] + ",'0','" + DateTime.Now.ToString() + "','" + PriLogName + "','" + PriRyXm + "'," + PriRyId + ",'10')";
        //            }
        //        }
        //    }
        private int GetLogmx(DSYQZLCX.VfmsdskckffmxlogDataTable adt, string XmlValues)
        {
            PriLogMxLst = new List<int>();
            DataTable aDtYc = ClsGetXML.GetItemTable(XmlValues, Xml_CXYCValues, "FAIL_LIST");
            foreach (DSYQZLCX.VfmsdskckffmxlogRow row in DSYQZLCX1.Vfmsdskckffmxlog)
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
        private int GetXlh(string aType)
        {
            return ClsRWMSSQLDb.GetInt(string.Format("Insert into Tfmsxlh values('{0}',getdate());Select SCOPE_IDENTITY()", aType), ClsGlobals.CntStrTMS);
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 7)
            {
                DSYQZLCX.VYQZLCXRow row = ((DataRowView)Bds.Current).Row as DSYQZLCX.VYQZLCXRow;
                FrmYqzlffcxmx f = new FrmYqzlffcxmx();
                f.Prepare(row);
                f.ShowDialog();
            }

        }

        private void BtnSure_Click(object sender, EventArgs e)
        {
            string where = " where zt=20";
            VyqzlcxTableAdapter1.FillByWhere(DSYQZLCX1.VYQZLCX, where);
            PriErrorLst = new List<string>();
            PriWinLst = new List<string>();
            PriClLst = new List<string>();
            foreach (DSYQZLCX.VYQZLCXRow row in DSYQZLCX1.VYQZLCX)
            {
                using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
                {
                    conn.Open();
                    SqlTransaction Trans = conn.BeginTransaction();
                    SqlCommand comm = new SqlCommand();
                    try
                    {
                        comm.Connection = conn;
                        comm.Transaction = Trans;
                        string[] strNameCX = new string[] { "RETURN_CODE", "F_STATUS", "F_MSG", "SUCCESS_AMOUNT", "SUCCESS_NUM", "FAIL_AMOUNT", "FAIL_NUM" };
                        Xml_CXValues = new string[] { GetXlh("F").ToString(), PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W2104", "CN", row.xlh.ToString(), "" };
                        string Str6w2104 = ClsSockets.sendStr(Xml_CXValues, "6W2104.xml");
                        List<string> LisCXValues = new List<string>(ClsGetXML.GetListStr(strNameCX, Str6w2104));
                        if (LisCXValues.Count > 0)
                        {
                            if (LisCXValues[0].ToString() == "000000")
                            {
                                PriWinLst.Add(row.xlh.ToString());
                                if (LisCXValues[1].ToString() == "0")
                                {
                                    //所有的都失败
                                    comm.CommandText = string.Format("UPDATE dbo.tfmsdskckffmx SET zt=0 WHERE pcid={0} and zt=20;Update  tfmsdskckffpc set zt=30,je=0 where id={0} and zt = 20;update tfmsdskckfflog set zt=30 where id={1} and zt=20;UPDATE dbo.Tfmsdskckffmxlog SET zt=20 WHERE pcid={1}", row.ffpcid, row.id);
                                }
                                else if (LisCXValues[1].ToString() == "1")
                                {
                                    double n;
                                    double m = 0;
                                    if (double.TryParse(LisCXValues[3].ToString(), out n))
                                        m = Convert.ToDouble(LisCXValues[3].ToString());
                                    if (Convert.ToDouble(LisCXValues[4]) == row.bs)//全部成功
                                    {
                                        comm.CommandText = " update  tfmsdskckffpc set zt=10 ,je=" + m + " where id=" + row.ffpcid;
                                        comm.CommandText += string.Format("UPDATE dbo.tfmsdskckffmx SET zt=10 WHERE pcid={0} and zt=20;update tfmsdskckfflog set zt=10 where id={1} and zt=20;UPDATE dbo.Tfmsdskckffmxlog SET zt=10 WHERE pcid={1}", row.ffpcid, row.id);

                                    }
                                    else if (Convert.ToDouble(LisCXValues[6]) == row.bs)//全部失败
                                    {
                                        comm.CommandText = string.Format("UPDATE dbo.tfmsdskckffmx SET zt=0 WHERE pcid={0} and zt=20;Update  tfmsdskckffpc set zt=30,je=0 where id={0} and zt = 20;update tfmsdskckfflog set zt=30 where id={1} and zt=20;UPDATE dbo.Tfmsdskckffmxlog SET zt=20 WHERE pcid={1}", row.ffpcid, row.id);
                                    }
                                    else //处理成功(其中成功/失败)
                                    {
                                        comm.CommandText = string.Format("UPDATE dbo.tfmsdskckffmx SET zt=10 WHERE pcid={0} and zt=20;Update  tfmsdskckffpc set zt=10,je={1} where id={0} and zt = 20;update tfmsdskckfflog set zt=10 where id={2} and zt=20;", row.ffpcid, m, row.id);
                                        VfmsYQZLDSKFFMxTableAdapter1.FillById(DSYQZLCX1.VfmsYQZLDSKFFMx, row.ffpcid);
                                        Xml_CXYCValues = new string[] { "OID", "RECV_ACCNO", "RECV_ACCNAME", "AMOUNT", "REMARK" };
                                        GetBfYcmx(DSYQZLCX1.VfmsYQZLDSKFFMx, Str6w2104);
                                        comm.CommandText += " insert into Tfmsdskffyc(mxid,dskid,ycxx,je,zt,inssj,insczyzh,insczyxm,insczyid,fflx) values " + PriYcInset;//插入异常信息
                                        comm.CommandText += string.Format(" UPDATE tfmsdskckffmxlog SET zt=20 WHERE zt=0 and pcid={0} AND dskid IN ({1});UPDATE tfmsdskckffmxlog SET zt=10 WHERE pcid={0} AND zt=0", row.id, PrimxLog);//修改明细日志
                                    }
                                }
                                else if (LisCXValues[1].ToString() == "2" || LisCXValues[1].ToString() == "3")
                                    PriClLst.Add(row.xlh.ToString());
                                comm.ExecuteNonQuery();
                                Trans.Commit();
                            }
                            else
                            {
                                PriErrorLst.Add(row.xlh.ToString());
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Trans.Rollback();
                        ClsMsgBox.Cw("遇到错误！", ex, ObjG.CustomMsgBox, this);
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                        comm.Dispose();
                    }
                }

            }
            ClsMsgBox.Ts("查询完成，成功：" + PriWinLst.Count.ToString() + "条，处理中：" + PriClLst.Count.ToString() + "条，未查询到结果：" + PriErrorLst.Count.ToString() + "条", ObjG.CustomMsgBox, this);
            VyqzlcxTableAdapter1.FillByWhere(DSYQZLCX1.VYQZLCX, where);
        }
    }
}