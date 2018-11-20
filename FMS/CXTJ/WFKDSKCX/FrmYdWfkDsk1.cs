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

namespace FMS.CXTJ.WFKDSKCX
{
    public partial class FrmYdWfkDsk1 : Form
    {
        #region 成员变量
        private ClsG ObjG;
        #endregion
        public FrmYdWfkDsk1()
        {
            InitializeComponent();
        }
        private DateTime PriStop;
        public void Prepare(string ajgmc, int ajgid, decimal azje, int adays, int alx1, int alx2,int afklx,DateTime asjXx,DateTime asj)
        {
            PriStop = asj;
            string SQLstr = "";
            ObjG = Session["ObjG"] as ClsG;
            this.AcceptButton = BtnExl;
            this.LblJgmc.Text = this.LblJgmc.Text + ": " + ajgmc;
            this.LblZj.Text = this.LblZj.Text + ": " + azje.ToString() + "元";
            if (afklx == 1)
            {
                SQLstr = "SELECT dqmc, bh, sljgmc, slsj, qsd, mdd, qsjgmc, fhf, shlxr, ddsj,(case when (yqts+" + adays + ")<=1 then 0 else (yqts+" + adays + "-1) end) as yqts, lx, dsk, jgid, inssj,fkfs,sjzt,sjsj FROM dbo.Vfmswfkdskcx where yqts+" + adays + ">=0 and jgid in (select id from jyjckj.dbo.tjigou where parentlst like '%," + ajgid + ",%' and fkfs='POS' )";
            }
            else if (afklx == 2)
            {
                SQLstr = "SELECT dqmc, bh, sljgmc, slsj, qsd, mdd, qsjgmc, fhf, shlxr, ddsj,(case WHEN DATEDIFF(hh,dateadd(hh,15,CONVERT(varchar(40),inssj, 23)),inssj)>0  AND DATEDIFF(day,inssj,'" + PriStop + "')<=1 then 0 WHEN DATEDIFF(hh,dateadd(hh,15,CONVERT(varchar(40),inssj, 23)),inssj)>0  AND DATEDIFF(day,inssj,'" + PriStop + "')> 1 then DATEDIFF(day,inssj,'" + PriStop + "')-1 WHEN DATEDIFF(hh,dateadd(hh,15,CONVERT(varchar(40),inssj, 23)),inssj)<=0 AND DATEDIFF(day,inssj,'" + PriStop + "')<=1 THEN 1 WHEN DATEDIFF(hh,dateadd(hh,15,CONVERT(varchar(40),inssj, 23)),inssj)<=0 AND DATEDIFF(day,inssj,'" + PriStop + "')> 1 THEN DATEDIFF(day,inssj,'" + PriStop + "') end) as yqts, lx, dsk, jgid, inssj,fkfs,sjzt,sjsj FROM dbo.Vfmswfkdskcx where yqts+" + adays + ">=0 and jgid in (select id from jyjckj.dbo.tjigou where parentlst like '%," + ajgid + ",%' and fkfs='现金' )";
            }
            else 
            {
                SQLstr = "SELECT dqmc, bh, sljgmc, slsj, qsd, mdd, qsjgmc, fhf, shlxr, ddsj,(case when (yqts+" + adays + ")<=1 then 0 else (yqts+" + adays + "-1) end) as yqts, lx, dsk, jgid, inssj,fkfs,sjzt,sjsj FROM dbo.Vfmswfkdskcx where yqts+" + adays + ">=0 and jgid in (select id from jyjckj.dbo.tjigou where parentlst like '%," + ajgid + ",%' and fkfs='POS') UNION ALL SELECT dqmc, bh, sljgmc, slsj, qsd, mdd, qsjgmc, fhf, shlxr, ddsj,(case WHEN DATEDIFF(hh,dateadd(hh,15,CONVERT(varchar(40),inssj, 23)),inssj)>0  AND DATEDIFF(day,inssj,'" + PriStop + "')<=1 then 0 WHEN DATEDIFF(hh,dateadd(hh,15,CONVERT(varchar(40),inssj, 23)),inssj)>0  AND DATEDIFF(day,inssj,'" + PriStop + "')> 1 then DATEDIFF(day,inssj,'" + PriStop + "')-1 WHEN DATEDIFF(hh,dateadd(hh,15,CONVERT(varchar(40),inssj, 23)),inssj)<=0 AND DATEDIFF(day,inssj,'" + PriStop + "')<=1 THEN 1 WHEN DATEDIFF(hh,dateadd(hh,15,CONVERT(varchar(40),inssj, 23)),inssj)<=0 AND DATEDIFF(day,inssj,'" + PriStop + "')> 1 THEN DATEDIFF(day,inssj,'" + PriStop + "') end) as yqts, lx, dsk, jgid, inssj,fkfs,sjzt,sjsj FROM dbo.Vfmswfkdskcx where yqts+" + adays + ">=0 and jgid in (select id from jyjckj.dbo.tjigou where parentlst like '%," + ajgid + ",%' and fkfs='现金' ) ";
            }
            
            if (alx1 == 0)
            {
                if (alx2 == 1)
                    SQLstr = SQLstr + " and lx='转单' ";
                else
                    SQLstr = SQLstr + " and lx='非转单' ";
            }
            this.Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(SQLstr, ClsGlobals.CntStrTMS);
        }
        //没改
        //public void Prepare(int adays, int ajgid, List<int> aJgids, int alx1, int alx2)
        //{
        //    this.LblJgmc.Visible = false;
        //    this.LblZj.Visible = false;
        //    this.BtnExl.Visible = false;
        //    this.BtnEls1.Visible = true;
        //    this.AcceptButton = BtnEls1;
        //    string SQLstr = "SELECT dqmc, bh, sljgmc, slsj, qsd, mdd, qsjgmc, fhf, shlxr, ddsj, yqts+" + adays + " as yqts, lx, dsk, jgid, inssj FROM dbo.Vfmswfkdskcx where yqts+" + adays + ">=0  and jgid in (" + string.Join(",", aJgids) + ")";
        //    if (alx1 == 0)
        //    {
        //        if (alx2 == 1)
        //            SQLstr = SQLstr + " and lx='转单' ";
        //        else
        //            SQLstr = SQLstr + " and lx='非转单' ";
        //    }
        //    this.Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(SQLstr, ClsGlobals.CntStrTMS);
        //}
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息!", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 10, 12 };
            ClsExcel.CreatExcel(Dgv, "机构未返款代收信息", this.ctrlDownLoad1, Rows);
        }
    }
}