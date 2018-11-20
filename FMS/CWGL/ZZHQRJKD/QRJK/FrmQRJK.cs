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
using NPOI.SS.Util;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
#endregion
namespace FMS.CWGL.ZZHQRJKD.QRJK
{
    public partial class FrmQRJK : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private List<int> PriListShid = new List<int>();//连锁店
        private DataTable PriJgDt = new DataTable();
        private List<int> PriLstYbfid = new List<int>();//运保费表中的id
        private List<int> PriLstKhjsid = new List<int>();//客户结算表中的PCid
        private string PriConStr;
        private int PriUserid;
        private string PriUserZh;
        private string PriUserXm;
        private int PriToJgid;//登录者的机构id
        private int PriJgid;//需要审核的机构id
        private string PriShzt;//审核状态
        private string PriYwqy;//业务区域
        private string PriSqlCon;
        private int PriYhlxid;//导出银行网银的银行类型id
        private double PriCuntsJe = 0;
        private List<string> PriListYhlx = new List<string>();
        private DataTable PriDt = new DataTable();
        #endregion
        #region 初始化数据
        public FrmQRJK()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriConStr = ClsGlobals.CntStrTMS;
            PriToJgid = ObjG.Jigou.id;
            PriUserid = ObjG.Renyuan.id;
            PriUserZh = ObjG.Renyuan.loginName;
            PriUserXm = ObjG.Renyuan.xm;
            PnlMain.Controls.Add(PnlJgcx);
            PnlJgcx.Visible = false; 
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            CmbYwqy.SelectedIndex = 0;
            CmbZt.SelectedIndex = 0;
            CmbYHlx.SelectedIndex = 0;
            //GetYhlx();
        }
        #endregion
        #region 机构查询
        private void TxtJg_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            PnlJgcx.Visible = true;
            string CmdText = "select mc as name,pym,id from jyjckj.dbo.tjigou  where id in( select 0 as jgid union all select jgid  from Tfmsjggx where tojgid=" + ObjG.Jigou.id + " and gxzl='J') and (pym like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%' or  mc like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%')";
            //string CmdText = "select Name,pym,id from jyjckj.dbo.GetChildren2(" + ObjG.Jigou.id + ") where pym like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%' or  name like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%'";
            PriJgDt = ClsRWMSSQLDb.GetDataTable(CmdText, ClsGlobals.CntStrTMS);
            LstV.DataSource = PriJgDt;
            LstV.Columns[0].Text = "机构名称";
            LstV.Columns[1].Text = "拼音码";
            LstV.Columns[2].Text = "jgid";
            LstV.Columns[2].Visible = false;
            LstV.Columns[0].Width = 120;
            LstV.Focus();
        }
        private void LstV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                if (TxtJg.Text.Trim().Length != 0)
                    TxtJg.Text = TxtJg.Text.Trim().Substring(0, TxtJg.Text.Trim().Length - 1);
                TxtJg.SelectionStart = TxtJg.Text.Length;
                TxtJg.Focus();
                PnlJgcx.Visible = false;
                PriJgDt.Dispose();
            }

            if (LstV.Items.Count > 0)
            {
                if (e.KeyChar == 13)
                {
                    this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
                    PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
                    this.PnlJgcx.Visible = false;
                    PriJgDt.Dispose();
                }
            }
        }
        private void LstV_LostFocus(object sender, EventArgs e)
        {
            PnlJgcx.Visible = false;
            PriJgDt.Dispose();
        }
        private void LstV_DoubleClick(object sender, EventArgs e)
        {
            this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
            PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
            this.PnlJgcx.Visible = false;
            PriJgDt.Dispose();

        }
        //private void DgvJgcx_LostFocus(object sender, EventArgs e)
        //{
        //    PnlJgcx.Visible = false;
        //    PriJgDt.Dispose();
        //}
        //private void DgvJgcx_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    this.TxtJgmc.Text = DgvJgcx.CurrentRow.Cells[DgvColTxtJgmc.Name].Value.ToString();
        //    PriJgid = Convert.ToInt32(DgvJgcx.CurrentRow.Cells["DgvColTxtjgid"].Value.ToString());
        //    this.PnlJgcx.Visible = false;
        //    PriJgDt.Dispose();
        //}
        //private void DgvJgcx_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 8)
        //    {
        //        if (TxtJg.Text.Trim().Length != 0)
        //            TxtJg.Text = TxtJg.Text.Trim().Substring(0, TxtJg.Text.Trim().Length - 1);
        //        TxtJg.SelectionStart = TxtJg.Text.Length;
        //        TxtJg.Focus();
        //        PnlJgcx.Visible = false;
        //        PriJgDt.Dispose();
        //    }
        //}
        #endregion
        #region 查询
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PriListShid.Clear();
            PriSqlCon = "";
            PriCuntsJe = 0;
            //DSqrjk1 = new DSQRJK();
            string Where = " where  tojgid=" + PriToJgid;
            //查询机构
            if (PriJgid > 0)
                Where = Where + " and jgid=" + PriJgid;
            //审核状态
            if (!this.CmbZt.Text.Trim().Equals("全部"))
            {
                PriShzt = this.CmbZt.Text.Trim();
                if (PriShzt.Equals("未审核"))
                    Where = Where + " and  zt=0 ";
                else if (PriShzt.Equals("审核相符"))
                    Where = Where + " and  zt=10 ";
            }
            //银行类型
            if (CmbYHlx.SelectedIndex != 0)
            {
                Where = Where + "  and yhlxmc='" + CmbYHlx.Text + "'";
            }
            //业务区域
            if (this.CmbYwqy.SelectedIndex>0)
            {
                PriYwqy = this.CmbYwqy.SelectedValue.ToString();
                Where = Where + "  and ywqy='" + PriYwqy + "'";
            }
            //制作开始日期
            if (DtpStart.Checked)
                Where = Where + " and  inssj >= '" + DtpStart.Value.ToString("yyyy-MM-dd") + "'";
            Where=Where+" and inssj< '" + DtpStop.Value.AddDays(1).ToString("yyyy-MM-dd") + "'";
            //确认日期
            if (DtpQrStart.Checked && DtpQrStop.Checked)
                Where = Where + " and  shsj >='" + DtpQrStart.Value.ToString("yyyy-MM-dd") + "' and shsj < '" + DtpQrStop.Value.AddDays(1).ToString("yyyy-MM-dd") + "'";
            if (DtpQrStart.Checked && !DtpQrStop.Checked)
                Where = Where + " and  shsj >= '" + DtpQrStart.Value.ToString("yyyy-MM-dd") + "' and shsj < '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            if (!DtpQrStart.Checked && DtpQrStop.Checked)
                Where = Where + " and  shsj  <='" + DtpQrStop.Value.AddDays(1).ToString("yyyy-MM-dd") + "'";
            Where += " ORDER BY jgmc collate Chinese_PRC_CS_AS_KS_WS,rbdh ";
            //PriSqlCon = "SELECT id, rbdh, jgid, jgmc, tojgid, tojgmc, dqid, dqmc, yck, ywqy, zzje, scje, inssj, shsj, zt,'详情' as xx, ztmc, pid, zh, zhmc, yhlxid, yhlxmc FROM dbo.Vfmsqrjk " + Where;
            //PriDt.Clear();
            //PriDt = ClsRWMSSQLDb.GetDataTable(PriSqlCon, PriConStr);
            //Dgv.DataSource = PriDt;

            VfmsqrjkTableAdapter1.FillByWhere(DSqrjk1.Vfmsqrjk, Where);
            //Dgv.DataSource = DSqrjk1.Vfmsqrjk;
            LblCount.Text = "共查询出" + Dgv.Rows.Count + "条记录";
            if (Dgv.RowCount < 1)
            {
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
                PriSqlCon = "";
                return;
            }
            LblHj.Text = DSqrjk1.Vfmsqrjk.Compute("sum(scje)", "").ToString();
            SumThisPage();
            Xh();
        }
        public void Xh()
        {
            for (int i = 0; i < Dgv.Rows.Count; i++)
            {
                Dgv.Rows[i].Cells[DgvColTxtXh.Name].Value = i + 1;
            }
        }
        #endregion
        #region 审核相符
        private void BtnSh_Click(object sender, EventArgs e)
        {
            if (PriListShid.Count == 0)
            {
                ClsMsgBox.Ts("请选择要审核的缴款日报！", ObjG.CustomMsgBox, this);
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
                    cmdText = " SET NOCOUNT OFF  update Tfmsrbpc set zt='10',shsj='" + DateTime.Now + "',shczyid=" + PriUserid + ",shczyxm='" + PriUserXm + "',shczyzh='" + PriUserZh + "' where id in(" + string.Join(",", PriListShid) + ");";
                    GetYdid();
                    if (PriLstYbfid.Count != 0)
                        cmdText = cmdText + " update tfmsybf set zt='20' where id in(" + string.Join(",", PriLstYbfid) + ");";
                    if (PriLstKhjsid.Count != 0)
                    {
                        cmdText = cmdText + " update Tfmskhjspc set zt='20' where id in(" + string.Join(",", PriLstKhjsid) + ");";
                        cmdText = cmdText + " update tfmsybf set zt='20' where id in (select ybfid from Tfmskhjsmx where pcid in (select id from Tfmskhjspc where id in(" + string.Join(",", PriLstKhjsid) + "))) ;";
                    }
                    comm.CommandText = cmdText;
                    int influenceSum = comm.ExecuteNonQuery();
                    if (influenceSum > 0)
                    {
                        //提交事物
                        ClsMsgBox.Ts("审核成功！", ObjG.CustomMsgBox, this);
                        foreach (int i in PriListShid)
                        {
                            int index = Bds.Find("id", i);
                            Bds.RemoveAt(index);
                        }
                        PriLstYbfid.Clear();
                        PriListShid.Clear();
                        PriLstKhjsid.Clear();
                        PriCuntsJe = 0;
                        trans.Commit();

                        //Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(PriSqlCon, PriConStr);
                        //BtnSearch.PerformClick();
                        GetXx();
                    }
                    else
                    {
                        //回滚事物
                        ClsMsgBox.Ts("审核失败！", ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    //回滚事物
                    try
                    {
                        ClsMsgBox.Cw("审核异常！", ex, ObjG.CustomMsgBox, this);
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
        /// <summary>
        /// 获取运单id
        /// </summary>
        private void GetYdid()
        {
            PriLstYbfid.Clear();
            string aSQlCont = " select ybfid from Tfmsrbmx where  ybfid>0 and rbpcid in(" + string.Join(",", PriListShid) + ")";
            DataTable dt = ClsRWMSSQLDb.GetDataTable(aSQlCont, PriConStr);
            if (dt.Rows.Count >= 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PriLstYbfid.Add(Convert.ToInt32(dt.Rows[i][0]));
                }
            }
            aSQlCont = " select khjsid from Tfmsrbmx where  khjsid>0 and rbpcid in(" + string.Join(",", PriListShid) + ")";
            dt = ClsRWMSSQLDb.GetDataTable(aSQlCont, PriConStr);
            if (dt.Rows.Count >= 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PriLstKhjsid.Add(Convert.ToInt32(dt.Rows[i][0]));
                }
            }
        }
        #endregion
        #region 鼠标单选
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                if (Dgv.Rows[e.RowIndex].Cells["DgvColTxtshzt"].Value.ToString() == "审核相符")
                {
                    ClsMsgBox.Ts("该缴款日报已经审核通过！", ObjG.CustomMsgBox, this);
                    return;
                }
                int aid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtid"].Value.ToString());
                double n;
                double aRowje = 0;
                if (double.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtsjyc.Name].Value.ToString(), out n))
                    aRowje = Convert.ToDouble(Dgv.Rows[e.RowIndex].Cells[DgvColTxtsjyc.Name].Value);

                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvColCbm.Name].Value))//取消选择
                {
                    Dgv.Rows[e.RowIndex].Cells[DgvColCbm.Name].Value = false;
                    PriListShid.Remove(aid);
                    PriCuntsJe = PriCuntsJe - aRowje;
                }
                else
                {
                    Dgv.Rows[e.RowIndex].Cells[DgvColCbm.Name].Value = true;
                    PriListShid.Add(aid);
                    PriCuntsJe = PriCuntsJe + aRowje;
                }
                GetXx();
            }
            //详情
            if (e.ColumnIndex == 13)
            {
                FrmYbfXq f = new FrmYbfXq();
                f.ShowDialog();
                f.Prepare(Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtid"].Value.ToString()), Dgv.Rows[e.RowIndex].Cells["DgvColTxtJkrb"].Value.ToString());
            }
        }
        #endregion
        #region 导出
        #region Excel报表
        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            CreatExcel();
        }
        private void CreatExcel()
        {
            string PriFln = "确认缴款清单_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";//文件名称     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
            //写入数据
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet") as HSSFSheet;
            HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
            cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
            try
            {
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                for (int i = 2; i < Dgv.ColumnCount - 6; i++)
                {
                    if (i == 3)
                        row0.CreateCell(i - 2).SetCellValue("存款机构");
                    else if (i == 5)
                        row0.CreateCell(i - 2).SetCellValue("运费金额");
                    else if (i == 6)
                        row0.CreateCell(i - 2).SetCellValue("日报单号");
                    else if (i == 7)
                        row0.CreateCell(i - 2).SetCellValue("转出银行");
                    else if (i == 8)
                        row0.CreateCell(i - 2).SetCellValue("转出银行帐号");
                    else if (i == 9)
                        row0.CreateCell(i - 2).SetCellValue("转出帐户名称");
                    else
                        row0.CreateCell(i - 2).SetCellValue(Dgv.Columns[i].HeaderText);
                }
                int roowIndex = 1;
                //数据添加
                foreach (DataGridViewRow Row in Dgv.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    for (int i = 2; i < Dgv.ColumnCount - 6; i++)
                    {
                        if (i == 4)
                            hssfrow.CreateCell(i - 2).SetCellValue(Convert.ToDateTime(Row.Cells[i].Value.ToString()).ToString("yyyy-MM-dd"));
                        else if (i == 5)
                        {
                            hssfrow.CreateCell(i - 2).SetCellValue(Convert.ToDouble(Row.Cells[10].Value));
                            row0.Cells[i - 2].CellStyle = cellStyle;
                        }
                        else if (i >= 6)
                            hssfrow.CreateCell(i - 2).SetCellValue(Row.Cells[i - 1].Value.ToString());
                        else
                            hssfrow.CreateCell(i - 2).SetCellValue(Row.Cells[i].Value.ToString());
                    }
                    roowIndex++;
                }
                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
                this.ctrlDownLoad1.download(PriFlp, true);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("导出库存报表失败", ex);
            }
        }
        #endregion
        #region 建行网银文件
        private void menuItem2_Click(object sender, EventArgs e)
        {
            int coutn = FileDgv("建设银行");
            if (coutn == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            else if (coutn == -1)
            {
                ClsMsgBox.Ts("页面信息中没有建行要确认缴款的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            else
            {
                string PriFln = "建行扣款明细" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
                string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
                HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
                HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                //写入数据
                HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
                sheet1.SetColumnWidth(0, 25 * 240);
                sheet1.SetColumnWidth(1, 25 * 120);
                try
                {
                    int roowIndex = 0;
                    for (int i = 0; i < Dgv.RowCount; i++)
                    {
                        if (Dgv.Rows[i].Cells["DgvColTxtshzt"].Value.ToString() == "未审核" && Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtyhlxid"].Value) == PriYhlxid)
                        {
                            HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                            for (int m = 0; m < 3; m++)
                            {
                                if (m == 0)
                                    hssfrow.CreateCell(0).SetCellValue(Dgv.Rows[i].Cells["DgvColTxtyhzh"].Value.ToString());
                                else if (m == 1)
                                    hssfrow.CreateCell(1).SetCellValue(Dgv.Rows[i].Cells["DgvColTxtyhzhmc"].Value.ToString());
                                else
                                {
                                    hssfrow.CreateCell(2).SetCellValue(Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtscje.Name].Value));
                                    hssfrow.Cells[2].CellStyle = cellStyle;
                                }
                            }
                            roowIndex++;
                        }
                    }
                    FileStream file = new FileStream(PriFlp, FileMode.Create);
                    hssfworkbook.Write(file);
                    file.Close();
                    this.ctrlDownLoad1.download(PriFlp, true);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("制作建行网银Excel失败！", ex);
                }
            }
        }
        #endregion
        #region 农行网银文件
        private void menuItem3_Click(object sender, EventArgs e)
        {
            int cout = FileDgv("农业银行");
            if (cout == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            else if (cout == -1)
            {
                ClsMsgBox.Ts("页面信息中没有农行要确认缴款的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            else
            {
                try
                {
                    string PriFln = "农行扣款明细" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";//文件名称     
                    string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
                    int PriNo = 1;
                    FileStream fs1 = new FileStream(PriFlp, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs1);
                    string str = "";
                    for (int i = 0; i < Dgv.Rows.Count; i++)
                    {
                        if (Dgv.Rows[i].Cells["DgvColTxtshzt"].Value.ToString() == "未审核" && Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtyhlxid"].Value) == PriYhlxid)
                        {
                            PriNo.ToString();
                            if (PriNo.ToString().Length == 1)
                                str += "00000" + PriNo;
                            else if (PriNo.ToString().Length == 2)
                                str += "0000" + PriNo;
                            else if (PriNo.ToString().Length == 3)
                                str += "000" + PriNo;
                            else if (PriNo.ToString().Length == 4)
                                str += "00" + PriNo;
                            else if (PriNo.ToString().Length == 5)
                                str += "0" + PriNo;
                            else
                                str += PriNo;
                            str += ",";
                            for (int j = 1; j < Dgv.Columns.Count - 1; j++)
                            {
                                if (Dgv.Columns[j].HeaderText == "银行账户" || Dgv.Columns[j].HeaderText == "银行账户名称" || Dgv.Columns[j].HeaderText == "实际应存(元)")
                                {
                                    str += Dgv.Rows[i].Cells[j].Value.ToString();
                                    str += ",";
                                }
                            }
                            str += "货款";
                            str += "\r\n";
                            PriNo++;
                        }
                    }
                    str = str.Substring(0, str.LastIndexOf("\r\n"));
                    sw.WriteLine(str);//要写入的信息。 
                    this.ctrlDownLoad1.download(PriFlp, true);
                    sw.Close();
                    fs1.Close();
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("制作农行网银文本失败!", ex, ObjG.CustomMsgBox, this);
                }
            }
        }
        #endregion
        private int FileDgv(string yhlxjc)
        {
            int b = 0;
            PriYhlxid = 0;
            if (Dgv.RowCount == 0)
                return b;
            //if (yhlxjc != "商业银行")
            PriYhlxid = ClsRWMSSQLDb.GetInt(" select id from tyhlx where jc='" + yhlxjc + "'", PriConStr);
            //else
            //{
            //    DataTable dt = ClsRWMSSQLDb.GetDataTable(" select id from tyhlx where jc='农业银行' or jc='建设银行'", PriConStr);
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        PriListYhlx.Add(dt.Rows[i][0].ToString());
            //    }
            //}
            int cout = 0;
            for (int i = 0; i < Dgv.RowCount; i++)
            {
                string zt = Dgv.Rows[i].Cells["DgvColTxtshzt"].Value.ToString();
                int n = 0;
                int yhlx = 0;
                if (int.TryParse(Dgv.Rows[i].Cells["DgvColTxtyhlxid"].Value.ToString(), out n))
                    yhlx = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtyhlxid"].Value);
                //if (zt == "未审核")
                //{
                //    if (yhlx == PriYhlxid && PriYhlxid > 0)
                //        cout++;
                //    else
                //    {
                //        for (int m = 0; i < PriListYhlx.Count; m++)
                //        {
                //            if (yhlx != Convert.ToInt32(PriListYhlx[m]))
                //                cout++;
                //        }
                //    }
                //}
                if (zt == "未审核" && yhlx == PriYhlxid && PriYhlxid > 0)
                    cout++;
            }
            //PriListYhlx.Clear();
            if (cout == 0)
                return b = -1;
            return b = cout;
        }
        #endregion
        #region 商行
        //private void menuItem4_Click(object sender, EventArgs e)
        //{
        //    int cout = FileDgv("商业银行");
        //    if (cout == 0)
        //    {
        //        ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
        //        return;
        //    }
        //    else if (cout == -1)
        //    {
        //        ClsMsgBox.Ts("页面信息中没有农行要确认缴款的信息！", ObjG.CustomMsgBox, this);
        //        return;
        //    }
        //    else
        //    {
        //    }
        //}
        #endregion
        #region 农行网银文件
        private void menuItem3_Click_1(object sender, EventArgs e)
        {
            int cout = FileDgv("农业银行");
            if (cout == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            else if (cout == -1)
            {
                ClsMsgBox.Ts("页面信息中没有农行要确认缴款的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            else
            {
                try
                {
                    string PriFln = "农行扣款明细" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";//文件名称     
                    string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
                    int PriNo = 1;
                    FileStream fs1 = new FileStream(PriFlp, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs1);
                    string str = "";
                    for (int i = 0; i < Dgv.Rows.Count; i++)
                    {
                        if (Dgv.Rows[i].Cells["DgvColTxtshzt"].Value.ToString() == "未审核" && Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtyhlxid"].Value) == PriYhlxid)
                        {
                            PriNo.ToString();
                            if (PriNo.ToString().Length == 1)
                                str += "00000" + PriNo;
                            else if (PriNo.ToString().Length == 2)
                                str += "0000" + PriNo;
                            else if (PriNo.ToString().Length == 3)
                                str += "000" + PriNo;
                            else if (PriNo.ToString().Length == 4)
                                str += "00" + PriNo;
                            else if (PriNo.ToString().Length == 5)
                                str += "0" + PriNo;
                            else
                                str += PriNo;
                            str += ",";
                            for (int j = 1; j < Dgv.Columns.Count - 1; j++)
                            {
                                if (Dgv.Columns[j].HeaderText == "银行账户" || Dgv.Columns[j].HeaderText == "银行账户名称" || Dgv.Columns[j].HeaderText == "实存金额(元)")
                                {
                                    str += Dgv.Rows[i].Cells[j].Value.ToString();
                                    str += ",";
                                }
                            }
                            str += "货款";
                            str += "\r\n";
                            PriNo++;
                        }
                    }
                    str = str.Substring(0, str.LastIndexOf("\r\n"));
                    sw.WriteLine(str);//要写入的信息。 
                    this.ctrlDownLoad1.download(PriFlp, true);
                    sw.Close();
                    fs1.Close();
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("制作农行网银文本失败!", ex, ObjG.CustomMsgBox, this);
                }
            }
        }
        #endregion

        #region 本页全选
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
                return;
            CheckThisPage();
            GetXx();
        }
        public void CheckThisPage()
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
            if (rowcount % pageSize > 0)
            {
                pageCount++;
                //先计算除了最后一页的合计
                if (currentpage < pageCount)
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                    {

                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value) && Dgv.Rows[i].Cells["DgvColTxtshzt"].Value.ToString() != "审核相符")
                        {
                            int aid = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtid"].Value.ToString());
                            double n;
                            double aRowje = 0;
                            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtsjyc.Name].Value.ToString(), out n))
                                aRowje = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtsjyc.Name].Value);
                            Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;
                            PriListShid.Add(aid);
                            PriCuntsJe = PriCuntsJe + aRowje;
                        }
                    }
                }
                //计算最后一页的值
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value) && Dgv.Rows[i].Cells["DgvColTxtshzt"].Value.ToString() != "审核相符")
                        {
                            int aid = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtid"].Value.ToString());
                            double n;
                            double aRowje = 0;
                            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtsjyc.Name].Value.ToString(), out n))
                                aRowje = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtsjyc.Name].Value);
                            Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;
                            PriListShid.Add(aid);
                            PriCuntsJe = PriCuntsJe + aRowje;
                        }
                    }
                }
            }
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value) && Dgv.Rows[i].Cells["DgvColTxtshzt"].Value.ToString() != "审核相符")
                    {
                        int aid = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtid"].Value.ToString());
                        double n;
                        double aRowje = 0;
                        if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtsjyc.Name].Value.ToString(), out n))
                            aRowje = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtsjyc.Name].Value);
                        Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;
                        PriListShid.Add(aid);
                        PriCuntsJe = PriCuntsJe + aRowje;
                    }
                }
            }
        }
        #endregion

        #region GetXx();
        private void GetXx()
        {
            if (PriListShid.Count == 0)
            {
                LblCheckCount.Text = "共选中0行,选中确认金额共0.00元";
            }
            else
            {
                LblCheckCount.Text = "共选中" + PriListShid.Count + "行,选中确认金额共" + PriCuntsJe + "元";
            }
        }
        #endregion

        #region  全选
        private void ChkB_CheckedChanged(object sender, EventArgs e)
        {
            CheckAll(ChkB.Checked);
            GetXx();
        }
        public void CheckAll(bool aChecked)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {

                if (row.Cells["DgvColTxtshzt"].Value.ToString() != "审核相符")
                {
                    int aid = Convert.ToInt32(row.Cells["DgvColTxtid"].Value.ToString());
                    double n;
                    double aRowje = 0;
                    if (double.TryParse(row.Cells[DgvColTxtsjyc.Name].Value.ToString(), out n))
                        aRowje = Convert.ToDouble(row.Cells[DgvColTxtsjyc.Name].Value);
                    if (!aChecked)//取消全选
                    {
                        if (Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))//取消选择
                        {
                            row.Cells[DgvColCbm.Name].Value = false;
                            PriListShid.Remove(aid);
                            PriCuntsJe = PriCuntsJe - aRowje;
                        }
                    }
                    else
                    {
                        if (!Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))//取消选择
                        {
                            row.Cells[DgvColCbm.Name].Value = true;
                            PriListShid.Add(aid);
                            PriCuntsJe = PriCuntsJe + aRowje;
                        }
                    }
                }
            }
        }
        #endregion

        #region 本页合计
        private void SumThisPage()
        {
            decimal sum = 0;
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
            if (rowcount % pageSize > 0)
            {
                pageCount++;
                //先计算除了最后一页的合计
                if (currentpage < pageCount)
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                    {
                        sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtscje.Name].Value);
                    }
                }
                //计算最后一页的值
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                    {
                        sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtscje.Name].Value);
                    }
                }
            }
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtscje.Name].Value);
                }
            }
            LblByhj.Text = sum.ToString();
        }
        #endregion

        private void BtnClear1_Click(object sender, EventArgs e)
        {
            this.TxtJgmc.Clear();
            PriJgid = 0;
        }

        private void Dgv_PagingChanged(object sender, EventArgs e)
        {
            SumThisPage();
        }
    }
}
