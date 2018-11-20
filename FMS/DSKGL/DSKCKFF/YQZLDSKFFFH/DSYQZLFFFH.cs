namespace FMS.DSKGL.DSKCKFF.YQZLDSKFFFH {
    
    
    public partial class DSYQZLFFFH {
    }
}
namespace FMS.DSKGL.DSKCKFF.YQZLDSKFFFH.DSYQZLFFFHTableAdapters
{
    public partial class VfmsYQZLDSKFFTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere1(DSYQZLFFFH.VfmsYQZLDSKFFDataTable tbl, string WhereExp)
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