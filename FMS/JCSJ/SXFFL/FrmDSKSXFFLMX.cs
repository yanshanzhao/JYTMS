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
using FMS.JCSJ.SXFFL;
using FMS.JCSJ.SXFFL.DSDSKSXFFLTableAdapters;

#endregion

namespace FMS.JCSJ.DSKKHDA.DSKSXFFLGL
{
    public partial class FrmDSKSXFFLMX : Form
    {
        #region 成员变量
        private string PriConStr; //数据库连接字符串
        private ClsG ObjG;
        public EnumNEDD PubEnumNEDD;
        private DSDSKSXFFL.tdskflRow PriRow;
        private tdskflTableAdapter PriTdskflTableAdapter1;
        public int PubId;
        private BindingSource PriBds;
        #endregion
        public FrmDSKSXFFLMX()
        {
            InitializeComponent();
        }
        public void Prepare(int aPriId, EnumNEDD aEnumNEDD, BindingSource aPriBds)
        {
            PubId = aPriId;
            PubEnumNEDD = aEnumNEDD;
            PriBds = aPriBds;
            PriTdskflTableAdapter1 = new tdskflTableAdapter();
            PriConStr = ClsGlobals.CntStrTMS;
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            Bind();
            if (PubEnumNEDD == EnumNEDD.New)
            {
                PriBds.AddNew();
            }
            PriRow = ((DataRowView)(PriBds.Current)).Row as DSDSKSXFFL.tdskflRow;
        }
        #region 绑定
        private void Bind()
        {
            this.TxtFL.DataBindings.Clear();
            this.TxtFL.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "fl", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtBmc.DataBindings.Clear();
            this.TxtBmc.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "mc", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtBZ.DataBindings.Clear();
            this.TxtBZ.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "bz", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtSxfsx.DataBindings.Clear();
            this.TxtSxfsx.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "sxfsx", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtSxfxx.DataBindings.Clear();
            this.TxtSxfxx.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "sxfxx", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
        }
        #endregion
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBmc.Text))
            {
                ClsMsgBox.Ts("名称不能为空！", this, TxtBmc, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtFL.Text))
            {
                ClsMsgBox.Ts("费率不能为空！", this, TxtFL, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtSxfsx.Text))
            {
                ClsMsgBox.Ts("手续费上限不能为空！", this, TxtSxfsx, ObjG.CustomMsgBox);
                return;
            }
            if (!ClsRegEx.IsShiShu(TxtSxfsx.Text.Trim()))
            {
                ClsMsgBox.Ts("手续费上限格式不正确，请重新输入！", this, TxtSxfsx, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtSxfxx.Text))
            {
                ClsMsgBox.Ts("手续费下限不能为空！", this, TxtSxfxx, ObjG.CustomMsgBox);
                return;
            }
            if (!ClsRegEx.IsShiShu(TxtSxfxx.Text.Trim()))
            {
                ClsMsgBox.Ts("手续费下限格式不正确，请重新输入！", this, TxtSxfxx, ObjG.CustomMsgBox);
                return;
            }
            try
            {
                PriBds.EndEdit();
                PriRow.fl = Convert.ToDecimal(TxtFL.Text);
                PriTdskflTableAdapter1.Update(PriRow);
                this.DialogResult = DialogResult.OK;
                this.Close();
                ClsMsgBox.Ts("保存成功！费率名称" + TxtBmc.Text + ",费率" + TxtFL.Text + "上限：" + TxtSxfsx.Text + "下限：" + TxtSxfxx.Text, ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("保存信息失败，请检查数据！", ex, ObjG.CustomMsgBox, this);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}