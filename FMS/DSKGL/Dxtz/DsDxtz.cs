﻿namespace FMS.DSKGL.Dxtz {
    
    
    public partial class DsDxtz {
    }
}
namespace FMS.DSKGL.Dxtz.DsDxtzTableAdapters
{
    public partial class VfmsdskdxfsTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DsDxtz.VfmsdskdxfsDataTable tbl, string WhereExp)
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