#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pub;
using JY.Pri;
using System.Collections;
using JYPubFiles.Pri;
using System.Configuration;
using System.IO;
using NPOI.HSSF.UserModel;

#endregion

namespace FMS.CWGL.YBFYQZLDK
{
    public partial class FrmYBFYQZLDK : UserControl
    {
        #region 成员变量
        private string PriServerKhhStr = ClsRWDBOptions.GetStr("YBF_KHH", ClsGlobals.CntStrKj);//运保费建行客户号
        private string PriServerPwdStr = ClsRWDBOptions.GetStr("YBF_DLMM", ClsGlobals.CntStrKj);//运保费建行密码
        private string PriServerCZYH = ClsRWDBOptions.GetStr("YBF_CZYH", ClsGlobals.CntStrKj);//运保费建行操作员号
        private string PriServerDKBH = ClsRWDBOptions.GetStr("YBF_DKBH", ClsGlobals.CntStrKj);//运保费建行代扣编号
        private string PriServerDKYTBH = ClsRWDBOptions.GetStr("YBF_DKYTPH", ClsGlobals.CntStrKj);//运保费建行代扣用途编号
        private string PriDgzh;//对公账户
        private string PriDgzhId;//对公账户ID
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private string PriWhere;
        private int PriRowCount;
        private decimal PriZj;
        string[] XML_TXValues;
        private string CmdText;
        private List<string> LstValues = new List<string>();
        private List<int> LstRowIndex = new List<int>();
        private List<string> LstError = new List<string>();
        private List<DSYBFDK.VfmsYbfdkRow> LstPcid = new List<DSYBFDK.VfmsYbfdkRow>();

        private DSYBFDK.VfmsYbfdkRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as DSYBFDK.VfmsYbfdkRow;
                }
            }
        }
        #endregion

        public FrmYBFYQZLDK()
        {
            InitializeComponent();
        }
        #region 初始化数据
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            PnlMain.Controls.Add(PnlJgcx);
            PnlJgcx.Visible = false;
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable(" select id,jc from tyhlx where  hdzt='Y' and id in(63)  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbYHlx, dtYhlx, "id", "jc"); 
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            CmbDczt.SelectedIndex = 0;
            CmbYHlx.SelectedIndex = 0;
            CmbYwqy.SelectedIndex = 0;
            CmbDkzt.SelectedIndex = 0;
            DataTable dt = ClsRWMSSQLDb.GetDataTable("select id,zh from Tfmsyhzh where  zhlxid=51 and zhxz='G'   and yhlxid=63  and zt=0", ClsGlobals.CntStrTMS);
            if (dt.Rows.Count == 1)
            {
                PriDgzh = dt.Rows[0]["zh"].ToString();
                PriDgzhId = dt.Rows[0]["id"].ToString();
            }
            VfmsYbfdkTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;

        }
        #endregion

        #region  机构查询
        private void TxtJg_EnterKeyDown_1(object objSender, KeyEventArgs objArgs)
        {
            PnlJgcx.Visible = true;
            string CmdText = "select mc,pym,id from  tjigou  where (pym like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%' or mc like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%') and id>1";
            PriJgDt = ClsRWMSSQLDb.GetDataTable(CmdText, ClsGlobals.CntStrKj);
            LstV.DataSource = PriJgDt;
            LstV.Columns[0].Text = "机构名称";
            LstV.Columns[1].Text = "拼音码";
            LstV.Columns[2].Text = "jgid";
            LstV.Columns[2].Visible = false;
            LstV.Columns[0].Width = 120;
            LstV.Focus();
        }
        private void LstV_LostFocus(object sender, EventArgs e)
        {
            PnlJgcx.Visible = false;
            PriJgDt.Dispose();
        }
        private void LstV_DoubleClick(object sender, EventArgs e)
        {
            this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
            this.LblJgid.Text = LstV.SelectedItems[0].SubItems[2].Text;
            this.PnlJgcx.Visible = false;
            PriJgDt.Dispose();
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
                    this.LblJgid.Text = LstV.SelectedItems[0].SubItems[2].Text;
                    this.PnlJgcx.Visible = false;
                    PriJgDt.Dispose();
                    TxtJg.Focus();
                }
            }
        }
        #endregion

        #region 查询
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            ClsD.TextBoxTrim(this);
            this.ChkB.Checked = false;
            Clear();
            PriWhere = " where spjgid= " + ObjG.Jigou.id;
            if (!string.IsNullOrEmpty(TxtJgmc.Text))
                PriWhere += " and jgid in(select id from jyjckj.dbo.tjigou where parentLst like '%," + LblJgid.Text + ",%')";
            PriWhere += " and yhlxid=" + CmbYHlx.SelectedValue;
            PriWhere += CmbYwqy.SelectedIndex == 0 ? "" : " and ywqy='" + CmbYwqy.SelectedValue + "'";
            PriWhere += " and dkzts='" + CmbDkzt.Text + "'";
            PriWhere += " and cksj between '" + DtpStart.Value + "' and dateadd(dd,1,'" + DtpStop.Value + "')";
            PriWhere += CmbDczt.SelectedIndex == 0 ? "" : " and dczts='" + CmbDczt.SelectedValue + "'";
            try
            {
                if (VfmsYbfdkTableAdapter1.FillByWhere(this.DSYBFDK1.VfmsYbfdk, PriWhere) == 0)
                    ClsMsgBox.Ts("没有查询到相应信息，请核对查询条件重新查询！", ObjG.CustomMsgBox, this);
            }
            catch
            {
                ClsMsgBox.Ts("信息查询失败，请重新查询", ObjG.CustomMsgBox, this);
            }

        }
        #endregion

        #region Clear()
        private void Clear()
        {
            PriRowCount = 0;
            PriZj = 0;
            LblCheckCount.Text = "共选中" + PriRowCount.ToString() + "行,选中代扣金额共" + PriZj.ToString() + "元";

        }
        #endregion

        #region 单行选择
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    PriRowCount--;
                    PriZj -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtSck.Name].Value);
                }
                else
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    PriRowCount++;
                    PriZj += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtSck.Name].Value);
                }
            }
            LblCheckCount.Text = "共选中" + PriRowCount.ToString() + "行,选中代扣金额共" + PriZj.ToString() + "元";
        }
        #endregion

        #region 全选
        private void ChkB_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (ChkB.Checked)
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                    {
                        row.Cells[DgvColCbm.Name].Value = true;
                        PriRowCount++;
                        PriZj += Convert.ToDecimal(row.Cells[DgvColTxtSck.Name].Value);
                    }
                }
                else
                {
                    if (Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                    {
                        row.Cells[DgvColCbm.Name].Value = false;
                        PriRowCount--;
                        PriZj -= Convert.ToDecimal(row.Cells[DgvColTxtSck.Name].Value);
                    }
                }
            }
            LblCheckCount.Text = "共选中" + PriRowCount.ToString() + "行,选中代扣金额共" + PriZj.ToString() + "元";
        }
        #endregion

        #region 本页全选

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
                return;
            CheckThisPage();
            LblCheckCount.Text = "共选中" + PriRowCount.ToString() + "行,选中代扣金额共" + PriZj.ToString() + "元";
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
            decimal sum = 0;
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
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value))
                        {
                            PriRowCount++;
                            Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;
                            sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtSck.Name].Value);

                        }
                    }
                    PriZj += sum;
                }
                //计算最后一页的值
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value))
                        {
                            PriRowCount++;
                            Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;
                            sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtSck.Name].Value);
                        }
                    }
                    PriZj += sum;
                }
            }
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value))
                    {
                        PriRowCount++;
                        Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;
                        sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtSck.Name].Value);

                    }
                }
                PriZj += sum;
            }
        }
        #endregion

        #region 银企直连代扣
        private void BtnSh_Click(object sender, EventArgs e)
        {
            LstError.Clear();
            LstRowIndex.Clear();
            if (PriRowCount <= 0)
            {
                ClsMsgBox.Ts("请选择需要代扣的信息!", ObjG.CustomMsgBox, this);
                return;
            }
            if (string.IsNullOrEmpty(PriDgzh))
            {
                ClsMsgBox.Ts("没有对公账户或对公账户维护重复！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Bds.Count == 0)
            {
                ClsMsgBox.Ts("请查询需要代扣的信息!", ObjG.CustomMsgBox, this);
                return;
            }
            try
            {
                Dk();
            }
            finally
            {
                if (LstError.Count == 0)
                    ClsMsgBox.Ts("代扣完成，请查询代扣结果！", ObjG.CustomMsgBox, this);
                else
                    ClsMsgBox.Cw("代扣失败，请重新查询后再次代扣！" + Environment.NewLine + string.Join(Environment.NewLine, LstError), ObjG.CustomMsgBox, this);
            }
        }


        /// <summary>
        /// 循环DataGridView，获取需要代扣的帐号信息
        /// </summary>
        private void Dk()
        {
            try
            {
                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                    {
                        LstRowIndex.Add(Convert.ToInt32(row.Cells[DgvColTxtrbid.Name].Value));
                        Socket(row.Cells[DgvColTxtRbdh.Name].Value.ToString(), row.Cells[DgvColTxtYhzh.Name].Value.ToString(), row.Cells[DgvColTxtZhmc.Name].Value.ToString(), row.Cells[DgvColTxtSck.Name].Value.ToString());
                        InserLog(row.Cells[DgvColTxtRbdh.Name].Value.ToString(), row.Cells[DgvColTxtZczhid.Name].Value.ToString(), row.Cells[DgvColTxtrbid.Name].Value.ToString(), row.Cells[DgvColTxtSck.Name].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LstError.Add("代扣失败！" + ex.Message);
            }
            finally
            {
                Clear();
                foreach (int id in LstRowIndex)
                {
                    Bds.RemoveAt(Bds.Find("ybfrbpcid", id));
                }
            }
        }
        /// <summary>
        /// 组装并发送报文，得到代扣结果
        /// </summary>
        /// <param name="aYhzh">代扣银行帐号</param>
        /// <param name="aZhmc">代扣帐号名称</param>
        /// <param name="aJe">代扣金额</param>
        private void Socket(string aRbdh, string aYhzh, string aZhmc, string aJe)
        {
            try
            {
                string[] strName = new string[] { "RETURN_CODE", "RETURN_MSG" };
                LstValues.Clear();
                XML_TXValues = new string[] { GetXlh("Y").ToString(), PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W1303", "CN", PriDgzh, PriServerDKBH, aYhzh, aZhmc, aJe, PriServerDKYTBH, "", "", "", "", "" };
                string recvStr = ClsYBFSockets.sendStr(XML_TXValues, "6W1303.xml");
                LstValues = ClsGetXML.GetListStr(strName, recvStr);
            }
            catch (Exception ex)
            {
                LstError.Add(aRbdh + "银企直连代扣失败！" + ex.Message);
            }


        }
        /// <summary>
        /// 将代扣结果写入日志表
        /// </summary>
        /// <param name="aZczhid">转出账户ID</param>
        /// <param name="aRbpcid">日报批次Id</param>
        /// <param name="aJe">转账额</param>
        private void InserLog(string aRbdh, string aZczhid, string aRbpcid, string aJe)
        {
            try
            {
                CmdText = "";
                if (LstValues.Count != 0)
                {
                    if (LstValues[0] == "000000")
                    {
                        CmdText = string.Format("Insert  into TfmsKjlog (ybfrbpcid,zczhid,zrzhid,zze,zy,inssj,insczyid,insczyxm,insczyzh) values('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}');update tfmsrbpc set dkzt=10  where id={9}",
                            aRbpcid, aZczhid, PriDgzhId, aJe, LstValues[1].ToString(), "getdate()", ObjG.Renyuan.id, ObjG.Renyuan.xm, ObjG.Renyuan.loginName, aRbpcid);
                        ClsRWMSSQLDb.ExecuteCmd(CmdText, ClsGlobals.CntStrTMS);
                    }
                    else
                    {
                        CmdText = string.Format("Insert  into TfmsKjlog (ybfrbpcid,zczhid,zrzhid,zze,zy,inssj,insczyid,insczyxm,insczyzh,zt) values('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}',{9});update tfmsrbpc set dkzt=20  where id={10}",
                                aRbpcid, aZczhid, PriDgzhId, aJe, LstValues[1].ToString(), "getdate()", ObjG.Renyuan.id, ObjG.Renyuan.xm, ObjG.Renyuan.loginName, 20, aRbpcid);
                        ClsRWMSSQLDb.ExecuteCmd(CmdText, ClsGlobals.CntStrTMS);
                    }
                }
            }
            catch (Exception ex)
            {
                LstError.Add(aRbdh + "写入代扣日志错误！" + ex.Message);
            }

        }
        /// <summary>
        /// 请求序列号
        /// </summary>
        /// <param name="aType"></param>
        /// <returns></returns>
        private int GetXlh(string aType)
        {
            return ClsRWMSSQLDb.GetInt(string.Format("Insert into tfmsybfxlh values('{0}',getdate());Select SCOPE_IDENTITY()", aType), ClsGlobals.CntStrTMS);
        }
        #endregion

        

        private void BtnClear1_Click(object sender, EventArgs e)
        {
            TxtJgmc.Clear();
            LblJgid.Text = "";
        }

        #region 导出
        #region 导出Excel
        private void menuItem4_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
                return;
            if (Dgv.Rows.Count > 60000)
            {
                ClsMsgBox.Ts("不允许导出大于60000条的数据!", (Session["ObjG"] as ClsG).CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 7, 8, 9 };
            ClsExcel.CreatExcel(Dgv, "运保费代扣信息", this.ctrlDownLoad1, Rows);
        }
        #endregion

        #region 建行网银
        private void menuItem5_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("没有需要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }

            LstPcid.Clear();
            string PriFln = "总部建行运保费代扣明细" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件 
            //写入数据
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.SetColumnWidth(0, 25 * 240);
            sheet1.SetColumnWidth(1, 25 * 120);
            HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
            cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
            try
            {

                int rowindex = 0;
                for (int i = 0; i < Dgv.Rows.Count; i++)
                {
                    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value))
                        continue;
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(rowindex);
                    Bds.Position = i;
                    DSYBFDK.VfmsYbfdkRow Rows = ((DataRowView)Bds.Current).Row as DSYBFDK.VfmsYbfdkRow;
                    if (Rows.wydkzt != 10)
                    {
                        Rows.dczt = 10;
                        Rows.wydkzt = 5;
                        LstPcid.Add(Rows);
                        for (int m = 0; m < Dgv.Columns.Count; m++)
                        {
                            if (Dgv.Columns[m].Name.ToString().Equals("DgvColTxtDkje"))
                            {
                                hssfrow.CreateCell(2).SetCellValue(Convert.ToDouble(Dgv.Rows[i].Cells[m].Value));
                                hssfrow.Cells[2].CellStyle = cellStyle;
                            }
                            else if (Dgv.Columns[m].Name.ToString().Equals("DgvColTxtYhzh"))
                            {
                                hssfrow.CreateCell(0).SetCellValue(Convert.ToString(Dgv.Rows[i].Cells[m].Value));
                            }
                            else if (Dgv.Columns[m].Name.ToString().Equals("DgvColTxtZhmc"))
                            {
                                hssfrow.CreateCell(1).SetCellValue(Dgv.Rows[i].Cells[m].Value.ToString());
                            }
                        }
                        rowindex++;
                    }
                }
                if (LstPcid.Count == 0)
                {
                    ClsMsgBox.Ts("请选择需要导出的代扣信息！", ObjG.CustomMsgBox, this);
                    return;
                }
                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
                this.ctrlDownLoad1.download(PriFlp, true);
                Bds.EndEdit();
                VfmsYbfdkTableAdapter1.Update(LstPcid.ToArray());
                this.ChkB.Checked = false;
                Clear();
                foreach (DSYBFDK.VfmsYbfdkRow Row in LstPcid)
                {
                    Bds.RemoveAt(Bds.Find("id", Row.id));
                }
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("导出网银报表失败！", ex);
                return;
            }
        }
        #endregion

        #region 农行网银
        private void menuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                LstPcid.Clear();
                string PriFln = "农行运保费代扣" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";//文件名称     
                string path = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
                int PriNo = 1;
                FileStream fs1 = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs1, Encoding.UTF8);
                string str = "";
                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                        continue;
                    Bds.Position = row.Index;
                    DSYBFDK.VfmsYbfdkRow Rows = ((DataRowView)Bds.Current).Row as DSYBFDK.VfmsYbfdkRow;
                    if (Rows.wydkzt != 10)
                    {
                        Rows.dczt = 10;
                        Rows.wydkzt = 5;
                        LstPcid.Add(Rows);
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
                        str += Convert.ToString(row.Cells[DgvColTxtYhzh.Name].Value);
                        str += ",";
                        str += row.Cells[DgvColTxtZhmc.Name].Value.ToString();
                        str += ",";
                        str += double.Parse(row.Cells[DgvColTxtDkje.Name].Value.ToString());
                        str += ",";
                        str += "货款";
                        str += "\r\n";
                        PriNo++;
                    }
                }
                if (string.IsNullOrEmpty(str))
                {
                    ClsMsgBox.Ts("没有需要导出的信息！", ObjG.CustomMsgBox, this);
                    return;
                }
                str = str.Substring(0, str.LastIndexOf("\r\n"));
                sw.WriteLine(str);//要写入的信息。 
                ctrlDownLoad1.download(path, true);
                sw.Close();
                fs1.Close();
                Bds.EndEdit();
                VfmsYbfdkTableAdapter1.Update(LstPcid.ToArray());
                this.ChkB.Checked = false;
                Clear();

                foreach (DSYBFDK.VfmsYbfdkRow Row in LstPcid)
                {
                    Bds.RemoveAt(Bds.Find("id", Row.id));
                }
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("导出信息失败", ex);
                return;
            }
        }
        #endregion


        #endregion

        #region 修改代扣金额
        private void BtnUpd_Click(object sender, EventArgs e)
        {
            if (PriRow == null)
                return;
            if (PriRow.dkzt == 5)
            {
                ClsMsgBox.Ts("该笔运保费正在代扣中，不允许操作！", ObjG.CustomMsgBox, this);
                return;
            }
            if (PriRow.dkzt == 10)
            {
                ClsMsgBox.Ts("该笔运保费已经代扣，不允许操作！", ObjG.CustomMsgBox, this);
                return;
            }
            FrmJexg f = new FrmJexg();
            f.Prepare(Bds, PriRow);
            f.ShowDialog();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed2);
        }
        void f_FormClosed2(object sender, FormClosedEventArgs e)
        {
            if (Convert.ToDecimal(Dgv.CurrentRow.Cells[DgvColTxtDkje.Name].Value.ToString()) != Convert.ToDecimal(Dgv.CurrentRow.Cells[DgvColTxtscje.Name].Value.ToString()))
            {
                Dgv.CurrentRow.Cells[DgvColTxtDkje.Name].Style.ForeColor = Color.Red;
            }
        }
        #endregion

        


    }
}
