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

namespace FMS.CXTJ.DQJFFYYSRYB
{
    public partial class FrmDQJFFYYSRYB : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        //private DateTime aKssj = DateTime.Now;
        #endregion
        public FrmDQJFFYYSRYB()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG; 
            ClsPopulateCmbDsS.PopuYd_cplx_qb(Cmbtjlx, ClsGlobals.CntStrKj);
            ClsPopulateCmbDsS.PopuYd_ywxz(CmbYwxz, ClsGlobals.CntStrKj);
            this.Cmbtjlx.Text = "整车";
            ClsPopulateCmbDsS.PopuYear(this.CmbYears);
            this.CmbYears.SelectedIndex = 2;
            this.CmbMoths.SelectedIndex = DateTime.Now.AddMonths(-1).Month;
        }
        #region 查询
        private void BtnSave_Click(object sender, EventArgs e)
        {
            DateTime aKssj = Convert.ToDateTime(CmbYears.Text + "-" + CmbMoths.Text + "-01");
            DateTime aJssj = aKssj.AddMonths(1);
            string awhere = "";
            if (CmbYwxz.SelectedIndex > 0)
                awhere += " and ywxz='" + CmbYwxz.SelectedValue.ToString() + "' ";
            string aSqlCmt = "select ywqymc,ywxzmc,jgmc,SUM(je) as je from Vfmsdqjfhyysryb   where  inssj between '" + aKssj + "' and  '" + aJssj + "' and ywqy='" + this.Cmbtjlx.SelectedValue.ToString() + "' " + awhere + " group by jgmc,ywxzmc,ywqymc ";
            this.Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(aSqlCmt, ClsGlobals.CntStrTMS);
            if (Dgv.Rows.Count == 0)
                ClsMsgBox.Ts("没有要查询的信息，请查询查询条件！", ObjG.CustomMsgBox, this);
        }
        #endregion
        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 1 };
            ClsExcel.CreatExcel(Dgv, "大区间整车发货营业收入月报", this.ctrlDownLoad1, Rows);
        }
        #endregion
    }
}