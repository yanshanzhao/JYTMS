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
using FMS.SeleFrm;
#endregion

namespace FMS.CWGL.YSKCX
{
    public partial class FrmYCZW : Form
    {
        #region 成员变量
        private ClsG ObjG;
        private string PriJgmc = "";
        private int PriJgid = 0;
        #endregion
        public FrmYCZW()
        {
            InitializeComponent();
        }
        public void Prepare(int aJgid, string aJgmc, int aid, int aYwqyIndex, int aJzlxIndex, DateTime aStartSj, DateTime aStopSj, int aSfycIndex)
        {
            PriJgmc = aJgmc;
            PriJgid = aJgid;
            this.TxtBJgmc.Text = PriJgmc;
            this.ObjG = VWGContext.Current.Session["ObjG"] as ClsG; 
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);

            CmbJglx.SelectedIndex = 2;
            CmbYwqy.SelectedIndex = aYwqyIndex;
            CmbJzlx.SelectedIndex = aJzlxIndex;
            DtpQrStart.Value = aStartSj;
            DtpQrStop.Value = aStopSj;
            CmbSfyc.SelectedIndex = aSfycIndex;
            this.VfmsyskzwTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.VfmsyskzwTableAdapter1.FillByWhere1(DSYSKCX1.Vfmsyskzw, " where ydid=" + aid);
        }
        #region 机构查询
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
        #region 查询信息
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (PriJgid == 0)
            {
                ClsMsgBox.Ts("请选择查询的机构！", ObjG.CustomMsgBox, this);
                return;
            }
            string aWhere = " where    inssj >='" + DtpQrStart.Value + "' and inssj<'"+DtpQrStop.Value.AddDays(1).Date+"'";
            if (CmbYwqy.SelectedIndex != 0)
                aWhere = aWhere + " and ywqy='" + CmbYwqy.Text + "'";
            if (CmbSfyc.SelectedIndex != 0)
                aWhere = aWhere + " and yc='" + CmbSfyc.Text + "'";
            if (CmbJzlx.SelectedIndex != 0)
                aWhere = aWhere + " and jzlx='" + CmbJzlx.Text + "'";
            if (CmbJglx.SelectedIndex == 2)
                aWhere = aWhere + " and ckjgid in( select ID from jyjckj.dbo.tjigou where parentLst like '%," + PriJgid + ",%')";
            else
                aWhere = aWhere + " and sljgid in( select ID from jyjckj.dbo.tjigou where parentLst like '%," + PriJgid + ",%')";
            this.VfmsyskzwTableAdapter1.FillByWhere1(DSYSKCX1.Vfmsyskzw, aWhere);
            if (Dgv.RowCount == 0)
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
        }
        #endregion

        #region 关闭
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (Dgv.Rows.Count > 60000)
            {
                ClsMsgBox.Ts("不允许导出大于60000条的数据!", (Session["ObjG"] as ClsG).CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 7, 8, 9 };
            ClsExcel.CreatExcel(Dgv, "应收款查询", this.ctrlDownLoad1, Rows);
        }

        #endregion

    }
}