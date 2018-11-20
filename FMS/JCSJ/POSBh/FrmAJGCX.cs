#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Linq;
using JY.Pri;
using JY.Pub;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Configuration;
using FMS.CWGL.YSKCX2;
using FMS.SeleFrm;

#endregion

namespace FMS.JCSJ.POSBh
{
    public partial class FrmAJGCX : UserControl
    {
        public FrmAJGCX()
        {
            InitializeComponent();
        }

        private DSAJGCX1.VPosBhRow tbVPosBhRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as DSAJGCX1.VPosBhRow;

                }

            }

        }
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private int PriJgid = 0;
        private string PriJgmc = "";
        public void Prepare()
        {
            this.VPosBhTableAdapter.Connection.ConnectionString = ClsGlobals.CntStrKj;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            this.TxtbJGmc.Text = ObjG.Jigou.mc;
            PriJgid = ObjG.Jigou.id;

        }

        private void BtnJg_Click(object sender, EventArgs e)
        {
            FrmSelectJg f = new FrmSelectJg();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtbJGmc.Text = f.PubDictAttrs["mc"];
                this.PriJgmc = TxtbJGmc.Text;
                PriJgid = Convert.ToInt32(f.PubDictAttrs["id"]);
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtbJGmc.Text = "";
                PriJgid = 0;
                PriJgmc = "";
            }
        }

        private void btncha_Click(object sender, EventArgs e)
        {
            DSAJGCX.EnforceConstraints = false;
            string aWhere = "   ";
            if (TxtbJGmc.Text.Trim().Length > 0)
            {
                aWhere = " where mc='" + TxtbJGmc.Text.Trim() + "'";
            }
            this.VPosBhTableAdapter.FillByWhere(DSAJGCX.VPosBh, aWhere);
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
            }

        }

        private void Bds_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Btnxz_Click(object sender, EventArgs e)
        {
            FrmPOSBHTJ f = new FrmPOSBHTJ();
            f.Prepare(-1, EnumNEDD.New, this.Bds);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPOSBHTJ f = sender as FrmPOSBHTJ;
            if (f.DialogResult != DialogResult.OK && f.PubEnumNEDD == EnumNEDD.New)
            {
                this.Bds.RemoveCurrent();
                this.Bds.CancelEdit();
            }

        }

        private void BtnBj_Click(object sender, EventArgs e)
        {
            FrmPOSBHTJ f = new FrmPOSBHTJ();
            if (Bds.Current == null)
                return;
            f.Prepare(tbVPosBhRow.id, EnumNEDD.Edit, this.Bds);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        private void BtnSc_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            Bds.EndEdit();
            Bds.RemoveCurrent();
            VPosBhTableAdapter.Update(DSAJGCX.VPosBh);
          
        }

        private void BtnEles_Click(object sender, EventArgs e)
        {
            if (this.Dgv.RowCount == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "POS编码维护", this.ctrlDownLoad1);
        }

    }
}
    
   
