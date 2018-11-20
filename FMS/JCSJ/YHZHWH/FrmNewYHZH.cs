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
using FMS.JCSJ.YHZHWH.DSYHZHWHTableAdapters;
using FMS.JCSJ.YHZHWH;
using JY.Pub;
using JY.Pri;
using System.Text.RegularExpressions;
#endregion

namespace FMS.JCSJ.YHZHWH
{
    public partial class FrmNewYHZH : Form
    {
        #region 成员变量
        //private string PriServerKhhStr = JY.Pri.ClsOptions.DB.JHKHH;//建行客户号
        //private string PriServerPwdStr = JY.Pri.ClsOptions.DB.JHPWD;//建行密码
        //private string PriServerCZYH = JY.Pri.ClsOptions.DB.JHCZYH;//建行操作员号
        //private string PriServerDKBH = JY.Pri.ClsOptions.DB.JHDKBH;//建行代扣编号
        //private string PriServerDKYTBH = JY.Pri.ClsOptions.DB.JHDKYTBH;//建行代扣用途编号
        public EnumNEDD PubEnumNEDD;
        public int Pubzhlx = 0;
        private BindingSource Bds;
        private VyhzhTableAdapter VyhzhTableAdapter1;
        private DSYHZHWH DSYHZHWH1;
        private DSYHZHWH.VyhzhRow PriRow;
        private ClsG ObjG;
        #endregion
        public FrmNewYHZH()
        {
            InitializeComponent();
        }
        #region Prepare
        public void Prepare(EnumNEDD aEnumNEDD, BindingSource aBds, VyhzhTableAdapter aVyhzhTableAdapter,
            DSYHZHWH aDSYHZHWH, int ajgid)
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];

            //if (ObGj.Renyuan.loginName == "hds")
            //{
            //    this.Txtyhye.ReadOnly = false;
            //    this.Txtye.ReadOnly = false;
            //}
            PubEnumNEDD = aEnumNEDD;
            Bds = aBds;
            CmbBd();
            ClsPopulateCmbDsS.PopuZh_yhzhxz(Cmbzhxz);
            ClsPopulateCmbDsS.PopuZh_yhzhzt(Cmbzt);
            Rebind();
            VyhzhTableAdapter1 = aVyhzhTableAdapter;
            DSYHZHWH1 = aDSYHZHWH;
            if (PubEnumNEDD == EnumNEDD.New)
            {
                Bds.AddNew();
                PriRow = ((DataRowView)Bds.Current).Row as DSYHZHWH.VyhzhRow;
                PriRow.jgid = ajgid;
            }
            else if (PubEnumNEDD == EnumNEDD.Edit)
            {
                PriRow = ((DataRowView)Bds.Current).Row as DSYHZHWH.VyhzhRow;
                this.Text = "银行明细";
                //UpdateYhye();
            }
        }
        private void CmbBd()
        {
            DataTable dtyhlx = ClsRWMSSQLDb.GetDataTable(" select id,jc from tyhlx where hdzt='Y' order by bh ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.Cmbyhlx, dtyhlx, "id", "jc");
            DataTable dtzhlxmc = ClsRWMSSQLDb.GetDataTable(" select id,mc from tfmszhlx ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.Cmbzhlxmc, dtzhlxmc, "id", "mc");
        }

        #endregion
        #region 控件绑定
        private void Rebind()
        {
            //this.Txtwybh.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "wybm", true,
            //    Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.Cmbyhlx.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("SelectedValue", this.Bds, "yhlxid", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.Cmbzhxz.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("SelectedValue", this.Bds, "zhxz", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.Cmbzt.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("SelectedValue", this.Bds, "zt", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.Cmbzhlxmc.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("SelectedValue", this.Bds, "zhlxid", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.Txtzh.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "zh", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.Txtqrzh.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "qrzh", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.Txtzhmc.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "zhmc", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.Txtkhh.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "khh", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            this.TxtLhh.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "lhh", true,
                Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            //this.TxtXh.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "xh", true,
            //   Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
            //this.Txtkhhdm.DataBindings.Add(new Gizmox.WebGUI.Forms.Binding("Text", this.Bds, "khhdm", true,
            //    Gizmox.WebGUI.Forms.DataSourceUpdateMode.OnValidation));
        }
        #endregion
        #region 保存
        private void BtnSave_Click(object sender, EventArgs e)
        {
            #region 数据验证
            ClsD.TextBoxTrim(this);
            ClsD.SetMaxLength(this, DSYHZHWH1.Vyhzh);
            //if (string.IsNullOrEmpty(Txtwybh.Text))
            //{
            //    ClsMsgBox.Ts("请输入网银编码", this, Txtwybh);
            //    return;
            //}
            //if (string.IsNullOrEmpty(TxtXh.Text)) 
            //{
            //    ClsMsgBox.Ts("请输入序号！", this, TxtXh, ObjG.CustomMsgBox);
            //    return;
            //}
            if (string.IsNullOrEmpty(Txtzhmc.Text))
            {
                ClsMsgBox.Ts("请输入账户名称！", this, Txtzhmc, ObjG.CustomMsgBox);
                return;
            }
            if (this.Cmbyhlx.SelectedIndex < 0)
            {
                ClsMsgBox.Ts("请选择银行类型！", this, Cmbyhlx, ObjG.CustomMsgBox);
                return;
            }
            if (TxtLhh.Text.Trim().Length>0)
            {
                if (!ClsRegEx.IsShiShu(TxtLhh.Text.Trim()))
                {
                    ClsMsgBox.Ts("请输入正确的联行号！", this, TxtLhh, ObjG.CustomMsgBox);
                    return;
                }
            }
            if (string.IsNullOrEmpty(Txtzh.Text))
            {
                ClsMsgBox.Ts("请输入银行账号！", this, Txtzh, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(Txtqrzh.Text))
            {
                ClsMsgBox.Ts("请输入确认银行账号！", this, Txtqrzh, ObjG.CustomMsgBox);
                return;
            }
            //if (!ClsRegEx.IsYinHangZhangHao(this.Txtzh.Text))
            //{
            //    ClsMsgBox.Ts("输入的帐号格式不正确！", this, Txtzh);
            //    return;
            //}
            if (this.Txtzh.Text != this.Txtqrzh.Text)
            {
                ClsMsgBox.Ts("两次输入的账户不一致，请重新输入！", this, Txtqrzh, ObjG.CustomMsgBox);
                this.Txtqrzh.Text = "";
                return;
            }
            if (this.Cmbzhxz.SelectedIndex < 0)
            {
                ClsMsgBox.Ts("请选择账户性质！", this, Cmbzhxz, ObjG.CustomMsgBox);
                return;
            }
            if (this.Cmbzhlxmc.SelectedIndex < 0)
            {
                ClsMsgBox.Ts("请选择账户类型！", this, Cmbzhlxmc, ObjG.CustomMsgBox);
                return;
            }
            if (this.Cmbzt.SelectedIndex < 0)
            {
                ClsMsgBox.Ts("请选择银行账户状态！", this, Cmbzt, ObjG.CustomMsgBox);
                return;
            }
            //if (string.IsNullOrEmpty(Txtkhh.Text)) 
            //{
            //    ClsMsgBox.Ts("请输入开户行！",this,Txtkhh,ObjG.CustomMsgBox);
            //    return;
            //}
            //double n;
            //if (!double.TryParse(this.Txtye.Text, out n))
            //{
            //    ClsMsgBox.Ts("余额为数字", this, Txtye);
            //    return;
            //}
            //double m;
            //if (!double.TryParse(this.Txtyhye.Text, out m))
            //{
            //    ClsMsgBox.Ts("银行余额为数字", this, Txtyhye);
            //    return;
            //}
            //if (Convert.ToDecimal(this.Txtye.Text) < 0)
            //{
            //    ClsMsgBox.Ts("余额大于0", this, Txtye);
            //    return;
            //}
            //if (Convert.ToDecimal(this.Txtyhye.Text) < 0)
            //{
            //    ClsMsgBox.Ts("银行余额大于0", this, Txtyhye);
            //    return;
            //}
            #endregion
            try
            {
                Bds.EndEdit();
                VyhzhTableAdapter1.Update(PriRow);
                this.DialogResult = DialogResult.OK;
                Pubzhlx = PriRow.zhlxid;
                this.Close();
                if (PubEnumNEDD == EnumNEDD.New)
                    ClsMsgBox.Ts("新增成功！" + Environment.NewLine + "户名：" + Txtzhmc.Text + Environment.NewLine + "银行账户：" + Txtzh.Text, ObjG.CustomMsgBox, this);
                else
                    ClsMsgBox.Ts("编辑成功！" + Environment.NewLine + "户名：" + Txtzhmc.Text + Environment.NewLine + "银行账户：" + Txtzh.Text, ObjG.CustomMsgBox, this);
            }
            catch (Exception ex)
            {
                Pubzhlx = 0;
                //if(ex.Message.Contains("IX_Tfmsyhzh_1"))
                //{
                //    ClsMsgBox.Ts("序号重复，请重新输入!",this,TxtXh,ObjG.CustomMsgBox);
                //    return;
                //}
                ClsMsgBox.Cw("保存失败!", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion
        #region 取消
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        private void UpdateYhye()
        {
            //如建设银行 
            //Sockets();
        }
        #region Sockets()
        //public void Sockets()
        //{
        //    string[] strName=new string[]{};//返回字符的节点
        //    List<string> strValues = new List<string>();
        //    string[] XML_TXValues=new string[]{};//发送的报文
        //    string yhzh = this.Txtzh.Text;
        //    string yhlx = "";
        //    if (Cmbzhxz.Text == "G:对公")
        //    {
        //        if (PriRow.yhlxid == 63)
        //        {
        //            strName = new string[] { "RETURN_CODE", "BALANCE" };
        //            XML_TXValues = new string[] { GetXlh("S").ToString(), PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W0100", "CN", yhzh };
        //            yhlx = "6W0100.xml";
        //        }
        //    }
        //    else
        //    {

        //        DataRow dr = ClsRWMSSQLDb.GetDataRow(" select zh from Vyhzh where yhlxmc='" + Cmbyhlx.Text + "' and  zhxz='G' and zhlxid=5 and yhlxid= "+PriRow.yhlxid, ClsGlobals.CntStrFMS);
        //        if (PriRow.yhlxid == 63)
        //        {
        //            string DGyhzh = "";
        //            if (dr == null)
        //                return;
        //            strName = new string[] { "RETURN_CODE", "RETURN_MSG" }; 
        //             DGyhzh = dr[0].ToString();
        //             XML_TXValues = new string[] { GetXlh("S").ToString(), PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W1303", "CN", DGyhzh, PriServerDKBH, Txtzh.Text, Txtzhmc.Text, "10000000", PriServerDKYTBH, "", "", "", "", "" };
        //            yhlx = "6W1303.xml";
        //        }
        //    }
        //    if (yhlx == "")
        //        return;
        //    try
        //    {
        //        strValues = ClsGetXML.GetListStr(strName, ClsSockets.sendStr(XML_TXValues, yhlx));
        //    }
        //    catch (Exception)
        //    {
        //        ClsMsgBox.Ts("出现异常！");
        //        this.Close();
        //    } 
        //    if (strValues[0] != "000000" && Cmbzhxz.Text == "G:对公")
        //        return;
        //    decimal RowYhye = GetNumber(strValues[1].ToString());
        //    //decimal n;
        //    //string str = strValues[1].ToString();
        //    //if (decimal.TryParse(str, out n))
        //    //{
        //    //    RowYhye = Convert.ToDecimal(strValues[1]);
        //    //} 
        //    //if(strValues[1].IndexOf("+")>0)
        //    //{ //银行账户账户中余额(个人的银行账户)
        //    //    RowYhye = Convert.ToDecimal(strValues[1].Substring(strValues[1].IndexOf("+")).ToString());
        //    //}
        //    this.Txtyhye.Text = RowYhye.ToString();
        //    PriRow.yhye = RowYhye;
        //    if (RowYhye >= 0)
        //    {
        //        PriRow.yhye = RowYhye;
        //        ClsRWMSSQLDb.ExecuteCmd(" update tyhzh set yhye=" + RowYhye + " where id= " + PriRow.id, ClsGlobals.CntStrFMS);
        //        VyhzhTableAdapter1.Update(PriRow);
        //    }
        //}
        #endregion
        private decimal GetNumber(string str)
        {
            decimal result = 0;
            if (str.LastIndexOf('额') > 0)
            {
                string[] s1 = str.Substring(str.LastIndexOf('额')).Split('.');
                str = s1[0] + "." + s1[1].Substring(0, 2);
                // 正则表达式剔除非数字字符（不包含小数点.）
                str = Regex.Replace(str, @"[^\d.\d]", "");
            }
            else
                return -1;
            try
            {
                // 如果是数字，则转换为decimal类型
                if (Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$"))
                    result = decimal.Parse(str);
            }
            catch (Exception)
            {
                return -1;
            }
            return result;
        }
        private int GetXlh(string ywlx)
        {
            return ClsRWMSSQLDb.GetInt(" insert into tqqxlh values('" + ywlx + "') Select SCOPE_IDENTITY()", ClsGlobals.CntStrTMS);
        }
    }
}
