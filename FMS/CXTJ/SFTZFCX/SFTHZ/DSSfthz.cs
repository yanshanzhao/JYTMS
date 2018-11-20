namespace FMS.CXTJ.SFTZFCX.SFTHZ
{


    public partial class DSSfthz
    {
    }
}
namespace FMS.CXTJ.SFTZFCX.SFTHZ.DSSfthzTableAdapters
{
    public partial class VfmssftzhmxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSSfthz.VfmssftzhmxDataTable tbl, string WhereExp, int lx, string sql)
        {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
            {
                if (lx == 0)
                    this.CommandCollection[0].CommandText += WhereExp;
                else
                    this.CommandCollection[0].CommandText = sql;
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