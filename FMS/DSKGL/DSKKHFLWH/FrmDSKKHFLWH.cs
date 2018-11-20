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
#endregion

namespace FMS.DSKGL.DSKKHFLWH
{
    public partial class FrmDSKKHFLWH : UserControl
    {
        #region 成员变量
        private ClsG ObjG; 
        private DSDSKKHFLWH.VfmsdskkhflwhRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as DSDSKKHFLWH.VfmsdskkhflwhRow;
                }
            }
        }
        #endregion
        public FrmDSKKHFLWH()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            this.VfmsdskkhflwhTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }
        #region 查询
        private void BtnSave_Click(object sender, EventArgs e)
        {
            ClsD.TextBoxTrim(this);
            if (string.IsNullOrWhiteSpace(TxtFwkh.Text))
            {
                ClsMsgBox.Ts("请输入服务卡号！", ObjG.CustomMsgBox, this);
                return;
            }
            this.VfmsdskkhflwhTableAdapter1.FillByWhere(this.DSDSKKHFLWH1.Vfmsdskkhflwh, " where bh like '" + TxtFwkh.Text + "' ");
            if (Dgv.Rows.Count == 0)
                ClsMsgBox.Ts("没有要查询的信息，请核对查询条件！",ObjG.CustomMsgBox,this);
        }
        #endregion

        #region 双击
        private void Dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (PriRow == null)
            {
                ClsMsgBox.Ts("请选择要修该的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            FrmKHFLBJ f = new FrmKHFLBJ();
            f.Prepare(Bds);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmKHFLBJ f = sender as FrmKHFLBJ;
            if (f.DialogResult != DialogResult.OK)
                Bds.CancelEdit();
        }
        #endregion

        #region 单选
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1)
                return;
            if (e.ColumnIndex == 4)//修改信息
            {
                FrmKHFLBJ f = new FrmKHFLBJ();
                f.Prepare(Bds);
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
                f.ShowDialog();
            }
        }
        #endregion    
    }
}