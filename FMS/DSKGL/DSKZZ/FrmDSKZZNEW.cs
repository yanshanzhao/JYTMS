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
using JY.Pub;
using JY.Pri;
using FMS.SeleFrm;
using System.Data.SqlClient;
using JY.Pri;
using System.Data.SqlClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using JYPubFiles.Classes;
using Gizmox.WebGUI.Common.Interfaces;
using System.Configuration;
using FMS.DSKGL.ZZYCDSKMX;
#endregion

namespace FMS.DSKGL.DSKZZ
{
    public partial class FrmDSKZZNEW : Form
    {

        #region ��Ա����
        private ClsG ObjG;
        private DataTable PriJgDt = new DataTable();
        private decimal PriZj;
        private decimal PriYcje;//��PriZj�Ա������Ƿ�׼ȷ
        private int ChkRowCount;
        private int PriRowCount;//��ChkRowCount�Ա������Ƿ�׼ȷ
        private string CmdText;
        private string PriZffs;
        private string PriRbbh;
        private string PriRbpcid;
        //private List<string> LstSql = new List<string>();
        private List<int> LstYdid = new List<int>();
        private string PriFwjgid;
        private bool IsChecked;
        private int PriUpdRows;
        private int PriZflx = 0;
        //private DataTable Prizflxss = new DataTable();
        private string PriConStr;
        private FrmMsgBox Box = new FrmMsgBox();
        #endregion

        #region ����ҳ��
        public FrmDSKZZNEW()
        {
            InitializeComponent();
        }
        #endregion

        #region ��ʼ������
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            vfmsdskzz3TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            PriJgDt = ClsRWMSSQLDb.GetDataTable("select tojgmc,tojgid from vfmsjggx where gxzl='D' and jgid=" + ObjG.Jigou.id, ClsGlobals.CntStrTMS);
            if (PriJgDt.Rows.Count == 1)
            {
                LblFwjgmc.Text = PriJgDt.Rows[0]["tojgmc"].ToString();
                PriFwjgid = PriJgDt.Rows[0]["tojgid"].ToString();
            }
            //ClsPopulateCmbDsS.PopuYd_jylx(Cmbzffs, ClsGlobals.CntStrKj);//�������Ͱ� 
            ClsPopulateCmbDsS.PopuYd_dshklx(CmbDszl, ClsGlobals.CntStrKj);//���ջ�������
            CmbZffs.SelectedIndex = 0;
            CmbDszl.SelectedIndex = 0;
            //Prizflxss.Columns.Add("lxmc", Type.GetType("System.String"));//�������� 
            //Prizflxss.Columns.Add("lx", Type.GetType("System.String"));//����  0-���� 1-���� 2-��ά��
            //Prizflxss.Columns.Add("je", Type.GetType("System.Decimal"));//��� 
            //Prizflxss.Columns.Add("hybh", Type.GetType("System.String"));//���˱�� 
            //Prizflxss.Columns.Add("dskfkfs", Type.GetType("System.String"));//���ʽ 
            //Prizflxss.Columns.Add("lxADDdskfkfs", Type.GetType("System.String"));//����+���ʽ 
            ClsPopulateCmbDsS.PopuYd_dshksqfsALL(Cmbfkfs);
            Cmbfkfs.SelectedIndex = 0;
            PriConStr = ClsGlobals.CntStrTMS;
        }
        #endregion

        #region ���������ѯ
        private void BtnSearchjg_Click(object sender, EventArgs e)
        {
            FrmSelectJg f = new FrmSelectJg();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
                this.txtsljg.Text = f.PubDictAttrs["mc"];
            else if (f.DialogResult == DialogResult.No)
                this.txtsljg.Text = "";
        }
        #endregion

        #region ��Prizflxss���в���
        //private int FindRowIndex(DataRow dr)
        //{
        //    return Prizflxss.Rows.IndexOf(dr);
        //}

        //private DataRow[] GerRows(string aydbh)
        //{
        //    return Prizflxss.Select(string.Format(" hybh='{0}' ", aydbh));
        //}

        //private void RemoveRows(string aydbh)
        //{
        //    DataRow[] dr = GerRows(aydbh);
        //    if (dr.Length > 0)
        //        Prizflxss.Rows.RemoveAt(FindRowIndex(dr[0]));
        //}

        #endregion

        #region �ͻ���ѯ
        private void BtnSearchKh_Click(object sender, EventArgs e)
        {
            FrmSelectKh f = new FrmSelectKh();
            f.Prepare();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectKh f = sender as FrmSelectKh;
            if (f.DialogResult == DialogResult.OK)
                Txtfhkh.Text = f.PubKhmc;
        }
        #endregion

        #region ��Żس����¼�
        private void TxtBh_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            this.BtnKsxz.PerformClick();
        }
        #endregion

        #region ����ѡ��
        private void BtnKsxz_Click(object sender, EventArgs e)
        {
            LblTs.Visible = true;
            IsChecked = false;
            if (string.IsNullOrEmpty(TxtBh.Text))
            {
                LblTs.Text = "��¼����˱�ţ�";
                LblTs.ForeColor = Color.Red;
                return;
            }
            //DataRow newRow;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (row.Cells[DgvColTxthydh.Name].Value.ToString().Trim().Equals(TxtBh.Text) && !Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                {
                    row.Cells[DgvColTxtCheck.Name].Value = true;
                    Bds.Position = row.Index;
                    IsChecked = true;
                    PriZj += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                    ChkRowCount++;
                    //string hydh = row.Cells[DgvColTxthydh.Name].Value.ToString();
                    //if (GerRows(hydh).Length == 0)
                    //{
                    //    newRow = Prizflxss.NewRow();
                    //    newRow["lxmc"] = row.Cells[DgvColTxtzflx.Name].Value.ToString();
                    //    newRow["lx"] = row.Cells[DgvTxtzflxxh.Name].Value.ToString();
                    //    newRow["je"] = row.Cells[DgvColTxtdsk.Name].Value.ToString();
                    //    newRow["hybh"] = row.Cells[DgvColTxthydh.Name].Value.ToString();
                    //    newRow["dskfkfs"] = row.Cells[DgvColTxtdskfkfs.Name].Value.ToString();
                    //    newRow["lxADDdskfkfs"] = row.Cells[DgvTxtzflxxh.Name].Value.ToString() + row.Cells[DgvColTxtdskfkfs.Name].Value.ToString();
                    //    Prizflxss.Rows.Add(newRow);
                    //}
                }
            }
            if (!IsChecked)
            {
                LblTs.Visible = true;
                LblTs.Text = "û�в�ѯ����Ӧ�˵���";
                LblTs.ForeColor = Color.Red;
                return;
            }
            ClsD.TurnToBdsPosPage(Dgv);
            int RowIndex = Bds.Find("bh", TxtBh.Text);
            LblCheckCount.Text = "��ѡ��" + ChkRowCount + "��";
            LblZjje.Text = PriZj.ToString();
            LblTs.Visible = true;
            string bh = TxtBh.Text;
            TxtBh.Text = "";
            LblTs.Text = "�˵���" + bh + "��ѡ�У���ѡ��" + ChkRowCount + "��";
            LblTs.ForeColor = Color.Green;
        }
        #endregion

        #region ��ѡ
        private void BtnFX_Click(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            DataRow newRow;
            if (ChkRowCount == 0)
            {
                ChkQx.Checked = true;
                return;
            }
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                //string hybh = row.Cells[DgvColTxthydh.Name].Value.ToString();
                //DataRow[] dr = GerRows(hybh);
                if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                {
                    row.Cells[DgvColTxtCheck.Name].Value = false;
                    PriZj -= Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                    ChkRowCount--;
                    //RemoveRows(hybh);
                }
                else
                {
                    row.Cells[DgvColTxtCheck.Name].Value = true;
                    PriZj += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                    ChkRowCount++;
                    //if (dr.Length == 0)
                    //{
                    //    newRow = Prizflxss.NewRow();
                    //    newRow["lxmc"] = row.Cells[DgvColTxtzflx.Name].Value.ToString();
                    //    newRow["lx"] = row.Cells[DgvTxtzflxxh.Name].Value.ToString();
                    //    newRow["je"] = row.Cells[DgvColTxtdsk.Name].Value.ToString();
                    //    newRow["hybh"] = row.Cells[DgvColTxthydh.Name].Value.ToString();
                    //    newRow["dskfkfs"] = row.Cells[DgvColTxtdskfkfs.Name].Value.ToString();
                    //    newRow["lxADDdskfkfs"] = row.Cells[DgvTxtzflxxh.Name].Value.ToString() + row.Cells[DgvColTxtdskfkfs.Name].Value.ToString();
                    //    Prizflxss.Rows.Add(newRow);
                    //}
                }
            }
            LblCheckCount.Text = "��ѡ��" + ChkRowCount + "��";
            LblZjje.Text = PriZj.ToString();
            if (ChkRowCount == 0)
            {
                ChkQx.Checked = false;
                return;
            }
        }
        #endregion

        #region ��ҳȫѡ
        private void BtnCheck_Click_1(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            if (Dgv.Rows.Count == 0)
                return;
            CheckThisPage();
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "��ѡ��" + ChkRowCount + "��";
        }

        public void CheckThisPage()
        {
            if (Bds.Count == 0)
                return;
            int curPageFirstIndex = (Dgv.CurrentPage - 1) * Dgv.ItemsPerPage;//��ȡ��ǰҳ�ĵ�һ�е�RowIndex
            int lastPageSize = Dgv.RowCount - (Dgv.TotalPages - 1) * Dgv.ItemsPerPage; //��ȡ���һҳ������
            int curPageSize = Dgv.CurrentPage != Dgv.TotalPages ? Dgv.ItemsPerPage : lastPageSize; //��ȡÿҳ���������������һҳ��
            int curRowIndex = curPageFirstIndex;
            while ((curRowIndex) < (curPageFirstIndex + curPageSize))
            {
                //string hybh = Dgv.Rows[curRowIndex].Cells[DgvColTxthydh.Name].Value.ToString();
                //DataRow[] dr = GerRows(hybh);
                if (!Convert.ToBoolean(Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value).Equals(true))
                {
                    Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value = true;
                    PriZj += Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtdsk.Name].Value);
                    ChkRowCount++;
                    //if (dr.Length == 0)
                    //{
                    //    DataRow newRow = Prizflxss.NewRow();
                    //    newRow["lxmc"] = Dgv.Rows[curRowIndex].Cells[DgvColTxtzflx.Name].Value;
                    //    newRow["lx"] = Dgv.Rows[curRowIndex].Cells[DgvTxtzflxxh.Name].Value;
                    //    newRow["je"] = Dgv.Rows[curRowIndex].Cells[DgvColTxtdsk.Name].Value;
                    //    newRow["hybh"] = Dgv.Rows[curRowIndex].Cells[DgvColTxthydh.Name].Value;
                    //    newRow["dskfkfs"] = Dgv.Rows[curRowIndex].Cells[DgvColTxtdskfkfs.Name].Value;
                    //    newRow["lxADDdskfkfs"] = Dgv.Rows[curRowIndex].Cells[DgvTxtzflxxh.Name].Value.ToString() + Dgv.Rows[curRowIndex].Cells[DgvColTxtdskfkfs.Name].Value.ToString();
                    //    Prizflxss.Rows.Add(newRow);
                    //}
                }
                //else
                //{
                //    Dgv.Rows[curRowIndex].Cells[DgvColTxtCheck.Name].Value = false;
                //    PriZj -= Convert.ToDecimal(Dgv.Rows[curRowIndex].Cells[DgvColTxtdsk.Name].Value);
                //    ChkRowCount--;
                //    RemoveRows(hybh);
                //}
                curRowIndex++;
            }
        }
        #endregion

        #region ����ѡ��
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblTs.Visible = false;
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                //DataRow newRow;
                //string hybh = Dgv.Rows[e.RowIndex].Cells[DgvColTxthydh.Name].Value.ToString();
                if (Convert.ToBoolean(Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    ChkRowCount--;
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    PriZj -= Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);

                    //RemoveRows(hybh);
                }
                else
                {
                    ChkRowCount++;
                    Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    PriZj += Convert.ToDecimal(Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value);
                    //if (GerRows(hybh).Length == 0)
                    //{
                    //    newRow = Prizflxss.NewRow();
                    //    newRow["lxmc"] = Dgv.Rows[e.RowIndex].Cells[DgvColTxtzflx.Name].Value;
                    //    newRow["lx"] = Dgv.Rows[e.RowIndex].Cells[DgvTxtzflxxh.Name].Value;
                    //    newRow["je"] = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdsk.Name].Value;
                    //    newRow["hybh"] = Dgv.Rows[e.RowIndex].Cells[DgvColTxthydh.Name].Value;
                    //    newRow["dskfkfs"] = Dgv.Rows[e.RowIndex].Cells[DgvColTxtdskfkfs.Name].Value;
                    //    newRow["lxADDdskfkfs"] = Dgv.Rows[e.RowIndex].Cells[DgvTxtzflxxh.Name].Value.ToString() + Dgv.Rows[e.RowIndex].Cells[DgvColTxtdskfkfs.Name].Value.ToString();
                    //    Prizflxss.Rows.Add(newRow);
                    //}
                }
            }
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "��ѡ��" + ChkRowCount + "��";
        }
        #endregion

        #region ȫѡ
        private void ChkQx_CheckedChanged(object sender, EventArgs e)
        {
            //Prizflxss.Clear();
            LblTs.Visible = false;
            if (Dgv.Rows.Count == 0)
                return;
            CheckAll(ChkQx.Checked);
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "��ѡ��" + ChkRowCount + "��";
        }
        public void CheckAll(bool aChecked)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                //DataRow newRow;
                if (aChecked)
                {
                    if (!Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                    {
                        row.Cells[DgvColTxtCheck.Name].Value = true;
                        PriZj += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                        ChkRowCount++;
                        //string hydh = row.Cells[DgvColTxthydh.Name].Value.ToString();
                        //if (GerRows(hydh).Length == 0)
                        //{
                        //    newRow = Prizflxss.NewRow();
                        //    newRow["lxmc"] = row.Cells[DgvColTxtzflx.Name].Value;
                        //    newRow["lx"] = row.Cells[DgvTxtzflxxh.Name].Value;
                        //    newRow["je"] = row.Cells[DgvColTxtdsk.Name].Value;
                        //    newRow["hybh"] = row.Cells[DgvColTxthydh.Name].Value;
                        //    newRow["dskfkfs"] = row.Cells[DgvColTxtdskfkfs.Name].Value;
                        //    newRow["lxADDdskfkfs"] = row.Cells[DgvTxtzflxxh.Name].Value.ToString() + row.Cells[DgvColTxtdskfkfs.Name].Value.ToString();
                        //    Prizflxss.Rows.Add(newRow);
                        //}
                    }
                }
                else
                {
                    if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
                    {
                        row.Cells[DgvColTxtCheck.Name].Value = false;
                        PriZj -= Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
                        ChkRowCount--;
                    }
                }
            }
        }
        #endregion

        #region ��ѯ
        private void BtnSave_Click(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            try
            {
                ChkQx.Checked = false;
                ClsD.TextBoxTrim(this);
                Clear();
                string where = " where qsjgid=" + ObjG.Jigou.id;//ǩ�ջ���Ϊ������jgid  
                if (DtpSlStart.Checked)
                    where += " and inssj >= '" + DtpSlStart.Value.Date + "'";
                if (DtpSlStop.Checked)
                    where += " and inssj < '" + DtpSlStop.Value.AddDays(1).Date + "'";//ǩ��ʱ����в�ѯ
                if (DtpQsStart.Checked)
                    where += " and qssj >= '" + DtpQsStart.Value.Date + "'";
                if (DtpQsStop.Checked)
                    where += " and qssj < '" + DtpQsStop.Value.AddDays(1).Date + "'";//����ʱ����в�ѯ
                where += string.IsNullOrEmpty(txtsljg.Text) ? "" : " and sljg ='" + txtsljg.Text + "'";//���������ѯ�˵�
                where += string.IsNullOrEmpty(Txthydh.Text) ? "" : " and bh='" + Txthydh.Text + "'";//�����ͻ����˵���Ų�ѯ 
                //where += Cmbzffs.SelectedIndex == 0 ? "" : " and zflxmc='" + Cmbzffs.Text.Trim() + "'";//֧�����ͣ���Ϊȫ�������в�ѯ
                if (CmbZffs.SelectedIndex > 0)
                    where = where + "  and zflxmc='" + CmbZffs.Text + "' ";
                if (Cmbfkfs.SelectedIndex > 0)
                    where += " and dskfkfs='" + Cmbfkfs.SelectedValue + "'";
                where += string.IsNullOrEmpty(Txtfhkh.Text) ? "" : " and fhkhmc ='" + Txtfhkh.Text + "'";//�����ͻ�
                where += CmbDszl.SelectedIndex == 0 ? "" : " and dshklx='" + CmbDszl.Text.Trim() + "'";//���տ����ͽ��в�ѯ 
                where += " ORDER BY dskfkfs,zflxmc,dsffsj,qssj   ";//����ʱ�����ͺ�ǩ��ʱ���������
                dsdskzznew1.EnforceConstraints = false;
                vfmsdskzz3TableAdapter1.FillByWhere(dsdskzznew1.Vfmsdskzz3, where);
                //PriZffs = Cmbzffs.SelectedValue.ToString();
                if (Bds.Count == 0)
                {
                    ClsMsgBox.Ts("û�в�ѯ�����տ���ת��Ϣ��", ObjG.CustomMsgBox, this);
                    return;
                }
                for (int i = 0; i < Dgv.Rows.Count - 1; i++)
                {
                    int zfzt = 0;
                    int.TryParse(Dgv.Rows[i].Cells[DgvColTxtZfzt.Name].Value.ToString(), out zfzt);
                    if (zfzt == 1)
                    {
                        LblTs.Visible = false;
                        if (Convert.ToBoolean(Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value))
                        {
                            ChkRowCount--;
                            Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value = false;
                            PriZj -= Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                        }
                        else
                        {
                            ChkRowCount++;
                            Dgv.Rows[i].Cells[DgvColTxtCheck.Name].Value = true;
                            PriZj += Convert.ToDecimal(Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value);
                        }
                        LblZjje.Text = PriZj.ToString();
                        LblCheckCount.Text = "��ѡ��" + ChkRowCount + "��";
                    }
                }
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("���տ���ת��Ϣ��ѯʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion

        #region ���տ���ת��ֱ����������Ӧ����տ����ҳ��
        private void OpenFrm(object sender, EventArgs e)
        {
            FrmMsgBox c = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.OK)
            {
                FrmZZYCDSKTJ f1 = new FrmZZYCDSKTJ();
                f1.ShowDialog();
                f1.Prepare();
            }
        }
        private static void InvokeFocusCommand(Control objControl, Control aControl = null)
        {
            if (aControl == null)
                return;
            IApplicationContext objApplicationContext = aControl.Context as IApplicationContext;
            if (objApplicationContext != null)
                objApplicationContext.SetFocused(objControl, true);
        }
        public static void JGts(string mess, EventHandler hdl, FrmMsgBox aMsgBox = null, Control aParControl = null, float aFontsize = 14)
        {
            aMsgBox.Text = "����";
            aMsgBox.LblMess.Text = mess;
            aMsgBox.LblMess.Font = new System.Drawing.Font("����", aFontsize, System.Drawing.FontStyle.Bold);
            aMsgBox.LblMess.ForeColor = System.Drawing.Color.Red;
            aMsgBox.Btn1.Text = "ȷ��";
            aMsgBox.Btn1.AutoSize = true;
            aMsgBox.Btn1.DialogResult = DialogResult.OK;
            aMsgBox.Btn1.TabStop = true;
            aMsgBox.Tag = null;
            aMsgBox.Btn2.Text = "ȡ��";
            aMsgBox.Btn2.AutoSize = true;
            aMsgBox.Btn2.DialogResult = DialogResult.Cancel;
            aMsgBox.Btn2.Visible = true;
            aMsgBox.ShowDialog();
            aMsgBox.FrmCloseHdl = hdl;
            InvokeFocusCommand(aMsgBox, aParControl);
        }
        #endregion

        #region ��ת��ť�¼�
        private void BtnZz_Click(object sender, EventArgs e)
        {
            LblTs.Visible = false;
            PriRbbh = "D" + DateTime.Now.ToString("yyyyMMdd") + ObjG.Jigou.id;
            if (string.IsNullOrEmpty(LblFwjgmc.Text))
            {
                ClsMsgBox.Ts("�û���û�д��տ��ϵ��������ά����", this, LblFwjgmc, ObjG.CustomMsgBox);
                return;
            }
            if (ChkRowCount <= 0)
            {
                ClsMsgBox.Ts("��ѡ��Ҫ���������ݼ�¼ ", ObjG.CustomMsgBox, this);
                return;
            }
            DskZZ();
        }
        public void DskZZ()
        {
            LstYdid.Clear();
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
                        int RowCount = 0;//��ת�ķǶ�ά��֧����������
                        string QtRbpcid = "0";//�Ƕ�ά��֧���ձ�����id
                        for (int i = 0; i < Bds.Count; i++)
                        {
                            if ((bool)Dgv.Rows[i].Cells[DgvColTxtCheck.Name].EditedFormattedValue == true)
                            {
                                if (Dgv.Rows[i].Cells[DgvColTxtzflx.Name].Value.Equals("��ά��"))
                                {
                                    CmdText = "";
                                    CmdText = string.Format("  SET NOCOUNT OFF insert into Tfmsdskjkpc(rbdh,jgid,zffs,dsk,sxf,zt,cnt,zzsj,zzczyid,zzczyzh,zzczyxm,spjgid,zflx)" +
                                            "  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');select SCOPE_IDENTITY() ",
                                            PriRbbh, ObjG.Jigou.id, Dgv.Rows[i].Cells[DgvColTxtdskfkfs.Name].Value.ToString(), Dgv.Rows[i].Cells[this.DgvColTxtdsk.Name].Value, 0, 0, 1, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriFwjgid, Dgv.Rows[i].Cells[DgvTxtzflxxh.Name].Value.ToString());
                                    comm.CommandText = CmdText;//������սɿ��ձ����� 
                                    PriRbpcid = comm.ExecuteScalar().ToString();
                                    CmdText = string.Format("INSERT INTO Tfmsdskjkmx (pcid,dskid,ydid,dsk,sxf) VALUES('{0}','{1}','{2}','{3}','{4}')",
                         PriRbpcid, Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtYdid.Name].Value.ToString(), Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value, 0);
                                    //CmdText = "";
                                    comm.CommandText = CmdText;//������սɿ��ձ���ϸ 
                                    comm.ExecuteNonQuery();
                                }
                                else
                                {
                                    RowCount++;
                                    if (RowCount == 1)
                                    {
                                        CmdText = string.Format("  SET NOCOUNT OFF insert into Tfmsdskjkpc(rbdh,jgid,zffs,dsk,sxf,zt,cnt,zzsj,zzczyid,zzczyzh,zzczyxm,spjgid,zflx)" +
                                           "  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');select SCOPE_IDENTITY() ",
                                           PriRbbh, ObjG.Jigou.id, Dgv.Rows[i].Cells[DgvColTxtdskfkfs.Name].Value.ToString(), Dgv.Rows[i].Cells[this.DgvColTxtdsk.Name].Value, 0, 0, 1, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriFwjgid, Dgv.Rows[i].Cells[DgvTxtzflxxh.Name].Value.ToString());
                                        comm.CommandText = CmdText;//������սɿ��ձ����� 
                                        QtRbpcid = comm.ExecuteScalar().ToString();
                                    }
                                    else
                                    {
                                        CmdText = string.Format(@"UPDATE tfmsdskjkpc SET dsk=dsk+{0},cnt=cnt+1,zzsj=GETDATE() WHERE id={1}", Dgv.Rows[i].Cells[this.DgvColTxtdsk.Name].Value, QtRbpcid);
                                        comm.CommandText = CmdText;//�޸Ĵ��տ��������ʱ��
                                        comm.ExecuteNonQuery();
                                    }
                                    CmdText = string.Format("INSERT INTO Tfmsdskjkmx (pcid,dskid,ydid,dsk,sxf) VALUES('{0}','{1}','{2}','{3}','{4}')",
                         QtRbpcid, Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtYdid.Name].Value.ToString(), Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value, 0);
                                    //CmdText = "";
                                    comm.CommandText = CmdText;//������սɿ��ձ���ϸ 
                                    comm.ExecuteNonQuery();
                                }
                                LstYdid.Add(Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtYdid.Name].Value.ToString()));
                            }
                        }
                        CmdText = "";
                        CmdText = "SET NOCOUNT OFF UPDATE Tfmsdsk SET SJDSKZT=10 WHERE ydid IN (" + string.Join(",", LstYdid) + ") and SJDSKZT=0 ";
                        comm.CommandText = CmdText;//���´��տ���Ͻ����տ�״̬��ԭ����δ�����Ϊ����ת
                        PriUpdRows = comm.ExecuteNonQuery();
                        if (ChkRowCount != PriUpdRows)
                        {
                            ClsMsgBox.Ts("���տ���תʧ��!", ObjG.CustomMsgBox, this);
                            trans.Rollback();
                            return;
                        }
                        else
                        {
                            //�ύ����
                            trans.Commit();
                            this.Close();
                            int n = ClsRWMSSQLDb.GetInt(" SELECT  jgid  FROM dbo.Tfmsyhzh  WHERE (zhlxid = 50) AND (zt = 0) AND jgid = " + ObjG.Jigou.id, PriConStr);
                            if (n <= 0)
                            {
                                JGts("ϵͳδά�������˻���Ϣ��������տ��ϵ�绰��0531-58681288", new EventHandler(OpenFrm), Box, this);
                                return;
                            }
                            FrmZZYCDSKTJ f = new FrmZZYCDSKTJ();
                            f.ShowDialog();
                            f.Prepare(); 
                            ClsMsgBox.Ts("���տ���ת�ɹ�������ת" + ChkRowCount + "Ʊ,�ܹ�" + LblZjje.Text + "Ԫ", ObjG.CustomMsgBox, this);
                        }
                    }
                    catch (Exception ex)
                    {
                        ClsMsgBox.Cw("���տ���תʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

        }
        #region ��Ч����
        //public void DskZZ()
        //{
        //    PriUpdRows = 0;
        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.ConnectionString = ClsGlobals.CntStrTMS;
        //        conn.Open();
        //        SqlTransaction trans = conn.BeginTransaction();
        //        using (SqlCommand comm = new SqlCommand())
        //        {
        //            comm.Connection = conn;
        //            comm.Transaction = trans;
        //            try
        //            {



        //                var query = from t in Prizflxss.AsEnumerable()
        //                            group t by new { t1 = t.Field<string>("lx"), t2 = t.Field<string>("dskfkfs"), t3 = t.Field<string>("lxmc"), t4 = t.Field<string>("lxADDdskfkfs") } into m
        //                            select new
        //                            {
        //                                lx = m.Key.t1,
        //                                dskfkfs = m.Key.t2,
        //                                lxmc = m.Key.t3,
        //                                lxADDdskfkfs = m.Key.t4,
        //                                je = m.Sum(n => n.Field<decimal>("je")),
        //                                count = m.Count()
        //                            };
        //                //ѡ����տ���Ϣ����ȡ֧����������     
        //                List<string> lxList = new List<string>();
        //                List<string> lxmcList = new List<string>();
        //                List<string> dskfkfsList = new List<string>();
        //                List<string> lxADDdskfkfsList = new List<string>();
        //                List<decimal> jeList = new List<decimal>();
        //                List<int> countList = new List<int>();

        //                foreach (var item in query.ToList())
        //                {
        //                    if (item.count > 0)
        //                    {
        //                        lxList.Add(item.lx);
        //                        lxmcList.Add(item.lxmc);
        //                        dskfkfsList.Add(item.dskfkfs);
        //                        lxADDdskfkfsList.Add(item.lxADDdskfkfs);
        //                        jeList.Add(item.je);
        //                        countList.Add(item.count);
        //                    }
        //                }
        //                int count = Convert.ToInt32(query.ToList().Count);//��ȡ����ͬ���ٸ�֧������
        //                if (count == 1)
        //                {//���֧����������Ϊ1
        //                    PriZffs = dskfkfsList[0].ToString();
        //                    PriZflx = Convert.ToInt32(lxList[0].ToString());
        //                    CmdText = string.Format("  SET NOCOUNT OFF insert into Tfmsdskjkpc(rbdh,jgid,zffs,dsk,sxf,zt,cnt,zzsj,zzczyid,zzczyzh,zzczyxm,spjgid,zflx)" +
        //                        "  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');select SCOPE_IDENTITY() ",
        //                        PriRbbh, ObjG.Jigou.id, PriZffs, PriZj, 0, 0, ChkRowCount, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriFwjgid, PriZflx);
        //                    comm.CommandText = CmdText;//������սɿ��ձ�����
        //                    PriRbpcid = comm.ExecuteScalar().ToString();
        //                    GetSql(PriRbpcid);//�����ձ�����id����սɿ��ձ�������ϸ���в�������
        //                    if (PriYcje != PriZj)
        //                    {
        //                        ClsMsgBox.Ts("���տ���תʧ�ܣ�������ѡ�����ݣ�", ObjG.CustomMsgBox, this);
        //                        trans.Rollback();
        //                        return;
        //                    }
        //                    if (PriRowCount != ChkRowCount)
        //                    {
        //                        ClsMsgBox.Ts("���տ���תʧ�ܣ�������ѡ�����ݣ�", ObjG.CustomMsgBox, this);
        //                        trans.Rollback();
        //                        return;
        //                    }
        //                    comm.CommandText = string.Join(";", LstSql);
        //                    comm.ExecuteNonQuery();
        //                    CmdText = "";
        //                    CmdText = "SET NOCOUNT OFF UPDATE Tfmsdsk SET SJDSKZT=10 WHERE id IN (" + string.Join(",", LstYdid) + ") and SJDSKZT=0 ";
        //                    comm.CommandText = CmdText;//���´��տ���Ͻ����տ�״̬��ԭ����δ�����Ϊ����ת
        //                    PriUpdRows = comm.ExecuteNonQuery();
        //                    if (LstSql.Count() != PriUpdRows)
        //                    {
        //                        ClsMsgBox.Ts("���տ���תʧ��!", ObjG.CustomMsgBox, this);
        //                        trans.Rollback();
        //                        return;
        //                    }
        //                    trans.Commit();
        //                    this.Close();
        //                    ClsMsgBox.Ts("���տ���ת�ɹ�������ת" + ChkRowCount + "Ʊ,�ܹ�" + LblZjje.Text + "Ԫ", ObjG.CustomMsgBox, this);
        //                }
        //                else
        //                {
        //                    int ydid = 0;
        //                    //string strzflxmc = lxADDdskfkfsList[0].ToString();//��ȡ��һ��֧���������� 
        //                    string strzflxmc = Prizflxss.Rows[0]["lxADDdskfkfs"].ToString();//��ȡ��һ��֧���������� 
        //                    int iTotallxcount = Prizflxss.Rows.Count;//��ȡһ��ѡ���˶����� 
        //                    int index = 0;
        //                    index = lxADDdskfkfsList.LastIndexOf(strzflxmc);
        //                    int lxcounts = countList[index];
        //                    string zflxstrings = strzflxmc;
        //                    int inum = 0;//���i=0 ����ѭ��Ϊѡ�еĵڼ��� 
        //                    int itlxxh = 0;//ͬ���͵�ѭ������  ��0��ʼ
        //                    for (int i = 0; i <= Bds.Count; i++)
        //                    {
        //                        if (inum >= iTotallxcount)
        //                        {
        //                            if (LstSql.Count > 0)
        //                            {
        //                                comm.CommandText = string.Join(";", LstSql);
        //                                comm.ExecuteNonQuery();
        //                            }
        //                            LstSql.Clear();
        //                            //�����Ŵ��������ܸ��� 
        //                            CmdText = "SET NOCOUNT OFF UPDATE Tfmsdsk SET SJDSKZT=10 WHERE id IN (" + string.Join(",", LstYdid) + ") and  SJDSKZT=0 ";
        //                            comm.CommandText = CmdText;//���´��տ���Ͻ����տ�״̬��ԭ����δ�����Ϊ����ת  
        //                            comm.ExecuteNonQuery();
        //                            trans.Commit();
        //                            LstYdid.Clear();
        //                            break;
        //                        }
        //                        else
        //                        {
        //                            if ((bool)Dgv.Rows[i].Cells[DgvColTxtCheck.Name].EditedFormattedValue == true)
        //                            {
        //                                ydid = Convert.ToInt32(Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value);
        //                                //string Getzflx = Dgv.Rows[i].Cells[DgvColTxtzflx.Name].Value.ToString().Trim();//��ȡ���Ϊi��֧������ΪM  
        //                                string Getzflx = Dgv.Rows[i].Cells[DgvTxtzflxxh.Name].Value.ToString() + Dgv.Rows[i].Cells[DgvColTxtdskfkfs.Name].Value.ToString();
        //                                //PriZffs = Dgv.Rows[i].Cells[DgvColTxtdskfkfs.Name].Value.ToString().Trim();//���ʽ
        //                                //PriZflx = Convert.ToInt32(Dgv.Rows[i].Cells[DgvTxtzflxxh.Name].Value.ToString().Trim());//֧����ʽ
        //                                if (Getzflx == strzflxmc)
        //                                {
        //                                    //�����ȡ����֧������==��ȡ���ĵ�һ��֧�����͵�ֵ
        //                                    if (itlxxh == 0)
        //                                    {//���ͬ��֧������==0ʱ
        //                                        if (LstSql.Count > 0)
        //                                        {
        //                                            comm.CommandText = string.Join(";", LstSql);
        //                                            comm.ExecuteNonQuery();
        //                                        }
        //                                        LstSql.Clear();
        //                                        index = lxADDdskfkfsList.LastIndexOf(strzflxmc);
        //                                        PriZj = jeList[index];
        //                                        int RowCount = countList[index];
        //                                        PriZffs = Dgv.Rows[i].Cells[DgvColTxtdskfkfs.Name].Value.ToString().Trim();//���ʽ
        //                                        PriZflx = Convert.ToInt32(Dgv.Rows[i].Cells[DgvTxtzflxxh.Name].Value.ToString().Trim());//֧����ʽ
        //                                        CmdText = string.Format("  SET NOCOUNT OFF insert into Tfmsdskjkpc(rbdh,jgid,zffs,dsk,sxf,zt,cnt,zzsj,zzczyid,zzczyzh,zzczyxm,spjgid,zflx)" +
        //                                "  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');select SCOPE_IDENTITY() ",
        //                                PriRbbh, ObjG.Jigou.id, PriZffs, PriZj, 0, 0, RowCount, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriFwjgid, PriZflx);
        //                                        comm.CommandText = CmdText;//������սɿ��ձ�����
        //                                        PriRbpcid = comm.ExecuteScalar().ToString();
        //                                        LstYdid.Add(ydid);
        //                                        LstSql.Add(string.Format("INSERT INTO Tfmsdskjkmx (pcid,dskid,ydid,dsk,sxf) VALUES('{0}','{1}','{2}','{3}','{4}')",
        //              PriRbpcid, Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtYdid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value, 0));
        //                                    }
        //                                    else
        //                                    {
        //                                        LstYdid.Add(ydid);
        //                                        LstSql.Add(string.Format("INSERT INTO Tfmsdskjkmx (pcid,dskid,ydid,dsk,sxf) VALUES('{0}','{1}','{2}','{3}','{4}')",
        //              PriRbpcid, Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtYdid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value, 0));
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    if (LstSql.Count > 0)
        //                                    {
        //                                        comm.CommandText = string.Join(";", LstSql);
        //                                        comm.ExecuteNonQuery();
        //                                    }
        //                                    strzflxmc = Getzflx;
        //                                    itlxxh = 0;//��ȡ���ĵ�һ��֧�����͵�ֵ=��ȡ����֧�����ͣ����ͬ���ͷ�ʽ=0
        //                                    LstSql.Clear();
        //                                    index = lxADDdskfkfsList.LastIndexOf(strzflxmc);
        //                                    PriZj = jeList[index];
        //                                    int RowCount = countList[index];
        //                                    PriZffs = Dgv.Rows[i].Cells[DgvColTxtdskfkfs.Name].Value.ToString().Trim();//���ʽ
        //                                    PriZflx = Convert.ToInt32(Dgv.Rows[i].Cells[DgvTxtzflxxh.Name].Value.ToString().Trim());//֧����ʽ
        //                                    CmdText = string.Format("  SET NOCOUNT OFF insert into Tfmsdskjkpc(rbdh,jgid,zffs,dsk,sxf,zt,cnt,zzsj,zzczyid,zzczyzh,zzczyxm,spjgid,zflx)" +
        //                            "  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');select SCOPE_IDENTITY() ",
        //                            PriRbbh, ObjG.Jigou.id, PriZffs, PriZj, 0, 0, RowCount, DateTime.Now, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriFwjgid, PriZflx);
        //                                    comm.CommandText = CmdText;//������սɿ��ձ�����
        //                                    PriRbpcid = comm.ExecuteScalar().ToString();
        //                                    LstYdid.Add(ydid);
        //                                    LstSql.Add(string.Format("INSERT INTO Tfmsdskjkmx (pcid,dskid,ydid,dsk,sxf) VALUES('{0}','{1}','{2}','{3}','{4}')",
        //          PriRbpcid, Dgv.Rows[i].Cells[DgvColTxtDskid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtYdid.Name].Value, Dgv.Rows[i].Cells[DgvColTxtdsk.Name].Value, 0));
        //                                }
        //                                itlxxh = itlxxh + 1;
        //                                inum = inum + 1;
        //                            }
        //                        }
        //                    }
        //                    if (LstSql.Count > 0)
        //                    {
        //                        comm.CommandText = string.Join(";", LstSql);
        //                        comm.ExecuteNonQuery();
        //                        LstSql.Clear();
        //                    }
        //                    if (LstYdid.Count > 0)
        //                    {
        //                        //�����Ŵ��������ܸ��� 
        //                        CmdText = "SET NOCOUNT OFF UPDATE Tfmsdsk SET SJDSKZT=10 WHERE id IN (" + string.Join(",", LstYdid) + ") and  SJDSKZT=0 ";
        //                        comm.CommandText = CmdText;//���´��տ���Ͻ����տ�״̬��ԭ����δ�����Ϊ����ת  
        //                        comm.ExecuteNonQuery();
        //                        trans.Commit();
        //                        LstYdid.Clear();
        //                    }
        //                }
        //                this.Close();
        //                ClsMsgBox.Ts("���տ���ת�ɹ�������ת" + ChkRowCount + "Ʊ,�ܹ�" + LblZjje.Text + "Ԫ", ObjG.CustomMsgBox, this);
        //            }
        //            catch (Exception ex)
        //            {
        //                ClsMsgBox.Cw("���տ���תʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
        //                trans.Rollback();
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}
        //#endregion
        //#region ��װ��ϸSQL���
        //private void GetSql(string aRbpdid)
        //{
        //    LblTs.Visible = false;
        //    //LstSql.Clear();
        //    LstYdid.Clear();
        //    PriYcje = 0;
        //    PriRowCount = 0;
        //    foreach (DataGridViewRow row in Dgv.Rows)
        //    {
        //        if (Convert.ToBoolean(row.Cells[DgvColTxtCheck.Name].Value))
        //        {
        //            LstSql.Add(string.Format("INSERT INTO Tfmsdskjkmx (pcid,dskid,ydid,dsk,sxf) VALUES('{0}','{1}','{2}','{3}','{4}')",
        //                PriRbpcid, row.Cells[DgvColTxtDskid.Name].Value, row.Cells[DgvColTxtYdid.Name].Value, row.Cells[DgvColTxtdsk.Name].Value, 0));
        //            PriYcje += Convert.ToDecimal(row.Cells[DgvColTxtdsk.Name].Value);
        //            LstYdid.Add(Convert.ToInt32(row.Cells[DgvColTxtDskid.Name].Value));
        //            PriRowCount++;
        //        }
        //    }
        //}
        //#endregion
        #endregion
        #endregion

        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 5, 6 };
            ClsExcel.CreatExcel(Dgv, "���տ���ת", this.ctrlDownLoad1, Rows);
        }
        #endregion

        #region Clear ���
        public void Clear()
        {
            PriZj = Convert.ToDecimal(0.00);
            ChkRowCount = 0;
            LblZjje.Text = PriZj.ToString();
            LblCheckCount.Text = "��ѡ��" + ChkRowCount + "��";
            //this.Prizflxss.Clear();
        }
        #endregion

        #region ����
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
