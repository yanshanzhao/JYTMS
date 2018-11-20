namespace FMS.CWGL.DataSets {
    
    
    public partial class DSXTWDR {
    }
}

namespace FMS.CWGL.DataSets.DSXTWDRTableAdapters
{
    public partial class VfmsxtwdrpcTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSXTWDR.VfmsxtwdrpcDataTable tbl, string WhereExp)
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
