using System;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;
using System.Text;

namespace cskh.domain
{
    public class Constants
    {
        public static string StrUser = ConfigurationManager.AppSettings["StrUser"];
        public static string StrPassword = ConfigurationManager.AppSettings["StrPassword"];
        public static int HdMax = int.Parse(ConfigurationManager.AppSettings["HdMax"]);
        public static string EmailHDGiay = ConfigurationManager.AppSettings["EmailHDGiay"];
        public static string KindOfToken = ConfigurationManager.AppSettings["KindOfToken"];
        
        public const string EI_CON_NAME = "EIConStr";
        public const string CR_CON_NAME = "CRConStr";

        // column names of HD_HOADON
        public const string IDKH = "IDKH";
        public const string MADP = "MADP";
        public const string NGAYNHAP_TT = "NGAYNHAP_TT";
        public const string NGAYNHAP = "NGAYNHAP";
        public const string TENKH = "TENKH";
        public const string DIACHI = "DIACHI";
        public const string MST = "MST";
        public const string STK = "STK";
        public const string SDT = "SDT";
        public const string EMAIL = "EMAIL";
        public const string SOHO = "SOHO";
        public const string SONK = "SONK";
        public const string SODB = "SODB";
        public const string STT = "STT";
        public const string KY = "KY";
        public const string NAM = "NAM";
        public const string THANG = "THANG";// UNUSED
        public const string CHISODAU = "CHISODAU";
        public const string CHISOCUOI = "CHISOCUOI";
        public const string CSTR_SC = "CSTR_SC";
        public const string CSSAU_SC = "CSSAU_SC";
        public const string KLTIEUTHU = "KLTIEUTHU";
        public const string TTHAI = "TTHAI";
        public const string TTHAIGHI = "TTHAIGHI";
        public const string TIENNUOC = "TIENNUOC";
        public const string TIENTHUE = "TIENTHUE";
        public const string TIENPHIMT = "TIENPHIMT";
        public const string TIENPHITN = "TIENPHITN";
        public const string TIENPHITNMT = "TIENPHITNMT";
        public const string M3TINHTIEN = "M3TINHTIEN";
        public const string TONGTIEN = "TONGTIEN";

        public const string M3MUC1 = "M3MUC1";
        public const string M3MUC2 = "M3MUC2";
        public const string M3MUC3 = "M3MUC3";
        public const string M3MUC4 = "M3MUC4";
        public const string M3MUC5 = "M3MUC5";
        public const string M3MUC6 = "M3MUC6";
        public const string M3MUC7 = "M3MUC7";
        public const string M3MUC8 = "M3MUC8";
        public const string M3MUC1_CU = "M3MUC1_CU";
        public const string M3MUC2_CU = "M3MUC2_CU";
        public const string M3MUC3_CU = "M3MUC3_CU";
        public const string M3MUC4_CU = "M3MUC4_CU";
        public const string M3MUC5_CU = "M3MUC5_CU";
        public const string M3MUC6_CU = "M3MUC6_CU";
        public const string M3MUC7_CU = "M3MUC7_CU";
        public const string M3MUC8_CU = "M3MUC8_CU";

        public const string GIAMUC1 = "GIAMUC1";
        public const string GIAMUC2 = "GIAMUC2";
        public const string GIAMUC3 = "GIAMUC3";
        public const string GIAMUC4 = "GIAMUC4";
        public const string GIAMUC5 = "GIAMUC5";
        public const string GIAMUC6 = "GIAMUC6";
        public const string GIAMUC7 = "GIAMUC7";
        public const string GIAMUC8 = "GIAMUC8";
        public const string GIAMUC1_CU = "GIAMUC1_CU";
        public const string GIAMUC2_CU = "GIAMUC2_CU";
        public const string GIAMUC3_CU = "GIAMUC3_CU";
        public const string GIAMUC4_CU = "GIAMUC4_CU";
        public const string GIAMUC5_CU = "GIAMUC5_CU";
        public const string GIAMUC6_CU = "GIAMUC6_CU";
        public const string GIAMUC7_CU = "GIAMUC7_CU";
        public const string GIAMUC8_CU = "GIAMUC8_CU";
       
        public const string TIENMUC1 = "TIENMUC1";
        public const string TIENMUC2 = "TIENMUC2";
        public const string TIENMUC3 = "TIENMUC3";
        public const string TIENMUC4 = "TIENMUC4";
        public const string TIENMUC5 = "TIENMUC5";
        public const string TIENMUC6 = "TIENMUC6";
        public const string TIENMUC7 = "TIENMUC7";
        public const string TIENMUC8 = "TIENMUC8";
        public const string TIENMUC1_CU = "TIENMUC1_CU";
        public const string TIENMUC2_CU = "TIENMUC2_CU";
        public const string TIENMUC3_CU = "TIENMUC3_CU";
        public const string TIENMUC4_CU = "TIENMUC4_CU";
        public const string TIENMUC5_CU = "TIENMUC5_CU";
        public const string TIENMUC6_CU = "TIENMUC6_CU";
        public const string TIENMUC7_CU = "TIENMUC7_CU";
        public const string TIENMUC8_CU = "TIENMUC8_CU";

        public const string TONGTIENTEXT = "TONGTIENTEXT";
        public const string MALKHDB = "MALKHDB";
        public const string TLSH = "TLSH";
        public const string BARCODEINFO = "BARCODEINFO";
        public const string MAUHOADON = "MAUHOADON";
        public const string KIHIEUHOADON = "KIHIEUHOADON";
        public const string SOHOADON = "SOHOADON";
        public const string HOADON_XML = "HOADON_XML";
        public const string NGAYKY = "NGAYKY";
        public const string NGUOIKY = "NGUOIKY";
        public const string GHICHU = "GHICHU";
        public const string transactionUuid = "transactionUuid";
        public const string LANKY = "LANKY";
        
        public const string IS_SIGNED = "ISSIGNED";

        // columns of HD_SOHOADON        
        public const string SUDUNG = "SuDung";
        public const string HUYBO = "HuyBo";

        // columns of HD_DMNGUOIDUNG
        public const string MANGUOIDUNG = "MaNguoiDung";
        public const string TENNGUOIDUNG = "TenNguoiDung";
        public const string MATMA = "MatMa";
        public const string QUYENHAN = "QuyenHan";

        // columns of DUONGPHO (HUE)
        public const string DP_MADP = "MADP";
        public const string DP_TENDP = "TENDP";
        public const string DP_TENDP_GOP = "TENDP_GOP";

        // columns of KYHD (HUE)
        //public const string KYHD_THANG = "THANG";
        //public const string KYHD_NAM = "NAM";

        // column of KHUVUC (HUE)
        public const string KV_MAKV = "MAKV";
        public const string KV_TENKV = "TENKV";

        // columns of CERTIFICATE
        public const string ID_KEY = "ID_KEY";
        public const string SIGN_NAME = "SIGN_NAME";
        public const string VALID_FROM = "VALID_FROM";
        public const string VALID_TO = "VALID_TO";
        public const string CERTIFICATE_FILE = "CERTIFICATE_FILE";
        public const string NGAY_THU_HOI = "NGAY_THU_HOI";
        public const string PUBLIC_KEY = "PUBLIC_KEY";
        public const string NGUOI_TAO = "NGUOI_TAO";
        public const string NGAY_TAO = "NGAY_TAO";
        public const string NGUOI_SUA = "NGUOI_SUA";
        public const string NGAY_SUA = "NGAY_SUA";
        public const string TRANG_THAI = "TRANG_THAI";
        public const string SERY_NUMBER = "SERY_NUMBER";


        // columns of HD_VATKIHIEU
        public const string KH_MAKIHIEU = "MAKIHIEU";
        public const string KH_MAU_SERY = "MAU_SERY";
        public const string KH_TENKIHIEU = "TENKIHIEU";
        public const string KH_SUDUNG = "SUDUNG";
        public const string KH_SERY_DAU = "SERY_DAU";
        public const string KH_SERY_CUOI = "SERY_CUOI";
        public const string KH_SERY_GANNHAT = "SERY_GANNHAT";
        public const string KH_NGAY_TAO = "NGAY_TAO";
        public const string KH_NGUOI_TAO = "NGUOI_TAO";
        public const string KH_NGAY_SUA = "NGAY_SUA";
        public const string KH_NGUOI_SUA = "NGUOI_SUA";
        
        // sp_hd_bckyhuy_trongky
        public const string sp_hd_bckyhuy_trongky_madp = "MADP";
        public const string sp_hd_bckyhuy_trongky_sohdky = "SOHDKY";
        public const string sp_hd_bckyhuy_trongky_sohdhuy = "SOHDHUY";
        
        // Devexpress customize
        //Update - cancel button edit form
        public const string UPDATE = "Update";
        public const string UPDATE_VN = "Lưu";
        public const string CANCEL = "Cancel";
        public const string CANCEL_VN = "Thoát";
        //Find panel
        public const string FIND_PANEL_FIND = "Tìm kiếm";
        public const string FIND_PANEL_CLEAR = "Xóa";
        public const string FindNullPrompt = "Nhập từ cần tìm kiếm";
         
        public const string GridGroupPanelText = "Kéo thả cột cần phân nhóm vào đây";

        // Lộc sử dụng trong form 
        public const string REC_ADD = "NEW";
        public const string REC_EDIT = "EDIT";
        public const string ADMIN = "ADMIN";
    
        // SQL QUERY
        //CSKH-HDDT
        //public const string SQL_GET_VATKIHIEU_INUSE = "SELECT MAKIHIEU, TENKIHIEU FROM HD_VATKIHIEU WHERE SUDUNG = 1 ORDER BY MAKIHIEU;";
        //public const string SQL_GET_ALL_CHUNGTHUSO = "SELECT * FROM HD_CHUNGTHUSO WHERE TRANG_THAI != 0;";
        //public const string SQL_GET_ALL_VATKIHIEU = "SELECT * FROM HD_VATKIHIEU ORDER BY NGAY_TAO;";
        
        ////HUE
        ////public const string SQL_HUE_GET_DP = "select MADP, MADP + ' - ' + TENDP AS TENDP from DUONGPHO order by MADP;";
        //public const string SQL_HUE_GET_DP_BY_KV = "select MADP, MADP + ' - ' + TENDP AS TENDP from DUONGPHO WHERE MAKV = @MAKV order by MADP;";
        //public const string SQL_HUE_GET_KYHD = "SELECT * FROM KYHD;";
        //public const string SQL_HUE_GET_KHUVUC = "SELECT MAKV, TENKV FROM KHUVUC;";
        //public const string SQL_HUE_GET_DP_WITH_KV = "SELECT MADP, TENDP, DUONGPHO.MAKV, TENKV FROM DUONGPHO INNER JOIN KHUVUC ON DUONGPHO.MAKV = KHUVUC.MAKV;";

        //PROCEDURE [HDDT_BangKeHoaDonKy]
        public const string HDDT_BangKeHoaDonKy_MAKV = "MAKV";
        public const string HDDT_BangKeHoaDonKy_TENKV = "TENKV";
        public const string HDDT_BangKeHoaDonKy_MADP = "MADP";
        public const string HDDT_BangKeHoaDonKy_TENDP = "TENDP";
        public const string HDDT_BangKeHoaDonKy_SOHD = "SOHD";

        // Common SQL ERROR NUMBER
        public const int ERR_UNIQUE_VIOLATE = 2627;

        public const string DEFAULT_PASS = "123";
        public static string ENCRYPT_DEFAUL_PASS()
        {
            return Cryp.Encrypt(DEFAULT_PASS);
        }

        public static string Encrypt(string clearText)
        {
            const string encryptionKey = "HUEWACO2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}
