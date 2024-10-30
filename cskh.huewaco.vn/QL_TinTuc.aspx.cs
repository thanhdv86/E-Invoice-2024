using System;
using System.Web;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class QL_TinTuc: CsBaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                User objUser = new User(HttpContext.Current.User.Identity.Name);
                if (!objUser.IsSuperUser) Response.Redirect("Default.aspx");
            }
        }
    }
}