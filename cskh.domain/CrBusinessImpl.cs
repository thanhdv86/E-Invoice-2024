using System;
using System.Data;

namespace cskh.domain
{
    public class CrBusinessImpl : DataAccess
    //, ICRBusiness
    {

        public CrBusinessImpl(): base(CrconString)
        {

        }
        
        /// <summary>
        /// Update thông tin số hóa đơn cho kỳ hóa đơn đã ký nhưng chưa lưu số hóa đơn Author: ThanhDV
        /// </summary>
        /// <param name="transactionUuid"></param>
        /// <param name="invoiceNo"></param>
        public void UpdateInvoiceNo(string transactionUuid, string invoiceNo)
        {
            base.Open();
            const string query = "UPDATE TIEUTHU SET invoiceNo = @invoiceNo WHERE THANG = 7 AND NAM = 2022 AND transactionUuid = @transactionUuid AND (invoiceNo IS NULL OR invoiceNo = '')";
            var names = new[] { "@transactionUuid", "@invoiceNo" };
            var values = new object[] { transactionUuid, invoiceNo };
            var result = Db.runDynamicSqlQuery(query, names, values, CommandType.Text);
            base.Close();
        }
        public DataTable CallSpCr(string strSql)
        {DataTable dt = null;
            Open();
            var ds = Db.runSQLQuery(strSql);
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            Close();
            return dt;
        }
        public DataTable CallSpCr(string strSql, string[] paramNames, object[] paramValues)
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
        public DataSet GetListDp()
        {
            const string strobjectname = "select MADP, MADP + ' - ' + TENDP AS TENDP from DUONGPHO order by MADP;";
            base.Open();
            DataSet dsResult = Db.runDynamicSqlQuery(strobjectname, null, null, CommandType.Text);
            base.Close();
            return dsResult;}
        public DataSet getListDP_withKV()
        {
            base.Open();
            var result = Db.runSQLQuery("SELECT DP.MADP, DP.TENDP, DP.MAKV, KV.TENKV FROM DUONGPHO AS DP INNER JOIN KHUVUC AS KV ON DP.MAKV = KV.MAKV;");
            base.Close();
            return result;
        }
        public DataTable GetDsDuongPho(string makv)
        {
            base.Open();
            const string query = "select MADP, MADP + ' - ' + TENDP AS TENDP from DUONGPHO WHERE (MAKV = @MAKV) or (@MAKV = '%' ) order by MADP;";
            var names = new[] { "@MAKV" };
            var values = new object[] { makv };
            var result = Db.runDynamicSqlQuery(query, names, values, CommandType.Text);
            base.Close();
            return result.Tables[0];
        }

        public DataTable GetHdbyDp(string madp, int thang, int nam)
        {
            return CallSpCr("HDDT_InHoaDonGiaTangX", new[] { "@MADP", "@THANG", "@NAM" }, new object[] { madp, thang, nam });
        }

        public DataTable GetHdbytransactionUuid(string transactionUuid, int thang, int nam)
        {
            return CallSpCr("HDDT_HoaDonByTransactionUuidX", new[] { "@transactionUuid", "@THANG", "@NAM" }, new object[] { transactionUuid, thang, nam });
        }

        public DataTable GetHdbyIdkh(string idkh, int thang, int nam)
        {
            return CallSpCr("HDDT_InHoaDonByIDKHX", new[] { "@IDKH", "@THANG", "@NAM" }, new object[] { idkh, thang, nam });
        }

        public DataTable GetHdbyKv(string makv, int thang, int nam)
        {
            return CallSpCr("HDDT_DSKH_KyHoaDon", new[] { "@MAKV", "@THANG", "@NAM" }, new object[] { makv, thang, nam });
        }

        public DataTable GetKyHd()
        {
            return CallSpCr("HDDT_GetKyHD");
        }

        public DataTable getCountHD_byKV(string makv, int thang, int nam)
        {
            return CallSpCr("HDDT_BangKeHoaDonKy", new[] { "@MAKV", "@THANG", "@NAM" }, new object[] { makv, thang, nam });
        }

        /// <summary>
        /// Gets the ds thuc no.
        /// </summary>
        /// <param name="makv">The makv.</param>
        /// <param name="madp">The madp.</param>
        /// <param name="thang">The thang.</param>
        /// <param name="nam">The nam.</param>
        /// <param name="nhamang">1. Viettel, 2.VINA, 3. MOBIFONE</param>
        /// <returns></returns>
        public DataTable GetDsThucNo(string makv, string madp, int thang, int nam, int nhamang)
        {
            string strobjectname;

            switch (Convert.ToInt16(nhamang))
            {
                case 1:
                    strobjectname = "SMS_VIETTEL";
                    break;
                case 2:
                    strobjectname = "SMS_VINAPHONE";
                    break;
                default:
                    strobjectname = "SMS_MOBIFONE";
                    break;
            }
            return CallSpCr(strobjectname, new[] { "@MAKV", "@MADP", "@THANG", "@NAM" }, new object[] { makv, madp, thang, nam });
        }

        /* Lọc theo nhà mạng
        public DataTable GetDsThucNoX(bool nhothu, int nhamang, int thang, int nam, string madp, string makv)
        {
            return CallSpCr("HDDT_SMS", new[] {"@NHOTHU", "@MANG","@THANG","@NAM","@MADP", "@MAKV"}, new object[] { nhothu, nhamang, thang, nam, madp, makv });
        }
         */
        public DataTable GetDsThucNoX(bool nhothu, int nhamang, int thang, int nam, string madp, string makv)
        {
            return CallSpCr("HDDT_SMS", new[] { "@NHOTHU", "@MANG", "@THANG", "@NAM", "@MADP", "@MAKV" }, new object[] { nhothu, nhamang, thang, nam, madp, makv });
        }

        public DataTable GetDsThucNoAllKy(bool nhothu, int nhamang, int thang, int nam, string madp, string makv, string maqt)
        {
            return CallSpCr("HDDT_SMS_ALLKY", new[] { "@NHOTHU", "@MANG", "@THANG", "@NAM", "@MADP", "@MAKV", "@MAQUAYTHU" }, new object[] { nhothu, nhamang, thang, nam, madp, makv, maqt });
        }
        public DataTable GetDsKhachHang(string makv, string madp, int nhamang)
        {
            return CallSpCr("SMS_DSKH", new[] { "@MAKV", "@MADP", "@MANG" }, new object[] { makv, madp, nhamang });
        }
        public DataTable GetDsKhachHangX(string makv, string madp, int nhamang)
        {
            return CallSpCr("HDDT_SMS_DSKH", new[] { "@MAKV", "@MADP", "@MANG" }, new object[] { makv, madp, nhamang });
        }

        public DataTable GetCustomerInfo(string idkh, string maDanhBo, string tenKhachHang, string cmnd, string sdt, string soNha, string duongPho, string makv, string maQuan, string maPhuong)
        {
            var dt = CallSpCr("HDDT_GetCustomerInfo", new[] { "@IDKH", "@SODB", "@TENKH", "@CMNN", "@SDT", "@SONHA", "@TENDUONGPHO", "@MAKV", "@MAQUAN", "@MAPHUONG" }, new object[] { idkh, maDanhBo, tenKhachHang, cmnd, sdt, soNha, duongPho, makv, maQuan, maPhuong });
            if (dt != null && dt.Rows.Count > 0)
            {
                UtilCustCares.MappingFunction("GetCustomerInfo", ref dt);
            }
            return dt;
        }

        public DataTable GetDanhSachKhuVuc()
        {
            var dt = CallSpCr("HDDT_GetDanhSachKhuVuc");
            if (dt != null && dt.Rows.Count > 0)
            {
                UtilCustCares.MappingFunction("GetDanhSachKhuVuc", ref dt);
            }
            return dt;

        }

        public DataTable GetDanhSachQuayThu()
        {
            var dt = CallSpCr("HDDT_GetDanhSachQuayThu");
            if (dt != null && dt.Rows.Count > 0)
            {
                UtilCustCares.MappingFunction("GetDanhSachQuayThu", ref dt);
            }
            return dt;

        }

        public DataTable GetDanhSachKhuVucX(int thang, int nam)
        {
            var dt = CallSpCr("HDDT_GetDanhSachKhuVucX", new[] { "@THANG", "@NAM" }, new object[] { thang, nam });
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    UtilCustCares.MappingFunction("GetDanhSachKhuVucX", ref dt);
            //}
            return dt;

        }
        public DataTable GetDanhSachQuanHuyen()
        {
            var dt = CallSpCr("HDDT_GetDanhSachQuanHuyen");
            if (dt != null && dt.Rows.Count > 0)
            {
                UtilCustCares.MappingFunction("GetDanhSachQuanHuyen", ref dt);
            }
            return dt;
        }
        public DataTable GetDanhSachPhuongXa()
        {
            var dt = CallSpCr("HDDT_GetDanhSachPhuongXa");
            if (dt != null && dt.Rows.Count > 0)
            {
                UtilCustCares.MappingFunction("GetDanhSachPhuongXa", ref dt);
            }
            return dt;
        }

        public DataTable GetDanhSachLoTrinhTheoKhuVuc(string makv)
        {
            var dt = CallSpCr("HDDT_GetDanhSachLoTrinhTheoKhuVuc", new[] { "@MAKV" }, new object[] { makv });
            if (dt != null && dt.Rows.Count > 0)
            {
                UtilCustCares.MappingFunction("GetDanhSachLoTrinhTheoKhuVuc", ref dt);
            }
            return dt;
        }
        public DataTable GetDanhSachChuaGcs(string makv, string maQuan, string maPhuong)
        {
            var dt = CallSpCr("HDDT_GetDanhSachChuaGCS", new[] { "@MAKV", "MAQUAN", "MAPHUONG" }, new object[] { makv, maQuan, maPhuong });
            if (dt != null && dt.Rows.Count > 0)
            {
                UtilCustCares.MappingFunction("GetDanhSachChuaGCS", ref dt);
            }
            return dt;
        }

        public DataTable GetDanhSachTrangThai()
        {
            var dt = CallSpCr("HDDT_GetDanhSachTrangThai");
            if (dt != null && dt.Rows.Count > 0)
            {
                UtilCustCares.MappingFunction("GetDanhSachTrangThai", ref dt);
            }
            return dt;

        }

        public DataTable GetLichSuCapNuocByIdkh(string idkh)
        {
            var dt = CallSpCr("HDDT_GetLichSuCapNuocByIDKH", new[] { "@IDKH" }, new object[] { idkh });
            if (dt != null && dt.Rows.Count > 0)
            {
                UtilCustCares.MappingFunction("GetLichSuCapNuocByIDKH", ref dt);
            }
            return dt;
        }

        public DataTable GetLichSuDungNuocByIdkh(string idkh)
        {
            var dt = CallSpCr("HDDT_GetLichSuDungNuocByIDKH", new[] { "@IDKH" }, new object[] { idkh });
            if (dt != null && dt.Rows.Count > 0)
            {
                UtilCustCares.MappingFunction("GetLichSuDungNuocByIDKH", ref dt);
            }
            return dt;
        }

        public DataTable GetLichGhiChiSo(string idkh, DateTime tungay, DateTime denngay)
        {
            var dt = CallSpCr("HDDT_GetLichGhiChiSo", new[] { "@IDKH", "@TUNGAY", "@DENNGAY" }, new object[] { idkh, tungay, denngay });
            if (dt != null && dt.Rows.Count > 0)
            {
                UtilCustCares.MappingFunction("GetLichGhiChiSo", ref dt);
            }
            return dt;
        }

        public DataTable GetListTienDolapDatNuoc(string maddk)
        {
            var dt = CallSpCr("HDDT_GetListTienDolapDatNuoc", new[] { "@MADDK" }, new object[] { maddk });
            if (dt != null && dt.Rows.Count > 0)
            {
                UtilCustCares.MappingFunction("GetListTienDolapDatNuoc", ref dt);
            }

            return dt;
        }
    }
}
