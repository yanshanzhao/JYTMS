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
#endregion

namespace FMS.JSGL.KHJS
{
    public partial class FrmKHZJUp : Form
    {
        private decimal PriDzje = 0;
        private ClsG ObjG;
        private DataRow PriDataRow;
        private int PriPcid = 0;
        private List<int> PriNewListYbfid = new List<int>();
        private List<int> PriOldListYbfid = new List<int>();
        public FrmKHZJUp()
        {
            InitializeComponent();
        }
        public void Prepare(int aId)
        {
            PriPcid = aId;
            PriDataRow = ClsRWMSSQLDb.GetDataRow(" select dzdh,Y,M,zdjgmc,ywqy,khmc,ST,et,je,zdjg,insczyxm,inssj,jyje,bz,cnt,jsjgmc,jsje,jslx,jsczyxm,jkbz from Vfmskhjspc where id=" + PriPcid, ClsGlobals.CntStrTMS);
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            this.vfmskhjsmxTableAdapter.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.vfmskhjsmxTableAdapter.FillByWhere(DSKHJS1.Vfmskhjsmx, " where pcid=" + PriPcid);
            GetQx();
        }

        #region 修改
        private void BtnAnd_Click(object sender, EventArgs e)
        {
            FrmKHJSXX f = new FrmKHJSXX();
            f.Prepare(PriPcid, PriDzje, PriNewListYbfid, PriOldListYbfid);
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
            //if (PriDzje > 0)
            //{
            //    FrmKHJSXX f = new FrmKHJSXX();
            //    f.Prepare(PriPcid, PriDzje, PriNewListYbfid, PriOldListYbfid);
            //    f.FormClosed += new FormClosedEventHandler(f_FormClosed);
            //    f.ShowDialog();
            //}
            //else
            //    ClsMsgBox.Ts("请选择要新增的月结客户运单信息！", ObjG.CustomMsgBox, this);
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form f = sender as FrmKHJSXX;
            if (f.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }
        #endregion
        #region 鼠标单选
        private void GetQx()
        {
            for (int i = 0; i < Dgv.RowCount; i++)
            {
                decimal n;
                decimal aRowJe = 0;
                int aid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtId.Name].Value);
                if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                    aRowJe = Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value);
                Dgv.Rows[i].Cells[0].Value = true;
                PriDzje = PriDzje + aRowJe;
                PriNewListYbfid.Add(aid);
            }
            GetXx();
        }
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex <= -1)
                return;
            if (e.ColumnIndex == 0)//审核动作
            {
                decimal n;
                decimal aRowJe = 0;
                int aid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtId.Name].Value);
                if (decimal.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                    aRowJe = Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtje.Name].Value);
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))//取消
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    PriDzje = PriDzje - aRowJe;
                    PriNewListYbfid.Remove(aid);
                    PriOldListYbfid.Add(aid);
                }
                else
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    PriDzje = PriDzje + aRowJe;
                    PriNewListYbfid.Add(aid);
                    PriOldListYbfid.Remove(aid);
                }
                GetXx();
            }
        }
        #endregion
        #region 返回
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void ChkB_CheckedChanged(object sender, EventArgs e)
        {
            CheckAll(ChkB.Checked);
            GetXx();
        }
        private void CheckAll(bool aChecked)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                decimal n;
                decimal aRowJe = 0;
                int aid = Convert.ToInt32(row.Cells[DgvColTxtId.Name].Value);
                if (decimal.TryParse(row.Cells[DgvColTxtje.Name].Value.ToString(), out n))
                    aRowJe = Convert.ToDecimal(row.Cells[DgvColTxtje.Name].Value);
                if (Convert.ToBoolean(row.Cells[DgvColCelXz.Name].Value) == true && aChecked == false)//取消
                {
                    row.Cells[DgvColCelXz.Name].Value = false;
                    PriDzje = PriDzje - aRowJe;
                    PriNewListYbfid.Remove(aid);
                    PriOldListYbfid.Add(aid);
                }
                else if (Convert.ToBoolean(row.Cells[DgvColCelXz.Name].Value) == false && aChecked == true)
                {
                    row.Cells[DgvColCelXz.Name].Value = true;
                    PriDzje = PriDzje + aRowJe;
                    PriNewListYbfid.Add(aid);
                    PriOldListYbfid.Remove(aid);
                }
            }
        }
        #region 显示信息
        private void GetXx()
        {
            LblCheckCount.Text = "共选中" + PriNewListYbfid.Count.ToString() + "行";
            if (PriDzje == 0)
                LblCheckSumJe.Text = "共选中金额0.00元";
            else
                LblCheckSumJe.Text = "共选中金额" + PriDzje.ToString() + "元";
        }
        #endregion

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
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCelXz.Name].Value))
                        {
                            decimal n;
                            decimal aRowJe = 0;
                            int aid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtId.Name].Value);
                            if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                                aRowJe = Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value);
                            Dgv.Rows[i].Cells[DgvColCelXz.Name].Value = true;
                            PriDzje = PriDzje + aRowJe;
                            PriNewListYbfid.Add(aid);
                            PriOldListYbfid.Remove(aid);
                        }
                    }
                }
                //计算最后一页的值
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCelXz.Name].Value))
                        {
                            decimal n;
                            decimal aRowJe = 0;
                            int aid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtId.Name].Value);
                            if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                                aRowJe = Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value);
                            Dgv.Rows[i].Cells[DgvColCelXz.Name].Value = true;
                            PriDzje = PriDzje + aRowJe;
                            PriNewListYbfid.Add(aid);
                            PriOldListYbfid.Remove(aid);
                        }
                    }
                }
            }
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCelXz.Name].Value))
                    {
                        decimal n;
                        decimal aRowJe = 0;
                        int aid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtId.Name].Value);
                        if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                            aRowJe = Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value);
                        Dgv.Rows[i].Cells[DgvColCelXz.Name].Value = true;
                        PriDzje = PriDzje + aRowJe;
                        PriNewListYbfid.Add(aid);
                        PriOldListYbfid.Remove(aid);
                    }
                }
            }
        }
    }
}