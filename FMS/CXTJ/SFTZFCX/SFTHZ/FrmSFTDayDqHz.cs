#region Using 
using System; 
using Gizmox.WebGUI.Forms; 
using JY.Pub;
using JY.Pri;
#endregion

namespace FMS.CXTJ.SFTZFCX.SFTHZ
{
    public partial class FrmSFTDayDqHz : Form
    {
        public DateTime DtBate;
        public DateTime DtEnd;
        public FrmSFTDayDqHz()
        {
            InitializeComponent();
        }

        public void Prepare(string sj)
        {
            DtBate = Convert.ToDateTime(sj);
            DtEnd = DtBate.AddDays(1);
            this.VfmssftzhmxTableAdapter1.Connection.ConnectionString = ClsGlobals.CntStrTMS;
            this.DsSfthz1.EnforceConstraints = false;
            string SqlStr = string.Format(" SELECT  dqmc,jgid,jgmc,sj,SUM(cgbs) cgbs,SUM(cgje) AS cgje,SUM(sbbs) sbbs,SUM(sbje) sbje,SUM(je) je FROM (SELECT   dqmc,jgid,jgmc, sj,   cgbs,  cgje,  sbbs,  sbje, je FROM  Vfmssftzhmx WHERE sj>='{0}' AND sj<'{1}'   ) a  GROUP BY a.dqmc,a.jgid,a.jgmc,a.sj ", DtBate.ToString("yyyyMMdd"), DtEnd.ToString("yyyyMMdd"));
            this.VfmssftzhmxTableAdapter1.FillByWhere(this.DsSfthz1.Vfmssftzhmx, "", 1, SqlStr);
        }

        public void BtnExcel_Click(object sender, EventArgs e)
        {

            if (this.Dgv.RowCount == 0)
                return;
            ClsExcel.CreatExcel(Dgv, "善付通每日明细汇总", this.ctrlDownLoad1);
        }
    }
}