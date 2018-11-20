namespace FMS.SeleFrm {
    
    
    public partial class DSJG {
    }
}
namespace FMS.SeleFrm.DSJGTableAdapters
{
    public partial class vjigouTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere2(DSJG.vjigouDataTable tbl, string WhereExp)
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