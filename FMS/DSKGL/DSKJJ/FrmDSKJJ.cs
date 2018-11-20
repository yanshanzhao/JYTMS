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
#endregion
namespace FMS.DSKGL.DSKJJ
{
    public partial class FrmDSKJJ : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private List<int> PriList;
        private int PriRowCount;
        #endregion
        public FrmDSKJJ()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            this.CmbJjzt.SelectedIndex = 0;
        }
        private void BtnSel_Click(object sender, EventArgs e)
        {

            ClsD.TextBoxTrim(this);
            this.DSDSKJJ1.Clear();
            this.Check.Checked = false;
            string aWhere = " where jjzt='" + CmbJjzt.Text.ToString() + "' ";
            if (TxtBYdbh.Text.Length > 0)
                aWhere += " and bh='" + this.TxtBYdbh.Text.ToString() + "' ";
            if (TxtBFwkh.Text.Length > 0)
                aWhere += " and dskkhbh='" + this.TxtBFwkh.Text.ToString() + "' ";
            if (TxtBKhmc.Text.Length > 0)
                aWhere += " and mc='" + this.TxtBKhmc.Text.ToString() + "' ";
            if (TxtFhflxfs.Text.Length > 0)
                aWhere += " and fhlxdh='" + this.TxtFhflxfs.Text.ToString() + "' ";
            this.VfmsDskjjTableAdapter1.FillByWhere(this.DSDSKJJ1.VfmsDskjj, aWhere);
            //Check.Checked = true;
            PriRowCount = 0;
        }
        /*
        private void BtnQx_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (PriQxzt)
                {
                    if (Convert.ToBoolean(row.Cells[DgvChkBQx.Name].Value))
                        row.Cells[DgvChkBQx.Name].Value = false;
                }
                else
                {
                    if (!Convert.ToBoolean(row.Cells[DgvChkBQx.Name].Value))
                        row.Cells[DgvChkBQx.Name].Value = true;
                }
            }
            PriQxzt = !PriQxzt;
        }
        */
        private void BtnByqx_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count <= 0)
                return;
            int curPageFristIndex = 0;
            int curPageCount = Dgv.ItemsPerPage;
            if (Dgv.CurrentPage > 1)
                curPageFristIndex = (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;
            if (Dgv.CurrentPage == Dgv.TotalPages)
                curPageCount = Dgv.RowCount - (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;
            bool flag = Convert.ToBoolean(Dgv.Rows[curPageFristIndex].Cells[DgvChkBQx.Name].Value);
            for (int i = 0; i < curPageCount; i++)
            {
                Dgv.Rows[curPageFristIndex + i].Cells[DgvChkBQx.Name].Value = !flag;
            }
        }
        //加急
        private void BtnJj_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            string Jjzt = Dgv.Rows[0].Cells[DgvColTxtjjzt.Name].Value.ToString();
            if (Jjzt == "加急")
                return;
            GetList(false);

        }
        //取消加急
        private void BtnQxjj_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            string Jjzt = Dgv.Rows[0].Cells[DgvColTxtjjzt.Name].Value.ToString();
            if (Jjzt == "不加急")
                return;
            GetList(true);
        }
        private void GetList(bool jjzt)
        {
            PriList = new List<int>();
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvChkBQx.Name].Value))
                {
                    int aDskid = Convert.ToInt32(row.Cells[DgvColTxtid.Name].Value.ToString());
                    PriList.Add(aDskid);
                }
            }
            if (PriList.Count == 0)
            {
                ClsMsgBox.Ts("没有要操作的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            try
            {
                string SqlCmd = " update tfmsdsk set jjzt='" + jjzt + "' where id in ( " + string.Join(",", PriList) + ") and ffdskzt=0";
                int count = ClsRWMSSQLDb.ExecuteCmd(SqlCmd, ClsGlobals.CntStrTMS);
                string SqlCmd2 = " select sum(dsk) from tfmsdsk  where id in ( " + string.Join(",", PriList) + ") and ffdskzt=0";
                string zje = ClsRWMSSQLDb.GetStr(SqlCmd2, ClsGlobals.CntStrTMS);
                if (count > 0)
                {
                    string Jjzt = Dgv.Rows[0].Cells[DgvColTxtjjzt.Name].Value.ToString();
                    if (Jjzt == "不加急")
                    {
                        ClsMsgBox.Ts("操作成功,共成功" + count + "条！加急金额为" + zje + "元", ObjG.CustomMsgBox, this);
                    }
                    else
                    {
                        ClsMsgBox.Ts("操作成功,共成功" + count + "条！取消加急金额为" + zje + "元", ObjG.CustomMsgBox, this);
                    }
                }
                else
                {
                    ClsMsgBox.Ts("操作失败！", ObjG.CustomMsgBox, this);
                    return;
                }
                foreach (int id in PriList)
                {
                    Bds.RemoveAt(Bds.Find("id", id));
                }
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("操作异常！", ex, ObjG.CustomMsgBox, this);
            }
        }
        private void BtnEl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "代收款加急", this.ctrlDownLoad1, new int[] { 2 });
        }

        private void Check_CheckedChanged(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Check.Checked)
                    row.Cells[DgvChkBQx.Name].Value = true;
                else
                    row.Cells[DgvChkBQx.Name].Value = false;
            }
        }

        private void TxtBYdbh_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            BtnSel.PerformClick();
        }

        private void TxtBFwkh_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            BtnSel.PerformClick();
        }

        private void TxtBKhmc_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            BtnSel.PerformClick();
        }

        private void TxtFhflxfs_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            BtnSel.PerformClick();
        }

        private void BtnKSXZ_Click(object sender, EventArgs e)
        {
            kuaisuxuanze();
        }
        void kuaisuxuanze()
        {
            this.LblTs.Visible = true;
            if (string.IsNullOrEmpty(TxtBh.Text))
            {
                LblTs.Text = "请填写货运单号后，再进行快速选择";
                LblTs.ForeColor = Color.Red;
                TxtBh.Focus();
                return;
            }
            int RowIndex = Bds.Find("bh", TxtBh.Text);
            if (RowIndex < 0)
            {
                LblTs.Text = "没有要选择的运单！";
                LblTs.ForeColor = Color.Red;
                TxtBh.Focus();
                TxtBh.SelectAll();
                return;
            }
            Bds.Position = RowIndex;
            if (Convert.ToBoolean(Dgv.CurrentRow.Cells[DgvChkBQx.Name].Value))
            {
                this.LblTs.Visible = false;
                ClsMsgBox.Ts("该笔代收款已被选中！", ObjG.CustomMsgBox, this);
                return;
            }
            Dgv.CurrentRow.Cells[DgvChkBQx.Name].Value = true;
            PriRowCount++;
            LblTs.Text = "运单：" + TxtBh.Text + "被选中，共选中" + PriRowCount + "条。";
            LblTs.ForeColor = Color.Green;
            TxtBh.Text = "";
            TxtBh.Focus();
            this.ActiveControl = this.BtnKSXZ;
           
        }

        private void TxtBh_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            kuaisuxuanze();
            TxtBh.Focus();
        }

       
        #region 单选
        /*
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                else
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
            }
        }*/
        #endregion
    }
}