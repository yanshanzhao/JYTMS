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

namespace FMS.CXTJ.JGYSKCX
{
    public partial class FrmJGYSKCXMX : Form
    {
        private ClsG ObjG;
        public FrmJGYSKCXMX()
        {
            InitializeComponent();
        }
        public void Prepare(string aJgid,string aSj) 
        {
            ObjG = Session["ObjG"] as ClsG;
            string where = " where jgid=" + aJgid + aSj;
            VfmsjgyskcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            VfmsjgyskcxTableAdapter1.FillByWhere(DsJgyskCx1.Vfmsjgyskcx, where);
            LblHj.Text= DsJgyskCx1.Vfmsjgyskcx.Compute("sum(zj)", "").ToString();
            LblFfyf.Text = DsJgyskCx1.Vfmsjgyskcx.Compute("sum(ff)", "").ToString();
            LblDfyf.Text = DsJgyskCx1.Vfmsjgyskcx.Compute("sum(tf)", "").ToString();
            LblHfyf.Text = DsJgyskCx1.Vfmsjgyskcx.Compute("sum(hf)", "").ToString();
            LblZfyf.Text = DsJgyskCx1.Vfmsjgyskcx.Compute("sum(zf)", "").ToString();
            LblFfbf.Text = DsJgyskCx1.Vfmsjgyskcx.Compute("sum(bfff)", "").ToString();
            LblHfbf.Text = DsJgyskCx1.Vfmsjgyskcx.Compute("sum(bfhf)", "").ToString();
            LblDfbf.Text = DsJgyskCx1.Vfmsjgyskcx.Compute("sum(bftf)", "").ToString();
            LblZfbf.Text = DsJgyskCx1.Vfmsjgyskcx.Compute("sum(bfzf)", "").ToString();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("没有需要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] RowIndex = { 1,2, 3, 4, 5, 6,  8 };
            ClsExcel.CreatExcel(Dgv, "机构应收款查询明细", ctrlDownLoad1, RowIndex);
        }
    }
}