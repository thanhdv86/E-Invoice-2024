using System;
using System.Data;
using System.Web;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class LichSuCapNuoc : CsBaseControl
    {
        protected User objUser = new User(HttpContext.Current.User.Identity.Name);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) BindCondition();
        }

        private void BindCondition()
        {
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
            // Assign the data source in grvLich_DataBinding
            grvLich.DataSource = ViewState["DataLichSuCapNuoc"];
        }
        protected void grvLich_OnDataBound(object sender, EventArgs e)
        {
            grvLich.DataSource = ViewState["DataLichSuCapNuoc"];
        }


        protected void btnXem_OnClick(object sender, EventArgs e)
        {

            using (var cr = new CrBusinessImpl())
            {
                var dt = cr.GetLichSuCapNuocByIdkh(txtCustomerCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    UtilCustCares.MappingFunction("GetLichSuCapNuocByIDKH", ref dt);
                }
                ViewState["DataLichSuCapNuoc"] = dt;
                grvLich.DataSource = dt;
                grvLich.DataBind();
                //grvLich.SortBy(grvLich.Columns[2], DevExpress.Data.ColumnSortOrder.Descending);                
            }
        }
    }
}