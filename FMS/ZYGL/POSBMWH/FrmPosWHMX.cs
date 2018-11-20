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

namespace FMS.ZYGL.POSBMWH
{
    public partial class FrmPosWHMX : Form
    {
        private DSPOSWH.tjigouRow PriRow;
        private ClsG ObjG;
        public FrmPosWHMX()
        {
            InitializeComponent();
        }
        public void Prepare(DSPOSWH.tjigouRow row)
        {
            PriRow = row;
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            TxtJgmc.Text = row.mc;
            TxtPosBh.Text = row.IsposbhNull() ? "" : row.posbh;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ClsD.TextBoxTrim(this);
            if (string.IsNullOrEmpty(TxtPosBh.Text.Trim()))
            {
                ClsMsgBox.Ts("POS编号不能为空！", this, TxtPosBh, ObjG.CustomMsgBox);
                return;
            }
            PriRow.posbh = TxtPosBh.Text;
            try
            {
                PriRow.EndEdit();
                int POSCounts = ClsRWMSSQLDb.GetInt(" select id from Tjigou where  posbh='"+PriRow.posbh+"' ",ClsGlobals.CntStrKj);
                if (POSCounts>0)
                {
                    ClsMsgBox.Ts("该POS编码已存在！", ObjG.CustomMsgBox, this);
                    return;
                }
                int count = TjigouTableAdapter1.Update(PriRow);
                this.Close();
                if (count > 0)
                    ClsMsgBox.Ts("保存成功！", ObjG.CustomMsgBox, this);
                else 
                    ClsMsgBox.Ts("保存失败！", ObjG.CustomMsgBox, this); 
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("保存失败！", ex, ObjG.CustomMsgBox, this);
            }
        }

        private void BtnCanCell_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}