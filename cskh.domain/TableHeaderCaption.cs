using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cskh.domain
{
    public static class TableHeaderCaption
    {
        const string IDKH = "Mã khách hàng";
        const string SOHOADON = "Số hóa đơn";
        const string KLTIEUTHU = "Khối lượng tiêu thụ";
        const string TIENNUOC = "Tiền nước";
        const string TIENTHUE = "Tiền thuế";
        const string TIENPHITNMT = "Tiền phí môi trường";
        const string TONGTIEN = "Tổng tiền";
        const string NGAYKY = "Ngày ký";
        const string HETNO = "Hết nợ";

        public static string getCaption(string key)
        {
            switch (key)
            {
                case "IDKH":
                    {
                        return IDKH;
                    }
                case "SOHOADON":
                    {
                        return SOHOADON;
                    }
                case "KLTIEUTHU":
                    {
                        return KLTIEUTHU;
                    }
                case "TIENNUOC":
                    {
                        return TIENNUOC;
                    }
                case "TIENTHUE":
                    {
                        return TIENTHUE;
                    }
                case "TIENPHITNMT":
                    {
                        return TIENPHITNMT;
                    }
                case "TONGTIEN":
                    {
                        return TONGTIEN;
                    }
                case "NGAYKY":
                    {
                        return NGAYKY;
                    }
                case "HETNO":
                    {
                        return HETNO;
                    }
            }
            return "";
        }
    }
}
