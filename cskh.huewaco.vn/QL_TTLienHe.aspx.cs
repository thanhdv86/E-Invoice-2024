using System;
using System.Data;
using System.Web;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class QL_TTLienHe : CsBaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                User objUser = new User(HttpContext.Current.User.Identity.Name);
                if (!objUser.IsSuperUser) Response.Redirect("Default.aspx");
            }
            if (!this.IsPostBack) BindData(drlDonvi.SelectedValue);
        }
        private bool IsValidType(string strMIME)
        {
            if (strMIME.IndexOf("image") != -1)
                return true;
            return false;
        }
        private void BindData(string strDocName)
        {
            using (var eib = new EiBusinessImpl())
            {
                var dt = eib.GetThongTinLienHe(strDocName);
                ftbDocContent.Html = dt.Rows.Count > 0 ? Server.HtmlDecode(dt.Rows[0]["strDocContent"].ToString()) : null;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strDocName = drlDonvi.SelectedValue;
            string strDocContent = Server.HtmlEncode(ftbDocContent.Html);
            using (var ei = new EiBusinessImpl())
            {
                if (ei.SetThongTinLienHe(strDocName, strDocContent))
                {
                    Globals.ShowPopUpMsg(this.Page, "Cập nhật thành công.");
                }
            }
        }

        protected void drlDonvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData(drlDonvi.SelectedValue);
        }

        #region RenderingEvent
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion
    }
}