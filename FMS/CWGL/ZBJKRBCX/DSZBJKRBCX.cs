namespace FMS.CWGL.ZBJKRBCX {
    
    
    public partial class DSZBJKRBCX {
    }
}
namespace FMS.CWGL.ZBJKRBCX.DSZBJKRBCXTableAdapters
{
    public partial class VfmszbjkrbcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSZBJKRBCX.VfmszbjkrbcxDataTable tbl, string WhereExp,string CmdText=null)
        {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
            {
                if (CmdText == null)
                    this.CommandCollection[0].CommandText += WhereExp;
                else 
                {
                    this.CommandCollection[0].CommandText = CmdText + WhereExp;
                }
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
