namespace FMS.JCSJ.WDXXWH {
    
    
    public partial class DSWDXX {
    }
}

namespace FMS.JCSJ.WDXXWH.DSWDXXTableAdapters
{
    public partial class v_wdTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSWDXX.v_wdDataTable tbl, string WhereExp)
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
