using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.Xml;
using System.Xml;
using cskh.domain;
using DevExpress.Web;

namespace cskh.huewaco.vn
{
    public partial class XacThucHDDT : CsBaseControl
    {
        protected string HtmlFile = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["ListFile"] = null;
            }
            else
            {
                var files = Session["ListFile"] as List<UploadedFile>;
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        HtmlFile += string.Format("<tr><td>{0}</td><td></td></tr>", file.FileName);
                    }
                    btnXacThuc.Visible = true;
                }
            }
        }


        protected void btnXacThuc_OnClick(object sender, EventArgs e)
        {
            if (Captcha.IsValid)
            {
                var files = Session["ListFile"] as List<UploadedFile>;

                HtmlFile = string.Empty;
                if (files != null)
                    foreach (var file in files)
                    {
                        try
                        {
                            using (var stream = new MemoryStream(file.FileBytes))
                            {
                                var document = new XmlDocument();

                                document.Load(stream);
                                HtmlFile += String.Format("<tr><td>{0}</td>{1}</tr>", file.FileName, VerifyXmlFile(document));

                            }
                        }
                        catch (Exception)
                        {
                            HtmlFile += String.Format("<tr><td>{0}</td>{1}</tr>", file.FileName, "<td style='color:red'>Xác thực thất bại: Nội dung tệp hóa đơn đã bị thay đổi</td>");
                        }

                    }
                Session["ListFile"] = null;
            }
        }
        public string GetPublicKey(XmlDocument xmlDoc)
        {
            var strpkey = "";
            var publickey = xmlDoc.GetElementsByTagName("RSAKeyValue", @"http://www.w3.org/2000/09/xmldsig#");
            if (publickey.Count == 1)
            {
                var pk = publickey[0];
                strpkey = pk.OuterXml;
                var ns = pk.NamespaceURI;
                var nsToRemove = String.Format(" xmlns=\"{0}\"", ns);// note: a space before xmlns
                strpkey = strpkey.Replace(nsToRemove, "");
            }
            return strpkey;
        }

        public string VerifyXmlFile(XmlDocument xmlDocument)
        {
            try
            {
                // Format using white spaces.
                xmlDocument.PreserveWhitespace = true;

                // Create a new SignedXml object and pass it 
                // the XML document class.
                var signedXml = new SignedXml(xmlDocument);

                // Find the "Signature" node and create a new 
                // XmlNodeList object.
                var nodeList = xmlDocument.GetElementsByTagName("Signature");
                // Throw an exception if no signature was found. 
                if (nodeList.Count <= 0)
                {
                    return "<td style='color:red'>Xác thực thất bại: Không tồn tại chữ ký trong tệp hóa đơn</td>";
                }

                // This example only supports one signature for 
                // the entire XML document.  Throw an exception  
                // if more than one signature was found. 
                if (nodeList.Count >= 2)
                {
                    return "<td style='color:red'>Xác thực thất bại: Có nhiều hơn 1 chữ ký trong tệp hóa đơn</td>";
                }

                // Load the signature node.
                signedXml.LoadXml((XmlElement)nodeList[0]);
                // Check the signature and return the result. 
                if (signedXml.CheckSignature())
                {
                    if (IsValidCertificate(GetPublicKey(xmlDocument)))
                    {
                        // Kiểm tra xem còn trong bảng HD_HOADON hoặc HD_HOADON_HUY không?
                        var nodeListHoadon = xmlDocument.GetElementsByTagName("HOADON");
                        if (nodeListHoadon.Count <= 0)
                        {
                            return "<td style='color:red'>Xác thực thất bại: Không có Thông tin Hóa đơn</td>";
                        }
                        if (nodeListHoadon.Count >= 2)
                        {
                            return "<td style='color:red'>Xác thực thất bại: Có quá nhiều thông tin Hóa đơn</td>";
                        }

                        var mauhoadon = Int16.Parse(nodeListHoadon[0].Attributes["NAM"].InnerText) < 2019 ? "" : nodeListHoadon[0].Attributes["MAUHOADON"].InnerText;
                        var kihieuhoadon = nodeListHoadon[0].Attributes["KIHIEUHOADON"].InnerText;
                        var sohoadon = nodeListHoadon[0].Attributes["SOHOADON"].InnerText;
                        using (var eib = new EiBusinessImpl())
                        {
                            var dt = eib.GetHdByMauKiHieuSo(mauhoadon, kihieuhoadon, sohoadon);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                return
                                    string.Format(
                                        "<td style='color:green'>Xác thực hóa đơn thành công: Hóa đơn được ký bởi {0}</td>",
                                        Systems.CompanyAbbreviatedValue);
                            }
                            var dt1 = eib.GetHdHuyByMauKiHieuSo(mauhoadon, kihieuhoadon, sohoadon);
                            if (dt1 != null && dt1.Rows.Count > 0)
                            {
                                return string.Format("<td style='color:red'>Xác thực thất bại: Hóa đơn đã bị Hủy</td>");

                            }
                            return string.Format("<td style='color:red'>Xác thực thất bại: Hóa đơn không có trong Hệ thống</td>");
                        }
                    }
                    return string.Format("<td style='color:red'>Xác thực thất bại: Hóa đơn không được ký bởi {0}</td>", Systems.CompanyAbbreviatedValue);
                }
                return "<td style='color:red'>Xác thực thất bại: Nội dung tệp hóa đơn đã bị thay đổi</td>";
            }
            catch (Exception)
            {
                return "<td style='color:red'>Xác thực thất bại: Nội dung tệp hóa đơn đã bị thay đổi</td>";
            }
        }

        public Boolean IsValidCertificate(string publickey)
        {
            using (var ebi = new EiBusinessImpl())
            {
                return ebi.CheckValidCertificate(publickey);
            }
        }

        protected void UploadControl_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {

            //var files = (List<UploadedFile>)Session["ListFile"];
            //if (files == null)
            //{

            //    files = new List<UploadedFile>();
            //}

            var files = (List<UploadedFile>)Session["ListFile"] ?? new List<UploadedFile>();
            var hasfile = false;
            foreach (var file in files)
            {
                if (file.FileName.Trim().Equals(e.UploadedFile.FileName.Trim()))
                {
                    hasfile = true;
                    break;
                }
            }

            if (hasfile)
            {
                e.CallbackData = "false";
            }
            else
            {
                files.Add(e.UploadedFile);
                Session["ListFile"] = files;
                var name = e.UploadedFile.FileName;
                e.CallbackData = name;
            }
        }
        protected void OnCallback(object source, CallbackEventArgs e)
        {
        }
    }
}