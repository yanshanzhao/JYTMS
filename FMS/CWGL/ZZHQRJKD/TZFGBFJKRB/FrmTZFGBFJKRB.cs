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
using System.Collections;
using System.Data.SqlClient;

#endregion

namespace FMS.CWGL.ZZHQRJKD.TZFGBFJKRB
{
    public partial class FrmTZFGBFJKRB : UserControl
    {
        private ClsG ObjG;
        private string PriLsh;
        //private int Prilx = 0;
        public FrmTZFGBFJKRB()
        {
            InitializeComponent();
        }

        public void Prepare()
        {

            ObjG = (ClsG)Session["ObjG"];

            this.VfmsxtsrTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            string sql = "   SELECT -1 id,'-ȫ��-'name,0  sort    UNION ALL  SELECT id,name ,sort FROM dbo.Tfmsxtwsr_lx   where  zt=0  ORDER BY sort ";
            //if (Prilx == 2)
            //    sql =sql+" where  bh in ('tzf','gbf') "; 
            DataTable dt = ClsRWMSSQLDb.GetDataTable(sql, ClsGlobals.CntStrTMS);
            this.CmbLx.DataSource = dt;
            this.CmbLx.DisplayMember = "name";
            this.CmbLx.ValueMember = "id";
            this.CmbLx.SelectedIndex = 0;


            //CmbLx.DataSource = dt1;
            //CmbLx.ValueMember = "id";
            //CmbLx.DisplayMember = "name";
            //CmbLx.SelectedIndex = 0;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string SWhere = " WHERE jgid=" + ObjG.Jigou.id + " AND zt=0 ";
            //SWhere += " AND lxbhs='" + CmbLx.Text + "'";
            if (CmbLx.SelectedIndex > 0)
            {
                SWhere += " AND lxbhs='" + CmbLx.Text.Trim().ToString() + "'";
            }
            if (DtpStart.Checked)
                SWhere += " AND inssj>='" + DtpStart.Value.Date + "'";
            if (DtpStop.Checked)
                SWhere += " AND inssj<'" + DtpStop.Value.Date.AddDays(1) + "'";
            VfmsxtsrTableAdapter1.FillByWhere(Dstfmsxtsr1.vfmsxtsr, SWhere);
            LblRowCount.Text = "����" + Bds.Count.ToString() + "������";
            if (Dgv.Rows.Count == 0)
            {
                this.LblSum.Text = "Ӧ��0.00Ԫ";
            }
            else
            {
                this.LblSum.Text = "Ӧ��" + Dstfmsxtsr1.vfmsxtsr.Compute("sum(je)", "zt=0") + "Ԫ";
            }
        }

        private void BtnJk_Click(object sender, EventArgs e)
        {
            FrmTZFGBFJKMX f = new FrmTZFGBFJKMX();
            f.ShowDialog();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            BtnSearch.PerformClick();
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            if (Bds.Count > 60000)
            {
                ClsMsgBox.Ts("������������60000��������!", ObjG.CustomMsgBox, this);
                return;
            }
            int[] CellIndex = { 4 };
            ClsExcel.CreatExcel(Dgv, "�˵���������񿨹�������ϸ", this.ctrlDownLoad1, CellIndex);
        }
    }
}
