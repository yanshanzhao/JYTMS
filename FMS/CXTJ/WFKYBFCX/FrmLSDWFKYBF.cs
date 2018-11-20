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
using System.IO;
using System.Configuration;

#endregion

namespace FMS.CXTJ.WFKYBFCX
{
    public partial class FrmLSDWFKYBF : Form
    {
        #region  ��Ա����
        private ClsG ObjG;
        private int PriLevel;
        private int PriJgid;
        private DateTime PriStop;
        private SqlDataAdapter sda;
        private DataSet ds;
        private FrmYDWFKYBF f;
        #endregion
        public FrmLSDWFKYBF()
        {
            InitializeComponent();
        }
        #region  ��ʼ������
        public void Prepare(string aJgid, DateTime aTime, string aJgmc, string aJe, string aType)
        {
            PriStop = aTime;
            LblJgmc.Text = aJgmc;
            LblJe.Text = aJe;
            PriJgid = Convert.ToInt32(aJgid);
            ObjG = Session["ObjG"] as ClsG;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsGlobals.CntStrTMS;
                conn.Open();
                using (SqlCommand comm = new SqlCommand())
                {
                    try
                    {
                        sda = new SqlDataAdapter();
                        ds = new DataSet();
                        if (aType == "A")
                            PriLevel = ClsRWMSSQLDb.GetInt("select level from tjigou where id=" + aJgid, ClsGlobals.CntStrKj);
                        comm.Connection = conn;
                        ArrayList aryLst = new ArrayList();
                        aryLst.Add(new SqlParameter("@jgid", aJgid));
                        aryLst.Add(new SqlParameter("@time", aTime));
                        aryLst.Add(new SqlParameter("@Level", PriLevel==0?ObjG.Jigou.level:PriLevel));
                        aryLst.Add(new SqlParameter("@Type", aType));
                        comm.Parameters.AddRange(aryLst.ToArray(typeof(SqlParameter)));
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.CommandText = "P_Fmswfkybfcx";
                        sda.SelectCommand = comm;
                        ds.Clear();
                        sda.Fill(ds, "fmswfkybfcx");
                        DataRow dt = ds.Tables["fmswfkybfcx"].NewRow();
                        dt["jgmc"] = "�ϼ�";
                        dt["ts0"] = ds.Tables["fmswfkybfcx"].Compute("sum(ts0)", "");
                        dt["ts1"] = ds.Tables["fmswfkybfcx"].Compute("sum(ts1)", "");
                        dt["ts2"] = ds.Tables["fmswfkybfcx"].Compute("sum(ts2)", "");
                        dt["ts3"] = ds.Tables["fmswfkybfcx"].Compute("sum(ts3)", "");
                        dt["ts999"] = ds.Tables["fmswfkybfcx"].Compute("sum(ts999)", "");
                        dt["hj"] = ds.Tables["fmswfkybfcx"].Compute("sum(hj)", "");
                        ds.Tables["fmswfkybfcx"].Rows.Add(dt);
                        Dgv.DataSource = ds.Tables["fmswfkybfcx"];
                    }
                    catch (Exception ex)
                    {
                        ClsMsgBox.Cw("��ѯ��Ϣʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
                    }
                    finally
                    {
                        conn.Close();
                        sda.Dispose();
                    }
                }
            }
        }
        #endregion

        #region Dgv�����¼�
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.RowIndex < Dgv.Rows.Count - 1 && e.ColumnIndex == 6)
            {
                f = new FrmYDWFKYBF();
                f.Prepare(PriStop, Dgv.Rows[e.RowIndex].Cells[DgvColTxtJgid.Name].Value.ToString(),
                    Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgmc.Name].Value.ToString(), Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),"B");
                f.ShowDialog();
            }
            else if (e.RowIndex == Dgv.Rows.Count - 1 && e.ColumnIndex == 6) 
            {
                f = new FrmYDWFKYBF();
                f.Prepare(PriStop, PriJgid.ToString(),
                    LblJgmc.Text, Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), "D");
                f.ShowDialog();
            }
        }
        #endregion

        #region ����
        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "δ�����˱��Ѳ�ѯ" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
            //д������
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.DefaultColumnWidth = 17;
            try
            {
                //�����ĵ�����
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                LieFont.FontHeightInPoints = 10;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.SetFont(LieFont);
                HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                for (int i = 0; i < Dgv.ColumnCount - 1; i++)
                {
                    row0.CreateCell(i).SetCellValue(Dgv.Columns[i].HeaderText);
                    row0.Cells[i].CellStyle = styleRow;
                }
                int roowIndex = 1;
                //�������
                foreach (DataGridViewRow Row in Dgv.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    for (int i = 0; i < Dgv.ColumnCount - 1; i++)
                    {
                        if (i > 0)
                        {
                            double n;
                            double je = 0;
                            if (Double.TryParse(Row.Cells[i].Value.ToString(), out n))
                            {
                                je = Convert.ToDouble(Row.Cells[i].Value.ToString());
                                hssfrow.CreateCell(i).SetCellValue(je);
                                hssfrow.Cells[i].CellStyle = cellStyle;
                            }
                        }
                        else
                        {
                            hssfrow.CreateCell(i).SetCellValue(Convert.ToString(Row.Cells[i].Value));
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
                ClsMsgBox.Cw("����Excelʧ��", ex);
            }
        }
        #endregion
    }
}