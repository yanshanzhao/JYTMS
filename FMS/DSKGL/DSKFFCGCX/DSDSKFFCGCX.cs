namespace FMS.DSKGL.DSKFFCGCX {
    
    
    public partial class DSDSKFFCGCX {
    }
}
namespace FMS.DSKGL.DSKFFCGCX.DSDSKFFCGCXTableAdapters
{
    public partial class VfmsdskffcgcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDSKFFCGCX.VfmsdskffcgcxDataTable tbl, string WhereExp,string CmdText=null)
        {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
            {
                if (string.IsNullOrEmpty(CmdText))
                    this.CommandCollection[0].CommandText += WhereExp;
                else
                    this.CommandCollection[0].CommandText = CmdText+WhereExp;
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