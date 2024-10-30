using System;
using System.Web;
using DevExpress.Web;
using System.IO;
using DevExpress.Web.Data;

namespace cskh.huewaco.vn
{
    public partial class QL_VanBan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                User objUser = new User(HttpContext.Current.User.Identity.Name);
                if (!objUser.IsSuperUser) Response.Redirect("Default.aspx");
            }
        }

        protected void ulFile_OnFileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {


            string resultFileName = Path.GetRandomFileName() + "_" + e.UploadedFile.FileName;
            string resultFileUrl = "~/VanBan/" + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);
            e.UploadedFile.SaveAs(resultFilePath);
            Session["FileLink"] = resultFileName;
        }

        protected void grvCauHoi_OnRowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            if (Session["FileLink"] != null)
            {
                e.NewValues["FileLink"] = Session["FileLink"].ToString();
                Session["FileLink"] = null;
            }}

        protected void grvCauHoi_OnRowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            if (Session["FileLink"] != null)
            {
                e.NewValues["FileLink"] = Session["FileLink"].ToString();
                Session["FileLink"] = null;
            }}
    }
}