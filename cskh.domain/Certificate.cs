using System;
using System.Security.Cryptography.X509Certificates;

namespace cskh.domain
{
    public class Certificate
    {
        public enum Status { Deleted, Active };
        public string SignName { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public byte[] CertificateFile { get; set; }
        public DateTime NgayThuHoi { get; set; }
        public string PublicKey { get; set; }
        public string NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
        public string SeryNumber { get; set; }
        public string NguoiSua { get; set; }
        public DateTime NgaySua { get; set; }
        public Certificate(string signName, DateTime validFrom, DateTime validTo, byte[] certificateFile, DateTime ngayThuHoi,
            string publicKey, string nguoiTao, DateTime ngayTao, int trangThai, string seryNumber)
        {
            SignName = signName;
            ValidFrom = validFrom;
            ValidTo = validTo;
            CertificateFile = certificateFile;
            NgayThuHoi = ngayThuHoi;
            PublicKey = publicKey;
            NguoiTao = nguoiTao;
            NgayTao = ngayTao;
            TrangThai = trangThai;
            SeryNumber = seryNumber;
        }
        public Certificate(X509Certificate2 x509)
        {
            if (x509 != null)
            {
                SignName = SignUtil.GetSignName(x509.Subject);
                ValidFrom = x509.NotBefore;
                ValidTo = x509.NotAfter;
                CertificateFile = x509.GetRawCertData();
                NgayThuHoi = x509.NotAfter;
                PublicKey = x509.PublicKey.Key.ToXmlString(false);
                SeryNumber = x509.SerialNumber;
            }
        }
    }
}
