namespace FMS.DSKGL.DSKCKFF.YQZLFFCX {
    
    
    public partial class DSYQZLCX {
    }
}
namespace FMS.DSKGL.DSKCKFF.YQZLFFCX.DSYQZLCXTableAdapters
{
    public partial class VYQZLCXTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSYQZLCX.VYQZLCXDataTable tbl, string WhereExp)
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