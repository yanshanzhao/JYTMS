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
    public partial class FrmDSKXX : Form
    {

        public FrmDSKXX()
        {
            InitializeComponent();
        }
        public void Prepare(string asj, int aRowCount, string aZt, int ajgid)
        {
            //0:�˵�δǩ�� 1���ѷ��� 2����ǩ��δ����
            this.Vfmsfbdskhz2TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            string aSqlCon = "";
            if (aZt == "0")
                this.Text = this.Text + "--�˵�δǩ��";
            else if (aZt == "2")
                this.Text = this.Text + "--��ǩ��δ����";
            if (aRowCount == 0)
            {
                aSqlCon = "  where sljgid=" + ajgid + "   and  slsj<'" + Convert.ToDateTime(asj).ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                aSqlCon = "  where sljgid=" + ajgid + "  and slsj='" + Convert.ToDateTime(asj).ToString("yyyy-MM-dd") + "'";
            }
            if (aZt.Length > 0)
                aSqlCon = aSqlCon + " and zt='" + aZt + "'";
            this.Vfmsfbdskhz2TableAdapter1.FillByWhere(this.DSFBDSKHZ1.Vfmsfbdskhz2, aSqlCon);
        }
        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��");
                return;
            }
            int[] Rows = new int[] { 6 };
            ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1);
        }
        #endregion

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}