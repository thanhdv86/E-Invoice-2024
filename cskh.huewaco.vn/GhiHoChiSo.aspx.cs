using System;
using System.Data;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class GhiHoChiSo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }

            grvLich.DataBind();
        }

        protected void btnXem_OnClick(object sender, EventArgs e)
        {
            using (var cr = new CrBusinessImpl())
            {
                var dt = cr.GetDanhSachChuaGcs(ddlKhuVuc.SelectedValue, ddlQuan.SelectedValue, ddlPhuong.SelectedValue);
                if (dt != null && dt.Rows.Count > 0)
                {
                    UtilCustCares.MappingFunction("GetDanhSachChuaGCS", ref dt);
                }
                ViewState["DataDSGCS"] = dt;
                grvLich.DataSource = dt;
                grvLich.DataBind();
            }
        }

        protected void grvLich_OnDataBound(object sender, EventArgs e)
        {
            grvLich.DataSource = ViewState["DataDSGCS"];
        }

        protected void grvLich_DataBinding(object sender, EventArgs e)
        {
            grvLich.DataSource = ViewState["DataDSGCS"];
        }
    }
}