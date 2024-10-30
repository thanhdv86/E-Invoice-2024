using System;
using System.Data;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class PhuongthucThanhtoan : CsBaseControl
    {
        protected string htmlContent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["idpt"] != null)
                {
                    divCauHoi.Visible = true;
                    divListCH.Visible = false;
                    LoadDetailPT(Request.QueryString["idpt"].ToString());
                }
                else
                {
                    divCauHoi.Visible = false;
                    divListCH.Visible = true;
                    LoadDSPhuongThuc();
                }

            }
        }

        protected void LoadDetailPT(string id)
        {
            using (var ei = new EiBusinessImpl())
            {
                DataTable dt = ei.GetThanhToanById(id);

                lblNoiDung.Text = dt.Rows[0]["NoiDung"].ToString();
                lblTieude.Text = dt.Rows[0]["TieuDe"].ToString();
            }
        }

        protected void LoadDSPhuongThuc()
        {
            using (var ei = new EiBusinessImpl())
            {
                DataTable dt = ei.GetDsThanhToan();

                foreach (DataRow item in dt.Rows)
                {
                    string trichND = (item["TomTat"].ToString().Length > 100)
                        ? item["TomTat"].ToString().Substring(0, 100)
                        : item["TomTat"].ToString();
                    htmlContent +=
                     "<tr><td><img src='Images/PTTT/" + item["LinkHinh"] + "' height='100px' width='150px'/></td> <td><b>" + item["TieuDe"] + "</b> " +
                     "<br/> " + trichND + "... <br/><a style='float: right' href='PhuongthucThanhtoan.aspx?idpt=" + item["ID"] + "'>Xem thêm</a></td>  </tr>";
                }
            }
        }
    }
}
