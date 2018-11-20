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

#endregion

namespace FMS.CWGL.THYDCX
{
    public partial class FrmTHYDCX : UserControl
    {
        private ClsG ObjG;
        private int Prilevel;
        public FrmTHYDCX()
        {
            InitializeComponent();
        }

        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            this.ActiveControl = BtnJg;
            ClsPopulateCmbDsS.PopuYd_ydzts(CmbThydzt);
            CmbThydzt.SelectedIndex = 0;
            CmbDsk.SelectedIndex = 1;
            TxtSQjg.Text = ObjG.Jigou.mc;
            TxtSQjg.Tag = ObjG.Jigou.id.ToString();
            Prilevel = ObjG.Jigou.level;
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (Prilevel < 0)
            {
                ClsMsgBox.Ts("请选择要查询的机构", ObjG.CustomMsgBox, this);
                return;
            }
            string Where = " where 1=1";
            if (CmbThydzt.SelectedIndex != 0)
                Where += " and xydzt='" + CmbThydzt.SelectedValue + "'";
            int jgid = Convert.ToInt32(TxtSQjg.Tag.ToString());
            Where += " and sqjgid in (SELECT id FROM jyjckj.dbo.tjigou WHERE parentLst LIKE '%," + jgid + ",%') ";
            if (!string.IsNullOrEmpty(TxtYhydh.Text.Trim()))
                Where += " and ybh='" + TxtYhydh.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(TxtXhydh.Text.Trim()))
                Where += " and xbh='" + TxtXhydh.Text.Trim() + "'";
            if (DtpStart.Checked)
                Where += "   and sqsj>='" + DtpStart.Value.Date + "' ";
            if (DtpStop.Checked)
                Where += "   and sqsj<'" + DtpStop.Value.Date + "' ";
            if (CmbDsk.SelectedIndex > 0)
            {
                if (CmbDsk.SelectedIndex == 1)
                    Where += "   and dsk>0 ";
                else if (CmbDsk.SelectedIndex == 2)
                    Where += "   and dsk=0 ";
            }
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                conn.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                DataTable PriDt = new DataTable();
                com.CommandText = "P_Dskthcxmx";
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@Where", Where));
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(PriDt);
                Dgv.DataSource = PriDt;
                conn.Close();
                conn.Dispose();
                da.Dispose();
                com.Dispose();
            }
            if (Dgv.Rows.Count == 0)
                ClsMsgBox.Ts("没有要查询的信息，请核对查询条件！", ObjG.CustomMsgBox, this);
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(Dgv, "退货调整签收状态明细查询", this.ctrlDownLoad1);
        }

        private void BtnJg_Click(object sender, EventArgs e)
        {
            FrmSelectJg2 f = new FrmSelectJg2();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            Prilevel = -1;
            FrmSelectJg2 f = sender as FrmSelectJg2;
            this.TxtSQjg.Text = f.PubDictAttrs["mc"];
            this.TxtSQjg.Tag = f.PubDictAttrs["id"];
            if (f.DialogResult == DialogResult.OK)
            {
                Prilevel = Convert.ToInt32(f.PubDictAttrs["level"]);
            }
            f.Dispose();
        }
    }
}