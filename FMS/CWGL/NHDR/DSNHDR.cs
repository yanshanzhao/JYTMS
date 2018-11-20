namespace FMS.CWGL.NHDR {
    
    
    public partial class DSNHDR {
    }
}
namespace FMS.CWGL.NHDR.DSNHDRTableAdapters
{
    public partial class VfmsybfdrpcTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSNHDR.VfmsybfdrpcDataTable tbl, string WhereExp)
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