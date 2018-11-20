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
using FMS.SeleFrm;
using JY.Pri;
using JY.Pub;
#endregion

namespace FMS.CXTJ.SRQKCX
{
    public partial class FrmSRCXLSZD : Form
    {
        #region 成员变量
        private ClsG ObjG;
        private int PriLevel = 0;
        private int PriJgid = 0;
        private string PriYwqy = "";
        private string PriKssj = "";
        private string PriJssj = "";
        #endregion
        public FrmSRCXLSZD()
        {
            InitializeComponent();
        }
        public void Prepare(string akssj, string ajssj, int ajgid, string aywqy, string ajgmc)
        {
            ObjG = Session["ObjG"] as ClsG;
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            CmbYwqy.SelectedValue = aywqy;
            DtpStart.Value = Convert.ToDateTime(akssj);
            DtpStop.Value = Convert.ToDateTime(ajssj);
            PriJgid = ajgid;
            this.TxtSljg.Text = ajgmc;
            PriLevel = 4;
            string SQLstr = "";
            PriYwqy = CmbYwqy.SelectedValue.ToString();
            PriKssj = DtpStart.Text;
            PriJssj = DtpStop.Text;
            string awhere = "  and   inssj between '" + akssj + "' and  DateAdd(dd,+1,  '" + ajssj + "')";
            if (aywqy != "0")
                awhere = awhere + " and ywqy='" + aywqy + "' ";
            SQLstr = "  SELECT  id6 as jgid,mc6 as jgmc,sum(ffsr) as ffsr ,sum(tfsr) as tfsr,sum(zfsr) as zfsr,sum(hfsr) as hfsr,sum(hjsr) as hjsr,sum(ffbf) as ffbf,sum(tfbf) as tfbf ,sum(zfbf)as zfbf,sum(hfbf) as hfbf,sum(hjbh) as hjbh,sum(zyf) as zyf,5 as level FROM  Vfmssrqkcx where id5=" + PriJgid + awhere + " group by id6,mc6 ";
            Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(SQLstr, ClsGlobals.CntStrTMS);
            BtnSave.PerformClick();
        }
        private void BtnJG_Click(object sender, EventArgs e)
        {
            FrmSelectJg3 f = new FrmSelectJg3();
            f.Prepare(4);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg3 f = sender as FrmSelectJg3;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtSljg.Text = f.PubDictAttrs["mc"];
                PriJgid = Convert.ToInt32(f.PubDictAttrs["id"]);
                PriLevel = Convert.ToInt32(f.PubDictAttrs["level"]);
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtSljg.Text = "";
                PriLevel = PriJgid = 0;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            LblZhj.Text = "总合计：0.00元";
            LblByhj.Text = "本页合计：0.00元";
            if (PriLevel == 0)
            {
                ClsMsgBox.Ts("请选择要查询的受理机构！", ObjG.CustomMsgBox, this);
                return;
            }
            PriYwqy = CmbYwqy.SelectedValue.ToString();
            PriKssj = DtpStart.Text;
            PriJssj = DtpStop.Text;
            try
            {
                DataTable dt = ClsRWMSSQLDb.GetDataTable(GetSQLstr(), ClsGlobals.CntStrTMS);
                Dgv.DataSource = dt;
                if (Dgv.Rows.Count == 0)
                    ClsMsgBox.Ts("没有要查询的信息，请核对查询条件！", ObjG.CustomMsgBox, this);
                if (Dgv.Rows.Count > 0)
                {
                    LblZhj.Text = "总合计：" + dt.AsEnumerable().Sum(r => Convert.ToDecimal(r["zyf"])) + "元";
                    Heji();
                }
            }
            catch (Exception)
            {
                ClsMsgBox.Ts("查询异常！", ObjG.CustomMsgBox, this);
            }
        }
        private void Dgv_PagingChanged(object sender, EventArgs e)
        {
            Heji();
        }
        private void Dgv_Sorted(object sender, EventArgs e)
        {
            Heji();
        }
        public void Heji()
        {
            DataTable dt = ClsRWMSSQLDb.GetDataTable(GetSQLstr(), ClsGlobals.CntStrTMS);
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
                //计算是不是正好每页都填满
                if (rowcount % pageSize == 0)
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                    {
                        decimal n;
                        if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtzyf.Name].Value.ToString(), out n))
                        {
                            PageCount += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtzyf.Name].Value.ToString());
                        }
                    }
                }
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

            }
            LblByhj.Text = "本页合计：" + PageCount + "元";
        }
        private string GetSQLstr()
        {
            string SQLstr = "";
            string awhere = "  and   inssj between '" + DtpStart.Text + "' and  DateAdd(dd,+1, '" + DtpStop.Text + "')";
            if (PriYwqy != "0")
                awhere = awhere + " and ywqy='" + PriYwqy + "' ";
            if (PriLevel == 1)
                SQLstr = "SELECT  id3 as jgid,mc3 as jgmc,sum(ffsr) as ffsr ,sum(tfsr) as tfsr,sum(zfsr) as zfsr,sum(hfsr) as hfsr,sum(hjsr) as hjsr,sum(ffbf) as ffbf,sum(tfbf) as tfbf ,sum(zfbf) as zfbf,sum(hfbf) as hfbf,sum(hjbh) as hjbh,sum(zyf) as zyf,2 as level FROM  Vfmssrqkcx where id2=" + PriJgid + awhere + "  group by id3,mc3";
            else if (PriLevel == 2)
                SQLstr = "SELECT  id4 as jgid,mc4 as jgmc,sum(ffsr) as ffsr ,sum(tfsr) as tfsr,sum(zfsr) as zfsr,sum(hfsr) as hfsr,sum(hjsr) as hjsr,sum(ffbf) as ffbf,sum(tfbf) as tfbf ,sum(zfbf) as zfbf,sum(hfbf) as hfbf,sum(hjbh) as hjbh,sum(zyf) as zyf,3 as level FROM  Vfmssrqkcx where id3=" + PriJgid + awhere + "group by id4,mc4";
            else if (PriLevel == 3)
                SQLstr = "SELECT  id5 as jgid,mc5 as jgmc,sum(ffsr) as ffsr ,sum(tfsr) as tfsr,sum(zfsr) as zfsr,sum(hfsr) as hfsr,sum(hjsr) as hjsr,sum(ffbf) as ffbf,sum(tfbf) as tfbf ,sum(zfbf) as zfbf,sum(hfbf) as hfbf,sum(hjbh) as hjbh,sum(zyf) as zyf,4 as level FROM  Vfmssrqkcx where id4=" + PriJgid + awhere + " group by id5,mc5";
            else if (PriLevel == 4)
                SQLstr = "  SELECT  id6 as jgid,mc6 as jgmc,sum(ffsr) as ffsr ,sum(tfsr) as tfsr,sum(zfsr) as zfsr,sum(hfsr) as hfsr,sum(hjsr) as hjsr,sum(ffbf) as ffbf,sum(tfbf) as tfbf ,sum(zfbf)as zfbf,sum(hfbf) as hfbf,sum(hjbh) as hjbh,sum(zyf) as zyf,5 as level FROM  Vfmssrqkcx where id5=" + PriJgid + awhere + " group by id6,mc6 ";
            else if (PriLevel == 5)
                SQLstr = " SELECT   id6 as jgid,mc6 as jgmc,sum(ffsr) as ffsr ,sum(tfsr) as tfsr,sum(zfsr) as zfsr,sum(hfsr) as hfsr,sum(hjsr) as hjsr,sum(ffbf) as ffbf,sum(tfbf) as tfbf ,sum(zfbf) as zfbf,sum(hfbf) as hfbf,sum(hjbh) as hjbh,sum(zyf) as zyf,5 as level FROM  Vfmssrqkcx where id6 =" + PriJgid + awhere + " group by id6,mc6";
            return SQLstr;
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            //判断层级 
            int n;
            int aLevel = 0;
            if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtLever.Name].Value.ToString(), out n))
                aLevel = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtLever.Name].Value.ToString());
            int ajgid = 0;
            if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgid.Name].Value.ToString(), out n))
                ajgid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgid.Name].Value.ToString());
            string ajgmc = Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgmc.Name].Value.ToString();
            if (aLevel == 0 || ajgid == 0)
            {
                ClsMsgBox.Ts("查询异常！", ObjG.CustomMsgBox, this);
                return;
            }
            //int aLevel = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtLever.Name].Value.ToString());
            //int ajgid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgid.Name].Value.ToString());
            //string ajgmc = Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgmc.Name].Value.ToString();
            if (aLevel == 5 && PriLevel != 5)
            { 
                FrmSRCXLSD f = new FrmSRCXLSD();
                f.Prepare(PriKssj, PriJssj, ajgid, PriYwqy, ajgmc);
                f.ShowDialog();
            }
            else if (aLevel == 5 && PriLevel == 5)
            {
                FrmSRCXYDXX f = new FrmSRCXYDXX();
                //f.Prepare(PriKssj, PriJssj, ajgid, PriYwqy, ajgmc);
                f.ShowDialog();
            }
        }
    }
}