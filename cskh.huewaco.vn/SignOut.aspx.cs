using System;
using System.Web;
using System.Web.Security;

namespace cskh.huewaco.vn
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //using (USER_LOGIN uo = new USER_LOGIN()) uo.setUSER_LOGOUT(Session.SessionID);
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("~/Default.aspx", true);
        }
    }
}