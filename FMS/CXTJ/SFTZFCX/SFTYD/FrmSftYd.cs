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

#endregion

namespace FMS.CXTJ.SFTZFCX.SFTYD
{
    public partial class FrmSftYd : UserControl
    {
        private string Prijgid = "0";
        public FrmSftYd()
        {
            InitializeComponent();
        }

        public void Prepare()
        {
            this.Cmbshzt.SelectedIndex = 0;
            this.vfmssftydcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.DSsftyd1.EnforceConstraints = false;
        }

        private void BtnSele_Click(object sender, EventArgs e)
        {
            string WhereSQL = "";
            if (Txtydbh.Text.Trim().Length > 0)
            {
                WhereSQL = string.Format(" where ydbh='{0}' ", Txtydbh.Text.Trim());
            }
            else
            {
                WhereSQL = getwhere();
            }
            if (WhereSQL.Trim().Length == 0)
            {
                ClsMsgBox.Ts("请选择查询条件！");
                return;
            }

        }
        private string getwhere()
        {
            string where = "";
            List<string> listStr = new List<string>();
            if (Txtqsjg.Text.Trim().Length > 0)
            {
                string jgstr = string.Format(" jgid={0}  ", Prijgid);
                listStr.Add(jgstr);
            }
            if (Cmbshzt.SelectedIndex > 0)
            {
                string ztstr = string.Format(" shzt='{0}'  ", Cmbshzt.Text);
                listStr.Add(ztstr);
            }

            if (DtimQsBegin.Checked)
            {
                string qssjstr = string.Format(" qssj>='{0}'  ", DtimQsBegin.Value.Date);
                listStr.Add(qssjstr);
            }

            if (DtimQsEnd.Checked)
            {
                string qssjstr = string.Format(" qssj<'{0}'  ", DtimQsEnd.Value.AddDays(1).Date);
                listStr.Add(qssjstr);
            }
            if (DtimZdBegin.Checked)
            {
                string zdsjstr = string.Format(" zdsj>='{0}'  ", DtimZdBegin.Value.Date);
                listStr.Add(zdsjstr);
            }
            if (DtimZdEnd.Checked)
            {
                string zdsjstr = string.Format(" zdsj<'{0}'  ", DtimZdEnd.Value.AddDays(1).Date);
                listStr.Add(zdsjstr);
            }
            if (listStr.Count > 0)
            {
                for (int i = 0; i < listStr.Count; i++)
                {
                    if (i == 0)
                        where = "  " + listStr[0].ToString();
                    else
                        where = " and  " + listStr[0].ToString();
                }

            }
            else
            {
                where = "";
            }
            return where;
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "善付通运单查询", this.ctrlDownLoad1);
        }

        private void Btnqsjg_Click(object sender, EventArgs e)
        {
            FrmSelectJg PriFrmSelectJg = new FrmSelectJg();
            PriFrmSelectJg.Prepare();
            PriFrmSelectJg.ShowDialog();
            PriFrmSelectJg.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmJGCX1_FormClosed);
        }
        private void FrmJGCX1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
            {
                Prijgid = f.PubDictAttrs["id"].ToString();
            }
            else
            {
                Prijgid = "0";
            }
            this.Txtqsjg.Text = f.PubDictAttrs["mc"];

            f.Dispose();
        }
    }
}