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

namespace FMS.CXTJ.Zjglsjhd
{
    public partial class FrmZjglsjhd : UserControl
    {
        public FrmZjglsjhd()
        {
            InitializeComponent();
        }
        public void Prepare() { }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            TxtYysr2.Text=TxtYysr1.Text = TxtYysr.Text = ClsRWMSSQLDb.GetStr("select (sum(bf)+sum(yf)+sum(zsf)+sum(jhf)+sum(qtfy)+sum(psf)+sum(hdf)+sum(bzf)+sum(txf)+sum(fwf)) as zj from tfmssr", ClsGlobals.CntStrTMS);
            TxtSlydmx.Text = ClsRWMSSQLDb.GetStr("select (sum(bf)+sum(yf)+sum(zsf)+sum(jhf)+sum(qtfy)+sum(psf)+sum(hdf)+sum(bzf)+sum(txf)+sum(fwf)) as zj from tyd  where ydzt<>'X'", ClsGlobals.CntStrTMS);
            TxtYsk1.Text=TxtYsk.Text = ClsRWMSSQLDb.GetStr("select (sum(bf)+sum(yf)+sum(zsf)+sum(jhf)+sum(qtfy)+sum(psf)+sum(hdf)+sum(bzf)+sum(txf)+sum(fwf)) as zj from tfmsybf", ClsGlobals.CntStrTMS);
            TxtYysrffyj.Text = ClsRWMSSQLDb.GetStr("select (sum(bf)+sum(yf)+sum(zsf)+sum(jhf)+sum(qtfy)+sum(psf)+sum(hdf)+sum(bzf)+sum(txf)+sum(fwf)) as zj from tfmsybf  where fkfs in('F','Z','D','S')", ClsGlobals.CntStrTMS);
            TxtQstf.Text = ClsRWMSSQLDb.GetStr("select (sum((case when bffkfs='T' then bf else 0 end))+sum((case when yffkfs='T' then yf  else 0 end))+sum((case  when zsffkfs='T' then zsf else 0 end))+sum((case when jhffkfs='T' then jhf else 0 end))+sum((case when qtfyfkfs='T' then qtfy else 0 end))+sum((case when psffkfs='T' then psf else 0 end))+sum((case when hdffkfs='T' then hdf else 0 end))+sum((case when bzffkfs='T' then bzf else 0 end))+sum((case when txffkfs='T' then txf else 0 end))+sum((case when fwffkfs='T' then fwf else 0 end))) as zj from tyd  where ydzt='Q' ", ClsGlobals.CntStrTMS);
            TxtZgk.Text = ClsRWMSSQLDb.GetStr("select (sum((case when bffkfs='T' then bf else 0 end))+sum((case when yffkfs='T' then yf  else 0 end))+sum((case  when zsffkfs='T' then zsf else 0 end))+sum((case when jhffkfs='T' then jhf else 0 end))+sum((case when qtfyfkfs='T' then qtfy else 0 end))+sum((case when psffkfs='T' then psf else 0 end))+sum((case when hdffkfs='T' then hdf else 0 end))+sum((case when bzffkfs='T' then bzf else 0 end))+sum((case when txffkfs='T' then txf else 0 end))+sum((case when fwffkfs='T' then fwf else 0 end))) as zj from tyd  where ydzt<>'Q' and ydzt<>'X'", ClsGlobals.CntStrTMS);
            TxtWth.Text = ClsRWMSSQLDb.GetStr("select (sum(bf)+sum(yf)+sum(zsf)+sum(jhf)+sum(qtfy)+sum(psf)+sum(hdf)+sum(bzf)+sum(txf)+sum(fwf)) as zj from Tyd where ydzt<>'Q'  and ydzt<>'X'", ClsGlobals.CntStrTMS);
            TxtQs.Text = ClsRWMSSQLDb.GetStr("select (sum(bf)+sum(yf)+sum(zsf)+sum(jhf)+sum(qtfy)+sum(psf)+sum(hdf)+sum(bzf)+sum(txf)+sum(fwf)) as zj from Tyd where ydzt='Q'", ClsGlobals.CntStrTMS);
        
        }
    }
}