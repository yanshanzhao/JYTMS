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

namespace FMS.ZYGL.ZJDB.SGDB
{
    public partial class FrmSGDBMX : Form
    {
        private ClsG ObjG;
        private BindingSource PriBds;
        public EnumNEDD PubEnumNEDD;
        private DSSGDB.VzzlogRow PriRow;
        private DataTable PriDt;
        public FrmSGDBMX()
        {
            InitializeComponent();
        }
        public void Prepare(EnumNEDD aEnumNEDD, BindingSource aBds)
        {
            ObjG = Session["ObjG"] as ClsG;
            PriBds = aBds;
            PubEnumNEDD = aEnumNEDD;
            string ConStr = " Select id,zh,zhmc,yhlxmc,zhlxid,zhlxmc from Vjtyhzh  ";
            PriDt = ClsRWMSSQLDb.GetDataTable(ConStr, ClsGlobals.CntStrTMS);
            DataRow[] dr = PriDt.Select(" zhlxid=62 ");
            ClsPopulateCmbDsS.PopuByTb(this.CmbZRZH, dr.CopyToDataTable(), "id", "zh");
            if (PubEnumNEDD == EnumNEDD.New)
            {
                PriBds.AddNew();
                PriRow = ((DataRowView)aBds.Current).Row as DSSGDB.VzzlogRow;
            }
            else if (PubEnumNEDD == EnumNEDD.Edit)
            {
                PriRow = ((DataRowView)aBds.Current).Row as DSSGDB.VzzlogRow;
            }
            CmbZczh();
            LblZRZHMC.Text = dr[0][2].ToString();
            LblZRYHMC.Text = dr[0][3].ToString();
            lalzrzhlx.Text = dr[0][5].ToString();
            CmbZRZH.Enabled = false;
            Rebind();
            CmbZRZH.SelectedIndex = 0;
            CmbZCZH.SelectedIndex = 0;
            this.CmbZCZH.SelectedIndexChanged += new System.EventHandler(this.CmbZCZH_SelectedIndexChanged);
            CmbZCZH_SelectedIndexChanged(null, null);
           
        }
        private void CmbZczh()
        {
            DataRow[] row = PriDt.Select(" yhlxmc <> '建设银行'");
            DataTable dt = row.CopyToDataTable();
            //DataRow dr = dt.NewRow();
            //dr["id"] = 0;
            //dr["zh"] = "------请选择------";
            //dt.Rows.InsertAt(dr, 0);
            ClsPopulateCmbDsS.PopuByTb(this.CmbZCZH, dt, "id", "zh");
        }
        #region  数据绑定
        private void Rebind()
        {
            this.CmbZCZH.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("SelectedValue", this.PriBds, "zczhid", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.CmbZRZH.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("SelectedValue", this.PriBds, "zrzhid", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtZzje.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "zze", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtQrzzje.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "sjzze", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtBz.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "bz", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.LblZCZHMC.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "zczhmc", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            //this.lalzczhlx.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "zhlxmc", true,
            //  Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.LblZCYHMC.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "zcyhlx", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.LblZRZHMC.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "zrzhmc", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.LblZRYHMC.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "zryhlxmc", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
           // this.lalzrzhlx.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.PriBds, "zhlxmc", true,
           //Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
        }
        #endregion

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CmbZCZH.SelectedIndex <0)
            {
                ClsMsgBox.Ts("请选择转出账号！", this, CmbZCZH, ObjG.CustomMsgBox);
                return;
            }
            ClsD.TextBoxTrim(this);
            if (CmbZCZH.Text.Equals(CmbZRZH.Text))
            {
                ClsMsgBox.Ts("转出账号和转入账号不能一致！", this, CmbZCZH, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtZzje.Text))
            {
                ClsMsgBox.Ts("转账金额不能为空！", this, TxtZzje, ObjG.CustomMsgBox);
                return;
            }
            if (!ClsRegEx.IsDecimal(TxtZzje.Text))
            {
                ClsMsgBox.Ts("转账金额格式不正确！", this, TxtZzje, ObjG.CustomMsgBox);
                return;
            }
            if (!ClsRegEx.IsDecimal(TxtQrzzje.Text))
            {
                ClsMsgBox.Ts("确认转账金额格式不正确！", this, TxtZzje, ObjG.CustomMsgBox);
                return;
            }
            if (Convert.ToDecimal(TxtZzje.Text) != Convert.ToDecimal(TxtQrzzje.Text))
            {
                ClsMsgBox.Ts("转账金额与确认转账金额不一致！", this, TxtQrzzje, ObjG.CustomMsgBox);
                return;
            }
            PriRow.insczyid = ObjG.Renyuan.id;
            PriRow.insczyxm = ObjG.Renyuan.xm;
            PriRow.inssj = DateTime.Now;
            try
            {
                PriBds.EndEdit();
                if (VzzlogTableAdapter1.Update(PriRow) > 0)
                {
                    this.Close();
                    ClsMsgBox.Ts("手动调拨成功！", ObjG.CustomMsgBox, this);
                }
                else
                    ClsMsgBox.Ts("手动调拨失败！", ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("手动调拨失败", ex, ObjG.CustomMsgBox, this);
            }
        }

        private void BtnCancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbZCZH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbZCZH.SelectedIndex <= 0)
            {
                LblZCZHMC.Text = "";
                LblZCYHMC.Text = "";
                lalzczhlx.Text = "";
            }
            DataRow[] dr = PriDt.Select("zh = '" + CmbZCZH.Text + "'");
            if (dr.Count() > 0)
            {
                LblZCZHMC.Text = dr[0]["zhmc"].ToString();
                LblZCYHMC.Text = dr[0]["yhlxmc"].ToString();
                lalzczhlx.Text = dr[0]["zhlxmc"].ToString();
            }
        }
    }
}