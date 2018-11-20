namespace FMS.DSKGL.DSKCX.DSKPMCX {
    
    
    public partial class DSDSKPMMX {
    }
}
namespace FMS.DSKGL.DSKCX.DSKPMCX.DSDSKPMMXTableAdapters
{
    public partial class VDskpmmxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDSKPMMX.VDskpmmxDataTable tbl, string WhereExp, string Selects = null)
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
