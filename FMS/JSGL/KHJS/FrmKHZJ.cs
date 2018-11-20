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
using FMS.SeleFrm;
#endregion

namespace FMS.JSGL.KHJS
{
    public partial class FrmKHZJ : Form
    {
        private decimal PriDzje = 0;
        private ClsG ObjG;
        private string PriYwqy = "";
        private string PriKhmc = "";
        private string PriDzqssj = "";
        private string PriDzjsjs = "";
        private string PriWhere = "";
        private int PriJgid = 0;
        private string PriJgmc = "";
        private EnumNEDD PriEnumNEDD;
        private int PriXzCnt = 0;
        private string PriKhid = "0";
        private List<int> PriListYbfId = new List<int>();
        public FrmKHZJ()
        {
            InitializeComponent();
        }
        public void Prepare(EnumNEDD aEnumNEDD)
        {
            PriEnumNEDD = aEnumNEDD;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            PriJgid = ObjG.Jigou.id;
            PriJgmc = ObjG.Jigou.mc;
            this.LblJG.Text = PriJgid.ToString();
            this.TxtDzjg.Text = PriJgmc;
            this.BtnJG.Visible = false;
            VfmsyfzjTableAdapter.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }
        #region ����
        private void BtnAnd_Click(object sender, EventArgs e)
        {
            if (PriXzCnt > 0)
            {
                FrmKHJSXX f = new FrmKHJSXX();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed2);
                f.ShowDialog();
                f.Prepare(PriYwqy, PriKhmc, PriDzqssj, PriDzjsjs, PriDzje, PriListYbfId, lblKhid.Text, PriJgid.ToString());
            }
            else
                ClsMsgBox.Ts("��ѡ��Ҫ�������½�ͻ��˵���Ϣ��", ObjG.CustomMsgBox, this);
        }
        void f_FormClosed2(object sender, FormClosedEventArgs e)
        {
            FrmKHJSXX f = sender as FrmKHJSXX;
            if (f.DialogResult == DialogResult.OK)
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
                //ClsMsgBox.Ts("�����ɹ���", ObjG.CustomMsgBox, this);
            }

        }

        #endregion
        #region ��굥ѡ
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1)
                return;
            if (e.ColumnIndex == 0)//��˶���
            {
                decimal n;
                decimal aRowJe = 0;
                if (decimal.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                    aRowJe = Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtje.Name].Value);
                int aYdid = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtId.Name].Value);
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))//ȡ��
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    PriDzje = PriDzje - aRowJe;
                    PriXzCnt = PriXzCnt - 1;
                    PriListYbfId.Remove(aYdid);
                }
                else
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    PriDzje = PriDzje + aRowJe;
                    PriXzCnt = PriXzCnt + 1;
                    PriListYbfId.Add(aYdid);
                }
                GetXx();
            }
        }
        #endregion
        #region ��ѯ
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            PriDzje = 0;
            if (TxtKhmc.Text.Trim() == "")
            {
                ClsMsgBox.Ts("��ѡ��ͻ����ƣ�", ObjG.CustomMsgBox, this);
                return;
            }
            PriListYbfId.Clear();
            if (CmbYwqy.SelectedIndex != 0)
                PriYwqy = CmbYwqy.Text;
            PriDzqssj = DtpStart.Text;
            PriDzjsjs = DtpStop.Text;
            PriKhmc = TxtKhmc.Text;
            PriKhid = lblKhid.Text;
            PriWhere = "";
            PriWhere = " where  zt='0' and jsjgid='" + LblJG.Text.Trim() + "'";
            if (TxtDzjg.Text.Trim() != "")
                PriWhere = PriWhere + " and  jsjgid=" + LblJG.Text;
            //if (CmbYwqy.SelectedIndex != 0)
            PriWhere = PriWhere + "  and inssj between'" + DtpStart.Value + "'and DateAdd(dd,+1, '" + DtpStop.Value + "')";
            if (CmbYwqy.SelectedIndex != 0)
                PriWhere = PriWhere + " and ywqy='" + PriYwqy + "'";
            PriWhere = PriWhere + " and  khmc='" + TxtKhmc.Text + "' ";
            this.VfmsyfzjTableAdapter.FillByWhere(DSKHJS1.Vfmsyfzj, PriWhere);
            if (Dgv.RowCount == 0)
                ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ��", ObjG.CustomMsgBox, this);
            GetXx();
        }
        #endregion
        #region ����
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        private void TxtDzjg_KeyDown(object objSender, KeyEventArgs objArgs)
        {
            if (objArgs.KeyCode == Keys.Back)
            {
                this.TxtDzjg.Text = "";
                this.LblJG.Text = "";
            }

        }
        private void TxtKhmc_KeyDown(object objSender, KeyEventArgs objArgs)
        {
            if (objArgs.KeyCode == Keys.Back)
                this.TxtKhmc.Text = "";
        }
        private void BtnJG_Click(object sender, EventArgs e)
        {
            FrmSelectJg f = new FrmSelectJg();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            using (FrmSelectJg f = sender as FrmSelectJg)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    this.TxtDzjg.Text = f.PubDictAttrs["mc"];
                    this.LblJG.Text = f.PubDictAttrs["id"];
                    PriJgid = Convert.ToInt32(this.LblJG.Text);
                    PriJgmc = this.TxtDzjg.Text;
                }
                else if (f.DialogResult == DialogResult.No)
                {
                    this.TxtDzjg.Text = "";
                    this.LblJG.Text = "";
                    PriJgid = 0;
                    PriJgmc = this.TxtDzjg.Text;
                }
            }
        }

        private void BtnKh_Click(object sender, EventArgs e)
        {
            FrmSelectKh1 f = new FrmSelectKh1();
            f.ShowDialog();
            f.Prepare();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }
        void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FrmSelectKh1 f = sender as FrmSelectKh1)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    TxtKhmc.Text = f.PubKhmc;
                    this.lblKhid.Text = f.PubKkid.ToString();
                }
                else
                {
                    TxtKhmc.Text = "";
                    this.lblKhid.Text = "0";
                }
            }
        }

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
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCelXz.Name].Value))
                        {
                            decimal n;
                            decimal aRowJe = 0;
                            if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                                aRowJe = Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value);
                            int aYdid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtId.Name].Value);
                            Dgv.Rows[i].Cells[DgvColCelXz.Name].Value = true;
                            PriDzje = PriDzje + aRowJe;
                            PriXzCnt = PriXzCnt + 1;
                            PriListYbfId.Add(aYdid);
                        }
                    }
                }
                //�������һҳ��ֵ
                else
                {
                    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCelXz.Name].Value))
                        {
                            decimal n;
                            decimal aRowJe = 0;
                            if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                                aRowJe = Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value);
                            int aYdid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtId.Name].Value);
                            Dgv.Rows[i].Cells[DgvColCelXz.Name].Value = true;
                            PriDzje = PriDzje + aRowJe;
                            PriXzCnt = PriXzCnt + 1;
                            PriListYbfId.Add(aYdid);
                        }
                    }
                }
            }
            else
            {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    if (!Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColCelXz.Name].Value))
                    {
                        decimal n;
                        decimal aRowJe = 0;
                        if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                            aRowJe = Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value);
                        int aYdid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtId.Name].Value);
                        Dgv.Rows[i].Cells[DgvColCelXz.Name].Value = true;
                        PriDzje = PriDzje + aRowJe;
                        PriXzCnt = PriXzCnt + 1;
                        PriListYbfId.Add(aYdid);
                    }
                }
            }
        }
        #region ȫѡ
        private void ChkB_CheckedChanged(object sender, EventArgs e)
        {
            CheckAll(ChkB.Checked);
            GetXx();
        }
        private void CheckAll(bool aChecked)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                decimal n;
                decimal aRowJe = 0;
                if (decimal.TryParse(row.Cells[DgvColTxtje.Name].Value.ToString(), out n))
                    aRowJe = Convert.ToDecimal(row.Cells[DgvColTxtje.Name].Value);
                int aYdid = Convert.ToInt32(row.Cells[DgvColTxtId.Name].Value);
                if (Convert.ToBoolean(row.Cells[DgvColCelXz.Name].Value) == true && aChecked == false)//ȡ��
                {
                    row.Cells[DgvColCelXz.Name].Value = false;
                    PriDzje = PriDzje - aRowJe;
                    PriXzCnt = PriXzCnt - 1;
                    PriListYbfId.Remove(aYdid);
                }
                else if (Convert.ToBoolean(row.Cells[DgvColCelXz.Name].Value) == false && aChecked == true)
                {
                    row.Cells[DgvColCelXz.Name].Value = true;
                    PriDzje = PriDzje + aRowJe;
                    PriXzCnt = PriXzCnt + 1;
                    PriListYbfId.Add(aYdid);
                }
            }
        }
        #endregion
        #region ��ʾ��Ϣ
        private void GetXx()
        {
            LblCheckCount.Text = "��ѡ��" + PriListYbfId.Count.ToString() + "��";
            if (PriDzje == 0)
                LblCheckSumJe.Text = "��ѡ�н��0.00Ԫ";
            else
                LblCheckSumJe.Text = "��ѡ�н��" + PriDzje.ToString() + "Ԫ";
        }
        #endregion

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 7 };
            ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1);
        }

    }
}