namespace FMS.ZYGL.XTWSRLX {
    
    
    public partial class DSXTWSRLX {
    }
}
namespace FMS.ZYGL.XTWSRLX.DSXTWSRLXTableAdapters
{
    public partial class Tfmsxtwsr_lxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSXTWSRLX.Tfmsxtwsr_lxDataTable tbl, string WhereExp)
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


