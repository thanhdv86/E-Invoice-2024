using System;
using System.Data;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class DichVu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool KiemTraUser()
        {
            try
            {
                using (var cr = new CrBusinessImpl())
                {
                    var dt = cr.GetCustomerInfo(txtContractNumber.Text.Trim(), "", "", "", "", "", "","","","");
                    return dt.Rows.Count > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        protected void btnDangKy_OnClick(object sender, EventArgs e)
        {
            if (!KiemTraUser())
            {
                lblError_idkh.Visible = true;
                return;
            }
            try
            {
                using (var ei = new EiBusinessImpl())
                {
                    if (ei.Insert_DichVu(rbLoaiDK.SelectedValue.Trim(), txtContractNumber.Text, txtCustomerName.Text.Trim(), txtSDT.Text, txtEmail.Text.Trim()) > 0)
                    {
                        Globals.ShowPopUpMsg(this, "Đã gửi yêu cầu thành công, nhân viên cskh sẽ liên lạc với quý khách sớm nhất!");
                    }

                }
            }
            catch (Exception ex)
            {
                //Globals.ShowPopUpMsg(this, String.Format("Error: {0} {1}", ex.HResult, ex.Message));
                Globals.ShowPopUpMsg(this,
                    ex.HResult == -2146232832
                        ? string.Format("Dịch vụ {0} đã được đăng ký. Không cần đăng ký lại!", rbLoaiDK.SelectedValue.Trim())
                        : "Có lỗi trong quá trình xử lý, vui lòng thử lại sau!");
            }
        }      
    }
}