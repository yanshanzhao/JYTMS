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

#endregion

namespace FMS.SeleFrm
{
    public partial class FrmSelectKh : Form
    {
        public string PubKhmc;
        public FrmSelectKh()
        {
            InitializeComponent();
        }
        public void Prepare() 
        {
            TxtKhmc.Focus();
            TkhTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.DSkh1.EnforceConstraints = false;
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            PubKhmc = "";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            TxtKhmc.Text = TxtKhmc.Text.Trim();
            TxtKhbh.Text = TxtKhbh.Text.Trim();
            if (string.IsNullOrEmpty(TxtKhmc.Text) && string.IsNullOrEmpty(TxtKhbh.Text))
            {
                TkhTableAdapter1.Fill(DSkh1.Tkh);
                Dgv.DataSource = Bds;
            }
            else
            {
                string sql = string.Format("select bh,mc,address,lxr,tel from tkh where bh like '%{0}%' and mc like '%{1}%'", TxtKhbh.Text, TxtKhmc.Text);
                DataTable dt = ClsRWMSSQLDb.GetDataTable(sql,ClsGlobals.CntStrTMS);
                Dgv.DataSource = dt;
            }
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PubKhmc = Dgv.CurrentRow.Cells[DgvColTxtKhmc.Name].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}