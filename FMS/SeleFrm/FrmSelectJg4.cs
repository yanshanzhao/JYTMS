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
    public partial class FrmSelectJg4 : Form
    {
        private string PriConStr; //���ݿ������ַ���
        //private ClsG ObjG;
        public StringDictionary PubDictAttrs;
        public int PubCountJgs = 0;
        public string PubStr = "";
        public FrmSelectJg4()
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
                string sql = string.Format("select id,mc,pym,level from tjigou where  pym like'%{0}%' or mc like '%{1}%'",  TxtJGMC.Text, TxtJGMC.Text);
                DataTable dt = ClsRWMSSQLDb.GetDataTable(sql, PriConStr);
                Dgv.DataSource = dt;
            }
            else
            {
                VjigouTableAdapter1.FillByWhere2(DSJG1.vjigou,"  ");
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
          

            //PubDictAttrs.Add("mc", Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtJGMC.Name].Value));
            //PubDictAttrs.Add("level", Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtLevel.Name].Value)); 
          
        }

        private void TxtJGMC_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        { 
            TxtJGMC.Text = TxtJGMC.Text.Trim();
            if (!string.IsNullOrEmpty(TxtJGMC.Text))
            {
                string sql = "select id,mc,pym,level from tjigou  where   (pym like '%" + TxtJGMC.Text + "%' or mc like '%" + TxtJGMC.Text + "%') ";
                DataTable dt = ClsRWMSSQLDb.GetDataTable(sql, PriConStr);
                Dgv.DataSource = dt;
            }
            else
            {
                VjigouTableAdapter1.FillByWhere2(DSJG1.vjigou, " ");
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

        private void BtnColse_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnXz_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex != 0)
                return;
            if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[DgvChkDx.Name].Value))
                return;
            string jgid = Convert.ToString(Dgv.Rows[e.RowIndex].Cells[DgvColTxtJGBH.Name].Value);
            //int n = PubStr.IndexOf(jgid + ",");
            if (PubStr.Contains(","+jgid+","))
                {
                Dgv.Rows[e.RowIndex].Cells[DgvChkDx.Name].Value = true;
                return;
                }
                
            PubStr = PubStr + jgid + ",";
            PubCountJgs++;
            Dgv.Rows[e.RowIndex].Cells[DgvChkDx.Name].Value = true;
        }
    }
}