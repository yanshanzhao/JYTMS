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
    public partial class FrmTHDSKCX : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private int Prilevel;
        private string PriWhere = "";
        private string PriWherejg = "";
        #endregion

        public FrmTHDSKCX()
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
            CmbQszt.SelectedIndex = 0; 
            Prilevel = -1;
            TxtSQjg.Text = ObjG.Jigou.mc;
            TxtSQjg.Tag = ObjG.Jigou.id.ToString();
            Prilevel = ObjG.Jigou.level;
        }

        #region 查询
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (Prilevel < 0)
            {
                ClsMsgBox.Ts("请选择要查询的机构", ObjG.CustomMsgBox, this);
                return;
            }
            int alx = 0;
            if (Prilevel <= 4)
                alx = 1;
            PriWhere = "";
            PriWherejg = "";
            string Where = " where qszts=" + CmbQszt.SelectedIndex ;

            int jgid = Convert.ToInt32(TxtSQjg.Tag.ToString());
            PriWherejg = "   and sqjgid in (SELECT id FROM jyjckj.dbo.tjigou WHERE parentLst LIKE '%," + jgid + ",%') ";
            if (DtpStart.Checked)
                Where += "   and sqsj>='" + DtpStart.Value.Date + "' ";
            if (DtpStop.Checked)
                Where += "   and sqsj<'" + DtpStop.Value.Date + "' ";
            if (DtpBzStart.Checked)
                Where += "   and bzsj>='" + DtpBzStart.Value.Date + "' ";
            if (DtpBzStop.Checked)
                Where += "   and bzsj<'" + DtpBzStop.Value.Date + "' ";
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
                com.CommandText = "P_Dskthcx";
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@Where", Where+PriWherejg));
                com.Parameters.Add(new SqlParameter("@lx", alx));
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(PriDt);
                Dgv.DataSource = PriDt;
                conn.Close();
                conn.Dispose();
                da.Dispose();
                com.Dispose();
                PriWhere = Where;
            }
            if (Dgv.Rows.Count == 0)
                ClsMsgBox.Ts("没有要查询的信息，请核对查询条件！", ObjG.CustomMsgBox, this);

        }
        #endregion



        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == Dgv.RowCount - 1)
            //    return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            int ajgid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgid.Name].Value.ToString()); 
            if (e.ColumnIndex == 1)
            {
                string awhere = "   and sqjgid in (SELECT id FROM jyjckj.dbo.tjigou WHERE parentLst LIKE '%," + ajgid + ",%') ";
                FrmTHDSKCXMX f = new FrmTHDSKCXMX();
                f.Prepare(PriWhere + awhere);
                f.Show();
            }
            else if (e.ColumnIndex == 3)
            {
                string awhere = "   and sqjgid in (SELECT id FROM jyjckj.dbo.tjigou WHERE parentLst LIKE '%," + ajgid + ",%')  and qszts=0 ";
                FrmTHDSKCXMX f = new FrmTHDSKCXMX();
                f.Prepare(PriWhere + awhere);
                f.Show();
            }
        }

        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(Dgv, "退货代收款查询", this.ctrlDownLoad1);
        }
        #endregion

        private void BtnExlmx_Click(object sender, EventArgs e)
        { 

            FrmTHDSKCXMX f = new FrmTHDSKCXMX();
            f.Prepare(PriWhere + PriWherejg);
            f.BtnDc_Click(null, null);
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
