namespace FMS.ZYGL.JGGXWH {
    
    
    public partial class DSJGGXWH {
    }
}
namespace FMS.ZYGL.JGGXWH.DSJGGXWHTableAdapters
{
    public partial class VfmsjggxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSJGGXWH.VfmsjggxDataTable tbl, string WhereExp)
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