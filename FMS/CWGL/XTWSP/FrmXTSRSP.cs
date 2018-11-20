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
#endregion

namespace FMS.CWGL.XTWSP
{
    public partial class FrmXTSRSP : UserControl
    {
        private ClsG ObjG;
        private string PriConStr;
        private DSSP.VfmsxtwpcRow PriRow;
        private List<int> PriList = new List<int>();
        private int pageSize = 0;
        private int PriJgid;//��Ҫ��˵Ļ���id
        public FrmXTSRSP()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriConStr = ClsGlobals.CntStrTMS;
            VfmsxtwpcTableAdapter1.Connection.ConnectionString = PriConStr;
            CmbZt.SelectedIndex = 0;
            CmbPpjg.SelectedIndex = 0;
            DataTable dt = ClsRWMSSQLDb.GetDataTable("SELECT -1 id, 'ȫ��' name,-1 sort FROM dbo.Tfmsxtwsr_lx UNION  SELECT id,name,sort FROM dbo.Tfmsxtwsr_lx  ORDER BY sort ", ClsGlobals.CntStrTMS);
            this.CmbLx.DataSource = dt;
            this.CmbLx.DisplayMember = "name";
            this.CmbLx.ValueMember = "id";
            this.CmbLx.SelectedIndex = 0;


            //��������
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable("SELECT -1 id, 'ȫ��' jc   UNION  SELECT id,jc FROM  tyhlx WHERE  id in (49,63,241);  ", ClsGlobals.CntStrTMS);
            this.CmbYHlx.DataSource = dtYhlx;
            this.CmbYHlx.DisplayMember = "jc";
            this.CmbYHlx.ValueMember = "id";
            this.CmbYHlx.SelectedIndex = 0;

            pageSize = Convert.ToInt32(Dgv.ItemsPerPage);
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            Chb.Checked = false;
            LblCheckSumJe.Text = "��ҳ�ɿ�ϼ�0Ԫ��ȫ���ɿ�ϼ�0Ԫ";
            if (DtpQrStart.Checked == false && DtpQrStop.Checked == false && DtpSpStart.Checked == false && DtpSpStop.Checked == false)
            {
                ClsMsgBox.Ts("����ʱ�������ʱ�����ѡ��һ����", ObjG.CustomMsgBox, this);
                return;
            }
            if (CmbZt.Text == "������" && (DtpSpStart.Checked == true || DtpSpStop.Checked == true))
            {
                ClsMsgBox.Ts("�����е����벻��ѡ������ʱ�䣡", ObjG.CustomMsgBox, this);
                return;
            }
            string SWhere = " WHERE spjgid=" + ObjG.Jigou.id;
            if (PriJgid > 0)
                SWhere += "  and  zzjgid= " + PriJgid;
            if (DtpQrStart.Checked == true)
                SWhere += " AND inssj>= '" + DtpQrStart.Value.Date + "' ";
            if (DtpQrStop.Checked == true)
                SWhere += " AND inssj<='" + DtpQrStop.Value.Date.AddDays(1) + "' ";
            if (DtpSpStart.Checked == true)
                SWhere += " AND spsj>= ' " + DtpSpStart.Value.Date + "' ";
            if (DtpSpStop.Checked == true)
                SWhere += " AND spsj<='" + DtpSpStop.Value.Date.AddDays(1) + "' ";
            if (CmbZt.SelectedIndex == 0)
                SWhere += " AND zt=0 ";
            else if (CmbZt.SelectedIndex == 1)
                SWhere += " AND zt=1 ";
            else
                SWhere += " AND zt=2 ";
            if (CmbLx.SelectedIndex != 0)
                SWhere += " AND lxs='" + CmbLx.Text + "'";
            if (CmbYHlx.SelectedIndex != 0)
                SWhere += " and yhlxid= " + CmbYHlx.SelectedValue;
            if (CmbPpjg.SelectedIndex != 0)
                SWhere += " and ppzt='" + CmbPpjg.Text.ToString() + "'";
            VfmsxtwpcTableAdapter1.FillByWhere(DSSP1.Vfmsxtwpc, SWhere);
            PriList.Clear();
            if (Dgv.Rows.Count == 0)
                ClsMsgBox.Ts("û�в�ѯ����Ϣ��������ȷ�ϲ�ѯ������", ObjG.CustomMsgBox, this);
            else
                SumThisPage();
        }
        private void BtnSel_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.Rows.Count > 60000)
            {
                ClsMsgBox.Ts("������������60000��������!", (Session["ObjG"] as ClsG).CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(Dgv, "ϵͳ����������", ctrlDownLoad1, new int[] { 4 });
        }
        private void BtnSPTG_Click(object sender, EventArgs e)
        {
            GetList();
            if (PriList.Count == 0)
            {
                ClsMsgBox.Ts("���������һ��������Ϣ��", ObjG.CustomMsgBox, this);
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
                    cmdText = string.Format(" update  tfmsxtwsrpc set spsj='{0}', sprid='{1}',sprzh='{2}',spr='{3}',zt='{4}' where id in ({5})",
                 DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, 1, string.Join(",", PriList));
                    cmdText += " update  Tfmsxtsr set zt=20 where id in (select srid  from tfmsxtwsrmx where pcid in (select id from  tfmsxtwsrpc where id   in (" + string.Join(",", PriList) + "))) ";
                    comm.CommandText = cmdText;
                    int influenceSum = comm.ExecuteNonQuery();
                    if (influenceSum > 0)
                    {
                        //�ύ����
                        ClsMsgBox.Ts("��˳ɹ��������" + PriList.Count + "����Ϣ", ObjG.CustomMsgBox, this);
                        trans.Commit();
                        foreach (int i in PriList)
                        {
                            int index = Bds.Find("id", i);
                            Bds.RemoveAt(index);
                        }
                        PriList.Clear();
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
                    SumThisPage();
                }
            }
        }

        private void GetList()
        {
            PriList.Clear();
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvCbxQx.Name].Value))
                {
                    if (row.Cells[DgvCbxQx.Name].Value.ToString().Length > 0)
                    {
                        int id = Convert.ToInt32(row.Cells[DgvTxtid.Name].Value.ToString());
                        PriList.Add(id);
                    }
                }

            }
        }

        private void BtnByQx_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
                return;
            CheckThisPage();
        }
        public void CheckThisPage()
        {
            //��ҳ�ж�����
            int currenRows = 0;
            if (Dgv.CurrentPage == Dgv.TotalPages)
                currenRows = Dgv.RowCount - (Dgv.TotalPages - 1) * pageSize;
            else
                currenRows = pageSize;
            for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + currenRows; i++)
            {
                if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvCbxQx.Name].Value))
                {
                    if (Dgv.Rows[i].Cells[DgvTxtZt.Name].Value.ToString().LastIndexOf("����") != 0)
                        Dgv.Rows[i].Cells[DgvCbxQx.Name].Value = true;
                }

            }
        }

        private void Chb_CheckedChanged(object sender, EventArgs e)
        {
            CheckAll(Chb.Checked);
        }
        public void CheckAll(bool aChecked)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (row.Cells[DgvTxtZt.Name].Value.ToString().LastIndexOf("����") != 0)
                    row.Cells[DgvCbxQx.Name].Value = aChecked;
            }
        }

        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                string zt = Dgv.Rows[e.RowIndex].Cells[DgvTxtZt.Name].Value.ToString();

                if (zt.LastIndexOf("����") == 0)
                {
                    ClsMsgBox.Ts("����Ϣ�Ѿ���ˣ�������ˣ�");
                    Dgv.Rows[e.RowIndex].Cells[DgvCbxQx.Name].Value = false;
                    return;
                }
                //else
                //{
                //    if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvCbxQx.Name].Value))
                //        Dgv.Rows[e.RowIndex].Cells[DgvCbxQx.Name].Value = false;
                //    else
                //        Dgv.Rows[e.RowIndex].Cells[DgvCbxQx.Name].Value = true;
                //}
            }
        }

        #region ��ҳ�ϼ�
        private void SumThisPage()
        {
            decimal sum_by = 0;//��ҳ�ϼƽ��
            decimal sum_qb = 0;//ȫ���ϼƽ��
            if (Dgv.RowCount > 0)
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
                            sum_by += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvTxtje.Name].Value);
                        }
                    }
                    //�������һҳ��ֵ
                    else
                    {
                        for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                        {
                            sum_by += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvTxtje.Name].Value);
                        }
                    }
                }
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                    {
                        sum_by += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvTxtje.Name].Value);
                    }
                }
                for (int i = 0; i < Dgv.RowCount; i++)
                {
                    sum_qb += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvTxtje.Name].Value);
                }
            }
            LblCheckSumJe.Text = "��ҳ�ɿ�ϼ�" + sum_by + "Ԫ��ȫ���ɿ�ϼ�" + sum_qb + "Ԫ";

        }
        #endregion

        private void BtnSPBTG_Click(object sender, EventArgs e)
        {
            SumThisPage();
        }


        #region ����ѡ�� BtnJg_Click(object sender, EventArgs e)
        /// <summary>
        /// ����ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnJg_Click(object sender, EventArgs e)
        {
            SeleFrm.FrmSelectJg f = new SeleFrm.FrmSelectJg();
            f.Prepare();

            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            SeleFrm.FrmSelectJg f = sender as SeleFrm.FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtBJg.Text = f.PubDictAttrs["mc"];
                PriJgid = Convert.ToInt32(f.PubDictAttrs["id"]);
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtBJg.Text = "";
                PriJgid = 0;
            }
        }
        #endregion
    }
}