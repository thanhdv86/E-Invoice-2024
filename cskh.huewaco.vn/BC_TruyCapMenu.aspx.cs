using System;
using DevExpress.Web;
using System.Web.UI;

namespace cskh.huewaco.vn
{
    public partial class BC_TruyCapMenu : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                datTo.Date = DateTime.Now; datFrom.Date = DateTime.Now.AddMonths(-1);
            }
        }



        protected void grvDeTail_OnBeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["ParentID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void grvTruyCap_OnDataBound(object sender, EventArgs e)
        {
            grvTruyCap.DetailRows.ExpandAllRows();
        }
    }
}