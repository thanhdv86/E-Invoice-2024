using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using System.Reflection;
using System.Text;
using EBase;

namespace cskh.domain
{
    public class EiBusinessImpl : DataAccess
    {
        public EiBusinessImpl()
            : base()
        {

        }

        public int CallSpEiReturnInt(string strSql)
        {
            Open();
            var intResult = Db.runDynamicSqlNoQuery(strSql, null, null, CommandType.StoredProcedure);
            Close();
            return intResult;
        }
        public int CallSpEiReturnInt(string strSql, string[] paramNames, object[] paramValues)
        {
            Open();
            var intResult = Db.runDynamicSqlNoQuery(strSql, paramNames, paramValues, CommandType.StoredProcedure);
            Close();
            return intResult;
        }
        public DataTable CallSpEi(string strSql)
        {
            DataTable dt = null;
            Open();
            var ds = Db.runSQLQuery(strSql);
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            Close();
            return dt;

        }
        public DataTable CallSpEi(string strSql, string[] paramNames, object[] paramValues)
        {

            DataTable dt = null;
            Open();
            var ds = Db.runDynamicSqlQuery(strSql, paramNames, paramValues, CommandType.StoredProcedure);
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            Close();
            return dt;
        }

        // Begin CSKH & HĐĐT
        public IDataReader GetHoaDonDetail(string idkh, int thang, int nam)
        {
            const string strobjectname = "sp_hd_get_hoa_don_by_pk";
            var names = new string[] { "@idkh", "@thang", "@nam" };
            var values = new object[] { idkh, thang, nam };
            base.Open();
            var result = Db.runDynamicSqlQuery(strobjectname, names, values, CommandType.StoredProcedure, CommandBehavior.CloseConnection);
            //base.Close();
            return result;
        }
        public DataTable GetHoaDonInfo(string idkh, int thang, int nam)
        {
            return CallSpEi("sp_get_hoa_don_by_pk", new[] { "@idkh", "@thang", "@nam" }, new object[] { idkh, thang, nam });
        }

        // End CSKH & HĐĐT

        // Begin HĐĐT     
        public DataTable GetDateOfServer()
        {
            return CallSpEi("SELECT CONVERT(date, GETDATE(),103) as DateOfServer");
        }
        public DataTable GetListHoaDon()
        {
            return CallSpEi("sp_hd_get_all_hoadon");
        }

        public DataTable GetAllInvoiceNums()
        {
            return CallSpEi("sp_hd_get_all_invoice_nums");
        }

        public DataTable GetListHoaDonByKyThang(int thang, int nam)
        {
            return CallSpEi("sp_hd_get_hoadon_by_thangnam", new[] { "@thang", "@nam" }, new object[] { thang, nam });
        }

        public DataTable GetSignedHdByKy(int thang, int nam)
        {
            return CallSpEi("SP_HD_GET_HD_BY_KY", new[] { "@thang", "@nam" }, new object[] { thang, nam });
        }

        public DataTable GetAvailableInvoiceNum(string kihieu)
        {
            return CallSpEi("sp_hd_get_available_invoice_num", new[] { "@kihieu" }, new object[] { kihieu });
        }

        public DataTable CheckLogin(string username, string password)
        {
            return CallSpEi("sp_hd_check_login", new[] { "@username", "@password" }, new object[] { username, Cryp.Encrypt(password) });
        }

        // tra ve danh sach hoa don da ky + hoa don bi huy nhung ko lap lai
        public DataTable GetSignedHdbyDp(string madp, int thang, int nam)
        {
            return CallSpEi("sp_hd_get_hd_by_dp", new[] { "@madp", "@thang", "@nam" }, new object[] { madp, thang, nam });
        }

        public DataTable GetHoaDonBySoHoaDon(string sohoadon, string kihieuhoadon)
        {
            return CallSpEi("sp_hd_gethoadon_bysohoadon", new[] { "@sohoadon", "@kihieuhoadon" }, new object[] { sohoadon, kihieuhoadon });
        }

        public DataTable GetKihieuInUse()
        {
            return CallSpEi("SELECT * FROM HD_VATKIHIEU WHERE SUDUNG = 1 ORDER BY MAKIHIEU;");
        }

        public DataTable GetHoaDonByPk(string idkh, int thang, int nam)
        {
            return CallSpEi("sp_hd_get_hoa_don_by_pk", new[] { "@idkh", "@thang", "@nam" }, new object[] { idkh, thang, nam }); ;
        }

        // get list of all certifcate
        public DataTable GetAllChungthu()
        {
            return CallSpEi("SELECT * FROM HD_CHUNGTHUSO WHERE TRANG_THAI != 0;");
        }

        // get all mau sery
        public DataTable GetAllMauSery()
        {
            return CallSpEi("SELECT * FROM HD_VATKIHIEU ORDER BY NGAY_TAO;");
        }
        // tim kiem hoa don theo ten/id kh, ky, nam, thang
        public DataTable SearchHoaDon(string kh, string madp, int? ky, int? nam)
        {
            return CallSpEi("sp_hd_search_hoadon", new[] { "@tenkh", "@madp", "@ky", "@nam" }, new object[] { kh, madp, ky, nam }); ;
        }

        // tong hop bao cao tinh hinh su dung hoa don
        public DataTable tonghop_BC26AC(int year, int quarter)
        {
            return CallSpEi("SP_HD_BC26AC", new[] { "@year", "@quarter" }, new object[] { year, quarter });
        }

        public DataTable tonghop_BC26AC_thang(int year, int month)
        {
            return CallSpEi("SP_HD_BC26AC_THANG", new[] { "@year", "@month" }, new object[] { year, month });
        }

        // bao cao tinh hinh ky hoa don cua ky
        public DataTable getCountKyHuy_ByKy(int nam, int ky)
        {
            return CallSpEi("sp_hd_bckyhuy_trongky", new[] { "@nam", "@ky" }, new object[] { nam, ky });
        }

        // bao cao phieu xu ly san pham khong phu hop
        public DataTable tonghop_PXLSPKHP(int nam, int ky)
        {
            //return CallSpEi("sp_hd_bcpxlkhl", new[] { "@nam", "@ky" }, new object[] { nam, ky });
            return CallSpEi("spHdBcPxlKhl", new[] { "@nam", "@ky" }, new object[] { nam, ky });

        }

        public DataTable DmNguoiDung()
        {
            return CallSpEi("sp_hd_get_DMNguoiDung");
        }
        public DataTable DmPhanQuyen()
        {
            return CallSpEi("Select * from HD_DMPhanQuyen");
        }

        public DataTable GetDmNguoiDung(string maNguoiDung)
        {
            return CallSpEi("spHdGetDsNguoiDung", new[] { "@MaNguoiDung" }, new object[] { maNguoiDung });
        }
        public DataTable GetDsMauSms()
        {
            return CallSpEi("Select * from tblMauSMS");
        }

        public DataTable GetDsLoaiSms()
        {
            return CallSpEi("SELECT * FROM dbo.tblLoaiSMS");
        }

        public DataTable GetDsThamSoByLoaiSms(int idLoaiSms)
        {
            return CallSpEi("spHdGetDsThamSoByLoaiSms", new[] { "@IDLoaiSMS" }, new object[] { idLoaiSms });
        }

        public DataTable GetDsKhuVuc()
        {
            return CallSpEi("SELECT * FROM dbo.tblKhuVuc ");
        }

        public DataTable GetDsEmail(int ky, int nam, string loaiDv, bool isapproved)
        {
            return CallSpEi("spGetDsEmail", new[] { "@KY", "@NAM", "@LoaiDV", "@ISAPPROVED" }, new object[] { ky, nam, loaiDv, isapproved });
        }

        public int UpdateHoaDonXml(string idkh, int thang, int nam, byte[] hoadonXml)
        {
            const string strobjectname = "sp_hd_udpate_hoadon_xml";
            var names = new[] { "@idkh", "@thang", "@nam", "@hoadon_xml" };
            var values = new object[] { idkh, thang, nam, hoadonXml };
            base.Open();
            var result = Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
            return result;
        }
        public byte[] GetHoaDonXml(string idkh, int thang, int nam)
        {
            const string strobjectname = "sp_hd_get_hoadon_xml";
            var names = new[] { "@idkh", "@thang", "@nam" };
            var values = new object[] { idkh, thang, nam };
            base.Open();
            var ds = Db.runDynamicSqlQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
            return ds.Tables[0].Rows[0][0] as byte[];
        }

        public int GenInvoiceNums(string prefix, string suffix, string startNum, string endNum, string kyhieu)
        {
            const string strobjectname = "sp_hd_gen_sery_in_range";
            var names = new[] { "@prefix", "@suffix", "@startnum", "@endnum", "@kyhieu" };
            var values = new object[] { prefix, suffix, startNum, endNum, kyhieu };
            base.Open();
            var result = Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
            return result;
        }

        public string GetMinAvailableInvoiceNum(string kyhieu)
        {
            var dt = GetAvailableInvoiceNum(kyhieu);
            if (dt.Rows.Count > 0) return dt.Rows[0][Constants.SOHOADON].ToString();
            return null;
        }

        public int UpdateHoaDonXml(string idkh, int thang, int nam, byte[] hoadonXml, string sohoadon, string kihieu)
        {
            const string strobjectname = "sp_hd_udpate_hoadon_xml_2";
            var names = new string[] { "@idkh", "@thang", "@nam", "@hoadon_xml", "@sohoadon", "@kihieu" };
            var values = new object[] { idkh, thang, nam, hoadonXml, sohoadon, kihieu };
            base.Open();
            int result = Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
            return result;
        }

        public bool CheckLogin2(string username, string password)
        {
            var dt = CheckLogin(username, password);
            if (dt != null && dt.Rows.Count == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hd"></param>
        /// <returns>Neu ki thanh cong tra ve 0, neu khong tra ve ma loi</returns>
        public int InsertSignedHd(EI hd)
        {
            //const string strobjectname = "sp_hd_insert_singed_hd";
            const string strobjectname = "spHdInsertSingedHd";
            var properties = SignUtil.GetProperties(hd);
            var paramsL = new List<DbParameter>();
            // Những trường tính toán không phải được là đối số của các Store Sprocedure 
            string[] strNamesArray = { "TONGTIENTEXT" };
            foreach (var prop in properties)
            {
                if (strNamesArray.All(x => x != prop.Name))
                {
                    paramsL.Add(new DbParameter(prop.Name, prop.GetValue(hd, null)));
                }
            }
            // them error code va message de tracking loi
            var errorCode = new DbParameter("@ERROR_CODE", SqlDbType.Int, 15) { Direction = ParameterDirection.Output };
            var errorMsg = new DbParameter("@ERROR_MSG", SqlDbType.NVarChar, 4000) { Direction = ParameterDirection.Output };

            paramsL.Add(errorCode);
            paramsL.Add(errorMsg);

            var prs = paramsL.ToArray();
            base.Open();
            Db.runDynamicSqlScalar(strobjectname, prs, CommandType.StoredProcedure);
            base.Close();
            return Convert.ToInt16(errorCode.Value.ToString());
        }

        public string GetVariableValue(string variableName)
        {
            const string sql = "sp_getVariableValue";
            var parameter = new DbParameter("@VariableName", variableName);
            var parameters = new DbParameter[] { parameter };
            base.Open();
            var obj = base.Db.runDynamicSqlScalar(sql, parameters, CommandType.StoredProcedure);
            base.Close();
            return obj.ToString();
        }

        public int huy_laplaiHD(EI hd, string lydo)
        {
            //const string strobjectname = "sp_hd_huylaplai";
            const string strobjectname = "spHdHuyLaplai";
            var properties = SignUtil.GetProperties(hd);
            //var names = new List<string>();
            //var values = new List<object>();
            var paramsL = new List<DbParameter>();
            // Những trường tính toán không phải được là đối số của các Store Sprocedure 
            string[] strNamesArray = { "TONGTIENTEXT" };
            foreach (var prop in properties)
            {
                if (strNamesArray.All(x => x != prop.Name))
                {
                    //names.Add(prop.Name);
                    //values.Add(prop.GetValue(hd, null));
                    paramsL.Add(new DbParameter(prop.Name, prop.GetValue(hd, null)));
                }
            }
            // add them parameter reason huy           
            paramsL.Add(new DbParameter("@lydo", lydo));

            // them error code va message de tracking loi
            var errorCode = new DbParameter("@ERROR_CODE", SqlDbType.Int, 15) { Direction = ParameterDirection.Output };
            var errorMsg = new DbParameter("@ERROR_MSG", SqlDbType.NVarChar, 4000) { Direction = ParameterDirection.Output };

            paramsL.Add(errorCode);
            paramsL.Add(errorMsg);
            var prs = paramsL.ToArray();

            base.Open();
            Db.runDynamicSqlScalar(strobjectname, prs, CommandType.StoredProcedure);
            base.Close();
            return Convert.ToInt16(errorCode.Value.ToString());
        }


        public int HuyHd(string idkh, int thang, int nam, string nguoihuy, string lydo, DateTime? ngayhuy)
        {
            //const string strobjectname = "sp_hd_huyhoadon";
            const string strobjectname = "spHdHuyHoadon";
            var namesArr = new[] { "@idkh", "@thang", "@nam", "@nguoihuy", "@lydo", "@ngayhuy" };
            var valuesArr = new object[] { idkh, thang, nam, nguoihuy, lydo, ngayhuy };
            base.Open();
            var result = Db.runDynamicSqlNoQuery(strobjectname, namesArr, valuesArr, CommandType.StoredProcedure);
            base.Close();
            return result;
        }

        // Lay so hoa don dau khi ki hoa don
        public string GetStartInvoiceNum(string kihieu)
        {
            const string strobjectname = "sp_hd_get_start_invoice_num";
            var pkihieu = new DbParameter("@kihieu", kihieu);
            var pseryRetStr = new DbParameter("@sery_ret_str", SqlDbType.VarChar, 15) { Direction = ParameterDirection.Output };
            var prs = new DbParameter[] { pkihieu, pseryRetStr };
            base.Open();
            Db.runDynamicSqlScalar(strobjectname, prs, CommandType.StoredProcedure);
            base.Close();

            return pseryRetStr.Value.ToString();

        }

        // lay so hoa don cuoi khi ki hoa don
        public string GetEndInvoiceNum(string kihieu, string sohddau, int tongsohd)
        {
            const string strobjectname = "sp_hd_get_end_invoice_num";
            var pkihieu = new DbParameter("@kihieu", kihieu);
            var psohddau = new DbParameter("@sohddau", sohddau);
            var ptongsohd = new DbParameter("@tongsohd", tongsohd);
            var pseryRetStr = new DbParameter("@sohdcuoi", SqlDbType.VarChar, 15) { Direction = ParameterDirection.Output };
            var prs = new DbParameter[] { pkihieu, psohddau, ptongsohd, pseryRetStr };
            base.Open();
            Db.runDynamicSqlScalar(strobjectname, prs, CommandType.StoredProcedure);
            base.Close();
            return pseryRetStr.Value.ToString();
        }

        // Lay tong so hoa don chua dung cua mot bo mau so
        public int GetSoHdChuaDung(string kihieu)
        {
            const string strobjectname = "sp_hd_get_sohd_available";
            var pkihieu = new DbParameter("@kihieu", kihieu);
            var psohdchuadung = new DbParameter("@sohdchuadung", SqlDbType.Int, 4) { Direction = ParameterDirection.Output };
            var prs = new DbParameter[] { pkihieu, psohdchuadung };
            base.Open();
            Db.runDynamicSqlScalar(strobjectname, prs, CommandType.StoredProcedure);
            base.Close();
            return Convert.ToInt32(psohdchuadung.Value);
        }

        // insert a new certificate
        public int InsertChungthu(Certificate cer)
        {
            const string strobjname = "sp_hd_insert_cer";
            var names = new[] { "@sign_name", "@valid_from", "@valid_to", "@certificate_file", "@ngay_thu_hoi ", "@public_key", "@nguoi_tao", "@ngay_tao", "@trang_thai", "@sery_number" };
            var values = new object[] { cer.SignName, cer.ValidFrom, cer.ValidTo, cer.CertificateFile, cer.NgayThuHoi, cer.PublicKey, cer.NguoiTao, cer.NgayTao, cer.TrangThai, cer.SeryNumber };
            base.Open();
            try
            {
                var ds = Db.runDynamicSqlQuery(strobjname, names, values, CommandType.StoredProcedure);
                object test = ds.Tables[0].Rows[0][0];
                return Convert.ToInt32(test);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                base.Close();
            }

        }

        // update ngay_thu_hoi of a certificate
        public int UpdateChungthu(int id_key, string nguoisua, DateTime ngaysua, DateTime ngaythuhoi)
        {
            const string strobjname = "sp_hd_update_cer";
            var names = new[] { "@id_key", "@nguoi_sua", "@ngay_sua", "@ngay_thu_hoi" };
            var values = new object[] { id_key, nguoisua, ngaysua, ngaythuhoi };
            base.Open();
            var result = Db.runDynamicSqlNoQuery(strobjname, names, values, CommandType.StoredProcedure);
            base.Close();
            return result;
        }

        // update trang_thai of a certificate
        public int updateChungthuStatus(int id_key, string nguoisua, DateTime ngaysua, int trangthai)
        {
            const string strobjname = "sp_hd_update_cer_status";
            var names = new string[] { "@id_key", "@nguoi_sua", "@ngay_sua", "@trang_thai" };
            var values = new object[] { id_key, nguoisua, ngaysua, trangthai };
            base.Open();
            var result = Db.runDynamicSqlNoQuery(strobjname, names, values, CommandType.StoredProcedure);
            base.Close();
            return result;
        }

        // insert mau sery hoa don
        public int InsertMauSery(MauSery mausery)
        {
            const string strobjname = "sp_hd_insert_vatkihieu";
            var names = new[] { "@MAKIHIEU", "@MAU_SERY", "@TENKIHIEU", "@SUDUNG", "@SERY_DAU", "@SERY_CUOI", "@NGUOI_TAO", "@NGAY_TAO" };
            var values = new object[] { mausery.MAKIHIEU, mausery.MAU_SERY, mausery.TENKIHIEU, mausery.SUDUNG, mausery.SERY_DAU, mausery.SERY_CUOI, mausery.NGUOI_TAO, mausery.NGAY_TAO };
            base.Open();
            var result = Db.runDynamicSqlNoQuery(strobjname, names, values, CommandType.StoredProcedure);
            base.Close();
            return result;
        }

        // update so sery cuoi cua mot mau sery
        public int UpdateMauSery(string makihieu, string mausery, string tenkihieu, bool sudung, string serycuoi, string nguoisua, DateTime ngaysua)
        {
            const string strobjname = "sp_hd_udpate_mausery";
            var names = new[] { "@MAKIHIEU", "@MAU_SERY", "@TENKIHIEU", "@SUDUNG", "@SERY_CUOI", "@NGUOI_SUA", "@NGAY_SUA" };
            var values = new object[] { makihieu, mausery, tenkihieu, sudung, serycuoi, nguoisua, ngaysua };
            base.Open();
            var result = Db.runDynamicSqlNoQuery(strobjname, names, values, CommandType.StoredProcedure);
            base.Close();
            return result;
        }

        // get ten muc of a muc  (for a.Loc)
        public string GetTenMucFromMuc(string muc)
        {
            const string strobjectname = "sp_hd_get_ten_muc";
            var pmuc = new DbParameter("@MUC", muc);
            var ptenmucRet = new DbParameter("@TENMUC", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };
            var prs = new DbParameter[] { pmuc, ptenmucRet };
            base.Open();
            Db.runDynamicSqlScalar(strobjectname, prs, CommandType.StoredProcedure);
            base.Close();
            return ptenmucRet.Value.ToString();
        }

        // check mot hoa don co duoc duoc ky boi huewaco ko
        public bool IsValidCertificate(string publickey)
        {
            const string strobjectname = "sp_hd_checkValidCertificate";
            var pPublickey = new DbParameter("@public_key", publickey);
            var pIsvalid = new DbParameter("@isvalid", SqlDbType.Bit, 1) { Direction = ParameterDirection.Output };
            var prs = new DbParameter[] { pPublickey, pIsvalid };
            base.Open();
            Db.runDynamicSqlScalar(strobjectname, prs, CommandType.StoredProcedure);
            base.Close();
            return Convert.ToBoolean(pIsvalid.Value.ToString());

        }

        // thay doi mat khau
        public int ChangePassword(string username, string newpass)
        {
            const string strobjname = "sp_hd_change_password";
            var names = new string[] { "@username", "@newpass" };
            var values = new object[] { username, Cryp.Encrypt(newpass) };
            base.Open();
            int res = Db.runDynamicSqlNoQuery(strobjname, names, values, CommandType.StoredProcedure);
            base.Close();
            return res;
        }

        public int UpdateDmNguoiDung(string maNguoiDung, string tenNguoiDung)
        {
            const string strobjname = "Update HD_DMNguoiDung Set TenNguoiDung = @TenNguoiDung Where MaNguoiDung = @MaNguoiDung";
            var names = new[] { "@MaNguoiDung", "@TenNguoiDung" };
            var values = new object[] { maNguoiDung, tenNguoiDung };
            base.Open();
            var result = Db.runDynamicSqlNoQuery(strobjname, names, values, CommandType.Text);
            base.Close();
            return result;
        }

        public int SetQuyenSd(string maNguoiDung, string quyenHan)
        {
            const string strobjectname = "Update HD_DMNguoiDung set QuyenHan = @QuyenHan where MaNguoiDung = @MaNguoiDung ";
            var names = new string[] { "@MaNguoiDung", "@QuyenHan" };
            var values = new object[] { maNguoiDung, quyenHan };
            base.Open();
            var result = Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.Text);
            base.Close();
            return result;
        }
        public int InsertDmNguoiDung(string maNguoiDung, string tenNguoiDung)
        {
            const string strobjname = "Insert HD_DMNguoiDung (MaNguoiDung, TenNguoiDung, MatMa) Values (@MaNguoiDung, @TenNguoiDung, @MatMa) ";
            var names = new string[] { "@MaNguoiDung", "@TenNguoiDung", "@MatMa" };
            var values = new object[] { maNguoiDung, tenNguoiDung, Constants.ENCRYPT_DEFAUL_PASS() };
            base.Open();
            var result = Db.runDynamicSqlNoQuery(strobjname, names, values, CommandType.Text);
            base.Close();
            return result;
        }
        public int TaoDmPhanQuyen(string muc, string tenMuc)
        {
            const string strobjname = "Insert HD_DMPhanQuyen (Muc, TenMuc) values (@Muc, @TenMuc) ";
            var names = new string[] { "@Muc", "@TenMuc" };
            var values = new object[] { muc, tenMuc };
            base.Open();
            var result = Db.runDynamicSqlNoQuery(strobjname, names, values, CommandType.Text);
            base.Close();
            return result;
        }
        public int XoaDmNguoiDung(string maNguoiDung)
        {
            const string strobjname = "Delete HD_DMNguoiDung where MaNguoiDung = @MaNguoiDung ";
            var names = new string[] { "@MaNguoiDung" };
            var values = new object[] { maNguoiDung };
            base.Open();
            int result = Db.runDynamicSqlNoQuery(strobjname, names, values, CommandType.Text);
            base.Close();
            return result;
        }
        public int XoaDmpQuyen()
        {
            const string strobjname = "Delete HD_DMPhanQuyen ";
            var names = new string[] { };
            var values = new object[] { };
            base.Open();
            int result = Db.runDynamicSqlNoQuery(strobjname, names, values, CommandType.Text);
            base.Close();
            return result;
        }

        public int InsertMauSms(string idLoaiSms, string tieuDe, string mauNd)
        {
            const string strobjname = "INSERT INTO dbo.tblMauSMS (IDLoaiSMS, TieuDe, MauND, NgayTao ) VALUES ( @IDLoaiSMS,@TieuDe, @MauND, GETDATE() )";
            var names = new[] { "@IDLoaiSMS", "@TieuDe", "@MauND" };
            var values = new object[] { idLoaiSms, tieuDe, mauNd };
            base.Open();
            var result = Db.runDynamicSqlNoQuery(strobjname, names, values, CommandType.Text);
            base.Close();
            return result;
        }

        public int UpdateMauSms(string id, string idLoaiSms, string tieuDe, string mauNd)
        {
            const string strobjname = "Update dbo.tblMauSMS Set IDLoaiSMS = @IDLoaiSMS, TieuDe = @TieuDe, MauND = @MauND where ID=@ID";
            var names = new[] { "@ID", "@IDLoaiSMS", "@TieuDe", "@MauND" };
            var values = new object[] { id, idLoaiSms, tieuDe, mauNd };
            base.Open();
            var result = Db.runDynamicSqlNoQuery(strobjname, names, values, CommandType.Text);
            base.Close();
            return result;
        }

        public int DeleteMauSms(string id)
        {
            const string strobjname = "Delete tblMauSMS where ID = @ID";
            var names = new[] { "@ID" };
            var values = new object[] { id };
            base.Open();
            var result = Db.runDynamicSqlNoQuery(strobjname, names, values, CommandType.Text);
            base.Close();
            return result;
        }

        public int UpdateHdgiay(string idkh, int nam, int ky, string lan, string nguoihdgiay)
        {
            const string sql = "spUpdateHDGIAY";
            var paramNames = new[] { "@IDKH", "@NAM", "@KY", "@LAN", "@NGUOIHDGIAY" };
            var paramValues = new object[] { idkh, nam, ky, lan, nguoihdgiay };
            base.Open();
            var num = Db.runDynamicSqlNoQuery(sql, paramNames, paramValues, CommandType.StoredProcedure);
            base.Close();
            return num;
        }
        public bool KiemTraDaKyHoaDon(int ky, int nam)
        {
            const string strobjname = "SELECT top 1 ky FROM dbo.HD_HOADON WHERE KY = @KY AND NAM = @NAM";
            var names = new string[] { "@KY", "@NAM" };
            var values = new object[] { ky, nam };
            base.Open();
            var result = Db.runDynamicSqlScalar(strobjname, names, values, CommandType.Text);
            base.Close();
            return Convert.ToInt16(result) > 0;
        }
        // End HĐĐT

        // Begin CSKH
        public IDataReader GetUser(string strUsername)
        {
            const string strobjectname = "sp_getUser";
            var names = new[] { "@strUsername" };
            var values = new object[] { strUsername };
            base.Open();
            var result = Db.runDynamicSqlQuery(strobjectname, names, values, CommandType.StoredProcedure, CommandBehavior.CloseConnection);
            return result;
        }
        public IDataReader GetSmtpConfig()
        {
            const string strobjectname = "sp_getSMTPConfig";
            base.Open();
            var result = Db.runDynamicSqlQuery(strobjectname, null, null, CommandType.StoredProcedure, CommandBehavior.CloseConnection);
            return result;
        }
        public IDataReader GetOldPassword(string strUsername)
        {
            const string strobjectname = "sp_getOldPassword";
            var names = new string[] { "@strUsername" };
            var values = new object[] { strUsername };
            base.Open();
            var result = Db.runDynamicSqlQuery(strobjectname, names, values, CommandType.StoredProcedure, CommandBehavior.CloseConnection);
            return result;
        }
        public IDataReader GetThread(int intThreadId)
        {
            const string strobjectname = "sp_getThread";
            var names = new[] { "@intThreadID" };
            var values = new object[] { intThreadId };
            base.Open();
            var result = Db.runDynamicSqlQuery(strobjectname, names, values, CommandType.StoredProcedure, CommandBehavior.CloseConnection);
            return result;
        }
        public IDataReader GetCustomerInfo(string strUsername)
        {
            const string strobjectname = "sp_getCustomerInfo";
            var names = new[] { "@strUsername" };
            var values = new object[] { strUsername };
            base.Open();
            var result = Db.runDynamicSqlQuery(strobjectname, names, values, CommandType.StoredProcedure, CommandBehavior.CloseConnection);
            return result;
        }

        public IDataReader GetSurveyInfor(int intSurveyId)
        {
            const string strobjectname = "sp_getSurveyInfor";
            var names = new string[] { "@intSurveyID" };
            var values = new object[] { intSurveyId };
            base.Open();
            var result = Db.runDynamicSqlQuery(strobjectname, names, values, CommandType.StoredProcedure, CommandBehavior.CloseConnection);
            return result;
        }
        public IDataReader GetContract(int intContractId)
        {
            const string strobjectname = "sp_getContract";
            var names = new string[] { "@intContractID" };
            var values = new object[] { intContractId };
            base.Open();
            var result = Db.runDynamicSqlQuery(strobjectname, names, values, CommandType.StoredProcedure, CommandBehavior.CloseConnection);
            return result;
        }
        public DataTable GetLoginAccount(string strUsername)
        {
            return CallSpEi("sp_getLoginAccount", new[] { "@strUsername" }, new object[] { strUsername });
        }
        public DataTable GetService(string maKhang)
        {
            return CallSpEi("sp_getService", new[] { "@MA_KHANG" }, new object[] { maKhang });
        }
        public DataTable GetCustomerList(string strUsername, DateTime datFromDate, DateTime datToDate)
        {
            return CallSpEi("sp_getCustomerList", new[] { "@strUsername", "@datFromDate", "@datToDate" }, new object[] { strUsername, datFromDate, datToDate });
        }
        public DataTable GetNewContractList(string strUsername, DateTime datFromDate, DateTime datToDate)
        {
            return CallSpEi("sp_getNewContractList", new[] { "@strUsername", "@datFromDate", "@datToDate" }, new object[] { strUsername, datFromDate, datToDate });
        }
        public DataTable GetDistricts(string strDivisionCode)
        {
            return CallSpEi("sp_getDistricts", new[] { "@strDivisionCode" }, new object[] { strDivisionCode });
        }
        public DataTable GetSessions(string strUsername, string strKeyLanguage)
        {
            return CallSpEi("sp_getSessions", new[] { "@strUsername", "@strKeyLanguage" }, new object[] { strUsername, strKeyLanguage });
        }
        public DataTable GetThreads(int intSessionId, string strUsername, int intPageSize, int intPageIndexChild, int intCategoryIdOther, string strKeyLanguage)
        {
            return CallSpEi("sp_getThreads", new[] { "@intSessionID", "@strUsername", "@intPageSize", "@intPageIndexChild", "@intCategoryIdOther", "@strKeyLanguage" }, new object[] { intSessionId, strUsername, intPageSize, intPageIndexChild, intCategoryIdOther, strKeyLanguage });
        }
        public DataTable GetAnswers(int intThreadId)
        {
            return CallSpEi("sp_getAnswers", new[] { "@intThreadID" }, new object[] { intThreadId });
        }
        public DataTable GetAllSessions(string strKeyLanguage)
        {
            return CallSpEi("sp_getAllSessions", new[] { "@strKeyLanguage" }, new object[] { strKeyLanguage });
        }
        public DataTable GetRecordingMeters(string maKhang)
        {
            return CallSpEi("sp_getRecordingMeters", new[] { "@MA_KHANG" }, new object[] { maKhang });
        }

        public DataTable GetUsers(string strUsername, string strDivisionCodeSearch, string strSubDivisionCodeSearch, string strUsernameSearch)
        {
            return CallSpEi("sp_getUsers", new[] { "@strUsername", "@strDivisionCodeSearch", "@strSubDivisionCodeSearch", "@strUsernameSearch" }, new object[] { strUsername, strDivisionCodeSearch, strSubDivisionCodeSearch, strUsernameSearch });
        }
        public DataTable GetMessageFromQueue()
        {
            return CallSpEi("sp_getMessageFromQueue");
        }
        public DataTable GetSurveys(string strUsername, object objEditor, object objStatus, string strSurveyName)
        {
            return CallSpEi("sp_getSurveys", new[] { "@strUsername", "@intEditor", "@intStatus", "@strSurveyName" }, new object[] { strUsername, objEditor, objStatus, strSurveyName });
        }

        public DataTable GetQuestions(int intSurveyId)
        {
            return CallSpEi("sp_getQuestions", new[] { "@intSurveyID" }, new object[] { intSurveyId });
        }
        public DataTable GetSurveyAnswers(int intSurveyQuestionId)
        {
            return CallSpEi("sp_getSurveyAnswers", new[] { "@intSurveyQuestionID" }, new object[] { intSurveyQuestionId });
        }

        public DataTable GetVotingResult(int intSurveyQuestionId)
        {
            return CallSpEi("sp_getVotingResult", new string[] { "@intSurveyQuestionID" }, new object[] { intSurveyQuestionId });
        }
        public DataTable GetSurveysPublic()
        {
            return CallSpEi("sp_getSurveysPublic");
        }

        public DataTable GetTempletes()
        {
            return CallSpEi("sp_getTempletes");
        }
        public DataTable GetContracts(string strUsername, bool bitApproved, string strDivisionCodeSearch, string strSubDivisionCodeSearch, string strCustomerName)
        {
            return CallSpEi("sp_getContracts", new[] { "@strUsername", "@bitApproved", "@strDivisionCodeSearch", "@strSubDivisionCodeSearch", "@strCustomerName" }, new object[] { strUsername, bitApproved, strDivisionCodeSearch, strSubDivisionCodeSearch, strCustomerName });
        }

        public DataTable GetMenuParents(string strKeyLanguage, string strUsername)
        {
            return CallSpEi("sp_getMenuParents", new[] { "@strKeyLanguage", "@strUsername" }, new object[] { strKeyLanguage, strUsername });
        }
        public DataTable GetSubMenuByParentId(int intParentId, string strKeyLanguage, string strUsername)
        {
            return CallSpEi("sp_getSubMenuByParentID", new[] { "@intParentID", "@strKeyLanguage", "@strUsername" }, new object[] { intParentId, strKeyLanguage, strUsername });
        }
        public DataTable GetDayPCuttingOff(string strUsername, string strDivisionCodeSearch, string strSubDivisionCodeSearch, string strMonthYear)
        {
            return CallSpEi("sp_getDayPCuttingOff", new[] { "@strUsername", "@strDivisionCodeSearch", "@strSubDivisionCodeSearch", "@strMonthYear" }, new object[] { strUsername, strDivisionCodeSearch, strSubDivisionCodeSearch, strMonthYear });
        }
        public DataTable GetPCuttingOff(string datPcDate, string strDivisionCodeSearch, string strSubDivisionCodeSearch)
        {
            return CallSpEi("sp_getPCuttingOff", new[] { "@datPCDate", "@strDivisionCodeSearch", "@strSubDivisionCodeSearch" }, new object[] { datPcDate, strDivisionCodeSearch, strSubDivisionCodeSearch });
        }

        public DataTable getTSVH_SmartHome(string maDiemDo1, string maDiemDo2, string maDiemDo3, string maDiemDo4, string maDiemDo5)
        {
            return CallSpEi("getTSVH_SmartHome", new[] { "@Ma_DiemDo1", "@Ma_DiemDo2", "@Ma_DiemDo3", "@Ma_DiemDo4", "@Ma_DiemDo5" }, new object[] { maDiemDo1, maDiemDo2, maDiemDo3, maDiemDo4, maDiemDo5 });
        }
        public DataTable GetDocuments(string intDocId)
        {
            return CallSpEi("sp_getDocuments", new[] { "@intDocID" }, new object[] { intDocId });
        }
        public DataTable GetCustomerSearch(string value, string dviqly)
        {
            return CallSpEi("sp_getCustomerSearch", new[] { "@Value", "@DVIQLY" }, new object[] { value, dviqly });
        }
        public DataTable GetThongTinLienHe(string maDviqly)
        {
            return CallSpEi("sp_getThongTinLienHe", new[] { "@MA_DVIQLY" }, new object[] { maDviqly });
        }

        public DataTable GetTinTucByIDe(string id)
        {
            return CallSpEi("sp_getTinTucByID", new[] { "@ID" }, new object[] { id });
        }

        public DataTable get_DSDonvi()
        {
            return CallSpEi("sp_get_DSDonvi");
        }
        public DataTable GetPcScheduleKv(string strDevisionCode, string strSubDevisionCode, string strFrom, string strTo)
        {
            return CallSpEi("sp_getPCScheduleKV", new[] { "@strDivisionCode", "@strSubDivisionCode", "@strFrom", "@strTo" }, new object[] { strDevisionCode, strSubDevisionCode, strFrom, strTo });
        }

        public DataTable GetPcScheduleKv(string strDevisionCode, string strSubDevisionCode, string strMaSoGcs, string strFrom, string strTo)
        {
            return CallSpEi("sp_getPCScheduleKV", new[] { "@strDivisionCode", "@strSubDivisionCode", "@strMaSoGCS", "@strFrom", "@strTo" }, new object[] { strDevisionCode, strSubDevisionCode, strMaSoGcs, strFrom, strTo });
        }
        public DataTable GetPcSchedule(string strDevisionCode, string strSubDevisionCode, object strLineCode, object strStationCode, string strFrom, string strTo)
        {
            return CallSpEi("sp_getPCSchedule", new[] { "@strDivisionCode", "@strSubDivisionCode", "@strLineCode", "@strStationCode", "@strFrom", "@strTo" }, new object[] { strDevisionCode, strSubDevisionCode, strLineCode, strStationCode, strFrom, strTo });
        }

        public DataSet get_DVI_CAPTREN()
        {
            const string strobjectname = "sp_get_DVI_CAPTREN";
            base.Open();
            var dsResult = Db.runDynamicSqlQuery(strobjectname, null, null, CommandType.StoredProcedure);
            base.Close();
            return dsResult;
        }
        public DataTable get_DVI_CAPDUOI(string maDviqly)
        {
            return CallSpEi("sp_get_DVI_CAPDUOI", new[] { "@MA_DVIQLY" }, new object[] { maDviqly });
        }
        public DataTable GetConInfo(string maKhang)
        {
            return CallSpEi("sp_getConInfo", new[] { "@MA_KHANG" }, new object[] { maKhang });
        }
        public DataTable GetInfoCompanyByCompanycode(string maDviqly)
        {
            return CallSpEi("sp_getInfoCompanyByCompanycode", new[] { "@MA_DVIQLY" }, new object[] { maDviqly });
        }
        public DataTable GetUsernameByContractNumber(string strContractNumber)
        {
            return CallSpEi("sp_getUsernameByContractNumber", new[] { "@strContractNumber" }, new object[] { strContractNumber });
        }

        public DataTable getUSER_LOGIN(string tungay, string denngay)
        {
            return CallSpEi("sp_getUSER_LOGIN", new[] { "@TUNGAY", "@DENNGAY" }, new object[] { tungay, denngay });
        }

        public DataTable getUSER_ONLINE()
        {
            return CallSpEi("sp_getUSER_ONLINE");
        }
        public DataTable sp_getUSER_LOGIN_BYMAKHANG(string maDviqly, string tungay, string denngay)
        {
            return CallSpEi("sp_getUSER_LOGIN_BYMAKHANG", new[] { "@MA_DVIQLY", "@TUNGAY", "@DENNGAY" }, new object[] { maDviqly, tungay, denngay });
        }

        public DataTable getUSER_LOGIN(string maDviqly, string tungay, string denngay)
        {
            return CallSpEi("sp_getUSER_LOGIN", new[] { "@MA_DVIQLY", "@TUNGAY", "@DENNGAY" }, new object[] { maDviqly, tungay, denngay });
        }

        public DataTable GetDiemThuInfo(string maTinh, string maHuyen, int loai, string diaChi)
        {
            return CallSpEi("sp_getDiemThuInfo", new[] { "@MA_TINH", "@MA_HUYEN", "@LOAI", "@DIA_CHI" }, new object[] { maTinh, maHuyen, loai, diaChi });
        }

        public DataTable DiemThuUpdate(string tenGiaoDich, int gioLamViec, string diaChi, string sdt, int ID_DIEM_THU, int LOAI)
        {
            return CallSpEi("sp_updateDiemThu", new[] { "@TEN_GIAO_DICH", "@GIO_LAM_VIEC", "@DIA_CHI", "@SDT", "@ID_DIEM_THU", "LOAI" }, new object[] { tenGiaoDich, gioLamViec, diaChi, sdt, ID_DIEM_THU, LOAI });
        }

        public DataTable DiemThuAddNew(string maTinh, string maHuyen, string tenGiaoDich, string sdt, string diaChi, int gioLamViec, int loai)
        {
            return CallSpEi("sp_insertDiemThu", new[] { "@MA_CAP1", "@MA_CAP2", "@TEN_GIAO_DICH", "@SDT", "@DIA_CHI", "@GIO_LAM_VIEC", "@LOAI" }, new object[] { maTinh, maHuyen, tenGiaoDich, sdt, diaChi, gioLamViec, loai });
        }

        public DataTable GetDvDiaChinhCap1()
        {
            return CallSpEi("sp_get_DVDiaChinhCap1");
        }

        public DataTable GetDvDiaChinhCap2(string maDvcaptren)
        {
            return CallSpEi("sp_get_DVDiaChinhCap2", new[] { "@MA_DVICTREN" }, new object[] { maDvcaptren });
        }

        public DataTable getDSGopY_By_MA_DVIQLY(string maDviqly)
        {
            return CallSpEi("get_DSGopY", new[] { "@MA_DVIQLY" }, new object[] { maDviqly });
        }
        public DataTable GetHdByMauKiHieuSo(string mauhoadon, string kihieuhoadon, string sohoadon)
        {
            return CallSpEi("spGetHDByMauKiHieuSo", new[] { "@mauhoadon", "@kihieuhoadon", "@sohoadon" }, new object[] { mauhoadon, kihieuhoadon, sohoadon });
        }
        public DataTable GetHdHuyByMauKiHieuSo(string mauhoadon, string kihieuhoadon, string sohoadon)
        {
            return CallSpEi("spGetHDHuyByMauKiHieuSo", new[] { "@mauhoadon", "@kihieuhoadon", "@sohoadon" }, new object[] { mauhoadon, kihieuhoadon, sohoadon });
        }
        public DataTable GetHddtbyMaKh(string maKh, int ky, int nam)
        {
            return CallSpEi("sp_get_HDDT", new[] { "@MaKH", "@Ky", "@Nam" }, new object[] { maKh, ky, nam });
        }
        public DataTable GetDsQuayThu(string maKv)
        {
            return CallSpEi("sp_getDSQuayThu", new[] { "@MaKV" }, new object[] { maKv });
        }
        public DataTable GetDsCauHoiThuongGap()
        {
            return CallSpEi("sp_getDSCauHoi");
        }
        public DataTable GetDsThanhToan()
        {
            return CallSpEi("sp_getDSThanhToan");
        }

        public DataTable Bc_TaiHDDT(int nam, int ky)
        {
            return CallSpEi("spBcTaiHDDT", new[] { "@nam", "@ky" }, new object[] { nam, ky });
        }

        public DataTable GetDsVanBan()
        {
            return CallSpEi("sp_getDSVanBan");
        }

        public DataTable GetDsCauHoiByKey(string key)
        {
            return CallSpEi("sp_getDSCauHoiByKey", new[] { "@Key" }, new object[] { key });
        }

        public DataTable GetDsCauHoiById(string idCh)
        {
            return CallSpEi("sp_getDSCauHoiByID", new[] { "@ID" }, new object[] { idCh });
        }

        public DataTable GetThanhToanById(string idCh)
        {
            return CallSpEi("sp_getThanhToanByID", new[] { "@ID" }, new object[] { idCh });
        }

        public DataTable GetHdsdbyId(string id)
        {
            return CallSpEi("sp_getHDSDByID", new[] { "@ID" }, new object[] { id });
        }

        public DataTable GetHdsd()
        {
            return CallSpEi("sp_getHDSD");
        }

        public string GetContractNumberByUsername(string strUsername)
        {
            const string strobjectname = "sp_getContractNumberByUsername";
            var names = new[] { "@strUsername" };
            var values = new object[] { strUsername };
            base.Open();
            var strResult = Db.runDynamicSqlScalar(strobjectname, names, values, CommandType.StoredProcedure).ToString();
            base.Close();
            return strResult;
        }
        public string GetCustomerNameByUsername(string strUsername)
        {
            const string strobjectname = "sp_getCustomerNameByUsername";
            var names = new string[] { "@strUsername" };
            var values = new object[] { strUsername };
            base.Open();
            var strResult = Db.runDynamicSqlScalar(strobjectname, names, values, CommandType.StoredProcedure).ToString();
            base.Close();
            return strResult;
        }
        public int SetCustomerInformation(int intCustomerId, string strContractNumber, string strCustomerName, string strAddress)
        {
            const string strobjectname = "sp_setCustomerInformation";
            var names = new[] { "@intCustomerID", "@strContractNumber", "@strCustomerName", "@strAddress" };
            var values = new object[] { intCustomerId, strContractNumber, strCustomerName, strAddress };
            base.Open();
            var intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public void SetUsernames(string strUsername, string strPassword, string strContractNumber, string strDivisionCode, string strSubDivisionCode, bool bitIsSuperUser, int intAdminLevel)
        {
            const string strobjectname = "sp_setUsernames";
            var names = new[] { "@strUsername", "@strPassword", "@strContractNumber", "@strDivisionCode", "@strSubDivisionCode", "@bitIsSuperUser", "@intAdminLevel" };
            var values = new object[] { strUsername, strPassword, strContractNumber, strDivisionCode, strSubDivisionCode, bitIsSuperUser, intAdminLevel };
            base.Open();
            Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
        }
        public bool GetExistUsername(string strUsername)
        {
            const string strobjectname = "sp_getExistUsername";
            var names = new[] { "@strUsername" };
            var values = new object[] { strUsername };
            base.Open();
            var bolResult = Convert.ToBoolean(Db.runDynamicSqlScalar(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return bolResult;
        }
        public bool GetExistService(string strUsername)
        {
            const string strobjectname = "sp_getExistService";
            var names = new[] { "@strUsername" };
            var values = new object[] { strUsername };
            base.Open();
            var bolResult = Convert.ToBoolean(Db.runDynamicSqlScalar(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return bolResult;
        }
        public int SetService(string maKhang, string strTelephone, string strEmail, string strAccountNumber, string strBank, bool bitSendSMS, bool bitSendEmail, bool bitSettleByBank)
        {
            const string strobjectname = "sp_setService";
            var names = new[] { "@MA_KHANG", "@strTelephone", "@strEmail", "@strAccountNumber", "@strBank", "@bitSendSMS", "@bitSendEmail", "@bitSettleByBank" };
            var values = new object[] { maKhang, strTelephone, strEmail, strAccountNumber, strBank, bitSendSMS, bitSendEmail, bitSettleByBank };
            base.Open();
            var intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }

        public void SetPassword(string strUsername, string strPassword)
        {
            const string strobjectname = "sp_setPassword";
            var names = new[] { "@Username", "@Password" };
            var values = new object[] { strUsername, strPassword };
            base.Open();
            Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
        }
        public bool GetIsSuperUser(string strUsername)
        {
            const string strobjectname = "sp_getIsSuperUser";
            var names = new[] { "@strUsername" };
            var values = new object[] { strUsername };
            base.Open();
            var bolResult = Convert.ToBoolean(Db.runDynamicSqlScalar(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return bolResult;
        }

        public string GetDivisionByUsername(string strUsername)
        {
            const string strobjectname = "sp_getDivisionByUsername";
            var names = new[] { "@strUsername" };
            var values = new object[] { strUsername };
            base.Open();
            var strResult = Db.runDynamicSqlScalar(strobjectname, names, values, CommandType.StoredProcedure).ToString();
            base.Close();
            return strResult;
        }
        public int SetNewContract(string strDivisionCode, int intType, string strContractNumber, string strContractName, string strStreet, string strWard, int intDistrictID, string strContactName, string strContactCMND, string strContactDateIssue, string strContactPlaceIssue, string strContactEmail, string strContactTelephone, string strContactAddress, decimal decLatitude, decimal decLongitude, int intPurpose, bool bitPha, bool bitStatus)
        {
            const string strobjectname = "sp_setNewContract";
            var names = new[] { "@strDivisionCode", "@intType", "@strContractNumber", "@strContractName", "@strStreet", "@strWard", "@intDistrictID", "@strContactName", "@strContactCMND", "@strContactDateIssue", "@strContactPlaceIssue", "@strContactEmail", "@strContactTelephone", "@strContactAddress", "@decLatitude", "@decLongitude", "@intPurpose", "@bitPha", "@bitStatus" };
            var values = new object[] { strDivisionCode, intType, strContractNumber, strContractName, strStreet, strWard, intDistrictID, strContactName, strContactCMND, strContactDateIssue, strContactPlaceIssue, strContactEmail, strContactTelephone, strContactAddress, decLatitude, decLongitude, intPurpose, bitPha, bitStatus };
            base.Open();
            var intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public int SetNewThread(int intThreadId, string strThreadTitle, string strThreadMessage, string strUsername, string strCustomerName, string strCustomerAddress, string strTelephone, string strEmail, int intSessionID, int intParentID, string strKeyLanguage)
        {
            const string strobjectname = "sp_setNewThread";
            var names = new[] { "@intThreadID", "@strThreadTitle", "@strThreadMessage", "@strUsername", "@strCustomerName", "@strCustomerAddress", "@strTelephone", "@strEmail", "@intSessionID", "@intParentID", "@strKeyLanguage" };
            var values = new object[] { intThreadId, strThreadTitle, strThreadMessage, strUsername, strCustomerName, strCustomerAddress, strTelephone, strEmail, intSessionID, intParentID, strKeyLanguage };
            base.Open();
            var intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public int SetNewAnswer(int intThreadId, string strThreadTitle, string strThreadMessage, string strUsername, int intParentId, string strKeyLanguage)
        {
            const string strobjectname = "sp_setNewAnswer";
            var names = new[] { "@intThreadID", "@strThreadTitle", "@strThreadMessage", "@strUsername", "@intParentID", "@strKeyLanguage" };
            var values = new object[] { intThreadId, strThreadTitle, strThreadMessage, strUsername, intParentId, strKeyLanguage };
            base.Open();
            int intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public int SetPublicThread(int intThreadId)
        {
            const string strobjectname = "sp_setPublicThread";
            var names = new[] { "@intThreadID" };
            var values = new object[] { intThreadId };
            base.Open();
            var intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public int SetDisableThread(int intThreadId)
        {
            const string strobjectname = "sp_setDisableThread";
            var names = new[] { "@intThreadID" };
            var values = new object[] { intThreadId };
            base.Open();
            var intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }

        public int SetRecordingMeters(int intRecordingId, string maKhang, string bcs, decimal chisoMoi, DateTime ngayGhichiso)
        {
            const string strobjectname = "sp_setRecordingMeters";
            var names = new[] { "@intRecordingID", "@MA_KHANG", "@BCS", "@CHISO_MOI", "@NGAY_GHICHISO" };
            var values = new object[] { intRecordingId, maKhang, bcs, chisoMoi, ngayGhichiso };
            base.Open();
            int intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }

        public void DelMessageFromQueue(int intMessageId)
        {
            const string strobjectname = "sp_delMessageFromQueue";
            var names = new[] { "@intMessageID" };
            var values = new object[] { intMessageId };
            base.Open();
            Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
        }
        public void SetResendMessageIntoQueue(int intMessageId)
        {
            const string strobjectname = "sp_setResendMessageIntoQueue";
            var names = new[] { "@intMessageID" };
            var values = new object[] { intMessageId };
            base.Open();
            Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
        }

        public int SetPublicSurvey(int intSurveyId)
        {
            const string strobjectname = "sp_setPublicSurvey";
            var names = new[] { "@intSurveyID" };
            var values = new object[] { intSurveyId };
            base.Open();
            var intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public int SetLockSurvey(int intSurveyId)
        {
            const string strobjectname = "sp_setLockSurvey";
            var names = new[] { "@intSurveyID" };
            var values = new object[] { intSurveyId };
            base.Open();
            var intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public int SetReOpenSurvey(int intSurveyId)
        {
            const string strobjectname = "sp_setReOpenSurvey";
            var names = new[] { "@intSurveyID" };
            var values = new object[] { intSurveyId };
            base.Open();
            int intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public int SetSurvey(int intSurveyId, string strSurveyName, DateTime datDateStart, DateTime datDateEnd)
        {
            const string strobjectname = "sp_setSurvey";
            var names = new[] { "@intSurveyID", "@strSurveyName", "@datDateStart", "@datDateEnd" };
            var values = new object[] { intSurveyId, strSurveyName, datDateStart, datDateEnd };
            base.Open();
            var intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }

        public int SetDeleteAnswer(int intSurveyAnswerId)
        {
            const string strobjectname = "sp_setDeleteAnswer";
            var names = new[] { "@intSurveyAnswerID" };
            var values = new object[] { intSurveyAnswerId };
            base.Open();
            var intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public int SetSurveyAnswers(int intSurveyAnswerId, string strSurveyAnswerName, bool bitOther, int intSurveyQuestionId)
        {
            const string strobjectname = "sp_setSurveyAnswers";
            var names = new string[] { "@intSurveyAnswerID", "@strSurveyAnswerName", "@bitOther", "@intSurveyQuestionID" };
            var values = new object[] { intSurveyAnswerId, strSurveyAnswerName, bitOther, intSurveyQuestionId };
            base.Open();
            var intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public int SetSurveyQuestion(int intSurveyQuestionId, string strSurveyQuestionName, int intSurveyQuestionTypeId, object intTempleteId, int intSurveyId)
        {
            const string strobjectname = "sp_setSurveyQuestion";
            var names = new[] { "@intSurveyQuestionID", "@strSurveyQuestionName", "@intSurveyQuestionTypeID", "@intTempleteID", "@intSurveyID" };
            var values = new object[] { intSurveyQuestionId, strSurveyQuestionName, intSurveyQuestionTypeId, intTempleteId, intSurveyId };
            base.Open();
            var intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public int SetDeleteSurveyQuestion(int intSurveyQuestionId)
        {
            const string strobjectname = "sp_setDeleteSurveyQuestion";
            var names = new string[] { "@intSurveyQuestionID" };
            var values = new object[] { intSurveyQuestionId };
            base.Open();
            var intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }

        public int SetVoting(string strUsername, int intSurveyQuestionId, string strSurveyAnswerListId, string strOtherText)
        {
            const string strobjectname = "sp_setVoting";
            var names = new string[] { "@strUsername", "@intSurveyQuestionID", "@strSurveyAnswerListID", "@strOtherText" };
            var values = new object[] { strUsername, intSurveyQuestionId, strSurveyAnswerListId, strOtherText };
            base.Open();
            int intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }

        public int SetReEditSurvey(int intSurveyId)
        {
            const string strobjectname = "sp_setReEditSurvey";
            var names = new string[] { "@intSurveyID" };
            var values = new object[] { intSurveyId };
            base.Open();
            int intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public int SetFinishSurvey(int intSurveyId)
        {
            const string strobjectname = "sp_setFinishSurvey";
            var names = new string[] { "@intSurveyID" };
            var values = new object[] { intSurveyId };
            base.Open();
            int intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }

        public bool GetIsVotingAlready(string strUsername, int intSurveyId)
        {
            var bolResult = false;
            const string strobjectname = "sp_getIsVotingAlready";
            var names = new string[] { "@strUsername", "@intSurveyID" };
            var values = new object[] { strUsername, intSurveyId };
            base.Open();
            bolResult = Convert.ToBoolean(Db.runDynamicSqlScalar(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return bolResult;
        }

        public int SetAllocateContract(int intContractId)
        {
            const string strobjectname = "sp_setAllocateContract";
            var names = new string[] { "@intContractID" };
            var values = new object[] { intContractId };
            base.Open();
            int intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public int SetAllocateContract(int intContractId, string strSubDivisionCode)
        {
            const string strobjectname = "sp_setAllocateContract";
            var names = new string[] { "@intContractID", "@strSubDivisionCode" };
            var values = new object[] { intContractId, strSubDivisionCode };
            base.Open();
            int intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public bool SetAllocateContractAll(string strContractListId)
        {
            const string strobjectname = "sp_setAllocateContractAll";
            var names = new string[] { "@strContractListID" };
            var values = new object[] { strContractListId };
            base.Open();
            bool bolResult = Convert.ToBoolean(Db.runDynamicSqlScalar(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return bolResult;
        }

        public int SetDeletePcSchedule(int intPCuttingScheduleId)
        {
            const string strobjectname = "sp_setDeletePCSchedule";
            var names = new string[] { "@intPCuttingScheduleID" };
            var values = new object[] { intPCuttingScheduleId };
            base.Open();
            int intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public int SetUpdatePcSchedule(int intPCuttingScheduleId, string strDivisionCode, string strSubDivisionCode, string strLineCode, string strLineName, string strStationCode, string strStationName, DateTime datPcDate, string strTimeStart1, string strTimeEnd1, string strTimeStart2, string strTimeEnd2, object strReason)
        {
            const string strobjectname = "sp_setUpdatePCSchedule";
            var names = new string[] { "@intPCuttingScheduleID", "@strDivisionCode", "@strSubDivisionCode", "@strLineCode", "@strLineName", "@strStationCode", "@strStationName", "@datPCDate", "@strTimeStart1", "@strTimeEnd1", "@strTimeStart2", "@strTimeEnd2", "@strReason" };
            var values = new object[] { intPCuttingScheduleId, strDivisionCode, strSubDivisionCode, strLineCode, strLineName, strStationCode, strStationName, datPcDate, strTimeStart1, strTimeEnd1, strTimeStart2, strTimeEnd2, strReason };
            base.Open();
            int intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }

        public bool SetDocuments(string intDocId, string strDocContent)
        {
            const string strobjectname = "sp_setDocuments";
            var names = new string[] { "@intDocID", "@strDocContent" };
            var values = new object[] { intDocId, strDocContent };
            base.Open();
            Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
            return true;
        }


        public bool SetThongTinLienHe(string maDviqly, string strDocContent)
        {
            const string strobjectname = "sp_setThongTinLienHe";
            var names = new string[] { "@MA_DVIQLY", "@strDocContent" };
            var values = new object[] { maDviqly, strDocContent };
            base.Open();
            Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
            return true;
        }

        public int DelRecordingMeters(int intRecordingId)
        {
            const string strobjectname = "sp_delRecordingMeters";
            var names = new string[] { "@intRecordingID" };
            var values = new object[] { intRecordingId };
            base.Open();
            int intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public string getMA_DVIDCHINH(string maDviqly)
        {
            const string strobjectname = "sp_getMA_DVIDCHINH";
            var names = new string[] { "@MA_DVIQLY" };
            var values = new object[] { maDviqly };
            base.Open();
            var strResult = Db.runDynamicSqlScalar(strobjectname, names, values, CommandType.StoredProcedure).ToString();
            base.Close();
            return strResult;
        }
        public int InsertYeuCauThayDoiThongTinKh(string idkh, string tenKh, string sdt, string diaChi)
        {
            const string strobjectname = "sp_InsertYeuCauThayDoiThongTinKH";
            var names = new string[] { "@IDKH", "@TenKhachHang", "@SDT", "@DiaChi" };
            var values = new object[] { idkh, tenKh, sdt, diaChi };
            base.Open();
            int intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }
        public int Insert_to_DV_KQUA_XLY(string DLUC_CAPCHA, string DLUC_CAPCON, string KHACH_HANG, string TEN_KHANG, string TEN_DDIEN, string CMND_HCHIEU, string NOI_CAP, int CAP_NGAY, int CAP_THANG, int CAP_NAM, string SO_NHA, string DUONG_PHO, string PHUONG_XA, string SO_PHA, string EMAIL, string DCHI_DUNGDIEN, string SO_DTHOAI)
        {
            const string strobjectname = "sp_Insert_to_DV_KQUA_XLY";
            var names = new string[] { "@DLUC_CAPCHA", "@DLUC_CAPCON", "@KHACH_HANG", "@TEN_KHANG", "@TEN_DDIEN", "@CMND_HCHIEU", "@NOI_CAP", "@CAP_NGAY", "@CAP_THANG", "@CAP_NAM", "@SO_NHA", "@DUONG_PHO", "@PHUONG_XA", "@SO_PHA", "@EMAIL", "@DCHI_DUNGDIEN", "@SO_DTHOAI" };
            var values = new object[] { DLUC_CAPCHA, DLUC_CAPCON, KHACH_HANG, TEN_KHANG, TEN_DDIEN, CMND_HCHIEU, NOI_CAP, CAP_NGAY, CAP_THANG, CAP_NAM, SO_NHA, DUONG_PHO, PHUONG_XA, SO_PHA, EMAIL, DCHI_DUNGDIEN, SO_DTHOAI };
            base.Open();
            int intResult = Convert.ToInt32(Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure));
            base.Close();
            return intResult;
        }

        public int Insert_GopY(string hoTen, string diaChi, string sdt, string email, string noiDung)
        {
            const string strobjectname = "sp_insertGopY";
            var names = new string[] { "@HO_TEN", "@DIA_CHI", "@SDT", "@EMAIL", "@NOI_DUNG" };
            var values = new object[] { hoTen, diaChi, sdt, email, noiDung };
            base.Open();
            int intResult = Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
            return intResult;
        }

        public Boolean CheckValidCertificate(string publickey)
        {
            const string strobjectname = "sp_hd_checkValidCertificate";
            var p_publickey = new DbParameter("@public_key", publickey);
            var p_isvalid = new DbParameter("@isvalid", SqlDbType.Bit, 1) { Direction = ParameterDirection.Output };
            var prs = new[] { p_publickey, p_isvalid };
            base.Open();
            Db.runDynamicSqlScalar(strobjectname, prs, CommandType.StoredProcedure);
            base.Close();
            return Convert.ToBoolean(p_isvalid.Value.ToString());
        }

        public int UpdateQuayThu(string kinhDo, string viDo, string id)
        {
            const string strobjectname = "UPDATE dbo.tblQuayThu SET KinhDo = @KinhDo, ViDo = @Vido WHERE ID = @ID";
            var names = new string[] { "@KinhDo", "@Vido", "@ID" };
            var values = new object[] { kinhDo, viDo, id };
            base.Open();
            int intResult = Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.Text);
            base.Close();
            return intResult;
        }

        public int Insert_YeuCau(string loaiYc, string maKv, string maPhuong, string tenKh, string soNha, string sdt, string cmnd, string dgPho, string email, string noiDung)
        {
            const string strobjectname = "sp_InsertYeuCau";
            var names = new string[] { "@LoaiYC", "@MaKV", "@MaPhuong", "@TenKH", "@SoNha", "@SDT", "@CMND", "@DuongPho", "@Email", "@NoiDung" };
            var values = new object[] { loaiYc, maKv, maPhuong, tenKh, soNha, sdt, cmnd, dgPho, email, noiDung };
            base.Open();
            var intResult = Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
            return intResult;
        }
        //public int Insert_DichVu(string madv, string idkh, string tenkh, string sdt, string email)
        //{
        //    const string strobjectname = "sp_InsertDichvu";
        //    var names = new string[] { "@madv", "@idkh", "@tenkh", "@sdt", "@email" };
        //    var values = new object[] { madv, idkh, tenkh, sdt, email };
        //    base.Open();
        //    var intResult = Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
        //    base.Close();
        //    return intResult;
        //}
        public int Insert_DichVu(string madv, string idkh, string tenkh, string sdt, string email)
        {
            return CallSpEiReturnInt("sp_InsertDichvu", new[] { "@madv", "@idkh", "@tenkh", "@sdt", "@email" }, new object[] { madv, idkh, tenkh, sdt, email });
        }

        public int Insert_CauHoi(string tieuDe, string noiDung, string nguoiTao)
        {
            const string strobjectname = "sp_InsertCauHoi";
            var names = new string[] { "@TieuDe", "@NoiDung", "@NguoiTao" };
            var values = new object[] { tieuDe, noiDung, nguoiTao };
            base.Open();
            int intResult = Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
            return intResult;
        }
        public int Insert_User(string userName, string passWord, string idKH, string tenKH, string madb, string maLoTrinh, string diachi, string sdt, string makv, string maphuong)
        {
            const string strobjectname = "sp_InsertUser";
            var names = new string[] { "@UserName", "@PassWord", "@IDKH", "@TenKhachHang", "@MaDB", "@MaLoTrinh", "@DiaChi", "@SDT", "@MaKv", "MaPhuong" };
            var values = new object[] { userName, Constants.Encrypt(passWord), idKH, tenKH, madb, maLoTrinh, diachi, sdt, makv, maphuong };
            base.Open();
            var intResult = Db.runDynamicSqlScalar(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
            return int.Parse(intResult.ToString());
        }

        public void SetTruyCap(string strSessionId, string strUsername, string diaChiIp, string pageName)
        {
            const string strobjectname = "sp_TruyCap";
            var names = new string[] { "@SessionID", "@UserName", "@DiaChiIP", "@PageName" };
            var values = new object[] { strSessionId, strUsername, diaChiIp, pageName };
            base.Open();
            Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
        }

        public void SetDownloadHd(string idkh, int nam, int ky)
        {
            const string strobjectname = "sp_setDownloadHD";
            var names = new string[] { "@IDKH", "@NAM", "@KY" };
            var values = new object[] { idkh, nam, ky };
            base.Open();
            Db.runDynamicSqlScalar(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
        }

        public void GetLuongTruyCap(DateTime tuNgay, DateTime denNgay)
        {
            const string strobjectname = "sp_get_TruyCap";
            var names = new string[] { "@TuNgay", "@DenNgay" };
            var values = new object[] { tuNgay, denNgay };
            base.Open();
            Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
        }

        public bool Addmalo(DateTime ngayBatDau, DateTime ngayKetThuc, int gioBatDau, int phutBatDau, int gioKetThuc, int phutKetThuc, string lydo, bool suCo, string maLoTrinh, string maKv)
        {
            const string strobjectname = "sp_addmalo";
            var names = new string[] { "@NgayBatDau", "@NgayKetThuc", "@GioBatDau", "@PhutBatDau", "@GioKetThuc", "@PhutKetThuc", "@Lydo", "@SuCo", "@MaLoTrinh", "@MaKV" };
            var values = new object[] { ngayBatDau, ngayKetThuc, gioBatDau, phutBatDau, gioKetThuc, phutKetThuc, lydo, suCo, maLoTrinh, maKv };
            base.Open();
            Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
            return true;
        }

        // End CSKH


    }
}
