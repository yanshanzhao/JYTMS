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
using JY.Pri;
using JY.Pub;
using JYPubFiles.Classes;
using System.Data.SqlClient;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Configuration;

#endregion

namespace FMS.DSKGL.WYFFYCCL
{
    public partial class FrmWYFFYCCL : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private string PriWhere;
        private string Priffzt;
        private int PriRowCout;
        private decimal PriZje;
        private decimal PriZje1;
        private List<string> LstSQL = new List<string>();
        private DataTable PriDt;
        private bool flag;
        private int RowIndex;
        //private List<int> LstId = new List<int>();
        //private List<int> LstNotDel = new List<int>();
        #endregion
        #region 异常原因
        private List<ClsBhMcByte> PriLstYcyy = new List<ClsBhMcByte>();
        public class ClsBhMcByte
        {
            public ClsBhMcByte(string abh, string amc)
            {
                Bh = abh;
                Mc = amc;
            }
            public string Bh { get; set; }
            public string Mc { get; set; }
            public string Bh_Mc
            {
                get
                {
                    return Bh + ":" + Mc;
                }
            }
        }
        #endregion
        public FrmWYFFYCCL()
        {
            InitializeComponent();
            PriLstYcyy.Add(new ClsBhMcByte("K", "卡销"));
            PriLstYcyy.Add(new ClsBhMcByte("Z", "账号错误"));
            PriLstYcyy.Add(new ClsBhMcByte("X", "客户姓名不符"));
            PriLstYcyy.Add(new ClsBhMcByte("H", "开户行错误"));
            PriLstYcyy.Add(new ClsBhMcByte("Q", "其他"));
            this.DgvCmb.DataSource = PriLstYcyy;
            DgvCmb.DisplayMember = "mc";
            DgvCmb.ValueMember = "bh";
        }
        #region 初始化数据
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            //DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable(" select 0 as id,'全部' as jc  union  select id,jc from tyhlx where  hdzt='Y' and id in(63,64,241)  ", ClsGlobals.CntStrTMS);
            //ClsPopulateCmbDsS.PopuByTb(this.CmbYhlx, dtYhlx, "id", "jc");
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable("select 'all' as bh,'--全部--' as mc union all select bh,mc from Tfmsdskffyhlx where zt=1  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbYhlx, dtYhlx, "bh", "mc");
            ClsPopulateCmbDsS.PopuFMSDSKZZ_dszl(CmbDSZL);
            CmbYhlx.SelectedIndex = 0;
            CmbZt.SelectedIndex = 0;
            CmbDSZL.SelectedIndex = 0;
        }
        #endregion
        #region 查询
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            //TimeSpan ts = DtpStop.Value - DtpStart.Value;
            //if (ts.Days > 7 || ts.Days < -7)
            //{
            //    ClsMsgBox.Ts("查询天数不能超过七天！", ObjG.CustomMsgBox, this);
            //    Dgv.DataSource = "";
            //    return;
            //}
            if (!DtpUpdsjJ.Checked && !DtpUpdsjK.Checked)
            {
                if (string.IsNullOrEmpty(this.TxtBh.Text.Trim().ToString()) && string.IsNullOrEmpty(this.TxtFwkh.Text.Trim().ToString()) && string.IsNullOrEmpty(this.TxtYhzh.Text.Trim().ToString()) && string.IsNullOrEmpty(this.TxtKhmc.Text.Trim().ToString()))
                {
                    ClsMsgBox.Ts("服务卡号、货运单号、客户名称、卡号修改时间和银行账号至少填写一个！", ObjG.CustomMsgBox, this);
                    return;
                }
            }
            try
            {
                Clear();
                ClsD.TextBoxTrim(this);


                PriWhere = "";
               
                if (DtpStart.Checked)
                    PriWhere += " and ffsj>='" + DtpStart.Value.Date + "'";
                if (DtpStop.Checked)
                    PriWhere += " and ffsj <'" + DtpStop.Value.AddDays(1).Date + "'";
                PriWhere += DtpUpdsjK.Checked ? " and updsj>='" + DtpUpdsjK.Value.Date + "'" : "";
                PriWhere += DtpUpdsjJ.Checked ? " and updsj<'" + DtpUpdsjJ.Value.Date.AddDays(1) + "'" : "";
                PriWhere+=Convert.ToInt32(CmbZt.SelectedIndex) == 0 ? " and (zt=20 or zt=10)" : " and zt=0 ";
                PriWhere += string.IsNullOrEmpty(TxtBh.Text) ? "" : " and bh like '" + TxtBh.Text + "'";
                PriWhere += string.IsNullOrEmpty(TxtFwkh.Text) ? "" : " and fwkh like '" + TxtFwkh.Text + "'";
                PriWhere += string.IsNullOrEmpty(TxtYhzh.Text) ? "" : " and yhzh = '" + TxtYhzh.Text + "'";
                PriWhere += string.IsNullOrEmpty(TxtKhmc.Text) ? "" : " and mc like '" + TxtKhmc.Text + "'";
                PriWhere += CmbDSZL.SelectedIndex == 0 ? "" : " and lx='" + CmbDSZL.SelectedValue + "'";
                //PriWhere += Convert.ToInt32(CmbYhlx.SelectedValue) == 0 ? "" : Convert.ToInt32(CmbYhlx.SelectedValue) == 64 ? " and yhid not in(63,241)" : " and yhid=" + CmbYhlx.SelectedValue;
                PriWhere += CmbYhlx.SelectedValue.Equals("all") ? "" : " and ffyhlx ='" + CmbYhlx.SelectedValue + "'";
                //PriWhere += " and ffsj between '" + DtpStart.Value + "' and dateadd(d,1,'" + DtpStop.Value + "')";
                PriWhere=PriWhere.Trim();
                if (PriWhere.Length > 0)
                    PriWhere =" where " +PriWhere.Remove(0, 3);
                Priffzt = CmbZt.Text.ToString();
                PriDt = ClsRWMSSQLDb.GetDataTable("select *,'删除' as cz from Vfmswyffyccl " + PriWhere, ClsGlobals.CntStrTMS);
                Dgv.DataSource = PriDt;
                if (Priffzt == "发放成功")
                {
                    Dgv.Columns[DgvColTxtTzjl.Name].ReadOnly = true;
                    Dgv.Columns[DgvCmb.Name].ReadOnly = false;
                }
                else if (Priffzt == "发放异常")
                {
                    Dgv.Columns[DgvColTxtTzjl.Name].ReadOnly = false;
                    Dgv.Columns[DgvCmb.Name].ReadOnly = true;
                }
                //PriDt = ClsRWMSSQLDb.GetDataTable("select * from Vfmswyffyccl1 "+PriWhere,ClsGlobals.CntStrTMS);;
                if (Dgv.Rows.Count == 0)
                {
                    ClsMsgBox.Ts("无查询信息，请核对查询条件！", ObjG.CustomMsgBox, this);
                    return;
                }

            }
            catch
            {
                ClsMsgBox.Cw("查询信息失败，请重新查询！", ObjG.CustomMsgBox, this);
                Clear();
            }
        }
        #endregion
        #region 单行选择
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (string.IsNullOrEmpty(Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvCmb.Name].Value)))
                {
                    if (string.IsNullOrEmpty(Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYcxx.Name].Value)))
                    {
                        ClsMsgBox.Ts("请选择异常原因！", ObjG.CustomMsgBox, this);
                        return;
                    }
                }
                if (!Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    PriRowCout++;
                    PriZje += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtJe.Name].Value);
                }
                else
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    PriRowCout--;
                    PriZje -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtJe.Name].Value);
                }
                LblCheckCount.Text = "共选中" + PriRowCout + "笔，总金额" + PriZje + "元";
            }
            if (e.RowIndex >= 0 && Dgv.Columns[e.ColumnIndex].Name.Equals("DgvColLnk"))
            {
                if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtLx1.Name].Value) == "2")
                {
                    RowIndex = e.RowIndex;
                    ClsMsgBox.YesNo("确认删除该条信息吗？", new EventHandler(Delete), ObjG.CustomMsgBox, this);
                }
                else
                {
                    ClsMsgBox.Ts("该运单不允许删除！", ObjG.CustomMsgBox, this);
                }
            }

        }
        #endregion
        private void Delete(object sender, EventArgs e)
        {
            Form f = sender as Form;
            FrmMsgBox frm = new FrmMsgBox();
            if (f.DialogResult == DialogResult.Yes)
            {
                try
                {
                    ClsRWMSSQLDb.ExecuteCmd("delete tfmsdskffyc where id=" + Dgv.Rows[RowIndex].Cells[DgvColTxtId.Name].Value, ClsGlobals.CntStrTMS);
                    ClsMsgBox.Ts("删除成功！", frm, this);
                    PriDt = ClsRWMSSQLDb.GetDataTable("select *,'删除' as cz from Vfmswyffyccl1 " + PriWhere, ClsGlobals.CntStrTMS);
                    Dgv.DataSource = PriDt;
                    //Dgv.Rows.Remove(Dgv.Rows[RowIndex]);
                    Clear();
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("删除失败！", ex, frm, this);
                }
            }
        }
        #region 异常
        private void BtnYc_Click(object sender, EventArgs e)
        {
            if (PriRowCout == 0)
            {
                ClsMsgBox.Ts("请选择处理信息！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Priffzt == "发放异常")
            {
                ClsMsgBox.Ts("标记信息为异常信息，不能再进行异常处理！", ObjG.CustomMsgBox, this);
                return;
            }
            //if (CmbYcyy.SelectedIndex == -1)
            //{
            //    ClsMsgBox.Ts("标记信息为异常信息的原因！", ObjG.CustomMsgBox, this);
            //    return;
            //}
            ClsMsgBox.YesNo("确认将选中的发放信息标记为发放异常？", new EventHandler(SaveMessage), ObjG.CustomMsgBox, this);
        }
        private void SaveMessage(object sender, EventArgs e)
        {
            FrmMsgBox frm = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {

                try
                {
                    InsertMx();
                    if (PriZje != PriZje1)
                    {
                        ClsMsgBox.Ts("标记异常信息失败！", frm, this);
                        return;
                    }
                    ClsRWMSSQLDb.ExecuteCmd(string.Join(";", LstSQL), ClsGlobals.CntStrTMS);
                    ClsMsgBox.Ts("标记信息成功！", frm, this);
                    PriDt = ClsRWMSSQLDb.GetDataTable("select *,'删除' as cz from Vfmswyffyccl1 " + PriWhere, ClsGlobals.CntStrTMS);
                    Dgv.DataSource = PriDt;
                    Clear();
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("标记异常信息失败！", ex, frm, this);
                }
            }
        }
        private void InsertMx()
        {
            //备注：K-卡销,Z-账号错误,X-客户姓名不符,H-开户行错误,Q-其他
            //string aBz = "";
            //if (CmbYcyy.Text == "卡销") 
            //    aBz = "K";
            //else if (CmbYcyy.Text == "账号错误")
            //    aBz = "Z";
            //else if (CmbYcyy.Text == "客户姓名不符")
            //    aBz = "X";
            //else if (CmbYcyy.Text == "开户行错误")
            //    aBz = "H";
            //else
            //    aBz = "Q";
            LstSQL.Clear();
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvColTxtChk.Name].Value))
                {

                    PriZje1 += Convert.ToDecimal(row.Cells[DgvColTxtJe.Name].Value);
                    LstSQL.Add(string.Format("Insert into Tfmsdskffyc (mxid,dskid,je,zt,inssj,insczyxm,insczyzh,insczyid,fflx,bz)" +
                        " values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}')", row.Cells[DgvColTxtMxid.Name].Value, row.Cells[DgvColTxtDskId.Name].Value,
                        row.Cells[DgvColTxtJe.Name].Value, 0, "getdate()", ObjG.Renyuan.xm, ObjG.Renyuan.loginName, ObjG.Renyuan.id, row.Cells[DgvColTxtFflx.Name].Value, row.Cells[DgvCmb.Name].Value));
                }
            }
        }
        #endregion
        #region Clear() 页面显示
        private void Clear()
        {
            PriRowCout = 0;
            PriZje = 0;
            PriZje1 = 0;
            LblCheckCount.Text = "共选中" + PriRowCout + "笔，总金额" + PriZje + "元";
            RowIndex = -2;
        }
        #endregion
        #region 发放
        private void BtnFf_Click(object sender, EventArgs e)
        {
            if (PriRowCout == 0)
            {
                ClsMsgBox.Ts("请选择处理信息！", ObjG.CustomMsgBox, this);
                return;
            }

            if (Priffzt == "发放成功")
            {
                ClsMsgBox.Ts("标记信息为发放成功信息，不能再进行发放处理！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsMsgBox.YesNo("确认将选中的发放异常信息标记为已发放？", new EventHandler(SaveMessage1), ObjG.CustomMsgBox, this);
        }
        private void SaveMessage1(object sender, EventArgs e)
        {
            FrmMsgBox frm = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {
                if (PriRowCout == 0)
                {
                    ClsMsgBox.Ts("请选择要导出的信息！", ObjG.CustomMsgBox, this);
                    return;
                }
                int[] CellIndex = new int[] { 10, 11, 12 };
                #region  导出
                string PriFln = "代收款发放异常处理" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
                string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
                HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
                //写入数据
                HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
                sheet1.DefaultColumnWidth = 17;
                try
                {
                    InsertFfmx();
                    if (PriZje != PriZje1)
                    {
                        ClsMsgBox.Ts("标记异常信息失败！", frm, this);
                        return;
                    }
                    //导出
                    //行名的的设置
                    HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                    HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                    LieFont.FontHeightInPoints = 10;
                    LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                    styleRow.SetFont(LieFont);
                    HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                    int n = 0;//Dgv中的隐藏列的个数
                    for (int i = 0; i < Dgv.ColumnCount; i++)
                    {
                        if (Dgv[i, 0].Visible)
                        {
                            if (Dgv[i, 0].GetType().Name == "DataGridViewCheckBoxCell")
                            {
                                n = n + 1;
                                continue;
                            }
                            //if (Dgv[i, 0].GetType().Name == "DataGridViewComboBoxCell")
                            //{
                            //    n = n + 1;
                            //    continue;
                            //}
                            if (Dgv[i, 0].GetType().Name == "DataGridViewImageCell")
                            {
                                n = n + 1;
                                continue;
                            }
                            if (Dgv[i, 0].GetType().Name == "DataGridViewButtonCell")
                            {
                                n = n + 1;
                                continue;
                            }
                            if (Dgv[i, 0].GetType().Name == "DataGridViewLinkCell")
                            {
                                n = n + 1;
                                continue;
                            }
                            if (Dgv[i, 0].GetType().Name == "DataGridViewMaskedTextBoxCell")
                            {
                                n = n + 1;
                                continue;
                            }
                            row0.CreateCell(i - n).SetCellValue(Dgv.Columns[i].HeaderText);
                            row0.Cells[i - n].CellStyle = styleRow;
                        }
                        else
                            n = n + 1;
                    }
                    int roowIndex = 1;
                    //数据添加
                    foreach (DataGridViewRow Row in Dgv.Rows)
                    {
                        HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                        int m = 0;//Dgv中的隐藏列的个数
                        if (Convert.ToBoolean(Row.Cells[DgvColTxtChk.Name].Value))
                        {
                            for (int i = 0; i < Dgv.ColumnCount; i++)
                            {
                                if (Dgv[i, 0].Visible)
                                {
                                    if (Dgv[i, 0].GetType().Name == "DataGridViewCheckBoxCell")
                                    {
                                        m = m + 1;
                                        continue;
                                    }
                                    //if (Dgv[i, 0].GetType().Name == "DataGridViewComboBoxCell")
                                    //{
                                    //    m = m + 1;
                                    //    continue;
                                    //}
                                    if (Dgv[i, 0].GetType().Name == "DataGridViewImageCell")
                                    {
                                        m = m + 1;
                                        continue;
                                    }
                                    if (Dgv[i, 0].GetType().Name == "DataGridViewButtonCell")
                                    {
                                        m = m + 1;
                                        continue;
                                    }
                                    if (Dgv[i, 0].GetType().Name == "DataGridViewLinkCell")
                                    {
                                        m = m + 1;
                                        continue;
                                    }
                                    if (Dgv[i, 0].GetType().Name == "DataGridViewMaskedTextBoxCell")
                                    {
                                        m = m + 1;
                                        continue;
                                    }
                                    //判断是否有数字格式的列
                                    //if (LstCellIndex.Contains(i - m))
                                    //if()
                                    //{
                                    //    hssfrow.CreateCell(i - m).SetCellValue(Convert.ToDouble(Row.Cells[i].Value));
                                    //    hssfrow.Cells[i - m].CellStyle = cellStyle;
                                    //}
                                    //else
                                    if (Dgv[i, 0].GetType().Name == "DataGridViewComboBoxCell")
                                    {
                                        string ycxx = Row.Cells[i].EditedFormattedValue.ToString();
                                        //string ycxx = Row.Cells[i].FormattedValue.ToString(); 
                                        hssfrow.CreateCell(i - m).SetCellValue(ycxx);
                                    }
                                    else
                                    {
                                        if (CellIndex.ToList().Contains(i))
                                        {
                                            double j;
                                            if (double.TryParse(Convert.ToString(Row.Cells[i].Value), out j))
                                            {
                                                hssfrow.CreateCell(i - m).SetCellValue(Convert.ToDouble(Row.Cells[i].Value));
                                                hssfrow.Cells[i - m].CellStyle = cellStyle;
                                            }
                                            else
                                            {
                                                hssfrow.CreateCell(i - m).SetCellValue(Convert.ToString(Row.Cells[i].Value));
                                            }
                                        }
                                        else
                                            hssfrow.CreateCell(i - m).SetCellValue(Convert.ToString(Row.Cells[i].Value));
                                    }


                                }
                                else
                                    m = m + 1;
                            }
                            roowIndex++;
                        }

                    }
                    //if (roowIndex == 1)
                    //{
                    //    ClsMsgBox.Ts("请选择要导出的信息！", ObjG.CustomMsgBox, this);
                    //    return;
                    //}
                    FileStream file = new FileStream(PriFlp, FileMode.Create);
                    hssfworkbook.Write(file);
                    file.Close();
                    //DownLoad.download(PriFlp, true);
                    this.ctrlDownLoad1.download(PriFlp, true);
                #endregion
                    ClsRWMSSQLDb.ExecuteCmd(string.Join(";", LstSQL), ClsGlobals.CntStrTMS);
                    //ClsMsgBox.Ts("标记信息成功！", frm, this);
                    PriDt = ClsRWMSSQLDb.GetDataTable("select *,'删除' as cz from Vfmswyffyccl1 " + PriWhere, ClsGlobals.CntStrTMS);
                    Dgv.DataSource = PriDt;
                    Clear();
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("标记异常信息失败！", ex, frm, this);
                }
            }
        }
        private void InsertFfmx()
        {
            LstSQL.Clear();

            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvColTxtChk.Name].Value))
                {
                    PriZje1 += Convert.ToDecimal(row.Cells[DgvColTxtJe.Name].Value);
                    LstSQL.Add(string.Format("Insert into Tfmsdskffyc (mxid,dskid,je,zt,inssj,insczyxm,insczyzh,insczyid,fflx)" +
                        " values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}')", row.Cells[DgvColTxtMxid.Name].Value, row.Cells[DgvColTxtDskId.Name].Value,
                        row.Cells[DgvColTxtJe.Name].Value, 10, "getdate()", ObjG.Renyuan.xm, ObjG.Renyuan.loginName, ObjG.Renyuan.id, 20));
                }
            }
        }
        #endregion
        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            //if (Dgv.RowCount == 0)
            //{
            //    ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //int[] Rows = new int[] { 8 };
            //ClsExcel.CreatExcel(Dgv, "代收款发放异常处理", this.ctrlDownLoad1, Rows);
            GetExl(new int[] { 10, 11, 12 });
        }
        private void GetExl(int[] aCellIndex = null)
        {
            List<int> LstCellIndex = new List<int>();
            if (aCellIndex != null)
            {
                if (aCellIndex.Length != 0)
                    LstCellIndex.AddRange(aCellIndex);
            }
            //int[] LstCellIndex = new int[] { 8 };
            if (PriRowCout == 0)
            {
                ClsMsgBox.Ts("请选择要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "代收款发放异常处理" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
            //写入数据
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.DefaultColumnWidth = 17;
            try
            {
                //行名的的设置
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                LieFont.FontHeightInPoints = 10;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.SetFont(LieFont);
                HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                int n = 0;//Dgv中的隐藏列的个数
                for (int i = 0; i < Dgv.ColumnCount; i++)
                {
                    if (Dgv[i, 0].Visible)
                    {
                        if (Dgv[i, 0].GetType().Name == "DataGridViewCheckBoxCell")
                        {
                            n = n + 1;
                            continue;
                        }
                        //if (Dgv[i, 0].GetType().Name == "DataGridViewComboBoxCell")
                        //{
                        //    n = n + 1;
                        //    continue;
                        //}
                        if (Dgv[i, 0].GetType().Name == "DataGridViewImageCell")
                        {
                            n = n + 1;
                            continue;
                        }
                        if (Dgv[i, 0].GetType().Name == "DataGridViewButtonCell")
                        {
                            n = n + 1;
                            continue;
                        }
                        if (Dgv[i, 0].GetType().Name == "DataGridViewLinkCell")
                        {
                            n = n + 1;
                            continue;
                        }
                        if (Dgv[i, 0].GetType().Name == "DataGridViewMaskedTextBoxCell")
                        {
                            n = n + 1;
                            continue;
                        }
                        row0.CreateCell(i - n).SetCellValue(Dgv.Columns[i].HeaderText);
                        row0.Cells[i - n].CellStyle = styleRow;
                    }
                    else
                        n = n + 1;
                }
                int roowIndex = 1;
                //数据添加
                foreach (DataGridViewRow Row in Dgv.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    int m = 0;//Dgv中的隐藏列的个数
                    if (Convert.ToBoolean(Row.Cells[DgvColTxtChk.Name].Value))
                    {
                        for (int i = 0; i < Dgv.ColumnCount; i++)
                        {
                            if (Dgv[i, 0].Visible)
                            {
                                if (Dgv[i, 0].GetType().Name == "DataGridViewCheckBoxCell")
                                {
                                    m = m + 1;
                                    continue;
                                }
                                //if (Dgv[i, 0].GetType().Name == "DataGridViewComboBoxCell")
                                //{
                                //    m = m + 1;
                                //    continue;
                                //}
                                if (Dgv[i, 0].GetType().Name == "DataGridViewImageCell")
                                {
                                    m = m + 1;
                                    continue;
                                }
                                if (Dgv[i, 0].GetType().Name == "DataGridViewButtonCell")
                                {
                                    m = m + 1;
                                    continue;
                                }
                                if (Dgv[i, 0].GetType().Name == "DataGridViewLinkCell")
                                {
                                    m = m + 1;
                                    continue;
                                }
                                if (Dgv[i, 0].GetType().Name == "DataGridViewMaskedTextBoxCell")
                                {
                                    m = m + 1;
                                    continue;
                                }
                                //判断是否有数字格式的列
                                //if (LstCellIndex.Contains(i - m))
                                //if()
                                //{
                                //    hssfrow.CreateCell(i - m).SetCellValue(Convert.ToDouble(Row.Cells[i].Value));
                                //    hssfrow.Cells[i - m].CellStyle = cellStyle;
                                //}
                                //else
                                if (Dgv[i, 0].GetType().Name == "DataGridViewComboBoxCell")
                                {
                                    string ycxx = Row.Cells[i].EditedFormattedValue.ToString();
                                    //string ycxx = Row.Cells[i].FormattedValue.ToString(); 
                                    hssfrow.CreateCell(i - m).SetCellValue(ycxx);
                                }
                                else
                                {
                                    if (LstCellIndex.Contains(i))
                                    {
                                        double j;
                                        if (double.TryParse(Convert.ToString(Row.Cells[i].Value), out j))
                                        {
                                            hssfrow.CreateCell(i - m).SetCellValue(Convert.ToDouble(Row.Cells[i].Value));
                                            hssfrow.Cells[i - m].CellStyle = cellStyle;
                                        }
                                        else
                                        {
                                            hssfrow.CreateCell(i - m).SetCellValue(Convert.ToString(Row.Cells[i].Value));
                                        }
                                    }
                                    else
                                        hssfrow.CreateCell(i - m).SetCellValue(Convert.ToString(Row.Cells[i].Value));

                                }

                            }
                            else
                                m = m + 1;
                        }
                        roowIndex++;
                    }

                }
                //if (roowIndex == 1)
                //{
                //    ClsMsgBox.Ts("请选择要导出的信息！", ObjG.CustomMsgBox, this);
                //    return;
                //}
                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
                //DownLoad.download(PriFlp, true);
                this.ctrlDownLoad1.download(PriFlp, true);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("导出Excel失败", ex);
            }
        }
        #endregion
        #region  更新通知记录
        private void Dgv_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (!flag)
                return;
            Dgv.EndEdit();
            DataRow dr = ((DataRowView)Dgv.CurrentRow.DataBoundItem).Row as DataRow;
            dr.EndEdit();
            if (Priffzt == "发放异常")
            {
                if (dr.RowState == DataRowState.Modified)
                {
                    try
                    {
                        ClsRWMSSQLDb.ExecuteCmd("Update tfmsdskffyc set tzjl='" + PriDt.Rows[0]["tzjl"] + "' where id=" + PriDt.Rows[0]["id"], ClsGlobals.CntStrTMS);
                    }
                    catch (Exception ex)
                    {
                        ClsMsgBox.Cw("记录通知失败！", ex, ObjG.CustomMsgBox, this);
                    }
                }
            }

        }
        private void Dgv_LostFocus(object sender, EventArgs e)
        {
            flag = false;
            if (Dgv.Rows.Count <= 0)
                return;
            Dgv.EndEdit();
            DataRow dr = ((DataRowView)Dgv.CurrentRow.DataBoundItem).Row as DataRow;
            dr.EndEdit();
            if (Priffzt == "发放异常")
            {
                if (dr.RowState == DataRowState.Modified)
                {
                    try
                    {
                        ClsRWMSSQLDb.ExecuteCmd("Update tfmsdskffyc set tzjl='" + PriDt.Rows[0]["tzjl"] + "' where id=" + PriDt.Rows[0]["id"], ClsGlobals.CntStrTMS);
                    }
                    catch (Exception ex)
                    {
                        ClsMsgBox.Cw("记录通知失败！", ex, ObjG.CustomMsgBox, this);
                    }
                }
            }
        }
        private void Dgv_GotFocus(object sender, EventArgs e)
        {
            flag = true;
        }
        #endregion

        //private void Delete(object sender, EventArgs e)
        //{
        //    Form f = sender as Form;
        //    FrmMsgBox frm = new FrmMsgBox();
        //    if (f.DialogResult == DialogResult.Yes)
        //    {
        //        LstId.Clear();
        //        LstNotDel.Clear();
        //        foreach (DataGridViewRow row in Dgv.Rows)
        //        {
        //            if (Convert.ToBoolean(row.Cells[DgvColTxtChk.Name].Value) && Convert.ToString(row.Cells[DgvColTxtLx1.Name].Value) == "2")
        //                LstId.Add(Convert.ToInt32(row.Cells[DgvColTxtId.Name].Value));
        //            else if (Convert.ToBoolean(row.Cells[DgvColTxtChk.Name].Value) && Convert.ToString(row.Cells[DgvColTxtLx1.Name].Value) == "1")
        //                LstNotDel.Add(Convert.ToInt32(row.Cells[DgvColTxtId.Name].Value));
        //        }
        //        if (LstId.Count > 0)
        //            ClsRWMSSQLDb.ExecuteCmd("delete tfmsdskffyc where id in(" + string.Join(",", LstId) + ")", ClsGlobals.CntStrTMS);
        //        PriDt = ClsRWMSSQLDb.GetDataTable("select *,'删除' as cz from Vfmswyffyccl1 " + PriWhere, ClsGlobals.CntStrTMS);
        //        Dgv.DataSource = PriDt;
        //        if (LstId.Count > 0 && LstNotDel.Count > 0)
        //            ClsMsgBox.Ts("删除成功，但存在部分无法删除的运单！", frm, this);
        //        else if (LstId.Count > 0 && LstNotDel.Count == 0)
        //            ClsMsgBox.Ts("删除成功！", frm, this);
        //        else if (LstId.Count == 0 && LstNotDel.Count > 0)
        //            ClsMsgBox.Ts("选中运单无法删除！", frm, this);
        //        else
        //            ClsMsgBox.Ts("无删除运单信息！", frm, this);
        //        Clear();
        //    }
        //}
    }
}