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
using System.Configuration;
using NPOI.HSSF.UserModel;
using System.IO;
using JY.Pub;
using System.Linq;
using System.Data.SqlClient;
using JYPubFiles.Classes;
using TMS.ysgl.ImportYd;

#endregion

namespace FMS.DSKGL.DSKPOSFA
{
    public partial class FrmPOSDSKFA : UserControl
    {

        #region ��Ա����
        private string PriConStr;
        private ClsG ObjG;
        private string PriFilePath;//�ļ�·��
        private string[] PriExtention = { ".xls" };//�����ϴ����ļ�����չ����
        List<string> LstFiles = new List<string>();
        private HSSFWorkbook Hssfworkbook;
        private List<string> Prirbid = new List<string>();
        #endregion
        public FrmPOSDSKFA()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            PriConStr = ClsGlobals.CntStrTMS;
            //��ñ��˵����ֵ��DataTable
            //PriTydColsDescription = ClsRWMSSQLDb.GetColDescription("T_LineTmp", PriConStr);
            //����ļ���·��
            PriFilePath = Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), ClsOptions.WebCfg.YDFILES  + DateTime.Now.ToString("yyyyMM"));
            if (!Directory.Exists(PriFilePath))
                Directory.CreateDirectory(PriFilePath);
            //��ָ��·���µ��ļ���ʾ��ListBox��
            ImportFileToDgv(PriFilePath);
            //�Զ����ϴ��ļ�·��,�����Զ���ؼ����Prepare����
            //PriUploadFoldr = ClsOptions.WebCfg.PosXlsFilePath + DateTime.Now.ToString("yyyyMM");
            ctrlUploadFile1.Prepare(PriFilePath, PriExtention, false, "�����ļ�");
            ImportFileToDgv(PriFilePath);
            ctrlUploadFile1.PrepareA(new JY.CtrlPub.ImportToDB(DgvAddFile));
            CmbZtlx.SelectedIndex = 0;
            //VCMSLypcTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrKj;
        }


        #region ������ϴ��ļ����ļ�������ļ�������DataGridview��
        private void ImportFileToDgv(string filePath)
        {
            Dgv.Rows.Clear();
            LstFiles.Clear();
            foreach (string str in Directory.GetFiles(PriFilePath, "*.xls"))
            {
                FileInfo f = new FileInfo(str);
                LstFiles.Add(Path.GetFileName(str).ToString());
                string[] str1 = { Path.GetFileName(str).ToString(), string.Format("{0:0.00}", f.Length / 1024) };
                Dgv.Rows.Add(str1);
            }
        }
        #endregion

        #region  �����������ļ���ѡ��
        public void DgvAddFile(string filepath)
        {
            foreach (string str in Directory.GetFiles(PriFilePath, "*.xls"))
            {
                FileInfo f = new FileInfo(str);
                string a = LstFiles.ToArray().FirstOrDefault(cx => string.Compare(Path.GetFileName(str).ToString(), cx.ToString()) == 0);
                if (string.IsNullOrEmpty(a))
                {
                    string[] str1 = { Path.GetFileName(str).ToString(), string.Format("{0:0.00}", f.Length / 1024) };
                    Dgv.Rows.Add(str1);
                    LstFiles.Add(Path.GetFileName(str).ToString());
                }
            }
            Dgv.CurrentCell = Dgv.Rows[Dgv.Rows.Count - 1].Cells[0];
            Dgv.BeginEdit(true);
        }
        #endregion

        private void BtnToData_Click(object sender, EventArgs e)
        {
            if (Dgv.SelectedRows != null && Dgv.Rows.Count != 0)
            {
                string flName = Dgv.CurrentRow.Cells[0].Value.ToString();
                ExcelToDatatable(PriFilePath + @"\" + flName);
            }
        }

        #region ExcelToDataTable()
        public void ExcelToDatatable(string filePath)
        {
            int Pcid = 0;
            try
            {
                Stream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                Hssfworkbook = new HSSFWorkbook(fs);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("�������", ex);
                return;
            }
            using (SqlConnection conn = new SqlConnection(PriConStr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                SqlTransaction trans = conn.BeginTransaction();
                comm.Transaction = trans;
                comm.CommandTimeout = 300;
                try
                {
                    bool aBool = true;

                    string aTs = "";

                    // ����������Ϣ�����pcid
                    comm.CommandText = string.Format("INSERT INTO TydTempPc (czyxm,czyzh,czyid,jgid,jgmc,filepath)" +
                    "  VALUES ('{0}','{1}',{2},{3},'{4}','{5}');SELECT SCOPE_IDENTITY()", ObjG.Renyuan.xm, ObjG.Renyuan.loginName, ObjG.Renyuan.id, ObjG.Jigou.id, ObjG.Jigou.mc, filePath);
                    Pcid = Convert.ToInt32(comm.ExecuteScalar());
                    //��ȡExcel�ĵ�һ��sheet
                    HSSFSheet hssfsheet = (HSSFSheet)Hssfworkbook.GetSheetAt(0);
                    //����ÿ����Ԫ���ֵ
                    List<string> LstCellValue = new List<string>();
                    //List<string> LstValue = new List<string>();
                    for (int i = 1; i <= hssfsheet.LastRowNum; i++)
                    {

                        LstCellValue.Clear();
                        HSSFRow row = (HSSFRow)hssfsheet.GetRow(i);
                        if (row.Cells[0].ToString().Trim().Equals(""))
                            continue;
                        LstCellValue.Add(Pcid.ToString());//����ID
                        LstCellValue.Add("'" + row.Cells[0].ToString().Trim() + "'");//���
                        //LstCellValue.Add("'" + row.Cells[1].ToString() + "'");//��Ʒ����
                        LstCellValue.Add("'" + row.Cells[2].ToString().Trim() + "'");//�������
                        //LstCellValue.Add("'" + row.Cells[3].ToString() + "'");//��ʼ��
                        LstCellValue.Add("'" + row.Cells[4].ToString().Trim() + "'");//����ʱ��
                        //LstCellValue.Add("'" + row.Cells[6].ToString().Trim() + "'");//�յ�λ��

                        LstCellValue.Add("'" + row.Cells[10].ToString().Trim() + "'");//�ͻ����
                        LstCellValue.Add("'" + row.Cells[11].ToString().Trim() + "'");//�����ͻ�����
                        LstCellValue.Add("'" + row.Cells[12].ToString().Trim() + "'");//������ϵ��
                        string fhlxdh = row.Cells[13].ToString().Trim();
                        if (fhlxdh.Length > 16)
                            fhlxdh = fhlxdh.Substring(0, 16);
                        LstCellValue.Add("'" + fhlxdh + "'");//������ϵ�绰


                        LstCellValue.Add("'" + row.Cells[14].ToString().Trim() + "'");//�ջ��ͻ�����
                        LstCellValue.Add("'" + row.Cells[15].ToString().Trim() + "'");//������ϵ��
                        string dhlxdh = row.Cells[16].ToString().Trim();
                        if (dhlxdh.Length > 16)
                            dhlxdh = dhlxdh.Substring(0, 16);
                        if (dhlxdh.Length == 0)
                            dhlxdh = "0";
                        LstCellValue.Add("'" + dhlxdh + "'");//������ϵ�绰

                        LstCellValue.Add("'" + row.Cells[19].ToString().Trim() + "'");//�����ʽ
                        LstCellValue.Add(row.Cells[20].ToString().Trim().Equals("") ? "0" : row.Cells[20].ToString().Trim());//�ص�����
                        LstCellValue.Add(row.Cells[21].ToString().Trim().Equals("") ? "0" : row.Cells[21].ToString().Trim());//���տ�
                        LstCellValue.Add("'" + (row.Cells[22].ToString().Trim().Equals("") ? "0" : row.Cells[22].ToString().Trim()) + "'");//���񿨺�

                        //LstCellValue.Add(row.Cells[27].ToString().Trim());//�ܼ���
                        //LstCellValue.Add(row.Cells[28].ToString().Trim());//������
                        //LstCellValue.Add(row.Cells[29].ToString().Trim());//�����
                        //LstCellValue.Add(row.Cells[31].ToString().Trim());//���۽��
                        //LstCellValue.Add(row.Cells[32].ToString().Trim());//���۷�
                        //LstCellValue.Add(row.Cells[34].ToString().Trim());//�˷�
                        //LstCellValue.Add(row.Cells[36].ToString().Trim());//ֱ�ͷ�
                        //LstCellValue.Add(row.Cells[38].ToString().Trim());//��¥��
                        //LstCellValue.Add("'" + row.Cells[44].ToString().Trim() + "'");//��������



                        LstCellValue.Add(row.Cells[27].ToString().Trim().Equals("") ? "0" : row.Cells[27].ToString().Trim());//�ܼ���
                        LstCellValue.Add(row.Cells[28].ToString().Trim().Equals("") ? "0" : row.Cells[28].ToString().Trim());//������

                        LstCellValue.Add(row.Cells[30].ToString().Trim().Equals("") ? "0" : row.Cells[30].ToString().Trim());//�����
                        LstCellValue.Add(row.Cells[32].ToString().Trim().Equals("") ? "0" : row.Cells[32].ToString().Trim());//���۽��
                        LstCellValue.Add(row.Cells[33].ToString().Trim().Equals("") ? "0" : row.Cells[33].ToString().Trim());//���۷�
                        LstCellValue.Add(row.Cells[35].ToString().Trim().Equals("") ? "0" : row.Cells[35].ToString().Trim());//�˷�
                        LstCellValue.Add("'" + row.Cells[36].ToString().Trim() + "'");//���ʽ 
                        LstCellValue.Add(row.Cells[37].ToString().Trim().Equals("") ? "0" : row.Cells[37].ToString().Trim());//ֱ�ͷ�

                        LstCellValue.Add(row.Cells[39].ToString().Trim().Equals("") ? "0" : row.Cells[39].ToString().Trim());//��¥��
                        if (string.IsNullOrEmpty(row.Cells[45].ToString().Trim()))
                        {
                            aBool = false;
                            aTs = "��" + (i + 1) + "�л�������Ϊ�գ�";
                            break;
                        }
                        LstCellValue.Add("'" + row.Cells[45].ToString().Trim() + "'");//��������


                        LstCellValue.Add("'" + DateTime.Now.AddDays(3) + "'");//Ԥ�Ƶ���ʱ��
                        LstCellValue.Add("'" + row.Cells[56].ToString().Trim() + "'");//���տ�����

                        if (string.IsNullOrEmpty(row.Cells[60].ToString().Trim()))
                        {
                            aBool = false;
                            aTs = "��" + (i + 1) + "����idΪ�գ�";
                            break;
                        }

                        int n;
                        if (!int.TryParse(row.Cells[60].ToString().Trim(), out n))
                        {
                            aBool = false;
                            aTs = "��" + (i + 1) + "����id��ֵ���쳣��";
                            break;
                        }
                        LstCellValue.Add(row.Cells[60].ToString().Trim());
                        if (string.IsNullOrEmpty(row.Cells[61].ToString().Trim()))
                        {
                            aBool = false;
                            aTs = "��" + (i + 1) + "����nameΪ�գ�";
                            break;
                        }
                        string zdwzmc=row.Cells[61].ToString().Trim();
                        int last = zdwzmc.LastIndexOf("@");
                        if (last <= 0)
                        {
                            aBool = false;
                            aTs = "��" + (i + 1) + "����nameֵ�쳣��";
                            break;
                        }
                        LstCellValue.Add("'"+zdwzmc.Substring(last+1)+"'");
                        comm.CommandText = "INSERT INTO TydTemp (pcid,bh,sljgmc,qysj,khbh,fhkhmc,fhlxr,fhlxdh,shkhmc,shlxr,shlxdh,ztbzs,hdfs,dsk,fwkh,zjs,zzl,ztj,bjje,bf,yf,fkfsmc,zsf,qtfy,hwmc,yjddsj,dskzls,zdwzid,zdwzmc) VALUES " + "(" + string.Join(",", LstCellValue) + ")";
                        comm.ExecuteNonQuery();
                    }
                    if (aBool)
                    {
                        trans.Commit();
                        ClsMsgBox.Ts("����ɹ���", ObjG.CustomMsgBox, this);
                    }
                    else
                    {
                        trans.Rollback();
                        ClsMsgBox.Ts("����ʧ�ܣ�" + aTs, ObjG.CustomMsgBox, this);
                    }

                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw(ex.Message, ObjG.CustomMsgBox, this);
                    trans.Rollback();
                    return;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Dgv.SelectedRows != null && Dgv.Rows.Count != 0)
            {
                ClsMsgBox.YesNo("ȷ��ɾ��" + Dgv.CurrentRow.Cells[0].Value + "��", new EventHandler(DeleteFile));
            }
        }
        private void DeleteFile(object sender, EventArgs e)
        {
            Form p = sender as Form;
            if (p.DialogResult == DialogResult.Yes)
            {
                File.Delete(PriFilePath + @"\" + Dgv.CurrentRow.Cells[0].Value);
                ImportFileToDgv(PriFilePath);
            }
        }

        private void BtnQuiry_Click(object sender, EventArgs e)
        {
            string where = " WHERE inssj >= '" + DtpStart.Value.Date + "' AND inssj < '" + DtpStop.Value.AddDays(1).Date + "' and jgid = " + ObjG.Jigou.id;
            if (CmbZtlx.Text == "��ʼ")
                where += " AND zt = 0";
            else if (CmbZtlx.Text == "��ͨ��")
                where += " AND zt = 1";
            else if (CmbZtlx.Text == "δͨ��")
                where += " AND zt = 2";
            else //if (CmbZtlx.Text == "�ѵ���")
                where += " AND zt = 3";
            //TydTempPcTableAdapter1.FillByWhere(DSYDIMPORT1.TydTempPc, where);
            //ChangeCloor();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            //if (Bds.Current == null)
            //    return;
            //ClsMsgBox.YesNo("�Ƿ�ɾ���˵���Ϣ��", new EventHandler(Delete), ObjG.CustomMsgBox, this);
        }

        private void Delete(object sender, EventArgs e)
        {
            //FrmMsgBox f = new FrmMsgBox();
            //using (Form frm = sender as Form)
            //{
            //    if (frm.DialogResult == DialogResult.Yes)
            //    {
            //        DSYDIMPORT.TydTempPcRow row = ((DataRowView)Bds.Current).Row as DSYDIMPORT.TydTempPcRow;
            //        int zt = ClsRWMSSQLDb.GetInt("SELECT zt FROM TydTempPc WHERE id = " + row.id, ClsGlobals.CntStrTMS);
            //        if (zt == 3)
            //        {
            //            ClsMsgBox.Ts("����ɾ������ɹ������ݣ�", f, this);
            //            return;
            //        }
            //        TydTempPcTableAdapter1.Delete(row.id);
            //        Bds.RemoveCurrent();
            //        DSYDIMPORT1.AcceptChanges();
            //        ClsMsgBox.Ts("ɾ���ɹ���", f, this);
            //    }
            //}
        }

        //private void ChangeCloor()
        //{
        //    for (int i = 0; i < DGVDRxx.Rows.Count; i++)
        //    {
        //        if (DGVDRxx.Rows[i].Cells[3].Value.ToString().Equals("δͨ��"))
        //        {
        //            DGVDRxx.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
        //        }
        //        else if (DGVDRxx.Rows[i].Cells[3].Value.ToString().Equals("��ͨ��"))
        //        {
        //            DGVDRxx.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
        //        }
        //        else if (DGVDRxx.Rows[i].Cells[3].Value.ToString().Equals("�ѵ���"))
        //        {
        //            DGVDRxx.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
        //        }
        //    }
        //}

        private void DGVDRxx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                //DSYDIMPORT.TydTempPcRow row = ((DataRowView)Bds.Current).Row as DSYDIMPORT.TydTempPcRow;
                //FrmYdError f = new FrmYdError();
                //f.ShowDialog();
                //f.Prepare(row.id);
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            //if (Bds.Current == null)
            //    return;
            //DSYDIMPORT.TydTempPcRow row = ((DataRowView)Bds.Current).Row as DSYDIMPORT.TydTempPcRow;
            //if (row.zt != 1)
            //{
            //    ClsMsgBox.Ts("�������Ϣ��û��ͨ����֤���ѵ���������������˵���", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            //{
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = conn;
            //    try
            //    {
            //        conn.Open();
            //        cmd.CommandText = "P_ydImport";
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@pcid", row.id);
            //        cmd.Parameters.AddWithValue("@czyid", ObjG.Renyuan.id);
            //        cmd.Parameters.AddWithValue("@czyxm", ObjG.Renyuan.xm);
            //        SqlParameter parOutput = cmd.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar, 100);
            //        parOutput.Direction = ParameterDirection.Output;
            //        SqlParameter parReturn = new SqlParameter("@return", SqlDbType.Int);
            //        parReturn.Direction = ParameterDirection.ReturnValue; ����//��������ΪReturnValue                    
            //        cmd.Parameters.Add(parReturn);
            //        cmd.ExecuteNonQuery();
            //        if (Convert.ToInt32(parReturn.Value) == 1)
            //        {
            //            ClsMsgBox.Ts("�����˵�ȫ���ɹ���", ObjG.CustomMsgBox, this);
            //        }
            //        else if (Convert.ToInt32(parReturn.Value) == 0)
            //        {
            //            ClsMsgBox.Ts("����ʧ�ܣ�����" + parOutput.Value.ToString(), ObjG.CustomMsgBox, this);
            //        }
            //        else
            //        {
            //            ClsMsgBox.Ts("����δ֪����", ObjG.CustomMsgBox, this);
            //        }
            //        Bds.RemoveCurrent();
            //    }
            //    catch (Exception ex)
            //    {
            //        ClsMsgBox.Ts(ex.Message, ObjG.CustomMsgBox, this);
            //    }
            //}
        }

        private void BtnValidate_Click(object sender, EventArgs e)
        {
            //if (DGVDRxx.Rows.Count == 0)
            //{
            //    ClsMsgBox.Ts("��ѡ��Ҫ��֤���˵���Ϣ��", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //DSYDIMPORT.TydTempPcRow Row = ((DataRowView)Bds.Current).Row as DSYDIMPORT.TydTempPcRow;
            //if (Row.zt == 3)
            //{
            //    ClsMsgBox.Ts("���˵��Ѿ����룬�����ٴμ�飡", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //if (Row.zt > 0)
            //{
            //    ClsMsgBox.Ts("������˵��Ѿ���֤���������ٴ���֤��", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = ClsGlobals.CntStrTMS;
            //conn.Open();
            //SqlCommand comm = new SqlCommand();
            ////SqlDataAdapter sda = new SqlDataAdapter();
            //try
            //{
            //    comm.Connection = conn;
            //    comm.CommandType = CommandType.StoredProcedure;
            //    comm.CommandText = "P_yddrjc";
            //    comm.Parameters.Add(new SqlParameter("@pcid", Row.id));
            //    SqlParameter parReturn = new SqlParameter("@return", SqlDbType.Int);
            //    parReturn.Direction = ParameterDirection.ReturnValue; ����//��������ΪReturnValue                    
            //    comm.Parameters.Add(parReturn);
            //    comm.ExecuteNonQuery();
            //    int count = Convert.ToInt32(parReturn.Value);
            //    if (count == 0)
            //    {
            //        ClsMsgBox.Ts("��֤ʧ�ܣ������쳣�˵���", ObjG.CustomMsgBox, this);
            //    }
            //    else
            //    {
            //        ClsMsgBox.Ts("��֤�����˵�ȫ���ɹ���", ObjG.CustomMsgBox, this);
            //    }
            //    Bds.RemoveCurrent();
            //}
            //catch (Exception ex)
            //{
            //    ClsMsgBox.Cw("��֤�����˵�ʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            //}
            //finally
            //{
            //    conn.Close();
            //    conn.Dispose();
            //    comm.Dispose();
            //}
        }
    }
}
