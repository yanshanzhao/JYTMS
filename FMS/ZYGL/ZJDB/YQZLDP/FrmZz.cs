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
using System.Collections;
using System.Data.SqlClient;
using JY.Pri;
#endregion

namespace FMS.ZYGL.ZJDB.YQZLDB
    {
    public partial class FrmZz : Form
        {
        #region 成员变量
        private Dictionary<string, string> PriDic;
        private string PriServerKhhStr;
        private string PriServerPwdStr;
        private string PriServerCZYH;
        //private string PriServerKhhStr = ClsRWDBOptions.GetStr("JY_KHH", ClsGlobals.CntStrKj);//建行客户号
        //private string PriServerPwdStr = ClsRWDBOptions.GetStr("JY_DLMM", ClsGlobals.CntStrKj);//建行密码
        //private string PriServerCZYH = ClsRWDBOptions.GetStr("JY_CZYH", ClsGlobals.CntStrKj);//建行操作员号
        private string PriConStr; //数据库连接字符串
        private ClsG ObjG;
        private DataTable PriDt;
        private char PriIsOk;
        public List<string> list;
        private int PriXlh;
        private string PriZzlx = "";
        private List<int> PriPcid = new List<int>();
        #endregion
        public FrmZz()
            {
            InitializeComponent();
            }
        public void Prepare(string aZzlx)
            {
            PriConStr = ClsGlobals.CntStrTMS;
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            PriDic = new Dictionary<string, string>();
            PriDic = ClsRWDBOptions.GetDic(ClsGlobals.CntStrKj);
            PriServerKhhStr = PriDic["JY_KHH"];
            PriServerPwdStr = PriDic["JY_DLMM"];
            PriServerCZYH = PriDic["JY_CZYH"];
            PriZzlx = aZzlx;
            string ConStr = " Select id,zh,zhmc,yhlxmc,zhlxid,yhlxid,zhlxmc from Vjtyhzh  ";
            PriDt = ClsRWMSSQLDb.GetDataTable(ConStr, PriConStr);
            if (PriZzlx == "R")
                {
                CmbZRZH.Enabled = false;
                DataTable dt = ClsRWMSSQLDb.ExpTable(PriDt, "zhlxid=62");
                //DataRow[] dr = PriDt.Select(" zhlxid=62 ");
                ClsPopulateCmbDsS.PopuByTb(this.CmbZRZH, dt, "id", "zh");
                LblZRZHMC.Text = dt.Rows[0][2].ToString();
                LblZRYHMC.Text = dt.Rows[0][3].ToString();
                Lalzrzhlx.Text = dt.Rows[0][6].ToString();
                CmbZczh();
                }
            else if (PriZzlx == "C")
                {
                CmbZCZH.Enabled = false;
                DataTable dt = ClsRWMSSQLDb.ExpTable(PriDt, "zhlxid=62");
                //DataRow[] dr = PriDt.Select(" zhlxid=62 ");
                ClsPopulateCmbDsS.PopuByTb(this.CmbZCZH, dt, "id", "zh");
                LblZCZHMC.Text = dt.Rows[0][2].ToString();
                LblZCYHMC.Text = dt.Rows[0][3].ToString();
                Lalzczhlx.Text = dt.Rows[0][6].ToString();
                CmbZrzh();
                }

            }

        #region 绑定ComBox
        private void CmbZczh()
            {
            DataTable dt = ClsRWMSSQLDb.ExpTable(PriDt, "yhlxid=63 and zhlxid=53");
            //string ConStr = " Select id,zh,zhmc,yhlxmc,zhlxid  from Vjtyhzh where yhlxid=63 and zhlxid=53";
            //PriDt = ClsRWMSSQLDb.GetDataTable(ConStr, PriConStr);
            //DataRow dr = PriDt.NewRow();
            //dr["id"] = 0;
            //dr["zh"] = "------请选择------";
            //PriDt.Rows.InsertAt(dr, 0);
            ClsPopulateCmbDsS.PopuByTb(this.CmbZCZH, dt, "id", "zh");
            //CmbZCZH.SelectedIndex = 0;

            }
        private void CmbZrzh()
            {
            DataTable dt = ClsRWMSSQLDb.ExpTable(PriDt, "zhlxid=59");
            //string ConStr = " Select id,zh,zhmc,yhlxmc,zhlxid  from Vjtyhzh where zhlxid=59";
            //PriDt = ClsRWMSSQLDb.GetDataTable(ConStr, PriConStr);
            DataRow dr = dt.NewRow();
            dr["id"] = 0;
            dr["zh"] = "------请选择------";
            dt.Rows.InsertAt(dr, 0);
            ClsPopulateCmbDsS.PopuByTb(this.CmbZRZH, dt, "id", "zh");

            }
        #endregion

        private void BtnZZ_Click(object sender, EventArgs e)
            {
            ClsD.TextBoxTrim(this);

            #region 条件验证

            if (Convert.ToInt32(CmbZCZH.SelectedValue) == 0 && PriZzlx == "R")
                {
                ClsMsgBox.Ts("请选择转出帐号！");
                return;
                }
            if (Convert.ToInt32(CmbZRZH.SelectedValue) == 0 && PriZzlx == "C")
                {
                ClsMsgBox.Ts("请选择转人帐号！");
                return;
                }
            if (!ClsRegEx.IsJe(TxtSJZZJE.Text))
                {
                ClsMsgBox.Ts("输入金额格式不正确！", ObjG.CustomMsgBox, TxtSJZZJE);
                return;
                }
            else if (CmbZCZH.Text == CmbZRZH.Text)
                {
                ClsMsgBox.Ts("请选择不同的帐号！");
                return;
                }

            else
                {
                ClsMsgBox.YesNo("确认要转账吗？", new EventHandler(Yhzz));
                }
            #endregion
            }
        #region 银行转账
        private void Yhzz(object sender, EventArgs e)
            {
            Form frm = sender as Form;
            if (frm.DialogResult == DialogResult.Yes)
                {
                SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS);
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                SqlCommand com = new SqlCommand();
                try
                    {
                    com.Connection = conn;
                    com.Transaction = trans;
                    com.CommandText = string.Format("  INSERT INTO Tzzlog(zczhid,zrzhid,zze,sjzze,bz,insczyid,insczyxm ,lx) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') Select SCOPE_IDENTITY() ",
                         CmbZCZH.SelectedValue, CmbZRZH.SelectedValue, TxtZZJE.Text, TxtSJZZJE.Text, Txtbz.Text.Trim(), ObjG.Renyuan.id, ObjG.Renyuan.xm, PriZzlx);
                    int pcid = Convert.ToInt32(com.ExecuteScalar());
                    if (PriPcid.Count > 0)
                        {
                        for (int i = 0; i < PriPcid.Count; i++)
                            {
                            if (i != 0)
                                com.CommandText += " ,(" + pcid + "," + PriPcid[i] + ") ";
                            else
                                com.CommandText = " INSERT INTO Tzzlogmx VALUES(" + pcid + "," + PriPcid[i] + ") ";
                            }
                        com.CommandText += ";update tfmsdskckffpc set zzzt='5' where id in(" + string.Join(",", PriPcid) + ") ";
                        com.ExecuteNonQuery();
                        }
                    trans.Commit();
                    this.Close();
                    ClsMsgBox.Ts("转账成功！", ObjG.CustomMsgBox, this);
                    }
                catch (Exception ex)
                    {
                    trans.Rollback();
                    ClsMsgBox.Cw("遇到错误！", ex);
                    }
                finally
                    {
                    conn.Close();
                    }
                }
            }
        #endregion
        private void BtnCancel_Click(object sender, EventArgs e)
            {
            PriDt.Clear();
            PriDt.Dispose();
            this.Close();
            }
        private void CmbZCZH_SelectedIndexChanged(object sender, EventArgs e)
            {
            //if (CmbZCZH.SelectedIndex <= 0)
            //    return;
            if (!CmbZCZH.Enabled) return;
            DataRow dr = PriDt.NewRow();
            dr = PriDt.Select("zh = '" + CmbZCZH.Text + "'")[0];
            LblZCZHMC.Text = dr["zhmc"].ToString();
            LblZCYHMC.Text = dr["yhlxmc"].ToString();
            Lalzczhlx.Text=dr["zhlxmc"].ToString();
            string sqlText = "insert into Tfmsxlh values('Z',getdate()) Select SCOPE_IDENTITY() ";
            PriXlh = ClsRWMSSQLDb.GetInt(sqlText, PriConStr);
            string[] XmlRecive = { "RETURN_CODE", "RETURN_MSG", "BALANCE", "BALANCE1" };
            string[] Xml6W0100 = { PriXlh.ToString(), PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W0100", "CN", CmbZCZH.Text };
            list = ClsGetXML.GetListStr(XmlRecive, ClsSockets.sendStr(Xml6W0100, "6W0100.xml"));
            if (list.Count > 0)
                {
                if (list[0] != "000000")
                    {
                    ClsMsgBox.Jg(list[1]);
                    LblYE.Text = "0.00";
                    TxtZZJE.Text = "0.00";
                    }
                else
                    {
                    LblYE.Text = list[2];
                    TxtZZJE.Text = list[2];
                    }
                list.Clear();
                }
            else
                {
                //LblYE.Text = "0.00";
                TxtZZJE.Text = "0.00";
                ClsMsgBox.Ts("未成功查询到数据,请确认查询账户是否正确或银企直联功能是否正常!", ObjG.CustomMsgBox, this);
                return;
                }



            }
        private void CmbZRZH_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (CmbZRZH.SelectedIndex <= 0 || !CmbZRZH.Enabled)
                return;

            PriPcid.Clear();
            string sqlText = "";
            if (LblZCYHMC.Text.Contains("中信"))
                sqlText = "   SELECT SUM(dsk-sxf) AS zje,pcid FROM tfmsdskckffmx WHERE pcid IN (  SELECT id  FROM tfmsdskckffpc WHERE yhlxid  NOT  IN( 63,64,241) and zzzt = 0 ) GROUP BY pcid";
            else
                sqlText = "   SELECT SUM(dsk-sxf) AS zje,pcid FROM tfmsdskckffmx WHERE pcid IN (  SELECT id  FROM tfmsdskckffpc WHERE yhlxid IN( select yhlxid from tfmsyhzh where id =" + CmbZRZH.SelectedValue + ") and zzzt = 0) GROUP BY pcid";
            DataTable dt = ClsRWMSSQLDb.GetDataTable(sqlText, PriConStr);
            if (dt.Rows.Count == 0)
                {
                this.TxtZZJE.Text = "0.00";
                }
            else
                {
                    PriPcid = dt.AsEnumerable().Select(r => Convert.ToInt32(r["pcid"])).ToList();
                //foreach (DataRow row in dt.Rows)
                //    {
                //    PriPcid.Add(Convert.ToInt32(row["id"].ToString()));
                //    }
                this.TxtZZJE.Text = dt.AsEnumerable().Sum(r => r.Field<decimal>("zje")).ToString();
                }
            DataRow[] dr = PriDt.Select("zh = '" + CmbZRZH.Text + "'");
            LblZRZHMC.Text = dr[0][2].ToString();
            LblZRYHMC.Text = dr[0][3].ToString();
            Lalzrzhlx.Text = dr[0][6].ToString();
            }
        }
    }