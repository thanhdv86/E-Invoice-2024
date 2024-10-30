using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using cskh.domain;
using DevExpress.XtraSplashScreen;
using iTextSharp.text;
using iTextSharp.text.pdf;
using XMLSigner.Properties;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;
using Rectangle = iTextSharp.text.Rectangle;

namespace XMLSigner.ui
{
    public partial class frmHDCD : Form
    {
        public frmHDCD()
        {
            InitializeComponent();
        }
        private Font _fontRedBold;
        private Font _fontBlueBold;
        private Font _fontBlackBold;
        private Font _fontRedNomal;
        private Font _fontBlueNomal;
        private Font _fontBlackNomal;
        private Font _fontBlackItalic;
        private Font _fontBlackBoldItalic;
        private void InstallationFont(string fontName)
        {
            var bf = BaseFont.CreateFont(string.Format("{0}Resources\\Font\\{1}.TTF", AppDomain.CurrentDomain.BaseDirectory, fontName), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            _fontRedNomal = new Font(bf) { Size = 12, Color = new BaseColor(Color.Red) };
            //_fontRedNomal.SetStyle(Font.NORMAL);

            _fontBlackNomal = new Font(bf) { Size = 12, Color = new BaseColor(34, 62, 136) };
            //_fontBlackNomal.Color = new BaseColor(40, 40, 41);
            //_fontBlackNomal.SetStyle(Font.NORMAL);

            _fontBlueNomal = new Font(bf) { Size = 12, Color = new BaseColor(34, 62, 136) };
            //_fontBlueNomal.SetStyle(Font.NORMAL);

            bf = BaseFont.CreateFont(string.Format("{0}Resources\\Font\\{1}I.TTF", AppDomain.CurrentDomain.BaseDirectory, fontName), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            _fontBlackItalic = new Font(bf) { Size = 12, Color = new BaseColor(34, 62, 136) };
            //_fontBlackItalic.Color = new BaseColor(40, 40, 41);

            bf = BaseFont.CreateFont(string.Format("{0}Resources\\Font\\{1}BI.TTF", AppDomain.CurrentDomain.BaseDirectory, fontName), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            _fontBlackBoldItalic = new Font(bf) { Size = 12, Color = new BaseColor(34, 62, 136) };
            //_fontBlackBoldItalic.Color = new BaseColor(40, 40, 41);

            bf = BaseFont.CreateFont(string.Format("{0}Resources\\Font\\{1}BD.TTF", AppDomain.CurrentDomain.BaseDirectory, fontName), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            _fontRedBold = new Font(bf) { Size = 14, Color = new BaseColor(Color.Red) };
            //_fontRedBold.SetStyle(Font.NORMAL);

            _fontBlackBold = new Font(bf) { Size = 12, Color = new BaseColor(34, 62, 136) };
            //_fontBlackBold.Color = new BaseColor(40, 40, 41);
            //_fontBlackBold.SetStyle(Font.NORMAL);

            _fontBlueBold = new Font(bf) { Size = 12, Color = new BaseColor(34, 62, 136) };
            //_fontBlueBold.SetStyle(Font.NORMAL);

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmHDCD_Load(object sender, EventArgs e)
        {
            for (var i = DateTime.Now.Year - 4; i <= DateTime.Now.Year; i++)
            {
                cbbNam.Items.Add(i.ToString(CultureInfo.InvariantCulture));
            }
            for (var i = 1; i <= 12; i++)
            {
                cbbThang.Items.Add(i.ToString(CultureInfo.InvariantCulture));
            }
            try
            {
                using (var cbi = new CrBusinessImpl())
                {
                    var dt = cbi.GetKyHd();
                    if ((dt == null) || (dt.Rows.Count <= 0)) return;
                    cbbThang.SelectedItem = dt.Rows[0]["THANG"].ToString();
                    cbbNam.SelectedItem = dt.Rows[0]["NAM"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy xuất dữ liệu:" + ex.Message, "Lỗi [" + ex.InnerException + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cbbNam.SelectedItem) < Systems.NamBatDau)
            {
                MessageBox.Show(string.Format("Hóa đơn trước năm {0}. Xin sử dụng phần mềm cũ", Systems.NamBatDau));
                return;
            }
            if (!KiemTraKyHd())
            {
                MessageBox.Show("Chưa có hóa đơn kỳ này");
                grdEmail.DataSource = null;
                btnSend.Enabled = false;
            }
            else
            {
                LoadHdGiay();
            }
        }
        private bool KiemTraKyHd()
        {
            using (var ebi = new EiBusinessImpl())
            {
                return ebi.KiemTraDaKyHoaDon(Convert.ToInt16(cbbThang.SelectedItem), Convert.ToInt16(cbbNam.SelectedItem));
            }
        }
        private void LoadHdGiay()
        {
            using (var eib = new EiBusinessImpl())
            {
                var dt = eib.GetDsEmail(Convert.ToInt16(cbbThang.SelectedItem), Convert.ToInt16(cbbNam.SelectedItem), "HDGIAY", true);
                if (dt != null && dt.Rows.Count > 0)
                {
                    UtilCustCares.MappingFunction("GetDsHDGiay", ref dt);

                    // Cập nhật Đã in  Hóa đơn điện tử chuyển đổi ra giấy hay chưa?
                    foreach (DataRow row in dt.Rows)
                    {
                        var dtHd = eib.GetHoaDonInfo(row["IDKH"].ToString(), Convert.ToInt16(cbbThang.SelectedItem), Convert.ToInt16(cbbNam.SelectedItem));
                        if (dtHd != null && dtHd.Rows.Count > 0)
                        {
                            row["HDGIAY"] = dtHd.Rows[0]["HDGIAY"];
                            row["NGAYHDGIAY"] = dtHd.Rows[0]["NGAYHDGIAY"];
                            row["NGUOIHDGIAY"] = dtHd.Rows[0]["NGUOIHDGIAY"];
                            row.EndEdit();
                        }
                    }

                    // Cập nhật Hết nợ hay chưa
                    foreach (DataRow row in dt.Rows)
                    {
                        using (var cbi = new CrBusinessImpl())
                        {
                            var dtHetno = cbi.GetHdbyIdkh(row["IDKH"].ToString(), int.Parse(cbbThang.SelectedItem.ToString()), int.Parse(cbbNam.SelectedItem.ToString()));
                            if (dtHetno != null && dtHetno.Rows.Count > 0)
                            {
                                row["HETNO"] = dtHetno.AsEnumerable().Any(c => c.Field<bool>("HETNO").Equals(true));
                                row.EndEdit();
                            }
                        }
                    }
                    grdEmail.DataSource = dt;
                    btnSend.Enabled = true;
                }
                else
                {
                    grdEmail.DataSource = null;
                    btnSend.Enabled = false;
                }
            }

        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            // Gửi đến Email của Quản trị 
            var emailHdGiay = Constants.EmailHDGiay;
            if ((emailHdGiay == null) || !IsValidEmail(emailHdGiay.Trim()))
            {
                MessageBox.Show("Email của Quản trị không có hoặc không chính xác");
                return;
            }
            var selectedindex = gridView1.GetSelectedRows();
            if (selectedindex.Count() < 1)
            {
                MessageBox.Show("Vui lòng chọn danh sách khách hàng gửi hóa đơn");
                return;
            }
            SplashScreenManager.ShowForm(this, typeof(WaitFormEmail), true, true, false);
            foreach (var r in gridView1.GetSelectedRows())
            {
                if (gridView1.IsDataRow(r))
                {
                    var idkh = gridView1.GetRowCellValue(r, "IDKH");
                    if (!bool.Parse(gridView1.GetRowCellValue(r, "HETNO").ToString()))
                    {
                        gridView1.SetRowCellValue(r, "TRANGTHAI", "Khách hàng chưa trả tiền");
                    }
                    else
                    {
                        if (bool.Parse(gridView1.GetRowCellValue(r, "HDGIAY").ToString()))
                        {
                            gridView1.SetRowCellValue(r, "TRANGTHAI", "Không chuyển đổi ra giấy lần 2");
                        }
                        else
                        {
                            var type = bool.Parse(gridView1.GetRowCellValue(r, "HETNO").ToString()) && !bool.Parse(gridView1.GetRowCellValue(r, "HDGIAY").ToString());
                            var ketqua = GuiEmail(idkh.ToString().Trim(), type, emailHdGiay.Trim());
                            gridView1.SetRowCellValue(r, "TRANGTHAI", ketqua);
                            // Cập nhật HDGIAY, NGAYHDGIAY, NGUOIHDGIAY
                            if (ketqua == "Đã gửi xong")
                            {
                                using (var ebi = new EiBusinessImpl())
                                {
                                    if (ebi.UpdateHdgiay(gridView1.GetRowCellValue(r, "IDKH").ToString(),
                                        Convert.ToInt16(cbbNam.SelectedItem.ToString()),
                                        Convert.ToInt16(cbbThang.SelectedItem.ToString()),
                                        "0", frmSignIn.user.RealName) == 1)
                                    {
                                        gridView1.SetRowCellValue(r, "HDGIAY", 1);
                                        gridView1.SetRowCellValue(r, "NGAYHDGIAY", DateTime.Now.ToShortDateString());
                                        gridView1.SetRowCellValue(r, "NGUOIHDGIAY", frmSignIn.user.RealName);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            SplashScreenManager.CloseForm(false);
            MessageBox.Show("Đã xử lý xong!\nHãy vào Hộp thư để In Hóa đơn điện tử chuyển đổi ra giấy, \nKý và Đóng dấu trước khi gửi cho Khách hàng");
        }
        public bool IsValidEmail(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None);
            }
            catch (Exception)
            {
                return false;
            }

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase);
            }
            catch (Exception)
            {
                return false;
            }
        }
        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            var idn = new IdnMapping();

            var domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                return string.Empty;
            }
            return match.Groups[1].Value + domainName;
        }
        private string GuiEmail(string idkh, bool type, string email)
        {
            try
            {
                var hdInfo = new EI(idkh, Convert.ToInt16(cbbThang.SelectedItem.ToString()), Convert.ToInt16(cbbNam.SelectedItem.ToString()));
                if (hdInfo.HOADON_XML == null)
                {
                    return "Chưa ký hóa đơn";
                }
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(Systems.UserNameEmailValue);
                    message.To.Add(email);
                    message.Subject = string.Format("{0} gửi Hóa đơn điện tử chuyển đổi ra giấy kỳ {1} năm {2}", Systems.CompanyValue, hdInfo.KY, hdInfo.NAM);
                    //Tạo nội dung hóa đơn
                    message.Body = TaoHtml(hdInfo);
                    message.IsBodyHtml = true;
                    //Tạo file hóa đơn xml
                    var item = new Attachment(new MemoryStream(hdInfo.HOADON_XML), string.Format("{0}_{1}_{2}.xml", hdInfo.IDKH, hdInfo.KY, hdInfo.NAM), "application/xml");

                    // Chỉ gửi file XML nếu khách hàng đã trả tiền
                    if (type)
                    {
                        message.Attachments.Add(item);
                    }

                    using (var ms = new MemoryStream())
                    {
                        try
                        {
                            const string fontName = "TIMES";
                            InstallationFont(fontName);
                            //Tạo file hóa đơn pdf
                            var document = new Document();
                            //document.SetPageSize(new Rectangle(700f, 550f));
                            document.SetPageSize(new Rectangle(PageSize.A4.Rotate()));
                            document.SetMargins(5f, 5f, 5f, 5f);
                            PdfWriter.GetInstance(document, ms);
                            document.Open();
                            document.Add(TableHeader(hdInfo, type));
                            document.Add(new Phrase("\n"));
                            document.Add(TableCustomerInfo(hdInfo));
                            document.Add(TableContent(hdInfo));
                            document.Close();
                            item = new Attachment(new MemoryStream(ms.GetBuffer()), string.Format("{0}_{1}_{2}.pdf", hdInfo.IDKH, hdInfo.KY, hdInfo.NAM), "application/pdf");
                            message.Attachments.Add(item);

                            using (var client = new SmtpClient())
                            {
                                client.Host = "smtp.gmail.com";
                                client.Port = 587;
                                client.EnableSsl = true;
                                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                                client.UseDefaultCredentials = true;
                                client.Credentials = new NetworkCredential(Systems.UserNameEmailValue, Systems.PasswordEmailValue);
                                //client.TargetName = "STARTTLS/smtp.gmail.com";
                                client.Send(message);
                            }
                        }
                        catch (Exception)
                        {
                            return string.Format("Tạo {0}_{1}_{2}.pdf không được hoặc Gửi không thành công!", hdInfo.IDKH, hdInfo.KY, hdInfo.NAM);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "Gửi không thành công";
            }
            return "Đã gửi xong";
        }
        private string TaoHtml(EI hdInfo)
        {
            var body = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmailTemplate.html"));

            body = body.Replace("{strtenkh}", hdInfo.TENKH);
            body = body.Replace("{strsohoadon}", hdInfo.SOHOADON);
            if (hdInfo.NGAYNHAP != null && hdInfo.NGAYNHAP_TT != null)
                body = body.Replace("{strtungaydenngay}", "Từ: " + hdInfo.NGAYNHAP_TT.Value.ToString("dd/MM/yyyy") + "  Đến: " + hdInfo.NGAYNHAP.Value.ToString("dd/MM/yyyy"));

            body = body.Replace("{strdiachi}", hdInfo.DIACHI);
            body = body.Replace("{strdienthoaikh}", hdInfo.SDT);
            body = body.Replace("{strmstkh}", hdInfo.MST);
            body = body.Replace("{strstkkh}", hdInfo.STK);
            body = body.Replace("{strdanhbo}", hdInfo.SODB);
            body = body.Replace("{strky}", hdInfo.KY.ToString());
            body = body.Replace("{strnam}", hdInfo.NAM.ToString());

            body = body.Replace("{strchisomoi}", hdInfo.CHISOCUOI.ToString());
            body = body.Replace("{strchisocu}", hdInfo.CHISODAU.ToString());
            body = body.Replace("{strm3tieuthu}", hdInfo.KLTIEUTHU.ToString());
            body = body.Replace("{strm3thanhtoan}", hdInfo.M3TINHTIEN.ToString());

            //body = body.Replace("{strm3muc1_cu}", hdInfo.M3MUC1_CU == 0 ? string.Empty : hdInfo.M3MUC1_CU.ToString(CultureInfo.InvariantCulture));
            //body = body.Replace("{strm3muc1}", hdInfo.M3MUC1 == 0 ? string.Empty : hdInfo.M3MUC1.ToString(CultureInfo.InvariantCulture));
            //body = body.Replace("{strgiamuc1_cu}", Math.Abs(hdInfo.GIAMUC1_CU) <= 0 ? string.Empty : hdInfo.GIAMUC1_CU.ToString("##,###"));
            //body = body.Replace("{strgiamuc1}", Math.Abs(hdInfo.GIAMUC1) <= 0 ? string.Empty : hdInfo.GIAMUC1.ToString("##,###"));
            //body = body.Replace("{strtienmuc1_cu}", Math.Abs(hdInfo.TIENMUC1_CU) <= 0 ? string.Empty : hdInfo.TIENMUC1_CU.ToString("##,###"));
            //body = body.Replace("{strtienmuc1}", Math.Abs(hdInfo.TIENMUC1) <= 0 ? string.Empty : hdInfo.TIENMUC1.ToString("##,###"));

            //body = body.Replace("{strm3muc2_cu}", hdInfo.M3MUC2_CU == 0 ? string.Empty : hdInfo.M3MUC2_CU.ToString(CultureInfo.InvariantCulture));
            //body = body.Replace("{strm3muc2}", hdInfo.M3MUC2 == 0 ? string.Empty : hdInfo.M3MUC2.ToString(CultureInfo.InvariantCulture));
            //body = body.Replace("{strgiamuc2_cu}", Math.Abs(hdInfo.GIAMUC2_CU) <= 0 ? string.Empty : hdInfo.GIAMUC2_CU.ToString("##,###"));
            //body = body.Replace("{strgiamuc2}", Math.Abs(hdInfo.GIAMUC2) <= 0 ? string.Empty : hdInfo.GIAMUC2.ToString("##,###"));
            //body = body.Replace("{strtienmuc2_cu}", Math.Abs(hdInfo.TIENMUC2_CU) <= 0 ? string.Empty : hdInfo.TIENMUC2_CU.ToString("##,###"));
            //body = body.Replace("{strtienmuc2}", Math.Abs(hdInfo.TIENMUC2) <= 0 ? string.Empty : hdInfo.TIENMUC2.ToString("##,###"));

            //body = body.Replace("{strm3muc3_cu}", hdInfo.M3MUC3_CU == 0 ? string.Empty : hdInfo.M3MUC3_CU.ToString(CultureInfo.InvariantCulture));
            //body = body.Replace("{strm3muc3}", hdInfo.M3MUC3 == 0 ? string.Empty : hdInfo.M3MUC3.ToString(CultureInfo.InvariantCulture));
            //body = body.Replace("{strgiamuc3_cu}", Math.Abs(hdInfo.GIAMUC3_CU) <= 0 ? string.Empty : hdInfo.GIAMUC3_CU.ToString("##,###"));
            //body = body.Replace("{strgiamuc3}", Math.Abs(hdInfo.GIAMUC3) <= 0 ? string.Empty : hdInfo.GIAMUC3.ToString("##,###"));
            //body = body.Replace("{strtienmuc3_cu}", Math.Abs(hdInfo.TIENMUC3_CU) <= 0 ? string.Empty : hdInfo.TIENMUC3_CU.ToString("##,###"));
            //body = body.Replace("{strtienmuc3}", Math.Abs(hdInfo.TIENMUC3) <= 0 ? string.Empty : hdInfo.TIENMUC3.ToString("##,###"));

            //body = body.Replace("{strm3muc4_cu}", hdInfo.M3MUC4_CU == 0 ? string.Empty : hdInfo.M3MUC4_CU.ToString(CultureInfo.InvariantCulture));
            //body = body.Replace("{strm3muc4}", hdInfo.M3MUC4 == 0 ? string.Empty : hdInfo.M3MUC4.ToString(CultureInfo.InvariantCulture));
            //body = body.Replace("{strgiamuc4_cu}", Math.Abs(hdInfo.GIAMUC4_CU) <= 0 ? string.Empty : hdInfo.GIAMUC4_CU.ToString("##,###"));
            //body = body.Replace("{strgiamuc4}", Math.Abs(hdInfo.GIAMUC4) <= 0 ? string.Empty : hdInfo.GIAMUC4.ToString("##,###"));
            //body = body.Replace("{strtienmuc4_cu}", Math.Abs(hdInfo.TIENMUC4_CU) <= 0 ? string.Empty : hdInfo.TIENMUC4_CU.ToString("##,###"));
            //body = body.Replace("{strtienmuc4}", Math.Abs(hdInfo.TIENMUC4) <= 0 ? string.Empty : hdInfo.TIENMUC4.ToString("##,###"));

            body = body.Replace("{strtiennuocthue}", Math.Abs(hdInfo.TIENNUOC) <= 0 ? string.Empty : hdInfo.TIENTHUE.ToString("##,###"));
            body = body.Replace("{strtiengtgt}", Math.Abs(hdInfo.TIENTHUE) <= 0 ? string.Empty : hdInfo.TIENTHUE.ToString("##,###"));
            body = body.Replace("{strtienmoitruong}", Math.Abs(hdInfo.TIENPHITNMT) <= 0 ? string.Empty : hdInfo.TIENPHITNMT.ToString("##,###"));
            body = body.Replace("{strtongtien}", Math.Abs(hdInfo.TONGTIEN) <= 0 ? string.Empty : hdInfo.TONGTIEN.ToString("##,###"));
            body = body.Replace("{strtienbangchu}", hdInfo.TONGTIENTEXT);

            body = body.Replace("{strngayky}", "Ngày " + hdInfo.NGAYKY.Day + " Tháng " + hdInfo.NGAYKY.Month + " Năm " + hdInfo.NGAYKY.Year);

            return body;

        }
        private PdfPTable TableHeader(EI infoHoaDon, bool type)
        {
            var tblHeader = new PdfPTable(3);
            tblHeader.SetWidths(new[] { 20f, 55f, 25f });
            tblHeader.WidthPercentage = 100f;

            var gif = Image.GetInstance(string.Format("{0}Resources/{1}", AppDomain.CurrentDomain.BaseDirectory, (Int32.Parse(infoHoaDon.NAM.ToString()) < 2017) ? "logo-huewaco.png" : "logo-huewacoCTCP.png"));

            gif.ScalePercent(60);
            var cell = new PdfPCell(gif)
            {
                Rowspan = 3,
                BorderWidth = 0,
                VerticalAlignment = Element.ALIGN_TOP,
                HorizontalAlignment = Element.ALIGN_CENTER
            };
            //cell.AddElement(gif);
            tblHeader.AddCell(cell);

            cell = new PdfPCell(new Phrase((Int32.Parse(infoHoaDon.NAM.ToString()) < 2017) ? Systems.CompanyValue1 : Systems.CompanyValue, _fontBlueBold))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                Colspan = 2,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);

            var phrase = new Phrase
            {
                new Chunk(string.Format("MST: {0}", Systems.TaxCodeValue), _fontBlueNomal),
                new Chunk(string.Format("\nĐC: {0}", Systems.AddressValue), _fontBlueNomal)
            };
            cell = new PdfPCell(phrase)
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);

            phrase = new Phrase
            {
                new Chunk(string.Format("TK: {0}",Systems.AccountNumberValue), _fontBlueNomal),
                new Chunk(string.Format("\nTại: {0}", Systems.BankValue), _fontBlueNomal)
            };
            cell = new PdfPCell(phrase)
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);

            phrase = new Phrase();
            if (type)
            {
                phrase.Add(new Chunk("\nHÓA ĐƠN GIÁ TRỊ GIA TĂNG", _fontBlueBold));
                phrase.Add(new Chunk("\n(Hóa đơn chuyển đổi từ Hóa đơn điện tử)", _fontBlueBold));
                phrase.Add(new Chunk("\nTừ: " + (infoHoaDon.NGAYNHAP_TT.HasValue ? infoHoaDon.NGAYNHAP_TT.Value.ToString("dd/MM/yyyy") : ""), _fontBlueNomal));
                phrase.Add(new Chunk(" Đến: " + (infoHoaDon.NGAYNHAP.HasValue ? infoHoaDon.NGAYNHAP.Value.ToString("dd/MM/yyyy") : ""), _fontBlueNomal));
            }
            else
            {
                phrase.Add(new Chunk("\nGIẤY BÁO THANH TOÁN TIỀN NƯỚC", _fontBlueBold));
                phrase.Add(new Chunk("\n(Giấy báo này không thay thế cho hóa đơn tiền nước)", _fontBlueNomal));
                phrase.Add(new Chunk("\nTừ: " + (infoHoaDon.NGAYNHAP_TT.HasValue ? infoHoaDon.NGAYNHAP_TT.Value.ToString("dd/MM/yyyy") : ""), _fontBlueNomal));
                phrase.Add(new Chunk(" Đến: " + (infoHoaDon.NGAYNHAP.HasValue ? infoHoaDon.NGAYNHAP.Value.ToString("dd/MM/yyyy") : ""), _fontBlueNomal));
            }
            phrase.Add(new Chunk("\n", _fontBlueNomal));

            cell = new PdfPCell(phrase)
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);

            phrase = new Phrase();
            if (type)
            {
                //phrase.Add(new Chunk((Int32.Parse(infoHoaDon.NAM.ToString()) < 2017) ? "Mẫu: 01GTKT0/001" : "Mẫu: 01GTKT0/002", _fontBlueNomal));
                phrase.Add(new Chunk(string.Format("Mẫu: {0}", infoHoaDon.MAUHOADON), _fontBlueNomal));
                phrase.Add(new Chunk(string.Format("\nKý hiệu: {0}", infoHoaDon.KIHIEUHOADON), _fontBlueNomal));
                phrase.Add(new Chunk(string.Format("\nSố: {0}", infoHoaDon.SOHOADON), _fontBlueBold));
            }
            else
            {
                phrase.Add(new Chunk("Trung tâm CSKH: " + Systems.PhoneCCCValue, _fontBlueNomal));
                phrase.Add(new Chunk("\nSố: " + infoHoaDon.SOHOADON, _fontBlueBold));
            }

            cell = new PdfPCell(phrase)
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);

            return tblHeader;

        }
        private PdfPTable TableCustomerInfo(EI infoHoaDon)
        {
            var tblHeader = new PdfPTable(3);
            tblHeader.SetWidths(new[] { 20f, 40f, 40f });
            tblHeader.WidthPercentage = 100f;
            // 1
            var cell = new PdfPCell(new Phrase("Khách hàng: ", _fontBlueNomal))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);

            cell = new PdfPCell(new Phrase(infoHoaDon.TENKH, _fontBlueBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_TOP,
                Colspan = 2,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);
            // 2
            cell = new PdfPCell(new Phrase("Địa chỉ: ", _fontBlueNomal))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);

            cell = new PdfPCell(new Phrase(infoHoaDon.DIACHI, _fontBlueBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_TOP,
                Colspan = 2,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);
            // 3
            cell = new PdfPCell(new Phrase("Điện thoại: ", _fontBlueNomal))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);

            cell = new PdfPCell(new Phrase(infoHoaDon.SDT, _fontBlueNomal))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);

            cell = new PdfPCell(new Phrase(string.Format("Mã số thuế: {0}", infoHoaDon.MST), _fontBlueNomal))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);
            // 4
            cell = new PdfPCell(new Phrase("Tài khoản: ", _fontBlueNomal))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);

            cell = new PdfPCell(new Phrase(infoHoaDon.STK, _fontBlueNomal))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);

            // Khi thiết kế mẫu thì có Tại ngân hàng.
            // Nhưng không có dữ liệu để in cả bên QLKH cũng như bên HDDT???
            // 
            cell = new PdfPCell(new Phrase("Tại: ", _fontBlueNomal))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);
            // 5
            cell = new PdfPCell(new Phrase("Danh bộ: ", _fontBlueNomal))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);

            cell = new PdfPCell(new Phrase(infoHoaDon.SODB, _fontBlueNomal))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);

            cell = new PdfPCell(new Phrase(String.Format("Kỳ thanh toán: {0} Năm: {1}", infoHoaDon.KY, infoHoaDon.NAM), _fontBlueNomal))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0
            };
            tblHeader.AddCell(cell);

            return tblHeader;

        }
        private PdfPTable TableContent(EI hdInfo)
        {

            var table = new PdfPTable(12) { HeaderRows = 1, WidthPercentage = 100f };
            var cell = new PdfPCell(new Phrase("Chỉ số mới", _fontBlackNomal))
            {
                Colspan = 3,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthTop = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Chỉ số cũ", _fontBlackNomal))
            {
                Colspan = 3,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthTop = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Số m3 tiêu thụ", _fontBlackNomal))
            {
                Colspan = 3,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthTop = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Số m3 thanh toán", _fontBlackNomal))
            {
                Colspan = 3,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthTop = 0.005f,
                BorderWidthRight = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(hdInfo.CHISOCUOI.ToString(), _fontBlackNomal))
            {
                Colspan = 3,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthTop = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(hdInfo.CHISODAU.ToString(), _fontBlackNomal))
            {
                Colspan = 3,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthTop = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(hdInfo.KLTIEUTHU.ToString(), _fontBlackNomal))
            {
                Colspan = 3,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthTop = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(hdInfo.M3TINHTIEN.ToString(), _fontBlackNomal))
            {
                Colspan = 3,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthTop = 0.005f,
                BorderWidthRight = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Mức sử dụng (m3)", _fontBlackNomal))
            {
                Colspan = 3,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthTop = 0.005f,
                BorderWidthBottom = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Đơn giá (đ/m3)", _fontBlackNomal))
            {
                Colspan = 3,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthTop = 0.005f,
                BorderWidthBottom = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Thành tiền (đ)", _fontBlackNomal))
            {
                Colspan = 6,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthTop = 0.005f,
                BorderWidthBottom = 0.005f,
                BorderWidthRight = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);
            var sodong = 0;
            // Muc 1
            if ((decimal.Parse(hdInfo.TIENMUC1_CU.ToString()) > 0) || (decimal.Parse(hdInfo.TIENMUC1.ToString()) > 0))
            {
                sodong = sodong + 1;
                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC1_CU.ToString()) == 0 ? "" : hdInfo.M3MUC1_CU.ToString(), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC1.ToString()) == 0 ? "" : hdInfo.M3MUC1.ToString(), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC1_CU.ToString()) == 0 ? "" : hdInfo.GIAMUC1_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC1.ToString()) == 0 ? "" : hdInfo.GIAMUC1.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC1_CU.ToString()) == 0 ? "" : hdInfo.TIENMUC1_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC1.ToString()) == 0 ? "" : hdInfo.TIENMUC1.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthRight = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f
                };
                table.AddCell(cell);
            }
            //Muc2
            if ((decimal.Parse(hdInfo.TIENMUC2_CU.ToString()) > 0) || (decimal.Parse(hdInfo.TIENMUC2.ToString()) > 0))
            {
                sodong = sodong + 1;
                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC2_CU.ToString()) == 0 ? "" : hdInfo.M3MUC2_CU.ToString(), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC2.ToString()) == 0 ? "" : hdInfo.M3MUC2.ToString(), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC2_CU.ToString()) == 0 ? "" : hdInfo.GIAMUC2_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC2.ToString()) == 0 ? "" : hdInfo.GIAMUC2.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC2_CU.ToString()) == 0 ? "" : hdInfo.TIENMUC2_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC2.ToString()) == 0 ? "" : hdInfo.TIENMUC2.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthRight = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f
                };
                table.AddCell(cell);
            }
            //Muc 3
            if ((decimal.Parse(hdInfo.TIENMUC3_CU.ToString()) > 0) || (decimal.Parse(hdInfo.TIENMUC3.ToString()) > 0))
            {
                sodong = sodong + 1;
                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC3_CU.ToString()) == 0 ? "" : hdInfo.M3MUC3_CU.ToString(), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC3.ToString()) == 0 ? "" : hdInfo.M3MUC3.ToString(), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC3_CU.ToString()) == 0 ? "" : hdInfo.GIAMUC3_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC3.ToString()) == 0 ? "" : hdInfo.GIAMUC3.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC3_CU.ToString()) == 0 ? "" : hdInfo.TIENMUC3_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC3.ToString()) == 0 ? "" : hdInfo.TIENMUC3.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthRight = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f
                };
                table.AddCell(cell);
            }
            //Muc 4
            if ((decimal.Parse(hdInfo.TIENMUC4_CU.ToString()) > 0) || (decimal.Parse(hdInfo.TIENMUC4.ToString()) > 0))
            {
                sodong = sodong + 1;
                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC4_CU.ToString()) == 0 ? "" : hdInfo.M3MUC4_CU.ToString(), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC4.ToString()) == 0 ? "" : hdInfo.M3MUC4.ToString(), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC4_CU.ToString()) == 0 ? "" : hdInfo.GIAMUC4_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC4.ToString()) == 0 ? "" : hdInfo.GIAMUC4.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC4_CU.ToString()) == 0 ? "" : hdInfo.TIENMUC4_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC4.ToString()) == 0 ? "" : hdInfo.TIENMUC4.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthRight = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f,
                };
                table.AddCell(cell);
            }
            //Muc 5
            if ((decimal.Parse(hdInfo.TIENMUC5_CU.ToString()) > 0) || (decimal.Parse(hdInfo.TIENMUC5.ToString()) > 0))
            {
                sodong = sodong + 1;
                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC5_CU.ToString()) == 0 ? "" : hdInfo.M3MUC5_CU.ToString(), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC5.ToString()) == 0 ? "" : hdInfo.M3MUC5.ToString(), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC5_CU.ToString()) == 0 ? "" : hdInfo.GIAMUC5_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC5.ToString()) == 0 ? "" : hdInfo.GIAMUC5.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC5_CU.ToString()) == 0 ? "" : hdInfo.TIENMUC5_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC5.ToString()) == 0 ? "" : hdInfo.TIENMUC5.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthRight = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f,
                };
                table.AddCell(cell);
            }
            //Muc 6
            if ((decimal.Parse(hdInfo.TIENMUC6_CU.ToString()) > 0) || (decimal.Parse(hdInfo.TIENMUC6.ToString()) > 0))
            {
                sodong = sodong + 1;
                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC6_CU.ToString()) == 0 ? "" : hdInfo.M3MUC6_CU.ToString(), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC6.ToString()) == 0 ? "" : hdInfo.M3MUC6.ToString(), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC6_CU.ToString()) == 0 ? "" : hdInfo.GIAMUC6_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC6.ToString()) == 0 ? "" : hdInfo.GIAMUC6.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC6_CU.ToString()) == 0 ? "" : hdInfo.TIENMUC6_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC6.ToString()) == 0 ? "" : hdInfo.TIENMUC6.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthRight = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f,
                };
                table.AddCell(cell);
            }
            //Muc 7
            if ((decimal.Parse(hdInfo.TIENMUC7_CU.ToString()) > 0) || (decimal.Parse(hdInfo.TIENMUC7.ToString()) > 0))
            {
                sodong = sodong + 1;
                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC7_CU.ToString()) == 0 ? "" : hdInfo.M3MUC7_CU.ToString(), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC7.ToString()) == 0 ? "" : hdInfo.M3MUC7.ToString(), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC7_CU.ToString()) == 0 ? "" : hdInfo.GIAMUC7_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC7.ToString()) == 0 ? "" : hdInfo.GIAMUC7.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC7_CU.ToString()) == 0 ? "" : hdInfo.TIENMUC7_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC7.ToString()) == 0 ? "" : hdInfo.TIENMUC7.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthRight = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f,
                };
                table.AddCell(cell);
            }
            //Muc 8
            if ((decimal.Parse(hdInfo.TIENMUC8_CU.ToString()) > 0) || (decimal.Parse(hdInfo.TIENMUC8.ToString()) > 0))
            {
                sodong = sodong + 1;
                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC8_CU.ToString()) == 0 ? "" : hdInfo.M3MUC8_CU.ToString(), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.M3MUC8.ToString()) == 0 ? "" : hdInfo.M3MUC8.ToString(), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC8_CU.ToString()) == 0 ? "" : hdInfo.GIAMUC8_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 2,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC8.ToString()) == 0 ? "" : hdInfo.GIAMUC8.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 1,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderColor = new BaseColor(34, 62, 136)
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC8_CU.ToString()) == 0 ? "" : hdInfo.TIENMUC8_CU.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthLeft = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f
                };
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(decimal.Parse(hdInfo.TIENMUC8.ToString()) == 0 ? "" : hdInfo.TIENMUC8.ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal))
                {
                    Colspan = 3,
                    MinimumHeight = 20,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BorderWidth = 0,
                    BorderWidthRight = 0.005f,
                    BorderColor = new BaseColor(34, 62, 136),
                    PaddingRight = 10f,
                };
                table.AddCell(cell);
            }

            if (sodong < 5)
            {
                for (int i = 1; i < 5 - sodong; i++)
                {
                    cell = new PdfPCell(new Phrase("", _fontBlackNomal))
                    {
                        Colspan = 1,
                        MinimumHeight = 20,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        BorderWidth = 0,
                        BorderWidthLeft = 0.005f,
                        BorderColor = new BaseColor(34, 62, 136)
                    };
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", _fontBlackNomal))
                    {
                        Colspan = 2,
                        MinimumHeight = 20,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        BorderWidth = 0,
                        BorderColor = new BaseColor(34, 62, 136)
                    };
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", _fontBlackNomal))
                    {
                        Colspan = 2,
                        MinimumHeight = 20,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        BorderWidth = 0,
                        BorderColor = new BaseColor(34, 62, 136)
                    };
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", _fontBlackNomal))
                    {
                        Colspan = 1,
                        MinimumHeight = 20,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        BorderWidth = 0,
                        BorderColor = new BaseColor(34, 62, 136)
                    };
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", _fontBlackNomal))
                    {
                        Colspan = 3,
                        MinimumHeight = 20,
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        BorderWidth = 0,
                        BorderWidthLeft = 0.005f,
                        BorderColor = new BaseColor(34, 62, 136),
                        PaddingRight = 10f
                    };
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("", _fontBlackNomal))
                    {
                        Colspan = 3,
                        MinimumHeight = 20,
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        BorderWidth = 0,
                        BorderWidthRight = 0.005f,
                        BorderColor = new BaseColor(34, 62, 136),
                        PaddingRight = 10f,
                    };
                    table.AddCell(cell);
                }
            }

            cell = new PdfPCell(new Phrase("- Tiền nước phải tính thuế: ", _fontBlackNomal))
            {
                Colspan = 6,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthTop = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(new Chunk(hdInfo.TIENNUOC.ToString("0,0;-0,0;0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal)))
            {
                Colspan = 6,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthTop = 0.005f,
                BorderWidthRight = 0.005f,
                BorderColor = new BaseColor(34, 62, 136),
                PaddingRight = 10f
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("- Tiền thuế giá trị gia tăng (5%): ", _fontBlackNomal))
            {
                Colspan = 6,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                //BorderWidthTop = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(new Chunk(hdInfo.TIENTHUE.ToString("0,0;-0,0;0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal)))
            {
                Colspan = 6,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                //BorderWidthTop = 0.005f,
                BorderWidthRight = 0.005f,
                BorderColor = new BaseColor(34, 62, 136),
                PaddingRight = 10f
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase((Int32.Parse(hdInfo.NAM.ToString()) < 2019) ? "- Phí thoát nước + MT Rừng: " : "- Phí BVMT + MT Rừng: ", _fontBlackNomal))
            {
                Colspan = 6,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                //BorderWidthTop = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(new Chunk(hdInfo.TIENPHITNMT.ToString("0,0;-0,0;0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackNomal)))
            {
                Colspan = 6,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                //BorderWidthTop = 0.005f,
                BorderWidthRight = 0.005f,
                BorderColor = new BaseColor(34, 62, 136),
                PaddingRight = 10f
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("- Tổng tiền thanh toán:", _fontBlackBold))
            {
                Colspan = 6,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                //BorderWidthTop = 0.005f,
                BorderWidthBottom = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(new Chunk(hdInfo.TONGTIEN.ToString("0,0;-0,0;0", CultureInfo.CreateSpecificCulture(("el-GR"))), _fontBlackBold)))
            {
                Colspan = 6,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                //BorderWidthTop = 0.005f,
                BorderWidthRight = 0.005f,
                BorderWidthBottom = 0.005f,
                BorderColor = new BaseColor(34, 62, 136),
                PaddingRight = 10f
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("  Bằng chữ:", _fontBlackBold))
            {
                Colspan = 2,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthBottom = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(hdInfo.TONGTIENTEXT, _fontBlackBoldItalic))
            {
                Colspan = 10,
                MinimumHeight = 20,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                //BorderWidthTop = 0.005f,
                BorderWidthBottom = 0.005f,
                BorderWidthRight = 0.005f,
                BorderColor = new BaseColor(34, 62, 136),
                PaddingRight = 10f
            };
            table.AddCell(cell);

            // Đặc thù của hóa đơn chuyển đổi
            var ngaychuyendoi = DateTime.Now;
            cell = new PdfPCell(new Phrase(string.Format("Ngày chuyển đổi: Ngày {0} tháng {1} năm {2}", ngaychuyendoi.Day, ngaychuyendoi.Month, ngaychuyendoi.Year), _fontBlackNomal))
            {
                Colspan = 5,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                //BorderWidthTop = 0.005f,
                //BorderWidthRight = 0.005f,                
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            // Ngày ký không phải là Ngày nhập!!!
            // Kể từ Kỳ áp dụng mới sẽ lấy Ngày ký để đưa vào ở đây. 
            // Còn các Kỳ trước đây vẫn sử dụng Ngày nhập để các HĐĐT đã in trước đây không bị sai lệch!
            var ngayky = (Int32.Parse(hdInfo.NAM.ToString()) < 2019) ? DateTime.Parse(hdInfo.NGAYNHAP.ToString()) : DateTime.Parse(hdInfo.NGAYKY.ToString());
            cell = new PdfPCell(new Phrase(string.Format("Ngày ký: Ngày {0} tháng {1} năm {2}", ngayky.Day, ngayky.Month, ngayky.Year), _fontBlackBold))
            {
                Colspan = 7,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                //BorderWidthLeft = 0.005f,
                //BorderWidthTop = 0.005f,
                BorderWidthRight = 0.005f,
                //BorderWidthBottom = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(string.Format("Người chuyển đổi: {0}", frmSignIn.user.RealName.ToUpper()), _fontBlackNomal))
            {
                Colspan = 5,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                //BorderWidthTop = 0.005f,
                //BorderWidthRight = 0.005f,
                //BorderWidthBottom = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            //cell = new PdfPCell(new Phrase(string.Format("Người ký: {0}", hdInfo.CTYTEN), _fontBlackBold))
            cell = new PdfPCell(new Phrase(string.Format("Người ký: {0}", ((Int32.Parse(hdInfo.NAM.ToString()) < 2017) ? Systems.CompanyValue1 : Systems.CompanyValue)), _fontBlackBold))
            {
                Colspan = 7,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_TOP,
                BorderWidth = 0,
                //BorderWidthLeft = 0.005f,
                //BorderWidthTop = 0.005f,
                BorderWidthRight = 0.005f,
                //BorderWidthBottom = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(" ", _fontBlackNomal))
            {
                Colspan = 12,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                //BorderWidthTop = 0.005f,
                BorderWidthRight = 0.005f,
                //BorderWidthBottom = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(" ", _fontBlackNomal))
            {
                Colspan = 12,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                //BorderWidthTop = 0.005f,
                BorderWidthRight = 0.005f,
                //BorderWidthBottom = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(" ", _fontBlackNomal))
            {
                Colspan = 12,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                //BorderWidthTop = 0.005f,
                BorderWidthRight = 0.005f,
                //BorderWidthBottom = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(" ", _fontBlackNomal))
            {
                Colspan = 12,
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                //BorderWidthTop = 0.005f,
                BorderWidthRight = 0.005f,
                BorderWidthBottom = 0.005f,
                BorderColor = new BaseColor(34, 62, 136)
            };
            table.AddCell(cell);

            return table;
        }
    }
}
