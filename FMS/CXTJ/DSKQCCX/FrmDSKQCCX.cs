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

namespace FMS.CXTJ.DSKQCCX
{
    public partial class FrmDSKQCCX : UserControl
    {
        private ClsG ObjG;
        public FrmDSKQCCX()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["OBjG"];
            CmbCplx.SelectedIndex = 0;
            ClsPopulateCmbDsS.PopuFmsDskffsj(CmbCplx);
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string where = " where  dksj>='" + DtpStart.Value.Date + "' and dksj <'" + DtpEnd.Value.AddDays(1).Date + "'";
            where += CmbCplx.SelectedValue.ToString() == "" ? "" : " and dsffsj = '" + CmbCplx.SelectedValue.ToString() + "'";
            //if (CmbCplx.SelectedIndex == 1)
            //    where += " and dsffsj='A'";
            //if (CmbCplx.SelectedIndex == 2)
            //    where += " and dsffsj='B'";
            //if (CmbCplx.SelectedIndex == 3)
            //    where += " and dsffsj='C'";
            if (!string.IsNullOrEmpty(TxtYcts.Text.Trim()) && !ClsRegEx.IsShuZi(TxtYcts.Text.Trim()))
            {
                ClsMsgBox.Ts("延迟天数输入格式不正确！", ObjG.CustomMsgBox, this);
                return;
            }
            where += string.IsNullOrEmpty(TxtYcts.Text.Trim()) ? "" : " and ycts >=" + TxtYcts.Text.Trim();
           
            VdskqccxTableAdapter1.FillByWhere(DSDSKQCCX1.Vdskqccx, where);
            AddColor();
        }
        private void AddColor()
        {
            for (int i = 0; i < Dgv.Rows.Count; i++)
            {
                //decimal ts = Convert.ToDecimal(Dgv.Rows[i].Cells["DgvColTxtycts"].Value);
                //decimal ts2 = string.IsNullOrEmpty(Dgv.Rows[i].Cells["DgvColTxtDkje"].Value.ToString()) ? 0 : Convert.ToDecimal(Dgv.Rows[i].Cells["DgvColTxtDkje"].Value);
                //if (dskje != dkje)
                //{
                if (Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtycts"].Value) < 0)
                {
                    Dgv.Rows[i].Cells["DgvColTxtycts"].Style.ForeColor = Color.Red;
                }
                //}
            }
        }

        private void BtnExlym_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "代收款全程查询明细", ctrlDownLoad1, new int[] { 1, 11, 13, 15, 16, 17 });
        }
    }
}