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
using FMS.JCSJ.SXFFL;
using JYPubFiles.Classes;

#endregion

namespace FMS.JCSJ.DSKKHDA.DSKSXFFLGL
{
    public partial class FrmDSKSXFFL : UserControl
    {
        #region 成员变量
        private string PriConStr; //数据库连接字符串
        private ClsG ObjG;
        #endregion
        public FrmDSKSXFFL()
        {
            InitializeComponent();
        }
        private DSDSKSXFFL.tdskflRow PriId
        {
            get
            {
                if (Bds.Current == null)
                    return null;
                else
                {
                    return (DSDSKSXFFL.tdskflRow)(((DataRowView)Bds.Current).Row);
                }
            }
        }
        public void Prepare()
        {
            //PnlBtns.BackColor = ClsOptions.WebCfg.PnlBtnsColor;
            PriConStr = ClsGlobals.CntStrTMS;
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            TdskflTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            TdskflTableAdapter1.Fill(DSDSKSXFFL1.tdskfl);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmDSKSXFFLMX f = new FrmDSKSXFFLMX();
            f.Prepare(-1, EnumNEDD.New, this.Bds);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmDSKSXFFLMX f = sender as FrmDSKSXFFLMX;
            if (f.DialogResult != DialogResult.OK)
            {
                if (f.PubEnumNEDD == EnumNEDD.New)
                    Bds.RemoveCurrent();
                else if (f.PubEnumNEDD == EnumNEDD.Edit)
                    Bds.CancelEdit();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FrmDSKSXFFLMX f = new FrmDSKSXFFLMX();
            if (Bds.Current == null)
                return;
            f.Prepare(PriId.id, EnumNEDD.Edit, this.Bds);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            ClsMsgBox.YesNo("是否删除？", new EventHandler(DeleteFL), ObjG.CustomMsgBox, this);
        }
        private void DeleteFL(object sender, EventArgs e)
        {
            Form frm = sender as Form;
            FrmMsgBox f = new FrmMsgBox();
            try
            {
                if (frm.DialogResult == DialogResult.Yes)
                {
                    TdskflTableAdapter1.DeleteById(PriId.id);
                    Bds.RemoveCurrent();
                    ClsMsgBox.Ts("删除成功！", f, this);
                }
            }
            catch (Exception ex)
            {
                string ExStr = ex.Message;
                if (ExStr.LastIndexOf("REFERENCE") > 0)
                    ClsMsgBox.Ts(PriId.mc + "类型正在使用，不能删除", frm, this);
                else
                    ClsMsgBox.Cw("遇到错误，无法删除！", f, this);
            }

        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            BtnEdit.PerformClick();
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 3, 4 };
            ClsExcel.CreatExcel(Dgv, "代收款手续费费率", this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, "代收款手续费费率", this.ctrlDownLoad1);
        }
    }
}