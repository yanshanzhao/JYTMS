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

namespace FMS.CWGL.DHWTHCX
{
    public partial class FrmDHWTHKCX : UserControl
    {
        public FrmDHWTHKCX()
        {
            InitializeComponent();
        }

        #region
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private int PriJgid = 0;
        private string PriJgmc = "";
        private int PriYwquIndex = 0;

        private DateTime Pristartsj = DateTime.Now;
        private DateTime pristopsj = DateTime.Now;

        public void prepare()
        {

            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            ClsPopulateCmbDsS.PopuYd_cplx_qb(Cmbywqy, ClsGlobals.CntStrKj);
            this.Cmbywqy.SelectedIndex = 0;

            this.Txtsel.Text = ObjG.Jigou.mc;
            PriJgid = ObjG.Jigou.id;
        }
        #endregion
        #region 机构查询
        private void Btnsele_Click(object sender, EventArgs e)
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
                this.Txtsel.Text = f.PubDictAttrs["mc"];
                this.PriJgmc = Txtsel.Text;
                PriJgid = Convert.ToInt32(f.PubDictAttrs["id"]);
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.Txtsel.Text = "";
                PriJgid = 0;
                PriJgmc = "";
            }
        }
        #endregion

        #region 查询
        private void BtnSel_Click(object sender, EventArgs e)
        {
            if (PriJgid == 0)
            {
                ClsMsgBox.Ts("请选择查询机构", ObjG.CustomMsgBox, this);
                return;
            }
            string awhere = string.Format(" where sj >= '{0}' and sj <'{1}' and jgid  in (select ID from jyjckj.dbo.tjigou where parentLst like '%,{2},%')", DtpKssj.Value.Date, Dtpjssj.Value.Date.AddDays(1), PriJgid);
            if (Cmbywqy.SelectedIndex != 0)
                awhere = awhere + "and ywqy='" + Cmbywqy.Text + "'";
            string sql = "SELECT dqmc,jgmc,ywqy,bh,sum(yf) as yf,sum(bf) as bf,sum(hdf) as hdf,sum(jehj) as jehj FROM dbo.Vfmsdhwthcx " + awhere + "  GROUP BY  dqmc,jgmc,ywqy,bh ";
            DataTable dt = ClsRWMSSQLDb.GetDataTable(sql, ClsGlobals.CntStrTMS);
            DataRow dr = dt.NewRow();
            dr["dqmc"] = "合计";
            dr["yf"] = dt.Compute("sum(yf)", "");
            dr["bf"] = dt.Compute("sum(bf)", "");
            dr["hdf"] = dt.Compute("sum(hdf)", "");
            dr["jehj"] = dt.Compute("sum(jehj)", "");
            dt.Rows.Add(dr);
            this.Dgv.DataSource = dt;
            PriYwquIndex = Cmbywqy.SelectedIndex;
            Pristartsj = DtpKssj.Value;
            pristopsj = Dtpjssj.Value;
            if (Dgv.RowCount == 1)
            {
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
                return;
            }
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
            int[] Rows = new int[] { 4, 5, 6, 7 };
            ClsExcel.CreatExcel(Dgv, "连锁店到货未提货提付总运费", this.ctrlDownLoad2, Rows);
        }
        #endregion
    }
}
