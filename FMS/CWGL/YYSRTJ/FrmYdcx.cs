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

namespace FMS.CWGL.YYSRTJ
{
    public partial class FrmYdcx : Form
    {
        public FrmYdcx()
        {
            InitializeComponent();
        }

        public void Prepare(string aBh, string aFkfs)
        {
            //T.�ḶF.����Z.���½�D.���½�S.�������½�
            if (aFkfs == "F")
                aFkfs = "����";
            else if (aFkfs == "H")
                aFkfs = "�ظ�";
            else if (aFkfs == "T")
                aFkfs = "�Ḷ";
            else if (aFkfs == "Z")
                aFkfs = "���½�";
            else if (aFkfs == "D")
                aFkfs = "���½�";
            else
                aFkfs = "�������½�";
            this.VfmsyysrcxmxTableAdapter.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            string awhere = " where bh='" + aBh + "' and fkfs='" + aFkfs + "'";
            this.VfmsyysrcxmxTableAdapter.FillByWhere2(this.DSYYSRCX.Vfmsyysrcxmx, awhere);
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (this.Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ����������");
            }
            else
            {
                ClsExcel.CreatExcel(this.Dgv, " �˵���ϸ��Ϣ ", this.ctrlDownLoad1);
            }
        }
    }
}