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
using FMS.CWGL.GLSDWNWYYSR;
using NPOI.HSSF.UserModel;
using System.Configuration;
using System.IO;
using NPOI.SS.Util;
using FMS.SelectFrm;

#endregion

namespace FMS.CWGL.GLSDWNWYYSR
{
    public partial class FrmGLSDWNWYYSR : UserControl
    {
        public FrmGLSDWNWYYSR()
        {
            InitializeComponent();
        }

        #region ��Ա����
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private int PriJgid = 0;
        private int PriCplxIndx = 0;
        private int PriYwxzIndx = 0;
        private int PriJyxzIndx = 0;
        private DateTime PriStartSj = DateTime.Now;
        private DateTime PriStopSj = DateTime.Now;
        #endregion

        #region ����ҳ�� Prepare()
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbCplx, ClsGlobals.CntStrKj);
            this.CmbCplx.SelectedIndex = 0;
            CmbYwxz.SelectedIndex = 0;
            CmbJyxz.SelectedIndex = 0;
            PnlMain.Controls.Add(PnlJgcx);
            PnlJgcx.Visible = false;
            PriJgid = ObjG.Jigou.id;
            TxtJgmc.Text = ObjG.Jigou.mc;
            ClsPopulateCmbDsS.PopuYd_ywxz(CmbYwxz, ClsGlobals.CntStrKj);
            DtpQrStart.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            DataTable dtDqxx = ClsRWMSSQLDb.GetDataTable(" SELECT 0 AS dqid,'--ȫ��--' dqmc,'' sybid  UNION SELECT dqid,dqmc,sybid  FROM jyjckj.dbo.Vdqjigou   WHERE  dqid<>jgid GROUP BY dqid,dqmc,sybid ORDER BY sybid,dqid ", ClsGlobals.CntStrKj);
        }
        #endregion

        #region ���������Ϣ BtnClear1_Click(object sender, EventArgs e)
        private void BtnClear1_Click(object sender, EventArgs e)
        {
            this.TxtJgmc.Clear();
            PriJgid = 0;
        }
        #endregion

        #region �����Ļس��¼�TxtJg_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        private void TxtJg_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            PnlJgcx.Visible = true;
            string CmdText = "select mc,pym,id from jyjckj.dbo.tjigou where  (pym like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%' or  mc like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%')";
            PriJgDt = ClsRWMSSQLDb.GetDataTable(CmdText, ClsGlobals.CntStrTMS);
            LstV.DataSource = PriJgDt;
            LstV.Columns[0].Text = "��������";
            LstV.Columns[1].Text = "ƴ����";
            LstV.Columns[2].Text = "jgid";
            LstV.Columns[2].Visible = false;
            LstV.Columns[0].Width = 120;
            LstV.Focus();
        }
        #endregion

        #region �������ƻ�ý��� LstV_KeyPress(object sender, KeyPressEventArgs e)
        private void LstV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                if (TxtJg.Text.Trim().Length != 0)
                    TxtJg.Text = TxtJg.Text.Trim().Substring(0, TxtJg.Text.Trim().Length - 1);
                TxtJg.SelectionStart = TxtJg.Text.Length;
                TxtJg.Focus();
                PnlJgcx.Visible = false;
                PriJgDt.Dispose();
            }
            if (LstV.Items.Count > 0)
            {
                if (e.KeyChar == 13)
                {
                    this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
                    PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
                    this.PnlJgcx.Visible = false;
                    PriJgDt.Dispose();

                }
            }
        }
        #endregion

        #region ��������ʧȥ���� LstV_LostFocus(object sender, EventArgs e)
        private void LstV_LostFocus(object sender, EventArgs e)
        {
            PnlJgcx.Visible = false;
            PriJgDt.Dispose();
        }
        #endregion

        #region �����������˫���¼� LstV_DoubleClick(object sender, EventArgs e)
        private void LstV_DoubleClick(object sender, EventArgs e)
        {
            this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
            PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
            this.PnlJgcx.Visible = false;
            PriJgDt.Dispose();
        }
        #endregion

        #region Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex < 0 || e.ColumnIndex != 12)
                return;
            if (e.RowIndex != Dgv.Rows.Count - 1)//����
            {
                FrmGLSDWNWYYSRXX f = new FrmGLSDWNWYYSRXX();
                f.ShowDialog();
                string adqid = Dgv.Rows[e.RowIndex].Cells[dataGridViewTextBoxColumn5.Name].Value.ToString();
                string adqmc = Dgv.Rows[e.RowIndex].Cells[dataGridViewTextBoxColumn43.Name].Value.ToString();
                string cpmc = Dgv.Rows[e.RowIndex].Cells[dataGridViewTextBoxColumn44.Name].Value.ToString();
                f.Prepare(adqid,adqmc, cpmc, PriStartSj, PriStopSj, PriCplxIndx, PriYwxzIndx, PriJyxzIndx);
            }
        }
        #endregion

        #region ��ѯ��ť BtnSave_Click(object sender, EventArgs e)
        private void BtnSave_Click(object sender, EventArgs e)
        {
            LblHj.Text = "�ϼƣ�0.00Ԫ";
            if (PriJgid == 0)
            {
                ClsMsgBox.Ts("��ѡ���ѯ�Ļ�����", ObjG.CustomMsgBox, this);
                return;
            }
            string aWhere = " where EXISTS (SELECT id FROM jyjckj.dbo.tjigou WHERE parentlst like '%," + PriJgid + ",%' AND id=sljgid) and  inssj >= '" + DtpQrStart.Value.Date + "' and inssj< DateAdd(dd,+1, '" + DtpQrStop.Value.Date + "')";
            if (CmbCplx.SelectedIndex != 0)
                aWhere = aWhere + " and cplxmc='" + CmbCplx.Text + "'";
            if (CmbYwxz.SelectedIndex != 0)
                aWhere = aWhere + " and ywxz = '" + CmbYwxz.Text + "'";
            if (CmbJyxz.SelectedIndex == 1)
            {
                aWhere += " and jyxz='Z' ";
            }
            else if (CmbJyxz.SelectedIndex == 2)
            {
                aWhere += " and jyxz='J' ";
            }
            else if (CmbJyxz.SelectedIndex == 3)
            {
                aWhere += " and jyxz ='H' ";
            }
            //aWhere += "  and jezj<> 0.00  ";
            PriCplxIndx = CmbCplx.SelectedIndex;
            PriYwxzIndx = CmbYwxz.SelectedIndex;
            PriJyxzIndx = CmbJyxz.SelectedIndex;
            PriStartSj = DtpQrStart.Value.Date;
            PriStopSj = DtpQrStop.Value.Date;
            DataTable dt = ClsRWMSSQLDb.GetDataTable("    select '��ϸ' cz,SUM(jezj)jezj, cplxmc,dqmc,sum(wndhxj) as wndhxj,sum(wwdhxj) as wwdhxj,(sum(wndhxj)+sum(wwdhxj)) as dhxj,sum(dhjfzlxj)   as dhjfzlxj,sum(wnfhxj) as wnfhxj,  sum(wnfhjfzlxj) as wnfhjfzlxj,sum(wwfhxj) as wwfhxj ,sum(wwfhjfzlxj) as wwfhjfzlxj ,(sum(wnfhxj)+sum(wwfhxj)) as fhxj   ,sum(fhjfzlxj) as fhjfzlxj ,dqid   FROM dbo.tglsdwnwyysrcx a   " + aWhere + "group by dqid, cplxmc,dqmc,cz ", ClsGlobals.CntStrTMS);
            DataRow dr = dt.NewRow();
            dr["dqmc"] = "�ϼƣ�";
            dr["wndhxj"] = dt.Compute("sum(wndhxj)", "");
            dr["wwdhxj"] = dt.Compute("sum(wwdhxj)", "");
            dr["dhxj"] = dt.Compute("sum(dhxj)", "");
            dr["dhjfzlxj"] = dt.Compute("sum(dhjfzlxj)", "");
            dr["wnfhxj"] = dt.Compute("sum(wnfhxj)", "");
            dr["wnfhjfzlxj"] = dt.Compute("sum(wnfhjfzlxj)", "");
            dr["wwfhxj"] = dt.Compute("sum(wwfhxj)", "");
            dr["wwfhjfzlxj"] = dt.Compute("sum(wwfhjfzlxj)", "");
            dr["fhxj"] = dt.Compute("sum(fhxj)", "");
            dr["fhjfzlxj"] = dt.Compute("sum(fhjfzlxj)", "");
            dt.Rows.Add(dr);
            Dgv.DataSource = dt;
            if (dt.Rows.Count != 1)
                LblHj.Text = "�������˷�С�ƣ�" + dr["fhxj"].ToString() + "Ԫ";
            else
                ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ��", ObjG.CustomMsgBox, this);


        }
        #endregion

        #region �����¼� BtnExl_Click(object sender, EventArgs e)
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (this.Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ����������");
            }
            else
            {
                ClsExcel.CreatExcel(this.Dgv, "��������������Ӫҵ���� ", this.ctrlDownLoad1, new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
            }
        }
        #endregion 

    }
}
