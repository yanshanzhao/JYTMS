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

namespace FMS.DSKGL.DSKCKFF.WYDSKFF
{
    public partial class FrmWYDSKFFMX : Form
    {
        private ClsG ObjG;
        public FrmWYDSKFFMX()
        {
            InitializeComponent();
        }
        public void Prepare(int aPcid) 
        {
            ObjG = Session["ObjG"] as ClsG;
            VfmswydskffmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            VfmswydskffmxTableAdapter1.Fill(DSwydskff1.Vfmswydskffmx, aPcid);
            LblSxf.Text=DSwydskff1.Vfmswydskffmx.Compute("sum(sxf)", "pcid="+aPcid).ToString();
            LblZje.Text = DSwydskff1.Vfmswydskffmx.Compute("sum(zje)", "pcid=" + aPcid).ToString();
            LblSfje.Text = DSwydskff1.Vfmswydskffmx.Compute("sum(sfje)", "pcid=" + aPcid).ToString();
            LblBs.Text = DSwydskff1.Vfmswydskffmx.Compute("count(pcid)", "pcid=" + aPcid).ToString();
        }

        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 4, 5, 6 };
            ClsExcel.CreatExcel(Dgv, "代收款网银发放明细", this.ctrlDownLoad1, Rows);   
            //ClsExcel.CreatExcel(Dgv, "代收款网银发放明细", this.ctrlDownLoad1);    
        }
        #endregion
       
    }
}