namespace FMS.DSKGL.DSKZZ {
    
    
    public partial class DSDSKZZ {
    }
}
namespace FMS.DSKGL.DSKZZ.DSDSKZZTableAdapters
{
    public partial class Vfmsdskzz2TableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSDSKZZ.Vfmsdskzz2DataTable tbl, string WhereExp)
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
namespace FMS.DSKGL.DSKZZ.DSDSKZZTableAdapters
{
    public partial class Vfmsdskzz1TableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere1(DSDSKZZ.Vfmsdskzz1DataTable tbl, string WhereExp)
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