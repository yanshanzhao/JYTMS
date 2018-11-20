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
        private string PriDSKDJLX = "";//���տ�Խ����� 0- ���Խ� 1- ֻ�д��տ�  2- ֻ���˱��� 3 -���˶�����
        private string PriDSKZFLS = "";//���տ�ϵͳ�Խ����� 1-�Ƹ�ͨ 2-�Ƹ�ͨ����³����
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
                ClsMsgBox.Ts("δά��ϵͳ�Խӵ���Ϣ������ϵ���տ�ţ�");
                return;
            }
            if (PriDSKZFLS != "2")
            {
                ClsMsgBox.Ts("ϵͳδ������ά��֧������ȴ���");
                return;
            }
            LinkParameters paras = new LinkParameters();
            paras.FullScreen = true;
            paras.Target = "_blank";
            Link.Open(string.Format("/aspx/FrmQlyh_dz.aspx?jgid='{0}'",ObjG.Jigou.id), paras);

        }
    }
}