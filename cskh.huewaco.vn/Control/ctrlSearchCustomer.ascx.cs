using System;
using System.Data;
using cskh.domain;

namespace cskh.huewaco.vn.Control
{
    public partial class ctrlSearchCustomer : CsBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Globals.LoadKhuVuc(ddlKhuVuc);
                Globals.LoadQuanHuyen(ddlQuan);
                Globals.LoadPhuongXa(ddlPhuong);
            }
        }

        protected void lnkShowSearch_OnClick(object sender, EventArgs e)
        {
            Timten.Visible = true;
        }
        protected void grdKetQua_OnDataBinding(object sender, EventArgs e)
        {
            grdKetQua.DataSource = ViewState["DataService"];
        }
        protected void btnTim_OnClick(object sender, EventArgs e)
        {
            if (
                (!string.IsNullOrWhiteSpace(ddlKhuVuc.SelectedValue)) ||
                (!string.IsNullOrWhiteSpace(ddlQuan.SelectedValue)) ||
                (!string.IsNullOrWhiteSpace(ddlPhuong.SelectedValue)) ||
                (!string.IsNullOrWhiteSpace(TxtTenKH.Text.Trim())) ||
                (!string.IsNullOrWhiteSpace(TxtSDT.Text.Trim())) ||
                (!string.IsNullOrWhiteSpace(TxtSoNha.Text.Trim())) ||
                (!string.IsNullOrWhiteSpace(TxtTenDuongPho.Text.Trim()))
                )
            {
                if (Captcha.IsValid)
                {
                    System.Threading.Thread.Sleep(1);
                    using (var cr = new CrBusinessImpl())
                    {
                        var dt = cr.GetCustomerInfo("", "", TxtTenKH.Text.Trim(), "", TxtSDT.Text.Trim(), TxtSoNha.Text.Trim(), TxtTenDuongPho.Text.Trim(), ddlKhuVuc.SelectedValue, ddlQuan.SelectedValue, ddlPhuong.SelectedValue);
                        ViewState["DataService"] = dt;
                        grdKetQua.DataSource = dt;
                        grdKetQua.DataBind();
                        grdKetQua.ClientVisible = true;
                    }
                }
                else
                {
                    Globals.ShowPopUpMsg(this.Page, "Mã xác thực không đúng!");
                }
            }
            else
            {
                Globals.ShowPopUpMsg(this.Page, "Yêu cầu nhập thông tin của Khách hàng cần tìm kiếm.");
            }
        }

        protected void ddlQuan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}