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
using System.Collections;
using JYPubFiles.Classes;


#endregion

namespace FMS.DSKGL.DSKCX.DSKPMCX
{
    public partial class FrmDSKPMCX : UserControl
    {
        private ClsG ObjG;
        private string PriDskdbje;
        public FrmDSKPMCX()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            PriDskdbje = System.Configuration.ConfigurationManager.AppSettings["DSKDBJE"].ToString() ;
            Dgv.Columns["DgvClsTxtBl"].HeaderText = "单笔超过"+PriDskdbje+"的比率";
        }
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            ClsD.TextBoxTrim(this);
            if (string.IsNullOrEmpty(TxtTop.Text)) 
            {
                ClsMsgBox.Ts("请输入名次范围！",ObjG.CustomMsgBox,this);
                return;
            }
            if (!ClsRegEx.IsNotZeroInt(TxtTop.Text))
            {
                ClsMsgBox.Ts("请输入正确的名次范围！", ObjG.CustomMsgBox, this);
                return;
            }
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                conn.Open();
                DataTable dt = new DataTable();
                ArrayList als = new ArrayList();
                als.Add(new SqlParameter("@top", TxtTop.Text));
                als.Add(new SqlParameter("@startsj", DtpStart.Text));
                als.Add(new SqlParameter("@endsj", DtpEnd.Text));
                als.Add(new SqlParameter("@dsk", PriDskdbje));
                using (SqlCommand cmd = new SqlCommand("P_dskpm"))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(als.ToArray(typeof(SqlParameter)));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    Dgv.DataSource = dt;
                }
                conn.Close();
            }
        }

        private void BtnDc_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("没有要导出的运单信息！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(Dgv, "代收款排名查询", ctrlDownLoad1,new int[]{2});
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex<0)
                return;
            if (Dgv.Columns[e.ColumnIndex].Name.Equals("DgvColLinkMx"))
            {
                DataGridViewRow dr = (DataGridViewRow)Dgv.CurrentRow;
                FrmDSKPMMX f = new FrmDSKPMMX();
                f.Prepare(dr, DtpStart.Text,DtpEnd.Text);
                f.ShowDialog();
            }
        }
    }
}