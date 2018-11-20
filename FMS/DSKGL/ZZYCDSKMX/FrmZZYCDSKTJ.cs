#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pri;
using JY.Pub;
using System.Data.SqlClient;
using JYPubFiles.Classes;
#endregion

namespace FMS.DSKGL.ZZYCDSKMX
{
    public partial class FrmZZYCDSKTJ : Form
    {
        #region ��Ա����
        private ClsG ObjG;
        private int PriId;
        private string PriLogNama;
        private string PriXm;
        private int PriZhid;
        private string PriConStr;
        private List<int> PriListid = new List<int>();
        private int PriYdCounts = 0;
        private double PriSumJe = 0;
        private int PriRowIndexId = 0;
        private int PriRowIndexCount = 0;
        private FrmMsgBox frm;
        #endregion
        public FrmZZYCDSKTJ()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriId = ObjG.Jigou.id;
            PriLogNama = ObjG.Renyuan.loginName;
            PriXm = ObjG.Renyuan.xm;
            PriZhid = ObjG.Renyuan.id;
            PriConStr = ClsGlobals.CntStrTMS;
            this.Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select id,jgmc,dsk,sxf,zh,zffsmc,cnt,'��ϸ��Ϣ' as Xq,'ɾ��'as Del,rbdh,zt,zflxmc from Vfmszzycdsk where jgid=" + PriId, PriConStr);
        }
        #region ��굥ѡ
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1)
                return;
            int ColumnIndex = e.ColumnIndex;
            if (ColumnIndex == 0 || ColumnIndex == 8 || ColumnIndex == 9)//��ϸ
            {
                int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtid"].Value);
                int n;
                int aYdCounts = 0;

                if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells["DgvColTxtcounts"].Value.ToString(), out n))
                {
                    aYdCounts = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells["DgvColTxtcounts"].Value);//������
                }
                double m;
                double aRowDsk = 0;
                if (double.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                    aRowDsk = Convert.ToDouble(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                if (ColumnIndex == 0)
                {
                    if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvColTxtxz.Name].Value))//ȡ��ѡ��
                    {
                        Dgv.Rows[e.RowIndex].Cells[DgvColTxtxz.Name].Value = false;
                        PriListid.Remove(aId);
                        PriYdCounts = PriYdCounts - aYdCounts;
                        PriSumJe = PriSumJe - aRowDsk;
                    }
                    else
                    {
                        Dgv.Rows[e.RowIndex].Cells[DgvColTxtxz.Name].Value = true;
                        PriListid.Add(aId);
                        PriYdCounts = PriYdCounts + aYdCounts;
                        PriSumJe = PriSumJe + aRowDsk;
                    }
                    GetXx();
                }
                else if (ColumnIndex == 8)
                {
                    string aRhdh = Dgv.Rows[e.RowIndex].Cells[DgvColTxtrbdh.Name].Value.ToString();
                    string aSkjg = Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgmc.Name].Value.ToString();
                    string aDsk = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value.ToString();
                    string aSxf = Dgv.Rows[e.RowIndex].Cells[DgvColTxtsxf.Name].Value.ToString();
                    FrmDSKRBLL f = new FrmDSKRBLL();
                    f.ShowDialog();
                    f.Prepare(aRhdh, aSkjg, aDsk, aSxf, aYdCounts.ToString(), aId);
                }
                else
                {
                    GetRowLing(aId, aYdCounts);
                }

            }
        }
        #endregion
        #region ����
        private void BtnQery_Click(object sender, EventArgs e)
        {
            //sjdskzt(�Ͻɴ��տ�״̬)��Ĭ��ֵΪ0-δ�ɿ10-�ѱ��棻20-���ύ��30-�ѽɿ�

            if (PriListid.Count == 0)
            {
                ClsMsgBox.Ts("��ѡ��Ҫ�����Ĵ��տ��ձ���", ObjG.CustomMsgBox, this);
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
                    cmdText = " update tfmsdsk set sjdskzt='20' where id in(select dskid from Tfmsdskjkmx where pcid  in (" + string.Join(",", PriListid) + "))";
                    comm.CommandText = cmdText;
                    int influenceSum = comm.ExecuteNonQuery();
                    cmdText = " update Tfmsdskjkpc set dkje=dsk,zt='10', zdczyid=" + PriZhid + ",zdczyxm='" + PriXm + "',zdczyzh='" + PriLogNama + "',zdsj='" + DateTime.Now.ToString() + "' where id  in (" + string.Join(",", PriListid) + ")";
                    comm.CommandText = cmdText;
                    influenceSum = influenceSum + comm.ExecuteNonQuery();
                    if (influenceSum == PriYdCounts + PriListid.Count)
                    {
                        //�ύ����
                        ClsMsgBox.Ts("����ɹ�!���������տ�" + PriSumJe.ToString() + "Ԫ", ObjG.CustomMsgBox, this);
                        trans.Commit();
                        this.Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select id,jgmc,dsk,sxf,zh,zffsmc,cnt,'��ϸ' as Xq,'ɾ��'as Del,rbdh,zt from Vfmszzycdsk where jgid=" + PriId, PriConStr);
                        PriListid.Clear();
                        PriYdCounts = 0;
                        PriSumJe = 0;
                        GetXx();
                    }
                    else
                    {
                        //�ع�����
                        ClsMsgBox.Ts("����ʧ�ܣ�", ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    //�ع�����
                    try
                    {
                        ClsMsgBox.Cw("�����쳣��", ex, ObjG.CustomMsgBox, this);
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
        private void GetRowLing(int aId, int aCounts)
        {
            PriRowIndexId = aId;
            PriRowIndexCount = aCounts;
            ClsMsgBox.YesNo("�Ƿ�ɾ��ת�Ĵ��տ��ձ���", new EventHandler(DelYh), ObjG.CustomMsgBox, this);
        }
        private void DelYh(object sender, EventArgs e)
        {
            frm = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {
                //sjdskzt(�Ͻɴ��տ�״̬)��Ĭ��ֵΪ0-δ�ɿ10-�ѱ��棻20-���ύ��30-�ѽɿ� 
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
                        cmdText = " update Tfmsdskjkpc   set zt='5' where  id=" + PriRowIndexId;
                        comm.CommandText = cmdText;
                        influenceSum = influenceSum + comm.ExecuteNonQuery();
                        if (influenceSum == PriRowIndexCount + 1)
                        {
                            //�ύ����
                            ClsMsgBox.Ts("ɾ���ɹ���",frm,this);
                            trans.Commit();
                            //this.Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" select id,jgmc,dsk,sxf,zh,zffsmc,cnt,'��ϸ��Ϣ' as Xq,'ɾ��'as Del,rbdh,zt from Vfmszzycdsk where jgid=" + PriId, PriConStr);

                        }
                        else
                        {
                            //�ع�����
                            ClsMsgBox.Ts("ɾ��ʧ�ܣ�",frm,this);
                            trans.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        //�ع�����
                        try
                        {
                            ClsMsgBox.Cw("ɾ���쳣��", ex, frm, this);
                            trans.Rollback();
                        }
                        catch (SqlException ex1)
                        {
                            if (trans.Connection != null)
                                ClsMsgBox.Cw("�ع�ʧ��! �쳣����:" + ex1.GetType(), ex1, frm, this);
                        }
                    }
                    finally
                    {
                        conn.Close();
                        //PriListid.Clear();
                    }
                }
            }
        }
        #region ����
        private void BtnClose_Click(object sender, EventArgs e)
        {
            PriListid.Clear();
            PriYdCounts = 0;
            this.Close();
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
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value))
                        {
                            int aId = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtid"].Value);
                            int n;
                            int aYdCounts = 0;
                            double m;
                            double aRowDsk = 0;
                            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                                aRowDsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                            if (Int32.TryParse(Dgv.Rows[i].Cells["DgvColTxtcounts"].Value.ToString(), out n))
                            {
                                aYdCounts = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtcounts"].Value);//������
                            }
                            if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value))//ȡ��ѡ��
                            {
                                Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value = true;
                                PriListid.Add(aId);
                                PriYdCounts = PriYdCounts + aYdCounts;
                                PriSumJe = PriSumJe + aRowDsk;
                            }
                        }
                    }
                }
                //�������һҳ��ֵ
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value))
                        {
                            int aId = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtid"].Value);
                            int n;
                            int aYdCounts = 0;
                            double m;
                            double aRowDsk = 0;
                            if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                                aRowDsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                            if (Int32.TryParse(Dgv.Rows[i].Cells["DgvColTxtcounts"].Value.ToString(), out n))
                            {
                                aYdCounts = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtcounts"].Value);//������
                            }
                            if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value))//ȡ��ѡ��
                            {
                                Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value = true;
                                PriListid.Add(aId);
                                PriYdCounts = PriYdCounts + aYdCounts;
                                PriSumJe = PriSumJe + aRowDsk;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value))
                    {
                        int aId = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtid"].Value);
                        int n;
                        int aYdCounts = 0;
                        double m;
                        double aRowDsk = 0;
                        if (double.TryParse(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                            aRowDsk = Convert.ToDouble(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                        if (Int32.TryParse(Dgv.Rows[i].Cells["DgvColTxtcounts"].Value.ToString(), out n))
                        {
                            aYdCounts = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtcounts"].Value);//������
                        }
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value))//ȡ��ѡ��
                        {
                            Dgv.Rows[i].Cells[DgvColTxtxz.Name].Value = true;
                            PriListid.Add(aId);
                            PriYdCounts = PriYdCounts + aYdCounts;
                            PriSumJe = PriSumJe + aRowDsk;
                        }
                    }
                }
            }
        }
        #endregion
        #region ��ʾ��Ϣ
        private void GetXx()
        {
            LblCheckCount.Text = "��ѡ��" + PriListid.Count.ToString() + "��";
            if (PriSumJe == 0)
                LblCheckSumJe.Text = "��ѡ�д��տ�0.00Ԫ";
            else
                LblCheckSumJe.Text = "��ѡ�д��տ�" + PriSumJe.ToString() + "Ԫ";
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
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                int aId = Convert.ToInt32(row.Cells["DgvColTxtid"].Value);
                int n;
                int aYdCounts = 0;
                double m;
                double aRowDsk = 0;
                if (double.TryParse(row.Cells[DgvColTxtdsk.Name].Value.ToString(), out m))
                    aRowDsk = Convert.ToDouble(row.Cells[DgvColTxtdsk.Name].Value);
                if (Int32.TryParse(row.Cells["DgvColTxtcounts"].Value.ToString(), out n))
                    aYdCounts = Convert.ToInt32(row.Cells["DgvColTxtcounts"].Value);//������ 
                if (!aChecked)//ȡ��ȫѡ
                {
                    if (Convert.ToBoolean(row.Cells[DgvColTxtxz.Name].Value))//ȡ��ѡ��
                    {
                        row.Cells[DgvColTxtxz.Name].Value = false;
                        PriListid.Remove(aId);
                        PriYdCounts = PriYdCounts - aYdCounts;
                        PriSumJe = PriSumJe - aRowDsk;
                    }
                }
                else
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColTxtxz.Name].Value))
                    {
                        row.Cells[DgvColTxtxz.Name].Value = true;
                        PriListid.Add(aId);
                        PriYdCounts = PriYdCounts + aYdCounts;
                        PriSumJe = PriSumJe + aRowDsk;
                    }
                }
            }
        }
        #endregion

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 3, 4, 5 };
            ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1, Rows);  
            //ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1);  
        }
    }
}
