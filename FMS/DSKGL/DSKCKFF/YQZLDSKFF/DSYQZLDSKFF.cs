namespace FMS.DSKGL.DSKCKFF.YQZLDSKFF {
    
    
    public partial class DSYQZLDSKFF {
    }
}
namespace FMS.DSKGL.DSKCKFF.YQZLDSKFF.DSYQZLDSKFFTableAdapters
{
    public partial class VfmsYQZLDSKFFTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere1(DSYQZLDSKFF.VfmsYQZLDSKFFDataTable tbl, string WhereExp)
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