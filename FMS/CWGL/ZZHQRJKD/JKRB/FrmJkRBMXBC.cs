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
using JYPubFiles.Classes;

#endregion

namespace FMS.CWGL.ZZHQRJKD.JKRB
{
    public partial class FrmJkRBMXBC : Form
    {
        #region 成员变量
        private ClsG ObjG;
        private DataTable PriDtJsgx;
        private string CmdText;
        private List<int> LstYbfid = new List<int>();
        private List<int> LstRbpcid = new List<int>();
        private List<string> LstSql = new List<string>();
        private List<int> LstJsdid = new List<int>();
        private decimal PriYck = 0;
        private string PriRbdh;//运单明细的日报单号
        private string PriRbdh1;//批次日报的日报单号
        private string PriSpjgid;//审批机构ID
        private string PriYwqy;//选择的业务区域
        private string PriRbpcid;//日报批次ID
        private decimal PriYckje;
        private decimal PriXjjgjk;//下级机构缴款
        private bool PriFlag;
        private string PriLx;
        private DSJKRB.Vfmsjkrb2DataTable PriYdTable;//获取上个页面选中的数据
        private int PriUpdRows;
        private DataTable PriDtRbpc;//记录下级缴款批次（Group by之前的）
        #endregion
        public FrmJkRBMXBC()
        {
            InitializeComponent();
        }
        #region 初始化数据
        public void Prepare(string aYwqys, string aYck, string aYwqy, string aLx, DSJKRB.Vfmsjkrb2DataTable aYdTable)
        {
            ObjG = (ClsG)Session["ObjG"];
            PriLx = aLx;
            BindPc();
            if (Dgv.Rows.Count != 0)
                ForeachRbpc();
            LblBjgjk.Text = aYck.ToString();
            LblSjyc.Text = (Convert.ToDecimal(aYck) + PriXjjgjk).ToString();
            LblYwqy.Text = aYwqys;
            PriYwqy = aYwqy;
            PriYdTable = aYdTable;
            if (PriYdTable.Count > 0)
                PriYck = Convert.ToDecimal(aYck);

            PriDtJsgx = ClsRWMSSQLDb.GetDataTable(" select tojgid,tojgmc from vfmsjggx where gxzl='J' and jgid=" + ObjG.Jigou.id, ClsGlobals.CntStrTMS);
            if (PriDtJsgx.Rows.Count == 1)
            {
                LblSkjg.Text = PriDtJsgx.Rows[0]["tojgmc"].ToString();
                PriSpjgid = PriDtJsgx.Rows[0]["tojgid"].ToString();
            }
            DataRow dr = ClsRWMSSQLDb.GetDataRow("  select SUM(ysje) from  Vfmsjkrb2 where jgid=" + ObjG.Jigou.id, ClsGlobals.CntStrTMS);
            decimal aSumwc = 0;
            decimal n;
            if (decimal.TryParse(dr[0].ToString(), out n))
                aSumwc = Convert.ToDecimal(dr[0]);
            this.lblQk.Text = (aSumwc - (Convert.ToDecimal(aYck))).ToString();
        }
        #endregion

        #region 获得下级缴款机构信息和循环下级机构日报批次

        private void BindPc()
        {
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                conn.ConnectionString = ClsGlobals.CntStrTMS;
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "P_Fmsrbpc";
                comm.Parameters.Add(new SqlParameter("@jgid", ObjG.Jigou.id));
                sda.SelectCommand = comm;
                sda.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    Dgv.DataSource = ds.Tables[0];
                    LblXjjk.Text = ds.Tables[0].Compute("sum(jkje)", "").ToString();
                    LblXjjk.Text = string.IsNullOrEmpty(LblXjjk.Text) ? "0" : LblXjjk.Text;
                    PriDtRbpc = ds.Tables[1];
                    //PriDtrbpc1 = ds.Tables[1];
                }
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("查询下级缴款批次信息失败！", ex, ObjG.CustomMsgBox, this);
            }
            finally
            {
                conn.Dispose();
                sda.Dispose();
                ds.Dispose();
            }
        }
        private void ForeachRbpc()
        {
            LstRbpcid.Clear();
            foreach (DataRow row in PriDtRbpc.Rows)
            {
                PriXjjgjk += Convert.ToDecimal(row["jkje"]);
                LstRbpcid.Add(Convert.ToInt32(row["id"]));
            }
            //LblXjjk.Text = PriXjjgjk.ToString();
        }
        #endregion

        #region 保存
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PriSpjgid))
            {
                ClsMsgBox.Ts("该机构无结算关系，请维护！", ObjG.CustomMsgBox, this);
                return;
            }
            if (!ClsRegEx.IsShiShu(TxtZzje.Text.Trim()))
            {
                ClsMsgBox.Ts("坐支金额格式不正确，请重新输入！", this, TxtZzje, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtZzdh.Text.Trim()) && Convert.ToDecimal(TxtZzje.Text.Trim()) > 0)
            {
                ClsMsgBox.Ts("请输入坐支单号！", this, TxtZzdh, ObjG.CustomMsgBox);
                return;
            }
            //if (Convert.ToDecimal(TxtZzje.Text.Trim()) > PriYck)
            //{
            //    ClsMsgBox.Ts("坐支金额不允许大于实际应存，请重新输入！", this, TxtZzje, ObjG.CustomMsgBox);
            //    return;
            //}
            ClsMsgBox.YesNo("确认保存缴款日报吗？", new EventHandler(SaveRb), ObjG.CustomMsgBox, this);
        }

        public void SaveRb(object sender, EventArgs e)
        {
            PriUpdRows = 0;
            PriFlag = true;
            PriRbdh = "Y" + DateTime.Now.ToString("yyyyMMdd") + ObjG.Jigou.id.ToString().PadLeft(4, '0');
            PriRbdh1 = "P" + DateTime.Now.ToString("yyyyMMdd") + ObjG.Jigou.id.ToString().PadLeft(4, '0');
            Form f = sender as Form;
            FrmMsgBox frm = new FrmMsgBox();
            if (f.DialogResult != DialogResult.Yes)
            {
                Clear();
                return;
            }
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsGlobals.CntStrTMS;
                conn.Open();
                SqlTransaction Trans = conn.BeginTransaction();
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.Transaction = Trans;
                    try
                    {
                        if (PriYdTable.Rows.Count != 0 && Dgv.Rows.Count == 0)
                            InsertYdRB(comm, Trans, frm);
                        else if (Dgv.Rows.Count != 0 && PriYdTable.Rows.Count == 0)
                            InsertPcRB(comm, Trans, frm);
                        else if (PriYdTable.Rows.Count != 0 && Dgv.Rows.Count != 0)
                        {
                            InsertYdRB(comm, Trans, frm);
                            InsertPcRB(comm, Trans, frm);
                        }
                        else
                        {
                            ClsMsgBox.Ts("请选择缴款日报！", frm, this);
                            return;
                        }
                        if (PriFlag)
                        {
                            Trans.Commit();
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            ClsMsgBox.Ts("保存日报成功！" + Environment.NewLine + "本机构应存" + LblBjgjk.Text + "元,实存" + LblSjyc.Text + "元", frm, this);
                        }
                        else
                        {
                            Trans.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        Trans.Rollback();
                        ClsMsgBox.Cw("保存日报失败！", ex, frm, this);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
        }
        #endregion

        #region 运单日报
        private void InsertYdRB(SqlCommand comm, SqlTransaction Trans, FrmMsgBox frm)
        {
            CmdText = "";
            CmdText = string.Format("Insert Into Tfmsrbpc (rbdh,jgid,spjgid, ywqy,yck,zzdh,zzje,insczyid,insczyzh,insczyxm,ckbz,dkje,dczt,wydkzt,dkzt)" +
                "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},{11},0,0,0);select SCOPE_IDENTITY() ", PriRbdh, ObjG.Jigou.id, PriSpjgid, PriYwqy,
                PriYck, string.IsNullOrEmpty(TxtZzdh.Text.Trim()) ? "0" : TxtZzdh.Text.Trim(), TxtZzje.Text.Trim(), ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm,
                ChkIsSrzh.Checked ? 1 : 0, PriYck - Convert.ToDecimal(TxtZzje.Text.Trim()));
            comm.CommandText = CmdText;
            PriRbpcid = comm.ExecuteScalar().ToString();
            GetSql(PriRbpcid);
            if (LstSql.Count == 0)
            {
                ClsMsgBox.Ts("请选择日报后在保存！", frm, this);
                PriFlag = false;
                return;
            }
            if (!PriYck.Equals(PriYckje))
            {
                ClsMsgBox.Ts("保存日报失败！", frm, this);
                Clear();
                PriFlag = false;
                return;
            }
            CmdText = string.Join(";", LstSql);
            comm.CommandText = CmdText;
            comm.ExecuteNonQuery();
            CmdText = "";
            if (LstYbfid.Count != 0)
                CmdText = " SET NOCOUNT OFF Update tfmsybf set zt=10 where id in(" + string.Join(",", LstYbfid) + ") and zt=0 ";
            if (LstJsdid.Count != 0)
                CmdText = "SET NOCOUNT OFF Update tfmskhjspc set zt=15 where id in(" + string.Join(",", LstJsdid) + ")  and zt=10 ";
            comm.CommandText = CmdText;
            PriUpdRows = comm.ExecuteNonQuery();
            if (LstSql.Count() != PriUpdRows)
            {
                ClsMsgBox.Ts("保存日报失败！", frm, this);
                Clear();
                PriFlag = false;
                return;
            }
        }
        #endregion

        #region 下级机构日报
        private void InsertPcRB(SqlCommand comm, SqlTransaction Trans, FrmMsgBox frm)
        {
            CmdText = "";
            CmdText = string.Format(" SET NOCOUNT OFF Insert Into Tfmsrbpc (rbdh,jgid,spjgid,ywqy,yck,zzdh,zzje,insczyid,insczyzh,insczyxm,dkje,dczt,wydkzt,dkzt) " +
                "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},0,0,0);select SCOPE_IDENTITY() ", PriRbdh1, ObjG.Jigou.id,PriSpjgid, PriYwqy,
                PriXjjgjk, "0", 0.00, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriXjjgjk);
            comm.CommandText = CmdText;
            PriRbpcid = comm.ExecuteScalar().ToString();
            CmdText = " SET NOCOUNT OFF Update tfmsrbpc set pczt=10,pid=" + PriRbpcid + " where id in(" + string.Join(",", LstRbpcid) + ")  and pczt=0";
            if (Convert.ToDecimal(LblXjjk.Text) != PriXjjgjk) 
            {
                ClsMsgBox.Ts("保存日报失败，下级缴款批次金额不准确！",ObjG.CustomMsgBox,this);
                Trans.Rollback();
                PriFlag = false;
                return;
            }
           comm.CommandText = CmdText;
            PriUpdRows=comm.ExecuteNonQuery();
            if (LstRbpcid.Count() != PriUpdRows)
            {
                ClsMsgBox.Ts("保存日报失败！", frm, this);
                PriFlag = false;
                return;
            }
        }
        #endregion

        #region 组装运单明细SQL语句
        private void GetSql(string aRbpcid)
        {
            LstSql.Clear();
            LstYbfid.Clear();
            LstJsdid.Clear();
            PriYckje = 0;

            foreach (DSJKRB.Vfmsjkrb2Row row in PriYdTable.Rows)
            {

                if (row["lx"].ToString().Equals("0"))
                {
                    LstSql.Add(string.Format("SET NOCOUNT OFF INSERT INTO Tfmsrbmx(rbpcid,jzlx,ydid ,yf,bf,zj,ybfid,lx)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", aRbpcid, row["Jzlx"],
         row["Ydid"], row["yf"], row["bf"], row["ysje"],row["Ybfid"], 'Y'));
                    PriYckje += Convert.ToDecimal(row["ysje"]);
                    LstYbfid.Add(Convert.ToInt32(row["Ybfid"]));
                }
                else if (row["Lx"].ToString().Equals("1"))
                {
                    LstSql.Add(string.Format("SET NOCOUNT OFF INSERT INTO Tfmsrbmx(rbpcid,jzlx ,yf,bf ,zj,khjsid,lx)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", aRbpcid, row["Jzlx"],
              row["yf"], row["bf"], row["ysje"], row["Ybfid"], 'J'));
                    PriYckje += Convert.ToDecimal(row["ysje"]);
                    LstJsdid.Add(Convert.ToInt32(row["Ybfid"]));
                }
            }

        }
        #endregion

        #region Clear()
        private void Clear()
        {
            PriYckje = 0;
            CmdText = "";
        }
        #endregion

        #region 返回按钮
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 坐支金额判断
        private void TxtZzje_LostFocus(object sender, EventArgs e)
        {
            ClsD.TextBoxTrim(this);
            if (!ClsRegEx.IsJe2(TxtZzje.Text))
            {
                ClsMsgBox.Ts("坐支金额格式不正确，请重新输入！", this, TxtZzje, ObjG.CustomMsgBox);
                return;
            }
            //if (Convert.ToDecimal(LblSjyc.Text) < Convert.ToDecimal(TxtZzje.Text))
            //{

            //    ClsMsgBox.Ts("坐支金额不允许大于实际应存，请重新输入！", this, TxtZzje, ObjG.CustomMsgBox);
            //    return;
            //}
            LblSjyc.Text = (Convert.ToDecimal(LblSjyc.Text) - Convert.ToDecimal(TxtZzje.Text)).ToString();
        }
        #endregion

        #region 判断是否存入机构收入账户
        private void ChkIsSrzh_CheckedChanged(object sender, EventArgs e)
        {
            if (PriLx.Equals("Y"))
            {
                ChkIsSrzh.Checked = true;
                ClsMsgBox.Ts("缴款日报为运单明细，资金必须选择存入机构收入账户！", ObjG.CustomMsgBox, this);
                return;
            }
        }
        #endregion

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (Dgv.Columns[e.ColumnIndex].Name == "DgvColLnk")
            {
                Dgv.Visible = false;
                Dgv1.Visible = true;
                Dgv1.DataSource = (from datarow in PriDtRbpc.AsEnumerable() where datarow.Field<int>("jgid") == (Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtJgid.Name].Value)) select datarow).CopyToDataTable();
            }
        }

        private void Dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (Dgv1.Columns[e.ColumnIndex].Name == "DgvColLnk1")
            {
                Dgv.Visible = true;
                Dgv1.Visible = false;
                Dgv1.DataSource = "";
            }
        }
    }
}
