using System;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Web;

namespace cskh.huewaco.vn
{
    public class CsBaseUserControl : System.Web.UI.UserControl
    {
        public ResourceManager _resourceManager;
        //public string StrUser = ConfigurationManager.AppSettings["StrUser"];
        //public string StrPassword = ConfigurationManager.AppSettings["StrPassword"];
        public virtual void SetUI() { }

        private void InitResource()
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
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);
            _resourceManager = new ResourceManager("cskh.huewaco.vn.Resources.UIResources", Assembly.GetExecutingAssembly());
        }
        public string getString(string key)
        {
            if (_resourceManager == null) lock (this) InitResource();
            try
            {
                return _resourceManager.GetString(key, Thread.CurrentThread.CurrentUICulture);
            }
            catch
            {
                if (key.StartsWith("freetext."))
                {
                    return key.Substring("freetext.".Length).Replace(".", " ");
                }
                return "[" + key + "]";
            }
        }
    }
}