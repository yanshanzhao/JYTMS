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

        #region 成员变量
        private string PriConStr;
        private ClsG ObjG;
        private string PriFilePath;//文件路径
        private string[] PriExtention = { ".xls" };//允许上传的文件的扩展类型
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
            //获得表的说明赋值给DataTable
            //PriTydColsDescription = ClsRWMSSQLDb.GetColDescription("T_LineTmp", PriConStr);
            //获得文件的路径
            PriFilePath = Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), ClsOptions.WebCfg.YDFILES  + DateTime.Now.ToString("yyyyMM"));
            if (!Directory.Exists(PriFilePath))
                Directory.CreateDirectory(PriFilePath);
            //将指定路径下的文件显示在ListBox中
            ImportFileToDgv(PriFilePath);
            //自定义上传文件路径,调用自定义控件里的Prepare方法
            //PriUploadFoldr = ClsOptions.WebCfg.PosXlsFilePath + DateTime.Now.ToString("yyyyMM");
            ctrlUploadFile1.Prepare(PriFilePath, PriExtention, false, "导入文件");
            ImportFileToDgv(PriFilePath);
            ctrlUploadFile1.PrepareA(new JY.CtrlPub.ImportToDB(DgvAddFile));
            CmbZtlx.SelectedIndex = 0;
            //VCMSLypcTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrKj;
        }


        #region 将存放上传文件的文件夹里的文件名存入DataGridview中
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

        #region  增加新增的文件并选中
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
                ClsMsgBox.Cw("导入错误！", ex);
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

                    // 插入批次信息，获得pcid
                    comm.CommandText = string.Format("INSERT INTO TydTempPc (czyxm,czyzh,czyid,jgid,jgmc,filepath)" +
                    "  VALUES ('{0}','{1}',{2},{3},'{4}','{5}');SELECT SCOPE_IDENTITY()", ObjG.Renyuan.xm, ObjG.Renyuan.loginName, ObjG.Renyuan.id, ObjG.Jigou.id, ObjG.Jigou.mc, filePath);
                    Pcid = Convert.ToInt32(comm.ExecuteScalar());
                    //获取Excel的第一个sheet
                    HSSFSheet hssfsheet = (HSSFSheet)Hssfworkbook.GetSheetAt(0);
                    //保存每个单元格的值
                    List<string> LstCellValue = new List<string>();
                    //List<string> LstValue = new List<string>();
                    for (int i = 1; i <= hssfsheet.LastRowNum; i++)
                    {

                        LstCellValue.Clear();
                        HSSFRow row = (HSSFRow)hssfsheet.GetRow(i);
                        if (row.Cells[0].ToString().Trim().Equals(""))
                            continue;
                        LstCellValue.Add(Pcid.ToString());//批次ID
                        LstCellValue.Add("'" + row.Cells[0].ToString().Trim() + "'");//编号
                        //LstCellValue.Add("'" + row.Cells[1].ToString() + "'");//产品类型
                        LstCellValue.Add("'" + row.Cells[2].ToString().Trim() + "'");//受理机构
                        //LstCellValue.Add("'" + row.Cells[3].ToString() + "'");//起始地
                        LstCellValue.Add("'" + row.Cells[4].ToString().Trim() + "'");//起运时间
                        //LstCellValue.Add("'" + row.Cells[6].ToString().Trim() + "'");//终到位置

                        LstCellValue.Add("'" + row.Cells[10].ToString().Trim() + "'");//客户编号
                        LstCellValue.Add("'" + row.Cells[11].ToString().Trim() + "'");//发货客户名称
                        LstCellValue.Add("'" + row.Cells[12].ToString().Trim() + "'");//发货联系人
                        string fhlxdh = row.Cells[13].ToString().Trim();
                        if (fhlxdh.Length > 16)
                            fhlxdh = fhlxdh.Substring(0, 16);
                        LstCellValue.Add("'" + fhlxdh + "'");//发货联系电话


                        LstCellValue.Add("'" + row.Cells[14].ToString().Trim() + "'");//收货客户名称
                        LstCellValue.Add("'" + row.Cells[15].ToString().Trim() + "'");//到货联系人
                        string dhlxdh = row.Cells[16].ToString().Trim();
                        if (dhlxdh.Length > 16)
                            dhlxdh = dhlxdh.Substring(0, 16);
                        if (dhlxdh.Length == 0)
                            dhlxdh = "0";
                        LstCellValue.Add("'" + dhlxdh + "'");//到货联系电话

                        LstCellValue.Add("'" + row.Cells[19].ToString().Trim() + "'");//提货方式
                        LstCellValue.Add(row.Cells[20].ToString().Trim().Equals("") ? "0" : row.Cells[20].ToString().Trim());//回单份数
                        LstCellValue.Add(row.Cells[21].ToString().Trim().Equals("") ? "0" : row.Cells[21].ToString().Trim());//代收款
                        LstCellValue.Add("'" + (row.Cells[22].ToString().Trim().Equals("") ? "0" : row.Cells[22].ToString().Trim()) + "'");//服务卡号

                        //LstCellValue.Add(row.Cells[27].ToString().Trim());//总件数
                        //LstCellValue.Add(row.Cells[28].ToString().Trim());//总重量
                        //LstCellValue.Add(row.Cells[29].ToString().Trim());//总体积
                        //LstCellValue.Add(row.Cells[31].ToString().Trim());//保价金额
                        //LstCellValue.Add(row.Cells[32].ToString().Trim());//保价费
                        //LstCellValue.Add(row.Cells[34].ToString().Trim());//运费
                        //LstCellValue.Add(row.Cells[36].ToString().Trim());//直送费
                        //LstCellValue.Add(row.Cells[38].ToString().Trim());//上楼费
                        //LstCellValue.Add("'" + row.Cells[44].ToString().Trim() + "'");//货物名称



                        LstCellValue.Add(row.Cells[27].ToString().Trim().Equals("") ? "0" : row.Cells[27].ToString().Trim());//总件数
                        LstCellValue.Add(row.Cells[28].ToString().Trim().Equals("") ? "0" : row.Cells[28].ToString().Trim());//总重量

                        LstCellValue.Add(row.Cells[30].ToString().Trim().Equals("") ? "0" : row.Cells[30].ToString().Trim());//总体积
                        LstCellValue.Add(row.Cells[32].ToString().Trim().Equals("") ? "0" : row.Cells[32].ToString().Trim());//保价金额
                        LstCellValue.Add(row.Cells[33].ToString().Trim().Equals("") ? "0" : row.Cells[33].ToString().Trim());//保价费
                        LstCellValue.Add(row.Cells[35].ToString().Trim().Equals("") ? "0" : row.Cells[35].ToString().Trim());//运费
                        LstCellValue.Add("'" + row.Cells[36].ToString().Trim() + "'");//付款方式 
                        LstCellValue.Add(row.Cells[37].ToString().Trim().Equals("") ? "0" : row.Cells[37].ToString().Trim());//直送费

                        LstCellValue.Add(row.Cells[39].ToString().Trim().Equals("") ? "0" : row.Cells[39].ToString().Trim());//上楼费
                        if (string.IsNullOrEmpty(row.Cells[45].ToString().Trim()))
                        {
                            aBool = false;
                            aTs = "第" + (i + 1) + "行货物名称为空！";
                            break;
                        }
                        LstCellValue.Add("'" + row.Cells[45].ToString().Trim() + "'");//货物名称


                        LstCellValue.Add("'" + DateTime.Now.AddDays(3) + "'");//预计到达时间
                        LstCellValue.Add("'" + row.Cells[56].ToString().Trim() + "'");//代收款种类

                        if (string.IsNullOrEmpty(row.Cells[60].ToString().Trim()))
                        {
                            aBool = false;
                            aTs = "第" + (i + 1) + "行县id为空！";
                            break;
                        }

                        int n;
                        if (!int.TryParse(row.Cells[60].ToString().Trim(), out n))
                        {
                            aBool = false;
                            aTs = "第" + (i + 1) + "行县id的值有异常！";
                            break;
                        }
                        LstCellValue.Add(row.Cells[60].ToString().Trim());
                        if (string.IsNullOrEmpty(row.Cells[61].ToString().Trim()))
                        {
                            aBool = false;
                            aTs = "第" + (i + 1) + "行县name为空！";
                            break;
                        }
                        string zdwzmc=row.Cells[61].ToString().Trim();
                        int last = zdwzmc.LastIndexOf("@");
                        if (last <= 0)
                        {
                            aBool = false;
                            aTs = "第" + (i + 1) + "行县name值异常！";
                            break;
                        }
                        LstCellValue.Add("'"+zdwzmc.Substring(last+1)+"'");
                        comm.CommandText = "INSERT INTO TydTemp (pcid,bh,sljgmc,qysj,khbh,fhkhmc,fhlxr,fhlxdh,shkhmc,shlxr,shlxdh,ztbzs,hdfs,dsk,fwkh,zjs,zzl,ztj,bjje,bf,yf,fkfsmc,zsf,qtfy,hwmc,yjddsj,dskzls,zdwzid,zdwzmc) VALUES " + "(" + string.Join(",", LstCellValue) + ")";
                        comm.ExecuteNonQuery();
                    }
                    if (aBool)
                    {
                        trans.Commit();
                        ClsMsgBox.Ts("导入成功！", ObjG.CustomMsgBox, this);
                    }
                    else
                    {
                        trans.Rollback();
                        ClsMsgBox.Ts("导入失败！" + aTs, ObjG.CustomMsgBox, this);
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
                ClsMsgBox.YesNo("确认删除" + Dgv.CurrentRow.Cells[0].Value + "吗？", new EventHandler(DeleteFile));
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
            if (CmbZtlx.Text == "初始")
                where += " AND zt = 0";
            else if (CmbZtlx.Text == "已通过")
                where += " AND zt = 1";
            else if (CmbZtlx.Text == "未通过")
                where += " AND zt = 2";
            else //if (CmbZtlx.Text == "已导入")
                where += " AND zt = 3";
            //TydTempPcTableAdapter1.FillByWhere(DSYDIMPORT1.TydTempPc, where);
            //ChangeCloor();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            //if (Bds.Current == null)
            //    return;
            //ClsMsgBox.YesNo("是否删除运单信息？", new EventHandler(Delete), ObjG.CustomMsgBox, this);
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
            //            ClsMsgBox.Ts("不能删除导入成功的数据！", f, this);
            //            return;
            //        }
            //        TydTempPcTableAdapter1.Delete(row.id);
            //        Bds.RemoveCurrent();
            //        DSYDIMPORT1.AcceptChanges();
            //        ClsMsgBox.Ts("删除成功！", f, this);
            //    }
            //}
        }

        //private void ChangeCloor()
        //{
        //    for (int i = 0; i < DGVDRxx.Rows.Count; i++)
        //    {
        //        if (DGVDRxx.Rows[i].Cells[3].Value.ToString().Equals("未通过"))
        //        {
        //            DGVDRxx.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
        //        }
        //        else if (DGVDRxx.Rows[i].Cells[3].Value.ToString().Equals("已通过"))
        //        {
        //            DGVDRxx.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
        //        }
        //        else if (DGVDRxx.Rows[i].Cells[3].Value.ToString().Equals("已导入"))
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
            //    ClsMsgBox.Ts("导入的信息还没有通过验证或已导入过，不能生成运单！", ObjG.CustomMsgBox, this);
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
            //        parReturn.Direction = ParameterDirection.ReturnValue; 　　//参数类型为ReturnValue                    
            //        cmd.Parameters.Add(parReturn);
            //        cmd.ExecuteNonQuery();
            //        if (Convert.ToInt32(parReturn.Value) == 1)
            //        {
            //            ClsMsgBox.Ts("生成运单全部成功！", ObjG.CustomMsgBox, this);
            //        }
            //        else if (Convert.ToInt32(parReturn.Value) == 0)
            //        {
            //            ClsMsgBox.Ts("生成失败！错误：" + parOutput.Value.ToString(), ObjG.CustomMsgBox, this);
            //        }
            //        else
            //        {
            //            ClsMsgBox.Ts("发生未知错误！", ObjG.CustomMsgBox, this);
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
            //    ClsMsgBox.Ts("请选择要验证的运单信息！", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //DSYDIMPORT.TydTempPcRow Row = ((DataRowView)Bds.Current).Row as DSYDIMPORT.TydTempPcRow;
            //if (Row.zt == 3)
            //{
            //    ClsMsgBox.Ts("该运单已经导入，不用再次检查！", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //if (Row.zt > 0)
            //{
            //    ClsMsgBox.Ts("导入的运单已经验证过，不能再次验证！", ObjG.CustomMsgBox, this);
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
            //    parReturn.Direction = ParameterDirection.ReturnValue; 　　//参数类型为ReturnValue                    
            //    comm.Parameters.Add(parReturn);
            //    comm.ExecuteNonQuery();
            //    int count = Convert.ToInt32(parReturn.Value);
            //    if (count == 0)
            //    {
            //        ClsMsgBox.Ts("验证失败，存在异常运单！", ObjG.CustomMsgBox, this);
            //    }
            //    else
            //    {
            //        ClsMsgBox.Ts("验证导入运单全部成功！", ObjG.CustomMsgBox, this);
            //    }
            //    Bds.RemoveCurrent();
            //}
            //catch (Exception ex)
            //{
            //    ClsMsgBox.Cw("验证导入运单失败！", ex, ObjG.CustomMsgBox, this);
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
