namespace FMS.ZYGL.ZJDB.SGDB {
    
    
    public partial class DSSGDB {
    }
}
namespace FMS.ZYGL.ZJDB.SGDB.DSSGDBTableAdapters
{
    public partial class VzzlogTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSSGDB.VzzlogDataTable tbl, string WhereExp)
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