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

using System.IO;
using System.Text.RegularExpressions;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
using System.Configuration;

#endregion
namespace FMS.ZJCGL.ZHCX
{
    public partial class FrmZHCX : UserControl
    {
        private StringBuilder cmdText;
        //private string PriServerKhhStr = JY.Pri.ClsOptions.DB.JHKHH;//���пͻ���
        //private string PriServerPwdStr = JY.Pri.ClsOptions.DB.JHPWD;//��������
        //private string PriServerCZYH = JY.Pri.ClsOptions.DB.JHCZYH;//���в���Ա��
        private ClsG ObjG;
        public FrmZHCX()
        {
            InitializeComponent();
        }
        private string where = "  ";
        #region Prepare()
        public void Prepare()
        {
            ObjG = (ClsG)VWGContext.Current.Session["ObjG"];
            CmbBd();
        }
        private void CmbBd()
        {
            DataTable dtjgmc = ClsRWMSSQLDb.GetDataTable("select id,mc from tjigou where level<2 order by xh,id ",
                ClsGlobals.CntStrKj);
            ClsPopulateCmbDsS.PopuByTb(this.Cmbjg, TjSyb(dtjgmc, "id", "mc"), "id", "mc");

            DataTable dtyhlx = ClsRWMSSQLDb.GetDataTable(" select id,jc from tyhlx where hdzt='Y' ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.Cmbyhmc, TjYhlx(dtyhlx, "id", "jc"), "id", "jc");

            DataTable dtzhlx = ClsRWMSSQLDb.GetDataTable(" select id,mc from tfmszhlx ", ClsGlobals.CntStrTMS);
            ClsPopulateCmbDsS.PopuByTb(this.Cmbzhlx, TjZhlx(dtzhlx, "id", "mc"), "id", "mc");

            CmbZhxz.SelectedIndex = 0;
            Cmbzt.SelectedIndex = 0;
        }
        #region combobox�ľ�̬���
        private DataTable TjYhlx(DataTable dt, System.String lm1, System.String lm2)
        {
            DataRow dr = dt.NewRow();
            dr[lm1] = 0;
            dr[lm2] = "--��ѡ����������--";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }
        private DataTable TjZhlx(DataTable dt, System.String lm1, System.String lm2)
        {
            DataRow dr = dt.NewRow();
            dr[lm1] = 0;
            dr[lm2] = "--��ѡ���˻�����--";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }
        private DataTable TjSyb(DataTable dt, System.String lm1, System.String lm2)
        {
            DataRow dr = dt.NewRow();
            dr[lm1] = 0;
            dr[lm2] = "ȫ��";
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }
        #endregion
        #endregion

        #region ��ѯ
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            where = "  ";
            where += !string.IsNullOrEmpty(this.TxtZhmc.Text.Trim()) ? " and [zhmc] like '%" + this.TxtZhmc.Text.Trim() + "%'" : "";
            if (!string.IsNullOrEmpty(this.Txtzh.Text.Trim()))
            {
                if (!ClsRegEx.IsYinHangZhangHao(this.Txtzh.Text.Trim()))
                {
                    ClsMsgBox.Ts("����������˺Ų���ȷ,���������룡",ObjG.CustomMsgBox,this);
                    return;
                }
                where += !string.IsNullOrEmpty(this.Txtzh.Text.Trim()) ? " and [zh]='" + this.Txtzh.Text.Trim() + "'" : "";
            }
            where += !string.IsNullOrEmpty(this.Txtkhh.Text.Trim()) ? " and [khh] like '%" + this.Txtkhh.Text.Trim() + "%'" : "";


            if (CmbZhxz.SelectedItem != null)
            {
                switch (CmbZhxz.SelectedItem.ToString())
                {
                    case "�Թ�":
                        where += " and  [zhxz]= 'G' ";
                        break;
                    case "�����˻�":
                        where += " and  [zhxz]= 'R' ";
                        break;
                    default:
                        break;
                }
            }
            if (this.Cmbzt.SelectedItem != null)
            {
                switch (Cmbzt.SelectedItem.ToString())
                {
                    case "����":
                        where += " and  [zt]= 0 ";
                        break;
                    case "����":
                        where += " and  [zt]= 10 ";
                        break;
                    default:
                        break;
                }
            }
            if (this.Cmbjg.Text.ToString() != "ȫ��")
                Jgid();
            if (this.Cmbyhmc.Text.ToString() != "--��ѡ����������--")
                where += string.Format(" and [yhlxmc]='{0}' ", Cmbyhmc.Text.ToString());
            if (this.Cmbzhlx.Text.ToString() != "--��ѡ���˻�����--")
                where += string.Format(" and [zhlxmc]='{0}'  ", Cmbzhlx.Text.ToString());
            where=where.Trim();
            if (where.Length > 0)
                where = " where " + where.Remove(0, 3);
            DgvBinding();
            if (Dgv.Rows.Count <= 0)
                ClsMsgBox.Ts("û��Ҫ��ѯ���˻���Ϣ��", ObjG.CustomMsgBox, this);
        }

        #region ��û���ID
        private void Jgid()
        {
            int jgid = Convert.ToInt32(Cmbjg.SelectedValue.ToString());
            string PriCmd = "select level from tjigou where id= " + jgid;
            int Level = ClsRWMSSQLDb.GetInt(PriCmd, ClsGlobals.CntStrKj);
            List<int> lstJgid = new List<int>();
            if (Level != 5)
            {
                lstJgid.Clear();
                PriCmd = "";
                string id = "id" + (Level + 1).ToString();
                for (int i = 0; i < 5; i++)
                {
                    if (Level < 5)
                    {
                        if (Level == 0)
                            PriCmd = " select id2 from vjigou123456  where  " + id + "=" + jgid + " and(cnt2 is null) and id2 is not null union ";
                        if (Level == 1)
                            PriCmd += " select id3 from vjigou123456  where " + id + "=" + jgid + " and(cnt3 is null) and id3 is not null union  ";
                        if (Level == 2)
                            PriCmd += " select id4 from vjigou123456  where " + id + "=" + jgid + "and(cnt4 is null) and id4 is not null union  ";
                        if (Level == 3)
                            PriCmd += " select id5 from vjigou123456  where " + id + "=" + jgid + " and(cnt5 is null) and id5 is not null union  ";
                        if (Level == 4)
                            PriCmd += " select id6 from vjigou123456  where " + id + "=" + jgid + " and(cnt6 is null) and id6 is not null ";
                        Level++;
                    }
                    else
                        break;
                }

                DataTable dt = ClsRWMSSQLDb.GetDataTable(PriCmd, ClsGlobals.CntStrKj);
                foreach (DataRow dr in dt.Rows)
                {
                    lstJgid.Add(Convert.ToInt32(dr[0]));
                }
                if (lstJgid.Count == 0)
                    where += " and  jgid=" + jgid;
                else
                    where += " and  jgid in (" + string.Join(",", lstJgid) + ")";
            }
        }
        #endregion

        #region DgvBinding
        private void DgvBinding()
        {
            DSCX.Clear();
            cmdText = new StringBuilder();
            if (this.CmbZhxz.Text == "�Թ�")
            {
                cmdText.Append(" (select [jgmc], [zhlxmc],[yhlxmc],[zhmc],[zh],null as [ye], [yhye],[zhxzmc],[khh], [ztmc], 1px from  [Vfmsyhzh]   ");
                cmdText.Append( where + ")");
                cmdText.Append(" Union (SELECT  '�ϼƣ�', CAST( COUNT(id) AS varchar)+'��' ,null ,null,  null,null,sum(yhye),null,null ,null  ,2px from Vfmsyhzh ");
                cmdText.Append(" where " + where + ")");
                cmdText.Append(" order by px,3,4,1  ");
            }
            else
            {
                cmdText.Append(" (select [jgmc], [zhlxmc],[yhlxmc],[zhmc],[zh],[ye], null as [yhye],[zhxzmc],[khh], [ztmc], 1px from  [Vfmsyhzh]   ");
                cmdText.Append( where + ")");
                cmdText.Append(" Union (SELECT  '�ϼƣ�', CAST( COUNT(id) AS varchar)+'��' ,null ,null,  null,sum(ye),null,null,null ,null  ,2px from Vfmsyhzh ");
                cmdText.Append(" where " + where + ")");
                cmdText.Append(" order by px,3,4,1  ");
            }
            DataTable dt = ClsRWMSSQLDb.GetDataTable(cmdText.ToString(), ClsGlobals.CntStrTMS);
            if (dt.Rows.Count == 1)
                return;
            if (this.CmbZhxz.Text == "�Թ�")
                Sockets(dt);
            DSCX.Clear();
            ClsRWMSSQLDb.FillTable(DSCX, cmdText.ToString(), ClsGlobals.CntStrTMS);
        }
        #endregion

        #region Socket��ѯ�������
        public void Sockets(DataTable dt)
        {
            //for (int i = 0; i < dt.Rows.Count - 1; i++)
            //{
            //    string[] strName = new string[] { };//�����ַ��Ľڵ�
            //    List<string> strValues = new List<string>();
            //    string[] XML_TXValues = new string[] { };//���͵ı���
            //    string yhzh = dt.Rows[i]["zh"].ToString();
            //    string ywlx = "";
            //    string zhxz = dt.Rows[i]["zhxzmc"].ToString();
            //    string zhmc = dt.Rows[i]["zhmc"].ToString();
            //    string yhmc = dt.Rows[i]["yhlxmc"].ToString();
            //    DataRow dryh = ClsRWMSSQLDb.GetDataRow(" select id from tyhlx where jc='" + yhmc + "'", ClsGlobals.CntStrFMS);
            //    int yhlxid = Convert.ToInt32(dryh[0]);
            //    if (yhlxid == 63)
            //    {
            //        strName = new string[] { "RETURN_CODE", "BALANCE" };
            //        XML_TXValues = new string[] { GetXlh("S").ToString(), PriServerKhhStr, PriServerCZYH, PriServerPwdStr, "6W0100", "CN", yhzh };
            //        ywlx = "6W0100.xml";
            //    }
            //    if (ywlx == "")
            //        continue;
            //    string recvStr = ClsSockets.sendStr(XML_TXValues, ywlx);
            //    if (recvStr == "")
            //        continue;
            //    strValues = ClsGetXML.GetListStr(strName, recvStr);
            //    if (strValues[0] != "000000" && zhxz == "�Թ�")
            //        continue;
            //    decimal RowYhye = GetNumber(strValues[1].ToString());
               
            //    if (RowYhye >= 0)
            //        ClsRWMSSQLDb.ExecuteCmd(" update tyhzh set yhye=" + RowYhye + " where zh= '" + yhzh + "'", ClsGlobals.CntStrFMS);
            //}
            
        }
        #endregion

        private decimal GetNumber(string str)
        {
            decimal result = 0;
            string Str = str;
            if (str != null && str != string.Empty)
            {
                // ������ʽ�޳��������ַ���������С����.��
                str = Regex.Replace(str, @"[^\d.\d]", "");
                //ɸѡ���ַ����Ƿ���������
                if (!(Str.IndexOf(str) >= 0))
                    return -1;
                try
                {
                    // ��������֣���ת��Ϊdecimal����
                    if (Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$"))
                        result = decimal.Parse(str);
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            return result;
        }
        private int GetXlh(string ywlx)
        {
            return ClsRWMSSQLDb.GetInt(" insert into tqqxlh values('" + ywlx + "') Select SCOPE_IDENTITY()", ClsGlobals.CntStrTMS);
        }
        #endregion

        #region ����
        private void BtnExp_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count == 0)
            {
                ClsMsgBox.Ts("û��Ҫ�����������û�", ObjG.CustomMsgBox, this);
                return;
            }
            CreatExcelZhcx();
        }
        #region Excel
        private void CreatExcelZhcx()
        {
            string PriFln = "�����û���Ϣ" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";//�ļ�����     
            string PriFlp = System.IO.Path.Combine(ConfigurationManager.AppSettings.Get("TMSDownLoad"), PriFln);//����ļ�·��
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(); //ʹ��NPOI����Excel�ļ�
            //д������
            HSSFSheet sheet1 = hssfworkbook.CreateSheet("sheet1") as HSSFSheet;
            sheet1.DefaultColumnWidth = 17;
            sheet1.SetColumnWidth(0, 25 * 60);
            sheet1.SetColumnWidth(2, 25 * 160);
            sheet1.SetColumnWidth(4, 25 * 200);
            sheet1.SetColumnWidth(5, 25 * 260);
            sheet1.SetColumnWidth(6, 25 * 140);
            sheet1.SetColumnWidth(7, 25 * 140);
            sheet1.SetColumnWidth(8, 25 * 85);
            sheet1.SetColumnWidth(9, 25 * 200);
            sheet1.SetColumnWidth(10, 25 * 80);
            //д�����
            HSSFRow titRow = sheet1.CreateRow(0) as HSSFRow;
            HSSFCell titCell = titRow.CreateCell(0) as HSSFCell;
            titRow.Height = 30 * 20;
            titCell.SetCellValue("�����˻���Ϣ");
            //���ñ�����ʽ
            HSSFCellStyle style = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
            //�����������
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//�м����
            //�����������ʽ
            HSSFFont font = hssfworkbook.CreateFont() as HSSFFont;
            font.FontName = "����";
            font.FontHeightInPoints = 16;
            font.Boldweight = 700;
            style.SetFont(font);
            titCell.CellStyle = style;
            //�ϲ�������
            sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, Dgv.ColumnCount));
            #region д��ʱ��
            //д��ʱ��
            HSSFRow timeRow = sheet1.CreateRow(1) as HSSFRow;
            HSSFCell timeCell = timeRow.CreateCell(0) as HSSFCell;
            timeCell.SetCellValue("ʱ�䣺" + DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss"));
            //�ϲ�ʱ�����
            sheet1.AddMergedRegion(new CellRangeAddress(1, 1, 0, Dgv.ColumnCount));
            #endregion
            ///���õ�Ԫ����ʽ(����������ʾ����)
            HSSFCellStyle cellStyleC = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
            cellStyleC.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
            HSSFFont font1 = hssfworkbook.CreateFont() as HSSFFont;
            font1.FontHeightInPoints = 10;
            font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
            cellStyleC.SetFont(font1);
            ///���õ�Ԫ����ʽ(����������ʾ)
            HSSFCellStyle cellStyleR = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
            cellStyleR.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
            try
            {
                //�����ĵ�����
                HSSFRow row0 = (HSSFRow)sheet1.CreateRow(2);
                HSSFCellStyle styleRow = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont LieFont = (HSSFFont)hssfworkbook.CreateFont();
                LieFont.FontHeightInPoints = 10;
                LieFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                styleRow.SetFont(LieFont);
                for (int i = 0; i <= Dgv.ColumnCount; i++)
                {
                    if (i == 0)
                        row0.CreateCell(0).SetCellValue("���");
                    else
                        row0.CreateCell(i).SetCellValue(Dgv.Columns[i - 1].HeaderText);
                    row0.Cells[i].CellStyle = styleRow;
                }
                int roowIndex = 3;
                //�������
                foreach (DataGridViewRow Row in Dgv.Rows)
                {
                    HSSFRow hssfrow = (HSSFRow)sheet1.CreateRow(roowIndex);
                    for (int i = 0; i < Dgv.ColumnCount + 1; i++)
                    {
                        if (i == 0)
                        {
                            if (Row.Index == Dgv.RowCount - 1)
                            {
                                hssfrow.CreateCell(i).SetCellValue("�ϼ�:");
                                hssfrow.Cells[i].CellStyle = cellStyleC;
                            }
                            else
                                hssfrow.CreateCell(i).SetCellValue(Row.Index + 1);
                        }
                        else
                        {
                            if (string.Compare(Dgv.Columns[i - 1].DataPropertyName, "jgmc", true) == 0
                                && Row.Index == Dgv.RowCount - 1)
                                continue;
                            hssfrow.CreateCell(i).SetCellValue(Row.Cells[i - 1].Value.ToString());
                            if (string.Compare(Dgv.Columns[i - 1].DataPropertyName, "ye", true) == 0)
                            {
                                if (Row.Index != Dgv.RowCount - 1)
                                    hssfrow.Cells[i].CellStyle = cellStyleR;
                                else
                                    hssfrow.Cells[i - 1].CellStyle = cellStyleC;
                            }
                            if (string.Compare(Dgv.Columns[i - 1].DataPropertyName, "yhye", true) == 0)
                            {
                                if (Row.Index != Dgv.RowCount - 1)
                                    hssfrow.Cells[i].CellStyle = cellStyleR;
                                else
                                    hssfrow.Cells[i - 1].CellStyle = cellStyleC;
                            }
                        }
                    }
                    roowIndex++;
                }
                FileStream file = new FileStream(PriFlp, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
                this.CtrlDown.download(PriFlp, true);
            }
            catch (Exception ex)
            {
                ClsMsgBox.Cw("������汨��ʧ��", ex, ObjG.CustomMsgBox, this);
            }
        }
        #endregion
        #endregion
    }
}