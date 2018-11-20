namespace FMS.DSKGL.DSKPOSFA {
    
    
    public partial class DSPOSFA {
    }
}
namespace FMS.DSKGL.DSKPOSFA.DSPOSFATableAdapters
{
    public partial class TfmspospcTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSPOSFA.TfmspospcDataTable tbl, string WhereExp)
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