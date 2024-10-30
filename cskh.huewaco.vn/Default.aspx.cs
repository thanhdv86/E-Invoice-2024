using System;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;
using cskh.domain;
using DevExpress.Web;
using DevExpress.XtraCharts;

namespace cskh.huewaco.vn
{
    public partial class Default : CsBaseControl
    {
        protected string HtmlLogin = "";
        protected User objUser = new User(HttpContext.Current.User.Identity.Name);
        protected void Page_Load(object sender, EventArgs e)
        {
            SetUI();
            if (this.IsPostBack) return;
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                LoadLichSuSuDung();
                LoadLichCatNuoc();
                LoadLichGcs();
            }
            else
            {
                HtmlLogin = "Vui lòng đăng nhập tài khoản khách hàng để được xem thông tin này";
                charTieuThu.Visible = false;
                grvLich.Visible = false;
            }
            lblTinTD.DataBind();
        }
        protected void LoadLichCatNuoc()
        {
            if (!objUser.IsSuperUser)
            {
                LichDataSource.SelectParameters["MaKV"].DefaultValue = objUser.MaKhuVuc;

            }
        }
        protected void LoadLichGcs()
        {
            using (var cr = new CrBusinessImpl())
            {
                var dt = cr.GetLichGhiChiSo(objUser.ContractNumber, DateTime.Now.AddMonths(-3), DateTime.Now);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblGCS.Text = String.Format("Ngày ghi chỉ số: {0:dd/MM/yyyy}; Ngày ghi chỉ số tháng trước: {1:dd/MM/yyyy}", (DateTime)dt.Rows[0]["ngaynhap"], (DateTime)dt.Rows[0]["ngaynhap_tt"]);
                }
                else
                {
                    lblGCS.Text = "Chưa có thông tin";
                }
            }
        }
        protected void LoadLichSuSuDung()
        {
            if (objUser.IsSuperUser) return;
            using (var cr = new CrBusinessImpl())
            {
                var dt1 = cr.GetLichSuDungNuocByIdkh(objUser.ContractNumber);

                if (dt1 != null && dt1.Rows.Count > 0)
                {

                    //convert DataSet table to DataView  
                    DataView dv = dt1.DefaultView;

                    //apply the sort   
                    dv.Sort = "nam DESC, thang DESC";

                    //save back into our dataset  
                    DataTable dt = dv.ToTable();

                    //Series namHt = charTieuThu.Series["2015"];
                    //Series namTruoc = charTieuThu.Series["2014"];

                    Series namHt = charTieuThu.Series[0];
                    Series namTruoc = charTieuThu.Series[1];

                    namHt.Name = dt.Rows[0]["nam"].ToString();
                    namTruoc.Name = (int.Parse(dt.Rows[0]["nam"].ToString()) - 1).ToString();

                    for (var i = 3; i >= 0; i--)
                    {
                        if (dt.Rows.Count - 1 < i) continue;
                        var drHT = dt.Select(String.Format("nam = {0} and thang= {1}", dt.Rows[i]["nam"], dt.Rows[i]["thang"])).FirstOrDefault();

                        if (drHT == null) continue;
                        namHt.Points.Add(new SeriesPoint("Tháng " + drHT["thang"].ToString().ToUpper(),
                            Math.Round(double.Parse(drHT["tongtien"].ToString()), 0)));
                        DataRow drTruoc =
                            dt.Select(String.Format("nam = {0} and thang= {1}", ((int)drHT["nam"] - 1),
                                drHT["thang"])).FirstOrDefault();
                        if (drTruoc != null)
                        {
                            namTruoc.Points.Add(new SeriesPoint("Tháng " + drTruoc["thang"].ToString().ToUpper(),
                                Math.Round(double.Parse(drTruoc["tongtien"].ToString()), 0)));
                        }
                    }
                    lblCongNo.Text = String.Format("Tiền nước nhà bạn kỳ {0}/{1}: {2} VNĐ <br/> Tình trạng: {3}", dt.Rows[0]["thang"], dt.Rows[0]["nam"], Math.Round(double.Parse(dt.Rows[0]["tongtien"].ToString())).ToString("0,0", CultureInfo.CreateSpecificCulture(("el-GR"))), (bool.Parse(dt.Rows[0]["hetNo"].ToString()) ? "Đã nộp" : "Chưa thanh toán"));
                }
                else
                {
                    charTieuThu.Visible = false;
                    lblChart.Visible = true;
                    lblChart.Text = "Chưa có thông tin"; lblCongNo.Text = "Chưa có thông tin";
                }

            }
        }
        protected string MakeTitle(string title)
        {
            return Globals.VietNamese2English(title.Length > 100 ? title.Substring(0, 100) : title);
        }

        protected void grvLich_OnDataBound(object sender, EventArgs e)
        {
            grvLich.DetailRows.ExpandAllRows();
        }

        protected void grdDetail_OnBeforePerformDataSelect(object sender, EventArgs e)
        {
            var asPxGridView = sender as ASPxGridView;
            if (asPxGridView != null) Session["IDLich"] = asPxGridView.GetMasterRowKeyValue();
        }

        #region MultiLanguages
        public override void SetUI()
        {
            lblCompany.Text = Systems.CompanyValue;
            lblAddress.Text = string.Format("Địa chỉ: {0}, Phường {1}, Thành phố {2}, Tỉnh {3}", Systems.StreetValue, Systems.WardsValue, Systems.CityValue, Systems.ProvinceValue);
            lblPhone.Text = string.Format("Điện thoại: {0}", Systems.PhoneCCCValue);
            lblEmail.Text = string.Format("Email: {0}", Systems.EmailCskhValue);
        }
        #endregion
        #region RenderingEvent
        override protected void OnInit(EventArgs e)
        {
            Load += Page_Load;
        }
        #endregion
        protected void lblTinView_OnDataBinding(object sender, EventArgs e)
        {
            var dr = ((DataRowView)(grvTinTuc.GetRow(0)));
            lblTinTD.Text = dr[1].ToString();
            lblTinTT.Text = dr[2].ToString();
        }

        protected void grvLich_OnCustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "MaLoTrinh") return;
            var ds = Globals.DanhSachLoTrinh;
            if (ds == null) return;
            var tenlotrinh = ds.Select("maduongpho = '" + e.Value + "'");
            e.DisplayText = tenlotrinh[0]["maduongpho"] + " - " + tenlotrinh[0]["tenduongpho"];
        }
    }
}
