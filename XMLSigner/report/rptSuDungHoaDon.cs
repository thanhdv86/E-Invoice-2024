using System;

namespace XMLSigner.report
{
    public partial class rptSuDungHoaDon : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSuDungHoaDon()
        {
            InitializeComponent();
            txtNgayLap.Text = string.Format("Ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        }
    }
}
