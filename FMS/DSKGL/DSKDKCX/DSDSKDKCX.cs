namespace FMS.DSKGL.DSKDKCX {
    
    
    public partial class DSDSKDKCX {
    }
}
namespace FMS.DSKGL.DSKDKCX.DSDSKDKCXTableAdapters
    {
    public partial class VfmsdskdkcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDSKDKCX.VfmsdskdkcxDataTable tbl, string WhereExp)
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