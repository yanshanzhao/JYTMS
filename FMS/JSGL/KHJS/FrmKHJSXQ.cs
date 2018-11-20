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
using JY.Pri;
using JY.Pub;
using System.Collections;
using System.Data.SqlClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Configuration;
#endregion

namespace FMS.JSGL.KHJS
{
    public partial class FrmKHJSXQ : Form
    {
        #region ��Ա����
        private int PriPcId = 0;
        private int PriCnts = 0;
        private ClsG ObjG;
        #endregion
        public FrmKHJSXQ()
        {
            InitializeComponent();
        }
        public void Prepare(int aId)
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            DataRow dr = ClsRWMSSQLDb.GetDataRow("select dzdh,Y,M,zdjgmc,ywqy,khmc,ST,et,je,zdjg,insczyxm,inssj,jyje,bz,jsjgmc,jsje,jslx,jsczyxm,jkbz,jssj from Vfmskhjspc where id=" + aId, ClsGlobals.CntStrTMS);
            lblZddh.Text = dr[0].ToString();
            LblNd.Text = dr[1].ToString();
            LblYd.Text = dr[2].ToString();
            LblDzjg.Text = dr[3].ToString();
            LblYwqy.Text = dr[4].ToString();
            LblKhmc.Text = dr[5].ToString();
            LblDzqssj.Text = Convert.ToDateTime(dr[6].ToString()).ToString("yyyy-MM-dd");
            LblDzjssj.Text = Convert.ToDateTime(dr[7].ToString()).ToString("yyyy-MM-dd");
            LblDzje.Text = dr[8].ToString();
            LblZdjg.Text = dr[9].ToString();
            LblZdr.Text = dr[10].ToString();
            LblZsj.Text = Convert.ToDateTime(dr[11].ToString()).ToString("yyyy-MM-dd");
            LblYJje.Text = dr[12].ToString();
            LblBzxx.Text = dr[13].ToString();
            LblJsjg.Text = dr[14].ToString();
            Lbljsje.Text = dr[15].ToString();
            LblJslx.Text = dr[16].ToString();
            LblJsr.Text = dr[17].ToString();
            LblJkbz.Text = dr[18].ToString();
            if (!string.IsNullOrEmpty(dr[19].ToString()))
                LblJssj.Text = Convert.ToDateTime(dr[19].ToString()).ToString("yyyy-MM-dd");
            else
                LblJssj.Text = null;
            PriPcId = aId;
            int n;
            if (Int32.TryParse(dr[13].ToString(), out n))
                PriCnts = Convert.ToInt32(dr[13].ToString());
            this.VfmskhjsmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            VfmskhjsmxTableAdapter1.FillByWhere(DSKHJS1.Vfmskhjsmx, " where pcid=" + PriPcId);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            else
            {
                string PriFln = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
                string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
                HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
                //д������
                HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
                sheet1.DefaultColumnWidth = 17;
                sheet1.SetColumnWidth(1, 25 * 100);
                //д�����
                HSSFRow titRow = sheet1.CreateRow(0) as HSSFRow;
                HSSFCell titCell = titRow.CreateCell(0) as HSSFCell;
                titRow.Height = 30 * 20;
                titCell.SetCellValue("�ͻ����㵥��ϸ");
                //���ñ�����ʽ
                HSSFCellStyle style = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                //�����������
                style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//�м����
                //�����������ʽ
                HSSFFont font = hssfworkbook.CreateFont() as HSSFFont;
                font.FontName = "����";
                font.FontHeightInPoints = 14;
                font.Boldweight = 700;
                style.SetFont(font);
                titCell.CellStyle = style;
                //�ϲ�������
                sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 9));

                HSSFCellStyle styleCell = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                styleCell.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;
                HSSFRow timeRow1 = sheet1.CreateRow(1) as HSSFRow;
                HSSFCell timeCell = timeRow1.CreateCell(0) as HSSFCell;
                timeCell.SetCellValue("���ʵ���:");
                timeCell.CellStyle = styleCell;
                HSSFCell timeCell2 = timeRow1.CreateCell(1) as HSSFCell;
                timeCell2.SetCellValue(lblZddh.Text);

                HSSFCell timeCell3 = timeRow1.CreateCell(3) as HSSFCell;
                timeCell3.SetCellValue("���ʵ����:");
                timeCell3.CellStyle = styleCell;
                HSSFCell timeCell4 = timeRow1.CreateCell(4) as HSSFCell;
                timeCell4.SetCellValue(LblNd.Text);

                HSSFCell timeCell5 = timeRow1.CreateCell(6) as HSSFCell;
                timeCell5.SetCellValue("���ʵ��¶�:");
                timeCell5.CellStyle = styleCell;
                HSSFCell timeCell6 = timeRow1.CreateCell(7) as HSSFCell;
                timeCell6.SetCellValue(LblYd.Text);


                HSSFRow timeRow2 = sheet1.CreateRow(2) as HSSFRow;
                HSSFCell timeCell7 = timeRow2.CreateCell(0) as HSSFCell;
                timeCell7.SetCellValue("���ʻ���:");
                timeCell7.CellStyle = styleCell;
                HSSFCell timeCell8 = timeRow2.CreateCell(1) as HSSFCell;
                timeCell8.SetCellValue(LblDzjg.Text);

                HSSFCell timeCell9 = timeRow2.CreateCell(3) as HSSFCell;
                timeCell9.SetCellValue("ҵ������:");
                timeCell9.CellStyle = styleCell;
                HSSFCell timeCell10 = timeRow2.CreateCell(4) as HSSFCell;
                timeCell10.SetCellValue(LblYwqy.Text);

                HSSFCell timeCell11 = timeRow2.CreateCell(6) as HSSFCell;
                timeCell11.SetCellValue("�ͻ�����:");
                timeCell11.CellStyle = styleCell;
                HSSFCell timeCell12 = timeRow2.CreateCell(7) as HSSFCell;
                timeCell12.SetCellValue(LblKhmc.Text);



                HSSFRow timeRow3 = sheet1.CreateRow(3) as HSSFRow;
                HSSFCell timeCell13 = timeRow3.CreateCell(0) as HSSFCell;
                timeCell13.SetCellValue("���ʽ��:");
                timeCell13.CellStyle = styleCell;
                HSSFCell timeCell14 = timeRow3.CreateCell(1) as HSSFCell;
                timeCell14.SetCellValue(this.LblDzje.Text);

                HSSFCell timeCell15 = timeRow3.CreateCell(3) as HSSFCell;
                timeCell15.SetCellValue("������ʼʱ��:");
                timeCell15.CellStyle = styleCell;
                HSSFCell timeCell16 = timeRow3.CreateCell(4) as HSSFCell;
                timeCell16.SetCellValue(LblDzqssj.Text);

                HSSFCell timeCell17 = timeRow3.CreateCell(6) as HSSFCell;
                timeCell17.SetCellValue("���ʽ���ʱ��:");
                timeCell17.CellStyle = styleCell;
                HSSFCell timeCell18 = timeRow3.CreateCell(7) as HSSFCell;
                timeCell18.SetCellValue(LblDzjssj.Text);



                HSSFRow timeRow4 = sheet1.CreateRow(4) as HSSFRow;
                HSSFCell timeCell119 = timeRow4.CreateCell(0) as HSSFCell;
                timeCell119.SetCellValue("�Ƶ�����:");
                timeCell119.CellStyle = styleCell;
                HSSFCell timeCell20 = timeRow4.CreateCell(1) as HSSFCell;
                timeCell20.SetCellValue(this.LblZdjg.Text);

                HSSFCell timeCell21 = timeRow4.CreateCell(3) as HSSFCell;
                timeCell21.SetCellValue("�Ƶ���:");
                timeCell21.CellStyle = styleCell;
                HSSFCell timeCell22 = timeRow4.CreateCell(4) as HSSFCell;
                timeCell22.SetCellValue(LblZdr.Text);

                HSSFCell timeCell23 = timeRow4.CreateCell(6) as HSSFCell;
                timeCell23.SetCellValue("�Ƶ�����:");
                timeCell23.CellStyle = styleCell;
                HSSFCell timeCell24 = timeRow4.CreateCell(7) as HSSFCell;
                timeCell24.SetCellValue(LblZsj.Text);

                HSSFRow timeRow5 = sheet1.CreateRow(5) as HSSFRow;
                HSSFCell timeCell125 = timeRow5.CreateCell(0) as HSSFCell;
                timeCell125.SetCellValue("��ע:");
                timeCell125.CellStyle = styleCell;
                HSSFCell timeCell26 = timeRow5.CreateCell(1) as HSSFCell;
                timeCell26.SetCellValue(this.LblBzxx.Text);

                sheet1.AddMergedRegion(new CellRangeAddress(1, 1, 1, 2));
                sheet1.AddMergedRegion(new CellRangeAddress(1, 1, 4, 5));
                sheet1.AddMergedRegion(new CellRangeAddress(1, 1, 7, 8));
                sheet1.AddMergedRegion(new CellRangeAddress(2, 2, 1, 2));
                sheet1.AddMergedRegion(new CellRangeAddress(2, 2, 4, 5));
                sheet1.AddMergedRegion(new CellRangeAddress(2, 2, 7, 8));
                sheet1.AddMergedRegion(new CellRangeAddress(3, 3, 1, 2));
                sheet1.AddMergedRegion(new CellRangeAddress(3, 3, 4, 5));
                sheet1.AddMergedRegion(new CellRangeAddress(3, 3, 7, 8));
                sheet1.AddMergedRegion(new CellRangeAddress(4, 4, 1, 2));
                sheet1.AddMergedRegion(new CellRangeAddress(4, 4, 4, 5));
                sheet1.AddMergedRegion(new CellRangeAddress(4, 4, 7, 8));
                sheet1.AddMergedRegion(new CellRangeAddress(5, 5, 1, 8));
                ///���õ�Ԫ����ʽ(����������ʾ����)
                HSSFCellStyle cellStyleC = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
                cellStyleC.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
                HSSFFont font1 = hssfworkbook.CreateFont() as HSSFFont;
                font1.FontHeightInPoints = 10;
                font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                cellStyleC.SetFont(font1);
                try
                {
                    //�����ĵ�����
                    HSSFRow row0 = (HSSFRow)sheet1.CreateRow(6);
                    HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    styleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    for (int i = 0; i < Dgv.ColumnCount; i++)
                    {
                        row0.CreateCell(i).SetCellValue(Dgv.Columns[i].HeaderText);
                        row0.Cells[i].CellStyle = styleRow;
                    }
                    int roowIndex = 7;
                    //�������
                    HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                    cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    HSSFCellStyle cellStyleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    cellStyleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    foreach (DataGridViewRow Row in Dgv.Rows)
                    {
                        HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                        for (int i = 0; i < Dgv.ColumnCount; i++)
                        {
                            if (i >= 5 && i <= 8)
                            {
                                if (i == 5)
                                {
                                    double n;
                                    double m = 0;
                                    if (double.TryParse(Row.Cells[i].Value.ToString(), out n))
                                        m = Convert.ToDouble(Row.Cells[i].Value);
                                    hssfrow.CreateCell(i).SetCellValue(m);
                                    hssfrow.Cells[i].CellStyle = cellStyle;
                                }
                                else
                                {
                                    DateTime n;
                                    if (DateTime.TryParse(Row.Cells[i].Value.ToString(), out n))
                                    {
                                        hssfrow.CreateCell(i).SetCellValue(Convert.ToDateTime(Row.Cells[i].Value.ToString()).ToString("yyyy - MM - dd"));
                                        hssfrow.Cells[i].CellStyle = cellStyleRow;
                                    }
                                    else
                                    {
                                        hssfrow.CreateCell(i).SetCellValue("");
                                    }
                                }
                            }
                            else
                            {
                                hssfrow.CreateCell(i).SetCellValue(Row.Cells[i].Value.ToString());
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
                    ClsMsgBox.Cw("�����ͻ�������Ϣ����ʧ��", ex);
                }
            }


        }
        #endregion
    }
}