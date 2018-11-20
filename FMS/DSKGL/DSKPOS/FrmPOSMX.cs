#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pub;
using JY.Pri;
using System.Data.SqlClient;
#endregion

namespace FMS.DSKGL.DSKPOS
{
    public partial class FrmPOSMX : Form
    {

        public FrmPOSMX()
        {
            InitializeComponent();
        }
        public void Prepare(int pcid)
        {
            ClsG ObjG = Session["ObjG"] as ClsG;
            string aStr = "  SELECT posbh,bs,je,a.sxf,b.rbdh,(CASE WHEN a.zt=0 THEN 'Î´Æ¥Åä' WHEN a.zt=5 THEN '²»·û'  "+
                          "  WHEN a.zt=10 THEN 'Ïà·û'end)AS zt FROM Tfmsposmx AS a LEFT JOIN dbo.Tfmsdskjkpc  AS b "+
                          "  ON a.rbpcid=b.id  where a.pcid=" + pcid;
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = new SqlCommand();
                    sda.SelectCommand.Connection = conn;
                    sda.SelectCommand.CommandText = aStr;
                    conn.Open();
                    DataTable dts = new DataTable();
                    sda.Fill(dts);
                    Dgv.DataSource = dts;
                    sda.Dispose();
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw(ex.Message, ObjG.CustomMsgBox, this);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        
        }
    }
}