#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using FMS.SeleFrm;
using JY.Pri;
using JY.Pub;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data.SqlClient;
using FMS.SelectFrm;
#endregion

namespace FMS.CXTJ.SRQKCX
{
    public partial class FrmSRQKCX : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private int PriLevel = 0;
        private string PriJgid = "";
        private string PriYwqy = "";
        private DateTime PriKssj;
        private DateTime PriJssj;
        private string PriJgmc;
        private int PriSldqid = 0;
        private string PriYwxz = "A";
        #endregion
        public FrmSRQKCX()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG; 
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            this.CmbYwqy.SelectedIndex = 0;
            PriJgid = ObjG.Jigou.id.ToString();
            PriLevel = ObjG.Jigou.level;
            this.TxtSljg.Text = ObjG.Jigou.mc;
            TxtSljg.Tag = ObjG.Jigou.id;


            ClsPopulateCmbDsS.PopuYd_ywxz(Cmbywxz, ClsGlobals.CntStrKj);
            Txtsldq.Tag = "0";
        }
        #region 机构查询
        private void BtnJG_Click(object sender, EventArgs e)
        {
            FrmSelectJg2 f = new FrmSelectJg2();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg2 f = sender as FrmSelectJg2;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtSljg.Text = f.PubDictAttrs["mc"];
                PriJgid = f.PubDictAttrs["id"].ToString();
                PriLevel = Convert.ToInt32(f.PubDictAttrs["level"]);
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtSljg.Text = "";
                PriJgid = "";
                PriLevel = -1;
            }
        }
        #endregion
        #region 查询
        private void BtnSave_Click(object sender, EventArgs e)
        {
            LblZhj.Text = "总合计：0.00元";
            LblByhj.Text = "本页合计：0.00元";
            if (PriLevel == -1)
            {
                ClsMsgBox.Ts("请选择要查询的受理机构！", ObjG.CustomMsgBox, this);
                return;
            }
            else if (PriLevel == 0)
            {
                ClsMsgBox.Ts("请选择正确的受理机构！", ObjG.CustomMsgBox, this);
                return;
            }
            PriYwqy = CmbYwqy.SelectedValue.ToString();
            PriKssj = DtpStart.Value.Date;
            PriJssj = DtpStop.Value.Date.AddDays(1);
            PriSldqid = Convert.ToInt32(Txtsldq.Tag.ToString());
            PriYwxz = Cmbywxz.SelectedValue.ToString();
            try
            {
                //DataTable dt = ClsRWMSSQLDb.GetDataTable(GetSQLstr(), ClsGlobals.CntStrTMS);
                Getdatatable(PriJgid, PriLevel, PriYwqy, PriKssj, PriJssj, PriSldqid, PriYwxz);
            }
            catch (Exception)
            {
                ClsMsgBox.Ts("查询异常！", ObjG.CustomMsgBox, this);
            }
        }
        private void Dgv_PagingChanged(object sender, EventArgs e)
        {
            Heji((DataTable)Dgv.DataSource);
        }
        private void Dgv_Sorted(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0) return;
            Heji((DataTable)Dgv.DataSource);
        }
        public void Heji(DataTable dt)
        {
            decimal PageCount = 0;
            //一共有多少行
            int rowcount = Convert.ToInt32(Dgv.RowCount);
            //当前是第几页
            int currentpage = Convert.ToInt32(Dgv.CurrentPage);
            //一页有多少行
            int pageSize = Convert.ToInt32(Dgv.ItemsPerPage);
            //如果总行数小于或等于每页显示行数
            if (rowcount <= pageSize)
                PageCount = dt.AsEnumerable().Sum(r => Convert.ToDecimal(r["zyf"]));
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    if (i >= Dgv.Rows.Count)
                        break;
                    decimal n;
                    if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtzyf.Name].Value.ToString(), out n))
                    {
                        PageCount += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtzyf.Name].Value.ToString());
                    }
                }

            }


            LblByhj.Text = "本页合计：" + PageCount + "元";
        }
        //private string GetSQLstr()
        //    {
        //    string SQLstr = "";
        //    string awhere = "  and   inssj >= '" + DtpStart.Value.Date + "' and  inssj<'" + DtpStop.Value.Date.AddDays(1) + "'";
        //    if (PriYwqy != "0")
        //        awhere = awhere + " and ywqy='" + PriYwqy + "' ";
        //    if (PriLevel == 1)
        //        SQLstr = "SELECT  id3 as jgid,mc3 as jgmc,sum(ffsr) as ffsr ,sum(tfsr) as tfsr,sum(zfsr) as zfsr,sum(hfsr) as hfsr,sum(hjsr) as hjsr,sum(ffbf) as ffbf,sum(tfbf) as tfbf ,sum(zfbf) as zfbf,sum(hfbf) as hfbf,sum(hjbh) as hjbh,sum(zyf) as zyf,2 as level FROM  Vfmssrqkcx where id2=" + PriJgid + awhere + "  group by id3,mc3";
        //    else if (PriLevel == 2)
        //        SQLstr = "SELECT  id4 as jgid,mc4 as jgmc,sum(ffsr) as ffsr ,sum(tfsr) as tfsr,sum(zfsr) as zfsr,sum(hfsr) as hfsr,sum(hjsr) as hjsr,sum(ffbf) as ffbf,sum(tfbf) as tfbf ,sum(zfbf) as zfbf,sum(hfbf) as hfbf,sum(hjbh) as hjbh,sum(zyf) as zyf,3 as level FROM  Vfmssrqkcx where id3=" + PriJgid + awhere + "group by id4,mc4";
        //    else if (PriLevel == 3)
        //        SQLstr = "SELECT  id5 as jgid,mc5 as jgmc,sum(ffsr) as ffsr ,sum(tfsr) as tfsr,sum(zfsr) as zfsr,sum(hfsr) as hfsr,sum(hjsr) as hjsr,sum(ffbf) as ffbf,sum(tfbf) as tfbf ,sum(zfbf) as zfbf,sum(hfbf) as hfbf,sum(hjbh) as hjbh,sum(zyf) as zyf,4 as level FROM  Vfmssrqkcx where id4=" + PriJgid + awhere + " group by id5,mc5";
        //    else if (PriLevel == 4)
        //        SQLstr = "  SELECT  id6 as jgid,mc6 as jgmc,sum(ffsr) as ffsr ,sum(tfsr) as tfsr,sum(zfsr) as zfsr,sum(hfsr) as hfsr,sum(hjsr) as hjsr,sum(ffbf) as ffbf,sum(tfbf) as tfbf ,sum(zfbf)as zfbf,sum(hfbf) as hfbf,sum(hjbh) as hjbh,sum(zyf) as zyf,5 as level FROM  Vfmssrqkcx where id5=" + PriJgid + awhere + " group by id6,mc6 ";
        //    else if (PriLevel == 5)
        //        SQLstr = " SELECT   id6 as jgid,mc6 as jgmc,sum(ffsr) as ffsr ,sum(tfsr) as tfsr,sum(zfsr) as zfsr,sum(hfsr) as hfsr,sum(hjsr) as hjsr,sum(ffbf) as ffbf,sum(tfbf) as tfbf ,sum(zfbf) as zfbf,sum(hfbf) as hfbf,sum(hjbh) as hjbh,sum(zyf) as zyf,5 as level FROM  Vfmssrqkcx where id6 =" + PriJgid + awhere + " group by id6,mc6";
        //    return SQLstr;
        //    }
        #endregion
        #region 双击事件
        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            //判断层级 
            if (!Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtLever.Name].Value.ToString(), out PriLevel))
                return;
            PriJgid = Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgid.Name].Value.ToString();
            PriJgmc = Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgmc.Name].Value.ToString();
            TxtSljg.Text = PriJgmc;



            PriSldqid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdqid.Name].Value.ToString());
            PriYwxz = Dgv.Rows[e.RowIndex].Cells[DgvColTxtywxz.Name].Value.ToString();

            if (PriLevel != 5)
            {
                Getdatatable(PriJgid, PriLevel, PriYwqy, PriKssj, PriJssj, PriSldqid, PriYwxz);
            }
            else
            {
                FrmSRCXYDXX f = new FrmSRCXYDXX();
                f.Prepare(PriKssj, PriJssj, PriJgid, CmbYwqy.Text, PriJgmc);
                f.ShowDialog();
            }
        }
        #endregion

        protected void Getdatatable(string jgid, int level, string ywqy, DateTime st, DateTime et, int sldqid, string ywxz)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 40;
                    cmd.Connection = conn;
                    cmd.CommandText = "P_Srqkcx";
                    cmd.Parameters.Add(new SqlParameter("@jgid", jgid));
                    cmd.Parameters.Add(new SqlParameter("@ywqy", ywqy));
                    cmd.Parameters.Add(new SqlParameter("@st", st));
                    cmd.Parameters.Add(new SqlParameter("@et", et));
                    cmd.Parameters.Add(new SqlParameter("@level", level));
                    cmd.Parameters.Add(new SqlParameter("@sldqid", sldqid));
                    cmd.Parameters.Add(new SqlParameter("@ywxz", ywxz));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                }
                conn.Close();
            }
            Dgv.DataSource = dt;
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("没有要查询的信息，请核对查询条件！", ObjG.CustomMsgBox, this);
                return;
            }
            LblZhj.Text = "总合计：" + dt.AsEnumerable().Sum(r => Convert.ToDecimal(r["zyf"])) + "元";
            Heji((DataTable)Dgv.DataSource);

        }

        private void BtnExlym_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("没有需要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }

            int[] RowIndex = { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            ClsExcel.CreatExcel(Dgv, "收入情况", ctrlDownLoad1, RowIndex, true);
        }

        private void Btndq_Click(object sender, EventArgs e)
        {
            FrmSelectDq f = new FrmSelectDq();
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(fsl_FormClosing);
        }
        void fsl_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FrmSelectDq f = sender as FrmSelectDq)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    Txtsldq.Text = f.PubDictAttrs["dqmc"].ToString();
                    Txtsldq.Tag = f.PubDictAttrs["dqid"].ToString();
                }
                else
                {
                    Txtsldq.Text = "";
                    Txtsldq.Tag = "0";
                }
            }
        }

    }
}