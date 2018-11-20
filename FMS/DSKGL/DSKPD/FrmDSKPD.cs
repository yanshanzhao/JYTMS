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
using System.Data.SqlClient;
#endregion

namespace FMS.DSKGL.DSKPD
{
    public partial class FrmDSKPD : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        #endregion
        public FrmDSKPD()
        {
            InitializeComponent();
        }
        public void Prepare()
        {
            ObjG = Session["ObjG"] as ClsG;
            this.Cmbcplx.SelectedIndex = 0;
            ClsPopulateCmbDsS.PopuFmsDskffsj(Cmbcplx);
        }
        private void BtnQr_Click(object sender, EventArgs e)
        {
            TimeSpan aTsp;
            aTsp = DtpStop.Value.Date - DtpStart.Value.Date;
            int aDayCun = 0;
            aDayCun = Convert.ToInt32(Convert.ToDateTime(DtpStop.Text).Subtract(Convert.ToDateTime(DtpStart.Text)).Days);
            if (aDayCun < 0)
            {
                ClsMsgBox.Ts("����ʱ�䲻��С����ʼʱ�䣡", ObjG.CustomMsgBox, this);
                this.Dgv.DataSource = "";
                return;
            }
            if (aTsp.Days > 31)
            {
                ClsMsgBox.Ts("Ϊ��֤��ѯЧ�ʣ��벻Ҫ��ѯ����һ���µ�����", ObjG.CustomMsgBox, this);
                this.Dgv.DataSource = "";
                return;
            }
            DataTable dt = new DataTable();
            string lx = "";
            if (string.IsNullOrEmpty(Cmbcplx.SelectedValue.ToString()))
                lx = "0";
            else
                lx = Cmbcplx.SelectedValue.ToString();
            //if (Cmbcplx.SelectedIndex == 0)
            //    lx = "A";
            //else if (Cmbcplx.SelectedIndex == 1)
            //    lx = "B";
            //else if (Cmbcplx.SelectedIndex == 2)
            //    lx = "C";
            //else lx = "D";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsGlobals.CntStrTMS;
                conn.Open();
                using (SqlCommand comm = new SqlCommand())
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    try
                    {
                        comm.Connection = conn;
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.CommandText = "P_fmsdskpd1";
                        SqlParameter[] spa = {new SqlParameter("@Star",DtpStart.Value.Date),
                                         new SqlParameter("@Stop",DtpStop.Value.Date),
                                         new SqlParameter("@lx",lx),};
                        comm.Parameters.AddRange(spa);
                        sda.SelectCommand = comm;
                        sda.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ��", ObjG.CustomMsgBox, this);
                            return;
                        }
                        DataRow dr = dt.NewRow();
                        dr["rq"] = "��ĩ��";
                        dr["skje"] = dt.Compute("sum(skje)", "");
                        dr["fkje"] = dt.Compute("sum(fkje)", "");
                        dr["ye"] = dt.Compute("sum(ye)", "");
                        dt.Rows.Add(dr);
                        Dgv.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        ClsMsgBox.Cw("��ѯ��Ϣʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
                    }
                    finally
                    {
                        sda.Dispose();
                        dt.Dispose();
                        comm.Dispose();
                        conn.Close();
                    }

                }
            }
        }
        private void BtnElse_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "���ջ����̵�", this.ctrlDownLoad1, new int[] { 1, 2, 3 });
        }
    }
}
