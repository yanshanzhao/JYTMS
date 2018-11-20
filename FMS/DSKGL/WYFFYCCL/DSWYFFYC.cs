namespace FMS.DSKGL.WYFFYCCL {
    
    
    public partial class DSWYFFYC {
    }
}
namespace FMS.DSKGL.WYFFYCCL.DSWYFFYCTableAdapters
{
    public partial class Vfmswyffyccl1TableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSWYFFYC.Vfmswyffyccl1DataTable tbl, string WhereExp)
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
