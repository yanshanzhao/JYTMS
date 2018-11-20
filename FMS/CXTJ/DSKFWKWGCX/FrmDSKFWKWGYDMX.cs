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

namespace FMS.CXTJ.DSKFWKWGCX
{
    public partial class FrmDSKFWKWGYDMX : Form
    {
        #region 
        private ClsG ObjG;
        #endregion
        public FrmDSKFWKWGYDMX()
        {
            InitializeComponent();
        }
        public void Prepare(string aFwkh,string aWhere) 
        {
            ObjG = Session["ObjG"] as ClsG;
            ObjG = Session["ObjG"] as ClsG;
            try
            {
                DSCX.Clear();
                LblFwkh.Text = aFwkh;
                ClsRWMSSQLDb.FillTable(DSCX, "select bh,inssj as slsj,(select mc from jyjckj.dbo.tjigou where id=sljgid) as sljg,fwkh,(select mc from tkh where bh=fwkh) as ckr,hwmc,zjs,dsk from tyd where fwkh='" + aFwkh + "' and " + aWhere , ClsGlobals.CntStrTMS);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ��ϸʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count <= 0)
            {
                ClsMsgBox.Ts("û����Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(Dgv, "���񿨺�Υ���ѯ��ϸ", ctrlDownLoad2,new int[]{6,7});
        }
    }
}