namespace FMS.CWGL.YDTZFCX {
    
    
    public partial class DSXTSRCX {
    }
}

namespace FMS.CWGL.YDTZFCX.DSXTSRCXTableAdapters
{
    public partial class vfmsxtsrcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSXTSRCX.vfmsxtsrcxDataTable tbl, string WhereExp)
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
