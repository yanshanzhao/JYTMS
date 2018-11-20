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
using System.Collections;

#endregion

namespace FMS.CWGL.ZZHQRJKD.TZFGBFJKRB
{
    public partial class FrmTZFGBFJKMX : Form
    {
        private ClsG ObjG;
        private string PriLsh;
        public FrmTZFGBFJKMX()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
           
            ObjG = (ClsG)Session["ObjG"];
            VfmsxtsrTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;

            string sql = " select id,name from Tfmsxtwsr_lx ";
         
            DataTable dt = ClsRWMSSQLDb.GetDataTable(sql, ClsGlobals.CntStrTMS);
            this.CmbLx.DataSource = dt;
            this.CmbLx.DisplayMember = "name";
            this.CmbLx.ValueMember = "id";
            this.CmbLx.SelectedIndex = 0;
            BtnSearch.PerformClick();
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Bds.Count > 60000)
            {
                ClsMsgBox.Ts("不允许导出大于60000条的数据!", ObjG.CustomMsgBox, this);
                return;
            }
            int[] CellIndex = { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            ClsExcel.CreatExcel(Dgv, "运单调整或服务卡工本费缴款明细", this.ctrlDownLoad1, CellIndex);
        }

        private void BtnJk_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> PriId = new List<int>();
                List<ClsXtsr> ClsXtsr = new List<ClsXtsr>();
                List<string> list = new List<string>();
                GetLsh();
                decimal je = 0M;
                int jgid = 0, lxid = 0, id = 0;
                string inssj = "";
                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    var value = row.Cells[DgvColTxtQx.Name].Value;
                    if (value != null && value.Equals(true))
                    {
                        ClsXtsr Clsxs = new ClsXtsr();
                        je += Convert.ToDecimal(row.Cells[DgvColTxtJe.Name].Value);
                        jgid = Convert.ToInt32(row.Cells[DgvColTxtJgid.Name].Value);
                        inssj = row.Cells[DgvColTxtJzsj.Name].Value.ToString();
                        lxid = Convert.ToInt32(row.Cells[DgvColTxtLxid.Name].Value);
                        id = Convert.ToInt32(row.Cells[DgvColTxtId.Name].Value);
                        Clsxs.Je = Convert.ToDecimal(row.Cells[DgvColTxtJe.Name].Value);
                        if (string.IsNullOrEmpty(row.Cells[DgvColTxtYdtzid.Name].Value.ToString()))
                            Clsxs.Ydtzid = 0;
                        else
                            Clsxs.Ydtzid = Convert.ToInt32(row.Cells[DgvColTxtYdtzid.Name].Value.ToString());
                        if (string.IsNullOrEmpty(row.Cells[DgvColTxtKhid.Name].Value.ToString()))
                            Clsxs.Khid = 0;
                        else
                            Clsxs.Khid = Convert.ToInt32(row.Cells[DgvColTxtKhid.Name].Value);
                        Clsxs.Bh = row.Cells[DgvColTxtBh.Name].Value.ToString();
                        Clsxs.srid = id;
                        PriId.Add(id);
                        ClsXtsr.Add(Clsxs);
                    }
                }
                list.Add(je.ToString());
                list.Add(inssj);
                list.Add(lxid.ToString());
                list.Add(PriLsh);
                if (PriId.Count > 0)
                {
                    FrmTZFGBFBC f = new FrmTZFGBFBC();
                    f.ShowDialog();
                    f.Prepare(PriId, ClsXtsr, list);
                    f.FormClosed += new FormClosedEventHandler(f_FormClosed);
                }
                else
                {
                    ClsMsgBox.Ts("请选择要交款的信息!");
                    return;
                }
                
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("缴款失败", ex, ObjG.CustomMsgBox, this);
            }
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmTZFGBFBC f = sender as FrmTZFGBFBC;
            BtnSearch.PerformClick();
        }

        private void GetLsh()
        {
            ArrayList als = new ArrayList();
            als.Add(new SqlParameter("@tbln", "Tfmsxtwsr"));
            als.Add(new SqlParameter("@currq", DateTime.Now.Date));
            als.Add(new SqlParameter("@return", SqlDbType.Int));
            ((SqlParameter)als[2]).Direction = ParameterDirection.ReturnValue;
            ClsRWMSSQLDb.ExecuteCmd("PGetLsh", ClsGlobals.CntStrTMS, als, true);
            string lsh = ((SqlParameter)als[2]).Value.ToString().PadLeft(4, '0');
            if (lsh.Equals("0000"))
            {
                ClsMsgBox.Ts("生成流水号错误！", ObjG.CustomMsgBox, this);
                return;
            }
            PriLsh = DateTime.Now.ToString("yyyyMMdd") + lsh;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            ChkQx.Checked = false;
            string SWhere = " WHERE jgid=" + ObjG.Jigou.id + " AND zt=0 ";
            SWhere += " AND lxbhs='" + CmbLx.Text + "'";
            if(DtpStart.Checked==true)
                SWhere += " AND inssj>='" + DtpStart.Value.Date + "'";
            if(DtpStop.Checked==true)
                SWhere += " AND inssj<'" + DtpStop.Value.Date.AddDays(1) + "'";
            VfmsxtsrTableAdapter1.FillByWhere(Dstfmsxtsr1.vfmsxtsr, SWhere);
            if (Dgv.Rows.Count == 0)
            {
                this.LblSum.Text = "共选中0行，应存0.00元";
            }
            else
            {
                this.LblSum.Text = "共选中0行，应存" + Dstfmsxtsr1.vfmsxtsr.Compute("sum(je)", "zt=0") + "元";
            }
        }


        #region 全选、反选功能
        /// <summary>
        /// 全选功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkQx_CheckedChanged(object sender, EventArgs e)
        {
            CheckAll(ChkQx.Checked);
        }

        public void CheckAll(bool aChecked)
        {
            if (aChecked)
            {
                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    row.Cells[DgvColTxtQx.Name].Value = true;
                }
                this.LblSum.Text = "共选中" + Dgv.Rows.Count + "行，应存" + Dstfmsxtsr1.vfmsxtsr.Compute("sum(je)", "zt=0") + "元";
            }
            else
            {
                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    row.Cells[DgvColTxtQx.Name].Value = false;
                }
                this.LblSum.Text = "共选中0行，应存" + Dstfmsxtsr1.vfmsxtsr.Compute("sum(je)", "zt=0") + "元";
            }
        }
        #endregion

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                }
                else
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                }
            }
            int count = 0;
            decimal je = 0;
            foreach (DataGridViewRow item in Dgv.Rows)
            {
                var value = item.Cells[DgvColTxtQx.Name].Value;
                if (value != null && value.Equals(true))
                {
                    count++;
                    je += Convert.ToDecimal(item.Cells[DgvColTxtJe.Name].Value);
                }
            }
            this.LblSum.Text = "共选中" + count + "行，应存" + je + "元";
        }
    }
}
