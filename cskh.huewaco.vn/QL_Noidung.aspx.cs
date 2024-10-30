using System;
using System.Data;
using System.Web;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class QL_Noidung : CsBaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated) //Neu ko co ContractNumber nhung co Account
            {
                User objUser = new User(HttpContext.Current.User.Identity.Name);
                if (!objUser.IsSuperUser) Response.Redirect("Default.aspx");
            }
            if (!this.IsPostBack)
            {
                drlDanhmuc.DataBind();
                BindData(drlDanhmuc.SelectedValue);
            }
        }
       
        private void BindData(string intDocID)
        {
            using (var ebi = new EiBusinessImpl())
            {
                var dt = ebi.GetDocuments(intDocID);
                if (dt.Rows.Count > 0)
                {
                    ASPxHtmlEditor1.Html = Server.HtmlDecode(dt.Rows[0]["strDocContent"].ToString());
                }
                
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strDocName = drlDanhmuc.SelectedValue;
            string strDocContent = Server.HtmlEncode(ASPxHtmlEditor1.Html);
            using (var ei = new EiBusinessImpl())
            {
                if (ei.SetDocuments(strDocName, strDocContent))
                {
                    Globals.ShowPopUpMsg(this.Page, "Cập nhật thành công.");
                }
            }
        }

        protected void drlDanhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData(drlDanhmuc.SelectedValue);
        }
        #region RenderingEvent
       
        #endregion
    }
}