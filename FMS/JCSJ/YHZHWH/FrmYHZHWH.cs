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
using System.Text.RegularExpressions;
using JYPubFiles.Classes;
using System.Collections;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Configuration;

#endregion

namespace FMS.JCSJ.YHZHWH
{
    public partial class FrmYHZHWH : UserControl
    {
        #region 成员变量
        //private string PriServerKhhStr = JY.Pri.ClsOptions.DB.JHKHH;//建行客户号
        //private string PriServerPwdStr = JY.Pri.ClsOptions.DB.JHPWD;//建行密码
        //private string PriServerCZYH = JY.Pri.ClsOptions.DB.JHCZYH;//建行操作员号
        //private string PriServerDKBH = JY.Pri.ClsOptions.DB.JHDKBH;//建行代扣编号
        //private string PriServerDKYTBH = JY.Pri.ClsOptions.DB.JHDKYTBH;//建行代扣用途编号
        private string PriConStr; //数据库连接字符串
        private ClsG ObjG;
        private int PriJgId;
        //private int PriYhlxid;
        //private int PriNodeCount;//下一子节点的个数
        ArrayList al = new ArrayList();
        private TreeNode PriTn;
        private DSYHZHWH.VyhzhRow PriRow
        {
            get
            {
                if (Bds.Current == null)
                {
                    return null;
                }
                else
                {
                    return ((DataRowView)Bds.Current).Row as DSYHZHWH.VyhzhRow;
                }
            }
        }
        #endregion
        public FrmYHZHWH()
        {
            InitializeComponent();
        }
        #region Prepare()
        public void Prepare()
        {
            PriConStr = ClsGlobals.CntStrKj;
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            TjigouTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrKj;
            VyhzhTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            TjigouTableAdapter1.Fill(DSYHZHWH1.tjigou);
            //PnlBtns.BackColor = ClsOptions.WebCfg.PnlBtnsColor;
            CreateTree();
            //选中根结点
            TrV.SelectedNode = TrV.Nodes[0];
            //展开到第1级
            TrV.Nodes[0].Expand();
        }
        private void CreateTree()
        {
            TreeNode tn, tp;
            TreeNode[] tarr;
            DSYHZHWH.tjigouRow rp;
            DSYHZHWH.tjigouDataTable tjigou1 = TjigouTableAdapter1.GetData();
            int rootid = DSYHZHWH1.tjigou.First(r => r.mc == "佳怡集团").parentid;
            EnumerableRowCollection rows = tjigou1.Where(rw => true).OrderBy(rw => rw.level).ThenBy(rw => rw.xh);//按序号顺序加载
            int pid;
            foreach (DSYHZHWH.tjigouRow r in rows)
            {
                if (TrV.Nodes.Find(r.id.ToString(), true).Length == 1)
                    continue;
                tn = CreateANode(r);
                //if(r.IsparentidNull())
                pid = r.parentid;
                do
                {
                    if (pid == rootid)
                    {
                        TrV.Nodes.Add(tn);
                        break;
                    }
                    tarr = TrV.Nodes.Find(pid.ToString(), true);
                    //已经存在父节点
                    if (tarr.Count() > 0)
                    {
                        tarr[0].Nodes.Add(tn);
                        break;
                    }
                    //尚未存在父节点，依次生成各父节点
                    {
                        rp = tjigou1.Where(rw => rw.id == pid).ToArray()[0];
                        tp = CreateANode(rp);
                        tp.Nodes.Add(tn);
                        tn = tp;
                        pid = rp.parentid;
                    }
                } while (true);
            }
        }
        private TreeNode CreateANode(DSYHZHWH.tjigouRow r)
        {
            TreeNode tn = new TreeNode(r.mc);
            tn.Name = r.id.ToString();
            tn.Tag = r;
            tn.ContextMenu = CTxtMnu1;
            return tn;
        }
        #endregion
        #region 新增
        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmNewYHZH f = new FrmNewYHZH();
            f.Prepare(EnumNEDD.New, Bds, VyhzhTableAdapter1, DSYHZHWH1, PriJgId);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmNewYHZH f = sender as FrmNewYHZH;
            if (f.DialogResult != DialogResult.OK)
            {
                if (f.PubEnumNEDD == EnumNEDD.New)
                {
                    Bds.RemoveCurrent();
                }
                else if (f.PubEnumNEDD == EnumNEDD.Edit)
                    Bds.CancelEdit();
                DSYHZHWH1.RejectChanges();
            }
        }
        #endregion
        #region 编辑
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (PriRow == null)
                return;
            FrmNewYHZH f = new FrmNewYHZH();
            f.Prepare(EnumNEDD.Edit, Bds, VyhzhTableAdapter1, DSYHZHWH1, PriJgId);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }
        #endregion
        #region 删除
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (PriRow == null)
                return;
            ClsMsgBox.YesNo("是否删除该帐户", new EventHandler(DelYh), ObjG.CustomMsgBox, this);
        }
        private void DelYh(object sender, EventArgs e)
        {
            FrmMsgBox frm = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {
                try
                {
                    int id = PriRow.zhlxid;
                    VyhzhTableAdapter1.DeleteById(PriRow.id);
                    Bds.RemoveCurrent();
                    //int counts = this.DSYHZHWH1.Vyhzh.AsEnumerable().Where(rw => rw.RowState == DataRowState.Detached).Count(rw => rw.zhlxid == 1);
                    if (id == 1)
                        this.BtnNew.Enabled = true;
                    DSYHZHWH1.AcceptChanges();
                    ClsMsgBox.Ts("删除成功！", frm, this);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("删除银行账户失败！", ex, frm, this);
                }

            }
        }
        #endregion
        #region 双击Dgv
        private void Dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (PriRow == null)
                return;
            BtnEdit.PerformClick();
        }
        #endregion
        #region 机构账户
        private void TrV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            for (int i = 0; i < al.Count; i++) //先清除上一次查询的高亮显示
            {
                ((TreeNode)al[i]).BackColor = SystemColors.Window;
            }
            if (PriTn != null)
                PriTn.BackColor = SystemColors.Window;
            PriTn = TrV.SelectedNode;
            TrV.SelectedNode.BackColor = Color.LightBlue;
            this.BtnNew.Enabled = true;//新增按钮
            DSYHZHWH.tjigouRow jg = (DSYHZHWH.tjigouRow)TrV.SelectedNode.Tag;
            PriJgId = jg.id;
            VyhzhTableAdapter1.FillByJgid(DSYHZHWH1.Vyhzh, PriJgId);
            int counts = this.DSYHZHWH1.Vyhzh.AsEnumerable().Where(rw => rw.RowState == DataRowState.Unchanged).Count(rw => rw.zhlxid == 1);
            if (counts == 0)
                return;
        }
        #region Sockets()
        public void Sockets()
        {
            //for (int i = 0; i < Dgv.RowCount; i++)
            //{
            //    string[] strName = new string[] { };//返回字符的节点
            //    List<string> strValues = new List<string>();
            //    string[] XML_TXValues = new string[] { };//发送的报文
            //    string yhzh = Dgv.Rows[i].Cells["DgvColTxtzh"].Value.ToString();
            //    string ywlx = "";
            //    string zhxz = Dgv.Rows[i].Cells["DgvColTxtzhxzmc"].Value.ToString();
            //    string zhmc = Dgv.Rows[i].Cells["DgvColTxtzhmc"].Value.ToString();
            //    PriYhlxid = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtyhlxid"].Value);
            //    if (zhxz == "对公")
            //    {
            //        if (PriYhlxid == 63)
            //        {
            //            strName = new string[] { "RETURN_CODE", "BALANCE" };
            //            XML_TXValues = new string[] { GetXlh("S").ToString(), PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W0100", "CN", yhzh };
            //            ywlx = "6W0100.xml";
            //        }
            //    }
            //    else
            //    { 
            //        DataRow dr = ClsRWMSSQLDb.GetDataRow(" select zh from Vyhzh where   zhxz='G' and zhlxid=5 and yhlxid=" + PriYhlxid, ClsGlobals.CntStrFMS);
            //        if (PriYhlxid == 63)
            //        {
            //            string DGyhzh = "";
            //            strName = new string[] { "RETURN_CODE", "RETURN_MSG" };
            //            if (dr == null)
            //                return;
            //            DGyhzh = dr[0].ToString();
            //            XML_TXValues = new string[] { GetXlh("S").ToString(), PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W1303", "CN", DGyhzh, PriServerDKBH, yhzh, zhmc, "10000000", PriServerDKYTBH, "", "", "", "", "" };
            //            ywlx = "6W1303.xml";
            //        }
            //    }
            //    if (ywlx == "")
            //        continue;
            //    string recvStr = ClsSockets.sendStr(XML_TXValues, ywlx);
            //    if (recvStr == "")
            //        continue;
            //    strValues = ClsGetXML.GetListStr(strName, recvStr);
            //    if (strValues[0] != "000000" && zhxz == "对公")
            //        continue;
            //    decimal RowYhye = GetNumber(strValues[1].ToString());
            //    //decimal n;
            //    //string str = strValues[1].ToString();
            //    //if (decimal.TryParse(str, out n))
            //    //{
            //    //    RowYhye = Convert.ToDecimal(strValues[1]);
            //    //}
            //    //else
            //    //{ //银行账户账户中余额(个人的银行账户)
            //    //    RowYhye = Convert.ToDecimal(strValues[1].Substring(strValues[1].IndexOf("+")).ToString());
            //    //}
            //    if (RowYhye >= 0) 
            //        ClsRWMSSQLDb.ExecuteCmd(" update tyhzh set yhye=" + RowYhye + " where  zh='" + yhzh + "'", ClsGlobals.CntStrFMS); 
            //}
            //VyhzhTableAdapter1.FillByJgid(DSYHZHWH1.Vyhzh, PriJgId);
        }
        #endregion

        private decimal GetNumber(string str)
        {
            decimal result = 0;
            string Str = str;
            if (str != null && str != string.Empty)
            {
                // 正则表达式剔除非数字字符（不包含小数点.）
                str = Regex.Replace(str, @"[^\d.\d]", "");
                //筛选的字符串是否是连续的
                if (!(Str.IndexOf(str) >= 0))
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
            }
            return result;
        }
        private int GetXlh(string ywlx)
        {
            return ClsRWMSSQLDb.GetInt(" insert into tqqxlh values('" + ywlx + "') Select SCOPE_IDENTITY()", ClsGlobals.CntStrTMS);
        }
        #endregion
        #region 新增账户
        private void MnuNew_Click(object sender, EventArgs e)
        {
            FrmNewYHZH f = new FrmNewYHZH();
            f.Prepare(EnumNEDD.New, Bds, VyhzhTableAdapter1, DSYHZHWH1, PriJgId);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }
        #endregion

        private void BtnSx_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            Sockets();
        }


        private void BtnSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < al.Count; i++) //先清除上一次查询的高亮显示
            {
                ((TreeNode)al[i]).BackColor = SystemColors.Window;
            }
            al.Clear();//清除数组
            if (string.IsNullOrEmpty(TxtCZ.Text))
                return;
            TrV.CollapseAll();//节点关闭
            TrV.Nodes[0].Expand();
            if (TxtCZ.Text != "")//不为空判断
            {
                foreach (TreeNode tn in TrV.Nodes)
                {
                    funHightLight(tn);//高亮显示方法
                }
            }

        }

        private void funHightLight(TreeNode tn)
        {
            if (tn.Text.Contains(TxtCZ.Text))
            {
                tn.BackColor = Color.LightBlue;
                al.Add(tn);//添加进数组
                funOpen(tn);//父节点展开
            }
            if (tn.Nodes.Count > 0)//如果有子节点,子节点判断
            {
                foreach (TreeNode tnc in tn.Nodes)
                {
                    funHightLight(tnc);
                }
            }
        }

        private void funOpen(TreeNode tn)
        {
            if (tn.Parent != null)
            {
                tn.Parent.Expand();
                funOpen(tn.Parent);
            }
        }

        private TreeNode FindNode(TreeNode tnParent, string strValue)
        {
            if (tnParent == null)
                return null;
            if (tnParent.Text.Contains(strValue))
                return tnParent;
            TreeNode tnRet = null;
            foreach (TreeNode tn in tnParent.Nodes)
            {
                tnRet = FindNode(tn, strValue);
                if (tnRet != null)
                {
                    tnRet.Expand();
                }
            }
            return tnRet;
        }

        #region 导出
        private void BtnExl_Click(object sender, EventArgs e)
        {
            string SQLstr = "SELECT jgmc,zhlxmc,yhlxmc,zhmc,zh,zhxzmc,khh,ztmc,dqmc FROM dbo.Vfmsyhzh";
            DataTable dt = ClsRWMSSQLDb.GetDataTable(SQLstr, ClsGlobals.CntStrTMS);
            if (dt.Rows.Count == 0)
            {
                ClsMsgBox.Ts("没有要导出的信息！", ObjG.CustomMsgBox, this);
                return;
            }
            try
            {
                string PriFln = "银行账户明细" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//文件名称     
                string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//存放文件路径
                HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //使用NPOI创建Excel文件
                //写入数据
                HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
                sheet1.DefaultColumnWidth = 17;
                sheet1.SetColumnWidth(0, 32 * 256);
                //行名的的设置
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                LieFont.FontHeightInPoints = 10;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                styleRow.SetFont(LieFont);
                row0.CreateCell(0).SetCellValue("机构名称");
                row0.Cells[0].CellStyle = styleRow;
                row0.CreateCell(1).SetCellValue("账户类型");
                row0.Cells[1].CellStyle = styleRow;
                row0.CreateCell(2).SetCellValue("银行类型");
                row0.Cells[2].CellStyle = styleRow;
                row0.CreateCell(3).SetCellValue("账户名称");
                row0.Cells[3].CellStyle = styleRow;
                row0.CreateCell(4).SetCellValue("账号");
                row0.Cells[4].CellStyle = styleRow;
                row0.CreateCell(5).SetCellValue("账户性质");
                row0.Cells[5].CellStyle = styleRow;
                row0.CreateCell(6).SetCellValue("开户行");
                row0.Cells[6].CellStyle = styleRow;
                row0.CreateCell(7).SetCellValue("状态");
                row0.Cells[7].CellStyle = styleRow;
                row0.CreateCell(8).SetCellValue("大区名称");
                row0.Cells[8].CellStyle = styleRow;
                int roowIndex = 1;
                HSSFCellStyle cellStyleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;
                for (int m = 0; m < dt.Rows.Count; m++)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    for (int i = 0; i < 9; i++)
                    {
                        hssfrow.CreateCell(i).SetCellValue(dt.Rows[m][i].ToString());
                        hssfrow.Cells[i].CellStyle = cellStyleRow;
                    }
                    roowIndex++;
                }
                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
                this.ctrlDownLoad1.download(PriFlp, true);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("银行账户明细导出失败", ex);
            }
        }
        #endregion

    }
}