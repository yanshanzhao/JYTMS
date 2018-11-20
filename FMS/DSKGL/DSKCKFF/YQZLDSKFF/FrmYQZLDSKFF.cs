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
        #region 成员变量
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
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable("select 'all' as bh,'--全部--' as mc union all select bh,mc from Tfmsdskffyhlx where zt=1  ", ClsGlobals.CntStrTMS);
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
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
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
            if (e.ColumnIndex == 10)//打款动作
            {
                if (PriRow.zt == 20)
                {
                    ClsMsgBox.Ts("打款处理中的不允许再次打款！", ObjG.CustomMsgBox, this);
                    return;
                }
                if (PriRow.zt == 10)
                {
                    ClsMsgBox.Ts("该笔代收款已打款不允许再次打款！", ObjG.CustomMsgBox, this);
                    return;
                }
                if (PriRow.fhzt == 0)
                {
                    ClsMsgBox.Ts("该笔代收款为挂起状态不允许打款！", ObjG.CustomMsgBox, this);
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
                    ClsMsgBox.Ts("出现异常！", ObjG.CustomMsgBox, this);
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
                if (Dgv.CurrentRow.Cells[DgvColTxtcz.Name].Value.ToString() == "打款")
                {
                    DKYesNo("您确认要打款吗？", new EventHandler(Dk), Box, this);
                }
            }
        }
        #region 打款的操作
        void Dk(object sender, EventArgs e)
        {
            //打款状态首先变成10（已打款），如果报文上传成功，上传状态变成上传成功，同时打款状态变成20（打款处理中），如果失败，上传状态为失败，打款状态不变（保持10）。允许再次打款，再次打款时需要根据报文上传状态将打款状态变成20（打款处理中），同时保证打款状态是20时不允许再次打款。增加打款日志表，记录打款信息，打款时不需要在更新打款方式
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
                    ClsMsgBox.Ts("没有要发放的明细！", ObjG.CustomMsgBox, this);
                    return;
                }
                try
                {
                    comm.CommandText = string.Format("insert into tfmsdskckfflog (ffpcid,ffsj,insczyid,insczyxm) values ({0},'{1}',{2},'{3}')SELECT SCOPE_IDENTITY();", PriRow.id, PriRow.ffsj, ObjG.Renyuan.id, ObjG.Renyuan.xm);
                    int pcid = Convert.ToInt32(comm.ExecuteScalar());
                    comm.CommandText = string.Format("INSERT INTO dbo.Tfmsdskckffmxlog ( pcid, ydid, dskid, je, zt ) SELECT {0},ydid,dskid,dsk-sxf,0 FROM dbo.tfmsdskckffmx WHERE pcid={1} order by id", pcid, PriRow.id);
                    comm.ExecuteNonQuery();
                    string PriFln = DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";//文件名称
                    //现有文件路径
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
                    sw.WriteLine(str);//要写入的信息。  
                    sw.Close();
                    fs1.Close();
                    //ftp上传
                    bool isload = Upload(path, ConfigurationManager.AppSettings.Get("FtpIp"), ConfigurationManager.AppSettings.Get("FtpLoginName"), ConfigurationManager.AppSettings.Get("FtpPassWord"));
                    string TargetPath =  System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("FtpFilePath"), PriFln);
                    //目标文件路径
                    //string TargetPath = ConfigurationManager.AppSettings.Get("ParamTargetPath") + PriFln;
                    //File.Copy(path, TargetPath, true);
                    //FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read)
                    comm.CommandText = " SET NOCOUNT OFF Update tfmsdskckffpc set fhzt = 0,sczt = 0, filepath = '" + TargetPath + "' where id=" + PriRow.id + " and  fhzt = 10; ";
                    //comm.CommandText += string.Format("INSERT INTO dbo.Tfmsdskckffmxlog ( pcid, ydid, dskid, je, zt ) SELECT pcid,ydid,dskid,dsk-sxf,0 FROM dbo.tfmsdskckffmx WHERE pcid={0}",PriRow.id);
                    if (comm.ExecuteNonQuery() > 0 && isload)
                    {
                        Trans.Commit();
                        ClsMsgBox.Ts("上传文件成功！", ObjG.CustomMsgBox, this);
                        Bds.RemoveCurrent();
                    }
                    else
                    {
                        Trans.Rollback();
                        ClsMsgBox.Ts("上传文件失败！", ObjG.CustomMsgBox, this);
                    }
                }
                catch (Exception ex)
                {
                    Trans.Rollback();
                    ClsMsgBox.Cw("上传文件失败", ex, ObjG.CustomMsgBox, this);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region FTP 上传

        public bool Upload(string filename, string ftpServerIP, string ftpUserID, string ftpPassword)
        {

            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
            // 根据uri创建FtpWebRequest对象
            FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            // 指定数据传输类型
            reqFTP.UseBinary = true;
            // ftp用户名和密码
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            // 默认为true，连接不会被关闭
            // 在一个命令之后被执行
            reqFTP.KeepAlive = false;
            // 指定执行什么命令
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            // 上传文件时通知服务器文件的大小
            reqFTP.ContentLength = fileInf.Length;
            // 缓冲大小设置为kb 
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            // 打开一个文件流(System.IO.FileStream) 去读上传的文件
            FileStream fs = fileInf.OpenRead();
            try
            {
                // 把上传的文件写入流
                Stream strm = reqFTP.GetRequestStream();
                // 每次读文件流的kb
                contentLen = fs.Read(buff, 0, buffLength);
                // 流内容没有结束
                while (contentLen != 0)
                {
                    // 把内容从file stream 写入upload stream 
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                // 关闭两个流
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
        /// 代收款打款确认
        /// </summary>
        public static void DKYesNo(string mess, EventHandler hdl, FrmMsgBox aMsgBox = null, Control aParControl = null, float aFontsize = 20)
        {
            aMsgBox.Text = "警告";
            aMsgBox.LblMess.Text = mess;
            aMsgBox.LblMess.Font = new System.Drawing.Font("黑体", aFontsize, System.Drawing.FontStyle.Bold);
            aMsgBox.LblMess.ForeColor = System.Drawing.Color.Red;
            aMsgBox.Btn1.Text = "确定";
            aMsgBox.Btn1.AutoSize = true;
            aMsgBox.Btn1.DialogResult = DialogResult.Yes;
            aMsgBox.Btn2.Text = "取消";
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
