namespace FMS.DSKGL.DSKPOSDR {
    
    
    public partial class DSDSKPLPOS {
    }
}
namespace FMS.DSKGL.DSKPOSDR.DSDSKPLPOSTableAdapters
{
    public partial class VplposdrTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDSKPLPOS.VplposdrDataTable tbl, string WhereExp)
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
