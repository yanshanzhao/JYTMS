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
using System.Data.SqlClient;
using FMS.SeleFrm;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Configuration;
#endregion
namespace FMS.DSKGL.DSKYKGL
{
    public partial class FrmDSKYKGL : UserControl
    {
        List<ClsBhMcStr> PriYkyy=new List<ClsBhMcStr>();
        public class ClsBhMcStr 
        {
            public ClsBhMcStr(string aBh, string aMc) 
            {
                Bh = aBh;
                Mc = aMc;
            }
            public string Bh { set; get; }
            public string Mc { set; get; }
            public string Bh_Mc 
            {
                get 
                {
                    return Bh+":"+Mc;
                }
            }
        }
        #region ��Ա����
        private ClsG ObjG;
        private string PriConStr;
        private List<int> PriListDskid = new List<int>();
        private List<int> PriListJYYdid = new List<int>();
        private List<int> PriListYKYdid = new List<int>();
        private List<string> PriLstYkyy = new List<string>();
        private int PriId = 0;
        private int PriJgid = 0;
        private string PriZh = "";
        private string PriXm = "";
        private string Where = "";
        private double PriSum = 0;
        private bool PriQx = true;
        private bool PriFlag;
        #endregion
        #region ��ʼ��
        public FrmDSKYKGL()
        {
            InitializeComponent();
            PriYkyy.Add(new ClsBhMcStr("B", "���ﲻ��"));
            PriYkyy.Add(new ClsBhMcStr("Y", "�����˻��쳣�ͻ�Ҫ��ѹ��"));
            PriYkyy.Add(new ClsBhMcStr("F", "���ӷǷ�"));
            PriYkyy.Add(new ClsBhMcStr("C", "��������"));
            PriYkyy.Add(new ClsBhMcStr("H", "��δ�ᣬ�����Ѵ�"));
            PriYkyy.Add(new ClsBhMcStr("K", "���񿨺�¼��")); 
            PriYkyy.Add(new ClsBhMcStr("Q", "����"));  
            DgvCmb.DataSource = PriYkyy;
            DgvCmb.DisplayMember = "mc";
            DgvCmb.ValueMember = "bh";
        }
        public void Prepare()
        {
            CmbYkzt.SelectedIndex = 0;
            PriConStr = ClsGlobals.CntStrTMS;
            this.VfmsdskykTableAdapter1.Connection.ConnectionString = PriConStr;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            //ClsPopulateCmbDsS.PopuDsk_ykyy(CmbYkyy);
            PriId = ObjG.Renyuan.id;
            PriZh = ObjG.Renyuan.loginName;
            PriXm = ObjG.Renyuan.xm;
            PriJgid = ObjG.Jigou.id;
            this.ActiveControl = BtnJg;
            //CmbYkyy.SelectedIndex = 0;
            GetYkyy();
        }

        private void GetYkyy()
        {
            DataTable DtYkyy = new DataTable();
            DtYkyy.Columns.Add("mc", typeof(string));
            DtYkyy.Columns.Add("bh", typeof(string));
            DataRow dr0 = DtYkyy.NewRow();
            dr0["mc"] = "W";
            dr0["bh"] = "--��ѡ��--";
            DtYkyy.Rows.Add(dr0);

            DataRow dr1 = DtYkyy.NewRow();
            dr1["mc"] = "B";
            dr1["bh"] = "���ﲻ��";
            DtYkyy.Rows.Add(dr1);

            DataRow dr2 = DtYkyy.NewRow();
            dr2["mc"] = "Y";
            dr2["bh"] = "�����˻��쳣�ͻ�Ҫ��ѹ��";
            DtYkyy.Rows.Add(dr2);
           
            DataRow dr3 = DtYkyy.NewRow();
            dr3["mc"] = "F";
            dr3["bh"] = "���ӷǷ�";
            DtYkyy.Rows.Add(dr3);

            DataRow dr4 = DtYkyy.NewRow();
            dr4["mc"] = "C";
            dr4["bh"] = "��������";
            DtYkyy.Rows.Add(dr4);

            DataRow dr5 = DtYkyy.NewRow();
            dr5["mc"] = "H";
            dr5["bh"] = "��δ�ᣬ�����Ѵ�";
            DtYkyy.Rows.Add(dr5);

            DataRow dr6 = DtYkyy.NewRow();
            dr6["mc"] = "K";
            dr6["bh"] = "���񿨺�¼��";
            DtYkyy.Rows.Add(dr6);

            DataRow dr7 = DtYkyy.NewRow();
            dr7["mc"] = "Q";
            dr7["bh"] = "����";
            DtYkyy.Rows.Add(dr7);
            ClsPopulateCmbDsS.PopuByTb(this.CmbYkyy, DtYkyy, "mc", "bh");
        }

        #endregion
        #region ��ѯ
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.PriListYKYdid.Clear();
                this.PriListJYYdid.Clear();
                this.PriListDskid.Clear();
                this.ChkB.Checked = false;
                PriQx = true;
                PriSum = 0;
                Where = " where 1=1";
                if (DtpStart.Checked && DtpStop.Checked)
                {
                    Where = Where + "  and shsj between'" + DtpStart.Value + "'and DateAdd(dd,+1, '" + DtpStop.Value + "')";
                }
                else if (DtpStart.Checked && !DtpStop.Checked)
                {
                    Where = Where + "  and shsj between'" + DtpStart.Value + "'and DateAdd(dd,+1, '" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                }
                else if (!DtpStart.Checked && DtpStop.Checked)
                {
                    Where = Where + "   and shsj <='" + DtpStop.Value + "')";
                }
                Where += string.IsNullOrEmpty(TxtSljg.Text.Trim()) ? "  " : " and sljgmc like '%" + TxtSljg.Text.Trim() + "%'";
                Where += string.IsNullOrEmpty(TxtBh.Text.Trim()) ? "  " : " and bh like '%" + TxtBh.Text.Trim() + "%'";
                Where += string.IsNullOrEmpty(TxtFwkh.Text.Trim()) ? "  " : " and fwkh like '%" + TxtFwkh.Text.Trim() + "%'";
                if (CmbYkzt.SelectedIndex > 0)
                    Where += " and dskykzt='" + CmbYkzt.Text + "' ";
                else
                    PriQx = false;



                this.VfmsdskykTableAdapter1.FillByWhere(DSDSKYK1.Vfmsdskyk, Where);
                GetXx();
                if (Bds.Count == 0)
                    ClsMsgBox.Ts("�޲�ѯ��Ϣ����˶Բ�ѯ������", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ�쳣��", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion
        #region ѹ��
        private void BtnYk_Click(object sender, EventArgs e)
        {
            //�޸�ѹ��״̬��ѹ��ʱ�䣨��tyd���У�
            if (PriListYKYdid.Count == 0)
            {
                if (PriListJYYdid.Count > 0)
                    ClsMsgBox.Ts("�����ť����������ѹ��ť��", ObjG.CustomMsgBox, this);
                else
                    ClsMsgBox.Ts("û��Ҫѹ�����Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            List<string> ListStr = GetDskyhLog();
            if (ListStr.Count != PriListYKYdid.Count)
            {
                ClsMsgBox.Ts("��ѡ��Ѻ��ԭ��", ObjG.CustomMsgBox, this);
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
                    cmdText = " update tfmsdsk set dskyk='1' where  dskyk='0' and  id in(" + string.Join(",", PriListDskid) + ");";
                    comm.CommandText = cmdText;
                    int influenceSum = comm.ExecuteNonQuery();
                    cmdText = " insert into Tfmsdskyk(dskid,ydid,jgid, insczyid,insczyzh,insczyxm,ykyy,zt) values" + string.Join(",", ListStr);
                    comm.CommandText = cmdText;
                    int influenseSumLog = comm.ExecuteNonQuery();
                    if (influenceSum == influenseSumLog && influenceSum > 0)
                    {
                        //�ύ����
                        ClsMsgBox.Ts("ѹ��ɹ�����ѹ��" + PriListDskid.Count + "Ʊ", ObjG.CustomMsgBox, this);
                        trans.Commit();
                        PriListDskid.Clear();
                        PriListJYYdid.Clear();
                        PriListYKYdid.Clear();
                        PriLstYkyy.Clear();
                        PriSum = 0;
                        this.VfmsdskykTableAdapter1.FillByWhere(DSDSKYK1.Vfmsdskyk, Where);
                        GetXx();
                    }
                    else
                    {
                        //�ع�����
                        ClsMsgBox.Ts("ѹ��ʧ�ܣ�", ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    //�ع�����
                    try
                    {
                        ClsMsgBox.Cw("ѹ���쳣��", ex, ObjG.CustomMsgBox, this);
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
        #endregion
        #region ��ѹ
        private void BtnJy_Click(object sender, EventArgs e)
        {
            //�޸�ѹ��״̬����tyd���У�
            if (PriListJYYdid.Count == 0)
            {
                if (PriListJYYdid.Count > 0)
                    ClsMsgBox.Ts("�����ť��������ѹ�ť��", ObjG.CustomMsgBox, this);
                else
                    ClsMsgBox.Ts("û��Ҫ��ѹ����Ϣ��", ObjG.CustomMsgBox, this);
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
                    cmdText = " update tfmsdsk set dskyk='0' where dskyk='1' and id in(" + string.Join(",", PriListDskid) + ");";
                    comm.CommandText = cmdText;
                    int influenceSum = comm.ExecuteNonQuery();
                    cmdText = " update tfmsdskyk set zt=0,jyczyid='" + ObjG.Renyuan.id + "',jyczyxm='" + ObjG.Renyuan.xm + "',jyczyzh='" + ObjG.Renyuan.xm + "',jysj=getdate()  where id in(" + string.Join(",", PriListJYYdid) + ")";
                    comm.CommandText = cmdText;
                    int influenseSumLog = comm.ExecuteNonQuery();
                    if (influenceSum == influenseSumLog && influenceSum > 0)
                    {
                        //�ύ����
                        ClsMsgBox.Ts("��ѹ�ɹ�������ѹ" + PriListDskid.Count + "Ʊ", ObjG.CustomMsgBox, this);
                        trans.Commit();
                        PriListDskid.Clear();
                        PriListJYYdid.Clear();
                        PriListYKYdid.Clear();
                        PriLstYkyy.Clear();
                        PriSum = 0;
                        this.VfmsdskykTableAdapter1.FillByWhere(DSDSKYK1.Vfmsdskyk, Where);
                        GetXx();
                    }
                    else
                    {
                        //�ع�����
                        ClsMsgBox.Ts("��ѹʧ�ܣ�", ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    //�ع�����
                    try
                    {
                        ClsMsgBox.Cw("��ѹ�쳣��", ex, ObjG.CustomMsgBox, this);
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
        #endregion
        #region ���ɼ�¼
        private List<string> GetDskyhLog()
        {
            PriLstYkyy.Clear();
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                {
                    if (row.Cells[DgvCmb.Name].Value.ToString().Length > 0)
                        PriLstYkyy.Add("(" + row.Cells[DgvColTxtDskid.Name].Value + "," + row.Cells[DgvColTxtid.Name].Value + "," + PriJgid + "," + PriId + ",'" + PriZh + "','" + PriXm + "','" + row.Cells[DgvCmb.Name].Value + "',1)");
                }
            }
            return PriLstYkyy;
        }
        #endregion
        #region ��굥��
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1)
                return;
            if (e.ColumnIndex == 0)
            {
                string aykzt = Dgv.Rows[e.RowIndex].Cells[DgvColTxtykzt.Name].Value.ToString();


                if (PriListJYYdid.Count > 0 && aykzt == "δѹ��" || PriListYKYdid.Count > 0 && aykzt == "��ѹ��")
                {
                    ClsMsgBox.Jg("��ѹ��ѹ���ͬʱ���У�", ObjG.CustomMsgBox, this);
                    return;
                }
                int aid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtid.Name].Value.ToString());
                int ykid = string.IsNullOrEmpty(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYkid.Name].Value.ToString()) ? 0 : Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtYkid.Name].Value);
                int adskid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtDskid.Name].Value.ToString());
                double n;
                double RowDsk = 0;
                if (double.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString(), out n))
                    RowDsk = Convert.ToDouble(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvColCbm.Name].Value))//ȡ��ѡ��
                {
                    Dgv.Rows[e.RowIndex].Cells[DgvColCbm.Name].Value = false;
                    if (aykzt == "��ѹ��")
                        PriListJYYdid.Remove(ykid);
                    else
                        PriListYKYdid.Remove(aid);
                    PriListDskid.Remove(adskid);
                    PriSum = PriSum - RowDsk;
                }
                else
                {
                    //if (aykzt == "δѹ��")
                    //{
                    //    if (string.IsNullOrEmpty(Dgv.Rows[e.RowIndex].Cells[DgvCmb.Name].Value.ToString()))
                    //    {
                    //        ClsMsgBox.Ts("��ѡ��Ѻ��ԭ��", ObjG.CustomMsgBox, this);
                    //        return;
                    //    }
                    //}
                    Dgv.Rows[e.RowIndex].Cells[DgvColCbm.Name].Value = true;
                    if (aykzt == "δѹ��")
                    {
                        PriListYKYdid.Add(aid);
                        if (CmbYkyy.SelectedIndex > 0)
                            Dgv.Rows[e.RowIndex].Cells[DgvCmb.Name].Value = CmbYkyy.SelectedValue;
                    }
                    else
                        PriListJYYdid.Add(ykid);
                    PriListDskid.Add(adskid);
                    PriSum = PriSum + RowDsk;
                }
                GetXx();
            }
        }
        #endregion
        #region ����
        private void BtnJg_Click(object sender, EventArgs e)
        {
            FrmSelectJg f = new FrmSelectJg();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
                this.TxtSljg.Text = f.PubDictAttrs["mc"];
            else if (f.DialogResult == DialogResult.No)
                this.TxtSljg.Text = "";
        }
        #endregion
        #region ����Textbook�ؼ�������
        private void TxtSljg_KeyDown(object objSender, KeyEventArgs objArgs)
        {
            if (objArgs.KeyCode == Keys.Back)
                this.TxtSljg.Text = "";
        }
        #endregion
        #region ��ҳȫѡ
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
                return;
            if (!PriQx)
            {
                ClsMsgBox.Ts("��ѯ�����ȫ��,�޷����б�ҳȫѡ���ܣ�",ObjG.CustomMsgBox,this);
                return;
            }
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
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value))
                        {
                            int aid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value.ToString());
                            int ykid = string.IsNullOrEmpty(Dgv.Rows[i].Cells[DgvColTxtYkid.Name].Value.ToString()) ? 0 : Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYkid.Name].Value);
                            int adskid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value.ToString());
                            string aykzt = Dgv.Rows[i].Cells[DgvColTxtykzt.Name].Value.ToString();
                            double n;
                            //if (aykzt == "δѹ��")
                            //{
                            //    if (string.IsNullOrEmpty(Dgv.Rows[i].Cells[DgvCmb.Name].Value.ToString()))
                            //    {
                            //        //ClsMsgBox.Ts("��ѡ��Ѻ��ԭ��", ObjG.CustomMsgBox, this);
                            //        continue;
                            //    }
                            //}
                            double RowDsk = 0;
                            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out n))
                                RowDsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);

                            Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;

                            if (aykzt == "δѹ��")
                            {
                                PriListYKYdid.Add(aid);
                                if (CmbYkyy.SelectedIndex > 0)
                                    Dgv.Rows[i].Cells[DgvCmb.Name].Value = CmbYkyy.SelectedValue;
                            }
                            else
                                PriListJYYdid.Add(ykid);
                            PriListDskid.Add(adskid);
                            PriSum = PriSum + RowDsk;
                        }
                    }
                }
                //�������һҳ��ֵ
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value))
                        {
                            int aid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value.ToString());
                            int ykid = string.IsNullOrEmpty(Dgv.Rows[i].Cells[DgvColTxtYkid.Name].Value.ToString()) ? 0 : Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYkid.Name].Value);
                            int adskid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value.ToString());
                            string aykzt = Dgv.Rows[i].Cells[DgvColTxtykzt.Name].Value.ToString();
                            double n;
                            //if (aykzt == "δѹ��")
                            //{
                            //    if (string.IsNullOrEmpty(Dgv.Rows[i].Cells[DgvCmb.Name].Value.ToString()))
                            //    {
                            //        //ClsMsgBox.Ts("��ѡ��Ѻ��ԭ��", ObjG.CustomMsgBox, this);
                            //        continue;
                            //    }
                            //}
                            double RowDsk = 0;
                            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out n))
                                RowDsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                            Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;

                            if (aykzt == "δѹ��")
                            {
                                PriListYKYdid.Add(aid);
                                if (CmbYkyy.SelectedIndex > 0)
                                    Dgv.Rows[i].Cells[DgvCmb.Name].Value = CmbYkyy.SelectedValue;
                            }
                            else
                                PriListJYYdid.Add(ykid);
                            PriListDskid.Add(adskid);
                            PriSum = PriSum + RowDsk;
                        }
                    }
                }
            }
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCbm.Name].Value))
                    {
                        int aid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtid.Name].Value.ToString());
                        int ykid = string.IsNullOrEmpty(Dgv.Rows[i].Cells[DgvColTxtYkid.Name].Value.ToString()) ? 0 : Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYkid.Name].Value);
                        int adskid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value.ToString());
                        string aykzt = Dgv.Rows[i].Cells[DgvColTxtykzt.Name].Value.ToString();
                        double n;
                        //if (aykzt == "δѹ��")
                        //{
                        //    if (string.IsNullOrEmpty(Dgv.Rows[i].Cells[DgvCmb.Name].Value.ToString()))
                        //    {
                        //        //ClsMsgBox.Ts("��ѡ��Ѻ��ԭ��", ObjG.CustomMsgBox, this);
                        //        continue;
                        //    }
                        //}
                        double RowDsk = 0;
                        if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out n))
                            RowDsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                        Dgv.Rows[i].Cells[DgvColCbm.Name].Value = true;
                        //if (aykzt == "δѹ��")
                        //{
                        //    if (string.IsNullOrEmpty(Dgv.Rows[i].Cells[DgvCmb.Name].Value.ToString()))
                        //    {
                        //        //ClsMsgBox.Ts("��ѡ��Ѻ��ԭ��", ObjG.CustomMsgBox, this);
                        //        continue;
                        //    }
                        //}
                        if (aykzt == "δѹ��")
                        {
                            PriListYKYdid.Add(aid);
                            if (CmbYkyy.SelectedIndex > 0)
                                Dgv.Rows[i].Cells[DgvCmb.Name].Value = CmbYkyy.SelectedValue;
                        }
                        else
                            PriListJYYdid.Add(ykid);
                        PriListDskid.Add(adskid);
                        PriSum = PriSum + RowDsk;
                    }
                }
            }
        }
        #endregion
        #region ��Ϣ��ʾ
        private void GetXx()
        {
            LblCheckCount.Text = "��ѡ��" + PriListDskid.Count + "��";
            if (PriSum == 0)
                LblCheckSumJe.Text = "��ѡ��0.00Ԫ";
            else
                LblCheckSumJe.Text = "��ѡ��" + PriSum.ToString() + "Ԫ";
        }
        #endregion
        #region ȫѡ
        private void ChkB_CheckedChanged(object sender, EventArgs e)
        {
            if (!PriQx)
            {
                ClsMsgBox.Ts("��ѯ�����ȫ��,�޷�����ȫѡ���ܣ�", ObjG.CustomMsgBox, this);
                return;
            }
            CheckAll(ChkB.Checked);
            GetXx();
        }
        public void CheckAll(bool aChecked)
        {
            PriFlag = false;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                string aykzt = row.Cells[DgvColTxtykzt.Name].Value.ToString();
                int aid = Convert.ToInt32(row.Cells[DgvColTxtid.Name].Value.ToString());
                int ykid = string.IsNullOrEmpty(row.Cells[DgvColTxtYkid.Name].Value.ToString()) ? 0 : Convert.ToInt32(row.Cells[DgvColTxtYkid.Name].Value);
                int adskid = Convert.ToInt32(row.Cells[DgvColTxtDskid.Name].Value.ToString());
                double n;
                double RowDsk = 0;
                if (double.TryParse(row.Cells[DgvColTxtdsk.Name].Value.ToString(), out n))
                    RowDsk = Convert.ToDouble(row.Cells[DgvColTxtdsk.Name].Value);
                if (!aChecked)//ȡ��ȫѡ
                {
                    if (Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))//ȡ��ѡ��
                    {
                        row.Cells[DgvColCbm.Name].Value = false;
                        if (aykzt == "��ѹ��")
                            PriListJYYdid.Remove(ykid);
                        else
                        {
                            PriListYKYdid.Remove(aid);
                        }
                        PriListDskid.Remove(adskid);
                        PriSum = PriSum - RowDsk;
                    }
                }
                else
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                    {
                        //if (aykzt == "δѹ��")
                        //{
                        //    if (string.IsNullOrEmpty(row.Cells[DgvCmb.Name].Value.ToString()))
                        //    {
                        //        PriFlag = true;
                        //        //ClsMsgBox.Ts("��ѡ��Ѻ��ԭ��", ObjG.CustomMsgBox, this);
                        //        continue;
                        //    }
                        //}
                        row.Cells[DgvColCbm.Name].Value = true;
                        if (aykzt == "δѹ��")
                        {
                            PriListYKYdid.Add(aid);
                            if (CmbYkyy.SelectedIndex > 0)
                                row.Cells[DgvCmb.Name].Value = CmbYkyy.SelectedValue;
                        }
                        else
                            PriListJYYdid.Add(ykid);
                        PriListDskid.Add(adskid);
                        PriSum = PriSum + RowDsk;
                    }
                }
            }
            if (PriFlag)
                ClsMsgBox.Ts("�����Ƿ���δѡ��Ѻ��ԭ����˵���", ObjG.CustomMsgBox, this);
        }
        #endregion
        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            int[] ShuZhi = {3};
            GetExl(ShuZhi);
        }
        private void GetExl(int[] aCellIndex)
        {
            List<int> LstCellIndex = new List<int>();
            if (aCellIndex != null)
            {
                if (aCellIndex.Length != 0)
                    LstCellIndex.AddRange(aCellIndex);
            }
            //int[] LstCellIndex = new int[] { 8 };
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("��ѡ��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            string PriFln = "���տ�Ѻ��" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
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
                    //if (Convert.ToBoolean(Row.Cells[DgvColTxtChk.Name].Value))
                    //{
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
                               
                                if (Dgv[i, 0].GetType().Name == "DataGridViewComboBoxCell")
                                {
                                    string ycxx = Row.Cells[i].EditedFormattedValue.ToString();
                                    //string yxxx = Row.Cells[i].Value.ToString();
                                    //string ycxx = Row.Cells[i].FormattedValue.ToString(); 
                                    hssfrow.CreateCell(i - m).SetCellValue(ycxx);
                                }
                                else
                                    hssfrow.CreateCell(i - m).SetCellValue(Convert.ToString(Row.Cells[i].Value));
                             //�ж��Ƿ������ָ�ʽ����
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
                                    hssfrow.CreateCell(i - m).SetCellValue(Convert.ToString(Row.Cells[i].EditedFormattedValue.ToString()));
                            }
                            else
                                m = m + 1;
                        }
                        roowIndex++;
                    //}

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

        private void TxtFwkh_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            BtnSearch.PerformClick();
            TxtFwkh.SelectAll();
        }

        private void TxtBh_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            BtnSearch.PerformClick();
            TxtBh.SelectAll();
        }

        private void CmbYkyy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            if (PriYkyy.Count == 0)
                return;
            if (CmbYkyy.SelectedIndex <= 0)
                return;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvColCbm.Name].Value))
                {
                    string aykzt = row.Cells[DgvColTxtykzt.Name].Value.ToString();
                    if (aykzt == "δѹ��")
                        row.Cells[DgvCmb.Name].Value = this.CmbYkyy.SelectedValue;
                }
            }
        }
    }
}