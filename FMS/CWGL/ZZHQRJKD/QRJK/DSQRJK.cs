namespace FMS.CWGL.ZZHQRJKD.QRJK {
    
    
    public partial class DSQRJK {
    }
}
namespace FMS.CWGL.ZZHQRJKD.QRJK.DSQRJKTableAdapters
{
    public partial class tjigouTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSQRJK.tjigouDataTable tbl, string WhereExp)
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
namespace FMS.CWGL.ZZHQRJKD.QRJK.DSQRJKTableAdapters
    {
    public partial class VfmsyfmxTableAdapter : global::System.ComponentModel.Component
        {
        public int FillByWhere(DSQRJK.VfmsyfmxDataTable tbl, string WhereExp)
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
namespace FMS.CWGL.ZZHQRJKD.QRJK.DSQRJKTableAdapters
    {
    public partial class VfmsyfpcTableAdapter : global::System.ComponentModel.Component
        {
        public int FillByWhere(DSQRJK.VfmsyfpcDataTable tbl, string WhereExp)
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
namespace FMS.CWGL.ZZHQRJKD.QRJK.DSQRJKTableAdapters
    {
    public partial class VfmsqrjkTableAdapter : global::System.ComponentModel.Component
        {
        public int FillByWhere(DSQRJK.VfmsqrjkDataTable tbl, string WhereExp)
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
