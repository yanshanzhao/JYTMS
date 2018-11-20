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

namespace FMS.CWGL.XTWSP
{
    public partial class FrmXTSRSPMX : Form
    {
        private ClsG ObjG;
        private int srid;
        public FrmXTSRSPMX()
        {
            InitializeComponent();
        }

        public void Prepare(int asrid)
        {
            srid = asrid;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;

            TfmsxtwsrmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;

            DataTable dt = ClsRWMSSQLDb.GetDataTable("SELECT lsh,lxs,je,sqr,bz FROM  Vfmsxtwpc where id=" + srid, ClsGlobals.CntStrTMS);

            this.Txtbh.Text = dt.Rows[0][0].ToString();
            Txtlx.Text = dt.Rows[0][1].ToString();
            this.Txtje.Text = dt.Rows[0][2].ToString();
            this.Txtr.Text = dt.Rows[0][3].ToString();
            Txtbz.Text = dt.Rows[0][4].ToString();
            TfmsxtwsrmxTableAdapter1.FillByWhere(DSSP1.tfmsxtwsrmx, " where srid= " + srid);
        }

        private void BtnSPtg_Click(object sender, EventArgs e)
        {
            try
            {
                string SQL = string.Format(" update  tfmsxtwsrpc set spsj='{0}', sprid='{1}',sprzh='{2}',spr='{3}',zt='{4}' where id={5}",
                 DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, 1, srid);
                if (ClsRWMSSQLDb.ExecuteCmd(SQL, ClsGlobals.CntStrTMS) > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    ClsMsgBox.Ts("操作成功！", ObjG.CustomMsgBox, this);
                }  
               
              
               
            }
            catch (Exception ex)
            {
                ClsMsgBox.Ts("操作异常！" + ex.Message.ToString(), ObjG.CustomMsgBox, this);
            } 
        }

        private void BtnSPBtg_Click(object sender, EventArgs e)
        {
            try
            {
                string SQL = string.Format(" update  tfmsxtwsrpc set spsj='{0}', sprid='{1}',sprzh='{2}',spr='{3}',zt='{4}' where id={5}",
                 DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, 2, srid);
                if (ClsRWMSSQLDb.ExecuteCmd(SQL, ClsGlobals.CntStrTMS) > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    ClsMsgBox.Ts("操作成功！", ObjG.CustomMsgBox, this);
                }
              
            }
            catch (Exception ex)
            {
                ClsMsgBox.Ts("操作异常！" + ex.Message.ToString(), ObjG.CustomMsgBox, this);
            } 
        }

        private void BtnSPgb_Click(object sender, EventArgs e)
        {
            
                this.Close();
            
           
        } 
    }
}