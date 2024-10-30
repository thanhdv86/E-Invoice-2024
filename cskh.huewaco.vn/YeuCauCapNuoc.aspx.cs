using System;
using System.Web;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class YeuCauCapNuoc : CsBaseControl
    {
        #region RenderingEvent
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion
        protected User objUser = new User(HttpContext.Current.User.Identity.Name);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Globals.LoadKhuVuc(ddlKhuVuc);
                Globals.LoadQuanHuyen(ddlQuan);
                Globals.LoadPhuongXa(ddlPhuong);
            }
        }

        protected void btnDangKy_OnClick(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            try
            {
                using (var ei = new EiBusinessImpl())
                {
                    if (ei.Insert_YeuCau(rbLoaiDK.SelectedValue.Trim(), ddlKhuVuc.SelectedValue,
                        ddlPhuong.SelectedValue, txtTenKH.Text, txtSoNha.Text, txtSDT.Text, "",
                        txtDuongPho.Text, txtEmail.Text, Server.HtmlDecode(txtNoiDung.Text)) > 0)
                    {
                        Globals.ShowPopUpMsg(this, "Đã gửi yêu cầu thành công, nhân viên cskh sẽ liên lạc với quý khách sớm nhất!");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}