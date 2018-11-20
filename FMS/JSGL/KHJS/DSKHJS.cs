namespace FMS.JSGL.KHJS {
    
    
    public partial class DSKHJS {
    }
}
namespace FMS.JSGL.KHJS.DSKHJSTableAdapters
{
    public partial class VfmsyfzjTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSKHJS.VfmsyfzjDataTable tbl, string WhereExp)
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
namespace FMS.JSGL.KHJS.DSKHJSTableAdapters
{
    public partial class VfmskhjsdllTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSKHJS.VfmskhjsdllDataTable tbl, string WhereExp)
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
namespace FMS.JSGL.KHJS.DSKHJSTableAdapters
{
    public partial class VfmskhjsmxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSKHJS.VfmskhjsmxDataTable tbl, string WhereExp)
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
