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
using FMS.ZYGL.JYLXWH;
using JY.Pub;

#endregion

namespace FMS.ZYGL.JYLXWH
{
    public partial class FrmJylxwh : UserControl
    {
        private ClsG ObjG;
        public FrmJylxwh()
        {
            InitializeComponent();
        }

        #region 加载页面数据Prepare()
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            TjylxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            TjylxTableAdapter1.Fill(DSJYLXWH1.tjylx);
        }
        #endregion

        #region 新增 BtnNew_Click(object sender, EventArgs e)
        private void BtnNew_Click(object sender, EventArgs e)
        {
            int sort = DSJYLXWH1.tjylx.Rows.Count == 0 ? -1 : Convert.ToInt32(DSJYLXWH1.tjylx.Compute("MAX(sort)", "1=1"));
            FrmJylxwhmx f = new FrmJylxwhmx();
            f.Prepare(EnumNEDD.New, this.Bds, Convert.ToInt32((sort + 1)));
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }
        #endregion

        #region 编辑 BtnEndit_Click(object sender, EventArgs e)
        private void BtnEndit_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            FrmJylxwhmx f = new FrmJylxwhmx();
            DSJYLXWH.tjylxRow row = ((DataRowView)Bds.Current).Row as DSJYLXWH.tjylxRow;
            f.Prepare(EnumNEDD.Edit, this.Bds, Convert.ToInt32(row.jybh));
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }
        #endregion

        #region 作废 BtnDel_Click(object sender, EventArgs e)
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            DSJYLXWH.tjylxRow row = ((DataRowView)Bds.Current).Row as DSJYLXWH.tjylxRow;
            if (row.states != "无效")
            {
                ClsMsgBox.Ts("作废成功！", ObjG.CustomMsgBox, this);
            }
            else
            {
                ClsMsgBox.Ts("该信息已经作废！", ObjG.CustomMsgBox, this);
            }
            row.state = 0;
            row.states = "无效";
            Bds.EndEdit();
            TjylxTableAdapter1.Update(DSJYLXWH1.tjylx);
           
        }
        #endregion

        #region 启用 BtnStart_Click(object sender, EventArgs e)
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            DSJYLXWH.tjylxRow row = ((DataRowView)Bds.Current).Row as DSJYLXWH.tjylxRow;
            
            if (row.states != "有效")
            {
                ClsMsgBox.Ts("启用成功！", ObjG.CustomMsgBox, this);
            }
            else
            {
                ClsMsgBox.Ts("该信息已经启用！", ObjG.CustomMsgBox, this);
            }
            row.state = 1;
            row.states = "有效";
            Bds.EndEdit();
            TjylxTableAdapter1.Update(DSJYLXWH1.tjylx);
        }
        #endregion

        #region 收款排序 BtnSort_Click(object sender, EventArgs e)
        private void BtnSort_Click(object sender, EventArgs e)
        {
            TjylxTableAdapter1.FillBySort(DSJYLXWH1.tjylx);
            FrmSort f = new FrmSort();
            f.Prepare(DSJYLXWH1.tjylx, 1);
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }
        #endregion

        #region 调用关闭方法 f_FormClosing(object sender, FormClosingEventArgs e)
        void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            Bds.CancelEdit();
            TjylxTableAdapter1.Fill(DSJYLXWH1.tjylx);
        }
        #endregion
    }
}