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
using JYPubFiles.Classes;
#endregion

namespace FMS.DSKGL.DSKZZ
{
    public partial class FrmDSKZZ : UserControl
    {
        #region ��Ա����
        private ClsG ObjG;
        private string CmdText;
        private int PriMxCount;
        private int PriRowIndex = 0;
        #endregion
        public FrmDSKZZ()
        {
            InitializeComponent();
        }
        #region ��ʼ������
        public void Prepare()
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            Vfmsdskzz1TableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            ClsPopulateCmbDsS.PopuDsk_zl(CmbDskzl);
            CmbDskzl.SelectedIndex = 2;
        }
        #endregion

        #region ����Excel����
        private void BtnDc_Click(object sender, EventArgs e)
        {
            if (Dgv.RowCount == 0)
            {
                ClsMsgBox.Ts("û��Ҫ��������Ϣ!", ObjG.CustomMsgBox, this);
                return;
            }
            int[] CellIndex = { 6,7, 8 };
            ClsExcel.CreatExcel(Dgv, "���տ���ת", this.ctrlDownLoad2, CellIndex);
        }
        #endregion

        #region ��ѯ
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            ClsD.TextBoxTrim(this);
            string where = " where  jgid=" + ObjG.Jigou.id;
            if (DtpSlStart.Checked)
                where += " and inssj >= '" + DtpSlStart.Value.Date + "'";
            if (DtpSlStop.Checked)
                where += " and inssj < '" + DtpSlStop.Value.AddDays(1).Date + "'";
            if (DtpFfStart.Checked)
                where += " and fksj >= '" + DtpFfStart.Value.Date + "'";
            if (DtpFfStop.Checked)
                where += " and fksj < '" + DtpFfStop.Value.AddDays(1).Date + "'";
            where += string.IsNullOrEmpty(txtsljg.Text) ? "" : " and sljgid =" + Convert.ToInt32(txtsljg.Tag.ToString());
            where += CmbDskzl.SelectedIndex == 0 ? "" : " and dskzl='" + CmbDskzl.Text + "'";
            where += string.IsNullOrEmpty(TxtFhkh.Text) ? "" : " and fhkhmc='" + TxtFhkh.Text + "'";
          

            Vfmsdskzz1TableAdapter1.FillByWhere1(DSdskzz1.Vfmsdskzz1, where);
            if (Dgv.Rows.Count == 0)
                ClsMsgBox.Ts("û��Ҫ��ѯ����Ϣ����˶Բ�ѯ������",ObjG.CustomMsgBox,this);
        }
        #endregion

        #region ����
        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmNewDSKZZ f = new FrmNewDSKZZ();
            f.Prepare();
            f.ShowDialog();
        }

        #endregion

        #region ����ѡ��
        private void BtnSearchjg_Click(object sender, EventArgs e)
        {
            FrmSelectJg f = new FrmSelectJg();
            f.ShowDialog();
           
            f.Prepare();
            f.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed1);
        }
        void f_FormClosed1(object sender, FormClosedEventArgs e)
        {
            FrmSelectJg f = sender as FrmSelectJg;
            if (f.DialogResult == DialogResult.OK)
            {
                this.txtsljg.Text = f.PubDictAttrs["mc"];
                this.txtsljg.Tag=f.PubDictAttrs["id"];
            }
            else if (f.DialogResult == DialogResult.No)
            {
                this.txtsljg.Text = "";
                this.txtsljg.Tag = 0;
            }
        }
        #endregion

        #region ɾ��
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex<0)
                return;
            PriMxCount = 0;
            if (Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType().Name == "DataGridViewLinkCell" &&
                Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "ɾ��")
            {
                PriRowIndex = e.RowIndex;
                ClsMsgBox.YesNo("�Ƿ�ɾ�����տ���ת��Ϣ", new EventHandler(DelYh), ObjG.CustomMsgBox, this);
                //CmdText = "";
                //using (SqlConnection conn = new SqlConnection()) 
                //{
                //    conn.ConnectionString = ClsGlobals.CntStrTMS;
                //    conn.Open();
                //    using (SqlCommand comm = new SqlCommand()) 
                //    {
                //        comm.Connection = conn;
                //        try
                //        {
                //            CmdText = "select cnt from vfmsdskzz1 where mxid=" + Dgv.Rows[e.RowIndex].Cells[DgvColTxtMxid.Name].Value;
                //            comm.CommandText = CmdText;
                //            PriMxCount = Convert.ToInt32(comm.ExecuteScalar());
                //            if (PriMxCount > 1)
                //            {
                //                CmdText = string.Format("update tfmsdsk set sjdskzt=0 where id={0};delete tfmsdskjkmx where id={1};update tfmsdskjkpc set dsk-={2},cnt-=1  where id={3}",
                //                    Dgv.Rows[e.RowIndex].Cells[DgvColTxtDskid.Name].Value, Dgv.Rows[e.RowIndex].Cells[DgvColTxtMxid.Name].Value,
                //                    Dgv.Rows[e.RowIndex].Cells[DgvColTxtFkje.Name].Value, Dgv.Rows[e.RowIndex].Cells[DgvColTxtPcid.Name].Value);
                //            }
                //            else if(PriMxCount==1)
                //            {
                //                CmdText = string.Format("update tfmsdsk set sjdskzt=0 where id={0};delete tfmsdskjkmx where id={1};delete tfmsdskjkpc where id={2}",
                //                       Dgv.Rows[e.RowIndex].Cells[DgvColTxtDskid.Name].Value, Dgv.Rows[e.RowIndex].Cells[DgvColTxtMxid.Name].Value,
                //                       Dgv.Rows[e.RowIndex].Cells[DgvColTxtPcid.Name].Value);
                //            }
                //            comm.CommandText = CmdText;
                //            comm.ExecuteNonQuery();
                //            Dgv.Rows.RemoveAt(e.RowIndex);
                //        }
                //        catch (Exception ex)
                //        {
                //            ClsMsgBox.Cw("ɾ�����տ���ת��Ϣʧ�ܣ�", ObjG.CustomMsgBox, this);
                //        }
                //    }
                //}
            }
        }
        private void DelYh(object sender, EventArgs e)
        {
            FrmMsgBox c = new FrmMsgBox();
            Form f = sender as Form;
            if (f.DialogResult == DialogResult.Yes)
            {
                CmdText = "";
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ClsGlobals.CntStrTMS;
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        try
                        {
                            CmdText = "select cnt from vfmsdskzz1 where mxid=" + Dgv.Rows[PriRowIndex].Cells[DgvColTxtMxid.Name].Value;
                            comm.CommandText = CmdText;
                            PriMxCount = Convert.ToInt32(comm.ExecuteScalar());
                            if (PriMxCount > 1)
                            {
                                CmdText = string.Format("update tfmsdsk set sjdskzt=0 where id={0};delete tfmsdskjkmx where id={1};update tfmsdskjkpc set dsk-={2},cnt-=1  where id={3}",
                                    Dgv.Rows[PriRowIndex].Cells[DgvColTxtDskid.Name].Value, Dgv.Rows[PriRowIndex].Cells[DgvColTxtMxid.Name].Value,
                                    Dgv.Rows[PriRowIndex].Cells[DgvColTxtFkje.Name].Value, Dgv.Rows[PriRowIndex].Cells[DgvColTxtPcid.Name].Value);
                            }
                            else if (PriMxCount == 1)
                            {
                                CmdText = string.Format("update tfmsdsk set sjdskzt=0 where id={0};delete tfmsdskjkmx where id={1};delete tfmsdskjkpc where id={2}",
                                       Dgv.Rows[PriRowIndex].Cells[DgvColTxtDskid.Name].Value, Dgv.Rows[PriRowIndex].Cells[DgvColTxtMxid.Name].Value,
                                       Dgv.Rows[PriRowIndex].Cells[DgvColTxtPcid.Name].Value);
                            }
                            comm.CommandText = CmdText;
                            comm.ExecuteNonQuery();
                            Dgv.Rows.RemoveAt(PriRowIndex);
                        }
                        catch (Exception ex)
                        {
                            ClsMsgBox.Cw("ɾ�����տ���ת��Ϣʧ�ܣ�", c, this);
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

        #region    �ͻ����Ʋ�ѯ
        private void BtnSearchKh_Click(object sender, EventArgs e)
        {
            FrmSelectKh f = new FrmSelectKh();
            f.ShowDialog();
          
            f.Prepare();
            f.FormClosed +=new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(f_FormClosed);
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSelectKh f = sender as FrmSelectKh;
            if (f.DialogResult == DialogResult.OK)
                TxtFhkh.Text = f.PubKhmc;
        }
        #endregion
         
        #region ���տ���ת
        private void Btndskzz_Click(object sender, EventArgs e)
        {
            FrmDSKZZNEW f = new FrmDSKZZNEW();
            f.Prepare();
            f.ShowDialog();
        }
        #endregion
    }
}
