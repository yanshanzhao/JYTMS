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
#endregion

namespace FMS.DSKGL.DSKKHTZ
{
    public partial class FrmDSKKHTZ : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private string PriWhere = "";
        #endregion
        public FrmDSKKHTZ()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            Vfmsdskkhzt1TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(this.TxtDh.Text.Trim().Length==0)
            {
                ClsMsgBox.Ts("��������ﵥ��!", ObjG.CustomMsgBox, this);
                TxtDh.Focus();
                return;
            }
            PriWhere=" where bh ='" + this.TxtDh.Text.Trim().ToString()+ "'";
            Vfmsdskkhzt1TableAdapter1.FillByWhere1(DSDSKKHZT1.Vfmsdskkhzt1, PriWhere);
            if(Dgv.RowCount==0) 
                ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ��",ObjG.CustomMsgBox,this); 
        }

        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1)
                return;
            if (e.ColumnIndex == 5)//�޸���Ϣ
            {
                string aZt=Dgv.Rows[e.RowIndex].Cells[DgvColTxtzt.Name].Value.ToString();
                if (aZt == "2")
                    ClsMsgBox.Ts("���˵��Ѿ�����,�޷����п��ŵ������ܣ�", ObjG.CustomMsgBox, this);
                else if(aZt=="0")
                    ClsMsgBox.Ts("���˵�δǩ��,�޷����п��ŵ������ܣ�", ObjG.CustomMsgBox, this);
                else
                {
                    int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtId.Name].Value);
                    FrmDSKKHXX f = new FrmDSKKHXX();
                    f.ShowDialog();
                    f.Prepare(aId, aZt);
                    f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
                } 
            }
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmDSKKHXX f = sender as FrmDSKKHXX;
            if (f.DialogResult == DialogResult.OK)
            {
                ClsMsgBox.Ts("���տ���޸ĳɹ���", ObjG.CustomMsgBox, this);
                Vfmsdskkhzt1TableAdapter1.FillByWhere1(DSDSKKHZT1.Vfmsdskkhzt1, PriWhere);
            }
        }

        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 3 };
            ClsExcel.CreatExcel(Dgv, "���տ�ŵ���", this.ctrlDownLoad1, Rows, false);          
        }
        #endregion       
    }
}