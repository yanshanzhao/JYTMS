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

namespace FMS.DSKGL.ZZYCDSKMX
{
    public partial class FrmZZYCDSKTJ : Form
    {
        #region 成员变量
        private ClsG ObjG;
        private int PriId;
        private string PriLogNama;
        private string PriXm;
        private int PriZhid;
        private string PriConStr;
        private List<int> PriListid = new List<int>();
        private int PriYdCounts = 0;
        private double PriSumJe = 0;
        private int PriRowIndexId = 0;
        private int PriRowIndexCount = 0;
        private FrmMsgBox frm;
        #endregion
        public FrmZZYCDSKTJ()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriId = ObjG.Jigou.id;
            PriLogNama = ObjG.Renyuan.loginName;
            PriXm = ObjG.Renyuan.xm;
            PriZhid = ObjG.Renyuan.id;
            PriConStr = ClsGlobals.CntStrTMS;
            this.Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select id,jgmc,dsk,sxf,zh,zffsmc,cnt,'详细信息' as Xq,'删除'as Del,rbdh,zt,zflxmc from Vfmszzycdsk where jgid=" + PriId, PriConStr);
        }
        #region 鼠标单选
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1)
                return;
            int ColumnIndex = e.ColumnIndex;
            if (ColumnIndex == 0 || ColumnIndex == 8 || ColumnIndex == 9)//详细
            {
                int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtid"].Value);
                int n;
                int aYdCounts = 0;

                if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells["DgvColTxtcounts"].Value.ToString(), out n))
                {
                    aYdCounts = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtcounts"].Value);//有问题
                }
                double m;
                double aRowDsk = 0;
                if (double.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                    aRowDsk = Convert.ToDouble(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                if (ColumnIndex == 0)
                {
                    if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvColTxtxz.Name].Value))//取消选择
                    {
                        Dgv.Rows[e.RowIndex].Cells[DgvColTxtxz.Name].Value = false;
                        PriListid.Remove(aId);
                        PriYdCounts = PriYdCounts - aYdCounts;
                        PriSumJe = PriSumJe - aRowDsk;
                    }
                    else
                    {
                        Dgv.Rows[e.RowIndex].Cells[DgvColTxtxz.Name].Value = true;
                        PriListid.Add(aId);
                        PriYdCounts = PriYdCounts + aYdCounts;
                        PriSumJe = PriSumJe + aRowDsk;
                    }
                    GetXx();
                }
                else if (ColumnIndex == 8)
                {
                    string aRhdh = Dgv.Rows[e.RowIndex].Cells[DgvColTxtrbdh.Name].Value.ToString();
                    string aSkjg = Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgmc.Name].Value.ToString();
                    string aDsk = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString();
                    string aSxf = Dgv.Rows[e.RowIndex].Cells[DgvColTxtsxf.Name].Value.ToString();
                    FrmDSKRBLL f = new FrmDSKRBLL();
                    f.ShowDialog();
                    f.Prepare(aRhdh, aSkjg, aDsk, aSxf, aYdCounts.ToString(), aId);
                }
                else
                {
                    GetRowLing(aId, aYdCounts);
                }

            }
        }
        #endregion
        #region 保存
        private void BtnQery_Click(object sender, EventArgs e)
        {
            //sjdskzt(上缴代收款状态)：默认值为0-未缴款；10-已保存；20-已提交；30-已缴款

            if (PriListid.Count == 0)
            {
                ClsMsgBox.Ts("请选择要制作的代收款日报！", ObjG.CustomMsgBox, this);
                return;
            }
            using (SqlConnection conn = new SqlConnection(PriConStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand();
                try
                {
                    comm.Connection = conn;
                    comm.Transaction = trans;
                    string cmdText = "";
                    cmdText = " update tfmsdsk set sjdskzt='20' where id in(select dskid from Tfmsdskjkmx where pcid  in (" + string.Join(",", PriListid) + "))";
                    comm.CommandText = cmdText;
                    int influenceSum = comm.ExecuteNonQuery();
                    cmdText = " update Tfmsdskjkpc set dkje=dsk,zt='10', zdczyid=" + PriZhid + ",zdczyxm='" + PriXm + "',zdczyzh='" + PriLogNama + "',zdsj='" + DateTime.Now.ToString() + "' where id  in (" + string.Join(",", PriListid) + ")";
                    comm.CommandText = cmdText;
                    influenceSum = influenceSum + comm.ExecuteNonQuery();
                    if (influenceSum == PriYdCounts + PriListid.Count)
                    {
                        //提交事物
                        ClsMsgBox.Ts("保存成功!共制作代收款" + PriSumJe.ToString() + "元", ObjG.CustomMsgBox, this);
                        trans.Commit();
                        this.Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select id,jgmc,dsk,sxf,zh,zffsmc,cnt,'详细' as Xq,'删除'as Del,rbdh,zt from Vfmszzycdsk where jgid=" + PriId, PriConStr);
                        PriListid.Clear();
                        PriYdCounts = 0;
                        PriSumJe = 0;
                        GetXx();
                    }
                    else
                    {
                        //回滚事物
                        ClsMsgBox.Ts("保存失败！", ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    //回滚事物
                    try
                    {
                        ClsMsgBox.Cw("保存异常！", ex, ObjG.CustomMsgBox, this);
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
        private void GetRowLing(int aId, int aCounts)
        {
            PriRowIndexId = aId;
            PriRowIndexCount = aCounts;
            ClsMsgBox.YesNo("是否删中转的代收款日报！", new EventHandler(DelYh), ObjG.CustomMsgBox, this);
        }
        private void DelYh(object sender, EventArgs e)
        {
            frm = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {
                //sjdskzt(上缴代收款状态)：默认值为0-未缴款；10-已保存；20-已提交；30-已缴款 
                using (SqlConnection conn = new SqlConnection(PriConStr))
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    SqlCommand comm = new SqlCommand();
                    try
                    {
                        comm.Connection = conn;
                        comm.Transaction = trans;
                        string cmdText = "";
                        cmdText = " update tfmsdsk set sjdskzt='15' where id in(select dskid from Tfmsdskjkmx where pcid=" + PriRowIndexId + ");";
                        comm.CommandText = cmdText;
                        int influenceSum = comm.ExecuteNonQuery();
                        cmdText = " update Tfmsdskjkpc   set zt='5' where  id=" + PriRowIndexId;
                        comm.CommandText = cmdText;
                        influenceSum = influenceSum + comm.ExecuteNonQuery();
                        if (influenceSum == PriRowIndexCount + 1)
                        {
                            //提交事物
                            ClsMsgBox.Ts("删除成功！",frm,this);
                            trans.Commit();
                            //this.Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select id,jgmc,dsk,sxf,zh,zffsmc,cnt,'详细信息' as Xq,'删除'as Del,rbdh,zt from Vfmszzycdsk where jgid=" + PriId, PriConStr);

                        }
                        else
                        {
                            //回滚事物
                            ClsMsgBox.Ts("删除失败！",frm,this);
                            trans.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        //回滚事物
                        try
                        {
                            ClsMsgBox.Cw("删除异常！", ex, frm, this);
                            trans.Rollback();
                        }
                        catch (SqlException ex1)
                        {
                            if (trans.Connection != null)
                                ClsMsgBox.Cw("回滚失败! 异常类型:" + ex1.GetType(), ex1, frm, this);
                        }
                    }
                    finally
                    {
                        conn.Close();
                        //PriListid.Clear();
                    }
                }
            }
        }
        #region 返回
        private void BtnClose_Click(object sender, EventArgs e)
        {
            PriListid.Clear();
            PriYdCounts = 0;
            this.Close();
        }
        #endregion
        #region 本页全选
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
                return;
            CheckThisPage();
            GetXx();
        }
        public void CheckThisPage()
        {
            //一共有多少行
            int rowcount = Convert.ToInt32(Dgv.RowCount);
            //当前是第几页
            int currentpage = Convert.ToInt32(Dgv.CurrentPage);
            //一页有机行
            int pageSize = Convert.ToInt32(Dgv.ItemsPerPage);
            //一共有多少页
            int pageCount = (rowcount / pageSize);
            //合计的值 
            //判断一共有几页，有没有余数
            //如果有余数就是只最后一页不满足我们指定的显示的条数
            if (rowcount % pageSize > 0)
            {
                pageCount++;
                //先计算除了最后一页的合计
                if (currentpage < pageCount)
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                    {
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value))
                        {
                            int aId = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtid"].Value);
                            int n;
                            int aYdCounts = 0;
                            double m;
                            double aRowDsk = 0;
                            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                                aRowDsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                            if (Int32.TryParse(Dgv.Rows[i].Cells["DgvColTxtcounts"].Value.ToString(), out n))
                            {
                                aYdCounts = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtcounts"].Value);//有问题
                            }
                            if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value))//取消选择
                            {
                                Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value = true;
                                PriListid.Add(aId);
                                PriYdCounts = PriYdCounts + aYdCounts;
                                PriSumJe = PriSumJe + aRowDsk;
                            }
                        }
                    }
                }
                //计算最后一页的值
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value))
                        {
                            int aId = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtid"].Value);
                            int n;
                            int aYdCounts = 0;
                            double m;
                            double aRowDsk = 0;
                            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                                aRowDsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                            if (Int32.TryParse(Dgv.Rows[i].Cells["DgvColTxtcounts"].Value.ToString(), out n))
                            {
                                aYdCounts = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtcounts"].Value);//有问题
                            }
                            if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value))//取消选择
                            {
                                Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value = true;
                                PriListid.Add(aId);
                                PriYdCounts = PriYdCounts + aYdCounts;
                                PriSumJe = PriSumJe + aRowDsk;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value))
                    {
                        int aId = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtid"].Value);
                        int n;
                        int aYdCounts = 0;
                        double m;
                        double aRowDsk = 0;
                        if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                            aRowDsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                        if (Int32.TryParse(Dgv.Rows[i].Cells["DgvColTxtcounts"].Value.ToString(), out n))
                        {
                            aYdCounts = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtcounts"].Value);//有问题
                        }
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value))//取消选择
                        {
                            Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value = true;
                            PriListid.Add(aId);
                            PriYdCounts = PriYdCounts + aYdCounts;
                            PriSumJe = PriSumJe + aRowDsk;
                        }
                    }
                }
            }
        }
        #endregion
        #region 显示信息
        private void GetXx()
        {
            LblCheckCount.Text = "共选中" + PriListid.Count.ToString() + "行";
            if (PriSumJe == 0)
                LblCheckSumJe.Text = "共选中代收款0.00元";
            else
                LblCheckSumJe.Text = "共选中代收款" + PriSumJe.ToString() + "元";
        }
        #endregion
        #region 全选
        private void ChkB_CheckedChanged(object sender, EventArgs e)
        {
            CheckAll(ChkB.Checked);
            GetXx();
        }
        public void CheckAll(bool aChecked)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                int aId = Convert.ToInt32(row.Cells["DgvColTxtid"].Value);
                int n;
                int aYdCounts = 0;
                double m;
                double aRowDsk = 0;
                if (double.TryParse(row.Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                    aRowDsk = Convert.ToDouble(row.Cells[DgvColTxtdsk.Name].Value);
                if (Int32.TryParse(row.Cells["DgvColTxtcounts"].Value.ToString(), out n))
                    aYdCounts = Convert.ToInt32(row.Cells["DgvColTxtcounts"].Value);//有问题 
                if (!aChecked)//取消全选
                {
                    if (Convert.ToBoolean(row.Cells[DgvColTxtxz.Name].Value))//取消选择
                    {
                        row.Cells[DgvColTxtxz.Name].Value = false;
                        PriListid.Remove(aId);
                        PriYdCounts = PriYdCounts - aYdCounts;
                        PriSumJe = PriSumJe - aRowDsk;
                    }
                }
                else
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColTxtxz.Name].Value))
                    {
                        row.Cells[DgvColTxtxz.Name].Value = true;
                        PriListid.Add(aId);
                        PriYdCounts = PriYdCounts + aYdCounts;
                        PriSumJe = PriSumJe + aRowDsk;
                    }
                }
            }
        }
        #endregion

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 3, 4, 5 };
            ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1, Rows);  
            //ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1);  
        }
    }
}
