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

namespace FMS.CWGL.XTWSP
{
    public partial class FrmXTSRSP : UserControl
    {
        private ClsG ObjG;
        private string PriConStr;
        private DSSP.VfmsxtwpcRow PriRow;
        private List<int> PriList = new List<int>();
        private int pageSize = 0;
        private int PriJgid;//需要审核的机构id
        public FrmXTSRSP()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriConStr = ClsGlobals.CntStrTMS;
            VfmsxtwpcTableAdapter1.Connection.ConnectionString = PriConStr;
            CmbZt.SelectedIndex = 0;
            CmbPpjg.SelectedIndex = 0;
            DataTable dt = ClsRWMSSQLDb.GetDataTable("SELECT -1 id, '全部' name,-1 sort FROM dbo.Tfmsxtwsr_lx UNION  SELECT id,name,sort FROM dbo.Tfmsxtwsr_lx  ORDER BY sort ", ClsGlobals.CntStrTMS);
            this.CmbLx.DataSource = dt;
            this.CmbLx.DisplayMember = "name";
            this.CmbLx.ValueMember = "id";
            this.CmbLx.SelectedIndex = 0;


            //银行类型
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable("SELECT -1 id, '全部' jc   UNION  SELECT id,jc FROM  tyhlx WHERE  id in (49,63,241);  ", ClsGlobals.CntStrTMS);
            this.CmbYHlx.DataSource = dtYhlx;
            this.CmbYHlx.DisplayMember = "jc";
            this.CmbYHlx.ValueMember = "id";
            this.CmbYHlx.SelectedIndex = 0;

            pageSize = Convert.ToInt32(Dgv.ItemsPerPage);
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            Chb.Checked = false;
            LblCheckSumJe.Text = "本页缴款合计0元，全部缴款合计0元";
            if (DtpQrStart.Checked == false && DtpQrStop.Checked == false && DtpSpStart.Checked == false && DtpSpStop.Checked == false)
            {
                ClsMsgBox.Ts("申请时间或审批时间必须选中一个！", ObjG.CustomMsgBox, this);
                return;
            }
            if (CmbZt.Text == "申请中" && (DtpSpStart.Checked == true || DtpSpStop.Checked == true))
            {
                ClsMsgBox.Ts("申请中的收入不能选则审批时间！", ObjG.CustomMsgBox, this);
                return;
            }
            string SWhere = " WHERE spjgid=" + ObjG.Jigou.id;
            if (PriJgid > 0)
                SWhere += "  and  zzjgid= " + PriJgid;
            if (DtpQrStart.Checked == true)
                SWhere += " AND inssj>= '" + DtpQrStart.Value.Date + "' ";
            if (DtpQrStop.Checked == true)
                SWhere += " AND inssj<='" + DtpQrStop.Value.Date.AddDays(1) + "' ";
            if (DtpSpStart.Checked == true)
                SWhere += " AND spsj>= ' " + DtpSpStart.Value.Date + "' ";
            if (DtpSpStop.Checked == true)
                SWhere += " AND spsj<='" + DtpSpStop.Value.Date.AddDays(1) + "' ";
            if (CmbZt.SelectedIndex == 0)
                SWhere += " AND zt=0 ";
            else if (CmbZt.SelectedIndex == 1)
                SWhere += " AND zt=1 ";
            else
                SWhere += " AND zt=2 ";
            if (CmbLx.SelectedIndex != 0)
                SWhere += " AND lxs='" + CmbLx.Text + "'";
            if (CmbYHlx.SelectedIndex != 0)
                SWhere += " and yhlxid= " + CmbYHlx.SelectedValue;
            if (CmbPpjg.SelectedIndex != 0)
                SWhere += " and ppzt='" + CmbPpjg.Text.ToString() + "'";
            VfmsxtwpcTableAdapter1.FillByWhere(DSSP1.Vfmsxtwpc, SWhere);
            PriList.Clear();
            if (Dgv.Rows.Count == 0)
                ClsMsgBox.Ts("没有查询到信息，请重新确认查询条件！", ObjG.CustomMsgBox, this);
            else
                SumThisPage();
        }
        private void BtnSel_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.Rows.Count > 60000)
            {
                ClsMsgBox.Ts("不允许导出大于60000条的数据!", (Session["ObjG"] as ClsG).CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(Dgv, "系统外收入审批", ctrlDownLoad1, new int[] { 4 });
        }
        private void BtnSPTG_Click(object sender, EventArgs e)
        {
            GetList();
            if (PriList.Count == 0)
            {
                ClsMsgBox.Ts("请至少审核一条收入信息！", ObjG.CustomMsgBox, this);
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
                    cmdText = string.Format(" update  tfmsxtwsrpc set spsj='{0}', sprid='{1}',sprzh='{2}',spr='{3}',zt='{4}' where id in ({5})",
                 DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, 1, string.Join(",", PriList));
                    cmdText += " update  Tfmsxtsr set zt=20 where id in (select srid  from tfmsxtwsrmx where pcid in (select id from  tfmsxtwsrpc where id   in (" + string.Join(",", PriList) + "))) ";
                    comm.CommandText = cmdText;
                    int influenceSum = comm.ExecuteNonQuery();
                    if (influenceSum > 0)
                    {
                        //提交事物
                        ClsMsgBox.Ts("审核成功！共审核" + PriList.Count + "条信息", ObjG.CustomMsgBox, this);
                        trans.Commit();
                        foreach (int i in PriList)
                        {
                            int index = Bds.Find("id", i);
                            Bds.RemoveAt(index);
                        }
                        PriList.Clear();
                    }
                    else
                    {
                        //回滚事物
                        ClsMsgBox.Ts("审核失败！", ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    //回滚事物
                    try
                    {
                        ClsMsgBox.Cw("审核异常！", ex, ObjG.CustomMsgBox, this);
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
                    SumThisPage();
                }
            }
        }

        private void GetList()
        {
            PriList.Clear();
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvCbxQx.Name].Value))
                {
                    if (row.Cells[DgvCbxQx.Name].Value.ToString().Length > 0)
                    {
                        int id = Convert.ToInt32(row.Cells[DgvTxtid.Name].Value.ToString());
                        PriList.Add(id);
                    }
                }

            }
        }

        private void BtnByQx_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
                return;
            CheckThisPage();
        }
        public void CheckThisPage()
        {
            //本页有多少行
            int currenRows = 0;
            if (Dgv.CurrentPage == Dgv.TotalPages)
                currenRows = Dgv.RowCount - (Dgv.TotalPages - 1) * pageSize;
            else
                currenRows = pageSize;
            for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + currenRows; i++)
            {
                if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvCbxQx.Name].Value))
                {
                    if (Dgv.Rows[i].Cells[DgvTxtZt.Name].Value.ToString().LastIndexOf("审批") != 0)
                        Dgv.Rows[i].Cells[DgvCbxQx.Name].Value = true;
                }

            }
        }

        private void Chb_CheckedChanged(object sender, EventArgs e)
        {
            CheckAll(Chb.Checked);
        }
        public void CheckAll(bool aChecked)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (row.Cells[DgvTxtZt.Name].Value.ToString().LastIndexOf("审批") != 0)
                    row.Cells[DgvCbxQx.Name].Value = aChecked;
            }
        }

        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                string zt = Dgv.Rows[e.RowIndex].Cells[DgvTxtZt.Name].Value.ToString();

                if (zt.LastIndexOf("审批") == 0)
                {
                    ClsMsgBox.Ts("该信息已经审核，不能审核！");
                    Dgv.Rows[e.RowIndex].Cells[DgvCbxQx.Name].Value = false;
                    return;
                }
                //else
                //{
                //    if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvCbxQx.Name].Value))
                //        Dgv.Rows[e.RowIndex].Cells[DgvCbxQx.Name].Value = false;
                //    else
                //        Dgv.Rows[e.RowIndex].Cells[DgvCbxQx.Name].Value = true;
                //}
            }
        }

        #region 本页合计
        private void SumThisPage()
        {
            decimal sum_by = 0;//本页合计金额
            decimal sum_qb = 0;//全部合计金额
            if (Dgv.RowCount > 0)
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
                            sum_by += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvTxtje.Name].Value);
                        }
                    }
                    //计算最后一页的值
                    else
                    {
                        for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                        {
                            sum_by += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvTxtje.Name].Value);
                        }
                    }
                }
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                    {
                        sum_by += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvTxtje.Name].Value);
                    }
                }
                for (int i = 0; i < Dgv.RowCount; i++)
                {
                    sum_qb += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvTxtje.Name].Value);
                }
            }
            LblCheckSumJe.Text = "本页缴款合计" + sum_by + "元，全部缴款合计" + sum_qb + "元";

        }
        #endregion

        private void BtnSPBTG_Click(object sender, EventArgs e)
        {
            SumThisPage();
        }


        #region 机构选择 BtnJg_Click(object sender, EventArgs e)
        /// <summary>
        /// 机构选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnJg_Click(object sender, EventArgs e)
        {
            SeleFrm.FrmSelectJg f = new SeleFrm.FrmSelectJg();
            f.Prepare();

            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            SeleFrm.FrmSelectJg f = sender as SeleFrm.FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtBJg.Text = f.PubDictAttrs["mc"];
                PriJgid = Convert.ToInt32(f.PubDictAttrs["id"]);
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtBJg.Text = "";
                PriJgid = 0;
            }
        }
        #endregion
    }
}