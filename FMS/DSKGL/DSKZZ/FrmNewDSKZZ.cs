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
using JY.Pub;
using JY.Pri;
using FMS.SeleFrm;
using System.Data.SqlClient;
#endregion
namespace FMS.DSKGL.DSKZZ
{
    public partial class FrmNewDSKZZ : Form
    {
        #region ��Ա����
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private decimal PriZj;
        private decimal PriYcje;//��PriZj�Ա������Ƿ�׼ȷ
        private int ChkRowCount;
        private int PriRowCount;//��ChkRowCount�Ա������Ƿ�׼ȷ
        private string CmdText;
        private string PriZffs;
        private string PriRbbh;
        private string PriRbpcid;
        private List<string> LstSql = new List<string>();
        private List<int> LstYdid = new List<int>();
        private string PriFwjgid;
        //private int RowCount;
        private bool IsChecked;
        private int PriUpdRows;
        private int PriZflx = 0;
        #endregion
        public FrmNewDSKZZ()
        {
            InitializeComponent();
        }
        #region ��ʼ������
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            Vfmsdskzz2TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            PriJgDt = ClsRWMSSQLDb.GetDataTable("select tojgmc,tojgid from vfmsjggx where gxzl='D' and jgid=" + ObjG.Jigou.id, ClsGlobals.CntStrTMS);
            if (PriJgDt.Rows.Count == 1)
            {
                LblFwjgmc.Text = PriJgDt.Rows[0]["tojgmc"].ToString();
                PriFwjgid = PriJgDt.Rows[0]["tojgid"].ToString();
            }
            ClsPopulateCmbDsS.PopuYd_dshksqfs(Cmbfkfs);

            ClsPopulateCmbDsS.PopuFmsDskffsj(CmbDszl);
            Cmbfkfs.SelectedIndex = 0;
            CmbDszl.SelectedIndex = 0;
            CmbZffs.SelectedIndex = 0;
        }
        #endregion

        #region ����
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region �ͻ���ѯ
        private void BtnSearchKh_Click(object sender, EventArgs e)
        {
            FrmSelectKh f = new FrmSelectKh();
            f.Prepare();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectKh f = sender as FrmSelectKh;
            if (f.DialogResult == DialogResult.OK)
                Txtfhkh.Text = f.PubKhmc;
        }
        #endregion

        #region ���������ѯ
        private void BtnSearchjg_Click(object sender, EventArgs e)
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
                this.txtsljg.Text = f.PubDictAttrs["mc"];
            else if (f.DialogResult == DialogResult.No)
                this.txtsljg.Text = "";
        }
        #endregion

        #region ��ѯ
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //ChkQx.Checked = false;
            LblTs.Visible = false;
            try
            {
                ClsD.TextBoxTrim(this);
                Clear();
                string where = " where qsjgid=" + ObjG.Jigou.id;
                if (DtpSlStart.Checked)
                    where += " and inssj >= '" + DtpSlStart.Value.Date + "'";
                if (DtpSlStop.Checked)
                    where += " and inssj < '" + DtpSlStop.Value.AddDays(1).Date + "'";
                if (DtpQsStart.Checked)
                    where += " and qssj >= '" + DtpQsStart.Value.Date + "'";
                if (DtpQsStop.Checked)
                    where += " and qssj < '" + DtpQsStop.Value.AddDays(1).Date + "'";
                where += string.IsNullOrEmpty(txtsljg.Text) ? "" : " and sljg ='" + txtsljg.Text + "'";
                where += string.IsNullOrEmpty(Txthydh.Text) ? "" : " and bh='" + Txthydh.Text + "'";
                where += " and dskfkfs='" + Cmbfkfs.SelectedValue + "'";
                where += string.IsNullOrEmpty(Txtfhkh.Text) ? "" : " and fhkhmc ='" + Txtfhkh.Text + "'";
                where += CmbDszl.SelectedIndex == 0 ? "" : " and dshklx='" + CmbDszl.Text.Trim() + "'";
                where += " and zflx= '" + CmbZffs.Text.Trim() + "'";
                where += "   ORDER BY dsffsj,qssj  ";
                DSdskzz1.EnforceConstraints = false;
                PriZflx = CmbZffs.SelectedIndex;
                Vfmsdskzz2TableAdapter1.FillByWhere(DSdskzz1.Vfmsdskzz2, where);
                PriZffs = Cmbfkfs.SelectedValue.ToString();
                if (Bds.Count == 0)
                {
                    ClsMsgBox.Ts("û�в�ѯ�����տ���ת��Ϣ��", ObjG.CustomMsgBox, this);
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("���տ���ת��Ϣ��ѯʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion

        #region ��ת
        private void BtnZz_Click(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            PriRbbh = "D" + DateTime.Now.ToString("yyyyMMdd") + ObjG.Jigou.id;
            if (string.IsNullOrEmpty(LblFwjgmc.Text))
            {
                ClsMsgBox.Ts("�û���û�д��տ��ϵ��������ά����", this, LblFwjgmc, ObjG.CustomMsgBox);
                return;
            }
            if (ChkRowCount <= 0)
            {
                ClsMsgBox.Ts("��ѡ��Ҫ���������ݼ�¼ ", ObjG.CustomMsgBox, this);
                return;
            }
            DskZZ();
        }
        public void DskZZ()
        {
            PriUpdRows = 0;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsGlobals.CntStrTMS;
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.Transaction = trans;
                    try
                    {
                        //if (PriZffs == "X"&& PriZflx > 0)
                        //{ 
                        //        PriZflx = 0;
                        //}
                        CmdText = string.Format("  SET NOCOUNT OFF insert into Tfmsdskjkpc(rbdh,jgid,zffs,dsk,sxf,zt,cnt,zzsj,zzczyid,zzczyzh,zzczyxm,spjgid,zflx)" +
                            "  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');select SCOPE_IDENTITY() ",
                            PriRbbh, ObjG.Jigou.id, PriZffs, PriZj, 0, 0, ChkRowCount, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriFwjgid, PriZflx);
                        comm.CommandText = CmdText;
                        PriRbpcid = comm.ExecuteScalar().ToString();
                        GetSql(PriRbpcid);
                        if (PriYcje != PriZj)
                        {
                            ClsMsgBox.Ts("���տ���תʧ�ܣ�������ѡ�����ݣ�", ObjG.CustomMsgBox, this);
                            trans.Rollback();
                            return;
                        }
                        if (PriRowCount != ChkRowCount)
                        {
                            ClsMsgBox.Ts("���տ���תʧ�ܣ�������ѡ�����ݣ�", ObjG.CustomMsgBox, this);
                            trans.Rollback();
                            return;
                        }
                        comm.CommandText = string.Join(";", LstSql);
                        comm.ExecuteNonQuery();
                        CmdText = "";
                        CmdText = "SET NOCOUNT OFF UPDATE Tfmsdsk SET SJDSKZT=10 WHERE id IN (" + string.Join(",", LstYdid) + ") and fkfs='" + PriZffs + "'   and SJDSKZT=0 ";
                        comm.CommandText = CmdText;
                        PriUpdRows = comm.ExecuteNonQuery();
                        if (LstSql.Count() != PriUpdRows)
                        {
                            ClsMsgBox.Ts("���տ���תʧ��!", ObjG.CustomMsgBox, this);
                            trans.Rollback();
                            return;
                        }
                        trans.Commit();
                        this.Close();
                        ClsMsgBox.Ts("���տ���ת�ɹ�������ת" + ChkRowCount + "Ʊ,�ܹ�" + LblZjje.Text + "Ԫ", ObjG.CustomMsgBox, this);
                    }
                    catch (Exception ex)
                    {
                        ClsMsgBox.Cw("���տ���תʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
        }
        #endregion

        #region ��װ��ϸSQL���
        private void GetSql(string aRbpdid)
        {
            LblTs.Visible = false;
            LstSql.Clear();
            LstYdid.Clear();
            PriYcje = 0;
            PriRowCount = 0;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                {
                    LstSql.Add(string.Format("INSERT INTO Tfmsdskjkmx (pcid,dskid,ydid,dsk,sxf) VALUES('{0}','{1}','{2}','{3}','{4}')",
                        PriRbpcid, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtdsk.Name].Value, 0));
                    PriYcje += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                    LstYdid.Add(Convert.ToInt32(row.Cells[DgvColTxtDskid.Name].Value));
                    PriRowCount++;
                }
            }
        }
        #endregion

        #region ����ѡ��
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblTs.Visible = false;
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                //string mcs = Dgv.Rows[e.RowIndex].Cells[DgvColTxtsftzt.Name].Value.ToString();
                //if (Dgv.Rows[e.RowIndex].Cells[DgvColTxtsftzt.Name].Value.ToString() != "2")
                //{
                    if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                    {
                        ChkRowCount--;
                        Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        PriZj -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                    }
                    else
                    {
                        ChkRowCount++;
                        Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        PriZj += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                    }
                //}
            }
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "��ѡ��" + ChkRowCount + "��";
        }
        #endregion

        #region ��ҳȫѡ
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            if (Dgv.Rows.Count == 0)
                return;
            CheckThisPage();
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "��ѡ��" + ChkRowCount + "��";
        }
        public void CheckThisPage()
        {
            if (Bds.Count == 0)
                return;
            int curPageFirstIndex = (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;//��ȡ��ǰҳ�ĵ�һ�е�RowIndex
            int lastPageSize = Dgv.RowCount - (Dgv.TotalPages - 1) * Dgv.ItemsPerPage; //��ȡ���һҳ������
            int curPageSize = Dgv.CurrentPage != Dgv.TotalPages ? Dgv.ItemsPerPage : lastPageSize; //��ȡÿҳ���������������һҳ��
            int curRowIndex = curPageFirstIndex;

            while (curRowIndex < (curPageFirstIndex + curPageSize))
            {
                if (Dgv.Rows[curRowIndex].Cells[DgvColTxtsftzt.Name].Value.ToString() != "2")
                {
                    if (!Convert.ToBoolean(Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value).Equals(true))
                    {
                        Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value = true;
                        PriZj += Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtdsk.Name].Value);
                        ChkRowCount++;
                    }
                    else
                    {
                        Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value = false;
                        PriZj -= Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtdsk.Name].Value);
                        ChkRowCount++;
                    }
                }
                curRowIndex++;
            }
            /*
            //һ���ж�����
            int rowcount = Convert.ToInt32(Dgv.RowCount);
            //��ǰ�ǵڼ�ҳ
            int currentpage = Convert.ToInt32(Dgv.CurrentPage);
            //һҳ�л���
            int pageSize = Convert.ToInt32(Dgv.ItemsPerPage);
            //һ���ж���ҳ
            int pageCount = (rowcount / pageSize);
            //�ϼƵ�ֵ
            decimal sum = 0;
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
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value))
                        {
                            Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value = true;
                            sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                            ChkRowCount++;
                        }
                    }
                    PriZj += sum;
                }
                //�������һҳ��ֵ
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value))
                        {
                            Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value = true;
                            sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                            ChkRowCount++;
                        }
                    }
                    PriZj += sum;
                }
            }
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value))
                    {
                        Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value = true;
                        sum += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                        ChkRowCount++;
                    }
                }
                PriZj += sum;
            }*/
        }
        #endregion

        #region ȫѡ
        private void ChkQx_CheckedChanged(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            if (Dgv.Rows.Count == 0)
                return;
            CheckAll(ChkQx.Checked);
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "��ѡ��" + ChkRowCount + "��";
        }
        public void CheckAll(bool aChecked)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (aChecked)
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                    {
                        row.Cells[DgvColTxtCheck.Name].Value = true;
                        PriZj += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                        ChkRowCount++;
                    }
                }
                else
                {
                    if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                    {
                        row.Cells[DgvColTxtCheck.Name].Value = false;
                        PriZj -= Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                        ChkRowCount--;
                    }
                }
            }
        }
        #endregion

        #region Clear
        public void Clear()
        {
            PriZj = Convert.ToDecimal(0.00);
            ChkRowCount = 0;
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "��ѡ��" + ChkRowCount + "��";
            //RowCount = 0;
            //LblTs.Text = "��ѡ��" + RowCount.ToString() + "��!";
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
            int[] Rows = new int[] { 5, 6 };
            ClsExcel.CreatExcel(Dgv, "���տ���ת", this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, "���տ���ת", this.ctrlDownLoad1); 
        }
        #endregion

        private void BtnKsxz_Click(object sender, EventArgs e)
        {
            LblTs.Visible = true;
            //RowCount = 0;
            IsChecked = false;
            if (string.IsNullOrEmpty(TxtBh.Text))
            {
                LblTs.Text = "��¼����˱�ţ�";
                LblTs.ForeColor = Color.Red;
                return;
            }
            //int position = Bds.Find("bh", TxtBh.Text);
            //if (position < 0)
            //{
            //    LblTs.Text = "û��Ҫѡ����˵���";
            //    return;
            //}
            //Bds.Position = position;
            //if (!Convert.ToBoolean(Dgv.CurrentRow.Cells[DgvColTxtCheck.Name].Value))
            //{
            //    Dgv.CurrentRow.Cells[DgvColTxtCheck.Name].Value = true;
            //    ChkRowCount++;
            //    LblCheckCount.Text = "��ѡ��" + ChkRowCount + "��";
            //}
            //ClsD.TurnToBdsPosPage(Dgv);
            //LblTs.Text = "��" + this.Dgv.CurrentPage + "ҳ����" + (Convert.ToInt32(position) + 1) + "��!";
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (row.Cells[DgvColTxthydh.Name].Value.Equals(TxtBh.Text) && !Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                {
                    row.Cells[DgvColTxtCheck.Name].Value = true;
                    Bds.Position = row.Index;
                    IsChecked = true;
                    PriZj += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                    ChkRowCount++;
                    //RowCount++;
                }
            }
            if (!IsChecked)
            {
                LblTs.Visible = true;
                LblTs.Text = "û�в�ѯ����Ӧ�˵���";
                LblTs.ForeColor = Color.Red;
                return;
            }
            ClsD.TurnToBdsPosPage(Dgv);
            int RowIndex = Bds.Find("bh", TxtBh.Text);
            LblCheckCount.Text = "��ѡ��" + ChkRowCount + "��";
            LblZjje.Text = PriZj.ToString();
            LblTs.Visible = true;
            string bh = TxtBh.Text;
            TxtBh.Text = "";
            LblTs.Text = "�˵���" + bh + "��ѡ�У���ѡ��" + ChkRowCount + "��";
            LblTs.ForeColor = Color.Green;
        }

        private void TxtBh_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            this.BtnKsxz.PerformClick();
        }

        private void BtnFX_Click(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            foreach (DataGridViewRow row in Dgv.Rows)
            {

                if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                {
                    row.Cells[DgvColTxtCheck.Name].Value = false;
                    PriZj -= Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                    ChkRowCount--;
                    //RowCount--;
                }
                else
                {
                    row.Cells[DgvColTxtCheck.Name].Value = true;
                    PriZj += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                    ChkRowCount++;
                }
            }
            LblCheckCount.Text = "��ѡ��" + ChkRowCount + "��";
            LblZjje.Text = PriZj.ToString();
            //LblTs.Text = "��ѡ��" + RowCount.ToString() + "��!";
        }



    }
}
