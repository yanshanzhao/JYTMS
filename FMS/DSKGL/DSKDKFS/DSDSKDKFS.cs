namespace FMS.DSKGL.DSKDKFS {
    
    
    public partial class DSDSKDKFS {
    }
} 
namespace FMS.DSKGL.DSKDKFS.DSDSKDKFSTableAdapters
{
    public partial class VfmsdskdffsTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDSKDKFS.VfmsdskdffsDataTable tbl, string WhereExp)
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