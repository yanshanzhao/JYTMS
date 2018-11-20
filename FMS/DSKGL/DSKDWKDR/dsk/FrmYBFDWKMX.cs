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
using JY.Pri;
using System.Data.SqlClient;
using JY.Pub;

#endregion

namespace FMS.DSKGL.DSKDWKDR.dsk
{
    public partial class FrmYBFDWKMX : Form
    {
        public FrmYBFDWKMX()
        {
            InitializeComponent();
        }
        public void Prepare(int pcid, string lx)
        {
            ClsG ObjG = Session["ObjG"] as ClsG;
            //string aStr = " SELECT a.yhzh,a.zhmc,a.jyje AS dsk,b.rbdh,(CASE WHEN a.zt=0 THEN 'Î´Æ¥Åä' WHEN a.zt=5 THEN 'Ïà·û'      WHEN a.zt=10 THEN '²»Ïà'end)AS zt FROM tfmsdsknhdrmx AS a LEFT JOIN Tfmsdskjkpc AS b ON  a.rbpcid=b.id   WHERE a.pcid=" + pcid;
            string aStr = "";
            if (lx == "N")
                aStr = @"   SELECT  DISTINCT  a.dfzh AS yhzh,a.dfhm as zhmc,a.dkje AS dsk,b.rbdh,(CASE WHEN a.zt=0 THEN 'Î´Æ¥Åä' WHEN a.zt=5 THEN 'Ïà·û'    
                            WHEN a.zt=10 THEN '²»·û'end)AS zt FROM tfmsdskdwknhdrmx AS a LEFT JOIN Tfmsdskjkpc AS b ON  a.rbpcid=b.id 
	                        left JOIN vfmsyhzh AS c ON b.jgid=c.jgid  WHERE a.pcid=" + pcid+"  order by   a.dfzh,a.dfhm,a.dkje ,b.rbdh  ";
            else
                aStr = @"   SELECT  DISTINCT  a.sfzh AS yhzh,a.sfmc as zhmc,a.dkje AS dsk,b.rbdh,(CASE WHEN a.zt=0 THEN 'Î´Æ¥Åä' WHEN a.zt=5 THEN 'Ïà·û'    
                            WHEN a.zt=10 THEN '²»·û'end)AS zt FROM tfmsdskdwkzsdrmx AS a LEFT JOIN Tfmsdskjkpc AS b ON  a.rbpcid=b.id 
	                        left JOIN vfmsyhzh AS c ON b.jgid=c.jgid  WHERE a.pcid=" + pcid+"  order by   a.sfzh,a.sfmc,a.dkje ,b.rbdh  ";

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
