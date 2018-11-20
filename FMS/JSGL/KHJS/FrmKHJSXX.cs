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
using System.Collections;
using System.Data.SqlClient;
#endregion

namespace FMS.JSGL.KHJS
{
    public partial class FrmKHJSXX : Form
    {
        #region 成员变量
        private ClsG ObjG;
        //private EnumNEDD PubEnumNEDD;
        private int PriNd = 0;
        private int PriYf = 0;
        private int PriPcId = 0;
        private string PriInsStr = "";
        private int PriNewCnts = 0;
        //private int PriPcCnts = 0;
        private decimal PriSumJe = 0;
        private List<string> PriList = new List<string>();
        private string PriKhid = "0";
        private string PriJsjgId = "0";
        private List<int> PriListYdid = new List<int>();//选择修改的运单信息
        private List<int> PriListOldYdid = new List<int>();//需要将运单的状态改为初始化状态
        private List<string> PriLstmx = new List<string>();//插入的明细
        #endregion
        public FrmKHJSXX()
        {
            InitializeComponent();
        }
        public void Prepare(string aYwqy, string aKhmc, string aDzqssj, string aDzjsjs, decimal aDzje, List<int> aybfid, string akhid, string ajsjgid)
        {
            this.lblZddh.Visible = false;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            this.LblYwqy.Text = aYwqy;
            this.LblKhmc.Text = aKhmc;
            this.LblDzqssj.Text = aDzqssj;
            this.LblDzje.Text = aDzje.ToString();
            this.LblDzjg.Text = ObjG.Jigou.mc;
            this.LblZdjg.Text = ObjG.Jigou.mc;
            this.LblZdr.Text = ObjG.Renyuan.xm;
            this.LblZsj.Text = DateTime.Now.ToString("yyyy-MM-dd");
            LblDzqssj.Text = aDzqssj;
            LblDzjssj.Text = aDzjsjs;
            PriKhid = akhid;
            PriJsjgId = ajsjgid;
            PriSumJe = aDzje;
            this.VfmsyfzjTableAdapter.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            VfmsyfzjTableAdapter.FillByWhere(DSKHJS1.Vfmsyfzj, " where id in(" + string.Join(",", aybfid) + ")");
            if (PriSumJe != this.DSKHJS1.Vfmsyfzj.AsEnumerable().Sum(rw => rw.Field<Decimal>("je")))
                PriSumJe =this.DSKHJS1.Vfmsyfzj.AsEnumerable().Sum(rw => rw.Field<Decimal>("je"));
        }
        public void Prepare(int aPcId, decimal aJe, List<int> aListYfid, List<int> aListOldYfid)
        {
            PriPcId = aPcId;
            PriListYdid = aListYfid;
            PriListOldYdid = aListOldYfid;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            DataRow dr = ClsRWMSSQLDb.GetDataRow("   select dzdh,zdjgmc,ywqy,khmc,st,et,y,m,bz from Vfmskhjspc where id=" + PriPcId, ClsGlobals.CntStrTMS);
            this.lblZddh.Text = dr[0].ToString();
            this.LblDzjg.Text = dr[1].ToString();
            this.LblYwqy.Text = dr[2].ToString();
            this.LblKhmc.Text = dr[3].ToString();
            this.LblDzqssj.Text = Convert.ToDateTime(dr[4].ToString()).ToString("yyyy-mm-dd");
            this.LblDzjssj.Text = Convert.ToDateTime(dr[5].ToString()).ToString("yyyy-mm-dd");
            this.TxtDZND.Text = dr[6].ToString();
            this.TxttYf.Text = dr[7].ToString();
            this.TxtBzxx.Text = dr[8].ToString();
            this.LblDzje.Text = aJe.ToString();
            this.LblZdjg.Text = ObjG.Jigou.mc;
            this.LblZdr.Text = ObjG.Renyuan.xm;
            this.LblZsj.Text = DateTime.Now.ToString("yyyy-mm-dd");
            this.VfmsyfzjTableAdapter.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            VfmsyfzjTableAdapter.FillByWhere(DSKHJS1.Vfmsyfzj, " where id in(" + string.Join(",", aListYfid) + ")");
        }
        private void BtnAnd_Click(object sender, EventArgs e)
        {
            if (this.TxtDZND.Text.Trim().Length == 0)
            {
                ClsMsgBox.Ts("输入的对账单年度！", ObjG.CustomMsgBox, this);
                TxtDZND.Focus();
                return;
            }
            if (this.TxttYf.Text.Trim().Length == 0)
            {
                ClsMsgBox.Ts("输入的对账单月份！", ObjG.CustomMsgBox, this);
                TxttYf.Focus();
                return;
            }
            int n;
            if (!Int32.TryParse(this.TxtDZND.Text, out n))
            {
                ClsMsgBox.Ts("输入的对账单年度格式错误！", ObjG.CustomMsgBox, this);
                TxtDZND.Text = "";
                TxtDZND.Focus();
                return;
            }
            else
            {
                int aNd = Convert.ToInt32(TxtDZND.Text);
                if (!(aNd > 1990 && aNd < 2100))
                {
                    ClsMsgBox.Ts("输入的对账单年度不合理,请重新输入", ObjG.CustomMsgBox, this);
                    TxtDZND.Text = "";
                    TxtDZND.Focus();
                    return;
                }
                else
                    PriNd = aNd;
            }
            if (!Int32.TryParse(this.TxttYf.Text, out n))
            {
                ClsMsgBox.Ts("输入的对账单月份格式错误！", ObjG.CustomMsgBox, this);
                TxttYf.Text = "";
                TxttYf.Focus();
                return;
            }
            else
            {
                int aYf = Convert.ToInt32(TxttYf.Text);
                if (!(aYf > 0 && aYf <= 12))
                {
                    ClsMsgBox.Ts("输入的对账单月份不合理,请重新输入！", ObjG.CustomMsgBox, this);
                    TxttYf.Text = "";
                    TxttYf.Focus();
                    return;
                }
                else
                    PriYf = aYf;
            }
            //获取选中的信息
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand();
                try
                {
                    comm.Connection = conn;
                    comm.Transaction = trans;
                    string cmdText = "";
                    string ywlx = "";

                    if (LblYwqy.Text == "零担")
                        ywlx = "L";
                    else if (LblYwqy.Text == "整车")
                        ywlx = "Z";
                    else
                        ywlx = "Q";
                    int influenceSum = 0;

                    if (PriPcId == 0)
                    {
                        ArrayList als = new ArrayList();
                        als.Add(new SqlParameter("@tbln", "tfmskhjspc"));
                        als.Add(new SqlParameter("@currq", DateTime.Now.Date));
                        als.Add(new SqlParameter("@return", SqlDbType.Int));
                        ((SqlParameter)als[2]).Direction = ParameterDirection.ReturnValue;
                        ClsRWMSSQLDb.ExecuteCmd("PGetLsh", ClsGlobals.CntStrTMS, als, true);
                        string lsh = ((SqlParameter)als[2]).Value.ToString().PadLeft(4, '0');
                        if (lsh.Equals("0000"))
                        {
                            //回滚事物
                            ClsMsgBox.Ts("获取生成流水号错误失败！", ObjG.CustomMsgBox, this);
                            trans.Rollback();
                        }

                        string adzdh = "TS" + DateTime.Now.ToString("yyyyMMdd") + lsh + ObjG.Jigou.id;
                        ArrayList list = new ArrayList();
                        list.Add(new SqlParameter("@dzdh", adzdh));
                        list.Add(new SqlParameter("@khid", PriKhid));
                        list.Add(new SqlParameter("@jgid", PriJsjgId));
                        list.Add(new SqlParameter("@y", PriNd));
                        list.Add(new SqlParameter("@m", PriYf));
                        list.Add(new SqlParameter("@st", LblDzqssj.Text));
                        list.Add(new SqlParameter("@et", LblDzjssj.Text));
                        list.Add(new SqlParameter("@ywqy", ywlx));
                        list.Add(new SqlParameter("@je", PriSumJe));
                        list.Add(new SqlParameter("@zt", '0'));
                        list.Add(new SqlParameter("@bz", TxtBzxx.Text.Trim().ToString()));
                        list.Add(new SqlParameter("@cnt", Dgv.RowCount));
                        list.Add(new SqlParameter("@insczyid", ObjG.Renyuan.id));
                        list.Add(new SqlParameter("@insczyxm", LblZdr.Text));
                        list.Add(new SqlParameter("@inssj", DateTime.Now));
                        list.Add(new SqlParameter("@ret_p", SqlDbType.Int));
                        ((SqlParameter)list[15]).Direction = ParameterDirection.Output;
                        ClsRWMSSQLDb.ExecuteCmd("Pfmskhjs", ClsGlobals.CntStrTMS, list, true);
                        PriPcId = Convert.ToInt32(((SqlParameter)list[15]).Value);
                        GetMx();
                        cmdText = " SET NOCOUNT OFF";
                        foreach (string Ins in PriLstmx)
                        {
                            cmdText += " insert into tfmskhjsmx(pcid,ydid,ybfid,fymc,je)values" + Ins;
                        }
                        comm.CommandText = cmdText;
                        influenceSum = comm.ExecuteNonQuery();
                        cmdText = " SET NOCOUNT OFF update tfmsybf set zt='10' where id in(" + string.Join(",", PriList) + ") and zt=0 ";
                        comm.CommandText = cmdText;
                        influenceSum = influenceSum + comm.ExecuteNonQuery();
                        if (influenceSum == 2 * Dgv.RowCount)
                        {
                            //提交事物
                            this.DialogResult = DialogResult.OK;
                            trans.Commit();
                            this.Close();
                            ClsMsgBox.Ts("保存成功！结算单号：" + adzdh + "总共结算" + PriSumJe + "元", ObjG.CustomMsgBox, this);
                        }
                        else
                        {
                            //回滚事物
                            ClsMsgBox.Ts("新增失败！", ObjG.CustomMsgBox, this);
                            trans.Rollback();
                        }
                    }
                    else
                    {

                        if (PriListOldYdid.Count == 0)
                        {
                            cmdText = " SET NOCOUNT OFF update tfmskhjspc set insczyid=" + ObjG.Renyuan.id + ",insczyxm='" + ObjG.Renyuan.xm + "',inssj='" + DateTime.Now.ToString() + "',y=" + PriNd + ",m=" + PriYf + ",bz='" + this.TxtBzxx.Text.Trim().ToString() + "' from tfmskhjspc where zt=0 and id=" + PriPcId;

                            comm.CommandText = cmdText;
                            influenceSum = comm.ExecuteNonQuery();
                            if (influenceSum == 1)
                            {
                                //提交事物

                                this.DialogResult = DialogResult.OK;
                                trans.Commit();
                                this.Close();
                                ClsMsgBox.Ts("修改结算单号：" + lblZddh.Text + "成功！总共结算" + PriSumJe + "元", ObjG.CustomMsgBox, this);
                            }
                            else
                            {
                                //回滚事物
                                ClsMsgBox.Ts("修改结算单号：" + lblZddh.Text + "失败！", ObjG.CustomMsgBox, this);
                                trans.Rollback();
                            }
                        }
                        else
                        {
                            cmdText = " SET NOCOUNT OFF update tfmskhjspc set insczyid=" + ObjG.Renyuan.id + ",insczyxm='" + ObjG.Renyuan.xm + "',inssj='" + DateTime.Now.ToString() + "',y=" + PriNd + ",m=" + PriYf + ",bz='" + this.TxtBzxx.Text.Trim().ToString() + "',je=" + this.LblDzje.Text + ",cnt=" + PriListYdid.Count + "  where zt=0 and id=" + PriPcId;
                            comm.CommandText = cmdText;
                            influenceSum = comm.ExecuteNonQuery();
                            cmdText = " SET NOCOUNT OFF delete tfmskhjsmx where pcid=" + PriPcId + " and ybfid in(" + string.Join(",", PriListOldYdid) + ")";
                            comm.CommandText = cmdText;
                            influenceSum = influenceSum + comm.ExecuteNonQuery();
                            cmdText = " SET NOCOUNT OFF  update   Tfmsybf set zt='0' where id in(" + string.Join(",", PriListOldYdid) + ") and zt=10 ";
                            comm.CommandText = cmdText;
                            influenceSum = influenceSum + comm.ExecuteNonQuery();
                            if (influenceSum == 1 + PriListOldYdid.Count * 2)
                            {
                                //提交事物 
                                this.DialogResult = DialogResult.OK;
                                trans.Commit();
                                this.Close();
                                ClsMsgBox.Ts("修改结算单号：" + lblZddh.Text + "成功！总共结算" + PriSumJe + "元", ObjG.CustomMsgBox, this);
                            }
                            else
                            {
                                //回滚事物
                                ClsMsgBox.Ts("修改结算单号：" + lblZddh.Text + "失败！", ObjG.CustomMsgBox, this);
                                trans.Rollback();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //回滚事物
                    try
                    {
                        ClsMsgBox.Cw("新增异常！", ex, ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                    catch (SqlException ex1)
                    {
                        if (trans.Connection != null)
                            ClsMsgBox.Cw("回滚失败! 异常类型:" + ex1.GetType(), ex1, ObjG.CustomMsgBox, this);
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GetMx()
        {
            int i = 1;
            foreach (DataGridViewRow Row in Dgv.Rows)
            {
                //for (int i = 0; i < 1000; i++)
                //    {

                //    }
                string aybfid = Row.Cells[DgvColTxtydid.Name].Value.ToString();
                string aydid = Row.Cells[DgvColTxtId.Name].Value.ToString();
                string ayfmc = Row.Cells[DgvColTxtfymc.Name].Value.ToString();
                decimal n;
                decimal aje = 0;
                if (decimal.TryParse(Row.Cells[DgvColTxtje.Name].Value.ToString(), out n))
                {
                    aje = Convert.ToDecimal(Row.Cells[DgvColTxtje.Name].Value.ToString());
                }
                if (PriInsStr.Length == 0)
                    PriInsStr = "(" + PriPcId + "," + aybfid + "," + aydid + ",'" + ayfmc + "'," + aje + ")";
                else
                    PriInsStr = PriInsStr + "," + "(" + PriPcId + "," + aybfid + "," + aydid + ",'" + ayfmc + "'," + aje + ")";
                i++;
                //PriLstmx.Add(PriInsStr);
                PriList.Add(aydid);
                PriNewCnts++;
                if (i == 1000)
                {
                    PriLstmx.Add(PriInsStr);
                    PriInsStr = "";
                    i = 1;
                }

                //PriSumJe += aje;
            }
            if (PriInsStr.Length > 0)
                PriLstmx.Add(PriInsStr);
        }
    }
}