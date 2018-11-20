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

namespace FMS.DSKGL.DSKCKFF.YQZLFFCX
{
    public partial class FrmYqzlffcxmx : Form
    {
        private ClsG ObjG;
        public FrmYqzlffcxmx()
        {
            InitializeComponent();
        }
        public void Prepare(DSYQZLCX.VYQZLCXRow row)
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            LblZje.Text = row.zje.ToString();
            LblSxf.Text = row.sxf.ToString();
            LblSfje.Text = row.sfje.ToString();
            LblBs.Text = row.bs.ToString();
            DataTable dt = ClsRWMSSQLDb.GetDataTable("SELECT b.bh,b.fwkh,c.yhzh,a.je,b.dsk,b.qssj,c.mc,(CASE a.zt WHEN 0 THEN '发放' WHEN 10 THEN '成功' WHEN 20 THEN '失败' END) as zt,c.lxr  FROM dbo.Tfmsdskckffmxlog AS a LEFT JOIN dbo.Tyd AS b ON a.ydid = b.id LEFT JOIN dbo.Tkh AS c ON b.fwkh = c.bh AND c.lx ='C' LEFT JOIN dbo.Tyhlx AS d ON c.yhid = d.id where a.pcid = " + row.id, ClsGlobals.CntStrTMS);
            Dgv.DataSource = dt;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {

        }



        private void BtnExl_Click(object sender, EventArgs e)
            {
            int[] col = new int[] { 4, 5 };
            string Filename = "银企直联代发结果查询" + DateTime.Now.ToString("yyyyMMdd");
            ClsExcel.CreatExcel(Dgv, Filename, ctrlDownLoad2, col);
            }
    }
}