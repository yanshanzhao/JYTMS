namespace FMS.CWGL.YSKCX {
    
    
    public partial class DSYSKCX {
    }
}
namespace FMS.CWGL.YSKCX.DSYSKCXTableAdapters
{
    public partial class VfmsyskcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere1(DSYSKCX.VfmsyskcxDataTable tbl, string WhereExp)
        {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
            {
                this.CommandCollection[0].CommandText += WhereExp;
                this.CommandCollection[0].CommandText += " union all SELECT null, null, null, null, null, null,ISNULL(sum(fhxf),0) as fhxf ,  isnull(sum(tf),0 )as tf , isnull(sum(fzf),0) as fzf,  isnull(sum(tzf),0)as tzf,  isnull(sum(hf),0) as hf,  isnull(sum(dsfzf),0) as dsfzf,  isnull(sum(bfxf),0) as bfxf,  isnull(sum(bfdf),0)  as bfdf,  isnull(sum(bffzff),0) as bfzff,  isnull(sum(bftzff),0) as bftzff,  isnull(sum(bfdsfzf),0) as bfdsfzf,  isnull(sum(jezj),0) as  jezf,  null, null, null,null FROM dbo.Vfmsyskcx  ";
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
namespace FMS.CWGL.YSKCX.DSYSKCXTableAdapters
{
    public partial class VfmsyskzwTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere1(DSYSKCX.VfmsyskzwDataTable tbl, string WhereExp)
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


