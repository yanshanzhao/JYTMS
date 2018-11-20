namespace FMS.DSKGL.DSKDK {
    
    
    public partial class DSDSKDK {
    }
}
namespace FMS.DSKGL.DSKDK.DSDSKDKTableAdapters
{
    public partial class VfmsdskdkTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere1(DSDSKDK.VfmsdskdkDataTable tbl, string WhereExp)
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
