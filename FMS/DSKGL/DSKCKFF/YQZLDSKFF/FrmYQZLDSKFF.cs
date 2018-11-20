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
using JYPubFiles.Classes;
using System.Data.SqlClient;
using System.IO;
using FMS.DSKGL.DSKDK;
using System.Net;
using System.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
#endregion

namespace FMS.DSKGL.DSKCKFF.YQZLDSKFF
{
    public partial class FrmYQZLDSKFF : UserControl
    {
        #region ��Ա����
        private string PriWhere;
        private ClsG ObjG;
        FrmMsgBox Box = new FrmMsgBox();
        private DSYQZLDSKFF.VfmsYQZLDSKFFRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as DSYQZLDSKFF.VfmsYQZLDSKFFRow;
                }
            }
        }
        #endregion
        public FrmYQZLDSKFF()
        {
            InitializeComponent();
        }
        public void Prepare()
        {

            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable("select 'all' as bh,'--ȫ��--' as mc union all select bh,mc from Tfmsdskffyhlx where zt=1  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbYhlx, dtYhlx, "bh", "mc");
            CmbYhlx.SelectedIndex = 0;
            CmbDkzt.SelectedIndex = 0;
            this.VfmsYQZLDSKFFTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            //BtnSearch.PerformClick();

        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PriWhere = " where fhzt = 10  ";
            PriWhere += CmbYhlx.SelectedValue.Equals("all") ? "" : " and ffyhlx ='" + CmbYhlx.SelectedValue + "'";
            if (DtpFfStart.Checked)
                PriWhere += " and ffsj>='" + DtpFfStart.Value.Date + "'";
            if (DtpFfStop.Checked)
                PriWhere += " and ffsj<'" + DtpFfStop.Value.AddDays(1).Date + "'";
            if (DtpDkStart.Checked)
            {
                PriWhere += "  and dksj >='" + DtpDkStart.Value.Date + "'";
            }
            if (DtpDkStop.Checked)
            {
                PriWhere = PriWhere + " and  dksj<'" + DtpDkStop.Value.AddDays(1).Date + "'";
            }
            if (CmbDkzt.SelectedIndex == 0)
                PriWhere += " and  zt = 0 ";
            if (CmbDkzt.SelectedIndex == 1)
                PriWhere += " and  zt = 10 ";
            this.VfmsYQZLDSKFFTableAdapter1.FillByWhere1(DSYQZLDSKFF1.VfmsYQZLDSKFF, PriWhere);
            if (Dgv.RowCount == 0)
                ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ��", ObjG.CustomMsgBox, this);
            else
                GetBh();

        }
        private void GetBh()
        {
            for (int i = 0; i < Dgv.Rows.Count; i++)
            {
                Dgv.Rows[i].Cells[0].Value = Dgv.Rows[i].Index + 1;
            }
        }

        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == 10)//����
            {
                if (PriRow.zt == 20)
                {
                    ClsMsgBox.Ts("�����еĲ������ٴδ�", ObjG.CustomMsgBox, this);
                    return;
                }
                if (PriRow.zt == 10)
                {
                    ClsMsgBox.Ts("�ñʴ��տ��Ѵ������ٴδ�", ObjG.CustomMsgBox, this);
                    return;
                }
                if (PriRow.fhzt == 0)
                {
                    ClsMsgBox.Ts("�ñʴ��տ�Ϊ����״̬�������", ObjG.CustomMsgBox, this);
                    return;
                }
                FrmPwd f = new FrmPwd();
                f.Prepare();
                f.ShowDialog();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);

            }
            if (e.ColumnIndex == 11)
            {
                if (PriRow.id == 0)
                {
                    ClsMsgBox.Ts("�����쳣��", ObjG.CustomMsgBox, this);
                    return;
                }
                FrmYQZLDSKFFMX f = new FrmYQZLDSKFFMX();
                f.ShowDialog();
                f.Prepare(PriRow.id, PriRow.zje.ToString(), PriRow.sxf.ToString(), PriRow.sfje.ToString(), PriRow.bs.ToString());
            }
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPwd f = sender as FrmPwd;
            if (f.DialogResult == DialogResult.Yes)
            {
                if (Dgv.CurrentRow.Cells[DgvColTxtcz.Name].Value.ToString() == "���")
                {
                    DKYesNo("��ȷ��Ҫ�����", new EventHandler(Dk), Box, this);
                }
            }
        }
        #region ���Ĳ���
        void Dk(object sender, EventArgs e)
        {
            //���״̬���ȱ��10���Ѵ�����������ϴ��ɹ����ϴ�״̬����ϴ��ɹ���ͬʱ���״̬���20�������У������ʧ�ܣ��ϴ�״̬Ϊʧ�ܣ����״̬���䣨����10���������ٴδ��ٴδ��ʱ��Ҫ���ݱ����ϴ�״̬�����״̬���20�������У���ͬʱ��֤���״̬��20ʱ�������ٴδ����Ӵ����־����¼�����Ϣ�����ʱ����Ҫ�ڸ��´�ʽ
            Form f = sender as Form;
            FrmMsgBox frm = new FrmMsgBox();
            if (f.DialogResult != DialogResult.Yes)
                return;
            using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
            {
                conn.Open();
                SqlTransaction Trans = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.Transaction = Trans;
                DataTable dt = ClsRWMSSQLDb.GetDataTable(string.Format(" select yhzh,mc,sfje,id,dskid,dsk,ydid from VfmsYQZLDSKFFMx where pcid={0} order by id", PriRow.id), ClsGlobals.CntStrTMS);
                if (dt.Rows.Count == 0)
                {
                    ClsMsgBox.Ts("û��Ҫ���ŵ���ϸ��", ObjG.CustomMsgBox, this);
                    return;
                }
                try
                {
                    comm.CommandText = string.Format("insert into tfmsdskckfflog (ffpcid,ffsj,insczyid,insczyxm) values ({0},'{1}',{2},'{3}')SELECT SCOPE_IDENTITY();", PriRow.id, PriRow.ffsj, ObjG.Renyuan.id, ObjG.Renyuan.xm);
                    int pcid = Convert.ToInt32(comm.ExecuteScalar());
                    comm.CommandText = string.Format("INSERT INTO dbo.Tfmsdskckffmxlog ( pcid, ydid, dskid, je, zt ) SELECT {0},ydid,dskid,dsk-sxf,0 FROM dbo.tfmsdskckffmx WHERE pcid={1} order by id", pcid, PriRow.id);
                    comm.ExecuteNonQuery();
                    string PriFln = DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";//�ļ�����
                    //�����ļ�·��
                    string path = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("OriginalFilePath"), PriFln);
                    FileStream fs1 = new FileStream(path, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs1, System.Text.Encoding.GetEncoding("GB2312"));
                    string str = "";
                    //PriLstStr = new List<string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //PriLstStr.Add("(" + pcid + "," + Convert.ToInt32(dt.Rows[i]["ydid"]) + "," + Convert.ToInt32(dt.Rows[i]["dskid"]) + "," + Convert.ToDecimal(dt.Rows[i]["sfje"]) + ")");
                        for (int j = 0; j < 3; j++)
                        {
                            if (j < 2)
                            {
                                str += dt.Rows[i][j].ToString();
                                str += "|";
                            }
                            else if (j == 2)
                            {
                                str += (double.Parse(dt.Rows[i][j].ToString()).ToString());
                            }
                        }
                        str += "\r\n";
                    }
                    str = str.Substring(0, str.LastIndexOf("\r\n"));
                    sw.WriteLine(str);//Ҫд�����Ϣ��  
                    sw.Close();
                    fs1.Close();
                    //ftp�ϴ�
                    bool isload = Upload(path, ConfigurationManager.AppSettings.Get("FtpIp"), ConfigurationManager.AppSettings.Get("FtpLoginName"), ConfigurationManager.AppSettings.Get("FtpPassWord"));
                    string TargetPath =  System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("FtpFilePath"), PriFln);
                    //Ŀ���ļ�·��
                    //string TargetPath = ConfigurationManager.AppSettings.Get("ParamTargetPath") + PriFln;
                    //File.Copy(path, TargetPath, true);
                    //FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read)
                    comm.CommandText = " SET NOCOUNT OFF Update tfmsdskckffpc set fhzt = 0,sczt = 0, filepath = '" + TargetPath + "' where id=" + PriRow.id + " and  fhzt = 10; ";
                    //comm.CommandText += string.Format("INSERT INTO dbo.Tfmsdskckffmxlog ( pcid, ydid, dskid, je, zt ) SELECT pcid,ydid,dskid,dsk-sxf,0 FROM dbo.tfmsdskckffmx WHERE pcid={0}",PriRow.id);
                    if (comm.ExecuteNonQuery() > 0 && isload)
                    {
                        Trans.Commit();
                        ClsMsgBox.Ts("�ϴ��ļ��ɹ���", ObjG.CustomMsgBox, this);
                        Bds.RemoveCurrent();
                    }
                    else
                    {
                        Trans.Rollback();
                        ClsMsgBox.Ts("�ϴ��ļ�ʧ�ܣ�", ObjG.CustomMsgBox, this);
                    }
                }
                catch (Exception ex)
                {
                    Trans.Rollback();
                    ClsMsgBox.Cw("�ϴ��ļ�ʧ��", ex, ObjG.CustomMsgBox, this);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region FTP �ϴ�

        public bool Upload(string filename, string ftpServerIP, string ftpUserID, string ftpPassword)
        {

            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
            // ����uri����FtpWebRequest����
            FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            // ָ�����ݴ�������
            reqFTP.UseBinary = true;
            // ftp�û���������
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            // Ĭ��Ϊtrue�����Ӳ��ᱻ�ر�
            // ��һ������֮��ִ��
            reqFTP.KeepAlive = false;
            // ָ��ִ��ʲô����
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            // �ϴ��ļ�ʱ֪ͨ�������ļ��Ĵ�С
            reqFTP.ContentLength = fileInf.Length;
            // �����С����Ϊkb 
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            // ��һ���ļ���(System.IO.FileStream) ȥ���ϴ����ļ�
            FileStream fs = fileInf.OpenRead();
            try
            {
                // ���ϴ����ļ�д����
                Stream strm = reqFTP.GetRequestStream();
                // ÿ�ζ��ļ�����kb
                contentLen = fs.Read(buff, 0, buffLength);
                // ������û�н���
                while (contentLen != 0)
                {
                    // �����ݴ�file stream д��upload stream 
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                // �ر�������
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// ���տ���ȷ��
        /// </summary>
        public static void DKYesNo(string mess, EventHandler hdl, FrmMsgBox aMsgBox = null, Control aParControl = null, float aFontsize = 20)
        {
            aMsgBox.Text = "����";
            aMsgBox.LblMess.Text = mess;
            aMsgBox.LblMess.Font = new System.Drawing.Font("����", aFontsize, System.Drawing.FontStyle.Bold);
            aMsgBox.LblMess.ForeColor = System.Drawing.Color.Red;
            aMsgBox.Btn1.Text = "ȷ��";
            aMsgBox.Btn1.AutoSize = true;
            aMsgBox.Btn1.DialogResult = DialogResult.Yes;
            aMsgBox.Btn2.Text = "ȡ��";
            aMsgBox.Btn2.Visible = true;
            aMsgBox.Btn2.AutoSize = true;
            aMsgBox.Btn2.DialogResult = DialogResult.No;
            //aMsgBox.Btn1.TabStop = false;
            aMsgBox.FrmCloseHdl = hdl;
            aMsgBox.Tag = null;
            aMsgBox.ShowDialog();
            if (aParControl == null)
                return;
            IApplicationContext objApplicationContext = aParControl.Context as IApplicationContext;
            if (objApplicationContext != null)
                objApplicationContext.SetFocused(aMsgBox, true);
        }
    }
}
