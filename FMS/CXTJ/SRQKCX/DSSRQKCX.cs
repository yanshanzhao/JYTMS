﻿namespace FMS.CXTJ.SRQKCX {
    
    
    public partial class DSSRQKCX {
    }
}
namespace FMS.CXTJ.SRQKCX.DSSRQKCXTableAdapters
{
    public partial class VfmssrcxydxxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSSRQKCX.VfmssrcxydxxDataTable tbl, string WhereExp)
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
