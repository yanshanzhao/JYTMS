 
namespace FMS.CWGL.GLSDWNWYYSR {
    
    
    public partial class DSGLSDWNWYYSR {
    }
}


namespace FMS.CWGL.GLSDWNWYYSR.DSGLSDWNWYYSRTableAdapters
{
    public partial class tglsdwnwyysrcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSGLSDWNWYYSR.tglsdwnwyysrcxDataTable tbl, string WhereExp)
        {
            string oldSelect = null;
            oldSelect = this.CommandCollection[0].CommandText;
            try
            {
                string SQL = "SELECT id,sybmc,cplxmc,ywlxmc,dqmc,jgmc,case when jyxz='Z' then '直营机构' when jyxz='J' then '加盟机构' when jyxz='H' then '合作机构' else '其他' end jyxz ,wndhyf,wndhbf,wndhzsf,wndhjhf,wndhtxf,wndhqtfy,wndhpsf,wndhhdf,wndhbzf,wndhfwf,wndhxj,wwdhyf,wwdhbf,wwdhzsf,wwdhjhf,wwdhqtfy,wwdhtxf,wwdhpsf,wwdhhdf,wwdhbzf,wwdhfwf,wwdhxj,dhxj,wnfhyf,wnfhbf,wnfhzsf,wnfhjhf,wnfhtxf,wnfhqtfy,wnfhpsf,wnfhhdf,wnfhbzf,wnfhfwf,wnfhxj,wwfhyf,wwfhbf,wwfhzsf,wwfhjhf,wwfhqtfy,wwfhtxf,wwfhpsf,wwfhhdf,wwfhbzf,wwfhfwf,wwfhxj,fhxj,jezj,inssj,sljgid,dhjfzlxj,wnfhjfzlxj,wwfhjfzlxj,fhjfzlxj,cz,jzlg,ckjg,ywxz,dqid  FROM tglsdwnwyysrcx ";
                this.CommandCollection[0].CommandText =SQL+ WhereExp;
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
namespace FMS.CWGL.GLSDWNWYYSR.DSGLSDWNWYYSRTableAdapters
{
    public partial class VglsdwnwyysrcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere(DSGLSDWNWYYSR.VglsdwnwyysrcxDataTable tbl, string WhereExp)
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
namespace FMS.CWGL.GLSDWNWYYSR.DSGLSDWNWYYSRTableAdapters
{
    public partial class VglsdwnwyysrcxTableAdapter : global::System.ComponentModel.Component
    {
        public int FillByWhere3(DSGLSDWNWYYSR.VglsdwnwyysrcxDataTable tbl, string WhereExp)
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
