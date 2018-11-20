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
using NPOI.HSSF.UserModel;
using System.IO;
using JYPubFiles.Classes;
using System.Data.SqlClient;
using FMS.SeleFrm;
#endregion
namespace FMS.DSKGL.ZBDSKFF
{
    public partial class FrmZBDSKFF : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private string PriYhlx;
        //private string PriYhzh;
        private int PriRowCount;//ѡ������
        private List<string> LstSql = new List<string>();//���½ɿ���ϸ�����ѵ�SQL���
        private List<int> LstDskid = new List<int>();
        private string PriWhere;
        private bool IsSumSxf;//�Ƿ����������
        private decimal PriSxf;//������
        private decimal PriZje;//�����ܽ��
        private decimal PriZje1;
        //private int PriFfzhid;//�����˻�ID 
        private string CmdText;//SQL���
        private string PriPcid;//�ձ�����
        private decimal PriJhJe;//ѡ�н����ܽ��
        private int PriJhCount;//ѡ�н��б���
        private string PriJhPcid;//��������ID
        private decimal PriNhje;//ѡ��ũ���ܽ��
        private int PriNhCount;//ѡ��ũ�б���
        private string PriNhPcid;//ũ������ID
        private decimal PriQlje;//ѡ����³�ܽ��(����)
        private int PriQlCount;//ѡ����³����(����)
        private string PriQlPcid;//��³����ID(����)
        private decimal PriQlHwje;//ѡ����³�ܽ��(����)
        private int PriQlHwCount;//ѡ����³����(����)
        private string PriQlHwPcid;//��³����ID(����)
        private decimal PriZxhnje;//ѡ�������ܽ��(����)
        private int PriZxhnCount;//ѡ�����ű���(����)
        private string PriZxhnPcid;//��������ID(����)
        private decimal PriZxhwje;//ѡ����³�ܽ��(����)
        private int PriZxhwCount;//ѡ����³����(����)
        private string PriZxhwPcid;//��������ID(����)

        private List<string> LstCkffSql = new List<string>();
        private DataTable dtFl;
        private DataRow[] rows;
        private int PriUpdRows;
        private int PriLevel;//��������Ƿ�Ϊ������
        private int PriSljgid;//�������ID
        private decimal PriSfje;//ʵ�ʷ����ܽ��
        #endregion

        public FrmZBDSKFF()
        {
            InitializeComponent();
        }
        #region ��ʼ������
        public void Prepare()
        {
            CmbDSZL.SelectedIndex = 0;
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            Vfmsdskff1TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            DataTable dtYhlx = ClsRWMSSQLDb.GetDataTable("select 'all' as bh,'--ȫ��--' as mc union all select bh,mc from Tfmsdskffyhlx    where zt=1  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbYhlx, dtYhlx, "bh", "mc");

            DataTable Tdskffsj = ClsRWMSSQLDb.GetDataTable("select 'all' as bh,'--ȫ��--' as mc,-1 AS sort   union all select bh,mc,sort from Tdskffsj    order by sort  ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.CmbCplx, Tdskffsj, "bh", "mc");


            ClsPopulateCmbDsS.PopuFMSDSKZZ_dszl(CmbDSZL);
            CmbYhlx.SelectedIndex = 0;
            CmbDSZL.SelectedIndex = 0;
            CmbQsfs.SelectedIndex = 0;
            CmbCplx.SelectedIndex = 0;
        }
        #endregion
        #region ��ҳȫѡ

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (Bds.Count == 0)
                return;
            if (!Convert.ToBoolean(Dgv.Rows[Dgv.FirstDisplayedScrollingRowIndex].Cells[DgvColTxtCheck.Name].Value))
                CheckAllPage();
            else
                NoCheckAllPage();
            LblDskCountText();
        }
        private void CheckAllPage()
        {
            if (Bds.Count == 0)
                return;
            int curPageFirstIndex = (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;//��ȡ��ǰҳ�ĵ�һ�е�RowIndex
            int lastPageSize = Dgv.RowCount - (Dgv.TotalPages - 1) * Dgv.ItemsPerPage; //��ȡ���һҳ������
            int curPageSize = Dgv.CurrentPage != Dgv.TotalPages ? Dgv.ItemsPerPage : lastPageSize; //��ȡÿҳ���������������һҳ��
            int curRowIndex = curPageFirstIndex;
            while (curRowIndex < (curPageFirstIndex + curPageSize))
            {
                if (!Convert.ToBoolean(Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value))
                {
                    if (!Validate(Dgv.Rows[curRowIndex]))
                    {
                        curRowIndex++;
                        continue;
                    }
                    PriRowCount++;
                    Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value = true;
                    PriZje += Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtZje.Name].Value);
                    PriYhfl(curRowIndex, true);
                    PriSfje += Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtSfje.Name].Value);
                }
                curRowIndex++;
            }
        }
        private void NoCheckAllPage()
        {
            if (Bds.Count == 0)
                return;
            int curPageFirstIndex = (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;//��ȡ��ǰҳ�ĵ�һ�е�RowIndex
            int lastPageSize = Dgv.RowCount - (Dgv.TotalPages - 1) * Dgv.ItemsPerPage; //��ȡ���һҳ������
            int curPageSize = Dgv.CurrentPage != Dgv.TotalPages ? Dgv.ItemsPerPage : lastPageSize; //��ȡÿҳ���������������һҳ��
            int curRowIndex = curPageFirstIndex;
            while (curRowIndex < (curPageFirstIndex + curPageSize))
            {
                if (Convert.ToBoolean(Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value).Equals(true))
                {
                    PriRowCount--;
                    Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value = false;
                    PriZje -= Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtZje.Name].Value);
                    PriYhfl(curRowIndex, false);
                    PriSfje -= Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtSfje.Name].Value);
                }
                curRowIndex++;
            }
        }


        #endregion
        #region ��ѯ��ť
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            Clear();
            ClsD.TextBoxTrim(this);
            DSZbdskff1.Clear();
            this.Chk.Checked = false;
            PriYhlx = CmbYhlx.Text;
            PriWhere = "  ";
            if (DtpQsStart.Checked)
                PriWhere += " and qssj >= '" + DtpQsStart.Value.Date + "'";
            if (DtpQsStop.Checked)
                PriWhere += " and qssj < '" + DtpQsStop.Value.AddDays(1).Date + "'";
            if (DtpSlStart.Checked)
                PriWhere += " and slsj >= '" + DtpSlStart.Value.Date + "'";
            if (DtpSlStop.Checked)
                PriWhere += " and slsj < '" + DtpSlStop.Value.AddDays(1).Date + "'";

            if (DtKsShsj.Checked)
                PriWhere += " and shsj >= '" + DtpSlStart.Value.Date + "'";
            if (DtJsShsj.Checked)
                PriWhere += " and shsj < '" + DtpSlStop.Value.AddDays(1).Date + "'";
            //�ж���������
            //PriWhere += Convert.ToInt32(CmbYhlx.SelectedValue) == 0 ? "" : Convert.ToInt32(CmbYhlx.SelectedValue) == 64 ? " and yhid not in(63,241) " : " and yhid =" + CmbYhlx.SelectedValue;
            if (!CmbYhlx.SelectedValue.Equals("all"))
                PriWhere += " and ffbh = '" + CmbYhlx.SelectedValue + "'";
            if (CmbDSZL.SelectedIndex != 0)
                PriWhere += " and lx ='" + CmbDSZL.SelectedValue + "'";
            if (CmbQsfs.SelectedIndex != 0)
                PriWhere += " and qsfs='" + CmbQsfs.Text + "'";
            if (CmbCplx.SelectedIndex != 0)
                PriWhere += " and cplx='" + CmbCplx.Text + "'";
            if(!string.IsNullOrEmpty(TxtEJGmc.Text))
                PriWhere += PriLevel == 3 ? " and qsjgid in(select id from jyjckj.dbo.tjigou  where parentLst like '%" + TxtEJGmc.Tag + "%')" : " and qsjgid=" + TxtEJGmc.Tag;
            PriWhere += string.IsNullOrEmpty(TxtBh.Text) ? "" : " and bh='" + TxtBh.Text + "'";

            PriWhere += " and ffdskzt=0 ";//�ֶ�ָ������ѯδ���ŵ�

            

            if (TxtBFwkh.Text.Trim().Length > 0)
            {
                PriWhere += "  and dskkhbh='" + TxtBFwkh.Text.Trim().ToString() + "' ";
            }
            if (TxtBJGmc.Text.Trim().Length > 0)
            {
                PriWhere += PriLevel == 3 ? " and sljgid in(select id from jyjckj.dbo.tjigou  where parentLst like '%" + PriSljgid + "%')" : " and sljgid=" + PriSljgid;
                //PriWhere += "  and sljgmc='" + TxtBJGmc.Text.Trim().ToString() + "' ";
            }




            if (TxtDddq.Text.Trim().Length > 0)
            {
                PriWhere += PriLevel == 3 ? " and dqid in(select id from jyjckj.dbo.tjigou  where parentLst like '%" + TxtDddq.Tag+ "%')" : " and dqid=" + TxtDddq.Tag;
               
            }
            if (ChkBYdsj.Checked)
                PriWhere += " and days>=0  ";
            PriWhere = PriWhere.Trim();
            if (PriWhere.Length > 0)
                PriWhere =  " where  "+ PriWhere.Remove(0, 3);
            PriWhere += " ORDER BY jjzt1, sort, qssj,slsj,shsj";
            Vfmsdskff1TableAdapter1.FillByWhere(DSZbdskff1.Vfmsdskff1, PriWhere);
            if (Dgv.Rows.Count == 0)
                ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ,��˶Բ�ѯ������", ObjG.CustomMsgBox, this);
            LblDskCountText();
        }
        #endregion

        #region  ����������
        private void BtnSumSxf_Click(object sender, EventArgs e)
        {
            if (PriRowCount == 0)
            {
                ClsMsgBox.Ts("��ѡ���˵���", ObjG.CustomMsgBox, this);
                return;
            }
            try
            {
                dtFl = new DataTable();
                dtFl = ClsRWMSSQLDb.GetDataTable("select pcid,dskffsj,fl,sxfsx,sxfxx from tfmssxfflmx", ClsGlobals.CntStrTMS);
                LstSql.Clear();
                PriSfje = 0;
                foreach (DataGridViewRow row in Dgv.Rows)
                {

                    PriSxf = 0;
                    if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                    {
                        //��֤���񿨺��Ƿ���Ч
                        if (!Validate(row))
                        {
                            Bds.Position = row.Index;
                            ClsD.TurnToBdsPosPage(Dgv);
                            return;
                        }
                        if (row.Cells[DgvColTxtDszl.Name].Value.ToString() == "H")
                        {
                            PriSxf = SumSxf(row.Cells[DgvColTxtFlid.Name].Value.ToString(),
                                row.Cells[DgvColTxtDsffsj.Name].Value.ToString(), Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value));
                            //LstSql.Add(string.Format("update tfmsdskjkmx set sxf={0} where id={1}", PriSxf
                            //    , row.Cells[DgvColTxtMxid.Name].Value));
                        }
                        else if (row.Cells[DgvColTxtDszl.Name].Value.ToString() == "Y")
                        {
                            PriSxf = 0;
                        }
                        if (PriSxf == -10)
                        {
                            ClsMsgBox.Ts("���ţ�" + row.Cells[DgvColTxtBh.Name].Value.ToString() + "�޷�����������,����ͻ����ʣ�", ObjG.CustomMsgBox, this);
                            return;
                        }
                        row.Cells[DgvColTxtSxf.Name].Value = PriSxf;
                        row.Cells[DgvColTxtSfje.Name].Value = Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value) - PriSxf;
                        PriSfje = PriSfje + Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value) - PriSxf;
                    }
                }
                //if (LstSql.Count != 0)
                //    ClsRWMSSQLDb.ExecuteCmd(string.Join(";", LstSql), ClsGlobals.CntStrTMS);
                ClsMsgBox.Ts("���������ѳɹ���", ObjG.CustomMsgBox, this);
                IsSumSxf = true;
                LblDskCountText();
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("����������ʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }

        }
        private decimal SumSxf(string aFlid, string aDsffsj, decimal aDsk)
        {
            rows = dtFl.Select(" pcid=" + aFlid + " and dskffsj='" + aDsffsj + "'");
            if (rows.Length != 1)
                return -10;
            else
            {
                if (aDsk * Convert.ToDecimal(rows[0]["fl"]) < Convert.ToDecimal(rows[0]["sxfxx"]))
                    return Convert.ToDecimal(rows[0]["sxfxx"]);
                else if (aDsk * Convert.ToDecimal(rows[0]["fl"]) > Convert.ToDecimal(rows[0]["sxfsx"]))
                    return Convert.ToDecimal(rows[0]["sxfsx"]);
                else
                    return Math.Round(Convert.ToDecimal(aDsk * Convert.ToDecimal(rows[0]["fl"])), 1);
            }
        }
        #endregion

        #region ��֤
        private bool Validate(DataGridViewRow row)
        {
            int fwkh;
            int.TryParse(row.Cells[DgvColTxtFwkh.Name].Value.ToString(), out fwkh);
            if (string.IsNullOrEmpty(row.Cells[DgvColTxtFwkh.Name].Value.ToString()) || fwkh == 0)
            {
                return false;
            }
            if (Convert.ToInt32(row.Cells[DgvColTxtZt.Name].Value) == 0)
            {
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(row.Cells[DgvColTxtFlid.Name].Value)))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(row.Cells[DgvColTxtYhzh.Name].Value)))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(row.Cells[DgvColTxtFfbh.Name].Value)))
            {
                return false;
            }
            if (row.Cells[DgvColTxtShzt.Name].Value.ToString() != "10")
            {
                return false;
            }
            return true;
        }
        private bool Validate2(DataGridViewRow row)
        {
            int fwkh;
            int.TryParse(row.Cells[DgvColTxtFwkh.Name].Value.ToString(), out fwkh);
            if (string.IsNullOrEmpty(row.Cells[DgvColTxtFwkh.Name].Value.ToString()) || fwkh == 0)
            {
                ClsMsgBox.Ts("���ţ�" + row.Cells[DgvColTxtBh.Name].Value.ToString() + "�ñʴ��տ��޷��񿨺ţ���ά�����񿨺ź��ٷ��ţ�", ObjG.CustomMsgBox, this);

                return false;
            }
            if (Convert.ToInt32(row.Cells[DgvColTxtZt.Name].Value) == 0)
            {
                ClsMsgBox.Ts("���ţ�" + row.Cells[DgvColTxtBh.Name].Value.ToString() + "�÷��񿨺���Ч����ά�����񿨺ź��ٷ��ţ�", ObjG.CustomMsgBox, this);

                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(row.Cells[DgvColTxtFlid.Name].Value)))
            {
                ClsMsgBox.Ts("���ţ�" + row.Cells[DgvColTxtBh.Name].Value.ToString() + "����ͻ�����ά�����ʺ��ٷ��ţ�", ObjG.CustomMsgBox, this);
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(row.Cells[DgvColTxtYhzh.Name].Value)))
            {
                ClsMsgBox.Ts("���ţ�" + row.Cells[DgvColTxtBh.Name].Value.ToString() + "����ͻ�����ά���˻���Ϣ��", ObjG.CustomMsgBox, this);
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(row.Cells[DgvColTxtFfbh.Name].Value)))
            {
                ClsMsgBox.Ts("���ţ�" + row.Cells[DgvColTxtBh.Name].Value.ToString() + "��ά�����տ���������ͣ�", ObjG.CustomMsgBox, this);
                return false;
            }
            if (row.Cells[DgvColTxtShzt.Name].Value.ToString() != "10")
            {
                ClsMsgBox.Ts("���ţ�" + row.Cells[DgvColTxtBh.Name].Value.ToString() + "�븴�˴��տ�ͻ�������", ObjG.CustomMsgBox, this);
                return false;
            }
            return true;
        }
        #endregion

        #region ����
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!IsSumSxf)
            {
                ClsMsgBox.Ts("���ȼ����������ڽ��б��棡", ObjG.CustomMsgBox, this);
                return;
            }
            ClsMsgBox.YesNo("�Ƿ񱣴���տ����ϸ��", new EventHandler(SaveMessage), ObjG.CustomMsgBox, this);
        }
        public void SaveMessage(object sender, EventArgs e)
        {
            FrmMsgBox frm = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {
                PriUpdRows = 0;
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ClsGlobals.CntStrTMS;
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.Transaction = trans;
                        try
                        {
                            CmdText = string.Format("Insert into Tfmsdskxtffpc (jgid,je,bs,inssj,insczyid,insczyxm,insczyzh) values('{0}','{1}','{2}',{3},'{4}','{5}','{6}')" +
                               ";select SCOPE_IDENTITY() ", ObjG.Jigou.id, PriZje, PriRowCount, "getdate()",
                               ObjG.Renyuan.id, ObjG.Renyuan.xm, ObjG.Renyuan.loginName);
                            comm.CommandText = CmdText;
                            PriPcid = comm.ExecuteScalar().ToString();
                            //�ж�����Щ����������Ҫ���ɳֿ���������
                            if (PriJhCount > 0) //����
                            {
                                CmdText = string.Format("Insert into tfmsdskckffpc (xtpcid,je,zje,bs,yhlxid,zt,ffyhlx) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}');select SCOPE_IDENTITY()",
                                    PriPcid, 0.00, PriJhJe, PriJhCount, "(select yhlxid from TfmsDskffyhlx where bh='jh')", 0, "jh");
                                comm.CommandText = CmdText;
                                PriJhPcid = comm.ExecuteScalar().ToString();
                            }
                            if (PriNhCount > 0)//ũ��
                            {
                                CmdText = string.Format("Insert into tfmsdskckffpc (xtpcid,je,zje,bs,yhlxid,zt,ffyhlx) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}');select SCOPE_IDENTITY()",
                                    PriPcid, 0.00, PriNhje, PriNhCount, "(select yhlxid from TfmsDskffyhlx where bh='nh')", 0, "nh");
                                comm.CommandText = CmdText;
                                PriNhPcid = comm.ExecuteScalar().ToString();
                            }
                            if (PriQlCount > 0) //��³����
                            {
                                CmdText = string.Format("Insert into tfmsdskckffpc (xtpcid,je,zje,bs,yhlxid,zt,fkfs,ffyhlx) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}');select SCOPE_IDENTITY()",
                                        PriPcid, 0.00, PriQlje, PriQlCount, "(select yhlxid from TfmsDskffyhlx where bh='qlhn')", 0, 10, "qlhn");
                                comm.CommandText = CmdText;
                                PriQlPcid = comm.ExecuteScalar().ToString();
                            }
                            if (PriQlHwCount > 0)//��³����
                            {
                                CmdText = string.Format("Insert into tfmsdskckffpc (xtpcid,je,zje,bs,yhlxid,zt,fkfs,ffyhlx) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}');select SCOPE_IDENTITY()",
                                        PriPcid, 0.00, PriQlHwje, PriQlHwCount, "(select yhlxid from TfmsDskffyhlx where bh='qlhw')", 0, 20, "qlhw");
                                comm.CommandText = CmdText;
                                PriQlHwPcid = comm.ExecuteScalar().ToString();
                            }
                            if (PriZxhnCount > 0) //��������  
                            {
                                CmdText = string.Format("Insert into tfmsdskckffpc (xtpcid,je,zje,bs,yhlxid,zt,fkfs,ffyhlx) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}');select SCOPE_IDENTITY()",
                                           PriPcid, 0.00, PriZxhnje, PriZxhnCount, "(select yhlxid from TfmsDskffyhlx where bh='zxhn')", 0, 10, "zxhn");
                                comm.CommandText = CmdText;
                                PriZxhnPcid = comm.ExecuteScalar().ToString();
                            }
                            if (PriZxhwCount > 0) //��������
                            {
                                CmdText = string.Format("Insert into tfmsdskckffpc (xtpcid,je,zje,bs,yhlxid,zt,fkfs,ffyhlx) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}');select SCOPE_IDENTITY()",
                                           PriPcid, 0.00, PriZxhwje, PriZxhwCount, "(select yhlxid from TfmsDskffyhlx where bh='zxhw')", 0, 20, "zxhw");
                                comm.CommandText = CmdText;
                                PriZxhwPcid = comm.ExecuteScalar().ToString();
                            }
                            if (string.IsNullOrEmpty(PriPcid))
                            {
                                ClsMsgBox.Ts("��������ʧ�ܣ�", frm, this);
                                trans.Rollback();
                                return;
                            }
                            InsertMx(PriPcid);
                            if (LstSql.Count != LstCkffSql.Count)
                            {
                                ClsMsgBox.Ts("���տ����Ϣ����ʧ��,ϵͳ���ű������������һ�£�", frm, this);
                                trans.Rollback();
                                return;
                            }
                            if (PriZje != PriZje1)
                            {
                                ClsMsgBox.Ts("���տ����Ϣ����ʧ��,ѡ����ܽ���뱣����ܽ�һ�£�", frm, this);
                                trans.Rollback();
                                return;
                            }
                            if (PriZje1 != PriJhJe + PriNhje + PriQlje + PriQlHwje + PriZxhnje + PriZxhwje || PriRowCount != PriJhCount + PriNhCount + PriQlCount + PriQlHwCount + PriZxhnCount + PriZxhwCount)
                            {
                                ClsMsgBox.Ts("���տ����Ϣ����ʧ��,������Ӧ��������ܽ�һ�£�", frm, this);
                                trans.Rollback();
                                return;
                            }
                            if (LstSql.Count == 0)
                            {
                                ClsMsgBox.Ts("���տ����Ϣ����ʧ��,û�б����κη�����Ϣ��", frm, this);
                                trans.Rollback();
                                return;
                            }
                            comm.CommandText = string.Join(";", LstSql);
                            comm.ExecuteScalar();
                            if (LstDskid.Count == 0)
                            {
                                ClsMsgBox.Ts("���տ����Ϣ����ʧ��,û�б����κδ����Ϣ��", frm, this);
                                trans.Rollback();
                                return;
                            }
                            comm.CommandText = string.Join(";", LstCkffSql);

                            comm.ExecuteNonQuery();
                            comm.CommandText = "SET NOCOUNT OFF Update tfmsdsk set ffdskzt=20 where id in(" + string.Join(",", LstDskid) + ") and ffdskzt=0";
                            PriUpdRows = comm.ExecuteNonQuery();
                            if (LstSql.Count != PriUpdRows)
                            {
                                ClsMsgBox.Ts("���տ����Ϣ����ʧ��,����Ĵ����Ϣ��Ӧ��������һ�£�", frm, this);
                                trans.Rollback();
                                return;
                            }
                            trans.Commit();
                            ClsMsgBox.Ts("���տ����Ϣ����ɹ���", frm, this);
                            //Vfmsdskff1TableAdapter1.FillByWhere(DSZbdskff1.Vfmsdskff1, PriWhere);
                            foreach (int dskid in LstDskid)
                            {
                                Bds.RemoveAt(Bds.Find("dskid", dskid));
                            }
                            Clear();
                            LblDskCountText();
                        }
                        catch (Exception ex)
                        {
                            ClsMsgBox.Cw("������տ����Ϣʧ�ܣ�", ex, frm, this);
                            trans.Rollback();
                            return;
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }

                }
            }
        }
        #endregion

        #region ��װ��ϸSQL���
        private void InsertMx(string aPcid)
        {
            LstSql.Clear();
            LstDskid.Clear();
            LstCkffSql.Clear();
            PriZje1 = 0;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                {
                    PriZje1 += Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value);
                    LstSql.Add(string.Format("Insert into tfmsdskxtffmx" +
                        " (pcid,dskid,dsk,sxf) values('{0}','{1}','{2}','{3}')", aPcid, row.Cells[DgvColTxtDskid.Name].Value,
                        row.Cells[DgvColTxtZje.Name].Value, row.Cells[DgvColTxtSxf.Name].Value));
                    LstDskid.Add(Convert.ToInt32(row.Cells[DgvColTxtDskid.Name].Value));
                    if (row.Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("jh")) //����
                    {
                        LstCkffSql.Add(string.Format("Insert into tfmsdskckffmx (pcid,ydid,dskid,dsk,sxf,zt) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                            PriJhPcid, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtZje.Name].Value,
                            row.Cells[DgvColTxtSxf.Name].Value, 0));
                    }
                    else if (row.Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("nh"))//ũ��
                    {
                        LstCkffSql.Add(string.Format("Insert into tfmsdskckffmx (pcid,ydid,dskid,dsk,sxf,zt) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                           PriNhPcid, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtZje.Name].Value,
                           row.Cells[DgvColTxtSxf.Name].Value, 0));
                    }
                    else if (row.Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("qlhn"))//��³����
                    {
                        LstCkffSql.Add(string.Format("Insert into tfmsdskckffmx (pcid,ydid,dskid,dsk,sxf,zt) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                              PriQlPcid, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtZje.Name].Value,
                              row.Cells[DgvColTxtSxf.Name].Value, 0));

                    }
                    else if (row.Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("qlhw"))//��³����
                    {
                        LstCkffSql.Add(string.Format("Insert into tfmsdskckffmx (pcid,ydid,dskid,dsk,sxf,zt) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                              PriQlHwPcid, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtZje.Name].Value,
                              row.Cells[DgvColTxtSxf.Name].Value, 0));
                    }
                    else if (row.Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("zxhw"))//��������
                    {
                        LstCkffSql.Add(string.Format("Insert into tfmsdskckffmx (pcid,ydid,dskid,dsk,sxf,zt) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                              PriZxhwPcid, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtZje.Name].Value,
                              row.Cells[DgvColTxtSxf.Name].Value, 0));
                    }
                    else if (row.Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("zxhn"))//��������
                    {
                        LstCkffSql.Add(string.Format("Insert into tfmsdskckffmx (pcid,ydid,dskid,dsk,sxf,zt) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                              PriZxhnPcid, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtZje.Name].Value,
                              row.Cells[DgvColTxtSxf.Name].Value, 0));
                    }
                }
            }
        }
        #endregion

        #region clear()
        private void Clear()
        {
            IsSumSxf = false;
            LstSql.Clear();
            PriSxf = 0;
            PriRowCount = 0;
            PriZje = 0;
            PriZje1 = 0;
            CmdText = "";
            PriPcid = "";
            LstDskid.Clear();
            PriJhJe = 0;
            PriJhCount = 0;
            PriNhje = 0;
            PriNhCount = 0;
            PriQlje = 0;
            PriQlCount = 0;
            PriQlHwje = 0;
            PriQlHwCount = 0;
            PriZxhnCount = 0;
            PriZxhnje = 0;
            PriZxhwCount = 0;
            PriZxhwje = 0;
            PriSfje = 0;
        }
        private void LblDskCountText()
        {
            LblDskCount.Text = "ÿҳ" + this.Dgv.ItemsPerPage + "��,��" + Dgv.Rows.Count + "��,ѡ��" + PriRowCount + "��,�ܽ��" + PriZje.ToString() + "Ԫ,ʵ���ܽ��" + PriSfje.ToString() + "Ԫ";
        }
        #endregion

        #region ʱ��ѡ��
        /*
        private void DtpQsStop_CheckedChanged(object sender, EventArgs e)
            {
            if (DtpQsStop.Checked)
                DtpQsStart.Checked = true;
            }
        private void DtpSjStop_CheckedChanged(object sender, EventArgs e)
            {
            if (DtpSlStop.Checked)
                DtpSlStart.Checked = true;
            }
         * */
        #endregion

        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 4, 5, 6 };
            ClsExcel.CreatExcel(Dgv, "���տ�ϵͳ����", this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, "���տ�ϵͳ����", this.ctrlDownLoad1);
        }
        #endregion

        #region ������ѯ
        private void BtnJg_Click(object sender, EventArgs e)
        {
            FrmSelectJg2 f = new FrmSelectJg2();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg2 f = sender as FrmSelectJg2;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtBJGmc.Text = f.PubDictAttrs["mc"];
                PriLevel = Convert.ToInt32(f.PubDictAttrs["Level"]);
                PriSljgid = Convert.ToInt32(f.PubDictAttrs["id"]);
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtBJGmc.Text = "";
                PriLevel = 0;
                PriSljgid = 0;
            }
        }
        #endregion

        #region ȫѡ
        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            int RowCout = 0;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                try
                {
                    IsSumSxf = false;
                    if (!Chk.Checked)
                    {
                        if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                        {
                            row.Cells[DgvColTxtCheck.Name].Value = false;
                            PriRowCount--;
                            PriZje -= Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value);
                            PriSfje -= Convert.ToDecimal(row.Cells[DgvColTxtSfje.Name].Value);
                            PriYhfl(row.Index, false);
                        }
                    }
                    else if (Chk.Checked)
                    {
                        //if (!IsNull(row))
                        //{
                        //    continue; 
                        //}
                        if (!Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                        {
                            try
                            {
                                if (!Validate(row))
                                {
                                    continue;
                                }
                                row.Cells[DgvColTxtCheck.Name].Value = true;
                                PriRowCount++;
                                PriZje += Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value);
                                PriSfje += Convert.ToDecimal(row.Cells[DgvColTxtSfje.Name].Value);
                                PriYhfl(row.Index, true);
                            }
                            catch (Exception ex)
                            { 
                                Validate(row);
                            }
                            
                           
                        }
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                } 
                RowCout++; 
            }
            LblDskCountText();
        }
        #endregion

        #region  ����ѡ��
        private void BtnKsxz_Click(object sender, EventArgs e)
        {
            this.LblTs.Visible = true;
            if (string.IsNullOrEmpty(TxtBh.Text))
            {
                LblTs.Text = "����д���˵��ź��ٽ��п���ѡ��";
                LblTs.ForeColor = Color.Red;
                TxtBh.Focus();
                return;
            }
            int RowIndex = Bds.Find("bh", TxtBh.Text);
            if (RowIndex < 0)
            {
                LblTs.Text = "û��Ҫѡ����˵���";
                LblTs.ForeColor = Color.Red;
                TxtBh.Focus();
                TxtBh.SelectAll();
                return;
            }
            Bds.Position = RowIndex;
            IsSumSxf = false;
            if (Convert.ToBoolean(Dgv.CurrentRow.Cells[DgvColTxtCheck.Name].Value))
            {
                ClsMsgBox.Ts("�ñʴ��տ��ѱ�ѡ�У�", ObjG.CustomMsgBox, this);
                return;
            }
            //if (string.IsNullOrEmpty(Dgv.CurrentRow.Cells[DgvColTxtFwkh.Name].Value.ToString()))
            //{
            //    ClsMsgBox.Ts("�ñʴ��տ��޷��񿨺ţ���ά�����񿨺ź��ٷ��ţ�", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //else
            //{
            //    if (Convert.ToInt32(Dgv.CurrentRow.Cells[DgvColTxtFwkh.Name].Value) == 0)
            //    {
            //        ClsMsgBox.Ts("�ñʴ��տ��޷��񿨺ţ���ά�����񿨺ź��ٷ��ţ�", ObjG.CustomMsgBox, this);
            //        return;
            //    }
            //}
            //if (string.IsNullOrEmpty(Convert.ToString(Dgv.CurrentRow.Cells[DgvColTxtFlid.Name].Value)))
            //{
            //    ClsMsgBox.Ts("����ͻ�����ά�����ʺ��ٷ��ţ�", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //if (string.IsNullOrEmpty(Convert.ToString(Dgv.CurrentRow.Cells[DgvColTxtYhzh.Name].Value)))
            //{
            //    ClsMsgBox.Ts("����ͻ�����ά���˻���Ϣ��", ObjG.CustomMsgBox, this);
            //    return;
            //}
            //if (string.IsNullOrEmpty(Convert.ToString(Dgv.CurrentRow.Cells[DgvColTxtFfbh.Name].Value)))
            //{
            //    ClsMsgBox.Ts("��ά�����տ���������ͣ�", ObjG.CustomMsgBox, this);
            //    return;
            //}
            if (!Validate2(Dgv.CurrentRow))
            {
                return;
            }
            Dgv.CurrentRow.Cells[DgvColTxtCheck.Name].Value = true;
            PriRowCount++;
            PriZje += Convert.ToDecimal(Dgv.CurrentRow.Cells[DgvColTxtZje.Name].Value);
            PriSfje += Convert.ToDecimal(Dgv.CurrentRow.Cells[DgvColTxtSfje.Name].Value);
            PriYhfl(Dgv.CurrentRow.Index, true);
            ClsD.TurnToBdsPosPage(Dgv);
            LblTs.Text = "�˵���" + TxtBh.Text + "��ѡ�У���ѡ��" + PriRowCount + "����";
            LblTs.ForeColor = Color.Green;
            TxtBh.Text = "";
            TxtBh.Focus();
            this.ActiveControl = this.BtnKsxz;
            //LblDskCount.Text = "ÿҳ" + this.Dgv.ItemsPerPage + "��,��" + Dgv.Rows.Count + "��,ѡ��" + PriRowCount + "��,�ܽ��" + PriZje.ToString() + "Ԫ";
            LblDskCountText();
        }

        private void TxtBh_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            BtnKsxz.PerformClick();
            TxtBh.Focus();
        }
        #endregion

        #region ���з���
        private void PriYhfl(int i, Boolean Pribool)
        {
            if (Pribool == true)
            {
                //�ж���ѡ��Ϣ���ĸ�����
                if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("jh")) //����
                {
                    PriJhJe += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriJhCount++;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("nh"))//ũ��
                {
                    PriNhje += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriNhCount++;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("qlhn"))//��³����
                {
                    PriQlje += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriQlCount++;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("qlhw"))//��³����
                {
                    PriQlHwje += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriQlHwCount++;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("zxhn"))//��������
                {
                    PriZxhnje += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriZxhnCount++;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("zxhw"))//��������
                {
                    PriZxhwje += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriZxhwCount++;
                }
            }
            else
            {
                //�ж���ѡ��Ϣ���ĸ�����
                if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("jh")) //����
                {
                    PriJhJe -= Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriJhCount--;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("nh"))//ũ��
                {
                    PriNhje -= Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriNhCount--;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("qlhn"))//��³����
                {
                    PriQlje -= Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriQlCount--;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("qlhw"))//��³����
                {
                    PriQlHwje -= Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriQlHwCount--;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("zxhn"))//��������
                {
                    PriZxhnje -= Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriZxhnCount--;
                }
                else if (Dgv.Rows[i].Cells[DgvColTxtFfbh.Name].Value.ToString().Equals("zxhw"))//��������
                {
                    PriZxhwje -= Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtZje.Name].Value);
                    PriZxhwCount--;
                }
            }
        }
        #endregion
        private void BtnYff_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtKffje.Text.Trim()))
            {
                ClsMsgBox.Ts("����д�ɷ��Ž�", ObjG.CustomMsgBox, this);
                return;
            }
            if (!ClsRegEx.IsJe(TxtKffje.Text.Trim()))
            {
                ClsMsgBox.Ts("��д�Ŀɷ��Ž���ʽ����ȷ��", ObjG.CustomMsgBox, this);
                return;
            }
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                    row.Cells[DgvColTxtCheck.Name].Value = false;
            }
            IsSumSxf = true;
            PriRowCount = 0;
            PriZje = 0;
            PriSfje = 0;
            PriJhJe = 0;
            PriNhje = 0;
            PriQlje = 0;
            PriQlHwje = 0; 
            PriZxhnje = 0;
            PriZxhwje = 0;
            PriJhCount = 0;
            PriNhCount = 0;
            PriQlCount = 0;
            PriQlHwCount = 0;
            PriZxhnCount = 0;
            PriZxhwCount = 0;
            decimal kffje = 0;
            try
            {
                dtFl = new DataTable();
                dtFl = ClsRWMSSQLDb.GetDataTable("select pcid,dskffsj,fl,sxfsx,sxfxx from tfmssxfflmx", ClsGlobals.CntStrTMS);
                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    PriSxf = 0;
                    if (!Validate(row))
                        continue;
                    if (row.Cells[DgvColTxtDszl.Name].Value.ToString() == "H")
                    {
                        PriSxf = SumSxf(row.Cells[DgvColTxtFlid.Name].Value.ToString(),
                            row.Cells[DgvColTxtDsffsj.Name].Value.ToString(), Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value));
                    }
                    else if (row.Cells[DgvColTxtDszl.Name].Value.ToString() == "Y")
                        PriSxf = 0;
                    if (PriSxf == -10)
                    {
                        continue;
                    }
                    kffje += Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value) - PriSxf;
                    if (kffje < Convert.ToDecimal(TxtKffje.Text))
                    {
                        row.Cells[DgvColTxtCheck.Name].Value = true;
                        row.Cells[DgvColTxtSxf.Name].Value = PriSxf;
                        row.Cells[DgvColTxtSfje.Name].Value = Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value) - PriSxf;
                        PriRowCount++;
                        PriZje += Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value);
                        PriSfje += Convert.ToDecimal(row.Cells[DgvColTxtZje.Name].Value) - PriSxf;
                        PriYhfl(row.Index, true);
                    }
                    else
                        break;

                }
                LblDskCountText();
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("Ԥ����ʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
                return;
            }
        }
        #region ����ѡ��
        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                IsSumSxf = false;
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    PriRowCount--;
                    PriZje -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtZje.Name].Value);
                    PriYhfl(e.RowIndex, false);
                    PriSfje -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtSxf.Name].Value);
                }
                else
                {
                    if (!Validate2(Dgv.Rows[e.RowIndex]))
                    {

                        return;
                    }
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    PriRowCount++;
                    PriZje += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtZje.Name].Value);
                    PriSfje += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtSfje.Name].Value);
                    PriYhfl(e.RowIndex, true);
                }
            }
            LblDskCountText();
        }
        #endregion

        private void BtnEjg_Click(object sender, EventArgs e)
        {
            FrmSelectJg2 frm = new FrmSelectJg2();
            frm.Prepare();
            frm.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(frm_FormClosed);
            frm.ShowDialog();
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg2 f = sender as FrmSelectJg2;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtEJGmc.Text = f.PubDictAttrs["mc"];
                this.TxtEJGmc.Tag = f.PubDictAttrs["id"];
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtBJGmc.Text = "";
                this.TxtEJGmc.Tag = "";
            }
        }

        private void btndddq_Click(object sender, EventArgs e)
        {
            FrmSelectJg2 fr = new FrmSelectJg2();
            fr.Prepare();
            fr.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(fr_FormClosed);
            fr.ShowDialog();
        }

        void fr_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg2 f = sender as FrmSelectJg2;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtDddq.Text = f.PubDictAttrs["mc"];
                this.TxtDddq.Tag = f.PubDictAttrs["id"];
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtDddq.Text = "";
                this.TxtDddq.Tag = "";
            }
        }
    }
}
