using System;
using System.Data;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class Diemthutiennuoc : CsBaseControl
    {
        protected string htmlContent = string.Empty;
        protected string datamap = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Globals.LoadKhuVuc(ddlKV);
            }
        }
        public string GetDataMap()
        {
            try
            {
                using (var ebi = new EiBusinessImpl())
                {
                    var dt = ebi.GetDsQuayThu(ddlKV.SelectedValue.Trim());
                    var content = string.Empty;
                    foreach (DataRow dr in dt.Rows)
                    {
                        content += string.Format("{{" + "'title': '{0}', " + "'lat': '{1}', " + "'lng': '{2}', " + "'description': '{0}<br/>{3}<br/>{4}', " + "'icon': 'Images/icon_puspin.png'" + "}},", dr["TenQuayThu"], dr["ViDo"], dr["KinhDo"], dr["DiaChi"].ToString().Replace("'", " "), dr["GhiChu"].ToString().Replace("'", " "));
                        htmlContent += string.Format("<tr><td ><img src='Images/icon_puspin.png'></td> <td><b>{0}</b> </td> <td><b>{1}</b> </td>  </tr>", dr["TenQuayThu"], dr["DiaChi"]);
                    }
                    return string.Format("[{0}]", content);
                }                               
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ddlKV_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "LoadMap", "LoadMap()", true);
        }
    }
}