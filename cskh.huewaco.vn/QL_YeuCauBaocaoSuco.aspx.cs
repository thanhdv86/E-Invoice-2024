using DevExpress.Web;
using System;

namespace cskh.huewaco.vn
{
    public partial class QL_YeuCauBaocaoSuco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Details_Grid_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["Id"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
    }
}