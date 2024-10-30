using System;
using System.Web;
using System.Web.Security;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.Identity is FormsIdentity)
                {
                    var identity = (FormsIdentity)HttpContext.Current.User.Identity;
                    var ticket = identity.Ticket;
                    User objUser;
                    if (Session["USEROBJECT"] != null) objUser = (User)Session["USEROBJECT"];
                    else objUser = new User(HttpContext.Current.User.Identity.Name);
                    lblUser.Text = "Chào mừng " + (!objUser.IsSuperUser ? "khách hàng " + objUser.CustomerName : "Quản trị viên " + objUser.CustomerName) + " | <a href = '/DoiMatKhau.aspx' style='Color:White'>Đổi mật khẩu</a> | <a href = '/SignOut.aspx' style='Color:White'>Đăng xuất</a>";
                }
            }
            else lblUser.Text = "<a href = '/SignIn.aspx' style='Color:White'>Đăng nhập</a> | <a href = '/RegisterAccount.aspx' style='Color:White'>Đăng ký</a>";

            if (!IsPostBack)
            {
                try
                {
                    using (var obj = new EiBusinessImpl())
                    {
                        obj.SetTruyCap(Session.SessionID, HttpContext.Current.User.Identity.Name, Context.Request.UserHostAddress, System.IO.Path.GetFileName(Request.CurrentExecutionFilePath.ToLower()));
                    }
                }
                catch
                {

                }
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}
