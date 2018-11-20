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

namespace FMS.CWGL.YBFYQZLDK
{
    public partial class FrmJexg : Form
    {
        private ClsG ObjG;
        //private DSDSKDK.VfmsdskdkRow PriRow;
        //private DSDSKDK.TfmsdskdkjeRow PriDkjeRow;

        private DSYBFDK.VfmsYbfdkRow PriRow;
        private DSYBFDK.TfmsybfdkjeRow PriDkjeRow;
        private BindingSource Bds;
        private DSYBFDK DSYBFDK1 = new DSYBFDK();
        private DSYBFDKTableAdapters.TfmsybfdkjeTableAdapter TfmsybfdkjeTableAdapter1 = new DSYBFDKTableAdapters.TfmsybfdkjeTableAdapter();
        private DSYBFDKTableAdapters.VfmsYbfdkTableAdapter VfmsYbfdkTableAdapter1 = new DSYBFDKTableAdapters.VfmsYbfdkTableAdapter();

        public FrmJexg()
        {
            InitializeComponent();
        }
        public void Prepare(BindingSource aBds,DSYBFDK.VfmsYbfdkRow row)
        {
            Bds = aBds; 
            VfmsYbfdkTableAdapter1.Connection.ConnectionString = TfmsybfdkjeTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG; 
            PriDkjeRow = ((DataRowView)Bds.AddNew()).Row as DSYBFDK.TfmsybfdkjeRow;
            PriRow = row;
            TxtOldJe.Text = PriRow.IsdkjeNull() ? "" : PriRow.dkje.ToString();         

        }
        /// <summary>
        /// ���տ���ȷ��
        /// </summary>
        public static void YesNo(string mess, EventHandler hdl, FrmMsgBox aMsgBox = null, Control aParControl = null, float aFontsize = 20)
        {
            aMsgBox.Text = "����";
            aMsgBox.LblMess.Text = mess;
            aMsgBox.LblMess.Font = new System.Drawing.Font("����", aFontsize, System.Drawing.FontStyle.Bold);
            aMsgBox.LblMess.ForeColor = System.Drawing.Color.Red;
            aMsgBox.Btn1.Text = "ȷ��";
            aMsgBox.Btn1.AutoSize = true;
            aMsgBox.Btn1.DialogResult = DialogResult.Yes;
            aMsgBox.Btn2.Text = "ȡ��";
            aMsgBox.Btn2.Visible = true;
            aMsgBox.Btn2.AutoSize = true;
            aMsgBox.Btn2.DialogResult = DialogResult.No;
            aMsgBox.Btn1.TabStop = false;
            aMsgBox.FrmCloseHdl = hdl;
            aMsgBox.Tag = null;
            aMsgBox.ShowDialog();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            TxtNewJe.Text = TxtNewJe.Text.Trim();
            if (string.IsNullOrEmpty(TxtNewJe.Text))
            {
                ClsMsgBox.Ts("�޸ĺ����Ϊ�գ�", ObjG.CustomMsgBox, this);
                return;
            }
            if (!ClsRegEx.IsJe(TxtNewJe.Text))
            {
                ClsMsgBox.Ts("�޸ĺ����ʽ����ȷ��", ObjG.CustomMsgBox, this);
                return;
            }
            FrmMsgBox Box = new FrmMsgBox();
            string aNewJe = TxtNewJe.Text;
            if (aNewJe.LastIndexOf(".") < 0)
                aNewJe += ".00";
            YesNo("ȷ�Ͻ����" + PriRow.dkje + "�޸�Ϊ" + aNewJe + "��", new EventHandler(Save), Box, this);
        }
        void Save(object sender, EventArgs e)
        {
            Form f = sender as Form;
            FrmMsgBox frm = new FrmMsgBox();
            if (f.DialogResult != DialogResult.Yes)
                return;
            try
            {
                PriRow.dkje = Convert.ToDecimal(TxtNewJe.Text);
                Bds.EndEdit();
                TfmsybfdkjeTableAdapter1.Insert(PriRow.ybfrbpcid, Convert.ToDecimal(TxtOldJe.Text.Trim().ToString()), Convert.ToDecimal(TxtNewJe.Text), ObjG.Renyuan.id, ObjG.Renyuan.xm, DateTime.Now);
                VfmsYbfdkTableAdapter1.Update(PriRow);
                this.Close();
                ClsMsgBox.Ts("����ɹ���", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("����ʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}