using System;
using System.Data;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class TinTuc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Page.RouteData.Values["ID"] != null)
                {
                    using (var eib = new EiBusinessImpl())
                    {
                        var ds = eib.GetTinTucByIDe(this.Page.RouteData.Values["ID"].ToString());

                        if (ds != null)
                        {
                            lblContent.Text = Server.HtmlDecode(ds.Rows[0]["Noidung"].ToString());
                        }
                    }
                }
            }

        }
    }
}