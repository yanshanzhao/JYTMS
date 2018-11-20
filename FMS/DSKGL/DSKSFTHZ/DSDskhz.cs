namespace FMS.DSKGL.DSKSFTHZ
{


    public partial class DSDskhz
    {
    }
}

namespace FMS.DSKGL.DSKSFTHZ.DSDskhzTableAdapters
{
    public partial class VfmssftcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDskhz.VfmssftcxDataTable tbl, string WhereExp)
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
