#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FMS.CWGL.XTWSR.DSXTWSRTableAdapters;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pri;
using JY.Pub;

#endregion

namespace FMS.CWGL.XTWSR
{
    public partial class FrmXTWSRSPMX : Form
    {
        private ClsG ObjG;
        private VfmsxtwsrTableAdapter vfmsxtwsrTableAdapter1;
        DSXTWSR.VfmsxtwsrRow PriRow;
        public FrmXTWSRSPMX()
        {
            InitializeComponent();
        }


        public void Prepare(DSXTWSR.VfmsxtwsrRow Row)
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriRow = Row;
            vfmsxtwsrTableAdapter1 = new VfmsxtwsrTableAdapter();
            vfmsxtwsrTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            TxtLsh.Text = PriRow.lsh;
            TxtJe.Text = PriRow.je.ToString(); ;
            TxtBz.Text = PriRow.bz;
            CmbShbz.SelectedIndex = 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PriRow.spsj = DateTime.Now;
                PriRow.sprid = ObjG.Renyuan.id;
                PriRow.sprzh = ObjG.Renyuan.loginName;
                PriRow.spr = ObjG.Renyuan.xm;
                PriRow.je = Convert.ToDecimal(TxtJe.Text.ToString());
                if (CmbShbz.Text == "审核通过")
                    PriRow.zt = 1;
                else
                    PriRow.zt = 2;

                vfmsxtwsrTableAdapter1.Update(PriRow);
                this.DialogResult = DialogResult.OK;
                this.Close();
                ClsMsgBox.Ts("审批成功！", ObjG.CustomMsgBox, this);
            }
            catch (Exception)
            {

                throw;
            }
            //if (PriRow.lxid == 64 || PriRow.lxid == 65)
            //{
            //    if (CmbShbz.Text == "审核不通过")
            //    {
            //        ClsMsgBox.Ts("运单调整费和工本费只能审核通过",ObjG.CustomMsgBox,this);
            //        return;
            //    }
            //}    

        }

        private void BtnQuXiao_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
