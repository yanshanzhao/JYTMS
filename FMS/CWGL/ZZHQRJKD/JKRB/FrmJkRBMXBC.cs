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
using JYPubFiles.Classes;

#endregion

namespace FMS.CWGL.ZZHQRJKD.JKRB
{
    public partial class FrmJkRBMXBC : Form
    {
        #region ��Ա����
        private ClsG ObjG;
        private DataTable PriDtJsgx;
        private string CmdText;
        private List<int> LstYbfid = new List<int>();
        private List<int> LstRbpcid = new List<int>();
        private List<string> LstSql = new List<string>();
        private List<int> LstJsdid = new List<int>();
        private decimal PriYck = 0;
        private string PriRbdh;//�˵���ϸ���ձ�����
        private string PriRbdh1;//�����ձ����ձ�����
        private string PriSpjgid;//��������ID
        private string PriYwqy;//ѡ���ҵ������
        private string PriRbpcid;//�ձ�����ID
        private decimal PriYckje;
        private decimal PriXjjgjk;//�¼������ɿ�
        private bool PriFlag;
        private string PriLx;
        private DSJKRB.Vfmsjkrb2DataTable PriYdTable;//��ȡ�ϸ�ҳ��ѡ�е�����
        private int PriUpdRows;
        private DataTable PriDtRbpc;//��¼�¼��ɿ����Σ�Group by֮ǰ�ģ�
        #endregion
        public FrmJkRBMXBC()
        {
            InitializeComponent();
        }
        #region ��ʼ������
        public void Prepare(string aYwqys, string aYck, string aYwqy, string aLx, DSJKRB.Vfmsjkrb2DataTable aYdTable)
        {
            ObjG = (ClsG)Session["ObjG"];
            PriLx = aLx;
            BindPc();
            if (Dgv.Rows.Count != 0)
                ForeachRbpc();
            LblBjgjk.Text = aYck.ToString();
            LblSjyc.Text = (Convert.ToDecimal(aYck) + PriXjjgjk).ToString();
            LblYwqy.Text = aYwqys;
            PriYwqy = aYwqy;
            PriYdTable = aYdTable;
            if (PriYdTable.Count > 0)
                PriYck = Convert.ToDecimal(aYck);

            PriDtJsgx = ClsRWMSSQLDb.GetDataTable(" select tojgid,tojgmc from vfmsjggx where gxzl='J' and jgid=" + ObjG.Jigou.id, ClsGlobals.CntStrTMS);
            if (PriDtJsgx.Rows.Count == 1)
            {
                LblSkjg.Text = PriDtJsgx.Rows[0]["tojgmc"].ToString();
                PriSpjgid = PriDtJsgx.Rows[0]["tojgid"].ToString();
            }
            DataRow dr = ClsRWMSSQLDb.GetDataRow("  select SUM(ysje) from  Vfmsjkrb2 where jgid=" + ObjG.Jigou.id, ClsGlobals.CntStrTMS);
            decimal aSumwc = 0;
            decimal n;
            if (decimal.TryParse(dr[0].ToString(), out n))
                aSumwc = Convert.ToDecimal(dr[0]);
            this.lblQk.Text = (aSumwc - (Convert.ToDecimal(aYck))).ToString();
        }
        #endregion

        #region ����¼��ɿ������Ϣ��ѭ���¼������ձ�����

        private void BindPc()
        {
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                conn.ConnectionString = ClsGlobals.CntStrTMS;
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "P_Fmsrbpc";
                comm.Parameters.Add(new SqlParameter("@jgid", ObjG.Jigou.id));
                sda.SelectCommand = comm;
                sda.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    Dgv.DataSource = ds.Tables[0];
                    LblXjjk.Text = ds.Tables[0].Compute("sum(jkje)", "").ToString();
                    LblXjjk.Text = string.IsNullOrEmpty(LblXjjk.Text) ? "0" : LblXjjk.Text;
                    PriDtRbpc = ds.Tables[1];
                    //PriDtrbpc1 = ds.Tables[1];
                }
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ�¼��ɿ�������Ϣʧ�ܣ�", ex, ObjG.CustomMsgBox, this);
            }
            finally
            {
                conn.Dispose();
                sda.Dispose();
                ds.Dispose();
            }
        }
        private void ForeachRbpc()
        {
            LstRbpcid.Clear();
            foreach (DataRow row in PriDtRbpc.Rows)
            {
                PriXjjgjk += Convert.ToDecimal(row["jkje"]);
                LstRbpcid.Add(Convert.ToInt32(row["id"]));
            }
            //LblXjjk.Text = PriXjjgjk.ToString();
        }
        #endregion

        #region ����
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PriSpjgid))
            {
                ClsMsgBox.Ts("�û����޽����ϵ����ά����", ObjG.CustomMsgBox, this);
                return;
            }
            if (!ClsRegEx.IsShiShu(TxtZzje.Text.Trim()))
            {
                ClsMsgBox.Ts("��֧����ʽ����ȷ�����������룡", this, TxtZzje, ObjG.CustomMsgBox);
                return;
            }
            if (string.IsNullOrEmpty(TxtZzdh.Text.Trim()) && Convert.ToDecimal(TxtZzje.Text.Trim()) > 0)
            {
                ClsMsgBox.Ts("��������֧���ţ�", this, TxtZzdh, ObjG.CustomMsgBox);
                return;
            }
            //if (Convert.ToDecimal(TxtZzje.Text.Trim()) > PriYck)
            //{
            //    ClsMsgBox.Ts("��֧���������ʵ��Ӧ�棬���������룡", this, TxtZzje, ObjG.CustomMsgBox);
            //    return;
            //}
            ClsMsgBox.YesNo("ȷ�ϱ���ɿ��ձ���", new EventHandler(SaveRb), ObjG.CustomMsgBox, this);
        }

        public void SaveRb(object sender, EventArgs e)
        {
            PriUpdRows = 0;
            PriFlag = true;
            PriRbdh = "Y" + DateTime.Now.ToString("yyyyMMdd") + ObjG.Jigou.id.ToString().PadLeft(4, '0');
            PriRbdh1 = "P" + DateTime.Now.ToString("yyyyMMdd") + ObjG.Jigou.id.ToString().PadLeft(4, '0');
            Form f = sender as Form;
            FrmMsgBox frm = new FrmMsgBox();
            if (f.DialogResult != DialogResult.Yes)
            {
                Clear();
                return;
            }
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsGlobals.CntStrTMS;
                conn.Open();
                SqlTransaction Trans = conn.BeginTransaction();
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.Transaction = Trans;
                    try
                    {
                        if (PriYdTable.Rows.Count != 0 && Dgv.Rows.Count == 0)
                            InsertYdRB(comm, Trans, frm);
                        else if (Dgv.Rows.Count != 0 && PriYdTable.Rows.Count == 0)
                            InsertPcRB(comm, Trans, frm);
                        else if (PriYdTable.Rows.Count != 0 && Dgv.Rows.Count != 0)
                        {
                            InsertYdRB(comm, Trans, frm);
                            InsertPcRB(comm, Trans, frm);
                        }
                        else
                        {
                            ClsMsgBox.Ts("��ѡ��ɿ��ձ���", frm, this);
                            return;
                        }
                        if (PriFlag)
                        {
                            Trans.Commit();
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            ClsMsgBox.Ts("�����ձ��ɹ���" + Environment.NewLine + "������Ӧ��" + LblBjgjk.Text + "Ԫ,ʵ��" + LblSjyc.Text + "Ԫ", frm, this);
                        }
                        else
                        {
                            Trans.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        Trans.Rollback();
                        ClsMsgBox.Cw("�����ձ�ʧ�ܣ�", ex, frm, this);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
        }
        #endregion

        #region �˵��ձ�
        private void InsertYdRB(SqlCommand comm, SqlTransaction Trans, FrmMsgBox frm)
        {
            CmdText = "";
            CmdText = string.Format("Insert Into Tfmsrbpc (rbdh,jgid,spjgid, ywqy,yck,zzdh,zzje,insczyid,insczyzh,insczyxm,ckbz,dkje,dczt,wydkzt,dkzt)" +
                "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},{11},0,0,0);select SCOPE_IDENTITY() ", PriRbdh, ObjG.Jigou.id, PriSpjgid, PriYwqy,
                PriYck, string.IsNullOrEmpty(TxtZzdh.Text.Trim()) ? "0" : TxtZzdh.Text.Trim(), TxtZzje.Text.Trim(), ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm,
                ChkIsSrzh.Checked ? 1 : 0, PriYck - Convert.ToDecimal(TxtZzje.Text.Trim()));
            comm.CommandText = CmdText;
            PriRbpcid = comm.ExecuteScalar().ToString();
            GetSql(PriRbpcid);
            if (LstSql.Count == 0)
            {
                ClsMsgBox.Ts("��ѡ���ձ����ڱ��棡", frm, this);
                PriFlag = false;
                return;
            }
            if (!PriYck.Equals(PriYckje))
            {
                ClsMsgBox.Ts("�����ձ�ʧ�ܣ�", frm, this);
                Clear();
                PriFlag = false;
                return;
            }
            CmdText = string.Join(";", LstSql);
            comm.CommandText = CmdText;
            comm.ExecuteNonQuery();
            CmdText = "";
            if (LstYbfid.Count != 0)
                CmdText = " SET NOCOUNT OFF Update tfmsybf set zt=10 where id in(" + string.Join(",", LstYbfid) + ") and zt=0 ";
            if (LstJsdid.Count != 0)
                CmdText = "SET NOCOUNT OFF Update tfmskhjspc set zt=15 where id in(" + string.Join(",", LstJsdid) + ")  and zt=10 ";
            comm.CommandText = CmdText;
            PriUpdRows = comm.ExecuteNonQuery();
            if (LstSql.Count() != PriUpdRows)
            {
                ClsMsgBox.Ts("�����ձ�ʧ�ܣ�", frm, this);
                Clear();
                PriFlag = false;
                return;
            }
        }
        #endregion

        #region �¼������ձ�
        private void InsertPcRB(SqlCommand comm, SqlTransaction Trans, FrmMsgBox frm)
        {
            CmdText = "";
            CmdText = string.Format(" SET NOCOUNT OFF Insert Into Tfmsrbpc (rbdh,jgid,spjgid,ywqy,yck,zzdh,zzje,insczyid,insczyzh,insczyxm,dkje,dczt,wydkzt,dkzt) " +
                "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},0,0,0);select SCOPE_IDENTITY() ", PriRbdh1, ObjG.Jigou.id,PriSpjgid, PriYwqy,
                PriXjjgjk, "0", 0.00, ObjG.Renyuan.id, ObjG.Renyuan.loginName, ObjG.Renyuan.xm, PriXjjgjk);
            comm.CommandText = CmdText;
            PriRbpcid = comm.ExecuteScalar().ToString();
            CmdText = " SET NOCOUNT OFF Update tfmsrbpc set pczt=10,pid=" + PriRbpcid + " where id in(" + string.Join(",", LstRbpcid) + ")  and pczt=0";
            if (Convert.ToDecimal(LblXjjk.Text) != PriXjjgjk) 
            {
                ClsMsgBox.Ts("�����ձ�ʧ�ܣ��¼��ɿ����ν�׼ȷ��",ObjG.CustomMsgBox,this);
                Trans.Rollback();
                PriFlag = false;
                return;
            }
           comm.CommandText = CmdText;
            PriUpdRows=comm.ExecuteNonQuery();
            if (LstRbpcid.Count() != PriUpdRows)
            {
                ClsMsgBox.Ts("�����ձ�ʧ�ܣ�", frm, this);
                PriFlag = false;
                return;
            }
        }
        #endregion

        #region ��װ�˵���ϸSQL���
        private void GetSql(string aRbpcid)
        {
            LstSql.Clear();
            LstYbfid.Clear();
            LstJsdid.Clear();
            PriYckje = 0;

            foreach (DSJKRB.Vfmsjkrb2Row row in PriYdTable.Rows)
            {

                if (row["lx"].ToString().Equals("0"))
                {
                    LstSql.Add(string.Format("SET NOCOUNT OFF INSERT INTO Tfmsrbmx(rbpcid,jzlx,ydid ,yf,bf,zj,ybfid,lx)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", aRbpcid, row["Jzlx"],
         row["Ydid"], row["yf"], row["bf"], row["ysje"],row["Ybfid"], 'Y'));
                    PriYckje += Convert.ToDecimal(row["ysje"]);
                    LstYbfid.Add(Convert.ToInt32(row["Ybfid"]));
                }
                else if (row["Lx"].ToString().Equals("1"))
                {
                    LstSql.Add(string.Format("SET NOCOUNT OFF INSERT INTO Tfmsrbmx(rbpcid,jzlx ,yf,bf ,zj,khjsid,lx)VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", aRbpcid, row["Jzlx"],
              row["yf"], row["bf"], row["ysje"], row["Ybfid"], 'J'));
                    PriYckje += Convert.ToDecimal(row["ysje"]);
                    LstJsdid.Add(Convert.ToInt32(row["Ybfid"]));
                }
            }

        }
        #endregion

        #region Clear()
        private void Clear()
        {
            PriYckje = 0;
            CmdText = "";
        }
        #endregion

        #region ���ذ�ť
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ��֧����ж�
        private void TxtZzje_LostFocus(object sender, EventArgs e)
        {
            ClsD.TextBoxTrim(this);
            if (!ClsRegEx.IsJe2(TxtZzje.Text))
            {
                ClsMsgBox.Ts("��֧����ʽ����ȷ�����������룡", this, TxtZzje, ObjG.CustomMsgBox);
                return;
            }
            //if (Convert.ToDecimal(LblSjyc.Text) < Convert.ToDecimal(TxtZzje.Text))
            //{

            //    ClsMsgBox.Ts("��֧���������ʵ��Ӧ�棬���������룡", this, TxtZzje, ObjG.CustomMsgBox);
            //    return;
            //}
            LblSjyc.Text = (Convert.ToDecimal(LblSjyc.Text) - Convert.ToDecimal(TxtZzje.Text)).ToString();
        }
        #endregion

        #region �ж��Ƿ������������˻�
        private void ChkIsSrzh_CheckedChanged(object sender, EventArgs e)
        {
            if (PriLx.Equals("Y"))
            {
                ChkIsSrzh.Checked = true;
                ClsMsgBox.Ts("�ɿ��ձ�Ϊ�˵���ϸ���ʽ����ѡ�������������˻���", ObjG.CustomMsgBox, this);
                return;
            }
        }
        #endregion

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (Dgv.Columns[e.ColumnIndex].Name == "DgvColLnk")
            {
                Dgv.Visible = false;
                Dgv1.Visible = true;
                Dgv1.DataSource = (from datarow in PriDtRbpc.AsEnumerable() where datarow.Field<int>("jgid") == (Convert.ToInt32(Dgv.Rows[e.RowIndex].Cells[DgvColTxtJgid.Name].Value)) select datarow).CopyToDataTable();
            }
        }

        private void Dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (Dgv1.Columns[e.ColumnIndex].Name == "DgvColLnk1")
            {
                Dgv.Visible = true;
                Dgv1.Visible = false;
                Dgv1.DataSource = "";
            }
        }
    }
}
