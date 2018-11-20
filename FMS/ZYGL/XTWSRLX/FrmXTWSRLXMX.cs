#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using JY.Pri;
using TMS.SelectFrm;
using FMS.ZYGL.XTWSRLX.DSXTWSRLXTableAdapters;
using JY.Pub;

#endregion

namespace FMS.ZYGL.XTWSRLX
{
    public partial class FrmXTWSRLXMX : Form
    {
        public FrmXTWSRLXMX()
        {
            InitializeComponent();
        }
        private ClsG ObjG;
        public EnumNEDD PubEnumNEDD;
        private string PriConStr;
        private DSXTWSRLX.Tfmsxtwsr_lxRow PriRow;
        private BindingSource Bds;
        private DSXTWSRLXTableAdapters.Tfmsxtwsr_lxTableAdapter Tfmsxtwsr_lxTableAdapter1;
        public FrmXTWSRLX XTB = null;
        public void PrePare(EnumNEDD enumNedd, BindingSource bds)
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            PriConStr = ClsGlobals.CntStrTMS;
            this.PubEnumNEDD = enumNedd;
            this.Bds = bds;
            this.Tfmsxtwsr_lxTableAdapter1 = new Tfmsxtwsr_lxTableAdapter();
            this.Tfmsxtwsr_lxTableAdapter1.Connection.ConnectionString = PriConStr;
            DataBind();
            if (PubEnumNEDD == EnumNEDD.New)
            {
                this.Bds.AddNew();
                PriRow = (DSXTWSRLX.Tfmsxtwsr_lxRow)((DataRowView)(Bds.Current)).Row;
                this.PriRow.zt = 0;
            }
            if (PubEnumNEDD == EnumNEDD.Edit)
            {
                PriRow = (DSXTWSRLX.Tfmsxtwsr_lxRow)((DataRowView)(Bds.Current)).Row;
            }
        }
        public void DataBind()
        {
            this.TxtBh.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds,
                "bh", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtName.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds,
                "name", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            //this.Txtsort.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds,
            //    "sort",true,Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            //this.Cmbzt.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("SelectedValue",this.Bds,
            //    "zt",true,Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            #region 验证
            if (string.IsNullOrEmpty(TxtBh.Text))
            {
                ClsMsgBox.Ts("编号不能为空！", this, TxtBh, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtName.Text))
            {
                ClsMsgBox.Ts("名称不能为空！", this, TxtName, ObjG.CustomMsgBox);
                return;
            }
            //if (string.IsNullOrEmpty(Txtsort.Text))
            //{
            //    ClsMsgBox.Ts("排序不能为空！", this, Txtsort, ObjG.CustomMsgBox);
            //    return;
            //}
            //if (Cmbzt.SelectedIndex<0)
            //{
            //    ClsMsgBox.Ts("请选择状态！", this, Cmbzt, ObjG.CustomMsgBox);
            //    return;
            //}
            #endregion
            try
            {
                this.Bds.EndEdit();
                Tfmsxtwsr_lxTableAdapter1.Update(PriRow);
                this.DialogResult = DialogResult.OK;
                this.Close();
                ClsMsgBox.Ts("保存成功！", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                string ExStr = ex.Message;
                if (ExStr.LastIndexOf("重复") > 0)
                {
                    ClsMsgBox.Ts("保存失败！", ObjG.CustomMsgBox, this);
                }
                else
                {
                    ClsMsgBox.Cw("保存失败！", ex, ObjG.CustomMsgBox, this);
                }
            }
        }
        private void BtnQX_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}