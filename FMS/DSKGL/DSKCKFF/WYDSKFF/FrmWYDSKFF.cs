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
using System.IO;
using NPOI.HSSF.UserModel;
using JYPubFiles.Classes;
using System.Configuration;

#endregion

namespace FMS.DSKGL.DSKCKFF.WYDSKFF
{
    public partial class FrmWYDSKFF : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private string PriWhere;
        private string PriYhzh;
        FrmWYDSKFFMX f;
        private DataGridViewCellEventArgs args;
        private FrmMsgBox CusMsgBox = new FrmMsgBox();
        private EnumNEDD PriEnumNEDD = EnumNEDD.New;
        #endregion
        public FrmWYDSKFF()
        {
            InitializeComponent();
        }
        #region 初始化数据
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            VfmswydskffTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            Vfmswydskffmx_zxhwTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            //DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable(" select 0 as id,'--全部--' as jc union all select id,jc from tyhlx where  hdzt='Y' and id in(63,64,241)  ", ClsGlobals.CntStrTMS);
            //ClsPopulateCmbDsS.PopuByTb(this.CmbYhlx, dtYhlx, "id", "jc");
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable("select 'all' as bh,'--全部--' as mc union all select bh,mc from Tfmsdskffyhlx where zt=1  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbYhlx, dtYhlx, "bh", "mc");
            DataTable DtDcfs = ClsRWMSSQLDb.GetDataTable("select 'default' as bh,'--默认--' as mc union all select bh,mc from Tfmsdskffyhlx where zt=1  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbDcgs, DtDcfs, "bh", "mc");
            CmbYhlx.SelectedIndex = 0;
            CmbZt.SelectedIndex = 0;
            CmbDcgs.SelectedIndex = 0;
            DtpFfStart.Value = DtpFfStart.Value.AddDays(-1);
            DtpFfStart.Checked = false;
            BtnSearch.PerformClick();
        }
        #endregion

        private void SetXh()
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                row.Cells[DgvColTxtXh.Name].Value = row.Index + 1;
            }
        }
        #region 查询
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                PriWhere = "  ";
                //PriWhere += Convert.ToInt32(CmbYhlx.SelectedValue) == 0 ? "" : Convert.ToInt32(CmbYhlx.SelectedValue) == 64 ? " and yhlxid not in(63,241) " : " and yhlxid =" + CmbYhlx.SelectedValue;
                PriWhere += CmbYhlx.SelectedValue.Equals("all") ? "" : " and ffyhlx ='" + CmbYhlx.SelectedValue + "'";
                PriWhere += Convert.ToInt32(CmbZt.SelectedIndex) == 0 ? " and zt=0 " : Convert.ToInt32(CmbZt.SelectedIndex) == 1 ? " and zt=10" : "";
                //PriWhere += " and ffsj between '" + DtpFfStart.Value + "' and dateadd(dd,1,'" + DtpFfStop.Value + "')";
                if (DtpFfStart.Checked)
                    PriWhere += " and ffsj>='" + DtpFfStart.Value.Date + "'";
                if (DtpFfStop.Checked)
                    PriWhere += " and ffsj<'" + DtpFfStop.Value.AddDays(1).Date + "'";
                PriWhere += DtpDkStart.Checked ? " and dksj>='" + DtpDkStart.Value.Date + "'" : "";
                PriWhere += DtpDkStop.Checked ? " and dksj<'" + DtpDkStop.Value.Date.AddDays(1) + "'" : "";
                PriWhere = PriWhere.Trim();
                if (PriWhere.Length > 0)
                    PriWhere = " where " + PriWhere.Remove(0, 3);
                VfmswydskffTableAdapter1.FillByWhere(DSwydskff1.Vfmswydskff, PriWhere);
                SetXh();
                if (PriEnumNEDD == EnumNEDD.New)
                {
                    PriEnumNEDD = EnumNEDD.Edit;
                    return;
                }
                if (Bds.Count == 0)
                    ClsMsgBox.Ts("没有查询到相应信息，请核对查询条件！", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("查询信息失败！", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion

        #region 单击事件
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("详细信息"))
            {
                f = new FrmWYDSKFFMX();
                f.Prepare(Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtId.Name].Value));
                f.ShowDialog();
            }
            if (Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("打款"))
            {
                args = e;
                DSWYDSKFF.VfmswydskffRow row = (Dgv.Rows[e.RowIndex].DataBoundItem as DataRowView
                    ).Row as DSWYDSKFF.VfmswydskffRow;
                if (row.IsffcsNull() == true || row.ffcs == 0)
                {
                    dk();
                }
                else
                    ClsMsgBox.DKYesNo(string.Format("第{0}次打款，确认要进行重复打款么？", row.ffcs + 1)
                      , new EventHandler(dk), CusMsgBox, this, 20);
            }
        }
        private void dk(object sender, EventArgs e)
        {
            FrmMsgBox f = sender as FrmMsgBox;
            if (f.DialogResult == DialogResult.Yes)
            {
                dk();
            }
        }
        private void dk()
        {
            ClsRWMSSQLDb.ExecuteCmd("update tfmsdskckffpc set ffcs=ffcs+1  where id=" + Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value, ClsGlobals.CntStrTMS);
            if (Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtZt.Name].Value) == 0)
            {
                try
                {
                    ClsRWMSSQLDb.ExecuteCmd("update tfmsdskckffpc set zt=10,je=(SELECT CONVERT(DECIMAL(15,2),SUM(dsk-sxf)) FROM dbo.tfmsdskckffmx WHERE pcid=dbo.tfmsdskckffpc.id),ffsj=getdate(),jgid=" + ObjG.Jigou.id + ",ffsczyid=" + ObjG.Renyuan.id + ",ffsczyzh='" + ObjG.Renyuan.loginName + "',ffsczyxm='" + ObjG.Renyuan.xm + "' where id=" + Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value + ";update tfmsdskckffmx set zt=20 where pcid =" + Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value + ";update tfmsdsk set ffdskzt=30 where id in (select dskid from tfmsdskckffmx where pcid =" + Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value + ")", ClsGlobals.CntStrTMS);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("更新发放状态失败！", ex, ObjG.CustomMsgBox, this);
                    return;
                }
            }
            //if (Dgv.Rows[args.RowIndex].Cells[DgvColTxtYhlxid.Name].Value.ToString().Equals("241"))//农行
            //{
            if (CmbDcgs.SelectedValue.Equals("default"))
            {
                if (Dgv.Rows[args.RowIndex].Cells[DgvColTxtFfyhlx.Name].Value.Equals("nh"))
                    NH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
                else if (Dgv.Rows[args.RowIndex].Cells[DgvColTxtFfyhlx.Name].Value.Equals("jh"))
                    JH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
                else if (Dgv.Rows[args.RowIndex].Cells[DgvColTxtFfyhlx.Name].Value.Equals("qlhn"))
                    QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "N");
                else if (Dgv.Rows[args.RowIndex].Cells[DgvColTxtFfyhlx.Name].Value.Equals("qlhw"))
                    QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "W");
                else if (Dgv.Rows[args.RowIndex].Cells[DgvColTxtFfyhlx.Name].Value.Equals("zxhn"))
                    ZXHN(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
                else if (Dgv.Rows[args.RowIndex].Cells[DgvColTxtFfyhlx.Name].Value.Equals("zxhw"))
                    ZXHW(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            }
            else if (CmbDcgs.SelectedValue.Equals("nh"))
                NH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            else if (CmbDcgs.SelectedValue.Equals("jh"))
                JH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            else if (CmbDcgs.SelectedValue.Equals("qlhn"))
                QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "N");
            else if (CmbDcgs.SelectedValue.Equals("qlhw"))
                QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "W");
            else if (CmbDcgs.SelectedValue.Equals("zxhn"))
                ZXHN(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            else if (CmbDcgs.SelectedValue.Equals("zxhw"))
                ZXHW(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            //}
            //else if (Dgv.Rows[args.RowIndex].Cells[DgvColTxtYhlxid.Name].Value.ToString().Equals("63"))//建行
            //{
            //    if (CmbDcgs.Text == "默认" || CmbDcgs.Text == "建设银行")
            //        JH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            //    else if (CmbDcgs.Text == "农业银行")
            //        NH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            //    else if (CmbDcgs.Text == "齐鲁银行（网内）")
            //        QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "N");
            //    else if (CmbDcgs.Text == "齐鲁银行（网外）")
            //        QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "W");
            //}
            //else if (Dgv.Rows[args.RowIndex].Cells[DgvColTxtYhlxid.Name].Value.ToString().Equals("64") && Dgv.Rows[args.RowIndex].Cells[DgvColTxtFkfs.Name].Value.ToString().Equals("10"))
            //{
            //    if (CmbDcgs.Text == "默认" || CmbDcgs.Text == "齐鲁银行（网内）")
            //        QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "N");//齐鲁行内
            //    else if (CmbDcgs.Text == "建设银行")
            //        JH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            //    else if (CmbDcgs.Text == "农业银行")
            //        NH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            //    else if (CmbDcgs.Text == "齐鲁银行（网外）")
            //        QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "W");
            //}
            //else
            //{
            //    if (CmbDcgs.Text == "默认" || CmbDcgs.Text == "齐鲁银行（网外）")
            //        QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "W"); //齐鲁行外
            //    else if (CmbDcgs.Text == "建设银行")
            //        JH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            //    else if (CmbDcgs.Text == "农业银行")
            //        NH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            //    else if (CmbDcgs.Text == "齐鲁银行（网内）")
            //        QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "N");
            //}
            VfmswydskffTableAdapter1.FillByWhere(DSwydskff1.Vfmswydskff, PriWhere);
            SetXh();
        }
        #endregion

        #region 建行网银报表
        private void JH(int aPcid)
        {
            VfmswydskffmxTableAdapter1.FillByPcid(DSwydskff1.Vfmswydskffmx, aPcid);
            string PriFln = "总部建行代收款发放明细" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
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

                for (int i = 0; i < DSwydskff1.Vfmswydskffmx.Rows.Count; i++)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(i);
                    for (int m = 0; m < DSwydskff1.Vfmswydskffmx.Columns.Count; m++)
                    {
                        if (DSwydskff1.Vfmswydskffmx.Columns[m].ColumnName.ToString().Equals("sfje"))
                        {
                            hssfrow.CreateCell(2).SetCellValue(Convert.ToDouble(DSwydskff1.Vfmswydskffmx.Rows[i][m]));
                            hssfrow.Cells[2].CellStyle = cellStyle;
                        }
                        else if (DSwydskff1.Vfmswydskffmx.Columns[m].ColumnName.ToString().Equals("yhzh"))
                        {
                            hssfrow.CreateCell(0).SetCellValue(DSwydskff1.Vfmswydskffmx.Rows[i][m].ToString());
                        }
                        else if (DSwydskff1.Vfmswydskffmx.Columns[m].ColumnName.ToString().Equals("mc"))
                        {
                            hssfrow.CreateCell(1).SetCellValue(DSwydskff1.Vfmswydskffmx.Rows[i][m].ToString());
                        }
                    }
                }
                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
                this.ctrlDownLoad1.download(PriFlp, true);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("制作总部建行代收款发放网银Excel失败！", ex);
                return;
            }
            finally
            {
                VfmswydskffmxTableAdapter1.Dispose();
            }

        }
        #endregion

        #region 齐鲁银行网银报表
        private void QL(int aPcid, string aType)
        {
            PriYhzh = ClsRWMSSQLDb.GetStr("  select zh from tfmsyhzh  where zhlxid=60 and zt=0 and yhlxid=64 and jgid=" + ObjG.Jigou.id, ClsGlobals.CntStrTMS);
            VfmswydskffmxTableAdapter1.FillByPcid(DSwydskff1.Vfmswydskffmx, aPcid);

            string PriFln = "总部齐鲁银行网银报表" + (Convert.ToBoolean(aType.Equals("N")) ? "（行内）" : "(行外)") + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
            //写入数据
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.DefaultColumnWidth = 17;
            try
            {
                //行名的的设置
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                LieFont.FontHeightInPoints = 10;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.SetFont(LieFont);
                row0.CreateCell(0).SetCellValue("转账类型");
                row0.CreateCell(1).SetCellValue("付款账号");
                row0.CreateCell(2).SetCellValue("收款账号");
                row0.CreateCell(3).SetCellValue("收款账户名");
                row0.CreateCell(4).SetCellValue("交易金额");
                row0.CreateCell(5).SetCellValue("联行号");
                row0.CreateCell(6).SetCellValue("预约转账");
                row0.CreateCell(7).SetCellValue("预约时间");
                row0.CreateCell(8).SetCellValue("用途");
                int roowIndex = 1;
                //数据添加
                foreach (DSWYDSKFF.VfmswydskffmxRow Row in DSwydskff1.Vfmswydskffmx.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    if (aType == "N")
                        hssfrow.CreateCell(0).SetCellValue("行内");
                    else
                        hssfrow.CreateCell(0).SetCellValue("行外");
                    hssfrow.CreateCell(1).SetCellValue(PriYhzh);
                    for (int i = 0; i <= 3; i++)
                    {
                        if (i == 0)
                            hssfrow.CreateCell(2).SetCellValue(Convert.ToString(Row["yhzh"]));
                        else if (i == 1)
                            hssfrow.CreateCell(3).SetCellValue(Convert.ToString(Row["mc"]));
                        else if (i == 2)
                        {
                            hssfrow.CreateCell(4).SetCellValue(Convert.ToDouble(Row["sfje"]));
                            hssfrow.Cells[4].CellStyle = cellStyle;
                        }
                        else if (i == 3)
                            hssfrow.CreateCell(5).SetCellValue(Convert.ToString(Row["lhh"]));
                    }
                    hssfrow.CreateCell(8).SetCellValue("佳怡货款");
                    roowIndex++;
                }
                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
                this.ctrlDownLoad1.download(PriFlp, true);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("导出Excel失败", ex);
                return;
            }

        }
        #endregion

        #region 农行网银报表
        private void NH(int aPcid)
        {
            VfmswydskffmxTableAdapter1.FillByPcid(DSwydskff1.Vfmswydskffmx, aPcid);
            try
            {
                string PriFln = "行代收款发放" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";//文件名称     
                string path = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
                int PriNo = 1;
                FileStream fs1 = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs1, Encoding.UTF8);
                string str = "";
                for (int i = 0; i < DSwydskff1.Vfmswydskffmx.Rows.Count; i++)
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
                    string bh = "";
                    for (int j = 1; j < DSwydskff1.Vfmswydskffmx.Columns.Count; j++)
                    {
                        if (DSwydskff1.Vfmswydskffmx.Columns[j].ColumnName.ToString().Equals("yhzh") || DSwydskff1.Vfmswydskffmx.Columns[j].ColumnName.ToString().Equals("mc"))
                        {
                            str += DSwydskff1.Vfmswydskffmx.Rows[i][j].ToString();
                            str += ",";
                        }
                        if (DSwydskff1.Vfmswydskffmx.Columns[j].ColumnName.ToString().Equals("sfje"))
                        {
                            str += double.Parse(DSwydskff1.Vfmswydskffmx.Rows[i][j].ToString());
                            str += ",";
                        }
                        if (DSwydskff1.Vfmswydskffmx.Columns[j].ColumnName.ToString().Equals("bh"))
                        {
                            bh = DSwydskff1.Vfmswydskffmx.Rows[i][j].ToString();
                        }
                    }
                    str += "佳怡货款" + bh;
                    str += "\r\n";
                    PriNo++;

                }
                str = str.Substring(0, str.LastIndexOf("\r\n"));
                sw.WriteLine(str);//要写入的信息。 
                ctrlDownLoad1.download(path, true);
                sw.Close();
                fs1.Close();
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("导出信息失败", ex);
                return;
            }
            finally
            {
                VfmswydskffmxTableAdapter1.Dispose();
            }

        }
        #endregion

        #region 中信银行网银报表（行内）
        private void ZXHN(int aPcid)
        {
            VfmswydskffmxTableAdapter1.FillByPcid(DSwydskff1.Vfmswydskffmx, aPcid);

            string PriFln = "总部中信银行网银报表（行内）" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
            //写入数据
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.DefaultColumnWidth = 17;
            try
            {
                //行名的的设置
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                LieFont.FontHeightInPoints = 10;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.SetFont(LieFont);
                row0.CreateCell(0).SetCellValue("员工编号");
                row0.CreateCell(1).SetCellValue("员工账号");
                row0.CreateCell(2).SetCellValue("员工姓名");
                row0.CreateCell(3).SetCellValue("支付金额");
                row0.CreateCell(4).SetCellValue("币种");
                int roowIndex = 1;
                //数据添加
                foreach (DSWYDSKFF.VfmswydskffmxRow Row in DSwydskff1.Vfmswydskffmx.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    //设置员工编号
                    hssfrow.CreateCell(0).SetCellValue(roowIndex.ToString());
                    for (int i = 0; i <= 3; i++)
                    {
                        if (i == 0)
                            hssfrow.CreateCell(1).SetCellValue(Convert.ToString(Row["yhzh"]));
                        else if (i == 1)
                            hssfrow.CreateCell(2).SetCellValue(Convert.ToString(Row["mc"]));
                        else if (i == 2)
                        {
                            hssfrow.CreateCell(3).SetCellValue(Convert.ToDouble(Row["sfje"]));
                            hssfrow.Cells[3].CellStyle = cellStyle;
                        }
                        else if (i == 3)
                            hssfrow.CreateCell(4).SetCellValue("人民币");
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
                ClsMsgBox.Cw("导出Excel失败", ex);
                return;
            }

        }
        #endregion

        #region 中信银行网银报表（行外）
        private void ZXHW(int aPcid)
        {
            Vfmswydskffmx_zxhwTableAdapter1.FillByPcid(DSwydskff1.Vfmswydskffmx_zxhw, aPcid);
            string PriFln = "总部中信银行网银报表（行外）" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
            //写入数据
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.DefaultColumnWidth = 17;
            try
            {
                //行名的的设置
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                hssfworkbook.CreateDataFormat();
                LieFont.FontHeightInPoints = 10;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.SetFont(LieFont);
                row0.CreateCell(0).SetCellValue("序号");
                row0.CreateCell(1).SetCellValue("受理时间");
                row0.CreateCell(2).SetCellValue("受理大区");
                row0.CreateCell(3).SetCellValue("受理机构");
                row0.CreateCell(4).SetCellValue("到达大区");
                row0.CreateCell(5).SetCellValue("到达站");
                row0.CreateCell(6).SetCellValue("货运编号");
                row0.CreateCell(7).SetCellValue("服务卡号");
                row0.CreateCell(8).SetCellValue("持卡人");
                row0.CreateCell(9).SetCellValue("开户行");
                row0.CreateCell(10).SetCellValue("银行账号");
                row0.CreateCell(11).SetCellValue("支付方式");
                row0.CreateCell(12).SetCellValue("代收款金额");
                row0.CreateCell(13).SetCellValue("实发金额");
                row0.CreateCell(14).SetCellValue("手续费");
                row0.CreateCell(15).SetCellValue("系统发放日期");

                int roowIndex = 1;
                //数据添加
                foreach (DSWYDSKFF.Vfmswydskffmx_zxhwRow Row in DSwydskff1.Vfmswydskffmx_zxhw.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    //设置员工编号
                    hssfrow.CreateCell(0).SetCellValue(roowIndex.ToString());
                    hssfrow.CreateCell(1).SetCellValue(Convert.ToString(Row["slsj"]));
                    hssfrow.CreateCell(2).SetCellValue(Convert.ToString(Row["sldq"]));
                    hssfrow.CreateCell(3).SetCellValue(Convert.ToString(Row["sljg"]));
                    hssfrow.CreateCell(4).SetCellValue(Convert.ToString(Row["dddq"]));
                    hssfrow.CreateCell(5).SetCellValue(Convert.ToString(Row["ddz"]));
                    hssfrow.CreateCell(6).SetCellValue(Convert.ToString(Row["bh"]));
                    hssfrow.CreateCell(7).SetCellValue(Convert.ToString(Row["dskkhbh"]));
                    hssfrow.CreateCell(8).SetCellValue(Convert.ToString(Row["mc"]));

                    hssfrow.CreateCell(9).SetCellValue(Convert.ToString(Row["jc"]));
                    hssfrow.CreateCell(10).SetCellValue(Convert.ToString(Row["yhzh"]));
                    hssfrow.CreateCell(11).SetCellValue(Convert.ToString(Row["zffs"]));
                    hssfrow.CreateCell(12).SetCellValue(Convert.ToDouble(Row["zje"]));
                    hssfrow.Cells[12].CellStyle = cellStyle;
                    hssfrow.CreateCell(13).SetCellValue(Convert.ToDouble(Row["sfje"]));
                    hssfrow.Cells[13].CellStyle = cellStyle;
                    hssfrow.CreateCell(14).SetCellValue(Convert.ToDouble(Row["sxf"]));
                    hssfrow.Cells[14].CellStyle = cellStyle;
                    hssfrow.CreateCell(15).SetCellValue(Convert.ToString(Row["xtffsj"]));
                    roowIndex++;
                }
                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
                this.ctrlDownLoad1.download(PriFlp, true);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("导出Excel失败", ex);
                return;
            }

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
            int[] Rows = new int[] { 1, 2, 3, 4 };
            ClsExcel.CreatExcel(Dgv, "代收款网银发放", this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, "代收款网银发放", this.ctrlDownLoad1);
        }
        #endregion



    }
}





