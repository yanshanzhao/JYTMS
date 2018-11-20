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
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using NPOI.HSSF.UserModel;
using System.Reflection;
using NPOI.SS.Formula;
#endregion

namespace FMS.DSKGL.DSKJSD
{
    public partial class FrmDSKJSD : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private DateTime PriKssj;
        private DateTime PriJssj;
        #endregion
        public FrmDSKJSD()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
        }

        private void BtnElse_Click(object sender, EventArgs e)
        {
            PriKssj = DtpSj.Value.Date;
            PriJssj = PriKssj.AddDays(1).Date;
            string PriFln = "代收款结算单";//文件名称    
            PriFln = PriFln + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            string PriFlp = System.IO.Path.Combine(System.Configuration.ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
            //创建数据库连接对接对象
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TMSConnectionString"].ToString());
            //打开数据库连接
            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                com.CommandText = "P_dskjsd1";
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@kssj", PriKssj));
                com.Parameters.Add(new SqlParameter("@jssj", PriJssj));
                dataAdapter.Fill(ds);
                //模板路径
                string priModel = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath + @"App_Data\ModelExcel", "dskjsd.xls");
                //生成模板读取IO流
                FileStream fileStreamRead = new FileStream(priModel, FileMode.Open, FileAccess.Read);
                //创建工作簿XLS对象
                HSSFWorkbook hssfwork = new HSSFWorkbook(fileStreamRead);
                HSSFSheet hssfSheet = hssfwork.GetSheetAt(0) as HSSFSheet;
                HSSFRow hssfRow = hssfSheet.GetRow(1) as HSSFRow;
                HSSFCell hssfCell = hssfRow.GetCell(0) as HSSFCell;
                /*
                 代收货款发款
                 */
                hssfCell.SetCellValue("日期：" + DtpSj.Value.ToString("yyyy-MM-dd"));
                int RowIndex = 5;
                string[] yhmc = { "农业银行", "建设银行", "齐鲁银行", "其他银行" };
                for (int i = 0; i < yhmc.Length; i++)
                {
                    DataRow[] dr, dr1;
                    hssfRow = hssfSheet.GetRow(RowIndex) as HSSFRow;
                    if (yhmc[i] == "其他银行")
                    {
                        dr = ds.Tables[0].Select("jc not in ('农业银行','建设银行','齐鲁银行')");
                        dr1 = ds.Tables[1].Select("jc not in ('农业银行','建设银行','齐鲁银行')");
                    }
                    else
                    {
                        dr = ds.Tables[0].Select("jc ='" + yhmc[i].ToString() + "'");
                        dr1 = ds.Tables[1].Select("jc ='" + yhmc[i].ToString() + "'");
                    }

                    if (dr.Length > 0)
                    {
                        (hssfRow.GetCell(1) as HSSFCell).SetCellValue(Convert.ToDouble(dr[0].ItemArray[1]));
                        (hssfRow.GetCell(2) as HSSFCell).SetCellValue(Convert.ToDouble(dr[0].ItemArray[2]));
                        (hssfRow.GetCell(3) as HSSFCell).SetCellValue(Convert.ToDouble(dr[0].ItemArray[3]));
                    }
                    if (dr1.Length > 0)
                    {
                        (hssfRow.GetCell(4) as HSSFCell).SetCellValue(Convert.ToDouble(dr1[0].ItemArray[0]));
                    }
                    hssfRow.GetCell(6).CellFormula = string.Format("E{0}-B{0}", RowIndex + 1);
                    RowIndex++;
                }
                //设置最后一行合计
                hssfRow = hssfSheet.GetRow(RowIndex) as HSSFRow;
                hssfRow.GetCell(1).CellFormula = "SUM(B5:B9)";
                hssfRow.GetCell(2).CellFormula = "SUM(C5:C9)";
                hssfRow.GetCell(3).CellFormula = "SUM(D5:D9)";
                hssfRow.GetCell(4).CellFormula = "SUM(E5:F9)";
                hssfRow.GetCell(6).CellFormula = "SUM(G5:H9)";
                /*
                 银行压款明细
                 */
                RowIndex = 12;
                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[2].Rows[i];
                    hssfRow = hssfSheet.GetRow(RowIndex) as HSSFRow;
                    (hssfRow.GetCell(1) as HSSFCell).SetCellValue(string.IsNullOrEmpty(dr.ItemArray[1].ToString()) ? 0 : Convert.ToDouble(dr.ItemArray[1]));
                    (hssfRow.GetCell(3) as HSSFCell).SetCellValue(string.IsNullOrEmpty(dr.ItemArray[2].ToString()) ? 0 : Convert.ToDouble(dr.ItemArray[2]));
                    (hssfRow.GetCell(6) as HSSFCell).SetCellValue(string.IsNullOrEmpty(dr.ItemArray[3].ToString()) ? 0 : Convert.ToDouble(dr.ItemArray[3]));
                    (hssfRow.GetCell(7) as HSSFCell).SetCellValue(string.IsNullOrEmpty(dr.ItemArray[4].ToString()) ? 0 : Convert.ToDouble(dr.ItemArray[4]));
                    RowIndex++;
                }
                /*
                    资金调拨
                 */
                string[] yhmc1 = { "农业银行", "建设银行", "工商银行", "齐鲁银行", "中信银行" };
                RowIndex = 16;
                for (int i = 0; i < yhmc1.Length; i++)
                {
                    hssfRow = hssfSheet.GetRow(RowIndex) as HSSFRow;
                    DataRow[] dr = ds.Tables[3].Select("dcyh ='" + yhmc1[i].ToString() + "'");
                    if (dr.Length > 0)
                    {
                        (hssfRow.GetCell(3) as HSSFCell).SetCellValue(Convert.ToDouble(dr[0].ItemArray[1]));
                    }
                    else
                    {
                        (hssfRow.GetCell(3) as HSSFCell).SetCellValue(0.0);
                    }
                    DataRow[] dr1 = ds.Tables[4].Select("dryh ='" + yhmc1[i].ToString() + "'");
                    if (dr1.Length > 0)
                    {
                        (hssfRow.GetCell(7) as HSSFCell).SetCellValue(Convert.ToDouble(dr1[0].ItemArray[1]));
                    }
                    else
                    {
                        (hssfRow.GetCell(7) as HSSFCell).SetCellValue(0.0);
                    }
                    RowIndex++;
                }
                hssfRow = hssfSheet.GetRow(RowIndex) as HSSFRow;
                hssfRow.GetCell(3).CellFormula = "SUM(D17:E21)";
                hssfRow.GetCell(7).CellFormula = "SUM(H17:H21)";
                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfwork.Write(file);
                file.Close();
                ctrlDownLoad1.download(PriFlp, true);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Ts("遇到错误！" + ex.ToString(), ObjG.CustomMsgBox, this);
                return;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}