namespace FMS.DSKGL.DSKZZ {
    
    
    public partial class DSDSKZZNEW {
    }
}


namespace FMS.DSKGL.DSKZZ.DSDSKZZNEWTableAdapters
{
    public partial class Vfmsdskzz3TableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDSKZZNEW.Vfmsdskzz3DataTable tbl, string WhereExp)
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
