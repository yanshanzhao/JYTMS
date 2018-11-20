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
using TMS.SelectFrm; 
using FMS.JCSJ.WDXXWH;
using JY.Pub;
using JYPubFiles.Classes;

#endregion

namespace FMS.WDXXWH
{
    public partial class FrmWDXX : Gizmox.WebGUI.Forms.UserControl
    {
        private ClsG ObjG; 
        private DSWDXX.TwdmxRow Prirow;
        public FrmWDXX()
        {
            InitializeComponent();
        }

        #region 初始化数据
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
        }
        #endregion

        #region 查询 Btn_Query_Click(object sender, EventArgs e)
        private void Btn_Query_Click(object sender, EventArgs e)
        {
            string SWhere = " WHERE 1=1 ";
            if (!string.IsNullOrEmpty(TxtWdmc.Text.Trim()))
            {
                SWhere += " and wdmc='" + TxtWdmc.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(TxtDqmc.Text.Trim()))
            {
                SWhere += " and mc='" + TxtDqmc.Text.Trim() + "'";
            }  
            v_wdTableAdapter1.FillByWhere(dswdxx1.v_wd, SWhere);
        }
        #endregion

        #region 新增 BtnNew_Click(object sender, EventArgs e)
        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmWDXXMX f = new FrmWDXXMX();
            f.Prapare(-1, EnumNEDD.New);
            f.ShowDialog();
        }
        #endregion

        #region 编辑 BtnEdit_Click(object sender, EventArgs e)
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            DSWDXX.v_wdRow PriRow = ((DataRowView)Bds.Current).Row as DSWDXX.v_wdRow;
            FrmWDXXMX f = new FrmWDXXMX();
            f.Prapare(PriRow.id, EnumNEDD.Edit);
            f.ShowDialog();
        }
        #endregion

        #region 删除 BtnDelete_Click(object sender, EventArgs e)
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            ClsMsgBox.YesNo("是否删除网点信息？", new EventHandler(DeleteWDXX), ObjG.CustomMsgBox, this);
        }
        private void DeleteWDXX(object sender, EventArgs e)
        {
            FrmMsgBox f = new FrmMsgBox();
            Form f1 = sender as Form;
            string sql = " DELETE FROM Twdmx WHERE (pcid = '" + Prirow.id + "'); DELETE FROM TImport WHERE (id = '" + Prirow.id + "')";
            try
            {
                if (f1.DialogResult == DialogResult.Yes)
                {
                    ClsRWMSSQLDb.ExecuteCmd(sql, TableAdapterManager1.Connection.ConnectionString = ClsGlobals.CntStrTMS);
                    ClsMsgBox.Ts("删除成功", f, this);
                    Bds.RemoveCurrent();
                }
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("删除失败！", ex, f, this);
            }
        }
        #endregion

        #region 大区按钮的点击事件 BtnSeleDq_Click(object sender, EventArgs e)
        private void BtnSeleDq_Click(object sender, EventArgs e)
        {
            FrmSelectDq f = new FrmSelectDq();
            f.Preapre();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }
        #endregion

        #region 关闭按钮
        void f_FormClosed(object sender, Gizmox.WebGUI.Forms.FormClosedEventArgs e)
        {
            FrmSelectDq frm = sender as FrmSelectDq;
            if (frm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.OK)
            {
                TxtDqmc.Text = frm.PubDictAttrs["dqmc"];
                TxtDqmc.Tag = frm.PubDictAttrs["dqid"]; 
            }
            else
            {
                TxtDqmc.Text = "";
                TxtDqmc.Tag = "";
            }
        }
        #endregion
    }
}