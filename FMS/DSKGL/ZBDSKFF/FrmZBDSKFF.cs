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
using NPOI.HSSF.UserModel;
using System.IO;
using JYPubFiles.Classes;
using System.Data.SqlClient;
using FMS.SeleFrm;
#endregion
namespace FMS.DSKGL.ZBDSKFF
{
    public partial class FrmZBDSKFF : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private string PriYhlx;
        //private string PriYhzh;
        private int PriRowCount;//选中行数
        private List<string> LstSql = new List<string>();//更新缴款明细手续费的SQL语句
        private List<int> LstDskid = new List<int>();
        private string PriWhere;
        private bool IsSumSxf;//是否计算手续费
        private decimal PriSxf;//手续费
        private decimal PriZje;//发放总金额
        private decimal PriZje1;
        //private int PriFfzhid;//发放账户ID 
        private string CmdText;//SQL语句
        private string PriPcid;//日报批次
        private decimal PriJhJe;//选中建行总金额
        private int PriJhCount;//选中建行笔数
        private string PriJhPcid;//建行批次ID
        private decimal PriNhje;//选中农行总金额
        private int PriNhCount;//选中农行笔数
        private string PriNhPcid;//农行批次ID
        private decimal PriQlje;//选中齐鲁总金额(行内)
        private int PriQlCount;//选中齐鲁笔数(行内)
        private string PriQlPcid;//齐鲁批次ID(行内)
        private decimal PriQlHwje;//选中齐鲁总金额(行外)
        private int PriQlHwCount;//选中齐鲁笔数(行外)
        private string PriQlHwPcid;//齐鲁批次ID(行外)
        private decimal PriZxhnje;//选中中信总金额(行内)
        private int PriZxhnCount;//选中中信笔数(行内)
        private string PriZxhnPcid;//中信批次ID(行内)
        private decimal PriZxhwje;//选中信鲁总金额(行外)
        private int PriZxhwCount;//选中信鲁笔数(行外)
        private string PriZxhwPcid;//中信批次ID(行外)

        private List<string> LstCkffSql = new List<string>();
        private DataTable dtFl;
        private DataRow[] rows;
        private int PriUpdRows;
        private int PriLevel;//受理机构是否为大区？
        private int PriSljgid;//受理机构ID
        private decimal PriSfje;//实际发放总金额
        #endregion

        public FrmZBDSKFF()
        {
            InitializeComponent();
        }
        #region 初始化数据
        public void Prepare()
        {
            CmbDSZL.SelectedIndex = 0;
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            Vfmsdskff1TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable("select 'all' as bh,'--全部--' as mc union all select bh,mc from Tfmsdskffyhlx    where zt=1  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbYhlx, dtYhlx, "bh", "mc");

            DataTable Tdskffsj = ClsRWMSSQLDb.GetDataTable("select 'all' as bh,'--全部--' as mc,-1 AS sort   union all select bh,mc,sort from Tdskffsj    order by sort  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbCplx, Tdskffsj, "bh", "mc");


            ClsPopulateCmbDsS.PopuFMSDSKZZ_dszl(CmbDSZL);
            CmbYhlx.SelectedIndex = 0;
            CmbDSZL.SelectedIndex = 0;
            CmbQsfs.SelectedIndex = 0;
            CmbCplx.SelectedIndex = 0;
        }
        #endregion
        #region 本页全选

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
                return;
            if (!Convert.ToBoolean(Dgv.Rows[Dgv.FirstDisplayedScrollingRowIndex].Cells[DgvColTxtCheck.Name].Value))
                CheckAllPage();
            else
                NoCheckAllPage();
            LblDskCountText();
        }
        private void CheckAllPage()
        {
            if (Bds.Count == 0)
                return;
            int curPageFirstIndex = (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;//获取当前页的第一行的RowIndex
            int lastPageSize = Dgv.RowCount - (Dgv.TotalPages - 1) * Dgv.ItemsPerPage; //获取最后一页的行数
            int curPageSize = Dgv.CurrentPage != Dgv.TotalPages ? Dgv.ItemsPerPage : lastPageSize; //获取每页的行数（考虑最后一页）
            int curRowIndex = curPageFirstIndex;
            while (curRowIndex < (curPageFirstIndex + curPageSize))
            {
                if (!Convert.ToBoolean(Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value))
                {
                    if (!Validate(Dgv.Rows[curRowIndex]))
                    {
                        curRowIndex++;
                        continue;
                    }
                    PriRowCount++;
                    Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value = true;
                    PriZje += Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtZje.Name].Value);
                    PriYhfl(curRowIndex, true);
                    PriSfje += Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtSfje.Name].Value);
                }
                curRowIndex++;
            }
        }
        private void NoCheckAllPage()
        {
            if (Bds.Count == 0)
                return;
            int curPageFirstIndex = (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;//获取当前页的第一行的RowIndex
            int lastPageSize = Dgv.RowCount - (Dgv.TotalPages - 1) * Dgv.ItemsPerPage; //获取最后一页的行数
            int curPageSize = Dgv.CurrentPage != Dgv.TotalPages ? Dgv.ItemsPerPage : lastPageSize; //获取每页的行数（考虑最后一页）
            int curRowIndex = curPageFirstIndex;
            while (curRowIndex < (curPageFirstIndex + curPageSize))
            {
                if (Convert.ToBoolean(Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value).Equals(true))
                {
                    PriRowCount--;
                    Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value = false;
                    PriZje -= Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtZje.Name].Value);
                    PriYhfl(curRowIndex, false);
                    PriSfje -= Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtSfje.Name].Value);
                }
                curRowIndex++;
            }
        }


        #endregion
        #region 查询按钮
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            Clear();
            ClsD.TextBoxTrim(this);
            DSZbdskff1.Clear();
            this.Chk.Checked = false;
            PriYhlx = CmbYhlx.Text;
            PriWhere = "  ";
            if (DtpQsStart.Checked)
                PriWhere += " and qssj >= '" + DtpQsStart.Value.Date + "'";
            if (DtpQsStop.Checked)
                PriWhere += " and qssj < '" + DtpQsStop.Value.AddDays(1).Date + "'";
            if (DtpSlStart.Checked)
                PriWhere += " and slsj >= '" + DtpSlStart.Value.Date + "'";
            if (DtpSlStop.Checked)
                PriWhere += " and slsj < '" + DtpSlStop.Value.AddDays(1).Date + "'";

            if (DtKsShsj.Checked)
                PriWhere += " and shsj >= '" + DtpSlStart.Value.Date + "'";
            if (DtJsShsj.Checked)
                PriWhere += " and shsj < '" + DtpSlStop.Value.AddDays(1).Date + "'";
            //判断银行类型
            //PriWhere += Convert.ToInt32(CmbYhlx.SelectedValue) == 0 ? "" : Convert.ToInt32(CmbYhlx.SelectedValue) == 64 ? " and yhid not in(63,241) " : " and yhid =" + CmbYhlx.SelectedValue;
            if (!CmbYhlx.SelectedValue.Equals("all"))
                PriWhere += " and ffbh = '" + CmbYhlx.SelectedValue + "'";
            if (CmbDSZL.SelectedIndex != 0)
                PriWhere += " and lx ='" + CmbDSZL.SelectedValue + "'";
            if (CmbQsfs.SelectedIndex != 0)
                PriWhere += " and qsfs='" + CmbQsfs.Text + "'";
            if (CmbCplx.SelectedIndex != 0)
                PriWhere += " and cplx='" + CmbCplx.Text + "'";
            if(!string.IsNullOrEmpty(TxtEJGmc.Text))
                PriWhere += PriLevel == 3 ? " and qsjgid in(select id from jyjckj.dbo.tjigou  where parentLst like '%" + TxtEJGmc.Tag + "%')" : " and qsjgid=" + TxtEJGmc.Tag;
            PriWhere += string.IsNullOrEmpty(TxtBh.Text) ? "" : " and bh='" + TxtBh.Text + "'";

            PriWhere += " and ffdskzt=0 ";//手动指定至查询未发放的

            

            if (TxtBFwkh.Text.Trim().Length > 0)
            {
                PriWhere += "  and dskkhbh='" + TxtBFwkh.Text.Trim().ToString() + "' ";
            }
            if (TxtBJGmc.Text.Trim().Length > 0)
            {
                PriWhere += PriLevel == 3 ? " and sljgid in(select id from jyjckj.dbo.tjigou  where parentLst like '%" + PriSljgid + "%')" : " and sljgid=" + PriSljgid;
                //PriWhere += "  and sljgmc='" + TxtBJGmc.Text.Trim().ToString() + "' ";
            }




            if (TxtDddq.Text.Trim().Length > 0)
            {
                PriWhere += PriLevel == 3 ? " and dqid in(select id from jyjckj.dbo.tjigou  where parentLst like '%" + TxtDddq.Tag+ "%')" : " and dqid=" + TxtDddq.Tag;
               
            }
            if (ChkBYdsj.Checked)
                PriWhere += " and days>=0  ";
            PriWhere = PriWhere.Trim();
            if (PriWhere.Length > 0)
                PriWhere =  " where  "+ PriWhere.Remove(0, 3);
            PriWhere += " ORDER BY jjzt1, sort, qssj,slsj,shsj";
            Vfmsdskff1TableAdapter1.FillByWhere(DSZbdskff1.Vfmsdskff1, PriWhere);
            if (Dgv.Rows.Count == 0)
                ClsMsgBox.Ts("没有要查询的信息,请核对查询条件！", ObjG.CustomMsgBox, this);
            LblDskCountText();
        }
        #endregion

        #region  计算手续费
        private void BtnSumSxf_Click(object sender, EventArgs e)
        {
            if (PriRowCount == 0)
            {
                ClsMsgBox.Ts("请选择运单！", ObjG.CustomMsgBox, this);
                return;
            }
            try
            {
                dtFl = new DataTable();
                dtFl = ClsRWMSSQLDb.GetDataTable("select pcid,dskffsj,fl,sxfsx,sxfxx from tfmssxfflmx", ClsGlobals.CntStrTMS);
                LstSql.Clear();
                PriSfje = 0;
                foreach (DataGridViewRow row in Dgv.Rows)
                {

                    PriSxf = 0;
                    if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                    {
                        //验证服务卡号是否有效
                        if (!Validate(row))
                        {
                            Bds.Position = row.Index;
                            ClsD.TurnToBdsPosPage(Dgv);
                            return;
                        }
                        if (row.Cells[DgvColTxtDszl.Name].Value.ToString() == "H")
                        {
                            PriSxf = SumSxf(row.Cells[DgvColTxtFlid.Name].Value.ToString(),
                                row.Cells[DgvColTxtDsffsj.Name].Value.ToString(), Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value));
                            //LstSql.Add(string.Format("update tfmsdskjkmx set sxf={0} where id={1}", PriSxf
                            //    , row.Cells[DgvColTxtMxid.Name].Value));
                        }
                        else if (row.Cells[DgvColTxtDszl.Name].Value.ToString() == "Y")
                        {
                            PriSxf = 0;
                        }
                        if (PriSxf == -10)
                        {
                            ClsMsgBox.Ts("单号：" + row.Cells[DgvColTxtBh.Name].Value.ToString() + "无法计算手续费,请检查客户费率！", ObjG.CustomMsgBox, this);
                            return;
                        }
                        row.Cells[DgvColTxtSxf.Name].Value = PriSxf;
                        row.Cells[DgvColTxtSfje.Name].Value = Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value) - PriSxf;
                        PriSfje = PriSfje + Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value) - PriSxf;
                    }
                }
                //if (LstSql.Count != 0)
                //    ClsRWMSSQLDb.ExecuteCmd(string.Join(";", LstSql), ClsGlobals.CntStrTMS);
                ClsMsgBox.Ts("计算手续费成功！", ObjG.CustomMsgBox, this);
                IsSumSxf = true;
                LblDskCountText();
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("计算手续费失败！", ex, ObjG.CustomMsgBox, this);
            }

        }
        private decimal SumSxf(string aFlid, string aDsffsj, decimal aDsk)
        {
            rows = dtFl.Select(" pcid=" + aFlid + " and dskffsj='" + aDsffsj + "'");
            if (rows.Length != 1)
                return -10;
            else
            {
                if (aDsk * Convert.ToDecimal(rows[0]["fl"]) < Convert.ToDecimal(rows[0]["sxfxx"]))
                    return Convert.ToDecimal(rows[0]["sxfxx"]);
                else if (aDsk * Convert.ToDecimal(rows[0]["fl"]) > Convert.ToDecimal(rows[0]["sxfsx"]))
                    return Convert.ToDecimal(rows[0]["sxfsx"]);
                else
                    return Math.Round(Convert.ToDecimal(aDsk * Convert.ToDecimal(rows[0]["fl"])), 1);
            }
        }
        #endregion

        #region 验证
        private bool Validate(DataGridViewRow row)
        {
            int fwkh;
            int.TryParse(row.Cells[DgvColTxtFwkh.Name].Value.ToString(), out fwkh);
            if (string.IsNullOrEmpty(row.Cells[DgvColTxtFwkh.Name].Value.ToString()) || fwkh == 0)
            {
                return false;
            }
            if (Convert.ToInt32(row.Cells[DgvColTxtZt.Name].Value) == 0)
            {
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(row.Cells[DgvColTxtFlid.Name].Value)))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(row.Cells[DgvColTxtYhzh.Name].Value)))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(row.Cells[DgvColTxtFfbh.Name].Value)))
            {
                return false;
            }
            if (row.Cells[DgvColTxtShzt.Name].Value.ToString() != "10")
            {
                return false;
            }
            return true;
        }
        private bool Validate2(DataGridViewRow row)
        {
            int fwkh;
            int.TryParse(row.Cells[DgvColTxtFwkh.Name].Value.ToString(), out fwkh);
            if (string.IsNullOrEmpty(row.Cells[DgvColTxtFwkh.Name].Value.ToString()) || fwkh == 0)
            {
                ClsMsgBox.Ts("单号：" + row.Cells[DgvColTxtBh.Name].Value.ToString() + "该笔代收款无服务卡号，请维护服务卡号后再发放！", ObjG.CustomMsgBox, this);

                return false;
            }
            if (Convert.ToInt32(row.Cells[DgvColTxtZt.Name].Value) == 0)
            {
                ClsMsgBox.Ts("单号：" + row.Cells[DgvColTxtBh.Name].Value.ToString() + "该服务卡号无效，请维护服务卡号后再发放！", ObjG.CustomMsgBox, this);

                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(row.Cells[DgvColTxtFlid.Name].Value)))
            {
                ClsMsgBox.Ts("单号：" + row.Cells[DgvColTxtBh.Name].Value.ToString() + "请给客户档案维护费率后再发放！", ObjG.CustomMsgBox, this);
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(row.Cells[DgvColTxtYhzh.Name].Value)))
            {
                ClsMsgBox.Ts("单号：" + row.Cells[DgvColTxtBh.Name].Value.ToString() + "请给客户档案维护账户信息！", ObjG.CustomMsgBox, this);
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(row.Cells[DgvColTxtFfbh.Name].Value)))
            {
                ClsMsgBox.Ts("单号：" + row.Cells[DgvColTxtBh.Name].Value.ToString() + "请维护代收款发放银行类型！", ObjG.CustomMsgBox, this);
                return false;
            }
            if (row.Cells[DgvColTxtShzt.Name].Value.ToString() != "10")
            {
                ClsMsgBox.Ts("单号：" + row.Cells[DgvColTxtBh.Name].Value.ToString() + "请复核代收款客户档案！", ObjG.CustomMsgBox, this);
                return false;
            }
            return true;
        }
        #endregion

        #region 保存
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!IsSumSxf)
            {
                ClsMsgBox.Ts("请先计算手续费在进行保存！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsMsgBox.YesNo("是否保存代收款发款明细？", new EventHandler(SaveMessage), ObjG.CustomMsgBox, this);
        }
        public void SaveMessage(object sender, EventArgs e)
        {
            FrmMsgBox frm = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {
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
                            CmdText = string.Format("Insert into Tfmsdskxtffpc (jgid,je,bs,inssj,insczyid,insczyxm,insczyzh) values('{0}','{1}','{2}',{3},'{4}','{5}','{6}')" +
                               ";select SCOPE_IDENTITY() ", ObjG.Jigou.id, PriZje, PriRowCount, "getdate()",
                               ObjG.Renyuan.id, ObjG.Renyuan.xm, ObjG.Renyuan.loginName);
                            comm.CommandText = CmdText;
                            PriPcid = comm.ExecuteScalar().ToString();
                            //判断有哪些发放银行需要生成持卡发放批次
                            if (PriJhCount > 0) //建行
                            {
                                CmdText = string.Format("Insert into tfmsdskckffpc (xtpcid,je,zje,bs,yhlxid,zt,ffyhlx) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}');select SCOPE_IDENTITY()",
                                    PriPcid, 0.00, PriJhJe, PriJhCount, "(select yhlxid from TfmsDskffyhlx where bh='jh')", 0, "jh");
                                comm.CommandText = CmdText;
                                PriJhPcid = comm.ExecuteScalar().ToString();
                            }
                            if (PriNhCount > 0)//农行
                            {
                                CmdText = string.Format("Insert into tfmsdskckffpc (xtpcid,je,zje,bs,yhlxid,zt,ffyhlx) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}');select SCOPE_IDENTITY()",
                                    PriPcid, 0.00, PriNhje, PriNhCount, "(select yhlxid from TfmsDskffyhlx where bh='nh')", 0, "nh");
                                comm.CommandText = CmdText;
                                PriNhPcid = comm.ExecuteScalar().ToString();
                            }
                            if (PriQlCount > 0) //齐鲁行内
                            {
                                CmdText = string.Format("Insert into tfmsdskckffpc (xtpcid,je,zje,bs,yhlxid,zt,fkfs,ffyhlx) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}');select SCOPE_IDENTITY()",
                                        PriPcid, 0.00, PriQlje, PriQlCount, "(select yhlxid from TfmsDskffyhlx where bh='qlhn')", 0, 10, "qlhn");
                                comm.CommandText = CmdText;
                                PriQlPcid = comm.ExecuteScalar().ToString();
                            }
                            if (PriQlHwCount > 0)//齐鲁行外
                            {
                                CmdText = string.Format("Insert into tfmsdskckffpc (xtpcid,je,zje,bs,yhlxid,zt,fkfs,ffyhlx) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}');select SCOPE_IDENTITY()",
                                        PriPcid, 0.00, PriQlHwje, PriQlHwCount, "(select yhlxid from TfmsDskffyhlx where bh='qlhw')", 0, 20, "qlhw");
                                comm.CommandText = CmdText;
                                PriQlHwPcid = comm.ExecuteScalar().ToString();
                            }
                            if (PriZxhnCount > 0) //中信行内  
                            {
                                CmdText = string.Format("Insert into tfmsdskckffpc (xtpcid,je,zje,bs,yhlxid,zt,fkfs,ffyhlx) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}');select SCOPE_IDENTITY()",
                                           PriPcid, 0.00, PriZxhnje, PriZxhnCount, "(select yhlxid from TfmsDskffyhlx where bh='zxhn')", 0, 10, "zxhn");
                                comm.CommandText = CmdText;
                                PriZxhnPcid = comm.ExecuteScalar().ToString();
                            }
                            if (PriZxhwCount > 0) //中信行外
                            {
                                CmdText = string.Format("Insert into tfmsdskckffpc (xtpcid,je,zje,bs,yhlxid,zt,fkfs,ffyhlx) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}');select SCOPE_IDENTITY()",
                                           PriPcid, 0.00, PriZxhwje, PriZxhwCount, "(select yhlxid from TfmsDskffyhlx where bh='zxhw')", 0, 20, "zxhw");
                                comm.CommandText = CmdText;
                                PriZxhwPcid = comm.ExecuteScalar().ToString();
                            }
                            if (string.IsNullOrEmpty(PriPcid))
                            {
                                ClsMsgBox.Ts("创建批次失败！", frm, this);
                                trans.Rollback();
                                return;
                            }
                            InsertMx(PriPcid);
                            if (LstSql.Count != LstCkffSql.Count)
                            {
                                ClsMsgBox.Ts("代收款发放信息保存失败,系统发放笔数与打款笔数不一致！", frm, this);
                                trans.Rollback();
                                return;
                            }
                            if (PriZje != PriZje1)
                            {
                                ClsMsgBox.Ts("代收款发放信息保存失败,选择的总金额与保存的总金额不一致！", frm, this);
                                trans.Rollback();
                                return;
                            }
                            if (PriZje1 != PriJhJe + PriNhje + PriQlje + PriQlHwje + PriZxhnje + PriZxhwje || PriRowCount != PriJhCount + PriNhCount + PriQlCount + PriQlHwCount + PriZxhnCount + PriZxhwCount)
                            {
                                ClsMsgBox.Ts("代收款发放信息保存失败,各银行应发金额与总金额不一致！", frm, this);
                                trans.Rollback();
                                return;
                            }
                            if (LstSql.Count == 0)
                            {
                                ClsMsgBox.Ts("代收款发放信息保存失败,没有保存任何发放信息！", frm, this);
                                trans.Rollback();
                                return;
                            }
                            comm.CommandText = string.Join(";", LstSql);
                            comm.ExecuteScalar();
                            if (LstDskid.Count == 0)
                            {
                                ClsMsgBox.Ts("代收款发放信息保存失败,没有保存任何打款信息！", frm, this);
                                trans.Rollback();
                                return;
                            }
                            comm.CommandText = string.Join(";", LstCkffSql);

                            comm.ExecuteNonQuery();
                            comm.CommandText = "SET NOCOUNT OFF Update tfmsdsk set ffdskzt=20 where id in(" + string.Join(",", LstDskid) + ") and ffdskzt=0";
                            PriUpdRows = comm.ExecuteNonQuery();
                            if (LstSql.Count != PriUpdRows)
                            {
                                ClsMsgBox.Ts("代收款发放信息保存失败,保存的打款信息与应发笔数不一致！", frm, this);
                                trans.Rollback();
                                return;
                            }
                            trans.Commit();
                            ClsMsgBox.Ts("代收款发放信息保存成功！", frm, this);
                            //Vfmsdskff1TableAdapter1.FillByWhere(DSZbdskff1.Vfmsdskff1, PriWhere);
                            foreach (int dskid in LstDskid)
                            {
                                Bds.RemoveAt(Bds.Find("dskid", dskid));
                            }
                            Clear();
                            LblDskCountText();
                        }
                        catch (Exception ex)
                        {
                            ClsMsgBox.Cw("保存代收款发放信息失败！", ex, frm, this);
                            trans.Rollback();
                            return;
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }

                }
            }
        }
        #endregion

        #region 组装明细SQL语句
        private void InsertMx(string aPcid)
        {
            LstSql.Clear();
            LstDskid.Clear();
            LstCkffSql.Clear();
            PriZje1 = 0;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                {
                    PriZje1 += Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value);
                    LstSql.Add(string.Format("Insert into tfmsdskxtffmx" +
                        " (pcid,dskid,dsk,sxf) values('{0}','{1}','{2}','{3}')", aPcid, row.Cells[DgvColTxtDskid.Name].Value,
                        row.Cells[DgvColTxtZje.Name].Value, row.Cells[DgvColTxtSxf.Name].Value));
                    LstDskid.Add(Convert.ToInt32(row.Cells[DgvColTxtDskid.Name].Value));
                    if (row.Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("jh")) //建行
                    {
                        LstCkffSql.Add(string.Format("Insert into tfmsdskckffmx (pcid,ydid,dskid,dsk,sxf,zt) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                            PriJhPcid, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtZje.Name].Value,
                            row.Cells[DgvColTxtSxf.Name].Value, 0));
                    }
                    else if (row.Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("nh"))//农行
                    {
                        LstCkffSql.Add(string.Format("Insert into tfmsdskckffmx (pcid,ydid,dskid,dsk,sxf,zt) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                           PriNhPcid, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtZje.Name].Value,
                           row.Cells[DgvColTxtSxf.Name].Value, 0));
                    }
                    else if (row.Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("qlhn"))//齐鲁行内
                    {
                        LstCkffSql.Add(string.Format("Insert into tfmsdskckffmx (pcid,ydid,dskid,dsk,sxf,zt) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                              PriQlPcid, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtZje.Name].Value,
                              row.Cells[DgvColTxtSxf.Name].Value, 0));

                    }
                    else if (row.Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("qlhw"))//齐鲁行外
                    {
                        LstCkffSql.Add(string.Format("Insert into tfmsdskckffmx (pcid,ydid,dskid,dsk,sxf,zt) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                              PriQlHwPcid, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtZje.Name].Value,
                              row.Cells[DgvColTxtSxf.Name].Value, 0));
                    }
                    else if (row.Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("zxhw"))//中信行外
                    {
                        LstCkffSql.Add(string.Format("Insert into tfmsdskckffmx (pcid,ydid,dskid,dsk,sxf,zt) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                              PriZxhwPcid, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtZje.Name].Value,
                              row.Cells[DgvColTxtSxf.Name].Value, 0));
                    }
                    else if (row.Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("zxhn"))//中信行内
                    {
                        LstCkffSql.Add(string.Format("Insert into tfmsdskckffmx (pcid,ydid,dskid,dsk,sxf,zt) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                              PriZxhnPcid, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtZje.Name].Value,
                              row.Cells[DgvColTxtSxf.Name].Value, 0));
                    }
                }
            }
        }
        #endregion

        #region clear()
        private void Clear()
        {
            IsSumSxf = false;
            LstSql.Clear();
            PriSxf = 0;
            PriRowCount = 0;
            PriZje = 0;
            PriZje1 = 0;
            CmdText = "";
            PriPcid = "";
            LstDskid.Clear();
            PriJhJe = 0;
            PriJhCount = 0;
            PriNhje = 0;
            PriNhCount = 0;
            PriQlje = 0;
            PriQlCount = 0;
            PriQlHwje = 0;
            PriQlHwCount = 0;
            PriZxhnCount = 0;
            PriZxhnje = 0;
            PriZxhwCount = 0;
            PriZxhwje = 0;
            PriSfje = 0;
        }
        private void LblDskCountText()
        {
            LblDskCount.Text = "每页" + this.Dgv.ItemsPerPage + "行,共" + Dgv.Rows.Count + "行,选中" + PriRowCount + "行,总金额" + PriZje.ToString() + "元,实发总金额" + PriSfje.ToString() + "元";
        }
        #endregion

        #region 时间选择
        /*
        private void DtpQsStop_CheckedChanged(object sender, EventArgs e)
            {
            if (DtpQsStop.Checked)
                DtpQsStart.Checked = true;
            }
        private void DtpSjStop_CheckedChanged(object sender, EventArgs e)
            {
            if (DtpSlStop.Checked)
                DtpSlStart.Checked = true;
            }
         * */
        #endregion

        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 4, 5, 6 };
            ClsExcel.CreatExcel(Dgv, "代收款系统发放", this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, "代收款系统发放", this.ctrlDownLoad1);
        }
        #endregion

        #region 机构查询
        private void BtnJg_Click(object sender, EventArgs e)
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
                this.TxtBJGmc.Text = f.PubDictAttrs["mc"];
                PriLevel = Convert.ToInt32(f.PubDictAttrs["Level"]);
                PriSljgid = Convert.ToInt32(f.PubDictAttrs["id"]);
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtBJGmc.Text = "";
                PriLevel = 0;
                PriSljgid = 0;
            }
        }
        #endregion

        #region 全选
        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            int RowCout = 0;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                try
                {
                    IsSumSxf = false;
                    if (!Chk.Checked)
                    {
                        if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                        {
                            row.Cells[DgvColTxtCheck.Name].Value = false;
                            PriRowCount--;
                            PriZje -= Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value);
                            PriSfje -= Convert.ToDecimal(row.Cells[DgvColTxtSfje.Name].Value);
                            PriYhfl(row.Index, false);
                        }
                    }
                    else if (Chk.Checked)
                    {
                        //if (!IsNull(row))
                        //{
                        //    continue; 
                        //}
                        if (!Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                        {
                            try
                            {
                                if (!Validate(row))
                                {
                                    continue;
                                }
                                row.Cells[DgvColTxtCheck.Name].Value = true;
                                PriRowCount++;
                                PriZje += Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value);
                                PriSfje += Convert.ToDecimal(row.Cells[DgvColTxtSfje.Name].Value);
                                PriYhfl(row.Index, true);
                            }
                            catch (Exception ex)
                            { 
                                Validate(row);
                            }
                            
                           
                        }
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                } 
                RowCout++; 
            }
            LblDskCountText();
        }
        #endregion

        #region  快速选择
        private void BtnKsxz_Click(object sender, EventArgs e)
        {
            this.LblTs.Visible = true;
            if (string.IsNullOrEmpty(TxtBh.Text))
            {
                LblTs.Text = "请填写货运单号后，再进行快速选择";
                LblTs.ForeColor = Color.Red;
                TxtBh.Focus();
                return;
            }
            int RowIndex = Bds.Find("bh", TxtBh.Text);
            if (RowIndex < 0)
            {
                LblTs.Text = "没有要选择的运单！";
                LblTs.ForeColor = Color.Red;
                TxtBh.Focus();
                TxtBh.SelectAll();
                return;
            }
            Bds.Position = RowIndex;
            IsSumSxf = false;
            if (Convert.ToBoolean(Dgv.CurrentRow.Cells[DgvColTxtCheck.Name].Value))
            {
                ClsMsgBox.Ts("该笔代收款已被选中！", ObjG.CustomMsgBox, this);
                return;
            }
            //if (string.IsNullOrEmpty(Dgv.CurrentRow.Cells[DgvColTxtFwkh.Name].Value.ToString()))
            //{
            //    ClsMsgBox.Ts("该笔代收款无服务卡号，请维护服务卡号后再发放！", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //else
            //{
            //    if (Convert.ToInt32(Dgv.CurrentRow.Cells[DgvColTxtFwkh.Name].Value) == 0)
            //    {
            //        ClsMsgBox.Ts("该笔代收款无服务卡号，请维护服务卡号后再发放！", ObjG.CustomMsgBox, this);
            //        return;
            //    }
            //}
            //if (string.IsNullOrEmpty(Convert.ToString(Dgv.CurrentRow.Cells[DgvColTxtFlid.Name].Value)))
            //{
            //    ClsMsgBox.Ts("请给客户档案维护费率后再发放！", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //if (string.IsNullOrEmpty(Convert.ToString(Dgv.CurrentRow.Cells[DgvColTxtYhzh.Name].Value)))
            //{
            //    ClsMsgBox.Ts("请给客户档案维护账户信息！", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //if (string.IsNullOrEmpty(Convert.ToString(Dgv.CurrentRow.Cells[DgvColTxtFfbh.Name].Value)))
            //{
            //    ClsMsgBox.Ts("请维护代收款发放银行类型！", ObjG.CustomMsgBox, this);
            //    return;
            //}
            if (!Validate2(Dgv.CurrentRow))
            {
                return;
            }
            Dgv.CurrentRow.Cells[DgvColTxtCheck.Name].Value = true;
            PriRowCount++;
            PriZje += Convert.ToDecimal(Dgv.CurrentRow.Cells[DgvColTxtZje.Name].Value);
            PriSfje += Convert.ToDecimal(Dgv.CurrentRow.Cells[DgvColTxtSfje.Name].Value);
            PriYhfl(Dgv.CurrentRow.Index, true);
            ClsD.TurnToBdsPosPage(Dgv);
            LblTs.Text = "运单：" + TxtBh.Text + "被选中，共选中" + PriRowCount + "条。";
            LblTs.ForeColor = Color.Green;
            TxtBh.Text = "";
            TxtBh.Focus();
            this.ActiveControl = this.BtnKsxz;
            //LblDskCount.Text = "每页" + this.Dgv.ItemsPerPage + "行,共" + Dgv.Rows.Count + "行,选中" + PriRowCount + "行,总金额" + PriZje.ToString() + "元";
            LblDskCountText();
        }

        private void TxtBh_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            BtnKsxz.PerformClick();
            TxtBh.Focus();
        }
        #endregion

        #region 银行分类
        private void PriYhfl(int i, Boolean Pribool)
        {
            if (Pribool == true)
            {
                //判断所选信息是哪个银行
                if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("jh")) //建行
                {
                    PriJhJe += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriJhCount++;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("nh"))//农行
                {
                    PriNhje += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriNhCount++;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("qlhn"))//齐鲁行内
                {
                    PriQlje += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriQlCount++;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("qlhw"))//齐鲁行外
                {
                    PriQlHwje += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriQlHwCount++;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("zxhn"))//中信行内
                {
                    PriZxhnje += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriZxhnCount++;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("zxhw"))//中信行外
                {
                    PriZxhwje += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriZxhwCount++;
                }
            }
            else
            {
                //判断所选信息是哪个银行
                if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("jh")) //建行
                {
                    PriJhJe -= Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriJhCount--;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("nh"))//农行
                {
                    PriNhje -= Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriNhCount--;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("qlhn"))//齐鲁行内
                {
                    PriQlje -= Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriQlCount--;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("qlhw"))//齐鲁行外
                {
                    PriQlHwje -= Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriQlHwCount--;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("zxhn"))//中信行内
                {
                    PriZxhnje -= Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriZxhnCount--;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("zxhw"))//中信行外
                {
                    PriZxhwje -= Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriZxhwCount--;
                }
            }
        }
        #endregion
        private void BtnYff_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtKffje.Text.Trim()))
            {
                ClsMsgBox.Ts("请填写可发放金额！", ObjG.CustomMsgBox, this);
                return;
            }
            if (!ClsRegEx.IsJe(TxtKffje.Text.Trim()))
            {
                ClsMsgBox.Ts("填写的可发放金额格式不正确！", ObjG.CustomMsgBox, this);
                return;
            }
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                    row.Cells[DgvColTxtCheck.Name].Value = false;
            }
            IsSumSxf = true;
            PriRowCount = 0;
            PriZje = 0;
            PriSfje = 0;
            PriJhJe = 0;
            PriNhje = 0;
            PriQlje = 0;
            PriQlHwje = 0; 
            PriZxhnje = 0;
            PriZxhwje = 0;
            PriJhCount = 0;
            PriNhCount = 0;
            PriQlCount = 0;
            PriQlHwCount = 0;
            PriZxhnCount = 0;
            PriZxhwCount = 0;
            decimal kffje = 0;
            try
            {
                dtFl = new DataTable();
                dtFl = ClsRWMSSQLDb.GetDataTable("select pcid,dskffsj,fl,sxfsx,sxfxx from tfmssxfflmx", ClsGlobals.CntStrTMS);
                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    PriSxf = 0;
                    if (!Validate(row))
                        continue;
                    if (row.Cells[DgvColTxtDszl.Name].Value.ToString() == "H")
                    {
                        PriSxf = SumSxf(row.Cells[DgvColTxtFlid.Name].Value.ToString(),
                            row.Cells[DgvColTxtDsffsj.Name].Value.ToString(), Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value));
                    }
                    else if (row.Cells[DgvColTxtDszl.Name].Value.ToString() == "Y")
                        PriSxf = 0;
                    if (PriSxf == -10)
                    {
                        continue;
                    }
                    kffje += Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value) - PriSxf;
                    if (kffje < Convert.ToDecimal(TxtKffje.Text))
                    {
                        row.Cells[DgvColTxtCheck.Name].Value = true;
                        row.Cells[DgvColTxtSxf.Name].Value = PriSxf;
                        row.Cells[DgvColTxtSfje.Name].Value = Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value) - PriSxf;
                        PriRowCount++;
                        PriZje += Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value);
                        PriSfje += Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value) - PriSxf;
                        PriYhfl(row.Index, true);
                    }
                    else
                        break;

                }
                LblDskCountText();
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("预发放失败！", ex, ObjG.CustomMsgBox, this);
                return;
            }
        }
        #region 单行选择
        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                IsSumSxf = false;
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    PriRowCount--;
                    PriZje -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtZje.Name].Value);
                    PriYhfl(e.RowIndex, false);
                    PriSfje -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtSxf.Name].Value);
                }
                else
                {
                    if (!Validate2(Dgv.Rows[e.RowIndex]))
                    {

                        return;
                    }
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    PriRowCount++;
                    PriZje += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtZje.Name].Value);
                    PriSfje += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtSfje.Name].Value);
                    PriYhfl(e.RowIndex, true);
                }
            }
            LblDskCountText();
        }
        #endregion

        private void BtnEjg_Click(object sender, EventArgs e)
        {
            FrmSelectJg2 frm = new FrmSelectJg2();
            frm.Prepare();
            frm.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(frm_FormClosed);
            frm.ShowDialog();
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg2 f = sender as FrmSelectJg2;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtEJGmc.Text = f.PubDictAttrs["mc"];
                this.TxtEJGmc.Tag = f.PubDictAttrs["id"];
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtBJGmc.Text = "";
                this.TxtEJGmc.Tag = "";
            }
        }

        private void btndddq_Click(object sender, EventArgs e)
        {
            FrmSelectJg2 fr = new FrmSelectJg2();
            fr.Prepare();
            fr.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(fr_FormClosed);
            fr.ShowDialog();
        }

        void fr_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg2 f = sender as FrmSelectJg2;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtDddq.Text = f.PubDictAttrs["mc"];
                this.TxtDddq.Tag = f.PubDictAttrs["id"];
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtDddq.Text = "";
                this.TxtDddq.Tag = "";
            }
        }
    }
}
