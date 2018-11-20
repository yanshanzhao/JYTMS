#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pub;
using JY.Pri;

#endregion

namespace FMS.DSKGL.YFLSDZJ
{
    public partial class FrmYfLsdZjLr : UserControl
    {
        public FrmYfLsdZjLr()
        {
            InitializeComponent();
        }
        private DataTable PriJgDt = new DataTable();
        private DataTable PriDqDt = new DataTable();
        private int PriJgid;
        private int PriDqid;
        private int PriLevl;
        private int PriBjgid;
        private ClsG ObjG;
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PnlJgcx.Visible = false;
            PriJgid = ObjG.Jigou.id;
            TxtJgmc.Text = ObjG.Jigou.mc;
            PnlDqcx.Visible = false;
            //PriDqid = ObjG.Jigou.id;
            PriLevl = ObjG.Jigou.level;
            //TxtDqmc.Text = ObjG.Jigou.mc;
            PriBjgid = ObjG.Jigou.id;
            PnlMain.Controls.Add(PnlJgcx);
            PnlMain.Controls.Add(PnlDqcx);
            if (PriLevl >= 3)
            {
                lbldq.Visible = false;
                TxtDq.Visible = false;
                TxtDqmc.Visible = false;
                BtnQcDq.Visible = false;
            }
        }
        //������ѯ
        private void TxtJg_TextChanged(object sender, EventArgs e)
        {
            PnlJgcx.Visible = true;
            string CmdText = "select mc,pym,id from jyjckj.dbo.tjigou where parentLst like '%," + ObjG.Jigou.id + ",%' and (pym like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%' or  mc like '%" + (string.IsNullOrEmpty(TxtJg.Text.Trim()) ? "" : TxtJg.Text.Trim()) + "%')";
            PriJgDt = ClsRWMSSQLDb.GetDataTable(CmdText, ClsGlobals.CntStrTMS);
            LstV.DataSource = PriJgDt;
            LstV.Columns[0].Text = "��������";
            LstV.Columns[1].Text = "ƴ����";
            LstV.Columns[2].Text = "jgid";
            LstV.Columns[2].Visible = false;
            LstV.Columns[0].Width = 120;
            LstV.Focus();
        }
        //������ѯ
        private void TxtDq_TextChanged(object sender, EventArgs e)
        {
            PnlDqcx.Visible = true;
            string CmdText = " select mc,pym,id from jyjckj.dbo.tjigou where parentLst like '%,3,%' AND LEVEL=3 and (pym like '%" + (string.IsNullOrEmpty(TxtDq.Text.Trim()) ? "" : TxtDq.Text.Trim()) + "%' or  mc like '%" + (string.IsNullOrEmpty(TxtDq.Text.Trim()) ? "" : TxtDq.Text.Trim()) + "%') ";
            PriDqDt = ClsRWMSSQLDb.GetDataTable(CmdText, ClsGlobals.CntStrTMS);
            LstVDq.DataSource = PriDqDt;
            LstVDq.Columns[0].Text = "��������";
            LstVDq.Columns[1].Text = "ƴ����";
            LstVDq.Columns[2].Text = "dqid";
            LstVDq.Columns[2].Visible = false;
            LstVDq.Columns[0].Width = 120;
            LstVDq.Focus();
        }
        //�������
        private void BtnQcJg_Click(object sender, EventArgs e)
        {
            this.TxtJgmc.Clear();
            PriJgid = 0;
        }
        //�������
        private void BtnQcDq_Click(object sender, EventArgs e)
        {
            this.TxtDqmc.Clear();
            PriDqid = 0;
        }
        private void LstV_DoubleClick(object sender, EventArgs e)
        {
            this.TxtJgmc.Text = LstV.SelectedItems[0].SubItems[0].Text;
            PriJgid = Convert.ToInt32(LstV.SelectedItems[0].SubItems[2].Text);
            this.PnlJgcx.Visible = false;
            PriJgDt.Dispose();
        }
        private void LstVDq_DoubleClick(object sender, EventArgs e)
        {
            this.TxtDqmc.Text = LstVDq.SelectedItems[0].SubItems[0].Text;
            PriDqid = Convert.ToInt32(LstVDq.SelectedItems[0].SubItems[2].Text);
            this.PnlDqcx.Visible = false;
            PriDqDt.Dispose();
        }
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
        private void LstVDq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                if (TxtDq.Text.Trim().Length != 0)
                    TxtDq.Text = TxtDq.Text.Trim().Substring(0, TxtDq.Text.Trim().Length - 1);
                TxtDq.SelectionStart = TxtJg.Text.Length;
                TxtDq.Focus();
                PnlDqcx.Visible = false;
                PriDqDt.Dispose();
            }
            if (LstVDq.Items.Count > 0)
            {
                if (e.KeyChar == 13)
                {
                    this.TxtDqmc.Text = LstVDq.SelectedItems[0].SubItems[0].Text;
                    PriDqid = Convert.ToInt32(LstVDq.SelectedItems[0].SubItems[2].Text);
                    this.PnlDqcx.Visible = false;
                    PriDqDt.Dispose();
                }
            }
        }
        private void LstV_LostFocus(object sender, EventArgs e)
        {
            PnlJgcx.Visible = false;
            PriJgDt.Dispose();
        }
        private void LstVDq_LostFocus(object sender, EventArgs e)
        {
            PnlDqcx.Visible = false;
            PriDqDt.Dispose();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string where = "  ";
            where += DptInStart.Checked ? " and insj>'" + this.DptInStart.Value.Date + "'" : "";
            where += DptInStop.Checked ? " and insj<'" + this.DptInStop.Value.Date + "'" : "";
            where += DptUpStart.Checked ? " and upsj>'" + this.DptUpStart.Value.Date + "'" : "";
            where += DptUpStop.Checked ? " and upsj<'" + this.DptUpStop.Value.Date + "'" : "";
            if (PriLevl < 3)
            {
                where += !string.IsNullOrEmpty(TxtJgmc.Text.Trim()) ? " and parentLst like '%," + PriJgid + ",%' " : "";
                where += !string.IsNullOrEmpty(TxtDqmc.Text.Trim()) ? " and parentLst like '%," + PriDqid + ",%' " : "";
            }
            else
            {
                where += " and parentLst like '%," + PriBjgid + ",%' ";
                where += !string.IsNullOrEmpty(TxtJgmc.Text.Trim()) ? " and parentLst like '%," + PriJgid + ",%' " : "";
            }
            where = where.Trim();
            if (where.Length > 0)
                where = " where " + where.Remove(0, 3);
            DataTable dt = ClsRWMSSQLDb.GetDataTable(" select id,dqmc,jgmc,yjje,flje,yfkhj,insj,upsj from Vyflsdzj " + where + "", ClsGlobals.CntStrTMS);
            if (dt.Rows.Count != 0)
            {
                DataRow dr = dt.NewRow();
                dr["dqmc"] = "�ϼƣ�";
                dr["yjje"] = dt.Compute("sum(yjje)", "");
                dr["flje"] = dt.Compute("sum(flje)", "");
                dr["yfkhj"] = dt.Compute("sum(yfkhj)", "");
                dt.Rows.Add(dr);
                Dgv.DataSource = dt;
            }
            else
            {
                dt.Rows.Clear();
                Dgv.DataSource = dt;
                ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ��", ObjG.CustomMsgBox, this);
            }
        }
        private void BtnIn_Click(object sender, EventArgs e)
        {
            int id = 0;
            FrmInsert f = new FrmInsert();
            f.Prepare(-1, id);
            f.ShowDialog();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
        }

        private void BtnYfkwh_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (Dgv.RowCount > 0 && Dgv.SelectedRows[0] != null && Dgv.SelectedRows[0].Index + 1 < Dgv.RowCount)
            {
                id = Convert.ToInt32(Dgv.SelectedRows[0].Cells[7].Value);
                FrmInsert f = new FrmInsert();
                f.Prepare(1, id);
                f.ShowDialog();
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            }
            else
            {
                ClsMsgBox.Ts("��ѡ������");
            }
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmInsert f = sender as FrmInsert;
            if (f.DialogResult == DialogResult.OK)
            {
                ClsMsgBox.Ts("����ɹ�");
                BtnSave.PerformClick();
            }
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 2, 3, 4 };
            ClsExcel.CreatExcel(this.Dgv, " Ӧ���������ʽ���־ ", this.ctrlDownLoad1, Rows);

        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            int id = 0;
            int count = 0;
            if (Dgv.RowCount > 0 && Dgv.SelectedRows[0] != null && Dgv.SelectedRows[0].Index + 1 < Dgv.RowCount)
            {
                id = Convert.ToInt32(Dgv.SelectedRows[0].Cells[7].Value);
                string Sql = " delete tyflsdzj where id=" + id + " ";
                count = ClsRWMSSQLDb.ExecuteCmd(Sql, ClsGlobals.CntStrTMS);
                if (count > 0)
                    BtnSave.PerformClick();
                else
                    ClsMsgBox.Ts("ɾ��ʧ��");
            }
            else
                ClsMsgBox.Ts("��ѡ��Ҫɾ��������");
        }
    }
}