namespace FMS.DSKGL.ZBDSKHZ {
    
    
    public partial class DSZBDSKHZ {
    }
}
namespace FMS.DSKGL.ZBDSKHZ.DSZBDSKHZTableAdapters
{
    public partial class VfmsZBDSKHZDSKMX1TableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere1(DSZBDSKHZ.VfmsZBDSKHZDSKMX1DataTable tbl, string WhereExp)
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
namespace FMS.DSKGL.ZBDSKHZ.DSZBDSKHZTableAdapters
{
    public partial class VfmsZBDSKHZDSKMX2TableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSZBDSKHZ.VfmsZBDSKHZDSKMX2DataTable tbl, string WhereExp,string aStr)
        {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
            {
                if (aStr.Length > 0)
                    this.CommandCollection[0].CommandText = aStr;
                //this.CommandCollection[0].CommandText += WhereExp;
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