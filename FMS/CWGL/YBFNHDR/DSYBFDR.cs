namespace FMS.CWGL.YBFNHDR {
    
    
    public partial class DSYBFDR {
    }
}

namespace FMS.CWGL.YBFNHDR.DSYBFDRTableAdapters
{
    public partial class VfmsybfdrpcTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSYBFDR.VfmsybfdrpcDataTable tbl, string WhereExp)
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
