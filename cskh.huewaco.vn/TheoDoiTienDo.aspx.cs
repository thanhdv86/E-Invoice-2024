using System;
using System.Data;
using cskh.domain;
using DevExpress.Web;

namespace cskh.huewaco.vn
{
    public partial class TheoDoiTienDo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMaTienDo();
            }
        }

        protected void LoadMaTienDo()
        {
            if (Globals.DanhSachMaTienDo == null)
            {
                using (var cbi = new CrBusinessImpl())
                {
                    var dt = cbi.GetDanhSachTrangThai();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        UtilCustCares.MappingFunction("GetDanhSachTrangThai", ref dt);
                    }

                    Globals.DanhSachMaTienDo = dt;
                }
            }
        }

        protected void btnXem_OnClick(object sender, EventArgs e)
        {
            using (var uService = new CrBusinessImpl())
            {
                var dt = uService.GetListTienDolapDatNuoc(txtMaDonDK.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    UtilCustCares.MappingFunction("GetListTienDolapDatNuoc", ref dt);
                }

                ViewState["DataTienDo"] = dt;

                grvTienDo.DataSource = dt;
                grvTienDo.DataBind();

                if (dt != null && dt.Rows.Count > 0)
                {
                    divKH.Visible = true;
                    grvTienDo.ClientVisible = true;
                    lblTenKH.Text = dt.Rows[0]["tenkh"].ToString();
                    lblDiaChi.Text = dt.Rows[0]["diachi"].ToString();
                }
                else
                {
                    divKH.Visible = false;
                    grvTienDo.ClientVisible = false;
                }
            }
        }

        protected void grvTienDo_OnDataBound(object sender, EventArgs e)
        {
            grvTienDo.DataSource = ViewState["DataTienDo"];
        }


        protected void grvTienDo_OnCustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            
            DataTable dt = Globals.DanhSachMaTienDo;

            foreach (DataRow trangthai in dt.Rows)
            {
                if (trangthai["matrangthai"].ToString().Trim().Equals(e.Value))
                {

                    e.DisplayText = trangthai["tentrangthai"].ToString().Trim();
                }
                
            }

        }
    }
}