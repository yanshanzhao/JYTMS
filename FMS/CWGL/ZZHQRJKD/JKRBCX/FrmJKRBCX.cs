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
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Data.SqlClient;
using FMS.CWGL.ZZHQRJKD.QRJK;
using JYPubFiles.Classes;
#endregion

namespace FMS.CWGL.ZZHQRJKD.JKRBCX
{




    public partial class FrmJKRBCX : UserControl
    {
        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (BdsRbcx.Count == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            int[] CellIndex = { 1, 2, 3 };
            ClsExcel.CreatExcel(Dgv, "�ɿ��ձ���ѯ", this.ctrlDownLoad1, CellIndex);
        }
        //    private void BtnExl_Click(object sender, EventArgs e)
        //    {
        //    if (Dgv.RowCount == 0)
        //        {
        //        ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
        //        return;
        //        }
        //        string PriFln = "�ɿ��ձ���ѯ_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
        //        string PriFlp = System.IO.Path.Combine(this.Context.HttpContext.Request.PhysicalApplicationPath + "App_Data\\Download", PriFln);//����ļ�·��
        //    ExcelWriter excel = new ExcelWriter(PriFlp);
        //    excel.BeginWrite();
        //    for (int i = 0; i < Dgv.ColumnCount - 5; i++)
        //        {
        //        excel.WriteString(0, (short)i, Dgv.Columns[i].HeaderText);
        //        }
        //    int roowIndex = 1;
        //    foreach (DataGridViewRow Row in Dgv.Rows)
        //        {

        //        for (int i = 0; i < Dgv.ColumnCount - 5; i++)
        //            {

        //            if (i == 0 || i == 4)
        //                {
        //                excel.WriteString((short)roowIndex, (short)i, Row.Cells[i].Value.ToString());
        //                }
        //            else
        //                {
        //                double d = Double.Parse(Row.Cells[i].Value.ToString());
        //                excel.WriteNumber((short)roowIndex, (short)i,d);
        //                }
        //            }
        //        roowIndex++;
        //        }

        //    excel.EndWrite();
        //    this.ctrlDownLoad1.download(PriFlp, true);
        //    }
        //public class ExcelWriter
        //    {
        //    System.IO.FileStream _writer;
        //    public ExcelWriter(string strPath)
        //        {
        //        _writer = new System.IO.FileStream(strPath, System.IO.FileMode.Create);
        //        }
        //    private void _writeFile(short[] values)
        //        {
        //        foreach (short v in values)
        //            {
        //            byte[] b = System.BitConverter.GetBytes(v);
        //            _writer.Write(b, 0, b.Length);
        //            }
        //        }
        //    public void BeginWrite()
        //        {
        //        _writeFile(new short[] {  0x809, 0x8, 0x0, 0x10, 0x0, 0x0 });
        //        }
        //    /// <summary>
        //    /// д�ļ�β
        //    /// </summary>
        //    public void EndWrite()
        //        {
        //        _writeFile(new short[] { 0xa, 0x0 });
        //        _writer.Close();
        //        }
        //    /// <summary>
        //    /// дһ�����ֵ���Ԫ��x,y
        //    /// </summary>
        //    /// <param name="x"></param>
        //    /// <param name="y"></param>
        //    /// <param name="value"></param>
        //    public void WriteNumber(short x, short y, double value)
        //        {
        //        _writeFile(new short[] { 0x203, 14, x, y, 0 });
        //        byte[] b = System.BitConverter.GetBytes(value);
        //        _writer.Write(b, 0, b.Length);
        //        }
        //    /// <summary>
        //    /// дһ���ַ�����Ԫ��x,y
        //    /// </summary>
        //    /// <param name="x"></param>
        //    /// <param name="y"></param>
        //    /// <param name="value"></param>
        //    public void WriteString(short x, short y, string value)
        //        {
        //        byte[] b = System.Text.Encoding.Default.GetBytes(value);
        //        _writeFile(new short[] { 0x204, (short)(b.Length + 8), x, y, 0, (short)b.Length });
        //        _writer.Write(b, 0, b.Length);
        //        }

        //    }


        #endregion

        #region ��Ա����
        private ClsG ObjG;
        private string Where;
        private int PriJgid;//������id
        private int PriShzt;
        private string PriConStr;
        #endregion
        public FrmJKRBCX()
        {
            InitializeComponent();
        }
        #region Prepare
        public void Prepare()
        {
            ObjG = (ClsG)Session["ObjG"];
            JkrbcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            PriJgid = ObjG.Jigou.id;
            Cmbjkzt.Text = "δ���"; 
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            //CmbYwqy.Text = "�㵣";
            ctrlDownLoad1.Visible = false;
            PriConStr = ClsGlobals.CntStrTMS;
        }
        #endregion
        //#region ����
        //private void BtnExl_Click(object sender, EventArgs e)
        //{
        //    if (Dgv.RowCount == 0)
        //    {
        //        ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
        //        return;
        //    }
        //    CreatExcelZhcx();
        //}
        //private void CreatExcelZhcx()
        //{
        //    string PriFln = "�ɿ��ձ���ѯ_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";//�ļ�����     
        //    string PriFlp = System.IO.Path.Combine(this.Context.HttpContext.Request.PhysicalApplicationPath +
        //        "App_Data\\Download", PriFln);//����ļ�·��
        //    HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
        //    //д������
        //    HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet") as HSSFSheet;
        //    sheet1.DefaultColumnWidth = 17;
        //    ///���õ�Ԫ����ʽ(����������ʾ����)
        //    HSSFCellStyle cellStyleC = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
        //    cellStyleC.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
        //    HSSFFont font1 = hssfworkbook.CreateFont() as HSSFFont;
        //    font1.FontHeightInPoints = 10;
        //    font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
        //    cellStyleC.SetFont(font1);
        //    ///���õ�Ԫ����ʽ(����������ʾ)
        //    HSSFCellStyle cellStyleR = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
        //    cellStyleR.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
        //    try
        //    {
        //        //�����ĵ�����
        //        HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
        //        HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
        //        HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
        //        LieFont.FontHeightInPoints = 10;
        //        LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
        //        styleRow.SetFont(LieFont);
        //        int roowIndex = 1;
        //        for (int i = 0; i < Dgv.ColumnCount - 5; i++)
        //        {
        //            row0.CreateCell(i).SetCellValue(Dgv.Columns[i].HeaderText);

        //        }
        //        //�������
        //        foreach (DataGridViewRow Row in Dgv.Rows)
        //        {
        //            HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
        //            for (int i = 0; i < Dgv.ColumnCount - 5; i++)
        //            {

        //                hssfrow.CreateCell(i).SetCellValue(Row.Cells[i].Value.ToString());
        //            }
        //            roowIndex++;
        //        }
        //        FileStream file = new FileStream(PriFlp, FileMode.Create);
        //        hssfworkbook.Write(file);

        //        file.Close();
        //        this.ctrlDownLoad1.download(PriFlp, true);
        //    }
        //    catch (Exception ex)
        //    {
        //        ClsMsgBox.Cw("������汨��ʧ��", ex);
        //    }
        //}
        ////#endregion
        #region ��ѯ
        public void BtnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(PriConStr))
            {
                conn.Open();
                try
                {
                    Where = " where  jgid=" + PriJgid;
                    if (CmbYwqy.SelectedIndex>0)
                    {
                        Where += " and ywqy='" + CmbYwqy.SelectedValue + "'";
                    }
                    
                    if (this.Cmbjkzt.Text == "δ���")
                    {
                        PriShzt = 0;
                        Where += " and zt=" + PriShzt;
                    }
                    else if (this.Cmbjkzt.Text == "������")
                    {
                        PriShzt = 10;
                        Where += " and zt=" + PriShzt;
                    }
                    Where += " and  inssj > '" + DtpStart.Value.Date + "' and  inssj<'"+DtpStop.Value.AddDays(1).Date+"'";
                    JkrbcxTableAdapter1.FillByWhere(jkrbcx1.Tfmsrbpc, Where);
                    if (Dgv.RowCount < 1)
                    {
                        ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ��", ObjG.CustomMsgBox, this);
                    }
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("��ѯ��Ϣʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
                }
                finally
                {
                    conn.Close();


                }
            }
        }
        #endregion
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (BdsRbcx.Count == 0) 
            //{
            //    ClsMsgBox.Ts("û��Ҫɾ������Ϣ��",ObjG.CustomMsgBox,this);
            //    return;
            //}
            if (e.RowIndex == -1 || e.ColumnIndex < 0)
                return;
            #region ɾ��
            if (string.Compare(Dgv.Columns[e.ColumnIndex].Name, "DgvColTxtCz", true) == 0)
            {

                if (Dgv.SelectedCells[4].Value.ToString() == "������")//�ж��ձ��Ƿ����
                {
                    ClsMsgBox.Cw("���ձ�����ˣ��޷�ɾ����", ObjG.CustomMsgBox, this);
                    return;
                }
                else if (Dgv.SelectedCells[10].Value.ToString() == "10" || Dgv.SelectedCells[10].Value.ToString() == "5" || Dgv.SelectedCells[10].Value.ToString() == "20")//�ж��ձ��Ƿ����
                {
                    ClsMsgBox.Cw("���ձ��Ѵ��ۣ��޷�ɾ����", ObjG.CustomMsgBox, this);
                    return;
                }
                else
                    ClsMsgBox.YesNo("ȷ��ɾ���ɿ��ձ���", new EventHandler(DelRb), ObjG.CustomMsgBox, this);

            }
            #endregion
            #region ��ϸ��Ϣ
            else if (string.Compare(Dgv.Columns[e.ColumnIndex].Name, "DgvColTxtXq", true) == 0)
            {
                FrmYbfXq f = new FrmYbfXq();
                f.ShowDialog();
                f.Prepare(Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtid"].Value.ToString()), Dgv.Rows[e.RowIndex].Cells["DgvColTxtRbdh"].Value.ToString());
            }
            #endregion
        }
        private void DelRb(object sender, EventArgs e)
        {
            FrmMsgBox frm = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult != DialogResult.Yes)
            {

                return;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(PriConStr))
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.Transaction = trans;

                    string aid;
                    aid = this.Dgv.CurrentRow.Cells["DgvColTxtId"].Value.ToString();
                    string cmdText = "";
                    if (Dgv.SelectedCells[0].Value.ToString().StartsWith("Y"))//�˵���ϸ
                    {
                        cmdText = "update tfmsybf set zt=0 where id in (select ybfid from Tfmsrbmx where rbpcid='" + aid + "') and zt=10;update tfmsybf set zt=15 where id in (select ybfid from tfmskhjsmx where pcid in (select khjsid from tfmsrbmx where rbpcid='" + aid + "') and zt=10);update tfmskhjspc set zt=10 where id in (select khjsid from tfmsrbmx where rbpcid='" + aid + "') and zt=15;  delete tfmsrbmx where rbpcid='" + aid + "' delete tfmsrbpc where id='" + aid + "' ";
                        try
                        {
                            //Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(cmdText, PriConStr);
                            comm.CommandText = cmdText;
                            int influenceSum = comm.ExecuteNonQuery();
                            if (influenceSum > 0)
                            {
                                //�ύ����
                                ClsMsgBox.Ts("ɾ���ɹ���", frm, this);
                                trans.Commit();
                                BdsRbcx.RemoveCurrent();
                                //JkrbcxTableAdapter1.FillByWhere(jkrbcx1.Tfmsrbpc, Where);
                            }
                            else
                            {
                                //�ع�����
                                ClsMsgBox.Ts("ɾ��ʧ�ܣ�û��Ҫɾ������Ϣ��", frm, this);
                                trans.Rollback();
                                JkrbcxTableAdapter1.FillByWhere(jkrbcx1.Tfmsrbpc, Where);
                            }
                        }
                        catch (Exception ex)
                        {
                            ClsMsgBox.Cw("ɾ���쳣��", ex, frm, this);
                        }
                        finally
                        {
                            conn.Close();
                            cmdText = "";
                        }
                    }
                    else//������ϸ
                    {
                        cmdText = " update tfmsrbpc set pid=null,pczt=0 where pid='" + aid + "' and pczt=10;delete tfmsrbpc where id='" + aid + "'";
                        try
                        {
                            //Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(cmdText, PriConStr);
                            comm.CommandText = cmdText;
                            int influenceSum = comm.ExecuteNonQuery();
                            if (influenceSum > 0)
                            {
                                //�ύ����
                                ClsMsgBox.Ts("ɾ���ɹ���", frm, this);
                                trans.Commit();
                                BdsRbcx.RemoveCurrent();
                                //JkrbcxTableAdapter1.FillByWhere(jkrbcx1.Tfmsrbpc, Where);
                            }
                            else
                            {
                                //�ع�����
                            ClsMsgBox.Ts("ɾ��ʧ�ܣ�û��Ҫɾ������Ϣ��", frm, this);
                                trans.Rollback();
                                JkrbcxTableAdapter1.FillByWhere(jkrbcx1.Tfmsrbpc, Where);
                            }
                        }
                        catch (Exception ex)
                        {
                            ClsMsgBox.Cw("ɾ���쳣��", ex, frm, this);
                        }
                        finally
                        {
                            conn.Close();
                            cmdText = "";
                        }
                    }

                }
            }
        }

    }



}

