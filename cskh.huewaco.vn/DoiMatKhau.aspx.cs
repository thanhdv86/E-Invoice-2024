using System;
using System.Data;
using System.Web;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class DoiMatKhau : CsBaseControl
    {
        protected User objUser = new User(HttpContext.Current.User.Identity.Name);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (objUser != null && objUser.IsSuperUser)
            {
                Globals.ShowPopUpMsg(this.Page,"Chức năng này chỉ sử dụng cho loại tài khoản Khách hàng");
                Response.Redirect("Default.aspx");
            }
        }


        protected void btnThayDoi_OnClick(object sender, EventArgs e)
        {

            using (var ebi = new EiBusinessImpl())
            {
                var dt = ebi.GetLoginAccount(objUser.Username);
                if (dt.Rows[0]["Password"].ToString() != Globals.Encrypt(txtPassword.Text.Trim()))
                {
                    lblMessageLogin.Text = "Mật khẩu cũ không chính xác";
                    txtPassword.Focus();
                    return;
                }
                else
                {
                    ebi.SetPassword(HttpContext.Current.User.Identity.Name, Globals.Encrypt(txtNewPassword.Text.Trim()));
                    Globals.ShowPopUpMsg(this.Page, "Thay đổi mật khẩu thành công");
                    Response.Redirect("Default.aspx");
                    return;
                }

            }
        }

    }
}