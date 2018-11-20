namespace FMS.DSKGL.DSKDWKDR.dsk
{
    
    
    public partial class DSYBFDWKDR {
    }
}

namespace FMS.DSKGL.DSKDWKDR.dsk.DSYBFDWKDRTableAdapters
{
    public partial class VybfdwkdrpcTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSYBFDWKDR.VybfdwkdrpcDataTable tbl, string WhereExp)
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
