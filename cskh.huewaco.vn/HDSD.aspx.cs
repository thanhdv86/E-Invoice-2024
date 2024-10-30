using System;
using System.Data;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class HDSD : System.Web.UI.Page
    {
        protected string htmlContent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["idhd"] != null)
                {
                    divChiTiet.Visible = true;
                    divDanhSach.Visible = false;
                    LoadDetailCauHoi(Request.QueryString["idhd"].ToString());
                }
                else
                {
                    divChiTiet.Visible = false;
                    divDanhSach.Visible = true;
                    LoadDSCauHoi();
                }
             
            }
        }

        protected void LoadDetailCauHoi(string id)
        {
            using (var ei = new EiBusinessImpl())
            {
                DataTable dt = ei.GetHdsdbyId(id);
                lblContent.Text = dt.Rows[0]["NoiDung"].ToString();
            }
        }

        protected void LoadDSCauHoi()
        {
            using (var ei = new EiBusinessImpl())
            {
                DataTable dt = ei.GetHdsd();

                foreach (DataRow item in dt.Rows)
                {
                    string trichND = (item["TieuDe"].ToString().Length > 100)
                        ? item["TieuDe"].ToString().Substring(0, 100)
                        : item["TieuDe"].ToString();
                    htmlContent +=
                     "<tr><td ><img src='images/HDSD.png'></td> <td><a style='float: left' href='HDSD.aspx?idhd=" + item["ID"] + "'><b>" + item["TieuDe"] + "</b></a></td>  </tr>";
                }
            }
        }
    }
}