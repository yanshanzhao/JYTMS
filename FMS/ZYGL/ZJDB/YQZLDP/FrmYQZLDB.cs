#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Data.SqlClient;
using FMS.DSKGL.DSKDK;
using JY.Pub;
using JY.Pri;
using JYPubFiles.Classes;
using FMS.ZYGL.ZJDB.YQZLDP;
#endregion

namespace FMS.ZYGL.ZJDB.YQZLDB
{
    public partial class FrmYQZLDB : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private string Pristrdtp = "";
        private string Pristrend = "";
        private string Prilx = "R";
        private List<int> PirList = new List<int>();
        private string PriStr = "";
        private DSYQZL.VfmsyqzlfhRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                    return null;
                return ((DataRowView)Bds.Current).Row as DSYQZL.VfmsyqzlfhRow;
            }
            set
            {
                PriRow = value;
            }
        }
        #endregion
        public FrmYQZLDB()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
        }

        private void BtnQr_Click(object sender, EventArgs e)
        {
            Pristrdtp = DtpStart.Value.Date.ToString();
            Pristrend = DtpStop.Value.AddDays(1).Date.ToString();
            PriStr = " where inssj>= '" + Pristrdtp + "' and inssj<'" + Pristrend + "'";
            this.VfmsyqzlfhTableAdapter1.FillByWhere(this.DSYQZL1.Vfmsyqzlfh, PriStr);
        }

        private void BtnZz_Click(object sender, EventArgs e)
        {
            Prilx = "C";
            FrmPwd f = new FrmPwd();
            f.Prepare();
            f.ShowDialog();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPwd f = sender as FrmPwd;
            if (f.DialogResult == DialogResult.Yes)
            {
                FrmZz frm = new FrmZz();
                frm.ShowDialog();
                frm.Prepare(Prilx);
                //this.VfmsyqzlfhTableAdapter1.FillByWhere(this.DSYQZL1.Vfmsyqzlfh, PriStr);
            }

        }

        private void BtnZr_Click(object sender, EventArgs e)
        {
            Prilx = "R";
            FrmPwd f = new FrmPwd();
            f.Prepare();
            f.ShowDialog();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (PriRow == null)
            {
                ClsMsgBox.Ts("没有要删除的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            ClsMsgBox.YesNo("确定要删除该条信息吗？", new EventHandler(JGGX_Delete), ObjG.CustomMsgBox, this);
        }
        public void JGGX_Delete(object sender, EventArgs e)
        {
            Form f = sender as Form;
            FrmMsgBox frm = new FrmMsgBox();
            if (f.DialogResult == DialogResult.Yes)
            {
                try
                {
                    VfmsyqzlfhTableAdapter1.DeletePcid(PriRow.id);
                    Bds.RemoveCurrent();
                    ClsMsgBox.Ts("删除成功！", frm, this);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("删除失败！", ex, frm, this);
                }
            }
        }



        private void BtnElse_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            ClsExcel.CreatExcel(this.Dgv, "银企直联调拨", this.ctrlDownLoad1, new int[] { 6 });
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                if (Dgv.Rows[e.RowIndex].Cells[DgvColTxtlx.Name].Value.ToString() == "R")
                {
                    ClsMsgBox.Ts("没有要查看的明细!", ObjG.CustomMsgBox, this);
                    return;
                }
                FrmDPXX f = new FrmDPXX();
                f.Prepare(PriRow);
                f.ShowDialog();
            }
            else return;
        }


    }
}