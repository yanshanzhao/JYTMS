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
using System.Collections;
using System.Data.SqlClient;
using FMS.SeleFrm;
using FMS.CWGL.XTWSR;
using FMS.CWGL.XTWSR.DSXTWSRTableAdapters;
using Gizmox.WebGUI.Forms;

#endregion

namespace FMS.ZYGL.XTWSRLX
{
    public partial class FrmXTWSRMX : Form
    {
        public FrmXTWSRMX()
        {
            InitializeComponent();
        }
        private ClsG ObjG;
        private DataTable PriDtJsgx;
        public EnumNEDD PubEnumNEDD;
        private string PriConStr;
        private DSXTWSR.VfmsxtwsrRow PriRow;
        private BindingSource Bds;
        private FMS.CWGL.XTWSR.DSXTWSRTableAdapters.VfmsxtwsrTableAdapter VfmsxtwsrTableAdapter1;
        public FrmXTWSR XTB = null;
        public void Prepare(EnumNEDD enumNedd, BindingSource bds)
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            //ClsPopulateCmbDsS.PopuFMSLX_xtwsrlx(CmbLx);
            //this.CmbLx.SelectedIndex = 0;
            PriConStr = ClsGlobals.CntStrTMS;
            DataTable dt = ClsRWMSSQLDb.GetDataTable("SELECT id,name FROM dbo.Tfmsxtwsr_lx where  bh NOT IN ('gbf') and zt=0  ORDER BY sort ", PriConStr);
            this.CmbLx.DataSource = dt;
            this.CmbLx.DisplayMember = "name";
            this.CmbLx.ValueMember = "id";
            this.CmbLx.SelectedIndex = 0;
            this.PubEnumNEDD = enumNedd;
            this.Bds = bds;
            this.VfmsxtwsrTableAdapter1 = new VfmsxtwsrTableAdapter();
            this.VfmsxtwsrTableAdapter1.Connection.ConnectionString = PriConStr;
            DataBind();
            if (PubEnumNEDD == EnumNEDD.New)
            {
                this.Bds.AddNew();
                PriRow = (DSXTWSR.VfmsxtwsrRow)((DataRowView)(Bds.Current)).Row;
                PriRow.inssj = DateTime.Now;
                PriRow.sqr = ObjG.Renyuan.xm;
                PriRow.zzjgid = ObjG.Jigou.id;
                TxtGzjg.Text = ObjG.Jigou.mc;
                TxtGzjg.Tag = ObjG.Jigou.id;
                PriRow.zt = 0;
            }
            if (PubEnumNEDD == EnumNEDD.Edit)
            {
                PriRow = (DSXTWSR.VfmsxtwsrRow)((DataRowView)(Bds.Current)).Row;
                TxtGzjg.Text = PriRow.zzjg;
                TxtGzjg.Tag = PriRow.zzjgid.ToString();
            }
            PriDtJsgx = ClsRWMSSQLDb.GetDataTable(" select tojgid,tojgmc from vfmsjggx where gxzl='X' and jgid=" + ObjG.Jigou.id, ClsGlobals.CntStrTMS);
            if (PriDtJsgx.Rows.Count == 1)
            {
                lblSpjg.Text = PriDtJsgx.Rows[0]["tojgmc"].ToString();
                lblSpjg.Tag = PriDtJsgx.Rows[0]["tojgid"].ToString();
            }
        }
        #region 数据源绑定
        public void DataBind()
        {
            this.TxtJe.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "je", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.CmbLx.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("SelectedValue", this.Bds, "lxid", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtBz.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "bz", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtYwdh.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "ywdh", true,
              Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            //this.TxtSqr.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "sqr", true,
            //    Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
        }

        #endregion
        #region 取消
        private void BtnQuXiao_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region 保存
        private void BtnSave_Click(object sender, EventArgs e)
        {
            #region 验证
            if (string.IsNullOrEmpty(lblSpjg.Text.Trim()))
            {
                ClsMsgBox.Ts("本机构无结算（系统外）关系请联系管理员！", this, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtJe.Text))
            {
                ClsMsgBox.Ts("金额不能为空！", this, TxtJe, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtBz.Text))
            {
                ClsMsgBox.Ts("备注不能为空！", this, TxtBz, ObjG.CustomMsgBox);
                return;
            }
            if (this.TxtGzjg.Tag == "0")
            {
                ClsMsgBox.Ts("申请挂账机构不能为空！", this, BtnSeleJG, ObjG.CustomMsgBox);
                return;
            }
            if (this.TxtGzjg.Text.Trim().Length == 0)
            {
                ClsMsgBox.Ts("申请挂账机构不能为空！", this, BtnSeleJG, ObjG.CustomMsgBox);
                return;
            }

            if (CmbLx.Text.LastIndexOf("录入错误") >= 0 || CmbLx.Text.LastIndexOf("未提货") >= 0 || CmbLx.Text.LastIndexOf("调整费") >= 0)
            {
                if (string.IsNullOrEmpty(TxtYwdh.Text))
                {
                    ClsMsgBox.Ts("业务单号不能为空！", this, TxtBz, ObjG.CustomMsgBox);
                    return;
                }
            }

            #endregion
            try
            {
                ArrayList als = new ArrayList();
                als.Add(new SqlParameter("@tbln", "Tfmsxtwsr"));
                als.Add(new SqlParameter("@currq", DateTime.Now.Date));
                als.Add(new SqlParameter("@return", SqlDbType.Int));
                ((SqlParameter)als[2]).Direction = ParameterDirection.ReturnValue;
                ClsRWMSSQLDb.ExecuteCmd("PGetLsh", ClsGlobals.CntStrTMS, als, true);
                string lsh = ((SqlParameter)als[2]).Value.ToString().PadLeft(4, '0');
                if (lsh.Equals("0000"))
                {
                    ClsMsgBox.Ts("生成流水号错误！", ObjG.CustomMsgBox, this);
                    return;
                }
                if (PubEnumNEDD == EnumNEDD.New)
                    PriRow.lsh = DateTime.Now.ToString("yyyyMMdd") + lsh;
                PriRow.zzjgid = Convert.ToInt32(TxtGzjg.Tag);
                PriRow.sqrid = ObjG.Renyuan.id;
                PriRow.sqrzh = ObjG.Renyuan.loginName;
                //PriRow.zt = 0;
                PriRow.spjgid = Convert.ToInt32(lblSpjg.Tag);
                this.Bds.EndEdit();
                VfmsxtwsrTableAdapter1.Update(PriRow);
                this.DialogResult = DialogResult.OK;
                this.Close();
                ClsMsgBox.Ts("保存成功！！", ObjG.CustomMsgBox, this);

            }
            catch (Exception ex)
            {
                string ExS = ex.Message;
                if (ExS.LastIndexOf("重复") > 0)
                {
                    ClsMsgBox.Ts("保存失败！！", ObjG.CustomMsgBox, this);
                }
                else
                {
                    ClsMsgBox.Cw("保存失败！！", ex, ObjG.CustomMsgBox, this);

                }
            }
        }
        #endregion

        private void BtnSeleJG_Click(object sender, EventArgs e)
        {
            FrmSelectJg2 f = new FrmSelectJg2();
            f.ShowDialog();
            f.Prepare();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg2 f = sender as FrmSelectJg2;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtGzjg.Text = f.PubDictAttrs["mc"];
                this.TxtGzjg.Tag = f.PubDictAttrs["id"];
            }
            else
            {
                this.TxtGzjg.Text = "";
                this.TxtGzjg.Tag = 0;
            }
        }
    }
}
