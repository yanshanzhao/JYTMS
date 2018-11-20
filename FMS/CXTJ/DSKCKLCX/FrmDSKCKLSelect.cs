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
#endregion

namespace FMS.CXTJ.DSKCKLCX
{
    public partial class FrmDSKCKLSelect : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private int PriJgid = 0;
        private string PriWhere1;
        private string PriWhere2;
        private string PriCmdText;
        private FrmDskCklMx f;
        private DataTable PriDt;
        #endregion

        public FrmDSKCKLSelect()
        {
            InitializeComponent();
        }
        #region 初始化数据
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            ClsPopulateCmbDsS.PopuYear(CmbYear);
            CmbYear.SelectedIndex = 2;
            this.CmbMonth.SelectedIndex = DateTime.Now.AddMonths(-1).Month;
            //DataTable dtjgmc = ClsRWMSSQLDb.GetDataTable(" select id as dqid,mc as dqmc from tjigou  where level=3 order by mc desc    ", ClsGlobals.CntStrKj);
            //DataRow dr = dtjgmc.NewRow();
            //dr["dqid"] = 0;
            //dr["dqmc"] = "全部";
            //dtjgmc.Rows.InsertAt(dr, 0);
            //ClsPopulateCmbDsS.PopuByTb(this.CmbDqmc, dtjgmc, "dqid", "dqmc");
            //this.CmbDqmc.SelectedIndex = 0;
            PnlMain.Controls.Add(PnlJgcx);
            PnlJgcx.Visible = false;
        }
        #endregion
        #region 获取查询机构信息
        private void TxtJg_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            PriDt = ClsRWMSSQLDb.GetDataTable(" select id as dqid,mc as dqmc from tjigou  where level=3 and ( pym like '%" + TxtJg.Text.Trim() + "%' or mc like '%" + TxtJg.Text.Trim() + "%') order by dqid desc    ", ClsGlobals.CntStrKj);
            LstV.DataSource = PriDt;
            LstV.Columns[0].Visible = false;
            LstV.Columns[1].Text = "大区名称";
            LstV.Columns[1].Width = 200;
            PnlJgcx.Visible = true;
            LstV.Focus();
        }
        private void LstV_KeyUp(object objSender, KeyEventArgs objArgs)
        {
            if (Convert.ToInt32(objArgs.KeyCode) == 8)
            {
                if (TxtJg.Text.Trim().Length != 0)
                    TxtJg.Text = TxtJg.Text.Trim().Substring(0, TxtJg.Text.Trim().Length - 1);
                TxtJg.SelectionStart = TxtJg.Text.Length;
                TxtJg.Focus();
                PnlJgcx.Visible = false;
                PriDt.Dispose();
            }
            if (LstV.Items.Count > 0)
            {
                if (Convert.ToInt32(objArgs.KeyCode) == 13)
                {
                    this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[1].Text;
                    PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[0].Text);
                    this.PnlJgcx.Visible = false;
                    PriDt.Dispose();
                    TxtJg.Focus();
                }
            }
        }
        private void LstV_LostFocus(object sender, EventArgs e)
        {
            PnlJgcx.Visible = false;
        }
        private void LstV_DoubleClick(object sender, EventArgs e)
        {
            this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[1].Text;
            PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[0].Text);
            this.PnlJgcx.Visible = false;
            TxtJg.Focus();
            PriDt.Dispose();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtJgmc.Text = "";
            PriJgid = 0;
            //PriDt.Dispose();
        }
        
        #endregion

        #region 查询
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet1.Tables[0].Clear();
                PriCmdText = "";
                PriWhere1 =PriWhere2 = "  ";
                int month = Convert.ToInt32(CmbMonth.Text);
                int year = Convert.ToInt32(CmbYear.Text);
                PriWhere1 += "  year=" + year + " and month=" + month;
                PriWhere1 += !string.IsNullOrEmpty(TxtJgmc.Text.Trim())? " and b.dqid=" + PriJgid : "";
               
                if (month == 1)
                {
                    year = year - 1;
                    month = 12;
                }
                else
                    month = month - 1;
                PriWhere2 += "  year=" + year + " and month=" + month;
                //PriCmdText = "select b.dqid as jgid,b.dqmc as jgmc,sum(a.ljwc) as ljwc,sum(a.yc) as byyc,sum(sc) as bysc, " +
                //    "(convert(nvarchar(20),convert(decimal(15,2),convert(decimal(15,4),isnull(((sum(sc))*1.0)/nullif((sum(a.yc)+sum(a.ljwc)),0),0))*100))+'%') as jsl " +
                //    ",'详细信息' as xx from tfmsdskckl as a left join " +
                //    "(select a1.id as jgid,a1.mc as jgmc, (CASE WHEN a1.level=5  THEN a3.id ELSE a2.id   END )   as dqid,(CASE WHEN a1.level=5  THEN  a3.mc ELSE  a2.mc   END )     as dqmc   from jyjckj.dbo.tjigou as a1 " +
                //    " left join jyjckj.dbo.tjigou as a2 on a1.parentid=a2.id left join jyjckj.dbo.tjigou as a3 on a2.parentid=a3.id " +
                //    " where a1.level in (4,5)) as b on a.jgid=b.jgid  where " + PriWhere + " group by dqid,dqmc";
                PriCmdText = "SELECT  C1.jgid,C1.jgmc,ISNULL(C2.ljwc,0.00) AS ljwc,C1.byyc,C1.bysc,(convert(nvarchar(20),convert(decimal(15,2),convert(decimal(15,4),isnull(((C1.bysc)*1.0)/NULLIF((ISNULL(C1.byyc,0.00)+ISNULL(C2.ljwc,0.00)),0),0))*100))+'%')  as jsl,'详细信息' AS xx  FROM (select b.dqid as jgid,b.dqmc as jgmc,sum(a.yc) as byyc,sum(sc) as bysc  from tfmsdskckl  as a left join jyjckj.dbo.Vdqjigou b ON a.jgid=b.jgid where  " + PriWhere1 + " group by dqid,dqmc )  AS C1 LEFT JOIN  (select b.dqid,sum(a.ljwc) as ljwc from tfmsdskckl as a left JOIN jyjckj.dbo.Vdqjigou b on a.jgid=b.jgid  where " + PriWhere2 + " group by dqid,dqmc  ) AS C2 ON C1.jgid=C2.dqid ";
                ClsRWMSSQLDb.FillTable(DataSet1.Tables[0], PriCmdText, ClsGlobals.CntStrTMS);
                if (DataSet1.Tables[0].Rows.Count == 0)
                    ClsMsgBox.Ts("没有查询到相应信息！", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("查询信息失败！ ",ex,ObjG.CustomMsgBox,this);
            }
            
        }
        #endregion

        #region  详细
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv.Columns[e.ColumnIndex].Name.Equals("DgvLnkXx"))
                {
                    f = new FrmDskCklMx();
                    f.Prepare(Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtJgid"].Value), 
                        Dgv.Rows[e.RowIndex].Cells["DgvColTxtJgmc"].Value.ToString(), Dgv.Rows[e.RowIndex].Cells["DgvColTxtJsl"].Value.ToString(),PriWhere1,PriWhere2);
                    f.ShowDialog();
                }
            }
            catch (Exception)
            {
                return;
            }
            
        }
        #endregion

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count <= 0)
            {
                ClsMsgBox.Ts("没有需要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(Dgv, "代收款存款率", ctrlDownLoad2,new int[]{1,2,3});
        }







    }
}