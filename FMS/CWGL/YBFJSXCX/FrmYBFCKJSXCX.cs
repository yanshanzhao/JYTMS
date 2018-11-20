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
using System.Data.SqlClient;
using System.IO;
using System.Web;
#endregion

namespace FMS.CWGL.YBFJSXCX
{
    public partial class FrmYBFCKJSXCX : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private int Prijgid = 0;
        //private int PriLevel = 0;
        //private int PriLx;
        //private int PriQsfs; 

        private string PriStrWhere = "";
        #endregion
        public FrmYBFCKJSXCX()
        {
            InitializeComponent();
        }

        //private DSYBF.VybfcxRow PriRow
        //{
        //    get
        //    {
        //        if (Bds.Current == null)
        //            return null;
        //        return ((DataRowView)Bds.Current).Row as DSYBF.VybfcxRow;
        //    }
        //    set
        //    {
        //        PriRow = value;
        //    }

        //}
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            //Prijgid = ObjG.Jigou.id;
            TxtJg.Text = ObjG.Jigou.mc;
            TxtJg.Tag = ObjG.Jigou.id.ToString();
            //PriLevel = ObjG.Jigou.level;
            Cmbqsfs.SelectedIndex = 0;
            this.DSYBF1.EnforceConstraints = false;
            this.VybfjsxcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }
        #region 查询
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            //if (Prijgid == 0)
            //{
            //    ClsMsgBox.Ts("请选择要查询的机构！", ObjG.CustomMsgBox, this);
            //    return;
            //} 

            PriStrWhere = "";
            if (string.IsNullOrEmpty(TxtJg.Text))
            {
                ClsMsgBox.Ts("请选择要查询的机构信息！");
                return;
            }

            string Where = "";
            Where += "   where  inssj>='" + DtpStart.Value.Date + "'";
            Where += "   and   inssj<='" + DtpEnd.Value.Date + "'";
            //if (!string.IsNullOrEmpty(Txtdq.Text))
            //{
            //    Where += " and dqmc = '" + Txtdq.Text.Trim() + "'";
            //} 
            PriStrWhere = Where;
            if (!string.IsNullOrEmpty(TxtJg.Text))
            {
                Where += " and jgid  in (SELECT id  FROM jyjckj.dbo.tjigou WHERE parentLst LIKE '%," + TxtJg.Tag.ToString() + ",%' ) ";
                Prijgid = Convert.ToInt32(TxtJg.Tag.ToString());
            }
            string SQLString = " SELECT dqmc,jgmc,ybfje, yqje,jsje,ywlx,dqid,jgid FROM (SELECT dqmc,jgmc,SUM(ybfje) ybfje,SUM(yqje)  yqje,SUM(ybfje-yqje)jsje,ywlx,dqid,jgid,1 px FROM  Vybfjsxcx " + Where + " GROUP BY dqmc,jgmc,ywlx,dqid,jgid UNION ALL SELECT '' dqmc,'合计' jgmc,SUM(ybfje) ybfje,SUM(yqje)  yqje,SUM(ybfje-yqje) jsje,'' ywlx,0 dqid,0 jgid,2 px FROM  Vybfjsxcx  " + Where + "  ) AS a ORDER BY a.px  ";
            //PriStrWhere = Where;
            VybfjsxcxTableAdapter1.FillByWhere(DSYBF1.Vybfjsxcx, SQLString, 1);
        }
        #endregion

        #region 机构查询
        private void BtnJg_Click(object sender, EventArgs e)
        {
            FrmSelectJg2 PriFrmSelectJg = new FrmSelectJg2();
            PriFrmSelectJg.Prepare();
            PriFrmSelectJg.ShowDialog();
            PriFrmSelectJg.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmJGCX1_FormClosed);
        }
        private void FrmJGCX1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg2 f = sender as FrmSelectJg2;
            if (f.DialogResult == DialogResult.OK)
            {
                //Prijgid = Convert.ToInt32(f.PubDictAttrs["id"]);
                this.TxtJg.Text = f.PubDictAttrs["mc"];
                this.TxtJg.Tag = f.PubDictAttrs["id"];
            }
            else
            {
                this.TxtJg.Text = "";
                this.TxtJg.Tag = "0";
            }
            f.Dispose();
        }
        private void Btndq_Click(object sender, EventArgs e)
        {

            //FrmSelectJg2 PriFrmSelectJg = new FrmSelectJg2();
            //PriFrmSelectJg.Prepare();
            //PriFrmSelectJg.ShowDialog();
            //PriFrmSelectJg.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmDq_FormClosed);
        }
        private void FrmDq_FormClosed(object sender, FormClosedEventArgs e)
        {
            //FrmSelectJg2 f = sender as FrmSelectJg2;
            //if (f.DialogResult == DialogResult.OK)
            //{
            //    Prijgid = Convert.ToInt32(f.PubDictAttrs["id"]);
            //    this.TxtJg.Text = f.PubDictAttrs["mc"];
            //    PriLevel = Convert.ToInt32(f.PubDictAttrs["level"]);
            //}
            //else if (f.DialogResult == DialogResult.None)
            //{
            //    return;
            //}
            //else if (f.DialogResult == DialogResult.No)
            //{
            //    this.TxtJg.Text = "";
            //    Prijgid = 0;
            //    PriLevel = -1;
            //}
            //f.Dispose();
        }
        #endregion

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.RowIndex == Dgv.RowCount - 1)
                return;
            int ajgid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DvgTxtjgid.Name].Value.ToString()); ;
            FrmYBFCKJSXMX f = new FrmYBFCKJSXMX();
            f.ShowDialog();
            f.Prepare(ajgid, PriStrWhere);


        }
        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            //string filehead = "机构\t已签收代收款票数\t已签收代收款金额\t及时的代收款票数\t及时的代收款金额\t票数的及时率\t金额的及时率\t签收方式";
            int[] Rows = new int[] { 2, 3, 4 };
            //ClsExcel.CreatExcel(Dgv, "代收款存款及时性查询", this.ctrlDownLoad1, Rows);
            ClsExcel.CreatExcel(Dgv, "运保费存款及时性查询", this.ctrlDownLoad1, Rows);
        }
        #endregion

        private void BtnExlmx_Click(object sender, EventArgs e)
        {
            string inssj = DtpStart.Text;
            string jssj = DtpEnd.Text;

            FrmYBFCKJSXMX f = new FrmYBFCKJSXMX();
            f.Prepare(Prijgid, PriStrWhere);
            f.BtnExl_Click(null, null);
        }
    }
}
