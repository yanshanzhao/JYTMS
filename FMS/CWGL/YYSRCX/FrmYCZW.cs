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

namespace FMS.CWGL.YYSRCX
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
        public void Prepare(int aJgid, string aJgmc, string aBh, int aYwqyIndex, string aSj, DateTime aStartSj, DateTime aStopSj, string aFkfs)
        {
            PriJgmc = aJgmc;
            PriJgid = aJgid;
            this.TxtBJgmc.Text = PriJgmc;
            this.ObjG = VWGContext.Current.Session["ObjG"] as ClsG; 
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);

            CmbJglx.SelectedIndex = 0;
            CmbYwqy.SelectedIndex = aYwqyIndex;
            CmbJzlx.SelectedIndex = 0;
            DtpQrStart.Value = aStartSj;
            DtpQrStop.Value = aStopSj;
            //T.提付F.发付Z.发月结D.提月结S.第三方月结
            if (aFkfs == "F")
                aFkfs = "发付";
            else if (aFkfs == "H")
                aFkfs = "回付";
            else if (aFkfs == "T")
                aFkfs = "提付";
            else if (aFkfs == "Z")
                aFkfs = "发月结";
            else if (aFkfs == "D")
                aFkfs = "提月结";
            else
                aFkfs = "第三方月结";
            this.VfmsyysrcxmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            string awhere = " where bh='" + aBh + "' and fkfs='" + aFkfs + "'";
            this.VfmsyysrcxmxTableAdapter1.FillByWhere2(this.DSYYSRCX1.Vfmsyysrcxmx, awhere);
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
        #region 查询
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string awhere = " where  jzsj  >= '" + DtpQrStart.Value.Date + "' and jzsj < '" + DtpQrStop.Value.AddDays(1).Date + "'";
            if (CmbJglx.SelectedIndex == 2)
                awhere = awhere + "  and ckjg in(select mc from jyjckj.dbo.tjigou where parentLst like '%," + PriJgid + ",%')";
            else
                awhere = awhere + "  and jzlg in(select mc from jyjckj.dbo.tjigou where parentLst like '%," + PriJgid + ",%')";
            if (CmbJzlx.SelectedIndex > 0)
                awhere = awhere + "  and  jzlx='" + CmbJzlx.Text + "' ";
            if (CmbYwqy.SelectedIndex > 0)
                awhere = awhere + "  and  ywqy='" + CmbYwqy.Text + "' ";
            this.VfmsyysrcxmxTableAdapter1.FillByWhere2(this.DSYYSRCX1.Vfmsyysrcxmx, awhere);
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
    }
}