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

#endregion

namespace FMS.CWGL.ZZHQRJKD.TZFGBFJKRB
{
    public partial class FrmTZFGBFBC : Form
    {
        private ClsG ObjG;
        private int pcid;
        private string sqlStr = "";
        private List<int> PriId;
        private List<string> PriInfo;
        private List<ClsXtsr> PriClsXtwsr;
        private DataTable PriDtJsgx;
        public FrmTZFGBFBC()
        {
            InitializeComponent();
        }

        public void Prepare(List<int> lst, List<ClsXtsr> lstCls, List<string> list)
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriId = lst;
            PriInfo = list;
            PriClsXtwsr = lstCls;
            TxtLsh.Text = PriInfo[3];
            TxtJe.Text = PriInfo[0];
            TxtSpjg.Text = "零担运输事业部";
            TxtSpjg.Tag = 3;
            TxtBz.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtLsh.Text))
            {
                ClsMsgBox.Ts("流水号不能为空！", ObjG.CustomMsgBox, this);
                return;
            }
            if (string.IsNullOrEmpty(TxtJe.Text))
            {
                ClsMsgBox.Ts("挂账金额不能为空！", ObjG.CustomMsgBox, this);
                return;
            }
            //if (!ClsRegEx.IsJe(TxtJe.Text.Trim()))
            //{
            //    ClsMsgBox.Ts("挂账金额格式不正确！", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //if (string.IsNullOrEmpty(TxtBz.Text))
            //{
            //    ClsMsgBox.Ts("备注不能为空！", ObjG.CustomMsgBox, this);
            //    return;
            //}
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    cmd.Transaction = trans;
                    try
                    {
                        sqlStr = string.Format("INSERT INTO dbo.tfmsxtwsrpc(lsh,lxid,je,bz,zzjgid,sqrid,sqrzh ,sqr,inssj,spjgid) VALUES('{0}',{1},{2},'{3}',{4},{5},'{6}','{7}','{8}',{9})", TxtLsh.Text, PriInfo[2], TxtJe.Text, TxtBz.Text.Trim(), ObjG.Jigou.id, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriInfo[1], 3);
                        sqlStr += "SELECT SCOPE_IDENTITY()";
                        cmd.CommandText = sqlStr;
                        pcid = Convert.ToInt32(cmd.ExecuteScalar());
                        foreach (ClsXtsr item in PriClsXtwsr)
                        {
                            if (item.Ydtzid == 0)
                                sqlStr = string.Format("INSERT INTO dbo.tfmsxtwsrmx(pcid,srid,khid,bh,je)VALUES({0},{1},{2},'{3}',{4})", pcid, item.srid, item.Khid, item.Bh, item.Je);
                            else if (item.Khid == 0)
                                sqlStr = string.Format("INSERT INTO dbo.tfmsxtwsrmx(pcid,srid,ydtzid,bh,je)VALUES({0},{1},{2},'{3}',{4})", pcid, item.srid, item.Ydtzid, item.Bh, item.Je);
                            cmd.CommandText = sqlStr;
                            cmd.ExecuteNonQuery();
                        }
                        sqlStr = " UPDATE tfmsxtsr SET zt=10 WHERE id in(" + string.Join(",", PriId) + ")";
                        cmd.CommandText = sqlStr;
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                        ClsMsgBox.Ts("缴款成功！", ObjG.CustomMsgBox, this);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        ClsMsgBox.Cw("缴款失败！原因是：", ex, ObjG.CustomMsgBox, this);
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
        }

        private void BtnQuXiao_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
