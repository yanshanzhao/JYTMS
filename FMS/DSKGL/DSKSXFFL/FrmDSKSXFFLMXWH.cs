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
using JYPubFiles.Classes;
#endregion

namespace FMS.DSKGL.DSKSXFFL
{
    public partial class FrmDSKSXFFLMXWH : Form
    {
        #region ��Ա����
        private ClsG ObjG;
        private FrmMsgBox frm;
        private bool PriIsDefault;
        #endregion
        public FrmDSKSXFFLMXWH()
        {
            InitializeComponent();
        }
        #region ��ʼ������
        public void Prepare(int aPcid, EnumNEDD aEnumNEDD)
        {
            ObjG = Session["ObjG"] as ClsG;
            Bind();
            TfmssxfflpcTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            VfmssxfflmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            TableAdapterManager1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            if (aEnumNEDD == EnumNEDD.New)
                Bds.AddNew();
            if (aEnumNEDD == EnumNEDD.Edit)
            {
                TfmssxfflpcTableAdapter1.FillById(DSdsksxffl1.Tfmssxfflpc, aPcid);
                if (chkB.Checked)
                    PriIsDefault = true;
                VfmssxfflmxTableAdapter1.FillByPcid(DSdsksxffl1.Vfmssxfflmx, aPcid);
            }
        }
        #endregion

        #region ���ݰ�
        private void Bind()
        {
            this.TxtMc.DataBindings.Clear();
            this.TxtMc.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "mc", true,
               Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtBz.DataBindings.Clear();
            this.TxtBz.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "bz", true,
               Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.chkB.DataBindings.Clear();
            this.chkB.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Checked", this.Bds, "isdefault", true,
               Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
        }
        #endregion

        #region �����ͱ༭
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Bds.EndEdit();
            FrmDSKSXFFLMXNEW f = new FrmDSKSXFFLMXNEW();
            f.Prepare(BdsMX, EnumNEDD.New, DSdsksxffl1.Vfmssxfflmx);
            f.ShowDialog();
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (BdsMX.Current == null)
                return;
            FrmDSKSXFFLMXNEW f = new FrmDSKSXFFLMXNEW();
            f.Prepare(BdsMX, EnumNEDD.Edit, DSdsksxffl1.Vfmssxfflmx);
            f.ShowDialog();
        }
        #endregion

        #region ����
        private void BtnSave_Click(object sender, EventArgs e)
        {
            ClsD.TextBoxTrim(this);
            if (string.IsNullOrEmpty(TxtMc.Text))
            {
                ClsMsgBox.Ts("�������Ʋ�����Ϊ�գ�", this, TxtMc, ObjG.CustomMsgBox);
                return;
            }
            if (!PriIsDefault  && chkB.Checked)
            {
                if (ClsRWMSSQLDb.GetDataTable("select id from Tfmssxfflpc where isdefault='1'", ClsGlobals.CntStrTMS).Rows.Count > 0)
                {
                    ClsMsgBox.Ts("�Ѵ���Ĭ�Ϸ��ʣ�", ObjG.CustomMsgBox, this);
                    return;
                }
            }
            if (BdsMX.Count == 0)
            {
                ClsMsgBox.Ts("�������ϸ��", this, BtnNew, ObjG.CustomMsgBox);
                return;
            }
            try
            {
                BdsMX.CancelEdit();
                Bds.EndEdit();
                TableAdapterManager1.UpdateAll(DSdsksxffl1);
                this.DialogResult = DialogResult.OK;
                this.Close();
                ClsMsgBox.Ts("����ɹ���", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("�ظ�"))
                {
                    ClsMsgBox.Cw("������Ϣά���ظ���", ObjG.CustomMsgBox, this);
                    return;
                }
                ClsMsgBox.Cw("����ʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }

        }
        #endregion

        #region ɾ��
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (BdsMX.Current == null)
            {
                ClsMsgBox.Ts("û����Ҫɾ������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            ClsMsgBox.YesNo("ȷ��Ҫɾ������������", new EventHandler(DeleteFlMx), ObjG.CustomMsgBox, this);
        }
        private void DeleteFlMx(object sender, EventArgs e)
        {
            frm = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {
                try
                {
                    BdsMX.RemoveCurrent();
                    BdsMX.MoveNext();
                    ClsMsgBox.Ts("ɾ����Ϣ�ɹ���", frm, this);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("ɾ����Ϣʧ�ܣ�", ex, frm, this);
                }
            }
        }
        #endregion

        #region ȡ��
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv.Rows.Count <= 0)
            {
                ClsMsgBox.Ts("û����Ҫ�༭����Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            BtnEdit.PerformClick();
        }

       
    }
}