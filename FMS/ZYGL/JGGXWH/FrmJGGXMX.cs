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
using FMS.ZYGL.JGGXWH.DSJGGXWHTableAdapters;
using JY.CtrlPub;
using FMS.SeleFrm;
using JY.Pub;

#endregion

namespace FMS.ZYGL.JGGXWH
{
    public partial class FrmJGGXMX : Form
    {
        #region 成员变量
        private BindingSource Bds;
        private FrmSelectJg PriFrmSelectJg;
        private ClsG ObjG;
        private DSJGGXWH.VfmsjggxRow PriCurJggxRow;
        private VfmsjggxTableAdapter VfmsjggxTableAdapter1;
        public EnumNEDD PubEnumNEDD;
        #endregion
        public FrmJGGXMX()
        {
            InitializeComponent();
        }
        #region 初始化数据
        public void Prepare(BindingSource aBds, EnumNEDD aEnumNEDD)
        {
            Bds = aBds;
            ObjG = Session["ObjG"] as ClsG;
            PubEnumNEDD = aEnumNEDD;
            VfmsjggxTableAdapter1 = new VfmsjggxTableAdapter();
            Rebind();
            ClsPopulateCmbDsS.PopuFMS_Jggx(CmbGxzl);
            CmbGxzl.SelectedIndex = 1;
            if (aEnumNEDD == EnumNEDD.New)
                Bds.AddNew();
            PriCurJggxRow = ((DataRowView)Bds.Current).Row as DSJGGXWH.VfmsjggxRow;


        }
        #endregion
        #region  数据绑定
        private void Rebind()
        {
            this.TxtYjg.DataBindings.Clear();
            this.TxtYjg.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "jgmc", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtGxjg.DataBindings.Clear();
            this.TxtGxjg.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "tojgmc", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.CmbGxzl.DataBindings.Clear();
            this.CmbGxzl.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("SelectedValue", this.Bds, "gxzl", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
        }
        #endregion

        #region 保存
        private void BtnSave_Click(object sender, EventArgs e)
        {
            #region 数据验证
            if (string.IsNullOrEmpty(TxtYjg.Text.Trim()))
            {
                ClsMsgBox.Ts("源机构不允许为空，请选择！", this, TxtYjg, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtGxjg.Text.Trim()))
            {
                ClsMsgBox.Ts("关系机构不允许为空，请选择！", this, TxtGxjg, ObjG.CustomMsgBox);
                return;
            }
            if (CmbGxzl.SelectedIndex == 0)
            {
                ClsMsgBox.Ts("请选择关系种类！", this, CmbGxzl, ObjG.CustomMsgBox);
                return;
            }
            if (TxtYjg.Text == TxtGxjg.Text)
            {
                ClsMsgBox.Ts("源机构和关系机构不能相同！", ObjG.CustomMsgBox, this);
                return;
            }
            #endregion
            try
            {
                Bds.EndEdit();
                VfmsjggxTableAdapter1.Update(PriCurJggxRow);
                this.DialogResult = DialogResult.OK;
                this.Close();
                ClsMsgBox.Ts("保存" + TxtYjg.Text + "与" + TxtGxjg.Text + "的"+CmbGxzl.Text+"成功！", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                string ExStr = ex.Message;
                if (ExStr.LastIndexOf("重复") > 0)
                    ClsMsgBox.Ts("保存失败！" + TxtYjg.Text + "机构已经具有" + CmbGxzl.Text, this, CmbGxzl, ObjG.CustomMsgBox);
                else
                    ClsMsgBox.Cw("保存失败！", ex, ObjG.CustomMsgBox, this);
            }


        }
        #endregion
        #region 机构选择
        //源机构
        private void BtnYjg_Click(object sender, EventArgs e)
        {
            PriFrmSelectJg = new FrmSelectJg();
            PriFrmSelectJg.Prepare();
            PriFrmSelectJg.ShowDialog();
            PriFrmSelectJg.FormClosed += new FormClosedEventHandler(FrmJGCX1_FormClosed);
        }
        private void FrmJGCX1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
            {
                PriCurJggxRow.jgmc = f.PubDictAttrs["mc"];
                PriCurJggxRow.jgid = Convert.ToInt16(f.PubDictAttrs["id"]);
                this.TxtYjg.Text = f.PubDictAttrs["mc"];
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtYjg.Text = "";
            }
            f.Dispose();
        }
        //关系机构
        private void BtnGxjg_Click(object sender, EventArgs e)
        {
            PriFrmSelectJg = new FrmSelectJg();
            PriFrmSelectJg.Prepare();
            PriFrmSelectJg.ShowDialog();
            PriFrmSelectJg.FormClosed += new FormClosedEventHandler(FrmJGCX2_FormClosed);
        }
        private void FrmJGCX2_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (FrmSelectJg f = sender as FrmSelectJg)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    PriCurJggxRow.tojgmc = f.PubDictAttrs["mc"];
                    PriCurJggxRow.tojgid = Convert.ToInt16(f.PubDictAttrs["id"]);
                    this.TxtGxjg.Text = f.PubDictAttrs["mc"];
                }
                else if (f.DialogResult == DialogResult.No)
                {
                    this.TxtGxjg.Text = "";
                }
            }
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