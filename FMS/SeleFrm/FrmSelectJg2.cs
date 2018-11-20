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
    public partial class FrmSelectJg2 : Form
    {
        private string PriConStr; //数据库连接字符串
        //private ClsG ObjG;
        public StringDictionary PubDictAttrs; 
        public FrmSelectJg2()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            PubDictAttrs = new StringDictionary();
            PriConStr = ClsGlobals.CntStrKj; 
            VjigouTableAdapter1.Connection.ConnectionString = PriConStr;
            this.ActiveControl = TxtJGMC; 
        } 
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            TxtJGMC.Text = TxtJGMC.Text.Trim();
            if (!string.IsNullOrEmpty(TxtJGMC.Text))
            {
                string sql = string.Format("select id,mc,pym,level from tjigou where id>2 and pym like'%{0}%' or mc like '%{1}%'", TxtJGMC.Text.Trim(), TxtJGMC.Text.Trim());
                DataTable dt = ClsRWMSSQLDb.GetDataTable(sql, PriConStr);
                Dgv.DataSource = dt;
            }
            else
            {
                VjigouTableAdapter1.FillByWhere2(DSJG1.vjigou, " where id>2 and level<>2 ");
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
            PubDictAttrs.Add("level", Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtLevel.Name].Value)); 
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TxtJGMC_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        { 
            TxtJGMC.Text = TxtJGMC.Text.Trim();
            if (!string.IsNullOrEmpty(TxtJGMC.Text))
            {
                string sql = string.Format("select id,mc,pym,level from tjigou  where id>2 and level<>2 and (pym like '%{0}%' or mc like '%{1}%')", TxtJGMC.Text.Trim(), TxtJGMC.Text.Trim());
                DataTable dt = ClsRWMSSQLDb.GetDataTable(sql, PriConStr);
                Dgv.DataSource = dt;
            }
            else
            {
                VjigouTableAdapter1.FillByWhere2(DSJG1.vjigou, " where id>2 and level<>2 ");
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
