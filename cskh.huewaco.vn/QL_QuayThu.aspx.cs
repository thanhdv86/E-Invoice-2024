using System;
using System.Web;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class QL_QuayThu : CsBaseControl
    {
        //protected string ConnectionStringsss = "Data Source=" + ConfigurationManager.AppSettings["DataSource"] + ";Initial Catalog=" + ConfigurationManager.AppSettings["InitialCatalog"] + "; User ID=" + ConfigurationManager.AppSettings["UserID"] + ";Password=" + ConfigurationManager.AppSettings["Password"];
        protected void Page_Load(object sender, EventArgs e)
        {
            UICulture = "vi";
            Culture = "vi";
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                User objUser = new User(HttpContext.Current.User.Identity.Name);
                if (!objUser.IsSuperUser) Response.Redirect("Default.aspx");
            }
            SetUI();
            
        }
       
       
    }
}
