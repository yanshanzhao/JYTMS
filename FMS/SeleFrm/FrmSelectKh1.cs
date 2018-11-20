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
    public partial class FrmSelectKh1 : Form
    {
        public string PubKhmc;
        private ClsG ObjgG;
        public int PubKkid;
        public FrmSelectKh1()
        {
            InitializeComponent();
        }
        public void Prepare() 
        {
            TxtKhmc.Focus();
            TkhTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            ObjgG=VWGContext.Current.Session["ObjG"] as ClsG;
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            PubKhmc = "";
            PubKkid = 0;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            TxtKhmc.Text = TxtKhmc.Text.Trim();
            TxtKhbh.Text = TxtKhbh.Text.Trim();
            if (string.IsNullOrEmpty(TxtKhmc.Text) && string.IsNullOrEmpty(TxtKhbh.Text))
            {
                string sql = string.Format("select bh,mc,address,lxr,tel,id from tkh where  lx='A' and jgid={0}", ObjgG.Jigou.id);
                DataTable dt = ClsRWMSSQLDb.GetDataTable(sql, ClsGlobals.CntStrTMS);
                Dgv.DataSource = dt;
                //////////TkhTableAdapter1.FillByWhere(DSkh1.Tkh, " where 1=1 and jgid=" + ObjgG .Jigou.id);
                //////////Dgv.DataSource = Bds;
            }
            else
            {
                string sql = string.Format("select bh,mc,address,lxr,tel,id from tkh where  lx='A' and  jgid={0} and bh like '%{1}%' and mc like '%{2}%'", ObjgG.Jigou.id, TxtKhbh.Text, TxtKhmc.Text);
                DataTable dt = ClsRWMSSQLDb.GetDataTable(sql,ClsGlobals.CntStrTMS);
                Dgv.DataSource = dt;
            }
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PubKhmc = Dgv.CurrentRow.Cells[DgvColTxtKhmc.Name].Value.ToString();
            int n;
            if (Int32.TryParse(Dgv.CurrentRow.Cells[DgvColTxtkhid.Name].Value.ToString(), out n))
                PubKkid = Convert.ToInt32(Dgv.CurrentRow.Cells[DgvColTxtkhid.Name].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}