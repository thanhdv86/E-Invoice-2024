using System;
using System.Data;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class VanBanPhapLuat : CsBaseControl
    {
        protected string htmlContent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDSVanBan();

            }
        }

        protected void LoadDSVanBan()
        {
            using (var ei = new EiBusinessImpl())
            {
                DataTable dt = ei.GetDsVanBan();

                foreach (DataRow item in dt.Rows)
                {
                    htmlContent +=
                     "<tr><td ><img src='images/icon_vanban.png'></td> <td><b>" + item["TieuDe"] + "</b> </td>  <td><a href='VanBan/" + item["FileLink"] + "' target='_blank'><img src='images/icon_download.png' /></a> </td> </tr>";
                }
            }
        }
    }
}