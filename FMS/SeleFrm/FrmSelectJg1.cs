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

#endregion

namespace FMS.SeleFrm
{
    public partial class FrmSelectJg1 : Form
    {
        private string PriConStr; //数据库连接字符串
        private ClsG ObjG;
        public StringDictionary PubDictAttrs;
        private string PriJgid;
        public FrmSelectJg1()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            PubDictAttrs = new StringDictionary();
            PriConStr = ClsGlobals.CntStrKj;
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            VjigouTableAdapter1.Connection.ConnectionString = PriConStr;
            this.ActiveControl = TxtJGMC;
            PriJgid = ObjG.Jigou.id.ToString();
        } 
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            TxtJGMC.Text = TxtJGMC.Text.Trim();
            if (!string.IsNullOrEmpty(TxtJGMC.Text))
            {
                string sql =string.Format( "select id,mc,pym from tjigou where (pym like '%{0}%' or mc like '%{1}%') and id in (select id from tjigou where parentLst like '%,{2},%')",TxtJGMC.Text.Trim(),TxtJGMC.Text.Trim(),PriJgid);
                DataTable dt = ClsRWMSSQLDb.GetDataTable(sql, PriConStr);
                Dgv.DataSource = dt;
            }
            else
            {
                //VjigouTableAdapter1=new vjigouTableAdapter {Connection = {ConnectionString = ClsGlobals.CntStrKj}};
                VjigouTableAdapter1.FillByJgid(DSJG1.vjigou,PriJgid);
                Dgv.DataSource = this.Bds;
            }
            Dgv.Focus();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            PubDictAttrs.Clear();
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            PubDictAttrs.Add("id", Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtJGBH.Name].Value));
            PubDictAttrs.Add("mc", Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtJGMC.Name].Value));
            //PubDictAttrs.Add("areaid", Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtAreaid.Name].Value));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TxtJGMC_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        { 
            TxtJGMC.Text = TxtJGMC.Text.Trim();
            if (!string.IsNullOrEmpty(TxtJGMC.Text))
            {
            string sql = "select id,mc,pym from tjigou where (pym like '%" + TxtJGMC.Text + "%' or mc like '%" + TxtJGMC.Text + "%') and id in (select id from tjigou where parentLst like '%," + PriJgid + ",%')";
                DataTable dt = ClsRWMSSQLDb.GetDataTable(sql, PriConStr);
                Dgv.DataSource = dt;
            }
            else
            {
                //VjigouTableAdapter1=new vjigouTableAdapter {Connection = {ConnectionString = ClsGlobals.CntStrKj}};
            VjigouTableAdapter1.FillByJgid(DSJG1.vjigou, PriJgid);
                Dgv.DataSource = this.Bds;
            }
            Dgv.Focus();
        }  
        private void Dgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                this.TxtJGMC.Text = "";
                TxtJGMC.Focus();
            }
        }
    }
}