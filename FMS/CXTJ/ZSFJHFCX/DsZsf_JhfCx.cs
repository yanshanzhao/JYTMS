namespace FMS.CXTJ.ZSFJHFCX
{


    public partial class DsZsf_JhfCx
    {
    }
}
namespace FMS.CXTJ.ZSFJHFCX.DsZsf_JhfCxTableAdapters
{
    public partial class VfmsZsf_JhfCxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DsZsf_JhfCx.VfmsZsf_JhfCxDataTable tbl, string WhereExp, string CmdText = null)
        {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
            {
                if (string.IsNullOrEmpty(CmdText))
                    this.CommandCollection[0].CommandText += WhereExp;
                else
                    this.CommandCollection[0].CommandText = CmdText + WhereExp;
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