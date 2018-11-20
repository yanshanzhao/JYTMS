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
using JY.Pub;

#endregion

namespace FMS.CXTJ.ZSFJHFCX
{
    public partial class FrmZSFJHFMX : Form
    {
        private ClsG ObjG;
        public FrmZSFJHFMX()
        {
            InitializeComponent();
        }
        public void Prepare(string aJgmc,string aJgid,string aKssj,string aJssj) 
        {
            ObjG = Session["ObjG"] as ClsG;
            LblJgmc.Text = aJgmc;
            LblStart.Text = aKssj;
            LblStop.Text = aJssj;
            try
            {
                VfmsZsf_JhfCxTableAdapter1.FillByWhere(DsZsf_JhfCx1.VfmsZsf_JhfCx, string.Format(" where jgid={0} and sj between '{1}' and '{2}' ", aJgid, Convert.ToDateTime(aKssj), Convert.ToDateTime(aJssj).AddDays(1)), "select bh,sljgmc,slsj,zdwz,qssj,zsf,jhf,hj from VfmsZsf_JhfCx ");
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("≤È—Ø–≈œ¢ ß∞‹!",ex,ObjG.CustomMsgBox,this);
            }
        }
    }
}