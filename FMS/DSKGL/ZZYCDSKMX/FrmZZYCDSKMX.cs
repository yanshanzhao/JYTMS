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
using System.Data.SqlClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using JYPubFiles.Classes;
using Gizmox.WebGUI.Common.Interfaces;
using System.Configuration;
#endregion
namespace FMS.DSKGL.ZZYCDSKMX
{
    public partial class FrmZZYCDSKMX : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private int PriJgid;
        private string PriWhere;
        private string PriConStr;
        private DataTable PriData = new DataTable();
        private int PriRowIndex = 0;
        private int PriRowIndexId = 0;
        private int PriRowIndexCounts = 0;
        private FrmMsgBox Box = new FrmMsgBox();
        #endregion
        public FrmZZYCDSKMX()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            CmbFkfs.SelectedIndex = 0;
            CbmDskbz.SelectedIndex = 0;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriJgid = ObjG.Jigou.id;
            PriConStr = ClsGlobals.CntStrTMS;
            this.VfmszzycdskmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }
        #region ͳ��
        private void BtnTj_Click(object sender, EventArgs e)
        {
            int n = ClsRWMSSQLDb.GetInt(" SELECT  jgid  FROM dbo.Tfmsyhzh  WHERE (zhlxid = 50) AND (zt = 0) AND jgid = " + ObjG.Jigou.id, PriConStr);
            if (n <= 0)
            {
                JGts("ϵͳδά�������˻���Ϣ��������տ��ϵ�绰��0531-58681288", new EventHandler(OpenFrm), Box, this);
                return;
            }
            FrmZZYCDSKTJ f = new FrmZZYCDSKTJ();
            f.ShowDialog();
            f.Prepare();
        }
        private void OpenFrm(object sender, EventArgs e)
        {
            FrmMsgBox c = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.OK)
            {
                FrmZZYCDSKTJ f1 = new FrmZZYCDSKTJ();
                f1.ShowDialog();
                f1.Prepare();
            }
        }
        private static void InvokeFocusCommand(Control objControl, Control aControl = null)
        {
            if (aControl == null)
                return;
            IApplicationContext objApplicationContext = aControl.Context as IApplicationContext;
            if (objApplicationContext != null)
                objApplicationContext.SetFocused(objControl, true);
        }
        public static void JGts(string mess, EventHandler hdl, FrmMsgBox aMsgBox = null, Control aParControl = null, float aFontsize = 14)
        {
            aMsgBox.Text = "����";
            aMsgBox.LblMess.Text = mess;
            aMsgBox.LblMess.Font = new System.Drawing.Font("����", aFontsize, System.Drawing.FontStyle.Bold);
            aMsgBox.LblMess.ForeColor = System.Drawing.Color.Red;
            aMsgBox.Btn1.Text = "ȷ��";
            aMsgBox.Btn1.AutoSize = true;
            aMsgBox.Btn1.DialogResult = DialogResult.OK;
            aMsgBox.Btn1.TabStop = true;
            aMsgBox.Tag = null;
            aMsgBox.Btn2.Text = "ȡ��";
            aMsgBox.Btn2.AutoSize = true;
            aMsgBox.Btn2.DialogResult = DialogResult.Cancel;
            aMsgBox.Btn2.Visible = true;
            aMsgBox.ShowDialog();
            aMsgBox.FrmCloseHdl = hdl;
            InvokeFocusCommand(aMsgBox, aParControl);
        }
        #endregion
        #region ��������
        private void BtnExlhz_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ!", ObjG.CustomMsgBox, this);
                return;
            }
            else
            {
                string RowTiems = "";
                if (DtpStart.Checked && DtpStop.Checked)
                {
                    RowTiems = DtpStart.Value.ToString("yyyy-MM-dd") + "~" + DtpStop.Value.ToString("yyyy-MM-dd");
                }
                else if (DtpStart.Checked && !DtpStop.Checked)
                {
                    RowTiems = DtpStart.Value.ToString("yyyy-MM-dd") + "~" + DateTime.Now.ToString("yyyy-MM-dd");
                }
                else if (!DtpStart.Checked && DtpStop.Checked)
                {
                    RowTiems = DateTime.Now.ToString("yyyy-MM-dd") + "~" + DtpStop.Value.ToString("yyyy-MM-dd");
                }
                string PriFln = "����Ӧ����տ���ϸ��������" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
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
                titCell.SetCellValue("���տ�Ӧ����ϸ");
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
                sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 6));
                #region д��ʱ��ͻ���
                //д��ʱ��ͻ���
                HSSFCellStyle styleCell = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                styleCell.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
                HSSFRow timeRow = sheet1.CreateRow(1) as HSSFRow;
                HSSFCell timeCell = timeRow.CreateCell(0) as HSSFCell;
                timeCell.SetCellValue("�Ƶ�����:");
                timeCell.CellStyle = styleCell;
                HSSFCell timeCell2 = timeRow.CreateCell(1) as HSSFCell;
                timeCell2.SetCellValue(ObjG.Jigou.mc);
                HSSFRow timeRow1 = sheet1.CreateRow(2) as HSSFRow;
                HSSFCell timeCell3 = timeRow1.CreateCell(0) as HSSFCell;
                timeCell3.SetCellValue("�Ƶ�����:");
                timeCell3.CellStyle = styleCell;
                HSSFCell timeCell4 = timeRow1.CreateCell(1) as HSSFCell;
                timeCell4.SetCellValue(RowTiems);
                sheet1.AddMergedRegion(new CellRangeAddress(1, 1, 1, 6));
                sheet1.AddMergedRegion(new CellRangeAddress(2, 2, 1, 6));
                #endregion
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
                    HSSFRow row0 = (HSSFRow)sheet1.CreateRow(3);
                    HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                    LieFont.FontHeightInPoints = 12;
                    LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                    styleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    styleRow.SetFont(LieFont);
                    for (int i = 0; i < 7; i++)
                    {
                        if (i == 4)
                        {
                            row0.CreateCell(i).SetCellValue("POS�����");
                            row0.Cells[i].CellStyle = styleRow;
                        }
                        else if (i == 5)
                        {
                            row0.CreateCell(i).SetCellValue("���տ���");
                            row0.Cells[i].CellStyle = styleRow;
                        }
                        else if (i == 6)
                        {
                            row0.CreateCell(i).SetCellValue("���ʽ");
                            row0.Cells[i].CellStyle = styleRow;
                        }
                        else
                        {
                            row0.CreateCell(i).SetCellValue(Dgv.Columns[i + 1].HeaderText);
                            row0.Cells[i].CellStyle = styleRow;
                        }

                    }
                    int roowIndex = 4;
                    double sum = 0;
                    //�������
                    HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                    foreach (DataGridViewRow Row in Dgv.Rows)
                    {
                        HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                        double dsk = 0;
                        for (int i = 0; i < 7; i++)
                        {
                            if (i == 4)
                                hssfrow.CreateCell(i).SetCellValue(" ");
                            else if (i == 5)
                            {
                                dsk = Convert.ToDouble(Row.Cells[i].Value);
                                sum += dsk;
                                hssfrow.CreateCell(i).SetCellValue(dsk);
                                hssfrow.Cells[i].CellStyle = cellStyle;
                            }
                            else if (i == 6)
                                hssfrow.CreateCell(i).SetCellValue(Row.Cells[13].Value.ToString());
                            else
                                hssfrow.CreateCell(i).SetCellValue(Row.Cells[i + 1].Value.ToString());
                        }
                        roowIndex++;
                    }
                    HSSFRow hssfrowSum = (HSSFRow)sheet1.CreateRow(roowIndex);
                    hssfrowSum.CreateCell(0).SetCellValue("�ܼ�");
                    hssfrowSum.CreateCell(5).SetCellValue(sum);
                    FileStream file = new FileStream(PriFlp, FileMode.Create);
                    hssfworkbook.Write(file);
                    file.Close();
                    this.ctrlDownLoad1.download(PriFlp, true);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("�������ܱ���ʧ��", ex);
                }
            }
        }
        #endregion
        #region ������ϸ
        private void BtnExlmx_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ!", ObjG.CustomMsgBox, this);
                return;
            }
            else
            {
                GetDataYdmx();
                string PriFln = "����Ӧ����տ���ϸ������ϸ" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
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
                titCell.SetCellValue("���տ�Ӧ����ϸ�˵���ϸ");
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
                sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 6));
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
                    HSSFRow row0 = (HSSFRow)sheet1.CreateRow(1);
                    HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                    LieFont.FontHeightInPoints = 12;
                    LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                    styleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    styleRow.SetFont(LieFont);
                    row0.CreateCell(0).SetCellValue("��������");
                    row0.Cells[0].CellStyle = styleRow;
                    row0.CreateCell(1).SetCellValue("�������");
                    row0.Cells[1].CellStyle = styleRow;
                    row0.CreateCell(2).SetCellValue("�������");
                    row0.Cells[2].CellStyle = styleRow;
                    row0.CreateCell(3).SetCellValue("�������");
                    row0.Cells[3].CellStyle = styleRow;
                    row0.CreateCell(4).SetCellValue("����վ");
                    row0.Cells[4].CellStyle = styleRow;
                    row0.CreateCell(5).SetCellValue("������");
                    row0.Cells[5].CellStyle = styleRow;
                    row0.CreateCell(6).SetCellValue("�ջ���");
                    row0.Cells[6].CellStyle = styleRow;
                    row0.CreateCell(7).SetCellValue("���˵���");
                    row0.Cells[7].CellStyle = styleRow;
                    row0.CreateCell(8).SetCellValue("���տ���");
                    row0.Cells[8].CellStyle = styleRow;
                    row0.CreateCell(9).SetCellValue("ʵ�����");
                    row0.Cells[9].CellStyle = styleRow;
                    row0.CreateCell(10).SetCellValue("���㷽ʽ");
                    row0.Cells[10].CellStyle = styleRow;
                    row0.CreateCell(11).SetCellValue("��������");
                    row0.Cells[11].CellStyle = styleRow;
                    row0.CreateCell(12).SetCellValue("���񿨺�");
                    row0.Cells[12].CellStyle = styleRow;
                    row0.CreateCell(13).SetCellValue("��������");
                    row0.Cells[13].CellStyle = styleRow;
                    row0.CreateCell(14).SetCellValue("ǩ������");
                    row0.Cells[14].CellStyle = styleRow;
                    row0.CreateCell(15).SetCellValue("ǩ����");
                    row0.Cells[15].CellStyle = styleRow;
                    row0.CreateCell(16).SetCellValue("ǩ����֤������");
                    row0.Cells[16].CellStyle = styleRow;
                    row0.CreateCell(17).SetCellValue("ǩ����֤����");
                    row0.Cells[17].CellStyle = styleRow;
                    row0.CreateCell(18).SetCellValue("ί����ǩ��");
                    row0.Cells[18].CellStyle = styleRow;
                    row0.CreateCell(19).SetCellValue("ί����֤������");
                    row0.Cells[19].CellStyle = styleRow;
                    row0.CreateCell(20).SetCellValue("ί��֤������");
                    row0.Cells[20].CellStyle = styleRow;
                    row0.CreateCell(21).SetCellValue("�Ƶ�����");
                    row0.Cells[21].CellStyle = styleRow;
                    row0.CreateCell(22).SetCellValue("�������");
                    row0.Cells[22].CellStyle = styleRow;
                    int roowIndex = 2;
                    //�������
                    HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                    HSSFCellStyle cellStyleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    cellStyleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    for (int m = 0; m < PriData.Rows.Count; m++)
                    {
                        HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                        for (int i = 0; i < 23; i++)
                        {
                            if (i == 0 || i == 11 || i == 14)
                            {

                                DateTime dTime;
                                if (DateTime.TryParse(PriData.Rows[m][i].ToString(), out dTime))
                                {
                                    hssfrow.CreateCell(i).SetCellValue(Convert.ToDateTime(PriData.Rows[m][i]).ToString("yyyy-MM-dd"));
                                    hssfrow.Cells[i].CellStyle = cellStyleRow;
                                }
                                else
                                {
                                    hssfrow.CreateCell(i).SetCellValue(PriData.Rows[m][i].ToString());
                                    hssfrow.Cells[i].CellStyle = cellStyleRow;
                                }
                            }
                            else if (i == 8 || i == 9)
                            {
                                double n;
                                if (double.TryParse(PriData.Rows[m][i].ToString(), out n))
                                {
                                    hssfrow.CreateCell(i).SetCellValue(Convert.ToDouble(PriData.Rows[m][i]));
                                    hssfrow.Cells[i].CellStyle = cellStyle;
                                }
                                else
                                {
                                    hssfrow.CreateCell(i).SetCellValue(PriData.Rows[m][i].ToString());
                                    hssfrow.Cells[i].CellStyle = cellStyleRow;
                                }
                            }
                            else
                            {
                                hssfrow.CreateCell(i).SetCellValue(PriData.Rows[m][i].ToString());
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
                    ClsMsgBox.Cw("��������Ӧ����տ���ϸ������ϸ����ʧ��", ex);
                }
            }
        }
        #endregion
        #region ��ѯ
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                PriWhere = " where    jgid=" + PriJgid + " and zt<> '0' and zt<>'5'   ";
                PriWhere += string.IsNullOrEmpty(TxtBRbdh.Text.Trim()) ? "  " : " and rbdh like '%" + TxtBRbdh.Text.Trim() + "%'";
                if (CbmDskbz.SelectedIndex != 0)
                    PriWhere = PriWhere + " and ztmc='" + CbmDskbz.Text + "'";
                if (CmbFkfs.SelectedIndex != 0)
                    PriWhere = PriWhere + " and zffsmc='" + CmbFkfs.Text + "'";
                if (DtpStart.Checked && DtpStop.Checked)
                {
                    PriWhere = PriWhere + "  and zdsj between'" + DtpStart.Value + "'and DateAdd(dd,+1, '" + DtpStop.Value + "')";
                }
                else if (DtpStart.Checked && !DtpStop.Checked)
                {
                    PriWhere = PriWhere + "  and zdsj between'" + DtpStart.Value + "'and DateAdd(dd,+1, '" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                }
                else if (!DtpStart.Checked && DtpStop.Checked)
                {
                    PriWhere = PriWhere + "   and zdsj <='" + DtpStop.Value + "'";
                }
                if (Txthydh.Text.Trim().Length > 0)
                {
                    int apcid = GetPcid();
                    if (apcid > 0)
                        PriWhere = PriWhere + " and id= " + apcid;
                }
                Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select id,rbdh,zh,zhmc,yhlx,tojgmc,dsk,sxf,zdsj,ztmc,zffsmc,khh,'��ϸ��Ϣ' as Xq,'ɾ��' as Del,cnt,jgzh,jgzhmc,jgmc from Vfmszzycdskmx  " + PriWhere, PriConStr);
                //VfmszzycdskmxTableAdapter1.FillByWhere(DSZZYCMX1.Vfmszzycdskmx, PriWhere);
                if (Dgv.RowCount == 0)
                    ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ��", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ�쳣��", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion
        #region ��굥ѡ
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1)
                return;
            if (e.ColumnIndex == 14)//��ϸ
            {
                string aRhdh = Dgv.Rows[e.RowIndex].Cells[DgvColTxtrbdh.Name].Value.ToString();
                string aSkjg = Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgmc.Name].Value.ToString();
                string aDsk = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString();
                string aSxf = Dgv.Rows[e.RowIndex].Cells[DgvColTxtsxf.Name].Value.ToString();
                int n;
                int aCouts = 0;
                if (Int32.TryParse(Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtCounts.Name].Value), out n))
                {
                    aCouts = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtCounts"].Value);
                }
                int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtId"].Value);
                FrmDSKRBLL f = new FrmDSKRBLL();
                f.Prepare(aRhdh, aSkjg, aDsk, aSxf, aCouts.ToString(), aId);
                f.ShowDialog();

            }
            if (e.ColumnIndex == 15)//ɾ��
            {
                string aZtmc = Dgv.Rows[e.RowIndex].Cells["DgvColTxtdskbz"].Value.ToString();

                if (aZtmc != "���ύ")
                {
                    ClsMsgBox.Ts("�ô��տ��ձ��Ѿ���˻��ѵ���,�޷�ɾ����", ObjG.CustomMsgBox, this);
                    return;
                }

                else
                {
                    int n;
                    int aCouts = 0;
                    PriRowIndexCounts = 0; PriRowIndex = 0;
                    if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtCounts.Name].Value.ToString(), out n))
                    {
                        aCouts = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtCounts"].Value);//������
                    }
                    PriRowIndexId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtId"].Value);
                    PriRowIndexCounts = aCouts;
                    PriRowIndex = e.RowIndex;
                    ClsMsgBox.YesNo("�Ƿ�ɾ�����ύ���տ��ձ�", new EventHandler(DelYh), ObjG.CustomMsgBox, this);
                    //GetRowLing(aId, aCouts);
                }
            }
        }
        private void DelYh(object sender, EventArgs e)
        {
            FrmMsgBox c = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {
                //sjdskzt(�Ͻɴ��տ�״̬)��Ĭ��ֵΪ0-δ�ɿ15:��ɾ��  10-�ѱ��棻20-���ύ��30-�ѽɿ� 
                using (SqlConnection conn = new SqlConnection(PriConStr))
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    SqlCommand comm = new SqlCommand();
                    try
                    {
                        comm.Connection = conn;
                        comm.Transaction = trans;
                        string cmdText = "";
                        cmdText = " update tfmsdsk set sjdskzt='15' where id in(select dskid from Tfmsdskjkmx where pcid=" + PriRowIndexId + ");";
                        comm.CommandText = cmdText;
                        int influenceSum = comm.ExecuteNonQuery();
                        cmdText = " update Tfmsdskjkpc set  zt='5' where id=" + PriRowIndexId;
                        comm.CommandText = cmdText;
                        influenceSum = influenceSum + comm.ExecuteNonQuery();
                        if (influenceSum == PriRowIndexCounts + 1)
                        {
                            //�ύ����
                            ClsMsgBox.Ts("ɾ���ɹ���", c, this);
                            trans.Commit();
                            Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select id,rbdh,zh,zhmc,yhlx,tojgmc,dsk,sxf,zdsj,ztmc,zffsmc,khh,'��ϸ��Ϣ' as Xq,'ɾ��' as Del,cnt from Vfmszzycdskmx  " + PriWhere, PriConStr);
                        }
                        else
                        {
                            //�ع�����
                            ClsMsgBox.Ts("ɾ��ʧ�ܣ�", c, this);
                            trans.Rollback();
                        }
                    }
                    catch
                    {
                        //�ع�����
                        try
                        {
                            ClsMsgBox.Cw("ɾ���쳣��", c, this);
                            trans.Rollback();
                        }
                        catch (SqlException ex1)
                        {
                            if (trans.Connection != null)
                                ClsMsgBox.Cw("�ع�ʧ��! �쳣����:" + ex1.GetType(), ex1, c, this);
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        #endregion
        //#region �޸�ȷ�ϵ��ձ�
        //private void GetRowLing(int aId, int aCounts)
        //{
        //    //sjdskzt(�Ͻɴ��տ�״̬)��Ĭ��ֵΪ0-δ�ɿ15:��ɾ��  10-�ѱ��棻20-���ύ��30-�ѽɿ� 
        //    using (SqlConnection conn = new SqlConnection(PriConStr))
        //    {
        //        conn.Open();
        //        SqlTransaction trans = conn.BeginTransaction();
        //        SqlCommand comm = new SqlCommand();
        //        try
        //        {
        //            comm.Connection = conn;
        //            comm.Transaction = trans;
        //            string cmdText = "";
        //            cmdText = " update tfmsdsk set sjdskzt='10' where id in(select dskid from Tfmsdskjkmx where pcid=" + aId + ");";
        //            comm.CommandText = cmdText;
        //            int influenceSum = comm.ExecuteNonQuery();
        //            cmdText = " update Tfmsdskjkpc set  zt='0' where id=" + aId;
        //            comm.CommandText = cmdText;
        //            influenceSum = influenceSum + comm.ExecuteNonQuery();
        //            if (influenceSum == aCounts + 1)
        //            {
        //                //�ύ����
        //                ClsMsgBox.Ts("ɾ���ɹ���", ObjG.CustomMsgBox, this);
        //                trans.Commit();
        //                Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select id,rbdh,zh,zhmc,yhlx,tojgmc,dsk,sxf,zdsj,ztmc,zffsmc,khh,'��ϸ��Ϣ' as Xq,'ɾ��' as Del,cnt from Vfmszzycdskmx  " + PriWhere, PriConStr);
        //            }
        //            else
        //            {
        //                //�ع�����
        //                ClsMsgBox.Ts("ɾ��ʧ�ܣ�", ObjG.CustomMsgBox, this);
        //                trans.Rollback();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            //�ع�����
        //            try
        //            {
        //                ClsMsgBox.Cw("ɾ���쳣��", ex, ObjG.CustomMsgBox, this);
        //                trans.Rollback();
        //            }
        //            catch (SqlException ex1)
        //            {
        //                if (trans.Connection != null)
        //                    ClsMsgBox.Cw("�ع�ʧ��! �쳣����:" + ex1.GetType(), ex1, ObjG.CustomMsgBox, this);
        //            }
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //}
        //#endregion
        private void GetDataYdmx()
        {
            PriData.Clear();
            List<int> ListPCid = new List<int>();
            for (int i = 0; i < Dgv.RowCount; i++)
            {
                int aPcid = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtId"].Value);
                ListPCid.Add(aPcid);
            }
            PriData = ClsRWMSSQLDb.GetDataTable(" SELECT [inssj],[sldqmc],[sljgmc],[zddqmc],[zdjgmc],[fhlxr],[dhlxr],[bh],[dsk],[sfje],[jfsf],[dskffcgsj],[fwkh],[dslxmc],[qssj],[qsr],[zjlxmc],[qsrzjh],[dlqsr],[dlqsrzjlxmc],[dlqsrzjh],[zdsj],[shsj] FROM  [Vfmsdskycydmx] where pcid in (" + string.Join(",", ListPCid) + ")", PriConStr);
        }
        private int GetPcid()
        {
            int apcid = 0;
            DataRow dr = ClsRWMSSQLDb.GetDataRow(" select pcid from Vfmsdskrbxx where bh='" + Txthydh.Text.Trim().ToString() + "' ", ClsGlobals.CntStrTMS);
            if (dr != null)
            {
                int n;
                if (Int32.TryParse(dr[0].ToString(), out n))
                {
                    apcid = Convert.ToInt32(dr[0]);
                }
            }
            return apcid;
        }
    }
}
