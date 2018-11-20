namespace FMS.CWGL.ZZHQRJKD.TZFGBFJKRB
{
    
    
    public partial class DSTFMSXTSR {
    }
}

namespace FMS.CWGL.ZZHQRJKD.TZFGBFJKRB.DSTFMSXTSRTableAdapters
{
    public partial class vfmsxtsrTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSTFMSXTSR.vfmsxtsrDataTable tbl, string WhereExp)
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