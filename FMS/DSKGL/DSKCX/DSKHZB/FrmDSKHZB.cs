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
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Data.SqlClient;
using FMS.SeleFrm;
#endregion

namespace FMS.DSKGL.DSKCX.DSKHZB
{
    public partial class FrmDSKHZB : UserControl
    {

        #region 成员变量
        private ClsG ObjG;
        private string Where;
        private int PriJgid;
        private string Jgid;
        private string PriJgmc;
        private string PriConStr;
        private string PriSsj;
        private string PriEsj;
        private string PriAjgid;
        //private int PriAzt;
        private int PriZt1;
        private int PriZt2;
        #endregion

        public FrmDSKHZB()
        {
            InitializeComponent();
        }

        #region Prepare
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriJgmc = ObjG.Jigou.mc;
            PriJgid = ObjG.Jigou.id;
            TxtCkjg.Text = PriJgmc;
            PriConStr = ClsGlobals.CntStrTMS;
            Jgid = PriJgid.ToString();
            dsklsdhzbTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            dskjrhzbTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            DateTime now = DateTime.Now;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);
            DtpStart.Value = d1;

        }
        #endregion

        #region 机构
        private void BtnJG_Click(object sender, EventArgs e)
        {
            FrmSelectJg1 f = new FrmSelectJg1();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg1 f = sender as FrmSelectJg1;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtCkjg.Text = f.PubDictAttrs["mc"];
                Jgid = f.PubDictAttrs["id"];
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtCkjg.Text = PriJgmc;
                Jgid = PriJgid.ToString();
            }
        }
        #endregion

        #region 查询
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Clear();
            using (SqlConnection conn = new SqlConnection(PriConStr))
            {
                conn.Open();
                try
                {
                    PriSsj = DtpStart.Value.ToString();
                    PriEsj = DtpStop.Value.AddDays(1).ToString();
                    PriAjgid = Jgid;

                    //if (Jgid != "57")
                    //{
                    //    Dgv2.Visible = false;
                    //    Dgv1.Visible = true;
                    Where = " where sj >= '" + DtpStart.Value.Date + "' and sj<'" + DtpStop.Value.Date.AddDays(1) + "'";
                    Where += " and jg=" + Jgid;
                    dsklsdhzbTableAdapter1.FillByWhere1(dskhzb1.Vfmsdsklsdhzb, Where);
                    if (Dgv1.RowCount < 1)
                    {
                        ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
                    }
                    //}
                    //else
                    //{
                    //    Dgv1.Visible = false;
                    //    Dgv2.Visible = true;
                    //    Where = " where 1=1 ";
                    //    Where += " and shsj between '" + DtpStart.Value + "' and dateadd(day,1,'" + DtpStop.Value + "')";
                    //    dskjrhzbTableAdapter1.FillByWhere1(dskhzb2.Vfmsdskjrhzb, Where);
                    //    if (Dgv2.RowCount < 1)
                    //    {
                    //        ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
                    //    }
                    //}


                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("查询信息失败！", ex, ObjG.CustomMsgBox, this);
                }
                finally
                {

                    conn.Close();
                    Where = "";
                }
            }

        }
        #endregion
        #region Clear
        private void Clear()
        {
            PriEsj = "";
            PriSsj = "";
            PriAjgid = "";
        }
        #endregion


        #region 导出
        private void button1_Click(object sender, EventArgs e)
        {
            if (Dgv2.Visible)
            {
                if (Dgv2.RowCount == 0)
                {
                    ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                    return;
                }
                int[] Rows = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
                ClsExcel.CreatExcel(Dgv2, "代收款汇总表", this.ctrlDownLoad1, Rows);
                //ClsExcel.CreatExcel(Dgv2, "代收款汇总表", this.ctrlDownLoad1);
            }
            if (Dgv1.Visible)
            {
                if (Dgv1.RowCount == 0)
                {
                    ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                    return;
                }
                int[] Rows = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
                ClsExcel.CreatExcel(Dgv1, "代收款汇总表", this.ctrlDownLoad1, Rows, true);
                //ClsExcel.CreatExcel(Dgv1, "代收款汇总表", this.ctrlDownLoad1);
            }
        }
        #endregion

        #region 查询明细
        private void Dgv1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            PriZt1 = PriZt2 = 0;
            if (Convert.ToDecimal(Dgv1[e.ColumnIndex, 0].Value) == 0)
            {
                ClsMsgBox.Ts("没有要查询的信息", ObjG.CustomMsgBox, this);
                return;
            }
            //if (e.ColumnIndex == 0)
            //    {

            //    }
            if (e.ColumnIndex == 0)
            {
                PriZt1 = 0;
                PriZt2 = 0;//本店发生额
            }
            else if (e.ColumnIndex == 4)
            {
                PriZt1 = 2;
                PriZt2 = 0;//未签收
            }
            else
            {
                PriZt1 = 1;
                if (e.ColumnIndex == 2)
                    PriZt2 = 1;//实存
                else if (e.ColumnIndex == 1)
                    PriZt2 = 2;//应存
                else PriZt2 = 0;//未存
            }
            FrmDSKHZBXX f = new FrmDSKHZBXX();
            f.Prepare(PriSsj, PriEsj, PriAjgid, PriZt1, PriZt2);
            f.ShowDialog();

        }
        #endregion

    }
}