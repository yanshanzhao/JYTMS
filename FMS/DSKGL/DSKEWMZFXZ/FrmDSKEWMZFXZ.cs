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

namespace FMS.DSKGL.DSKEWMZFXZ
{
    public partial class FrmDSKEWMZFXZ : UserControl
    {
        private ClsG ObjG;
        private int RowsCount = 0;
        private string PriDSKDJLX = "";//代收款对接类型 0- 不对接 1- 只有代收款  2- 只有运保费 3 -代运都含有
        private string PriDSKZFLS = "";//代收款系统对接类型 1-善付通 2-善付通和齐鲁银行
        public FrmDSKEWMZFXZ()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = Session["objG"] as ClsG;
            DataTable dt = ClsRWMSSQLDb.GetDataTable(string.Format("  SELECT userCertType,userCertValue,usertel,userxm FROM dbo.Vfmssftuser WHERE jgid={0}   AND zt=1  and xtlx=1  ", ObjG.Jigou.id), ClsGlobals.CntStrTMS);
            RowsCount = dt.Rows.Count;
            dt.Clear();
            PriDSKDJLX = System.Configuration.ConfigurationManager.AppSettings.Get("DSKDJLX");
            PriDSKZFLS = System.Configuration.ConfigurationManager.AppSettings.Get("DSKZFLS");
        }

        private void BtnTS_Click(object sender, EventArgs e)
        { 
            if (RowsCount == 0)
            {
                ClsMsgBox.Ts("未维护系统对接的信息，请联系代收款部门！");
                return;
            }
            if (PriDSKZFLS != "2")
            {
                ClsMsgBox.Ts("系统未开启二维码支付尽情等待！");
                return;
            }
            LinkParameters paras = new LinkParameters();
            paras.FullScreen = true;
            paras.Target = "_blank";
            Link.Open(string.Format("/aspx/FrmQlyh_dz.aspx?jgid='{0}'",ObjG.Jigou.id), paras);

        }
    }
}