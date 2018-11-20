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
using System.Data.SqlClient;
using System.Collections;

#endregion

namespace FMS.CXTJ.WFKYBFCX
{
    public partial class FrmYDWFKYBF : Form
    {
        #region ��Ա����
        private ClsG ObjG;
        private SqlDataAdapter sda;
        private DataSet ds;
        #endregion

        public FrmYDWFKYBF()
        {
            InitializeComponent();
        }
        #region ��ʼ������
        public void Prepare(DateTime aTime,string aJgid,string aJgmc,string aJe,string aType) 
        {
            LblJgmc.Text = aJgmc;
            LblZje.Text = aJe;
            ObjG = Session["ObjG"] as ClsG;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsGlobals.CntStrTMS;
                conn.Open();
                using (SqlCommand comm = new SqlCommand())
                {
                    try
                    {
                        sda = new SqlDataAdapter();
                        ds = new DataSet();
                        comm.Connection = conn;
                        ArrayList aryLst = new ArrayList();
                        aryLst.Add(new SqlParameter("@jgid", aJgid));
                        aryLst.Add(new SqlParameter("@time", aTime));
                        aryLst.Add(new SqlParameter("@Level", ObjG.Jigou.level));
                        aryLst.Add(new SqlParameter("@Type", aType));
                        comm.Parameters.AddRange(aryLst.ToArray(typeof(SqlParameter)));
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.CommandText = "P_Fmswfkybfcx";
                        sda.SelectCommand = comm;
                        ds.Clear();
                        sda.Fill(ds, "fmswfkybfcx");
                        Dgv.DataSource = ds.Tables["fmswfkybfcx"];
                    }
                    catch (Exception ex)
                    {
                        ClsMsgBox.Cw("��ѯ��Ϣʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
                    }
                    finally
                    {
                        conn.Close();
                        sda.Dispose();
                    }
                }
            }
        }
        #endregion 

        #region ����
        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0) 
            {
                ClsMsgBox.Ts("û����Ҫ��������Ϣ��",ObjG.CustomMsgBox,this);
                return;
            }
            int[] RowIndex = {4,5};
            ClsExcel.CreatExcel(Dgv, "δ�����˱����˵���ϸ", ctrlDownLoad1, RowIndex);
        }
        #endregion
    }
}