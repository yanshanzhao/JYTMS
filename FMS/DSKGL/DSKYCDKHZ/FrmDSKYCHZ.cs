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

namespace FMS.DSKGL.DSKYCDKHZ
{
    public partial class FrmDSKYCHZ : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private string PriTmsStrCon;
        //private string PriJyStrCon;
        private string PriStpSj = "";
        #endregion
        public FrmDSKYCHZ()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            PriTmsStrCon = ClsGlobals.CntStrTMS;
            DateTime now = DateTime.Now;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);
            DtpStart.Value = d1;

        }
        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 1, 2, 3 };
            ClsExcel.CreatExcel(Dgv, "代收款打款异常处理汇总", this.ctrlDownLoad1, Rows, true);
        }
        #endregion

        #region 查询
        private void BtnSave_Click(object sender, EventArgs e)
        {
            int aDayCun = 0;
            aDayCun = Convert.ToInt32(Convert.ToDateTime(DtpStop.Text).Subtract(Convert.ToDateTime(DtpStart.Text)).Days);
            //string aStrCon = "";
            if (aDayCun >= 0)
            {
                //aStrCon = "select xzje,ffje,qm,sj  from dbo.Fun_GetFmsDSKYCHZ('" + DtpStart.Text + "'," + aDayCun + ")";
                using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
                {
                    DataTable dt = new DataTable();
                    SqlCommand com = new SqlCommand();
                    com.Connection = conn;
                    conn.Open();
                    try
                    {
                        com.CommandText = "P_DSKYCHZ";
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
            //    aStrCon = "select xzje,ffje,qm,sj from dbo.Fun_GetFmsDSKYCHZ('" + DtpStop.Text + "'," + Math.Abs(aDayCun) + ")";
            //    PriStpSj = DtpStop.Text;
            //}
            //Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(aStrCon, PriTmsStrCon);
        }
        #endregion

        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= 0)
                return;
            Decimal aje;
            if(!Decimal.TryParse(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),out aje))
                    return; 
            aje = Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            string asj = Dgv.Rows[e.RowIndex].Cells[DgvColTxtsj.Name].Value.ToString();
            string amc = Dgv.Columns[e.ColumnIndex].HeaderText;
            if (aje == 0)
            {
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            FrmDSKFFYCMX f = new FrmDSKFFYCMX();
            f.ShowDialog();
            f.Prepare(amc, asj);
        }

    }
}