﻿namespace FMS.CXTJ.JGYSKCX {
    
    
    public partial class DSJgyskCx {
    }
}
namespace FMS.CXTJ.JGYSKCX.DSJgyskCxTableAdapters
{
    public partial class VfmsjgyskcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSJgyskCx.VfmsjgyskcxDataTable tbl, string WhereExp)
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