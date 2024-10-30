using System;
using cskh.domain;

namespace cskh.huewaco.vn.Control
{
    public partial class ctrlFooter : CsBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetUI();
        }
        #region MultiLanguages
        public override void SetUI()
        {
            lblCPCAddress.Text = getString("strAddressValue"); 
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