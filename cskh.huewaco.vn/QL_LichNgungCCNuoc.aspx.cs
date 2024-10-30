using System;
using System.Data;
using System.Web;
using cskh.domain;
using DevExpress.Web;

namespace cskh.huewaco.vn
{
    public partial class QL_LichNgungCCNuoc : CsBaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UICulture = "vi";
            Culture = "vi";
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                var objUser = new User(HttpContext.Current.User.Identity.Name);
                if (!objUser.IsSuperUser) Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                LoadLoTrinh();
            }
        }


        protected void LoadLoTrinh()
        {
            if (Globals.DanhSachLoTrinh == null)
            {
                using (var cbi = new CrBusinessImpl())
                {
                    Globals.DanhSachLoTrinh = cbi.GetDanhSachLoTrinhTheoKhuVuc("%");
                }
            }

            var combo = grdLich.Columns["MaLoTrinh"] as GridViewDataComboBoxColumn;

            if (combo != null)
            {
                combo.PropertiesComboBox.ValueType = typeof(string);
                foreach (DataRow duongpho in Globals.DanhSachLoTrinh.Rows)
                {
                    combo.PropertiesComboBox.Items.Add(duongpho["maduongpho"] + "-" + duongpho["tenduongpho"], duongpho["maduongpho"].ToString());
                }
            }

            var lblo = (ASPxListBox)drllo.FindControl("lblo");
            if (lblo != null)
            {
                lblo.ValueType = typeof(string);
                lblo.Items.Add("(Chọn tất cả)");
                foreach (DataRow duongpho in Globals.DanhSachLoTrinh.Rows)
                {
                    lblo.Items.Add(duongpho["maduongpho"] + "-" + duongpho["tenduongpho"], duongpho["maduongpho"].ToString());
                }
            }
        }
        protected void FillLoTrinhCombo(ASPxComboBox cmb, string makhuvuc)
        {
            if (string.IsNullOrEmpty(makhuvuc)) return;

            var dt = Globals.DanhSachLoTrinh;

            cmb.Items.Clear();
            foreach (DataRow duongpho in dt.Rows)
            {
                if (duongpho["makhuvuc"].ToString().Trim().Equals(makhuvuc))
                {
                    cmb.Items.Add(duongpho["maduongpho"] + "-" + duongpho["tenduongpho"], duongpho["maduongpho"].ToString());
                }
            }
        }

        protected void FillLoTrinhListbox(ASPxListBox lbx, string makhuvuc)
        {
            if (string.IsNullOrEmpty(makhuvuc)) return;

            var dt = Globals.DanhSachLoTrinh;

            lbx.Items.Clear();
            lbx.Items.Add("(Chọn tất cả)");
            foreach (DataRow duongpho in dt.Rows)
            {
                if (duongpho["makhuvuc"].ToString().Trim().Equals(makhuvuc))
                {
                    lbx.Items.Add(duongpho["maduongpho"] + "-" + duongpho["tenduongpho"], duongpho["maduongpho"].ToString());
                }
            }
        }

        protected void grdLich_OnCellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (!grdLich.IsEditing || e.Column.FieldName != "MaLoTrinh") return;

            var combo = e.Editor as ASPxComboBox;
            if (!grdLich.IsNewRowEditing)
            {
                if (e.KeyValue == DBNull.Value || e.KeyValue == null) return;
                object val = grdLich.GetRowValuesByKeyValue(e.KeyValue, "MaKV");
                if (val == DBNull.Value) return;
                var makv = (string)val;

                FillLoTrinhCombo(combo, makv);
            }

            if (combo != null) combo.Callback += cmbLoTrinh_OnCallback;
        }
        void cmbLoTrinh_OnCallback(object source, CallbackEventArgsBase e)
        {
            FillLoTrinhCombo(source as ASPxComboBox, e.Parameter);
        }

        protected void grdDetail_OnBeforePerformDataSelect(object sender, EventArgs e)
        {
            var asPxGridView = sender as ASPxGridView;
            if (asPxGridView != null) Session["IDLich"] = asPxGridView.GetMasterRowKeyValue();
        }

        protected string NgayCatDien(object datPcDate)
        {
            var dayOfWeek = new[] { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };
            var datDay = Convert.ToDateTime(datPcDate);
            return dayOfWeek[Convert.ToInt16(datDay.DayOfWeek)] + ", " + datDay.ToString("dd/MM/yyyy");
        }


        protected void grdLich_OnCustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "NgayBatDau")
            {
                e.DisplayText = NgayCatDien(e.Value);
            }
        }
        protected void cbKhuvuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lblo = (ASPxListBox)drllo.FindControl("lblo");
            FillLoTrinhListbox(lblo, cbKhuvuc.SelectedItem.Value.ToString());
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            var malotenlo = drllo.Value.ToString().Split(';');
            for (var i = 0; i < malotenlo.Length; i++)
            {
                string mavaten = malotenlo[i].Split('-')[0];
                using (var ei = new EiBusinessImpl())
                {
                    ei.Addmalo(Convert.ToDateTime(datebegin.Value), Convert.ToDateTime(dateend.Value), Convert.ToInt32(hourbegin.Value), Convert.ToInt32(minbegin.Value), Convert.ToInt32(hourend.Value), Convert.ToInt32(minend.Value), mmLydo.Text, Convert.ToBoolean(cbSuco.Value), mavaten, cbKhuvuc.SelectedItem.Value.ToString());
                }
            }
            Globals.ShowPopUpMsg(Page, string.Format("Thêm {0} mã lộ thành công", malotenlo.Length));
            grdLich.DataBind();
        }

    }
}