
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;
using JY.Pub;
using JY.Pri;
using System.Data.SqlClient;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Data;


namespace FMS.DSKGL.DSKYH
{
    class ClsCheckAYDRows
    {
        private string PriConStr;
        private string PriConstrFms;
        private string PriDrType;
        public string PubDskbz;
        public string PubCkryhzh;
        public string PubHybh;
        public int PubDskkhid;
        public string PubFwkh;
        private DateTime PriQysj;
        public DateTime PubQssj;
        private string PriYdzt;
        public string PubYffkfs;
        public string PubYffkfs1;
        public string PubZdjg;
        public int PubZdjgId;
        public string PubSljg;
        public List<string> lstErrors = new List<string>();
        public string PubCfbz = "";
        public Dictionary<string, string> DirJgMc;
        public Dictionary<string, string> DirJgId;
        private decimal PriZyf;
        private decimal PriDsk;
        public Dictionary<string, string> DirSszyf;

        #region 验证传进来的数据 (Excel)
        /// <summary>
        /// 验证传进来的aRow 的数据
        /// </summary>
        /// <param name="aRow">Excel的一行</param>
        /// <param name="aFlds">Excel的头部信息</param>
        /// <returns></returns>
        public List<string> RowToValues(HSSFRow aRow, Dictionary<int, string> aFlds, string aDRtype)
        {
            PubDskbz = "N";
            PubCkryhzh = "N";
            PriConStr = ClsGlobals.CntStrKj;
            PriConstrFms = ClsGlobals.CntStrTMS;
            PriDrType = aDRtype;
            //声明一个list集合来存储每一个单元格的信息
            List<string> lstValues = new List<string>();
            string sValue, s;
            decimal zyf = 0, hjyf = 0, d;
            //声明一个Excel单元格类型的变量
            NPOI.SS.UserModel.Cell c;
            //清除存储错误信息的list集合
            lstErrors.Clear();
            using (SqlConnection conn = new SqlConnection())//Jyjckj
            {
                conn.ConnectionString = PriConStr;
                using (SqlCommand comm = new SqlCommand())//jyjckj
                {
                    using (SqlConnection conn1 = new SqlConnection())//fms 
                    {
                        conn1.ConnectionString = PriConstrFms;
                        using (SqlCommand comm1 = new SqlCommand())//fms 
                        {
                            conn.Open();
                            comm.Connection = conn;
                            conn1.Open();
                            comm1.Connection = conn1;
                            //声明一个变量来判断保价费付款方式和运费付款方式的不同
                            string Bffkfs = null;
                            //遍历循环传进来的Dictionary集合
                            foreach (KeyValuePair<int, string> kv in aFlds)
                            {
                                //在传进来的Excel一行中寻找一个元素，这个元素的条件满足于它的下标和当前遍历Dictionary的数据的key值相等
                                c = aRow.Cells.Find(cx => cx.ColumnIndex == kv.Key);
                                //如果没有找到这个cell,则在结果集合中存入null
                                if (c == null)
                                    lstValues.Add("null");
                                else
                                {
                                    //得到找到的这个Cell的值并去除空格
                                    sValue = c.ToString().Trim();
                                    //如果去除空格后的值为空
                                    if (string.IsNullOrEmpty(sValue))
                                    {
                                        //在结果集中存入null
                                        lstValues.Add("null");
                                        //判断为空的这个Cell是否是货运编号或者总运费，如果是就将错误信息加入错误集合中
                                        if (string.Compare(kv.Value, "货运编号") == 0)
                                            lstErrors.Add("货运编号为空");
                                        else if (string.Compare(kv.Value, "总运费") == 0)
                                            lstErrors.Add("总运费为空");
                                    }
                                    else if (string.Compare(kv.Value, "货运编号") == 0)
                                    {
                                        PubHybh = sValue;
                                        lstValues.Add(ClsQ.Q1(sValue));
                                    }
                                    //业务区域字段
                                    else if (string.Compare(kv.Value, "业务区域") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstYwqy));
                                    }
                                    //运单状态
                                    else if (string.Compare(kv.Value, "运单状态") == 0)
                                    {
                                        if (string.Compare("SL", PriDrType) == 0)
                                        {
                                            PriYdzt = sValue;
                                        }
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstYdzt));
                                    }
                                    //自提标志
                                    else if (string.Compare(kv.Value, "自提标志") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstZtbz));
                                    }
                                    //代收款标志
                                    else if (string.Compare(kv.Value, "代收款标志") == 0)
                                    {
                                        if (string.Compare(sValue, "有") == 0)
                                        {
                                            PubDskbz = "Y";
                                        }
                                        else
                                        {
                                            PubDskbz = "N";
                                        }
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstDskbz));
                                    }
                                    else if (string.Compare(kv.Value, "银行类型") == 0)
                                    {
                                        comm1.CommandText = "select Id from tyhlx where jc=@yhlx";
                                        SqlParameter spa = new SqlParameter("@yhlx", sValue);
                                        comm1.Parameters.Add(spa);
                                        try
                                        {
                                            int id = Convert.ToInt32(comm1.ExecuteScalar());
                                            if (id == 0)
                                            {
                                                lstErrors.Add(kv.Value + ":" + sValue + "错误");
                                                lstValues.Add("null");
                                            }
                                            else
                                            {
                                                lstValues.Add(id.ToString());
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            lstErrors.Add(kv.Value + ex.Message);
                                        }
                                    }
                                    else if (string.Compare(kv.Value, "持卡人银行帐号") == 0)
                                    {
                                        PubDskkhid = 0;
                                        if (string.Compare(PubDskbz, "Y") == 0)
                                        {
                                            if (!string.IsNullOrEmpty(sValue))
                                            {
                                                PubCkryhzh = "Y";
                                                object id = null;
                                                comm1.CommandText = "select Id from tdskkhda where yhzh=@yhzh";
                                                SqlParameter spa = new SqlParameter("@yhzh", sValue);
                                                comm1.Parameters.Add(spa);
                                                id = comm1.ExecuteScalar();
                                                if (id == null)
                                                {
                                                    lstErrors.Add(kv.Value + ":" + sValue + "客户档案中不存在");
                                                }
                                                else
                                                {
                                                    PubDskkhid = (int)id;
                                                }
                                            }
                                        }

                                        lstValues.Add(ClsQ.Q1(sValue));
                                    }
                                    #region 付款方式
                                    //保价费付款方式
                                    else if (string.Compare(kv.Value, "保价费付款方式") == 0)
                                    {
                                        Bffkfs = sValue;
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                    }
                                    //运费付款方式
                                    else if (string.Compare(kv.Value, "运费付款方式") == 0)
                                    {
                                        //受理运单导入
                                        if (string.Compare("SL", PriDrType) == 0)
                                        {
                                            PubYffkfs = sValue;
                                            lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                        }
                                        else if (string.Compare("QS", PriDrType) == 0)
                                        {
                                            if (sValue == "提货方付" || sValue == "提货方月结")
                                                lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                            else
                                                return null;
                                        }
                                    }
                                    //直送费付款方式
                                    else if (string.Compare(kv.Value, "直送费付款方式") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                    }
                                    //接货费付款方式
                                    else if (string.Compare(kv.Value, "接货费付款方式") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                    }
                                    //上楼费付款方式
                                    else if (string.Compare(kv.Value, "上楼费付款方式") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                    }
                                    //通知费付款方式
                                    else if (string.Compare(kv.Value, "通知费付款方式") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                    }
                                    //回单费付款方式
                                    else if (string.Compare(kv.Value, "回单费付款方式") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                    }
                                    //包装费付款方式
                                    else if (string.Compare(kv.Value, "包装费付款方式") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                    }
                                    //通讯费付款方式
                                    else if (string.Compare(kv.Value, "通讯费付款方式") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                    }
                                    //验货费付款方式
                                    else if (string.Compare(kv.Value, "验货费付款方式") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                    }
                                    #endregion

                                    //受理机构转运
                                    else if (string.Compare(kv.Value, "受理机构转运") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstSlzyjg));
                                    }
                                    //证件类型
                                    else if (string.Compare(kv.Value, "证件类型") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstZjlx));
                                    }
                                    //代理签收客户证件类型
                                    else if (string.Compare(kv.Value, "代理签收客户证件类型") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstZjlx));
                                    }
                                    //代收种类
                                    else if (string.Compare(kv.Value, "代收种类") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstDszl));
                                    }
                                    //代收货款收取方式
                                    else if (string.Compare(kv.Value, "代收货款收取方式") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstDshksqfs));
                                    }
                                    //签收机构所属大区
                                    else if (string.Compare(kv.Value, "签收机构所属大区") == 0)
                                    {
                                        comm.CommandText = "select Id from tjigou where mc=@qsjgssdq";
                                        SqlParameter spa = new SqlParameter("@qsjgssdq", sValue);
                                        comm.Parameters.Add(spa);
                                        try
                                        {
                                            int id = Convert.ToInt32(comm.ExecuteScalar());
                                            if (id == 0)
                                            {
                                                lstErrors.Add(kv.Value + ":" + sValue + "错误");
                                                lstValues.Add("null");
                                            }
                                            else
                                            {
                                                lstValues.Add(id.ToString());
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            lstErrors.Add(kv.Value + ex.Message);
                                        }
                                    }
                                    //核对状态
                                    else if (string.Compare(kv.Value, "核对状态") == 0)
                                    {
                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstHdzt));
                                    }
                                    //费用类字段
                                    else if (aFyNames.Contains(kv.Value))
                                    {
                                        //验证是否是Decimal类型
                                        if (ClsRegEx.IsDecimal2(sValue) || ClsRegEx.IsInt(sValue))
                                        {
                                            lstValues.Add(sValue);
                                            d = Convert.ToDecimal(sValue);
                                            if (string.Compare(kv.Value, "总运费") == 0)
                                                zyf = d;
                                            else
                                                hjyf += d;
                                        }
                                        else
                                        {
                                            lstErrors.Add(kv.Value + "不是数值数据");
                                            lstValues.Add("null");
                                        }
                                    }
                                    #region 检测时间
                                    else if (string.Compare(kv.Value, "起运时间") == 0)
                                    {
                                        if (!ClsRegEx.IsDate(sValue))
                                        {
                                            lstErrors.Add(kv.Value + "不是日期类型");
                                            lstValues.Add("null");
                                        }
                                        else
                                        {
                                            PriQysj = Convert.ToDateTime(sValue);
                                            lstValues.Add(ClsQ.Q1(sValue));
                                        }
                                    }
                                    else if (string.Compare(kv.Value, "到达时间") == 0)
                                    {
                                        if (!ClsRegEx.IsDate(sValue))
                                        {
                                            lstErrors.Add(kv.Value + "不是日期类型");
                                            lstValues.Add("null");
                                        }
                                        else
                                        {
                                            lstValues.Add(ClsQ.Q1(sValue));
                                        }
                                    }
                                    else if (string.Compare(kv.Value, "签收时间") == 0)
                                    {
                                        if (!ClsRegEx.IsDate(sValue))
                                        {
                                            lstErrors.Add(kv.Value + "不是日期类型");
                                            lstValues.Add("null");
                                        }
                                        else
                                        {
                                            PubQssj = Convert.ToDateTime(sValue);
                                            lstValues.Add(ClsQ.Q1(sValue));
                                        }
                                    }
                                    else if (string.Compare(kv.Value, "预计达到时间") == 0)
                                    {
                                        if (!ClsRegEx.IsDate(sValue))
                                        {
                                            lstErrors.Add(kv.Value + "不是日期类型");
                                            lstValues.Add("null");
                                        }
                                        else
                                        {
                                            lstValues.Add(ClsQ.Q1(sValue));
                                        }
                                    }
                                    #endregion

                                    #region 检测整型数据
                                    else if (string.Compare(kv.Value, "回单份数") == 0)
                                    {
                                        if (!ClsRegEx.IsInt(sValue))
                                        {
                                            lstErrors.Add(kv.Value + "不是整型数据");
                                            lstValues.Add("null");
                                        }
                                        else
                                        {
                                            lstValues.Add(sValue);
                                        }
                                    }
                                    #endregion

                                    #region 检测其他实型数据 总件数总重量、总体积等
                                    else if (string.Compare(kv.Value, "总件数") == 0)
                                    {
                                        if (!ClsRegEx.IsInt(sValue))
                                        {
                                            lstErrors.Add(kv.Value + "不是整型数据");
                                            lstValues.Add("null");
                                        }
                                        else
                                        {
                                            lstValues.Add(sValue);
                                        }
                                    }
                                    else if (string.Compare(kv.Value, "总重量") == 0)
                                    {
                                        if (ClsRegEx.IsDecimal2(sValue) || ClsRegEx.IsInt(sValue))
                                        {
                                            lstValues.Add(sValue);
                                        }
                                        else
                                        {
                                            lstErrors.Add(kv.Value + "不是数值数据");
                                            lstValues.Add("null");
                                        }
                                    }
                                    else if (string.Compare(kv.Value, "总体积") == 0)
                                    {
                                        if (ClsRegEx.IsDecimal2(sValue) || ClsRegEx.IsInt(sValue))
                                        {
                                            lstValues.Add(sValue);
                                        }
                                        else
                                        {
                                            lstErrors.Add(kv.Value + "不是数值数据");
                                            lstValues.Add("null");
                                        }
                                    }
                                    #endregion

                                    #region 受理机构、终到位置应该为机构中有的，且应该转换为相应的id
                                    else if (string.Compare(kv.Value, "受理机构") == 0)
                                    {
                                        comm.CommandText = "select Id from tjigou where mc=@sljgmc";
                                        SqlParameter spa = new SqlParameter("@sljgmc", sValue);
                                        comm.Parameters.Add(spa);
                                        try
                                        {
                                            int id = Convert.ToInt32(comm.ExecuteScalar());
                                            if (id == 0)
                                            {
                                                lstErrors.Add(kv.Value + ":" + sValue + "错误");
                                                lstValues.Add("null");
                                            }
                                            else
                                            {
                                                lstValues.Add(id.ToString());
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            lstErrors.Add(kv.Value + ex.Message);
                                        }

                                    }
                                    else if (string.Compare(kv.Value, "终到机构") == 0)
                                    {
                                        comm.CommandText = "select Id from tjigou where mc=@zdjgmc";
                                        SqlParameter spa = new SqlParameter("@zdjgmc", sValue);
                                        comm.Parameters.Add(spa);
                                        try
                                        {
                                            int id = Convert.ToInt32(comm.ExecuteScalar());
                                            if (id == 0)
                                            {
                                                //lstErrors.Add(kv.Value + "终到机构错误");
                                                lstValues.Add("null");
                                            }
                                            else
                                            {
                                                lstValues.Add(id.ToString());
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            lstErrors.Add(kv.Value + ex.Message);
                                        }
                                    }
                                    #endregion
                                    else
                                    {
                                        lstValues.Add(ClsQ.Q1(sValue));
                                    }
                                }
                            }//foreach
                        }// using fms sqlcomm
                    }// using fms sqlconn
                }//using jyjckj sqlcomm
            }//using jyjckj sqlconn
            //总运费应该为其他运费项的和
            if (zyf != hjyf)
                lstErrors.Add(string.Format("总运费{0}≠其他费用项的和{1}", zyf, hjyf));
            if (string.Compare("QS", PriDrType) == 0)
            {
                return lstValues;
            }
            else if (string.Compare("SL", PriDrType) == 0)
            {
                if (string.Compare("已签收", PriYdzt) != 0)
                {
                    if (PubYffkfs == "发货方付" || PubYffkfs == "发货方月结" || PubYffkfs == "第三方月结")
                    {
                        return lstValues;
                    }
                    else
                        return null;
                }
                else if (string.Compare("已签收", PriYdzt) == 0)
                {
                    if (DateTime.Compare(PriQysj, PubQssj) == 0)
                    {
                        if (PubYffkfs == "发货方付" || PubYffkfs == "发货方月结" || PubYffkfs == "第三方月结")
                        {
                            return lstValues;
                        }
                        else
                            return null;
                    }
                    else
                        return null;
                }
            }
            return lstValues;
        }
        #endregion

        #region 验证传进来的数据  (Txt)
        ///// <summary>
        ///// 验证传进来的aRow 的数据
        ///// </summary>
        ///// <param name="aRow">Excel的一行</param>
        ///// <param name="aFlds">Excel的头部信息</param>
        ///// <returns></returns>
        //public List<string> RowToValues(List<string> list, Dictionary<int, string> aFlds, string aDRtype)
        //{
        //    PubDskbz = "N";
        //    PubCkryhzh = "N";
        //    PriConStr = ClsGlobals.CntStrKj;
        //    PriConstrFms = ClsGlobals.CntStrFMS;
        //    PriDrType = aDRtype;
        //    //声明一个list集合来存储每一个单元格的信息
        //    List<string> lstValues = new List<string>();
        //    string sValue, s;
        //    decimal zyf = 0, hjyf = 0, d;
        //    //声明一个Excel单元格类型的变量
        //    string c;
        //    //清除存储错误信息的list集合
        //    lstErrors.Clear();
        //    using (SqlConnection conn = new SqlConnection())//Jyjckj
        //    {
        //        conn.ConnectionString = PriConStr;
        //        using (SqlCommand comm = new SqlCommand())//jyjckj
        //        {
        //            using (SqlConnection conn1 = new SqlConnection())//fms 
        //            {
        //                conn1.ConnectionString = PriConstrFms;
        //                using (SqlCommand comm1 = new SqlCommand())//fms 
        //                {
        //                    conn.Open();
        //                    comm.Connection = conn;
        //                    conn1.Open();
        //                    comm1.Connection = conn1;
        //                    //声明一个变量来判断保价费付款方式和运费付款方式的不同
        //                    string Bffkfs = null;
        //                    //遍历循环传进来的Dictionary集合
        //                    foreach (KeyValuePair<int, string> kv in aFlds)
        //                    {
        //                        //在传进来的Excel一行中寻找一个元素，这个元素的条件满足于它的下标和当前遍历Dictionary的数据的key值相等
        //                        c = list[kv.Key];
        //                        //如果没有找到这个cell,则在结果集合中存入null
        //                        if (c == null)
        //                            lstValues.Add("null");
        //                        else
        //                        {
        //                            //得到找到的这个Cell的值并去除空格
        //                            sValue = c.ToString().Trim();
        //                            //如果去除空格后的值为空
        //                            if (string.IsNullOrEmpty(sValue))
        //                            {
        //                                //在结果集中存入null
        //                                lstValues.Add("null");
        //                                //判断为空的这个Cell是否是货运编号或者总运费，如果是就将错误信息加入错误集合中
        //                                if (string.Compare(kv.Value, "货运编号") == 0)
        //                                    lstErrors.Add("货运编号为空");
        //                                else if (string.Compare(kv.Value, "总运费") == 0)
        //                                    lstErrors.Add("总运费为空");
        //                            }
        //                            else if (string.Compare(kv.Value, "货运编号") == 0)
        //                            {
        //                                PubHybh = sValue;
        //                                lstValues.Add(ClsQ.Q1(sValue));
        //                            }
        //                            //业务区域字段
        //                            else if (string.Compare(kv.Value, "业务区域") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstYwqy));
        //                            }
        //                            //运单状态
        //                            else if (string.Compare(kv.Value, "运单状态") == 0)
        //                            {
        //                                //if (string.Compare("SL", PriDrType) == 0)
        //                                //{
        //                                PriYdzt = sValue;
        //                                //}
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstYdzt));
        //                            }
        //                            //自提标志
        //                            else if (string.Compare(kv.Value, "自提标志") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstZtbz));
        //                            }
        //                            //代收款标志
        //                            else if (string.Compare(kv.Value, "代收款标志") == 0)
        //                            {
        //                                if (string.Compare(sValue, "有") == 0)
        //                                {
        //                                    PubDskbz = "Y";
        //                                }
        //                                else
        //                                {
        //                                    PubDskbz = "N";
        //                                }
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstDskbz));
        //                            }
        //                            else if (string.Compare(kv.Value, "银行类型") == 0)
        //                            {
        //                                comm1.CommandText = "select Id from tyhlx where jc=@yhlx";
        //                                SqlParameter spa = new SqlParameter("@yhlx", sValue);
        //                                comm1.Parameters.Add(spa);
        //                                try
        //                                {
        //                                    int id = Convert.ToInt32(comm1.ExecuteScalar());
        //                                    if (id == 0)
        //                                    {
        //                                        lstErrors.Add(kv.Value + ":" + sValue + "错误");
        //                                        lstValues.Add("null");
        //                                    }
        //                                    else
        //                                    {
        //                                        lstValues.Add(id.ToString());
        //                                    }
        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                    lstErrors.Add(kv.Value + ex.Message);
        //                                }
        //                            }
        //                            //else if (string.Compare(kv.Value, "持卡人银行帐号") == 0)
        //                            //{
        //                            //    PubDskkhid = 0;
        //                            //    if (string.Compare(PubDskbz, "Y") == 0)
        //                            //    {
        //                            //        if (string.Compare(sValue, "N") != 0)
        //                            //        {
        //                            //            sValue = sValue.Substring(1); //sValue.LastIndexOf('N');
        //                            //            PubCkryhzh = "Y";
        //                            //            object id = null;
        //                            //            comm1.CommandText = "select Id from tdskkhda where yhzh=@yhzh";
        //                            //            SqlParameter spa = new SqlParameter("@yhzh", sValue);
        //                            //            comm1.Parameters.Add(spa);
        //                            //            id = comm1.ExecuteScalar();
        //                            //            if (id == null)
        //                            //            {
        //                            //                lstErrors.Add(kv.Value + ":" + sValue + "客户档案中不存在");
        //                            //            }
        //                            //            else
        //                            //            {
        //                            //                PubDskkhid = (int)id;
        //                            //            }
        //                            //        }
        //                            //    }

        //                            //    lstValues.Add(ClsQ.Q1(sValue));
        //                            //}
        //                            #region 付款方式
        //                            //保价费付款方式
        //                            else if (string.Compare(kv.Value, "保价费付款方式") == 0)
        //                            {
        //                                Bffkfs = sValue;
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
        //                            }
        //                            //运费付款方式
        //                            else if (string.Compare(kv.Value, "运费付款方式") == 0)
        //                            {
        //                                //受理运单导入
        //                                if (string.Compare("SL", PriDrType) == 0)
        //                                {
        //                                    PriYffkfs = sValue;
        //                                    lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
        //                                }
        //                                else if (string.Compare("QS", PriDrType) == 0)
        //                                {
        //                                    if (sValue == "提货方付" || sValue == "提货方月结")
        //                                        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
        //                                    else
        //                                        return null;
        //                                }
        //                            }
        //                            //直送费付款方式
        //                            else if (string.Compare(kv.Value, "直送费付款方式") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
        //                            }
        //                            //接货费付款方式
        //                            else if (string.Compare(kv.Value, "接货费付款方式") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
        //                            }
        //                            //上楼费付款方式
        //                            else if (string.Compare(kv.Value, "上楼费付款方式") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
        //                            }
        //                            //通知费付款方式
        //                            else if (string.Compare(kv.Value, "通知费付款方式") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
        //                            }
        //                            //回单费付款方式
        //                            else if (string.Compare(kv.Value, "回单费付款方式") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
        //                            }
        //                            //包装费付款方式
        //                            else if (string.Compare(kv.Value, "包装费付款方式") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
        //                            }
        //                            //通讯费付款方式
        //                            else if (string.Compare(kv.Value, "通讯费付款方式") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
        //                            }
        //                            //验货费付款方式
        //                            else if (string.Compare(kv.Value, "验货费付款方式") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
        //                            }
        //                            #endregion

        //                            //受理机构转运
        //                            else if (string.Compare(kv.Value, "受理机构转运") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstSlzyjg));
        //                            }
        //                            //证件类型
        //                            else if (string.Compare(kv.Value, "证件类型") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstZjlx));
        //                            }
        //                            //代理签收客户证件类型
        //                            else if (string.Compare(kv.Value, "代理签收客户证件类型") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstZjlx));
        //                            }
        //                            //代收种类
        //                            else if (string.Compare(kv.Value, "代收种类") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstDszl));
        //                            }
        //                            //代收货款收取方式
        //                            else if (string.Compare(kv.Value, "代收货款收取方式") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstDshksqfs));
        //                            }
        //                            //签收机构所属大区
        //                            else if (string.Compare(kv.Value, "签收机构所属大区") == 0)
        //                            {
        //                                comm.CommandText = "select Id from tjigou where mc=@qsjgssdq";
        //                                SqlParameter spa = new SqlParameter("@qsjgssdq", sValue);
        //                                comm.Parameters.Add(spa);
        //                                try
        //                                {
        //                                    int id = Convert.ToInt32(comm.ExecuteScalar());
        //                                    if (id == 0)
        //                                    {
        //                                        lstErrors.Add(kv.Value + ":" + sValue + "错误");
        //                                        lstValues.Add("null");
        //                                    }
        //                                    else
        //                                    {
        //                                        lstValues.Add(id.ToString());
        //                                    }
        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                    lstErrors.Add(kv.Value + ex.Message);
        //                                }
        //                            }
        //                            //核对状态
        //                            else if (string.Compare(kv.Value, "核对状态") == 0)
        //                            {
        //                                lstValues.Add(CheckCharList(kv.Value, sValue, lstHdzt));
        //                            }
        //                            //费用类字段
        //                            else if (aFyNames.Contains(kv.Value))
        //                            {
        //                                //验证是否是Decimal类型
        //                                if (ClsRegEx.IsDecimal2(sValue) || ClsRegEx.IsInt(sValue))
        //                                {
        //                                    lstValues.Add(sValue);
        //                                    d = Convert.ToDecimal(sValue);
        //                                    if (string.Compare(kv.Value, "总运费") == 0)
        //                                        zyf = d;
        //                                    else
        //                                        hjyf += d;
        //                                }
        //                                else
        //                                {
        //                                    lstErrors.Add(kv.Value + "不是数值数据");
        //                                    lstValues.Add("null");
        //                                }
        //                            }
        //                            #region 检测时间
        //                            else if (string.Compare(kv.Value, "起运时间") == 0)
        //                            {
        //                                if (!ClsRegEx.IsDate(sValue))
        //                                {
        //                                    lstErrors.Add(kv.Value + "不是日期类型");
        //                                    lstValues.Add("null");
        //                                }
        //                                else
        //                                {
        //                                    PriQysj = Convert.ToDateTime(sValue);
        //                                    lstValues.Add(ClsQ.Q1(sValue));
        //                                }
        //                            }
        //                            else if (string.Compare(kv.Value, "到达时间") == 0)
        //                            {
        //                                if (!ClsRegEx.IsDate(sValue))
        //                                {
        //                                    lstErrors.Add(kv.Value + "不是日期类型");
        //                                    lstValues.Add("null");
        //                                }
        //                                else
        //                                {
        //                                    lstValues.Add(ClsQ.Q1(sValue));
        //                                }
        //                            }
        //                            else if (string.Compare(kv.Value, "签收时间") == 0)
        //                            {
        //                                if (!ClsRegEx.IsDate(sValue))
        //                                {
        //                                    lstErrors.Add(kv.Value + "不是日期类型");
        //                                    lstValues.Add("null");
        //                                }
        //                                else
        //                                {
        //                                    PriQssj = Convert.ToDateTime(sValue);
        //                                    lstValues.Add(ClsQ.Q1(sValue));
        //                                }
        //                            }
        //                            else if (string.Compare(kv.Value, "预计达到时间") == 0)
        //                            {
        //                                if (!ClsRegEx.IsDate(sValue))
        //                                {
        //                                    lstErrors.Add(kv.Value + "不是日期类型");
        //                                    lstValues.Add("null");
        //                                }
        //                                else
        //                                {
        //                                    lstValues.Add(ClsQ.Q1(sValue));
        //                                }
        //                            }
        //                            #endregion

        //                            #region 检测整型数据
        //                            else if (string.Compare(kv.Value, "回单份数") == 0)
        //                            {
        //                                if (!ClsRegEx.IsInt(sValue))
        //                                {
        //                                    lstErrors.Add(kv.Value + "不是整型数据");
        //                                    lstValues.Add("null");
        //                                }
        //                                else
        //                                {
        //                                    lstValues.Add(sValue);
        //                                }
        //                            }
        //                            #endregion

        //                            #region 检测其他实型数据 总件数总重量、总体积等
        //                            else if (string.Compare(kv.Value, "总件数") == 0)
        //                            {
        //                                if (!ClsRegEx.IsInt(sValue))
        //                                {
        //                                    lstErrors.Add(kv.Value + "不是整型数据");
        //                                    lstValues.Add("null");
        //                                }
        //                                else
        //                                {
        //                                    lstValues.Add(sValue);
        //                                }
        //                            }
        //                            else if (string.Compare(kv.Value, "总重量") == 0)
        //                            {
        //                                if (ClsRegEx.IsDecimal2(sValue) || ClsRegEx.IsInt(sValue))
        //                                {
        //                                    lstValues.Add(sValue);
        //                                }
        //                                else
        //                                {
        //                                    lstErrors.Add(kv.Value + "不是数值数据");
        //                                    lstValues.Add("null");
        //                                }
        //                            }
        //                            else if (string.Compare(kv.Value, "总体积") == 0)
        //                            {
        //                                if (ClsRegEx.IsDecimal2(sValue) || ClsRegEx.IsInt(sValue))
        //                                {
        //                                    lstValues.Add(sValue);
        //                                }
        //                                else
        //                                {
        //                                    lstErrors.Add(kv.Value + "不是数值数据");
        //                                    lstValues.Add("null");
        //                                }
        //                            }
        //                            #endregion

        //                            #region 受理机构、终到位置应该为机构中有的，且应该转换为相应的id
        //                            else if (string.Compare(kv.Value, "受理机构") == 0)
        //                            {
        //                                comm.CommandText = "select Id from tjigou where mc=@sljgmc";
        //                                SqlParameter spa = new SqlParameter("@sljgmc", sValue);
        //                                comm.Parameters.Add(spa);
        //                                try
        //                                {
        //                                    int id = Convert.ToInt32(comm.ExecuteScalar());
        //                                    if (id == 0)
        //                                    {
        //                                        lstErrors.Add(kv.Value + ":" + sValue + "错误");
        //                                        lstValues.Add("null");
        //                                    }
        //                                    else
        //                                    {
        //                                        lstValues.Add(id.ToString());
        //                                    }
        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                    lstErrors.Add(kv.Value + ex.Message);
        //                                }

        //                            }
        //                            else if (string.Compare(kv.Value, "终到机构") == 0)
        //                            {
        //                                PriZdwz = sValue;
        //                                comm.CommandText = "select Id from tjigou where mc=@zdjgmc";
        //                                SqlParameter spa = new SqlParameter("@zdjgmc", sValue);
        //                                comm.Parameters.Add(spa);
        //                                try
        //                                {
        //                                    int id = Convert.ToInt32(comm.ExecuteScalar());

        //                                    if (id == 0)
        //                                    {
        //                                        //lstErrors.Add(kv.Value + "终到机构错误");
        //                                        lstValues.Add("null");
        //                                    }
        //                                    else
        //                                    {
        //                                        lstValues.Add(id.ToString());
        //                                    }

        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                    lstErrors.Add(kv.Value + ex.Message);
        //                                }
        //                            }
        //                            #endregion
        //                            else
        //                            {
        //                                lstValues.Add(ClsQ.Q1(sValue));
        //                            }
        //                        }
        //                    }//foreach
        //                }// using fms sqlcomm
        //            }// using fms sqlconn
        //        }//using jyjckj sqlcomm
        //    }//using jyjckj sqlconn
        //    //总运费应该为其他运费项的和
        //    if (zyf != hjyf)
        //        lstErrors.Add(string.Format("总运费{0}≠其他费用项的和{1}", zyf, hjyf));
        //    if (string.Compare("已签收", PriYdzt) == 0)
        //    {
        //        if (string.IsNullOrEmpty(PriZdwz))
        //        {
        //            lstErrors.Add("终到位置不能为空");
        //        }
        //    }
        //    if (string.Compare("QS", PriDrType) == 0)
        //    {
        //        return lstValues;
        //    }
        //    else if (string.Compare("SL", PriDrType) == 0)
        //    {
        //        if (string.Compare("已签收", PriYdzt) != 0)
        //        {
        //            if (PriYffkfs == "发货方付" || PriYffkfs == "发货方月结" || PriYffkfs == "第三方月结")
        //            {
        //                return lstValues;
        //            }
        //            else
        //                return null;
        //        }
        //        else if (string.Compare("已签收", PriYdzt) == 0)
        //        {
        //            if (DateTime.Compare(PriQysj, PriQssj) == 0)
        //            {
        //                if (PriYffkfs == "发货方付" || PriYffkfs == "发货方月结" || PriYffkfs == "第三方月结")
        //                {
        //                    return lstValues;
        //                }
        //                else
        //                    return null;
        //            }
        //            else
        //                return null;
        //        }
        //    }
        //    return lstValues;
        //}
        #endregion


        #region  解析Txt文本到数据库
        #region 验证传进来的数据  (Txt)
        public List<string> RowToValues(List<string> list, Dictionary<int, string> aFlds, string aDRtype)
        {
            PriConStr = ClsGlobals.CntStrKj;
            PriConstrFms = ClsGlobals.CntStrTMS;
            PriDrType = aDRtype;
            DirJgMc = new Dictionary<string, string>();
            DirSszyf = new Dictionary<string, string>();
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            //声明一个list集合来存储每一个单元格的信息
            List<string> lstValues = new List<string>();
            string sValue;
            decimal zyf = 0, hjyf = 0, d;
            //声明一个Excel单元格类型的变量
            string c;
            //清除存储错误信息的list集合
            lstErrors.Clear();
            using (SqlConnection conn = new SqlConnection())//Jyjckj
            {
                conn.ConnectionString = PriConStr;
                using (SqlCommand comm = new SqlCommand())//jyjckj
                {
                    using (SqlConnection conn1 = new SqlConnection())//fms 
                    {
                        conn1.ConnectionString = PriConstrFms;
                        using (SqlCommand comm1 = new SqlCommand())//fms 
                        {
                            conn.Open();
                            comm.Connection = conn;
                            conn1.Open();
                            comm1.Connection = conn1;
                            string Bffkfs = null;
                            foreach (KeyValuePair<int, string> kv in aFlds)
                            {
                                //在传进来的Excel一行中寻找一个元素，这个元素的条件满足于它的下标和当前遍历Dictionary的数据的key值相等
                                c = list[kv.Key];
                                //如果没有找到这个cell,则在结果集合中存入null
                                if (c == null)
                                {
                                    if (kv.Value.Equals("受理机构") || kv.Value.Equals("终到机构") || kv.Value.Equals("签收机构所属大区"))
                                        continue;
                                    lstValues.Add("null");
                                }

                                else
                                {
                                    //得到找到的这个Cell的值并去除空格
                                    sValue = c.ToString().Trim();
                                    //如果去除空格后的值为空
                                    if (string.IsNullOrEmpty(sValue))
                                    {
                                        //在结果集中存入null
                                        if (kv.Value.Equals("受理机构") || kv.Value.Equals("终到机构") || kv.Value.Equals("签收机构所属大区"))
                                            continue;
                                        lstValues.Add("null");
                                        //判断为空的这个Cell是否是货运编号或者总运费，如果是就将错误信息加入错误集合中
                                        if (string.Compare(kv.Value, "货运编号") == 0)
                                            lstErrors.Add("货运编号为空");
                                        //else if (string.Compare(kv.Value, "总运费") == 0)
                                        //    lstErrors.Add("总运费为空");
                                        //else if (string.Compare(kv.Value, "服务卡号") == 0 && PubDskbz == "Y")
                                        //{
                                        //    PubFwkh = "0";
                                        //    PubDskkhid = 0;
                                        //    //lstErrors.Add("代收款客户服务卡号不能为空");
                                        //}
                                    }
                                    else if (string.Compare(kv.Value, "货运编号") == 0)
                                    {
                                        PubHybh = sValue;
                                        //if (aDRtype == "SL")
                                        //{
                                        //    comm1.CommandText = "select  id from tyd where bh='" + PubHybh + "'";
                                        //    int tydid = Convert.ToInt32(comm1.ExecuteScalar());
                                        //    if (tydid != 0)
                                        //    {
                                        //        PubCfbz = "运单重复，程序自动跳过该条运单！运单编号为：" + PubHybh;
                                        //        return null;
                                        //    }
                                        //    else
                                        //        lstValues.Add(ClsQ.Q1(sValue));
                                        //}
                                        //else
                                        //{
                                        lstValues.Add(ClsQ.Q1(sValue));
                                        //}
                                    }
                                    ////业务区域字段
                                    //else if (string.Compare(kv.Value, "业务区域") == 0)
                                    //{
                                    //    lstValues.Add(CheckCharList(kv.Value, sValue, lstYwqy));
                                    //}
                                    ////运单状态
                                    //else if (string.Compare(kv.Value, "运单状态") == 0)
                                    //{
                                    //    PriYdzt = sValue;
                                    //    lstValues.Add(CheckCharList(kv.Value, sValue, lstYdzt));
                                    //}
                                    ////自提标志
                                    //else if (string.Compare(kv.Value, "自提标志") == 0)
                                    //{
                                    //    lstValues.Add(CheckCharList(kv.Value, sValue, lstZtbz));
                                    //}
                                    ////代收款标志
                                    //else if (string.Compare(kv.Value, "代收款标志") == 0)
                                    //{
                                    //    if (string.Compare(sValue, "有") == 0)
                                    //    {
                                    //        PubDskbz = "Y";
                                    //        lstValues.Add(CheckCharList(kv.Value, sValue, lstDskbz));
                                    //    }
                                    //    else if (string.Compare(sValue, "无") == 0)
                                    //    {
                                    //        PubDskbz = "N";
                                    //        lstValues.Add(CheckCharList(kv.Value, sValue, lstDskbz));
                                    //    }
                                    //    else
                                    //    {
                                    //        lstErrors.Add(kv.Value + "数据类型错误！");
                                    //        lstValues.Add("null");
                                    //    }

                                    //}
                                    else if (string.Compare(kv.Value, "代收款") == 0)
                                    {

                                        PriDsk = Convert.ToDecimal(sValue);
                                        lstValues.Add(sValue);
                                    }
                                //    else if (string.Compare(kv.Value, "银行类型") == 0)
                                //    {
                                //        comm1.CommandText = "select Id from tyhlx where jc=@yhlx";
                                //        SqlParameter spa = new SqlParameter("@yhlx", sValue);
                                //        comm1.Parameters.Add(spa);
                                //        try
                                //        {
                                //            int id = Convert.ToInt32(comm1.ExecuteScalar());
                                //            if (id == 0)
                                //            {
                                //                lstErrors.Add(kv.Value + ":" + sValue + "错误");
                                //                lstValues.Add("null");
                                //            }
                                //            else
                                //            {
                                //                lstValues.Add(id.ToString());
                                //            }
                                //        }
                                //        catch (Exception ex)
                                //        {
                                //            lstErrors.Add(kv.Value + ex.Message);
                                //        }
                                //    }
                                    else if (string.Compare(kv.Value, "服务卡号") == 0)
                                    {
                                        //PubDskkhid = 0;
                                        //if (sValue.Length == 4)
                                        //{
                                        //    sValue = "0" + sValue;
                                        //}
                                        //PubFwkh = sValue;
                                        //if (string.Compare(PubDskbz, "Y") == 0 && !sValue.Equals("0"))
                                        //{
                                        //    comm1.CommandText = "select Id from tdskkhda where zdybh=@zdybh";
                                        //    SqlParameter spa = new SqlParameter("@zdybh", sValue);
                                        //    object id = null;
                                        //    comm1.Parameters.Add(spa);
                                        //    id = comm1.ExecuteScalar();
                                        //    if (id == null)
                                        //    {
                                        //        PubFwkh = sValue;
                                        //    }
                                        //    else
                                        //    {
                                        //        PubDskkhid = (int)id;
                                        //    }

                                        //}
                                        //else if (string.Compare(PubDskbz, "Y") == 0 && sValue.Equals("0")) 
                                        //{
                                        //    lstErrors.Add("代收款客户服务卡号不能为空");
                                        //}
                                        lstValues.Add(ClsQ.Q1(sValue));
                                    }

                                //    #region 付款方式
                                //    //保价费付款方式
                                //    else if (string.Compare(kv.Value, "保价费付款方式") == 0)
                                //    {
                                //        Bffkfs = sValue;
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                //    }
                                    //运费付款方式
                                    else if (string.Compare(kv.Value, "运费付款方式") == 0)
                                    {
                                        PubYffkfs = sValue;
                                        PubYffkfs1 = CheckCharList(kv.Value, sValue, lstFkfs);
                                        lstValues.Add(PubYffkfs1);
                                    }
                                    else if (string.Compare(kv.Value, "总运费") == 0)
                                    {
                                        //PriDsk = Convert.ToDecimal(sValue);
                                        //lstValues.Add(sValue);
                                        zyf = Convert.ToDecimal(sValue);
                                        lstValues.Add(sValue);
                                    }
                                //    //直送费付款方式
                                //    else if (string.Compare(kv.Value, "直送费付款方式") == 0)
                                //    {
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                //    }
                                //    //接货费付款方式
                                //    else if (string.Compare(kv.Value, "接货费付款方式") == 0)
                                //    {
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                //    }
                                    //    上楼费付款方式
                                    //    else if (string.Compare(kv.Value, "上楼费付款方式") == 0)
                                //    {
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                //    }
                                    //    //通知费付款方式
                                    //    else if (string.Compare(kv.Value, "通知费付款方式") == 0)
                                //    {
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                //    }
                                //    //回单费付款方式
                                //    else if (string.Compare(kv.Value, "回单费付款方式") == 0)
                                //    {
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                //    }
                                //    //包装费付款方式
                                //    else if (string.Compare(kv.Value, "包装费付款方式") == 0)
                                //    {
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                //    }
                                //    //通讯费付款方式
                                //    else if (string.Compare(kv.Value, "通讯费付款方式") == 0)
                                //    {
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                //    }
                                    //    //验货费付款方式
                                    //    else if (string.Compare(kv.Value, "验货费付款方式") == 0)
                                //    {
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstFkfs));
                                //    }
                                //    #endregion

                                //    //受理机构转运
                                //    else if (string.Compare(kv.Value, "受理机构转运") == 0)
                                //    {
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstSlzyjg));
                                //    }
                                //    //货物名称
                                //    else if (string.Compare(kv.Value, "货物名称") == 0)
                                //    {
                                //        sValue = sValue.Replace("\'", "");
                                //        lstValues.Add(ClsQ.Q1(sValue));
                                //    }
                                //    //发货联系人
                                //    else if (string.Compare(kv.Value, "发货客户名称") == 0)
                                //    {
                                //        sValue = sValue.Replace("\'", "");
                                //        lstValues.Add(ClsQ.Q1(sValue));
                                //    }
                                //    //发货联系人
                                //    else if (string.Compare(kv.Value, "发货联系人") == 0)
                                //    {
                                //        sValue = sValue.Replace("\'", "");
                                //        lstValues.Add(ClsQ.Q1(sValue));
                                //    }
                                //    //发货联系电话
                                //    else if (string.Compare(kv.Value, "发货联系电话") == 0)
                                //    {
                                //        sValue = sValue.Replace("\'", "");
                                //        lstValues.Add(ClsQ.Q1(sValue));
                                //    }
                                //    //收货客户名称
                                //    else if (string.Compare(kv.Value, "收货客户名称") == 0)
                                //    {
                                //        sValue = sValue.Replace("\'", "");
                                //        lstValues.Add(ClsQ.Q1(sValue));
                                //    }
                                //    //到货联系人
                                //    else if (string.Compare(kv.Value, "到货联系人") == 0)
                                //    {
                                //        sValue = sValue.Replace("\'", "");
                                //        lstValues.Add(ClsQ.Q1(sValue));
                                //    }
                                //    //到货联系电话
                                //    else if (string.Compare(kv.Value, "到货联系电话") == 0)
                                //    {
                                //        sValue = sValue.Replace("\'", "");
                                //        lstValues.Add(ClsQ.Q1(sValue));
                                //    }
                                //    //发货备注
                                //    else if (string.Compare(kv.Value, "发货备注") == 0)
                                //    {
                                //        sValue = sValue.Replace("\'", "");
                                //        lstValues.Add(ClsQ.Q1(sValue));
                                //    }
                                //    //持卡人银行帐号
                                //    else if (string.Compare(kv.Value, "持卡人银行帐号") == 0)
                                //    {
                                //        sValue = sValue.Replace("\'", "");
                                //        lstValues.Add(ClsQ.Q1(sValue));
                                //    }
                                //    //签收人
                                //    else if (string.Compare(kv.Value, "签收人") == 0)
                                //    {
                                //        sValue = sValue.Replace("\'", "");
                                //        lstValues.Add(ClsQ.Q1(sValue));
                                //    }
                                //    //签收客户证件号码
                                //    else if (string.Compare(kv.Value, "签收客户证件号码") == 0)
                                //    {
                                //        sValue = sValue.Replace("\'", "");
                                //        lstValues.Add(ClsQ.Q1(sValue));
                                //    }
                                //    //代理签收人
                                //    else if (string.Compare(kv.Value, "代理签收人") == 0)
                                //    {
                                //        sValue = sValue.Replace("\'", "");
                                //        lstValues.Add(ClsQ.Q1(sValue));
                                //    }

                                //    //证件类型
                                //    else if (string.Compare(kv.Value, "证件类型") == 0)
                                //    {
                                //        sValue = sValue.Replace("\'", "");
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstZjlx));
                                //    }
                                //    //代理签收客户证件类型
                                //    else if (string.Compare(kv.Value, "代理签收客户证件类型") == 0)
                                //    {
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstZjlx));
                                //    }
                                //    //代收种类
                                //    else if (string.Compare(kv.Value, "代收种类") == 0)
                                //    {
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstDszl));
                                //    }
                                //    //代收货款收取方式
                                //    else if (string.Compare(kv.Value, "代收货款收取方式") == 0)
                                //    {
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstDshksqfs));
                                //    }
                                //    //签收机构所属大区
                                //    else if (string.Compare(kv.Value, "签收机构所属大区") == 0)
                                //    {
                                //        //comm.CommandText = "select Id from tjigou where mc=@qsjgssdq";
                                //        //SqlParameter spa = new SqlParameter("@qsjgssdq", sValue);
                                //        //comm.Parameters.Add(spa);
                                //        //try
                                //        //{
                                //        //    int id = Convert.ToInt32(comm.ExecuteScalar());
                                //        //    if (id == 0)
                                //        //    {
                                //        //        lstErrors.Add(kv.Value + ":" + sValue + "错误");
                                //        //        lstValues.Add("null");
                                //        //    }
                                //        //    else
                                //        //    {
                                //        //        lstValues.Add(id.ToString());
                                //        //    }
                                //        //}
                                //        //catch (Exception ex)
                                //        //{
                                //        //    lstErrors.Add(kv.Value + ex.Message);
                                //        //}
                                //        DirJgMc.Add("qsjgssdqid", ClsQ.Q1(sValue));
                                //    }
                                //    //核对状态
                                //    else if (string.Compare(kv.Value, "核对状态") == 0)
                                //    {
                                //        lstValues.Add(CheckCharList(kv.Value, sValue, lstHdzt));
                                //    }
                                //    //费用类字段
                                //    else if (aFyNames.Contains(kv.Value))
                                //    {
                                //        //验证是否是Decimal类型
                                //        if (ClsRegEx.IsDecimal2(sValue) || ClsRegEx.IsInt(sValue))
                                //        {
                                //            lstValues.Add(sValue);
                                //            d = Convert.ToDecimal(sValue);
                                //            if (string.Compare(kv.Value, "总运费") == 0)
                                //                zyf = d;
                                //            else
                                //                hjyf += d;
                                //        }
                                //        else
                                //        {
                                //            lstErrors.Add(kv.Value + "不是数值数据");
                                //            lstValues.Add("null");
                                //        }
                                //    }

                                //    #region 检测时间
                                //    else if (string.Compare(kv.Value, "起运时间") == 0)
                                //    {
                                //        if (!ClsRegEx.IsDate(sValue))
                                //        {
                                //            lstErrors.Add(kv.Value + "不是日期类型");
                                //            lstValues.Add("null");
                                //        }
                                //        else
                                //        {
                                //            lstValues.Add(ClsQ.Q1(sValue));
                                //        }
                                //    }
                                //    else if (string.Compare(kv.Value, "到达时间") == 0)
                                //    {
                                //        if (!ClsRegEx.IsDate(sValue))
                                //        {
                                //            lstErrors.Add(kv.Value + "不是日期类型");
                                //            lstValues.Add("null");
                                //        }
                                //        else
                                //        {
                                //            lstValues.Add(ClsQ.Q1(sValue));
                                //        }
                                //    }
                                //    else if (string.Compare(kv.Value, "签收时间") == 0)
                                //    {

                                //        if (!ClsRegEx.IsDate(sValue))
                                //        {
                                //            lstErrors.Add(kv.Value + "不是日期类型");
                                //            lstValues.Add("null");

                                //        }
                                //        else
                                //        {
                                //            PubQssj = Convert.ToDateTime(sValue);
                                //            lstValues.Add(ClsQ.Q1(sValue));
                                //        }
                                //    }
                                //    else if (string.Compare(kv.Value, "预计达到时间") == 0)
                                //    {
                                //        if (!ClsRegEx.IsDate(sValue))
                                //        {
                                //            lstErrors.Add(kv.Value + "不是日期类型");
                                //            lstValues.Add("null");
                                //        }
                                //        else
                                //        {
                                //            lstValues.Add(ClsQ.Q1(sValue));
                                //        }
                                //    }
                                //    else if (string.Compare(kv.Value, "代收货款发放时间") == 0)
                                //    {
                                //        if (string.Compare(sValue, "0*24小时") == 0)
                                //            lstValues.Add(ClsQ.Q1("1"));
                                //        else if (string.Compare(sValue, "3*24小时") == 0)
                                //            lstValues.Add(ClsQ.Q1("3"));
                                //        else if (string.Compare(sValue, "7*24小时") == 0)
                                //            lstValues.Add(ClsQ.Q1("7"));
                                //        else
                                //        {
                                //            lstErrors.Add(kv.Value + "数据类型错误！");
                                //            lstValues.Add("null");
                                //        }
                                //    }
                                //    #endregion

                                //    #region 检测整型数据
                                //    else if (string.Compare(kv.Value, "回单份数") == 0)
                                //    {
                                //        if (!ClsRegEx.IsInt(sValue))
                                //        {
                                //            lstErrors.Add(kv.Value + "不是整型数据");
                                //            lstValues.Add("null");
                                //        }
                                //        else
                                //        {
                                //            lstValues.Add(sValue);
                                //        }
                                //    }
                                //    #endregion

                                //    #region 检测其他实型数据 总件数总重量、总体积等
                                //    else if (string.Compare(kv.Value, "总件数") == 0)
                                //    {
                                //        if (!ClsRegEx.IsInt(sValue))
                                //        {
                                //            lstErrors.Add(kv.Value + "不是整型数据");
                                //            lstValues.Add("null");
                                //        }
                                //        else
                                //        {
                                //            lstValues.Add(sValue);
                                //        }
                                //    }
                                //    else if (string.Compare(kv.Value, "总重量") == 0)
                                //    {
                                //        if (ClsRegEx.IsDecimal2(sValue) || ClsRegEx.IsInt(sValue))
                                //        {
                                //            lstValues.Add(sValue);
                                //        }
                                //        else
                                //        {
                                //            lstErrors.Add(kv.Value + "不是数值数据");
                                //            lstValues.Add("null");
                                //        }
                                //    }
                                //    else if (string.Compare(kv.Value, "总体积") == 0)
                                //    {
                                //        if (ClsRegEx.IsDecimal2(sValue) || ClsRegEx.IsInt(sValue))
                                //        {
                                //            lstValues.Add(sValue);
                                //        }
                                //        else
                                //        {
                                //            lstErrors.Add(kv.Value + "不是数值数据");
                                //            lstValues.Add("null");
                                //        }
                                //    }
                                //    #endregion

                                //    #region 受理机构、终到位置应该为机构中有的，且应该转换为相应的id
                                //    else if (string.Compare(kv.Value, "受理机构") == 0)
                                //    {
                                //        PubSljg = sValue;
                                //        //comm.CommandText = "select Id from tjigou where mc=@sljgmc";
                                //        //SqlParameter spa = new SqlParameter("@sljgmc", sValue);
                                //        //comm.Parameters.Add(spa);
                                //        //try
                                //        //{
                                //        //    int id = Convert.ToInt32(comm.ExecuteScalar());
                                //        //    if (id == 0)
                                //        //    {
                                //        //        lstErrors.Add(kv.Value + ":" + sValue + "错误");
                                //        //        lstValues.Add("null");
                                //        //    }
                                //        //    else
                                //        //    {
                                //        //        lstValues.Add(id.ToString());
                                //        //    }
                                //        //}
                                //        //catch (Exception ex)
                                //        //{
                                //        //    lstErrors.Add(kv.Value + ex.Message);
                                //        //}
                                //        DirJgMc.Add("sljgid", ClsQ.Q1(sValue));

                                //    }
                                //    else if (string.Compare(kv.Value, "终到机构") == 0)
                                //    {
                                //        PubZdjg = sValue;
                                //        //comm.CommandText = "select Id from tjigou where mc=@zdjgmc";
                                //        //SqlParameter spa = new SqlParameter("@zdjgmc", sValue);
                                //        //comm.Parameters.Add(spa);
                                //        //try
                                //        //{
                                //        //    int id = Convert.ToInt32(comm.ExecuteScalar());

                                //        //    if (id == 0)
                                //        //    {
                                //        //        lstErrors.Add(kv.Value + ":" + sValue + "错误");
                                //        //        lstValues.Add("null");
                                //        //    }
                                //        //    else
                                //        //    {
                                //        //        PubZdjgId = id;
                                //        //        lstValues.Add(id.ToString());
                                //        //    }

                                //        //}
                                //        //catch (Exception ex)
                                //        //{
                                //        //    lstErrors.Add(kv.Value + ex.Message);
                                //        //}
                                //        DirJgMc.Add("zdjgid", ClsQ.Q1(sValue));
                                //    }
                                //    #endregion
                                //    else
                                //    {
                                //        lstValues.Add(ClsQ.Q1(sValue));
                                //    }
                                }
                            }//foreach

                            //if (DirJgMc.Count != 0)
                            //{
                            //    try
                            //    {
                            //        DirJgId = new Dictionary<string, string>();

                            //        comm.CommandText = "select id,mc from tjigou  where mc in " + ClsQ.Q0(string.Join(",", DirJgMc.Values), '(');
                            //        sd.SelectCommand = comm;
                            //        sd.Fill(dt);
                            //        if (dt.Rows.Count != DirJgMc.Count)
                            //        {
                            //            if (PubSljg == PubZdjg)
                            //            {
                            //                DataRow[] PriDrs1 = dt.Select("mc=" + DirJgMc["sljgid"]);
                            //                if (PriDrs1.Count() != 0)
                            //                {
                            //                    DirJgId.Add("sljgid", PriDrs1[0]["Id"].ToString());
                            //                    DirJgId.Add("zdjgid", PriDrs1[0]["Id"].ToString());
                            //                }
                            //                else
                            //                    lstErrors.Add("机构名称:" + string.Join(",", DirJgMc.Values) + "存在错误！");
                            //                DataRow[] PriDrs2 = dt.Select("mc=" + DirJgMc["qsjgssdqid"]);
                            //                if (PriDrs2.Count() != 0)
                            //                    DirJgId.Add("qsjgssdqid", PriDrs2[0]["Id"].ToString());
                            //                else
                            //                    lstErrors.Add("机构名称:" + string.Join(",", DirJgMc.Values) + "存在错误！");
                            //            }
                            //            else
                            //                lstErrors.Add("机构名称:" + string.Join(",", DirJgMc.Values) + "存在错误！");
                            //        }
                            //        else
                            //        {
                            //            //int i = 0;
                            //            foreach (KeyValuePair<string, string> dr in DirJgMc)
                            //            {
                            //                DataRow[] PriDrs = dt.Select("mc=" + dr.Value);
                            //                if (PriDrs.Count() != 0)
                            //                    DirJgId.Add(dr.Key, PriDrs[0]["Id"].ToString());
                            //                //i++;
                            //            }
                            //        }
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        lstErrors.Add("机构ID查询错误：" + ex.Message);
                            //    }
                            //    finally
                            //    {
                            //        sd.Dispose();
                            //        dt.Dispose();
                            //    }
                            //}
                        }// using fms sqlcomm
                    }// using fms sqlconn
                }//using jyjckj sqlcomm
            }//using jyjckj sqlconn
            //总运费应该为其他运费项的和


            //if (zyf != hjyf)
            //    lstErrors.Add(string.Format("总运费{0}≠其他费用项的和{1}", zyf, hjyf));
            //if (string.Compare("已签收", PriYdzt) == 0)
            //{
            //    if (string.IsNullOrEmpty(PubZdjg))
            //    {
            //        lstErrors.Add("终到机构不能为空");
            //    }
            //}
            //#region 受理运单导入条件  受理运单只导入发付、发货方月结还有第三方月结
            //if (string.Compare("SL", PriDrType) == 0)
            //{
            //    if (PubYffkfs == "发货方付" || PubYffkfs == "发货方月结" || PubYffkfs == "第三方月结")
            //    {
            //        return lstValues;
            //    }
            //    else
            //        return null;
            //}
            //#endregion
            //#region 签收运单
            //if (string.Compare("QS", PriDrType) == 0)
            //{

            //    if ((PubYffkfs == "提货方付" || PubYffkfs == "收货方月结") && PubSljg.StartsWith("零担"))
            //    {
            //        DirSszyf.Add("sszyf", (zyf + PriDsk).ToString());
            //    }
            //}
            //#endregion

            return lstValues;
        }
        #endregion
        #endregion



        #region  CheckCharList()

        /// <summary>
        /// 判断传进来的一列的值和传进来的Dictionary的值是否相等
        /// </summary>
        /// <param name="aHeader">列名</param>
        /// <param name="aContent">列的值</param>
        /// <param name="aLst">相关的Dictionary</param>
        /// <returns></returns>
        public string CheckCharList(string aHeader, string aContent, Dictionary<char, string> aLst)
        {
            //在传进来的Dictionary集合中需找一个元素，这个元素的条件是和传进来的aContent相等，如果找到就存入kv中
            KeyValuePair<char, string> kv = aLst.FirstOrDefault(kvx => string.Compare(kvx.Value, aContent) == 0);
            if (kv.Key == (char)0)
            {
                lstErrors.Add(aHeader + ":" + aContent);
                return "null";
            }
            else
            {
                return ClsQ.Q1(kv.Key.ToString());
            }
        }
        #endregion

        #region lstXXX Dictionary集合
        //声明一个数组来存储费用类型
        private static string[] aFyNames = new string[] { "总运费", "运费", "直送费", "接货费", "保价费", "上楼费", "通知费", "回单费", "包装费", "通讯费", "验货费" };
        //声明一个Dictionary集合来存储业务区域
        private static Dictionary<char, string> lstYwqy = new Dictionary<char, string>();
        //声明一个Dictionary集合来存储运单状态
        private static Dictionary<char, string> lstYdzt = new Dictionary<char, string>();
        //声明一个Dictionary集合来存储自提标志
        private static Dictionary<char, string> lstZtbz = new Dictionary<char, string>();
        //声明一个Dictionary集合来存储代收款标志
        private static Dictionary<char, string> lstDskbz = new Dictionary<char, string>();
        //声明一个Dictionary集合来存储付款方式
        public static Dictionary<char, string> lstFkfs = new Dictionary<char, string>();
        //声明一个Dictionary集合来存储受理转运机构
        private static Dictionary<char, string> lstSlzyjg = new Dictionary<char, string>();
        //声明一个Dictionary集合来存储证件类型
        private static Dictionary<char, string> lstZjlx = new Dictionary<char, string>();
        //声明一个Dictionary集合来存储代收种类
        private static Dictionary<char, string> lstDszl = new Dictionary<char, string>();
        //声明一个Dictionary集合来存储代收货款收取方式
        private static Dictionary<char, string> lstDshksqfs = new Dictionary<char, string>();
        //声明一个Dictionary集合来存储核对状态
        private static Dictionary<char, string> lstHdzt = new Dictionary<char, string>();



        #endregion

        #region  单件模式实例化
        private static Object LockHelper = new Object();
        private static bool IsInitialized = false;
        /// <summary>
        /// 以单件模式初始化，防止多用户冲突
        /// </summary>
        public static void Init()
        {
            if (!IsInitialized)
            {
                lock (LockHelper)
                {
                    if (!IsInitialized)
                    {
                        //业务区域
                        lstYwqy.Add('L', "零担");
                        lstYwqy.Add('K', "快运");
                        lstYwqy.Add('Z', "整车");
                        //运单状态
                        lstYdzt.Add('D', "待发");
                        lstYdzt.Add('S', "受理");
                        lstYdzt.Add('Z', "在途");
                        lstYdzt.Add('Y', "已到达");
                        lstYdzt.Add('Q', "已签收");
                        lstYdzt.Add('A', "全部");
                        //自提标志
                        lstZtbz.Add('Y', "自提");
                        lstZtbz.Add('Z', "直送");
                        lstZtbz.Add('Q', "其它");
                        //代收款标志
                        lstDskbz.Add('Y', "有");
                        lstDskbz.Add('W', "无");
                        //付款方式
                        lstFkfs.Add('T', "提货方付");
                        lstFkfs.Add('F', "发货方付");
                        lstFkfs.Add('Z', "发货方月结");
                        lstFkfs.Add('D', "收货方月结");
                        lstFkfs.Add('S', "第三方月结");
                        //受理机构转运
                        lstSlzyjg.Add('Y', "是");
                        lstSlzyjg.Add('N', "否");
                        //证件类型
                        lstZjlx.Add('S', "身份证");
                        lstZjlx.Add('X', "学生证");
                        lstZjlx.Add('D', "驾驶证");
                        lstZjlx.Add('J', "军人证");
                        lstZjlx.Add('H', "护照");
                        lstZjlx.Add('Q', "其他");
                        lstZjlx.Add(' ', "null");
                        //代收种类
                        lstDszl.Add('H', "代收货款");
                        lstDszl.Add('Y', "代收运费");
                        //代收货款收取方式
                        lstDshksqfs.Add('C', "现金");
                        lstDshksqfs.Add('M', "pos机");
                        //核对状态
                        lstHdzt.Add('W', "未核对");
                        lstHdzt.Add('Y', "已核对");
                        IsInitialized = true;
                    }
                } //lock
            }
        }
    }
        #endregion
}
