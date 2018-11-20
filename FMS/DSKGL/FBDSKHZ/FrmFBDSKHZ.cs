#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using FMS.SeleFrm;
using JY.Pri;
using JY.Pub;
using System.Data.SqlClient;
#endregion

namespace FMS.DSKGL.FBDSKHZ
{
    public partial class FrmFBDSKHZ : UserControl
    {
        #region
        private int PriJgid = 0;
        private ClsG ObjG;
        private string PriStrCon = "";
        private string PriStpSj = "";
        #endregion
        public FrmFBDSKHZ()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriStrCon = ClsGlobals.CntStrTMS;
            this.TxtBJgmc.Text = ObjG.Jigou.mc;
            PriJgid = ObjG.Jigou.id;
            DateTime now = DateTime.Now;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);
            DtpStart.Value = d1;
        }
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
                PriJgid = Convert.ToInt32(f.PubDictAttrs["id"]);
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtBJgmc.Text = "";
                PriJgid = 0;
            }
        }
        #region 查询
        private void BtnSave_Click(object sender, EventArgs e)
        {
            TimeSpan aTsp;
            aTsp = DtpStop.Value - DtpStart.Value;
            int aDayCun = 0;
            aDayCun = Convert.ToInt32(Convert.ToDateTime(DtpStop.Text).Subtract(Convert.ToDateTime(DtpStart.Text)).Days);
            if (aDayCun == 0)
            {
                //aStrCon = "select sj,dsk,ffje,sxf,yswfdsk,wqsdsk,sljgid from  Fun_GetFmsFBDSKHZ('" + DtpStart.Text + "'," + aDayCun + "," + PriJgid + ")";
            ClsMsgBox.Ts("结束时间不能小于起始时间！", ObjG.CustomMsgBox, this);
                this.Dgv.DataSource = "";
                return;
            }
            if (aTsp.Days > 30)
                {
                ClsMsgBox.Ts("为保证查询效率，请不要查询超过一个月的数据",ObjG.CustomMsgBox,this);
                    this.Dgv.DataSource="";
                return;
                }
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsGlobals.CntStrTMS;
                conn.Open();
                using (SqlCommand comm = new SqlCommand())
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    try
                    {
                        comm.Connection = conn;
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.CommandText = "P_fmsfbfhdskcx";
                        SqlParameter[] spa = {new SqlParameter("@Star",DtpStart.Value),
                                         new SqlParameter("@Stop",DtpStop.Value),
                                         new SqlParameter("@jgid",PriJgid),};
                        comm.Parameters.AddRange(spa);
                        
                        sda.SelectCommand = comm;
                        sda.Fill(dt);
                        Dgv.DataSource = dt;
                        PriStpSj = DtpStart.Text;
                    }
                    catch (Exception ex)
                    {
                        ClsMsgBox.Cw("查询信息失败！", ex, ObjG.CustomMsgBox, this);
                    }
                    finally 
                    {
                        sda.Dispose();
                        dt.Dispose();
                        comm.Dispose();
                        conn.Close();
                    }
                   
                }
            }
            
           
           
            //this.Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(aStrCon, ClsGlobals.CntStrTMS);
        }
        #endregion

        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1||e.ColumnIndex<=-1)
                return;
            if (Dgv[e.ColumnIndex, 0].GetType().Name == "DataGridViewLinkCell")
            {
                // azt   0:运单未签收 1：已发放 2：已签收未发放
                // act   判读连接到那个窗体 0 ：FrmDSKXX  1：FrmZBDSKHZXX
                string aZt = "";
                int act = 0;
                decimal d = 0;
                if (e.ColumnIndex == 1)
                {
                    //aZt = "0";
                    d = Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                }
                else if (e.ColumnIndex == 2)
                {
                    aZt = "1";
                    d = Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtffje.Name].Value);
                    act = 1;
                }
                //else if (e.ColumnIndex == 4)
                //{
                //    aZt = "2";
                //    d = Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyswfdsk.Name].Value);
                //}
                //else if (e.ColumnIndex == 5)
                //{
                //    aZt = "0";
                //    d = Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyswfdsk.Name].Value);
                //}
                if (d == 0)
                {
                    ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
                    return;
                }
                int aRowCount = e.RowIndex;
                int aJgid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtsljgid.Name].Value);
                string asj = Dgv.Rows[e.RowIndex].Cells[DgvColTxtsj.Name].Value.ToString();
                string akssj = "";
                if (aRowCount == 0)
                    akssj = PriStpSj;
                else
                    akssj = asj;
                if (act == 0)
                {
                    FrmDSKXX f = new FrmDSKXX();
                    f.Prepare(akssj, aRowCount, aZt, aJgid);
                    f.ShowDialog();
                }
                else
                {
                    FrmZBDSKHZXX f = new FrmZBDSKHZXX();
                    f.Prepare(akssj, aZt, aRowCount, aJgid);
                    f.ShowDialog();
                }
            }
        }
        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 1, 2, 3,4,5 };
            ClsExcel.CreatExcel(Dgv, "分部代收款汇总", this.ctrlDownLoad1, Rows, true);
            //ClsExcel.CreatExcel(Dgv, "分部代收款汇总", this.ctrlDownLoad1);   
        }
        #endregion


    }
}
