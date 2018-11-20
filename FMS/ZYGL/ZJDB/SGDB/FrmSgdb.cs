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
using JYPubFiles.Classes;

#endregion

namespace FMS.ZYGL.ZJDB.SGDB
{
    public partial class FrmSgdb : UserControl
    {
        private ClsG ObjG;
        public FrmSgdb()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string where = " where lx = 'S' ";
            if (DtpSlStart.Checked)
                where += " and inssj >='" + DtpSlStart.Value.Date + "'";
            if (DtpSlStop.Checked)
                where += " and inssj <'" + DtpSlStop.Value.AddDays(1).Date + "'";
            VzzlogTableAdapter1.FillByWhere(DSSGDB1.Vzzlog, where);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
            {
                ClsMsgBox.Ts("没有要删除的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsMsgBox.YesNo("确定要删除该条信息？", new EventHandler(Delete), ObjG.CustomMsgBox, this);

        }
        public void Delete(object sender, EventArgs e)
        {
            Form f = sender as Form;
            FrmMsgBox frm = new FrmMsgBox();
            if (f.DialogResult == DialogResult.Yes)
            {
                try
                {
                    Bds.RemoveCurrent();
                    if (VzzlogTableAdapter1.Update(DSSGDB1.Vzzlog) > 0)
                    {
                        ClsMsgBox.Ts("删除成功！", f, this);
                    }
                }
                catch (Exception cw)
                {
                    ClsMsgBox.Ts("删除失败！"+cw.ToString(), f, this);
                }
            }
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FrmSGDBMX f = new FrmSGDBMX();
            f.ShowDialog();
            f.Prepare(EnumNEDD.Edit, this.Bds);
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmSGDBMX f = new FrmSGDBMX();
            f.ShowDialog();
            f.Prepare(EnumNEDD.New, this.Bds);
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }

        void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            Bds.CancelEdit();
        }
    }
}