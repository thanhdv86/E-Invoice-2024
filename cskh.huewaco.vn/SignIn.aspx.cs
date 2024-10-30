using System;
using System.Web.Security;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class SignIn : CsBaseControl
    {
        public string TC_MSKH = "";
        public string madonvi = "";
        public string ten_tcuu = "";
        public string dchi_tcuu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SetUI();
            Session.Remove(Session.SessionID);
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Process as Login account
            string strUsername = txtUsername.Text.Trim();
            string strPassword = txtPassword.Text.Trim();
            using (var obj = new EiBusinessImpl())
            {
                var dt = obj.GetLoginAccount(strUsername);
                if (dt.Rows.Count <= 0)
                {
                    lblMessageLogin.Text = getString("strWrongUsername");
                    txtUsername.Focus();
                    return;
                }

                if (dt.Rows[0]["Password"].ToString() != Globals.Encrypt(strPassword))
                {
                    lblMessageLogin.Text = getString("strWrongPassword");
                    txtPassword.Focus();
                    return;
                }

                FormsAuthentication.SetAuthCookie(strUsername, false);

                //Insert Log
                using (var uo = new USER_LOGIN()) uo.setUSER_LOGIN(Session.SessionID, strUsername, Context.Request.UserHostAddress);
                // Get the requested page from the url
                string returnUrl = Request.QueryString["ReturnUrl"];
                // check if it exists, if not then redirect to default page
                if (returnUrl == null) returnUrl = "Default.aspx";
                Response.Redirect(returnUrl);

            }
        }
        protected void btnRemindPass_Click(object sender, EventArgs e)
        {
            using (var obj = new EiBusinessImpl())
            {
                obj.SetPassword(txtUsername.Text.Trim(), Globals.Encrypt("000000"));
            }
            Globals.ShowPopUpMsg(this.Page, "Mật khẩu của bạn vừa được thay đổi về 000000, mời bạn vui lòng đăng nhập lại.");
            txtPassword.Focus();
        }
        public String GetSessionID()
        {
            // Obtain current HttpContext of ASP+ Request
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            if (context.User.Identity.Name != "")
            {
                return context.User.Identity.Name;
            }
            // If user is not authenticated, either fetch (or issue) a new temporary cartID
            if ((context.Request.Cookies["SessionID"] != null) && (context.Request.Cookies["SessionID"].Value != string.Empty))
            {
                context.Session["SessionID"] = context.Request.Cookies["SessionID"].Value;
                return context.Request.Cookies["SessionID"].Value;
            }
            else
            {
                // Generate a new random GUID using System.Guid Class
                Guid tempCartId = Guid.NewGuid();
                // Send tempCartId back to client as a cookie
                context.Response.Cookies["SessionID"].Value = tempCartId.ToString();
                context.Session["SessionID"] = tempCartId.ToString();
                // Return tempCartId
                return tempCartId.ToString();
            }
        }

        #region MultiLanguages
        public override void SetUI()
        {
            //btnSignIn.Text = getString("strSignIn");
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