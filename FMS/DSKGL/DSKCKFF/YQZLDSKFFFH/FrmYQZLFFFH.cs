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
using FMS.DSKGL.DSKDK;
using JY.Pub;
#endregion

namespace FMS.DSKGL.DSKCKFF.YQZLDSKFFFH
{
    public partial class FrmYQZLFFFH : UserControl
    {
        private ClsG ObjG;
        private DSYQZLFFFH.VfmsYQZLDSKFFRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as DSYQZLFFFH.VfmsYQZLDSKFFRow;
                }
            }
        }
        public FrmYQZLFFFH()
        {
            InitializeComponent();
        }

        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            //BtnSearch.PerformClick();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string where = " where zt IN (0,25,40)  ";
            if (DtpFfStart.Checked)
                where += " and ffsj >='" + DtpFfStart.Value.Date + "'";
            if (DtpFfStop.Checked)
                where += " and ffsj < '" + DtpFfStop.Value.AddDays(1).Date + "'";
            VfmsYQZLDSKFFTableAdapter1.FillByWhere1(DSYQZLFFFH1.VfmsYQZLDSKFF, where);
            if (Dgv.RowCount == 0)
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
            else
                GetBh();

        }
        private void GetBh()
        {
            for (int i = 0; i < Dgv.Rows.Count; i++)
            {
                Dgv.Rows[i].Cells[0].Value = Dgv.Rows[i].Index + 1;
            }
        }

        private void BtnFh_Click(object sender, EventArgs e)
        {
            if (PriRow == null)
                return;
            if (PriRow.fhzt == 10)
            {
                ClsMsgBox.Ts("该条信息已经复核，不能重复复核！");
                return;
            }
            FrmPwd f = new FrmPwd();
            f.Prepare();
            f.ShowDialog();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPwd f = sender as FrmPwd;
            if (f.DialogResult == DialogResult.Yes)
            {
                FrmYQZLFHMX frm = new FrmYQZLFHMX();
                frm.ShowDialog();
                frm.Prepare(PriRow,this.Bds);
            }
        }
    }
}