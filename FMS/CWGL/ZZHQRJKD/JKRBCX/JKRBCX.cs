namespace FMS.CWGL.ZZHQRJKD.JKRBCX {
    
    
    public partial class JKRBCX {
    }
}
namespace FMS.CWGL.ZZHQRJKD.JKRBCX.JKRBCXTableAdapters
{
    public partial class JkrbcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(JKRBCX.TfmsrbpcDataTable tbl, string WhereExp)
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