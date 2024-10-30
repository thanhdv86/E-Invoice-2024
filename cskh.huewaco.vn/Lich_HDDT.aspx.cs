using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using cskh.domain;
using DocumentGeneration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Ionic.Zip;
using Font = iTextSharp.text.Font;
using Rectangle = iTextSharp.text.Rectangle;

namespace cskh.huewaco.vn
{
    public partial class Lich_HDDT : CsBaseControl
    {
        protected User objUser = new User(HttpContext.Current.User.Identity.Name);
        protected string htmlContent = string.Empty;
        protected string pMa_KH;
        //protected string pTen_KH;
        //protected string pSo_HD;
        //protected string pLoai_KH;
        //protected string pDchi_KH;
        protected void LoadInfo()
        {
            ddlKy.SelectedValue = DateTime.Now.Month.ToString();
            ddlNam.SelectedValue = DateTime.Now.Year.ToString();

            lblMaKH.Text = objUser.ContractNumber;
            lblTenKH.Text = objUser.CustomerName;
            lblDiaChi.Text = objUser.DiaChi;
            lblMaDB.Text = objUser.MaDanhBo;
            lblMaLo.Text = objUser.MaLoTrinh;

            fsdetail.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Response.AddHeader("Cache-Control", "max-age=0,no-cache,no-store,must-revalidate");
                for (var i = DateTime.Now.Year - 4; i <= DateTime.Now.Year; i++)
                {
                    ddlNam.Items.Add(i.ToString());
                }

                for (var i = 1; i <= 12; i++)
                {
                    ddlKy.Items.Add(i.ToString());
                }

                ddlKy.SelectedValue = DateTime.Now.Month.ToString();
                ddlNam.SelectedValue = DateTime.Now.Year.ToString();

                LoadInfo();
                LoaHdsd();
                return;

            }
            var action = Request.Form["action"];
            if (string.IsNullOrEmpty(action))
            {
                return;
            }
            var arrRequest = action.Split('|');
            action = arrRequest[0];
            //var intLan = int.Parse(arrRequest[1]);
            var idkh = arrRequest[1];
            switch (action)
            {
                case "lkbThongBao":
                    lkbThongBao_OnClick(idkh);
                    break;

                case "lkbXemHD":
                    lkbXemHD_OnClick(idkh);
                    break;

                case "lkbTaiHD":
                    lkbTaiHD_OnClick(idkh);
                    break;
            }

        }


        protected void LoaHdsd()
        {
            using (var ei = new EiBusinessImpl())
            {
                var dt = ei.GetHdsdbyId("2");
                lblContentTaiHoaDon.Text = dt.Rows[0]["NoiDung"].ToString();
                dt = ei.GetHdsdbyId("3");
                lblContentInHoaDon.Text = dt.Rows[0]["NoiDung"].ToString();
            }
        }
        #region MultiLanguages
        public override void SetUI()
        {
            //strImages = getString("imgGioithieu");
            //strGioithieu1 = getString("strGioithieu1");
            //strGioithieu2 = getString("strGioithieu2");
        }
        #endregion
        #region RenderingEvent
        protected override void OnInit(EventArgs e)
        {
            //Response.AddHeader("Cache-Control", "max-age=0,no-cache,no-store,must-revalidate");
            //Response.AddHeader("Pragma", "no-cache");
            //Response.AddHeader("Expires", "Tue, 01 Jan 1970 00:00:00 GMT");
            Load += Page_Load;
        }
        #endregion
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
            var bf = BaseFont.CreateFont(Server.MapPath(string.Format("~/font/{0}.ttf", fontName)), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            _fontRedNomal = new Font(bf) { Size = 12, Color = new BaseColor(Color.Red) };

            _fontBlackNomal = new Font(bf) { Size = 12, Color = new BaseColor(34, 62, 136) };

            _fontBlueNomal = new Font(bf) { Size = 12, Color = new BaseColor(34, 62, 136) };

            bf = BaseFont.CreateFont(Server.MapPath(string.Format("~/font/{0}i.ttf", fontName)), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            _fontBlackItalic = new Font(bf) { Size = 12, Color = new BaseColor(34, 62, 136) };

            bf = BaseFont.CreateFont(Server.MapPath(string.Format("~/font/{0}bi.ttf", fontName)), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            _fontBlackBoldItalic = new Font(bf) { Size = 12, Color = new BaseColor(34, 62, 136) };

            bf = BaseFont.CreateFont(Server.MapPath(string.Format("~/font/{0}bd.ttf", fontName)), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            _fontRedBold = new Font(bf) { Size = 14, Color = new BaseColor(Color.Red) };
            _fontBlackBold = new Font(bf) { Size = 12, Color = new BaseColor(34, 62, 136) };
            _fontBlueBold = new Font(bf) { Size = 12, Color = new BaseColor(34, 62, 136) };

        }
        public void DownloadFiles(string foldername, string filename)
        {
            Response.Clear();
            Response.BufferOutput = false;
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "attachment; filename=" + filename + ".zip");
            using (var zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectory(foldername);
                zip.Save(Response.OutputStream);
            }
            Response.End();
            Response.Close();
        }
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {

            if (int.Parse(ddlNam.SelectedValue) < Systems.NamBatDau)
            {
                Globals.ShowPopUpMsg(Page, string.Format("Hóa đơn trước năm {0}. Xin mời nhắp vào liên kết bên dưới", Systems.NamBatDau));
                return;
            }
            pMa_KH = objUser.ContractNumber;
            using (var eib = new EiBusinessImpl())
            {
                var dt = eib.GetHoaDonInfo(objUser.ContractNumber.Trim(), int.Parse(ddlKy.SelectedValue), int.Parse(ddlNam.SelectedValue));
                if (dt != null && dt.Rows.Count > 0)
                {
                    UtilCustCares.MappingFunction("getHoaDonInfo", ref dt);
                    using (var cr = new CrBusinessImpl())
                    {
                        var dtHetno = cr.GetHdbyIdkh(objUser.ContractNumber.Trim(), int.Parse(ddlKy.SelectedValue), int.Parse(ddlNam.SelectedValue));
                        if (dtHetno != null && dtHetno.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (dtHetno.AsEnumerable().Any(c => c.Field<bool>("HETNO").Equals(true)))
                                {
                                    row["HETNO"] = true;
                                    row.EndEdit();
                                }
                            }


                            divKetQua.Visible = true;
                            lbNotic.Text = "";
                            ViewState["HDDT"] = dt;

                            foreach (DataRow item in dt.Rows)
                            {
                                htmlContent +=
                                    string.Format("<tr class='gvtabletd' style='height: 22px;'>"
                                                  +
                                                  "<td style='width: 50px;' align='center'>{0}</td>"
                                                  + "<td style='width: 50px;' align='center'>{1}</td>"
                                                  + "<td style='width: 50px;' align='center'>{2}</td>"
                                                  + "<td style='width: 50px;' align='center'>{3}</td>"
                                                  + "<td style='width: 50px;' align='center'>{4}</td>"
                                                  + "<td style='width: 50px;' align='center'>{5}</td>"
                                                  + "<td style='width: 50px;' align='center'>{6}</td>"
                                                  + "<td align='center'><button type='submit' name='action' value='lkbThongBao|{7}'/>Xem TB</td>{8}</tr>",
                                        item["IDKH"],
                                        item["SOHOADON"],
                                        decimal.Parse(item["KLTIEUTHU"].ToString())
                                            .ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                                        decimal.Parse(item["TIENNUOC"].ToString())
                                            .ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                                        decimal.Parse(item["TIENTHUE"].ToString())
                                            .ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                                        decimal.Parse(item["TIENPHITNMT"].ToString())
                                            .ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                                        decimal.Parse(item["TONGTIEN"].ToString())
                                            .ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                                        item["IDKH"],
                                        (bool.Parse(item["HETNO"].ToString()))
                                            ? string.Format("<td align='center'><button type='submit' name='action' value='lkbXemHD|{0}'/>Xem HĐ</td><td align='center'><button type='submit' name='action' value='lkbTaiHD|{0}'/>Hóa đơn</td>", item["IDKH"])
                                            : "<td align='center' Colspan = 2 ><span style='color: Red'>Bạn phải thanh toán tiền <br/>để có thể xem và tải hóa đơn</span></td>"
                                                );
                            }
                        }
                        else
                        {
                            divKetQua.Visible = false;
                            lbNotic.Text = "Dữ liệu cũ đã chuyển sang lưu trữ. Vui lòng liên hệ Phòng Công nghệ Thông tin để được cung cấp HĐĐT";
                            lbNotic.Visible = true;
                        }
                    }
                }
                else
                {
                    divKetQua.Visible = false;
                    lbNotic.Text = " Không có thông tin hóa đơn.";
                    lbNotic.Visible = true;
                }

            }
        }
        private PdfPTable TableHeader(EI infoHoaDon, bool type)
        {
            var tblHeader = new PdfPTable(3);
            tblHeader.SetWidths(new[] { 20f, 55f, 25f });
            tblHeader.WidthPercentage = 100f;

            var gif = iTextSharp.text.Image.GetInstance(Server.MapPath((Int32.Parse(infoHoaDon.NAM.ToString()) < 2017) ? "~/Images/logo-huewaco.png" : "~/Images/logo-huewacoCTCP.png"));

            gif.ScalePercent(60);
            var cell = new PdfPCell(gif)
            {
                Rowspan = 3,
                BorderWidth = 0,
                VerticalAlignment = Element.ALIGN_TOP,
                HorizontalAlignment = Element.ALIGN_CENTER
            };
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
                phrase.Add(new Chunk("\n(Bản thể hiện của hóa đơn điện tử)", _fontBlueBold));
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

            var phrase = new Phrase();
            // Ngày ký không phải là Ngày nhập!!!
            // Kể từ Kỳ áp dụng mới sẽ lấy Ngày ký để đưa vào ở đây. 
            // Còn các Kỳ trước đây vẫn sử dụng Ngày nhập để các HĐĐT đã in trước đây không bị sai lệch!
            var ngayky = (Int32.Parse(hdInfo.NAM.ToString()) < 2019) ? DateTime.Parse(hdInfo.NGAYNHAP.ToString()) : DateTime.Parse(hdInfo.NGAYKY.ToString());
            phrase.Add(new Chunk(string.Format("Ngày {0} Tháng {1} Năm {2}", ngayky.Day, ngayky.Month, ngayky.Year), _fontBlackBold));
            phrase.Add(new Chunk(string.Format("\n(Người ký: {0})", ((Int32.Parse(hdInfo.NAM.ToString()) < 2017) ? Systems.CompanyValue1 : Systems.CompanyValue)), _fontBlackBold));
            cell = new PdfPCell(phrase)
            {
                Colspan = 12,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderWidth = 0,
                BorderWidthLeft = 0.005f,
                BorderWidthRight = 0.005f,
                BorderWidthBottom = 0.005f,
                BorderColor = new BaseColor(34, 62, 136),
                PaddingRight = 10f
            };
            table.AddCell(cell);
            return table;

        }
        private void GenPagePdf(EI hdInfo, bool type, bool isDownload)
        {
            const string fontName = "TIMES";
            InstallationFont(fontName);

            using (var ms = new MemoryStream())
            {
                var document = new DocumentGen();
                //document.SetPageSize(new Rectangle(700f, 550f));
                document.SetPageSize(new Rectangle(PageSize.A4.Rotate()));
                document.SetMargins(5f, 5f, 5f, 5f);
                PdfWriter.GetInstance(document, ms);
                document.Open();
                document.Add(TableHeader(hdInfo, type));
                document.Add(new Phrase(Environment.NewLine));
                document.Add(TableCustomerInfo(hdInfo));
                document.Add(TableContent(hdInfo));
                document.Close();

                // Nếu chưa có thư mục của Khách hàng tương ứng thì tạo, nếu có rồi thì xóa tất cả các file trong đó
                var strServerFolder = Server.MapPath(string.Format("~/TempUpload/{0}/", hdInfo.IDKH));

                //tao folder
                var folder = new DirectoryInfo(strServerFolder);
                if (folder.Exists)
                    foreach (var file in folder.GetFiles())
                    {
                        file.Delete();
                    }
                else
                {
                    Directory.CreateDirectory(strServerFolder);
                }

                document.CreateFile(ms.GetBuffer(),
                    type ? string.Format("1{0}{1}{2}{3}", hdInfo.IDKH, hdInfo.SODB, hdInfo.KY, hdInfo.NAM)
                        : string.Format("0{0}{1}{2}{3}", hdInfo.IDKH, hdInfo.SODB, hdInfo.KY, hdInfo.NAM),
                    strServerFolder, isDownload);
                ms.Close();
            }

        }
        protected void lkbThongBao_OnClick(string idkh)
        {
            try
            {
                var dt = ViewState["HDDT"] as DataTable;
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        htmlContent +=
                         string.Format("<tr class='gvtabletd' style='height: 22px;'>"
                         + "<td style='width: 50px;' align='center'>{0}</asp:Label></td>"
                         + "<td style='width: 50px;' align='center'>{1}</asp:Label></td>"
                         + "<td style='width: 50px;' align='center'>{2}</td>"
                         + "<td style='width: 50px;' align='center'>{3}</td>"
                         + "<td style='width: 50px;' align='center'>{4}</td>"
                         + "<td style='width: 50px;' align='center'>{5}</td>"
                         + "<td style='width: 50px;' align='center'>{6}</td>"
                         + "<td align='center'><button type='submit' name='action' value='lkbThongBao|{7}'/>Xem TB</td>{8}</tr>",
                         item["IDKH"],
                         item["SOHOADON"],
                         decimal.Parse(item["KLTIEUTHU"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                         decimal.Parse(item["TIENNUOC"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                         decimal.Parse(item["TIENTHUE"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                         decimal.Parse(item["TIENPHITNMT"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                         decimal.Parse(item["TONGTIEN"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                         item["IDKH"],
                            //(bool.Parse(item["HETNO"].ToString()) && bool.Parse(item["DAKY"].ToString()))
                         (bool.Parse(item["HETNO"].ToString()))
                         ? string.Format("<td align='center'><button type='submit' name='action' value='lkbXemHD|{0}'/>Xem HĐ</td><td align='center'><button type='submit' name='action' value='lkbTaiHD|{0}'/>Tải</td>", item["IDKH"])
                            : "<td align='center' Colspan = 2 ><span style='color: Red'>Bạn phải thanh toán tiền <br/>để có thể xem và tải hóa đơn</span></td>"
                            );
                    }
                    //var hdInfo = dt.Select(string.Format("Lan = '{0}'", intLan)).CopyToDataTable();
                    //var hdInfo = dt.Select(string.Format("idkh = '{0}'", idkh)).CopyToDataTable();
                    var hdInfo = new EI(idkh, int.Parse(ddlKy.SelectedValue), int.Parse(ddlNam.SelectedValue));
                    if (hdInfo.HOADON_XML != null)
                    {
                        GenPagePdf(hdInfo, false, false);

                        HDDTImage.ImageUrl = string.Format("TempUpload/{0}/0{0}{1}{2}{3}.png", hdInfo.IDKH, hdInfo.SODB, hdInfo.KY, hdInfo.NAM);
                        mp1.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Globals.ShowPopUpMsg(Page, string.Format("Lỗi {0}: {1}", ex.HResult, ex.Message));
            }
        }
        protected void lkbXemHD_OnClick(string idkh)
        {
            try
            {
                var dt = ViewState["HDDT"] as DataTable;
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        htmlContent +=
                         string.Format("<tr class='gvtabletd' style='height: 22px;'>"
                         + "<td style='width: 50px;' align='center'>{0}</td>"
                         + "<td style='width: 50px;' align='center'>{1}</td>"
                         + "<td style='width: 50px;' align='center'>{2}</td>"
                         + "<td style='width: 50px;' align='center'>{3}</td>"
                         + "<td style='width: 50px;' align='center'>{4}</td>"
                         + "<td style='width: 50px;' align='center'>{5}</td>"
                         + "<td style='width: 50px;' align='center'>{6}</td>"
                         + "<td align='center'><button type='submit' name='action' value='lkbThongBao|{7}'/>Xem TB</td>{8}"
                         + "</tr>",
                         item["IDKH"],
                         item["SOHOADON"],
                         decimal.Parse(item["KLTIEUTHU"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                         decimal.Parse(item["TIENNUOC"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                         decimal.Parse(item["TIENTHUE"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                         decimal.Parse(item["TIENPHITNMT"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                         decimal.Parse(item["TONGTIEN"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                         item["IDKH"],
                         (bool.Parse(item["HETNO"].ToString()))
                         ? string.Format("<td align='center'><button type='submit' name='action' value='lkbXemHD|{0}'/>Xem HĐ</td><td align='center'><button type='submit' name='action' value='lkbTaiHD|{0}'/>Hóa đơn</td>", item["IDKH"])
                         : "<td align='center' Colspan = 2 ><span style='color: Red'>Bạn phải thanh toán tiền <br/>để có thể xem và tải hóa đơn</span></td>"
                         );
                    }
                    //var hdInfo = dt.Select(string.Format("idkh = '{0}'", idkh)).CopyToDataTable();
                    var hdInfo = new EI(idkh, int.Parse(ddlKy.SelectedValue), int.Parse(ddlNam.SelectedValue));
                    if (hdInfo.HOADON_XML != null)
                    {
                        GenPagePdf(hdInfo, true, false);
                        HDDTImage.ImageUrl = string.Format("TempUpload/{0}/1{0}{1}{2}{3}.png", hdInfo.IDKH, hdInfo.SODB, hdInfo.KY, hdInfo.NAM);
                        mp1.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Globals.ShowPopUpMsg(Page, string.Format("Lỗi {0}: {1}", ex.HResult, ex.Message));
            }
        }
        protected void lkbTaiHD_OnClick(string idkh)
        {
            var dt1 = ViewState["HDDT"] as DataTable;
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                foreach (DataRow item in dt1.Rows)
                {
                    htmlContent +=
                     string.Format("<tr class='gvtabletd' style='height: 22px;'>"
                     + "<td style='width: 50px;' align='center'>{0}</td>"
                     + "<td style='width: 50px;' align='center'>{1}</td>"
                     + "<td style='width: 50px;' align='center'>{2}</td>"
                     + "<td style='width: 50px;' align='center'>{3}</td>"
                     + "<td style='width: 50px;' align='center'>{4}</td>"
                     + "<td style='width: 50px;' align='center'>{5}</td>"
                     + "<td style='width: 50px;' align='center'>{6}</td>"
                     + "<td align='center'><button type='submit' name='action' value='lkbThongBao|{7}'/>Xem TB</td>{8}</tr>",
                     item["IDKH"],
                     item["SOHOADON"],
                     decimal.Parse(item["KLTIEUTHU"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                     decimal.Parse(item["TIENNUOC"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                     decimal.Parse(item["TIENTHUE"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                     decimal.Parse(item["TIENPHITNMT"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                     decimal.Parse(item["TONGTIEN"].ToString()).ToString("0,0;-0.0;0", CultureInfo.CreateSpecificCulture("el-GR")),
                     item["IDKH"],
                     (bool.Parse(item["HETNO"].ToString()))
                     ? string.Format("<td align='center'><button type='submit' name='action' value='lkbXemHD|{0}'/>Xem HĐ</td><td align='center'><button type='submit' name='action' value='lkbTaiHD|{0}'/>Hóa đơn</td>", item["IDKH"])
                     : "<td align='center' Colspan = 2 ><span style='color: Red'>Bạn phải thanh toán tiền <br/>để có thể xem và tải hóa đơn</span></td>"
                        );
                }
            }
            //DataTable dt = userAccess.getHDDTByMaKH(idkh, int.Parse(ddlKy.SelectedValue), int.Parse(ddlNam.SelectedValue));
            var hdInfo = new EI(idkh, int.Parse(ddlKy.SelectedValue), int.Parse(ddlNam.SelectedValue));
            if (hdInfo.HOADON_XML != null)
            {
                var byteHoaDon = hdInfo.HOADON_XML;
                var strServerFolder = Server.MapPath(string.Format("~/TempUpload/{0}/", idkh));

                GenPagePdf(hdInfo, true, true);

                //Đoc nội dung chữ ký
                using (var xmlStream = new MemoryStream(byteHoaDon))
                using (var xmlReader = new XmlTextReader(xmlStream))
                {
                    var xml = XDocument.Load(xmlReader);

                    xml.Save(string.Format("{0}{1}{2}{3}{4}.xml", strServerFolder, hdInfo.IDKH, hdInfo.SODB, hdInfo.KY, hdInfo.NAM));
                }
                using (var ei = new EiBusinessImpl())
                {
                    ei.SetDownloadHd(idkh, int.Parse(ddlNam.SelectedValue), int.Parse(ddlKy.SelectedValue));
                }
                DownloadFiles(strServerFolder, "Download");
            }
            else
            {
                Globals.ShowPopUpMsg(Page, "Hóa đơn chưa được xử lý. Mong bạn thông cảm và thử lại sau.");
            }
        }
    }
}
