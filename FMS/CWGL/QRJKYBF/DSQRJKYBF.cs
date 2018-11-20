namespace FMS.CWGL.QRJKYBF {
    
    
    public partial class DSQRJKYBF {
    }
}
namespace FMS.CWGL.QRJKYBF.DSQRJKYBFTableAdapters
{
    public partial class VfmsybfqrjkTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSQRJKYBF.VfmsybfqrjkDataTable tbl, string WhereExp)
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