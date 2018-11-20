namespace FMS.SeleFrm {
    
    
    public partial class DSKH {
    }
}
namespace FMS.SeleFrm.DSKHTableAdapters
{
    public partial class TkhTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSKH.TkhDataTable tbl, string WhereExp)
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