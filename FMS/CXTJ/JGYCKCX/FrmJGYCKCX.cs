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
using JYPubFiles.Classes;
using FMS.SeleFrm;

#endregion

namespace FMS.CXTJ.JGYCKCX
{
    public partial class FrmJGYCKCX : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private FrmSelectJg PriFrmSelectJg;
        public int jgid;
        #endregion
        public FrmJGYCKCX()
        {
            InitializeComponent();
        }
        #region 初始化数据
        public void Prepare()
        {
            ObjG=(ClsG)VWGContext.Current.Session["OBjG"];
            VfmsjgyckcxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            CmbZt.SelectedIndex = 1;
            jgid = ObjG.Jigou.id;
            TxtJg.Text = ObjG.Jigou.mc;
        }
        #endregion
        #region 机构查询
        private void BtnJg_Click(object sender, EventArgs e)
        {
            PriFrmSelectJg = new FrmSelectJg();
            PriFrmSelectJg.Prepare();
            PriFrmSelectJg.ShowDialog();
            PriFrmSelectJg.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmJGCX1_FormClosed);
        }
        private void FrmJGCX1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
                jgid = Convert.ToInt32(f.PubDictAttrs["id"]);
                this.TxtJg.Text = f.PubDictAttrs["mc"];
                
            f.Dispose();
        }
        #endregion

        #region 导出
        private void BtnDc_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] CellIndex = { 5};
            ClsExcel.CreatExcel(Dgv, "机构应存款明细", this.ctrlDownLoad1, CellIndex);
        }
        #endregion 

        #region  查询
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            this.LblHj.Text = "金额合计：0.00元";
            try
            {                
                string where = " where  je<>0 ";
                if (CmbZt.SelectedIndex == 0)
                    where += " and zt='已存' ";
                if (CmbZt.SelectedIndex == 1)
                    where += " and zt='未存' ";
                
                where += string.IsNullOrEmpty(TxtJg.Text) ? "" : " and jsjgid in (select id from jyjckj.dbo.tjigou where parentLst like '%," + jgid + ",%')";
                
                if (DtpStart.Checked)
                    where += " and inssj >='" + DtpStart.Value.Date.ToString("yyyy-MM-dd") + "'";
                if (DtpEnd.Checked)
                    where +=" and inssj <'" + DtpEnd.Value.Date.AddDays(1).ToString("yyyy-MM-dd") + "' ";
                //where += " and inssj >='" + DtpStart.Value.Date.ToString("yyyy-MM-dd") + "' and inssj <'" + DtpEnd.Value.Date.AddDays(1).ToString("yyyy-MM-dd") + "' ";
                VfmsjgyckcxTableAdapter1.FillByWhere(DSJGYCKCX1.Vfmsjgyckcx, where);
                if (Bds.Count == 0)
                    ClsMsgBox.Ts("没有查询到相应信息，请核对查询条件！",ObjG.CustomMsgBox,this);
                else
                    this.LblHj.Text = "金额合计：" + this.DSJGYCKCX1.Vfmsjgyckcx.Compute("sum(je)", "").ToString() + "元";
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("查询信息失败！",ex,ObjG.CustomMsgBox,this);
            }

        }
        #endregion
    }
}