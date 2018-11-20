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
using JY.Pub;
using JY.Pri;
using FMS.DSKGL.DSKKHFLWH.DSDSKKHFLWHTableAdapters;
#endregion

namespace FMS.DSKGL.DSKKHFLWH
{
    public partial class FrmKHFLBJ : Form
    {
        #region 成员变量
        private ClsG ObjG;
        private BindingSource Bds;
        private DSDSKKHFLWH.VfmsdskkhflwhRow PriRow;
        private DSDSKKHFLWH DSDSKKHFLWH1;
        private VfmsdskkhflwhTableAdapter VfmsdskkhflwhTableAdapter1;
        private int PriOldFlid = 0;
        private int PriNewFlid = 0;
        private int PriZhid = 0;
        private string PriZhxm = "";
        private string PriZhLengName = "";
        #endregion
        public FrmKHFLBJ()
        {
            InitializeComponent();
        }
        public void Prepare(BindingSource aBds)
        {
            Bds = aBds;
            PriRow = ((DataRowView)Bds.Current).Row as DSDSKKHFLWH.VfmsdskkhflwhRow;
            DSDSKKHFLWH1 = new DSDSKKHFLWH();
            DataTable dtyhlx = ClsRWMSSQLDb.GetDataTable(" select id,mc from Tfmssxfflpc   ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbFl, dtyhlx, "id", "mc");
            VfmsdskkhflwhTableAdapter1 = new VfmsdskkhflwhTableAdapter();
            Rebind();
            ObjG = Session["ObjG"] as ClsG;
            PriOldFlid = Convert.ToInt32(CmbFl.SelectedValue);
            PriZhid = ObjG.Renyuan.id;
            PriZhxm = ObjG.Renyuan.xm;
            PriZhLengName = ObjG.Renyuan.loginName;
        }
        #region 绑定数据
        private void Rebind()
        {
            this.TxtBh.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "bh", true,
            Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtMc.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "mc", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtLhh.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "lhh", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.CmbFl.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("SelectedValue", this.Bds, "flid", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
        }
        #endregion
        #region 确认
        private void BtnQery_Click(object sender, EventArgs e)
        {
            try
            {
                PriNewFlid = Convert.ToInt32(CmbFl.SelectedValue);
                if (PriNewFlid != PriOldFlid)
                {
                //    ClsMsgBox.Ts("请选择要修改的费率类型！", ObjG.CustomMsgBox, this);
                //    return;
                //}
                //else
                //{
                    string aSQlCmd = " insert into tfmsdskkhflwhlog(khid,oldflid,newflid,czyid,czyxm,czyzh,inssj)  values(" + PriRow.id + "," + PriOldFlid + "," + PriNewFlid + "," + PriZhid + ",'" + PriZhxm + "','" + PriZhLengName + "',getdate()) ";
                    ClsRWMSSQLDb.GetInt(aSQlCmd, ClsGlobals.CntStrTMS);
                }
                Bds.EndEdit();
                VfmsdskkhflwhTableAdapter1.Update(PriRow);
                this.DialogResult = DialogResult.OK;
                this.Close();
                ClsMsgBox.Ts("修改成功！", ObjG.CustomMsgBox, this);
            }
            catch (Exception)
            {
                ClsMsgBox.Ts("修改失败！", ObjG.CustomMsgBox, this);
            }
        }
        #endregion
        #region 取消
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        #endregion       
    }
}