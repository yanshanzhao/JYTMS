namespace FMS.CWGL.XTWSR
{
    
    
    public partial class DSXTWSR {
    }
}
namespace FMS.CWGL.XTWSR.DSXTWSRTableAdapters
{
    public partial class VfmsxtwsrTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSXTWSR.VfmsxtwsrDataTable tbl, string WhereExp)
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
namespace FMS.CWGL.XTWSR.DSXTWSRTableAdapters
{
    public partial class VfmsxtwpcTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSXTWSR.VfmsxtwpcDataTable tbl, string WhereExp)
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
namespace FMS.CWGL.XTWSR.DSXTWSRTableAdapters
{
    public partial class VfmsxtwsrcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSXTWSR.VfmsxtwsrcxDataTable tbl, string WhereExp)
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


