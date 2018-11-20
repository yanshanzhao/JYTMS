namespace FMS.CWGL.YBFJSXCX {
    
    
    public partial class DSYBF {
    }
}
namespace FMS.CWGL.YBFJSXCX.DSYBFTableAdapters
{
    public partial class VybfjsxcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSYBF.VybfjsxcxDataTable tbl, string WhereExp, int lx )
        {

            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
            {
                if (lx == 0)
                { 
                    this.CommandCollection[0].CommandText += WhereExp;
                }
                else
                {
                    this.CommandCollection[0].CommandText = WhereExp;
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
namespace FMS.CWGL.YBFJSXCX.DSYBFTableAdapters
{
    public partial class VybfcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSYBF.VybfcxDataTable tbl, string WhereExp)
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