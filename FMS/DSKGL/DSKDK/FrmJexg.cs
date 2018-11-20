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
using FMS.DSKGL.DSKDK.DSDSKDKTableAdapters;
using JYPubFiles.Classes;
#endregion

namespace FMS.DSKGL.DSKDK
    {
    public partial class FrmJexg : Form
        {
        private ClsG ObjG;
        private DSDSKDK.VfmsdskdkRow PriRow;
        private DSDSKDK.TfmsdskdkjeRow PriDkjeRow;

        public FrmJexg()
            {
            InitializeComponent();
            }
        public void Prepare(DSDSKDK.VfmsdskdkRow row)
            {
            TfmsdskdkjeTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriRow = row;
            TxtOldJe.Text = PriRow.IsdskNull() ? "" : PriRow.dkje.ToString();
            PriDkjeRow = ((DataRowView)Bds.AddNew()).Row as DSDSKDK.TfmsdskdkjeRow;

            }
        /// <summary>
        /// 代收款打款确认
        /// </summary>
        public static void YesNo(string mess, EventHandler hdl, FrmMsgBox aMsgBox = null, Control aParControl = null, float aFontsize = 20)
            {
            aMsgBox.Text = "警告";
            aMsgBox.LblMess.Text = mess;
            aMsgBox.LblMess.Font = new System.Drawing.Font("黑体", aFontsize, System.Drawing.FontStyle.Bold);
            aMsgBox.LblMess.ForeColor = System.Drawing.Color.Red;
            aMsgBox.Btn1.Text = "确定";
            aMsgBox.Btn1.AutoSize = true;
            aMsgBox.Btn1.DialogResult = DialogResult.Yes;
            aMsgBox.Btn2.Text = "取消";
            aMsgBox.Btn2.Visible = true;
            aMsgBox.Btn2.AutoSize = true;
            aMsgBox.Btn2.DialogResult = DialogResult.No;
            aMsgBox.Btn1.TabStop = false;
            aMsgBox.FrmCloseHdl = hdl;
            aMsgBox.Tag = null;
            aMsgBox.ShowDialog();
            }
        private void BtnSave_Click(object sender, EventArgs e)
            {
            TxtNewJe.Text = TxtNewJe.Text.Trim();
            if (string.IsNullOrEmpty(TxtNewJe.Text))
                {
                ClsMsgBox.Ts("修改后金额不能为空！", ObjG.CustomMsgBox, this);
                return;
                }
            if (!ClsRegEx.IsJe(TxtNewJe.Text))
                {
                ClsMsgBox.Ts("修改后金额格式不正确！", ObjG.CustomMsgBox, this);
                return;
                }
            FrmMsgBox Box = new FrmMsgBox();
            string aNewJe = TxtNewJe.Text;
            if (aNewJe.LastIndexOf(".") < 0)
                aNewJe += ".00";
            YesNo("确认将金额" + PriRow.dkje + "修改为" + aNewJe + "吗？", new EventHandler(Save), Box, this);
            }
        void Save(object sender, EventArgs e)
            {
            Form f = sender as Form;
            FrmMsgBox frm = new FrmMsgBox();
            if (f.DialogResult != DialogResult.Yes)
                return;
            try
                {
                PriRow.dkje = Convert.ToDecimal(TxtNewJe.Text);
                TfmsdskdkjeTableAdapter1.Insert(Convert.ToDecimal(TxtNewJe.Text), PriRow.id, Convert.ToDecimal(TxtOldJe.Text), ObjG.Renyuan.id, ObjG.Renyuan.xm);
                this.Close();
                ClsMsgBox.Ts("保存成功！", ObjG.CustomMsgBox, this);
                }
            catch (Exception ex)
                {
                ClsMsgBox.Cw("保存失败！", ex, ObjG.CustomMsgBox, this);
                }
            }
        private void BtnCancel_Click(object sender, EventArgs e)
            {
            this.Close();
            }
        }
    }