namespace FMS.CXTJ.JGYCKCX {
    
    
    public partial class DSJGYCKCX {
    }
}
namespace FMS.CXTJ.JGYCKCX.DSJGYCKCXTableAdapters
{
    public partial class VfmsjgyckcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSJGYCKCX.VfmsjgyckcxDataTable tbl, string WhereExp, string Selects = null)
        {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
            {
                if (!string.IsNullOrEmpty(Selects))
                    this.CommandCollection[0].CommandText = Selects + WhereExp;
                else
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


