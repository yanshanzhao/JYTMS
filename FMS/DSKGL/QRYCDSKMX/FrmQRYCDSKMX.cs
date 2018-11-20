#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Linq;
using JY.Pri;
using JY.Pub;
using FMS.SeleFrm;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
#endregion
namespace FMS.DSKGL.QRYCDSKMX
{
    public partial class FrmQRYCDSKMX : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private string PriWhere = "";
        //private string PriStrCon = "";
        private int PriJgid = 0;
        private string PriLogMC = "";
        private int PriZhid = 0;
        private string PriXm = "";
        private List<DSQRYCDSK.VfmsqrycdskmxRow> PriListId = new List<DSQRYCDSK.VfmsqrycdskmxRow>();
        //private int PriYdCounts = 0;
        private double PriSumDsk = 0;
        private double PriXjje = 0;
        private double PriPosje = 0;
        private double PriJhje = 0;
        private double PriNhje = 0;
        private double PriZSje = 0;
        private int PriJgids = 0;
        private string PriJgidStr = "";
        private int PriRowsCunt = 0;
        private int chashu = 0;
        private double jezh = 0;
        #endregion
        public FrmQRYCDSKMX()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            CmbDskbz.SelectedIndex = 2;
            CmbZffs.SelectedIndex = 0;
            CmbCkjgkhh.SelectedIndex = 0;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            //PriStrCon = ClsGlobals.CntStrTMS;
            PriJgid = ObjG.Jigou.id;
            PriLogMC = ObjG.Renyuan.loginName;
            PriZhid = ObjG.Renyuan.id;
            PriXm = ObjG.Renyuan.xm;
            this.Lbljgid.Text = "共选择0个机构";
            CmbYqzldk.SelectedIndex = 0;
            CmbDkfs.SelectedIndex = 0;
            CmbDjzt.SelectedIndex = 1;
            CmbPOSpz.SelectedIndex = 0;
            CmbPpzt.SelectedIndex = 0;
            VfmsqrycdskmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.DSQRYCDSK1.EnforceConstraints = false;
            CmbZflx.SelectedIndex = 0;
        }
        #region 查询
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PriWhere = "";
            PriWhere = " where  zt not in (0,5)   and tojgid=" + PriJgid ;
            PriWhere += "  and  jdzt='" + this.CmbDjzt.Text + "'";
            if (CmbZflx.SelectedIndex != 0)
                PriWhere += " and   zflxs='" + CmbZflx.Text.Trim() + "'";
            if (CmbZflx.Text.Equals("线下"))
                PriWhere += " and poszt='" + CmbPOSpz.Text + "'";
            else if (CmbZflx.Text.Equals("二维码支付"))
                PriWhere += " and xtppzts='" + CmbPpzt.Text + "'";
            else
                PriWhere += " and poszt='" + CmbPOSpz.Text + "' and xtppzts='" + CmbPpzt.Text + "'";
            if (TxtRbdh.Text.Trim().Length > 0)
                PriWhere += "  and  rbdh='" + TxtRbdh.Text.Trim() + "'";
            decimal n;
            if (TxtBJe1.Text.Trim().Length > 0)
            {
                if (!decimal.TryParse(TxtBJe1.Text.Trim(), out n))
                {
                    ClsMsgBox.Ts("请输入正确的金额格式！");
                    return;
                }
                PriWhere += "  and  dsk>=" + TxtBJe1.Text.Trim() + "";
            }
            if (TxtBJe2.Text.Trim().Length > 0)
            {
                if (!decimal.TryParse(TxtBJe2.Text.Trim(), out n))
                {
                    ClsMsgBox.Ts("请输入正确的金额格式！");
                    return;
                }
                PriWhere += "  and  dsk<" + TxtBJe2.Text.Trim() + "";
            }
            if (CmbDskbz.SelectedIndex != 1)
                PriWhere += " and ztmc='" + CmbDskbz.Text + "'";
            if (PriJgids != 0)
                PriWhere += " and jgid in (" + PriJgidStr.Substring(0, PriJgidStr.Length - 1) + ")";
            if (CmbZffs.SelectedIndex != 0)
                PriWhere += " and zzfsmc='" + CmbZffs.Text + "'";
            if (DtpStart.Checked)
                PriWhere += "  and zzsj >='" + DtpStart.Value.Date + "'";
            if (DtpStop.Checked)
                PriWhere += "  and zzsj <'" + DtpStop.Value.AddDays(1).Date + "'";
            if (DtpShrq.Checked)
                PriWhere += "   and shsj  >= '" + DtpShrq.Value.Date + "' and  shsj <'" + DtpShrq.Value.AddDays(1).Date + "'"; ;
            if (CmbCkjgkhh.SelectedIndex != 0)
            {
                string aYhlx = CmbCkjgkhh.Text.ToString().Substring(0, 1);
                PriWhere += " and yhlx like '" + aYhlx + "%' ";
            }
            if (CmbYqzldk.SelectedIndex != 0)
                PriWhere += " and dkzt='" + CmbYqzldk.Text + "'";
            if (CmbDkfs.SelectedIndex != 0)
                PriWhere += " and dkfs='" + CmbDkfs.Text + "'";
            PriWhere += " order by px,ckjgmc,zzsj ";
            Clear();
            VfmsqrycdskmxTableAdapter1.FillByWhere1(this.DSQRYCDSK1.Vfmsqrycdskmx, PriWhere);
            if (!(DSQRYCDSK1.Vfmsqrycdskmx.Compute("sum(dkje)", "1=1") is DBNull))
            {
                jezh = Convert.ToDouble(DSQRYCDSK1.Vfmsqrycdskmx.Compute("sum(dkje)", "1=1"));
            }
            LblCheckCount.Text = "共选中0行";
            LblCheckSumJe.Text = "POS " + this.DSQRYCDSK1.Vfmsqrycdskmx.Compute("sum(dsk)", "zzfsmc='POS'").ToString() + "元,现金 "
                + this.DSQRYCDSK1.Vfmsqrycdskmx.Compute("sum(dsk)", " zzfsmc like '现%' ") + "元，其中建行 " + this.DSQRYCDSK1.Vfmsqrycdskmx.Compute("sum(dsk)", " zzfsmc like '现%'  and yhlx like '建%' ").ToString()
                + "元，农行 " + this.DSQRYCDSK1.Vfmsqrycdskmx.Compute("sum(dsk)", " zzfsmc like '现%'  and yhlx like '农%' ").ToString() + "元，招商" + this.DSQRYCDSK1.Vfmsqrycdskmx.Compute("sum(dsk)", " zzfsmc like '现%'  and yhlx like '招%' ").ToString() + "元" + ",代扣金额总和为：0.00元";
            if (Dgv.RowCount == 0)
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
            else
                AddColor();//添加颜色
            chashu = 0;
            jezh = 0;
        }
        private void AddColor()
        {
            for (int i = 0; i < Dgv.Rows.Count; i++)
            {
                decimal dskje = Convert.ToDecimal(Dgv.Rows[i].Cells["DgvColTxtdsk"].Value);
                decimal dkje = string.IsNullOrEmpty(Dgv.Rows[i].Cells["DgvColTxtDkje"].Value.ToString()) ? 0 : Convert.ToDecimal(Dgv.Rows[i].Cells["DgvColTxtDkje"].Value);
                if (dskje != dkje)
                {
                    if (string.IsNullOrEmpty(Dgv.Rows[i].Cells["DgvColTxtDkje"].Value.ToString()))
                        continue;
                    Dgv.Rows[i].Cells["DgvColTxtDkje"].Style.ForeColor = Color.Red;
                }
            }
        }
        #endregion
        #region Clear()
        private void Clear()
        {
            PriListId.Clear();
            //PriYdCounts = 0;
            PriSumDsk = 0;
            PriXjje = 0;
            PriPosje = 0;
            PriJhje = 0;
            PriNhje = 0;
            PriZSje = 0;
            PriRowsCunt = 0;
            ChkB.Checked = false;
            GetXx();
        }
        #endregion
        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(this.Dgv, "代收款应存明细", this.ctrlDownLoad1, new int[] { 4, 5, 6 });
            //string PriFln = "代收款应存明细" + ".xls";//文件名称     
            //string PriFlp = System.IO.Path.Combine(this.Context.HttpContext.Request.PhysicalApplicationPath +
            //    "App_Data\\Download", PriFln);//存放文件路径
            //HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
            ////写入数据
            //HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            //sheet1.DefaultColumnWidth = 17;
            //sheet1.SetColumnWidth(1, 25 * 100);
            //try
            //{
            //    //行名的的设置
            //    HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
            //    for (int i = 0; i < Dgv.ColumnCount - 4; i++)
            //    {
            //        if (i == 0)
            //            row0.CreateCell(i).SetCellValue("所属大区");
            //        else
            //            row0.CreateCell(i).SetCellValue(Dgv.Columns[i + 1].HeaderText);
            //    }
            //    int roowIndex = 1;
            //    //数据添加
            //    HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
            //    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
            //    foreach (DataGridViewRow Row in Dgv.Rows)
            //    {
            //        HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
            //        for (int i = 0; i < Dgv.ColumnCount - 4; i++)
            //        {
            //            if (i == 2)
            //                hssfrow.CreateCell(i).SetCellValue("");
            //            else if (i == 3)
            //            {
            //                DateTime dTime;
            //                if (DateTime.TryParse(Row.Cells[i + 1].Value.ToString(), out dTime))
            //                    hssfrow.CreateCell(i).SetCellValue(Convert.ToDateTime(Row.Cells[i + 1].Value).ToString("yyyy-MM-dd HH:mm:ss"));
            //                else
            //                    hssfrow.CreateCell(i).SetCellValue(Row.Cells[i + 1].Value.ToString());
            //            }
            //            else
            //            {
            //                if (i == 4 || i == 5 || i == 6)
            //                {
            //                    hssfrow.CreateCell(i).SetCellValue(Convert.ToDouble(Row.Cells[i + 1].Value));
            //                    hssfrow.Cells[i].CellStyle = cellStyle;
            //                }
            //                else
            //                    hssfrow.CreateCell(i).SetCellValue(Row.Cells[i + 1].Value.ToString());
            //            }
            //        }
            //        roowIndex++;
            //    }

            //    FileStream file = new FileStream(PriFlp, FileMode.Create);
            //    hssfworkbook.Write(file);
            //    file.Close();
            //    this.ctrlDownLoad1.download(PriFlp, true);
            //}
            //catch (Exception ex)
            //{
            //    ClsMsgBox.Cw("导出报表失败", ex);
            //    return;
            //}
        }
        #endregion
        #region 机构
        private void BtnJG_Click(object sender, EventArgs e)
        {
            FrmSelectJg4 f = new FrmSelectJg4();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg4 f = sender as FrmSelectJg4;
            if (f.DialogResult == DialogResult.OK)
            {
                //this.TxtCkjg.Text = f.PubDictAttrs["mc"];
                //this.Lbljgid.Text = f.PubDictAttrs["id"];
                this.Lbljgid.Text = "共选择" + f.PubCountJgs + "个机构";
                PriJgids = f.PubCountJgs;
                PriJgidStr = f.PubStr;
            }
            else
            {
                this.Lbljgid.Text = "共选择0个机构";
                PriJgids = 0;
                PriJgidStr = "";
            }
        }
        /*
        private void TxtCkjg_KeyDown(object objSender, KeyEventArgs objArgs)
        {
            if (objArgs.KeyCode == Keys.Back)
            {
                this.TxtCkjg.Text = "";
                this.Lbljgid.Text = "0";
            }
        }
        #endregion
        #region 鼠标单选
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex <= -1)
                return;
            if (e.ColumnIndex == 0)//审核动作
            {
                int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtid.Name].Value);
                int n;
                int aYdcount = 0;
                if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                    aYdcount = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value);
                double m;
                double adsk = 0;
                if (double.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                    adsk = Convert.ToDouble(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvColChkXz.Name].Value))//取消
                {
                    Dgv.Rows[e.RowIndex].Cells[DgvColChkXz.Name].Value = false;
                    PriListId.Remove(aId);
                    PriYdCounts = PriYdCounts - aYdcount;
                    PriSumDsk = PriSumDsk - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("现金"))
                        PriXjje = PriXjje - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).ToUpper().Contains("POS"))
                        PriPosje = PriPosje - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).Contains("农") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                        PriNhje = PriNhje - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).ToUpper().Contains("建") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                        PriJhje = PriJhje - adsk;
                }
                else
                {
                    if (Dgv.Rows[e.RowIndex].Cells[DgvColTxtdskbz.Name].Value.ToString() == "审核通过")
                    {
                        ClsMsgBox.Ts("该代收款日报已经审核通过，不能重复审核！", ObjG.CustomMsgBox, this);
                        return;
                    }
                    Dgv.Rows[e.RowIndex].Cells[DgvColChkXz.Name].Value = true;
                    PriListId.Add(aId);
                    PriYdCounts = PriYdCounts + aYdcount;
                    PriSumDsk = PriSumDsk + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("现金"))
                        PriXjje = PriXjje + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).ToUpper().Contains("POS"))
                        PriPosje = PriPosje + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).Contains("农") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                        PriNhje = PriNhje + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).ToUpper().Contains("建") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                        PriJhje = PriJhje + adsk;
                }
                GetXx();
            }
            if (Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("详细信息"))//详细
            {
                string aRbdh = Dgv.Rows[e.RowIndex].Cells[DgvColTxtrbdh.Name].Value.ToString();
                string aCkjg = Dgv.Rows[e.RowIndex].Cells[DgvColTxtckjg.Name].Value.ToString();
                string aCksj = Convert.ToDateTime(Dgv.Rows[e.RowIndex].Cells[DgvColTxtcksq.Name].Value).ToString("yyyy-MM-dd");//格式
                string aDsk = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString();
                string aYdcounts = "0";
                int n;
                if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                    aYdcounts = Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value.ToString();
                string aDskbz = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdskbz.Name].Value.ToString();
                int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtid.Name].Value);
                FrmQRYCDSKMXLL f = new FrmQRYCDSKMXLL();
                f.ShowDialog();
                f.Prepare(aRbdh, aCkjg, aCksj, aDsk, aYdcounts, aDskbz, aId);
            }
        }
         */
        #endregion
        #region 审核通过
        private void BtnShtg_Click(object sender, EventArgs e)
        {
            //sjdskzt(上缴代收款状态)：默认值为0-未缴款；10-已保存；20-已提交；30-已缴款
            if (PriRowsCunt == 0)
            {
                ClsMsgBox.Ts("请选择要制作的代收款日报！", ObjG.CustomMsgBox, this);
                return;
            }
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (!Convert.ToBoolean(row.Cells[DgvColChkXz.Name].Value))
                    continue;
                Bds.Position = row.Index;
                DSQRYCDSK.VfmsqrycdskmxRow Rows = ((DataRowView)Bds.Current).Row as DSQRYCDSK.VfmsqrycdskmxRow;
                Rows.shsj = DateTime.Now;
                Rows.shczyid = PriZhid;
                Rows.shczyxm = PriXm;
                Rows.shczyzh = PriLogMC;
                Rows.zt = 20;
                PriListId.Add(Rows);
            }
            #region 修改时间 2013/10/24
            //using (SqlConnection conn = new SqlConnection(PriStrCon))
            //{
            //    conn.Open();
            //    SqlTransaction trans = conn.BeginTransaction();
            //    SqlCommand comm = new SqlCommand();
            //    try
            //    {
            //        comm.Connection = conn;
            //        comm.Transaction = trans;
            //        string cmdText = "";
            //        cmdText = " SET NOCOUNT OFF update tfmsdsk set sjdskzt='30' where id in(select dskid from Tfmsdskjkmx where pcid  in (" + string.Join(",", PriListId) + "))";
            //        comm.CommandText = cmdText;
            //        int influenceSum = comm.ExecuteNonQuery();
            //        cmdText = " SET NOCOUNT OFF update Tfmsdskjkpc set  zt='20',shczyid=" + PriZhid + ",shczyxm='" + PriXm + "',shczyzh='" + PriLogMC + "',shsj='" + DateTime.Now.ToString() + "' where id  in (" + string.Join(",", PriListId) + ")";
            //        comm.CommandText = cmdText;
            //        influenceSum = influenceSum + comm.ExecuteNonQuery();
            //        if (influenceSum == PriYdCounts + PriListId.Count)
            //        {
            //            //LblCheckSumJe.Text = "共选中代收款" + PriSumDsk.ToString() + "元";
            //            //提交事物
            //            ClsMsgBox.Ts("审核成功！共审核代收款" + PriSumDsk.ToString() + "元", ObjG.CustomMsgBox, this);
            //            trans.Commit();
            //            //Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select b.dqmc,id,Null as  pos,ckjgmc,zzsj,dsk,dkje,sxf,zzfsmc,ztmc,shsj,rbdh,yhlx,yhzh,yhzhmc,cnt,'详细信息' as Xq,dkzt,dkfs,jdzt,poszt from  Vfmsqrycdskmx  as a left join jyjckj.dbo.Vdqjigou as b on a.jgid=b.jgid " + PriWhere + " order by ckjgmc", PriStrCon);
            //            foreach (DSQRYCDSK.VfmsqrycdskmxRow Row in PriListId)
            //            {
            //                Bds.Remove(Row);
            //            }
            //            Clear();
            //        }
            //        else
            //        {
            //            //回滚事物
            //            ClsMsgBox.Ts("审核失败！", ObjG.CustomMsgBox, this);
            //            trans.Rollback();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //回滚事物
            //        ClsMsgBox.Cw("审核异常！", ex, ObjG.CustomMsgBox, this);
            //        trans.Rollback();

            //    }
            //    finally
            //    {
            //        conn.Close();
            //    }
            //}
            #endregion
            try
            {
                Bds.EndEdit();
                VfmsqrycdskmxTableAdapter1.Update(PriListId.ToArray());
                ClsMsgBox.Ts("审核成功！共审核代收款" + PriSumDsk.ToString() + "元", ObjG.CustomMsgBox, this);
                foreach (DSQRYCDSK.VfmsqrycdskmxRow Row in PriListId)
                {
                    Bds.RemoveAt(Bds.Find("id", Row.id));
                }
                Clear();
            }
            catch (Exception ex)
            {
                //回滚事物
                ClsMsgBox.Cw("审核异常！", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion
        #region 显示信息
        private void GetXx()
        {
            LblCheckCount.Text = "共选中" + PriRowsCunt + "行";
            if (PriSumDsk == 0)
                LblCheckSumJe.Text = "共选中POS 0.00元,现金 0.00元，其中建行 0.00元，农行 0.00元，代扣金额总和为0.00，有0笔修改。";
            else
                LblCheckSumJe.Text = "共选中POS " + PriPosje.ToString() + "元,现金 " + PriXjje.ToString() + "元，其中建行 " + PriJhje.ToString() + "元，农行 " + PriNhje.ToString() + "元，代扣金额总和为" + Math.Round(Convert.ToDouble(jezh), 2) + ",有" + chashu + "笔修改";
        }
        #endregion
        #region 本页全选
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
                return;
            CheckThisPage1();
            GetXx();
        }
        /// <summary>
        /// 此方法与CheckThisPage1相同
        /// </summary>
        /* public void CheckThisPage()
         {
             //一共有多少行
             int rowcount = Convert.ToInt32(Dgv.RowCount);
             //当前是第几页
             int currentpage = Convert.ToInt32(Dgv.CurrentPage);
             //一页有机行
             int pageSize = Convert.ToInt32(Dgv.ItemsPerPage);
             //一共有多少页
             int pageCount = (rowcount / pageSize);
             //合计的值 
             //判断一共有几页，有没有余数
             //如果有余数就是只最后一页不满足我们指定的显示的条数
             //int n = 0;//定义i的初始值
             //int DgvCun = 0;//定义Dgv的显示的页数
             //if (rowcount % pageSize > 0)
             //{
             //    pageCount++;
             //    if (currentpage < pageCount)
             //    {
             //        n = Dgv.FirstDisplayedScrollingRowIndex;
             //        DgvCun = Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage;
             //    }
             //    else
             //    {
             //        n = Dgv.FirstDisplayedScrollingRowIndex;
             //        DgvCun = Dgv.RowCount;
             //    }
             //}
             //else
             //{
             //    n = Dgv.FirstDisplayedScrollingRowIndex;
             //    DgvCun = Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage;
             //}
             //for (int i = n; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
             //{
             //    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColChkXz.Name].Value))
             //    {
             //        if (Dgv.Rows[i].Cells[DgvColTxtdskbz.Name].Value.ToString() != "审核通过")
             //        {
             //            Dgv.Rows[i].Cells[DgvColChkXz.Name].Value = true;
             //            int aId = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value);
             //            int j;
             //            int aYdcount = 0;
             //            if (Int32.TryParse(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out j))
             //                aYdcount = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value);
             //            double m;
             //            double adsk = 0;
             //            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
             //                adsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
             //            PriListId.Add(aId);
             //            PriYdCounts = PriYdCounts + aYdcount;
             //            PriSumDsk = PriSumDsk + adsk;
             //        }
             //    }
             //}
             if (rowcount % pageSize > 0)
             {
                 pageCount++;
                 //先计算除了最后一页的合计
                 if (currentpage < pageCount)
                 {
                     for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                     {
                         if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColChkXz.Name].Value))
                         {
                             if (Dgv.Rows[i].Cells[DgvColTxtdskbz.Name].Value.ToString() != "审核通过")
                             {
                                 Dgv.Rows[i].Cells[DgvColChkXz.Name].Value = true;
                                 int aId = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value);
                                 int n;
                                 int aYdcount = 0;
                                 if (Int32.TryParse(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                                     aYdcount = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value);
                                 double m;
                                 double adsk = 0;
                                 if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                                     adsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                                 PriListId.Add(aId);
                                 PriYdCounts = PriYdCounts + aYdcount;
                                 PriSumDsk = PriSumDsk + adsk;
                             }
                         }
                     }
                 }
                 //计算最后一页的值
                 else
                 {
                     for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                     {
                         if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColChkXz.Name].Value))
                         {
                             if (Dgv.Rows[i].Cells[DgvColTxtdskbz.Name].Value.ToString() != "审核通过")
                             {
                                 Dgv.Rows[i].Cells[DgvColChkXz.Name].Value = true;
                                 int aId = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value);
                                 int n;
                                 int aYdcount = 0;
                                 if (Int32.TryParse(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                                     aYdcount = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value);
                                 double m;
                                 double adsk = 0;
                                 if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                                     adsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                                 PriListId.Add(aId);
                                 PriYdCounts = PriYdCounts + aYdcount;
                                 PriSumDsk = PriSumDsk + adsk;
                             }
                         }
                     }
                 }
             }
             else
             {
                 for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                 {
                     if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColChkXz.Name].Value))
                     {
                         if (Dgv.Rows[i].Cells[DgvColTxtdskbz.Name].Value.ToString() != "审核通过")
                         {
                             Dgv.Rows[i].Cells[DgvColChkXz.Name].Value = true;
                             int aId = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value);
                             int n;
                             int aYdcount = 0;
                             if (Int32.TryParse(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                                 aYdcount = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value);
                             double m;
                             double adsk = 0;
                             if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                                 adsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                             PriListId.Add(aId);
                             PriYdCounts = PriYdCounts + aYdcount;
                             PriSumDsk = PriSumDsk + adsk;
                         }
                     }
                 }
             }



         }*/

        private void CheckThisPage1()
        {
            if (Dgv.Rows.Count <= 0)
                return;
            int curPageFristIndex = 0;
            int curPageCount = Dgv.ItemsPerPage;
            if (Dgv.CurrentPage > 1)
                curPageFristIndex = (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;
            if (Dgv.CurrentPage == Dgv.TotalPages)
                curPageCount = Dgv.RowCount - (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;
            for (int i = curPageFristIndex; i < curPageCount + curPageFristIndex; i++)
            {
                if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColChkXz.Name].Value))
                {
                    if (Dgv.Rows[i].Cells[DgvColTxtdskbz.Name].Value.ToString() != "审核通过")
                    {
                        Dgv.Rows[i].Cells[DgvColChkXz.Name].Value = true;
                        int aId = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value);
                        int n;
                        int aYdcount = 0;
                        if (Int32.TryParse(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                            aYdcount = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value);
                        double m;
                        double adsk = 0;
                        if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                            adsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                        //PriListId.Add(aId);
                        //PriYdCounts = PriYdCounts + aYdcount;
                        PriSumDsk = PriSumDsk + adsk;
                        if (Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtfkfs.Name].Value).Contains("现金"))
                            PriXjje = PriXjje + adsk;
                        if (Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtfkfs.Name].Value).ToUpper().Contains("POS"))
                            PriPosje = PriPosje + adsk;
                        if (Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtyhlx.Name].Value).Contains("农") && Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                            PriNhje = PriNhje + adsk;
                        if (Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtyhlx.Name].Value).ToUpper().Contains("建") && Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                            PriJhje = PriJhje + adsk;
                        if (Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtyhlx.Name].Value).Contains("招商") && Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                            PriZSje = PriZSje + adsk;

                        PriRowsCunt++;
                        string aaa = ClsRWMSSQLDb.GetStr(" select dkje as jec from Vfmsqrycdskmx where id=" + Dgv.Rows[i].Cells["DgvColTxtid"].Value, ClsGlobals.CntStrTMS);
                        jezh = jezh + Convert.ToDouble(aaa);
                        if (Dgv.Rows[i].Cells["DgvColTxtDkje"].Style.ForeColor == Color.Red)
                        {
                            chashu++;
                        }
                    }
                }
            }
            //GetXx();
        }
        #endregion
        #region 全选
        private void ChkB_CheckedChanged(object sender, EventArgs e)
        {
            CheckAll(ChkB.Checked);
            GetXx();
        }
        public void CheckAll(bool aChecked)
        {
            if (Dgv.RowCount == 0)
                return;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                int aId = Convert.ToInt32(row.Cells[DgvColTxtid.Name].Value);
                int n;
                int aYdcount = 0;
                if (Int32.TryParse(row.Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                    aYdcount = Convert.ToInt32(row.Cells[DgvColTxtYdcounts.Name].Value);
                double m;
                double adsk = 0;
                if (double.TryParse(row.Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                    adsk = Convert.ToDouble(row.Cells[DgvColTxtdsk.Name].Value);
                if (!aChecked)//取消全选
                {
                    if (PriRowsCunt == 0)
                        break;
                    if (Convert.ToBoolean(row.Cells[DgvColChkXz.Name].Value))//取消
                    {
                        row.Cells[DgvColChkXz.Name].Value = false;
                        //PriListId.Remove(aId);
                        //PriYdCounts = PriYdCounts - aYdcount;
                        PriSumDsk = PriSumDsk - adsk;
                        if (Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("现金"))
                            PriXjje = PriXjje - adsk;
                        if (Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).ToUpper().Contains("POS"))
                            PriPosje = PriPosje - adsk;
                        if (Convert.ToString(row.Cells[DgvColTxtyhlx.Name].Value).Contains("农") && Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                            PriNhje = PriNhje - adsk;
                        if (Convert.ToString(row.Cells[DgvColTxtyhlx.Name].Value).ToUpper().Contains("建") && Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                            PriJhje = PriJhje - adsk;
                        if (Convert.ToString(row.Cells[DgvColTxtyhlx.Name].Value).Contains("招商") && Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                            PriZSje = PriZSje - adsk;
                        PriRowsCunt--;
                        //string aaa = ClsRWMSSQLDb.GetStr(" select dkje as jec from Vfmsqrycdskmx where id=" + row.Cells["DgvColTxtid"].Value, ClsGlobals.CntStrTMS);
                        //jezh = jezh - Convert.ToDouble(aaa);
                        //if (row.Cells["DgvColTxtDkje"].Style.ForeColor == Color.Red)
                        //{
                        //    chashu--;

                        //}
                        jezh = 0;
                        chashu = 0;
                    }
                }
                else
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColChkXz.Name].Value))//选中
                    {
                        if (row.Cells[DgvColTxtdskbz.Name].Value.ToString() != "审核通过")
                        {
                            row.Cells[DgvColChkXz.Name].Value = true;
                            //PriListId.Add(aId);
                            //PriYdCounts = PriYdCounts + aYdcount;
                            PriSumDsk = PriSumDsk + adsk;
                            if (Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("现金"))
                                PriXjje = PriXjje + adsk;
                            if (Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).ToUpper().Contains("POS"))
                                PriPosje = PriPosje + adsk;
                            if (Convert.ToString(row.Cells[DgvColTxtyhlx.Name].Value).Contains("农") && Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                                PriNhje = PriNhje + adsk;
                            if (Convert.ToString(row.Cells[DgvColTxtyhlx.Name].Value).ToUpper().Contains("建") && Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                                PriJhje = PriJhje + adsk;
                            if (Convert.ToString(row.Cells[DgvColTxtyhlx.Name].Value).Contains("招商") && Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                                PriZSje = PriZSje + adsk;
                            PriRowsCunt++;
                        }
                        string aaa = ClsRWMSSQLDb.GetStr(" select dkje as jec from Vfmsqrycdskmx where id=" + row.Cells["DgvColTxtid"].Value, ClsGlobals.CntStrTMS);
                        jezh = jezh + Convert.ToDouble(aaa);
                        if (row.Cells["DgvColTxtDkje"].Style.ForeColor == Color.Red)
                        {
                            chashu++;

                        }
                    }
                }
            }
        }
        #endregion

        private void BtnJd_Click(object sender, EventArgs e)
        {
            GetDj(0);
        }

        private void BtnDj_Click(object sender, EventArgs e)
        {
            GetDj(1);
        }
        private void GetDj(byte aZt)
        {
            if (PriRowsCunt == 0)
                return;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (!Convert.ToBoolean(row.Cells[DgvColChkXz.Name].Value))
                    continue;
                Bds.Position = row.Index;
                DSQRYCDSK.VfmsqrycdskmxRow Rows = ((DataRowView)Bds.Current).Row as DSQRYCDSK.VfmsqrycdskmxRow;
                if (Rows.jdzt1 == aZt)
                    continue;
                Rows.jdzt1 = aZt;
                PriListId.Add(Rows);
            }
            if (PriListId.Count == 0)
                ClsMsgBox.Ts("没有要操作的信息!", ObjG.CustomMsgBox, this);
            try
            {
                Bds.EndEdit();
                this.vfmsqrycdskmx1TableAdapter1.Update(PriListId.ToArray());
                foreach (DSQRYCDSK.VfmsqrycdskmxRow row in PriListId)
                {
                    Bds.RemoveAt(Bds.Find("id", row.id));
                }
                Clear();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #region 鼠标单选
        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex <= -1)
                return;
            if (e.ColumnIndex == 0)//审核动作
            {
                int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtid.Name].Value);
                int n;
                int aYdcount = 0;
                if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                    aYdcount = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value);
                double m;
                double adsk = 0;
                if (double.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                    adsk = Convert.ToDouble(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvColChkXz.Name].Value))//取消
                {
                    Dgv.Rows[e.RowIndex].Cells[DgvColChkXz.Name].Value = false;
                    //PriYdCounts = PriYdCounts - aYdcount;
                    PriSumDsk = PriSumDsk - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("现金"))
                        PriXjje = PriXjje - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).ToUpper().Contains("POS"))
                        PriPosje = PriPosje - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).Contains("农") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                        PriNhje = PriNhje - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).ToUpper().Contains("建") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                        PriJhje = PriJhje - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).Contains("招商") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                        PriZSje = PriZSje - adsk;
                    PriRowsCunt--;
                    if (Dgv.CurrentRow.Cells["DgvColTxtDkje"].Style.ForeColor == Color.Red)
                    {
                        chashu--;
                        string aaa = ClsRWMSSQLDb.GetStr(" select (dkje-dsk) as jec from Vfmsqrycdskmx where id=" + Dgv.CurrentRow.Cells["DgvColTxtid"].Value, ClsGlobals.CntStrTMS);
                        jezh = jezh - Convert.ToDouble(aaa);
                    }
                }
                else
                {
                    if (Dgv.Rows[e.RowIndex].Cells[DgvColTxtdskbz.Name].Value.ToString() == "审核通过")
                    {
                        ClsMsgBox.Ts("该代收款日报已经审核通过，不能重复审核！", ObjG.CustomMsgBox, this);
                        return;
                    }
                    Dgv.Rows[e.RowIndex].Cells[DgvColChkXz.Name].Value = true;
                    //PriYdCounts = PriYdCounts + aYdcount;
                    PriSumDsk = PriSumDsk + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("现金"))
                        PriXjje = PriXjje + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).ToUpper().Contains("POS"))
                        PriPosje = PriPosje + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).Contains("农") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                        PriNhje = PriNhje + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).ToUpper().Contains("建") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                        PriJhje = PriJhje + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).Contains("招商") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("现"))
                        PriZSje = PriZSje + adsk;
                    PriRowsCunt++;
                    string aaa = ClsRWMSSQLDb.GetStr(" select dkje as jec from Vfmsqrycdskmx where id=" + Dgv.CurrentRow.Cells["DgvColTxtid"].Value, ClsGlobals.CntStrTMS);
                    jezh = jezh + Convert.ToDouble(aaa);
                    if (Dgv.CurrentRow.Cells["DgvColTxtDkje"].Style.ForeColor == Color.Red)
                    {
                        chashu++;

                    }
                }
                GetXx();
            }
            if (Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("详细信息"))//详细
            {
                string aRbdh = Dgv.Rows[e.RowIndex].Cells[DgvColTxtrbdh.Name].Value.ToString();
                string aCkjg = Dgv.Rows[e.RowIndex].Cells[DgvColTxtckjg.Name].Value.ToString();
                string aCksj = string.IsNullOrEmpty(Dgv.Rows[e.RowIndex].Cells[DgvColTxtcksq.Name].Value.ToString()) ? "" : Convert.ToDateTime(Dgv.Rows[e.RowIndex].Cells[DgvColTxtcksq.Name].Value).ToString("yyyy-MM-dd");//格式
                string aDsk = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString();
                string aDKje = Dgv.Rows[e.RowIndex].Cells[DgvColTxtDkje.Name].Value.ToString();
                string aYdcounts = "0";
                int n;
                if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                    aYdcounts = Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value.ToString();
                string aDskbz = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdskbz.Name].Value.ToString();
                int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtid.Name].Value);
                FrmQRYCDSKMXLL f = new FrmQRYCDSKMXLL();
                f.ShowDialog();
                f.Prepare(aRbdh, aCkjg, aCksj, aDsk, aYdcounts, aDskbz, aId, aDKje);
            }
        #endregion
        }
    }
}
