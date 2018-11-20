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
using JY.Pub;
using JYPubFiles.Classes;
using FMS.SeleFrm;

#endregion

namespace FMS.ZYGL.JGGXWH
{
    public partial class FrmJGGXWH : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private FrmSelectJg PriFrmSelectJg;
        private DSJGGXWH.VfmsjggxRow PriJggxRow
        {
            get
            {
                if (Bds.Current == null)
                    return null;
                return ((DataRowView)Bds.Current).Row as DSJGGXWH.VfmsjggxRow;
            }
            set
            {
                PriJggxRow = value;
            }
        }
        private string PriWhere;
        #endregion
        public FrmJGGXWH()
        {
            InitializeComponent();
        }
        #region 初始化数据
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            VfmsjggxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            ClsPopulateCmbDsS.PopuFMS_Jggx(CmbGxzl);
        }
        #endregion

        #region 新增
        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmJGGXMX f = new FrmJGGXMX();
            f.Prepare(Bds, EnumNEDD.New);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmJGGXMX f = sender as FrmJGGXMX;
            if (f.DialogResult != DialogResult.OK && f.PubEnumNEDD == EnumNEDD.New)
            {
                this.Bds.RemoveCurrent();
                this.Bds.CancelEdit();
            }
            else if (f.DialogResult != DialogResult.OK)
            {
                this.Bds.CancelEdit();
            }
            DSjggxwh1.RejectChanges();
            TxtJl.Text = "共有" + Bds.Count + "条信息";
        }
        #endregion

        #region 编辑
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (PriJggxRow == null)
            {
                ClsMsgBox.Ts("没有可编辑的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            FrmJGGXMX f = new FrmJGGXMX();
            f.Prepare(Bds, EnumNEDD.Edit);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }
        #endregion

        #region 删除
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (PriJggxRow == null)
            {
                ClsMsgBox.Ts("没有要删除的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsMsgBox.YesNo("确定要删除该机构关系吗？", new EventHandler(JGGX_Delete), ObjG.CustomMsgBox, this);
        }
        public void JGGX_Delete(object sender, EventArgs e)
        {
            Form f = sender as Form;
            FrmMsgBox frm = new FrmMsgBox();
            if (f.DialogResult == DialogResult.Yes)
            {
                try
                {
                    VfmsjggxTableAdapter1.DeleteById(PriJggxRow.id);
                    Bds.RemoveCurrent();
                    DSjggxwh1.AcceptChanges();
                    ClsMsgBox.Ts("删除成功！", frm, this);
                    ClsD.TurnToBdsPosPage(Dgv);
                    TxtJl.Text = "共有" + Bds.Count + "条信息";
                }
                catch (Exception ex)
                {
                    string ExStr = ex.Message;
                    if (ExStr.LastIndexOf("REFERENCE") > 0)
                        ClsMsgBox.Ts(PriJggxRow.jgmc + "正在使用，不能删除", frm, this);
                    else
                        ClsMsgBox.Cw("删除失败！", ex, frm, this);
                }
            }
        }
        #endregion

        #region 机构选择
        private void BtnYjg_Click(object sender, EventArgs e)
        {
            PriFrmSelectJg = new FrmSelectJg();
            PriFrmSelectJg.Prepare();
            PriFrmSelectJg.ShowDialog();
            PriFrmSelectJg.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmJGCX1_FormClosed);
        }
        private void FrmJGCX1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
                this.TxtYjg.Text = f.PubDictAttrs["mc"];
            else if (f.DialogResult == DialogResult.No)
                this.TxtYjg.Text = "";
            f.Dispose();
        }

        private void BtnGxjg_Click(object sender, EventArgs e)
        {
            PriFrmSelectJg = new FrmSelectJg();
            PriFrmSelectJg.Prepare();
            PriFrmSelectJg.ShowDialog();
            PriFrmSelectJg.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(FrmJGCX2_FormClosed);
        }
        private void FrmJGCX2_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (FrmSelectJg f = sender as FrmSelectJg)
            {
                if (f.DialogResult == DialogResult.OK)
                    this.TxtGxjg.Text = f.PubDictAttrs["mc"];
                else if (f.DialogResult == DialogResult.No)
                    this.TxtGxjg.Text = "";
            }
        }
        #endregion

        #region 查询
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PriWhere = "  ";
            PriWhere += CmbGxzl.SelectedIndex == 0 ? "" : " and gxzl='" + CmbGxzl.SelectedValue + "'";
            PriWhere += string.IsNullOrEmpty(TxtYjg.Text.Trim()) ? "" : " and jgmc like '%" + TxtYjg.Text.Trim() + "%'";
            PriWhere += string.IsNullOrEmpty(TxtGxjg.Text.Trim()) ? "" : " and tojgmc like '%" + TxtGxjg.Text.Trim() + "%'";
            PriWhere = PriWhere.Trim();
            if (PriWhere.Length > 0)
                PriWhere = " where " + PriWhere.Remove(0, 3);
          
            try
            {
                VfmsjggxTableAdapter1.FillByWhere(DSjggxwh1.Vfmsjggx, PriWhere);
                TxtJl.Text = "共有" + Bds.Count + "条信息";
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("查询信息失败！", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion
        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！",ObjG.CustomMsgBox,this);
                return;
            }
            ClsExcel.CreatExcel(Dgv,"机构关系",this.ctrlDownLoad1);            

        }
        #endregion

    }
}