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

namespace FMS.DSKGL.DSKCX.DSKHZB
    {
    public partial class FrmDSKHZBXX : Form
        {

        public FrmDSKHZBXX()
            {
            InitializeComponent();
            }
        #region 成员变量
        private string where;
        #endregion
        #region Prepare
        public void Prepare(string Assj, string Aesj, string Ajgid, int Azt1, int Azt2)
            {
            this.VfmsdskhzbxxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            string aSQLStr = "";
            where = " where sj >= '" + Assj + "' and sj< '" + Aesj + "' and jgid=" + Ajgid;
            if (Azt1 == 0)//本店发生额
                {
                this.VfmsdskhzbxxTableAdapter1.FillByDh(this.dskhzb1.Vfmsdskhzbxx, where, aSQLStr);
                }
            else if (Azt1 == 1)//已签收
                {
                this.DgvColTxtqssj.Visible = true;
                if (Azt2 == 0)//未存
                    where += " and sjdskzt<>30";
                else if (Azt2 == 1)//已存
                    {
                    this.DgvColTxtshsj.Visible = true;
                    where += " and sjdskzt=30";
                    }
                this.VfmsdskhzbxxTableAdapter1.FillBy(this.dskhzb1.Vfmsdskhzbxx, where, aSQLStr);
                }
            else if (Azt1 == 2)
                {
                this.VfmsdskhzbxxTableAdapter1.FillByWqs(this.dskhzb1.Vfmsdskhzbxx, where, aSQLStr);
                }



            //this.VfmsdskhzbxxTableAdapter1.FillByWhere1(this.dskhzb1.Vfmsdskhzbxx, where, aSQLStr);

            }
        #endregion
        #region Close
        private void BtnClose_Click(object sender, EventArgs e)
            {
            this.Close();
            }
        #endregion
        #region 下载
        private void BtnExcel_Click(object sender, EventArgs e)
            {
            int[] Rows = new int[] { 6 };
            ClsExcel.CreatExcel(Dgv, this.Text, this.ctrlDownLoad1, Rows);
            }
        #endregion
        }
    }