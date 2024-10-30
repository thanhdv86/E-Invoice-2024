using System;
using System.Data;
using System.Web;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class LichSuThanhToan : CsBaseControl  //System.Web.UI.Page
    {
        public string TC_MSKH = "";
        public string MA_KH = "";
        public string TenKH = "";
        public string DiachiKH = "";
        public string Soho = "";
        //public int Soho;
        public string DVQUANLY = "";
        public string MADVQUANLY = "";
        public string CTQUANLY = "";
        //Public tong_no As Double = 0
        public string LoaiKH = "";
        public string LoaiHD = "";
        public string MasoGCS = "";
        public string Sopha = "";
        public string LoaiDDo = "";

        public string HSNhan = "";
        public string MaCto = "";
        public string SoCto = "";
        public string Sotru = "";
        public string BCS = "";
        public string Matram = "";
        public string Tentram = "";
        public string NgayKDCto = "";
        public string VitriCto = "";

        public string NgayHLHDong = "";
        public string Mahd1 = "";
        public string NgayhetHLHD1 = "";
        public string MaDDo1 = "";
        public string ManhomN1 = "";
        public string MaNN1 = "";
        public string STTtheoso1 = "";

        public string Chisomoi1 = "";
        public string NVkepchi = "";
        public string KDinhTI = "";
        public string CStram = "";

        public string Typetram = "";
        public string Nhomgia = "";
        public string Ngayktsdd = "";

        public Double Tien_no_tong;
        private string TtinKH;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.IsAuthenticated)
                {
                    var objUser = new User(HttpContext.Current.User.Identity.Name);
                    TxtMKH.Text = objUser.ContractNumber;
                }
            }
        }
        //Xuat du lieu ra bang phan tra cuu theo ma khach hang
        protected void Bindulieu()
        {
            try
            {
                var ds = new DataSet();
                //De lay dia chi treo cong to cua KH --> dung services duoi day

                if ((ds != null))
                {
                    TenKH = ds.Tables[0].Rows[0]["TEN_KHANG"].ToString();
                    DiachiKH = ds.Tables[0].Rows[0]["DCHI_DDO"].ToString();
                    MADVQUANLY = ds.Tables[0].Rows[0]["MA_DVIQLY"].ToString();

                    if (MADVQUANLY.Substring(0, 4) == "PC00")
                    {
                        DVQUANLY = "Công ty lưới Nước cao thế Miền trung";
                    }
                    else
                    {
                        DVQUANLY = ds.Tables[0].Rows[0]["TEN_DVIQLY"].ToString();
                    }

                    CTQUANLY = ds.Tables[0].Rows[0]["TEN_CONGTY"].ToString();
                    Soho = ds.Tables[0].Rows[0]["SO_HO"].ToString();
                    LoaiKH = ds.Tables[0].Rows[0]["LOAI_KHANG"].ToString();
                    LoaiHD = ds.Tables[0].Rows[0]["LOAI_HDONG"].ToString();
                    MasoGCS = ds.Tables[0].Rows[0]["MA_SOGCS"].ToString();
                    Sopha = ds.Tables[0].Rows[0]["SO_PHA"].ToString();
                    LoaiDDo = ds.Tables[0].Rows[0]["LOAI_DDO"].ToString();
                    HSNhan = ds.Tables[0].Rows[0]["HS_NHAN"].ToString();
                    MaCto = ds.Tables[0].Rows[0]["MA_CTO"].ToString();
                    Sotru = ds.Tables[0].Rows[0]["SO_COT"].ToString();
                    SoCto = ds.Tables[0].Rows[0]["SO_CTO"].ToString();
                    BCS = ds.Tables[0].Rows[0]["BCS"].ToString();
                    Matram = ds.Tables[0].Rows[0]["MA_TRAM"].ToString();
                    Tentram = ds.Tables[0].Rows[0]["TEN_TRAM"].ToString();
                    NgayHLHDong = ds.Tables[0].Rows[0]["NGAY_HLUC"].ToString();
                    NgayKDCto = ds.Tables[0].Rows[0]["NGAY_KDINH_LAI"].ToString();

                    VitriCto = ds.Tables[0].Rows[0]["VITRI_CONGTO"].ToString();
                    if (VitriCto == "NT")
                    {
                        VitriCto = "Ngoài trụ";
                    }
                    else
                    {
                        VitriCto = "Trong nhà";
                    }
                    //
                    Mahd1 = ds.Tables[0].Rows[0]["MA_HDONG"].ToString();
                    NgayhetHLHD1 = ds.Tables[0].Rows[0]["NGAY_HET_HLUC"].ToString();
                    MaDDo1 = ds.Tables[0].Rows[0]["MA_DIEMDO"].ToString();
                    ManhomN1 = ds.Tables[0].Rows[0]["MA_NHOMNN"].ToString().Substring(9);
                    MaNN1 = ds.Tables[0].Rows[0]["MA_NN"].ToString().Substring(9);
                    STTtheoso1 = ds.Tables[0].Rows[0]["STT"].ToString();

                    if (BCS.Length > 2)
                    {
                        Chisomoi1 = "";
                    }
                    else
                    {
                        Chisomoi1 = ds.Tables[0].Rows[0]["CHISO_MOI"].ToString();
                    }

                    NVkepchi = ds.Tables[0].Rows[0]["TEN_NVIEN_KEPCHI"].ToString();
                    KDinhTI = ds.Tables[0].Rows[0]["NGAY_KDINH_TI_LAI"].ToString();
                    CStram = ds.Tables[0].Rows[0]["CSUAT_TRAM"].ToString();
                    Typetram = ds.Tables[0].Rows[0]["LOAI_TRAM"].ToString();

                }

                TtinKH = "<table cellspacing='2' cellpadding='3' border='0' style='width: 100%; color: #333333'> " + " <tr align='left'><td valign='top' >Mã KH: " + TC_MSKH + "</td>" + " <td valign='top' >Tên KH: <b>" + TenKH + "</b></td>" + " <td valign='top' >Tên ĐVQL: " + DVQUANLY + "</td></tr>" + " <tr align='left'><td valign='top' >Mã hợp đồng: " + Mahd1 + " </td>" + " <td valign='top'>Địa chỉ gắn c.tơ: " + DiachiKH + "</td>" + " <td valign='top' >Trực thuộc: " + CTQUANLY + "</td></tr>" + " <tr align='left'><td valign='top' >Mã nhóm ngành: " + ManhomN1 + " </td>" + " <td valign='top' >Tên ngành nghề: " + MaNN1 + "</td>" + " <td valign='top' >Hiệu lực HĐ: Từ " + NgayHLHDong + " đến " + NgayhetHLHD1 + "</td></tr>" + " <tr align='left'><td valign='top' >Mã điểm đo: " + MaDDo1 + " </td>" + " <td valign='top' >Loại điểm đo: " + LoaiDDo + "</td>" + " <td valign='top' >Loại hợp đồng: " + LoaiHD + "</td></tr>" + " <tr align='left'><td valign='top' >Mã sổ (lộ trình) GCS: " + MasoGCS + " </td>" + " <td valign='top' >STT theo sổ: " + STTtheoso1 + " ; Trụ (cột) số: " + Sotru + " ; Vị trí lắp c.tơ: " + VitriCto + "</td>" + " <td valign='top' >Số hộ: " + Soho + " ; Số pha: " + Sopha + " ; Hệ số nhân: " + HSNhan + "</td></tr>" + " <tr align='left'><td valign='top' >Mã trạm: " + Matram + " </td>" + " <td valign='top' >Tên trạm TBA: " + Tentram + "</td>" + " <td valign='top' >CS trạm: " + CStram + " kVA ; Loại trạm: " + Typetram + "</td></tr>" + "</table>";
            }
            catch (Exception)
            {
                //MsgBox("THONG BAO: " & ex.Message)
            }

        }

        protected void Xuatno()
        {
            try
            {
                var ds = new DataSet();
               
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    // Them dong TONG CONG vao cuoi cung cua datatable
                    DataRow tc_row = default(DataRow);
                    tc_row = ds.Tables[0].NewRow();

                    for (int g = 0; g <= ds.Tables[0].Rows.Count - 1; g++)
                    {
                        Tien_no_tong += Convert.ToDouble(ds.Tables[0].Rows[g]["TIEN_NO"].ToString());
                    }

                    tc_row["LOAI_HDON"] = "<b>Tổng cộng</b>";
                    tc_row["TIEN_NO"] = Tien_no_tong;
                    ds.Tables[0].Rows.Add(tc_row);

                    this.G_no.DataSource = ds.Tables[0];
                    this.G_no.DataBind();
                    this.NoKH.Visible = true;
                    this.NoKH.Text = "TIỀN Nước VÀ NỢ CỦA KHÁCH HÀNG HIỆN TẠI";
                    this.G_no.Visible = true;
                    this.Labno.Visible = false;
                    this.Labno.Text = "";

                }
                else
                {
                    this.NoKH.Visible = true;
                    this.NoKH.Text = "TIỀN Nước VÀ NỢ CỦA KHÁCH HÀNG HIỆN TẠI";
                    this.G_no.Visible = false;
                    this.Labno.Visible = true;
                    this.Labno.Text = "KHÁCH HÀNG NÀY CHƯA PHÁT SINH HÓA ĐƠN TIỀN Nước";

                }

            }
            catch (Exception)
            {
                //MsgBox("THONG BAO: " & ex.Message)
            }
        }


        //Nut XEM phan tra cuu theo ma khach hang
        protected void cmdIn_Click1(object sender, EventArgs e)
        {
            
            this.G_no.Visible = false;
            this.Labno.Visible = false;
            this.NoKH.Visible = false;
            try
            {
                TC_MSKH = this.TxtMKH.Text.Trim().ToUpper();
                var ds = new DataSet();
               

                if (ds == null)
                {
                    TtinKH = "";
                    this.Thongtin.InnerHtml = TtinKH;
                    this.Label1.Text = "MÃ KHÁCH HÀNG KHÔNG TỒN TẠI HOẶC ĐÃ THANH LÝ, VUI LÒNG KIỂM TRA LẠI.";
                    this.TxtMKH.Focus();
                    this.TxtMKH.Attributes.Add("onfocus", "this.select();");
                    TtinKH = "";
                    this.Thongtin.InnerHtml = TtinKH;
                    this.G_no.Visible = false;
                    this.Labno.Visible = false;
                    //Me.Imno.Visible = False
                    this.NoKH.Visible = false;

                }
                else
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {

                        Bindulieu();
                        Xuatno();
                        this.Thongtin.InnerHtml = TtinKH;
                        this.Label1.Text = "THÔNG TIN CHI TIẾT";

                    }
                    else
                    {
                        TtinKH = "";
                        this.Thongtin.InnerHtml = TtinKH;
                        this.Label1.Text = "MÃ KHÁCH HÀNG KHÔNG TỒN TẠI HOẶC ĐÃ THANH LÝ, VUI LÒNG KIỂM TRA LẠI.";
                        this.TxtMKH.Focus();
                        this.TxtMKH.Attributes.Add("onfocus", "this.select();");

                        this.G_no.Visible = false;
                        this.Labno.Visible = false;
                        this.NoKH.Visible = false;

                    }
                }
            }
            catch (Exception)
            {
                this.Label1.Text = "MÃ KHÁCH HÀNG KHÔNG TỒN TẠI HOẶC ĐÃ THANH LÝ, VUI LÒNG KIỂM TRA LẠI.";
                this.Thongtin.InnerHtml = "";
            }
        }

    }
}