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
using FMS.SeleFrm;
using JY.Pub;
using JY.Pri;

#endregion

namespace FMS.CWGL.GLSDWNWYYSR
{
    public partial class FrmGLSDWNWYYSRXX : Form
    {
        #region 成员变量
        private ClsG ObjG;
        private string PriJgmc = "";
        private int PriJgid = 0;
        #endregion

        public FrmGLSDWNWYYSRXX()
        {
            InitializeComponent();
        }

        #region 初始化页面 Prepare()
        public void Prepare(string adqid, string adqmc, string acpmc, DateTime aStartSj, DateTime aStopSj, int aCplx, int aYwxz, int aJyxz)
        {
            PriJgmc = adqmc;
            PriJgid = Convert.ToInt32(adqid);
            DSGLSDWNWYYSR.EnforceConstraints = false;
            this.TxtBJgmc.Text = PriJgmc;
            this.TxtBJgmc.Tag = PriJgid;
            this.ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbCplx, ClsGlobals.CntStrKj);
            ClsPopulateCmbDsS.PopuYd_ywxz(CmbYwxz, ClsGlobals.CntStrKj);
            CmbCplx.Text = acpmc;
            CmbYwxz.SelectedIndex = aYwxz;
            CmbJyxz.SelectedIndex = aJyxz;
            DtpQrStart.Value = aStartSj;
            DtpQrStop.Value = aStopSj;
            string aWhere = " where  inssj  >= '" + DtpQrStart.Value.Date + "' and inssj < '" + DtpQrStop.Value.AddDays(1).Date + "'";
            if (PriJgmc.Length > 0)
                aWhere += " and sljgid in (SELECT id FROM jyjckj.dbo.tjigou WHERE parentLst LIKE '%," + adqid + ",%') and cplxmc='" + acpmc + "'";
            if (CmbYwxz.SelectedIndex != 0)
                aWhere = aWhere + " and ywxz = '" + CmbYwxz.Text.ToString() + "'";
            if (CmbJyxz.SelectedIndex == 1)
            {
                aWhere += " and jyxz='Z' ";
            }
            else if (CmbJyxz.SelectedIndex == 2)
            {
                aWhere += " and jyxz='J' ";
            }
            else if (CmbJyxz.SelectedIndex == 3)
            {
                aWhere += " and jyxz ='H' ";
            }
            this.tglsdwnwyysrcxTableAdapter.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.tglsdwnwyysrcxTableAdapter.FillByWhere(this.DSGLSDWNWYYSR.tglsdwnwyysrcx, aWhere);
        }
        #endregion

        #region 机构查询 BtnJg_Click(object sender, EventArgs e)
        private void BtnJg_Click(object sender, EventArgs e)
        {
            FrmSelectJg f = new FrmSelectJg();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }

        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtBJgmc.Text = f.PubDictAttrs["mc"];
                this.PriJgmc = TxtBJgmc.Text;
                PriJgid = Convert.ToInt32(f.PubDictAttrs["id"]);
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtBJgmc.Text = "";
                PriJgid = 0;
                PriJgmc = "";
            }
        }
        #endregion

        #region 查询 BtnSave_Click(object sender, EventArgs e)
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string awhere = " where  inssj  >= '" + DtpQrStart.Value.Date + "' and inssj < '" + DtpQrStop.Value.AddDays(1).Date + "'";
            //if (CmbJglx.SelectedIndex == 2)
            //    awhere = awhere + "  and ckjg in(select mc from jyjckj.dbo.tjigou where parentLst like '%," + PriJgid + ",%')";
            //else
            if (PriJgmc.Length > 0)
                awhere = awhere + "  and sljgid in(select id from jyjckj.dbo.tjigou where parentLst like '%," + PriJgid + ",%')";
            if (CmbYwxz.SelectedIndex != 0)
                awhere = awhere + " and ywxz = '" + CmbYwxz.Text.ToString() + "'";
            if (CmbJyxz.SelectedIndex == 1)
            {
                awhere += " and jyxz='Z' ";
            }
            else if (CmbJyxz.SelectedIndex == 2)
            {
                awhere += " and jyxz='J' ";
            }
            else if (CmbJyxz.SelectedIndex == 3)
            {
                awhere += " and jyxz ='H' ";
            }
            if (CmbCplx.SelectedIndex > 0)
                awhere = awhere + "  and  cplxmc='" + CmbCplx.Text + "' ";//产品类型
            //if (CmbYwxz.SelectedIndex > 0)
            //    awhere = awhere + "  and  ywxz='" + CmbYwxz.Text + "' ";//业务性质  
            this.tglsdwnwyysrcxTableAdapter.FillByWhere(this.DSGLSDWNWYYSR.tglsdwnwyysrcx, awhere);
            if (Dgv.RowCount == 0)
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
        }
        #endregion

        #region 关闭 BtnClose_Click(object sender, EventArgs e)
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "各连锁店网内外营业收入", this.ctrlDownLoad1, new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55 });
        }

    }
}
