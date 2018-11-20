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
using FMS.CWGL.YSKCX;
using FMS.SeleFrm;
using FMS.SelectFrm;
#endregion

namespace FMS.CWGL.DHYYECX
{
    public partial class FrmAJGCXDHYYE : UserControl
    {
        public FrmAJGCXDHYYE()
        {
            InitializeComponent();
        }
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private int PriJgid = 0;

        private string PriJgmc = "";
        private int PriYwqyIndex = 0;
        private int PriFkfsIndex = 0;
        private int PriJzjgIndex = 0;
        private DateTime PriStartSj = DateTime.Now;
        private DateTime PriStopSj = DateTime.Now;


        public void Prepare()
        {

            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            this.CmbYwqy.SelectedIndex = 0;
            this.Cmbfkfs.SelectedIndex = 0;

            this.TxtJg.Text = ObjG.Jigou.mc;
            PriJgid = ObjG.Jigou.id;

            ClsPopulateCmbDsS.PopuYd_ywxz(CmbYwxz, ClsGlobals.CntStrKj);

            DataTable dtDqxx = ClsRWMSSQLDb.GetDataTable(" SELECT 0 AS dqid,'--全部--' dqmc,'' sybid  UNION SELECT dqid,dqmc,sybid  FROM jyjckj.dbo.Vdqjigou   WHERE  dqid<>jgid GROUP BY dqid,dqmc,sybid ORDER BY sybid,dqid ", ClsGlobals.CntStrKj);
            Txtdq.Tag = "0";
        }

        private void BtnClear1_Click(object sender, EventArgs e)
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
                this.TxtJg.Text = f.PubDictAttrs["mc"];
                this.PriJgmc = TxtJg.Text;
                PriJgid = Convert.ToInt32(f.PubDictAttrs["id"]);
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtJg.Text = "";
                PriJgid = 0;
                PriJgmc = "";
            }

        }



        private void LSTV_LostFocus(object sender, EventArgs e)
        {

            PriJgDt.Dispose();
        }
        //查询
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (PriJgid == 0)
            {
                ClsMsgBox.Ts("请选择查询的机构！", ObjG.CustomMsgBox, this);
                return;
            }
            LblHj.Text = "合计：0元";
            string aWhere = string.Format(" where inssj >= '{0}' and inssj <'{1}' and EXISTS (SELECT id FROM jyjckj.dbo.tjigou WHERE parentlst like '%,{2},%' AND id=qsjgid)", DtpQrStart.Value.Date, DtpQrStop.Value.Date.AddDays(1), PriJgid);
            if (CmbYwqy.SelectedIndex != 0)
                aWhere = aWhere + " and ywqy='" + CmbYwqy.Text + "'";
            if (Cmbfkfs.SelectedIndex != 0)
                aWhere = aWhere + " and jzlx='" + Cmbfkfs.Text + "'";
            if (Txtdq.Tag.ToString() != "0")
                aWhere = aWhere + " and qsdqid=" + Txtdq.Tag.ToString();

            aWhere += "  group by dqmc,mc,ywqy,ywxzs ";
            DataTable dt = new DataTable();
            dt = ClsRWMSSQLDb.GetDataTable(" SELECT dqmc,mc,ywqy,sum(fhxf) as fhxf,sum(bf) bf,sum(jezj) jezj,ywxzs FROM Vfmsdhyyecx " + aWhere, ClsGlobals.CntStrTMS);
            //DataRow dr = dt.NewRow();
            //dr["fhxf"] = dt.Compute("sum(fhxf)", "");
            //dr["bf"] = dt.Compute("sum(bf)", "");
            //dr["jezj"] = dt.Compute("sum(jezj)", "");
            //dt.Rows.Add(dr);
            Dgv.DataSource = dt;
            PriYwqyIndex = CmbYwqy.SelectedIndex;
            PriFkfsIndex = Cmbfkfs.SelectedIndex;
            PriStartSj = DtpQrStart.Value;
            PriStopSj = DtpQrStop.Value;
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
                LblHj.Text = "合计：0.00";
                return;
            }
            LblHj.Text = "合计：" + dt.AsEnumerable().Sum(s => s.Field<decimal>("jezj")) + "元";
        }
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        //导出
        private void BtnDaoChu_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.RowCount > 6000)
            {
                ClsMsgBox.Ts("数据过大超过6000，无法导出！", ObjG.CustomMsgBox, this);

            }
            int[] Rows = new int[] { 4, 5, 6 };
            ClsExcel.CreatExcel(this.Dgv, "到货营业额查询", ctrlDownLoad1, Rows);


        }

        private void Btndq_Click(object sender, EventArgs e)
        {
            FrmSelectDq f = new FrmSelectDq();
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(fsl_FormClosing);
        }
        void fsl_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FrmSelectDq f = sender as FrmSelectDq)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    Txtdq.Text = f.PubDictAttrs["dqmc"].ToString();
                    Txtdq.Tag = f.PubDictAttrs["dqid"].ToString();
                }
                else
                {
                    Txtdq.Text = "";
                    Txtdq.Tag = "0";
                }
            }
        }



    }
}