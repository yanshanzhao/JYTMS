#region Using

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pri;
using JY.Pub;
using JYPubFiles.Classes;
using System.Web.Caching;
using System.Web;
#endregion

namespace FMS.SelectFrm
{
    public partial class FrmSelectDq : Form
    {
        public StringDictionary PubDictAttrs;
        private DataTable PriDtJG = new DataTable();

        public FrmSelectDq()
        {
            InitializeComponent();
        }
        public void Preapre()
        {

            this.TxtMc.Focus();
        }
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string SQL = "";
           
            Dgv.DataSource = null;
          
            TxtMc.Text = TxtMc.Text.Trim();
            if (string.IsNullOrEmpty(TxtMc.Text.Trim()))
                SQL = " SELECT dqid,dqmc FROM vdqxx ";
            else
                SQL =string.Format( " SELECT dqid,dqmc FROM vdqxx where dqmc like '%{0}%' ",TxtMc.Text);
            dt = ClsRWMSSQLDb.GetDataTable(SQL, ClsGlobals.CntStrKj);
            //Dgv.DataSource = dr.CopyToDataTable();
            Dgv.DataSource = dt;
        }
        private void GenDictAttrs(DataGridViewRow dgvr)
        {
            PubDictAttrs = new StringDictionary();
            PubDictAttrs.Add("dqid", Convert.ToString(dgvr.Cells[DgvColTxtdqid.Name].Value));
            PubDictAttrs.Add("dqmc", Convert.ToString(dgvr.Cells[DgvColTxtdqmc.Name].Value));

        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            GenDictAttrs(Dgv.Rows[e.RowIndex]); //hcd:
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.TxtMc.Text = "";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtMc_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            BtnQuery.PerformClick();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            PubDictAttrs = new StringDictionary();
            PubDictAttrs.Add("dqid", "0");
            PubDictAttrs.Add("dqmc", ""); 
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TxtMc_EnterKeyDown_1(object objSender, KeyEventArgs objArgs)
        {
            BtnQuery.PerformClick();
        }


    }
}
