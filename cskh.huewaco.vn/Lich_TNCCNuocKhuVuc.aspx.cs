using System;
using System.Data;
using System.Web.UI.WebControls;
using cskh.domain;
using DevExpress.Web;

namespace cskh.huewaco.vn
{
    public partial class Lich_TNCCNuocKhuVuc : CsBaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UICulture = "vi";
            Culture = "vi";
            if (!IsPostBack)
            {
                Globals.LoadKhuVuc(ddlKhuVuc);
                Globals.LoadLoTrinh(ddlLoTrinh,ddlKhuVuc);
                datFrom.Date = DateTime.Now; 
                datTo.Date = DateTime.Now.AddDays(7);
                //LoadLoTrinh();
                grdKetQua.DataBind();
                //grdKetQua.DetailRows.ExpandAllRows();

            }
        }

        //protected void LoadLoTrinh()
        //{

        //    if (Globals.DanhSachMaLoTrinh == null)
        //    {
        //        using (var cr = new CrBusinessImpl())
        //        {
        //            var dt = cr.GetDanhSachLoTrinh();
        //            Globals.DanhSachMaLoTrinh = dt;
        //            ddlLoTrinh.Items.Clear();
        //            ddlLoTrinh.Items.Insert(0, new ListItem("Tất cả", "%%"));
        //            foreach (DataRow duongpho in dt.Rows)
        //            {
        //                if (duongpho["makhuvuc"].ToString().Trim().Equals(ddlKhuVuc.SelectedValue))
        //                {
        //                    ddlLoTrinh.Items.Add(new ListItem(duongpho["maduongpho"] + " - " + duongpho["tenduongpho"], duongpho["maduongpho"].ToString()));
        //                }
        //            }
        //        }

        //    }
        //    else
        //    {
        //        var dt = Globals.DanhSachMaLoTrinh;
        //        ddlLoTrinh.Items.Clear();
        //        ddlLoTrinh.Items.Insert(0, new ListItem("Tất cả", "%%"));
        //        foreach (DataRow duongpho in dt.Rows)
        //        {
        //            if (duongpho["makhuvuc"].ToString().Trim().Equals(ddlKhuVuc.SelectedValue))
        //            {
        //                ddlLoTrinh.Items.Add(new ListItem(duongpho["maduongpho"].ToString() + " - " + duongpho["tenduongpho"].ToString(), duongpho["maduongpho"].ToString()));
        //            }
        //        }
        //    }

        //}

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1);
            grdKetQua.DataBind();
        }

        protected void grdDetail_OnBeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["IDLich"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void ddlKhuVuc_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var dt = Globals.DanhSachLoTrinh;

            ddlLoTrinh.Items.Clear();
            ddlLoTrinh.Items.Insert(0, new ListItem("Tất cả", "%%"));
            foreach (DataRow duongpho in dt.Rows)
            {
                if (duongpho["makhuvuc"].ToString().Trim().Equals(ddlKhuVuc.SelectedValue))
                {
                    ddlLoTrinh.Items.Add(new ListItem(duongpho["maduongpho"] + " - " + duongpho["tenduongpho"], duongpho["maduongpho"].ToString()));
                }
            }

            //ddlLoTrinh.DataBind();
            grdKetQua.DataBind();
        }

        protected void grdKetQua_OnDataBound(object sender, EventArgs e)
        {
            grdKetQua.DetailRows.ExpandAllRows();
        }

        protected void ddlKhuVuc_OnDataBound(object sender, EventArgs e)
        {
            ddlKhuVuc.Items.Insert(0, new ListItem("Tất cả", "%%"));
        }


        protected void grdKetQua_OnCustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "MaLoTrinh") return;
            var dt = Globals.DanhSachLoTrinh;
            if (dt == null) return;
            var tenlotrinh = dt.Select("maduongpho = '" + e.Value + "'");
            e.DisplayText = tenlotrinh[0]["maduongpho"] + " - " + tenlotrinh[0]["tenduongpho"];
        }
    }
}