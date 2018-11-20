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
using JY.Pub;
using JY.Pri;
#endregion

namespace FMS.CXTJ.DSKCKJSXCX
{
    public partial class FrmDSKCKJSXMX : Form
    {
        #region 成员变量
        private ClsG ObjG;
        #endregion
        public FrmDSKCKJSXMX()
        {
            InitializeComponent();
        }
        public void Prepare(int ajgid, string aStop, string aEnd, int alx1, bool aMX = false)
        {
            ObjG = Session["ObjG"] as ClsG;
            this.VfmsdskckjsxcxmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            string aWhere = " where  inssj >= '" + aStop + "' and inssj< DateAdd(dd,+1, '" + aEnd + "')  ";
            if (aMX)
                aWhere += "  and  jgid in ( select id   from  jyjckj.dbo.tjigou WHERE parentLst LIKE '%," + ajgid + ",%')";
            else
                aWhere += "  and jgid = " + ajgid;
            if (alx1 == 1)
                aWhere += " and lx1='Y'";
            else  if (alx1 ==2)
                aWhere += " and lx1<>'Y'";

                this.VfmsdskckjsxcxmxTableAdapter1.FillByWhere(this.DSDSKCKJSXCX1.Vfmsdskckjsxcxmx, aWhere);

        }

        public void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.RowCount > 60000)
            {
                ClsMsgBox.Ts("不允许导出大于60000条的数据，请缩小查询范围再进行导出！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 2, 5 };
            ClsExcel.CreatExcel(Dgv, "代收款存款及时性查询", this.ctrlDownLoad1, Rows);
        }

    }
}