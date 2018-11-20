namespace FMS.DSKGL.THBJ {
    
    
    public partial class DSYDTH {
    }
}
namespace FMS.DSKGL.THBJ.DSYDTHTableAdapters
{
    public partial class VfmsthdskTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSYDTH.VfmsthdskDataTable tbl, string WhereExp)
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