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
using JY.Pub;
#endregion

namespace FMS.DSKGL.FBDSKHZ
{
    public partial class FrmZBDSKHZXX : Form
    {
        public FrmZBDSKHZXX()
        {
            InitializeComponent();
        }
        public void Prepare(string asj, string azt, int aRowCount, int ajgid)
        {
            this.Vfmsfbdskhz2TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            string aSqlCon = "";
            //if (azt == "0")
            //    this.Text = "���귢������ϸ��Ϣ";
            //else
            //    this.Text = "�ܲ�ֱ�ӷ��Ž����ϸ��Ϣ";
            if (aRowCount == 0)
            {
                aSqlCon = "  where sljgid=" + ajgid + " and zt='" + azt + "'" + " and  slsj<'" + Convert.ToDateTime(asj).ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                aSqlCon = "  where sljgid=" + ajgid + " and zt='" + azt + "'" + " and slsj='" + Convert.ToDateTime(asj).ToString("yyyy-MM-dd") + "'";
            }
            this.Vfmsfbdskhz2TableAdapter1.FillByWhere(this.DSFBDSKHZ1.Vfmsfbdskhz2, aSqlCon);
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��");
                return;
            }
            int[] Rows = new int[] { 6,7 };
            ClsExcel.CreatExcel(Dgv, "�ܲ�ֱ�ӷ��Ž��", this.ctrlDownLoad1, Rows);    
            //ClsExcel.CreatExcel(Dgv, "�ܲ�ֱ�ӷ��Ž��", this.ctrlDownLoad1);    
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}