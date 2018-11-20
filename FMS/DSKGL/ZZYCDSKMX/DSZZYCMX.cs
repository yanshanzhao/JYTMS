namespace FMS.DSKGL.ZZYCDSKMX {
    
    
    public partial class DSZZYCMX {
    }
}
namespace FMS.DSKGL.ZZYCDSKMX.DSZZYCMXTableAdapters
{
    public partial class VfmszzycdskmxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSZZYCMX.VfmszzycdskmxDataTable tbl, string WhereExp)
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