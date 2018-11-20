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

namespace FMS.DSKGL.DSKSXFFL
{
    public partial class FrmDSKSXFFLMXNEW : Form
    {
        #region 成员变量
        private ClsG ObjG;
        private BindingSource BdsMx;
        private EnumNEDD PriEnumNEDD;
        private DSDSKSXFFL.VfmssxfflmxRow PriRow;
        private DSDSKSXFFL.VfmssxfflmxDataTable PriMx;
        #endregion

        public FrmDSKSXFFLMXNEW()
        {
            InitializeComponent();
        }
        #region 初始化数据
        public void Prepare(BindingSource aBds, EnumNEDD aEnumNEDD,DSDSKSXFFL.VfmssxfflmxDataTable aMx)
        {
            ObjG = Session["ObjG"] as ClsG;
            this.BdsMx = aBds;
            PriEnumNEDD = aEnumNEDD;
            Bind();
            PriMx = aMx;
            if (aEnumNEDD == EnumNEDD.New)
                BdsMx.AddNew();
            PriRow = ((DataRowView)BdsMx.Current).Row as DSDSKSXFFL.VfmssxfflmxRow;
            ClsPopulateCmbDsS.PopuZCYd_dskffsj1(CmbDSKFFSJ);
        }
        #endregion

        #region 数据绑定
        private void Bind()
        {
            this.CmbDSKFFSJ.DataBindings.Clear();
            this.CmbDSKFFSJ.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("SelectedValue", this.BdsMx, "dskffsj", true,
               Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtFl.DataBindings.Clear();
            this.TxtFl.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.BdsMx, "fl", true,
               Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtSxfsx.DataBindings.Clear();
            this.TxtSxfsx.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.BdsMx, "sxfsx", true,
               Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtSxfxx.DataBindings.Clear();
            this.TxtSxfxx.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.BdsMx, "sxfxx", true,
               Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
        }
        #endregion

        #region 保存
        private void BtnSave_Click(object sender, EventArgs e)
        {
            #region 数据验证
            ClsD.TextBoxTrim(this);
            if (string.IsNullOrEmpty(CmbDSKFFSJ.Text))
            {
                ClsMsgBox.Ts("请选择发放时间！", this, CmbDSKFFSJ, ObjG.CustomMsgBox);
                return;
            }

            if (string.IsNullOrEmpty(TxtSxfsx.Text))
            {
                ClsMsgBox.Ts("手续费上限不允许为空！", this, TxtSxfsx, ObjG.CustomMsgBox);
                return;
            }
            if (!ClsRegEx.IsShiShu(TxtSxfsx.Text))
            {
                ClsMsgBox.Ts("手续费上限格式不正确，请重新输入！", this, TxtSxfsx, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtSxfxx.Text))
            {
                ClsMsgBox.Ts("手续费下限不允许为空！", this, TxtSxfxx, ObjG.CustomMsgBox);
                return;
            }
            if (!ClsRegEx.IsShiShu(TxtSxfxx.Text))
            {
                ClsMsgBox.Ts("手续费下限格式不正确，请重新输入！", this, TxtSxfxx, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtFl.Text))
            {
                ClsMsgBox.Ts("手续费费率不允许为空！", this, TxtFl, ObjG.CustomMsgBox);
                return;
            } if (!ClsRegEx.IsShiShu(TxtFl.Text))
            {
                ClsMsgBox.Ts("手续费费率格式不正确，请重新输入！", this, TxtFl, ObjG.CustomMsgBox);
                return;
            }
            
            if (Convert.ToDecimal(TxtSxfsx.Text)<Convert.ToDecimal(TxtSxfxx.Text))
            {
                ClsMsgBox.Ts("手续费上限不能小于手续费下限！", ObjG.CustomMsgBox, this);
                return;
            }
            #endregion
            try
            {
                PriRow.dskffsjs = CmbDSKFFSJ.Text;
                BdsMx.EndEdit();
                if (PriEnumNEDD == EnumNEDD.New)
                {
                    if (PriMx.Select("dskffsjs='" + CmbDSKFFSJ.Text + "'").Count() > 1)
                    {
                        ClsMsgBox.Cw("费率信息维护重复！", ObjG.CustomMsgBox, this);
                        return;
                    }
                    BdsMx.AddNew();
                    PriRow = ((DataRowView)BdsMx.Current).Row as DSDSKSXFFL.VfmssxfflmxRow;
                }
                else
                {
                    if (PriMx.Select("dskffsjs='" + CmbDSKFFSJ.Text + "'").Count() > 1)
                    {
                        ClsMsgBox.Cw("费率信息维护重复！", ObjG.CustomMsgBox, this);
                        return;
                    }
                    this.Close();
                    ClsMsgBox.Ts("保存成功！", ObjG.CustomMsgBox, this);
                }
                CmbDSKFFSJ.Focus();
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("保存费率明细失败！", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion

        #region 窗体关闭事件
        private void FrmDSKSXFFLMXNEW_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (PriEnumNEDD == EnumNEDD.New)
                BdsMx.RemoveCurrent();
            else if (PriEnumNEDD == EnumNEDD.Edit)
                BdsMx.CancelEdit();
        }
        #endregion

        #region 取消
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}