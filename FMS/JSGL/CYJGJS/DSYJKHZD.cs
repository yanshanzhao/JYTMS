namespace FMS.JSGL.CYJGJS {
    
    
    public partial class DSYJKHZD {
    }
}
namespace FMS.JSGL.CYJGJS.DSYJKHZDTableAdapters
{
    public partial class VfmsyjkhzdTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSYJKHZD.VfmsyjkhzdDataTable tbl, string WhereExp)
        {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
            {
                this.CommandCollection[0].CommandText += WhereExp;
             //   this.CommandCollection[0].CommandText += "UNION ALL SELECT '合计',NULL,NULL,NUll,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,SUM(zjs),SUM(zzl),SUM(fhyj),SUM(thyj),SUM(dsfyj),SUM(bf),SUM(dsk),sum(zyf),NULL,NULL FROM dbo.Vfmsyjkhzd";
             //   this.CommandCollection[0].CommandText += WhereExp;
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