namespace FMS.CWGL.XTWSP {
    
    
    public partial class DSSP {
    }
}
namespace FMS.CWGL.XTWSP.DSSPTableAdapters
{
    public partial class VfmsxtwpcTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSSP.VfmsxtwpcDataTable tbl, string WhereExp)
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
    public partial class tfmsxtwsrmxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSSP.tfmsxtwsrmxDataTable tbl, string WhereExp)
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
    public partial class VfmsxtwcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSSP.VfmsxtwcxDataTable tbl, string WhereExp)
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
    public partial class Vfmsxtw_jgckTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSSP.Vfmsxtw_jgckDataTable tbl, string WhereExp)
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

//namespace FMS.CWGL.XTWSP.DSSPTableAdapters
//{
//    public partial class tfmsxtwsrmxTableAdapter : global::System.ComponentModel.Component
//    {
//        public int FillByWhere(DSSP.tfmsxtwsrmxDataTable tbl, string WhereExp)
//        {
//            string oldSelect = null;
//            oldSelect = this.CommandCollection[0].CommandText;
//            try
//            {
//                this.CommandCollection[0].CommandText += WhereExp;
//                return this.Fill(tbl);
//            }
//            catch (global::System.Exception ex)
//            {
//                throw (ex);
//            }
//            finally
//            {
//                this.CommandCollection[0].CommandText = oldSelect;
//            }
//        }
//    }
//}


