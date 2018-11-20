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
using System.Data.SqlClient;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Configuration;

#endregion

namespace FMS.CXTJ.DSKFWKWGCX
{
    public partial class FrmDSKFWKWGCX : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private string PriWhere;
        private FrmDSKFWKWGCXMX f;
        #endregion
        public FrmDSKFWKWGCX()
        {
            InitializeComponent();
        }
        #region ��ʼ������
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
        }
        #endregion

        #region ��ѯ
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtRs.Text.Trim()))
            {
                ClsMsgBox.Ts("�����뷢��������", ObjG.CustomMsgBox, this);
                return;
            }
            if (!ClsRegEx.IsInt(TxtRs.Text.Trim()))
            {
                ClsMsgBox.Ts("����������ʽ����ȷ��", ObjG.CustomMsgBox, this);
                return;
            }
            if (string.IsNullOrEmpty(TxtHwmc.Text.Trim()))
            {
                ClsMsgBox.Ts("�������������������", ObjG.CustomMsgBox, this);
                return;
            }
            if (!ClsRegEx.IsInt(TxtHwmc.Text.Trim()))
            {
                ClsMsgBox.Ts("��������������ʽ����ȷ��", ObjG.CustomMsgBox, this);
                return;
            }

            PriWhere = " ";
            try
            {
                DSCX.Clear();
                PriWhere += " CONVERT(INT,fwkh)>1001 and inssj >= '" + DtpStart.Value.Date + "' and inssj<'" + DtpEnd.Value.Date.AddDays(1) + "'";
                PriWhere += string.IsNullOrEmpty(TxtFwkh.Text.Trim()) ? "" : " and fwkh='" + TxtFwkh.Text.Trim() + "'";
                ClsRWMSSQLDb.FillTable(DSCX, " select a.fwkh,count(distinct a.fhlxr) as rs,count(distinct hwmc) as hwzl,'��ϸ��Ϣ' as xx from (select fwkh,fhlxr,hwmc from tyd where dsk>0 and ydzt<>'X' and " + PriWhere + " group by fwkh,fhlxr,hwmc) as a   group by a.fwkh having  count(distinct a.fhlxr)>=" + TxtRs.Text.Trim() + " and count(distinct a.hwmc)>=" + TxtHwmc.Text.Trim(), ClsGlobals.CntStrTMS);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ��Ϣʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion

        #region ��ϸ��Ϣ
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv.Columns[e.ColumnIndex].Name.Equals("DgvColLnkXx"))
            {
                f = new FrmDSKFWKWGCXMX();
                f.Prepare(PriWhere, Dgv.Rows[e.RowIndex].Cells[DgvColTxtFwkh.Name].Value.ToString());
                f.ShowDialog();
            }
        }
        #endregion

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Cw("���Ȳ�ѯ�󵼳���ϸ��", ObjG.CustomMsgBox, this);
                return;
            }
            //List<string> ls = new List<string>();
            //for (int i = 0; i < Dgv.Rows.Count; i++)
            //{
            //    ls.Add(Dgv.Rows[i].Cells[DgvColTxtFwkh.Name].Value.ToString());
            //}
            DataTable aDt = null;
            try
            {

                //DataTable dt= ClsRWMSSQLDb.GetDataTable(DSCX, "select bh,inssj as slsj,(select mc from jyjckj.dbo.tjigou where id=sljgid) as sljg,dsk from tyd where fwkh='" + Dgv.CurrentRow.Cells[DgvColTxtFwkh.Name].Value.ToString() + "' " + PriWhere, ClsGlobals.CntStrTMS);
                aDt = ClsRWMSSQLDb.GetDataTable("select bh,inssj as slsj,(select mc from jyjckj.dbo.tjigou where id=sljgid) as sljg,fwkh,(select mc from tkh where bh=fwkh) as ckr,hwmc,zjs,dsk,(select mc from jyjckj.dbo.tjigou where id=qsjgid) as qsjg,fhlxr,fhlxdh from tyd where dsk>0 and ydzt<>'X' and fwkh in(select a.fwkh from (select fwkh,fhlxr,hwmc from tyd where dsk>0 and ydzt<>'X' and " + PriWhere + " group by fwkh,fhlxr,hwmc) as a   group by a.fwkh having  count(distinct a.fhlxr)>=" + TxtRs.Text.Trim() + " and count(distinct a.hwmc)>=" + TxtHwmc.Text.Trim() + ") and" + PriWhere, ClsGlobals.CntStrTMS);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ��ϸʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
                return;
            }

            if (aDt.Rows.Count == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            if (aDt.Rows.Count > 60000)
            {
                ClsMsgBox.Ts("������������60000��������", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "���տ����Υ���ѯ" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
            //д������
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.DefaultColumnWidth = 17;
            sheet1.SetColumnWidth(0, 40 * 100);
            sheet1.SetColumnWidth(1, 40 * 150);
            sheet1.SetColumnWidth(2, 40 * 150);
            sheet1.SetColumnWidth(3, 30 * 150);
            sheet1.DefaultRowHeight = 8;
            //����һ���������洢��Щ�����������͵�
            int[] RowIndex = { 4 };
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
                row0.CreateCell(0).SetCellValue("���˱��");
                row0.CreateCell(1).SetCellValue("����ʱ��");
                row0.CreateCell(2).SetCellValue("����ṹ");
                row0.CreateCell(3).SetCellValue("���񿨺�");
                row0.CreateCell(4).SetCellValue("�ֿ���");
                row0.CreateCell(5).SetCellValue("��������");
                row0.CreateCell(6).SetCellValue("�ܼ���");
                row0.CreateCell(7).SetCellValue("���տ�");
                row0.CreateCell(8).SetCellValue("ǩ�ջ���");
                row0.CreateCell(9).SetCellValue("������");
                row0.CreateCell(10).SetCellValue("��ϵ�绰");
                row0.Cells[0].CellStyle = styleRow;
                row0.Cells[1].CellStyle = styleRow;
                row0.Cells[2].CellStyle = styleRow;
                row0.Cells[3].CellStyle = styleRow;
                row0.Cells[4].CellStyle = styleRow;
                row0.Cells[5].CellStyle = styleRow;
                row0.Cells[6].CellStyle = styleRow;
                row0.Cells[7].CellStyle = styleRow;
                row0.Cells[8].CellStyle = styleRow;
                row0.Cells[9].CellStyle = styleRow;
                row0.Cells[10].CellStyle = styleRow;
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

                        if (i == 6 || i == 7)
                        {

                            hssfrow.CreateCell(i).SetCellValue(Convert.ToDouble(row[i]));
                            hssfrow.Cells[i].CellStyle = cellStyle;


                        }
                        else
                            hssfrow.CreateCell(i).SetCellValue(row[i].ToString());
                    }
                    rowIndex++;
                }

                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfworkbook.Write(file);
                hssfworkbook.Dispose();
                sheet1.Dispose();
                file.Close();
                file.Dispose();
                this.ctrlDownLoad1.download(PriFlp, true);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("������ϸʧ��", ex, ObjG.CustomMsgBox, this);
                return;
            }

        }

        private void BtnDC_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.Rows.Count > 60000)
            {
                ClsMsgBox.Ts("������������60000��������!", (Session["ObjG"] as ClsG).CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 1 };
            ClsExcel.CreatExcel(Dgv, "���տ���񿨺�Υ����Ϣ", this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, "�˱��Ѵ���", this.ctrlDownLoad1);
        }
    }
}
