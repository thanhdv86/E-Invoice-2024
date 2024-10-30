using System;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Web;
using cskh.domain;
using System.Resources;

namespace cskh.huewaco.vn
{
    public partial class LichSuSuDung : CsBaseControl
    {
        protected User objUser = new User(HttpContext.Current.User.Identity.Name);

        protected void Page_Load(object sender, EventArgs e)
        {
            SetUI();
            if (HttpContext.Current.Request.IsAuthenticated) //Neu ko co ContractNumber nhung co Account
            {
                using (var ebi = new EiBusinessImpl())
                {
                    //User objUser = new User(HttpContext.Current.User.Identity.Name);
                    //if (objUser.IsNormalUser)
                    //{
                    //    txtCustomerCode.Text = obj.getContractNumberByUsername(HttpContext.Current.User.Identity.Name);
                    //    txtCustomerCode.ReadOnly = true;
                    //}
                }
            }
            if (!IsPostBack) BindCondition();
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


        #region MultiLanguages
        public override void SetUI()
        {

        }
        #endregion
        #region RenderingEvent
        override protected void OnInit(EventArgs e)
        {
            Load += Page_Load;
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void grvLich_DataBinding(object sender, EventArgs e)
        {
            // Assign the data source in grvLich_DataBinding
            grvLich.DataSource = ViewState["DataLichSu"];
        }

        protected void grvLich_OnDataBound(object sender, EventArgs e)
        {
            grvLich.DataSource = ViewState["DataLichSu"];
        }

        protected void btnXem_OnClick(object sender, EventArgs e)
        {
            using (var cbi = new CrBusinessImpl())
            {
                var dt = cbi.GetLichSuDungNuocByIdkh(txtCustomerCode.Text);
                ViewState["DataLichSu"] = dt;
                grvLich.DataSource = dt;
                grvLich.DataBind();
            }
        }
    }
}