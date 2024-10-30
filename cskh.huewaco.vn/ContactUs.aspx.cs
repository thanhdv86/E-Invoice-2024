using System;
using System.Data;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class ContactUs : CsBaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindData();
        }
        private void BindData()
        {

            using (var ebi = new EiBusinessImpl())
            {
                var dt = ebi.GetDocuments("11");
                if (dt!=null && dt.Rows.Count > 0)
                {
                    lblContent.Text = Server.HtmlDecode(dt.Rows[0]["strDocContent"].ToString());
                }
            }
        }
        #region RenderingEvent
        override protected void OnInit(EventArgs e)
        {
            Load += Page_Load;
        }
        #endregion
    }
}