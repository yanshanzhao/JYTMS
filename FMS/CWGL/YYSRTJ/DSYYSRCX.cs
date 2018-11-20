namespace FMS.CWGL.YYSRTJ {
    
    
    public partial class DSYYSRCX {
    }
}
namespace FMS.CWGL.YYSRTJ.DSYYSRCXTableAdapters
{
    public partial class VfmsyysrcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSYYSRCX.VfmsyysrcxDataTable tbl, string WhereExp)
        {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
            {
                this.CommandCollection[0].CommandText += WhereExp;
                //this.CommandCollection[0].CommandText += "    union all select null ,'合计：'as jzlx,null ,null ,sum(fhxf) as fhxf, sum(tf)as tf, sum(fzf) as fzf,  sum(tzf) as tzf,  sum(hf) as hf, sum(dsfzf) as dsfzf,  sum(bfxf) as bfxf, suM(bfdf) as bfdf, sum(bffzf) as bffzf, sum(bftzf) as bftzf, sum(bfdzfzf) as bfdzfzf, sum(jezj) as jezj,  null , null , null    FROM dbo.Vfmsyysrcx  ";
                //this.CommandCollection[0].CommandText += "    union all  select null ,'合计：'as jzlx,null ,null ,ISNULL(sum(fhxf),0) as fhxf,   ISNULL( sum(tf),0)as tf, ISNULL(sum(fzf),0) as fzf, ISNULL( sum(tzf),0)  as tzf, ISNULL( sum(hf),0) as hf,  ISNULL(sum(dsfzf),0 )  as dsfzf,  ISNULL( sum(bfxf),0) as bfxf,ISNULL( suM(bfdf),0) as bfdf,  ISNULL( sum(bffzf),0) as bffzf, ISNULL( sum(bftzf),0 )  as bftzf,  ISNULL(sum(bfdzfzf),0) as bfdzfzf,ISNULL( sum(jezj),0) as jezj,    null , null , null      FROM dbo.Vfmsyysrcx";
                //this.CommandCollection[0].CommandText += WhereExp;
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
namespace FMS.CWGL.YYSRTJ.DSYYSRCXTableAdapters
{
    public partial class VfmsyysrcxmxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere2(DSYYSRCX.VfmsyysrcxmxDataTable tbl, string WhereExp)
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

