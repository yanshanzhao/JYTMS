namespace FMS.CWGL.ZZHQRJKD.JKRB
    {


    public partial class DSJKRB
        {
        }
    }



namespace FMS.CWGL.ZZHQRJKD.JKRB.DSJKRBTableAdapters
    {
    public partial class VfmsrbpcTableAdapter : global::System.ComponentModel.Component
        {
        public int FillByWhere(DSJKRB.VfmsrbpcDataTable tbl, string SQlStr)
            {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
                {
                this.CommandCollection[0].CommandText = SQlStr;
                return this.Fill(tbl);
                }
            catch (global::System.Exception ex)
                {
                throw (ex);
                }
            finally
                {
                this.CommandCollection[0].CommandText = oldSelect;
                }
            }
        }
    }
namespace FMS.CWGL.ZZHQRJKD.JKRB.DSJKRBTableAdapters
    {
    public partial class VfmsjkrbTableAdapter : global::System.ComponentModel.Component
        {
        public int FillByWhere(DSJKRB.VfmsjkrbDataTable tbl, string WhereExp)
            {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
                {
                this.CommandCollection[0].CommandText += WhereExp;
                return this.Fill(tbl);
                }
            catch (global::System.Exception ex)
                {
                throw (ex);
                }
            finally
                {
                this.CommandCollection[0].CommandText = oldSelect;
                }
            }
        }
    }
namespace FMS.CWGL.ZZHQRJKD.JKRB.DSJKRBTableAdapters
    {
    public partial class Vfmsjkrb2TableAdapter : global::System.ComponentModel.Component
        {
        public int FillByWhere(DSJKRB.Vfmsjkrb2DataTable tbl, string WhereExp, string CmdText = null)
            {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
                {
                if (string.IsNullOrEmpty(CmdText))
                    this.CommandCollection[0].CommandText += WhereExp;
                else
                    this.CommandCollection[0].CommandText = CmdText;
                return this.Fill(tbl);
                }
            catch (global::System.Exception ex)
                {
                throw (ex);
                }
            finally
                {
                this.CommandCollection[0].CommandText = oldSelect;
                }
            }
        }
    }