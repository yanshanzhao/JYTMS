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
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
#endregion
namespace FMS.CWGL.ZZHQRJKD.QRJK
{
    public partial class FrmQRJK : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private List<int> PriListShid = new List<int>();//������
        private DataTable PriJgDt = new DataTable();
        private List<int> PriLstYbfid = new List<int>();//�˱��ѱ��е�id
        private List<int> PriLstKhjsid = new List<int>();//�ͻ�������е�PCid
        private string PriConStr;
        private int PriUserid;
        private string PriUserZh;
        private string PriUserXm;
        private int PriToJgid;//��¼�ߵĻ���id
        private int PriJgid;//��Ҫ��˵Ļ���id
        private string PriShzt;//���״̬
        private string PriYwqy;//ҵ������
        private string PriSqlCon;
        private int PriYhlxid;//����������������������id
        private double PriCuntsJe = 0;
        private List<string> PriListYhlx = new List<string>();
        private DataTable PriDt = new DataTable();
        #endregion
        #region ��ʼ������
        public FrmQRJK()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriConStr = ClsGlobals.CntStrTMS;
            PriToJgid = ObjG.Jigou.id;
            PriUserid = ObjG.Renyuan.id;
            PriUserZh = ObjG.Renyuan.loginName;
            PriUserXm = ObjG.Renyuan.xm;
            PnlMain.Controls.Add(PnlJgcx);
            PnlJgcx.Visible = false; 
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            CmbYwqy.SelectedIndex = 0;
            CmbZt.SelectedIndex = 0;
            CmbYHlx.SelectedIndex = 0;
            //GetYhlx();
        }
        #endregion
        #region ������ѯ
        private void TxtJg_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            PnlJgcx.Visible = true;
            string CmdText = "select mc as name,pym,id from jyjckj.dbo.tjigou  where id in( select 0 as jgid union all select jgid  from Tfmsjggx where tojgid=" + ObjG.Jigou.id + " and gxzl='J') and (pym like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%' or  mc like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%')";
            //string CmdText = "select Name,pym,id from jyjckj.dbo.GetChildren2(" + ObjG.Jigou.id + ") where pym like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%' or  name like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%'";
            PriJgDt = ClsRWMSSQLDb.GetDataTable(CmdText, ClsGlobals.CntStrTMS);
            LstV.DataSource = PriJgDt;
            LstV.Columns[0].Text = "��������";
            LstV.Columns[1].Text = "ƴ����";
            LstV.Columns[2].Text = "jgid";
            LstV.Columns[2].Visible = false;
            LstV.Columns[0].Width = 120;
            LstV.Focus();
        }
        private void LstV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                if (TxtJg.Text.Trim().Length != 0)
                    TxtJg.Text = TxtJg.Text.Trim().Substring(0, TxtJg.Text.Trim().Length - 1);
                TxtJg.SelectionStart = TxtJg.Text.Length;
                TxtJg.Focus();
                PnlJgcx.Visible = false;
                PriJgDt.Dispose();
            }

            if (LstV.Items.Count > 0)
            {
                if (e.KeyChar == 13)
                {
                    this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
                    PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
                    this.PnlJgcx.Visible = false;
                    PriJgDt.Dispose();
                }
            }
        }
        private void LstV_LostFocus(object sender, EventArgs e)
        {
            PnlJgcx.Visible = false;
            PriJgDt.Dispose();
        }
        private void LstV_DoubleClick(object sender, EventArgs e)
        {
            this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
            PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
            this.PnlJgcx.Visible = false;
            PriJgDt.Dispose();

        }
        //private void DgvJgcx_LostFocus(object sender, EventArgs e)
        //{
        //    PnlJgcx.Visible = false;
        //    PriJgDt.Dispose();
        //}
        //private void DgvJgcx_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    this.TxtJgmc.Text = DgvJgcx.CurrentRow.Cells[DgvColTxtJgmc.Name].Value.ToString();
        //    PriJgid = Convert.ToInt32(DgvJgcx.CurrentRow.Cells["DgvColTxtjgid"].Value.ToString());
        //    this.PnlJgcx.Visible = false;
        //    PriJgDt.Dispose();
        //}
        //private void DgvJgcx_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 8)
        //    {
        //        if (TxtJg.Text.Trim().Length != 0)
        //            TxtJg.Text = TxtJg.Text.Trim().Substring(0, TxtJg.Text.Trim().Length - 1);
        //        TxtJg.SelectionStart = TxtJg.Text.Length;
        //        TxtJg.Focus();
        //        PnlJgcx.Visible = false;
        //        PriJgDt.Dispose();
        //    }
        //}
        #endregion
        #region ��ѯ
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PriListShid.Clear();
            PriSqlCon = "";
            PriCuntsJe = 0;
            //DSqrjk1 = new DSQRJK();
            string Where = " where  tojgid=" + PriToJgid;
            //��ѯ����
            if (PriJgid > 0)
                Where = Where + " and jgid=" + PriJgid;
            //���״̬
            if (!this.CmbZt.Text.Trim().Equals("ȫ��"))
            {
                PriShzt = this.CmbZt.Text.Trim();
                if (PriShzt.Equals("δ���"))
                    Where = Where + " and  zt=0 ";
                else if (PriShzt.Equals("������"))
                    Where = Where + " and  zt=10 ";
            }
            //��������
            if (CmbYHlx.SelectedIndex != 0)
            {
                Where = Where + "  and yhlxmc='" + CmbYHlx.Text + "'";
            }
            //ҵ������
            if (this.CmbYwqy.SelectedIndex>0)
            {
                PriYwqy = this.CmbYwqy.SelectedValue.ToString();
                Where = Where + "  and ywqy='" + PriYwqy + "'";
            }
            //������ʼ����
            if (DtpStart.Checked)
                Where = Where + " and  inssj >= '" + DtpStart.Value.ToString("yyyy-MM-dd") + "'";
            Where=Where+" and inssj< '" + DtpStop.Value.AddDays(1).ToString("yyyy-MM-dd") + "'";
            //ȷ������
            if (DtpQrStart.Checked && DtpQrStop.Checked)
                Where = Where + " and  shsj >='" + DtpQrStart.Value.ToString("yyyy-MM-dd") + "' and shsj < '" + DtpQrStop.Value.AddDays(1).ToString("yyyy-MM-dd") + "'";
            if (DtpQrStart.Checked && !DtpQrStop.Checked)
                Where = Where + " and  shsj >= '" + DtpQrStart.Value.ToString("yyyy-MM-dd") + "' and shsj < '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            if (!DtpQrStart.Checked && DtpQrStop.Checked)
                Where = Where + " and  shsj  <='" + DtpQrStop.Value.AddDays(1).ToString("yyyy-MM-dd") + "'";
            Where += " ORDER BY jgmc collate Chinese_PRC_CS_AS_KS_WS,rbdh ";
            //PriSqlCon = "SELECT id, rbdh, jgid, jgmc, tojgid, tojgmc, dqid, dqmc, yck, ywqy, zzje, scje, inssj, shsj, zt,'����' as xx, ztmc, pid, zh, zhmc, yhlxid, yhlxmc FROM dbo.Vfmsqrjk " + Where;
            //PriDt.Clear();
            //PriDt = ClsRWMSSQLDb.GetDataTable(PriSqlCon, PriConStr);
            //Dgv.DataSource = PriDt;

            VfmsqrjkTableAdapter1.FillByWhere(DSqrjk1.Vfmsqrjk, Where);
            //Dgv.DataSource = DSqrjk1.Vfmsqrjk;
            LblCount.Text = "����ѯ��" + Dgv.Rows.Count + "����¼";
            if (Dgv.RowCount < 1)
            {
                ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ��", ObjG.CustomMsgBox, this);
                PriSqlCon = "";
                return;
            }
            LblHj.Text = DSqrjk1.Vfmsqrjk.Compute("sum(scje)", "").ToString();
            SumThisPage();
            Xh();
        }
        public void Xh()
        {
            for (int i = 0; i < Dgv.Rows.Count; i++)
            {
                Dgv.Rows[i].Cells[DgvColTxtXh.Name].Value = i + 1;
            }
        }
        #endregion
        #region ������
        private void BtnSh_Click(object sender, EventArgs e)
        {
            if (PriListShid.Count == 0)
            {
                ClsMsgBox.Ts("��ѡ��Ҫ��˵Ľɿ��ձ���", ObjG.CustomMsgBox, this);
                return;
            }
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
                    cmdText = " SET NOCOUNT OFF  update Tfmsrbpc set zt='10',shsj='" + DateTime.Now + "',shczyid=" + PriUserid + ",shczyxm='" + PriUserXm + "',shczyzh='" + PriUserZh + "' where id in(" + string.Join(",", PriListShid) + ");";
                    GetYdid();
                    if (PriLstYbfid.Count != 0)
                        cmdText = cmdText + " update tfmsybf set zt='20' where id in(" + string.Join(",", PriLstYbfid) + ");";
                    if (PriLstKhjsid.Count != 0)
                    {
                        cmdText = cmdText + " update Tfmskhjspc set zt='20' where id in(" + string.Join(",", PriLstKhjsid) + ");";
                        cmdText = cmdText + " update tfmsybf set zt='20' where id in (select ybfid from Tfmskhjsmx where pcid in (select id from Tfmskhjspc where id in(" + string.Join(",", PriLstKhjsid) + "))) ;";
                    }
                    comm.CommandText = cmdText;
                    int influenceSum = comm.ExecuteNonQuery();
                    if (influenceSum > 0)
                    {
                        //�ύ����
                        ClsMsgBox.Ts("��˳ɹ���", ObjG.CustomMsgBox, this);
                        foreach (int i in PriListShid)
                        {
                            int index = Bds.Find("id", i);
                            Bds.RemoveAt(index);
                        }
                        PriLstYbfid.Clear();
                        PriListShid.Clear();
                        PriLstKhjsid.Clear();
                        PriCuntsJe = 0;
                        trans.Commit();

                        //Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(PriSqlCon, PriConStr);
                        //BtnSearch.PerformClick();
                        GetXx();
                    }
                    else
                    {
                        //�ع�����
                        ClsMsgBox.Ts("���ʧ�ܣ�", ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    //�ع�����
                    try
                    {
                        ClsMsgBox.Cw("����쳣��", ex, ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                    catch (SqlException ex1)
                    {
                        if (trans.Connection != null)
                            ClsMsgBox.Cw("�ع�ʧ��! �쳣����:" + ex1.GetType(), ex1, ObjG.CustomMsgBox, this);
                    }
                }
                finally
                {
                    conn.Close();

                }
            }
        }
        /// <summary>
        /// ��ȡ�˵�id
        /// </summary>
        private void GetYdid()
        {
            PriLstYbfid.Clear();
            string aSQlCont = " select ybfid from Tfmsrbmx where  ybfid>0 and rbpcid in(" + string.Join(",", PriListShid) + ")";
            DataTable dt = ClsRWMSSQLDb.GetDataTable(aSQlCont, PriConStr);
            if (dt.Rows.Count >= 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PriLstYbfid.Add(Convert.ToInt32(dt.Rows[i][0]));
                }
            }
            aSQlCont = " select khjsid from Tfmsrbmx where  khjsid>0 and rbpcid in(" + string.Join(",", PriListShid) + ")";
            dt = ClsRWMSSQLDb.GetDataTable(aSQlCont, PriConStr);
            if (dt.Rows.Count >= 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PriLstKhjsid.Add(Convert.ToInt32(dt.Rows[i][0]));
                }
            }
        }
        #endregion
        #region ��굥ѡ
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                if (Dgv.Rows[e.RowIndex].Cells["DgvColTxtshzt"].Value.ToString() == "������")
                {
                    ClsMsgBox.Ts("�ýɿ��ձ��Ѿ����ͨ����", ObjG.CustomMsgBox, this);
                    return;
                }
                int aid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtid"].Value.ToString());
                double n;
                double aRowje = 0;
                if (double.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtsjyc.Name].Value.ToString(), out n))
                    aRowje = Convert.ToDouble(Dgv.Rows[e.RowIndex].Cells[DgvColTxtsjyc.Name].Value);

                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvColCbm.Name].Value))//ȡ��ѡ��
                {
                    Dgv.Rows[e.RowIndex].Cells[DgvColCbm.Name].Value = false;
                    PriListShid.Remove(aid);
                    PriCuntsJe = PriCuntsJe - aRowje;
                }
                else
                {
                    Dgv.Rows[e.RowIndex].Cells[DgvColCbm.Name].Value = true;
                    PriListShid.Add(aid);
                    PriCuntsJe = PriCuntsJe + aRowje;
                }
                GetXx();
            }
            //����
            if (e.ColumnIndex == 13)
            {
                FrmYbfXq f = new FrmYbfXq();
                f.ShowDialog();
                f.Prepare(Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtid"].Value.ToString()), Dgv.Rows[e.RowIndex].Cells["DgvColTxtJkrb"].Value.ToString());
            }
        }
        #endregion
        #region ����
        #region Excel����
        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            CreatExcel();
        }
        private void CreatExcel()
        {
            string PriFln = "ȷ�Ͻɿ��嵥_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";//�ļ�����     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
            //д������
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet") as HSSFSheet;
            HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
            cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
            try
            {
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                for (int i = 2; i < Dgv.ColumnCount - 6; i++)
                {
                    if (i == 3)
                        row0.CreateCell(i - 2).SetCellValue("������");
                    else if (i == 5)
                        row0.CreateCell(i - 2).SetCellValue("�˷ѽ��");
                    else if (i == 6)
                        row0.CreateCell(i - 2).SetCellValue("�ձ�����");
                    else if (i == 7)
                        row0.CreateCell(i - 2).SetCellValue("ת������");
                    else if (i == 8)
                        row0.CreateCell(i - 2).SetCellValue("ת�������ʺ�");
                    else if (i == 9)
                        row0.CreateCell(i - 2).SetCellValue("ת���ʻ�����");
                    else
                        row0.CreateCell(i - 2).SetCellValue(Dgv.Columns[i].HeaderText);
                }
                int roowIndex = 1;
                //�������
                foreach (DataGridViewRow Row in Dgv.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    for (int i = 2; i < Dgv.ColumnCount - 6; i++)
                    {
                        if (i == 4)
                            hssfrow.CreateCell(i - 2).SetCellValue(Convert.ToDateTime(Row.Cells[i].Value.ToString()).ToString("yyyy-MM-dd"));
                        else if (i == 5)
                        {
                            hssfrow.CreateCell(i - 2).SetCellValue(Convert.ToDouble(Row.Cells[10].Value));
                            row0.Cells[i - 2].CellStyle = cellStyle;
                        }
                        else if (i >= 6)
                            hssfrow.CreateCell(i - 2).SetCellValue(Row.Cells[i - 1].Value.ToString());
                        else
                            hssfrow.CreateCell(i - 2).SetCellValue(Row.Cells[i].Value.ToString());
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
                ClsMsgBox.Cw("������汨��ʧ��", ex);
            }
        }
        #endregion
        #region ���������ļ�
        private void menuItem2_Click(object sender, EventArgs e)
        {
            int coutn = FileDgv("��������");
            if (coutn == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            else if (coutn == -1)
            {
                ClsMsgBox.Ts("ҳ����Ϣ��û�н���Ҫȷ�Ͻɿ����Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            else
            {
                string PriFln = "���пۿ���ϸ" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
                string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
                HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
                HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                //д������
                HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
                sheet1.SetColumnWidth(0, 25 * 240);
                sheet1.SetColumnWidth(1, 25 * 120);
                try
                {
                    int roowIndex = 0;
                    for (int i = 0; i < Dgv.RowCount; i++)
                    {
                        if (Dgv.Rows[i].Cells["DgvColTxtshzt"].Value.ToString() == "δ���" && Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtyhlxid"].Value) == PriYhlxid)
                        {
                            HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                            for (int m = 0; m < 3; m++)
                            {
                                if (m == 0)
                                    hssfrow.CreateCell(0).SetCellValue(Dgv.Rows[i].Cells["DgvColTxtyhzh"].Value.ToString());
                                else if (m == 1)
                                    hssfrow.CreateCell(1).SetCellValue(Dgv.Rows[i].Cells["DgvColTxtyhzhmc"].Value.ToString());
                                else
                                {
                                    hssfrow.CreateCell(2).SetCellValue(Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtscje.Name].Value));
                                    hssfrow.Cells[2].CellStyle = cellStyle;
                                }
                            }
                            roowIndex++;
                        }
                    }
                    FileStream file = new FileStream(PriFlp, FileMode.Create);
                    hssfworkbook.Write(file);
                    file.Close();
                    this.ctrlDownLoad1.download(PriFlp, true);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("������������Excelʧ�ܣ�", ex);
                }
            }
        }
        #endregion
        #region ũ�������ļ�
        private void menuItem3_Click(object sender, EventArgs e)
        {
            int cout = FileDgv("ũҵ����");
            if (cout == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            else if (cout == -1)
            {
                ClsMsgBox.Ts("ҳ����Ϣ��û��ũ��Ҫȷ�Ͻɿ����Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            else
            {
                try
                {
                    string PriFln = "ũ�пۿ���ϸ" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";//�ļ�����     
                    string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
                    int PriNo = 1;
                    FileStream fs1 = new FileStream(PriFlp, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs1);
                    string str = "";
                    for (int i = 0; i < Dgv.Rows.Count; i++)
                    {
                        if (Dgv.Rows[i].Cells["DgvColTxtshzt"].Value.ToString() == "δ���" && Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtyhlxid"].Value) == PriYhlxid)
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
                            for (int j = 1; j < Dgv.Columns.Count - 1; j++)
                            {
                                if (Dgv.Columns[j].HeaderText == "�����˻�" || Dgv.Columns[j].HeaderText == "�����˻�����" || Dgv.Columns[j].HeaderText == "ʵ��Ӧ��(Ԫ)")
                                {
                                    str += Dgv.Rows[i].Cells[j].Value.ToString();
                                    str += ",";
                                }
                            }
                            str += "����";
                            str += "\r\n";
                            PriNo++;
                        }
                    }
                    str = str.Substring(0, str.LastIndexOf("\r\n"));
                    sw.WriteLine(str);//Ҫд�����Ϣ�� 
                    this.ctrlDownLoad1.download(PriFlp, true);
                    sw.Close();
                    fs1.Close();
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("����ũ�������ı�ʧ��!", ex, ObjG.CustomMsgBox, this);
                }
            }
        }
        #endregion
        private int FileDgv(string yhlxjc)
        {
            int b = 0;
            PriYhlxid = 0;
            if (Dgv.RowCount == 0)
                return b;
            //if (yhlxjc != "��ҵ����")
            PriYhlxid = ClsRWMSSQLDb.GetInt(" select id from tyhlx where jc='" + yhlxjc + "'", PriConStr);
            //else
            //{
            //    DataTable dt = ClsRWMSSQLDb.GetDataTable(" select id from tyhlx where jc='ũҵ����' or jc='��������'", PriConStr);
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        PriListYhlx.Add(dt.Rows[i][0].ToString());
            //    }
            //}
            int cout = 0;
            for (int i = 0; i < Dgv.RowCount; i++)
            {
                string zt = Dgv.Rows[i].Cells["DgvColTxtshzt"].Value.ToString();
                int n = 0;
                int yhlx = 0;
                if (int.TryParse(Dgv.Rows[i].Cells["DgvColTxtyhlxid"].Value.ToString(), out n))
                    yhlx = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtyhlxid"].Value);
                //if (zt == "δ���")
                //{
                //    if (yhlx == PriYhlxid && PriYhlxid > 0)
                //        cout++;
                //    else
                //    {
                //        for (int m = 0; i < PriListYhlx.Count; m++)
                //        {
                //            if (yhlx != Convert.ToInt32(PriListYhlx[m]))
                //                cout++;
                //        }
                //    }
                //}
                if (zt == "δ���" && yhlx == PriYhlxid && PriYhlxid > 0)
                    cout++;
            }
            //PriListYhlx.Clear();
            if (cout == 0)
                return b = -1;
            return b = cout;
        }
        #endregion
        #region ����
        //private void menuItem4_Click(object sender, EventArgs e)
        //{
        //    int cout = FileDgv("��ҵ����");
        //    if (cout == 0)
        //    {
        //        ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
        //        return;
        //    }
        //    else if (cout == -1)
        //    {
        //        ClsMsgBox.Ts("ҳ����Ϣ��û��ũ��Ҫȷ�Ͻɿ����Ϣ��", ObjG.CustomMsgBox, this);
        //        return;
        //    }
        //    else
        //    {
        //    }
        //}
        #endregion
        #region ũ�������ļ�
        private void menuItem3_Click_1(object sender, EventArgs e)
        {
            int cout = FileDgv("ũҵ����");
            if (cout == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            else if (cout == -1)
            {
                ClsMsgBox.Ts("ҳ����Ϣ��û��ũ��Ҫȷ�Ͻɿ����Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            else
            {
                try
                {
                    string PriFln = "ũ�пۿ���ϸ" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";//�ļ�����     
                    string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
                    int PriNo = 1;
                    FileStream fs1 = new FileStream(PriFlp, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs1);
                    string str = "";
                    for (int i = 0; i < Dgv.Rows.Count; i++)
                    {
                        if (Dgv.Rows[i].Cells["DgvColTxtshzt"].Value.ToString() == "δ���" && Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtyhlxid"].Value) == PriYhlxid)
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
                            for (int j = 1; j < Dgv.Columns.Count - 1; j++)
                            {
                                if (Dgv.Columns[j].HeaderText == "�����˻�" || Dgv.Columns[j].HeaderText == "�����˻�����" || Dgv.Columns[j].HeaderText == "ʵ����(Ԫ)")
                                {
                                    str += Dgv.Rows[i].Cells[j].Value.ToString();
                                    str += ",";
                                }
                            }
                            str += "����";
                            str += "\r\n";
                            PriNo++;
                        }
                    }
                    str = str.Substring(0, str.LastIndexOf("\r\n"));
                    sw.WriteLine(str);//Ҫд�����Ϣ�� 
                    this.ctrlDownLoad1.download(PriFlp, true);
                    sw.Close();
                    fs1.Close();
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("����ũ�������ı�ʧ��!", ex, ObjG.CustomMsgBox, this);
                }
            }
        }
        #endregion

        #region ��ҳȫѡ
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
                return;
            CheckThisPage();
            GetXx();
        }
        public void CheckThisPage()
        {
            //һ���ж�����
            int rowcount = Convert.ToInt32(Dgv.RowCount);
            //��ǰ�ǵڼ�ҳ
            int currentpage = Convert.ToInt32(Dgv.CurrentPage);
            //һҳ�л���
            int pageSize = Convert.ToInt32(Dgv.ItemsPerPage);
            //һ���ж���ҳ
            int pageCount = (rowcount / pageSize);
            //�ϼƵ�ֵ 
            //�ж�һ���м�ҳ����û������
            //�������������ֻ���һҳ����������ָ������ʾ������  
            if (rowcount % pageSize > 0)
            {
                pageCount++;
                //�ȼ���������һҳ�ĺϼ�
                if (currentpage < pageCount)
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                    {

                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value) && Dgv.Rows[i].Cells["DgvColTxtshzt"].Value.ToString() != "������")
                        {
                            int aid = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtid"].Value.ToString());
                            double n;
                            double aRowje = 0;
                            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtsjyc.Name].Value.ToString(), out n))
                                aRowje = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtsjyc.Name].Value);
                            Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;
                            PriListShid.Add(aid);
                            PriCuntsJe = PriCuntsJe + aRowje;
                        }
                    }
                }
                //�������һҳ��ֵ
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value) && Dgv.Rows[i].Cells["DgvColTxtshzt"].Value.ToString() != "������")
                        {
                            int aid = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtid"].Value.ToString());
                            double n;
                            double aRowje = 0;
                            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtsjyc.Name].Value.ToString(), out n))
                                aRowje = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtsjyc.Name].Value);
                            Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;
                            PriListShid.Add(aid);
                            PriCuntsJe = PriCuntsJe + aRowje;
                        }
                    }
                }
            }
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value) && Dgv.Rows[i].Cells["DgvColTxtshzt"].Value.ToString() != "������")
                    {
                        int aid = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtid"].Value.ToString());
                        double n;
                        double aRowje = 0;
                        if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtsjyc.Name].Value.ToString(), out n))
                            aRowje = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtsjyc.Name].Value);
                        Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;
                        PriListShid.Add(aid);
                        PriCuntsJe = PriCuntsJe + aRowje;
                    }
                }
            }
        }
        #endregion

        #region GetXx();
        private void GetXx()
        {
            if (PriListShid.Count == 0)
            {
                LblCheckCount.Text = "��ѡ��0��,ѡ��ȷ�Ͻ�0.00Ԫ";
            }
            else
            {
                LblCheckCount.Text = "��ѡ��" + PriListShid.Count + "��,ѡ��ȷ�Ͻ�" + PriCuntsJe + "Ԫ";
            }
        }
        #endregion

        #region  ȫѡ
        private void ChkB_CheckedChanged(object sender, EventArgs e)
        {
            CheckAll(ChkB.Checked);
            GetXx();
        }
        public void CheckAll(bool aChecked)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {

                if (row.Cells["DgvColTxtshzt"].Value.ToString() != "������")
                {
                    int aid = Convert.ToInt32(row.Cells["DgvColTxtid"].Value.ToString());
                    double n;
                    double aRowje = 0;
                    if (double.TryParse(row.Cells[DgvColTxtsjyc.Name].Value.ToString(), out n))
                        aRowje = Convert.ToDouble(row.Cells[DgvColTxtsjyc.Name].Value);
                    if (!aChecked)//ȡ��ȫѡ
                    {
                        if (Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))//ȡ��ѡ��
                        {
                            row.Cells[DgvColCbm.Name].Value = false;
                            PriListShid.Remove(aid);
                            PriCuntsJe = PriCuntsJe - aRowje;
                        }
                    }
                    else
                    {
                        if (!Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))//ȡ��ѡ��
                        {
                            row.Cells[DgvColCbm.Name].Value = true;
                            PriListShid.Add(aid);
                            PriCuntsJe = PriCuntsJe + aRowje;
                        }
                    }
                }
            }
        }
        #endregion

        #region ��ҳ�ϼ�
        private void SumThisPage()
        {
            decimal sum = 0;
            //һ���ж�����
            int rowcount = Convert.ToInt32(Dgv.RowCount);
            //��ǰ�ǵڼ�ҳ
            int currentpage = Convert.ToInt32(Dgv.CurrentPage);
            //һҳ�л���
            int pageSize = Convert.ToInt32(Dgv.ItemsPerPage);
            //һ���ж���ҳ
            int pageCount = (rowcount / pageSize);
            //�ϼƵ�ֵ 
            //�ж�һ���м�ҳ����û������
            //�������������ֻ���һҳ����������ָ������ʾ������  
            if (rowcount % pageSize > 0)
            {
                pageCount++;
                //�ȼ���������һҳ�ĺϼ�
                if (currentpage < pageCount)
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                    {
                        sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtscje.Name].Value);
                    }
                }
                //�������һҳ��ֵ
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                    {
                        sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtscje.Name].Value);
                    }
                }
            }
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtscje.Name].Value);
                }
            }
            LblByhj.Text = sum.ToString();
        }
        #endregion

        private void BtnClear1_Click(object sender, EventArgs e)
        {
            this.TxtJgmc.Clear();
            PriJgid = 0;
        }

        private void Dgv_PagingChanged(object sender, EventArgs e)
        {
            SumThisPage();
        }
    }
}
