using System;
using System.Data;
using System.Web.Security;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class RegisterAccount : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_OnClick(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1);
            try
            {
                var sOutput = System.Text.Encoding.ASCII.GetString(System.Text.Encoding.ASCII.GetBytes(txtTenDangNhap.Text.Trim()));
                using (var cr = new CrBusinessImpl())
                {
                    var dt = cr.GetCustomerInfo(txtContractNumber.Text.Trim(),"", "", "", "", "", "", "","", "");

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        using (var userAccess = new EiBusinessImpl())
                        {
                            if (userAccess.Insert_User(txtTenDangNhap.Text.Trim(), txtMatKhau.Text.Trim(), dt.Rows[0]["idkh"].ToString(), dt.Rows[0]["tenkh"].ToString(),
                               dt.Rows[0]["sodb"].ToString(), dt.Rows[0]["maduongpho"].ToString(), dt.Rows[0]["diachi"].ToString(), dt.Rows[0]["sodt"].ToString(), dt.Rows[0]["makv"].ToString(), dt.Rows[0]["maphuong"].ToString()) > 0)
                            {
                                lbError.Text = "Tài khoản này đã được đăng ký";
                            }
                            else
                            {
                                //Login vao account luon
                                FormsAuthentication.SetAuthCookie(txtTenDangNhap.Text.Trim(), false);
                                Session["ContractNumber"] = dt.Rows[0]["idkh"].ToString();
                                Session["USEROBJECT"] = new User(txtTenDangNhap.Text.Trim());
                                //Insert Log                                    
                                string strSessionID = Session.SessionID, strUserHostAddress = Context.Request.UserHostAddress;
                                using (USER_LOGIN uo = new USER_LOGIN()) uo.setUSER_LOGIN(strSessionID, txtTenDangNhap.Text.Trim(), strUserHostAddress);
                                Globals.ShowPopUpMsg(this.Page, "Đăng ký thành công", "Default.aspx");
                            }

                        }
                    }
                    else
                    {
                        Globals.ShowPopUpMsg(this.Page, "Mã khách hàng không tồn tại");
                        txtContractNumber.Focus();
                        txtContractNumber.Attributes.Add("onfocus", "this.select();");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}