using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using cskh.domain;
using cskh.domain.HInvoiceAuto.Class;
using cskh.domain.HInvoiceAuto.SInvoice;
using System.Data.SqlClient;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraSpreadsheet;
using Newtonsoft.Json;
using System.Threading.Tasks;
using DevExpress.XtraBars.Docking2010.Views.Widget;

namespace XMLSigner.ui
{
    public partial class frmInvoiceSigner2 : frmBase
    {

        //BackgroundWorker worker;
        //frmProgressAlert frmAlert;
        private string strAccessToken = "";
        private string urlAPI = "";
        private string codeTax = "";
        private string proxy = "";
        private int port = 0;
        private int ssl = 0;
        private string sql = "";
        private string strThueGTGT8 = "";


        public frmInvoiceSigner2()
        {
            InitializeComponent();
            urlAPI = ConfigurationManager.AppSettings["APILink"].ToString();
            codeTax = ConfigurationManager.AppSettings["CodeTax"].ToString();
            proxy = ConfigurationManager.AppSettings["ProxyIP"].ToString();
            port = int.Parse(ConfigurationManager.AppSettings["ProxyPort"].ToString());
        }

        private void frmInvoiceSigner2_Load(object sender, EventArgs e)
        {
            //bindKV();
            SignUtil.BindKy(tbMonth, tbYear);
            //SignUtil.BindKv(cbKV, "--Chọn chi nhánh--", "");
            if (tbMonth.Text.Length > 0 && tbYear.Text.Length > 0)
            {
                SignUtil.BindKvX(cbKV, tbMonth, tbYear, "--Chọn chi nhánh--", "");
            }
            //BindMaDp();
            //bindKy();            
            //gbKy.Enabled = false;
            //btnSaveFile.Enabled = false;
        }

        private void bntLoad_Click(object sender, EventArgs e)
        {
            if (tbMonth.Text == string.Empty || tbYear.Text == string.Empty)
            {
                MessageBox.Show("Không tìm thấy kỳ hóa đơn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var checkedDp = getCheckedMaDp();
            if (checkedDp == "")
            {
                MessageBox.Show("Vui lòng chọn lộ trình!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SplashScreenManager.ShowForm(this, typeof(frmBaseWaitform));
            BindGrid(checkedDp, Convert.ToInt16(tbMonth.Text), Convert.ToInt16(tbYear.Text));
            SplashScreenManager.CloseForm(false);
        }

        private void BindMaDp()
        {
            if (Convert.ToInt16(Convert.ToInt16(tbYear.Text)) < Systems.NamBatDau)
            {
                MessageBox.Show("Hóa đơn trước năm " + Systems.NamBatDau + ". Xin sử dụng phần mềm cũ");
                return;
            }
            try
            {
                /*cách thực hiện:
                 *1. Lấy danh sách idkh cần ký của một chi nhánh (khu vực) trong kỳ : dt1
                 *2. Lấy danh sách idkh đã ký trong kỳ : dt2
                 *3. dt1 - dt2 = dt3: danh sách idkh cần phải ký của chi nhánh trong kỳ
                 *4. lấy distinct madp trong C, có danh sách   
                 */
                if (cbKV.SelectedIndex == 0 || string.IsNullOrEmpty(tbMonth.Text) || string.IsNullOrEmpty(tbYear.Text))
                    return;
                var khuvuc = cbKV.SelectedValue.ToString();
                int ky = Convert.ToInt16(tbMonth.Text);
                int nam = Convert.ToInt16(tbYear.Text);
                using (var cri = new CrBusinessImpl())
                {
                    // 1. Lấy danh sách idkh cần ký của một chi nhánh (khu vực) trong kỳ
                    // IDKH, MAKV, TENKV, MADP, TENDP
                    var dt1 = cri.GetHdbyKv(khuvuc, ky, nam);
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        dt1.Columns.Add(Constants.DP_TENDP_GOP, typeof(string), "MADP + ' - ' +TENDP");
                        // them cot ten gop = madp - tendp

                        //2. Lấy danh sách idkh đã ký trong kỳ : dt2
                        using (var ebi = new EiBusinessImpl())
                        {
                            // Nếu khách hàng đã ký Hóa đơn rồi, nhưng sai Chi nhánh thì phải Hủy hóa đơn đó trước sau đó mới Ký lại hóa đơn
                            // còn trong trường hợp bình thường (không thay đổi chi nhánh) thì Hủy lặp lại!
                            // MADP,IDKH
                            var dt2 = ebi.GetSignedHdByKy(ky, nam);
                            //3. dt1 - dt2: idkh in dt1 but not in dt2                         
                            var idsNotIndt2 = (dt2 != null && dt2.Rows.Count > 0)
                                ? dt1.AsEnumerable()
                                    .Select(r => r.Field<string>(Constants.IDKH))
                                    .Except(dt2.AsEnumerable().Select(r => r.Field<string>(Constants.IDKH)))
                                : dt1.AsEnumerable().Select(r => r.Field<string>(Constants.IDKH));
                            DataTable dt3; // hoa don chua ky
                            try
                            {
                                dt3 =
                                    (from row in dt1.AsEnumerable()
                                        join id in idsNotIndt2 on row.Field<string>(Constants.IDKH) equals id
                                        select row).CopyToDataTable();

                            }
                            catch (Exception)
                            {
                                // this exception will be raised when all hd .are signed
                                ((ListBox) clbDp).DataSource = null;
                                return;
                            }

                            try
                            {
                                if (dt3 != null && dt3.Rows.Count > 0)
                                {
                                    var distinctValues = dt3.AsEnumerable()
                                        .Select(row => new
                                        {
                                            MADP = row.Field<string>(Constants.DP_MADP),
                                            TENDP_GOP = row.Field<string>(Constants.DP_TENDP_GOP)
                                        })
                                        .Distinct();

                                    var list = distinctValues.ToList();
                                    list.Insert(0, new {MADP = "All", TENDP_GOP = "--Tất cả--"});
                                    ((ListBox) clbDp).DataSource = list;
                                    ((ListBox) clbDp).DisplayMember = Constants.DP_TENDP_GOP;
                                    ((ListBox) clbDp).ValueMember = Constants.DP_MADP;

                                }
                                else
                                {
                                    ((ListBox) clbDp).DataSource = null;
                                }
                            }
                            catch
                            {
                                // error raised when dt3 has no row                            
                            }
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi DB: " + ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// bind grid. this grid contains unsigned hoa don only.
        /// So need to use Enumerable.Except
        /// </summary>
        /// <param name="madp"></param>
        /// <param name="thang"></param>
        /// <param name="nam"></param>
        private void BindGrid(string madp, int thang, int nam)
        {
            try
            {
                DataTable dt1, hdDaKy;
                // 1    Lấy danh sách Khách hàng cần Ký Hóa đơn theo Lộ trình trong CR
                using (var cr = new CrBusinessImpl())
                {
                    dt1 = cr.GetHdbyDp(madp, thang, nam);
                }
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    // 2    Lấy danh sách Khách hàng đã Ký Hóa đơn theo Lộ trình trong EI
                    using (var ei = new EiBusinessImpl())
                    {
                        //DataSet ds = hbi.getSignedHDByDP(madp, thang, nam);
                        // IDKH, TENKH, DIACHI, KY, NAM, TONGTIEN, SOHOADON, KIHIEUHOADON, issigned 
                        hdDaKy = ei.GetListHoaDonByKyThang(thang, nam); // hoa don da ky
                    }

                    // 3    So sánh để lấy danh sách chưa ký !!!
                    IEnumerable<String> idsNotInB;
                    if (hdDaKy != null && hdDaKy.Rows.Count > 0)
                    {
                        idsNotInB = dt1.AsEnumerable().Select(r => r.Field<string>(Constants.IDKH))
                            .Except(hdDaKy.AsEnumerable().Select(r => r.Field<string>(Constants.IDKH)));
                        // only one column IDKH
                    }
                    else
                    {
                        idsNotInB = dt1.AsEnumerable().Select(r => r.Field<string>(Constants.IDKH));
                    }

                    DataTable hdChuaKy = null; // hoa don chua ky
                    try
                    {
                        hdChuaKy = (from row in dt1.AsEnumerable()
                            join id in idsNotInB
                                on row.Field<string>(Constants.IDKH) equals id
                            select row).CopyToDataTable();
                    }
                    catch (Exception)
                    {
                        // this exception will be raised when all hd are signed
                    }

                    if (hdChuaKy == null)
                    {
                        showMessage("Không tìm thấy hóa đơn chưa ký!", MessageType.Information);
                        //gbKy.Enabled = false;
                    }
                    else
                    {
                        DataView dv = hdChuaKy.DefaultView;
                        dv.Sort = string.Format("{0} ASC" + ",{1} ASC", Constants.MADP, Constants.STT);
                        //gbKy.Enabled = true;
                    }
                    gridControl1.DataSource = hdChuaKy;
                    //btnSaveFile.Enabled = false;
                    ResetGbKy();
                }
                else
                {
                    gridControl1.DataSource = null;
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi DB:" + ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void BindGridAfterSign(string idkh, int thang, int nam)
        {
            using (var ebi = new EiBusinessImpl())
            {
                var dt = ebi.GetHoaDonByPk(idkh, thang, nam);
                gridControl1.DataSource = dt;
            }
        }

        /// <summary>
        /// handle when sign a selected list of hoa don
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSign_Click(object sender, EventArgs e)
        {
            if (IsValidForSign())
            {
                /*
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

                if (certificate == null) return;

                // Kiểm tra ngày hiệu lực
                if (Systems.DateOfServer < certificate.NotBefore || Systems.DateOfServer > certificate.NotAfter)
                {
                    MessageBox.Show(this,
                        string.Format("Chứng thư có hiệu lực\n Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}.",
                            certificate.NotBefore, certificate.NotAfter), "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                //Thread.Sleep(1000);                
                //var waitform = new frmBaseWaitform();
                SplashScreenManager.ShowForm(this, typeof(frmBaseWaitform));
                // get list hd from grid (not include hoadonxml and sohoadon, kihieu )
                 */
                var hds = GetSelectedHoaDonAssign();
                if (hds != null)
                    MessageBox.Show(this, string.Format("Ký hoàn tất {0}", " hóa đơn."), "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                /*
                var selectedIdkh = "";
                for (var i = 0; i < hds.Count; i++)
                {
                    var hd = hds[i];
                    selectedIdkh += hd.IDKH;
                    if (i != hds.Count - 1) selectedIdkh += ",";
                }

                // create dictionary hd whose element key is kihieuhoadon and element value is a list of num belong to that kihieu
                // after this step, we have sohoadon attached to hoadon obj
                var hdDic = new Dictionary<string, List<string>>();
                var list = new List<string>();
                var startNum = Convert.ToInt32(soHoaDonUC1.Sohoadon);
                var endNum = Convert.ToInt32(tbEndNum.Text);
                for (var i = startNum; i <= endNum; i++)
                {
                    list.Add(i.ToString("D" + soHoaDonUC1.Sohoadon.Length));
                    // format "Dx" --> number display with x digit, left padding with 0
                }
                //hdDic.Add(soHoaDonUC1.Kihieu, list);
                hdDic.Add(soHoaDonUC1.MauSery + ";" + soHoaDonUC1.Kihieu, list);

                // assign invoice num
                assignSoHoaDon(hds, hdDic);
                SplashScreenManager.CloseForm(false);

                var result = Sign(hds, certificate);
                var errorCode = result.ElementAt(0).Key;
                var signedCount = result.ElementAt(0).Value;

                if (errorCode == 0)
                {
                    MessageBox.Show(this, string.Format("Ký hoàn tất {0}/{0} hóa đơn.", hds.Count), "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this,
                        string.Format(
                            "Lỗi xảy ra khi ký hóa đơn của IDKH: {0} - Mã lỗi: {1}\nKý hoàn tất {2}/{3} hóa đơn.",
                            hds[signedCount].IDKH, errorCode, signedCount, hds.Count), "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                //btnSaveFile.Enabled = true;
                //gbKy.Enabled = false;
                 */

                BindMaDp(); // bind lai ma duong pho de loai ra ma da ky het
                //BindGridAfterSign(selectedIdkh, Convert.ToInt16(tbMonth.Text), Convert.ToInt16(tbYear.Text));


            }

            //worker = new BackgroundWorker();
            //worker.WorkerReportsProgress = true;
            //worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            //worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            //worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);

            //worker.RunWorkerAsync();
            //frmAlert = new frmProgressAlert();
            //frmAlert.ShowDialog();
        }


        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //tbTotal.Text = "" + gridView1.SelectedRowsCount;
            //tbEndNum.ResetText();
            //soHoaDonUC1.Sohoadon = string.Empty;
        }

        private generalInvoiceInfo getGeneralInvoiceInfo(string transactionUuid)
        {
            generalInvoiceInfo generalInvoiceInfo = new generalInvoiceInfo();
            generalInvoiceInfo.invoiceType = "1";
            generalInvoiceInfo.templateCode = "1/002";
            //generalInvoiceInfo.invoiceSeries = "K" + DateTime.Today.ToString("yy") + "TCN";
            generalInvoiceInfo.invoiceSeries = "K22TCN";
            generalInvoiceInfo.currencyCode = "VND";
            generalInvoiceInfo.adjustmentType = "1";
            generalInvoiceInfo.paymentStatus = "true";
            generalInvoiceInfo.cusGetInvoiceRight = "true";
            //generalInvoiceInfo.cusGetInvoiceRight = "true";
            generalInvoiceInfo.transactionUuid = transactionUuid;
            return generalInvoiceInfo;
        }

        private List<itemInfo> GetItemInfos(DataRow[] rows, double ThueGTGT, ref string str)
        {
            List<itemInfo> itemInfos = new List<itemInfo>();
            for (int i = 0; i < rows.Length; i++)
            {
                DataRow row = rows[i];
                itemInfo item = new itemInfo();
                string mathang = row["mathang"] == DBNull.Value ? "" : Convert.ToString(row["mathang"]);
                double SoSeri = row["SoSeri"] == DBNull.Value ? 0 : Convert.ToDouble(row["SoSeri"]);
                double khoiluong = row["khoiluong"] == DBNull.Value ? 0 : Convert.ToDouble(row["khoiluong"]);
                string DVT = row["DVT"] == DBNull.Value ? "" : Convert.ToString(row["DVT"]);
                double sotien = row["sotien"] == DBNull.Value ? 0 : Convert.ToDouble(row["sotien"]);
                double TienThanhToan = row["TienThanhToan"] == DBNull.Value ? 0 : Convert.ToDouble(row["TienThanhToan"]);

                string lydonop = row["lydonop"] == DBNull.Value ? "" : Convert.ToString(row["lydonop"]);

                item.lineNumber = (i + 1).ToString();
                item.itemCode = mathang + "-" + SoSeri;
                item.itemName = lydonop;
                item.unitName = DVT;
                item.unitPrice = sotien/(1 + ThueGTGT/100);
                item.quantity = khoiluong;
                item.selection = "1";
                item.itemTotalAmountWithoutTax = TienThanhToan/(1 + ThueGTGT/100);
                item.taxPercentage = ThueGTGT.ToString();
                item.taxAmount = (TienThanhToan/(1 + ThueGTGT/100))*(ThueGTGT/100);
                itemInfos.Add(item);

                if (str == "")
                    str = mathang + "-" + SoSeri;
                else
                    str += "," + mathang + "-" + SoSeri;
            }
            return itemInfos;
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
                string apiLink = urlAPI + @"/services/einvoiceapplication/api/InvoiceAPI/InvoiceWS/createBatchInvoice/" +
                                 codeTax;
                string contentType = "application/json";

                string result = cskh.domain.HInvoiceAuto.SInvoice.CreateRequest.webRequestV2(apiLink, request, strAccessToken, "POST",
                    contentType, proxy, port, ssl);
                //if (result.totalFail)

                InvoiceOutputs auth = JsonConvert.DeserializeObject<InvoiceOutputs>(result);
                return auth;
                //MessageBox.Show("OK " + result);
            }
            catch (Exception ex)
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
                //string user = ConfigurationManager.AppSettings["User"].ToString(); // User test
                //string pass = ConfigurationManager.AppSettings["Pass"].ToString(); // Password test
                string apiLink = urlAPI + @"/auth/login";
                string contentType = "application/json";
                string method = "POST";
                proxy = "";
                port = 0;

                string request = @"{""username"":""" + user + @""",""password"":""" + pass + @"""}";
                ssl = 1;
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

        
        private List<EI> GetSelectedHoaDon()
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

        private bool GetSelectedHoaDonAssign()
        {
            var hds = GetSelectedHoaDon();

            //List<InvoiceOutputs> invoiceOutputses = new List<InvoiceOutputs>();
            var i = 0;
            while (i < hds.Count)
            {
                commonInvoiceInputs commonInvoiceInputs = new commonInvoiceInputs();
                commonInvoiceInputs.iCommonInvoiceInputs = new List<commonInvoiceInput>();
                //List<string[]> vs = new List<string[]>();
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

                    /* Bỏ trường hợp ràng buộc CSDAU >= CSCUOI
                    if (ie.TTHAIGHI == "GDH_TDH" && ie.TONGTIEN > 0)
                    {
                        meterReading meterReading1 = new meterReading();
                        meterReading1.meterName = ie.KLTIEUTHU;
                        meterReading1.previousIndex = ie.CHISODAU;
                        meterReading1.currentIndex = ie.CSTR_SC;
                        meterReading1.factor = "1";
                        meterReading1.amount = ie.M3TINHTIEN;
                        meterReadings.Add(meterReading1);

                        meterReading meterReading2 = new meterReading();
                        meterReading2.meterName = ie.KLTIEUTHU;
                        meterReading2.previousIndex = ie.CSSAU_SC;
                        meterReading2.currentIndex = ie.CHISOCUOI;
                        meterReading2.factor = "1";
                        meterReading2.amount = ie.M3TINHTIEN;
                        meterReadings.Add(meterReading2);   
                    }
                    else if (ie.TTHAIGHI == "GDH_VG" && ie.TONGTIEN > 0)
                    {
                        meterReading meterReading1 = new meterReading();
                        meterReading1.meterName = ie.KLTIEUTHU;
                        meterReading1.previousIndex = ie.CHISODAU;
                        if ((ie.CHISODAU).ToString().Length == 4)
                        {
                            meterReading1.currentIndex = 10000; //ie.CSTR_SC;
                        }
                        else if((ie.CHISODAU).ToString().Length == 5)
                        {
                            meterReading1.currentIndex = 100000;  // ie.CSTR_SC;
                        }
                        meterReading1.factor = "1";
                        meterReading1.amount = ie.M3TINHTIEN;
                        meterReadings.Add(meterReading1);

                        meterReading meterReading2 = new meterReading();
                        meterReading2.meterName = ie.M3TINHTIEN;
                        meterReading2.previousIndex = 0; //ie.CSSAU_SC;
                        meterReading2.currentIndex = ie.CHISOCUOI;
                        meterReading2.factor = "1";
                        meterReading2.amount = ie.M3TINHTIEN;
                        meterReadings.Add(meterReading2);
                    }
                    else
                    {
                        meterReading meterReading1 = new meterReading();
                        meterReading1.meterName = ie.KLTIEUTHU;
                        meterReading1.previousIndex = ie.CHISODAU;
                        meterReading1.currentIndex = ie.CHISOCUOI;
                        meterReading1.factor = "1";
                        meterReading1.amount = ie.M3TINHTIEN;
                        meterReadings.Add(meterReading1);
                    }
                    */
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
                    {
                        //invoiceOutputses.Add(invoiceOutputs);
                        if (invoiceOutputs.totalFail > 0)
                        {
                            MessageBox.Show("Thông báo", "Có lỗi xảy ra: " + invoiceOutputs.lstMapError);
                        }
                        if (invoiceOutputs.totalSuccess > 0)
                        {
                            List<string> lstWhereIn = new List<string>();
                            string sqlQuery = "", sqlWhen = "";
                            foreach (createInvoiceOutputs createInvoice in invoiceOutputs.createInvoiceOutputs)
                            {
                                //sqlQuery = sqlQuery + string.Format("UPDATE TIEUTHU SET invoiceNo = '{0}' WHERE TransactionUuid = '{1}'|", createInvoice.result.invoiceNo, createInvoice.transactionUuid);
                                sqlWhen = string.Format("{0} WHEN TransactionUuid = '{1}' THEN '{2}'", sqlWhen, createInvoice.transactionUuid, createInvoice.result.invoiceNo);
                                lstWhereIn.Add(string.Format("'{0}'", createInvoice.transactionUuid));
                            }
                            sqlQuery = string.Format("UPDATE TIEUTHU SET invoiceNo = (CASE {0} END) WHERE TransactionUuid IN ({1})", sqlWhen, string.Join(",", lstWhereIn));

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
            await Task.Run(() => {
                using (var connection = new SqlConnection(sqlconnectstring))
                {
                    connection.Open();
                    using (var tran = connection.BeginTransaction())
                    using (var command = new SqlCommand(sqlQuery, connection, tran))
                    {
                        try
                        {
                            command.ExecuteNonQuery();
                            tran.Commit();
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
                //                    using ( var connection2 = new SqlConnection(sqlconnectstring))
                //                    using (var cmd2 = connection2.CreateCommand())
                //                    {
                //                        try
                //                        {
                //                            connection2.Open();
                //                            cmd2.CommandText = sql;
                //                            cmd2.ExecuteNonQuery();
                //                        }
                //                        catch (Exception ex2)
                //                        {
                //                            connection2.Close();
                //                            connection2.Dispose();
                //                            cmd2.Dispose();
                //                        }
                //                    }
                                
                //            }
                //        }
                //    }
                //    System.Threading.Thread.Sleep(20);
                //}
            });
            
        }
        private async Task DoVariousThingsFromTheUIThreadAsync(result rs, string transactionUuid)
        {
          // I have a bunch of async work to do, and I am executed on the UI thread.

            await Task.Run(() => LuuThongTinHoaDon(rs, transactionUuid));
        }

        private async Task LuuThongTinHoaDon(result rs, string transactionUuid)
        {
            var sqlconnectstring = ConfigurationManager.ConnectionStrings["EIConStrPlainText"].ToString();
            string sql = string.Format("UPDATE TIEUTHU SET invoiceNo = '{0}' WHERE TransactionUuid = '{1}'", rs.invoiceNo, transactionUuid);
            //using ( var connection = new SqlConnection(sqlconnectstring))
            //using (var cmd = connection.CreateCommand())
            //{
            //    connection.OpenAsync();
            //    cmd.ExecuteNonQueryAsync();
            //}
            using (var connection = new SqlConnection(sqlconnectstring))
            {
                await connection.OpenAsync().ConfigureAwait(false);
                using (var tran = connection.BeginTransaction())
                using (var command = new SqlCommand(sql, connection, tran))
                {
                    try
                    {
                        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        throw;
                    }
                    tran.Commit();
                }
            }
        }


        /*
         private List<EI> GetSelectedHoaDon1()
         {
             var hds = new List<EI>();

             var i = 0;
             while (i < gridView1.SelectedRowsCount)
             {
                 commonInvoiceInputs commonInvoiceInputs = new commonInvoiceInputs();
                 commonInvoiceInputs.iCommonInvoiceInputs = new List<commonInvoiceInput>();
                 List<string[]> vs = new List<string[]>();
                 while (i < gridView1.SelectedRowsCount && commonInvoiceInputs.iCommonInvoiceInputs.Count < 30)
                 {
                     commonInvoiceInput commonInvoiceInput = new commonInvoiceInput();
                     commonInvoiceInput.generalInvoiceInfo = getGeneralInvoiceInfo();
                     commonInvoiceInput.buyerInfo = new buyerInfo();
                     commonInvoiceInput.payments = new payments();
                     commonInvoiceInput.taxBreakdowns = new taxBreakdowns();
                     commonInvoiceInput.itemInfos = new List<itemInfo>();

                     //var dr = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);

                     DataRow row = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
                     string makhachhang = Convert.ToString(row["makhachhang"]);
                     string tenkhachhang = row["tenkhachhang"] == DBNull.Value
                         ? ""
                         : Convert.ToString(row["tenkhachhang"]);
                     //string mathang = row["mathang"] == DBNull.Value ? "" : Convert.ToString(row["mathang"]);
                     //string SoSeri = row["SoSeri"] == DBNull.Value ? "" : Convert.ToString(row["SoSeri"]);
                     //tring TienThanhToan = row["TienThanhToan"] == DBNull.Value ? "" : Convert.ToString(row["TienThanhToan"]);
                     string sonha = row["sonha"] == DBNull.Value ? "" : Convert.ToString(row["sonha"]);
                     string tenduong = row["tenduong"] == DBNull.Value ? "" : Convert.ToString(row["tenduong"]);
                     string tenphuong = row["tenphuong"] == DBNull.Value ? "" : Convert.ToString(row["tenphuong"]);
                     string tentp = row["tentp"] == DBNull.Value ? "" : Convert.ToString(row["tentp"]);
                     string lydonop = row["lydonop"] == DBNull.Value ? "" : Convert.ToString(row["lydonop"]);

                     commonInvoiceInput.buyerInfo.buyerCode = makhachhang;
                     commonInvoiceInput.buyerInfo.buyerName = tenkhachhang;
                     //commonInvoiceInput.buyerInfo.buyerLegalName = tenkhachhang;
                     commonInvoiceInput.buyerInfo.buyerTaxCode = "";
                     commonInvoiceInput.payments.paymentMethodName = "TM/CK";
                     string diachi = sonha;
                     if (diachi == "")
                         diachi = tenduong;
                     else
                         diachi += " " + tenduong;

                     if (diachi == "")
                         diachi = tenphuong;
                     else
                         diachi += ", " + tenphuong;

                     if (diachi == "")
                         diachi = tentp;
                     else
                         diachi += ", " + tentp;

                     diachi += ", " + "Tỉnh Thừa Thiên Huế";
                     commonInvoiceInput.buyerInfo.buyerAddressLine = diachi;
                     DataRow[] row1s =
                         gridView1.GetSelectedRows("makhachhang = '" + makhachhang + "' AND mathang in (" + strThueGTGT8 +")");
                     DataRow[] row2s =
                         gridView1.GetSelectedRows("makhachhang = '" + makhachhang + "' AND not mathang in (" + strThueGTGT8 + ")");

                     if (row1s.Length > 0 && row2s.Length > 0)
                     {
                         string str = "";
                         commonInvoiceInput.itemInfos = GetItemInfos(row1s, 8, ref str);
                         commonInvoiceInput.generalInvoiceInfo.transactionUuid = System.Guid.NewGuid().ToString();
                         //"Postman" + makhachhang + "-" + str;
                         commonInvoiceInput.taxBreakdowns = new taxBreakdowns();
                         commonInvoiceInput.taxBreakdowns.taxPercentage = 8;
                         commonInvoiceInput.taxBreakdowns.taxableAmount =
                             commonInvoiceInput.itemInfos.Sum(r => r.itemTotalAmountWithoutTax);
                         commonInvoiceInput.taxBreakdowns.taxAmount = commonInvoiceInput.itemInfos.Sum(r => r.taxAmount);
                         vs.Add(new string[3]);
                         vs[vs.Count - 1][0] = commonInvoiceInput.generalInvoiceInfo.transactionUuid;
                         vs[vs.Count - 1][1] = makhachhang + "-" + str;
                         vs[vs.Count - 1][2] = "8";

                         commonInvoiceInput commonInvoiceInput8 = new commonInvoiceInput();
                         commonInvoiceInput8.generalInvoiceInfo = getGeneralInvoiceInfo();
                         commonInvoiceInput8.buyerInfo = commonInvoiceInput.buyerInfo;
                         commonInvoiceInput8.payments = commonInvoiceInput.payments;
                         str = "";
                         commonInvoiceInput8.itemInfos = GetItemInfos(row2s, 10, ref str);
                         commonInvoiceInput8.generalInvoiceInfo.transactionUuid = System.Guid.NewGuid().ToString();
                         //"Postman" + makhachhang + "-" + str;

                         commonInvoiceInput8.taxBreakdowns = new taxBreakdowns();
                         commonInvoiceInput8.taxBreakdowns.taxPercentage = 10;
                         commonInvoiceInput8.taxBreakdowns.taxableAmount =
                             commonInvoiceInput8.itemInfos.Sum(r => r.itemTotalAmountWithoutTax);
                         commonInvoiceInput8.taxBreakdowns.taxAmount = commonInvoiceInput8.itemInfos.Sum(r => r.taxAmount);

                         commonInvoiceInputs.iCommonInvoiceInputs.Add(commonInvoiceInput8);
                         vs.Add(new string[3]);
                         vs[vs.Count - 1][0] = commonInvoiceInput8.generalInvoiceInfo.transactionUuid;
                         vs[vs.Count - 1][1] = makhachhang + "-" + str;
                         vs[vs.Count - 1][2] = "10";
                     }
                     else if (row1s.Length > 0)
                     {
                         string str = "";
                         commonInvoiceInput.itemInfos = GetItemInfos(row1s, 8, ref str);
                         commonInvoiceInput.generalInvoiceInfo.transactionUuid = System.Guid.NewGuid().ToString();
                         // "Postman" + makhachhang + "-" + str;
                         commonInvoiceInput.taxBreakdowns = new taxBreakdowns();
                         commonInvoiceInput.taxBreakdowns.taxPercentage = 8;
                         commonInvoiceInput.taxBreakdowns.taxableAmount =
                             commonInvoiceInput.itemInfos.Sum(r => r.itemTotalAmountWithoutTax);
                         commonInvoiceInput.taxBreakdowns.taxAmount = commonInvoiceInput.itemInfos.Sum(r => r.taxAmount);

                         vs.Add(new string[3]);
                         vs[vs.Count - 1][0] = commonInvoiceInput.generalInvoiceInfo.transactionUuid;
                         vs[vs.Count - 1][1] = makhachhang + "-" + str;
                         vs[vs.Count - 1][2] = "8";
                     }
                     else if (row2s.Length > 0)
                     {
                         string str = "";
                         commonInvoiceInput.itemInfos = GetItemInfos(row2s, 10, ref str);
                         commonInvoiceInput.generalInvoiceInfo.transactionUuid = System.Guid.NewGuid().ToString();
                         //"Postman" + makhachhang + "-" + str;
                         commonInvoiceInput.taxBreakdowns = new taxBreakdowns();
                         commonInvoiceInput.taxBreakdowns.taxPercentage = 10;
                         commonInvoiceInput.taxBreakdowns.taxableAmount =
                             commonInvoiceInput.itemInfos.Sum(r => r.itemTotalAmountWithoutTax);
                         commonInvoiceInput.taxBreakdowns.taxAmount = commonInvoiceInput.itemInfos.Sum(r => r.taxAmount);

                         vs.Add(new string[3]);
                         vs[vs.Count - 1][0] = commonInvoiceInput.generalInvoiceInfo.transactionUuid;
                         vs[vs.Count - 1][1] = makhachhang + "-" + str;
                         vs[vs.Count - 1][2] = "10";
                     }
                     commonInvoiceInputs.iCommonInvoiceInputs.Add(commonInvoiceInput);
                     i += row1s.Length + row2s.Length;
                 }
                 if (getAccessToken())
                 {
                     InvoiceOutputs invoiceOutputs = CreateRequest(commonInvoiceInputs.Body);
                     if (invoiceOutputs != null)
                     {
                         //if (invoiceOutputs.totalFail == 0
                         //    && invoiceOutputs.createInvoiceOutputs.Count == commonInvoiceInputs.iCommonInvoiceInputs.Count)
                         if (invoiceOutputs.totalFail > 0)
                         {

                         }
                         if (invoiceOutputs.totalSuccess > 0)
                         {
                             sql = "SELECT TOP 0 * FROM Invoice2022.dbo.createInvoiceOutputs";
                             DataTable table1 = p.OpenTable(sql, "createInvoiceOutputs");
                             DateTime dateTime = DateTime.Now;
                             foreach (createInvoiceOutputs createInvoice in invoiceOutputs.createInvoiceOutputs)
                             {
                                 List<string[]> vs1 = vs.Where(r => r[0] == createInvoice.transactionUuid).ToList();
                                 if (vs1.Count == 1)
                                 {
                                     DataRow row = table1.NewRow();
                                     row["transactionUuid"] = createInvoice.transactionUuid;
                                     row["IdKey"] = vs1[0][1];
                                     row["supplierTaxCode"] = createInvoice.result.supplierTaxCode;
                                     row["invoiceNo"] = createInvoice.result.invoiceNo;
                                     row["transactionID"] = createInvoice.result.transactionID;
                                     row["reservationCode"] = createInvoice.result.reservationCode;
                                     row["taxPercentage"] = vs1[0][2];
                                     row["Time"] = dateTime;
                                     table1.Rows.Add(row);
                                 }
                                 else
                                 {

                                 }
                             }
                             up = p.UpdateTable("Invoice2022.dbo.createInvoiceOutputs", table1);
                         }
                         else //if()
                         {

                         }
                     }
                     else
                     {

                     }
                 }

             }
             //p.CloseTransaction();
             p.Close();
         }
          */

        /// <summary>
        /// Assign a sery number get from hdDic to each hoa don in the hdList
        /// </summary>
        /// <param name="hdList">list of hoadon need to assign sery number</param>
        /// <param name="hdDic">list of sery number. use Dictionary to store multiple 'mau sery' at once</param>
        /// <returns></returns>
        private bool assignSoHoaDon(List<EI> hdList, Dictionary<string, List<string>> hdDic)
        {
            int totalNum = 0;
            foreach (var item in hdDic.Values)
            {
                totalNum += item.Count;
            }
            if (hdList.Count < totalNum) return false;

            int assignedCount = 0;
            for (int i = 0; i < hdDic.Count; i++)
            {
                var elem = hdDic.ElementAt(i);
                for (var j = assignedCount; j < elem.Value.Count; j++)
                {
                    //hdList[j].KIHIEUHOADON = elem.Key;
                    var pairKey = elem.Key.Split(new[] { ';' });
                    hdList[j].MAUHOADON = pairKey[0];
                    hdList[j].KIHIEUHOADON = pairKey[1];
                    hdList[j].SOHOADON = elem.Value[j];
                    assignedCount++;
                }

            }
            return true;
        }
        // Luu tep
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount != 1)
            {
                showMessage("Vui lòng chọn một hóa đơn để lưu!", MessageType.Error);
                return;
            }
            List<EI> hds = GetSelectedHoaDon();
            EI hd = hds[0];

            // Displays a SaveFileDialog 
            var saveFileDialog1 = new SaveFileDialog
            {
                FileName = string.Format("KH{0}_Ky{1}_Nam{2}", hd.IDKH, hd.KY, hd.NAM),
                Filter = "XML|*.xml",
                Title = "Ghi hóa đơn đã ký ra file"
            };
            var result = saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "" && result == DialogResult.OK)
            {
                using (var hdb = new EiBusinessImpl())
                {
                    byte[] xmlData = hdb.GetHoaDonXml(hd.IDKH, hd.KY, hd.NAM);
                    if (xmlData == null)
                    {
                        showMessage("Tệp hóa đơn chưa được tạo. Vui lòng ký hóa đơn trước.", MessageType.Error);
                    }
                    SignUtil.XmlstringToFile(saveFileDialog1.FileName, SignUtil.ByteArrayToString(xmlData));
                    showMessage("Tệp hóa đơn lưu thành công trên " + saveFileDialog1.FileName, MessageType.Information);
                }
            }
        }

        // khi so sery dau changed, update so sery cuoi
        //private void soHoaDonUC1_SoHoaDonChanged(object sender, EventArgs e)
        //{
        //    using (var ei = new EiBusinessImpl())
        //    {
        //        if (Convert.ToInt16(tbTotal.Text) <= 0)
        //        {
        //            tbEndNum.Text = "";
        //            return;
        //        }
        //        if (!String.IsNullOrEmpty(soHoaDonUC1.Sohoadon))
        //        {
        //            string sohdcuoi = ei.GetEndInvoiceNum(soHoaDonUC1.Kihieu, soHoaDonUC1.Sohoadon, Convert.ToInt16(tbTotal.Text));
        //            if (sohdcuoi != "-1") tbEndNum.Text = sohdcuoi;
        //            else
        //            {
        //                tbEndNum.Text = "";
        //                int sohdchuadung = ei.GetSoHdChuaDung(soHoaDonUC1.Kihieu);
        //                MessageBox.Show(string.Format("Mẫu sery {0}chỉ còn lại {1} số sery chưa sử dụng.\nVui lòng chọn tối đa {1} hóa đơn để ký!", sohdchuadung, sohdchuadung), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            //tbEndNum.Text = "";
        //        }
        //    }
        //}

        // validate before signing
        private bool IsValidForSign()
        {
            if (gridView1.SelectedRowsCount <= 0)
            {
                showMessage("Vui lòng chọn hóa đơn để ký!", MessageType.Error);
                return false;
            }
            if (gridView1.SelectedRowsCount > Constants.HdMax) // hien chi ho tro ky toi da 2000 hoa don trong 1 lan ky
            {
                showMessage(string.Format("Vui lòng không chọn quá {0} hóa đơn!", Constants.HdMax), MessageType.Information);
                return false;
            }
            //if (string.IsNullOrEmpty(soHoaDonUC1.Sohoadon) || string.IsNullOrEmpty(tbEndNum.Text))
            //{
            //    showMessage("Vui lòng lấy số hóa đơn trước khi ký!", MessageType.Error);
            //    return false;
            //}
            //if (Convert.ToInt32(tbEndNum.Text) - Convert.ToInt32(soHoaDonUC1.Sohoadon) + 1 < Convert.ToInt16(tbTotal.Text))
            //{
            //    showMessage("Dãy sery được chọn không đủ để ký cho " + tbTotal.Text + " hóa đơn.", MessageType.Error);
            //    return false;
            //}
            /*
            foreach (HoaDon hd in getSelectedHoaDon())
            {
                if (hd.isSigned())
                {
                    showMessage("Tồn tại hóa đơn đã ký trong danh sách được chọn!\nVui lòng sử dụng chức năng \"Hủy bỏ - Lập lại\" để ký lại một hóa đơn đã ký.", MessageType.Error);
                    return isok;
                }
            }*/
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hds"></param>
        /// <param name="certificate"></param>
        /// <returns>ma loi va stt (tinh tu 0) cua hoa don bi loi, neu tra ve (0,-1) --> OK ALL</returns>
        private Dictionary<int, int> Sign(List<EI> hds, X509Certificate2 certificate)
        {
            var errorHd = new Dictionary<int, int>();
            // show wait form            
            var waitForm = new frmWaitForm1();
            waitForm.SetMoreDescription("Đang ký, vui lòng đợi...");
            SplashScreenManager.ShowForm(this, typeof(frmWaitForm1), true, true, false);

            //The Wait Form is opened in a separate thread. To change its Description, use the SetWaitFormDescription method.
            var privateKey = certificate.PrivateKey as RSACryptoServiceProvider;
            for (var i = 0; i < hds.Count; i++)
            {
                var hd = hds[i];
                hd.LANKY = 1;
                var xmlHd = hd.CreateHoaDonXml(certificate);
                xmlHd = SignUtil.SignXmlFile(xmlHd, privateKey);
                hd.HOADON_XML = SignUtil.XmlToByteArray(xmlHd);
                var signResult = 0;
                try
                {
                    using (var ei = new EiBusinessImpl())
                    {
                        signResult = ei.InsertSignedHd(hd);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi DB:" + ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorHd.Add(-1, i);// loi khong bat duoc trong proc
                    return errorHd;
                }
                SplashScreenManager.Default.SendCommand(frmWaitForm1.WaitFormCommand.SetProgress, (i + 1) * 100 / hds.Count);
                //waitForm.setStatusMessage("Đã ký "+(i+1)+"/"+hds.Count+"hóa đơn");
                if (signResult != 0)
                { // if something went wrong, close progress form and return error code
                    SplashScreenManager.CloseForm(false);
                    errorHd.Add(signResult, i);   // oops, loi bat duoc tu proc
                }

            }
            //Close Wait Form
            SplashScreenManager.CloseForm(false);
            errorHd.Add(0, -1);// all Hds is OK
            return errorHd;
        }

        private void gridView1_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

        private void cbKV_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMaDp();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show(getCheckedMaDp());
        }

        private string getCheckedMaDp()
        {
            var checkedDp = "";
            for (int i = 0; i < clbDp.CheckedItems.Count; i++)
            {
                var obj = clbDp.CheckedItems[i];
                System.Type type = obj.GetType();

                var madp = (string)type.GetProperty(Constants.DP_MADP).GetValue(obj, null);
                if (madp != "All")
                {
                    checkedDp += madp;
                    if (i != clbDp.CheckedItems.Count - 1)
                    {
                        checkedDp += ",";
                    }
                }

            }
            return checkedDp;
        }

        private void clbDp_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                for (var i = 1; i < clbDp.Items.Count; i++)
                    clbDp.SetItemCheckState(i, e.NewValue);
            }
        }

        private void ResetGbKy()
        {
            //tbTotal.Text = "0";
            //soHoaDonUC1.Sohoadon = "";
        }

        private void tbMonth_Leave(object sender, EventArgs e)
        {
            if (tbMonth.Text.Length > 0 && tbYear.Text.Length > 0)
            {
                SignUtil.BindKvX(cbKV, tbMonth, tbYear, "--Chọn chi nhánh--", "");
            }
            //BindMaDp();
        }

        private void tbYear_Leave(object sender, EventArgs e)
        {
            if (tbMonth.Text.Length > 0 && tbYear.Text.Length > 0)
            {
                SignUtil.BindKvX(cbKV, tbMonth, tbYear, "--Chọn chi nhánh--", "");
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string test = "";
        }
    }
}
