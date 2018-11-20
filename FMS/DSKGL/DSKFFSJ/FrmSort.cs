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
    public partial class FrmSort : Form
    {
        private string PriConStr; //数据库连接字符串
        private ClsG ObjG;
        private int PriJgId;  //机构Id
        private Dictionary<string, string> PriDcty;
        private int PriSort;
        public FrmSort()
        {
            InitializeComponent();
        }
        public void Prepare(DSDSKFFSJ.TdskffsjDataTable aDSDSKFFSJ, int sort)
        {
            PriDcty = new Dictionary<string, string>();
            PriConStr = ClsGlobals.CntStrTMS;
            PriSort = sort;
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            //DataTable dt = ClsRWMSSQLDb.GetDataTable("select id,xm from trenyuan where jgid =" +
            //    PriJgId + "order by xh", PriConStr);
            foreach (DSDSKFFSJ.TdskffsjRow r in aDSDSKFFSJ.Rows)
            {
                PriDcty.Add(r.mc, r.bh);
            }
            LstB.Items.AddRange(PriDcty.Keys.ToArray());
            LstB.SelectedIndex = 0;
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            //若不是第一行则上移
            if (LstB.SelectedIndex > 0)
            {
                int index = LstB.SelectedIndex;
                string temp = LstB.Items[index - 1].ToString();
                LstB.Items[index - 1] = LstB.SelectedItem.ToString();
                LstB.Items[index] = temp;
                LstB.SelectedIndex = index - 1;
            }
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            if (LstB.SelectedIndex < LstB.Items.Count - 1)
            {
                int index = LstB.SelectedIndex;
                string temp = LstB.Items[index + 1].ToString();
                LstB.Items[index + 1] = LstB.SelectedItem.ToString();
                LstB.Items[index] = temp;
                LstB.SelectedIndex = index + 1;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < LstB.Items.Count; i++)
            {
                if (PriSort == 1)
                    sb.AppendLine("update tdskffsj set sort= " + i + " where bh ='" + PriDcty[LstB.Items[i].ToString()] + "'");
                else
                    sb.AppendLine("update tdskffsj set sort1= " + i + " where bh ='" + PriDcty[LstB.Items[i].ToString()] + "'");
            }
            try
            {
                ClsRWMSSQLDb.ExecuteCmd(sb.ToString(), PriConStr);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("保存失败！", ex, ObjG.CustomMsgBox, this);
            }
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}