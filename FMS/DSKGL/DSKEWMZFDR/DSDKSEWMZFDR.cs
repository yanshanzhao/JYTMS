namespace FMS.DSKGL.DSKEWMZFDR {
    
    
    public partial class DSDKSEWMZFDR {
    }
}
namespace FMS.DSKGL.DSKEWMZFDR.DSDKSEWMZFDRTableAdapters
{
    public partial class VdskewmdrpcTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDKSEWMZFDR.VdskewmdrpcDataTable tbl, string WhereExp)
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
