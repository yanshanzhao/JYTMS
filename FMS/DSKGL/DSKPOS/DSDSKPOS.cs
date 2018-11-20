namespace FMS.DSKGL.DSKPOS {
    
    
    public partial class DSDSKPOS {
    }
}
namespace FMS.DSKGL.DSKPOS.DSDSKPOSTableAdapters
{
    public partial class VfmspospcTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDSKPOS.VfmspospcDataTable tbl, string WhereExp)
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