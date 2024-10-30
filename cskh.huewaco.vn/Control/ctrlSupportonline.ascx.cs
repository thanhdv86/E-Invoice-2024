using System;
using System.Web;
using cskh.domain;

namespace cskh.huewaco.vn.Control
{
    public partial class ctrlSupportonline : CsBaseUserControl
    {
        protected User objUser = new User(HttpContext.Current.User.Identity.Name);
        protected void Page_Load(object sender, EventArgs e)
        {
            SetUI();
            //Load_ConInfo();
        }

        protected void Load_ConInfo()
        {
            //string pMaKH = objUser.DivisionCode;
            //DataTable dt;
            //using (UserAccess obj = new UserAccess())
            //{
            //    if (pMaKH.ToString() != "")
            //    {
            //        dt = obj.getInfoCompanyByCompanycode(pMaKH).Tables[0];
            //    }
            //    else
            //    {
            //        dt = obj.getInfoCompanyByCompanycode("").Tables[0];
            //    }
            //    dlCSKH.DataSource = dt;
            //    dlCSKH.DataBind();
            //}
        }

        #region MultiLanguages
        public override void SetUI()
        {
            lblPhoneCCC.Text = Systems.PhoneCCCValue;
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