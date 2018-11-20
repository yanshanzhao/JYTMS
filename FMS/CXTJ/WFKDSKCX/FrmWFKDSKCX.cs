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
using FMS.SeleFrm;
using System.Data.SqlClient;
using System.Collections;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.Util;
using System.Configuration;
using System.Web;
#endregion

namespace FMS.CXTJ.WFKDSKCX
{
    public partial class FrmWFKDSKCX : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private int PriJgid = 0;
        private string PriJgmc = "";
        private int PriLevel = 0;
        private DateTime PriStop = DateTime.Now;
        private int PriDays = 0;
        private int PriLx1 = 0;
        private int PriLx2 = 0;
        private string PriLx = "";
        private string PriCplx = "";
        private string PriCplxStr = "";
        #endregion
        public FrmWFKDSKCX()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriJgid = ObjG.Jigou.id;
            PriLevel = ObjG.Jigou.level;
            CmbQsfs.SelectedIndex = 2;
            ClsPopulateCmbDsS.PopuFmsDskffsj(CmbCplx);
            CmbCplx.SelectedIndex = 0;
            this.TxtCkjg.Text = ObjG.Jigou.mc;
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
                this.TxtCkjg.Text = f.PubDictAttrs["mc"];
                PriJgid = Convert.ToInt32(f.PubDictAttrs["id"]);
                PriJgmc = this.TxtCkjg.Text;
                PriLevel = Convert.ToInt32(f.PubDictAttrs["Level"]);
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtCkjg.Text = PriJgmc = "";
                PriJgid = PriLevel = 0;
            }
        }
        #endregion
        #region 查询
        private void BtnSearch_Click(object sender, EventArgs e)
        {

            PriStop = DtpStart.Value.Date;
            PriDays = PriStop.Date.Subtract(DateTime.Now.Date).Days;
            PriLx = CmbQsfs.Text;
            PriLx1 = CmbQsfs.SelectedIndex + 1;
            PriLx2 = PriLx1;
            PriCplx = "QB";
            if (CmbCplx.SelectedIndex > 0)
            {
                PriCplx = CmbCplx.SelectedValue.ToString();
                PriCplxStr = CmbCplx.Text;
            }
            //Dgv.Columns.Clear();
            //Dgv.DataSource = null;
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                conn.Open();
                DataTable dt = new DataTable();
                ArrayList als = new ArrayList();
                als.Add(new SqlParameter("@jgid", PriJgid));
                //als.Add(new SqlParameter("@level", PriLevel));
                als.Add(new SqlParameter("@lx", PriLx1));
                als.Add(new SqlParameter("@sj", PriStop.Date));
                als.Add(new SqlParameter("@cplx", PriCplx));
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = PriLevel < 3 ? "P_dskwfkcx" : "P_dskwfkcx2";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(als.ToArray(typeof(SqlParameter)));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["jgmc"] = "合计";
                        dr["yqts0"] = dt.Compute("sum(yqts0)", "").ToString();
                        dr["yqts1"] = dt.Compute("sum(yqts1)", "").ToString();
                        dr["yqts2"] = dt.Compute("sum(yqts2)", "").ToString();
                        dr["yqts3"] = dt.Compute("sum(yqts3)", "").ToString();
                        dr["yqts4"] = dt.Compute("sum(yqts4)", "").ToString();
                        dr["zj"] = dt.Compute("sum(zj)", "").ToString();
                        dr["level"] = 3;
                        dr["jgid"] = PriJgid;
                        dt.Rows.Add(dr);
                    }
                    else
                        ClsMsgBox.Ts("根据条件未查询到信息");
                    Dgv.DataSource = dt;
                }
                conn.Close();
            }
        }
        #endregion

        #region 明细导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            string SQLstr = " SELECT dqmc, bh, sljgmc, slsj, qsd, mdd, qsjgmc, fhf, shlxr, ddsj,(case when (yqts+" + PriDays + ")<=1 then 0 else (yqts+" + PriDays + "-1) end) as yqts, lx, dsk,cplx,fkfs,sjzt,sjsj,mc,zhmc,zh FROM dbo.Vfmswfkdskcx where yqts+ " + PriDays + " >=0 and jgid in (select id from jyjckj.dbo.tjigou WHERE parentLst LIKE '%," + PriJgid + ",%')";
            if (PriLx.CompareTo("全部") > 0)
            {
                if (PriLx2 == 1)
                    SQLstr = SQLstr + " and lx='转单' ";
                else
                    SQLstr = SQLstr + " and lx='非转单' ";
            }
            if( PriCplx != "QB")
                SQLstr = SQLstr + " and cplx='" + PriCplxStr + "'";
            //if (CmbCplx.SelectedIndex > 0)
            //    SQLstr = SQLstr + " and cplx='" + CmbCplx.Text + "'";
            DataTable dt = ClsRWMSSQLDb.GetDataTable(SQLstr, ClsGlobals.CntStrTMS);
            if (dt.Rows.Count == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            try
            {
                string PriFln = "未返款代收款明细" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
                string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
                HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
                //写入数据
                HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
                sheet1.DefaultColumnWidth = 17;
                sheet1.SetColumnWidth(1, 25 * 100);
                //写入标题
                HSSFRow titRow = sheet1.CreateRow(0) as HSSFRow;
                //HSSFCell titCell = titRow.CreateCell(0) as HSSFCell;
                //titRow.Height = 30 * 20;
                //titCell.SetCellValue("代收款应存明细运单明细");
                //设置标题样式
                HSSFCellStyle style = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                //对其相关设置
                style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//中间对齐
                //设置字体的样式
                HSSFFont font = hssfworkbook.CreateFont() as HSSFFont;
                font.FontName = "宋体";
                font.FontHeightInPoints = 14;
                font.Boldweight = 700;
                style.SetFont(font);
                //titCell.CellStyle = style;
                //合并标题行
                //sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 6));
                ///设置单元格样式(数量居中显示粗体)
                HSSFCellStyle cellStyleC = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
                cellStyleC.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
                HSSFFont font1 = hssfworkbook.CreateFont() as HSSFFont;
                font1.FontHeightInPoints = 10;
                font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                cellStyleC.SetFont(font1);

                //行名的的设置
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                LieFont.FontHeightInPoints = 10;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                styleRow.SetFont(LieFont);
                row0.CreateCell(0).SetCellValue("所属大区");
                row0.Cells[0].CellStyle = styleRow;
                row0.CreateCell(1).SetCellValue("货运单号");
                row0.Cells[1].CellStyle = styleRow;
                row0.CreateCell(2).SetCellValue("受理机构");
                row0.Cells[2].CellStyle = styleRow;
                row0.CreateCell(3).SetCellValue("受理时间");
                row0.Cells[3].CellStyle = styleRow;
                row0.CreateCell(4).SetCellValue("起始地");
                row0.Cells[4].CellStyle = styleRow;
                row0.CreateCell(5).SetCellValue("目的地");
                row0.Cells[5].CellStyle = styleRow;
                row0.CreateCell(6).SetCellValue("签收机构");
                row0.Cells[6].CellStyle = styleRow;
                row0.CreateCell(7).SetCellValue("发货方");
                row0.Cells[7].CellStyle = styleRow;
                row0.CreateCell(8).SetCellValue("收货方");
                row0.Cells[8].CellStyle = styleRow;
                row0.CreateCell(9).SetCellValue("到达时间");
                row0.Cells[9].CellStyle = styleRow;
                row0.CreateCell(10).SetCellValue("逾期天数");
                row0.Cells[10].CellStyle = styleRow;
                row0.CreateCell(11).SetCellValue("类别");
                row0.Cells[11].CellStyle = styleRow;
                row0.CreateCell(12).SetCellValue("代收款");
                row0.Cells[12].CellStyle = styleRow;
                row0.CreateCell(13).SetCellValue("产品类型");
                row0.Cells[13].CellStyle = styleRow;
                row0.CreateCell(14).SetCellValue("付款方式");
                row0.Cells[14].CellStyle = styleRow;
                row0.CreateCell(15).SetCellValue("上缴状态");
                row0.Cells[15].CellStyle = styleRow;
                row0.CreateCell(16).SetCellValue("上缴时间");
                row0.Cells[16].CellStyle = styleRow;
                row0.CreateCell(17).SetCellValue("机构开户行");
                row0.Cells[17].CellStyle = styleRow;
                row0.CreateCell(18).SetCellValue("户名");
                row0.Cells[18].CellStyle = styleRow;
                row0.CreateCell(19).SetCellValue("账号");
                row0.Cells[19].CellStyle = styleRow;
                int roowIndex = 1;
                //数据添加
                HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                HSSFCellStyle cellStyleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                for (int m = 0; m < dt.Rows.Count; m++)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    for (int i = 0; i < 19; i++)
                    {
                        if (i == 10)
                        {
                            int n;
                            if (Int32.TryParse(Convert.ToString(dt.Rows[m][i]), out  n))
                            {
                                hssfrow.CreateCell(i).SetCellValue(Convert.ToInt32(dt.Rows[m][i].ToString()));
                            }
                            else
                            {
                                hssfrow.CreateCell(i).SetCellValue(dt.Rows[m][i].ToString());
                                hssfrow.Cells[i].CellStyle = cellStyleRow;
                            }
                        }
                        else if (i == 12)
                        {
                            double n;
                            if (double.TryParse(Convert.ToString(dt.Rows[m][i]), out  n))
                            {
                                hssfrow.CreateCell(i).SetCellValue(Convert.ToDouble(dt.Rows[m][i].ToString()));
                                hssfrow.Cells[i].CellStyle = cellStyle;
                            }
                            else
                            {
                                hssfrow.CreateCell(i).SetCellValue(dt.Rows[m][i].ToString());
                                hssfrow.Cells[i].CellStyle = cellStyleRow;
                            }
                        }
                        else
                        {
                            hssfrow.CreateCell(i).SetCellValue(dt.Rows[m][i].ToString());
                            hssfrow.Cells[i].CellStyle = cellStyleRow;
                        }
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
                ClsMsgBox.Cw("未返款代收款明细导出明细报表失败", ex);
            }
        }
        #endregion

        private void BtnExlym_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("没有需要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] RowIndex = { 1, 2, 3, 4, 5, 6 };
            ClsExcel.CreatExcel(Dgv, "未返款代收款", ctrlDownLoad1, RowIndex, true);
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex != 6)
                return;
            //if (/*e.RowIndex != Dgv.RowCount - 1*/true)
            //{
            decimal zje = 0;
            if (!decimal.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtzj.Name].Value.ToString(), out zje))
            {
                ClsMsgBox.Ts("查询出现异常!", ObjG.CustomMsgBox, this);
                return;
            }
            else if (zje == 0)
            {
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int aJgId = 0;
            if (!Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgId.Name].Value.ToString(), out aJgId))
            {
                ClsMsgBox.Ts("查询出现异常!", ObjG.CustomMsgBox, this);
                return;
            }
            string ajgmc = Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgmc.Name].Value.ToString();
            if (PriLevel < 3)
            {
                FrmLSDWFKDSK f = new FrmLSDWFKDSK();
                f.ShowDialog();
                f.Prepare(ajgmc, aJgId, zje, PriLevel, PriLx1, PriStop,PriCplx, PriCplxStr);
            }
            else
            {
                FrmYDWFKDSK f = new FrmYDWFKDSK();
                f.ShowDialog();
                f.Prepare(ajgmc, aJgId, zje, PriDays, PriLx1, PriLx2, PriCplx, PriCplxStr);
            }

            //}
            //else
            //    {
            //    if (PriLevel < 3)
            //        {
            //        FrmLSDWFKDSK f = new FrmLSDWFKDSK();
            //        f.ShowDialog();
            //        f.Prepare(PriJgid, PriStop.Date, PriLx1);
            //        }
            //    else
            //        {
            //        List<int> Jgid = new List<int>();
            //        for (int i = 0; i < Dgv.RowCount - 1; i++)
            //            {
            //            int n;
            //            int aid = 0;
            //            if (Int32.TryParse(Dgv.Rows[i].Cells[DgvColTxtjgId.Name].Value.ToString(), out n))
            //                {
            //                aid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtjgId.Name].Value.ToString());
            //                Jgid.Add(aid);
            //                }
            //            }
            //        if (Jgid.Count > 0)
            //            {
            //            FrmYDWFKDSK f = new FrmYDWFKDSK();
            //            f.ShowDialog();
            //            f.Prepare(PriDays, PriJgid, Jgid, PriLx1, PriLx2);
            //            }
            //        }

            //    }
        }

        private void BtnExlMx_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    ArrayList als = new ArrayList();
                    als.Add(new SqlParameter("@jgid", PriJgid));
                    //als.Add(new SqlParameter("@level", PriLevel));
                    als.Add(new SqlParameter("@lx", PriLx1));
                    als.Add(new SqlParameter("@sj", PriStop.Date));
                    als.Add(new SqlParameter("@cplx", PriCplx));
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "P_dskwfkcx_dc";
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(als.ToArray(typeof(SqlParameter)));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                    conn.Close();
                    if (dt.Rows.Count > 60000)
                    {
                        ClsMsgBox.Ts("不允许导出超过60000条的数据");
                        return;
                    }
                    else
                    {
                        ClsExcel.CreatExcel_Data("未返款代收款_连锁店明细.xls", this.ctrlDownLoad1, dt, Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath + @"App_Data\ModelExcel", "Wfkdskcx.xls"), 1, new int[] { 2, 3, 4, 5, 6,7});
                    }
                }

            }
        }
    }
}
