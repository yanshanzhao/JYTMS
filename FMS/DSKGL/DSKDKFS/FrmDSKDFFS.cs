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
using JYPubFiles.Classes;
using System.Data.SqlClient;
using System.IO;
using FMS.DSKGL.DSKCKFF.YQZLDSKFF;
#endregion

namespace FMS.DSKGL.DSKDKFS
{
    public partial class FrmDSKDFFS : UserControl
    {
        #region 成员变量

        private string PriWhere;
        private List<int> LstPcid = new List<int>();
        private ClsG ObjG;
        #endregion
        public FrmDSKDFFS()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            //DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable(" select id,jc from tyhlx where  hdzt='Y' and id in(63,64,241)  ", ClsGlobals.CntStrTMS);
            //ClsPopulateCmbDsS.PopuByTb(this.CmbYhlx, dtYhlx, "id", "jc");
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable("select bh,mc from Tfmsdskffyhlx where zt=1  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbYhlx, dtYhlx, "bh", "mc");
            CmbYhlx.SelectedIndex = 0;
            CmbDKFS.SelectedIndex = 2;
            this.VfmsdskdffsTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PriWhere = " where  ffyhlx='" + CmbYhlx.SelectedValue + "'";
            if (DtpFfStart.Checked && !DtpFfStop.Checked)
                PriWhere += " and ffsj >='"+DtpFfStart.Value+"' and ffsj<'"+DateTime.Now+"'";
            else if (DtpFfStart.Checked && DtpFfStop.Checked)
                PriWhere += " and ffsj >='" + DtpFfStart.Value + "' and ffsj<'" + DtpFfStop.Value.AddDays(1) + "'";
            //PriWhere += " and yhlx='" + CmbYhlx.Text + "'";
         
            if (CmbDKFS.SelectedIndex == 0)
                PriWhere += " and fflx=0 ";
            else if (CmbDKFS.SelectedIndex == 1)
                PriWhere += " and fflx=10 ";
            this.VfmsdskdffsTableAdapter1.FillByWhere(DSDSKDKFS1.Vfmsdskdffs, PriWhere);
            if (Dgv.RowCount == 0)
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
        }
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtId.Name].Value);
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvColTxtqx.Name].Value))//取消
                {
                    Dgv.Rows[e.RowIndex].Cells[DgvColTxtqx.Name].Value = false;
                    LstPcid.Remove(aId);
                }
                else
                {
                    Dgv.Rows[e.RowIndex].Cells[DgvColTxtqx.Name].Value = true;
                    LstPcid.Add(aId);
                }
            }
            if (e.ColumnIndex == 8)
            {
                int n;
                int aid = 0;
                if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtId.Name].Value.ToString(), out n))
                {
                    aid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtId.Name].Value);
                } 
                if (aid == 0)
                {
                    ClsMsgBox.Ts("出现异常！", ObjG.CustomMsgBox, this);
                    return;
                }
                string aSumje = Dgv.Rows[e.RowIndex].Cells[DgvColTxtzje.Name].Value.ToString();
                string aSxf = Dgv.Rows[e.RowIndex].Cells[DgvColTxtsxf.Name].Value.ToString();
                string aSfje = Dgv.Rows[e.RowIndex].Cells[DgvColTxtffje.Name].Value.ToString();
                string aCun = Dgv.Rows[e.RowIndex].Cells[DgvColTxtbs.Name].Value.ToString();
                FrmYQZLDSKFFMX f = new FrmYQZLDSKFFMX();
                f.ShowDialog();
                f.Prepare(aid, aSumje, aSxf, aSfje, aCun);
            }

        }

        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 1, 2, 3, 4 };
            ClsExcel.CreatExcel(Dgv, "系统发放发放", this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, "代收款银企直联发放", this.ctrlDownLoad1);
        }
        #endregion
        private void BtnWY_Click(object sender, EventArgs e)
        {
            if (LstPcid.Count == 0)
                return;
            GetZtUpd("0");
        }
        private void BtnYQZL_Click(object sender, EventArgs e)
        {
            if (LstPcid.Count == 0)
                return;
            GetZtUpd("10");
        }
        #region 修改发放状态 0：网银 10：银企直连
        private void GetZtUpd(string azt)
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
                    int influenceSum = 0;
                    string cmdText = " SET NOCOUNT OFF update tfmsdskckffpc  set fflx='" + azt + "' where id in(" + string.Join(",", LstPcid) + ") and zt=0  ";
                    comm.CommandText = cmdText;
                    influenceSum = comm.ExecuteNonQuery();
                    if (influenceSum == LstPcid.Count)
                    {
                        //提交事物 
                        trans.Commit();
                        ClsMsgBox.Ts("保存成功！", ObjG.CustomMsgBox, this);
                        foreach (int  RowsId in LstPcid)
                        {
                            Bds.RemoveAt(Bds.Find("id", RowsId));
                        }
                        LstPcid.Clear();
                        //this.VfmsdskdffsTableAdapter1.FillByWhere(DSDSKDKFS1.Vfmsdskdffs, PriWhere);
                        
                    }
                    else
                    {
                        //回滚事物
                        ClsMsgBox.Ts("保存成功！", ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    //回滚事物
                    try
                    {
                        ClsMsgBox.Cw("保存成功！", ex, ObjG.CustomMsgBox, this);
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
        #endregion

        #region 全选
        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            bool aChecked = Chk.Checked;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                int aId = Convert.ToInt32(row.Cells[DgvColTxtId.Name].Value);
                if (!aChecked)//取消全选
                {
                    if (LstPcid.Count == 0)
                        return;
                    if (Convert.ToBoolean(row.Cells[DgvColTxtqx.Name].Value))//取消
                    {
                        row.Cells[DgvColTxtqx.Name].Value = false;
                        LstPcid.Remove(aId);
                    }
                }
                else
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColTxtqx.Name].Value))//选中
                    {
                        row.Cells[DgvColTxtqx.Name].Value = true;
                        LstPcid.Add(aId);
                    }
                } 
            }
        }
        #endregion

    }
}
