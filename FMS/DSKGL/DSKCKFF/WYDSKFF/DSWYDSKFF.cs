namespace FMS.DSKGL.DSKCKFF.WYDSKFF {
    
    
    public partial class DSWYDSKFF {
    }
}
namespace FMS.DSKGL.DSKCKFF.WYDSKFF.DSWYDSKFFTableAdapters
{
    public partial class VfmswydskffTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSWYDSKFF.VfmswydskffDataTable tbl, string WhereExp)
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
