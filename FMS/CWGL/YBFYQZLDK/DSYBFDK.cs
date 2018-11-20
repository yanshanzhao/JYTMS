namespace FMS.CWGL.YBFYQZLDK {
    
    
    public partial class DSYBFDK {
    }
}
namespace FMS.CWGL.YBFYQZLDK.DSYBFDKTableAdapters
{
    public partial class VfmsYbfdkTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSYBFDK.VfmsYbfdkDataTable tbl, string WhereExp)
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