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
using FMS.CWGL.YYSRCX;
using NPOI.HSSF.UserModel;
using System.Configuration;
using System.IO;
using NPOI.SS.Util;

#endregion

namespace FMS.CWGL.YYSRTJ2
{
    public partial class FrmXbYySrTj : UserControl
    {
        public FrmXbYySrTj()
        {
            InitializeComponent();
        }
        #region 成员变量
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private int PriJgid = 0;
        private int PriYwqyIndx = 0;
        private DateTime PriStartSj = DateTime.Now;
        private DateTime PriStopSj = DateTime.Now;
        private int Prilx = 0;
        #endregion
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG; 
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            this.CmbYwqy.SelectedIndex = 0;
            PnlMain.Controls.Add(PnlJgcx);
            PnlJgcx.Visible = false;
            PriJgid = ObjG.Jigou.id;
            TxtJgmc.Text = ObjG.Jigou.mc;
        }

        private void BtnClear1_Click(object sender, EventArgs e)
        {
            this.TxtJgmc.Clear();
            PriJgid = 0;
        }
        private void TxtJg_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            PnlJgcx.Visible = true;
            string CmdText = "select mc,pym,id from jyjckj.dbo.tjigou where parentLst like '%," + ObjG.Jigou.id + ",%' and (pym like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%' or  mc like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%')";
            PriJgDt = ClsRWMSSQLDb.GetDataTable(CmdText, ClsGlobals.CntStrTMS);
            LstV.DataSource = PriJgDt;
            LstV.Columns[0].Text = "机构名称";
            LstV.Columns[1].Text = "拼音码";
            LstV.Columns[2].Text = "jgid";
            LstV.Columns[2].Visible = false;
            LstV.Columns[0].Width = 120;
            LstV.Focus();
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (this.Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的数据");
            }
            else
            {
                ClsExcel.CreatExcel(this.Dgv, " 营业收入统计 ", this.ctrlDownLoad1);
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            LblHj.Text = "合计：0元";
            Prilx = 0;
            if (PriJgid == 0)
            {
                ClsMsgBox.Ts("请选择查询的机构！", ObjG.CustomMsgBox, this);
                return;
            }
            string aWhere = " where EXISTS (SELECT id FROM jyjckj.dbo.tjigou WHERE parentlst like '%," + PriJgid + ",%' AND id=sljgid) and  inssj >= '" + DtpQrStart.Value + "' and inssj< DateAdd(dd,+1, '" + DtpQrStop.Value + "')";

            if (CmbYwqy.SelectedIndex != 0)
                aWhere = aWhere + " and ywqy='" + CmbYwqy.Text + "'";
            aWhere += " and jezj<> 0.00 ";
            PriYwqyIndx = CmbYwqy.SelectedIndex;
            PriStartSj = DtpQrStart.Value;
            PriStopSj = DtpQrStop.Value;
            DataTable dt = new DataTable();
            if (PriStopSj.ToString("yyyyMMDD") != DateTime.Now.ToString("yyyyMMDD"))
            {
                dt = ClsRWMSSQLDb.GetDataTable(" select mc,ywqy,sljgid,cz,SUM(fhxf) AS fhxf,SUM(bf) AS bf,SUM(jezj) AS jezj,sum(zzl) as zzl,sum(ztj) ztj,sum(jfzl) as jfzl from Vfmsyysrcx3 " + aWhere + " group BY mc,ywqy,sljgid,cz ", ClsGlobals.CntStrTMS);
                Prilx = 1;
            }
            else
            {
                dt = ClsRWMSSQLDb.GetDataTable(" select mc,ywqy,sljgid,cz,SUM(fhxf) AS fhxf,SUM(bf) AS bf,SUM(jezj) AS jezj,sum(zzl) as zzl,sum(ztj) ztj,sum(jfzl) as jfzl from Vfmsyysrcx4 " + aWhere + " group BY mc,ywqy,sljgid,cz ", ClsGlobals.CntStrTMS);
                Prilx = 2;
            }
            if (dt.Rows.Count != 0)
            {
                DataRow dr = dt.NewRow();
                dr["mc"] = "合计：";
                dr["fhxf"] = dt.Compute("sum(fhxf)", "");
                dr["bf"] = dt.Compute("sum(bf)", "");
                dr["jezj"] = dt.Compute("sum(jezj)", "");
                dt.Rows.Add(dr);
                Dgv.DataSource = dt;
                LblHj.Text = "合计：" + dr["jezj"].ToString() + "元";
            }
            else
            {
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
            }
        }
        private void LstV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                if (TxtJg.Text.Trim().Length != 0)
                    TxtJg.Text = TxtJg.Text.Trim().Substring(0, TxtJg.Text.Trim().Length - 1);
                TxtJg.SelectionStart = TxtJg.Text.Length;
                TxtJg.Focus();
                PnlJgcx.Visible = false;
                PriJgDt.Dispose();
            }
            if (LstV.Items.Count > 0)
            {
                if (e.KeyChar == 13)
                {
                    this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
                    PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
                    this.PnlJgcx.Visible = false;
                    PriJgDt.Dispose();
                }
            }
        }
        private void LstV_LostFocus(object sender, EventArgs e)
        {
            PnlJgcx.Visible = false;
            PriJgDt.Dispose();
        }
        private void LstV_DoubleClick(object sender, EventArgs e)
        {
            this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
            PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
            this.PnlJgcx.Visible = false;
            PriJgDt.Dispose();
        }

        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex < 0 || e.ColumnIndex != 6)
                return;
            if (e.ColumnIndex == 6 && e.RowIndex != Dgv.Rows.Count - 1)//连接
            {
                FrmXbLsdSrTj f = new FrmXbLsdSrTj();
                f.ShowDialog();
                int aSljgid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColSljgid.Name].Value);
                f.Prepare(aSljgid, PriStartSj, PriStopSj, Prilx);
            }
        }
    }
}