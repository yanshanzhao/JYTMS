namespace FMS.CWGL.XTWSR {
    
    
    public partial class DSXtDKxz {
    }
}
namespace FMS.CWGL.XTWSR.DSXtDKxzTableAdapters
{
    public partial class VfmsxtwpcTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSXtDKxz.VfmsxtwpcDataTable tbl, string WhereExp)
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