using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public class Globals
    {
        public static string FormatURL()
        {
            var ServerPath = HttpContext.Current.Request.ApplicationPath;
            if (!ServerPath.EndsWith("/")) ServerPath += "/";
            return ServerPath + "Default.aspx";
        }

        //public static bool SendMail(string mailto, string subject, string body, string attachment, SMTPServerInfo server)
        //{
        //    var mail = new MailMessage
        //    {
        //        From = server.HostEmail,
        //        To = mailto,
        //        Subject = subject,
        //        Body = body,
        //        BodyFormat = MailFormat.Html,
        //        BodyEncoding = Encoding.UTF8
        //    };

        //    if (attachment != "") mail.Attachments.Add(new MailAttachment(attachment));
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", server.SMTPServer);
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", server.SMTPPort);
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", server.SMTPServer_AuthName);
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", server.SMTPServer_AuthPassword);
        //    try
        //    {
        //        SmtpMail.SmtpServer = server.SMTPServer;
        //        SmtpMail.Send(mail);
        //        return true;
        //    }
        //    catch { return false; }
        //}
        //public static bool SendMail(string mailto, string cc, string subject, string body, string attachment, SMTPServerInfo server)
        //{
        //    System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();

        //    mail.From = server.HostEmail;
        //    mail.To = mailto;
        //    mail.Cc = cc;
        //    mail.Subject = subject;
        //    mail.Body = body;
        //    mail.BodyFormat = System.Web.Mail.MailFormat.Html;
        //    mail.BodyEncoding = System.Text.Encoding.UTF8;
        //    if (attachment != "") mail.Attachments.Add(new System.Web.Mail.MailAttachment(attachment));
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", server.SMTPServer);
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", server.SMTPPort);
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", server.SMTPServer_AuthName);
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", server.SMTPServer_AuthPassword);
        //    try
        //    {
        //        System.Web.Mail.SmtpMail.SmtpServer = server.SMTPServer;
        //        System.Web.Mail.SmtpMail.Send(mail);
        //        return true;
        //    }
        //    catch { return false; }
        //}
        //public static bool SendMail(string mailto, string cc, string bcc, string subject, string body, string attachment, SMTPServerInfo server)
        //{
        //    var mail = new MailMessage
        //    {
        //        From = server.HostEmail,
        //        To = mailto,
        //        Cc = cc,
        //        Bcc = bcc,
        //        Subject = subject,
        //        Body = body,
        //        BodyFormat = MailFormat.Html,
        //        BodyEncoding = Encoding.UTF8
        //    };

        //    if (attachment != "") mail.Attachments.Add(new System.Web.Mail.MailAttachment(attachment));
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", server.SMTPServer);
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", server.SMTPPort);
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", server.SMTPServer_AuthName);
        //    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", server.SMTPServer_AuthPassword);
        //    try
        //    {
        //        SmtpMail.SmtpServer = server.SMTPServer;
        //        SmtpMail.Send(mail);
        //        return true;
        //    }
        //    catch { return false; }
        //}

        public static void ShowPopUpMsg(Page page, string msg)
        {
            var sb = new StringBuilder();
            sb.Append("alert('");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
            sb.Append("');");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "showalert", sb.ToString(), true);
        }
        public static void ShowPopUpMsg(Page page, string msg, string url)
        {
            var sb = new StringBuilder();
            sb.Append("alert('");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
            sb.Append("');");
            sb.Append("window.location.href='");
            sb.Append(url.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
            sb.Append("';");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "showalert", sb.ToString(), true);
        }

        //public static string GetCurrentLanguage()
        //{
        //    var lang = HttpContext.Current.Session["language"] != null ? HttpContext.Current.Session["language"].ToString() : (HttpContext.Current.Request.Cookies["language"] != null ? HttpContext.Current.Request.Cookies["language"].Value : ConfigurationManager.AppSettings["defaultLanguage"]);
        //    var httpCookie = HttpContext.Current.Response.Cookies["language"];
        //    if (httpCookie != null)
        //        httpCookie.Value = lang;
        //    HttpContext.Current.Session.Add("language", lang);
        //    return lang;
        //}
        public static void InitResource(CsBaseControl page)
        {
            String lang = HttpContext.Current.Session["language"] != null ? HttpContext.Current.Session["language"].ToString() : (HttpContext.Current.Request.Cookies["language"] != null ? HttpContext.Current.Request.Cookies["language"].Value : ConfigurationManager.AppSettings["defaultLanguage"]);
            HttpContext.Current.Response.Cookies["language"].Value = lang;
            HttpContext.Current.Session.Add("language", lang);
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture(lang);
            page._resourceManager = new ResourceManager("cskh.huewaco.vn.Resources.UIResources", Assembly.GetExecutingAssembly());
        }

        public static string Encrypt(string clearText)
        {
            const string encryptionKey = "HUEWACO2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            const string encryptionKey = "HUEWACO2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }

            }
            return cipherText;
        }

        public static string SmsViettelUserName = "bulk_huewaco";
        public static string SmsViettelPassword = "123456A@";
        public static string SmsViettelCpcode = "WACO";


        public static String VietNamese2English(string unicodeString)
        {
            try
            {
                //Remove VietNamese character
                unicodeString = unicodeString.ToLower();
                unicodeString = Regex.Replace(unicodeString, "[áàảãạâấầẩẫậăắằẳẵặ]", "a");
                unicodeString = Regex.Replace(unicodeString, "[ĂÂÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤ]", "A");
                unicodeString = Regex.Replace(unicodeString, "[éèẻẽẹêếềểễệ]", "e");
                unicodeString = Regex.Replace(unicodeString, "[ÈẺẼẸÉỀỂỄỆẾÊ]", "E");
                unicodeString = Regex.Replace(unicodeString, "[iíìỉĩị]", "i");
                unicodeString = Regex.Replace(unicodeString, "[IÌỈĨỊÍ]", "I");
                unicodeString = Regex.Replace(unicodeString, "[óòỏõọơớờởỡợôốồổỗộ]", "o");
                unicodeString = Regex.Replace(unicodeString, "[ÔƠÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚ]", "O");
                unicodeString = Regex.Replace(unicodeString, "[úùủũụưứừửữự]", "u");
                unicodeString = Regex.Replace(unicodeString, "[ƯÙỦŨỤÚỪỬỮỰỨ]", "U");
                unicodeString = Regex.Replace(unicodeString, "[yýỳỷỹỵ]", "y");
                unicodeString = Regex.Replace(unicodeString, "[YỲỶỸỴÝ]", "Y");
                unicodeString = Regex.Replace(unicodeString, "[đ]", "d");
                unicodeString = Regex.Replace(unicodeString, "[Đ]", "D");
                //NCHAR(272)+ NCHAR(208)

                //Remove special character
                unicodeString = Regex.Replace(unicodeString, "\"", "");
                unicodeString = Regex.Replace(unicodeString, "[`~!@#$%^&*()-+=?/>.<,{}[]|]\\:']", "");

                //Remove space
                unicodeString = unicodeString.Trim();
                unicodeString = unicodeString.Replace("'", "");
                unicodeString = unicodeString.Replace("”", "");
                unicodeString = unicodeString.Replace("“", "");
                unicodeString = unicodeString.Replace("-", "");
                unicodeString = unicodeString.Replace(" ", "-");
                unicodeString = unicodeString.Replace("--", "-");
                unicodeString = unicodeString.Replace(":", "");

                return unicodeString;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static void LoadKhuVuc(DropDownList ddlKhuVuc)
        {
            if (DanhSachKhuVuc == null)
            {
                using (var cbi = new CrBusinessImpl())
                {
                    var dt = cbi.GetDanhSachKhuVuc();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DanhSachKhuVuc = dt;
                    }
                }
            }
            ddlKhuVuc.DataSource = DanhSachKhuVuc;
            ddlKhuVuc.DataBind();
        }

        public static void LoadQuanHuyen(DropDownList ddlQuan)
        {
            if (DanhSachQuanHuyen == null)
            {
                using (var cbi = new CrBusinessImpl())
                {
                    var dt = cbi.GetDanhSachQuanHuyen();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DanhSachQuanHuyen = dt;
                    }
                }
            }
            ddlQuan.DataSource = DanhSachQuanHuyen;
            ddlQuan.DataBind();
        }

        public static void LoadPhuongXa(DropDownList ddlPhuong)
        {
            if (DanhSachPhuongXa == null)
            {
                using (var cbi = new CrBusinessImpl())
                {
                    var dt = cbi.GetDanhSachPhuongXa();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DanhSachPhuongXa = dt;
                    }
                }
            }
            ddlPhuong.DataSource = DanhSachPhuongXa;
            ddlPhuong.DataBind();
        }

        public static void LoadLoTrinh(DropDownList ddlLoTrinh, DropDownList ddlKhuVuc)
        {

            if (DanhSachLoTrinh == null)
            {
                using (var cbi = new CrBusinessImpl())
                {
                    var dt = cbi.GetDanhSachLoTrinhTheoKhuVuc("%");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DanhSachLoTrinh = dt;
                        ddlLoTrinh.Items.Clear();
                        ddlLoTrinh.Items.Insert(0, new ListItem("Tất cả", "%%"));
                        foreach (DataRow duongpho in dt.Rows)
                        {
                            if (duongpho["makhuvuc"].ToString().Trim().Equals(ddlKhuVuc.SelectedValue))
                            {
                                ddlLoTrinh.Items.Add(
                                    new ListItem(duongpho["maduongpho"] + " - " + duongpho["tenduongpho"],
                                        duongpho["maduongpho"].ToString()));
                            }
                        }
                    }
                }
            }
            else
            {
                var dt = DanhSachLoTrinh;
                ddlLoTrinh.Items.Clear();
                ddlLoTrinh.Items.Insert(0, new ListItem("Tất cả", "%%"));
                foreach (DataRow duongpho in dt.Rows)
                {
                    if (duongpho["makhuvuc"].ToString().Trim().Equals(ddlKhuVuc.SelectedValue))
                    {
                        ddlLoTrinh.Items.Add(new ListItem(duongpho["maduongpho"] + " - " + duongpho["tenduongpho"], duongpho["maduongpho"].ToString()));
                    }
                }
            }
        }

        public static DataTable DanhSachKhuVuc;
        public static DataTable DanhSachQuanHuyen;
        public static DataTable DanhSachPhuongXa;
        public static DataTable DanhSachLoTrinh;
        public static DataTable DanhSachMaTienDo;
    }
}