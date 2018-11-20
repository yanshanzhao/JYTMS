namespace FMS.DSKGL.DSKKHTZ {
    
    
    public partial class DSDSKKHZT {
    }
}
namespace FMS.DSKGL.DSKKHTZ.DSDSKKHZTTableAdapters
{
    public partial class Vfmsdskkhzt1TableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere1(DSDSKKHZT.Vfmsdskkhzt1DataTable tbl, string WhereExp)
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
