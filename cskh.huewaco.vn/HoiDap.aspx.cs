using System;
using System.Data;
using System.Web;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class HoiDap : System.Web.UI.Page
    {
        protected User objUser = new User(HttpContext.Current.User.Identity.Name);
        protected string htmlContent = string.Empty;
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["idch"] != null)
                {
                    divCauHoi.Visible = true;
                    divListCH.Visible = false;
                    LoadDetailCauHoi(Request.QueryString["idch"].ToString());
                }
                else
                {
                    divCauHoi.Visible = false;
                    divListCH.Visible = true;
                    LoadDSCauHoi();    
                }
                
            }
        }

        protected void LoadDetailCauHoi(string id)
        {
            using (var ei = new EiBusinessImpl())
            {
                DataTable dt = ei.GetDsCauHoiById(id);

                lblNoiDung.Text = dt.Rows[0]["NoiDung"].ToString();
                lblTraLoi.Text = dt.Rows[0]["TraLoi"].ToString();
            }
        }

        protected void LoadDSCauHoi()
        {
            using (var userAccess = new EiBusinessImpl())
            {
                DataTable dt = userAccess.GetDsCauHoiByKey("");

                foreach (DataRow item in dt.Rows)
                {
                    string trichND = (item["TraLoi"].ToString().Length > 100)
                        ? item["TraLoi"].ToString().Substring(0, 100)
                        : item["TraLoi"].ToString();
                    htmlContent +=
                     "<tr><td ><img src='images/icon_question.png'></td> <td><b>" + item["TieuDe"] + "</b> " +
                     //"<br/> " + trichND + "... <br/>" +
                     "<a style='float: right' href='HoiDap.aspx?idch=" + item["ID"] + "'>Xem tiếp</a></td>  </tr>";
                }
            }
        }

        protected void btnGuiCH_OnClick(object sender, EventArgs e)
        {
            try
            {
                using (var ei = new EiBusinessImpl())
                {
                    if (ei.Insert_CauHoi(txtTieuDe.Text, txtNoiDung.Text, txtLienHe.Text.Trim() + " - " + txtSDT.Text.Trim() + " - " + txtEmail.Text.Trim()) > 0)
                    {
                        Globals.ShowPopUpMsg(this.Page, "Đã gửi câu hỏi thành công!");
                        Response.Redirect("HoiDap.aspx");
                    }
                    else
                    {
                        Globals.ShowPopUpMsg(this, "Gửi câu hỏi không thành công! Vui lòng thử lại.");
                    }

                }
            }
            catch (Exception )
            {
                throw;
            }
        }


        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            using (var ei = new EiBusinessImpl())
            {
                DataTable dt = ei.GetDsCauHoiByKey(txtSearch.Text.Trim());

                foreach (DataRow item in dt.Rows)
                {
                    string trichND = (item["TraLoi"].ToString().Length > 100)
                        ? item["TraLoi"].ToString().Substring(0, 100)
                        : item["TraLoi"].ToString();
                    htmlContent +=
                     "<tr><td ><img src='images/icon_question.png'></td> <td><b>" + item["TieuDe"] + "</b> " +
                     //"<br/> " + trichND + "... <br/>" +
                     "<a style='float: right' href='HoiDap.aspx?idch=" + item["ID"] + "'>Xem thêm</a></td>  </tr>";
                }
            }
        }

    }
}