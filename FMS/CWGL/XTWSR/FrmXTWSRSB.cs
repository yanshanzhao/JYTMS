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
using FMS.CWGL.XTWSR;
using FMS.SelectFrm;
using TMS.SelectFrm;

#endregion

namespace FMS.ZYGL.XTWSRLX
{
    public partial class FrmXTWSR : UserControl
    {
        public FrmXTWSR()
        {
            InitializeComponent();
        }
        private DSXTWSR.VfmsxtwsrRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                    return null;
                return ((DataRowView)Bds.Current).Row as DSXTWSR.VfmsxtwsrRow;
            }
            set
            {
                PriRow = value;
            }
        }
        private ClsG ObjG;
        private DateTime PriDptStart = DateTime.Now;
        private DateTime PriDptEnd = DateTime.Now;
        public void Prepare()
        {
            this.VfmsxtwsrTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            DSXTWSR1.EnforceConstraints = false;
            DataTable dt = ClsRWMSSQLDb.GetDataTable("  SELECT -1 id,'-全部-'name,0  sort    UNION ALL   SELECT id,name ,sort FROM dbo.Tfmsxtwsr_lx  where  bh NOT IN ('gbf') and zt=0  ORDER BY sort ", ClsGlobals.CntStrTMS);
            this.CmbLx.DataSource = dt;
            this.CmbLx.DisplayMember = "name";
            this.CmbLx.ValueMember = "id";
            this.CmbLx.SelectedIndex = 0;
            CmbShzt.SelectedIndex = 2;
            Txtsqjg.Tag = "0";
            TxtSqdq.Tag = "0";
        }
        #region 查询
        private void BtnSel_Click(object sender, EventArgs e)
        {
            string aWhere = " where  inssj> '" + DtpQrStart.Value.Date + "' and inssj<='" + DtpQrStop.Value.Date.AddDays(1) + "'   ";
            aWhere = aWhere + " and sqrid IN (SELECT id FROM jyjckj.dbo.trenyuan WHERE jgid=" + ObjG.Jigou.id + " )";
            if (CmbLx.SelectedIndex != 0)
                aWhere += " and lxid='" + CmbLx.SelectedValue + "' ";
            if (CmbShzt.SelectedIndex > 0)
                aWhere += " and zts='" + CmbShzt.Text + "' ";
            //aWhere += " and inssj> '" + DtpQrStart.Value.Date + "' and inssj<='" + DtpQrStop.Value.Date.AddDays(1) + "'";
            this.VfmsxtwsrTableAdapter1.FillByWhere(DSXTWSR1.Vfmsxtwsr, aWhere);
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("没有要查询的信息！", ObjG.CustomMsgBox, this);
            }
        }
        #endregion



        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmXTWSRMX f = sender as FrmXTWSRMX;
            if (f.DialogResult != DialogResult.OK && f.PubEnumNEDD == EnumNEDD.New)
            {
                this.Bds.RemoveCurrent();
                this.Bds.CancelEdit();
            }
            else if (f.DialogResult != DialogResult.OK)
            {
                this.Bds.CancelEdit();

            }
            DSXTWSR1.RejectChanges();
        }


        #region 新增
        private void BtnNew_Click_1(object sender, EventArgs e)
        {
            FrmXTWSRMX f = new FrmXTWSRMX();
            f.Prepare(EnumNEDD.New, this.Bds);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.XTB = this;
            f.ShowDialog();
        }
        #endregion

        #region 修改
        private void BtnEdit_Click_1(object sender, EventArgs e)


        { 

            if (Bds.Current == null)
                return; 
            string sql = string.Format(" select id from  Vfmsxtwsr where id='{0}'  and zt=0  ", PriRow.id);
            DataTable dt = ClsRWMSSQLDb.GetDataTable(sql, ClsGlobals.CntStrTMS);
            if (dt.Rows.Count == 0)
            {
                ClsMsgBox.Ts("该条信息已审核过，无法修改！", ObjG.CustomMsgBox, this);
                return;
            }
            FrmXTWSRMX f = new FrmXTWSRMX();
            f.Prepare(EnumNEDD.Edit, this.Bds);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }
        #endregion

        #region 删除
        private void BtnDel_Click_1(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return; 
            if (PriRow.zt != 0)
            {
                ClsMsgBox.Ts("该条信息已审核过，无法删除！", ObjG.CustomMsgBox, this);
                return;
            }
            string sql = string.Format(" select id from  Vfmsxtwsr where id='{0}'  and zt=0  ", PriRow.id);

            DataTable dt = ClsRWMSSQLDb.GetDataTable(sql, ClsGlobals.CntStrTMS);
            if (dt.Rows.Count == 0)
            {
                ClsMsgBox.Ts("该条信息已审核过，无法删除！", ObjG.CustomMsgBox, this);
                return;
            } 
            ClsMsgBox.YesNo("是否删除信息？", new EventHandler(Delete), ObjG.CustomMsgBox, this);
        }
        private void Delete(object sender, EventArgs e)
        {
            FrmXTWSRLXMX f = new FrmXTWSRLXMX();
            Form frm = sender as Form;
            if (frm.DialogResult == DialogResult.Yes)
            {
                try
                {

                    Bds.RemoveCurrent();
                    VfmsxtwsrTableAdapter1.Update(DSXTWSR1.Vfmsxtwsr);
                    ClsMsgBox.Ts("删除成功！", f, this);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Ts("删除失败！" + ex.ToString(), f, this);
                }
            }
        }
        #endregion

        private void Btnsldq_Click(object sender, EventArgs e)
        {

            FrmSelectJG f = new FrmSelectJG();

            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(fsqjg_FormClosing);
        }
        void fsqjg_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FrmSelectJG f = sender as FrmSelectJG)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    Txtsqjg.Text = f.PubDictAttrs["mc"].ToString();
                    Txtsqjg.Tag = f.PubDictAttrs["id"].ToString();
                }
                else
                {
                    Txtsqjg.Text = "";
                    Txtsqjg.Tag = "0";
                }
            }
        }

        private void BtnSqdq_Click(object sender, EventArgs e)
        {
            FMS.SelectFrm.FrmSelectDq f = new FMS.SelectFrm.FrmSelectDq();
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(fsqdq_FormClosing);
        }
        void fsqdq_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FMS.SelectFrm.FrmSelectDq f = sender as FMS.SelectFrm.FrmSelectDq)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    TxtSqdq.Text = f.PubDictAttrs["dqmc"].ToString();
                    TxtSqdq.Tag = f.PubDictAttrs["dqid"].ToString();
                }
                else
                {
                    TxtSqdq.Text = "";
                    TxtSqdq.Tag = "0";
                }
            }

        }
    }
}
