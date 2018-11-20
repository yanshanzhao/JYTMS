namespace FMS.DSKGL.DSKKHFLWH {
    
    
    public partial class DSDSKKHFLWH {
    }
}
namespace FMS.DSKGL.DSKKHFLWH.DSDSKKHFLWHTableAdapters
{
    public partial class VfmsdskkhflwhTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDSKKHFLWH.VfmsdskkhflwhDataTable tbl, string WhereExp)
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