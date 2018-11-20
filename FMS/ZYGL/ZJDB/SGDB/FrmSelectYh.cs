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
using JY.Pri;
using System.Collections.Specialized;
using JY.Pub;

#endregion

namespace FMS.ZYGL.ZJDB.SGDB
{
    public partial class FrmSelectYh : Form
    {
        private ClsG ObjG;
        public StringDictionary PubDictAttrs;
        public FrmSelectYh()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            BtnQuery.PerformClick();
            TxtZhmc.Focus();
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            string where = string.IsNullOrEmpty(TxtZhmc.Text.Trim()) ? "" : " where zhmc like '%" + TxtZhmc.Text.Trim() + "%'";
            DataTable dt = ClsRWMSSQLDb.GetDataTable("SELECT id,zh,zhmc,zhlxmc,yhlxmc FROM Vjtyhzh " + where, ClsGlobals.CntStrTMS);
            Dgv.DataSource = dt;
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            PubDictAttrs = new StringDictionary();
            PubDictAttrs.Add("id", Dgv.Rows[e.RowIndex].Cells[DgvColTxtId.Name].Value.ToString());
            PubDictAttrs.Add("zh", Dgv.Rows[e.RowIndex].Cells[DgvColTxtZh.Name].Value.ToString());
            PubDictAttrs.Add("zhmc", Dgv.Rows[e.RowIndex].Cells[DgvColTxtZhmc.Name].Value.ToString());
            PubDictAttrs.Add("yhlxmc", Dgv.Rows[e.RowIndex].Cells[DgvColTxtYhlx.Name].Value.ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            PubDictAttrs = new StringDictionary();
            PubDictAttrs.Add("id", "0");
            PubDictAttrs.Add("zh", "");
            PubDictAttrs.Add("zhmc", "");
            PubDictAttrs.Add("yhlxmc", "");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}