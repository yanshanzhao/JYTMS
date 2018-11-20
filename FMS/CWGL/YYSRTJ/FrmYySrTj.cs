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
using FMS.SelectFrm;

#endregion

namespace FMS.CWGL.YYSRTJ
{
    public partial class FrmYySrTj : UserControl
    {
        public FrmYySrTj()
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
        #endregion
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            this.CmbYwqy.SelectedIndex = 0;
            CmbJzlx.SelectedIndex = 3;
            PnlMain.Controls.Add(PnlJgcx);
            PnlJgcx.Visible = false;
            PriJgid = ObjG.Jigou.id;
            TxtJgmc.Text = ObjG.Jigou.mc;
            //ClsPopulateCmbDsS.PopuYd_ywxz(CmbYwxz, ClsGlobals.CntStrKj);

            DataTable dtDqxx = ClsRWMSSQLDb.GetDataTable(" SELECT 0 AS dqid,'--全部--' dqmc,'' sybid  UNION SELECT dqid,dqmc,sybid  FROM jyjckj.dbo.Vdqjigou   WHERE  dqid<>jgid GROUP BY dqid,dqmc,sybid ORDER BY sybid,dqid ", ClsGlobals.CntStrKj);
            Txtdq.Tag = "0";
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
                ClsExcel.CreatExcel(this.Dgv, " 营业收入统计 ", this.ctrlDownLoad1, new int[] { 3, 4, 5, 7, 8, 9 });
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            LblHj.Text = "合计：0元";
            if (PriJgid == 0)
            {
                ClsMsgBox.Ts("请选择查询的机构！", ObjG.CustomMsgBox, this);
                return;
            }
            string aWhere = " where EXISTS (SELECT id FROM jyjckj.dbo.tjigou WHERE parentlst like '%," + PriJgid + ",%' AND id=sljgid) and  inssj >= '" + DtpQrStart.Value + "' and inssj< DateAdd(dd,+1, '" + DtpQrStop.Value + "')";
            if (CmbJzlx.SelectedIndex == 0)
            {
                aWhere += " and fkfs='F' ";
            }
            else if (CmbJzlx.SelectedIndex == 1)
            {
                aWhere += " and fkfs='T' ";
            }
            else if (CmbJzlx.SelectedIndex == 2)
            {
                aWhere += " and fkfs in('D','Z','S') ";
            }
            if (CmbYwqy.SelectedIndex != 0)
                aWhere = aWhere + " and ywqys='" + CmbYwqy.Text + "'";
            if (Txtdq.Tag.ToString() != "0")
                aWhere = aWhere + " and dqid = " + Txtdq.Tag.ToString();
            //if (CmbYwxz.SelectedIndex != 0)
            //    aWhere = aWhere + " and ywxz = '" + CmbYwxz.SelectedValue.ToString() + "'";
            aWhere += " and jezj<> 0.00 ";
            PriYwqyIndx = CmbYwqy.SelectedIndex;
            PriStartSj = DtpQrStart.Value;
            PriStopSj = DtpQrStop.Value;
            DataTable dt = ClsRWMSSQLDb.GetDataTable("  SELECT e.fzf,e.mc,e.ywqys,e.sljgid,e.cz,SUM(e.fhxf) AS fhxf,SUM(e.bf) AS bf,SUM(e.jezj) AS jezj,e.dqmc,ISNULL(m.zzl,0) zzl,ISNULL(m.ztj,0) ztj,ISNULL(m.jfzl,0) jfzl FROM ( select fzf,mc,ywqys,sljgid,cz,SUM(fhxf) AS fhxf,SUM(bf) AS bf,SUM(jezj) AS jezj,dqmc,ydid from Vfmsyysrcx2 " + aWhere + " group BY mc,ywqys,sljgid,cz,fzf,dqmc,ydid ) AS e LEFT JOIN tyd_sl AS m ON e.ydid=m.id group BY e.mc,e.ywqys,e.sljgid,e.cz,e.fzf,e.dqmc,m.zzl ,m.ztj,m.jfzl ", ClsGlobals.CntStrTMS);
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

            if (e.ColumnIndex == 10 && e.RowIndex != Dgv.Rows.Count - 1)//连接
            {
                FrmLsdSrTj f = new FrmLsdSrTj();
                f.ShowDialog();
                int aSljgid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColSljgid.Name].Value);
                f.Prepare(aSljgid, PriStartSj, PriStopSj);
            }
        }

        private void Btndq_Click(object sender, EventArgs e)
        {
            FrmSelectDq f = new FrmSelectDq();
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(fsl_FormClosing);
        }
        void fsl_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FrmSelectDq f = sender as FrmSelectDq)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    Txtdq.Text = f.PubDictAttrs["dqmc"].ToString();
                    Txtdq.Tag = f.PubDictAttrs["dqid"].ToString();
                }
                else
                {
                    Txtdq.Text = "";
                    Txtdq.Tag = "0";
                }
            }
        }
    }
}