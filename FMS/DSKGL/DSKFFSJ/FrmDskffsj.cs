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

#endregion

namespace FMS.DSKGL.DSKFFSJ
{
    public partial class FrmDskffsj : UserControl
    {
        private ClsG ObjG;
        public FrmDskffsj()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            TdskffsjTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            TdskffsjTableAdapter1.Fill(DSDSKFFSJ1.Tdskffsj);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            int sort = DSDSKFFSJ1.Tdskffsj.Rows.Count == 0 ? -1 : Convert.ToInt32(DSDSKFFSJ1.Tdskffsj.Compute("MAX(sort)", "1=1"));
            FrmDskffsjmx f = new FrmDskffsjmx();
            f.Prepare(EnumNEDD.New, this.Bds, (sort + 1).ToString());
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }

        private void BtnEndit_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            FrmDskffsjmx f = new FrmDskffsjmx();
            DSDSKFFSJ.TdskffsjRow row = ((DataRowView)Bds.Current).Row as DSDSKFFSJ.TdskffsjRow;
            f.Prepare(EnumNEDD.Edit, this.Bds, row.bh);
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            DSDSKFFSJ.TdskffsjRow row = ((DataRowView)Bds.Current).Row as DSDSKFFSJ.TdskffsjRow;
            row.Status = "��Ч";
            Bds.EndEdit();
            TdskffsjTableAdapter1.Update(DSDSKFFSJ1.Tdskffsj);
                  
        }

        private void BtnSort_Click(object sender, EventArgs e)
        {

            TdskffsjTableAdapter1.FillBySort(DSDSKFFSJ1.Tdskffsj);
            FrmSort f = new FrmSort();
            f.Prepare(DSDSKFFSJ1.Tdskffsj, 1);
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }

        void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            Bds.CancelEdit();
            TdskffsjTableAdapter1.Fill(DSDSKFFSJ1.Tdskffsj);
        }

        private void BtnSort1_Click(object sender, EventArgs e)
        {
            TdskffsjTableAdapter1.FillBySort1(DSDSKFFSJ1.Tdskffsj);
            FrmSort f = new FrmSort();
            f.Prepare(DSDSKFFSJ1.Tdskffsj, 2);
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }
    }
}