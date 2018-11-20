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
using System.Data.SqlClient;
#endregion

namespace FMS.DSKGL.DSKKHTZ
{
    public partial class FrmDSKKHXX : Form
    {
        #region ��Ա����
        private ClsG ObjG;
        private string PriOldDskBz = "";//�ɵĴ��ջ��ע
        private string PriZt = "";
        private string PriConStr = "";
        private int PriDSKid = 0;
        private int PriYdid = 0;
        private int PriZhid = 0;
        private string PriXm = "";
        private string PriLogName = "";
        private string PriNewFwkh = "";
        #endregion
        public FrmDSKKHXX()
        {
            InitializeComponent();
        }
        public void Prepare(int aydid, string azt)
        {
            ObjG = VWGContext.Current.Session["ObjG"] as ClsG;
            this.PriConStr = ClsGlobals.CntStrTMS;
            PriZhid = ObjG.Renyuan.id;
            PriXm = ObjG.Renyuan.xm;
            PriLogName = ObjG.Renyuan.loginName;
            PriYdid = aydid;
            PriZt = azt;
            DataRow dr = ClsRWMSSQLDb.GetDataRow(" select bh,zdsj,fhkhbh,shkhbh,fhlxdh,dhlxdh,fhlxr, dhlxr,  fhkhmc, shkhmc,  fhfdz,  shfdz,fwkh,dsk,dshkbz from vfmsdskkhzt2  where id=" + PriYdid, PriConStr);
            this.TxtBYdBh.Text = dr[0].ToString();
            this.TxtBZdsj.Text = Convert.ToDateTime(dr[1].ToString()).ToString("yyyy-MM-dd");
            this.TxtBKHbh1.Text = dr[2].ToString();
            this.TxtBKHbh2.Text = dr[3].ToString();
            this.TxtBDh1.Text = dr[4].ToString();
            this.TxtBDh2.Text = dr[5].ToString();
            this.TxtBfhlxr.Text = dr[6].ToString();
            this.TxtBShlxr.Text = dr[7].ToString();
            this.TxtBFhdw.Text = dr[8].ToString();
            this.TxtBShdw.Text = dr[9].ToString();
            this.TxtBXxDz1.Text = dr[10].ToString();
            this.TxtBXxDz2.Text = dr[11].ToString();
            this.TxtOldFwkh.Text = dr[12].ToString();
            this.TxtBDdsk.Text = dr[13].ToString();
            this.PriOldDskBz = dr[14].ToString();
        }

        private void TxtBNewFwkh_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            GetFwkh();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

            if (this.TxtBBz.Text.Trim().Length == 0)
            {
                ClsMsgBox.Ts("��������տע��", this, TxtBBz, ObjG.CustomMsgBox);
                return;
            }
            using (SqlConnection conn = new SqlConnection(PriConStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand();
                try
                {
                    comm.Connection = conn;
                    comm.Transaction = trans;
                    string cmdText = "";
                    cmdText = " insert into tfmsdskkhtz(ydid,oldfwkh,newfwkh,olddskbz,newdskbz,czyid,czyxm,czyzh,inssj)values (" + PriYdid + ",'" + this.TxtOldFwkh.Text + "','" + PriNewFwkh + "','" + PriOldDskBz + "','" + TxtBBz.Text.Trim().ToString() + "'," + PriZhid + ",'" + PriXm + "','" + PriLogName + "','" + DateTime.Now.ToString() + "'); ";
                    cmdText = cmdText + " update tyd set fwkh='" + PriNewFwkh + "',dshkbz='" + this.TxtBBz.Text.Trim().ToString() + "' where id =" + PriYdid;
                    if (PriZt == "1")
                        cmdText = cmdText + " update TfmsDsk set dskkhbh='" + PriNewFwkh + "',fhkhmc='" + this.TxtBCkr .Text+ "' where ydid=" + PriYdid; comm.CommandText = cmdText;
                    int influenceSum = comm.ExecuteNonQuery();
                    if (influenceSum > 0)
                    {
                        //�ύ���� 
                        trans.Commit();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        ClsMsgBox.Ts("���˵��ţ�" + TxtBYdBh.Text + "�Ĵ��տ�Ÿ�Ϊ" + TxtBNewFwkh.Text + "�޸ĳɹ���", ObjG.CustomMsgBox, this);
                    }
                    else
                    {
                        //�ع�����
                        ClsMsgBox.Ts("���տ���޸�ʧ�ܣ�", ObjG.CustomMsgBox, this);
                        trans.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    //�ع�����
                    try
                    {
                        ClsMsgBox.Cw("���տ���޸��쳣��", ex, ObjG.CustomMsgBox, this);
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
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtBNewFwkh_LostFocus(object sender, EventArgs e)
        {
            GetFwkh();
        }
        private void GetFwkh()
        { 
            if (this.TxtBNewFwkh.Text.Trim().Length == 0)
            {

                ClsMsgBox.Ts("�������´��տ���񿨣�", this, TxtBNewFwkh, ObjG.CustomMsgBox);
                return;
            }
            else
            {
                string SqlCnt = " select mc,id  from tkh where lx ='C' and bh='" + this.TxtBNewFwkh.Text.Trim().ToString() + "'";
                DataRow dr = ClsRWMSSQLDb.GetDataRow(SqlCnt, PriConStr);
                if (dr == null)
                {
                    ClsMsgBox.Ts("û�д��տ���񿨺��ǣ�" + this.TxtBNewFwkh.Text.Trim().ToString(), ObjG.CustomMsgBox, this); this.TxtBNewFwkh.Text = "";
                    this.TxtBNewFwkh.Focus();
                    return;
                }
                else
                {
                    PriNewFwkh = this.TxtBNewFwkh.Text.Trim().ToString();
                    PriDSKid = Convert.ToInt32(dr[1]);
                    this.TxtBCkr.Text = dr[0].ToString();
                }
            }
        }
    }
}