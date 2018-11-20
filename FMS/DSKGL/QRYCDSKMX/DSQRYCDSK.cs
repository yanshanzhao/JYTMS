namespace FMS.DSKGL.QRYCDSKMX {
    
    
    public partial class DSQRYCDSK {
    }
}
namespace FMS.DSKGL.QRYCDSKMX.DSQRYCDSKTableAdapters
{
    public partial class VfmsqrycdskmxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere1(DSQRYCDSK.VfmsqrycdskmxDataTable tbl, string WhereExp)
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