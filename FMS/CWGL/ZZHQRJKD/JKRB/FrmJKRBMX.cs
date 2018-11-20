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

#endregion

namespace FMS.CWGL.ZZHQRJKD.JKRB
{
    public partial class FrmJKRBMX : Form
    {
        #region ��Ա����
        private ClsG ObjG;
        private string Where;
        private string Where1;
        private decimal Zj;
        private int CheckCount = 0;
        //private int PriYdmxCount;
        //private int PriJsdCount;
        //DSJKRB.Vfmsfyjyd2DataTable YdTable;
        //private DSJKRB.Vfmsfyjyd2DataTable VfmsFyjyd2NotGroup = new DSJKRB.Vfmsfyjyd2DataTable();
        DSJKRB.Vfmsjkrb2DataTable YdTable;
        private DSJKRB.Vfmsjkrb2DataTable Vfmsjkrb2NotGroup = new DSJKRB.Vfmsjkrb2DataTable();
        private string PriLx;
        //private int RowCount;
        private bool IsChecked;
        private List<string> PriLstYbfid = new List<string>();//������ȡybfid

        //private EnumNEDD PriEnumNEDD;
        private decimal PriYfzj;
        private decimal PriBfzj;
        private string PriCmbYwqyText = "";
        private string PriCmbYwqySelsctVause = "";
        #endregion
        public FrmJKRBMX()
        {
            InitializeComponent();
        }
        #region ��ʼ������
        public void Prepare()
        {
            ObjG = (ClsG)Session["ObjG"];
            vfmsjkrb2TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            ClsPopulateCmbDsS.PopuFMS_Jzlx(CmbJzlx);
            CmbLy.SelectedIndex = 0;
            CmbJzlx.SelectedIndex = 0;
            //PriEnumNEDD = aEnumNEDD;
            this.BtnSearch.PerformClick();
            PriCmbYwqyText = CmbYwqy.Text;
            PriCmbYwqySelsctVause = CmbYwqy.SelectedValue.ToString();
        }
        #endregion

        #region ��ѯ
        private void BtnSave_Click(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            Clear();
            CheckRowCount();
            TxtBh.Text = TxtBh.Text.Trim();
            try
            {

                //Where = " where 1=1 ";
                Where1 = "";
                //Where += " and jgid =" + ObjG.Jigou.id;
                //Where += " and ywqy='" + CmbYwqy.SelectedValue + "'";
                //Where += CmbJzlx.SelectedIndex == 0 ? "" : " and jzlxs='" + CmbJzlx.Text + "'";
                Where1 += "  jgid =" + ObjG.Jigou.id;
                if (!string.IsNullOrEmpty(TxtBh.Text))
                {
                    Where1 += " and bh='" + TxtBh.Text + "'";
                }
                else
                {
                    if (CmbYwqy.SelectedIndex > 0)
                        Where1 += " and ywqy='" + CmbYwqy.SelectedValue + "'";
                    Where1 += CmbJzlx.SelectedIndex == 0 ? "" : " and jzlxs='" + CmbJzlx.Text + "'";
                    //Where += string.IsNullOrEmpty(TxtBh.Text.Trim()) ? "" : " and bh = '" + TxtBh.Text.Trim() + "'";
                    if (DtpStart.Checked)
                    {
                        //Where += " and sj >= '" + DtpStart.Value + "'";
                        Where1 += " and sj >= '" + DtpStart.Value + "'";
                    }

                    if (DtpStop.Checked)
                    {
                        //Where += " and sj <'" + DtpStop.Value.AddDays(1).Date + "'";
                        Where1 += " and sj <'" + DtpStop.Value.AddDays(1).Date + "'";
                    }


                    if (CmbLy.SelectedIndex == 0)
                    {
                        //Where += " and lx=0 ";
                        Where1 += " and lx=0 ";
                        PriLx = "Y";
                    }
                    else
                    {
                        //Where += " and lx=1 ";
                        Where1 += " and lx=1 ";
                        PriLx = "J";
                    }
                }
                //if (Where1.Trim().Length!=0)
                Where = " where  " + Where1;
                string CmdText = string.Format("SELECT jzlxs,jzlx,ywqy,ywqys,bh,ydid,jgid,SUM(yf) AS yf,SUM(bf) AS bf,SUM(ysje) AS ysje,(SELECT CONVERT(VARCHAR(10),a.ybfid)+',' FROM dbo.Vfmsjkrb2 AS a WHERE a.jzlx=b.jzlx AND ((a.bh=b.bh AND a.ydid=b.ydid) OR (a.bh=b.bh AND a.ydid IS NULL)) AND {0} FOR XML PATH('')) AS ybfid FROM dbo.Vfmsjkrb2 AS b WHERE   {0} group by jzlxs,jzlx,ywqy,ywqys,bh,ydid,jgid", Where1);
                vfmsjkrb2TableAdapter1.FillByWhere(DSjkrb1.Vfmsjkrb2, Where, CmdText);
                vfmsjkrb2TableAdapter1.FillByWhere(Vfmsjkrb2NotGroup, Where);
                PriCmbYwqyText = CmbYwqy.Text;
                PriCmbYwqySelsctVause = CmbYwqy.SelectedValue.ToString();
                //string CmdText = "select jzlxs,jzlx,ywqy,ywqys,bh,ydid,jgid,jgmc,sum(fhxf) as fhxf,sum(tf) as tf,sum(zf) as zf,sum(hf) as hf,sum(bfxf) as bfxf,sum(bfdf) as bfdf,sum(bfzf)as bfzf,sum(ysje) as ysje,sum(yc) as yc,zt,lx,(case when sum(b.px1)>0 then '0' else '1' end) as px,(select  convert(varchar(10), a.ybfid) +',' from Vfmsfyjyd2 as a  where (a.jzlx=b.jzlx and ((a.bh=b.bh  and a.ydid=b.ydid) or(a.bh=b.bh and a.ydid is null))) " + Where1 + " for xml path('') ) as ybfid from Vfmsfyjyd2 as b " + Where +
                //"  group by jzlxs,jzlx,ywqy,ywqys,bh,ydid,jgid,jgmc,zt,lx order by px";
                //Vfmsfyjyd2TableAdapter1.FillByWhere(DSjkrb1.Vfmsfyjyd2, Where, CmdText);
                //Vfmsfyjyd2TableAdapter1.FillByWhere(VfmsFyjyd2NotGroup, Where);

                //if (PriEnumNEDD == EnumNEDD.New)
                //{
                //    PriEnumNEDD = EnumNEDD.Edit;
                //    return;
                //}
                //if (Bds.Count == 0)
                //    ClsMsgBox.Ts("�޲�ѯ��Ϣ����˶Բ�ѯ������", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ��Ϣʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }

        }
        #endregion

        #region �ɿ�
        private void BtnJK_Click(object sender, EventArgs e)
        {
            GetMessage();
            FrmJkRBMXBC f = new FrmJkRBMXBC();
            f.Prepare(PriCmbYwqyText, Zj.ToString(), PriCmbYwqySelsctVause, PriLx, YdTable);
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form p = sender as FrmJkRBMXBC;
            if (p.DialogResult == DialogResult.OK)
                this.Close();
        }

        private void GetMessage()
        {
            try
            {
                List<string> LstYbfid = new List<string>();//������ȡ�Ѿ�����ybfid

                YdTable = new DSJKRB.Vfmsjkrb2DataTable();
                PriLstYbfid.Clear();
                foreach (DataGridViewRow Row in Dgv.Rows)
                {
                    PriLstYbfid.Clear();
                    var value = Row.Cells[DgvColTxtCheck.Name].Value;
                    if (value != null && value.Equals(true))
                    {
                        PriLstYbfid = Row.Cells[DgvColTxtYbfid.Name].Value.ToString().Substring(0, Row.Cells[DgvColTxtYbfid.Name].Value.ToString().LastIndexOf(',')).Split(',').ToList();

                        HashSet<string> LstYbfidHs = new HashSet<string>(PriLstYbfid); //��ʱȥ���ظ�������
                        if (LstYbfidHs.Count > 0)
                        {
                            foreach (DSJKRB.Vfmsjkrb2Row item in Vfmsjkrb2NotGroup.AsEnumerable().Where(r => LstYbfidHs.Contains(r.Field<string>("ybfid").ToString())).Where(r => r.Field<string>("jzlx").ToString().Equals(Row.Cells[DgvColTxtJzlx.Name].Value.ToString())).Where(r => r.Field<string>("ywqys").ToString().Equals(Row.Cells[this.DgvColTxtYwqys.Name].Value.ToString())).ToList())
                            {
                                YdTable.ImportRow(item);
                            }
                        }
                        //newrow = YdTable.NewRow() as DSJKRB.Vfmsfyjyd2Row;
                        //newrow.ItemArray = (((DataRowView)Row.DataBoundItem).Row as DSJKRB.Vfmsfyjyd2Row).ItemArray;
                        //YdTable.AddVfmsfyjyd2Row(newrow);
                    }
                }

            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("�ɿ�ʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }

        }

        #endregion

        #region ����
        private void BtnFh_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ��ҳȫѡ
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            if (Dgv.Rows.Count == 0)
                return;
            CheckThisPage();
            LblZjje.Text = "�ϼ��˷ѣ�" + PriYfzj.ToString() + " �ϼƱ��۷ѣ�" + PriBfzj.ToString() + " �ܺϼƣ�" + Zj.ToString();

            CheckRowCount();
        }

        public void CheckThisPage()
        {
            int curPageFirstIndex = (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;//��ȡ��ǰҳ�ĵ�һ�е�RowIndex
            int lastPageSize = Dgv.RowCount - (Dgv.TotalPages - 1) * Dgv.ItemsPerPage; //��ȡ���һҳ������
            int curPageSize = Dgv.CurrentPage != Dgv.TotalPages ? Dgv.ItemsPerPage : lastPageSize; //��ȡÿҳ���������������һҳ��
            int curRowIndex = curPageFirstIndex;
            while (curRowIndex < (curPageFirstIndex + curPageSize))
            {
                if (!Convert.ToBoolean(Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value))
                {
                    CheckCount++;
                    Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value = true;
                    Zj += Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvTxtZyf.Name].Value);
                    PriYfzj += Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvTxtYf.Name].Value);
                    PriBfzj += Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvTxtBf.Name].Value);
                }
                curRowIndex++;
            }
        }
        #endregion

        #region ȫѡ
        private void ChkQx_CheckedChanged(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            CheckAll(ChkQx.Checked);
            LblZjje.Text = "�ϼ��˷ѣ�" + PriYfzj.ToString() + " �ϼƱ��۷ѣ�" + PriBfzj.ToString() + " �ܺϼƣ�" + Zj.ToString();
            CheckRowCount();
        }

        public void CheckAll(bool aChecked)
        {
            if (aChecked)
            {
                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    row.Cells[DgvColTxtCheck.Name].Value = true;
                }
                CheckCount = Dgv.Rows.Count;
                Zj = Convert.ToDecimal(DSjkrb1.Vfmsjkrb2.Compute("sum(ysje)", ""));
                PriYfzj = Convert.ToDecimal(DSjkrb1.Vfmsjkrb2.Compute("sum(yf)", ""));
                PriBfzj = Convert.ToDecimal(DSjkrb1.Vfmsjkrb2.Compute("sum(bf)", ""));
            }
            else
            {
                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    row.Cells[DgvColTxtCheck.Name].Value = false;
                }
                Clear();
            }

        }
        #endregion

        #region Clear
        public void Clear()
        {
            Zj = Convert.ToDecimal(0.00);
            PriYfzj = Convert.ToDecimal(0.00);
            PriBfzj = Convert.ToDecimal(0.00);
            CheckCount = 0;
            LblZjje.Text = "�ϼ��˷ѣ�" + PriYfzj.ToString() + " �ϼƱ��۷ѣ�" + PriBfzj.ToString() + " �ܺϼƣ�" + Zj.ToString();

            //PriJsdCount = 0;
            //PriYdmxCount = 0;
            //RowCount = 0;
            //LblTs.Text = "��ѡ��" + RowCount.ToString() + "��!";
        }
        #endregion

        #region ѡ������
        private void CheckRowCount()
        {
            LblCheckCount.Text = "��ѡ��" + CheckCount + "��";
        }
        #endregion

        #region ����ѡ��
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblTs.Visible = false;
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    CheckCount--;
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    Zj -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvTxtZyf.Name].Value);
                    PriYfzj -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvTxtYf.Name].Value);
                    PriBfzj -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvTxtBf.Name].Value);

                }
                else
                {
                    CheckCount++;
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    Zj += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvTxtZyf.Name].Value);
                    PriYfzj += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvTxtYf.Name].Value);
                    PriBfzj += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvTxtBf.Name].Value);

                }
            }
            LblZjje.Text = "�ϼ��˷ѣ�" + PriYfzj.ToString() + " �ϼƱ��۷ѣ�" + PriBfzj.ToString() + " �ܺϼƣ�" + Zj.ToString();

            CheckRowCount();
        }
        #endregion

        #region ����ѡ��
        private void BtnKsxz_Click(object sender, EventArgs e)
        {
            LblTs.Visible = true;
            IsChecked = false;
            if (string.IsNullOrEmpty(TxtBh.Text))
            {
                LblTs.Text = "��¼��ҵ�񵥺ţ�";
                LblTs.ForeColor = Color.Red;
                return;
            }
            int RowIndex = Bds.Find("bh", TxtBh.Text);
            if (RowIndex < 0)
            {
                LblTs.Visible = true;
                LblTs.Text = "û�в�ѯ����Ӧ�˵���";
                LblTs.ForeColor = Color.Red;
                return;
            }
            if (Convert.ToBoolean(Dgv.Rows[RowIndex].Cells[DgvColTxtCheck.Name].Value))
            {
                LblTs.Visible = true;
                LblTs.Text = "���˵��ѱ�ѡ��";
                LblTs.ForeColor = Color.Red;
            }
            else
            {
                Dgv.Rows[RowIndex].Cells[DgvColTxtCheck.Name].Value = true;
                Zj += Convert.ToDecimal(Dgv.Rows[RowIndex].Cells[DgvTxtZyf.Name].Value);
                PriYfzj += Convert.ToDecimal(Dgv.Rows[RowIndex].Cells[DgvTxtYf.Name].Value);
                PriBfzj += Convert.ToDecimal(Dgv.Rows[RowIndex].Cells[DgvTxtBf.Name].Value);
                CheckCount++;
                CheckRowCount();
                LblZjje.Text = "�ϼ��˷ѣ�" + PriYfzj.ToString() + " �ϼƱ��۷ѣ�" + PriBfzj.ToString() + " �ܺϼƣ�" + Zj.ToString();
                LblTs.Visible = true;
                string bh = TxtBh.Text;
                TxtBh.Text = "";
                LblTs.Text = "ҵ�񵥣�" + bh + "��ѡ�У���ѡ��" + CheckCount.ToString() + "��!";
                LblTs.ForeColor = Color.Green;
                TxtBh.Focus();
            }
            Bds.Position = RowIndex;
            ClsD.TurnToBdsPosPage(Dgv);
        }
        #endregion


        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            int[] CellIndex = { 4, 5, 6 };
            ClsExcel.CreatExcel(Dgv, "Ӧ�����ϸ", this.ctrlDownLoad1, CellIndex);
        }

        private void TxtBh_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            this.BtnKsxz.PerformClick();
        }
        #region  ��ѡ
        private void BtnFX_Click(object sender, EventArgs e)
        {
            Clear();
            LblTs.Visible = false;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                {
                    row.Cells[DgvColTxtCheck.Name].Value = false;
                }
                else
                {
                    row.Cells[DgvColTxtCheck.Name].Value = true;
                    Zj += Convert.ToDecimal(row.Cells[DgvTxtZyf.Name].Value);
                    PriYfzj += Convert.ToDecimal(row.Cells[DgvTxtYf.Name].Value);
                    PriBfzj += Convert.ToDecimal(row.Cells[DgvTxtBf.Name].Value);
                    CheckCount++;
                }
            }
            LblZjje.Text = "�ϼ��˷ѣ�" + PriYfzj.ToString() + " �ϼƱ��۷ѣ�" + PriBfzj.ToString() + " �ܺϼƣ�" + Zj.ToString();
            CheckRowCount();
        }
        #endregion
    }
}
