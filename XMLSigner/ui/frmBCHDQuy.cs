using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using cskh.domain;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using XMLSigner.report;

namespace XMLSigner.ui
{
    public partial class frmBCHDQuy : frmBase
    {
        public frmBCHDQuy()
        {
            InitializeComponent();            
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (cbLoaiBC.SelectedIndex == 1) // Bao cao quy
            {
                if (cbQuarter.SelectedIndex == 0 || cbQuarter.SelectedIndex == -1)
                {
                    showMessage("Vui lòng chọn quý!", MessageType.Error);
                    return;
                }

                if (String.IsNullOrEmpty(tbYear.Text))
                {
                    showMessage("Vui lòng nhập năm!", MessageType.Error);
                    return;
                }
                int nam = Convert.ToInt16(tbYear.Text);
                int quy = cbQuarter.SelectedIndex;
                if (nam > DateTime.Now.Year || (nam == DateTime.Now.Year) && quy > GetQuarter(DateTime.Now))
                {
                    showMessage("Vui lòng chọn từ quý hiện tại trở về trước!", MessageType.Error);
                    return;
                }

                // Create a report. 
                var report = new rptSuDungHoaDon();

                try
                {
                    using (var ei = new EiBusinessImpl())
                    {
                        //frmBaseWaitform waitform = new frmBaseWaitform();
                        SplashScreenManager.ShowForm(this, typeof(frmBaseWaitform));
                        var dt = ei.tonghop_BC26AC(nam, quy);
                        SplashScreenManager.CloseForm(false);
                        //dt.WriteXmlSchema(@"E:/bc26ac.xml");
                        report.DataSource = dt;
                        report.p_quy.Value = string.Format("{0} Năm {1}", cbQuarter.Text, nam);
                        report.p_quy.Visible = false;

                        // Show the report's preview. 
                        //var tool = new ReportPrintTool(report);
                        //tool.ShowPreview();

                        new ReportPrintTool(report).ShowPreview();

                        this.Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi DB:" + ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra:" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (cbLoaiBC.SelectedIndex == 0) // bao cao tháng
            {
                if (cbQuarter.SelectedIndex == 0 || cbQuarter.SelectedIndex == -1)
                {
                    showMessage("Vui lòng chọn tháng!", MessageType.Error);
                    return;
                }

                if (String.IsNullOrEmpty(tbYear.Text))
                {
                    showMessage("Vui lòng nhập năm!", MessageType.Error);
                    return;
                }
                int nam = Convert.ToInt16(tbYear.Text);
                int thang = cbQuarter.SelectedIndex;
                if (nam > DateTime.Now.Year || (nam == DateTime.Now.Year) && thang > DateTime.Now.Month)
                {
                    showMessage("Vui lòng chọn từ tháng hiện tại trở về trước!", MessageType.Error);
                    return;
                }

                // Create a report. 
                var report = new rptSuDungHoaDon();

                try
                {
                    using (var ei = new EiBusinessImpl())
                    {
                        //frmBaseWaitform waitform = new frmBaseWaitform();
                        SplashScreenManager.ShowForm(this, typeof(frmBaseWaitform));
                        var dt = ei.tonghop_BC26AC_thang(nam, thang);
                        SplashScreenManager.CloseForm(false);
                      
                        //dt.WriteXmlSchema(@"E:/bc26ac.xml");
                        report.DataSource = dt;
                        report.p_quy.Value = string.Format("{0} Năm {1}", cbQuarter.Text, nam);
                        report.p_quy.Visible = false;

                        // Show the report's preview. 
                        //var tool = new ReportPrintTool(report);
                        //tool.ShowPreview();

                        new ReportPrintTool(report).ShowPreview();

                        this.Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi DB:" + ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra:" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                showMessage("Vui lòng chọn loại báo cáo",MessageType.Error);
            }

        }

        private void frmBCHDQuy_Load(object sender, EventArgs e)
        {            
            cbLoaiBC.SelectedIndex = 0;                        
            tbYear.Text = DateTime.Now.Year.ToString();
            bindThang();            
        }

        public static int GetQuarter(DateTime dt)
        {
            return (dt.Month - 1) / 3 + 1;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbLoaiBC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiBC.SelectedIndex == 0)
            {
                bindThang();
            }
            else if (cbLoaiBC.SelectedIndex == 1)
            {
                bindQuy();
            }
        }

        private void bindThang()
        {
            lbQuy.Text = "Tháng";
            this.cbQuarter.Items.Clear();
            this.cbQuarter.Items.AddRange(new object[] { "--Chọn--", "Tháng 01", "Tháng 02", "Tháng 03", "Tháng 04", "Tháng 05", "Tháng 06", "Tháng 07", "Tháng 08", "Tháng 09", "Tháng 10", "Tháng 11", "Tháng 12" });
            cbQuarter.SelectedIndex = DateTime.Now.Month;
        }

        private void bindQuy()
        {
            lbQuy.Text = "Quý";
            this.cbQuarter.Items.Clear();
            this.cbQuarter.Items.AddRange(new object[] {"--Chọn--","Quý I","Quý II","Quý III","Quý IV"});
            DateTime today = DateTime.Now;
            cbQuarter.SelectedIndex = GetQuarter(today);
        }

    }
}
