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
using JYPubFiles.Classes;
#endregion

namespace FMS.JSGL.KHJS
{
    public partial class FrmKHJSDel : Form
    {
        #region 成员变量
        private int PriPcId = 0;
        private int PriCnts = 0;
        private ClsG ObjG;
        public string PubZt = "N";
        #endregion
        public FrmKHJSDel()
        {
            InitializeComponent();
        }
        public void Prepare(int aId)
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            DataRow dr = ClsRWMSSQLDb.GetDataRow(" select dzdh,Y,M,zdjgmc,ywqy,khmc,ST,et,je,zdjg,insczyxm,jyje,bz,cnt,inssj from Vfmskhjspc where id=" + aId, ClsGlobals.CntStrTMS);
            lblZddh.Text = dr[0].ToString();
            LblNd.Text = dr[1].ToString();
            LblYd.Text = dr[2].ToString();
            LblDzjg.Text = dr[3].ToString();
            LblYwqy.Text = dr[4].ToString();
            LblKhmc.Text = dr[5].ToString();
            LblDzqssj.Text = Convert.ToDateTime(dr[6].ToString()).ToString("yyyy-mm-dd"); ;
            LblDzjssj.Text = Convert.ToDateTime(dr[7].ToString()).ToString("yyyy-mm-dd");
            LblDzje.Text = dr[8].ToString();
            LblZdjg.Text = dr[9].ToString();
            LblZdr.Text = dr[10].ToString();
            LblYJje.Text = dr[11].ToString();
            LblBzxx.Text = dr[12].ToString();
            LblZsj.Text = Convert.ToDateTime(dr[14].ToString()).ToString("yyyy-mm-dd");
            PriPcId = aId;
            int n;
            if (Int32.TryParse(dr[13].ToString(), out n))
                PriCnts = Convert.ToInt32(dr[13].ToString());
            this.VfmskhjsmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            VfmskhjsmxTableAdapter1.FillByWhere(DSKHJS1.Vfmskhjsmx, " where pcid=" + PriPcId);
        }
        private void BtnAnd_Click(object sender, EventArgs e)
        {
            ClsMsgBox.YesNo("是否删除该客户结算信息！", new EventHandler(DelYh), ObjG.CustomMsgBox, this);
        }
        private void DelYh(object sender, EventArgs e)
        {
            FrmMsgBox c = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {
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
                        string cmdText = " SET NOCOUNT OFF  update tfmsybf set zt=0 where  zt=10 and   id in( select ybfid from tfmskhjsmx where pcid=" + PriPcId + ")";
                        comm.CommandText = cmdText;
                        int influenceSum = comm.ExecuteNonQuery();
                        cmdText = " SET NOCOUNT OFF delete tfmskhjsmx where pcid=" + PriPcId;
                        comm.CommandText = cmdText;
                        influenceSum = influenceSum + comm.ExecuteNonQuery();
                        cmdText = " SET NOCOUNT OFF delete tfmskhjspc where id=" + PriPcId;
                        comm.CommandText = cmdText;
                        influenceSum = influenceSum + comm.ExecuteNonQuery();
                        if (influenceSum == 2 * Dgv.RowCount + 1)
                        {
                            //提交事物 
                            trans.Commit();
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            ClsMsgBox.Ts("删除成功！", c, this);
                        }
                        else
                        {
                            //回滚事物
                            ClsMsgBox.Ts("删除失败！", c, this);
                            trans.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        //回滚事物
                        try
                        {
                            ClsMsgBox.Cw("删除异常！", ex, c, this);
                            trans.Rollback();
                        }
                        catch (SqlException ex1)
                        {
                            if (trans.Connection != null)
                                ClsMsgBox.Cw("回滚失败! 异常类型:" + ex1.GetType(), ex1, c, this);
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 6 };
            ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1);
        }
    }
}