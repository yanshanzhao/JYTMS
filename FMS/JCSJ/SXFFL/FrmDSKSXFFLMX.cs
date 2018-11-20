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
using FMS.JCSJ.SXFFL;
using FMS.JCSJ.SXFFL.DSDSKSXFFLTableAdapters;

#endregion

namespace FMS.JCSJ.DSKKHDA.DSKSXFFLGL
{
    public partial class FrmDSKSXFFLMX : Form
    {
        #region ��Ա����
        private string PriConStr; //���ݿ������ַ���
        private ClsG ObjG;
        public EnumNEDD PubEnumNEDD;
        private DSDSKSXFFL.tdskflRow PriRow;
        private tdskflTableAdapter PriTdskflTableAdapter1;
        public int PubId;
        private BindingSource PriBds;
        #endregion
        public FrmDSKSXFFLMX()
        {
            InitializeComponent();
        }
        public void Prepare(int aPriId, EnumNEDD aEnumNEDD, BindingSource aPriBds)
        {
            PubId = aPriId;
            PubEnumNEDD = aEnumNEDD;
            PriBds = aPriBds;
            PriTdskflTableAdapter1 = new tdskflTableAdapter();
            PriConStr = ClsGlobals.CntStrTMS;
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            Bind();
            if (PubEnumNEDD == EnumNEDD.New)
            {
                PriBds.AddNew();
            }
            PriRow = ((DataRowView)(PriBds.Current)).Row as DSDSKSXFFL.tdskflRow;
        }
        #region ��
        private void Bind()
        {
            this.TxtFL.DataBindings.Clear();
            this.TxtFL.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "fl", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtBmc.DataBindings.Clear();
            this.TxtBmc.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "mc", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtBZ.DataBindings.Clear();
            this.TxtBZ.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "bz", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtSxfsx.DataBindings.Clear();
            this.TxtSxfsx.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "sxfsx", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtSxfxx.DataBindings.Clear();
            this.TxtSxfxx.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "sxfxx", true, Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
        }
        #endregion
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBmc.Text))
            {
                ClsMsgBox.Ts("���Ʋ���Ϊ�գ�", this, TxtBmc, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtFL.Text))
            {
                ClsMsgBox.Ts("���ʲ���Ϊ�գ�", this, TxtFL, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtSxfsx.Text))
            {
                ClsMsgBox.Ts("���������޲���Ϊ�գ�", this, TxtSxfsx, ObjG.CustomMsgBox);
                return;
            }
            if (!ClsRegEx.IsShiShu(TxtSxfsx.Text.Trim()))
            {
                ClsMsgBox.Ts("���������޸�ʽ����ȷ�����������룡", this, TxtSxfsx, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtSxfxx.Text))
            {
                ClsMsgBox.Ts("���������޲���Ϊ�գ�", this, TxtSxfxx, ObjG.CustomMsgBox);
                return;
            }
            if (!ClsRegEx.IsShiShu(TxtSxfxx.Text.Trim()))
            {
                ClsMsgBox.Ts("���������޸�ʽ����ȷ�����������룡", this, TxtSxfxx, ObjG.CustomMsgBox);
                return;
            }
            try
            {
                PriBds.EndEdit();
                PriRow.fl = Convert.ToDecimal(TxtFL.Text);
                PriTdskflTableAdapter1.Update(PriRow);
                this.DialogResult = DialogResult.OK;
                this.Close();
                ClsMsgBox.Ts("����ɹ�����������" + TxtBmc.Text + ",����" + TxtFL.Text + "���ޣ�" + TxtSxfsx.Text + "���ޣ�" + TxtSxfxx.Text, ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("������Ϣʧ�ܣ��������ݣ�", ex, ObjG.CustomMsgBox, this);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}