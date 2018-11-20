#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Linq;
using JY.Pri;
using JY.Pub;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Configuration;
using FMS.CWGL.YSKCX2;
using FMS.SeleFrm;
#endregion

namespace FMS.CWGL.YSKCX2
{
    public partial class FrmYSKCX : UserControl
    {
        public FrmYSKCX()
        {
            InitializeComponent();
        }
        #region
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private int PriJgid = 0;
        private string PriJgmc = "";
        private int PriYwquIndex = 0;
        private int PriSfycIndex = 0;
        private DateTime Pristartsj = DateTime.Now;
        private DateTime pristopsj = DateTime.Now;

        public void prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG; 

            ClsPopulateCmbDsS.PopuYd_cplx_qb(Cmbywqy, ClsGlobals.CntStrKj);

            this.Cmbywqy.SelectedIndex = 0;
            this.Cmbsffs.SelectedIndex = 0;
            this.Txtsel.Text = ObjG.Jigou.mc;
            PriJgid = ObjG.Jigou.id;
            //ClsPopulateCmbDsS.PopuYd_ywxz(CmbYwxz, ClsGlobals.CntStrKj);
        }
        #endregion

        #region   机构查询
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
        #region  查询
        private void BtnSel_Click(object sender, EventArgs e)
        {
            if (PriJgid == 0)
            {
                ClsMsgBox.Ts("请选择查询机构", ObjG.CustomMsgBox, this);
                return;
            }
            string awhere = string.Format(" where inssj >= '{0}' and inssj <'{1}' and EXISTS (select ID from jyjckj.dbo.tjigou where parentLst like '%,{2},%' and id=jsjgid)", DtpKssj.Value.Date, Dtpjssj.Value.Date.AddDays(1), PriJgid);
            if (Cmbywqy.SelectedIndex != 0)
                awhere = awhere + " and ywqys='" + Cmbywqy.Text + "'";
            if (Cmbsffs.SelectedIndex != 0)
                awhere = awhere + " and jzlx='" + Cmbsffs.Text + "'";
            
            string sql = " SELECT dqmc,jgmc,ywqys,sum(fhxf) AS fhxf,sum(bf) as bf,SUM(jezj)  jezj FROM dbo.vfmsyskcx3 " + awhere + "  GROUP BY  dqmc,jgmc,ywqys ";
            DataTable dt = ClsRWMSSQLDb.GetDataTable(sql, ClsGlobals.CntStrTMS);

            DataRow dr = dt.NewRow();
            dr["dqmc"] = "合计";
            dr["fhxf"] = dt.Compute("sum(fhxf)", "");
            dr["bf"] = dt.Compute("sum(bf)", "");
            dr["jezj"] = dt.Compute("sum(jezj)", "");
            dt.Rows.Add(dr);
            this.Dgv.DataSource = dt;

            PriYwquIndex = Cmbywqy.SelectedIndex;

            PriSfycIndex = Cmbsffs.SelectedIndex;
            Pristartsj = DtpKssj.Value;
            pristopsj = Dtpjssj.Value;
            if (Dgv.RowCount == 1)
            {
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);

                return;
            }

        }
        #endregion

        #region   导出
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
            int[] Rows = new int[] { 4, 5, 6 };
            ClsExcel.CreatExcel(Dgv, "应收款的查询", this.ctrlDownLoad2, Rows);
        }
        #endregion




    }
}