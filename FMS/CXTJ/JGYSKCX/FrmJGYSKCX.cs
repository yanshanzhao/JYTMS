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
using FMS.SeleFrm;
using JY.Pub;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Configuration;

#endregion

namespace FMS.CXTJ.JGYSKCX
{
    public partial class FrmJGYSKCX : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private int PriJgid;
        private FrmSelectJg f;
        private FrmJGYSKCXMX frm;
        private string PriWhere;
        private string PriTime;

        #endregion

        public FrmJGYSKCX()
        {
            InitializeComponent();
        }
        #region ��ʼ������
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            //ClsPopulateCmbDsS.PopuYd_ywxz(CmbYwxz, ClsGlobals.CntStrKj);
        }
        #endregion
        #region ��ѯ
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LblCheckhj.Text = "Ӧ�ս��ϼƣ�0.00Ԫ";
            LblCheckbyhj.Text = "��ҳ�ϼƣ�0.00Ԫ";
            try
            {
                DataSet1.Tables[0].Clear();

                PriWhere = " where  jzsj >= '" + DtpStart.Value.Date + "' and jzsj<'" + DtpStop.Value.AddDays(1).Date + "'";
                PriTime = " and jzsj >= '" + DtpStart.Value.Date + "' and jzsj <'" + DtpStop.Value.AddDays(1).Date + "'";

                PriWhere += string.IsNullOrEmpty(TxtJgmc.Text) ? "" : " and jgid in(select id from jyjckj.dbo.tjigou where parentLst like '%," + PriJgid + ",%')";

                //if (CmbYwxz.SelectedIndex > 0)
                //    PriWhere += " and ywxz='" + CmbYwxz.SelectedValue.ToString() + "' ";

                ClsRWMSSQLDb.FillTable(DataSet1.Tables[0], "select dqmc,ywqy,jgmc,sum(ff) as ff,sum(hf) as hf,sum(tf) as tf, sum(zf) as zf,sum(bfff) as bfff,sum(bfhf) as bfhf,sum(bftf) as bftf,sum(bfzf) as bfzf,isnull(sum(zj),0) as zj,'��ϸ��Ϣ' as xx,jgid from vfmsjgyskcx   " + PriWhere + " group by dqmc,jgmc,jgid,ywqy", ClsGlobals.CntStrTMS);
                if (Dgv.RowCount > 0)
                {
                    LblCheckhj.Text = "Ӧ�ս��ϼƣ�" + DataSet1.Tables[0].AsEnumerable().Sum(r => Convert.ToDecimal(r["zj"])) + "Ԫ";
                    PageRows();
                }
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ��Ϣʧ��!", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion
        private void Dgv_PagingChanged(object sender, EventArgs e)
        {
            PageRows();
        }
        private void Dgv_Sorted(object sender, EventArgs e)
        {
            PageRows();
        }
        private void PageRows()
        {
            decimal PageCount = 0;
            //һ���ж�����
            int rowcount = Convert.ToInt32(Dgv.RowCount);
            //��ǰ�ǵڼ�ҳ
            int currentpage = Convert.ToInt32(Dgv.CurrentPage);
            //һҳ�ж�����
            int pageSize = Convert.ToInt32(Dgv.ItemsPerPage);

            //���������С�ڻ����ÿҳ��ʾ����
            if (rowcount <= pageSize)
                PageCount = DataSet1.Tables[0].AsEnumerable().Sum(r => Convert.ToDecimal(r["zj"]));
            else
            {
                //�����ǲ�������ÿҳ������
                if (rowcount % pageSize == 0)
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                    {
                        decimal n;
                        if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtZj.Name].Value.ToString(), out n))
                        {
                            PageCount += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZj.Name].Value.ToString());
                        }
                    }
                }
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                    {
                        if (i >= Dgv.Rows.Count)
                            break;
                        decimal n;
                        if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtZj.Name].Value.ToString(), out n))
                        {
                            PageCount += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZj.Name].Value.ToString());
                        }
                    }

                }

            }
            LblCheckbyhj.Text = "��ҳ�ϼƣ�" + PageCount + "Ԫ";
        }
        #region ������ѯ
        private void BtnJgSearch_Click(object sender, EventArgs e)
        {
            f = new FrmSelectJg();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtJgmc.Text = f.PubDictAttrs["mc"];
                PriJgid = Convert.ToInt32(f.PubDictAttrs["id"]);
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtJgmc.Text = "";
                PriJgid = 0;
            }
        }
        #endregion

        #region ��ϸ��Ϣ
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 13)
            {
                frm = new FrmJGYSKCXMX();
                frm.Prepare(Dgv.Rows[e.RowIndex].Cells[DgvColTxtJgid.Name].Value.ToString(), PriTime);
                frm.ShowDialog();
            }
        }
        #endregion

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("û����Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            DataTable dt;
            try
            {
                dt = ClsRWMSSQLDb.GetDataTable("SELECT ywqy,dqmc,bh, jgmc, ff, tf, zf, bfff, bftf, bfzf, slsj, zj FROM dbo.Vfmsjgyskcx " + PriWhere, ClsGlobals.CntStrTMS);
                CreateExcel(dt);
                dt.Dispose();
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ������Ϣʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }
            //int[] RowIndex = { 2, 3, 4, 5, 6, 7, 8 };
            // ClsExcel.CreatExcel(Dgv, "����Ӧ�տ��ѯ", ctrlDownLoad1, RowIndex);
        }

        private void CreateExcel(DataTable aDt)
        {

            if (aDt.Rows.Count == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "����Ӧ�տ��ѯ" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
            //д������
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.DefaultColumnWidth = 17;
            sheet1.SetColumnWidth(1, 25 * 100);

            //����һ���������洢��Щ�����������͵�
            int[] RowIndex = { 5, 6, 7, 8, 9, 10, 12 };
            List<int> LstRowIndex = new List<int>();
            LstRowIndex.AddRange(RowIndex);
            try
            {
                //�����ĵ�����
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                LieFont.FontHeightInPoints = 12;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                styleRow.SetFont(LieFont);
                row0.RowStyle = styleRow;
                row0.CreateCell(0).SetCellValue("��Ʒ����");
                row0.CreateCell(1).SetCellValue("ҵ������");
                row0.CreateCell(2).SetCellValue("��������");
                row0.CreateCell(3).SetCellValue("ҵ�񵥺�");
                row0.CreateCell(4).SetCellValue("Ӧ�տ����");
                row0.CreateCell(5).SetCellValue("�����˷�");
                row0.CreateCell(6).SetCellValue("�����˷�");
                row0.CreateCell(7).SetCellValue("�ʸ��˷�");
                row0.CreateCell(8).SetCellValue("�������۷�");
                row0.CreateCell(9).SetCellValue("�������۷�");
                row0.CreateCell(10).SetCellValue("�ʸ����۷�");
                row0.CreateCell(11).SetCellValue("��������");
                row0.CreateCell(12).SetCellValue("�ϼ�");
                int rowIndex = 1;
                //�������
                HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                HSSFCellStyle cellStyleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                HSSFRow hssfrow = null;
                foreach (DataRow row in aDt.Rows)
                {
                    hssfrow = (HSSFRow)sheet1.CreateRow(rowIndex);
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        double result = 0;
                        if (LstRowIndex.Contains(i))
                        {
                            if (double.TryParse(Convert.ToString(row[i]), out  result))
                            {
                                hssfrow.CreateCell(i).SetCellValue(Convert.ToDouble(row[i]));
                                hssfrow.Cells[i].CellStyle = cellStyle;
                            }
                            else
                                hssfrow.CreateCell(i).SetCellValue(row[i].ToString());
                        }
                        else
                            hssfrow.CreateCell(i).SetCellValue(row[i].ToString());
                    }
                    rowIndex++;
                }
                //#region  
                //for (int m = 0; m < aDt.Rows.Count; m++)
                //{
                //    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(rowIndex);
                //    for (int i = 0; i < 13; i++)
                //    {
                //        if (i == 10)
                //        {
                //            int n;
                //            if (Int32.TryParse(aDt.Rows[m][i].ToString(), out  n))
                //            {
                //                hssfrow.CreateCell(i).SetCellValue(Convert.ToInt32(aDt.Rows[m][i].ToString()));
                //            }
                //            else
                //            {
                //                hssfrow.CreateCell(i).SetCellValue(aDt.Rows[m][i].ToString());
                //                hssfrow.Cells[i].CellStyle = cellStyleRow;
                //            }
                //        }
                //        else if (i == 12)
                //        {
                //            double n;
                //            if (double.TryParse(aDt.Rows[m][i].ToString(), out  n))
                //            {
                //                hssfrow.CreateCell(i).SetCellValue(Convert.ToInt32(aDt.Rows[m][i].ToString()));
                //                hssfrow.Cells[i].CellStyle = cellStyle;
                //            }
                //            else
                //            {
                //                hssfrow.CreateCell(i).SetCellValue(aDt.Rows[m][i].ToString());
                //                hssfrow.Cells[i].CellStyle = cellStyleRow;
                //            }
                //        }
                //        else
                //        {
                //            hssfrow.CreateCell(i).SetCellValue(aDt.Rows[m][i].ToString());
                //            hssfrow.Cells[i].CellStyle = cellStyleRow;
                //        }
                //    }
                //    rowIndex++;
                //}
                //#endregion
                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
                this.ctrlDownLoad1.download(PriFlp, true);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("δ������տ���ϸ������ϸ����ʧ��", ex);
            }
        }



    }
}