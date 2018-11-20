namespace FMS.DSKGL.DSKYCDKHZ {
    
    
    public partial class DSDSKYCHZ {
    }
}
namespace FMS.DSKGL.DSKYCDKHZ.DSDSKYCHZTableAdapters
{
    public partial class VfmsdskffycmxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere1(DSDSKYCHZ.VfmsdskffycmxDataTable tbl ,string aSQl)
        {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
            {
                if (aSQl.Length > 0)
                    this.CommandCollection[0].CommandText = aSQl; 
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