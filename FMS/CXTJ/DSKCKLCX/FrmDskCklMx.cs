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

namespace FMS.CXTJ.DSKCKLCX
{
    public partial class FrmDskCklMx : Form
    {
        #region 成员变量
        private ClsG ObjG;
        private string PriCmdText;
        #endregion
        public FrmDskCklMx()
        {
            InitializeComponent();
        }
        public void Prepare(int aDqid,string aDqmc,string aJsl,string aWhere1,string aWhere2)
        {
            try
            {
                ObjG = Session["ObjG"] as ClsG;
                LblDqmc.Text = aDqmc;
                LblJsl.Text = aJsl;
                //PriCmdText = "select a.jgid,b.jgmc,sum(a.ljwc) as ljwc,sum(a.yc) as byyc,sum(sc) as bysc, " +
                //    "(convert(nvarchar(20),convert(decimal(15,2),convert(decimal(15,4),isnull(((sum(sc))*1.0)/nullif((sum(a.yc)+sum(a.ljwc)),0),0))*100))+'%') as jsl " +
                //    ",'详细信息' as xx from tfmsdskckl as a left join " +
                //    "(select a1.id as jgid,a1.mc as jgmc,a3.id as dqid,a3.mc as dqmc from jyjckj.dbo.tjigou as a1 " +
                //    " left join jyjckj.dbo.tjigou as a2 on a1.parentid=a2.id left join jyjckj.dbo.tjigou as a3 on a2.parentid=a3.id " +
                //    " where a1.level=5) as b on a.jgid=b.jgid  where " + aWhere + " and b.dqid=" + aDqid + " group by a.jgid,b.jgmc";
                PriCmdText = " SELECT C1.jgid,C1.jgmc,ISNULL(c2.ljwc,0.00) AS ljwc,C1.byyc,C1.bysc," +
                    " (convert(nvarchar(20),convert(decimal(15,2),convert(decimal(15,4),isnull(((c1.bysc)*1.0)/nullif((ISNULL(C1.byyc,0.00)+ISNULL(c2.ljwc,0.00)),0),0))*100))+'%')  AS jsl," +
                    " '详细信息' AS xx  FROM ( select a.jgid,b.jgmc,sum(a.yc) as byyc,sum(sc) as bysc  from tfmsdskckl  as a left join jyjckj.dbo.Vdqjigou as b on a.jgid=b.jgid  " +
                    " where " + aWhere1 + " and b.dqid=" + aDqid + " group by a.jgid,b.jgmc)  AS  C1 LEFT JOIN ( select a.jgid,sum(a.ljwc) as ljwc from tfmsdskckl  as a left join jyjckj.dbo.Vdqjigou as b on a.jgid=b.jgid  " +
                    " where " + aWhere2 + " and b.dqid=" + aDqid + " group by a.jgid) AS c2 ON  C1.jgid=c2.jgid";
 
                ClsRWMSSQLDb.FillTable(DataSet1.Tables[0], PriCmdText, ClsGlobals.CntStrTMS);
                LblLjwc.Text = DataSet1.Tables[0].Compute("sum(ljwc)", "").ToString();
                LblByyc.Text = DataSet1.Tables[0].Compute(" sum(byyc)","").ToString();
                LblBysc.Text = DataSet1.Tables[0].Compute("sum(bysc)","").ToString();
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("查询存款率明细失败！",ex,ObjG.CustomMsgBox,this);
            }
          
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count <= 0)
            {
                ClsMsgBox.Ts("没有需要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(Dgv, "代收款存款率明细", ctrlDownLoad2, new int[] { 1, 2, 3 });
        }
    }
}