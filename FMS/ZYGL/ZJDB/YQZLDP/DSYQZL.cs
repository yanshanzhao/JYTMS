namespace FMS.ZYGL.ZJDB.YQZLDP {
    
    
    public partial class DSYQZL {
    }
}


namespace FMS.ZYGL.ZJDB.YQZLDP.DSYQZLTableAdapters
{
    public partial class VfmsyqzlfhTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSYQZL.VfmsyqzlfhDataTable tbl, string WhereExp)
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
namespace FMS.ZYGL.ZJDB.YQZLDP.DSYQZLTableAdapters
{
    public partial class VfmsyqzlfhmxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSYQZL.VfmsyqzlfhmxDataTable tbl, string WhereExp)
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