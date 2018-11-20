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

#endregion

namespace FMS.ZYGL.XTWSRLX
{
    public partial class FrmXTWSRLX : UserControl
    {
        public FrmXTWSRLX()
        {
            InitializeComponent();
        }
        private DSXTWSRLX.Tfmsxtwsr_lxRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as DSXTWSRLX.Tfmsxtwsr_lxRow;

                }
            }
        }
        private ClsG ObjG;        
        public void Prepare() 
        {
            this.Tfmsxtwsr_lxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            DSXTWSRLX1.EnforceConstraints = false;   
           this.Tfmsxtwsr_lxTableAdapter1.Fill(DSXTWSRLX1.Tfmsxtwsr_lx);
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmXTWSRLXMX f = new FrmXTWSRLXMX();
            f.PrePare(EnumNEDD.New,this.Bds);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.XTB = this;
            f.ShowDialog();                      
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmXTWSRLXMX f=sender as FrmXTWSRLXMX;
            if (f.DialogResult!=DialogResult.OK&&f.PubEnumNEDD==EnumNEDD.New)
            {
                this.Bds.RemoveCurrent();
                this.Bds.CancelEdit();
            }
            else if (f.DialogResult!=DialogResult.OK)
            {
                this.Bds.CancelEdit();
            }
            DSXTWSRLX1.RejectChanges();
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FrmXTWSRLXMX f = new FrmXTWSRLXMX();
            if (Bds.Current == null)
                return;
            f.PrePare(EnumNEDD.Edit,this.Bds);
            f.FormClosed+=new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();            
        }
        private void Dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            BtnEdit.PerformClick();
        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;

            ClsMsgBox.YesNo("ÊÇ·ñÉ¾³ýÐÅÏ¢£¿", new EventHandler(Delete), ObjG.CustomMsgBox, this);
        }
        private void Delete(object sender, EventArgs e)
        {
            FrmXTWSRLXMX f = new FrmXTWSRLXMX();
            Form frm = sender as Form;
            if (frm.DialogResult == DialogResult.Yes)
            {
                try
                {
                    Tfmsxtwsr_lxTableAdapter1.UpdateZt(PriRow.id);
                    Bds.RemoveCurrent();
                    ClsMsgBox.Ts("É¾³ý³É¹¦£¡", f, this);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Ts("É¾³ýÊ§°Ü£¡" + ex.ToString(), f, this);
                }
            }
        }

    }
}