using System;
using System.Data;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class Thutuccapnuoc : CsBaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) BindData();
        }
        private void BindData()
        {
            using (var ebi = new EiBusinessImpl())
            {
                var dt = ebi.GetDocuments("3");
                if (dt.Rows.Count > 0)
                {
                    lblContent.Text = Server.HtmlDecode(dt.Rows[0]["strDocContent"].ToString());
                }
            }
        }
    }
}