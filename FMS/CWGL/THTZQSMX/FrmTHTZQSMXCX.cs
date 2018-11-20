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
using FMS.SeleFrm;
using System.Data.SqlClient;

#endregion

namespace FMS.CWGL.THTZQSMX
{
    public partial class FrmTHTZQSMXCX : UserControl
    {
        private ClsG ObjG;
        private int Prilevel;
        private string PriWhere;
        public FrmTHTZQSMXCX()
        {
            InitializeComponent();
        }

        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            this.ActiveControl = BtnJg;
            ClsPopulateCmbDsS.PopuYd_ydzts(CmbThydzt);
            CmbThydzt.SelectedIndex = 0;
            CmbDsk.SelectedIndex = 1;
            CmbQszt.SelectedIndex = 0;
            CmbQsjgzt.SelectedIndex = 0;
            TxtSQjg.Text = ObjG.Jigou.mc;
            TxtSQjg.Tag = ObjG.Jigou.id.ToString();
            Prilevel = ObjG.Jigou.level;
        }

        #region 选择退货机构
        private void BtnJg_Click(object sender, EventArgs e)
        {
            FrmSelectJg2 f = new FrmSelectJg2();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            Prilevel = -1;
            FrmSelectJg2 f = sender as FrmSelectJg2;
            this.TxtSQjg.Text = f.PubDictAttrs["mc"];
            this.TxtSQjg.Tag = f.PubDictAttrs["id"];
            if (f.DialogResult == DialogResult.OK)
            {
                Prilevel = Convert.ToInt32(f.PubDictAttrs["level"]);
            }
            f.Dispose();
        }
        #endregion

        #region 查询
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (Prilevel < 0)
            {
                ClsMsgBox.Ts("请选择要查询的机构", ObjG.CustomMsgBox, this);
                return;
            }
            int alx = 0;
            if (Prilevel <= 4)
                alx = 1;
            //PriWhere = "";
            string Where = " where qszts=" + CmbQszt.SelectedIndex;
            if (CmbQsjgzt.SelectedIndex == 0)
                Where += " and qsjgzc='否'";
            else
                Where += " and qsjgzc='是'";
            if (CmbThydzt.SelectedIndex != 0)
                Where += " and xydzt='" + CmbThydzt.SelectedValue + "'";
            int jgid = Convert.ToInt32(TxtSQjg.Tag.ToString());
            Where += " and sqjgid in (SELECT id FROM jyjckj.dbo.tjigou WHERE parentLst LIKE '%," + jgid + ",%') ";
            if (!string.IsNullOrEmpty(TxtYydh.Text.Trim()))
                Where += " and ybh='" + TxtYydh.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(TxtXydh.Text.Trim()))
                Where += " and xbh='" + TxtXydh.Text.Trim() + "'";
            if (DtpStart.Checked)
                Where += "   and sqsj>='" + DtpStart.Value.Date + "' ";
            if (DtpStop.Checked)
                Where += "   and sqsj<'" + DtpStop.Value.Date + "' ";
            if (DtpBzStart.Checked)
                Where += "   and bzsj>='" + DtpBzStart.Value.Date + "' ";
            if (DtpBzStop.Checked)
                Where += "   and bzsj<'" + DtpBzStop.Value.Date + "' ";
            if (CmbDsk.SelectedIndex > 0)
            {
                if (CmbDsk.SelectedIndex == 1)
                    Where += "   and dsk>0 ";
                else if (CmbDsk.SelectedIndex == 2)
                    Where += "   and dsk=0 ";
            }
            string SqlStr = "SELECT  id, ysljgmc, ysljgid, yqsjgmc, yqsjgid, ybh, dsk, sqsj, xbh, xqsjg, xqsjgid, qsjgzc, qszt, thbzs, thbz, sqjgid, sqjgmc, xydzt, bzsj, yydfy, thlx, thlxs, dqmc, dqid FROM  Vfmsthdsk" + Where;
            DataTable PriDt = new DataTable();
            PriDt = ClsRWMSSQLDb.GetDataTable(SqlStr, ClsGlobals.CntStrTMS);
            Dgv.DataSource = PriDt;
            if (Dgv.Rows.Count == 0)
                ClsMsgBox.Ts("没有要查询的信息，请核对查询条件！", ObjG.CustomMsgBox, this);
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
            ClsExcel.CreatExcel(Dgv, "退货调整签收状态明细查询", this.ctrlDownLoad1);
        }
        #endregion

        #region 全选
        /// <summary>
        /// 全选功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (ChkB.Checked)
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                    {
                        row.Cells[DgvColCbm.Name].Value = true;
                    }
                }
                else
                {
                    if (Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                    {
                        row.Cells[DgvColCbm.Name].Value = false;
                    }
                }
            }
        }
        #endregion

    }
}