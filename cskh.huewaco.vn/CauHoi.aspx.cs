using System;
using System.Data;
using cskh.domain;
using System.Web.UI;

namespace cskh.huewaco.vn
{
    public partial class CauHoi : Page
    {
        protected string htmlContent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["idch"] != null)
                {
                    divCauHoi.Visible = true;
                    divListCH.Visible = false;
                    LoadDetailCauHoi(Request.QueryString["idch"]);
                }
                else
                {
                    divCauHoi.Visible = false;
                    divListCH.Visible = true;
                    LoadDsCauHoi();
                }

            }
        }

        protected void LoadDetailCauHoi(string id)
        {
            using (var ebi = new EiBusinessImpl())
            {
                var dt = ebi.GetDsCauHoiById(id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblNoiDung.Text = dt.Rows[0]["NoiDung"].ToString();
                    lblTraLoi.Text = dt.Rows[0]["TraLoi"].ToString();
                }
            }
        }

        protected void LoadDsCauHoi()
        {
            using (var ebi = new EiBusinessImpl())
            {
                var dt = ebi.GetDsCauHoiThuongGap();
                foreach (DataRow item in dt.Rows)
                {
                    string trichND = (item["TraLoi"].ToString().Length > 100)
                        ? item["TraLoi"].ToString().Substring(0, 100)
                        : item["TraLoi"].ToString();
                    htmlContent +=
                     "<tr><td ><img src='images/icon_question.png'></td> <td><b>" + item["TieuDe"] + "</b> " +
                        //"<br/> " + trichND + "... <br/>" +
                     "<a style='float: right' href='CauHoi.aspx?idch=" + item["ID"] + "'>Xem thêm</a></td></tr>";
                }
            }
        }
    }
}