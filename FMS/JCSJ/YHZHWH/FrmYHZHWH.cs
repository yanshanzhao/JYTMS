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
        #region ��Ա����
        //private string PriServerKhhStr = JY.Pri.ClsOptions.DB.JHKHH;//���пͻ���
        //private string PriServerPwdStr = JY.Pri.ClsOptions.DB.JHPWD;//��������
        //private string PriServerCZYH = JY.Pri.ClsOptions.DB.JHCZYH;//���в���Ա��
        //private string PriServerDKBH = JY.Pri.ClsOptions.DB.JHDKBH;//���д��۱��
        //private string PriServerDKYTBH = JY.Pri.ClsOptions.DB.JHDKYTBH;//���д�����;���
        private string PriConStr; //���ݿ������ַ���
        private ClsG ObjG;
        private int PriJgId;
        //private int PriYhlxid;
        //private int PriNodeCount;//��һ�ӽڵ�ĸ���
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
            //ѡ�и����
            TrV.SelectedNode = TrV.Nodes[0];
            //չ������1��
            TrV.Nodes[0].Expand();
        }
        private void CreateTree()
        {
            TreeNode tn, tp;
            TreeNode[] tarr;
            DSYHZHWH.tjigouRow rp;
            DSYHZHWH.tjigouDataTable tjigou1 = TjigouTableAdapter1.GetData();
            int rootid = DSYHZHWH1.tjigou.First(r => r.mc == "��������").parentid;
            EnumerableRowCollection rows = tjigou1.Where(rw => true).OrderBy(rw => rw.level).ThenBy(rw => rw.xh);//�����˳�����
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
                    //�Ѿ����ڸ��ڵ�
                    if (tarr.Count() > 0)
                    {
                        tarr[0].Nodes.Add(tn);
                        break;
                    }
                    //��δ���ڸ��ڵ㣬�������ɸ����ڵ�
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
        #region ����
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
        #region �༭
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
        #region ɾ��
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (PriRow == null)
                return;
            ClsMsgBox.YesNo("�Ƿ�ɾ�����ʻ�", new EventHandler(DelYh), ObjG.CustomMsgBox, this);
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
                    ClsMsgBox.Ts("ɾ���ɹ���", frm, this);
                }
                catch (Exception ex)
                {
                    ClsMsgBox.Cw("ɾ�������˻�ʧ�ܣ�", ex, frm, this);
                }

            }
        }
        #endregion
        #region ˫��Dgv
        private void Dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (PriRow == null)
                return;
            BtnEdit.PerformClick();
        }
        #endregion
        #region �����˻�
        private void TrV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            for (int i = 0; i < al.Count; i++) //�������һ�β�ѯ�ĸ�����ʾ
            {
                ((TreeNode)al[i]).BackColor = SystemColors.Window;
            }
            if (PriTn != null)
                PriTn.BackColor = SystemColors.Window;
            PriTn = TrV.SelectedNode;
            TrV.SelectedNode.BackColor = Color.LightBlue;
            this.BtnNew.Enabled = true;//������ť
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
            //    string[] strName = new string[] { };//�����ַ��Ľڵ�
            //    List<string> strValues = new List<string>();
            //    string[] XML_TXValues = new string[] { };//���͵ı���
            //    string yhzh = Dgv.Rows[i].Cells["DgvColTxtzh"].Value.ToString();
            //    string ywlx = "";
            //    string zhxz = Dgv.Rows[i].Cells["DgvColTxtzhxzmc"].Value.ToString();
            //    string zhmc = Dgv.Rows[i].Cells["DgvColTxtzhmc"].Value.ToString();
            //    PriYhlxid = Convert.ToInt32(Dgv.Rows[i].Cells["DgvColTxtyhlxid"].Value);
            //    if (zhxz == "�Թ�")
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
            //    if (strValues[0] != "000000" && zhxz == "�Թ�")
            //        continue;
            //    decimal RowYhye = GetNumber(strValues[1].ToString());
            //    //decimal n;
            //    //string str = strValues[1].ToString();
            //    //if (decimal.TryParse(str, out n))
            //    //{
            //    //    RowYhye = Convert.ToDecimal(strValues[1]);
            //    //}
            //    //else
            //    //{ //�����˻��˻������(���˵������˻�)
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
                // ������ʽ�޳��������ַ���������С����.��
                str = Regex.Replace(str, @"[^\d.\d]", "");
                //ɸѡ���ַ����Ƿ���������
                if (!(Str.IndexOf(str) >= 0))
                    return -1;
                try
                {
                    // ��������֣���ת��Ϊdecimal����
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
        #region �����˻�
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
            for (int i = 0; i < al.Count; i++) //�������һ�β�ѯ�ĸ�����ʾ
            {
                ((TreeNode)al[i]).BackColor = SystemColors.Window;
            }
            al.Clear();//�������
            if (string.IsNullOrEmpty(TxtCZ.Text))
                return;
            TrV.CollapseAll();//�ڵ�ر�
            TrV.Nodes[0].Expand();
            if (TxtCZ.Text != "")//��Ϊ���ж�
            {
                foreach (TreeNode tn in TrV.Nodes)
                {
                    funHightLight(tn);//������ʾ����
                }
            }

        }

        private void funHightLight(TreeNode tn)
        {
            if (tn.Text.Contains(TxtCZ.Text))
            {
                tn.BackColor = Color.LightBlue;
                al.Add(tn);//��ӽ�����
                funOpen(tn);//���ڵ�չ��
            }
            if (tn.Nodes.Count > 0)//������ӽڵ�,�ӽڵ��ж�
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

        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            string SQLstr = "SELECT jgmc,zhlxmc,yhlxmc,zhmc,zh,zhxzmc,khh,ztmc,dqmc FROM dbo.Vfmsyhzh";
            DataTable dt = ClsRWMSSQLDb.GetDataTable(SQLstr, ClsGlobals.CntStrTMS);
            if (dt.Rows.Count == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            try
            {
                string PriFln = "�����˻���ϸ" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
                string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
                HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
                //д������
                HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
                sheet1.DefaultColumnWidth = 17;
                sheet1.SetColumnWidth(0, 32 * 256);
                //�����ĵ�����
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(0);
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                LieFont.FontHeightInPoints = 10;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                styleRow.SetFont(LieFont);
                row0.CreateCell(0).SetCellValue("��������");
                row0.Cells[0].CellStyle = styleRow;
                row0.CreateCell(1).SetCellValue("�˻�����");
                row0.Cells[1].CellStyle = styleRow;
                row0.CreateCell(2).SetCellValue("��������");
                row0.Cells[2].CellStyle = styleRow;
                row0.CreateCell(3).SetCellValue("�˻�����");
                row0.Cells[3].CellStyle = styleRow;
                row0.CreateCell(4).SetCellValue("�˺�");
                row0.Cells[4].CellStyle = styleRow;
                row0.CreateCell(5).SetCellValue("�˻�����");
                row0.Cells[5].CellStyle = styleRow;
                row0.CreateCell(6).SetCellValue("������");
                row0.Cells[6].CellStyle = styleRow;
                row0.CreateCell(7).SetCellValue("״̬");
                row0.Cells[7].CellStyle = styleRow;
                row0.CreateCell(8).SetCellValue("��������");
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
                ClsMsgBox.Cw("�����˻���ϸ����ʧ��", ex);
            }
        }
        #endregion

    }
}