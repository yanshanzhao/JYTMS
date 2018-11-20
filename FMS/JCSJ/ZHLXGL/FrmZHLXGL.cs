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
using JYPubFiles.Classes;

#endregion

namespace FMS.JCSJ.ZHLXGL
{
    public partial class FrmZHLXGL : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private DSZHLXGL.tzhlxRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as DSZHLXGL.tzhlxRow;
                }
            }
        }
        #endregion

        public FrmZHLXGL()
        {
            InitializeComponent();
        }
        #region Prepare()
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            //PnlBtns.BackColor = ClsOptions.WebCfg.PnlBtnsColor;
            TzhlxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.TzhlxTableAdapter1.Fill(this.DSZHLXGL1.tzhlx);
        }
        #endregion
        #region 新增
        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmNewZhlx f = new FrmNewZhlx();
            f.Prepare(EnumNEDD.New, Bds, ObjG);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmNewZhlx f = sender as FrmNewZhlx;
            if (f.DialogResult != DialogResult.OK)
            {
                if (f.PubEnumNEDD == EnumNEDD.New)
                    Bds.RemoveCurrent();
                else if (f.PubEnumNEDD == EnumNEDD.Edit)
                    Bds.CancelEdit();
                DSZHLXGL1.RejectChanges();
                //this.TzhlxTableAdapter1.Fill(this.DSZHLXGL1.tzhlx);
            }
        }
        #endregion
        #region 编辑
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (PriRow == null)
            {
                ClsMsgBox.Ts("没有要编辑的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            FrmNewZhlx f = new FrmNewZhlx();
            f.Prepare(EnumNEDD.Edit, Bds, ObjG);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }
        #endregion
        #region 删除
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (PriRow == null)
            {
                ClsMsgBox.Ts("没有要删除的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            //if (ClsRWMSSQLDb.Exists(" select  zhlxid from tyhzh  where zhlxid=" + PriRow.id, ClsGlobals.CntStrFMS))
            //{
            //    ClsMsgBox.Jg("该账户类型已经使用，不能删除！");
            //    return;
            //}
            ClsMsgBox.YesNo("确定要删除该银行类型吗？", new EventHandler(Deleting), ObjG.CustomMsgBox, this);
        }
        private void Deleting(object sender, EventArgs e)
        {
            Form f = sender as Form;
            FrmMsgBox frm = new FrmMsgBox();
            if (f.DialogResult == DialogResult.Yes)
            {
                try
                {
                    TzhlxTableAdapter1.DeleteById(PriRow.id);
                    Bds.RemoveCurrent();
                    DSZHLXGL1.AcceptChanges();
                    ClsMsgBox.Ts("删除成功！", frm, this);
                    ClsD.TurnToBdsPosPage(Dgv);
                }
                catch (Exception ex)
                {
                    string ExStr = ex.Message;
                    if (ExStr.LastIndexOf("REFERENCE") > 0) 
                        ClsMsgBox.Ts(PriRow.mc + "类型正在使用，不能删除",frm,this); 
                    else
                        ClsMsgBox.Cw("删除失败！", ex, frm, this);
                }
            }
        }
        #endregion
        #region 双击Dgv
        private void Dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (PriRow == null)
                return;
            BtnEdit.PerformClick();
        }
        #endregion
    }
}