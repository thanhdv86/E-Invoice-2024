using System;
using DevExpress.XtraReports.UI;

namespace XMLSigner.report
{
    public partial class rptPXLSPKHL : XtraReport
    {
        public rptPXLSPKHL()
        {
            InitializeComponent();
        }

        public void title(string ky, string nam, string nguoilap, string chinhanh)
        {            
            txtSubTitle.Text = string.Format("Kỳ HĐ {0}/{1}. CHI NHÁNH: {2}", ky, nam, chinhanh.ToUpper());
            txtNguoiLap.Text = nguoilap;
            txtNgayLap.Text = string.Format("Huế, ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        }

        private void rptPXLSPKHL_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");
        }

    }
}
