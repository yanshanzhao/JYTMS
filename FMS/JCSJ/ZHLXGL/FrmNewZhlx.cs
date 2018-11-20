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
using FMS.JCSJ.ZHLXGL.DSZHLXGLTableAdapters;

#endregion

namespace FMS.JCSJ.ZHLXGL
{
    public partial class FrmNewZhlx : Form
    {
        #region ��Ա����
        public EnumNEDD PubEnumNEDD;
        private BindingSource Bds;
        private DSZHLXGL.tzhlxRow DSZHLXGL1;
        private tzhlxTableAdapter tzhlxTableAdapter1;
        private ClsG ObjG;
        //private DSYHZHWH.VyhzhRow PriRow;
        //private DSZHLXGL.tzhlxRow PriRow;
        #endregion
        public FrmNewZhlx()
        {
            InitializeComponent();
        }
        #region Prepare
        public void Prepare(EnumNEDD aEnumNEDD, BindingSource aBds, ClsG aObjG)
        {
            Bds = aBds;
            ObjG = aObjG;
            Rebind();
            PubEnumNEDD = aEnumNEDD;
            tzhlxTableAdapter1 = new tzhlxTableAdapter();

            //if (PubEnumNEDD == EnumNEDD.New)
            //{
            //    Bds.AddNew();
            //    PriRow = ((DataRowView)Bds.Current).Row as DSYHZHWH.VyhzhRow;
            //    PriRow.jgid = ajgid;
            //    PriRow.ye = 0;
            //    PriRow.yhye = 0;
            //}
            //else if (PubEnumNEDD == EnumNEDD.Edit)
            //{
            //    PriRow = ((DataRowView)Bds.Current).Row as DSYHZHWH.VyhzhRow;
            //    this.Text = "������ϸ";
            //    UpdateYhye();
            //}
            if (PubEnumNEDD == EnumNEDD.New)
            {
                Bds.AddNew();
            }
            else if (PubEnumNEDD == EnumNEDD.Detail)
            {
                this.BtnSave.Visible = false;
            }
            else if (PubEnumNEDD == EnumNEDD.Edit)
            {
                this.Text = "�˻�������Ϣ";
            }
        }
        #endregion
        #region ���ݰ�
        private void Rebind()
        {
            this.TxtMc.DataBindings.Clear();
            this.TxtMc.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "mc", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            //this.Lblid.DataBindings.Clear();
            //this.Lblid.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "id", true,
            //Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtMs.DataBindings.Clear();
            this.TxtMs.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "ms", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
        }
        #endregion
        #region ȡ��
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region ����
        private void BtnSave_Click(object sender, EventArgs e)
        {
            ClsD.TextBoxTrim(this);
            //if (string.IsNullOrEmpty(TxtBh.Text))
            //{
            //    ClsMsgBox.Ts("��Ų���Ϊ��");
            //    return;
            //}
            //if(!ClsRegEx.IsBanHao(this.TxtBh.Text))
            //{
            //    ClsMsgBox.Ts("������Ͳ���ȷ��");
            //    return;
            //}
            if (string.IsNullOrEmpty(TxtMc.Text))
            {
                ClsMsgBox.Ts("�˻����Ʋ���Ϊ��", this, TxtMc, ObjG.CustomMsgBox);
                return;
            }
            try
            {
                //int id= (((DataRowView)Bds.Current).Row as  DSZHLXGL.tzhlxRow).id;
                //string s =
                // ClsRWMSSQLDb.GetStr(string.Format("SELECT id FROM tfmszhlx where mc='{0}' and id<>" + id, TxtMc.Text.Trim().ToString()),
                //                     ClsGlobals.CntStrTMS);
                //if (!string.IsNullOrEmpty(s))
                //{ 
                //    ClsMsgBox.Ts("�˻��������Ʋ����ظ�", this,TxtMc, ObjG.CustomMsgBox);
                //    return;
                //}
                Bds.EndEdit();
                DSZHLXGL1 = ((DataRowView)(Bds.Current)).Row as DSZHLXGL.tzhlxRow;
                tzhlxTableAdapter1.Update(DSZHLXGL1);
                this.DialogResult = DialogResult.OK;
                this.Close();
                if (PubEnumNEDD == EnumNEDD.New)
                    ClsMsgBox.Ts("����"+TxtMc.Text+"�ɹ���", ObjG.CustomMsgBox, this);
                else
                    ClsMsgBox.Ts("�༭" + TxtMc.Text + "�ɹ���", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                string ExStr = ex.Message;
                if (ExStr.LastIndexOf("�ظ�") > 0)
                    ClsMsgBox.Ts("�˻��������Ʋ����ظ���", this, TxtMc, ObjG.CustomMsgBox);
                else
                    ClsMsgBox.Cw("����ʧ�ܣ�������������ݣ�", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion
    }
}