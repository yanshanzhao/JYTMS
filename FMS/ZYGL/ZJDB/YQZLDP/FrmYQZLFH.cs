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
//using FMS.DSKGL.DSKDK;
using FMS.ZYGL.ZJDB.YQZLDP;
using FMS.DSKGL.DSKDK;

#endregion

namespace FMS.ZYGL.ZJDB.YQZLDB
{
    public partial class FrmYQZLFH : UserControl
    {
        #region 成员变量
        private ClsG ObjG;
        private List<int> PriPcid = new List<int>();
        private List<int> PirList = new List<int>();
        private string Pristrdtp = "";
        private string Pristrend = "";
        private string PriStr = "";
        private List<string> LstValues = new List<string>();
        private Dictionary<string, string> PriDic;
        private string PriServerKhhStr;
        private string PriServerPwdStr;
        private string PriServerCZYH;
        private FrmZzCz f3;
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
        public FrmYQZLFH()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            PriDic = ClsRWDBOptions.GetDic(ClsGlobals.CntStrKj);
            PriServerKhhStr = PriDic["JY_KHH"];
            PriServerPwdStr = PriDic["JY_DLMM"];
            PriServerCZYH = PriDic["JY_CZYH"];
            this.Cmbzt.SelectedIndex = 0;
        }
        private void BtnFh_Click(object sender, EventArgs e)
        {
            if (PriRow == null)
                return;
            if (PriRow.zzzt == "成功")
            {
                ClsMsgBox.Ts("该条信息已经复核成功！", ObjG.CustomMsgBox, this);
                return;
            }
            if (PriRow.zzzt == "转账中")
            {
                ClsMsgBox.Ts("该条信息复核状态为转账中，可以点击【调拨结果查询】按钮查看复核状态！", ObjG.CustomMsgBox, this);
                return;
            }
            FrmPwd2 f = new FrmPwd2();
            f.Prepare(PriRow);
            f.ShowDialog();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);

        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPwd2 f = sender as FrmPwd2;
            if (f.DialogResult == DialogResult.Yes)
            {
                f3 = new FrmZzCz();
                f3.Prepare(PriRow);
                f3.ShowDialog();
                f3.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f3_FormClosed);
                //Bds.RemoveCurrent();
            }

        }
        void f3_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmZzCz f = sender as FrmZzCz;
            if (f.DialogResult == DialogResult.Yes)
                Bds.RemoveCurrent();
        }
        private void BtnQr_Click(object sender, EventArgs e)
        {
            Pristrdtp = DtpStart.Value.Date.ToString();
            Pristrend = DtpStop.Value.AddDays(1).Date.ToString();
            PriStr = " where    inssj>= '" + Pristrdtp + "' and inssj<'" + Pristrend + "'";
            if (Cmbzt.SelectedIndex > 0)
                PriStr = PriStr + " and zzzt='" + this.Cmbzt.Text.Trim() + "' ";
            this.VfmsyqzlfhTableAdapter1.FillByWhere(this.DSYQZL1.Vfmsyqzlfh, PriStr);
        }

        private void BtnElse_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            ClsExcel.CreatExcel(this.Dgv, "银企直连复核", this.ctrlDownLoad1, new int[] { 6 });
        }

        private void BtnSelDpjg_Click(object sender, EventArgs e)
        {
            this.VfmsyqzlfhTableAdapter1.FillByWhere(this.DSYQZL1.Vfmsyqzlfh, "  where zt=5 ");
            if (Dgv.RowCount == 0)
                return;
            //List<string> UncertaintyLst = new List<string>();
            int aSuccess = 0;
            int aFailure = 0;
            int aUncertain = 0;
            string aXlh = "";
            string[] XML_TXValues;
            foreach (DSYQZL.VfmsyqzlfhRow row in this.DSYQZL1.Vfmsyqzlfh)
            {
                aXlh = GetXlh("Z").ToString();//代收款代扣序列号
                string[] strName = new string[] { "RETURN_CODE", "DEAL_RESULT" };
                XML_TXValues = new string[] { aXlh, PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W0500", "CN", row.xlh.ToString() };
                string recvStr = ClsSockets.sendStr(XML_TXValues, "6W0500.xml");
                if (!ClsGetXML.IsXml(recvStr))
                {
                    ClsMsgBox.Ts("查询错误！\n" + recvStr, ObjG.CustomMsgBox, this);
                    break;
                }
                LstValues.Clear();
                LstValues = ClsGetXML.GetListStr(strName, recvStr);
                if (LstValues.Count > 0)
                {
                    if (LstValues[0] == "000000")
                    {
                        int azt1 = 0;
                        if (LstValues[1].ToString().Equals("4"))//成功 
                        {
                            azt1 = 10;
                            aSuccess++;
                        }
                        else if (LstValues[1].ToString().Equals("3"))//失败 
                        {
                            azt1 = 20;
                            aFailure++;
                        }
                        else
                        {
                            aUncertain++;
                        }
                        if (azt1 > 0)
                        {
                            string aStr = string.Format(" update Tzzlog set zt='{0}'where id ={1}; ", azt1, row.id);
                            if (row.lx == "C" && azt1 == 10)
                                aStr = aStr + string.Format(" update tfmsdskckffpc set zzzt='10' where id in (select ffpcid from Tzzlogmx where pcid='{0}'  ) ", row.id);
                            ClsRWMSSQLDb.ExecuteCmd(aStr, ClsGlobals.CntStrTMS);
                        }
                    }
                }
            }
            ClsMsgBox.Ts("一共成功" + aSuccess + "个,失败" + aFailure + "个,处理中" + aUncertain + "个", ObjG.CustomMsgBox, this);
            LstValues.Clear();
        }
        /// <summary>
        /// 请求序列号
        /// </summary>
        /// <param name="aType"></param>
        /// <returns></returns>
        private int GetXlh(string aType)
        {
            return ClsRWMSSQLDb.GetInt(string.Format("Insert into Tfmsxlh values('{0}',getdate());Select SCOPE_IDENTITY()", aType), ClsGlobals.CntStrTMS);
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                if (Dgv.Rows[e.RowIndex].Cells[DgvColTxtlx.Name].Value.ToString() == "R")
                    return;
                FrmDPXX f = new FrmDPXX();
                f.Prepare(PriRow);
                f.ShowDialog();
            }
            else return;
        }
    }
}
