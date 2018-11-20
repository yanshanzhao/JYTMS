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

namespace FMS.CWGL.THDSK
{
    public partial class FrmTHDSKCXMX : Form
    {
       
        public FrmTHDSKCXMX()
        {
            InitializeComponent();
        }
        public void Prepare(string awhere)
        { 
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                conn.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                DataTable PriDt = new DataTable();
                com.CommandText = "P_Dskthcxmx";
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@Where", awhere)); 
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(PriDt);
                Dgv.DataSource = PriDt;
                conn.Close();
                conn.Dispose();
                da.Dispose();
                com.Dispose(); 
            }
        }

        public void BtnDc_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "退货代收款查询", ctrlDownLoad1);
        }
       

    }
}
