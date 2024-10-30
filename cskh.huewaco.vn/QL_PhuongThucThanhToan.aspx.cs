using System;
using System.Web;
using cskh.domain;
using DevExpress.Web;
using DevExpress.Web.Data;
using System.IO;

namespace cskh.huewaco.vn
{
    public partial class QL_PhuongThucThanhToan : CsBaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                User objUser = new User(HttpContext.Current.User.Identity.Name);
                if (!objUser.IsSuperUser) Response.Redirect("Default.aspx");
            }
        }

        protected void ASPxUploadControl1_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            string resultFileName = Path.GetRandomFileName() + "_" + e.UploadedFile.FileName;
            string resultFileUrl = "~/Images/PTTT/" + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);
            e.UploadedFile.SaveAs(resultFilePath);
            Session["LinkHinh"] = resultFileName;
        }


        protected void grvThanhToan_OnRowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            if (Session["LinkHinh"] != null)
            {
                e.NewValues["LinkHinh"] = Session["LinkHinh"].ToString();
                Session["LinkHinh"] = null;
            }
           
        }


        protected void grvThanhToan_OnRowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            if (Session["LinkHinh"] != null)
            {
                e.NewValues["LinkHinh"] = Session["LinkHinh"].ToString();
                Session["LinkHinh"] = null;
            }
        }
    }
}