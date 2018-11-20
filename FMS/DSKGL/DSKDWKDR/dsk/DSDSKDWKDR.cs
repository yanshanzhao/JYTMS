namespace FMS.DSKGL.DSKDWKDR.dsk {
    
    
    public partial class DSDSKDWKDR {
    }
}


namespace FMS.DSKGL.DSKDWKDR.dsk.DSDSKDWKDRTableAdapters
{
    public partial class VdskdwkdrpcTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDSKDWKDR.VdskdwkdrpcDataTable tbl, string WhereExp)
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
