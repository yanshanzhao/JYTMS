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
using JY.Pub;
using JY.Pri;

#endregion

namespace FMS.CWGL.YYSRTJ
{
    public partial class FrmLsdSrTj : Form
    {
        public FrmLsdSrTj()
        {
            InitializeComponent();
        }
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (this.Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ����������");
            }
            else
            {
                ClsExcel.CreatExcel(this.Dgv, " ������Ӫҵ����ͳ�� ", this.ctrlDownLoad1);
            }
        }
        public void Prepare(int aSljgid, DateTime aStartSj, DateTime aStopSj)
        {
            LblHj.Text = "�ϼƣ�0Ԫ";
            string aWhere = " where EXISTS (SELECT id FROM jyjckj.dbo.tjigou WHERE parentlst like '%," + aSljgid + ",%' AND id=sljgid) and  inssj >= '" + aStartSj + "' and inssj< DateAdd(dd,+1, '" + aStopSj + "')";
            aWhere += " and jezj<> 0.00 ";
            DataTable dt = ClsRWMSSQLDb.GetDataTable(" select mc,ydid,inssj,sljgid,jzlx,ywqys,bh,fhxf,bf,jezj,fzf,cz,fkfs from Vfmsyysrcx2  " + aWhere, ClsGlobals.CntStrTMS);
            DataRow dr = dt.NewRow();
            dr["jzlx"] = "�ϼƣ�";
            dr["fhxf"] = dt.Compute("sum(fhxf)", "");
            dr["bf"] = dt.Compute("sum(bf)", "");
            dr["jezj"] = dt.Compute("sum(jezj)", "");
            dt.Rows.Add(dr);
            LblHj.Text = "�ϼƣ�" + dr["jezj"].ToString() + "0Ԫ";
            Dgv.DataSource = dt;

        }

        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1 || e.ColumnIndex < 0 || e.ColumnIndex != 8)
                return;
            if (e.ColumnIndex == 8 && e.RowIndex != Dgv.Rows.Count - 1)//����
            {

                FrmYdcx f = new FrmYdcx();
                f.ShowDialog();
                string aBh = Dgv.Rows[e.RowIndex].Cells[DgvColTxtywdh.Name].Value.ToString();
                string aFkfs = Dgv.Rows[e.RowIndex].Cells[DgvColTxtfkfs.Name].Value.ToString();
                f.Prepare(aBh, aFkfs);
            }
        }
    }
}