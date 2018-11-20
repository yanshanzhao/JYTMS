#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using JY.Pri;
using JY.Pub;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using FMS.SeleFrm;

#endregion

namespace FMS.DSKGL.YFLSDZJ
{
    public partial class FrmInsert : Form
    {
        public FrmInsert()
        {
            InitializeComponent();
        }
        private string PriSql = "";
        private int Choice = 0;
        private int Id = 0;
        private ClsG ObjG;
        public void Prepare(int _Choice, int _id)
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            Choice = _Choice;
            Id = _id;
            if (_Choice > 0)
            {
                string strSql = " select jgmc,jgid,yjje,flje from Vyflsdzj where id=" + _id + " ";
                DataRow dr = ClsRWMSSQLDb.GetDataRow(strSql, ClsGlobals.CntStrTMS);
                this.TxtJgmc.Text = dr["jgmc"].ToString();
                this.TxtJgmc.Tag = Convert.ToInt32(dr["jgid"]);
                this.TxtYjje.Text = dr["yjje"].ToString();
                this.TxtFlje.Text = dr["flje"].ToString();
            }
        }
        private void TxtSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TxtJgmc.Text.Trim()))
            {
                ClsMsgBox.Ts("请选择机构");
                return;
            }
            if (string.IsNullOrEmpty(this.TxtYjje.Text.Trim()))
            {
                ClsMsgBox.Ts("请输入押金金额");
                return;
            }
            double yjje;
            if (!double.TryParse(this.TxtYjje.Text.Trim(), out yjje)) 
            {
                ClsMsgBox.Ts("输入押金金额格式错误，请重新输入");
                this.TxtYjje.Text = "";
                this.TxtYjje.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.TxtFlje.Text.Trim()))
            {
                ClsMsgBox.Ts("请输入返利金额");
                return;
            }
            double flje;
            if (!double.TryParse(this.TxtFlje.Text.Trim(), out flje)) 
            {
                ClsMsgBox.Ts("输入返利金额格式错误，请重新输入");
                this.TxtFlje .Text = "";
                this.TxtFlje.Focus();
                return;
            }
            if (Choice < 0)
            {
                PriSql = " insert into [dbo].[tyflsdzj] ([yjje],[flje],[insj],[jgid],[inrxm],[inrid],[inrzh],[injgid]) values (" + this.TxtYjje.Text.Trim() + "," + this.TxtFlje.Text.Trim() + ",'" + System.DateTime.Now + "'," + this.TxtJgmc.Tag + ",'" + ObjG.Renyuan.xm + "'," + ObjG.Renyuan.id + ",'" + ObjG.Renyuan.loginName + "'," + ObjG.Jigou.id + ") ";
            }
            if (Choice > 0)
            {
                PriSql = " UPDATE [dbo].[tyflsdzj] SET [yjje] =" + this.TxtYjje.Text + ",[flje] =" + TxtFlje.Text + ",[jgid] =" + TxtJgmc.Tag + ",[upsj] ='" + System.DateTime.Now + "',[uprxm] ='" + ObjG.Renyuan.xm + "',[uprid] =" + ObjG.Renyuan.id + ",[uprzh] ='" + ObjG.Renyuan.loginName + "' where id=" + Id + " ";
            }
            int count = ClsRWMSSQLDb.ExecuteCmd(PriSql, ClsGlobals.CntStrTMS);
            if (count > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
        private void BtnSelectWz_Click(object sender, EventArgs e)
        {
            FrmSelectJg1 f = new FrmSelectJg1();
            f.ShowDialog();
            f.Prepare();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (FrmSelectJg1 f = sender as FrmSelectJg1)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    this.TxtJgmc.Tag = Convert.ToInt32(f.PubDictAttrs["id"]);
                    this.TxtJgmc.Text = f.PubDictAttrs["mc"];
                }
            }
        }

        private void TxtQx_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}