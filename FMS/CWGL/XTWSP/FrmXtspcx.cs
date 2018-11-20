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

namespace FMS.CWGL.XTWSP
{
    public partial class FrmXtspcx : UserControl
    {
        private ClsG ObjG;

        public FrmXtspcx()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            this.VfmsxtwcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable("   SELECT  0 as id,'--请选择--' as  jc union  select id,jc from tyhlx where  hdzt='Y' and id in(63,241)  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbYHlx, dtYhlx, "id", "jc");
            DataTable dtYwlx = ClsRWMSSQLDb.GetDataTable("   SELECT  0 as id,'--请选择--' as  name union   SELECT id,name  FROM dbo.Tfmsxtwsr_lx WHERE zt=0    ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbYwlx, dtYwlx, "id", "name");
            CmbShzt.SelectedIndex = 0;
        }

        private void BtnSel_Click(object sender, EventArgs e)
        {
            string where = " where  inssj>='" + DteTimeBegin.Value.Date + "'  and inssj<'" + DteTimeEnd.Value.Date.AddDays(1) + "'";
            if (CmbYHlx.SelectedIndex > 0)
                where += "  and yhlxmc='" + CmbYHlx.Text + "' ";
            if (CmbYwlx.SelectedIndex > 0)
                where += "  and name ='" + CmbYwlx.Text + "' ";
            where += "  and zts='" + this.CmbShzt.Text + "'";
            this.VfmsxtwcxTableAdapter1.FillByWhere(this.DSSP1.Vfmsxtwcx, where);
            if (Bds.Count == 0)
                ClsMsgBox.Ts("没有查询到信息，请重新选择查询条件！");


        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "系统外收入查询", this.ctrlDownLoad1, new int[] { 6 });
        }


    }
}