namespace FMS.DSKGL.DSKCX.DSKHZB
{


    public partial class DSKHZB
    {
    }
}
namespace FMS.DSKGL.DSKCX.DSKHZB.DSKHZBTableAdapters
{
    public partial class DsklsdhzbTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere1(DSKHZB.VfmsdsklsdhzbDataTable tbl, string WhereExp)
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
    public partial class DskjrhzbTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere1(DSKHZB.VfmsdskjrhzbDataTable tbl, string WhereExp)
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
    public partial class VfmsdskhzbxxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere1(DSKHZB.VfmsdskhzbxxDataTable tbl, string WhereExp,string aSQL)
        {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
            {
                if (aSQL.Length > 0)
                    CommandCollection[0].CommandText = aSQL;
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
        public int FillBy(DSKHZB.VfmsdskhzbxxDataTable tbl, string WhereExp, string aSQL)
            {
            string oldSelect = null;
            oldSelect = this.CommandCollection[1].CommandText;
            try
                {
                if (aSQL.Length > 0)
                    CommandCollection[1].CommandText = aSQL;
                this.CommandCollection[1].CommandText += WhereExp;
                return this.FillBy(tbl);
                }
            catch (global::System.Exception ex)
                {
                throw (ex);
                }
            finally
                {
                this.CommandCollection[1].CommandText = oldSelect;
                }
            }
        public int FillByWqs(DSKHZB.VfmsdskhzbxxDataTable tbl, string WhereExp, string aSQL)
            {
            string oldSelect = null;
            oldSelect = this.CommandCollection[3].CommandText;
            try
                {
                if (aSQL.Length > 0)
                    CommandCollection[3].CommandText = aSQL;
                this.CommandCollection[3].CommandText += WhereExp;
                return this.FillByWqs(tbl);
                }
            catch (global::System.Exception ex)
                {
                throw (ex);
                }
            finally
                {
                this.CommandCollection[3].CommandText = oldSelect;
                }
            }
        public int FillByDh(DSKHZB.VfmsdskhzbxxDataTable tbl, string WhereExp, string aSQL)
            {
            string oldSelect = null;
            oldSelect = this.CommandCollection[2].CommandText;
            try
                {
                if (aSQL.Length > 0)
                    CommandCollection[2].CommandText = aSQL;
                this.CommandCollection[2].CommandText += WhereExp;
                return this.FillByDh(tbl);
                }
            catch (global::System.Exception ex)
                {
                throw (ex);
                }
            finally
                {
                this.CommandCollection[2].CommandText = oldSelect;
                }
            }
    }
}