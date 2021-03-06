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

namespace FMS.CWGL.YBFNHDR
{
    public partial class FrmYBFNHMX : Form
    {

        public FrmYBFNHMX()
        {
            InitializeComponent();
        }
        public void Prepare(int pcid,string lx)
        {
            ClsG ObjG = Session["ObjG"] as ClsG;
            //string aStr = " SELECT a.yhzh,a.zhmc,a.jyje AS dsk,b.rbdh,(CASE WHEN a.zt=0 THEN 'δƥ��' WHEN a.zt=5 THEN '���'      WHEN a.zt=10 THEN '����'end)AS zt FROM tfmsdsknhdrmx AS a LEFT JOIN Tfmsdskjkpc AS b ON  a.rbpcid=b.id   WHERE a.pcid=" + pcid;
            string aStr = "";
            if(lx=="J")
                aStr = " SELECT  DISTINCT  a.zh AS yhzh,a.zhmc,a.dkje AS dsk,b.rbdh,(CASE WHEN a.zt=0 THEN 'δƥ��' WHEN a.zt=5 THEN '���'      WHEN a.zt=10 THEN '����'end)AS zt FROM Tfmsybfjhdrmx AS a LEFT JOIN Tfmsrbpc AS b ON  a.rbid=b.id   left JOIN vfmsyhzh AS c ON b.jgid=c.jgid  WHERE a.pcid=" + pcid + "  order by   a.zh,a.zhmc,a.dkje ,b.rbdh  ";
            else
                aStr = "  SELECT DISTINCT a.yhzh,a.zhmc,a.jyje AS dsk,b.rbdh, (CASE WHEN a.zt=0 THEN 'δƥ��' WHEN a.zt=5 THEN '���'     WHEN a.zt=10 THEN '����'end)AS zt  FROM dbo.Tfmsybfnhdrmx AS a LEFT JOIN Tfmsrbpc    AS b ON  a.rbpcid=b.id    left JOIN vfmsyhzh AS c ON b.jgid=c.jgid   WHERE a.pcid=" + pcid + "  order by   a.yhzh,a.zhmc,a.jyje ,b.rbdh  ";
           
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