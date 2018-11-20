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

namespace FMS.CXTJ.SRQKCX
{
    public partial class FrmSRCXYDXX : Form
    {
        private string PriWhere = "";
        private ClsG ObjG;
        private string Prijgid;
        private DateTime PriJssj;
        public FrmSRCXYDXX()
        {
            InitializeComponent();
        }
        public void Prepare(DateTime akssj, DateTime ajssj, string ajgid, string aywqy, string ajgmc)
        {

            ObjG = Session["ObjG"] as ClsG; 
            TxtYwqy.Text = aywqy;
            TxtStart.Text = akssj.ToString("yyyy-MM-dd"); ;
            TxtStop.Text = ajssj.AddDays(-1).ToString("yyyy-MM-dd");
            PriJssj = ajssj;
            this.TxtJgmc.Text = ajgmc;
            this.CmbYwzl.SelectedIndex = 0;
            Prijgid = ajgid;
            //this.VfmssrcxydxxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            //PriWhere = " where jgid= " + ajgid + "  and   inssj >='" + akssj + "' and inssj<'" + ajssj + "'";
            //if (aywqy != "0")
            //    PriWhere = PriWhere + " and  ywqy='" + aywqy + "'";
            //this.VfmssrcxydxxTableAdapter1.FillByWhere(this.DSSRQKCX1.Vfmssrcxydxx, PriWhere);
            BtnSave.PerformClick();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            LblZhj.Text = "�ܺϼƣ�0.00Ԫ";
            LblByhj.Text = "��ҳ�ϼƣ�0.00Ԫ";
            PriWhere = " where jgid= " + Prijgid + "  and   inssj >='" + TxtStart.Text + "' and inssj<'" + PriJssj.ToString() + "'";

            if (CmbYwzl.SelectedIndex > 0)
            {
                PriWhere += "  and fkfs='" + CmbYwzl.Text + "'";
            }
            //if (aywzl.Length > 0)
            //    this.VfmssrcxydxxTableAdapter1.FillByWhere(this.DSSRQKCX1.Vfmssrcxydxx, PriWhere + "  and fkfs='" + aywzl + "'");
            //else
            this.VfmssrcxydxxTableAdapter1.FillByWhere(this.DSSRQKCX1.Vfmssrcxydxx, PriWhere);
            if (Dgv.Rows.Count == 0)
                ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ����˶Բ�ѯ������", ObjG.CustomMsgBox, this);
            if (Dgv.Rows.Count > 0)
            {
                LblZhj.Text = "�ܺϼƣ�" + DSSRQKCX1.Tables[1].AsEnumerable().Sum(r => Convert.ToDecimal(r["je"])) + "Ԫ";
                Heji();
            }
        }
        private void Dgv_PaddingChanged(object sender, EventArgs e)
        {
            Heji();
        }

        private void Dgv_Sorted(object sender, EventArgs e)
        {
            Heji();
        }
        public void Heji()
        {
            decimal PageCount = 0;
            //һ���ж�����
            int rowcount = Convert.ToInt32(Dgv.RowCount);
            //��ǰ�ǵڼ�ҳ
            int currentpage = Convert.ToInt32(Dgv.CurrentPage);
            //һҳ�ж�����
            int pageSize = Convert.ToInt32(Dgv.ItemsPerPage);
            //���������С�ڻ����ÿҳ��ʾ����
            if (rowcount <= pageSize)
                PageCount = DSSRQKCX1.Tables[1].AsEnumerable().Sum(r => Convert.ToDecimal(r["je"]));
            else
            {
                //�����ǲ�������ÿҳ������
                //if (rowcount % pageSize == 0)
                //    {
                //    for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                //        {
                //        decimal n;
                //        if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                //            {
                //            PageCount += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value.ToString());
                //            }
                //        }
                //    }
                //else
                //    {
                for (int i = Dgv.FirstDisplayedScrollingRowIndex; i < Dgv.FirstDisplayedScrollingRowIndex + Dgv.ItemsPerPage; i++)
                {
                    if (i >= Dgv.Rows.Count)
                        break;
                    decimal n;
                    if (decimal.TryParse(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value.ToString(), out n))
                    {
                        PageCount += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtje.Name].Value.ToString());
                    }
                }

                //}

            }
            LblByhj.Text = "��ҳ�ϼƣ�" + PageCount + "Ԫ";
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == 5)//��˶���
            {
                string abh = Dgv.Rows[e.RowIndex].Cells[DgvColTxtbh.Name].Value.ToString();
                TMS.ysgl.ydcx.FrmYDSJLR f = new TMS.ysgl.ydcx.FrmYDSJLR();
                f.ShowDialog();
                f.Prepare(abh);
            }
        }
    }
}