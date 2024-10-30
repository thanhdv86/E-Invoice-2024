using System;
using System.Web;
using cskh.domain;
using DevExpress.Web;

namespace cskh.huewaco.vn
{
    public partial class Lich_TNCCNuoc : CsBaseControl
    {
        protected User objUser = new User(HttpContext.Current.User.Identity.Name);

        protected void Page_Load(object sender, EventArgs e)
        {
            SetUI();
            UICulture = "vi";
            Culture = "vi";
            if (HttpContext.Current.Request.IsAuthenticated) //Neu ko co ContractNumber nhung co Account
            {
                using (var obj = new EiBusinessImpl())
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
            datFrom.Date = DateTime.Now; datTo.Date = DateTime.Now.AddDays(7);
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void grvLich_OnDataBound(object sender, EventArgs e)
        {
            grvLich.DetailRows.ExpandAllRows();
        }

        protected void btnXem_OnClick(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated) //Neu ko co ContractNumber nhung co Account
            {
                Session["MAKV"] = objUser.MaKhuVuc.Trim();
            }
            else
            {
                using (var cr = new CrBusinessImpl())
                {
                    var ds = cr.GetCustomerInfo("", "", txtCustomerCode.Text, "", "", "", "", "", "", "");
                    Session["MAKV"] = ds.Rows[0]["makv"].ToString().Trim();
                }
            }

            grvLich.DataBind();

        }

        protected void grvLich_OnCustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "MaLoTrinh") return;
            var dt = Globals.DanhSachLoTrinh;
            if (dt == null) return;
            var tenlotrinh = dt.Select("maduongpho = '" + e.Value + "'");
            e.DisplayText = tenlotrinh[0]["maduongpho"] + " - " + tenlotrinh[0]["tenduongpho"];
        }
    }
}