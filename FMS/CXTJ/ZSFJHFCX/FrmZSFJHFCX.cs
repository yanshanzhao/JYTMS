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
using FMS.SeleFrm;

#endregion

namespace FMS.CXTJ.ZSFJHFCX
{
    public partial class FrmZSFJHFCX : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private string PriWhere;
        private FrmSelectJg f;
        private int PriJgid;
        private FrmZSFJHFMX frm;
        private string PriKssj;
        private string PriJssj;
        #endregion 
        public FrmZSFJHFCX()
        {
            InitializeComponent();
        }
        #region 初始化数据
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
        }
        #endregion
        #region 查询
        private void BtnSearch_Click(object sender, EventArgs e)
        {
           
            DSCX.Clear();
            try
            {
                PriWhere = " where  sj >= '" + DtpStart.Value.Date + "' and sj<'" + DtpStop.Value.AddDays(1).Date + "'";
                PriKssj = DtpStart.Value.ToString("yyyy.MM.dd");
                PriJssj = DtpStop.Value.ToString("yyyy.MM.dd");
                if (!string.IsNullOrEmpty(TxtJg.Text))
                    PriWhere += ChkBJg.Checked ? " and jgid =" + PriJgid : " and jgid in( select id from jyjckj.dbo.tjigou where parentLst like '%," + PriJgid + ",%')";
                
                ClsRWMSSQLDb.FillTable(DSCX, "select jgmc,SUM(jhf) as jhf,SUM(zsf) as zsf,(SUM(jhf)+SUM(zsf)) as hj,jgid,'详细信息' as xx from VfmsZsf_JhfCx " + PriWhere + " group by jgmc,jgid order by jgmc"
                    , ClsGlobals.CntStrTMS);
                if (DSCX.Rows.Count == 0)
                {
                    ClsMsgBox.Ts("没有查询到相应信息，请核对查询条件！", ObjG.CustomMsgBox, this);
                    return;
                }
                LblHj.Text = "接货费：" + DSCX.Compute("sum(jhf)", "").ToString() + "   直送费：" + DSCX.Compute("sum(zsf)", "").ToString() + "   合计：" + DSCX.Compute("sum(hj)", "").ToString();
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("查询失败！", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion

        #region 机构查询
        private void BtnJgSearch_Click(object sender, EventArgs e)
        {
            f = new FrmSelectJg();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtJg.Text = f.PubDictAttrs["mc"];
                PriJgid =Convert.ToInt32(f.PubDictAttrs["id"]);
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtJg.Clear();
                PriJgid = 0;
            }
        }
        #endregion

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if(Dgv.Columns[e.ColumnIndex].Name.Equals("DgvLnk"))
            {
                frm = new FrmZSFJHFMX();
                frm.Prepare(Dgv.Rows[e.RowIndex].Cells[DgvColTxtJgmc.Name].Value.ToString(),Dgv.Rows[e.RowIndex].Cells[DgvColTxtJgid.Name].Value.ToString(),PriKssj,PriJssj);
                frm.ShowDialog();
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0) 
            {
                ClsMsgBox.Ts("没有需要导出的信息！",ObjG.CustomMsgBox,this);
                return;
            }
            int[] RowIndex = { 1,2,3};
            ClsExcel.CreatExcel(Dgv,"直送费接货费查询",ctrlDownLoad1,RowIndex);
        }
    }
}