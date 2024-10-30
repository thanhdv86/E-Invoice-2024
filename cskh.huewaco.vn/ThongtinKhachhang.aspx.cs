using System;
using System.Web;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class ThongtinKhachhang : CsBaseControl
    {
        private static User GetObj()
        {
            var obj = new User(HttpContext.Current.User.Identity.Name);
            return obj;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var obj = GetObj();

                lblTEN_KHANG.Text = obj.CustomerName;
                lblMA_KHANG.Text = obj.ContractNumber;
                lblAddress.Text = obj.DiaChi;
                lblTel.Text = obj.SDT;

                txtTEN_KHANG.Text = obj.CustomerName;
                txtSDT.Text = obj.SDT;
                txtDIACHI.Text = obj.DiaChi;
            }
        }
     

        #region MultiLanguages
        public override void SetUI()
        {
            //strImages = getString("imgGioithieu");
            //strGioithieu1 = getString("strGioithieu1");
            //strGioithieu2 = getString("strGioithieu2");
        }
        #endregion
        #region RenderingEvent
        override protected void OnInit(EventArgs e)
        {
            Load += Page_Load;
        }
        #endregion

        protected void btnGui_OnClick(object sender, EventArgs e)
        {
            try
            {
                using (var ebi = new EiBusinessImpl())
                {
                    var user = GetObj();
                    ebi.InsertYeuCauThayDoiThongTinKh(user.ContractNumber,txtTEN_KHANG.Text.Trim(), txtSDT.Text.Trim(), txtDIACHI.Text.Trim());
                    Globals.ShowPopUpMsg(Page, "Gửi yêu cầu thành công. Đang chờ phê duyệt");
                }
            }
            catch (Exception ex)
            {
                Globals.ShowPopUpMsg(Page, String.Format("Có lỗi xảy ra {0}! Vui lòng thử lại", ex.Message));
            }
            
        }
    }
}