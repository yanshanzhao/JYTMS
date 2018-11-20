namespace FMS.CXTJ.DSKQCCX {
    
    
    public partial class DSDSKQCCX {
    }
}
namespace FMS.CXTJ.DSKQCCX.DSDSKQCCXTableAdapters
{
    public partial class VdskqccxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDSKQCCX.VdskqccxDataTable tbl, string WhereExp)
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
