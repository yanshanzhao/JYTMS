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
namespace FMS.CWGL.ZZHQRJKD.QRJK
{
    public partial class FrmYbfXq : Form
    {
        private int PriId;
        private bool b = false;
        private ClsG ObjG;
        public FrmYbfXq()
        {
            InitializeComponent();
        }
        public void Prepare(int aId, string aRbdh)
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG; 
            PriId = aId;
            string SqlCOnTxt = "";
            //ClsPopulateCmbDsS.PopuFMS_Jzlx(CmbJzlx);
            SqlCOnTxt = "select jgmc,rbdh,tojgmc,ywqymc,yck,scje,zzje,zzdh from Vfmsqrjk where id=" + aId;
            DataRow dr = ClsRWMSSQLDb.GetDataRow(SqlCOnTxt, ClsGlobals.CntStrTMS);
            this.LblJKJG.Text = dr[0].ToString();
            this.LblJKRB.Text = dr[1].ToString();
            this.LblSHJG.Text = dr[2].ToString();
            this.LBLYWQY.Text = dr[3].ToString();
            this.LBLSJYC.Text = dr[4].ToString();
            this.LBLSCJE.Text = dr[5].ToString();
            this.LBLZj.Text = dr[6].ToString();
            this.LBLZZDH.Text = dr[7].ToString();
            SqlCOnTxt = "";
            if (aRbdh.IndexOf('Y') >= 0)
            {
                b = true;
                this.Dgv.Visible = true;
                string Where = " where rbpcid=" + aId;
                //SqlCOnTxt = " select jzlxmc,ywqymc,bh,yf,bf,zj,inssj from vfmsyfmx where rbpcid=" + aId;
                VfmsyfmxTableAdapter1.FillByWhere(DSQRJK1.Vfmsyfmx, Where);
                //Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(SqlCOnTxt, ClsGlobals.CntStrTMS);
            }
            else
            {
                this.DgvPc.Visible = true;
                string Where = " where pid=" + aId;
                //SqlCOnTxt = "  select (ROW_NUMBER() OVER(ORDER BY  id ))as xh,yck,rbdh,mc,ztmc from vfmsyfpc where pid=" + aId;
                //DgvPc.DataSource = ClsRWMSSQLDb.GetDataTable(SqlCOnTxt, ClsGlobals.CntStrTMS);
                VfmsyfpcTableAdapter1.FillByWhere(DSQRJK1.Vfmsyfpc, Where);
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string SqlCOnTxt = " select  jzlxmc,ywqymc,bh,fhxf,tf,zf,bfxf,bfdf,bfzf,zj,zj,inssj from vfmsyfmx where rbpcid=" + PriId;
            if (b)
            {
                if (this.CmbJzlx.SelectedIndex != 0)
                    SqlCOnTxt = SqlCOnTxt + "  and jzlxmc='" + this.CmbJzlx.Text + "'";
                Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(SqlCOnTxt, ClsGlobals.CntStrTMS);
                if (Dgv.RowCount == 0)
                    ClsMsgBox.Ts("没有要查询的信息！",ObjG.CustomMsgBox,this);
            }
        }
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (b)
            {
                if (Dgv.RowCount == 0)
                {
                    ClsMsgBox.Ts("没有要导出的信息", ObjG.CustomMsgBox, this);
                    return;
                }
                int[] RowList = new int[] { 3, 4, 5, 6, 7, 8, 9, 10 };
                ClsExcel.CreatExcel(Dgv, "运保费详情", this.ctrlDownLoad1, RowList);
            }
            else
            {
                if (DgvPc.RowCount == 0)
                {
                    ClsMsgBox.Ts("没有要导出的信息", ObjG.CustomMsgBox, this);
                    return;
                }
                int[] RowList = new int[] { 2 };
                ClsExcel.CreatExcel(DgvPc, "运保费详情", this.ctrlDownLoad1, RowList);
            }
        }
    }
}