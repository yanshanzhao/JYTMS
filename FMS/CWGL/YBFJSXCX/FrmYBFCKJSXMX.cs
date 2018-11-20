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

namespace FMS.CWGL.YBFJSXCX
{
    public partial class FrmYBFCKJSXMX : Form
    {
        #region 成员变量
        private ClsG ObjG;
        #endregion
        public FrmYBFCKJSXMX()
        {
            InitializeComponent();
        }
        public void Prepare(int ajgid, string awhere)
        {
            this.VybfjsxcxTableAdapter.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            string aWhere = awhere + " and jgid  in (SELECT id  FROM jyjckj.dbo.tjigou WHERE parentLst LIKE '%," + ajgid + ",%' ) ";  
            VybfjsxcxTableAdapter.FillByWhere(DSYBF.Vybfjsxcx, aWhere, 0); 
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
            //int[] Rows = new int[] { 2, 5 };
            ClsExcel.CreatExcel(Dgv, "运保费存款及时性明细查询", this.ctrlDownLoad1);
        }

    }
}