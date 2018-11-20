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
using JY.CtrlPub;
#endregion

namespace FMS.CXTJ.DSKHDCX
{
    public partial class FrmDSKHDCX : UserControl
    {
        public FrmDSKHDCX()
        {
            InitializeComponent();
        }
        public void Prepare() 
        {
        
        }
        private void FrmDSKHDCX_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlTms = ClsGlobals.CntStrTMS;
            //除了作废的所有代收款总金额
            string Prisl = "select SUM(dsk) from Tyd where ydzt!='X' ";
            this.TxtSL.Text = ClsRWMSSQLDb.GetStr(Prisl, sqlTms);
                //ClsRWMSSQLDb.GetStr(Prisl, sqlTms);
            //在途状态的所有代收款总金额(not 已到达、签收、作废)
            string Prizt = "select SUM(dsk) from Tyd where  ydzt!='X' and ydzt!='Y' and ydzt!='Q'";
            this.TxtZT.Text = ClsRWMSSQLDb.GetStr(Prizt, sqlTms);
            //未提货状态的所有代收款金额总数（到达-未签收）
            string Priwth = "select SUM(dsk) from Tyd where ydzt='Y' and ydzt!='Q'";
            this.TxtWTH.Text = ClsRWMSSQLDb.GetStr(Priwth, sqlTms);
            //已签收状态的代收款总金额数
            string Priqs = "select SUM(dsk) from Tyd where ydzt='Q'";
            this.TxtQS.Text = ClsRWMSSQLDb.GetStr(Priqs,sqlTms);


            //已经确认缴款的代收款总金额
            string Priqrjk = "select SUM(dsk) from TfmsDsk where sjdskzt=30";
            this.TxtQRJK.Text = ClsRWMSSQLDb.GetStr(Priqrjk,sqlTms);
            //未返款代收款总金额
            string Priwfk = "select SUM(dsk) from TfmsDsk where sjdskzt !=30";
            this.TxtWFK.Text = ClsRWMSSQLDb.GetStr(Priwfk,sqlTms);

            //系统发放代收款总金额(未压款)
            string Prixtff = "select SUM(dsk) from TfmsDsk where dskyk=0 and ffdskzt>=20";
            this.TxtXTFF.Text = ClsRWMSSQLDb.GetStr(Prixtff, sqlTms);
            //系统未发放代收款总金额
            string Prixtwff = " select SUM(dsk) from TfmsDsk where ffdskzt=0 and dskyk=0 and sjdskzt=30";
            this.TxtXTWFF.Text = ClsRWMSSQLDb.GetStr(Prixtwff, sqlTms);
            //代收款压款总金额
            string Priyk = "select SUM(dsk) from TfmsDsk where dskyk=1";
            this.TxtYK.Text = ClsRWMSSQLDb.GetStr(Priyk, sqlTms);
        }
    }
}