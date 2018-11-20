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

namespace FMS.DSKGL.DSKCKFF.YQZLDSKFF
{
    public partial class FrmYQZLDSKFFMX : Form
    {
        #region ��Ա����
        private ClsG ObjG;
        #endregion
        public FrmYQZLDSKFFMX()
        {
            InitializeComponent();
        }
        public void Prepare(int apcid,string aSumJe,string aSxf,string aSfje,string aCun)
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            this.LblZje.Text = aSumJe;
            this.LblSxf.Text = aSxf;
            this.LblSfje.Text = aSfje;
            this.LblBs.Text = aCun; 
            this.VfmsYQZLDSKFFMX1TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.VfmsYQZLDSKFFMX1TableAdapter1.FillByPcid(this.DSYQZLDSKFF1.VfmsYQZLDSKFFMX1, apcid);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            if (Dgv.Rows.Count > 60000)
            {
                ClsMsgBox.Ts("������������60000��������!", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 4, 5, 6 };
            ClsExcel.CreatExcel(Dgv, "���տ�����ֱ��������ϸ", this.ctrlDownLoad1, Rows); 
            //ClsExcel.CreatExcel(Dgv, "���տ�����ֱ��������ϸ", this.ctrlDownLoad1); 
        }
        #endregion
       
    }
}