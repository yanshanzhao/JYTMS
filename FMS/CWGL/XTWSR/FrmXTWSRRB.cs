#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pub;
using JY.Pri;
using FMS.SeleFrm;

#endregion

namespace FMS.CWGL.XTWSR
{
    public partial class FrmXTWSRRB : UserControl
    {
        private ClsG ObjG;
        public FrmXTWSRRB()
        {
            InitializeComponent();
        }

        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            TxtSpJg.Text = ObjG.Jigou.mc;
            TxtSpJg.Tag = ObjG.Jigou.id;
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.Rows.Count > 60000)
            {
                ClsMsgBox.Ts("不允许导出大于60000条的数据!", (Session["ObjG"] as ClsG).CustomMsgBox, this);
                return;
            }
            ClsExcel.CreatExcel(Dgv, "系统外收入查询", ctrlDownLoad1);
        }

        private void BtnSel_Click(object sender, EventArgs e)
        {

            try
            {
                string SqlTxt = "SELECT dqmc,jzsj,jzjg,SUM(ydtzf) AS ydtzf,SUM(fwkgbf) AS fwkgbf,SUM(ccf) AS ccf,SUM(xcf) AS xcf,SUM(cqwtccf) AS cqwtccf,SUM(LX) AS LX,SUM(fpsr) AS fpsr,SUM(qtlsf) AS qtlsf,SUM(ydlrcw) AS ydlrcw,SUM(qtf) AS qtf,SUM(ydtzf)+SUM(fwkgbf)+SUM(ccf)+SUM(xcf)+SUM(cqwtccf)+SUM(LX)+SUM(fpsr)+SUM(qtlsf)+SUM(ydlrcw)+SUM(qtf) AS hj FROM Vxtwsrrb";
                SqlTxt += " WHERE jzsj>='" + DtpQrStart.Value.Date.ToShortDateString() + "' AND jzsj<'" + DtpQrStop.Value.Date.AddDays(1).ToShortDateString() + "'";
                SqlTxt += " AND jzjgid in (select id from jyjckj.dbo.tjigou where parentLst like '%," + TxtSpJg.Tag + ",%')";
                SqlTxt += " GROUP BY dqmc,jzjg,jzsj";
                DataTable dt = ClsRWMSSQLDb.GetDataTable(SqlTxt, ClsGlobals.CntStrTMS);
                Dgv.DataSource = dt;
                if (Dgv.Rows.Count == 0)
                    ClsMsgBox.Ts("没有查询出正确的信息，请重新确认查询条件！", ObjG.CustomMsgBox, this);
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }

        private void BtnSeleSP_Click(object sender, EventArgs e)
        {
            FrmSelectJg1 f = new FrmSelectJg1();
            f.ShowDialog();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg1 f = sender as FrmSelectJg1;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtSpJg.Text = f.PubDictAttrs["mc"];
                this.TxtSpJg.Tag = f.PubDictAttrs["id"];
            }
        }
    }
}