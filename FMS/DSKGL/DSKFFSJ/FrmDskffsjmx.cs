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

#endregion

namespace FMS.DSKGL.DSKFFSJ
{
    public partial class FrmDskffsjmx : Form
    {
        private ClsG ObjG;
        private DSDSKFFSJ.TdskffsjRow PriRow;
        public FrmDskffsjmx()
        {
            InitializeComponent();
        }
        public void Prepare(EnumNEDD aEnumNEDD, BindingSource aBds, string bh)
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            TdskffsjTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.Bds = aBds;
            if (aEnumNEDD == EnumNEDD.New)
            {
                PriRow = ((DataRowView)Bds.AddNew()).Row as DSDSKFFSJ.TdskffsjRow;
                PriRow.sort = Convert.ToInt32(bh);
                TxtSort.Text = bh;
            }
            else
            {
                TdskffsjTableAdapter1.FillByBh(DSDSKFFSJ1.Tdskffsj, bh);
                PriRow = ((DataRowView)Bds.Current).Row as DSDSKFFSJ.TdskffsjRow;
                TxtBh.Text = PriRow.bh;
                TxtMc.Text = PriRow.mc;
                TxtSort.Text = PriRow.sort.ToString();
                TxtDay.Text = PriRow.day.ToString();
                this.TxtBh.ReadOnly = true;
                if (PriRow.Status == "��Ч")
                    CHbYx.Checked = true;
                else
                    CHbYx.Checked = false;                
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            TxtBh.Text = TxtBh.Text.Trim();
            TxtMc.Text = TxtMc.Text.Trim();
            if (string.IsNullOrEmpty(TxtBh.Text))
            {
                ClsMsgBox.Ts("��Ų���Ϊ�գ�", ObjG.CustomMsgBox, this);
                return;
            }
            if (string.IsNullOrEmpty(TxtMc.Text))
            {
                ClsMsgBox.Ts("���Ʋ���Ϊ�գ�", ObjG.CustomMsgBox, this);
                return;
            }
            if (TxtBh.Text.Length > 1)
            {
                ClsMsgBox.Ts("��ų��Ȳ��ܴ���1");
                return;
            }
            if (!ClsRegEx.IsInt1(TxtDay.Text.Trim()))
            {
                ClsMsgBox.Ts("��������Ϊ��������", ObjG.CustomMsgBox, this);
                return;
            }
            try
            {
                if (CHbYx.Checked)
                    PriRow.Status = "��Ч";
                else
                    PriRow.Status = "��Ч";
                PriRow.bh = TxtBh.Text;
                PriRow.mc = TxtMc.Text;
                PriRow.day = Convert.ToInt32(TxtDay.Text.Trim());
                Bds.EndEdit();
                TdskffsjTableAdapter1.Update(PriRow);
                this.Close();
                ClsMsgBox.Ts("����ɹ���", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Ts("��������" + ex.Message, this, ObjG.CustomMsgBox);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}