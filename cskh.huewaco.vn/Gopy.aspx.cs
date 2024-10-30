using System;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Resources;
using System.Web;
using System.Web.UI;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class Gopy : CsBaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadDonVi();
            }
        }
        #region MultiLanguages
        #endregion

        protected void btnGui_OnClick(object sender, EventArgs e)
        {
            using (var obj = new EiBusinessImpl())
            {
                obj.Insert_GopY(TxtTenKH.Text.Trim(), txtDiaChi.Text.Trim(), txtSDT.Text.Trim(), txtEmail.Text.Trim(), txtNoiDung.Text.Trim());

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Cảm ơn bạn đã gửi góp ý chúng tôi.');window.location.replace('Default.aspx');", true);
            }

        }
    }
}