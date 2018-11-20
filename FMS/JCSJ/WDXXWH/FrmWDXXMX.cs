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
using System.Data.SqlClient;
using JY.Pub;
using JY.Pri;
using System.Collections;
using FMS.JCSJ.WDXXWH;
using TMS.SelectFrm;
using JYPubFiles.CtrlPub;

#endregion

namespace FMS.WDXXWH
{
    public partial class FrmWDXXMX : Form
    {
        #region 全局变量
        private ClsG ObjG;
        private int PriId;
        private EnumNEDD PriEnumNEDD;
        private DSWDXX.v_wdRow PriWdRow;
        DSWDXX.TwdmxRow PriMxRow;
        List<int> PriLsId = new List<int>();
        #endregion

        public FrmWDXXMX()
        {
            InitializeComponent();
        }

        #region 初始化数据 Prapare(int aPcid, EnumNEDD aEnumNEDD)
        public void Prapare(int aPcid, EnumNEDD aEnumNEDD)
        {
            ObjG = Session["ObjG"] as ClsG;
            FrmTrv.Prepare(1);
            PriId = aPcid;
            PriEnumNEDD = aEnumNEDD;
            Bind();
            if (PriEnumNEDD == EnumNEDD.New)
            {
                Bds.AddNew();
                BdsMx.AddNew();
            }
            if (PriEnumNEDD == EnumNEDD.Edit)
            {
                v_wdTableAdapter1.FillById(dswdxx1.v_wd, PriId);
                twdmxTableAdapter1.FillById(dswdxx1.Twdmx, PriId);
            }
            PriWdRow = ((DataRowView)Bds.Current).Row as DSWDXX.v_wdRow;
            PriMxRow = ((DataRowView)BdsMx.Current).Row as DSWDXX.TwdmxRow;
            if (PriEnumNEDD == EnumNEDD.Edit)
            {
                TxtDqmc.Text = PriWdRow.mc;
                TxtWdmc.Text = PriWdRow.wdmc;
                TxtWdbz.Text = PriWdRow.bz;
                if (PriWdRow.zt == 0)
                    RBtnYx.Checked = true;
                else
                    RBtnWx.Checked = true;
            }
        }

        #region 数据绑定
        private void Bind()
        {
            this.TxtWdmc.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "wdmc", true,
               Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtWdbz.DataBindings.Clear();
            this.TxtWdbz.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "bz", true,
               Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
        }
        #endregion
        #endregion

        #region 大区名称的click事件 BtnSeleDq_Click(object sender, EventArgs e)
        private void BtnSeleDq_Click(object sender, EventArgs e)
        {
            FrmSelectDq f = new FrmSelectDq();
            f.Preapre();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();

        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectDq frm = sender as FrmSelectDq;
            if (frm.DialogResult == DialogResult.OK)
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

        #region 保存 BtnSave_Click(object sender, EventArgs e)
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtWdmc.Text))
            {
                ClsMsgBox.Ts("网点名称不能为空！", ObjG.CustomMsgBox, this);
                return;
            }
            if (string.IsNullOrEmpty(TxtDqmc.Text))
            {
                ClsMsgBox.Ts("大区名称不能为空！", ObjG.CustomMsgBox, this);
                return;
            }
            PriWdRow.dqid = Convert.ToInt32(TxtDqmc.Tag);
            if (RBtnYx.Checked)
                PriWdRow.zt = 0;
            else if (RBtnWx.Checked)
                PriWdRow.zt = 1;
            Bds.EndEdit();
            foreach (TreeNode node in FrmTrv.Trv.Nodes)
            {
                getnodes(node);
                foreach (int item in PriLsId)
                {
                    PriMxRow.jgid = item;
                    BdsMx.EndEdit();
                }
            }
            //tableAdapterManager1.UpdateAll(dswdxx1);
            v_wdTableAdapter1.Update(PriWdRow);
            this.DialogResult = DialogResult.OK;
            this.Close();
            ClsMsgBox.Ts("保存成功！", ObjG.CustomMsgBox, this);
        }
        public void getnodes(TreeNode node)
        {
            if (node.HasNodes)
            {
                foreach (TreeNode node1 in node.Nodes)
                {
                    if (node1.Checked)
                    {
                        PriLsId.Add(Convert.ToInt32(node1.Name));
                    }
                    else
                    {
                        getnodes(node1);
                    }
                }
            }
        }
        #endregion

        #region 取消按钮 BtnCal_Click(object sender, EventArgs e)
        private void BtnCal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}