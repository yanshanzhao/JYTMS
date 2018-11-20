#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Linq;
using JY.Pri;
using JY.Pub;
using FMS.SeleFrm;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
#endregion
namespace FMS.DSKGL.QRYCDSKMX
{
    public partial class FrmQRYCDSKMX : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private string PriWhere = "";
        //private string PriStrCon = "";
        private int PriJgid = 0;
        private string PriLogMC = "";
        private int PriZhid = 0;
        private string PriXm = "";
        private List<DSQRYCDSK.VfmsqrycdskmxRow> PriListId = new List<DSQRYCDSK.VfmsqrycdskmxRow>();
        //private int PriYdCounts = 0;
        private double PriSumDsk = 0;
        private double PriXjje = 0;
        private double PriPosje = 0;
        private double PriJhje = 0;
        private double PriNhje = 0;
        private double PriZSje = 0;
        private int PriJgids = 0;
        private string PriJgidStr = "";
        private int PriRowsCunt = 0;
        private int chashu = 0;
        private double jezh = 0;
        #endregion
        public FrmQRYCDSKMX()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            CmbDskbz.SelectedIndex = 2;
            CmbZffs.SelectedIndex = 0;
            CmbCkjgkhh.SelectedIndex = 0;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            //PriStrCon = ClsGlobals.CntStrTMS;
            PriJgid = ObjG.Jigou.id;
            PriLogMC = ObjG.Renyuan.loginName;
            PriZhid = ObjG.Renyuan.id;
            PriXm = ObjG.Renyuan.xm;
            this.Lbljgid.Text = "��ѡ��0������";
            CmbYqzldk.SelectedIndex = 0;
            CmbDkfs.SelectedIndex = 0;
            CmbDjzt.SelectedIndex = 1;
            CmbPOSpz.SelectedIndex = 0;
            CmbPpzt.SelectedIndex = 0;
            VfmsqrycdskmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.DSQRYCDSK1.EnforceConstraints = false;
            CmbZflx.SelectedIndex = 0;
        }
        #region ��ѯ
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PriWhere = "";
            PriWhere = " where  zt not in (0,5)   and tojgid=" + PriJgid ;
            PriWhere += "  and  jdzt='" + this.CmbDjzt.Text + "'";
            if (CmbZflx.SelectedIndex != 0)
                PriWhere += " and   zflxs='" + CmbZflx.Text.Trim() + "'";
            if (CmbZflx.Text.Equals("����"))
                PriWhere += " and poszt='" + CmbPOSpz.Text + "'";
            else if (CmbZflx.Text.Equals("��ά��֧��"))
                PriWhere += " and xtppzts='" + CmbPpzt.Text + "'";
            else
                PriWhere += " and poszt='" + CmbPOSpz.Text + "' and xtppzts='" + CmbPpzt.Text + "'";
            if (TxtRbdh.Text.Trim().Length > 0)
                PriWhere += "  and  rbdh='" + TxtRbdh.Text.Trim() + "'";
            decimal n;
            if (TxtBJe1.Text.Trim().Length > 0)
            {
                if (!decimal.TryParse(TxtBJe1.Text.Trim(), out n))
                {
                    ClsMsgBox.Ts("��������ȷ�Ľ���ʽ��");
                    return;
                }
                PriWhere += "  and  dsk>=" + TxtBJe1.Text.Trim() + "";
            }
            if (TxtBJe2.Text.Trim().Length > 0)
            {
                if (!decimal.TryParse(TxtBJe2.Text.Trim(), out n))
                {
                    ClsMsgBox.Ts("��������ȷ�Ľ���ʽ��");
                    return;
                }
                PriWhere += "  and  dsk<" + TxtBJe2.Text.Trim() + "";
            }
            if (CmbDskbz.SelectedIndex != 1)
                PriWhere += " and ztmc='" + CmbDskbz.Text + "'";
            if (PriJgids != 0)
                PriWhere += " and jgid in (" + PriJgidStr.Substring(0, PriJgidStr.Length - 1) + ")";
            if (CmbZffs.SelectedIndex != 0)
                PriWhere += " and zzfsmc='" + CmbZffs.Text + "'";
            if (DtpStart.Checked)
                PriWhere += "  and zzsj >='" + DtpStart.Value.Date + "'";
            if (DtpStop.Checked)
                PriWhere += "  and zzsj <'" + DtpStop.Value.AddDays(1).Date + "'";
            if (DtpShrq.Checked)
                PriWhere += "   and shsj  >= '" + DtpShrq.Value.Date + "' and  shsj <'" + DtpShrq.Value.AddDays(1).Date + "'"; ;
            if (CmbCkjgkhh.SelectedIndex != 0)
            {
                string aYhlx = CmbCkjgkhh.Text.ToString().Substring(0, 1);
                PriWhere += " and yhlx like '" + aYhlx + "%' ";
            }
            if (CmbYqzldk.SelectedIndex != 0)
                PriWhere += " and dkzt='" + CmbYqzldk.Text + "'";
            if (CmbDkfs.SelectedIndex != 0)
                PriWhere += " and dkfs='" + CmbDkfs.Text + "'";
            PriWhere += " order by px,ckjgmc,zzsj ";
            Clear();
            VfmsqrycdskmxTableAdapter1.FillByWhere1(this.DSQRYCDSK1.Vfmsqrycdskmx, PriWhere);
            if (!(DSQRYCDSK1.Vfmsqrycdskmx.Compute("sum(dkje)", "1=1") is DBNull))
            {
                jezh = Convert.ToDouble(DSQRYCDSK1.Vfmsqrycdskmx.Compute("sum(dkje)", "1=1"));
            }
            LblCheckCount.Text = "��ѡ��0��";
            LblCheckSumJe.Text = "POS " + this.DSQRYCDSK1.Vfmsqrycdskmx.Compute("sum(dsk)", "zzfsmc='POS'").ToString() + "Ԫ,�ֽ� "
                + this.DSQRYCDSK1.Vfmsqrycdskmx.Compute("sum(dsk)", " zzfsmc like '��%' ") + "Ԫ�����н��� " + this.DSQRYCDSK1.Vfmsqrycdskmx.Compute("sum(dsk)", " zzfsmc like '��%'  and yhlx like '��%' ").ToString()
                + "Ԫ��ũ�� " + this.DSQRYCDSK1.Vfmsqrycdskmx.Compute("sum(dsk)", " zzfsmc like '��%'  and yhlx like 'ũ%' ").ToString() + "Ԫ������" + this.DSQRYCDSK1.Vfmsqrycdskmx.Compute("sum(dsk)", " zzfsmc like '��%'  and yhlx like '��%' ").ToString() + "Ԫ" + ",���۽���ܺ�Ϊ��0.00Ԫ";
            if (Dgv.RowCount == 0)
                ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ��", ObjG.CustomMsgBox, this);
            else
                AddColor();//�����ɫ
            chashu = 0;
            jezh = 0;
        }
        private void AddColor()
        {
            for (int i = 0; i < Dgv.Rows.Count; i++)
            {
                decimal dskje = Convert.ToDecimal(Dgv.Rows[i].Cells["DgvColTxtdsk"].Value);
                decimal dkje = string.IsNullOrEmpty(Dgv.Rows[i].Cells["DgvColTxtDkje"].Value.ToString()) ? 0 : Convert.ToDecimal(Dgv.Rows[i].Cells["DgvColTxtDkje"].Value);
                if (dskje != dkje)
                {
                    if (string.IsNullOrEmpty(Dgv.Rows[i].Cells["DgvColTxtDkje"].Value.ToString()))
                        continue;
                    Dgv.Rows[i].Cells["DgvColTxtDkje"].Style.ForeColor = Color.Red;
                }
            }
        }
        #endregion
        #region Clear()
        private void Clear()
        {
            PriListId.Clear();
            //PriYdCounts = 0;
            PriSumDsk = 0;
            PriXjje = 0;
            PriPosje = 0;
            PriJhje = 0;
            PriNhje = 0;
            PriZSje = 0;
            PriRowsCunt = 0;
            ChkB.Checked = false;
            GetXx();
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
            ClsExcel.CreatExcel(this.Dgv, "���տ�Ӧ����ϸ", this.ctrlDownLoad1, new int[] { 4, 5, 6 });
            //string PriFln = "���տ�Ӧ����ϸ" + ".xls";//�ļ�����     
            //string PriFlp = System.IO.Path.Combine(this.Context.HttpContext.Request.PhysicalApplicationPath +
            //    "App_Data\\Download", PriFln);//����ļ�·��
            //HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
            ////д������
            //HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            //sheet1.DefaultColumnWidth = 17;
            //sheet1.SetColumnWidth(1, 25 * 100);
            //try
            //{
            //    //�����ĵ�����
            //    HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
            //    for (int i = 0; i < Dgv.ColumnCount - 4; i++)
            //    {
            //        if (i == 0)
            //            row0.CreateCell(i).SetCellValue("��������");
            //        else
            //            row0.CreateCell(i).SetCellValue(Dgv.Columns[i + 1].HeaderText);
            //    }
            //    int roowIndex = 1;
            //    //�������
            //    HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
            //    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
            //    foreach (DataGridViewRow Row in Dgv.Rows)
            //    {
            //        HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
            //        for (int i = 0; i < Dgv.ColumnCount - 4; i++)
            //        {
            //            if (i == 2)
            //                hssfrow.CreateCell(i).SetCellValue("");
            //            else if (i == 3)
            //            {
            //                DateTime dTime;
            //                if (DateTime.TryParse(Row.Cells[i + 1].Value.ToString(), out dTime))
            //                    hssfrow.CreateCell(i).SetCellValue(Convert.ToDateTime(Row.Cells[i + 1].Value).ToString("yyyy-MM-dd HH:mm:ss"));
            //                else
            //                    hssfrow.CreateCell(i).SetCellValue(Row.Cells[i + 1].Value.ToString());
            //            }
            //            else
            //            {
            //                if (i == 4 || i == 5 || i == 6)
            //                {
            //                    hssfrow.CreateCell(i).SetCellValue(Convert.ToDouble(Row.Cells[i + 1].Value));
            //                    hssfrow.Cells[i].CellStyle = cellStyle;
            //                }
            //                else
            //                    hssfrow.CreateCell(i).SetCellValue(Row.Cells[i + 1].Value.ToString());
            //            }
            //        }
            //        roowIndex++;
            //    }

            //    FileStream file = new FileStream(PriFlp, FileMode.Create);
            //    hssfworkbook.Write(file);
            //    file.Close();
            //    this.ctrlDownLoad1.download(PriFlp, true);
            //}
            //catch (Exception ex)
            //{
            //    ClsMsgBox.Cw("��������ʧ��", ex);
            //    return;
            //}
        }
        #endregion
        #region ����
        private void BtnJG_Click(object sender, EventArgs e)
        {
            FrmSelectJg4 f = new FrmSelectJg4();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg4 f = sender as FrmSelectJg4;
            if (f.DialogResult == DialogResult.OK)
            {
                //this.TxtCkjg.Text = f.PubDictAttrs["mc"];
                //this.Lbljgid.Text = f.PubDictAttrs["id"];
                this.Lbljgid.Text = "��ѡ��" + f.PubCountJgs + "������";
                PriJgids = f.PubCountJgs;
                PriJgidStr = f.PubStr;
            }
            else
            {
                this.Lbljgid.Text = "��ѡ��0������";
                PriJgids = 0;
                PriJgidStr = "";
            }
        }
        /*
        private void TxtCkjg_KeyDown(object objSender, KeyEventArgs objArgs)
        {
            if (objArgs.KeyCode == Keys.Back)
            {
                this.TxtCkjg.Text = "";
                this.Lbljgid.Text = "0";
            }
        }
        #endregion
        #region ��굥ѡ
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex <= -1)
                return;
            if (e.ColumnIndex == 0)//��˶���
            {
                int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtid.Name].Value);
                int n;
                int aYdcount = 0;
                if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                    aYdcount = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value);
                double m;
                double adsk = 0;
                if (double.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                    adsk = Convert.ToDouble(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvColChkXz.Name].Value))//ȡ��
                {
                    Dgv.Rows[e.RowIndex].Cells[DgvColChkXz.Name].Value = false;
                    PriListId.Remove(aId);
                    PriYdCounts = PriYdCounts - aYdcount;
                    PriSumDsk = PriSumDsk - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("�ֽ�"))
                        PriXjje = PriXjje - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).ToUpper().Contains("POS"))
                        PriPosje = PriPosje - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).Contains("ũ") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                        PriNhje = PriNhje - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).ToUpper().Contains("��") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                        PriJhje = PriJhje - adsk;
                }
                else
                {
                    if (Dgv.Rows[e.RowIndex].Cells[DgvColTxtdskbz.Name].Value.ToString() == "���ͨ��")
                    {
                        ClsMsgBox.Ts("�ô��տ��ձ��Ѿ����ͨ���������ظ���ˣ�", ObjG.CustomMsgBox, this);
                        return;
                    }
                    Dgv.Rows[e.RowIndex].Cells[DgvColChkXz.Name].Value = true;
                    PriListId.Add(aId);
                    PriYdCounts = PriYdCounts + aYdcount;
                    PriSumDsk = PriSumDsk + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("�ֽ�"))
                        PriXjje = PriXjje + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).ToUpper().Contains("POS"))
                        PriPosje = PriPosje + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).Contains("ũ") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                        PriNhje = PriNhje + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).ToUpper().Contains("��") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                        PriJhje = PriJhje + adsk;
                }
                GetXx();
            }
            if (Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("��ϸ��Ϣ"))//��ϸ
            {
                string aRbdh = Dgv.Rows[e.RowIndex].Cells[DgvColTxtrbdh.Name].Value.ToString();
                string aCkjg = Dgv.Rows[e.RowIndex].Cells[DgvColTxtckjg.Name].Value.ToString();
                string aCksj = Convert.ToDateTime(Dgv.Rows[e.RowIndex].Cells[DgvColTxtcksq.Name].Value).ToString("yyyy-MM-dd");//��ʽ
                string aDsk = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString();
                string aYdcounts = "0";
                int n;
                if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                    aYdcounts = Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value.ToString();
                string aDskbz = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdskbz.Name].Value.ToString();
                int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtid.Name].Value);
                FrmQRYCDSKMXLL f = new FrmQRYCDSKMXLL();
                f.ShowDialog();
                f.Prepare(aRbdh, aCkjg, aCksj, aDsk, aYdcounts, aDskbz, aId);
            }
        }
         */
        #endregion
        #region ���ͨ��
        private void BtnShtg_Click(object sender, EventArgs e)
        {
            //sjdskzt(�Ͻɴ��տ�״̬)��Ĭ��ֵΪ0-δ�ɿ10-�ѱ��棻20-���ύ��30-�ѽɿ�
            if (PriRowsCunt == 0)
            {
                ClsMsgBox.Ts("��ѡ��Ҫ�����Ĵ��տ��ձ���", ObjG.CustomMsgBox, this);
                return;
            }
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (!Convert.ToBoolean(row.Cells[DgvColChkXz.Name].Value))
                    continue;
                Bds.Position = row.Index;
                DSQRYCDSK.VfmsqrycdskmxRow Rows = ((DataRowView)Bds.Current).Row as DSQRYCDSK.VfmsqrycdskmxRow;
                Rows.shsj = DateTime.Now;
                Rows.shczyid = PriZhid;
                Rows.shczyxm = PriXm;
                Rows.shczyzh = PriLogMC;
                Rows.zt = 20;
                PriListId.Add(Rows);
            }
            #region �޸�ʱ�� 2013/10/24
            //using (SqlConnection conn = new SqlConnection(PriStrCon))
            //{
            //    conn.Open();
            //    SqlTransaction trans = conn.BeginTransaction();
            //    SqlCommand comm = new SqlCommand();
            //    try
            //    {
            //        comm.Connection = conn;
            //        comm.Transaction = trans;
            //        string cmdText = "";
            //        cmdText = " SET NOCOUNT OFF update tfmsdsk set sjdskzt='30' where id in(select dskid from Tfmsdskjkmx where pcid  in (" + string.Join(",", PriListId) + "))";
            //        comm.CommandText = cmdText;
            //        int influenceSum = comm.ExecuteNonQuery();
            //        cmdText = " SET NOCOUNT OFF update Tfmsdskjkpc set  zt='20',shczyid=" + PriZhid + ",shczyxm='" + PriXm + "',shczyzh='" + PriLogMC + "',shsj='" + DateTime.Now.ToString() + "' where id  in (" + string.Join(",", PriListId) + ")";
            //        comm.CommandText = cmdText;
            //        influenceSum = influenceSum + comm.ExecuteNonQuery();
            //        if (influenceSum == PriYdCounts + PriListId.Count)
            //        {
            //            //LblCheckSumJe.Text = "��ѡ�д��տ�" + PriSumDsk.ToString() + "Ԫ";
            //            //�ύ����
            //            ClsMsgBox.Ts("��˳ɹ�������˴��տ�" + PriSumDsk.ToString() + "Ԫ", ObjG.CustomMsgBox, this);
            //            trans.Commit();
            //            //Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select b.dqmc,id,Null as  pos,ckjgmc,zzsj,dsk,dkje,sxf,zzfsmc,ztmc,shsj,rbdh,yhlx,yhzh,yhzhmc,cnt,'��ϸ��Ϣ' as Xq,dkzt,dkfs,jdzt,poszt from  Vfmsqrycdskmx  as a left join jyjckj.dbo.Vdqjigou as b on a.jgid=b.jgid " + PriWhere + " order by ckjgmc", PriStrCon);
            //            foreach (DSQRYCDSK.VfmsqrycdskmxRow Row in PriListId)
            //            {
            //                Bds.Remove(Row);
            //            }
            //            Clear();
            //        }
            //        else
            //        {
            //            //�ع�����
            //            ClsMsgBox.Ts("���ʧ�ܣ�", ObjG.CustomMsgBox, this);
            //            trans.Rollback();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //�ع�����
            //        ClsMsgBox.Cw("����쳣��", ex, ObjG.CustomMsgBox, this);
            //        trans.Rollback();

            //    }
            //    finally
            //    {
            //        conn.Close();
            //    }
            //}
            #endregion
            try
            {
                Bds.EndEdit();
                VfmsqrycdskmxTableAdapter1.Update(PriListId.ToArray());
                ClsMsgBox.Ts("��˳ɹ�������˴��տ�" + PriSumDsk.ToString() + "Ԫ", ObjG.CustomMsgBox, this);
                foreach (DSQRYCDSK.VfmsqrycdskmxRow Row in PriListId)
                {
                    Bds.RemoveAt(Bds.Find("id", Row.id));
                }
                Clear();
            }
            catch (Exception ex)
            {
                //�ع�����
                ClsMsgBox.Cw("����쳣��", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion
        #region ��ʾ��Ϣ
        private void GetXx()
        {
            LblCheckCount.Text = "��ѡ��" + PriRowsCunt + "��";
            if (PriSumDsk == 0)
                LblCheckSumJe.Text = "��ѡ��POS 0.00Ԫ,�ֽ� 0.00Ԫ�����н��� 0.00Ԫ��ũ�� 0.00Ԫ�����۽���ܺ�Ϊ0.00����0���޸ġ�";
            else
                LblCheckSumJe.Text = "��ѡ��POS " + PriPosje.ToString() + "Ԫ,�ֽ� " + PriXjje.ToString() + "Ԫ�����н��� " + PriJhje.ToString() + "Ԫ��ũ�� " + PriNhje.ToString() + "Ԫ�����۽���ܺ�Ϊ" + Math.Round(Convert.ToDouble(jezh), 2) + ",��" + chashu + "���޸�";
        }
        #endregion
        #region ��ҳȫѡ
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
                return;
            CheckThisPage1();
            GetXx();
        }
        /// <summary>
        /// �˷�����CheckThisPage1��ͬ
        /// </summary>
        /* public void CheckThisPage()
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
             //int n = 0;//����i�ĳ�ʼֵ
             //int DgvCun = 0;//����Dgv����ʾ��ҳ��
             //if (rowcount % pageSize > 0)
             //{
             //    pageCount++;
             //    if (currentpage < pageCount)
             //    {
             //        n = Dgv.FirstDisplayedScrollingRowIndex;
             //        DgvCun = Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage;
             //    }
             //    else
             //    {
             //        n = Dgv.FirstDisplayedScrollingRowIndex;
             //        DgvCun = Dgv.RowCount;
             //    }
             //}
             //else
             //{
             //    n = Dgv.FirstDisplayedScrollingRowIndex;
             //    DgvCun = Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage;
             //}
             //for (int i = n; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
             //{
             //    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColChkXz.Name].Value))
             //    {
             //        if (Dgv.Rows[i].Cells[DgvColTxtdskbz.Name].Value.ToString() != "���ͨ��")
             //        {
             //            Dgv.Rows[i].Cells[DgvColChkXz.Name].Value = true;
             //            int aId = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value);
             //            int j;
             //            int aYdcount = 0;
             //            if (Int32.TryParse(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out j))
             //                aYdcount = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value);
             //            double m;
             //            double adsk = 0;
             //            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
             //                adsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
             //            PriListId.Add(aId);
             //            PriYdCounts = PriYdCounts + aYdcount;
             //            PriSumDsk = PriSumDsk + adsk;
             //        }
             //    }
             //}
             if (rowcount % pageSize > 0)
             {
                 pageCount++;
                 //�ȼ���������һҳ�ĺϼ�
                 if (currentpage < pageCount)
                 {
                     for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                     {
                         if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColChkXz.Name].Value))
                         {
                             if (Dgv.Rows[i].Cells[DgvColTxtdskbz.Name].Value.ToString() != "���ͨ��")
                             {
                                 Dgv.Rows[i].Cells[DgvColChkXz.Name].Value = true;
                                 int aId = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value);
                                 int n;
                                 int aYdcount = 0;
                                 if (Int32.TryParse(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                                     aYdcount = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value);
                                 double m;
                                 double adsk = 0;
                                 if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                                     adsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                                 PriListId.Add(aId);
                                 PriYdCounts = PriYdCounts + aYdcount;
                                 PriSumDsk = PriSumDsk + adsk;
                             }
                         }
                     }
                 }
                 //�������һҳ��ֵ
                 else
                 {
                     for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                     {
                         if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColChkXz.Name].Value))
                         {
                             if (Dgv.Rows[i].Cells[DgvColTxtdskbz.Name].Value.ToString() != "���ͨ��")
                             {
                                 Dgv.Rows[i].Cells[DgvColChkXz.Name].Value = true;
                                 int aId = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value);
                                 int n;
                                 int aYdcount = 0;
                                 if (Int32.TryParse(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                                     aYdcount = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value);
                                 double m;
                                 double adsk = 0;
                                 if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                                     adsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                                 PriListId.Add(aId);
                                 PriYdCounts = PriYdCounts + aYdcount;
                                 PriSumDsk = PriSumDsk + adsk;
                             }
                         }
                     }
                 }
             }
             else
             {
                 for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                 {
                     if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColChkXz.Name].Value))
                     {
                         if (Dgv.Rows[i].Cells[DgvColTxtdskbz.Name].Value.ToString() != "���ͨ��")
                         {
                             Dgv.Rows[i].Cells[DgvColChkXz.Name].Value = true;
                             int aId = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value);
                             int n;
                             int aYdcount = 0;
                             if (Int32.TryParse(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                                 aYdcount = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value);
                             double m;
                             double adsk = 0;
                             if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                                 adsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                             PriListId.Add(aId);
                             PriYdCounts = PriYdCounts + aYdcount;
                             PriSumDsk = PriSumDsk + adsk;
                         }
                     }
                 }
             }



         }*/

        private void CheckThisPage1()
        {
            if (Dgv.Rows.Count <= 0)
                return;
            int curPageFristIndex = 0;
            int curPageCount = Dgv.ItemsPerPage;
            if (Dgv.CurrentPage > 1)
                curPageFristIndex = (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;
            if (Dgv.CurrentPage == Dgv.TotalPages)
                curPageCount = Dgv.RowCount - (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;
            for (int i = curPageFristIndex; i < curPageCount + curPageFristIndex; i++)
            {
                if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColChkXz.Name].Value))
                {
                    if (Dgv.Rows[i].Cells[DgvColTxtdskbz.Name].Value.ToString() != "���ͨ��")
                    {
                        Dgv.Rows[i].Cells[DgvColChkXz.Name].Value = true;
                        int aId = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value);
                        int n;
                        int aYdcount = 0;
                        if (Int32.TryParse(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                            aYdcount = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYdcounts.Name].Value);
                        double m;
                        double adsk = 0;
                        if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                            adsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                        //PriListId.Add(aId);
                        //PriYdCounts = PriYdCounts + aYdcount;
                        PriSumDsk = PriSumDsk + adsk;
                        if (Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtfkfs.Name].Value).Contains("�ֽ�"))
                            PriXjje = PriXjje + adsk;
                        if (Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtfkfs.Name].Value).ToUpper().Contains("POS"))
                            PriPosje = PriPosje + adsk;
                        if (Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtyhlx.Name].Value).Contains("ũ") && Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                            PriNhje = PriNhje + adsk;
                        if (Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtyhlx.Name].Value).ToUpper().Contains("��") && Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                            PriJhje = PriJhje + adsk;
                        if (Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtyhlx.Name].Value).Contains("����") && Convert.ToString(Dgv.Rows[i].Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                            PriZSje = PriZSje + adsk;

                        PriRowsCunt++;
                        string aaa = ClsRWMSSQLDb.GetStr(" select dkje as jec from Vfmsqrycdskmx where id=" + Dgv.Rows[i].Cells["DgvColTxtid"].Value, ClsGlobals.CntStrTMS);
                        jezh = jezh + Convert.ToDouble(aaa);
                        if (Dgv.Rows[i].Cells["DgvColTxtDkje"].Style.ForeColor == Color.Red)
                        {
                            chashu++;
                        }
                    }
                }
            }
            //GetXx();
        }
        #endregion
        #region ȫѡ
        private void ChkB_CheckedChanged(object sender, EventArgs e)
        {
            CheckAll(ChkB.Checked);
            GetXx();
        }
        public void CheckAll(bool aChecked)
        {
            if (Dgv.RowCount == 0)
                return;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                int aId = Convert.ToInt32(row.Cells[DgvColTxtid.Name].Value);
                int n;
                int aYdcount = 0;
                if (Int32.TryParse(row.Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                    aYdcount = Convert.ToInt32(row.Cells[DgvColTxtYdcounts.Name].Value);
                double m;
                double adsk = 0;
                if (double.TryParse(row.Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                    adsk = Convert.ToDouble(row.Cells[DgvColTxtdsk.Name].Value);
                if (!aChecked)//ȡ��ȫѡ
                {
                    if (PriRowsCunt == 0)
                        break;
                    if (Convert.ToBoolean(row.Cells[DgvColChkXz.Name].Value))//ȡ��
                    {
                        row.Cells[DgvColChkXz.Name].Value = false;
                        //PriListId.Remove(aId);
                        //PriYdCounts = PriYdCounts - aYdcount;
                        PriSumDsk = PriSumDsk - adsk;
                        if (Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("�ֽ�"))
                            PriXjje = PriXjje - adsk;
                        if (Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).ToUpper().Contains("POS"))
                            PriPosje = PriPosje - adsk;
                        if (Convert.ToString(row.Cells[DgvColTxtyhlx.Name].Value).Contains("ũ") && Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                            PriNhje = PriNhje - adsk;
                        if (Convert.ToString(row.Cells[DgvColTxtyhlx.Name].Value).ToUpper().Contains("��") && Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                            PriJhje = PriJhje - adsk;
                        if (Convert.ToString(row.Cells[DgvColTxtyhlx.Name].Value).Contains("����") && Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                            PriZSje = PriZSje - adsk;
                        PriRowsCunt--;
                        //string aaa = ClsRWMSSQLDb.GetStr(" select dkje as jec from Vfmsqrycdskmx where id=" + row.Cells["DgvColTxtid"].Value, ClsGlobals.CntStrTMS);
                        //jezh = jezh - Convert.ToDouble(aaa);
                        //if (row.Cells["DgvColTxtDkje"].Style.ForeColor == Color.Red)
                        //{
                        //    chashu--;

                        //}
                        jezh = 0;
                        chashu = 0;
                    }
                }
                else
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColChkXz.Name].Value))//ѡ��
                    {
                        if (row.Cells[DgvColTxtdskbz.Name].Value.ToString() != "���ͨ��")
                        {
                            row.Cells[DgvColChkXz.Name].Value = true;
                            //PriListId.Add(aId);
                            //PriYdCounts = PriYdCounts + aYdcount;
                            PriSumDsk = PriSumDsk + adsk;
                            if (Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("�ֽ�"))
                                PriXjje = PriXjje + adsk;
                            if (Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).ToUpper().Contains("POS"))
                                PriPosje = PriPosje + adsk;
                            if (Convert.ToString(row.Cells[DgvColTxtyhlx.Name].Value).Contains("ũ") && Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                                PriNhje = PriNhje + adsk;
                            if (Convert.ToString(row.Cells[DgvColTxtyhlx.Name].Value).ToUpper().Contains("��") && Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                                PriJhje = PriJhje + adsk;
                            if (Convert.ToString(row.Cells[DgvColTxtyhlx.Name].Value).Contains("����") && Convert.ToString(row.Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                                PriZSje = PriZSje + adsk;
                            PriRowsCunt++;
                        }
                        string aaa = ClsRWMSSQLDb.GetStr(" select dkje as jec from Vfmsqrycdskmx where id=" + row.Cells["DgvColTxtid"].Value, ClsGlobals.CntStrTMS);
                        jezh = jezh + Convert.ToDouble(aaa);
                        if (row.Cells["DgvColTxtDkje"].Style.ForeColor == Color.Red)
                        {
                            chashu++;

                        }
                    }
                }
            }
        }
        #endregion

        private void BtnJd_Click(object sender, EventArgs e)
        {
            GetDj(0);
        }

        private void BtnDj_Click(object sender, EventArgs e)
        {
            GetDj(1);
        }
        private void GetDj(byte aZt)
        {
            if (PriRowsCunt == 0)
                return;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (!Convert.ToBoolean(row.Cells[DgvColChkXz.Name].Value))
                    continue;
                Bds.Position = row.Index;
                DSQRYCDSK.VfmsqrycdskmxRow Rows = ((DataRowView)Bds.Current).Row as DSQRYCDSK.VfmsqrycdskmxRow;
                if (Rows.jdzt1 == aZt)
                    continue;
                Rows.jdzt1 = aZt;
                PriListId.Add(Rows);
            }
            if (PriListId.Count == 0)
                ClsMsgBox.Ts("û��Ҫ��������Ϣ!", ObjG.CustomMsgBox, this);
            try
            {
                Bds.EndEdit();
                this.vfmsqrycdskmx1TableAdapter1.Update(PriListId.ToArray());
                foreach (DSQRYCDSK.VfmsqrycdskmxRow row in PriListId)
                {
                    Bds.RemoveAt(Bds.Find("id", row.id));
                }
                Clear();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #region ��굥ѡ
        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex <= -1)
                return;
            if (e.ColumnIndex == 0)//��˶���
            {
                int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtid.Name].Value);
                int n;
                int aYdcount = 0;
                if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                    aYdcount = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value);
                double m;
                double adsk = 0;
                if (double.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                    adsk = Convert.ToDouble(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvColChkXz.Name].Value))//ȡ��
                {
                    Dgv.Rows[e.RowIndex].Cells[DgvColChkXz.Name].Value = false;
                    //PriYdCounts = PriYdCounts - aYdcount;
                    PriSumDsk = PriSumDsk - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("�ֽ�"))
                        PriXjje = PriXjje - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).ToUpper().Contains("POS"))
                        PriPosje = PriPosje - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).Contains("ũ") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                        PriNhje = PriNhje - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).ToUpper().Contains("��") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                        PriJhje = PriJhje - adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).Contains("����") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                        PriZSje = PriZSje - adsk;
                    PriRowsCunt--;
                    if (Dgv.CurrentRow.Cells["DgvColTxtDkje"].Style.ForeColor == Color.Red)
                    {
                        chashu--;
                        string aaa = ClsRWMSSQLDb.GetStr(" select (dkje-dsk) as jec from Vfmsqrycdskmx where id=" + Dgv.CurrentRow.Cells["DgvColTxtid"].Value, ClsGlobals.CntStrTMS);
                        jezh = jezh - Convert.ToDouble(aaa);
                    }
                }
                else
                {
                    if (Dgv.Rows[e.RowIndex].Cells[DgvColTxtdskbz.Name].Value.ToString() == "���ͨ��")
                    {
                        ClsMsgBox.Ts("�ô��տ��ձ��Ѿ����ͨ���������ظ���ˣ�", ObjG.CustomMsgBox, this);
                        return;
                    }
                    Dgv.Rows[e.RowIndex].Cells[DgvColChkXz.Name].Value = true;
                    //PriYdCounts = PriYdCounts + aYdcount;
                    PriSumDsk = PriSumDsk + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("�ֽ�"))
                        PriXjje = PriXjje + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).ToUpper().Contains("POS"))
                        PriPosje = PriPosje + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).Contains("ũ") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                        PriNhje = PriNhje + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).ToUpper().Contains("��") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                        PriJhje = PriJhje + adsk;
                    if (Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtyhlx.Name].Value).Contains("����") && Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value).Contains("��"))
                        PriZSje = PriZSje + adsk;
                    PriRowsCunt++;
                    string aaa = ClsRWMSSQLDb.GetStr(" select dkje as jec from Vfmsqrycdskmx where id=" + Dgv.CurrentRow.Cells["DgvColTxtid"].Value, ClsGlobals.CntStrTMS);
                    jezh = jezh + Convert.ToDouble(aaa);
                    if (Dgv.CurrentRow.Cells["DgvColTxtDkje"].Style.ForeColor == Color.Red)
                    {
                        chashu++;

                    }
                }
                GetXx();
            }
            if (Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("��ϸ��Ϣ"))//��ϸ
            {
                string aRbdh = Dgv.Rows[e.RowIndex].Cells[DgvColTxtrbdh.Name].Value.ToString();
                string aCkjg = Dgv.Rows[e.RowIndex].Cells[DgvColTxtckjg.Name].Value.ToString();
                string aCksj = string.IsNullOrEmpty(Dgv.Rows[e.RowIndex].Cells[DgvColTxtcksq.Name].Value.ToString()) ? "" : Convert.ToDateTime(Dgv.Rows[e.RowIndex].Cells[DgvColTxtcksq.Name].Value).ToString("yyyy-MM-dd");//��ʽ
                string aDsk = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString();
                string aDKje = Dgv.Rows[e.RowIndex].Cells[DgvColTxtDkje.Name].Value.ToString();
                string aYdcounts = "0";
                int n;
                if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value.ToString(), out n))
                    aYdcounts = Dgv.Rows[e.RowIndex].Cells[DgvColTxtYdcounts.Name].Value.ToString();
                string aDskbz = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdskbz.Name].Value.ToString();
                int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtid.Name].Value);
                FrmQRYCDSKMXLL f = new FrmQRYCDSKMXLL();
                f.ShowDialog();
                f.Prepare(aRbdh, aCkjg, aCksj, aDsk, aYdcounts, aDskbz, aId, aDKje);
            }
        #endregion
        }
    }
}
