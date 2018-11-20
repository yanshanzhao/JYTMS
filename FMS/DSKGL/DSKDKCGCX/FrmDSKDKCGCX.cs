#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using JY.Pub;
using JY.Pri;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
#endregion

namespace FMS.DSKGL.DSKDKCGCX
{
    public partial class FrmDSKDKCGCX : UserControl
    {
        public FrmDSKDKCGCX()
        {
            InitializeComponent();
        }
        private ClsG ObjG;
        public void Prepare()
        {
            ObjG = (ClsG)Session["ObjG"];
            this.CmbYhlx.SelectedIndex = 4;

        }
        private void BtnCX_Click(object sender, EventArgs e)
        {
            LblCheckCount.Text="共成功发放0笔，实发金额0.00元。";
            string where =" and  dbo.tfmsdskckffpc.ffsj>='" + Dtpdkstart.Value + "'";
            where += " and  dbo.tfmsdskckffpc.ffsj<'" + DtpdkEnd.Value.AddDays(1) + "'";
            ClsD.TextBoxTrim(this);
            if (this.CmbYhlx.SelectedIndex < 3)
                where += " and yhlx.jc='"+this.CmbYhlx.Text+"' ";
            if (this.CmbYhlx.SelectedIndex==3)
                where += " and yhlx.jc not in('农业银行','建设银行','齐鲁银行')";
            if (DtpffStart.Checked)
            {
                where += "  and dbo.Tfmsdskxtffpc.inssj>='" + DtpffStart.Value + "' ";
            }
            if (DtpffEnd.Checked)
            {
                where += " and dbo.Tfmsdskxtffpc.inssj<'" + DtpffEnd.Value.AddDays(1)+ "' ";
            }
            if (!string.IsNullOrEmpty(Txtfwkh.Text))
            {
                    where += " and dsk.dskkhbh ='" + Txtfwkh.Text + "'";
            }
            if (!string.IsNullOrEmpty(TxtBH.Text))
            {
                    where += " and dsk.bh ='" + TxtBH.Text + "'";
            }
           
            DataTable dt = ClsRWMSSQLDb.GetDataTable(@"SELECT     ROW_NUMBER() OVER (ORDER BY dsk.bh) AS xh, dsk.bh, dsk.dskkhbh,                                      Convert(nvarchar(10),dbo.Tfmsdskxtffpc.inssj,111) AS xtffsj, dbo.tfmsdskckffmx.sxf, dbo.tfmsdskckffmx.dsk as je, 
                      (dbo.tfmsdskckffmx.dsk-dbo.tfmsdskckffmx.sxf) AS sfje, (CASE WHEN dsk.fkfs = 'P' THEN 'POS' WHEN dsk.fkfs = 'X' THEN '现金' END) AS fkfs,                                Convert(nvarchar(10),dbo.tfmsdskckffpc.ffsj,111) AS dksj, dbo.Tkh.tel, dbo.Tkh.mc, 
                      dbo.Tkh.yhzh, yhlx.mc AS khh, jg.jgmc AS ddz, jg.dqmc AS dddq, tjg.jgmc AS sljg, tjg.dqmc AS sldq, Convert(nvarchar                            (10),dbo.Tyd.inssj,111) as inssj,dbo.Tyd.fhlxdh
                      FROM dbo.tfmsdskckffmx LEFT OUTER JOIN
                      dbo.TfmsDsk AS dsk ON dbo.tfmsdskckffmx.dskid = dsk.id LEFT OUTER JOIN
                      dbo.tfmsdskckffpc ON dbo.tfmsdskckffmx.pcid = dbo.tfmsdskckffpc.id LEFT OUTER JOIN
                      dbo.Tfmsdskxtffmx ON dbo.Tfmsdskxtffmx.dskid = dsk.id LEFT OUTER JOIN
                      dbo.Tfmsdskxtffpc ON dbo.Tfmsdskxtffmx.pcid = dbo.Tfmsdskxtffpc.id LEFT OUTER JOIN
                      dbo.Tkh ON dsk.dskkhbh = dbo.Tkh.bh LEFT OUTER JOIN
                      dbo.Tyhlx AS yhlx ON dbo.Tkh.yhid = yhlx.id LEFT OUTER JOIN
                      jyjckj.dbo.Vdqjigou AS jg ON dsk.qsjgid = jg.jgid LEFT OUTER JOIN
                      jyjckj.dbo.Vdqjigou AS tjg ON dsk.sljgid = tjg.jgid LEFT OUTER JOIN
                      dbo.Tyd ON dbo.Tyd.id = dbo.tfmsdskckffmx.ydid
                      WHERE  (dbo.tfmsdskckffmx.zt = 20) AND (dbo.tfmsdskckffmx.dskid NOT IN
                      (SELECT dskid FROM  dbo.Tfmsdskffyc))  AND dbo.tfmsdskckffmx.dsk>0  " + where, ClsGlobals.CntStrTMS);
            Dgv.DataSource = dt;
            if (dt.Rows.Count > 0)
                LblCheckCount.Text = "共成功发放" + dt.Rows.Count + "笔，实发金额" + dt.AsEnumerable().Sum(rw => rw.Field<decimal>("sfje")) + "元。";
          

        }

        private void BtnEls_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] cellindex = { 14, 15, 16 };
            ClsExcel.CreatExcel(Dgv, "代收款打款成功查询", this.ctrlDownLoad2, cellindex);
        }

        
    }
}