using System;
using System.Configuration;
using System.Web.UI;
using System.Web;
using System.Resources;
using System.Reflection;

namespace cskh.huewaco.vn
{
    public class MultiLanguagePage : Page
    {
        private ResourceManager _resourceManager;
        public MultiLanguagePage()
        {
        }
        public string CurrentLanguage
        {
            get
            {
                if (HttpContext.Current.Session["language"] != null)
                {
                    return HttpContext.Current.Session["language"].ToString();
                }
                if (Request["lg"] != null)
                {
                    HttpContext.Current.Session["language"] = Request["lg"];
                    return Request["lg"];
                }
                return ConfigurationManager.AppSettings["defaultLanguage"];
            }
        }

        public void InitResource()
        {
            String lang;
            if (HttpContext.Current.Session["language"] != null)
            {
                lang = HttpContext.Current.Session["language"].ToString();
            }
            else
            {
                if (HttpContext.Current.Request.Cookies["language"] != null)
                {
                    lang = HttpContext.Current.Request.Cookies["language"].Value;
                }
                else
                {
                    lang = ConfigurationManager.AppSettings["defaultLanguage"];
                    HttpContext.Current.Response.Cookies["language"].Value = lang;
                }

                Context.Session.Add("language", lang);
            }
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture(lang);
            _resourceManager = new ResourceManager("cskh.huewaco.vn.Resources.UIResources", Assembly.GetExecutingAssembly());
        }
        /// <summary>
        /// Lấy giá trị của chuỗi từ resource hiện tại theo khoá được cung cấp
        /// </summary>
        /// <param name="key">khoá của một giá trị trong resource</param>
        /// <returns>Trả về chuỗi tương ứng với từ khoá theo ngôn ngữ hiện tại. 
        /// Nếu không tìm thấy trong resource thì sẽ trả về Untitled - Chưa đặt tên
        /// </returns>
        public string getString(string key)
        {
            if (_resourceManager == null)
            {
                lock (this) InitResource();
            }
            try
            {
                return _resourceManager.GetString(key);
            }
            catch //(Exception exc)
            {
                if (key.StartsWith("freetext."))
                {
                    return key.Substring("freetext.".Length).Replace(".", " ");
                }
                return "[" + key + "]";
                //return exc.Message; 
            }
        }
        public string FormatDateString(DateTime d)
        {
            if (_resourceManager == null) InitResource();
            return d.ToUniversalTime().AddHours(7).ToString(System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
        }
        public string FormatDateString(string format, DateTime d)
        {
            if (_resourceManager == null) InitResource();
            return d.ToUniversalTime().AddHours(7).ToString(format, System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            var stringWriter = new System.IO.StringWriter();
            var htmlWriter = new HtmlTextWriter(stringWriter);
            base.Render(htmlWriter);
            var html = stringWriter.ToString();
            //			html = html.Replace("\t"," ");
            //			html = html.Replace("\r"," ");
            //			html = html.TrimStart(' ',' ');			

            html = ToTCVN6909(html.Trim());
            writer.Write(html);


        }
        protected String ToTCVN6909(string str)
        {
            var vn1258 = new[] { "à", "ả", "ã", "á", "ạ", "ằ", "ẳ", "ẵ", "ắ", "ặ", "ầ", "ẩ", "ẫ", "ấ", "ậ", "è", "ẻ", "ẽ", "é", "ẹ", "ề", "ể", "ễ", "ế", "ệ", "ò", "ỏ", "õ", "ó", "ọ", "ồ", "ổ", "ỗ", "ố", "ộ", "ờ", "ở", "ỡ", "ớ", "ợ", "ù", "ủ", "ũ", "ú", "ụ", "ừ", "ử", "ữ", "ứ", "ự", "ì", "ỉ", "ĩ", "í", "ị", "ỳ", "ỷ", "ỹ", "ý", "ỵ", "À", "Ả", "Ã", "Á", "Ạ", "Ằ", "Ẳ", "Ẵ", "Ắ", "Ặ", "Ầ", "Ẩ", "Ẫ", "Ấ", "Ậ", "È", "Ẻ", "Ẽ", "É", "Ẹ", "Ề", "Ể", "Ễ", "Ế", "Ệ", "Ò", "Ỏ", "Õ", "Ó", "Ọ", "Ồ", "Ổ", "Ỗ", "Ố", "Ộ", "Ờ", "Ở", "Ỡ", "Ớ", "Ợ", "Ù", "Ủ", "Ũ", "Ú", "Ụ", "Ừ", "Ử", "Ữ", "Ứ", "Ự", "Ì", "Ỉ", "Ĩ", "Í", "Ị", "Ỳ", "Ỷ", "Ỹ", "Ý", "Ỵ" };
            var vn6909 = new[] { "à", "ả", "ã", "á", "ạ", "ằ", "ẳ", "ẵ", "ắ", "ặ", "ầ", "ẩ", "ẫ", "ấ", "ậ", "è", "ẻ", "ẽ", "é", "ẹ", "ề", "ể", "ễ", "ế", "ệ", "ò", "ỏ", "õ", "ó", "ọ", "ồ", "ổ", "ỗ", "ố", "ộ", "ờ", "ở", "ỡ", "ớ", "ợ", "ù", "ủ", "ũ", "ú", "ụ", "ừ", "ử", "ữ", "ứ", "ự", "ì", "ỉ", "ĩ", "í", "ị", "ỳ", "ỷ", "ỹ", "ý", "ỵ", "À", "Ả", "Ã", "Á", "Ạ", "Ằ", "Ẳ", "Ẵ", "Ắ", "Ặ", "Ầ", "Ẩ", "Ẫ", "Ấ", "Ậ", "È", "Ẻ", "Ẽ", "É", "Ẹ", "Ề", "Ể", "Ễ", "Ế", "Ệ", "Ò", "Ỏ", "Õ", "Ó", "Ọ", "Ồ", "Ổ", "Ỗ", "Ố", "Ộ", "Ờ", "Ở", "Ỡ", "Ớ", "Ợ", "Ù", "Ủ", "Ũ", "Ú", "Ụ", "Ừ", "Ử", "Ữ", "Ứ", "Ự", "Ì", "Ỉ", "Ĩ", "Í", "Ị", "Ỳ", "Ỷ", "Ỹ", "Ý", "Ỵ" };
            for (int i = 0; i < vn1258.Length; i++)
            {
                str = str.Replace(vn1258[i], vn6909[i]);
            }
            return str;
        }
        protected String ToVN1258(string str)
        {
            var vn1258 = new[] { "à", "ả", "ã", "á", "ạ", "ằ", "ẳ", "ẵ", "ắ", "ặ", "ầ", "ẩ", "ẫ", "ấ", "ậ", "è", "ẻ", "ẽ", "é", "ẹ", "ề", "ể", "ễ", "ế", "ệ", "ò", "ỏ", "õ", "ó", "ọ", "ồ", "ổ", "ỗ", "ố", "ộ", "ờ", "ở", "ỡ", "ớ", "ợ", "ù", "ủ", "ũ", "ú", "ụ", "ừ", "ử", "ữ", "ứ", "ự", "ì", "ỉ", "ĩ", "í", "ị", "ỳ", "ỷ", "ỹ", "ý", "ỵ", "À", "Ả", "Ã", "Á", "Ạ", "Ằ", "Ẳ", "Ẵ", "Ắ", "Ặ", "Ầ", "Ẩ", "Ẫ", "Ấ", "Ậ", "È", "Ẻ", "Ẽ", "É", "Ẹ", "Ề", "Ể", "Ễ", "Ế", "Ệ", "Ò", "Ỏ", "Õ", "Ó", "Ọ", "Ồ", "Ổ", "Ỗ", "Ố", "Ộ", "Ờ", "Ở", "Ỡ", "Ớ", "Ợ", "Ù", "Ủ", "Ũ", "Ú", "Ụ", "Ừ", "Ử", "Ữ", "Ứ", "Ự", "Ì", "Ỉ", "Ĩ", "Í", "Ị", "Ỳ", "Ỷ", "Ỹ", "Ý", "Ỵ" };
            var vn6909 = new[] { "à", "ả", "ã", "á", "ạ", "ằ", "ẳ", "ẵ", "ắ", "ặ", "ầ", "ẩ", "ẫ", "ấ", "ậ", "è", "ẻ", "ẽ", "é", "ẹ", "ề", "ể", "ễ", "ế", "ệ", "ò", "ỏ", "õ", "ó", "ọ", "ồ", "ổ", "ỗ", "ố", "ộ", "ờ", "ở", "ỡ", "ớ", "ợ", "ù", "ủ", "ũ", "ú", "ụ", "ừ", "ử", "ữ", "ứ", "ự", "ì", "ỉ", "ĩ", "í", "ị", "ỳ", "ỷ", "ỹ", "ý", "ỵ", "À", "Ả", "Ã", "Á", "Ạ", "Ằ", "Ẳ", "Ẵ", "Ắ", "Ặ", "Ầ", "Ẩ", "Ẫ", "Ấ", "Ậ", "È", "Ẻ", "Ẽ", "É", "Ẹ", "Ề", "Ể", "Ễ", "Ế", "Ệ", "Ò", "Ỏ", "Õ", "Ó", "Ọ", "Ồ", "Ổ", "Ỗ", "Ố", "Ộ", "Ờ", "Ở", "Ỡ", "Ớ", "Ợ", "Ù", "Ủ", "Ũ", "Ú", "Ụ", "Ừ", "Ử", "Ữ", "Ứ", "Ự", "Ì", "Ỉ", "Ĩ", "Í", "Ị", "Ỳ", "Ỷ", "Ỹ", "Ý", "Ỵ" };
            for (var i = 0; i < vn1258.Length; i++)
            {
                str = str.Replace(vn6909[i], vn1258[i]);
            }
            return str;
        }
        protected String GetHelpForNoscript()
        {
            return String.Format(getString("noscripthelp"), Request.Url.Host, Request.Url.Host);
        }
        public string getTimeString(DateTime dt)
        {
            string s = "";
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    s = "Chủ Nhật";
                    break;
                case DayOfWeek.Monday:
                    s = "Thứ Hai";
                    break;
                case DayOfWeek.Tuesday:
                    s = "Thứ Ba";
                    break;
                case DayOfWeek.Wednesday:
                    s = "Thứ Tư";
                    break;
                case DayOfWeek.Thursday:
                    s = "Thứ Năm";
                    break;
                case DayOfWeek.Friday:
                    s = "Thứ Sáu";
                    break;
                case DayOfWeek.Saturday:
                    s = "Thứ Bảy";
                    break;
            }
            //{"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};
            return string.Format("{0}, {1} (GMT+7)", s, dt.ToString("dd/MM/yyyy hh:mm"));

        }
    }
}