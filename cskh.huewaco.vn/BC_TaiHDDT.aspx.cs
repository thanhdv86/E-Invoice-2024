using System;
using System.Data;
using System.Web.UI;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class BC_TaiHDDT : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (var i = DateTime.Now.Year - 4; i <= DateTime.Now.Year; i++)
                {
                    ddlNam.Items.Add(i.ToString());
                }

                for (var i = 1; i <= 12; i++)
                {
                    ddlKy.Items.Add(i.ToString());
                }

                ddlKy.SelectedValue = DateTime.Now.Month.ToString();
                ddlNam.SelectedValue = DateTime.Now.Year.ToString();
                Session["DataService"] = null; 
            }
        }

        private void LoadData()
        {
            if (
                (int.Parse(ddlKy.SelectedValue) != 0) ||
                (int.Parse(ddlNam.SelectedValue) != 0)
            )
            {
                using (var userAccess = new EiBusinessImpl())
                {
                    var dt = userAccess.Bc_TaiHDDT(int.Parse(ddlNam.SelectedValue), int.Parse(ddlKy.SelectedValue));
                    //ViewState["DataService"] = (dt != null && dt.Rows.Count > 0) ? dt : null;
                    Session["DataService"] = (dt != null && dt.Rows.Count > 0) ? dt : null;
                    //grvHDDT.DataSource = dt;
                    grvHDDT.DataBind();
                    //grvHDDT.ClientVisible = true;

                }
            }
            else
            {
                Globals.ShowPopUpMsg(Page, "Yêu cầu nhập thông tin cần thiết.");
            }
        }

        protected void btnTim_OnClick(object sender, EventArgs e)
        {
            LoadData();
        }

    protected void grvHDDT_DataBinding(object sender, EventArgs e)
        {
            grvHDDT.DataSource = (DataTable)Session["DataService"];
        }
    }
}