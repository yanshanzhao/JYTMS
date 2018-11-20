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
        #region ��Ա����
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
        #region ��ʼ������
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            VfmswydskffTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            Vfmswydskffmx_zxhwTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            //DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable(" select 0 as id,'--ȫ��--' as jc union all select id,jc from tyhlx where  hdzt='Y' and id in(63,64,241)  ", ClsGlobals.CntStrTMS);
            //ClsPopulateCmbDsS.PopuByTb(this.CmbYhlx, dtYhlx, "id", "jc");
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable("select 'all' as bh,'--ȫ��--' as mc union all select bh,mc from Tfmsdskffyhlx where zt=1  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbYhlx, dtYhlx, "bh", "mc");
            DataTable DtDcfs = ClsRWMSSQLDb.GetDataTable("select 'default' as bh,'--Ĭ��--' as mc union all select bh,mc from Tfmsdskffyhlx where zt=1  ", ClsGlobals.CntStrTMS);
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
        #region ��ѯ
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
                    ClsMsgBox.Ts("û�в�ѯ����Ӧ��Ϣ����˶Բ�ѯ������", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ��Ϣʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion

        #region �����¼�
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("��ϸ��Ϣ"))
            {
                f = new FrmWYDSKFFMX();
                f.Prepare(Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtId.Name].Value));
                f.ShowDialog();
            }
            if (Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("���"))
            {
                args = e;
                DSWYDSKFF.VfmswydskffRow row = (Dgv.Rows[e.RowIndex].DataBoundItem as DataRowView
                    ).Row as DSWYDSKFF.VfmswydskffRow;
                if (row.IsffcsNull() == true || row.ffcs == 0)
                {
                    dk();
                }
                else
                    ClsMsgBox.DKYesNo(string.Format("��{0}�δ�ȷ��Ҫ�����ظ����ô��", row.ffcs + 1)
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
                    ClsMsgBox.Cw("���·���״̬ʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
                    return;
                }
            }
            //if (Dgv.Rows[args.RowIndex].Cells[DgvColTxtYhlxid.Name].Value.ToString().Equals("241"))//ũ��
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
            //else if (Dgv.Rows[args.RowIndex].Cells[DgvColTxtYhlxid.Name].Value.ToString().Equals("63"))//����
            //{
            //    if (CmbDcgs.Text == "Ĭ��" || CmbDcgs.Text == "��������")
            //        JH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            //    else if (CmbDcgs.Text == "ũҵ����")
            //        NH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            //    else if (CmbDcgs.Text == "��³���У����ڣ�")
            //        QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "N");
            //    else if (CmbDcgs.Text == "��³���У����⣩")
            //        QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "W");
            //}
            //else if (Dgv.Rows[args.RowIndex].Cells[DgvColTxtYhlxid.Name].Value.ToString().Equals("64") && Dgv.Rows[args.RowIndex].Cells[DgvColTxtFkfs.Name].Value.ToString().Equals("10"))
            //{
            //    if (CmbDcgs.Text == "Ĭ��" || CmbDcgs.Text == "��³���У����ڣ�")
            //        QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "N");//��³����
            //    else if (CmbDcgs.Text == "��������")
            //        JH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            //    else if (CmbDcgs.Text == "ũҵ����")
            //        NH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            //    else if (CmbDcgs.Text == "��³���У����⣩")
            //        QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "W");
            //}
            //else
            //{
            //    if (CmbDcgs.Text == "Ĭ��" || CmbDcgs.Text == "��³���У����⣩")
            //        QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "W"); //��³����
            //    else if (CmbDcgs.Text == "��������")
            //        JH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            //    else if (CmbDcgs.Text == "ũҵ����")
            //        NH(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value));
            //    else if (CmbDcgs.Text == "��³���У����ڣ�")
            //        QL(Convert.ToInt32(Dgv.Rows[args.RowIndex].Cells[DgvColTxtId.Name].Value), "N");
            //}
            VfmswydskffTableAdapter1.FillByWhere(DSwydskff1.Vfmswydskff, PriWhere);
            SetXh();
        }
        #endregion

        #region ������������
        private void JH(int aPcid)
        {
            VfmswydskffmxTableAdapter1.FillByPcid(DSwydskff1.Vfmswydskffmx, aPcid);
            string PriFln = "�ܲ����д��տ����ϸ" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ� 
            //д������
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
                ClsMsgBox.Cw("�����ܲ����д��տ������Excelʧ�ܣ�", ex);
                return;
            }
            finally
            {
                VfmswydskffmxTableAdapter1.Dispose();
            }

        }
        #endregion

        #region ��³������������
        private void QL(int aPcid, string aType)
        {
            PriYhzh = ClsRWMSSQLDb.GetStr("  select zh from tfmsyhzh  where zhlxid=60 and zt=0 and yhlxid=64 and jgid=" + ObjG.Jigou.id, ClsGlobals.CntStrTMS);
            VfmswydskffmxTableAdapter1.FillByPcid(DSwydskff1.Vfmswydskffmx, aPcid);

            string PriFln = "�ܲ���³������������" + (Convert.ToBoolean(aType.Equals("N")) ? "�����ڣ�" : "(����)") + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
            //д������
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.DefaultColumnWidth = 17;
            try
            {
                //�����ĵ�����
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                LieFont.FontHeightInPoints = 10;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.SetFont(LieFont);
                row0.CreateCell(0).SetCellValue("ת������");
                row0.CreateCell(1).SetCellValue("�����˺�");
                row0.CreateCell(2).SetCellValue("�տ��˺�");
                row0.CreateCell(3).SetCellValue("�տ��˻���");
                row0.CreateCell(4).SetCellValue("���׽��");
                row0.CreateCell(5).SetCellValue("���к�");
                row0.CreateCell(6).SetCellValue("ԤԼת��");
                row0.CreateCell(7).SetCellValue("ԤԼʱ��");
                row0.CreateCell(8).SetCellValue("��;");
                int roowIndex = 1;
                //�������
                foreach (DSWYDSKFF.VfmswydskffmxRow Row in DSwydskff1.Vfmswydskffmx.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    if (aType == "N")
                        hssfrow.CreateCell(0).SetCellValue("����");
                    else
                        hssfrow.CreateCell(0).SetCellValue("����");
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
                    hssfrow.CreateCell(8).SetCellValue("��������");
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
                return;
            }

        }
        #endregion

        #region ũ����������
        private void NH(int aPcid)
        {
            VfmswydskffmxTableAdapter1.FillByPcid(DSwydskff1.Vfmswydskffmx, aPcid);
            try
            {
                string PriFln = "�д��տ��" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";//�ļ�����     
                string path = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
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
                    str += "��������" + bh;
                    str += "\r\n";
                    PriNo++;

                }
                str = str.Substring(0, str.LastIndexOf("\r\n"));
                sw.WriteLine(str);//Ҫд�����Ϣ�� 
                ctrlDownLoad1.download(path, true);
                sw.Close();
                fs1.Close();
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("������Ϣʧ��", ex);
                return;
            }
            finally
            {
                VfmswydskffmxTableAdapter1.Dispose();
            }

        }
        #endregion

        #region �������������������ڣ�
        private void ZXHN(int aPcid)
        {
            VfmswydskffmxTableAdapter1.FillByPcid(DSwydskff1.Vfmswydskffmx, aPcid);

            string PriFln = "�ܲ��������������������ڣ�" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
            //д������
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.DefaultColumnWidth = 17;
            try
            {
                //�����ĵ�����
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                LieFont.FontHeightInPoints = 10;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.SetFont(LieFont);
                row0.CreateCell(0).SetCellValue("Ա�����");
                row0.CreateCell(1).SetCellValue("Ա���˺�");
                row0.CreateCell(2).SetCellValue("Ա������");
                row0.CreateCell(3).SetCellValue("֧�����");
                row0.CreateCell(4).SetCellValue("����");
                int roowIndex = 1;
                //�������
                foreach (DSWYDSKFF.VfmswydskffmxRow Row in DSwydskff1.Vfmswydskffmx.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    //����Ա�����
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
                            hssfrow.CreateCell(4).SetCellValue("�����");
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
                return;
            }

        }
        #endregion

        #region �������������������⣩
        private void ZXHW(int aPcid)
        {
            Vfmswydskffmx_zxhwTableAdapter1.FillByPcid(DSwydskff1.Vfmswydskffmx_zxhw, aPcid);
            string PriFln = "�ܲ��������������������⣩" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
            //д������
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.DefaultColumnWidth = 17;
            try
            {
                //�����ĵ�����
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                hssfworkbook.CreateDataFormat();
                LieFont.FontHeightInPoints = 10;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.SetFont(LieFont);
                row0.CreateCell(0).SetCellValue("���");
                row0.CreateCell(1).SetCellValue("����ʱ��");
                row0.CreateCell(2).SetCellValue("�������");
                row0.CreateCell(3).SetCellValue("�������");
                row0.CreateCell(4).SetCellValue("�������");
                row0.CreateCell(5).SetCellValue("����վ");
                row0.CreateCell(6).SetCellValue("���˱��");
                row0.CreateCell(7).SetCellValue("���񿨺�");
                row0.CreateCell(8).SetCellValue("�ֿ���");
                row0.CreateCell(9).SetCellValue("������");
                row0.CreateCell(10).SetCellValue("�����˺�");
                row0.CreateCell(11).SetCellValue("֧����ʽ");
                row0.CreateCell(12).SetCellValue("���տ���");
                row0.CreateCell(13).SetCellValue("ʵ�����");
                row0.CreateCell(14).SetCellValue("������");
                row0.CreateCell(15).SetCellValue("ϵͳ��������");

                int roowIndex = 1;
                //�������
                foreach (DSWYDSKFF.Vfmswydskffmx_zxhwRow Row in DSwydskff1.Vfmswydskffmx_zxhw.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    //����Ա�����
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
                ClsMsgBox.Cw("����Excelʧ��", ex);
                return;
            }

        }
        #endregion
        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 1, 2, 3, 4 };
            ClsExcel.CreatExcel(Dgv, "���տ���������", this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, "���տ���������", this.ctrlDownLoad1);
        }
        #endregion



    }
}





