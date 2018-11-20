#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Collections;
using JY.Pri;
using System.Linq;
using JY.Pub;
using JYPubFiles.Classes;
using System.Configuration;
using NPOI.HSSF.UserModel;
using System.IO;
#endregion

namespace FMS.ZYGL.POSBMWH
{
    public partial class FrmPosBmwh : UserControl
    {
        private string PriConStr; //���ݿ������ַ���
        private ClsG ObjG;
        //private int PriNodeCount;//��һ�ӽڵ�ĸ���
        ArrayList al = new ArrayList();
        private DSPOSWH.tjigouRow PriJgRow
        {
            get
            {
                if (Bds.Current == null)
                    return null;
                return ((DataRowView)Bds.Current).Row as DSPOSWH.tjigouRow;
            }
            set
            {
                PriJgRow = value;
            }
        }
        public FrmPosBmwh()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            PriConStr = ClsGlobals.CntStrKj;
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            TjigouTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrKj;
            TjigouTableAdapter1.Fill(DSPOSWH1.tjigou);
            PnlBtns.BackColor = ClsOptions.WebCfg.PnlBtnsColor;
            CreateTree();
            //ѡ�и����
            TrV.SelectedNode = TrV.Nodes[0];
            //չ������1��
            TrV.Nodes[0].Expand();
            this.TrV.AfterSelect += new Gizmox.WebGUI.Forms.TreeViewEventHandler(this.TrV_AfterSelect);
        }
        private void CreateTree()
        {
            TreeNode tn, tp;
            TreeNode[] tarr;
            DSPOSWH.tjigouRow rp;
            DSPOSWH.tjigouDataTable tjigou1 = TjigouTableAdapter1.GetData();
            int rootid = DSPOSWH1.tjigou.First(r => r.mc == "��������").parentid;
            EnumerableRowCollection rows = tjigou1.Where(rw => true).OrderBy(rw => rw.level).ThenBy(rw => rw.xh);//�����˳�����
            int pid;
            foreach (DSPOSWH.tjigouRow r in rows)
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
        private TreeNode CreateANode(DSPOSWH.tjigouRow r)
        {
            TreeNode tn = new TreeNode(r.mc);
            tn.Name = r.id.ToString();
            tn.Tag = r;
            return tn;
        }

        private void TrV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DSPOSWH.tjigouRow r = (DSPOSWH.tjigouRow)TrV.SelectedNode.Tag;
            TjigouTableAdapter1.FillByid(DSPOSWH1.tjigou, r.id);
            Dgv.DataSource = Bds;
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
            TreeNode treeNode2 = new TreeNode();
            string venueCode = "";
            if (tnParent == null) return null;
            if (tnParent.Text == strValue)
            {
                tnParent.Expand();
                return tnParent;
            }
            TreeNode tnRet = null;
            foreach (TreeNode tn in tnParent.Nodes)
            {
                //��ýڵ�Value
                if (venueCode == "")
                {
                    //��¼�ڵ�
                    treeNode2 = tn;
                    venueCode = tn.Text;
                }
                else
                {
                    //��ѡ��ڵ㷢���仯ʱ
                    if (venueCode != tn.Text)
                    {
                        treeNode2.Collapse();
                        venueCode = tn.Text;
                        treeNode2 = tn;
                    }
                }

                tnRet = FindNode(tn, strValue);
                if (tnRet != null) break;
            }
            return tnRet;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            //DSPOSWH.tjigouRow row = ((DataRowView)Bds.Current).Row as DSPOSWH.tjigouRow;
            if (!PriJgRow.IsposbhNull() && PriJgRow.posbh != "")
            {
                ClsMsgBox.Ts("�Ѿ�ά��POS��ţ�����޸���༭��", ObjG.CustomMsgBox, this);
                return;
            }
            FrmPosWHMX f = new FrmPosWHMX();
            f.ShowDialog();
            f.Prepare(PriJgRow);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            //DSPOSWH.tjigouRow row = ((DataRowView)Bds.Current).Row as DSPOSWH.tjigouRow;
            if (PriJgRow.IsposbhNull() || PriJgRow.posbh == "")
            {
                ClsMsgBox.Ts("��û��ά��POS��ţ�", ObjG.CustomMsgBox, this);
                return;
            }
            FrmPosWHMX f = new FrmPosWHMX();
            f.ShowDialog();
            f.Prepare(PriJgRow);
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (Bds.Current == null)
                return;
            //DSPOSWH.tjigouRow row = ((DataRowView)Bds.Current).Row as DSPOSWH.tjigouRow;
            if (PriJgRow.IsposbhNull() || PriJgRow.posbh == "")
            {
                ClsMsgBox.Ts("��û��ά��POS��ţ�����ɾ����", ObjG.CustomMsgBox, this);
                return;
            }
            ClsMsgBox.YesNo("ȷ��Ҫɾ��POS�����", new EventHandler(Delete), ObjG.CustomMsgBox, this);

        }
        public void Delete(object sender, EventArgs e)
        {
            Form f = sender as Form;
            FrmMsgBox frm = new FrmMsgBox();
            if (f.DialogResult == DialogResult.Yes)
            {
                PriJgRow.posbh =null;
                Bds.EndEdit();
                int count = TjigouTableAdapter1.Update(PriJgRow);
                if (count > 0)
                    ClsMsgBox.Ts("ɾ���ɹ���", f, this);
                else
                    ClsMsgBox.Ts("ɾ��ʧ�ܣ�", f, this);
            }
        }

        private void BtnElse_Click(object sender, EventArgs e)
        {
            string SQLstr = "SELECT mc,posbh FROM tjigou WHERE id>2 AND posbh IS NOT NULL";
            DataTable dt = ClsRWMSSQLDb.GetDataTable(SQLstr, ClsGlobals.CntStrKj);
            if (dt.Rows.Count == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            try
            {
                string PriFln = "��������POS��Ϣ" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
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
                row0.CreateCell(1).SetCellValue("POS����");
                row0.Cells[1].CellStyle = styleRow;
                int roowIndex = 1;
                HSSFCellStyle cellStyleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                cellStyleRow.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;
                for (int m = 0; m < dt.Rows.Count; m++)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    for (int i = 0; i < 2; i++)
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
                ClsMsgBox.Cw("POS������ϸ����ʧ��", ex);
            }
        }
    }
}