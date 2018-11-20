namespace FMS.DSKGL.DSKJJ {
    
    
    public partial class DSDSKJJ {
    }
}
namespace FMS.DSKGL.DSKJJ.DSDSKJJTableAdapters
{
    public partial class VfmsDskjjTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDSKJJ.VfmsDskjjDataTable tbl, string WhereExp)
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
