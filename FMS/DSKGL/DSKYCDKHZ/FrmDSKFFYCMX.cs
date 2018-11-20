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

namespace FMS.DSKGL.DSKYCDKHZ
{
    public partial class FrmDSKFFYCMX : Form
    {
        #region 成员变量
        private DateTime PriKsTime; 
        private ClsG ObjG;
        #endregion
        public FrmDSKFFYCMX()
        {
            InitializeComponent();
        }
        public void Prepare(string aTxt,string aSj)
        {
            ObjG = Session["ObjG"] as ClsG;
            PriKsTime = Convert.ToDateTime(aSj);
            this.VfmsdskffycmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            string aSQl = "";
            this.Text = aTxt;
            if (aTxt.Trim() == "本日增加额")
            {
                aSQl = " SELECT  row_number()OVER (ORDER BY  id) as id, slsj, sldq, sljgmc, dddq, ddz, bh, fwkh, ckr, lxfs, khh, fhlxdh, yhzh, fkfs, dsk, sfdsk, sxf, xtffsj, dksj, ycyy  FROM dbo.Vfmsdskffycmx where   xzsj between '" + PriKsTime + "' and DateAdd(dd,+1,'" + PriKsTime + "') ";
            }
            else if (aTxt.Trim() == "本日减少额")
            {
                aSQl = " SELECT  row_number()OVER (ORDER BY  id) as id, slsj, sldq, sljgmc, dddq, ddz, bh, fwkh, ckr, lxfs, khh, fhlxdh, yhzh, fkfs, dsk, sfdsk, sxf, xtffsj, dksj, NULL as ycyy  FROM dbo.Vfmsdskffycmx where  ffsj between '" + PriKsTime + "' and DateAdd(dd,+1,'" + PriKsTime + "') ";
            }
            else
            {
                aSQl = " SELECT  row_number()OVER (ORDER BY  id) as id, slsj, sldq, sljgmc, dddq, ddz, bh, fwkh, ckr, lxfs, khh, fhlxdh, yhzh, fkfs, dsk, sfdsk, sxf, xtffsj, dksj, ycyy  FROM dbo.Vfmsdskffycmx where  xzsj<'" + PriKsTime.AddDays(1) + "' and (ffsj is null or ffsj >='" + PriKsTime.AddDays(1) + "')";
            }
            this.VfmsdskffycmxTableAdapter1.FillByWhere1(this.DSDSKYCHZ1.Vfmsdskffycmx, aSQl);

        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！");
                return;
            }
            int[] Rows = new int[] { 14,15,16 };
            ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1, Rows);   
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}