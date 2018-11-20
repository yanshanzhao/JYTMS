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
using FMS.SeleFrm;
#endregion

namespace FMS.JSGL.KHJS
{
    public partial class FrmKHZJ : Form
    {
        private decimal PriDzje = 0;
        private ClsG ObjG;
        private string PriYwqy = "";
        private string PriKhmc = "";
        private string PriDzqssj = "";
        private string PriDzjsjs = "";
        private string PriWhere = "";
        private int PriJgid = 0;
        private string PriJgmc = "";
        private EnumNEDD PriEnumNEDD;
        private int PriXzCnt = 0;
        private string PriKhid = "0";
        private List<int> PriListYbfId = new List<int>();
        public FrmKHZJ()
        {
            InitializeComponent();
        }
        public void Prepare(EnumNEDD aEnumNEDD)
        {
            PriEnumNEDD = aEnumNEDD;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            PriJgid = ObjG.Jigou.id;
            PriJgmc = ObjG.Jigou.mc;
            this.LblJG.Text = PriJgid.ToString();
            this.TxtDzjg.Text = PriJgmc;
            this.BtnJG.Visible = false;
            VfmsyfzjTableAdapter.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }
        #region 新增
        private void BtnAnd_Click(object sender, EventArgs e)
        {
            if (PriXzCnt > 0)
            {
                FrmKHJSXX f = new FrmKHJSXX();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed2);
                f.ShowDialog();
                f.Prepare(PriYwqy, PriKhmc, PriDzqssj, PriDzjsjs, PriDzje, PriListYbfId, lblKhid.Text, PriJgid.ToString());
            }
            else
                ClsMsgBox.Ts("请选择要新增的月结客户运单信息！", ObjG.CustomMsgBox, this);
        }
        void f_FormClosed2(object sender, FormClosedEventArgs e)
        {
            FrmKHJSXX f = sender as FrmKHJSXX;
            if (f.DialogResult == DialogResult.OK)
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
                //ClsMsgBox.Ts("新增成功！", ObjG.CustomMsgBox, this);
            }

        }

        #endregion
        #region 鼠标单选
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1)
                return;
            if (e.ColumnIndex == 0)//审核动作
            {
                decimal n;
                decimal aRowJe = 0;
                if (decimal.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                    aRowJe = Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtje.Name].Value);
                int aYdid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtId.Name].Value);
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))//取消
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    PriDzje = PriDzje - aRowJe;
                    PriXzCnt = PriXzCnt - 1;
                    PriListYbfId.Remove(aYdid);
                }
                else
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    PriDzje = PriDzje + aRowJe;
                    PriXzCnt = PriXzCnt + 1;
                    PriListYbfId.Add(aYdid);
                }
                GetXx();
            }
        }
        #endregion
        #region 查询
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            PriDzje = 0;
            if (TxtKhmc.Text.Trim() == "")
            {
                ClsMsgBox.Ts("请选择客户名称！", ObjG.CustomMsgBox, this);
                return;
            }
            PriListYbfId.Clear();
            if (CmbYwqy.SelectedIndex != 0)
                PriYwqy = CmbYwqy.Text;
            PriDzqssj = DtpStart.Text;
            PriDzjsjs = DtpStop.Text;
            PriKhmc = TxtKhmc.Text;
            PriKhid = lblKhid.Text;
            PriWhere = "";
            PriWhere = " where  zt='0' and jsjgid='" + LblJG.Text.Trim() + "'";
            if (TxtDzjg.Text.Trim() != "")
                PriWhere = PriWhere + " and  jsjgid=" + LblJG.Text;
            //if (CmbYwqy.SelectedIndex != 0)
            PriWhere = PriWhere + "  and inssj between'" + DtpStart.Value + "'and DateAdd(dd,+1, '" + DtpStop.Value + "')";
            if (CmbYwqy.SelectedIndex != 0)
                PriWhere = PriWhere + " and ywqy='" + PriYwqy + "'";
            PriWhere = PriWhere + " and  khmc='" + TxtKhmc.Text + "' ";
            this.VfmsyfzjTableAdapter.FillByWhere(DSKHJS1.Vfmsyfzj, PriWhere);
            if (Dgv.RowCount == 0)
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
            GetXx();
        }
        #endregion
        #region 返回
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        private void TxtDzjg_KeyDown(object objSender, KeyEventArgs objArgs)
        {
            if (objArgs.KeyCode == Keys.Back)
            {
                this.TxtDzjg.Text = "";
                this.LblJG.Text = "";
            }

        }
        private void TxtKhmc_KeyDown(object objSender, KeyEventArgs objArgs)
        {
            if (objArgs.KeyCode == Keys.Back)
                this.TxtKhmc.Text = "";
        }
        private void BtnJG_Click(object sender, EventArgs e)
        {
            FrmSelectJg f = new FrmSelectJg();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            using (FrmSelectJg f = sender as FrmSelectJg)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    this.TxtDzjg.Text = f.PubDictAttrs["mc"];
                    this.LblJG.Text = f.PubDictAttrs["id"];
                    PriJgid = Convert.ToInt32(this.LblJG.Text);
                    PriJgmc = this.TxtDzjg.Text;
                }
                else if (f.DialogResult == DialogResult.No)
                {
                    this.TxtDzjg.Text = "";
                    this.LblJG.Text = "";
                    PriJgid = 0;
                    PriJgmc = this.TxtDzjg.Text;
                }
            }
        }

        private void BtnKh_Click(object sender, EventArgs e)
        {
            FrmSelectKh1 f = new FrmSelectKh1();
            f.ShowDialog();
            f.Prepare();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }
        void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FrmSelectKh1 f = sender as FrmSelectKh1)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    TxtKhmc.Text = f.PubKhmc;
                    this.lblKhid.Text = f.PubKkid.ToString();
                }
                else
                {
                    TxtKhmc.Text = "";
                    this.lblKhid.Text = "0";
                }
            }
        }

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
                            if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                                aRowJe = Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value);
                            int aYdid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtId.Name].Value);
                            Dgv.Rows[i].Cells[DgvColCelXz.Name].Value = true;
                            PriDzje = PriDzje + aRowJe;
                            PriXzCnt = PriXzCnt + 1;
                            PriListYbfId.Add(aYdid);
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
                            if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                                aRowJe = Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value);
                            int aYdid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtId.Name].Value);
                            Dgv.Rows[i].Cells[DgvColCelXz.Name].Value = true;
                            PriDzje = PriDzje + aRowJe;
                            PriXzCnt = PriXzCnt + 1;
                            PriListYbfId.Add(aYdid);
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
                        if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                            aRowJe = Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value);
                        int aYdid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtId.Name].Value);
                        Dgv.Rows[i].Cells[DgvColCelXz.Name].Value = true;
                        PriDzje = PriDzje + aRowJe;
                        PriXzCnt = PriXzCnt + 1;
                        PriListYbfId.Add(aYdid);
                    }
                }
            }
        }
        #region 全选
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
                if (decimal.TryParse(row.Cells[DgvColTxtje.Name].Value.ToString(), out n))
                    aRowJe = Convert.ToDecimal(row.Cells[DgvColTxtje.Name].Value);
                int aYdid = Convert.ToInt32(row.Cells[DgvColTxtId.Name].Value);
                if (Convert.ToBoolean(row.Cells[DgvColCelXz.Name].Value) == true && aChecked == false)//取消
                {
                    row.Cells[DgvColCelXz.Name].Value = false;
                    PriDzje = PriDzje - aRowJe;
                    PriXzCnt = PriXzCnt - 1;
                    PriListYbfId.Remove(aYdid);
                }
                else if (Convert.ToBoolean(row.Cells[DgvColCelXz.Name].Value) == false && aChecked == true)
                {
                    row.Cells[DgvColCelXz.Name].Value = true;
                    PriDzje = PriDzje + aRowJe;
                    PriXzCnt = PriXzCnt + 1;
                    PriListYbfId.Add(aYdid);
                }
            }
        }
        #endregion
        #region 显示信息
        private void GetXx()
        {
            LblCheckCount.Text = "共选中" + PriListYbfId.Count.ToString() + "行";
            if (PriDzje == 0)
                LblCheckSumJe.Text = "共选中金额0.00元";
            else
                LblCheckSumJe.Text = "共选中金额" + PriDzje.ToString() + "元";
        }
        #endregion

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 7 };
            ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1);
        }

    }
}