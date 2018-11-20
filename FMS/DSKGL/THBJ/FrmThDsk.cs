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
using System.Data.SqlClient;
using FMS.SeleFrm;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Configuration;
#endregion
namespace FMS.DSKGL.THBJ
{
    public partial class FrmThDsk : UserControl
    {
        List<ClsBhStr> PriYkyy = new List<ClsBhStr>();
        public class ClsBhStr
        {
            public ClsBhStr(string aBh, string aMc)
            {
                Bh = aBh;
                Mc = aMc;
            }
            public string Bh { set; get; }
            public string Mc { set; get; }
            public string Bh_Mc
            {
                get
                {
                    return Bh + ":" + Mc;
                }
            }
        }
        #region 成员变量
        private ClsG ObjG;
        private string PriConStr;
        private int PriUserId = 0;
        private int PriJgid = 0;
        private string PriZh = "";
        private string PriXm = "";
        private int pageSize = 0;
        private string PriSql = "";
        private double PriSum = 0;
        private bool PriQx = true;
        private List<int> PriListDskid = new List<int>();
        private List<int> PriListJYYdid = new List<int>();
        private List<int> PriListYKYdid = new List<int>();
        private List<string> PriLstYkyy = new List<string>();
        private List<int> PriLis = new List<int>();


        #endregion
        #region 初始化
        public FrmThDsk()
        {
            InitializeComponent();
            PriYkyy.Add(new ClsBhStr("J", "集团无主货"));
            PriYkyy.Add(new ClsBhStr("D", "大区未提货"));
            PriYkyy.Add(new ClsBhStr("Z", "正常退货"));
            PriYkyy.Add(new ClsBhStr("Y", "异常退货"));
            DgvCmb.DataSource = PriYkyy;
            DgvCmb.DisplayMember = "mc";
            DgvCmb.ValueMember = "bh";
        }
        public void Prepare()
        {
            PriConStr = ClsGlobals.CntStrTMS;
            this.VfmsthdskTableAdapter1.Connection.ConnectionString = PriConStr;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriUserId = ObjG.Renyuan.id;
            PriZh = ObjG.Renyuan.loginName;
            PriXm = ObjG.Renyuan.xm;
            PriJgid = ObjG.Jigou.id;
            this.ActiveControl = BtnJg;
            ClsPopulateCmbDsS.PopuYd_ydzts(CmbThydzt);
            CmbThydzt.SelectedIndex = 0;
            CmbDsk.SelectedIndex = 0;
            Cmbqsjgyc.SelectedIndex = 0;
            CmbQszt.SelectedIndex = 0;
            GetYkyy();
            pageSize = Convert.ToInt32(Dgv.ItemsPerPage);
        }
        private void GetYkyy()
        {
            DataTable DtYkyy = new DataTable();
            DtYkyy.Columns.Add("mc", typeof(string));
            DtYkyy.Columns.Add("bh", typeof(string));
            DataRow dr0 = DtYkyy.NewRow();
            dr0["mc"] = "W";
            dr0["bh"] = "--请选择--";
            DtYkyy.Rows.Add(dr0);

            DataRow dr1 = DtYkyy.NewRow();
            dr1["mc"] = "J";
            dr1["bh"] = "集团无主货";
            DtYkyy.Rows.Add(dr1);

            DataRow dr2 = DtYkyy.NewRow();
            dr2["mc"] = "D";
            dr2["bh"] = "大区未提货";
            DtYkyy.Rows.Add(dr2);

            DataRow dr3 = DtYkyy.NewRow();
            dr3["mc"] = "Z";
            dr3["bh"] = "正常退货";
            DtYkyy.Rows.Add(dr3);

            DataRow dr4 = DtYkyy.NewRow();
            dr4["mc"] = "Y";
            dr4["bh"] = "异常退货";
            DtYkyy.Rows.Add(dr4);
            ClsPopulateCmbDsS.PopuByTb(this.Cmbbz, DtYkyy, "mc", "bh");
        }

        #endregion
        #region 查询
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.ChkB.Checked = false;
                PriSql = "";
                string Where = " where qszt='" + CmbQszt.Text + "'";
                int jgid = 0;
                if (TxtSQjg.Text.Trim().Length > 0)
                    jgid = Convert.ToInt32(TxtSQjg.Tag.ToString());
                if (jgid > 0)
                    Where += "   and sqjgid in (SELECT id FROM jyjckj.dbo.tjigou WHERE id LIKE '," + jgid + ",') ";
                if (DtpStart.Checked)
                    Where += "   and sqsj>='" + DtpStart.Value.Date + "' ";
                if (DtpStop.Checked)
                    Where += "   and sqsj<'" + DtpStop.Value.Date + "' ";
                if (!string.IsNullOrEmpty(TxtYdbh.Text.Trim()))
                    Where += "   and xbh='" + TxtYdbh.Text.Trim() + "' ";
                if (DtpBzStart.Checked)
                    Where += "   and bzsj>='" + DtpBzStart.Value.Date + "' ";
                if (DtpBzStop.Checked)
                    Where += "   and bzsj<'" + DtpBzStop.Value.Date + "' ";
                if (Cmbqsjgyc.SelectedIndex > 0)
                    Where += "   and qsjgzc='" + Cmbqsjgyc.Text + "' ";
                if (CmbThydzt.SelectedIndex > 0)
                    Where += "   and xydzt='" + Cmbqsjgyc.Text + "' ";
                if (CmbDsk.SelectedIndex > 0)
                {
                    if (CmbDsk.SelectedIndex == 1)
                        Where += "   and dsk>0 ";
                    else if (CmbDsk.SelectedIndex == 2)
                        Where += "   and dsk=0 ";
                }
                this.VfmsthdskTableAdapter1.FillByWhere(DSYDTH1.Vfmsthdsk, Where);
                if (Bds.Count == 0)
                    ClsMsgBox.Ts("无查询信息，请核对查询条件！", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("查询异常！", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion
        #region 备注
        private void BtnYk_Click(object sender, EventArgs e)
        {
            PriSql = "";
            PriLis.Clear();
            GetDskyhLog();
            if (PriSql.Length == 0)
            {
                ClsMsgBox.Ts("请选择要保存的信息或选择的信息中没有标记备注类型！", ObjG.CustomMsgBox, this);
                return;
            }
            using (SqlConnection conn = new SqlConnection(PriConStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand();
                try
                {
                    comm.Connection = conn;
                    comm.Transaction = trans;
                    string cmdText = "";
                    cmdText = PriSql;
                    comm.CommandText = cmdText;
                    int influenceSum = comm.ExecuteNonQuery();

                    if (influenceSum > 0)
                    {
                        //提交事物
                        ClsMsgBox.Ts("备注成功！共备注" + PriLis.Count + "条信息", ObjG.CustomMsgBox, this);
                        trans.Commit();
                        foreach (int i in PriLis)
                        {
                            int index = Bds.Find("id", i);
                            Bds.RemoveAt(index);
                        }
                        PriSql = "";
                        PriLis.Clear();

                    }
                    else
                    {
                        //回滚事物
                        ClsMsgBox.Ts("备注失败！", ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    //回滚事物
                    try
                    {
                        ClsMsgBox.Cw("备注异常！", ex, ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                    catch (SqlException ex1)
                    {
                        if (trans.Connection != null)
                            ClsMsgBox.Cw("回滚失败! 异常类型:" + ex1.GetType(), ex1, ObjG.CustomMsgBox, this);
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region 生成记录

        private void GetDskyhLog()
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {

                if (Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                {
                    if (row.Cells[DgvCmb.Name].Value.ToString().Length > 0)
                    {
                        int tzid = Convert.ToInt32(row.Cells[DgvColTxtid.Name].Value.ToString());
                        PriSql += " update  Tydtz set  thbz='" + row.Cells[DgvCmb.Name].Value + "',bzsj=getdate(),bzUserid=" + PriUserId + ",bzUserXm='" + PriXm + "'     where id= " + tzid + "; ";
                        PriLis.Add(tzid);
                    }
                }

            }
        }
        #endregion

        #region 鼠标单击
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1)
                return;
            if (e.ColumnIndex == 0)
            {
                string qszt = Dgv.Rows[e.RowIndex].Cells[DgvColTxtqszt.Name].Value.ToString();


                int aid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtid.Name].Value.ToString());
                double n;
                double RowDsk = 0;
                if (double.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString(), out n))
                    RowDsk = Convert.ToDouble(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvColCbm.Name].Value))//取消选择
                {
                    Dgv.Rows[e.RowIndex].Cells[DgvColCbm.Name].Value = false;

                    PriSum = PriSum - RowDsk;
                }
                else
                {

                    Dgv.Rows[e.RowIndex].Cells[DgvColCbm.Name].Value = true;
                    if (qszt == "未签收")
                    {
                        PriListYKYdid.Add(aid);
                        if (Cmbbz.SelectedIndex > 0)
                            Dgv.Rows[e.RowIndex].Cells[DgvCmb.Name].Value = Cmbbz.SelectedValue;
                    }
                    else
                        PriListJYYdid.Add(aid);
                    PriListDskid.Add(aid);

                    PriSum = PriSum + RowDsk;
                }

            }
        }


        #endregion
        #region 机构
        private void BtnJg_Click(object sender, EventArgs e)
        {
            FrmSelectJg f = new FrmSelectJg();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            this.TxtSQjg.Text = f.PubDictAttrs["mc"];
            this.TxtSQjg.Tag = f.PubDictAttrs["id"];
        }
        #endregion
        #region 本页全选
        private void BtnCheck_Click(object sender, EventArgs e)
        {

            if (!PriQx)
            {
                ClsMsgBox.Ts("查询结果是全部,无法进行全选功能！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.Rows.Count == 0)
                return;
            CheckThisPage();

        }
        public void CheckThisPage()
        {
            //本页有多少行
            int currenRows = 0;
            if (Dgv.CurrentPage == Dgv.TotalPages)
                currenRows = Dgv.RowCount - (Dgv.TotalPages - 1) * pageSize;
            else
                currenRows = pageSize;
            for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + currenRows; i++)
            {
                if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value))
                {
                    Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;
                }

            }
        }
        #endregion

        #region 全选
        private void ChkB_CheckedChanged(object sender, EventArgs e)
        {
            CheckAll(ChkB.Checked);
        }
        public void CheckAll(bool aChecked)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                row.Cells[DgvColCbm.Name].Value = aChecked;
            }
        }
        #endregion
        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "退货代收款", this.ctrlDownLoad1, new int[] { 4, 5 });
        }

        #endregion



        private void CmbYkyy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            if (PriYkyy.Count == 0)
                return;
            if (Cmbbz.SelectedIndex <= 0)
                return;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                {
                    row.Cells[DgvCmb.Name].Value = this.Cmbbz.SelectedValue;

                }
            }
        }
    }
}
