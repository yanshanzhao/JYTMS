namespace FMS.CWGL.LSDWCKCX {
    
    
    public partial class DSLSDWCKCX {
    }

}

namespace FMS.CWGL.LSDWCKCX.DSLSDWCKCXTableAdapters
{
    public partial class VfmslsdwckcxTableAdapter :global::System.ComponentModel.Component
    {
        public int FillByWhere(DSLSDWCKCX.VfmslsdwckcxDataTable tbl, string WhereExp)
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
