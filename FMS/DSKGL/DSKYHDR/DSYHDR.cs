namespace FMS.DSKGL.DSKYHDR {
    
    
    public partial class DSYHDR {
    }
}
namespace FMS.DSKGL.DSKYHDR.DSYHDRTableAdapters
{
    public partial class VfmsdsknhpcTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSYHDR.VfmsdsknhpcDataTable tbl, string WhereExp)
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


namespace FMS.DSKGL.DSKYHDR.DSYHDRTableAdapters
{
    public partial class VfmsdskjhpcTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSYHDR.VfmsdskjhpcDataTable tbl, string WhereExp)
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

