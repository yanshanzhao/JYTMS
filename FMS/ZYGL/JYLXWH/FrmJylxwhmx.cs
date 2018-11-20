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
using System.Text.RegularExpressions;

#endregion

namespace FMS.ZYGL.JYLXWH
{
    public partial class FrmJylxwhmx : Form
    {
        private ClsG ObjG;
        private DSJYLXWH.tjylxRow PriRow;
        private int PriJylxIndx = 0;
        public FrmJylxwhmx()
        {
            InitializeComponent();
        }
        #region 初始化页面 Prepare(EnumNEDD aEnumNEDD, BindingSource aBds)
        public void Prepare(EnumNEDD aEnumNEDD, BindingSource aBds, int jybh)
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            //cmbjylx.SelectedIndex = 0;
            //ClsPopulateCmbDsS.PopuYd_ywxz(cmbjylx, ClsGlobals.CntStrKj);
            TjylxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.Bds = aBds;
            if (aEnumNEDD == EnumNEDD.New)
            {
                PriRow = ((DataRowView)Bds.AddNew()).Row as DSJYLXWH.tjylxRow;
                PriRow.sort = Convert.ToInt32(jybh);
                TxtSort.Text = jybh.ToString();
            }
            else
            {
                TjylxTableAdapter1.FillByBh(DSJYLXWH1.tjylx, jybh);
                PriRow = ((DataRowView)Bds.Current).Row as DSJYLXWH.tjylxRow;
                Txtjybh.Text = PriRow.jybh.ToString();
                TxtjyMc.Text = PriRow.jymc;
                cmbjylx.Text = PriRow.lxs;
                TxtSort.Text = PriRow.sort.ToString();
                this.Txtjybh.ReadOnly = true;
                if (PriRow.states == "有效")
                    TxtAcitve.Checked = true;
                else
                    TxtAcitve.Checked = false;
            }
        }
        #endregion

        #region 保存 BtnSave_Click(object sender, EventArgs e)
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Txtjybh.Text = Txtjybh.Text.Trim();
            TxtjyMc.Text = TxtjyMc.Text.Trim();
            if (string.IsNullOrEmpty(Txtjybh.Text))
            {
                ClsMsgBox.Ts("交易编号不能为空！", ObjG.CustomMsgBox, this);
                return;
            }
            if (string.IsNullOrEmpty(TxtjyMc.Text))
            {
                ClsMsgBox.Ts("交易名称不能为空！", ObjG.CustomMsgBox, this);
                return;
            }
            Match ma = new Regex("^[0-9]+$").Match(Txtjybh.Text);
            if (!ma.Success)
            {
                ClsMsgBox.Ts("交易编号必须为数字！", ObjG.CustomMsgBox, this);
                return;
            }
            try
            {
                if (TxtAcitve.Checked)
                {
                    PriRow.states = "有效";
                    PriRow.state = 1;
                }
                else
                {
                    PriRow.states = "无效";
                    PriRow.state = 0;
                }
                PriRow.jybh = Convert.ToInt32(Txtjybh.Text);
                PriRow.jymc = TxtjyMc.Text;
                PriRow.lxs = cmbjylx.Text;
                PriRow.lx = cmbjylx.SelectedIndex;
                Bds.EndEdit();
                TjylxTableAdapter1.Update(PriRow);
                this.Close();
                ClsMsgBox.Ts("保存成功！", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Ts("遇到错误" + ex.Message, this, ObjG.CustomMsgBox);
            }
        }
        #endregion

        #region 取消按钮 BtnCancel_Click(object sender, EventArgs e)
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}