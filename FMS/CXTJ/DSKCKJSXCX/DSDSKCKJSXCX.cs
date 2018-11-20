namespace FMS.CXTJ.DSKCKJSXCX {
    
    
    public partial class DSDSKCKJSXCX {
    }
}
namespace FMS.CXTJ.DSKCKJSXCX.DSDSKCKJSXCXTableAdapters
{
    public partial class VfmsdskckjsxcxmxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDSKCKJSXCX.VfmsdskckjsxcxmxDataTable tbl, string WhereExp)
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