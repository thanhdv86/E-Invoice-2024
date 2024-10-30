using System;
using System.Configuration;
using System.Web;
using System.Reflection;
using System.Resources;
using cskh.domain;

namespace cskh.huewaco.vn.Control
{
    public partial class ctrlLanguages : CsBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetUI();
        }
        #region MultiLanguages
        //private void InitResource()
        //{
        //    String lang;
        //    if (HttpContext.Current.Session["language"] != null)
        //    {
        //        lang = HttpContext.Current.Session["language"].ToString();
        //    }
        //    else
        //    {
        //        if (HttpContext.Current.Request.Cookies["language"] != null)
        //        {
        //            lang = HttpContext.Current.Request.Cookies["language"].Value;
        //        }
        //        else
        //        {
        //            lang = ConfigurationManager.AppSettings["defaultLanguage"];
        //            HttpContext.Current.Response.Cookies["language"].Value = lang;
        //        }
        //        Context.Session.Add("language", lang);
        //    }
        //    System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture(lang);
        //    _resourceManager = new ResourceManager("cskh.huewaco.vn.Resources.UIResources", Assembly.GetExecutingAssembly());
        //}
        //public override string getString(string key)
        //{
        //    if (_resourceManager == null) lock (this) InitResource();
        //    try
        //    {
        //        return _resourceManager.GetString(key, System.Threading.Thread.CurrentThread.CurrentUICulture);
        //    }
        //    catch
        //    {
        //        if (key.StartsWith("freetext."))
        //        {
        //            return key.Substring("freetext.".Length).Replace(".", " ");
        //        }
        //        else
        //            return "[" + key + "]";
        //    }
        //}
        public override void SetUI()
        {
            lblLanguages.Text = "<a href='ChangeLang.aspx?ilang=en-US' class='LinkLanguage'>English</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href='ChangeLang.aspx?ilang=vi-VN' class='LinkLanguage'>Tiếng Việt</a>&nbsp;&nbsp;";
        }
        #endregion
        #region RenderingEvent
        override protected void OnInit(EventArgs e)
        {
            Load += Page_Load;
        }
        #endregion
    }
}