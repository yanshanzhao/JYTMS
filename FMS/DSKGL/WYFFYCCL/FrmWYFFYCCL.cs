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
using JY.Pub;
using JYPubFiles.Classes;
using System.Data.SqlClient;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Configuration;

#endregion

namespace FMS.DSKGL.WYFFYCCL
{
    public partial class FrmWYFFYCCL : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private string PriWhere;
        private string Priffzt;
        private int PriRowCout;
        private decimal PriZje;
        private decimal PriZje1;
        private List<string> LstSQL = new List<string>();
        private DataTable PriDt;
        private bool flag;
        private int RowIndex;
        //private List<int> LstId = new List<int>();
        //private List<int> LstNotDel = new List<int>();
        #endregion
        #region �쳣ԭ��
        private List<ClsBhMcByte> PriLstYcyy = new List<ClsBhMcByte>();
        public class ClsBhMcByte
        {
            public ClsBhMcByte(string abh, string amc)
            {
                Bh = abh;
                Mc = amc;
            }
            public string Bh { get; set; }
            public string Mc { get; set; }
            public string Bh_Mc
            {
                get
                {
                    return Bh + ":" + Mc;
                }
            }
        }
        #endregion
        public FrmWYFFYCCL()
        {
            InitializeComponent();
            PriLstYcyy.Add(new ClsBhMcByte("K", "����"));
            PriLstYcyy.Add(new ClsBhMcByte("Z", "�˺Ŵ���"));
            PriLstYcyy.Add(new ClsBhMcByte("X", "�ͻ���������"));
            PriLstYcyy.Add(new ClsBhMcByte("H", "�����д���"));
            PriLstYcyy.Add(new ClsBhMcByte("Q", "����"));
            this.DgvCmb.DataSource = PriLstYcyy;
            DgvCmb.DisplayMember = "mc";
            DgvCmb.ValueMember = "bh";
        }
        #region ��ʼ������
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            //DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable(" select 0 as id,'ȫ��' as jc  union  select id,jc from tyhlx where  hdzt='Y' and id in(63,64,241)  ", ClsGlobals.CntStrTMS);
            //ClsPopulateCmbDsS.PopuByTb(this.CmbYhlx, dtYhlx, "id", "jc");
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable("select 'all' as bh,'--ȫ��--' as mc union all select bh,mc from Tfmsdskffyhlx where zt=1  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbYhlx, dtYhlx, "bh", "mc");
            ClsPopulateCmbDsS.PopuFMSDSKZZ_dszl(CmbDSZL);
            CmbYhlx.SelectedIndex = 0;
            CmbZt.SelectedIndex = 0;
            CmbDSZL.SelectedIndex = 0;
        }
        #endregion
        #region ��ѯ
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            //TimeSpan ts = DtpStop.Value - DtpStart.Value;
            //if (ts.Days > 7 || ts.Days < -7)
            //{
            //    ClsMsgBox.Ts("��ѯ�������ܳ������죡", ObjG.CustomMsgBox, this);
            //    Dgv.DataSource = "";
            //    return;
            //}
            if (!DtpUpdsjJ.Checked && !DtpUpdsjK.Checked)
            {
                if (string.IsNullOrEmpty(this.TxtBh.Text.Trim().ToString()) && string.IsNullOrEmpty(this.TxtFwkh.Text.Trim().ToString()) && string.IsNullOrEmpty(this.TxtYhzh.Text.Trim().ToString()) && string.IsNullOrEmpty(this.TxtKhmc.Text.Trim().ToString()))
                {
                    ClsMsgBox.Ts("���񿨺š����˵��š��ͻ����ơ������޸�ʱ��������˺�������дһ����", ObjG.CustomMsgBox, this);
                    return;
                }
            }
            try
            {
                Clear();
                ClsD.TextBoxTrim(this);


                PriWhere = "";
               
                if (DtpStart.Checked)
                    PriWhere += " and ffsj>='" + DtpStart.Value.Date + "'";
                if (DtpStop.Checked)
                    PriWhere += " and ffsj <'" + DtpStop.Value.AddDays(1).Date + "'";
                PriWhere += DtpUpdsjK.Checked ? " and updsj>='" + DtpUpdsjK.Value.Date + "'" : "";
                PriWhere += DtpUpdsjJ.Checked ? " and updsj<'" + DtpUpdsjJ.Value.Date.AddDays(1) + "'" : "";
                PriWhere+=Convert.ToInt32(CmbZt.SelectedIndex) == 0 ? " and (zt=20 or zt=10)" : " and zt=0 ";
                PriWhere += string.IsNullOrEmpty(TxtBh.Text) ? "" : " and bh like '" + TxtBh.Text + "'";
                PriWhere += string.IsNullOrEmpty(TxtFwkh.Text) ? "" : " and fwkh like '" + TxtFwkh.Text + "'";
                PriWhere += string.IsNullOrEmpty(TxtYhzh.Text) ? "" : " and yhzh = '" + TxtYhzh.Text + "'";
                PriWhere += string.IsNullOrEmpty(TxtKhmc.Text) ? "" : " and mc like '" + TxtKhmc.Text + "'";
                PriWhere += CmbDSZL.SelectedIndex == 0 ? "" : " and lx='" + CmbDSZL.SelectedValue + "'";
                //PriWhere += Convert.ToInt32(CmbYhlx.SelectedValue) == 0 ? "" : Convert.ToInt32(CmbYhlx.SelectedValue) == 64 ? " and yhid not in(63,241)" : " and yhid=" + CmbYhlx.SelectedValue;
                PriWhere += CmbYhlx.SelectedValue.Equals("all") ? "" : " and ffyhlx ='" + CmbYhlx.SelectedValue + "'";
                //PriWhere += " and ffsj between '" + DtpStart.Value + "' and dateadd(d,1,'" + DtpStop.Value + "')";
                PriWhere=PriWhere.Trim();
                if (PriWhere.Length > 0)
                    PriWhere =" where " +PriWhere.Remove(0, 3);
                Priffzt = CmbZt.Text.ToString();
                PriDt = ClsRWMSSQLDb.GetDataTable("select *,'ɾ��' as cz from Vfmswyffyccl " + PriWhere, ClsGlobals.CntStrTMS);
                Dgv.DataSource = PriDt;
                if (Priffzt == "���ųɹ�")
                {
                    Dgv.Columns[DgvColTxtTzjl.Name].ReadOnly = true;
                    Dgv.Columns[DgvCmb.Name].ReadOnly = false;
                }
                else if (Priffzt == "�����쳣")
                {
                    Dgv.Columns[DgvColTxtTzjl.Name].ReadOnly = false;
                    Dgv.Columns[DgvCmb.Name].ReadOnly = true;
                }
                //PriDt = ClsRWMSSQLDb.GetDataTable("select * from Vfmswyffyccl1 "+PriWhere,ClsGlobals.CntStrTMS);;
                if (Dgv.Rows.Count == 0)
                {
                    ClsMsgBox.Ts("�޲�ѯ��Ϣ����˶Բ�ѯ������", ObjG.CustomMsgBox, this);
                    return;
                }

            }
            catch
            {
                ClsMsgBox.Cw("��ѯ��Ϣʧ�ܣ������²�ѯ��", ObjG.CustomMsgBox, this);
                Clear();
            }
        }
        #endregion
        #region ����ѡ��
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (string.IsNullOrEmpty(Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvCmb.Name].Value)))
                {
                    if (string.IsNullOrEmpty(Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYcxx.Name].Value)))
                    {
                        ClsMsgBox.Ts("��ѡ���쳣ԭ��", ObjG.CustomMsgBox, this);
                        return;
                    }
                }
                if (!Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    PriRowCout++;
                    PriZje += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtJe.Name].Value);
                }
                else
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    PriRowCout--;
                    PriZje -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtJe.Name].Value);
                }
                LblCheckCount.Text = "��ѡ��" + PriRowCout + "�ʣ��ܽ��" + PriZje + "Ԫ";
            }
            if (e.RowIndex >= 0 && Dgv.Columns[e.ColumnIndex].Name.Equals("DgvColLnk"))
            {
                if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtLx1.Name].Value) == "2")
                {
                    RowIndex = e.RowIndex;
                    ClsMsgBox.YesNo("ȷ��ɾ��������Ϣ��", new EventHandler(Delete), ObjG.CustomMsgBox, this);
                }
                else
                {
                    ClsMsgBox.Ts("���˵�������ɾ����", ObjG.CustomMsgBox, this);
                }
            }

        }
        #endregion
        private void Delete(object sender, EventArgs e)
        {
            Form f = sender as Form;
            FrmMsgBox frm = new FrmMsgBox();
            if (f.DialogResult == DialogResult.Yes)
            {
                try
                {
                    ClsRWMSSQLDb.ExecuteCmd("delete tfmsdskffyc where id=" + Dgv.Rows[RowIndex].Cells[DgvColTxtId.Name].Value, ClsGlobals.CntStrTMS);
                    ClsMsgBox.Ts("ɾ���ɹ���", frm, this);
                    PriDt = ClsRWMSSQLDb.GetDataTable("select *,'ɾ��' as cz from Vfmswyffyccl1 " + PriWhere, ClsGlobals.CntStrTMS);
                    Dgv.DataSource = PriDt;
                    //Dgv.Rows.Remove(Dgv.Rows[RowIndex]);
                    Clear();
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("ɾ��ʧ�ܣ�", ex, frm, this);
                }
            }
        }
        #region �쳣
        private void BtnYc_Click(object sender, EventArgs e)
        {
            if (PriRowCout == 0)
            {
                ClsMsgBox.Ts("��ѡ������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            if (Priffzt == "�����쳣")
            {
                ClsMsgBox.Ts("�����ϢΪ�쳣��Ϣ�������ٽ����쳣����", ObjG.CustomMsgBox, this);
                return;
            }
            //if (CmbYcyy.SelectedIndex == -1)
            //{
            //    ClsMsgBox.Ts("�����ϢΪ�쳣��Ϣ��ԭ��", ObjG.CustomMsgBox, this);
            //    return;
            //}
            ClsMsgBox.YesNo("ȷ�Ͻ�ѡ�еķ�����Ϣ���Ϊ�����쳣��", new EventHandler(SaveMessage), ObjG.CustomMsgBox, this);
        }
        private void SaveMessage(object sender, EventArgs e)
        {
            FrmMsgBox frm = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {

                try
                {
                    InsertMx();
                    if (PriZje != PriZje1)
                    {
                        ClsMsgBox.Ts("����쳣��Ϣʧ�ܣ�", frm, this);
                        return;
                    }
                    ClsRWMSSQLDb.ExecuteCmd(string.Join(";", LstSQL), ClsGlobals.CntStrTMS);
                    ClsMsgBox.Ts("�����Ϣ�ɹ���", frm, this);
                    PriDt = ClsRWMSSQLDb.GetDataTable("select *,'ɾ��' as cz from Vfmswyffyccl1 " + PriWhere, ClsGlobals.CntStrTMS);
                    Dgv.DataSource = PriDt;
                    Clear();
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("����쳣��Ϣʧ�ܣ�", ex, frm, this);
                }
            }
        }
        private void InsertMx()
        {
            //��ע��K-����,Z-�˺Ŵ���,X-�ͻ���������,H-�����д���,Q-����
            //string aBz = "";
            //if (CmbYcyy.Text == "����") 
            //    aBz = "K";
            //else if (CmbYcyy.Text == "�˺Ŵ���")
            //    aBz = "Z";
            //else if (CmbYcyy.Text == "�ͻ���������")
            //    aBz = "X";
            //else if (CmbYcyy.Text == "�����д���")
            //    aBz = "H";
            //else
            //    aBz = "Q";
            LstSQL.Clear();
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvColTxtChk.Name].Value))
                {

                    PriZje1 += Convert.ToDecimal(row.Cells[DgvColTxtJe.Name].Value);
                    LstSQL.Add(string.Format("Insert into Tfmsdskffyc (mxid,dskid,je,zt,inssj,insczyxm,insczyzh,insczyid,fflx,bz)" +
                        " values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}')", row.Cells[DgvColTxtMxid.Name].Value, row.Cells[DgvColTxtDskId.Name].Value,
                        row.Cells[DgvColTxtJe.Name].Value, 0, "getdate()", ObjG.Renyuan.xm, ObjG.Renyuan.loginName, ObjG.Renyuan.id, row.Cells[DgvColTxtFflx.Name].Value, row.Cells[DgvCmb.Name].Value));
                }
            }
        }
        #endregion
        #region Clear() ҳ����ʾ
        private void Clear()
        {
            PriRowCout = 0;
            PriZje = 0;
            PriZje1 = 0;
            LblCheckCount.Text = "��ѡ��" + PriRowCout + "�ʣ��ܽ��" + PriZje + "Ԫ";
            RowIndex = -2;
        }
        #endregion
        #region ����
        private void BtnFf_Click(object sender, EventArgs e)
        {
            if (PriRowCout == 0)
            {
                ClsMsgBox.Ts("��ѡ������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }

            if (Priffzt == "���ųɹ�")
            {
                ClsMsgBox.Ts("�����ϢΪ���ųɹ���Ϣ�������ٽ��з��Ŵ���", ObjG.CustomMsgBox, this);
                return;
            }
            ClsMsgBox.YesNo("ȷ�Ͻ�ѡ�еķ����쳣��Ϣ���Ϊ�ѷ��ţ�", new EventHandler(SaveMessage1), ObjG.CustomMsgBox, this);
        }
        private void SaveMessage1(object sender, EventArgs e)
        {
            FrmMsgBox frm = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {
                if (PriRowCout == 0)
                {
                    ClsMsgBox.Ts("��ѡ��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                    return;
                }
                int[] CellIndex = new int[] { 10, 11, 12 };
                #region  ����
                string PriFln = "���տ���쳣����" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
                string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
                HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
                //д������
                HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
                sheet1.DefaultColumnWidth = 17;
                try
                {
                    InsertFfmx();
                    if (PriZje != PriZje1)
                    {
                        ClsMsgBox.Ts("����쳣��Ϣʧ�ܣ�", frm, this);
                        return;
                    }
                    //����
                    //�����ĵ�����
                    HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                    HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                    LieFont.FontHeightInPoints = 10;
                    LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                    styleRow.SetFont(LieFont);
                    HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                    int n = 0;//Dgv�е������еĸ���
                    for (int i = 0; i < Dgv.ColumnCount; i++)
                    {
                        if (Dgv[i, 0].Visible)
                        {
                            if (Dgv[i, 0].GetType().Name == "DataGridViewCheckBoxCell")
                            {
                                n = n + 1;
                                continue;
                            }
                            //if (Dgv[i, 0].GetType().Name == "DataGridViewComboBoxCell")
                            //{
                            //    n = n + 1;
                            //    continue;
                            //}
                            if (Dgv[i, 0].GetType().Name == "DataGridViewImageCell")
                            {
                                n = n + 1;
                                continue;
                            }
                            if (Dgv[i, 0].GetType().Name == "DataGridViewButtonCell")
                            {
                                n = n + 1;
                                continue;
                            }
                            if (Dgv[i, 0].GetType().Name == "DataGridViewLinkCell")
                            {
                                n = n + 1;
                                continue;
                            }
                            if (Dgv[i, 0].GetType().Name == "DataGridViewMaskedTextBoxCell")
                            {
                                n = n + 1;
                                continue;
                            }
                            row0.CreateCell(i - n).SetCellValue(Dgv.Columns[i].HeaderText);
                            row0.Cells[i - n].CellStyle = styleRow;
                        }
                        else
                            n = n + 1;
                    }
                    int roowIndex = 1;
                    //�������
                    foreach (DataGridViewRow Row in Dgv.Rows)
                    {
                        HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                        int m = 0;//Dgv�е������еĸ���
                        if (Convert.ToBoolean(Row.Cells[DgvColTxtChk.Name].Value))
                        {
                            for (int i = 0; i < Dgv.ColumnCount; i++)
                            {
                                if (Dgv[i, 0].Visible)
                                {
                                    if (Dgv[i, 0].GetType().Name == "DataGridViewCheckBoxCell")
                                    {
                                        m = m + 1;
                                        continue;
                                    }
                                    //if (Dgv[i, 0].GetType().Name == "DataGridViewComboBoxCell")
                                    //{
                                    //    m = m + 1;
                                    //    continue;
                                    //}
                                    if (Dgv[i, 0].GetType().Name == "DataGridViewImageCell")
                                    {
                                        m = m + 1;
                                        continue;
                                    }
                                    if (Dgv[i, 0].GetType().Name == "DataGridViewButtonCell")
                                    {
                                        m = m + 1;
                                        continue;
                                    }
                                    if (Dgv[i, 0].GetType().Name == "DataGridViewLinkCell")
                                    {
                                        m = m + 1;
                                        continue;
                                    }
                                    if (Dgv[i, 0].GetType().Name == "DataGridViewMaskedTextBoxCell")
                                    {
                                        m = m + 1;
                                        continue;
                                    }
                                    //�ж��Ƿ������ָ�ʽ����
                                    //if (LstCellIndex.Contains(i - m))
                                    //if()
                                    //{
                                    //    hssfrow.CreateCell(i - m).SetCellValue(Convert.ToDouble(Row.Cells[i].Value));
                                    //    hssfrow.Cells[i - m].CellStyle = cellStyle;
                                    //}
                                    //else
                                    if (Dgv[i, 0].GetType().Name == "DataGridViewComboBoxCell")
                                    {
                                        string ycxx = Row.Cells[i].EditedFormattedValue.ToString();
                                        //string ycxx = Row.Cells[i].FormattedValue.ToString(); 
                                        hssfrow.CreateCell(i - m).SetCellValue(ycxx);
                                    }
                                    else
                                    {
                                        if (CellIndex.ToList().Contains(i))
                                        {
                                            double j;
                                            if (double.TryParse(Convert.ToString(Row.Cells[i].Value), out j))
                                            {
                                                hssfrow.CreateCell(i - m).SetCellValue(Convert.ToDouble(Row.Cells[i].Value));
                                                hssfrow.Cells[i - m].CellStyle = cellStyle;
                                            }
                                            else
                                            {
                                                hssfrow.CreateCell(i - m).SetCellValue(Convert.ToString(Row.Cells[i].Value));
                                            }
                                        }
                                        else
                                            hssfrow.CreateCell(i - m).SetCellValue(Convert.ToString(Row.Cells[i].Value));
                                    }


                                }
                                else
                                    m = m + 1;
                            }
                            roowIndex++;
                        }

                    }
                    //if (roowIndex == 1)
                    //{
                    //    ClsMsgBox.Ts("��ѡ��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                    //    return;
                    //}
                    FileStream file = new FileStream(PriFlp, FileMode.Create);
                    hssfworkbook.Write(file);
                    file.Close();
                    //DownLoad.download(PriFlp, true);
                    this.ctrlDownLoad1.download(PriFlp, true);
                #endregion
                    ClsRWMSSQLDb.ExecuteCmd(string.Join(";", LstSQL), ClsGlobals.CntStrTMS);
                    //ClsMsgBox.Ts("�����Ϣ�ɹ���", frm, this);
                    PriDt = ClsRWMSSQLDb.GetDataTable("select *,'ɾ��' as cz from Vfmswyffyccl1 " + PriWhere, ClsGlobals.CntStrTMS);
                    Dgv.DataSource = PriDt;
                    Clear();
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("����쳣��Ϣʧ�ܣ�", ex, frm, this);
                }
            }
        }
        private void InsertFfmx()
        {
            LstSQL.Clear();

            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvColTxtChk.Name].Value))
                {
                    PriZje1 += Convert.ToDecimal(row.Cells[DgvColTxtJe.Name].Value);
                    LstSQL.Add(string.Format("Insert into Tfmsdskffyc (mxid,dskid,je,zt,inssj,insczyxm,insczyzh,insczyid,fflx)" +
                        " values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}')", row.Cells[DgvColTxtMxid.Name].Value, row.Cells[DgvColTxtDskId.Name].Value,
                        row.Cells[DgvColTxtJe.Name].Value, 10, "getdate()", ObjG.Renyuan.xm, ObjG.Renyuan.loginName, ObjG.Renyuan.id, 20));
                }
            }
        }
        #endregion
        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            //if (Dgv.RowCount == 0)
            //{
            //    ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //int[] Rows = new int[] { 8 };
            //ClsExcel.CreatExcel(Dgv, "���տ���쳣����", this.ctrlDownLoad1, Rows);
            GetExl(new int[] { 10, 11, 12 });
        }
        private void GetExl(int[] aCellIndex = null)
        {
            List<int> LstCellIndex = new List<int>();
            if (aCellIndex != null)
            {
                if (aCellIndex.Length != 0)
                    LstCellIndex.AddRange(aCellIndex);
            }
            //int[] LstCellIndex = new int[] { 8 };
            if (PriRowCout == 0)
            {
                ClsMsgBox.Ts("��ѡ��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "���տ���쳣����" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
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
                int n = 0;//Dgv�е������еĸ���
                for (int i = 0; i < Dgv.ColumnCount; i++)
                {
                    if (Dgv[i, 0].Visible)
                    {
                        if (Dgv[i, 0].GetType().Name == "DataGridViewCheckBoxCell")
                        {
                            n = n + 1;
                            continue;
                        }
                        //if (Dgv[i, 0].GetType().Name == "DataGridViewComboBoxCell")
                        //{
                        //    n = n + 1;
                        //    continue;
                        //}
                        if (Dgv[i, 0].GetType().Name == "DataGridViewImageCell")
                        {
                            n = n + 1;
                            continue;
                        }
                        if (Dgv[i, 0].GetType().Name == "DataGridViewButtonCell")
                        {
                            n = n + 1;
                            continue;
                        }
                        if (Dgv[i, 0].GetType().Name == "DataGridViewLinkCell")
                        {
                            n = n + 1;
                            continue;
                        }
                        if (Dgv[i, 0].GetType().Name == "DataGridViewMaskedTextBoxCell")
                        {
                            n = n + 1;
                            continue;
                        }
                        row0.CreateCell(i - n).SetCellValue(Dgv.Columns[i].HeaderText);
                        row0.Cells[i - n].CellStyle = styleRow;
                    }
                    else
                        n = n + 1;
                }
                int roowIndex = 1;
                //�������
                foreach (DataGridViewRow Row in Dgv.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    int m = 0;//Dgv�е������еĸ���
                    if (Convert.ToBoolean(Row.Cells[DgvColTxtChk.Name].Value))
                    {
                        for (int i = 0; i < Dgv.ColumnCount; i++)
                        {
                            if (Dgv[i, 0].Visible)
                            {
                                if (Dgv[i, 0].GetType().Name == "DataGridViewCheckBoxCell")
                                {
                                    m = m + 1;
                                    continue;
                                }
                                //if (Dgv[i, 0].GetType().Name == "DataGridViewComboBoxCell")
                                //{
                                //    m = m + 1;
                                //    continue;
                                //}
                                if (Dgv[i, 0].GetType().Name == "DataGridViewImageCell")
                                {
                                    m = m + 1;
                                    continue;
                                }
                                if (Dgv[i, 0].GetType().Name == "DataGridViewButtonCell")
                                {
                                    m = m + 1;
                                    continue;
                                }
                                if (Dgv[i, 0].GetType().Name == "DataGridViewLinkCell")
                                {
                                    m = m + 1;
                                    continue;
                                }
                                if (Dgv[i, 0].GetType().Name == "DataGridViewMaskedTextBoxCell")
                                {
                                    m = m + 1;
                                    continue;
                                }
                                //�ж��Ƿ������ָ�ʽ����
                                //if (LstCellIndex.Contains(i - m))
                                //if()
                                //{
                                //    hssfrow.CreateCell(i - m).SetCellValue(Convert.ToDouble(Row.Cells[i].Value));
                                //    hssfrow.Cells[i - m].CellStyle = cellStyle;
                                //}
                                //else
                                if (Dgv[i, 0].GetType().Name == "DataGridViewComboBoxCell")
                                {
                                    string ycxx = Row.Cells[i].EditedFormattedValue.ToString();
                                    //string ycxx = Row.Cells[i].FormattedValue.ToString(); 
                                    hssfrow.CreateCell(i - m).SetCellValue(ycxx);
                                }
                                else
                                {
                                    if (LstCellIndex.Contains(i))
                                    {
                                        double j;
                                        if (double.TryParse(Convert.ToString(Row.Cells[i].Value), out j))
                                        {
                                            hssfrow.CreateCell(i - m).SetCellValue(Convert.ToDouble(Row.Cells[i].Value));
                                            hssfrow.Cells[i - m].CellStyle = cellStyle;
                                        }
                                        else
                                        {
                                            hssfrow.CreateCell(i - m).SetCellValue(Convert.ToString(Row.Cells[i].Value));
                                        }
                                    }
                                    else
                                        hssfrow.CreateCell(i - m).SetCellValue(Convert.ToString(Row.Cells[i].Value));

                                }

                            }
                            else
                                m = m + 1;
                        }
                        roowIndex++;
                    }

                }
                //if (roowIndex == 1)
                //{
                //    ClsMsgBox.Ts("��ѡ��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                //    return;
                //}
                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
                //DownLoad.download(PriFlp, true);
                this.ctrlDownLoad1.download(PriFlp, true);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("����Excelʧ��", ex);
            }
        }
        #endregion
        #region  ����֪ͨ��¼
        private void Dgv_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (!flag)
                return;
            Dgv.EndEdit();
            DataRow dr = ((DataRowView)Dgv.CurrentRow.DataBoundItem).Row as DataRow;
            dr.EndEdit();
            if (Priffzt == "�����쳣")
            {
                if (dr.RowState == DataRowState.Modified)
                {
                    try
                    {
                        ClsRWMSSQLDb.ExecuteCmd("Update tfmsdskffyc set tzjl='" + PriDt.Rows[0]["tzjl"] + "' where id=" + PriDt.Rows[0]["id"], ClsGlobals.CntStrTMS);
                    }
                    catch (Exception ex)
                    {
                        ClsMsgBox.Cw("��¼֪ͨʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
                    }
                }
            }

        }
        private void Dgv_LostFocus(object sender, EventArgs e)
        {
            flag = false;
            if (Dgv.Rows.Count <= 0)
                return;
            Dgv.EndEdit();
            DataRow dr = ((DataRowView)Dgv.CurrentRow.DataBoundItem).Row as DataRow;
            dr.EndEdit();
            if (Priffzt == "�����쳣")
            {
                if (dr.RowState == DataRowState.Modified)
                {
                    try
                    {
                        ClsRWMSSQLDb.ExecuteCmd("Update tfmsdskffyc set tzjl='" + PriDt.Rows[0]["tzjl"] + "' where id=" + PriDt.Rows[0]["id"], ClsGlobals.CntStrTMS);
                    }
                    catch (Exception ex)
                    {
                        ClsMsgBox.Cw("��¼֪ͨʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
                    }
                }
            }
        }
        private void Dgv_GotFocus(object sender, EventArgs e)
        {
            flag = true;
        }
        #endregion

        //private void Delete(object sender, EventArgs e)
        //{
        //    Form f = sender as Form;
        //    FrmMsgBox frm = new FrmMsgBox();
        //    if (f.DialogResult == DialogResult.Yes)
        //    {
        //        LstId.Clear();
        //        LstNotDel.Clear();
        //        foreach (DataGridViewRow row in Dgv.Rows)
        //        {
        //            if (Convert.ToBoolean(row.Cells[DgvColTxtChk.Name].Value) && Convert.ToString(row.Cells[DgvColTxtLx1.Name].Value) == "2")
        //                LstId.Add(Convert.ToInt32(row.Cells[DgvColTxtId.Name].Value));
        //            else if (Convert.ToBoolean(row.Cells[DgvColTxtChk.Name].Value) && Convert.ToString(row.Cells[DgvColTxtLx1.Name].Value) == "1")
        //                LstNotDel.Add(Convert.ToInt32(row.Cells[DgvColTxtId.Name].Value));
        //        }
        //        if (LstId.Count > 0)
        //            ClsRWMSSQLDb.ExecuteCmd("delete tfmsdskffyc where id in(" + string.Join(",", LstId) + ")", ClsGlobals.CntStrTMS);
        //        PriDt = ClsRWMSSQLDb.GetDataTable("select *,'ɾ��' as cz from Vfmswyffyccl1 " + PriWhere, ClsGlobals.CntStrTMS);
        //        Dgv.DataSource = PriDt;
        //        if (LstId.Count > 0 && LstNotDel.Count > 0)
        //            ClsMsgBox.Ts("ɾ���ɹ��������ڲ����޷�ɾ�����˵���", frm, this);
        //        else if (LstId.Count > 0 && LstNotDel.Count == 0)
        //            ClsMsgBox.Ts("ɾ���ɹ���", frm, this);
        //        else if (LstId.Count == 0 && LstNotDel.Count > 0)
        //            ClsMsgBox.Ts("ѡ���˵��޷�ɾ����", frm, this);
        //        else
        //            ClsMsgBox.Ts("��ɾ���˵���Ϣ��", frm, this);
        //        Clear();
        //    }
        //}
    }
}