using System;
using System.Web.UI;
using cskh.domain;

namespace cskh.huewaco.vn.Control
{
    public partial class ctrlSignIn : CsBaseUserControl
    {
        //private string strTenNguoiDung, strMatKhau;        
        protected void Page_Load(object sender, EventArgs e)
        {
            //SetUI();
            //hplRemindPass.Visible = hplRegister.Visible = txtUser.Visible = txtPassword.Visible = btnOk.Visible = !this.Request.IsAuthenticated;
            //hplChangePassword.Visible = hplSignOut.Visible = lblAccount.Visible = lblTienDien.Visible = lblStatus.Visible = this.Request.IsAuthenticated;
            //if (!this.IsPostBack)
            //{
            //    txtUser.Text = strTenNguoiDung;
            //    txtUser.Attributes.Add("onfocusin", "nulltext(this, '" + strTenNguoiDung + "');");
            //    txtUser.Attributes.Add("onfocusout", "rollback(this, '" + strTenNguoiDung + "');");

            //    txtPassword.Attributes.Add("value", strMatKhau);
            //    txtPassword.Attributes.Add("onfocusin", "nulltext(this, '" + strMatKhau + "');");
            //    txtPassword.Attributes.Add("onfocusout", "rollback(this, '" + strMatKhau + "');");
            //}
        }

        #region MultiLanguages
        public override void SetUI()
        {
            //strTenNguoiDung = getString("strTenNguoiDung");
            //strMatKhau = getString("strMatKhau");
            //lblLoginTitle.Text = this.Request.IsAuthenticated ? getString("strYourAccount") : getString("strSignInTitle");
            //lblAccount.Text = WelcomeString(new User(HttpContext.Current.User.Identity.Name));

            //btnOk.ImageUrl = getString("strLoginImages");
            //btnOk.ToolTip = getString("strSignIn");
            //hplRemindPass.Text = getString("strRemindPassword");
            //hplRegister.Text = getString("strRegis");
            //hplChangePassword.Text = getString("strChangePass");
            //hplSignOut.Text = getString("strSignOut");
        }
        #endregion
        #region RenderingEvent
        override protected void OnInit(EventArgs e)
        {
            Load += Page_Load;
        }
        #endregion

        protected void btnOk_Click(object sender, ImageClickEventArgs e)
        {
            ////Process as Login account
            //using (UserAccess obj = new UserAccess())
            //{
            //    DataSet ds = obj.getLoginAccount(txtUser.Text.Trim().ToUpper());
            //    if (ds.Tables[0].Rows.Count == 0)
            //    {
            //        //Label2.Text = getString("strWrongUsername");
            //        txtUser.Focus();
            //        return;
            //    }
            //    else if (Cryp.Decrypt(ds.Tables[0].Rows[0]["strPassword"].ToString()) != txtPassword.Text.Trim())
            //    //else if (ds.Tables[0].Rows[0]["strPassword"].ToString() != txtPassword.Text.Trim())
            //    {
            //        //Label2.Text = getString("strWrongPassword");
            //        txtPassword.Focus();
            //        return;
            //    }
            //    else
            //    {
            //        FormsAuthentication.SetAuthCookie(txtUser.Text.Trim(), false);
            //        Session["ContractNumber"] = ds.Tables[0].Rows[0]["strContractNumber"].ToString();
            //        if (ds.Tables[0].Rows[0]["strContractNumber"].ToString().ToUpper().Substring(0, 2) == "PC")
            //            Session["DonViQL"] = ds.Tables[0].Rows[0]["strContractNumber"].ToString().ToUpper().Substring(0, 4);
            //        else Session["DonViQL"] = ds.Tables[0].Rows[0]["strContractNumber"].ToString().ToUpper().Substring(0, 2); //Truong hop Don vi la Da Nang, Khanh Hoa
            //        string strMenu = "";
            //        try
            //        {
            //            strMenu = Request["menu"].ToString();
            //        }
            //        catch { }
            //        switch (strMenu)
            //        {
            //            case "Comparison":
            //                if (CheckExistService(txtUser.Text.Trim()))
            //                    Response.Redirect("~/Comparison.aspx");
            //                else Response.Redirect("~/RegisterService.aspx"); //Se change code cho cac case ben duoi sau
            //                break;
            //            case "Service":
            //                Response.Redirect("~/RegisterService.aspx");
            //                break;
            //            default:
            //                if (CheckExistService(txtUser.Text.Trim()))
            //                    Response.Redirect("~/Default.aspx");
            //                else Response.Redirect("~/RegisterService.aspx");
            //                break;
            //        }
            //    }
            //}
        }
        private bool CheckExistService(string strUsername)
        {
            bool bolResult = false;
            using (var ei = new EiBusinessImpl())
            {
                if (ei.GetExistService(strUsername))
                    bolResult = true;
            }
            return bolResult;
        }
        private string WelcomeString(User obj)
        {
            //string strResult = "";
            //DataSet ds = new DataSet();
            //if (this.Request.IsAuthenticated)
            //{
            //    if (obj.IsNormalUser)
            //    {
            //        ds = a.tracuu_thongtin_khachhang(obj.ContractNumber);
            //        lblTienDien.Text = getString("strTDTN") + Convert.ToDouble(ds.Tables[1].Rows[0]["Tong_tien"]).ToString("###,###") + " đ";
            //        lblStatus.Text = getString("strStatus") + ": " + (ds.Tables[1].Rows[0]["Tong_tien"].ToString() == ds.Tables[1].Rows[0]["TIENDANOP"].ToString() ? getString("strPaid") : getString("strOutStanding"));
            //        strResult = getString("strCustomer") + ": <b>" + obj.CustomerName + "</b>";
            //    }
            //    else if (obj.IsSuperUser)
            //    {
            //        if (obj.IsAdminLevelCPC) strResult = getString("strWelcomeAdminOf") + "CPC";
            //        if (obj.IsAdminLevelCompany) strResult = getString("strWelcomeAdminOf") + obj.DivisionCode;
            //        if (obj.IsAdminLevelBrand) strResult = getString("strWelcomeAdminOf") + obj.SubDivisionCode;
            //    }
            //}
            //else strResult = "<a href='SignIn.aspx' class='LinkLanguage'>" + getString("strSignIn") + "</a> | <a href='Register.aspx' class='LinkLanguage'>" + getString("strRegis") + "</a>";
            //return strResult;
            return "";
        }
    }
}