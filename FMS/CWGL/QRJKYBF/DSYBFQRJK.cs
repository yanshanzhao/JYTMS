namespace FMS.CWGL.QRJKYBF {
    
    
    public partial class DSYBFQRJK {
    }
}
namespace FMS.CWGL.QRJKYBF.DSYBFQRJKTableAdapters
{
    public partial class VfmsybfqrjkTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSYBFQRJK.VfmsybfqrjkDataTable tbl, string WhereExp)
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