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
using System.Data.SqlClient;
#endregion
namespace FMS.DSKGL.ZBDSKHZ
{
    public partial class FrmZBDSKHZ : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private string PriTmsStrCon;
        private string PriJyStrCon;
        private string PriStpSj = "";
        #endregion
        public FrmZBDSKHZ()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriJyStrCon = ClsGlobals.CntStrKj;
            PriTmsStrCon = ClsGlobals.CntStrTMS;
            this.VfmszbdskhzTableAdapter1.Connection.ConnectionString = PriTmsStrCon;
            DataRow dr = ClsRWMSSQLDb.GetDataRow(" select mc from tjigou where mc like '物流金融事业部' ", PriJyStrCon);
            this.TxtBJgmc.Text = dr[0].ToString();
            DateTime now = DateTime.Now;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);
            DtpStart.Value = d1;
        }
        #region 查询
        private void BtnSave_Click(object sender, EventArgs e)
        {
            int aDayCun = 0;
            aDayCun = Convert.ToInt32(Convert.ToDateTime(DtpStop.Text).Subtract(Convert.ToDateTime(DtpStart.Text)).Days);
            //string aStrCon = "";
            if (aDayCun >= 0)
            {
                //aStrCon = "select sj,ysdsk,zjfk,sxf,ye,wffje,ykje,sxfzj from dbo.Fun_GetFmsZBDSKHZ('" + DtpStart.Text + "'," + aDayCun + ")";
                using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
                {
                    DataTable dt = new DataTable();
                    SqlCommand com = new SqlCommand();
                    com.Connection = conn;
                    conn.Open();
                    try
                    {
                        com.CommandText = "P_ZBDSKHZ";
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add("@Stpsj", DtpStart.Text);
                        com.Parameters.Add("@CunDat", aDayCun);
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        da.Fill(dt);
                        Dgv.DataSource = dt;
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                        com.Dispose();
                    }
                }
                PriStpSj = DtpStart.Text;

            }
            //else
            //{
            //    aStrCon = "select sj,ysdsk,zjfk,sxf,ye,wffje,ykje,sxfzj from dbo.Fun_GetFmsZBDSKHZ('" + DtpStop.Text + "'," + Math.Abs(aDayCun) + ")";
            //    PriStpSj = DtpStop.Text;
            //}
            //Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(aStrCon, PriTmsStrCon);
        }
        #endregion
        #region 连接
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= 0)
                return;
            int aColumnIndex = e.ColumnIndex;

            if (aColumnIndex == 1 || aColumnIndex == 2 || aColumnIndex == 5 || aColumnIndex == 6)//本店发生额
            {
                decimal d = 0;
                if (aColumnIndex == 1)
                {
                    d = Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtysdak.Name].Value);
                }
                else if (aColumnIndex == 2)
                {
                    d = Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtzdfk.Name].Value);
                }
                else if (aColumnIndex == 5)
                {
                    d = Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtwffje.Name].Value);
                }
                else
                {
                    d = Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyk.Name].Value);
                }
                if (d == 0)
                {
                    ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
                    return;
                }
                string asj = Dgv.Rows[e.RowIndex].Cells[DgvColTxtrq.Name].Value.ToString();
                string akssj = "";
                akssj = asj;
                if (aColumnIndex <= 2)
                {
                    FrmDSKMXCX f = new FrmDSKMXCX();
                    f.Prepare(akssj, aColumnIndex);
                    f.ShowDialog();
                }
                else
                {
                    FrmDSKWFFMX f = new FrmDSKWFFMX();
                    f.Prepare(akssj, aColumnIndex);
                    f.ShowDialog();
                }
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
            int[] Rows = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            ClsExcel.CreatExcel(Dgv, "总部代收款汇总", this.ctrlDownLoad1, Rows, true);
        }
        #endregion
    }
}