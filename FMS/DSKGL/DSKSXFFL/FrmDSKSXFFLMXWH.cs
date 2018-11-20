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
using JYPubFiles.Classes;
#endregion

namespace FMS.DSKGL.DSKSXFFL
{
    public partial class FrmDSKSXFFLMXWH : Form
    {
        #region 成员变量
        private ClsG ObjG;
        private FrmMsgBox frm;
        private bool PriIsDefault;
        #endregion
        public FrmDSKSXFFLMXWH()
        {
            InitializeComponent();
        }
        #region 初始化数据
        public void Prepare(int aPcid, EnumNEDD aEnumNEDD)
        {
            ObjG = Session["ObjG"] as ClsG;
            Bind();
            TfmssxfflpcTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            VfmssxfflmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            TableAdapterManager1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            if (aEnumNEDD == EnumNEDD.New)
                Bds.AddNew();
            if (aEnumNEDD == EnumNEDD.Edit)
            {
                TfmssxfflpcTableAdapter1.FillById(DSdsksxffl1.Tfmssxfflpc, aPcid);
                if (chkB.Checked)
                    PriIsDefault = true;
                VfmssxfflmxTableAdapter1.FillByPcid(DSdsksxffl1.Vfmssxfflmx, aPcid);
            }
        }
        #endregion

        #region 数据绑定
        private void Bind()
        {
            this.TxtMc.DataBindings.Clear();
            this.TxtMc.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "mc", true,
               Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtBz.DataBindings.Clear();
            this.TxtBz.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "bz", true,
               Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.chkB.DataBindings.Clear();
            this.chkB.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Checked", this.Bds, "isdefault", true,
               Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
        }
        #endregion

        #region 新增和编辑
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Bds.EndEdit();
            FrmDSKSXFFLMXNEW f = new FrmDSKSXFFLMXNEW();
            f.Prepare(BdsMX, EnumNEDD.New, DSdsksxffl1.Vfmssxfflmx);
            f.ShowDialog();
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (BdsMX.Current == null)
                return;
            FrmDSKSXFFLMXNEW f = new FrmDSKSXFFLMXNEW();
            f.Prepare(BdsMX, EnumNEDD.Edit, DSdsksxffl1.Vfmssxfflmx);
            f.ShowDialog();
        }
        #endregion

        #region 保存
        private void BtnSave_Click(object sender, EventArgs e)
        {
            ClsD.TextBoxTrim(this);
            if (string.IsNullOrEmpty(TxtMc.Text))
            {
                ClsMsgBox.Ts("费率名称不允许为空！", this, TxtMc, ObjG.CustomMsgBox);
                return;
            }
            if (!PriIsDefault  && chkB.Checked)
            {
                if (ClsRWMSSQLDb.GetDataTable("select id from Tfmssxfflpc where isdefault='1'", ClsGlobals.CntStrTMS).Rows.Count > 0)
                {
                    ClsMsgBox.Ts("已存在默认费率！", ObjG.CustomMsgBox, this);
                    return;
                }
            }
            if (BdsMX.Count == 0)
            {
                ClsMsgBox.Ts("请添加明细！", this, BtnNew, ObjG.CustomMsgBox);
                return;
            }
            try
            {
                BdsMX.CancelEdit();
                Bds.EndEdit();
                TableAdapterManager1.UpdateAll(DSdsksxffl1);
                this.DialogResult = DialogResult.OK;
                this.Close();
                ClsMsgBox.Ts("保存成功！", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("重复"))
                {
                    ClsMsgBox.Cw("费率信息维护重复！", ObjG.CustomMsgBox, this);
                    return;
                }
                ClsMsgBox.Cw("保存失败！", ex, ObjG.CustomMsgBox, this);
            }

        }
        #endregion

        #region 删除
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (BdsMX.Current == null)
            {
                ClsMsgBox.Ts("没有需要删除的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsMsgBox.YesNo("确定要删除该条费率吗？", new EventHandler(DeleteFlMx), ObjG.CustomMsgBox, this);
        }
        private void DeleteFlMx(object sender, EventArgs e)
        {
            frm = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {
                try
                {
                    BdsMX.RemoveCurrent();
                    BdsMX.MoveNext();
                    ClsMsgBox.Ts("删除信息成功！", frm, this);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("删除信息失败！", ex, frm, this);
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

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv.Rows.Count <= 0)
            {
                ClsMsgBox.Ts("没有需要编辑的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            BtnEdit.PerformClick();
        }

       
    }
}