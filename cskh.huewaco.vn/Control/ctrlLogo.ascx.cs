using System;
using System.Configuration;
using System.Web;
using System.Reflection;
using System.Resources;
using cskh.domain;

namespace cskh.huewaco.vn.Control
{
    public partial class ctrlLogo : CsBaseUserControl
    {
        protected string strImagesLogo;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetUI();
        }
        #region MultiLanguages
        public override void SetUI()
        {
            strImagesLogo = getString("strImagesLogo");
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