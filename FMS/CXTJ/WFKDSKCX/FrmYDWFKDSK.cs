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
using JY.Pub;
using JY.Pri;
#endregion
namespace FMS.CXTJ.WFKDSKCX
{
    public partial class FrmYDWFKDSK : Form
    {
        #region ��Ա����
        private ClsG ObjG;
        private string PriCplx;
        private string PriCplxStr;
        #endregion
        public FrmYDWFKDSK()
        {
            InitializeComponent();
        }
        public void Prepare(string ajgmc, int ajgid, decimal azje, int adays, int alx1, int alx2, string aCplx, string aCplxStr)
        {
            ObjG = Session["ObjG"] as ClsG;
            PriCplx = aCplx;
            PriCplxStr = aCplxStr;
            this.AcceptButton = BtnExl;
            this.LblJgmc.Text = this.LblJgmc.Text + ": " + ajgmc;
            this.LblZj.Text = this.LblZj.Text + ": " + azje.ToString() + "Ԫ";
            string SQLstr = "SELECT dqmc, bh, sljgmc, slsj, qsd, mdd, qsjgmc, fhf, shlxr, ddsj,(case when (yqts+" + adays + ")<=1 then 0 else (yqts+" + adays + "-1) end) as yqts, lx, dsk, jgid, inssj,fkfs,sjzt,sjsj FROM dbo.Vfmswfkdskcx where yqts+" + adays + ">=0 and jgid in (select id from jyjckj.dbo.tjigou where parentlst like '%," + ajgid+",%')";
            if (alx1 == 0)
            {
                if (alx2 == 1)
                    SQLstr = SQLstr + " and lx='ת��' ";
                else
                    SQLstr = SQLstr + " and lx='��ת��' ";
            }
            if (PriCplx!="QB")
                SQLstr = SQLstr + " and cplx='" + PriCplxStr + "' ";
            this.Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(SQLstr, ClsGlobals.CntStrTMS);
        }
        public void Prepare(int adays, int ajgid, List<int> aJgids, int alx1, int alx2)
        { 
            this.LblJgmc.Visible = false;
            this.LblZj.Visible = false;
            this.BtnExl.Visible = false;
            this.BtnEls1.Visible = true;
            this.AcceptButton = BtnEls1;
            string SQLstr="SELECT dqmc, bh, sljgmc, slsj, qsd, mdd, qsjgmc, fhf, shlxr, ddsj, yqts+" + adays + " as yqts, lx, dsk, jgid, inssj FROM dbo.Vfmswfkdskcx where yqts+" + adays + ">=0  and jgid in (" + string.Join(",", aJgids) + ")";
             if (alx1 == 0)
            {
                if (alx2 == 1)
                    SQLstr = SQLstr + " and lx='ת��' ";
                else
                    SQLstr = SQLstr + " and lx='��ת��' ";
            }
             if (PriCplx != "QB")
                 SQLstr = SQLstr + " and cplx='" + PriCplxStr + "' ";
             this.Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(SQLstr, ClsGlobals.CntStrTMS);
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            GetExl();
        }
        private void GetExl()
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ!", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 10,12 };
            ClsExcel.CreatExcel(Dgv, "����δ���������Ϣ", this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, "����δ���������Ϣ", this.ctrlDownLoad1);
        }
        private void BtnEls1_Click(object sender, EventArgs e)
        {
            GetExl();
        }
    }
}