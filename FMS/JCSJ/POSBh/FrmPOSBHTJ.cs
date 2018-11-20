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
using FMS.JCSJ.POSBh.DSAJGCX1TableAdapters;
using TMS.SelectFrm;

#endregion

namespace FMS.JCSJ.POSBh
{
    public partial class FrmPOSBHTJ : Form
    {
        public FrmPOSBHTJ()
        {
            InitializeComponent();
        }
        //自定义变量
        private ClsG ObjG;
        public EnumNEDD PubEnumNEDD;
        private DSAJGCX1.VPosBhRow tbVPosBhRow;
        private string PriConStr;
        private BindingSource Bds;
        private DSAJGCX1TableAdapters.VPosBhTableAdapter VPosBhTableAdapter1;
        public void Prepare(int id, EnumNEDD enumNedd, BindingSource bds)
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            PriConStr = ClsGlobals.CntStrKj;
            this.PubEnumNEDD = enumNedd;
            this.Bds = bds;
            string SQl = "select id,jc from Tyhlx where id>0";
            ClsPopulateCmbDsS.PopuByTb(this.cmbyhlx, ClsRWMSSQLDb.GetDataTable(SQl, ClsGlobals.CntStrTMS), "id", "jc");

            
            this.VPosBhTableAdapter1 = new VPosBhTableAdapter();
            this.VPosBhTableAdapter1.Connection.ConnectionString = PriConStr;
            if (PubEnumNEDD == EnumNEDD.New)
            {
                this.Bds.AddNew();
                tbVPosBhRow = (POSBh.DSAJGCX1.VPosBhRow)((DataRowView)(Bds.Current)).Row;
                this.cmbyhlx.SelectedIndex = 0;
                this.cmbzt.SelectedIndex = 0;
            }
            if (PubEnumNEDD == EnumNEDD.Edit)
            {
                tbVPosBhRow = (DSAJGCX1.VPosBhRow)((DataRowView)(Bds.Current)).Row;
                this.cmbyhlx.SelectedValue = tbVPosBhRow.yhlxid;
                if (tbVPosBhRow.zt == 0)
                    this.cmbzt.SelectedIndex = 0;
                else if (tbVPosBhRow.zt == 5)
                    this.cmbzt.SelectedIndex = 1;
                else
                    this.cmbzt.SelectedIndex = 2;
                this.Txtjg.Text = tbVPosBhRow.mc;
                this.Txtjg.Tag = tbVPosBhRow.jgid;

            }
      
            DataBind();

        }
        //绑定数据源
        public void DataBind()
        {
            this.Txtpos.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text",this.Bds,"Posbh",true,Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));

        }
        //查询机构
        private void Btnjg_Click(object sender, EventArgs e)
        {
            FrmSelectJG f = new FrmSelectJG();
            f.Preapre();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJG f = sender as FrmSelectJG;
            if (f.DialogResult == DialogResult.OK)
            {
                this.Txtjg.Text = f.PubDictAttrs["mc"];
                this.Txtjg.Tag = Convert.ToInt32(f.PubDictAttrs["id"]);
            }
        }
        private void Txtjg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                tbVPosBhRow.id = 0;
                Txtjg.Clear();
            }
        }
        //取消
        private void Btnqx_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //保存
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            #region
            //验证不能为空
            if (string.IsNullOrEmpty( this.Txtjg.Text.ToString()))
            {
                ClsMsgBox.Ts("机构不能为空！", this, Btnjg, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(Txtpos.Text))
            {
                ClsMsgBox.Ts("POS编号不能为空！", this, Txtpos, ObjG.CustomMsgBox);
                return;
            }
         
            if (cmbyhlx.SelectedIndex <0)
            {
                ClsMsgBox.Ts("请选择银行类型！", this, cmbyhlx, ObjG.CustomMsgBox);
                return;

            }
            #endregion
            try
            {

                if (this.cmbzt.SelectedIndex==0)
                    tbVPosBhRow.zt = 0;
                else if (this.cmbzt.SelectedIndex == 1)
                    tbVPosBhRow.zt = 5;
                else
                    tbVPosBhRow.zt = 10;


                tbVPosBhRow.jgid = Convert.ToInt32( this.Txtjg.Tag);
                tbVPosBhRow.Inssj = DateTime.Now;
                tbVPosBhRow.yhlxid = Convert.ToInt32(this.cmbyhlx.SelectedValue);
                this.Bds.EndEdit();
                VPosBhTableAdapter1.Update(tbVPosBhRow);
                this.DialogResult = DialogResult.OK;
                this.Close();
                ClsMsgBox.Ts("保存成功！", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                string ExStr = ex.Message;
                if (ExStr.LastIndexOf("重复") > 0)
                {
                    ClsMsgBox.Ts("保存失败！", ObjG.CustomMsgBox, this);
                }
                else
                {
                    ClsMsgBox.Cw("保存失败！", ex, ObjG.CustomMsgBox, this);
                }
            }
        }
    }
}