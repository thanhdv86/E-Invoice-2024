using System;
using System.Web;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class ThanhToanTrucTuyen : CsBaseControl
    {
        protected string HtmlLogin = " ";
        protected User objUser = new User(HttpContext.Current.User.Identity.Name);

        protected void Page_Load(object sender, EventArgs e)
        {
            SetUI();
            if (IsPostBack) return;
        }

    }
}