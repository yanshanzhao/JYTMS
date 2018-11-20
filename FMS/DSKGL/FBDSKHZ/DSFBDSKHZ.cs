namespace FMS.DSKGL.FBDSKHZ {
    
    
    public partial class DSFBDSKHZ {
    }
}
namespace FMS.DSKGL.FBDSKHZ.DSFBDSKHZTableAdapters
{
    public partial class Vfmsfbdskhz2TableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSFBDSKHZ.Vfmsfbdskhz2DataTable tbl, string WhereExp)
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
