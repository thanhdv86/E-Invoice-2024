using System;
using System.Data;
using System.Web;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class LichGhiChiSo : CsBaseControl
    {
        protected User objUser = new User(HttpContext.Current.User.Identity.Name);
        protected void Page_Load(object sender, EventArgs e)
        {
            UICulture = "vi";
            Culture = "vi";
            if (!this.IsPostBack) BindCondition();
        }

        private void BindCondition()
        {
            datFrom.Date = DateTime.Now.AddDays(-30); datTo.Date = DateTime.Now.AddDays(30);
            if (HttpContext.Current.Request.IsAuthenticated) //Neu ko co ContractNumber nhung co Account
            {
                if (objUser != null)
                {
                    txtCustomerCode.Text = objUser.ContractNumber;
                }
            }
        }

        protected void grvLich_DataBinding(object sender, EventArgs e)
        {
            grvLich.DataSource = ViewState["DataLichGCS"];
        }
        protected void grvLich_OnDataBound(object sender, EventArgs e)
        {
            grvLich.DataSource = ViewState["DataLichGCS"];
        }

        protected void btnXem_OnClick(object sender, EventArgs e)
        {

            using (var cr = new CrBusinessImpl())
            {
                var dt = cr.GetLichGhiChiSo(txtCustomerCode.Text, (DateTime)(datFrom.Value), (DateTime)(datTo.Value));
                ViewState["DataLichGCS"] = dt;
                grvLich.DataSource = dt;
                grvLich.DataBind();
                grvLich.SortBy(grvLich.Columns[3], DevExpress.Data.ColumnSortOrder.Descending);

            }
        }
    }
}