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
using FMS.JCSJ.DQXX.DSQSXXTableAdapters;



#endregion

namespace FMS.JCSJ.DQXX
{
    public partial class FrmDQXXMX : Form
    {
        #region 成员变量
        private string PriConStr; //数据库连接字符串
        private ClsG ObjG;
        public EnumNEDD PubEnumNEDD;
        private DSQSXX.TdqRow PriRow;
        private TdqTableAdapter  PriTdq;

  
        public int PubId;
        private BindingSource PriBds;
        #endregion
        public FrmDQXXMX()
        {
            InitializeComponent();
        }
        public void Prepare(int aPriId, EnumNEDD aEnumNEDD, BindingSource aPriBds)
        {
            PubId = aPriId;
            PubEnumNEDD = aEnumNEDD;
            PriBds = aPriBds;
         
            PriTdq = new TdqTableAdapter();
            PriConStr = ClsGlobals.CntStrTMS;
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            Bind();
            if (PubEnumNEDD == EnumNEDD.New)
            {
                PriBds.AddNew();
            }
            PriRow = ((DataRowView)(PriBds.Current)).Row as DSQSXX.TdqRow;
        }
        #region 绑定
        private void Bind()
        {
            this.TxtFL.DataBindings.Clear();
            this.TxtFL.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "mc", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
             this.TxtBZ.DataBindings.Clear();
            this.TxtBZ.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "bh", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtSxfsx.DataBindings.Clear();
            this.TxtSxfsx.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "sm", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
           
        }
        #endregion
        private void BtnSave_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(TxtFL.Text))
            {
                ClsMsgBox.Ts("名称不能为空！", this, TxtFL, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtSxfsx.Text))
            {
                ClsMsgBox.Ts("编号不能为空！", this, TxtSxfsx, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtBZ.Text))
            {
                ClsMsgBox.Ts("说明不能为空", this, TxtBZ, ObjG.CustomMsgBox);
                return;
            }
          
           
            try
            {
                PriBds.EndEdit();
               
                
                PriTdq.Update(PriRow);
                this.DialogResult = DialogResult.OK;
                this.Close();
                ClsMsgBox.Ts("保存成功！费率名称");
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("保存信息失败，请检查数据！", ex, ObjG.CustomMsgBox, this);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}