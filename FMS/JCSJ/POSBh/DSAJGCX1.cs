namespace FMS.JCSJ.POSBh {
    
    
    public partial class DSAJGCX1 {
    }
}
namespace FMS.JCSJ.POSBh.DSAJGCX1TableAdapters
{
    public partial class VPosBhTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSAJGCX1.VPosBhDataTable tbl, string WhereExp)
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