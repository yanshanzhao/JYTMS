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
using FMS.SeleFrm;
using FMS.SelectFrm;

#endregion

namespace FMS.DSKGL.DSKSFTHZ
{
    public partial class FrmDSKSftHz : UserControl
    {
        private ClsG ObjG;
        private string Prixx = "";
        private string Prihz = "";
        public FrmDSKSftHz()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            this.DSDskhz1.EnforceConstraints = false;
            this.VfmssftcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }

        private void BtnSeleDQ_Click(object sender, EventArgs e)
        {
            FrmSelectDq f = new FrmSelectDq();
            f.Preapre();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectDq frm = sender as FrmSelectDq;
            if (frm.DialogResult == DialogResult.OK)
            {
                TxtDq.Text = frm.PubDictAttrs["dqmc"];
                TxtDq.Tag = frm.PubDictAttrs["dqid"];
            }
            else if (frm.DialogResult == DialogResult.No)
            {
                TxtDq.Text = "";
                TxtDq.Tag = 0;
            }
        }

        private void BtnSeleJG_Click(object sender, EventArgs e)
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
            {
                this.TxtJg.Text = f.PubDictAttrs["mc"];
                this.TxtJg.Tag = f.PubDictAttrs["id"].ToString();
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtJg.Text = "";
                this.TxtJg.Tag = 0;
            }
        }

        private void BtnSel_Click(object sender, EventArgs e)
        {
            Prixx = "";
            Prihz = "";
            string awhere = " where zfsj>='" + DptStart.Value.Date + "' and zfsj<'" + DptEnd.Value.Date.AddDays(1) + "'  ";
            Prixx = awhere;

            if (TxtJg.Tag != "0")
            {
                awhere += "  and jgid= " + TxtJg.Tag.ToString();
            }
            if (TxtDq.Tag != "0")
            {
                awhere += "  and dqid= " + TxtDq.Tag.ToString();
            }

            string SQl = " SELECT dqmc,jgmc,sum(gs) AS gs,sum(dsk) AS dsk,xx,jgid FROM Vfmssftcx  " + awhere + "   GROUP BY  dqmc,jgmc,xx,jgid  ";

            this.VfmssftcxTableAdapter1.FillByWhere(DSDskhz1.Vfmssftcx, awhere);
            this.Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(SQl, ClsGlobals.CntStrTMS);
            Prihz = awhere;
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            int[] RowIndex = { 3 };
            ClsExcel.CreatExcel(Dgv, "ÉÆ¸¶Í¨Ö§¸¶»ã×Ü", this.ctrlDownLoad1, RowIndex);
        }

        private void BtnMxExcel_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return; 
            FrmDSksftmx f = new FrmDSksftmx();
            f.ShowDialog();
            f.Prepare(Prihz);
            f.BtnExcel_Click(sender, e);
        }


        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                string jgid = Dgv.Rows[e.RowIndex].Cells["DgvTxtjgid"].Value.ToString();
                string awhere = Prihz + "   and   jgid= " + jgid;
                FrmDSksftmx f = new FrmDSksftmx();
                f.ShowDialog();
                f.Prepare(awhere);

            }
        }
    }
}