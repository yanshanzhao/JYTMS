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

namespace FMS.CWGL.QRJKYBF
{
    public partial class FrmYbfqrjk : UserControl
    {
        public FrmYbfqrjk()
        {
            InitializeComponent();
        }
        #region 成员变量
        private ClsG ObjG;
        private int PriUserid;
        private string PriUserZh;
        private string PriUserXm;
        private int PriToJgid;//登录者的机构id
        private int PriJgid;//需要审核的机构id
        //private string PriShzt;//审核状态
        //private string PriYwqy;//业务区域
        private List<int> PriListShid = new List<int>();//存放审核的id
        private double PriSumsSjJe = 0;//实际应存合计
        private double PriSumsDkje = 0;//实际代扣合计
        private string PriConStr;
        private List<int> PriLstYbfid = new List<int>();//运保费表中的id
        private List<int> PriLstKhjsid = new List<int>();//客户结算表中的PCid

        #endregion

        #region Pripare  
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            this.VfmsybfqrjkTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            PriConStr = ClsGlobals.CntStrTMS;
            CmbYhlx.SelectedIndex = 0;
            CmbDkzt.SelectedIndex = 0;
            CmbPpzt.SelectedIndex = 0;
            CmbWydkzt.SelectedIndex = 0;
            CmbShzt.SelectedIndex = 2;
            PriToJgid = ObjG.Jigou.id;
            PriUserid = ObjG.Renyuan.id;
            PriUserZh = ObjG.Renyuan.loginName;
            PriUserXm = ObjG.Renyuan.xm;  
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmBYwqy, ClsGlobals.CntStrKj);

        }
        private void GetXx()
        {
            LblCheckCount.Text = "共选中" + PriListShid.Count + "行,选中确认金额共" + PriSumsSjJe + "元，实际代扣金额" + PriSumsDkje + "元";
        }
        #endregion

        #region 机构选择
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

        #region 全选
        private void ChBQx_CheckedChanged(object sender, EventArgs e)
        {
            CheckAll(ChBQx.Checked);
            GetXx();
        }
        public void CheckAll(bool aChecked)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {

                if (row.Cells[DgvColTxtztmc.Name].Value.ToString() != "审核相符")
                {
                    int aid = Convert.ToInt32(row.Cells[DgvColTxtid.Name].Value.ToString());
                    double n;
                    double aRowScje = 0;
                    double aRowDkje = 0;
                    if (double.TryParse(row.Cells[DgvColTxtscje.Name].Value.ToString(), out n))
                        aRowScje = n;
                    if (double.TryParse(row.Cells[DgvColTxtDkje.Name].Value.ToString(), out n))
                        aRowDkje = n;
                    if (!aChecked)//取消全选
                    {
                        if (Convert.ToBoolean(row.Cells[DgvCoChb.Name].Value))//取消选择
                        {
                            row.Cells[DgvCoChb.Name].Value = false;
                            PriListShid.Remove(aid);
                            PriSumsSjJe = PriSumsSjJe - aRowScje;
                            PriSumsDkje = PriSumsDkje - aRowDkje;
                        }
                    }
                    else
                    {
                        if (!Convert.ToBoolean(row.Cells[DgvCoChb.Name].Value))//取消选择
                        {
                            row.Cells[DgvCoChb.Name].Value = true;
                            PriListShid.Add(aid);
                            PriSumsSjJe = PriSumsSjJe + aRowScje;
                            PriSumsDkje = PriSumsDkje + aRowDkje;
                        }
                    }
                }
            }
        }
        #endregion

        #region 本页全选
        private void BtnByqx_Click(object sender, EventArgs e)
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

                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvCoChb.Name].Value) && Dgv.Rows[i].Cells[DgvColTxtztmc.Name].Value.ToString() != "审核相符")
                        {
                            int aid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value.ToString());
                            double n;
                            double aRowScje = 0;
                            double aRowDkje = 0;
                            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtscje.Name].Value.ToString(), out n))
                                aRowScje = n;
                            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtDkje.Name].Value.ToString(), out n))
                                aRowDkje = n;
                            Dgv.Rows[i].Cells[DgvCoChb.Name].Value = true;
                            PriListShid.Add(aid);
                            PriSumsSjJe = PriSumsSjJe + aRowScje;
                            PriSumsDkje = PriSumsDkje + aRowDkje;
                        }
                    }
                }
                //计算最后一页的值
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvCoChb.Name].Value) && Dgv.Rows[i].Cells[DgvColTxtztmc.Name].Value.ToString() != "审核相符")
                        {
                            int aid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value.ToString());
                            double n;
                            double aRowScje = 0;
                            double aRowDkje = 0;
                            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtscje.Name].Value.ToString(), out n))
                                aRowScje = n;
                            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtDkje.Name].Value.ToString(), out n))
                                aRowDkje = n;
                            Dgv.Rows[i].Cells[DgvCoChb.Name].Value = true;
                            PriListShid.Add(aid);
                            PriSumsSjJe = PriSumsSjJe + aRowScje;
                            PriSumsDkje = PriSumsDkje + aRowDkje;
                        }
                    }
                }
            }
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvCoChb.Name].Value) && Dgv.Rows[i].Cells[DgvColTxtztmc.Name].Value.ToString() != "审核相符")
                    {
                        int aid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value.ToString());
                        double n;
                        double aRowScje = 0;
                        double aRowDkje = 0;
                        if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtscje.Name].Value.ToString(), out n))
                            aRowScje = n;
                        if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtDkje.Name].Value.ToString(), out n))
                            aRowDkje = n;
                        Dgv.Rows[i].Cells[DgvCoChb.Name].Value = true;
                        PriListShid.Add(aid);
                        PriSumsSjJe = PriSumsSjJe + aRowScje;
                        PriSumsDkje = PriSumsDkje + aRowDkje;
                    }
                }
            }
        }
        #endregion

        #region 查询
        private void BtnSel_Click(object sender, EventArgs e)
        {
            PriListShid.Clear();
            PriSumsSjJe = 0;
            PriSumsDkje = 0; 
            this.ChBQx.Checked = false;
            string aWhere = " where tojgid= " + PriToJgid + "  and  inssj>='" + DTimePInsjKs.Value.Date + "' and inssj< '" + DTimePInsjJs.Value.Date.AddDays(1) + "'";
            if (PriJgid > 0)
                aWhere += "  and  jgid= " + PriJgid;
            if(CmbYhlx.SelectedIndex>0)
                aWhere += "  and  yhlxmc= '" + CmbYhlx.Text.ToString() + "'";
            if(CmbDkzt.SelectedIndex>0)
                aWhere += "  and  dkzts= '" + CmbDkzt.Text.ToString() + "'";
            if (CmBYwqy.SelectedIndex > 0)
                aWhere += "  and  ywqy= '" + CmBYwqy.SelectedItem.ToString() + "'";
            if (CmbWydkzt.SelectedIndex > 0)
                aWhere += "  and  wydkzts= '" + CmbWydkzt.Text+ "'";
            if (CmbShzt.SelectedIndex > 0)
                aWhere += "  and  ztmc= '" + CmbShzt.Text.ToString() + "'";
            if(DTimePQrKs.Checked)
                aWhere += "  and  shsj>='" + DTimePQrKs.Value.Date + "'";
            if (DTimePQrJs.Checked)
                aWhere += "  and  shsj<'" + DTimePQrKs.Value.Date + "'";
            if (CmbPpzt.SelectedIndex > 0)
                aWhere += "  and  ppzts= '" + CmbPpzt.Text.ToString() + "'";  //匹配状态
            aWhere += " order by inssj desc";
            VfmsybfqrjkTableAdapter1.FillByWhere(DSYBFQRJK1.Vfmsybfqrjk,aWhere); 
            if (Dgv.RowCount < 1)
            {
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this); 
                return;
            } 
            GetXx();
        }

        #endregion

        #region 审核
        private void BtnQrjk_Click(object sender, EventArgs e)
        {
            if (PriListShid.Count == 0)
            {
                ClsMsgBox.Ts("请选择要审核的缴款日报！", ObjG.CustomMsgBox, this);
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
                    cmdText = " SET NOCOUNT OFF  update Tfmsrbpc set zt='10',shsj='" + DateTime.Now + "',shczyid=" + PriUserid + ",shczyxm='" + PriUserXm + "',shczyzh='" + PriUserZh + "' where id in(" + string.Join(",", PriListShid) + ");";
                    GetYdid();
                    if (PriLstYbfid.Count != 0)
                        cmdText = cmdText + " update tfmsybf set zt='20' where id in(" + string.Join(",", PriLstYbfid) + ");";
                    if (PriLstKhjsid.Count != 0)
                    {
                        cmdText = cmdText + " update Tfmskhjspc set zt='20' where id in(" + string.Join(",", PriLstKhjsid) + ");";
                        cmdText = cmdText + " update tfmsybf set zt='20' where id in (select ybfid from Tfmskhjsmx where pcid in (select id from Tfmskhjspc where id in(" + string.Join(",", PriLstKhjsid) + "))) ;";
                    }
                    comm.CommandText = cmdText;
                    int influenceSum = comm.ExecuteNonQuery();
                    if (influenceSum > 0)
                    {
                        //提交事物
                        ClsMsgBox.Ts("审核成功！", ObjG.CustomMsgBox, this);
                        foreach (int i in PriListShid)
                        {
                            int index = Bds.Find("id", i);
                            Bds.RemoveAt(index);
                        }
                        PriLstYbfid.Clear();
                        PriListShid.Clear();
                        PriLstKhjsid.Clear();
                        PriSumsSjJe = 0;
                        PriSumsDkje = 0;
                        trans.Commit();
                        GetXx();
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

                }
            }
        }
        /// <summary>
        /// 获取运单id
        /// </summary>
        private void GetYdid()
        {
            PriLstYbfid.Clear();
            string aSQlCont = " select ybfid from Tfmsrbmx where  ybfid>0 and rbpcid in(" + string.Join(",", PriListShid) + ")";
            DataTable dt = ClsRWMSSQLDb.GetDataTable(aSQlCont, PriConStr);
            if (dt.Rows.Count >= 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PriLstYbfid.Add(Convert.ToInt32(dt.Rows[i][0]));
                }
            }
            aSQlCont = " select khjsid from Tfmsrbmx where  khjsid>0 and rbpcid in(" + string.Join(",", PriListShid) + ")";
            dt = ClsRWMSSQLDb.GetDataTable(aSQlCont, PriConStr);
            if (dt.Rows.Count >= 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PriLstKhjsid.Add(Convert.ToInt32(dt.Rows[i][0]));
                }
            }
        }
        #endregion     

        #region 导出
        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(Dgv,"运保费代扣导出",this.ctrlDownLoad1, new int[]{3,4,5});
        }
        #endregion

        #region 鼠标单选
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                if (Dgv.Rows[e.RowIndex].Cells[DgvColTxtztmc.Name].Value.ToString() == "审核相符")
                {
                    ClsMsgBox.Ts("该缴款日报已经审核通过！", ObjG.CustomMsgBox, this);
                    Dgv.Rows[e.RowIndex].Cells[DgvCoChb.Name].Value = false;
                    return;
                }
                int aid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtid.Name].Value.ToString());
                double n;
                double aRowScje = 0;
                double aRowDkje = 0;
                if (double.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtscje.Name].Value.ToString(), out n))
                    aRowScje = n;
                if (double.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtDkje.Name].Value.ToString(), out n))
                    aRowDkje = n; 
                if (!Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvCoChb.Name].Value))//取消选择
                {
                    Dgv.Rows[e.RowIndex].Cells[DgvCoChb.Name].Value = false;
                    PriListShid.Remove(aid);
                    PriSumsSjJe = PriSumsSjJe - aRowScje;
                    PriSumsDkje = PriSumsDkje - aRowDkje;
                }
                else
                {
                    Dgv.Rows[e.RowIndex].Cells[DgvCoChb.Name].Value = true;
                    PriListShid.Add(aid);
                    PriSumsSjJe = PriSumsSjJe + aRowScje;
                    PriSumsDkje = PriSumsDkje + aRowDkje;
                }
                GetXx();
            }
        }
        #endregion
    }
}
