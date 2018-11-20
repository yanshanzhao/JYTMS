namespace FMS.DSKGL.ZBDSKFF {
    
    
    public partial class DSZBDSKFF {
    }
}
namespace FMS.DSKGL.ZBDSKFF.DSZBDSKFFTableAdapters
{
    public partial class Vfmsdskff1TableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSZBDSKFF.Vfmsdskff1DataTable tbl, string WhereExp)
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
