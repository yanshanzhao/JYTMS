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
using JY.Pri;
using FMS.SeleFrm;
using System.Data.SqlClient;
#endregion
namespace FMS.DSKGL.DSKZZ
{
    public partial class FrmNewDSKZZ : Form
    {
        #region 成员变量
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private decimal PriZj;
        private decimal PriYcje;//与PriZj对比数据是否准确
        private int ChkRowCount;
        private int PriRowCount;//与ChkRowCount对比数据是否准确
        private string CmdText;
        private string PriZffs;
        private string PriRbbh;
        private string PriRbpcid;
        private List<string> LstSql = new List<string>();
        private List<int> LstYdid = new List<int>();
        private string PriFwjgid;
        //private int RowCount;
        private bool IsChecked;
        private int PriUpdRows;
        private int PriZflx = 0;
        #endregion
        public FrmNewDSKZZ()
        {
            InitializeComponent();
        }
        #region 初始化数据
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            Vfmsdskzz2TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            PriJgDt = ClsRWMSSQLDb.GetDataTable("select tojgmc,tojgid from vfmsjggx where gxzl='D' and jgid=" + ObjG.Jigou.id, ClsGlobals.CntStrTMS);
            if (PriJgDt.Rows.Count == 1)
            {
                LblFwjgmc.Text = PriJgDt.Rows[0]["tojgmc"].ToString();
                PriFwjgid = PriJgDt.Rows[0]["tojgid"].ToString();
            }
            ClsPopulateCmbDsS.PopuYd_dshksqfs(Cmbfkfs);

            ClsPopulateCmbDsS.PopuFmsDskffsj(CmbDszl);
            Cmbfkfs.SelectedIndex = 0;
            CmbDszl.SelectedIndex = 0;
            CmbZffs.SelectedIndex = 0;
        }
        #endregion

        #region 返回
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 客户查询
        private void BtnSearchKh_Click(object sender, EventArgs e)
        {
            FrmSelectKh f = new FrmSelectKh();
            f.Prepare();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectKh f = sender as FrmSelectKh;
            if (f.DialogResult == DialogResult.OK)
                Txtfhkh.Text = f.PubKhmc;
        }
        #endregion

        #region 受理机构查询
        private void BtnSearchjg_Click(object sender, EventArgs e)
        {
            FrmSelectJg f = new FrmSelectJg();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
                this.txtsljg.Text = f.PubDictAttrs["mc"];
            else if (f.DialogResult == DialogResult.No)
                this.txtsljg.Text = "";
        }
        #endregion

        #region 查询
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //ChkQx.Checked = false;
            LblTs.Visible = false;
            try
            {
                ClsD.TextBoxTrim(this);
                Clear();
                string where = " where qsjgid=" + ObjG.Jigou.id;
                if (DtpSlStart.Checked)
                    where += " and inssj >= '" + DtpSlStart.Value.Date + "'";
                if (DtpSlStop.Checked)
                    where += " and inssj < '" + DtpSlStop.Value.AddDays(1).Date + "'";
                if (DtpQsStart.Checked)
                    where += " and qssj >= '" + DtpQsStart.Value.Date + "'";
                if (DtpQsStop.Checked)
                    where += " and qssj < '" + DtpQsStop.Value.AddDays(1).Date + "'";
                where += string.IsNullOrEmpty(txtsljg.Text) ? "" : " and sljg ='" + txtsljg.Text + "'";
                where += string.IsNullOrEmpty(Txthydh.Text) ? "" : " and bh='" + Txthydh.Text + "'";
                where += " and dskfkfs='" + Cmbfkfs.SelectedValue + "'";
                where += string.IsNullOrEmpty(Txtfhkh.Text) ? "" : " and fhkhmc ='" + Txtfhkh.Text + "'";
                where += CmbDszl.SelectedIndex == 0 ? "" : " and dshklx='" + CmbDszl.Text.Trim() + "'";
                where += " and zflx= '" + CmbZffs.Text.Trim() + "'";
                where += "   ORDER BY dsffsj,qssj  ";
                DSdskzz1.EnforceConstraints = false;
                PriZflx = CmbZffs.SelectedIndex;
                Vfmsdskzz2TableAdapter1.FillByWhere(DSdskzz1.Vfmsdskzz2, where);
                PriZffs = Cmbfkfs.SelectedValue.ToString();
                if (Bds.Count == 0)
                {
                    ClsMsgBox.Ts("没有查询到代收款中转信息！", ObjG.CustomMsgBox, this);
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("代收款中转信息查询失败！", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion

        #region 中转
        private void BtnZz_Click(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            PriRbbh = "D" + DateTime.Now.ToString("yyyyMMdd") + ObjG.Jigou.id;
            if (string.IsNullOrEmpty(LblFwjgmc.Text))
            {
                ClsMsgBox.Ts("该机构没有代收款关系机构，请维护！", this, LblFwjgmc, ObjG.CustomMsgBox);
                return;
            }
            if (ChkRowCount <= 0)
            {
                ClsMsgBox.Ts("请选择要操作的数据记录 ", ObjG.CustomMsgBox, this);
                return;
            }
            DskZZ();
        }
        public void DskZZ()
        {
            PriUpdRows = 0;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsGlobals.CntStrTMS;
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.Transaction = trans;
                    try
                    {
                        //if (PriZffs == "X"&& PriZflx > 0)
                        //{ 
                        //        PriZflx = 0;
                        //}
                        CmdText = string.Format("  SET NOCOUNT OFF insert into Tfmsdskjkpc(rbdh,jgid,zffs,dsk,sxf,zt,cnt,zzsj,zzczyid,zzczyzh,zzczyxm,spjgid,zflx)" +
                            "  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');select SCOPE_IDENTITY() ",
                            PriRbbh, ObjG.Jigou.id, PriZffs, PriZj, 0, 0, ChkRowCount, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriFwjgid, PriZflx);
                        comm.CommandText = CmdText;
                        PriRbpcid = comm.ExecuteScalar().ToString();
                        GetSql(PriRbpcid);
                        if (PriYcje != PriZj)
                        {
                            ClsMsgBox.Ts("代收款中转失败，请重新选择数据！", ObjG.CustomMsgBox, this);
                            trans.Rollback();
                            return;
                        }
                        if (PriRowCount != ChkRowCount)
                        {
                            ClsMsgBox.Ts("代收款中转失败，请重新选择数据！", ObjG.CustomMsgBox, this);
                            trans.Rollback();
                            return;
                        }
                        comm.CommandText = string.Join(";", LstSql);
                        comm.ExecuteNonQuery();
                        CmdText = "";
                        CmdText = "SET NOCOUNT OFF UPDATE Tfmsdsk SET SJDSKZT=10 WHERE id IN (" + string.Join(",", LstYdid) + ") and fkfs='" + PriZffs + "'   and SJDSKZT=0 ";
                        comm.CommandText = CmdText;
                        PriUpdRows = comm.ExecuteNonQuery();
                        if (LstSql.Count() != PriUpdRows)
                        {
                            ClsMsgBox.Ts("代收款中转失败!", ObjG.CustomMsgBox, this);
                            trans.Rollback();
                            return;
                        }
                        trans.Commit();
                        this.Close();
                        ClsMsgBox.Ts("代收款中转成功！共中转" + ChkRowCount + "票,总共" + LblZjje.Text + "元", ObjG.CustomMsgBox, this);
                    }
                    catch (Exception ex)
                    {
                        ClsMsgBox.Cw("代收款中转失败！", ex, ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
        }
        #endregion

        #region 组装明细SQL语句
        private void GetSql(string aRbpdid)
        {
            LblTs.Visible = false;
            LstSql.Clear();
            LstYdid.Clear();
            PriYcje = 0;
            PriRowCount = 0;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                {
                    LstSql.Add(string.Format("INSERT INTO Tfmsdskjkmx (pcid,dskid,ydid,dsk,sxf) VALUES('{0}','{1}','{2}','{3}','{4}')",
                        PriRbpcid, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtdsk.Name].Value, 0));
                    PriYcje += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                    LstYdid.Add(Convert.ToInt32(row.Cells[DgvColTxtDskid.Name].Value));
                    PriRowCount++;
                }
            }
        }
        #endregion

        #region 单行选择
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblTs.Visible = false;
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                //string mcs = Dgv.Rows[e.RowIndex].Cells[DgvColTxtsftzt.Name].Value.ToString();
                //if (Dgv.Rows[e.RowIndex].Cells[DgvColTxtsftzt.Name].Value.ToString() != "2")
                //{
                    if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                    {
                        ChkRowCount--;
                        Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        PriZj -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                    }
                    else
                    {
                        ChkRowCount++;
                        Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        PriZj += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                    }
                //}
            }
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "共选中" + ChkRowCount + "行";
        }
        #endregion

        #region 本页全选
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            if (Dgv.Rows.Count == 0)
                return;
            CheckThisPage();
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "共选中" + ChkRowCount + "行";
        }
        public void CheckThisPage()
        {
            if (Bds.Count == 0)
                return;
            int curPageFirstIndex = (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;//获取当前页的第一行的RowIndex
            int lastPageSize = Dgv.RowCount - (Dgv.TotalPages - 1) * Dgv.ItemsPerPage; //获取最后一页的行数
            int curPageSize = Dgv.CurrentPage != Dgv.TotalPages ? Dgv.ItemsPerPage : lastPageSize; //获取每页的行数（考虑最后一页）
            int curRowIndex = curPageFirstIndex;

            while (curRowIndex < (curPageFirstIndex + curPageSize))
            {
                if (Dgv.Rows[curRowIndex].Cells[DgvColTxtsftzt.Name].Value.ToString() != "2")
                {
                    if (!Convert.ToBoolean(Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value).Equals(true))
                    {
                        Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value = true;
                        PriZj += Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtdsk.Name].Value);
                        ChkRowCount++;
                    }
                    else
                    {
                        Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value = false;
                        PriZj -= Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtdsk.Name].Value);
                        ChkRowCount++;
                    }
                }
                curRowIndex++;
            }
            /*
            //一共有多少行
            int rowcount = Convert.ToInt32(Dgv.RowCount);
            //当前是第几页
            int currentpage = Convert.ToInt32(Dgv.CurrentPage);
            //一页有机行
            int pageSize = Convert.ToInt32(Dgv.ItemsPerPage);
            //一共有多少页
            int pageCount = (rowcount / pageSize);
            //合计的值
            decimal sum = 0;
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
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value))
                        {
                            Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value = true;
                            sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                            ChkRowCount++;
                        }
                    }
                    PriZj += sum;
                }
                //计算最后一页的值
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value))
                        {
                            Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value = true;
                            sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                            ChkRowCount++;
                        }
                    }
                    PriZj += sum;
                }
            }
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value))
                    {
                        Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value = true;
                        sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                        ChkRowCount++;
                    }
                }
                PriZj += sum;
            }*/
        }
        #endregion

        #region 全选
        private void ChkQx_CheckedChanged(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            if (Dgv.Rows.Count == 0)
                return;
            CheckAll(ChkQx.Checked);
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "共选中" + ChkRowCount + "行";
        }
        public void CheckAll(bool aChecked)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (aChecked)
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                    {
                        row.Cells[DgvColTxtCheck.Name].Value = true;
                        PriZj += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                        ChkRowCount++;
                    }
                }
                else
                {
                    if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                    {
                        row.Cells[DgvColTxtCheck.Name].Value = false;
                        PriZj -= Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                        ChkRowCount--;
                    }
                }
            }
        }
        #endregion

        #region Clear
        public void Clear()
        {
            PriZj = Convert.ToDecimal(0.00);
            ChkRowCount = 0;
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "共选中" + ChkRowCount + "行";
            //RowCount = 0;
            //LblTs.Text = "共选中" + RowCount.ToString() + "条!";
        }
        #endregion

        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 5, 6 };
            ClsExcel.CreatExcel(Dgv, "代收款中转", this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, "代收款中转", this.ctrlDownLoad1); 
        }
        #endregion

        private void BtnKsxz_Click(object sender, EventArgs e)
        {
            LblTs.Visible = true;
            //RowCount = 0;
            IsChecked = false;
            if (string.IsNullOrEmpty(TxtBh.Text))
            {
                LblTs.Text = "先录入货运编号！";
                LblTs.ForeColor = Color.Red;
                return;
            }
            //int position = Bds.Find("bh", TxtBh.Text);
            //if (position < 0)
            //{
            //    LblTs.Text = "没有要选择的运单！";
            //    return;
            //}
            //Bds.Position = position;
            //if (!Convert.ToBoolean(Dgv.CurrentRow.Cells[DgvColTxtCheck.Name].Value))
            //{
            //    Dgv.CurrentRow.Cells[DgvColTxtCheck.Name].Value = true;
            //    ChkRowCount++;
            //    LblCheckCount.Text = "共选中" + ChkRowCount + "行";
            //}
            //ClsD.TurnToBdsPosPage(Dgv);
            //LblTs.Text = "第" + this.Dgv.CurrentPage + "页，第" + (Convert.ToInt32(position) + 1) + "条!";
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (row.Cells[DgvColTxthydh.Name].Value.Equals(TxtBh.Text) && !Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                {
                    row.Cells[DgvColTxtCheck.Name].Value = true;
                    Bds.Position = row.Index;
                    IsChecked = true;
                    PriZj += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                    ChkRowCount++;
                    //RowCount++;
                }
            }
            if (!IsChecked)
            {
                LblTs.Visible = true;
                LblTs.Text = "没有查询到相应运单！";
                LblTs.ForeColor = Color.Red;
                return;
            }
            ClsD.TurnToBdsPosPage(Dgv);
            int RowIndex = Bds.Find("bh", TxtBh.Text);
            LblCheckCount.Text = "共选中" + ChkRowCount + "行";
            LblZjje.Text = PriZj.ToString();
            LblTs.Visible = true;
            string bh = TxtBh.Text;
            TxtBh.Text = "";
            LblTs.Text = "运单号" + bh + "已选中，共选中" + ChkRowCount + "条";
            LblTs.ForeColor = Color.Green;
        }

        private void TxtBh_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            this.BtnKsxz.PerformClick();
        }

        private void BtnFX_Click(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            foreach (DataGridViewRow row in Dgv.Rows)
            {

                if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                {
                    row.Cells[DgvColTxtCheck.Name].Value = false;
                    PriZj -= Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                    ChkRowCount--;
                    //RowCount--;
                }
                else
                {
                    row.Cells[DgvColTxtCheck.Name].Value = true;
                    PriZj += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                    ChkRowCount++;
                }
            }
            LblCheckCount.Text = "共选中" + ChkRowCount + "行";
            LblZjje.Text = PriZj.ToString();
            //LblTs.Text = "共选中" + RowCount.ToString() + "条!";
        }



    }
}
