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

#endregion

namespace FMS.CXTJ.DSKFWKWGCX
{
    public partial class FrmDSKFWKWGCXMX : Form
    {
        #region ��Ա����
        private ClsG ObjG;
        private string PriWhere;
        private FrmDSKFWKWGYDMX f;
        #endregion

        public FrmDSKFWKWGCXMX()
        {
            InitializeComponent();
        }
        #region ��ʼ������
        public void Prepare( string aWhere,string aFwkh)
        {
            ObjG = Session["ObjG"] as ClsG;
            try
            {
                DSCX.Clear();
                LblFwkh.Text = aFwkh;
                PriWhere = aWhere;
                ClsRWMSSQLDb.FillTable(DSCX, "select fhlxr as fhr,count(fhlxr) as ps,fhlxdh as lxfs,mc as sljgmc,sljgid,'��ϸ��Ϣ' as cz from tyd left join jyjckj.dbo.tjigou on tyd.sljgid=jyjckj.dbo.tjigou.id where fwkh='"+aFwkh+"'  and  " + aWhere + " group by fhlxr,fhlxdh,mc,sljgid", ClsGlobals.CntStrTMS);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("��ѯ��ϸʧ�ܣ�",ex,ObjG.CustomMsgBox,this);
            }
        }
        #endregion

        #region ����
        private void BtnExl_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count <= 0) 
            {
                ClsMsgBox.Ts("û����Ҫ��������Ϣ��",ObjG.CustomMsgBox,this);
                return;
            }

            ClsExcel.CreatExcel(Dgv, "���񿨺�Υ���ѯ��ϸ", ctrlDownLoad2,new int[]{1});
        }
        #endregion

        #region �˵���ϸ
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (Dgv.Columns[e.ColumnIndex].Name.Equals("DgvColLnk"))
            {
                f = new FrmDSKFWKWGYDMX();
                f.Prepare(LblFwkh.Text, PriWhere + " and fhlxr='" + Dgv.Rows[e.RowIndex].Cells[DgvColTxtFhr.Name].Value + "' and fhlxdh='" + Dgv.Rows[e.RowIndex].Cells[DgvColTxtLxfs.Name].Value + "'" + " and sljgid=" + Dgv.Rows[e.RowIndex].Cells[DgvColTxtSjgid.Name].Value);
                f.ShowDialog();
            }
        }
        #endregion
    }
}