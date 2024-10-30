using System;
using System.Data;

namespace cskh.domain
{
    public static class UtilCustCares
    {
        public static void MappingFunction(string functionName, ref DataTable dt)
        {
            switch (functionName)
            {
                case "GetThongKeHoaDonTheoDuong":
                    //dt.Columns["MAKV"].ColumnName = "MAKV";
                    //dt.Columns["TENKV"].ColumnName = "TENKV";
                    //dt.Columns["MADP"].ColumnName = "MADP";
                    //dt.Columns["TENDP"].ColumnName = "TENDP";
                    //dt.Columns["SOHD"].ColumnName = "SOHD";

                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;

                case "HDDT_GetHDByKV":
                    //dt.Columns["IDKH"].ColumnName = "IDKH";
                    //dt.Columns["MAKV"].ColumnName = "MAKV";
                    //dt.Columns["TENKV"].ColumnName = "TENKV";
                    //dt.Columns["MADP"].ColumnName = "MADP";
                    //dt.Columns["TENDP"].ColumnName = "TENDP";

                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;

                case "HDDT_GetHDByIDKH":
                    //dt.Columns["IDKH"].ColumnName = "IDKH";
                    //dt.Columns["NAM"].ColumnName = "NAM";
                    //dt.Columns["KY"].ColumnName = "KY";
                    //dt.Columns["LAN"].ColumnName = "LAN";
                    //dt.Columns["MADP"].ColumnName = "MADP";
                    //dt.Columns["NGAYNHAP"].ColumnName = "NGAYNHAP";
                    //dt.Columns["NGAYNHAP_TT"].ColumnName = "NGAYNHAP_TT";
                    //dt.Columns["TENKH"].ColumnName = "TENKH";
                    //dt.Columns["DIACHI"].ColumnName = "DIACHI";
                    //dt.Columns["MST"].ColumnName = "MST";
                    //dt.Columns["BIENLAI"].ColumnName = "BIENLAI";
                    //dt.Columns["SODB"].ColumnName = "SODB";
                    //dt.Columns["DMUC"].ColumnName = "DMUC";
                    //dt.Columns["STT"].ColumnName = "STT";
                    //dt.Columns["CHISODAU"].ColumnName = "CHISODAU";
                    //dt.Columns["CHISOCUOI"].ColumnName = "CHISOCUOI";
                    //dt.Columns["KLTIEUTHU"].ColumnName = "KLTIEUTHU";
                    //dt.Columns["TIENNUOC"].ColumnName = "TIENNUOC";
                    //dt.Columns["TIENTHUE"].ColumnName = "TIENTHUE";
                    //dt.Columns["TIENPHITNMT"].ColumnName = "TIENPHITNMT";
                    //dt.Columns["PTVAT"].ColumnName = "PTVAT";
                    //dt.Columns["TONGTIEN"].ColumnName = "TONGTIEN";
                    //dt.Columns["M3MUC1"].ColumnName = "M3MUC1";
                    //dt.Columns["M3MUC2"].ColumnName = "M3MUC2";
                    //dt.Columns["M3MUC3"].ColumnName = "M3MUC3";
                    //dt.Columns["M3MUC4"].ColumnName = "M3MUC4";
                    //dt.Columns["TIENMUC1"].ColumnName = "TIENMUC1";
                    //dt.Columns["TIENMUC2"].ColumnName = "TIENMUC2";
                    //dt.Columns["TIENMUC3"].ColumnName = "TIENMUC3";
                    //dt.Columns["TIENMUC4"].ColumnName = "TIENMUC4";
                    //dt.Columns["HETNO"].ColumnName = "HETNO";
                    //dt.Columns["BARCODEINFO"].ColumnName = "BARCODEINFO";

                    //dt.Columns.Add(new DataColumn { ColumnName = "STK", MaxLength = 100, DataType = Type.GetType("System.String") });
                    //dt.Columns.Add(new DataColumn { ColumnName = "SDT", MaxLength = 100, DataType = Type.GetType("System.String") });
                    //dt.Columns.Add(new DataColumn { ColumnName = "SONK", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    // Bổ sung trường DAKY với giá trị mặc định là False
                    //dt.Columns.Add(new DataColumn { ColumnName = "DAKY", AllowDBNull = false, DataType = Type.GetType("System.Boolean"), DefaultValue = false });

                    //dt.Columns.Add("NGAYNHAP_TT", typeof(DateTime));
                    //dt.Columns.Add("NGAYNHAP", typeof(DateTime));
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    row["NGAYNHAP"] = row["NGAYNHAP_TT"];
                    //    row.EndEdit();
                    //}
                    //dt.Columns.Add(new DataColumn { ColumnName = "TIENPHITNMT", AllowDBNull = false, DataType = Type.GetType("System.Decimal"), DefaultValue = 0 });
                    //dt.Columns.Add("M3TINHTIEN", typeof(int));
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    row["M3TINHTIEN"] = row["KLTIEUTHU"];
                    //    row.EndEdit();
                    //}
                    //// Bổ sung cột địa chỉ và tính lại cột địa chỉ theo các cột khác
                    //dt.Columns.Add("diachi");
                    //// Tính toán cột địa chỉ
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    row["diachi"] = (string.IsNullOrEmpty(row["sonha"].ToString()) ? "" : row["sonha"] + ", ") + row["TENTAT"];
                    //    row.EndEdit();
                    //}
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;

                case "HDDT_GetHDByMADP":
                    //dt.Columns["IDKH"].ColumnName = "IDKH";
                    //dt.Columns["MADP"].ColumnName = "MADP";
                    //dt.Columns["TENKH"].ColumnName = "TENKH";
                    //dt.Columns["DIACHI"].ColumnName = "DIACHI";
                    //dt.Columns["MST"].ColumnName = "MST";
                    //dt.Columns["SODB"].ColumnName = "SODB";
                    //dt.Columns["DMUC"].ColumnName = "DMUC";
                    //dt.Columns["STT"].ColumnName = "STT";
                    //dt.Columns["KY"].ColumnName = "KY";
                    //dt.Columns["NAM"].ColumnName = "NAM";
                    //dt.Columns["CHISODAU"].ColumnName = "CHISODAU";
                    //dt.Columns["CHISOCUOI"].ColumnName = "CHISOCUOI";
                    //dt.Columns["TIENNUOC"].ColumnName = "TIENNUOC";
                    //dt.Columns["TIENTHUE"].ColumnName = "TIENTHUE";
                    //dt.Columns["TIENPHITNMT"].ColumnName = "TIENPHITNMT";
                    //dt.Columns["KLTIEUTHU"].ColumnName = "KLTIEUTHU";
                    //dt.Columns["TONGTIEN"].ColumnName = "TONGTIEN";

                    //dt.Columns["M3MUC1"].ColumnName = "M3MUC1";
                    //dt.Columns["M3MUC2"].ColumnName = "M3MUC2";
                    //dt.Columns["M3MUC3"].ColumnName = "M3MUC3";
                    //dt.Columns["M3MUC4"].ColumnName = "M3MUC4";
                    //dt.Columns["TIENMUC1"].ColumnName = "TIENMUC1";
                    //dt.Columns["TIENMUC2"].ColumnName = "TIENMUC2";
                    //dt.Columns["TIENMUC3"].ColumnName = "TIENMUC3";
                    //dt.Columns["TIENMUC4"].ColumnName = "TIENMUC4";
                    ////dt.Columns["HETNO"].ColumnName = "HETNO";
                    //dt.Columns["BARCODEINFO"].ColumnName = "BARCODEINFO";

                    //dt.Columns.Add(new DataColumn { ColumnName = "STK", MaxLength = 100, DataType = Type.GetType("System.String") });
                    //dt.Columns.Add(new DataColumn { ColumnName = "SDT", MaxLength = 100, DataType = Type.GetType("System.String") });
                    //dt.Columns.Add(new DataColumn { ColumnName = "SONK", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    //dt.Columns.Add("NGAYNHAP_TT", typeof(DateTime));
                    //dt.Columns.Add("NGAYNHAP", typeof(DateTime));
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    row["NGAYNHAP"] = row["NGAYNHAP_TT"];
                    //    row.EndEdit();
                    //}
                    //dt.Columns.Add(new DataColumn { ColumnName = "TIENPHITNMT", AllowDBNull = false, DataType = Type.GetType("System.Decimal"), DefaultValue = 0 });
                    //dt.Columns.Add("M3TINHTIEN", typeof(int));
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    row["M3TINHTIEN"] = row["KLTIEUTHU"];
                    //    row.EndEdit();
                    //}
                    //// Bổ sung cột địa chỉ và tính lại cột địa chỉ theo các cột khác
                    //dt.Columns.Add("diachi");
                    //// Tính toán cột địa chỉ
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    row["diachi"] = row["sonha"] + " " + row["tenduongpho"];
                    //    row.EndEdit();
                    //}
                    //dt.Columns.Add("BARCODEINFO", typeof(String));
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;
                case "GetCustomerInfo":
                    dt.Columns["IDKH"].ColumnName = "idkh";
                    dt.Columns["TENKH"].ColumnName = "tenkh";
                    dt.Columns["SDT"].ColumnName = "sodt";
                    //dt.Columns["DIACHI"].ColumnName = "diachi";
                    dt.Columns["SODB"].ColumnName = "sodb";
                    //dt.Columns["CMND"].ColumnName = "cmnd";
                    dt.Columns["SONHA"].ColumnName = "sonha";
                    dt.Columns["MAKV"].ColumnName = "makv";
                    dt.Columns["MAPHUONG"].ColumnName = "maphuong";
                    dt.Columns["MADP"].ColumnName = "maduongpho";
                    dt.Columns["TENPHUONG"].ColumnName = "tenphuong";
                    dt.Columns["TENDP"].ColumnName = "tenduongpho";

                    // Bổ sung cột địa chỉ và tính lại cột địa chỉ theo các cột khác
                    dt.Columns.Add("diachi");
                    // Tính toán cột địa chỉ
                    foreach (DataRow row in dt.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["sonha"].ToString()))
                        {
                            row["diachi"] = row["sonha"] + ", " + row["tenduongpho"] + ", " + row["tenphuong"];
                        }
                        else
                        {
                            row["diachi"] = row["tenduongpho"] + ", " + row["tenphuong"];
                        }
                        row.EndEdit();
                    }
                    dt.AcceptChanges();
                    break;

                case "GetDanhSachChuaGCS":
                    dt.Columns["IDKH"].ColumnName = "idkh";
                    dt.Columns["SODB"].ColumnName = "sodb";
                    dt.Columns["TENKH"].ColumnName = "tenkh";
                    dt.Columns["DIDONG"].ColumnName = "didong";
                    //dt.Columns["SDT"].ColumnName = "didong";
                    dt.Columns["SONHA"].ColumnName = "sonha";
                    dt.Columns["MADP"].ColumnName = "maduongpho";
                    dt.Columns["TENDP"].ColumnName = "tenduongpho";
                    dt.Columns["MAKV"].ColumnName = "makv";
                    dt.Columns["TENKV"].ColumnName = "tenkv";
                    dt.Columns["MAQUAN"].ColumnName = "maquan";
                    dt.Columns["MAPHUONG"].ColumnName = "maphuong";

                    // Bổ sung cột địa chỉ và tính lại cột địa chỉ theo các cột khác
                    dt.Columns.Add("diachi");
                    // Tính toán cột địa chỉ
                    foreach (DataRow row in dt.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["sonha"].ToString()))
                        {
                            row["diachi"] = row["sonha"] + ", " + row["tenduongpho"] + ", " + row["tenkv"];
                        }
                        else
                        {
                            row["diachi"] = row["tenduongpho"] + ", " + row["tenkv"];
                        }
                        row.EndEdit();
                    }
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;

    //            //GetDanhSachHoaDonTheoDuongPho
    //            //GetDanhSachKhachHangKyHoaDon
    //            //GetDanhSachKhachHang
    //            //GetDanhSachKhachHangSMS 
                case "GetDanhSachKhuVuc":
                    //dt.Columns["MAKV"].ColumnName = "MAKV";
                    //dt.Columns["TENKV"].ColumnName = "TENKV";
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;
                case "GetDanhSachQuanHuyen":
                    //dt.Columns["MAQUAN"].ColumnName = "MAQUAN";
                    //dt.Columns["TENQUAN"].ColumnName = "TENQUAN";
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;
                case "GetDanhSachPhuongXa":
                    //dt.Columns["MAPHUONG"].ColumnName = "MAPHUONG";
                    //dt.Columns["TENPHUONG"].ColumnName = "TENPHUONG";
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;
                case "GetDanhSachLoTrinh":
                    dt.Columns["MADP"].ColumnName = "maduongpho";
                    dt.Columns["TENDP"].ColumnName = "tenduongpho";
                    dt.Columns["MAKV"].ColumnName = "makhuvuc";
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;

                case "GetDanhSachLoTrinhTheoKhuVuc":
                    dt.Columns["MADP"].ColumnName = "maduongpho";
                    dt.Columns["TENDP"].ColumnName = "tenduongpho";
                    dt.Columns["MAKV"].ColumnName = "makhuvuc";
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;
    //            //GetDanhSachLoTrinhTheoKhuVuc

                case "GetDanhSachTrangThai":
                    dt.Columns["MATT"].ColumnName = "matrangthai";
                    dt.Columns["TENTT"].ColumnName = "tentrangthai";
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;
                case "GetLichGhiChiSo":
                    dt.Columns["IDKH"].ColumnName = "idkh";
                    dt.Columns["SODB"].ColumnName = "sodb";
                    dt.Columns["TENKH"].ColumnName = "tenkh";
                    dt.Columns["THANG"].ColumnName = "thang";
                    dt.Columns["NAM"].ColumnName = "nam";
                    dt.Columns["NGAYNHAP"].ColumnName = "ngaynhap";
                    dt.Columns["NGAYNHAP_TT"].ColumnName = "ngaynhap_tt";
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;
                case "GetLichSuCapNuocByIDKH":
                    dt.Columns["IDKH"].ColumnName = "idkh";
                    dt.Columns["SODB"].ColumnName = "sodb";
                    dt.Columns["TENKH"].ColumnName = "tenkh";
                    dt.Columns["THANG"].ColumnName = "thang";
                    dt.Columns["NAM"].ColumnName = "nam";
                    dt.Columns["TTSD"].ColumnName = "ttsd";
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;
                case "GetLichSuDungNuocByIDKH":
                    dt.Columns["IDKH"].ColumnName = "idkh";
                    dt.Columns["SODB"].ColumnName = "sodb";
                    dt.Columns["TENKH"].ColumnName = "tenkh";
                    dt.Columns["THANG"].ColumnName = "thang";
                    dt.Columns["NAM"].ColumnName = "nam";
                    dt.Columns["M3TINHTIEN"].ColumnName = "kltieuthu";
                    dt.Columns["TONGTIEN"].ColumnName = "tongtien";
                    dt.Columns["HETNO"].ColumnName = "hetno";
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;
                case "GetListTienDolapDatNuoc":
                    dt.Columns["MADDK"].ColumnName = "maddk";
                    dt.Columns["TENKH"].ColumnName = "tenkh";
                    dt.Columns["SONHA"].ColumnName = "sonha";
                    dt.Columns["DIACHILD"].ColumnName = "diachi";
                    dt.Columns["LOAIDK"].ColumnName = "loaidk";
                    dt.Columns["duyet_pcks"].ColumnName = "duyet_pcks";
                    dt.Columns["khaosat"].ColumnName = "khaosat";
                    dt.Columns["dutoan"].ColumnName = "dutoan";
                    dt.Columns["duyetdutoan"].ColumnName = "duyetdutoan";
                    dt.Columns["hopdong"].ColumnName = "hopdong";
                    dt.Columns["chuyenvattu"].ColumnName = "chuyenvattu";
                    dt.Columns["nhap_pctc"].ColumnName = "nhap_pctc";
                    dt.Columns["thicong"].ColumnName = "thicong";
                    dt.Columns["quyettoan"].ColumnName = "quyettoan";
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;
                //StatusCongNoByIdkh???
                case "StatusCongNo":
                    dt.Columns["ID_KHACH_HANG"].ColumnName = "idkh";
                    dt.Columns["DANH_BO"].ColumnName = "sodb";
                    dt.Columns["TEN_KHACH_HANG"].ColumnName = "tenkh";
                    //dt.Columns[""].ColumnName = "cmnd";
                    dt.Columns["DIEN_THOAI"].ColumnName = "sodt";
                    dt.Columns["SO_NHA"].ColumnName = "sonha";
                    //dt.Columns[""].ColumnName = "diachi";
                    dt.Columns["TEN_DUONG_PHO"].ColumnName = "tenduongpho";
                    dt.Columns["TEN_KY"].ColumnName = "thang";
                    dt.Columns["NAM"].ColumnName = "nam";
                    dt.Columns["TONG_TIEN"].ColumnName = "tongtien";
                    dt.Columns["HET_NO"].ColumnName = "hetNo";
                    //dt.Columns[""].ColumnName = "ManvThu";
                    //dt.Columns[""].ColumnName = "Bank_id";                    
                    //dt.Columns[""].ColumnName = "Kenh_Giao_dich";                    
                    //dt.Columns[""].ColumnName = "Trans_ID";                    
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;
                default:
                    break;

                case "getHoaDonInfo":
                    //dt.Columns["IDKH"].ColumnName = "IDKH";
                    //dt.Columns["NAM"].ColumnName = "NAM";
                    //dt.Columns["KY"].ColumnName = "KY";
                    ////dt.Columns["LAN"].ColumnName = "LAN";
                    //dt.Columns["MADP"].ColumnName = "MADP";
                    //dt.Columns["NGAYNHAP_TT"].ColumnName = "NGAYNHAP_TT";
                    //dt.Columns["NGAYNHAP"].ColumnName = "NGAYNHAP";
                    //dt.Columns["TENKH"].ColumnName = "TENKH";
                    //dt.Columns["DIACHI"].ColumnName = "DIACHI";
                    //dt.Columns["MST"].ColumnName = "MST";
                    //dt.Columns["STK"].ColumnName = "STK";
                    //dt.Columns["SDT"].ColumnName = "SDT";
                    //dt.Columns["SOHO"].ColumnName = "SOHO";
                    //dt.Columns["SONK"].ColumnName = "SONK";
                    //dt.Columns["SODB"].ColumnName = "SODB";
                    //dt.Columns["STT"].ColumnName = "STT";
                    //dt.Columns["CHISODAU"].ColumnName = "CHISODAU";
                    //dt.Columns["CHISOCUOI"].ColumnName = "CHISOCUOI";
                    //dt.Columns["KLTIEUTHU"].ColumnName = "KLTIEUTHU";
                    //dt.Columns["TTHAI"].ColumnName = "TTHAI";

                    //dt.Columns["TIENNUOC"].ColumnName = "TIENNUOC";
                    //dt.Columns["TIENTHUE"].ColumnName = "TIENTHUE";
                    //dt.Columns["TIENPHIMT"].ColumnName = "TIENPHIMT";
                    //dt.Columns["TIENPHITN"].ColumnName = "TIENPHITN";                    
                    //dt.Columns["TIENPHITNMT"].ColumnName = "TIENPHITNMT";
                    //dt.Columns["M3TINHTIEN"].ColumnName = "M3TINHTIEN";
                    ////dt.Columns["PTVAT"].ColumnName = "PTVAT";
                    //dt.Columns["TONGTIEN"].ColumnName = "TONGTIEN";
                    //dt.Columns["TONGTIENTEXT"].ColumnName = "TONGTIENTEXT";

                    //dt.Columns["M3MUC1"].ColumnName = "M3MUC1";
                    //dt.Columns["M3MUC2"].ColumnName = "M3MUC2";
                    //dt.Columns["M3MUC3"].ColumnName = "M3MUC3";
                    //dt.Columns["M3MUC4"].ColumnName = "M3MUC4";

                    //dt.Columns["GIAMUC1"].ColumnName = "GIAMUC1";
                    //dt.Columns["GIAMUC2"].ColumnName = "GIAMUC2";
                    //dt.Columns["GIAMUC3"].ColumnName = "GIAMUC3";
                    //dt.Columns["GIAMUC4"].ColumnName = "GIAMUC4";

                    //dt.Columns["M3MUC1_CU"].ColumnName = "M3MUC1_CU";
                    //dt.Columns["M3MUC2_CU"].ColumnName = "M3MUC2_CU";
                    //dt.Columns["M3MUC3_CU"].ColumnName = "M3MUC3_CU";
                    //dt.Columns["M3MUC4_CU"].ColumnName = "M3MUC4_CU";

                    //dt.Columns["GIAMUC1_CU"].ColumnName = "GIAMUC1_CU";
                    //dt.Columns["GIAMUC2_CU"].ColumnName = "GIAMUC2_CU";
                    //dt.Columns["GIAMUC3_CU"].ColumnName = "GIAMUC3_CU";
                    //dt.Columns["GIAMUC4_CU"].ColumnName = "GIAMUC4_CU";

                    //dt.Columns["TIENMUC1"].ColumnName = "TIENMUC1";
                    //dt.Columns["TIENMUC2"].ColumnName = "TIENMUC2";
                    //dt.Columns["TIENMUC3"].ColumnName = "TIENMUC3";
                    //dt.Columns["TIENMUC4"].ColumnName = "TIENMUC4";

                    //dt.Columns["TIENMUC1_CU"].ColumnName = "TIENMUC1_CU";
                    //dt.Columns["TIENMUC2_CU"].ColumnName = "TIENMUC2_CU";
                    //dt.Columns["TIENMUC3_CU"].ColumnName = "TIENMUC3_CU";
                    //dt.Columns["TIENMUC4_CU"].ColumnName = "TIENMUC4_CU";

                    //dt.Columns["BARCODEINFO"].ColumnName = "BARCODEINFO";

                    dt.Columns.Add(new DataColumn { ColumnName = "HETNO", AllowDBNull = false, DataType = Type.GetType("System.Boolean"), DefaultValue = false });
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;

                case "GetDsEmail":
                    //dt.Columns["IDKH"].ColumnName = "IDKH";
                    dt.Columns.Add(new DataColumn { ColumnName = "HETNO", AllowDBNull = false, DataType = Type.GetType("System.Boolean"), DefaultValue = false });
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;

                case "GetDsHDGiay":
                    //dt.Columns["IDKH"].ColumnName = "IDKH";
                    dt.Columns.Add(new DataColumn { ColumnName = "HETNO", AllowDBNull = false, DataType = Type.GetType("System.Boolean"), DefaultValue = false });
                    dt.Columns.Add(new DataColumn { ColumnName = "HDGIAY", AllowDBNull = true, DataType = Type.GetType("System.Boolean"), DefaultValue = false });
                    dt.Columns.Add(new DataColumn { ColumnName = "NGAYHDGIAY", AllowDBNull = true, DataType = Type.GetType("System.DateTime"), DefaultValue = null });
                    dt.Columns.Add(new DataColumn { ColumnName = "NGUOIHDGIAY", AllowDBNull = true, DataType = Type.GetType("System.String"), DefaultValue = null });
                    dt.Columns.Add("islogin", typeof(bool));
                    dt.Columns.Add("Description", typeof(String));
                    dt.Columns.Add(new DataColumn { ColumnName = "error_code", AllowDBNull = false, DataType = Type.GetType("System.Int32"), DefaultValue = 0 });
                    dt.AcceptChanges();
                    break;

            }

        }
    }
}
