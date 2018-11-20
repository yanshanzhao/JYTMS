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

namespace FMS.CXTJ.ZBYCKCX
{
    public partial class FrmZBYSKCX : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private DateTime PriStopTimes =DateTime.Now;
        #endregion
        public FrmZBYSKCX()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG=VWGContext.Current.Session["ObjG"] as ClsG;
        }

        private void BtnQery_Click(object sender, EventArgs e)
        {  
            PriStopTimes = DtpQrStop.Value;
            //Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select jgmc, ffje , tfje,  zfje , ycje   from  dbo.Fun_GetZBYCKCX('" + PriStopTimes.AddDays(1) + "') ", ClsGlobals.CntStrTMS);
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
                    com.Parameters.Add("@strDate", PriStopTimes.AddDays(1).Day); 
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
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            string StopTime = PriStopTimes.ToString("yyyy-MM-dd");
            int []ListRow = new int []{ 1,2, 3, 4 };
            ClsExcel.CreatExcel(Dgv, "截至到" + StopTime + "日的各机构欠款情况", this.ctrlDownLoad1, ListRow,true);
        }

    }
}