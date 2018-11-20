namespace FMS.DSKGL.DSKYKGL {
    
    
    public partial class DSDSKYK {
    }
} 
namespace FMS.DSKGL.DSKYKGL.DSDSKYKTableAdapters
{
    public partial class VfmsdskykTableAdapter : global::System.ComponentModel.Component
        {
        public int FillByWhere(DSDSKYK.VfmsdskykDataTable tbl, string WhereExp)
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