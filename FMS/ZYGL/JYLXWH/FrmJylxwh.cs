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
using FMS.ZYGL.JYLXWH;
using JY.Pub;

#endregion

namespace FMS.ZYGL.JYLXWH
{
    public partial class FrmJylxwh : UserControl
    {
        private ClsG ObjG;
        public FrmJylxwh()
        {
            InitializeComponent();
        }

        #region ����ҳ������Prepare()
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            TjylxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            TjylxTableAdapter1.Fill(DSJYLXWH1.tjylx);
        }
        #endregion

        #region ���� BtnNew_Click(object sender, EventArgs e)
        private void BtnNew_Click(object sender, EventArgs e)
        {
            int sort = DSJYLXWH1.tjylx.Rows.Count == 0 ? -1 : Convert.ToInt32(DSJYLXWH1.tjylx.Compute("MAX(sort)", "1=1"));
            FrmJylxwhmx f = new FrmJylxwhmx();
            f.Prepare(EnumNEDD.New, this.Bds, Convert.ToInt32((sort + 1)));
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }
        #endregion

        #region �༭ BtnEndit_Click(object sender, EventArgs e)
        private void BtnEndit_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            FrmJylxwhmx f = new FrmJylxwhmx();
            DSJYLXWH.tjylxRow row = ((DataRowView)Bds.Current).Row as DSJYLXWH.tjylxRow;
            f.Prepare(EnumNEDD.Edit, this.Bds, Convert.ToInt32(row.jybh));
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }
        #endregion

        #region ���� BtnDel_Click(object sender, EventArgs e)
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            DSJYLXWH.tjylxRow row = ((DataRowView)Bds.Current).Row as DSJYLXWH.tjylxRow;
            if (row.states != "��Ч")
            {
                ClsMsgBox.Ts("���ϳɹ���", ObjG.CustomMsgBox, this);
            }
            else
            {
                ClsMsgBox.Ts("����Ϣ�Ѿ����ϣ�", ObjG.CustomMsgBox, this);
            }
            row.state = 0;
            row.states = "��Ч";
            Bds.EndEdit();
            TjylxTableAdapter1.Update(DSJYLXWH1.tjylx);
           
        }
        #endregion

        #region ���� BtnStart_Click(object sender, EventArgs e)
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            DSJYLXWH.tjylxRow row = ((DataRowView)Bds.Current).Row as DSJYLXWH.tjylxRow;
            
            if (row.states != "��Ч")
            {
                ClsMsgBox.Ts("���óɹ���", ObjG.CustomMsgBox, this);
            }
            else
            {
                ClsMsgBox.Ts("����Ϣ�Ѿ����ã�", ObjG.CustomMsgBox, this);
            }
            row.state = 1;
            row.states = "��Ч";
            Bds.EndEdit();
            TjylxTableAdapter1.Update(DSJYLXWH1.tjylx);
        }
        #endregion

        #region �տ����� BtnSort_Click(object sender, EventArgs e)
        private void BtnSort_Click(object sender, EventArgs e)
        {
            TjylxTableAdapter1.FillBySort(DSJYLXWH1.tjylx);
            FrmSort f = new FrmSort();
            f.Prepare(DSJYLXWH1.tjylx, 1);
            f.ShowDialog();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }
        #endregion

        #region ���ùرշ��� f_FormClosing(object sender, FormClosingEventArgs e)
        void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            Bds.CancelEdit();
            TjylxTableAdapter1.Fill(DSJYLXWH1.tjylx);
        }
        #endregion
    }
}