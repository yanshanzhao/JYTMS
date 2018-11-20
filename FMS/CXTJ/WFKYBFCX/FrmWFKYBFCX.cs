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
using NPOI.HSSF.UserModel;
using System.IO;
#endregion

namespace FMS.CXTJ.WFKYBFCX
{
    public partial class FrmWFKYBFCX : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private FrmSelectJg2 f;
        private FrmLSDWFKYBF f1;
        private FrmYDWFKYBF f2;
        private int PriJgid;
        private int PriLevel;
        private SqlDataAdapter sda;
        private DataSet ds;
        #endregion
        public FrmWFKYBFCX()
        {
            InitializeComponent();
        }

        #region ��ʼ������
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            PriLevel = ObjG.Jigou.level;
            PriJgid = ObjG.Jigou.id;
            TxtCkjg.Text = ObjG.Jigou.mc;
            sda = new SqlDataAdapter();
            ds = new DataSet();
        }
        #endregion

        #region ������ѯ
        private void BtnJG_Click(object sender, EventArgs e)
        {
            FrmSelectJg2 f = new FrmSelectJg2();
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
            f.ShowDialog();
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            f = sender as FrmSelectJg2;
            if (f.DialogResult == DialogResult.OK)
            {
                this.TxtCkjg.Text = f.PubDictAttrs["mc"];
                PriJgid = Convert.ToInt32(f.PubDictAttrs["id"]);
                PriLevel = Convert.ToInt32(f.PubDictAttrs["Level"]);

            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.TxtCkjg.Text = f.PubDictAttrs["mc"]; ;
                PriLevel = ObjG.Jigou.level;
                PriJgid = ObjG.Jigou.id;
            }
        }
        #endregion

        #region ��ѯ
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ClsGlobals.CntStrTMS;
            try
            {
                SqlParameter[] spa = new SqlParameter[]
                {
                    new SqlParameter("@jgid",PriJgid), 
                    new SqlParameter("@time",DtpStart.Value),
                    new SqlParameter("@Level",PriLevel),
                     new SqlParameter("@Type",'A')
                 };
                conn.Open();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "P_Fmswfkybfcx";
                comm.Parameters.AddRange(spa);
                comm.CommandTimeout = 300;
                sda.SelectCommand = comm;
                ds.Clear();
                sda.Fill(ds, "fmswfkybfcx");
                if (ds.Tables.Count == 0)
                {
                    ClsMsgBox.Ts("û�в�ѯ����Ӧ��Ϣ��", ObjG.CustomMsgBox, this);
                    return;
                }
                DataRow dt = ds.Tables["fmswfkybfcx"].NewRow();
                dt["jgmc"] = "�ϼ�";
                dt["ts0"] = ds.Tables["fmswfkybfcx"].Compute("sum(ts0)", "");
                dt["ts1"] = ds.Tables["fmswfkybfcx"].Compute("sum(ts1)", "");
                dt["ts2"] = ds.Tables["fmswfkybfcx"].Compute("sum(ts2)", "");
                dt["ts3"] = ds.Tables["fmswfkybfcx"].Compute("sum(ts3)", "");
                dt["ts999"] = ds.Tables["fmswfkybfcx"].Compute("sum(ts999)", "");
                dt["hj"] = ds.Tables["fmswfkybfcx"].Compute("sum(hj)", "");
                ds.Tables["fmswfkybfcx"].Rows.Add(dt);
                if (ds.Tables["fmswfkybfcx"].Rows.Count == 1)
                {
                    ClsMsgBox.Ts("û�в�ѯ����Ӧ��Ϣ��", ObjG.CustomMsgBox, this);
                    ds.Tables["fmswfkybfcx"].Clear();
                }
                Dgv.DataSource = ds.Tables["fmswfkybfcx"];
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ��Ϣʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }
            finally
            {
                sda.Dispose();
                comm.Dispose();
                conn.Close();
            }
        }
        #endregion

        #region Dgv�����¼�
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if ((e.ColumnIndex == 6) && e.RowIndex < Dgv.Rows.Count - 1)//����Ĵ�����������
            {
                if (PriLevel == 1 || PriLevel == 0) //����ϼƣ���ѯ��������ϸ
                {
                    f1 = new FrmLSDWFKYBF();
                    f1.Prepare(Dgv.Rows[e.RowIndex].Cells[DgvColTxtJgid.Name].Value.ToString(), Convert.ToDateTime(DtpStart.Value),
                        Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgmc.Name].Value.ToString(), Dgv.Rows[e.RowIndex].Cells[DgvColLclHj.Name].Value.ToString(), "A");
                    f1.ShowDialog();
                }
                else if (PriLevel >= 3) //����ϼƣ���ѯ���˵���ϸ
                {
                    f2 = new FrmYDWFKYBF();
                    f2.Prepare(Convert.ToDateTime(DtpStart.Value), Dgv.Rows[e.RowIndex].Cells[DgvColTxtJgid.Name].Value.ToString(),
                        Dgv.Rows[e.RowIndex].Cells[DgvColTxtjgmc.Name].Value.ToString(), Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), "B");
                    f2.ShowDialog();
                }
            }
            else if (e.ColumnIndex == 6 && e.RowIndex == Dgv.Rows.Count - 1) //����ܼƣ���ѯ�����л�����ϸ
            {
                if (PriLevel == 1 || PriLevel == 0) //����ϼƣ���ѯ��������ϸ
                {
                    f1 = new FrmLSDWFKYBF();
                    f1.Prepare(PriJgid.ToString(), Convert.ToDateTime(DtpStart.Value),
                        TxtCkjg.Text, Dgv.Rows[e.RowIndex].Cells[DgvColLclHj.Name].Value.ToString(), "C");
                    f1.ShowDialog();
                }
                else if (PriLevel >= 3) //����ϼƣ���ѯ���˵���ϸ
                {
                    f2 = new FrmYDWFKYBF();
                    f2.Prepare(Convert.ToDateTime(DtpStart.Value), PriJgid.ToString(),
                        TxtCkjg.Text, Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), "D");
                    f2.ShowDialog();
                }
            }
        }
        #endregion

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ��", ObjG.CustomMsgBox, this);
                return;
            }
            int[] Rows = new int[] { 1, 2, 3, 4, 5, 6 };
            ClsExcel.CreatExcel(Dgv, "δ�����˱��Ѳ�ѯ", this.ctrlDownLoad1, Rows, true);

        }
    }
}