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

namespace FMS.CWGL.ZBJKRBCX
{
    public partial class FrmZBJKRBCX : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private string PriWhere;
        private string Prijgid;
        #endregion
        public FrmZBJKRBCX()
        {
            InitializeComponent();
        }
        #region 初始化数据
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            PnlMain.Controls.Add(PnlJgcx);
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable(" select id,jc from tyhlx where  hdzt='Y' and id in(241,63)  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbYhlx, dtYhlx, "id", "jc");
            PnlJgcx.Visible = false;
            CmbYhlx.SelectedIndex = 0;
            CmbZt.SelectedIndex = 0;
            ClsPopulateCmbDsS.PopuFMS_Rblx(CmbRblx);
            CmbRblx.SelectedIndex = 0;
            DtpStop.Value = DateTime.Now.AddDays(1).Date;
            cmblx.SelectedIndex = 0;
           
        }
        #endregion

        #region 机构查询
        private void TxtJg_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            PnlJgcx.Visible = true;
            string CmdText = "select mc,pym,id from tjigou where parentLst like '%," + ObjG.Jigou.id + ",%' and (pym like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%' or mc like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%')";
            PriJgDt = ClsRWMSSQLDb.GetDataTable(CmdText, ClsGlobals.CntStrKj);
            LstV.DataSource = PriJgDt;
            LstV.Columns[0].Text = "机构名称";
            LstV.Columns[1].Text = "拼音码";
            LstV.Columns[2].Text = "jgid";
            LstV.Columns[2].Visible = false;
            LstV.Columns[0].Width = 120;
            LstV.Focus();
        }
        private void LstV_LostFocus(object sender, EventArgs e)
        {
            PnlJgcx.Visible = false; 
            PriJgDt.Dispose(); 
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
                    Prijgid = LstV.SelectedItems[0].SubItems[2].Text;
                    this.PnlJgcx.Visible = false;
                    PriJgDt.Dispose();
                }
            }
        }
        private void LstV_DoubleClick(object sender, EventArgs e)
        {
            this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
            Prijgid = LstV.SelectedItems[0].SubItems[2].Text;
            this.PnlJgcx.Visible = false;
            PriJgDt.Dispose();
        }
        //private void DgvJgcx_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    this.TxtJgmc.Text = DgvJgcx.CurrentRow.Cells[DgvColTxtJgmc.Name].Value.ToString();
        //    Prijgid = DgvJgcx.CurrentRow.Cells[DgvColTxtJg.Name].Value.ToString();
        //    this.PnlJgcx.Visible = false;
        //    PriJgDt.Dispose();
        //}

        //private void DgvJgcx_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 8)
        //    {
        //        if (TxtJg.Text.Trim().Length != 0)
        //            TxtJg.Text = TxtJg.Text.Trim().Substring(0, TxtJg.Text.Trim().Length - 1);
        //        TxtJg.SelectionStart = TxtJg.Text.Length;
        //        TxtJg.Focus();
        //        PnlJgcx.Visible = false;
        //        PriJgDt.Dispose();
        //    }
        //}

        //private void DgvJgcx_LostFocus(object sender, EventArgs e)
        //{
        //    PnlJgcx.Visible = false;

        //    PriJgDt.Dispose();
        //}
        #endregion

        #region 查询
        private void BtnQery_Click(object sender, EventArgs e)
        {
            try
            {
                ClsD.TextBoxTrim(this);
                DSCX.Clear();
               //string PriWhere1 = "";
                PriWhere = "";
                PriWhere += string.IsNullOrEmpty(TxtJgmc.Text) ? "" : " and a.jgid=" + Prijgid;
                PriWhere += " and a.inssj >='" + DtpStart.Value.Date + "' and a.inssj<'" + DtpStop.Value.AddDays(1).Date + "'";
                if (CmbZt.SelectedIndex == 0)
                    PriWhere += " and a.zt=0";
                else if (CmbZt.SelectedIndex == 1)
                    PriWhere += " and a.zt=10 ";
                if (CmbRblx.SelectedIndex != 0)
                    PriWhere += " and a.rbdh like '"+CmbRblx.SelectedValue+"%'";
                if (cmblx.SelectedIndex == 1)
                {
                    PriWhere += " and d.lx='J' ";
                }
                else if (cmblx.SelectedIndex == 2)
                {
                    PriWhere += " and d.lx='Y' ";
                }

                //PriWhere += " order by xh";
                //VfmszbjkrbcxTableAdapter1.FillByWhere(DSzbjkrbcx1.Vfmszbjkrbcx, PriWhere, "select row_number() over(order by jgmc) as xh,zhmc,zh,je,dqmc,jgmc,zts from Vfmszbjkrbcx");
                 //ClsRWMSSQLDb.FillTable(DSCX ,"select row_number() over(order by jgmc) as xh,zhmc,zh,je,dqmc,jgmc,zts from " +
                 //"(SELECT   zhmc, zh, SUM(je) AS je, dqid, dqmc, jgid, jgmc,zt, " +
                 //"(CASE WHEN zt = 0 THEN '未审核' WHEN zt = 10 THEN '审核通过' END) AS zts " +
                 // "FROM      (SELECT   b.xh, b.zhmc, b.zh, (a.yck - a.zzje) AS je, c.dqid, c.dqmc, a.jgid, c.jgmc,a.inssj," +
                 //                 "a.zt " +
                 // "FROM      (select * from Tfmsrbpc where inssj between  '" + DtpStart.Value + "' and '" + DtpStop.Value + "') AS a LEFT JOIN " +
                 //                " Tfmsyhzh AS b ON a.jgid = b.jgid LEFT JOIN " +
                 //                     "jyjckj.dbo.vdqjigou AS c ON a.jgid = c.jgid " +
                 //" WHERE   b.yhlxid = 241 AND b.zhlxid = 1 "+PriWhere1+") AS g " +
                 //    "GROUP BY xh, zhmc, zh, dqid, dqmc, jgid, jgmc,zt) as a1 "+ PriWhere, ClsGlobals.CntStrTMS);
                ClsRWMSSQLDb.FillTable(DSCX, " SELECT Distinct zhmc,zh,(yck-zzje) as je,dqmc,jgmc,(CASE WHEN a.zt = 0 THEN '未审核' WHEN a.zt = 10 THEN '审核通过' END) AS zts,a.id FROM dbo.Tfmsrbpc a LEFT JOIN jyjckj.dbo.Vdqjigou b ON a.jgid=b.jgid LEFT JOIN dbo.Tfmsyhzh c ON a.jgid=c.jgid   LEFT JOIN dbo.tfmsrbmx as d on a.id=d.rbpcid  WHERE c.yhlxid=" + CmbYhlx.SelectedValue + " AND zhlxid=1 " + PriWhere + " ", ClsGlobals.CntStrTMS);
                if (DSCX.Rows.Count == 0)
                    ClsMsgBox.Ts("没有查询到相应信息，请核对查询条件！", ObjG.CustomMsgBox, this);
                else
                {
                    xuhao();
                }
            }
            catch
            {
                ClsMsgBox.Cw("查询信息失败！", ObjG.CustomMsgBox, this);
            }
        }
        #endregion

        #region 导出Excel
        private void button1_Click(object sender, EventArgs e)
        {
            if (DSCX.Rows.Count == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.Rows.Count > 60000)
            {
                ClsMsgBox.Ts("不允许导出大于60000条的数据!", (Session["ObjG"] as ClsG).CustomMsgBox, this);
                return;
            }
            int[] rowIndex = { 3 };
            ClsExcel.CreatExcel(Dgv, "总部缴款日报查询", ctrlDownLoad1, rowIndex);
        }
        #endregion 
        void xuhao()
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                row.Cells[DgvColTxtXh.Name].Value = row.Index + 1;
            }
        }

        private void BtnClear1_Click(object sender, EventArgs e)
        {
            this.TxtJgmc.Clear();
            Prijgid = "0";
        }
    }
}