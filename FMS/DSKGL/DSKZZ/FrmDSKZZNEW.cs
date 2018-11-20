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
using FMS.SeleFrm;
using System.Data.SqlClient;
using JY.Pri;
using System.Data.SqlClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using JYPubFiles.Classes;
using Gizmox.WebGUI.Common.Interfaces;
using System.Configuration;
using FMS.DSKGL.ZZYCDSKMX;
#endregion

namespace FMS.DSKGL.DSKZZ
{
    public partial class FrmDSKZZNEW : Form
    {

        #region 成员变量
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private decimal PriZj;
        private decimal PriYcje;//与PriZj对比数据是否准确
        private int ChkRowCount;
        private int PriRowCount;//与ChkRowCount对比数据是否准确
        private string CmdText;
        private string PriZffs;
        private string PriRbbh;
        private string PriRbpcid;
        //private List<string> LstSql = new List<string>();
        private List<int> LstYdid = new List<int>();
        private string PriFwjgid;
        private bool IsChecked;
        private int PriUpdRows;
        private int PriZflx = 0;
        //private DataTable Prizflxss = new DataTable();
        private string PriConStr;
        private FrmMsgBox Box = new FrmMsgBox();
        #endregion

        #region 加载页面
        public FrmDSKZZNEW()
        {
            InitializeComponent();
        }
        #endregion

        #region 初始化数据
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            vfmsdskzz3TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            PriJgDt = ClsRWMSSQLDb.GetDataTable("select tojgmc,tojgid from vfmsjggx where gxzl='D' and jgid=" + ObjG.Jigou.id, ClsGlobals.CntStrTMS);
            if (PriJgDt.Rows.Count == 1)
            {
                LblFwjgmc.Text = PriJgDt.Rows[0]["tojgmc"].ToString();
                PriFwjgid = PriJgDt.Rows[0]["tojgid"].ToString();
            }
            //ClsPopulateCmbDsS.PopuYd_jylx(Cmbzffs, ClsGlobals.CntStrKj);//交易类型绑定 
            ClsPopulateCmbDsS.PopuYd_dshklx(CmbDszl, ClsGlobals.CntStrKj);//代收货款类型
            CmbZffs.SelectedIndex = 0;
            CmbDszl.SelectedIndex = 0;
            //Prizflxss.Columns.Add("lxmc", Type.GetType("System.String"));//类型名称 
            //Prizflxss.Columns.Add("lx", Type.GetType("System.String"));//类型  0-线下 1-线上 2-二维码
            //Prizflxss.Columns.Add("je", Type.GetType("System.Decimal"));//金额 
            //Prizflxss.Columns.Add("hybh", Type.GetType("System.String"));//货运编号 
            //Prizflxss.Columns.Add("dskfkfs", Type.GetType("System.String"));//付款方式 
            //Prizflxss.Columns.Add("lxADDdskfkfs", Type.GetType("System.String"));//类型+付款方式 
            ClsPopulateCmbDsS.PopuYd_dshksqfsALL(Cmbfkfs);
            Cmbfkfs.SelectedIndex = 0;
            PriConStr = ClsGlobals.CntStrTMS;
        }
        #endregion

        #region 受理机构查询
        private void BtnSearchjg_Click(object sender, EventArgs e)
        {
            FrmSelectJg f = new FrmSelectJg();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
                this.txtsljg.Text = f.PubDictAttrs["mc"];
            else if (f.DialogResult == DialogResult.No)
                this.txtsljg.Text = "";
        }
        #endregion

        #region 对Prizflxss进行操作
        //private int FindRowIndex(DataRow dr)
        //{
        //    return Prizflxss.Rows.IndexOf(dr);
        //}

        //private DataRow[] GerRows(string aydbh)
        //{
        //    return Prizflxss.Select(string.Format(" hybh='{0}' ", aydbh));
        //}

        //private void RemoveRows(string aydbh)
        //{
        //    DataRow[] dr = GerRows(aydbh);
        //    if (dr.Length > 0)
        //        Prizflxss.Rows.RemoveAt(FindRowIndex(dr[0]));
        //}

        #endregion

        #region 客户查询
        private void BtnSearchKh_Click(object sender, EventArgs e)
        {
            FrmSelectKh f = new FrmSelectKh();
            f.Prepare();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectKh f = sender as FrmSelectKh;
            if (f.DialogResult == DialogResult.OK)
                Txtfhkh.Text = f.PubKhmc;
        }
        #endregion

        #region 编号回车键事件
        private void TxtBh_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            this.BtnKsxz.PerformClick();
        }
        #endregion

        #region 快速选择
        private void BtnKsxz_Click(object sender, EventArgs e)
        {
            LblTs.Visible = true;
            IsChecked = false;
            if (string.IsNullOrEmpty(TxtBh.Text))
            {
                LblTs.Text = "先录入货运编号！";
                LblTs.ForeColor = Color.Red;
                return;
            }
            //DataRow newRow;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (row.Cells[DgvColTxthydh.Name].Value.ToString().Trim().Equals(TxtBh.Text) && !Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                {
                    row.Cells[DgvColTxtCheck.Name].Value = true;
                    Bds.Position = row.Index;
                    IsChecked = true;
                    PriZj += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                    ChkRowCount++;
                    //string hydh = row.Cells[DgvColTxthydh.Name].Value.ToString();
                    //if (GerRows(hydh).Length == 0)
                    //{
                    //    newRow = Prizflxss.NewRow();
                    //    newRow["lxmc"] = row.Cells[DgvColTxtzflx.Name].Value.ToString();
                    //    newRow["lx"] = row.Cells[DgvTxtzflxxh.Name].Value.ToString();
                    //    newRow["je"] = row.Cells[DgvColTxtdsk.Name].Value.ToString();
                    //    newRow["hybh"] = row.Cells[DgvColTxthydh.Name].Value.ToString();
                    //    newRow["dskfkfs"] = row.Cells[DgvColTxtdskfkfs.Name].Value.ToString();
                    //    newRow["lxADDdskfkfs"] = row.Cells[DgvTxtzflxxh.Name].Value.ToString() + row.Cells[DgvColTxtdskfkfs.Name].Value.ToString();
                    //    Prizflxss.Rows.Add(newRow);
                    //}
                }
            }
            if (!IsChecked)
            {
                LblTs.Visible = true;
                LblTs.Text = "没有查询到相应运单！";
                LblTs.ForeColor = Color.Red;
                return;
            }
            ClsD.TurnToBdsPosPage(Dgv);
            int RowIndex = Bds.Find("bh", TxtBh.Text);
            LblCheckCount.Text = "共选中" + ChkRowCount + "行";
            LblZjje.Text = PriZj.ToString();
            LblTs.Visible = true;
            string bh = TxtBh.Text;
            TxtBh.Text = "";
            LblTs.Text = "运单号" + bh + "已选中，共选中" + ChkRowCount + "条";
            LblTs.ForeColor = Color.Green;
        }
        #endregion

        #region 反选
        private void BtnFX_Click(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            DataRow newRow;
            if (ChkRowCount == 0)
            {
                ChkQx.Checked = true;
                return;
            }
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                //string hybh = row.Cells[DgvColTxthydh.Name].Value.ToString();
                //DataRow[] dr = GerRows(hybh);
                if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                {
                    row.Cells[DgvColTxtCheck.Name].Value = false;
                    PriZj -= Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                    ChkRowCount--;
                    //RemoveRows(hybh);
                }
                else
                {
                    row.Cells[DgvColTxtCheck.Name].Value = true;
                    PriZj += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                    ChkRowCount++;
                    //if (dr.Length == 0)
                    //{
                    //    newRow = Prizflxss.NewRow();
                    //    newRow["lxmc"] = row.Cells[DgvColTxtzflx.Name].Value.ToString();
                    //    newRow["lx"] = row.Cells[DgvTxtzflxxh.Name].Value.ToString();
                    //    newRow["je"] = row.Cells[DgvColTxtdsk.Name].Value.ToString();
                    //    newRow["hybh"] = row.Cells[DgvColTxthydh.Name].Value.ToString();
                    //    newRow["dskfkfs"] = row.Cells[DgvColTxtdskfkfs.Name].Value.ToString();
                    //    newRow["lxADDdskfkfs"] = row.Cells[DgvTxtzflxxh.Name].Value.ToString() + row.Cells[DgvColTxtdskfkfs.Name].Value.ToString();
                    //    Prizflxss.Rows.Add(newRow);
                    //}
                }
            }
            LblCheckCount.Text = "共选中" + ChkRowCount + "行";
            LblZjje.Text = PriZj.ToString();
            if (ChkRowCount == 0)
            {
                ChkQx.Checked = false;
                return;
            }
        }
        #endregion

        #region 本页全选
        private void BtnCheck_Click_1(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            if (Dgv.Rows.Count == 0)
                return;
            CheckThisPage();
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "共选中" + ChkRowCount + "行";
        }

        public void CheckThisPage()
        {
            if (Bds.Count == 0)
                return;
            int curPageFirstIndex = (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;//获取当前页的第一行的RowIndex
            int lastPageSize = Dgv.RowCount - (Dgv.TotalPages - 1) * Dgv.ItemsPerPage; //获取最后一页的行数
            int curPageSize = Dgv.CurrentPage != Dgv.TotalPages ? Dgv.ItemsPerPage : lastPageSize; //获取每页的行数（考虑最后一页）
            int curRowIndex = curPageFirstIndex;
            while ((curRowIndex) < (curPageFirstIndex + curPageSize))
            {
                //string hybh = Dgv.Rows[curRowIndex].Cells[DgvColTxthydh.Name].Value.ToString();
                //DataRow[] dr = GerRows(hybh);
                if (!Convert.ToBoolean(Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value).Equals(true))
                {
                    Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value = true;
                    PriZj += Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtdsk.Name].Value);
                    ChkRowCount++;
                    //if (dr.Length == 0)
                    //{
                    //    DataRow newRow = Prizflxss.NewRow();
                    //    newRow["lxmc"] = Dgv.Rows[curRowIndex].Cells[DgvColTxtzflx.Name].Value;
                    //    newRow["lx"] = Dgv.Rows[curRowIndex].Cells[DgvTxtzflxxh.Name].Value;
                    //    newRow["je"] = Dgv.Rows[curRowIndex].Cells[DgvColTxtdsk.Name].Value;
                    //    newRow["hybh"] = Dgv.Rows[curRowIndex].Cells[DgvColTxthydh.Name].Value;
                    //    newRow["dskfkfs"] = Dgv.Rows[curRowIndex].Cells[DgvColTxtdskfkfs.Name].Value;
                    //    newRow["lxADDdskfkfs"] = Dgv.Rows[curRowIndex].Cells[DgvTxtzflxxh.Name].Value.ToString() + Dgv.Rows[curRowIndex].Cells[DgvColTxtdskfkfs.Name].Value.ToString();
                    //    Prizflxss.Rows.Add(newRow);
                    //}
                }
                //else
                //{
                //    Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value = false;
                //    PriZj -= Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtdsk.Name].Value);
                //    ChkRowCount--;
                //    RemoveRows(hybh);
                //}
                curRowIndex++;
            }
        }
        #endregion

        #region 单行选择
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblTs.Visible = false;
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                //DataRow newRow;
                //string hybh = Dgv.Rows[e.RowIndex].Cells[DgvColTxthydh.Name].Value.ToString();
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    ChkRowCount--;
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    PriZj -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);

                    //RemoveRows(hybh);
                }
                else
                {
                    ChkRowCount++;
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    PriZj += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                    //if (GerRows(hybh).Length == 0)
                    //{
                    //    newRow = Prizflxss.NewRow();
                    //    newRow["lxmc"] = Dgv.Rows[e.RowIndex].Cells[DgvColTxtzflx.Name].Value;
                    //    newRow["lx"] = Dgv.Rows[e.RowIndex].Cells[DgvTxtzflxxh.Name].Value;
                    //    newRow["je"] = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value;
                    //    newRow["hybh"] = Dgv.Rows[e.RowIndex].Cells[DgvColTxthydh.Name].Value;
                    //    newRow["dskfkfs"] = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdskfkfs.Name].Value;
                    //    newRow["lxADDdskfkfs"] = Dgv.Rows[e.RowIndex].Cells[DgvTxtzflxxh.Name].Value.ToString() + Dgv.Rows[e.RowIndex].Cells[DgvColTxtdskfkfs.Name].Value.ToString();
                    //    Prizflxss.Rows.Add(newRow);
                    //}
                }
            }
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "共选中" + ChkRowCount + "行";
        }
        #endregion

        #region 全选
        private void ChkQx_CheckedChanged(object sender, EventArgs e)
        {
            //Prizflxss.Clear();
            LblTs.Visible = false;
            if (Dgv.Rows.Count == 0)
                return;
            CheckAll(ChkQx.Checked);
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "共选中" + ChkRowCount + "行";
        }
        public void CheckAll(bool aChecked)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                //DataRow newRow;
                if (aChecked)
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                    {
                        row.Cells[DgvColTxtCheck.Name].Value = true;
                        PriZj += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                        ChkRowCount++;
                        //string hydh = row.Cells[DgvColTxthydh.Name].Value.ToString();
                        //if (GerRows(hydh).Length == 0)
                        //{
                        //    newRow = Prizflxss.NewRow();
                        //    newRow["lxmc"] = row.Cells[DgvColTxtzflx.Name].Value;
                        //    newRow["lx"] = row.Cells[DgvTxtzflxxh.Name].Value;
                        //    newRow["je"] = row.Cells[DgvColTxtdsk.Name].Value;
                        //    newRow["hybh"] = row.Cells[DgvColTxthydh.Name].Value;
                        //    newRow["dskfkfs"] = row.Cells[DgvColTxtdskfkfs.Name].Value;
                        //    newRow["lxADDdskfkfs"] = row.Cells[DgvTxtzflxxh.Name].Value.ToString() + row.Cells[DgvColTxtdskfkfs.Name].Value.ToString();
                        //    Prizflxss.Rows.Add(newRow);
                        //}
                    }
                }
                else
                {
                    if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                    {
                        row.Cells[DgvColTxtCheck.Name].Value = false;
                        PriZj -= Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                        ChkRowCount--;
                    }
                }
            }
        }
        #endregion

        #region 查询
        private void BtnSave_Click(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            try
            {
                ChkQx.Checked = false;
                ClsD.TextBoxTrim(this);
                Clear();
                string where = " where qsjgid=" + ObjG.Jigou.id;//签收机构为本机构jgid  
                if (DtpSlStart.Checked)
                    where += " and inssj >= '" + DtpSlStart.Value.Date + "'";
                if (DtpSlStop.Checked)
                    where += " and inssj < '" + DtpSlStop.Value.AddDays(1).Date + "'";//签收时间进行查询
                if (DtpQsStart.Checked)
                    where += " and qssj >= '" + DtpQsStart.Value.Date + "'";
                if (DtpQsStop.Checked)
                    where += " and qssj < '" + DtpQsStop.Value.AddDays(1).Date + "'";//受理时间进行查询
                where += string.IsNullOrEmpty(txtsljg.Text) ? "" : " and sljg ='" + txtsljg.Text + "'";//受理机构查询运单
                where += string.IsNullOrEmpty(Txthydh.Text) ? "" : " and bh='" + Txthydh.Text + "'";//发货客户或运单编号查询 
                //where += Cmbzffs.SelectedIndex == 0 ? "" : " and zflxmc='" + Cmbzffs.Text.Trim() + "'";//支付类型（不为全部）进行查询
                if (CmbZffs.SelectedIndex > 0)
                    where = where + "  and zflxmc='" + CmbZffs.Text + "' ";
                if (Cmbfkfs.SelectedIndex > 0)
                    where += " and dskfkfs='" + Cmbfkfs.SelectedValue + "'";
                where += string.IsNullOrEmpty(Txtfhkh.Text) ? "" : " and fhkhmc ='" + Txtfhkh.Text + "'";//发货客户
                where += CmbDszl.SelectedIndex == 0 ? "" : " and dshklx='" + CmbDszl.Text.Trim() + "'";//代收款类型进行查询 
                where += " ORDER BY dskfkfs,zflxmc,dsffsj,qssj   ";//发放时间类型和签收时间进行排序
                dsdskzznew1.EnforceConstraints = false;
                vfmsdskzz3TableAdapter1.FillByWhere(dsdskzznew1.Vfmsdskzz3, where);
                //PriZffs = Cmbzffs.SelectedValue.ToString();
                if (Bds.Count == 0)
                {
                    ClsMsgBox.Ts("没有查询到代收款中转信息！", ObjG.CustomMsgBox, this);
                    return;
                }
                for (int i = 0; i < Dgv.Rows.Count - 1; i++)
                {
                    int zfzt = 0;
                    int.TryParse(Dgv.Rows[i].Cells[DgvColTxtZfzt.Name].Value.ToString(), out zfzt);
                    if (zfzt == 1)
                    {
                        LblTs.Visible = false;
                        if (Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value))
                        {
                            ChkRowCount--;
                            Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value = false;
                            PriZj -= Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                        }
                        else
                        {
                            ChkRowCount++;
                            Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value = true;
                            PriZj += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                        }
                        LblZjje.Text = PriZj.ToString();
                        LblCheckCount.Text = "共选中" + ChkRowCount + "行";
                    }
                }
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("代收款中转信息查询失败！", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion

        #region 代收款中转后直接跳到制作应存代收款汇总页面
        private void OpenFrm(object sender, EventArgs e)
        {
            FrmMsgBox c = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.OK)
            {
                FrmZZYCDSKTJ f1 = new FrmZZYCDSKTJ();
                f1.ShowDialog();
                f1.Prepare();
            }
        }
        private static void InvokeFocusCommand(Control objControl, Control aControl = null)
        {
            if (aControl == null)
                return;
            IApplicationContext objApplicationContext = aControl.Context as IApplicationContext;
            if (objApplicationContext != null)
                objApplicationContext.SetFocused(objControl, true);
        }
        public static void JGts(string mess, EventHandler hdl, FrmMsgBox aMsgBox = null, Control aParControl = null, float aFontsize = 14)
        {
            aMsgBox.Text = "警告";
            aMsgBox.LblMess.Text = mess;
            aMsgBox.LblMess.Font = new System.Drawing.Font("黑体", aFontsize, System.Drawing.FontStyle.Bold);
            aMsgBox.LblMess.ForeColor = System.Drawing.Color.Red;
            aMsgBox.Btn1.Text = "确定";
            aMsgBox.Btn1.AutoSize = true;
            aMsgBox.Btn1.DialogResult = DialogResult.OK;
            aMsgBox.Btn1.TabStop = true;
            aMsgBox.Tag = null;
            aMsgBox.Btn2.Text = "取消";
            aMsgBox.Btn2.AutoSize = true;
            aMsgBox.Btn2.DialogResult = DialogResult.Cancel;
            aMsgBox.Btn2.Visible = true;
            aMsgBox.ShowDialog();
            aMsgBox.FrmCloseHdl = hdl;
            InvokeFocusCommand(aMsgBox, aParControl);
        }
        #endregion

        #region 中转按钮事件
        private void BtnZz_Click(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            PriRbbh = "D" + DateTime.Now.ToString("yyyyMMdd") + ObjG.Jigou.id;
            if (string.IsNullOrEmpty(LblFwjgmc.Text))
            {
                ClsMsgBox.Ts("该机构没有代收款关系机构，请维护！", this, LblFwjgmc, ObjG.CustomMsgBox);
                return;
            }
            if (ChkRowCount <= 0)
            {
                ClsMsgBox.Ts("请选择要操作的数据记录 ", ObjG.CustomMsgBox, this);
                return;
            }
            DskZZ();
        }
        public void DskZZ()
        {
            LstYdid.Clear();
            PriUpdRows = 0;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsGlobals.CntStrTMS;
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.Transaction = trans;
                    try
                    {
                        int RowCount = 0;//中转的非二维码支付订单个数
                        string QtRbpcid = "0";//非二维码支付日报批次id
                        for (int i = 0; i < Bds.Count; i++)
                        {
                            if ((bool)Dgv.Rows[i].Cells[DgvColTxtCheck.Name].EditedFormattedValue == true)
                            {
                                if (Dgv.Rows[i].Cells[DgvColTxtzflx.Name].Value.Equals("二维码"))
                                {
                                    CmdText = "";
                                    CmdText = string.Format("  SET NOCOUNT OFF insert into Tfmsdskjkpc(rbdh,jgid,zffs,dsk,sxf,zt,cnt,zzsj,zzczyid,zzczyzh,zzczyxm,spjgid,zflx)" +
                                            "  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');select SCOPE_IDENTITY() ",
                                            PriRbbh, ObjG.Jigou.id, Dgv.Rows[i].Cells[DgvColTxtdskfkfs.Name].Value.ToString(), Dgv.Rows[i].Cells[this.DgvColTxtdsk.Name].Value, 0, 0, 1, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriFwjgid, Dgv.Rows[i].Cells[DgvTxtzflxxh.Name].Value.ToString());
                                    comm.CommandText = CmdText;//插入代收缴款日报批次 
                                    PriRbpcid = comm.ExecuteScalar().ToString();
                                    CmdText = string.Format("INSERT INTO Tfmsdskjkmx (pcid,dskid,ydid,dsk,sxf) VALUES('{0}','{1}','{2}','{3}','{4}')",
                         PriRbpcid, Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtYdid.Name].Value.ToString(), Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value, 0);
                                    //CmdText = "";
                                    comm.CommandText = CmdText;//插入代收缴款日报明细 
                                    comm.ExecuteNonQuery();
                                }
                                else
                                {
                                    RowCount++;
                                    if (RowCount == 1)
                                    {
                                        CmdText = string.Format("  SET NOCOUNT OFF insert into Tfmsdskjkpc(rbdh,jgid,zffs,dsk,sxf,zt,cnt,zzsj,zzczyid,zzczyzh,zzczyxm,spjgid,zflx)" +
                                           "  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');select SCOPE_IDENTITY() ",
                                           PriRbbh, ObjG.Jigou.id, Dgv.Rows[i].Cells[DgvColTxtdskfkfs.Name].Value.ToString(), Dgv.Rows[i].Cells[this.DgvColTxtdsk.Name].Value, 0, 0, 1, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriFwjgid, Dgv.Rows[i].Cells[DgvTxtzflxxh.Name].Value.ToString());
                                        comm.CommandText = CmdText;//插入代收缴款日报批次 
                                        QtRbpcid = comm.ExecuteScalar().ToString();
                                    }
                                    else
                                    {
                                        CmdText = string.Format(@"UPDATE tfmsdskjkpc SET dsk=dsk+{0},cnt=cnt+1,zzsj=GETDATE() WHERE id={1}", Dgv.Rows[i].Cells[this.DgvColTxtdsk.Name].Value, QtRbpcid);
                                        comm.CommandText = CmdText;//修改代收款金额和制作时间
                                        comm.ExecuteNonQuery();
                                    }
                                    CmdText = string.Format("INSERT INTO Tfmsdskjkmx (pcid,dskid,ydid,dsk,sxf) VALUES('{0}','{1}','{2}','{3}','{4}')",
                         QtRbpcid, Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtYdid.Name].Value.ToString(), Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value, 0);
                                    //CmdText = "";
                                    comm.CommandText = CmdText;//插入代收缴款日报明细 
                                    comm.ExecuteNonQuery();
                                }
                                LstYdid.Add(Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYdid.Name].Value.ToString()));
                            }
                        }
                        CmdText = "";
                        CmdText = "SET NOCOUNT OFF UPDATE Tfmsdsk SET SJDSKZT=10 WHERE ydid IN (" + string.Join(",", LstYdid) + ") and SJDSKZT=0 ";
                        comm.CommandText = CmdText;//更新代收款的上交代收款状态由原来的未交款变为已中转
                        PriUpdRows = comm.ExecuteNonQuery();
                        if (ChkRowCount != PriUpdRows)
                        {
                            ClsMsgBox.Ts("代收款中转失败!", ObjG.CustomMsgBox, this);
                            trans.Rollback();
                            return;
                        }
                        else
                        {
                            //提交事物
                            trans.Commit();
                            this.Close();
                            int n = ClsRWMSSQLDb.GetInt(" SELECT  jgid  FROM dbo.Tfmsyhzh  WHERE (zhlxid = 50) AND (zt = 0) AND jgid = " + ObjG.Jigou.id, PriConStr);
                            if (n <= 0)
                            {
                                JGts("系统未维护银行账户信息，请与代收款部联系电话：0531-58681288", new EventHandler(OpenFrm), Box, this);
                                return;
                            }
                            FrmZZYCDSKTJ f = new FrmZZYCDSKTJ();
                            f.ShowDialog();
                            f.Prepare(); 
                            ClsMsgBox.Ts("代收款中转成功！共中转" + ChkRowCount + "票,总共" + LblZjje.Text + "元", ObjG.CustomMsgBox, this);
                        }
                    }
                    catch (Exception ex)
                    {
                        ClsMsgBox.Cw("代收款中转失败！", ex, ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

        }
        #region 无效代码
        //public void DskZZ()
        //{
        //    PriUpdRows = 0;
        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.ConnectionString = ClsGlobals.CntStrTMS;
        //        conn.Open();
        //        SqlTransaction trans = conn.BeginTransaction();
        //        using (SqlCommand comm = new SqlCommand())
        //        {
        //            comm.Connection = conn;
        //            comm.Transaction = trans;
        //            try
        //            {



        //                var query = from t in Prizflxss.AsEnumerable()
        //                            group t by new { t1 = t.Field<string>("lx"), t2 = t.Field<string>("dskfkfs"), t3 = t.Field<string>("lxmc"), t4 = t.Field<string>("lxADDdskfkfs") } into m
        //                            select new
        //                            {
        //                                lx = m.Key.t1,
        //                                dskfkfs = m.Key.t2,
        //                                lxmc = m.Key.t3,
        //                                lxADDdskfkfs = m.Key.t4,
        //                                je = m.Sum(n => n.Field<decimal>("je")),
        //                                count = m.Count()
        //                            };
        //                //选择代收款信息，获取支付类型数量     
        //                List<string> lxList = new List<string>();
        //                List<string> lxmcList = new List<string>();
        //                List<string> dskfkfsList = new List<string>();
        //                List<string> lxADDdskfkfsList = new List<string>();
        //                List<decimal> jeList = new List<decimal>();
        //                List<int> countList = new List<int>();

        //                foreach (var item in query.ToList())
        //                {
        //                    if (item.count > 0)
        //                    {
        //                        lxList.Add(item.lx);
        //                        lxmcList.Add(item.lxmc);
        //                        dskfkfsList.Add(item.dskfkfs);
        //                        lxADDdskfkfsList.Add(item.lxADDdskfkfs);
        //                        jeList.Add(item.je);
        //                        countList.Add(item.count);
        //                    }
        //                }
        //                int count = Convert.ToInt32(query.ToList().Count);//获取本次同多少个支付类型
        //                if (count == 1)
        //                {//如果支付类型数量为1
        //                    PriZffs = dskfkfsList[0].ToString();
        //                    PriZflx = Convert.ToInt32(lxList[0].ToString());
        //                    CmdText = string.Format("  SET NOCOUNT OFF insert into Tfmsdskjkpc(rbdh,jgid,zffs,dsk,sxf,zt,cnt,zzsj,zzczyid,zzczyzh,zzczyxm,spjgid,zflx)" +
        //                        "  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');select SCOPE_IDENTITY() ",
        //                        PriRbbh, ObjG.Jigou.id, PriZffs, PriZj, 0, 0, ChkRowCount, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriFwjgid, PriZflx);
        //                    comm.CommandText = CmdText;//插入代收缴款日报批次
        //                    PriRbpcid = comm.ExecuteScalar().ToString();
        //                    GetSql(PriRbpcid);//根据日报批次id向代收缴款日报批次明细表中插入数据
        //                    if (PriYcje != PriZj)
        //                    {
        //                        ClsMsgBox.Ts("代收款中转失败，请重新选择数据！", ObjG.CustomMsgBox, this);
        //                        trans.Rollback();
        //                        return;
        //                    }
        //                    if (PriRowCount != ChkRowCount)
        //                    {
        //                        ClsMsgBox.Ts("代收款中转失败，请重新选择数据！", ObjG.CustomMsgBox, this);
        //                        trans.Rollback();
        //                        return;
        //                    }
        //                    comm.CommandText = string.Join(";", LstSql);
        //                    comm.ExecuteNonQuery();
        //                    CmdText = "";
        //                    CmdText = "SET NOCOUNT OFF UPDATE Tfmsdsk SET SJDSKZT=10 WHERE id IN (" + string.Join(",", LstYdid) + ") and SJDSKZT=0 ";
        //                    comm.CommandText = CmdText;//更新代收款的上交代收款状态由原来的未交款变为已中转
        //                    PriUpdRows = comm.ExecuteNonQuery();
        //                    if (LstSql.Count() != PriUpdRows)
        //                    {
        //                        ClsMsgBox.Ts("代收款中转失败!", ObjG.CustomMsgBox, this);
        //                        trans.Rollback();
        //                        return;
        //                    }
        //                    trans.Commit();
        //                    this.Close();
        //                    ClsMsgBox.Ts("代收款中转成功！共中转" + ChkRowCount + "票,总共" + LblZjje.Text + "元", ObjG.CustomMsgBox, this);
        //                }
        //                else
        //                {
        //                    int ydid = 0;
        //                    //string strzflxmc = lxADDdskfkfsList[0].ToString();//获取第一个支付类型名称 
        //                    string strzflxmc = Prizflxss.Rows[0]["lxADDdskfkfs"].ToString();//获取第一个支付类型名称 
        //                    int iTotallxcount = Prizflxss.Rows.Count;//获取一共选中了多少行 
        //                    int index = 0;
        //                    index = lxADDdskfkfsList.LastIndexOf(strzflxmc);
        //                    int lxcounts = countList[index];
        //                    string zflxstrings = strzflxmc;
        //                    int inum = 0;//序号i=0 本次循环为选中的第几个 
        //                    int itlxxh = 0;//同类型的循环次数  从0开始
        //                    for (int i = 0; i <= Bds.Count; i++)
        //                    {
        //                        if (inum >= iTotallxcount)
        //                        {
        //                            if (LstSql.Count > 0)
        //                            {
        //                                comm.CommandText = string.Join(";", LstSql);
        //                                comm.ExecuteNonQuery();
        //                            }
        //                            LstSql.Clear();
        //                            //如果序号大于类型总个数 
        //                            CmdText = "SET NOCOUNT OFF UPDATE Tfmsdsk SET SJDSKZT=10 WHERE id IN (" + string.Join(",", LstYdid) + ") and  SJDSKZT=0 ";
        //                            comm.CommandText = CmdText;//更新代收款的上交代收款状态由原来的未交款变为已中转  
        //                            comm.ExecuteNonQuery();
        //                            trans.Commit();
        //                            LstYdid.Clear();
        //                            break;
        //                        }
        //                        else
        //                        {
        //                            if ((bool)Dgv.Rows[i].Cells[DgvColTxtCheck.Name].EditedFormattedValue == true)
        //                            {
        //                                ydid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value);
        //                                //string Getzflx = Dgv.Rows[i].Cells[DgvColTxtzflx.Name].Value.ToString().Trim();//获取序号为i的支付类型为M  
        //                                string Getzflx = Dgv.Rows[i].Cells[DgvTxtzflxxh.Name].Value.ToString() + Dgv.Rows[i].Cells[DgvColTxtdskfkfs.Name].Value.ToString();
        //                                //PriZffs = Dgv.Rows[i].Cells[DgvColTxtdskfkfs.Name].Value.ToString().Trim();//付款方式
        //                                //PriZflx = Convert.ToInt32(Dgv.Rows[i].Cells[DgvTxtzflxxh.Name].Value.ToString().Trim());//支付方式
        //                                if (Getzflx == strzflxmc)
        //                                {
        //                                    //如果获取到的支付类型==获取到的第一个支付类型的值
        //                                    if (itlxxh == 0)
        //                                    {//如果同类支付类型==0时
        //                                        if (LstSql.Count > 0)
        //                                        {
        //                                            comm.CommandText = string.Join(";", LstSql);
        //                                            comm.ExecuteNonQuery();
        //                                        }
        //                                        LstSql.Clear();
        //                                        index = lxADDdskfkfsList.LastIndexOf(strzflxmc);
        //                                        PriZj = jeList[index];
        //                                        int RowCount = countList[index];
        //                                        PriZffs = Dgv.Rows[i].Cells[DgvColTxtdskfkfs.Name].Value.ToString().Trim();//付款方式
        //                                        PriZflx = Convert.ToInt32(Dgv.Rows[i].Cells[DgvTxtzflxxh.Name].Value.ToString().Trim());//支付方式
        //                                        CmdText = string.Format("  SET NOCOUNT OFF insert into Tfmsdskjkpc(rbdh,jgid,zffs,dsk,sxf,zt,cnt,zzsj,zzczyid,zzczyzh,zzczyxm,spjgid,zflx)" +
        //                                "  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');select SCOPE_IDENTITY() ",
        //                                PriRbbh, ObjG.Jigou.id, PriZffs, PriZj, 0, 0, RowCount, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriFwjgid, PriZflx);
        //                                        comm.CommandText = CmdText;//插入代收缴款日报批次
        //                                        PriRbpcid = comm.ExecuteScalar().ToString();
        //                                        LstYdid.Add(ydid);
        //                                        LstSql.Add(string.Format("INSERT INTO Tfmsdskjkmx (pcid,dskid,ydid,dsk,sxf) VALUES('{0}','{1}','{2}','{3}','{4}')",
        //              PriRbpcid, Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtYdid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value, 0));
        //                                    }
        //                                    else
        //                                    {
        //                                        LstYdid.Add(ydid);
        //                                        LstSql.Add(string.Format("INSERT INTO Tfmsdskjkmx (pcid,dskid,ydid,dsk,sxf) VALUES('{0}','{1}','{2}','{3}','{4}')",
        //              PriRbpcid, Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtYdid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value, 0));
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    if (LstSql.Count > 0)
        //                                    {
        //                                        comm.CommandText = string.Join(";", LstSql);
        //                                        comm.ExecuteNonQuery();
        //                                    }
        //                                    strzflxmc = Getzflx;
        //                                    itlxxh = 0;//获取到的第一个支付类型的值=获取到的支付类型；如果同类型方式=0
        //                                    LstSql.Clear();
        //                                    index = lxADDdskfkfsList.LastIndexOf(strzflxmc);
        //                                    PriZj = jeList[index];
        //                                    int RowCount = countList[index];
        //                                    PriZffs = Dgv.Rows[i].Cells[DgvColTxtdskfkfs.Name].Value.ToString().Trim();//付款方式
        //                                    PriZflx = Convert.ToInt32(Dgv.Rows[i].Cells[DgvTxtzflxxh.Name].Value.ToString().Trim());//支付方式
        //                                    CmdText = string.Format("  SET NOCOUNT OFF insert into Tfmsdskjkpc(rbdh,jgid,zffs,dsk,sxf,zt,cnt,zzsj,zzczyid,zzczyzh,zzczyxm,spjgid,zflx)" +
        //                            "  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');select SCOPE_IDENTITY() ",
        //                            PriRbbh, ObjG.Jigou.id, PriZffs, PriZj, 0, 0, RowCount, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriFwjgid, PriZflx);
        //                                    comm.CommandText = CmdText;//插入代收缴款日报批次
        //                                    PriRbpcid = comm.ExecuteScalar().ToString();
        //                                    LstYdid.Add(ydid);
        //                                    LstSql.Add(string.Format("INSERT INTO Tfmsdskjkmx (pcid,dskid,ydid,dsk,sxf) VALUES('{0}','{1}','{2}','{3}','{4}')",
        //          PriRbpcid, Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtYdid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value, 0));
        //                                }
        //                                itlxxh = itlxxh + 1;
        //                                inum = inum + 1;
        //                            }
        //                        }
        //                    }
        //                    if (LstSql.Count > 0)
        //                    {
        //                        comm.CommandText = string.Join(";", LstSql);
        //                        comm.ExecuteNonQuery();
        //                        LstSql.Clear();
        //                    }
        //                    if (LstYdid.Count > 0)
        //                    {
        //                        //如果序号大于类型总个数 
        //                        CmdText = "SET NOCOUNT OFF UPDATE Tfmsdsk SET SJDSKZT=10 WHERE id IN (" + string.Join(",", LstYdid) + ") and  SJDSKZT=0 ";
        //                        comm.CommandText = CmdText;//更新代收款的上交代收款状态由原来的未交款变为已中转  
        //                        comm.ExecuteNonQuery();
        //                        trans.Commit();
        //                        LstYdid.Clear();
        //                    }
        //                }
        //                this.Close();
        //                ClsMsgBox.Ts("代收款中转成功！共中转" + ChkRowCount + "票,总共" + LblZjje.Text + "元", ObjG.CustomMsgBox, this);
        //            }
        //            catch (Exception ex)
        //            {
        //                ClsMsgBox.Cw("代收款中转失败！", ex, ObjG.CustomMsgBox, this);
        //                trans.Rollback();
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}
        //#endregion
        //#region 组装明细SQL语句
        //private void GetSql(string aRbpdid)
        //{
        //    LblTs.Visible = false;
        //    //LstSql.Clear();
        //    LstYdid.Clear();
        //    PriYcje = 0;
        //    PriRowCount = 0;
        //    foreach (DataGridViewRow row in Dgv.Rows)
        //    {
        //        if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
        //        {
        //            LstSql.Add(string.Format("INSERT INTO Tfmsdskjkmx (pcid,dskid,ydid,dsk,sxf) VALUES('{0}','{1}','{2}','{3}','{4}')",
        //                PriRbpcid, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtdsk.Name].Value, 0));
        //            PriYcje += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
        //            LstYdid.Add(Convert.ToInt32(row.Cells[DgvColTxtDskid.Name].Value));
        //            PriRowCount++;
        //        }
        //    }
        //}
        //#endregion
        #endregion
        #endregion

        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 5, 6 };
            ClsExcel.CreatExcel(Dgv, "代收款中转", this.ctrlDownLoad1, Rows);
        }
        #endregion

        #region Clear 清除
        public void Clear()
        {
            PriZj = Convert.ToDecimal(0.00);
            ChkRowCount = 0;
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "共选中" + ChkRowCount + "行";
            //this.Prizflxss.Clear();
        }
        #endregion

        #region 返回
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
