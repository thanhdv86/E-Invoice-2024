using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Xml;
using cskh.domain;
using XMLSigner.data;
using cskh.domain.HInvoiceAuto.SInvoice;
using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;
using cskh.domain.HInvoiceAuto.Class;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraSplashScreen;
using cskh.domain;
using System.IO;

namespace XMLSigner.ui
{
    public partial class frmCancelResign : frmBase
    {
        static int curentPage = 1;
        protected int numRows = 30;
        private string strAccessToken = "";
        private string urlAPI = "";
        private string codeTax = "";
        private string proxy = "";
        private int port = 0;
        private int ssl = 0;
        private string sql = "";
        private EI _hd;
        private DataRow _drold;
        private DataRow _drnew;
        private readonly string[] _thaotacItems = { "--Chọn--", "Hóa đơn thay thế" };
        private readonly string[] _lydoItems = { "--Chọn--", "Giảm chảy tiền nước","Nhập sai", "Ghi sai", "Khác" };
        public frmCancelResign()
        {
            InitializeComponent();
            urlAPI = ConfigurationManager.AppSettings["APILink"].ToString();
            codeTax = ConfigurationManager.AppSettings["CodeTax"].ToString();
            proxy = ConfigurationManager.AppSettings["ProxyIP"].ToString();
            port = int.Parse(ConfigurationManager.AppSettings["ProxyPort"].ToString());
            //BindKihieu();
            for (int i = 0; i < _thaotacItems.Length; i++)
            {
                cbThaoTac.Items.Add(_thaotacItems[i]);
            }
            for (int i = 0; i < _lydoItems.Length; i++)
            {
                cbLyDo.Items.Add(_lydoItems[i]);
            }
            ResetAsFirstLoad();
            //test
            //saveToPDF();
        }
        public void saveToPDF()
        {
            DataTable _dt = new DataTable();
            _dt.Columns.AddRange(new DataColumn[]{
                                            new DataColumn("IDKH"),
                                            new DataColumn("SOHOADON"),
                                            new DataColumn("KLTIEUTHU"),
                                            new DataColumn("TIENNUOC"),
                                            new DataColumn("TIENTHUE"),
                                            new DataColumn("TIENPHITNMT"),
                                            new DataColumn("TONGTIEN"),
                                            new DataColumn("HETNO"),
                                            new DataColumn("NGAYKY")
                                        });
            _dt.Rows.Add("081689", "Test", "546", "7879999", "787", "34", "899999999", "Hết nợ", "11/08/2022 09:00:00 AM");
            _dt.Rows.Add("081689", "Test", "546", "7879999", "787", "34", "899999999", "Hết nợ", "11/08/2022 09:00:00 AM");
            _dt.Rows.Add("081689", "Test", "546", "7879999", "787", "34", "899999999", "Hết nợ", "11/08/2022 09:00:00 AM");
            _dt.Rows.Add("081689", "Test", "546", "7879999", "787", "34", "899999999", "Hết nợ", "11/08/2022 09:00:00 AM");
            _dt.Rows.Add("081689", "Test", "546", "7879999", "787", "34", "899999999", "Hết nợ", "11/08/2022 09:00:00 AM");

            string path = string.Format("{0}XMLSigner\\TempData", Application.StartupPath.Split(new[] { "XMLSigner" }, StringSplitOptions.None)[0]);
            PDFControlers PDFCtrl = new PDFControlers();
            byte[] fileContent = PDFCtrl.createPDF(_dt);
            // Kiểm tra file đã tồn tại hay chưa? Nếu chưa thì tạo mới

            if (!File.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            File.WriteAllBytes(string.Format("{0}\\{1}", path, "test.pdf"), fileContent);
            System.Diagnostics.Process.Start(string.Format("{0}\\{1}", path, "test.pdf"));
        }
        private void ResetAsFirstLoad()
        {
            cbThaoTac.SelectedIndex = 0;
            cbLyDo.SelectedIndex = 0;
            tbLyDoKhac.Enabled = false;
            //soHoaDonUC1.Enabled = false;
            //gbThucHien.Enabled = false;
            tbLyDoKhac.Enabled = true;
            //soHoaDonUC1.Enabled = true;
            gbThucHien.Enabled = true;
            btnDo.Enabled = true; //new
        }

        private bool isValidData
        {
            get{
                if (dtpTuNgay.Value == null)
                {
                    showMessage("Vui lòng chọn môc thời gian để lọc dữ liệu!", MessageType.Error);
                    dtpTuNgay.Focus();
                    return false;
                }
                if (dtpDenNgay.Value == null)
                {
                    showMessage("Vui lòng chọn môc thời gian để lọc dữ liệu!", MessageType.Error);
                    dtpDenNgay.Focus();
                    return false;
                }
                return true;
            }
            
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (!isValidData) return;
            var btn = sender as Button;
            switch (btn.Name)
            {
                case "btnXem":
                    {
                        curentPage = 1;
                        break;
                    }
                case "btnNext":
                    {
                        curentPage++;
                        break;
                    }
                case "btnPrev":
                    {
                        if(curentPage > 1)
                        {
                            curentPage--;
                        }
                        if (curentPage <= 1)
                        {
                            btn.Enabled = false;
                        }
                        break;
                    }
            }
            lbCurentPage.Text = curentPage.ToString();
            SplashScreenManager.ShowForm(this, typeof(frmBaseWaitform));
            BindGrid();
            SplashScreenManager.CloseForm(false);
        }

        private void BindKihieu()
        {
            //using (var ebi = new EiBusinessImpl())
            //{
            //    var dt = ebi.GetAllMauSery();
            //    cbKihieu.DataSource = dt;
            //    cbKihieu.ValueMember = "MAKIHIEU";
            //    cbKihieu.DisplayMember = "TENKIHIEU";
            //    var dr = dt.NewRow();
            //    dr[Constants.KH_TENKIHIEU] = "--Chọn--";
            //    dr[Constants.KH_MAKIHIEU] = null;
            //    dt.Rows.InsertAt(dr, 0);
            //    cbKihieu.SelectedIndex = 0;
            //}
        }

        private void BindGrid()
        {            
            var GetInvoiceRequest = new requestGetInvoice()
            {
                startDate = dtpTuNgay.Value.ToString("yyyy-MM-dd"),
                endDate = dtpDenNgay.Value.ToString("yyyy-MM-dd"),
                templateCode = "1/002",
                invoiceType = null,
                rowPerPage = numRows,
                pageNum = curentPage,
                invoiceNo = string.IsNullOrEmpty(txtInvoiceNo.Text) ? null : txtInvoiceNo.Text
            };
            string s = JsonConvert.SerializeObject(GetInvoiceRequest);
            string urlRequest = string.Format("{0}/{1}/{2}", urlAPI, "services/einvoiceapplication/api/InvoiceAPI/InvoiceUtilsWS/getInvoices", codeTax);
            if (getAccessToken())
            {
                string results = cskh.domain.HInvoiceAuto.SInvoice.CreateRequest.webRequestV2(urlRequest, s, strAccessToken, "POST", "application/json", "", 0, 0);
                try
                {
                    InvoiceResults listInvoice = JsonConvert.DeserializeObject<InvoiceResults>(results);
                    if(!listInvoice.code.HasValue)
                    {
                        // Khởi tạo datatable
                        DataTable tbInvoices = new DataTable("tbInvoices");
                        tbInvoices.Columns.AddRange(new DataColumn[] {
                        new DataColumn("CustomerName", typeof(System.String)),
                        new DataColumn("InvoiceNo", typeof(System.String)), 
                        new DataColumn("invoiceType", typeof(System.String)),
                        new DataColumn("invoiceSeries", typeof(System.String)),
                        new DataColumn("invoiceNumber", typeof(System.String)),
                        new DataColumn("DatePublished", typeof(System.DateTime)),
                        new DataColumn("transactionUuid", typeof(System.String))
                        });
                        for(var i = 0; i < listInvoice.invoices.Length; i++)
                        {
                            DataRow dr = tbInvoices.NewRow();
                            dr["CustomerName"] = listInvoice.invoices[i].buyerName;
                            dr["InvoiceNo"] = listInvoice.invoices[i].invoiceNo;
                            dr["invoiceType"] = listInvoice.invoices[i].invoiceType;
                            dr["invoiceSeries"] = listInvoice.invoices[i].invoiceSeri;
                            dr["invoiceNumber"] = listInvoice.invoices[i].invoiceNumber;
                            dr["DatePublished"] = listInvoice.invoices[i].issueDateStr;
                            dr["transactionUuid"] = listInvoice.invoices[i].transactionUuid;
                            tbInvoices.Rows.Add(dr);
                        }
                        grCtrlResults.DataSource = tbInvoices;
                        if(tbInvoices.Rows.Count < numRows)
                        {
                            btnNext.Enabled = false;
                        }
                        else
                        {
                            btnNext.Enabled = true;
                        }
                    }
                    if(curentPage > 1)
                    {
                        btnPrev.Enabled = true;
                    }
                }
                catch(Exception ex)
                {
                    btnNext.Enabled = btnPrev.Enabled = false;
                    MessageBox.Show("Có lỗi xảy ra: " + results);
                }
            }
            //DataTable dtold;
            //using (var ebi = new EiBusinessImpl())
            //{
            //    var dt = ebi.GetHoaDonBySoHoaDon(tbSoHoaDon.Text, cbKihieu.SelectedValue.ToString());
            //    dtold = dt;
            //    //gridControl1.DataSource = dtold;
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        _drold = dt.Rows[0];
            //    }
            //    else
            //    {
            //        MessageBox.Show(string.Format("Không tìm thấy thông tin hóa đơn đã ký từ ngày {0} đến ngày {1}.", dtpTuNgay.Value, dtpDenNgay.Value), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        grCtrlResults.DataSource = null;
            //        ResetAsFirstLoad();
            //        return;
            //    }

            //}
            //if (_drold != null)
            //{
            //    var idkh = _drold[Constants.IDKH].ToString();
            //    var thang = Convert.ToInt16(_drold[Constants.KY].ToString());
            //    var nam = Convert.ToInt16(_drold[Constants.NAM].ToString());
            //    using (var cri = new CrBusinessImpl())
            //    {
            //        var dt = cri.GetHdbyIdkh(idkh, thang, nam);
            //        var dtnew = dt;
            //        _drnew = dt.Rows[0]; var col = new DataColumn("HOADON");
            //        var col1 = new DataColumn("HOADON");
            //        dtnew.Columns.Add(col);
            //        dtold.Columns.Add(col1);
            //        _drnew["HOADON"] = "Thông tin mới";
            //        _drold["HOADON"] = "Thông tin cũ";

            //        dtold.Merge(dtnew, true);
            //        vGridControl1.DataSource = dtold;

            //        _hd = new EI();
            //        _hd.PopulateData(_drnew);
            //        gbThucHien.Enabled = true;
            //    }
            //}
        }
        // huy hoa don
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DeleteInvoice();
        }

        private void DeleteInvoice()
        {

            //if (_drold == null || _drnew == null)
            //{
            //    showMessage("Vui lòng chọn hóa đơn muốn hủy!", MessageType.Error);
            //    return;
            //}
            //if (GetLydo() == "")
            //{
            //    showMessage("Vui lòng chọn/nhập lý do!", MessageType.Error);
            //    return;
            //}
            //var res = MessageBox.Show(string.Format("Bạn có muốn hủy hóa đơn {0}-{1}?", cbKihieu.Text, tbSoHoaDon.Text), "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (res == DialogResult.OK || res == DialogResult.Yes)
            //{
            //    using (var ebi = new EiBusinessImpl())
            //    {
            //        ebi.HuyHd(_hd.IDKH, _hd.KY, _hd.NAM, frmSignIn.user.Username, GetLydo(), DateTime.Now);
            //        MessageBox.Show(string.Format("Đã hủy hóa đơn số {0}-{1}", cbKihieu.Text, tbSoHoaDon.Text), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        BindGridAfter();
            //    }
            //    ResetAsFirstLoad();
            //}

        }

        // huy, ky lai
        private void btnResign_Click(object sender, EventArgs e)
        {
            //Resign();
        }

        private void Resign()
        {
            if (IsvalidForResign())
            {
                using (var ebi = new EiBusinessImpl())
                {
                    // them so hoa don, mau sery
                    //_hd.MAUHOADON = soHoaDonUC1.MauSery;
                    //_hd.SOHOADON = soHoaDonUC1.Sohoadon;
                    //_hd.KIHIEUHOADON = soHoaDonUC1.Kihieu;

                    // ky, tao hoadon_xml
                    X509Certificate2 certificate = null;
                    if (Constants.KindOfToken == "USBToken")
                    {
                        // open store to select cer	
                        //Cách 1: sử dụng USB Token
                        certificate = SignUtil.ChooseCerfromStore(StoreName.My);
                    }
                    else if (Constants.KindOfToken == "SoftTokenP12")
                    {
                        //Cách 2: sử dụng Soft Token P12
                        var strPath = string.Format("{0}{1}", Application.StartupPath,
                            "\\Resources\\tokensign\\testPass1.p12");
                        certificate = new X509Certificate2(strPath, "1",
                            X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
                    }
                    else
                    {
                        MessageBox.Show(this, "Chưa cấu hình phương thức ký hoặc phương thức ký không hợp lệ!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    // Kiểm tra ngày hiệu lực
                    if (Systems.DateOfServer < certificate.NotBefore || Systems.DateOfServer > certificate.NotAfter)
                    {
                        MessageBox.Show(this, string.Format("Chứng thư có hiệu lực\n Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}.", certificate.NotBefore, certificate.NotAfter), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var privateKey = certificate.PrivateKey as RSACryptoServiceProvider;
                    var xmlDoc = _hd.CreateHoaDonXml(certificate);
                    xmlDoc = SignUtil.SignXmlFile(xmlDoc, privateKey);
                    _hd.HOADON_XML = SignUtil.XmlToByteArray(xmlDoc);

                    // them thong tin tracking
                    _hd.NGAYKY = DateTime.Now;
                    _hd.NGUOIKY = frmSignIn.user.Username;
                    _hd.LANKY = Convert.ToInt16(_drold[Constants.LANKY].ToString()) + 1;
                    var result = ebi.huy_laplaiHD(_hd, GetLydo());
                    if (result == 0)
                    {
                        showMessage(string.Format("Đã hủy hóa đơn {0}-{1} và tạo mới hóa đơn {2}-{3}", _drold[Constants.KIHIEUHOADON], _drold[Constants.SOHOADON], _hd.KIHIEUHOADON, _hd.SOHOADON), MessageType.Information);
                        BindGridAfter();
                    }
                    else
                    {
                       // MessageBox.Show(string.Format("Có lỗi xảy ra khi hủy hóa đơn {0}-{1}", cbKihieu.Text, tbSoHoaDon.Text), "Lỗi [" + result + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ResetAsFirstLoad();
            }
        }
        private void frmCancelResign_Load(object sender, EventArgs e)
        {
            InitDate();
            //BindKihieu();
            toolTip1.SetToolTip(this.btnSearch, "Kích vào đây để tìm hóa đơn");
        }
        private void InitDate()
        {
            // tu ngay
            dtpTuNgay.Value = DateTime.Now.Date;
            // den ngay
            dtpDenNgay.Value = DateTime.Now.Date;
        }

        // sau khi ký chỉ hiên thị thông tin mới (trong bảng đã ký)
        private void BindGridAfter()
        {
            _drold = null;
            _drnew = null;
            using (var ebi = new EiBusinessImpl())
            {
                var dt = ebi.GetHoaDonByPk(_hd.IDKH, _hd.KY, _hd.NAM);
                //vGridControl1.DataSource = dt;
            }
        }

        // validate before resign
        private bool IsvalidForResign()
        {
            if (GetLydo() == "")
            {
                showMessage("Vui lòng chọn/nhập lý do!", MessageType.Error);
                return false;
            }
            if (_drold == null || _drnew == null)
            {
                showMessage("Vui lòng chọn hóa đơn muốn hủy - điều chỉnh, thay thế!", MessageType.Error);
                return false;
            }
            //if (string.IsNullOrEmpty(soHoaDonUC1.Kihieu) || string.IsNullOrEmpty(soHoaDonUC1.Sohoadon))
            //{
            //    showMessage("Vui lòng chọn mẫu sery và số hóa đơn mới để ký lại!", MessageType.Error);
            //    return false;
            //}
            return true;
        }


        // method này sẽ được gọi từ form tìm kiếm để load số hóa đơn sau khi tìm kiếm
        public void LoadHoaDon(string kihieu, string sohoadon)
        {
            //cbKihieu.SelectedValue = kihieu;
            //tbSoHoaDon.Text = sohoadon;
        }

        // neu chọn lý do khác, thì enable textbox lý do khác
        private void cbLyDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLyDo.Text == _lydoItems[_lydoItems.Length - 1])
            {
                tbLyDoKhac.Enabled = true;
            }
            else
            {
                tbLyDoKhac.Text = "";
                tbLyDoKhac.Enabled = false;
            }
        }

        // nếu chọn thao tác "hủy bỏ và lập lại" thì enable control chọn số hóa đơn
        private void cbThaoTac_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbThaoTac.Text == _thaotacItems[_thaotacItems.Length - 1])// huy bo-lap lai
            //{
            //    soHoaDonUC1.Enabled = true;
            //    soHoaDonUC1.Sohoadon = "";
            //}
            //else
            //{
            //    soHoaDonUC1.Enabled = false;
            //    soHoaDonUC1.Sohoadon = "";
            //}
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            if (cbThaoTac.Text == _thaotacItems[1])// huy bo - Thay thế
            {

                SplashScreenManager.ShowForm(this, typeof(frmBaseWaitform));
                //GetSelectedHoaDonAssign();
                var hds = GetSelectedHoaDonAssign();
                if (hds != null)
                    MessageBox.Show(this, string.Format("Ký hoàn tất {0}", " hóa đơn thay thế"), "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Resign();
                SplashScreenManager.CloseForm(false);
            }
            //else if (cbThaoTac.Text == _thaotacItems[2])// huy bo - Thay thế
            //{
            //    SplashScreenManager.ShowForm(this, typeof(frmBaseWaitform));
            //    //GetSelectedHoaDonAssign();
            //    var hds = GetSelectedHoaDonAssign();
            //    if (hds != null)
            //        MessageBox.Show(this, string.Format("Ký hoàn tất {0}", " hóa đơn thay thế"), "Thông báo",
            //            MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //Resign();
            //    SplashScreenManager.CloseForm(false);
            //}
            else
            {
                showMessage("Vui lòng chọn một thao tác!", MessageType.Error);
            }
        }

        private string GetLydo()
        {
            string lydo = "";
            if (cbLyDo.Text == _lydoItems[_lydoItems.Length - 1])
            {
                lydo = tbLyDoKhac.Text;
            }
            else if (cbLyDo.Text == _lydoItems[0]) lydo = "";
            else lydo = cbLyDo.Text;
            return lydo;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var frmSearch = new frmSearchInvoice(this);
            frmSearch.ShowDialog();
        }
        private generalInvoiceInfo getGeneralInvoiceInfo(string transactionUuid)
        {
            generalInvoiceInfo generalInvoiceInfo = new generalInvoiceInfo();
            generalInvoiceInfo.invoiceType = "1";
            generalInvoiceInfo.templateCode = "1/002";
            //generalInvoiceInfo.invoiceSeries = "K" + DateTime.Today.ToString("yy") + "TCN";
            generalInvoiceInfo.invoiceSeries = "K22TCN";
            generalInvoiceInfo.currencyCode = "VND";
            generalInvoiceInfo.adjustmentType = "3"; // Hóa đơn thay thế
            //if (cbThaoTac.SelectedIndex == 1)
            //{
            //    generalInvoiceInfo.adjustmentType = "5"; // điều chỉnh thông tin
            //}
            //else if (cbThaoTac.SelectedIndex == 2)
            //{
            //    generalInvoiceInfo.adjustmentType = "3"; // Hóa đơn thay thế
            //}
            foreach (var r in gridView1.GetSelectedRows())
            {
                //if (gridView1.IsDataRow(r))
                if (gridView1.RowCount > 0 && gridView1.IsDataRow(r))
                {
                    //var strMauGoc = gridView1.GetRowCellValue(r, gridView1.Columns["invoiceType"]).ToString();
                    //var strKyHieu = gridView1.GetRowCellValue(r, gridView1.Columns["invoiceSeries"]).ToString();
                    //var strSoHoaDon = gridView1.GetRowCellValue(r, gridView1.Columns["invoiceNumber"]).ToString();
                    var strSoHoaDonGoc = gridView1.GetRowCellValue(r, gridView1.Columns["InvoiceNo"]).ToString();
                    DateTime NgayKyGoc = DateTime.Parse(gridView1.GetRowCellValue(r, gridView1.Columns["DatePublished"]).ToString());
                    long NgayKyMillisecond = (long)(NgayKyGoc - new DateTime(1970, 1, 1)).TotalMilliseconds;
                    
                    generalInvoiceInfo.originalInvoiceId = strSoHoaDonGoc;
                    generalInvoiceInfo.originalInvoiceIssueDate = NgayKyMillisecond.ToString();
                    generalInvoiceInfo.adjustedNote = GetLydo(); //cbLyDo.SelectedItem.ToString();
                    generalInvoiceInfo.additionalReferenceDesc = "Văn bản thỏa thuận";
                    generalInvoiceInfo.additionalReferenceDate = NgayKyMillisecond.ToString();
                    
                    //if (cbThaoTac.SelectedIndex == 1)
                    //{
                    //    generalInvoiceInfo.adjustmentInvoiceType = "2"; //Hóa đơn điều chỉnh thông tin 
                    //}
                    //generalInvoiceInfo.adjustedNote = cbLyDo.SelectedItem.ToString();
                    //generalInvoiceInfo.originalInvoiceType = "1";
                    //generalInvoiceInfo.originalTemplateCode = "1/002";
                    //generalInvoiceInfo.additionalReferenceDesc = "Hóa đơn thay thế cho hóa đơn điện tử mẫu " + strMau + " ký hiệu " + strKyHieu +
                    //                                             " số " + strSoHoaDon + " lập ngày " + NgayKy.ToString("dd/MM/yyyy"); //NgayKy.ToString("dd/MM/yyyy hh:mm:ss tt")
                }
            }
            generalInvoiceInfo.paymentStatus = "true";
            generalInvoiceInfo.cusGetInvoiceRight = "true";
            //generalInvoiceInfo.cusGetInvoiceRight = "true";
            generalInvoiceInfo.transactionUuid = transactionUuid + DateTime.Now.Date.Day.ToString("00");
            return generalInvoiceInfo;
        }
        private InvoiceOutputs CreateRequest(string request)
        {
            try
            {
                if (string.IsNullOrEmpty(strAccessToken))
                {
                    MessageBox.Show("Chưa lấy giá tị Token");
                    return null;
                }
                string apiLink = urlAPI + @"/services/einvoiceapplication/api/InvoiceAPI/InvoiceWS/createInvoice/" + codeTax; 
                string contentType = "application/json";

                string result = cskh.domain.HInvoiceAuto.SInvoice.CreateRequest.webRequestV2(apiLink, request, strAccessToken, "POST",
                    contentType, null, port, ssl);
                 //contentType, proxy, port, ssl);
                InvoiceOutputs auth = JsonConvert.DeserializeObject<InvoiceOutputs>(result);
                return auth;
                //MessageBox.Show("OK " + result);
            }catch (Exception ex)
            {
                MessageBox.Show("NOK " + ex.Message);
            }
            return null;
        }
        private bool getAccessToken()
        {
            try
            {
                strAccessToken = "";
                string user = frmSignIn.user.Username;
                string pass = frmSignIn.user.Password;
                //string user = ConfigurationManager.AppSettings["User"].ToString(); //user test
                //string pass = ConfigurationManager.AppSettings["Pass"].ToString(); // password test
                string apiLink = ConfigurationManager.AppSettings["APILink"].ToString() + @"/auth/login";
                string contentType = "application/json";
                string method = "POST";
                var proxy = "";
                var port = 0;
                string request = @"{""username"":""" + user + @""",""password"":""" + pass + @"""}";
                var ssl = 1;
                //string result = HInvoice2022.SInvoice.CreateRequest.webRequestgetToken(apiLink, request, method, contentType, proxy, port, ssl);
                string result = cskh.domain.HInvoiceAuto.SInvoice.CreateRequest.webRequestgetToken(apiLink, request, method, contentType, proxy, port, ssl);
                //MessageBox.Show("Lấy giá trị token", result);
                //HInvoice2022.SInvoice.responseGetAccessToken auth = JsonConvert.DeserializeObject<HInvoice2022.SInvoice.responseGetAccessToken>(result);
                responseGetAccessToken auth = JsonConvert.DeserializeObject<responseGetAccessToken>(result);
                strAccessToken = @"access_token=" + auth.access_token;
                //MessageBox.Show("Đăng nhập thành công");
                //MessageBox.Show("Lấy giá trị token", "Đăng nhập thành công");
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                MessageBox.Show("Lấy giá trị token", "Có lỗi xảy ra: " + ex.Message);
                //return "";
                return false;
            }
        }
        private List<EI> GetSelectedHoaDon1()
        {
            var hds = new List<EI>();
            for (var i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                if (gridView1.GetSelectedRows()[i] >= 0)
                {
                    var dr = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
                    var hd = new EI();
                    //DataRow -> EI
                    hd.PopulateDataInvoice(dr);
                    //hd.NGUOIKY = frmSignIn.user.Username;
                    // Khi máy Client bị lỗi Pin CMOS thì Ngày ký sẽ bị sai!!!
                    // Vì vậy phải lấy ngày mặc định của Server!
                    //hd.NGAYKY = DateTime.Now;
                    hds.Add(hd);
                }
            }
            return hds;
        }
        private List<EI> GetSelectedHoaDon()
        {
            var hds = new List<EI>();
            foreach (var r in gridView1.GetSelectedRows())
            {
                //if (gridView1.IsDataRow(r))
                if (gridView1.RowCount > 0 && gridView1.IsDataRow(r))
                {
                    //----------
                    var strtransactionUuid = gridView1.GetRowCellValue(r, gridView1.Columns["transactionUuid"]).ToString();
                    var thang = 6;
                    var nam = 2022;
                    using (var cri = new CrBusinessImpl())
                    {
                        var dt = cri.GetHdbytransactionUuid(strtransactionUuid, thang, nam);
                        //var dtnew = dt;
                        _drnew = dt.Rows[0];
                        var hd = new EI();
                        //DataRow -> EI
                        hd.PopulateDataInvoice(_drnew);
                        //hd.NGUOIKY = frmSignIn.user.Username;
                        // Khi máy Client bị lỗi Pin CMOS thì Ngày ký sẽ bị sai!!!
                        // Vì vậy phải lấy ngày mặc định của Server!
                        //hd.NGAYKY = DateTime.Now;
                        hds.Add(hd);
                    }
                }
            }
            return hds;
        }

        

        private bool GetSelectedHoaDonAssign()
        {

            var hds = GetSelectedHoaDon();
            commonInvoiceInputs commonInvoiceInputs = new commonInvoiceInputs();

            //List<InvoiceOutputs> invoiceOutputses = new List<InvoiceOutputs>();
            var i = 0;
            while (i < hds.Count)
            {
                commonInvoiceInputs.iCommonInvoiceInputs = new List<commonInvoiceInput>();
                
                while (i < hds.Count && commonInvoiceInputs.iCommonInvoiceInputs.Count < 30)
                {
                    var ie = hds[i];

                    commonInvoiceInput commonInvoiceInput = new commonInvoiceInput();
                    commonInvoiceInput.generalInvoiceInfo = getGeneralInvoiceInfo(Convert.ToString(ie.transactionUuid));
                    commonInvoiceInput.buyerInfo = new buyerInfo();
                    commonInvoiceInput.payments = new payments();
                    commonInvoiceInput.taxBreakdowns = new taxBreakdowns();
                    commonInvoiceInput.summarizeInfo = new summarizeInfo();


                    commonInvoiceInput.buyerInfo.buyerCode = ie.IDKH;
                    if (ie.MST != null && ie.MST != "")
                    {
                        commonInvoiceInput.buyerInfo.buyerName = "";

                        commonInvoiceInput.buyerInfo.buyerLegalName = ie.TENKH;
                        commonInvoiceInput.buyerInfo.buyerTaxCode = ie.MST;
                    }
                    else
                    {
                        commonInvoiceInput.buyerInfo.buyerName = ie.TENKH;
                        commonInvoiceInput.buyerInfo.buyerLegalName = "";
                        commonInvoiceInput.buyerInfo.buyerTaxCode = "";
                    }
                    commonInvoiceInput.buyerInfo.buyerAddressLine = ie.DIACHI;
                    commonInvoiceInput.payments.paymentMethodName = "TM/CK";
                    commonInvoiceInput.buyerInfo.buyerPhoneNumber = ie.SDT.ToString();
                    commonInvoiceInput.buyerInfo.buyerEmail = ie.EMAIL.ToString();
                    commonInvoiceInput.buyerInfo.buyerBankAccount = ie.STK;
                    commonInvoiceInput.buyerInfo.buyerBankName = "";

                    List<itemInfo> itemInfos = new List<itemInfo>();
                    int sodong = 1;
                    if (ie.TIENMUC1 > 0)
                    {
                        itemInfo itemInfo1 = new itemInfo();
                        itemInfo1.lineNumber = sodong.ToString();
                        itemInfo1.itemCode = ie.IDKH + "-" + sodong.ToString();
                        itemInfo1.selection = "1";
                        itemInfo1.itemName = "Sinh hoạt";
                        itemInfo1.unitName = "m3";
                        itemInfo1.unitPrice = Convert.ToDouble(ie.GIAMUC1);
                        itemInfo1.quantity = Convert.ToDouble(ie.M3MUC1);
                        itemInfo1.itemTotalAmountWithoutTax = Convert.ToDouble(ie.TIENMUC1);
                        itemInfo1.taxPercentage = "5";
                        itemInfo1.taxAmount = Convert.ToDouble(ie.TIENMUC1);
                        itemInfos.Add(itemInfo1);
                        sodong++;
                    }
                    if (ie.TIENMUC2 > 0)
                    {
                        itemInfo itemInfo2 = new itemInfo();
                        itemInfo2.lineNumber = sodong.ToString();
                        itemInfo2.itemCode = ie.IDKH + "-" + sodong.ToString();
                        itemInfo2.selection = "1";
                        itemInfo2.itemName = "Sinh hoạt";
                        itemInfo2.unitName = "m3";
                        itemInfo2.unitPrice = Convert.ToDouble(ie.GIAMUC2);
                        itemInfo2.quantity = Convert.ToDouble(ie.M3MUC2);
                        itemInfo2.itemTotalAmountWithoutTax = Convert.ToDouble(ie.TIENMUC2);
                        itemInfo2.taxPercentage = "5";
                        itemInfo2.taxAmount = Convert.ToDouble(ie.TIENMUC2);
                        itemInfos.Add(itemInfo2);
                        sodong++;
                    }
                    if (ie.TIENMUC3 > 0)
                    {
                        itemInfo itemInfo3 = new itemInfo();
                        itemInfo3.lineNumber = sodong.ToString();
                        itemInfo3.itemCode = ie.IDKH + "-" + sodong.ToString();
                        itemInfo3.selection = "1";
                        itemInfo3.itemName = "Sinh hoạt";
                        itemInfo3.unitName = "m3";
                        itemInfo3.unitPrice = Convert.ToDouble(ie.GIAMUC3);
                        itemInfo3.quantity = Convert.ToDouble(ie.M3MUC3);
                        itemInfo3.itemTotalAmountWithoutTax = Convert.ToDouble(ie.TIENMUC3);
                        itemInfo3.taxPercentage = "5";
                        itemInfo3.taxAmount = Convert.ToDouble(ie.TIENMUC3);
                        itemInfos.Add(itemInfo3);
                        sodong++;
                    }
                    if (ie.TIENMUC4 > 0)
                    {
                        itemInfo itemInfo4 = new itemInfo();
                        itemInfo4.lineNumber = sodong.ToString();
                        itemInfo4.itemCode = ie.IDKH + "-" + sodong.ToString();
                        itemInfo4.selection = "1";
                        itemInfo4.itemName = "Sinh hoạt";
                        itemInfo4.unitName = "m3";
                        itemInfo4.unitPrice = Convert.ToDouble(ie.GIAMUC4);
                        itemInfo4.quantity = Convert.ToDouble(ie.M3MUC4);
                        itemInfo4.itemTotalAmountWithoutTax = Convert.ToDouble(ie.TIENMUC4);
                        itemInfo4.taxPercentage = "5";
                        itemInfo4.taxAmount = Convert.ToDouble(ie.TIENMUC4);
                        itemInfos.Add(itemInfo4);
                        sodong++;
                    }
                    if (ie.TIENMUC5 > 0)
                    {
                        itemInfo itemInfo5 = new itemInfo();
                        itemInfo5.lineNumber = sodong.ToString();
                        itemInfo5.itemCode = ie.IDKH + "-" + sodong.ToString();
                        itemInfo5.selection = "1";
                        itemInfo5.itemName = "Hành chính sự nghiệp";
                        itemInfo5.unitName = "m3";
                        itemInfo5.unitPrice = Convert.ToDouble(ie.GIAMUC5);
                        itemInfo5.quantity = Convert.ToDouble(ie.M3MUC5);
                        itemInfo5.itemTotalAmountWithoutTax = Convert.ToDouble(ie.TIENMUC5);
                        itemInfo5.taxPercentage = "5";
                        itemInfo5.taxAmount = Convert.ToDouble(ie.TIENMUC5);
                        itemInfos.Add(itemInfo5);
                        sodong++;
                    }
                    if (ie.TIENMUC6 > 0)
                    {
                        itemInfo itemInfo6 = new itemInfo();
                        itemInfo6.lineNumber = sodong.ToString();
                        itemInfo6.itemCode = ie.IDKH + "-" + sodong.ToString();
                        itemInfo6.selection = "1";
                        itemInfo6.itemName = "Sản xuất";
                        itemInfo6.unitName = "m3";
                        itemInfo6.unitPrice = Convert.ToDouble(ie.GIAMUC6);
                        itemInfo6.quantity = Convert.ToDouble(ie.M3MUC6);
                        itemInfo6.itemTotalAmountWithoutTax = Convert.ToDouble(ie.TIENMUC6);
                        itemInfo6.taxPercentage = "5";
                        itemInfo6.taxAmount = Convert.ToDouble(ie.TIENMUC6);
                        itemInfos.Add(itemInfo6);
                        sodong++;
                    }
                    if (ie.TIENMUC7 > 0)
                    {
                        itemInfo itemInfo7 = new itemInfo();
                        itemInfo7.lineNumber = sodong.ToString();
                        itemInfo7.itemCode = ie.IDKH + "-" + sodong.ToString();
                        itemInfo7.selection = "1";
                        itemInfo7.itemName = "Kinh doanh";
                        itemInfo7.unitName = "m3";
                        itemInfo7.unitPrice = Convert.ToDouble(ie.GIAMUC7);
                        itemInfo7.quantity = Convert.ToDouble(ie.M3MUC7);
                        itemInfo7.itemTotalAmountWithoutTax = Convert.ToDouble(ie.TIENMUC7);
                        itemInfo7.taxPercentage = "5";
                        itemInfo7.taxAmount = Convert.ToDouble(ie.TIENMUC7);
                        itemInfos.Add(itemInfo7);
                        sodong++;
                    }
                    if (ie.TIENMUC8 > 0)
                    {
                        itemInfo itemInfo8 = new itemInfo();
                        itemInfo8.lineNumber = sodong.ToString();
                        itemInfo8.itemCode = ie.IDKH + "-" + sodong.ToString();
                        itemInfo8.selection = "1";
                        itemInfo8.itemName = "Nhân đạo";
                        itemInfo8.unitName = "m3";
                        itemInfo8.unitPrice = Convert.ToDouble(ie.GIAMUC8);
                        itemInfo8.quantity = Convert.ToDouble(ie.M3MUC8);
                        itemInfo8.itemTotalAmountWithoutTax = Convert.ToDouble(ie.TIENMUC8);
                        itemInfo8.taxPercentage = "5";
                        itemInfo8.taxAmount = Convert.ToDouble(ie.TIENMUC8);
                        itemInfos.Add(itemInfo8);
                        sodong++;
                    }
                    if (ie.TIENPHIMT >= 0)
                    {
                        itemInfo itemInfo9 = new itemInfo();
                        itemInfo9.lineNumber = sodong.ToString();
                        itemInfo9.itemCode = ie.IDKH + "-" + sodong.ToString();
                        itemInfo9.selection = "5";
                        itemInfo9.itemName = "MT Rừng";
                        itemInfo9.unitName = "m3";
                        itemInfo9.unitPrice = Convert.ToDouble(ie.TIENPHIMT);
                        itemInfo9.quantity = 1;
                        itemInfo9.itemTotalAmountWithoutTax = Convert.ToDouble(ie.TIENPHIMT);
                        itemInfo9.taxPercentage = "0";
                        itemInfo9.taxAmount = 0;
                        itemInfos.Add(itemInfo9);
                        sodong++;
                    }
                    if (ie.TIENPHITN >= 0)
                    {
                        itemInfo itemInfo10 = new itemInfo();
                        itemInfo10.lineNumber = sodong.ToString();
                        itemInfo10.itemCode = ie.IDKH + "-" + sodong.ToString();
                        itemInfo10.selection = "5";
                        itemInfo10.itemName = "BVMT";
                        itemInfo10.unitName = "m3";
                        itemInfo10.unitPrice = Convert.ToDouble(ie.TIENPHITN);
                        itemInfo10.quantity = 1;
                        itemInfo10.itemTotalAmountWithoutTax = Convert.ToDouble(ie.TIENPHITN);
                        itemInfo10.taxPercentage = "0";
                        itemInfo10.taxAmount = 0;
                        itemInfos.Add(itemInfo10);
                        sodong++;
                    }
                    //if (tbNoidung.Text.Length > 0)
                    //{
                    //    itemInfo itemInfo11 = new itemInfo();
                    //    itemInfo11.selection = "2";
                    //    itemInfo11.itemName = tbNoidung.Text.ToString();
                    //    itemInfo11.unitName = "";
                    //    itemInfo11.unitPrice = 0;
                    //    itemInfo11.quantity = 0;
                    //    itemInfo11.itemTotalAmountWithoutTax = 0;
                    //    itemInfo11.taxPercentage = "0";
                    //    itemInfo11.taxAmount = 0;
                    //    itemInfos.Add(itemInfo11);
                    //}
                    //summarizeInfo
                    commonInvoiceInput.summarizeInfo.sumOfTotalLineAmountWithoutTax = Convert.ToDouble(ie.TIENNUOC);
                    commonInvoiceInput.summarizeInfo.totalAmountWithoutTax = Convert.ToDouble(ie.TIENNUOC);
                    commonInvoiceInput.summarizeInfo.totalTaxAmount = Convert.ToDouble(ie.TIENTHUE);
                    commonInvoiceInput.summarizeInfo.totalAmountWithTax = Convert.ToDouble(ie.TONGTIEN);
                    commonInvoiceInput.summarizeInfo.totalAmountWithTax = 0;
                    commonInvoiceInput.summarizeInfo.totalAmountWithTaxInWords = ie.TONGTIENTEXT;
                    commonInvoiceInput.summarizeInfo.isTotalTaxAmountPos = "false";
                    commonInvoiceInput.summarizeInfo.isTotalAmtWithoutTaxPos = "false";
                    commonInvoiceInput.summarizeInfo.discountAmount = 0;
                    //taxBreakdowns
                    commonInvoiceInput.taxBreakdowns.taxPercentage = 5;
                    commonInvoiceInput.taxBreakdowns.taxableAmount = Convert.ToDouble(ie.TIENTHUE);
                    commonInvoiceInput.taxBreakdowns.taxAmount = Convert.ToDouble(ie.TIENTHUE);

                    //metadata
                    List<metadata> metadatas = new List<metadata>();
                    metadata metadatas1 = new metadata();
                    metadatas1.keyTag = "startDate";
                    metadatas1.valueType = "text";
                    metadatas1.keyLabel = "Từ Ngày";
                    metadatas1.stringValue = String.Format("{0:dd/MM/yyyy}", ie.NGAYNHAP_TT);
                    metadatas1.isRequired = "false";
                    metadatas1.isSeller = "false";
                    metadatas.Add(metadatas1);
                    metadata metadatas2 = new metadata();
                    metadatas2.keyTag = "endDate";
                    metadatas2.valueType = "text";
                    metadatas2.keyLabel = "Đến Ngày";
                    metadatas2.stringValue = String.Format("{0:dd/MM/yyyy}", ie.NGAYNHAP);
                    metadatas2.isRequired = "false";
                    metadatas2.isSeller = "false";
                    metadatas.Add(metadatas2);
                    metadata metadatas3 = new metadata();
                    metadatas3.keyTag = "paymentPeriod";
                    metadatas3.valueType = "text";
                    metadatas3.keyLabel = "Kỳ thanh toán";
                    metadatas3.stringValue = ie.KY.ToString() + " Năm " + ie.NAM;
                    metadatas3.isRequired = "false";
                    metadatas3.isSeller = "false";
                    metadatas.Add(metadatas3);

                    //meterReading
                    List<meterReading> meterReadings = new List<meterReading>();
                    meterReading meterReading1 = new meterReading();
                    meterReading1.meterName = ie.KLTIEUTHU;
                    meterReading1.previousIndex = ie.CHISODAU;
                    meterReading1.currentIndex = ie.CHISOCUOI;
                    meterReading1.factor = "1";
                    meterReading1.amount = ie.M3TINHTIEN;
                    meterReadings.Add(meterReading1);

                    commonInvoiceInput.itemInfos = itemInfos;
                    commonInvoiceInput.metadatas = metadatas;
                    commonInvoiceInput.meterReadings = meterReadings;

                    //commonInvoiceInput.taxBreakdowns = new taxBreakdowns();
                    commonInvoiceInput.taxBreakdowns.taxPercentage = 5;
                    commonInvoiceInput.taxBreakdowns.taxableAmount = Convert.ToDouble(ie.TIENTHUE);
                    commonInvoiceInput.taxBreakdowns.taxAmount = Convert.ToDouble(ie.TIENTHUE);
                    //commonInvoiceInput.taxBreakdowns.taxableAmount =
                    //    commonInvoiceInput.itemInfos.Sum(r => r.itemTotalAmountWithoutTax);
                    //commonInvoiceInput.taxBreakdowns.taxAmount = commonInvoiceInput.itemInfos.Sum(r => r.taxAmount);


                    commonInvoiceInputs.iCommonInvoiceInputs.Add(commonInvoiceInput);
                    i++;
                }
                if (getAccessToken())
                {
                    InvoiceOutputs invoiceOutputs = CreateRequest(commonInvoiceInputs.Body);
                    if (invoiceOutputs != null)
                    {//invoiceOutputses.Add(invoiceOutputs);
                        if (invoiceOutputs.totalFail > 0 || invoiceOutputs.errorCode != null)
                        {
                            MessageBox.Show("Thông báo", "Có lỗi xảy ra: " + invoiceOutputs.errorCode);
                        }
                        if (invoiceOutputs.totalSuccess > 0 || invoiceOutputs.errorCode == null)
                        {
                            List<string> lstWhereIn = new List<string>();
                            string sqlQuery = "", sqlInvoiceNoWhen = "", sqlTransactionUuidWhen = "";
                            Result createInvoice = invoiceOutputs.result;
                            foreach(var obj in commonInvoiceInputs.iCommonInvoiceInputs)
                            {
                                createInvoice.transactionUuid = obj.generalInvoiceInfo.transactionUuid;
                            }
                            //foreach (createInvoiceOutputs createInvoice in invoiceOutputs.createInvoiceOutputs)
                            //{
                            string oldTransactionUuid = createInvoice.transactionUuid.Substring(0, createInvoice.transactionUuid.Length - 2);
                                //sqlQuery = sqlQuery + string.Format("UPDATE TIEUTHU SET invoiceNo = '{0}' WHERE TransactionUuid = '{1}'|", createInvoice.result.invoiceNo, createInvoice.transactionUuid);
                            sqlTransactionUuidWhen = string.Format("{0} WHEN TransactionUuid = '{1}' THEN '{2}' WHEN invoiceNo = '{3}' THEN '{2}'", sqlInvoiceNoWhen, oldTransactionUuid, createInvoice.transactionUuid, createInvoice.invoiceNo);
                            sqlInvoiceNoWhen = string.Format("{0} WHEN TransactionUuid = '{1}' THEN '{2}' WHEN TransactionUuid = '{3}' THEN '{2}'", sqlInvoiceNoWhen, oldTransactionUuid, createInvoice.invoiceNo, createInvoice.transactionUuid);
                                lstWhereIn.Add(string.Format("'{0}'", oldTransactionUuid));
                                lstWhereIn.Add(string.Format("'{0}'", createInvoice.transactionUuid));
                            //}
                            sqlQuery = string.Format("UPDATE TIEUTHU SET invoiceNo = (CASE {0} END), transactionUuid = (CASE {1} END) WHERE TransactionUuid IN ({2})", sqlInvoiceNoWhen, sqlTransactionUuidWhen, string.Join(",", lstWhereIn));

                            Task.Run(() => UpdateThreadAsync(sqlQuery));
                        }

                    }

                }

            }
            return true; //invoiceOutputses;
        }
        private async Task UpdateThreadAsync(string sqlQuery)
        {
            var sqlconnectstring = ConfigurationManager.ConnectionStrings["EIConStrPlainText"].ToString();
            //var arrQuerry = sqlQuery.Split('|');
            await Task.Run(() =>
            {
                using (var connection = new SqlConnection(sqlconnectstring))
                {
                    connection.Open();
                    using (var tran = connection.BeginTransaction())
                    using (var command = new SqlCommand(sqlQuery, connection, tran))
                    {
                        try
                        {
                            command.ExecuteNonQuery();tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            connection.Close();
                            connection.Dispose();
                            command.Dispose();
                        }
                    }
                }
                
                //foreach (string sql in arrQuerry)
                //{
                //    if (string.IsNullOrEmpty(sql)) continue;
                //    using (var connection = new SqlConnection(sqlconnectstring))
                //    {
                //        connection.Open();
                //        using (var tran = connection.BeginTransaction())
                //        using (var command = new SqlCommand(sql, connection, tran))
                //        {
                //            try
                //            {
                //                command.ExecuteNonQuery();
                //                tran.Commit();
                //            }
                //            catch (Exception ex)
                //            {
                //                tran.Rollback();
                //                connection.Close();
                //                connection.Dispose();
                //                command.Dispose();
                //                System.Threading.Thread.Sleep(20);
                //                using (var connection2 = new SqlConnection(sqlconnectstring))
                //                using (var cmd2 = connection2.CreateCommand())
                //                {
                //                    try
                //                    {
                //                        connection2.Open();
                //                        cmd2.CommandText = sql;
                //                        cmd2.ExecuteNonQuery();
                //                    }
                //                    catch (Exception ex2)
                //                    {
                //                        connection2.Close();
                //                        connection2.Dispose();
                //                        cmd2.Dispose();
                //                    }
                //                }

                //            }
                //        }
                //    }
                //    System.Threading.Thread.Sleep(20);
                //}

            });

        }

        private void btnSaveInvoince_Click(object sender, EventArgs e)
        {
            if(gridView1.SelectedRowsCount <= 0)
            {
                showMessage("Vui lòng chọn thông tin dòng thông tin hóa đơn cần lưu!", MessageType.Error);
                return;
            }
            SplashScreenManager.ShowForm(this, typeof(frmBaseWaitform));
            List<string> lstWhereIn = new List<string>();
            string sqlQuery = "", sqlWhen = "";
            int step = 1, rowsCount = 50;
            for (var i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                var row = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
                string transactionUuid = row["transactionUuid"].ToString();
                string invoiceNo = row["invoiceNo"].ToString();
                sqlWhen = string.Format("{0} WHEN TransactionUuid = '{1}' THEN '{2}'", sqlWhen, transactionUuid, invoiceNo);
                lstWhereIn.Add(string.Format("'{0}'", transactionUuid));
                // cập nhật thông tin số hóa đơn
                //cr.UpdateInvoiceNo(transactionUuid, invoiceNo);
                if (i == step * rowsCount || i + 1 >= gridView1.SelectedRowsCount)
                {
                    sqlQuery = string.Format("UPDATE TIEUTHU SET invoiceNo = (CASE {0} END) WHERE (invoiceNo is null OR invoiceNo = '') AND TransactionUuid IN ({1})", sqlWhen, string.Join(",", lstWhereIn));
                    Task.Run(() => UpdateThreadAsync(sqlQuery));
                    System.Threading.Thread.Sleep(1000);
                    sqlQuery = sqlWhen = "";
                    lstWhereIn.Clear();
                    step++;
                }
            }


            System.Threading.Thread.Sleep(2000);
            showMessage("Lưu thông tin số hóa đơn thành công!", MessageType.Information);
            SplashScreenManager.CloseForm(false);
        }

        private void numRowPerPage_ValueChanged(object sender, EventArgs e)
        {
            numRows = (int)Math.Round(numRowPerPage.Value);
        }
        
        private void gridView1_Click(object sender, EventArgs e)
        {
            foreach (var r in gridView1.GetSelectedRows())
            {
                //if (gridView1.IsDataRow(r))
                if (gridView1.RowCount > 0 && gridView1.IsDataRow(r))
                {
                    //var strMau = gridView1.GetRowCellValue(r, gridView1.Columns["invoiceType"]).ToString();
                    var strKyHieu = gridView1.GetRowCellValue(r, gridView1.Columns["invoiceSeries"]).ToString();
                    var strSoHoaDon = gridView1.GetRowCellValue(r, gridView1.Columns["invoiceNumber"]).ToString();
                    var strNgayPhat = DateTime.Parse(gridView1.GetRowCellValue(r, gridView1.Columns["DatePublished"]).ToString());
                    //var arrNgay = string.Join("/", strNgayPhat.Split('/'), 0, 3);
                        tbNoidung.Text = "Hóa đơn thay thế cho hóa đơn giá trị gia tăng điện tử ký hiệu " + strKyHieu +
                         " số " + strSoHoaDon + " lập ngày " + strNgayPhat.ToString("dd/MM/yyyy"); 
                    //if (cbThaoTac.SelectedIndex == 1) // điều chỉnh thông tin
                    //{
                    //    tbNoidung.Text = "Hóa đơn điều chỉnh thông tin cho hóa đơn giá trị gia tăng điện tử ký hiệu " + strKyHieu +
                    //    " số " + strSoHoaDon + " lập ngày " + strNgayPhat.ToString("dd/MM/yyyy");
                    //}
                    //else if (cbThaoTac.SelectedIndex == 2) // Hóa đơn thay thế
                    //{
                    //    tbNoidung.Text = "Hóa đơn thay thế cho hóa đơn giá trị gia tăng điện tử ký hiệu " + strKyHieu +
                    //     " số " + strSoHoaDon + " lập ngày " + strNgayPhat.ToString("dd/MM/yyyy"); 
                    //}

                }
                else
                {
                    tbLyDoKhac.Text = "";
                    tbNoidung.Text = "";
                }
            }
            
        }

       
    }
}