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

namespace FMS.DSKGL.LSDDZD
{
    public partial class FrmLSDDZDMX : Form
    {
        private string PriWHER;
        private string PriConStr;
        public FrmLSDDZDMX()
        {
            InitializeComponent();
        }

        public void Prepare(string where)
        {
            PriWHER = where;
            PriConStr = ClsGlobals.CntStrTMS;
            string SqlStr = string.Format(@"SELECT dqmc,jgmc,ydbh,jzje,rbje,ppzt,shzt FROM dbo.VLsddzd {0} UNION ALL SELECT NULL,'合计',NULL,SUM(jzje),SUM(rbje),NULL,NULL FROM dbo.VLsddzd {0}", PriWHER);
            DataTable dt = ClsRWMSSQLDb.GetDataTable(SqlStr, PriConStr);
            Dgv.AutoGenerateColumns = false;
            Dgv.DataSource = dt;

        }

        private void Bnt_dc_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有可导出的信息！");
                return;
            }
            int[] Rows = new int[] { 3, 4 };
            ClsExcel.CreatExcel(Dgv, "连锁店对账单信息", this.ctrlDownLoad1, Rows);
        }


    }
}
