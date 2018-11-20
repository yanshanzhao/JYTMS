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
using FMS.SeleFrm;
using System.Data.SqlClient;
#endregion

namespace FMS.JSGL.KHJS
{
    public partial class FrmKHJSDLL : UserControl
    {
        #region ��Ա����
        private string PriWhere = "";
        private ClsG ObjG;
        private int PriNd = 0;
        private int PriYf = 0;
        #endregion
        public FrmKHJSDLL()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ClsPopulateCmbDsS.PopuYd_cplx_qb(CmbYwqy, ClsGlobals.CntStrKj);
            CmbJegx.SelectedIndex = 0;
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            VfmskhjsdllTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
        }
        #region ����
        private void BtnAnd_Click(object sender, EventArgs e)
        {
            FrmKHZJ f = new FrmKHZJ();
            f.ShowDialog();
            f.Prepare(EnumNEDD.New);
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed2);
        }
        #endregion
        void f_FormClosed2(object sender, FormClosedEventArgs e)
        {
            FrmKHZJ f = sender as FrmKHZJ;
            if (f.DialogResult == DialogResult.OK)
            {
                ClsMsgBox.Ts("�����ɹ���", ObjG.CustomMsgBox, this);
            }
        }

        private void BtnJG_Click(object sender, EventArgs e)
        {
            FrmSelectJg f = new FrmSelectJg();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            using (FrmSelectJg f = sender as FrmSelectJg)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    this.TxtDzjg.Text = f.PubDictAttrs["mc"];
                    this.LblDzjgmc.Text = f.PubDictAttrs["id"];
                }
                else if (f.DialogResult == DialogResult.No)
                {
                    this.TxtDzjg.Text = "";
                    this.LblDzjgmc.Text = "0";
                }
            }
        }

        private void BtnKH_Click(object sender, EventArgs e)
        {
            FrmSelectKh1 f = new FrmSelectKh1();
            f.ShowDialog();
            f.Prepare();
            f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosing);
        }
        void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FrmSelectKh1 f = sender as FrmSelectKh1)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    TxtKhmc.Text = f.PubKhmc;
                    this.lblKhid.Text = f.PubKkid.ToString();
                }
                else
                {
                    TxtKhmc.Text = "";
                    this.lblKhid.Text = "";
                }
            }
        }

        #region ��굥ѡ
        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1)
                return;
            if (e.ColumnIndex < 12)
                return;
            int aId = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtId.Name].Value);
            if (e.ColumnIndex == 12 && Dgv.Rows[e.RowIndex].Cells[DgvColCelDel.Name].Value.ToString() == "ɾ��")
            {
                FrmKHJSDel f = new FrmKHJSDel();
                f.ShowDialog();
                f.Prepare(aId);
                f.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(f_FormClosingDel);
            }
            else if (e.ColumnIndex == 13 && Dgv.Rows[e.RowIndex].Cells[DgvColTxtXg.Name].Value.ToString() == "�޸�")
            {
                FrmKHZJUp f = new FrmKHZJUp();
                f.ShowDialog();
                f.Prepare(aId);
                f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
            }
            else if (e.ColumnIndex == 14 && Dgv.Rows[e.RowIndex].Cells[DgvColTxtJs.Name].Value.ToString() == "����")
            {
                int cnts = 0;
                int n;
                if (Int32.TryParse(Dgv.Rows[e.RowIndex].Cells[DgvColTxtCnt.Name].Value.ToString(), out n))
                {
                    cnts = Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtCnt.Name].Value);
                }
                using (SqlConnection conn = new SqlConnection(ClsGlobals.CntStrTMS))
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    SqlCommand comm = new SqlCommand();
                    try
                    {
                        comm.Connection = conn;
                        comm.Transaction = trans;
                        string cmdText = "";
                        int influenceSum = 0;
                        cmdText = " SET NOCOUNT OFF update tfmsybf set zt='15' where zt=10 and id in(select ybfid from tfmskhjsmx where pcid=" + aId + ");";
                        comm.CommandText = cmdText;
                        influenceSum = comm.ExecuteNonQuery();
                        cmdText = " SET NOCOUNT OFF update tfmskhjspc set zt='10',jsczyid=" + ObjG.Renyuan.id + ",jsczyxm='" + ObjG.Renyuan.xm + "',jssj='" + DateTime.Now.ToString() + "'   where zt=0 and id=" + aId;
                        comm.CommandText = cmdText;
                        influenceSum = influenceSum + comm.ExecuteNonQuery();
                        if (influenceSum == cnts + 1)
                        {
                            //�ύ����
                            ClsMsgBox.Ts("����ɹ���", ObjG.CustomMsgBox, this);
                            trans.Commit();
                            Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" SELECT id, dzdh, y, m, st, et, ywqy, jgid, dzjgmc, khid, khmc, je, yjje, wjje, jszt, del, xg, js, xx, cnt FROM dbo.Vfmskhjsdll  " + PriWhere, ClsGlobals.CntStrTMS);
                        }
                        else
                        {
                            //�ع�����
                            ClsMsgBox.Ts("����ʧ�ܣ�", ObjG.CustomMsgBox, this);
                            trans.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        //�ع�����
                        try
                        {
                            ClsMsgBox.Cw("�����쳣��", ex, ObjG.CustomMsgBox, this);
                            trans.Rollback();
                        }
                        catch (SqlException ex1)
                        {
                            if (trans.Connection != null)
                                ClsMsgBox.Cw("�ع�ʧ��! �쳣����:" + ex1.GetType(), ex1, ObjG.CustomMsgBox, this);
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else if (e.ColumnIndex == 15)
            {
                FrmKHJSXQ f = new FrmKHJSXQ();
                f.ShowDialog();
                f.Prepare(aId);
            }
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (FrmKHZJUp f = sender as FrmKHZJUp)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" SELECT id, dzdh, y, m, st, et, ywqy, jgid, dzjgmc, khid, khmc, je, yjje, wjje, jszt, del, xg, js, xx, cnt FROM dbo.Vfmskhjsdll  " + PriWhere, ClsGlobals.CntStrTMS);
                }
            }
        }
        void f_FormClosingDel(object sender, FormClosingEventArgs e)
        {
            using (FrmKHJSDel f = sender as FrmKHJSDel)
            {
                if (f.DialogResult == DialogResult.OK)
                {
                    Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" SELECT id, dzdh, y, m, st, et, ywqy, jgid, dzjgmc, khid, khmc, je, yjje, wjje, jszt, del, xg, js, xx, cnt FROM dbo.Vfmskhjsdll  " + PriWhere, ClsGlobals.CntStrTMS);
                }
            }
        }
        #endregion

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //PriWhere = "";
            PriWhere = " ";
            if (DtpStart.Checked && DtpStop.Checked)
                PriWhere = PriWhere + "  and inssj >='" + DtpStart.Value.Date + "'and inssj< '" + DtpStop.Value.AddDays(1).Date + "')";
            else if (DtpStart.Checked && !DtpStop.Checked)
                PriWhere = PriWhere + "  and inssj >='" + DtpStart.Value + "'and inssj<'" + DateTime.Now.AddDays(1).Date + "')";
            else if (!DtpStart.Checked && DtpStop.Checked)
                PriWhere = PriWhere + "   and inssj <='" + DtpStop.Value + "'";
            if (TxtBDh.Text.Trim().Length > 0)
                PriWhere = PriWhere + " and dzdh like '%" + TxtBDh.Text.Trim().ToString() + "%'";
            if (CmbYwqy.SelectedIndex != 0)
                PriWhere = PriWhere + " and ywqy='" + CmbYwqy.Text + "'";
            if (TxtKhmc.Text.Trim().Length > 0)
                PriWhere = PriWhere + " and khmc='" + TxtKhmc.Text.Trim().ToString() + "'";
            int n;
            if (this.TxtNd.Text.Trim().Length > 0)
            {
                if (!Int32.TryParse(this.TxtNd.Text, out n))
                {
                    ClsMsgBox.Ts("����Ķ��˵���ȸ�ʽ����", ObjG.CustomMsgBox, this);
                    TxtNd.Text = "";
                    TxtNd.Focus();
                    return;
                }
                else
                {
                    int aNd = Convert.ToInt32(TxtNd.Text);
                    if (!(aNd > 1990 && aNd < 2100))
                    {
                        ClsMsgBox.Ts("����Ķ��˵���Ȳ�����,����������", ObjG.CustomMsgBox, this);
                        TxtNd.Text = "";
                        TxtNd.Focus();
                        return;
                    }
                    else
                    {
                        PriNd = aNd;
                        PriWhere = PriWhere + " and y=" + aNd;
                    }
                }

            }
            if (this.TxtYf.Text.Trim().Length > 0)
            {
                if (!Int32.TryParse(this.TxtYf.Text, out n))
                {
                    ClsMsgBox.Ts("����Ķ��˵��·ݸ�ʽ����", ObjG.CustomMsgBox, this);
                    TxtYf.Text = "";
                    TxtYf.Focus();
                    return;
                }
                else
                {
                    int aYf = Convert.ToInt32(TxtYf.Text);
                    if (!(aYf > 0 && aYf <= 12))
                    {
                        ClsMsgBox.Ts("����Ķ��˵��·ݲ�����,���������룡", ObjG.CustomMsgBox, this);
                        TxtYf.Text = "";
                        TxtYf.Focus();
                        return;
                    }
                    else
                    {
                        PriYf = aYf;
                        PriWhere = PriWhere + " and m=" + aYf;
                    }
                }
            }
            if (TxtDzjg.Text.Trim().Length > 0)
                PriWhere = PriWhere + " and dzjgmc='" + TxtDzjg.Text.Trim().ToString() + "'";
            if (CmbJegx.SelectedIndex != 0)
                PriWhere = PriWhere + " and jszt='" + CmbJegx.Text + "'";
            PriWhere = PriWhere.Trim();
            if (PriWhere.Length > 0)
                PriWhere = " where  " + PriWhere.Remove(0, 3);            
            Dgv.DataSource = ClsRWMSSQLDb.GetDataTable(" SELECT id, dzdh, y, m, st, et, ywqy, jgid, dzjgmc, khid, khmc, je, yjje, wjje, jszt, del, xg, js, xx, cnt FROM dbo.Vfmskhjsdll  " + PriWhere, ClsGlobals.CntStrTMS);
            if (Dgv.RowCount == 0)
                ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ!", ObjG.CustomMsgBox, this);
        }

        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 8, 9, 10 };
            ClsExcel.CreatExcel(Dgv, "�ͻ����㵥���", this.ctrlDownLoad1, Rows);
            //ClsExcel.CreatExcel(Dgv, "�ͻ����㵥���", this.ctrlDownLoad1);    
        }
    }
}