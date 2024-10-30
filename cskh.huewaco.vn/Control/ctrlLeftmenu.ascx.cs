using System;
using System.Web;
using System.Configuration;
using System.Data;
using cskh.domain;

namespace cskh.huewaco.vn.Control
{
    public partial class ctrlLeftmenu : CsBaseUserControl
    {
        protected string DVKH, TCTD, DKDVHT, DKCDM, TTC, HD, KST, CNQL, XEX, QLHD, QLT, QLND;
        private string strKeyLanguage = ConfigurationManager.AppSettings["defaultLanguage"];
        protected void Page_Load(object sender, EventArgs e)
        {
            SetUI();
            if (!IsPostBack) BindData();
        }
        private void BindData()
        {
            using (var ebi = new EiBusinessImpl())
            {
                rptMenu.DataSource = ebi.GetMenuParents(strKeyLanguage, HttpContext.Current.User.Identity.Name);
                rptMenu.DataBind();
            }
        }
        protected DataTable GetSubMenuByParentID(int intParentID)
        {
            using (var ebi = new EiBusinessImpl())
            {
                return ebi.GetSubMenuByParentId(intParentID, strKeyLanguage, HttpContext.Current.User.Identity.Name);
            }
        }
        #region MultiLanguages
        public override void SetUI()
        {
            //DVKH = getString("strDVKH");
            //TCTD = getString("strTCTTTD");
            //DKDVHT = getString("strDKDVHT");
            //DKCDM = getString("strRegisterContract");
            //TTC = getString("strTTC");
            //HD = getString("strQuestion");
            //KST = getString("strCustomerSurvey");
            //CNQL = getString("strCNQL");
            //XEX = getString("strExport");
            //QLHD = getString("strNewContractManage");
            //QLT = getString("strSurveyManage");
            //QLND = getString("strUserManage");

            TCTD = "Tra cứu tiền Nước";
            DKDVHT = "Đăng ký dịch vụ hỗ trợ";
            DKCDM = "Đăng ký cấp Nước mới";
            TTC = "Thông tin chung";
            HD = "Hỏi đáp và Góp ý";
            KST = "Khảo sát thư";
            CNQL = "Chức năng quản lý";
            XEX = "Xuất Excel";
            QLHD = "Quản lý hợp đồng mua bán Nước";
            QLT = "Quản lý danh mục thư";
            QLND = "Quản lý người dùng";

            strKeyLanguage = "vi-VN";
        }
        #endregion
        #region RenderingEvent
        override protected void OnInit(EventArgs e)
        {
            Load += Page_Load;
        }
        #endregion
    }
}