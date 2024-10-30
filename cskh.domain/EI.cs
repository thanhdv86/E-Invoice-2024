using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace cskh.domain
{
    public class EI
    {
        #region properties
        public string IDKH { get; set; }
        public int NAM { get; set; }
        public int KY { get; set; }        
        public string MADP { get; set; }
        public DateTime? NGAYNHAP_TT { get; set; }
        public DateTime? NGAYNHAP { get; set; }
        public string TENKH { get; set; }
        public string DIACHI { get; set; }
        public string MST { get; set; }
        public string STK { get; set; }
        public string SDT { get; set; }
        public string EMAIL { get; set; }
        public int SOHO { get; set; }
        public int SONK { get; set; }
        public string SODB { get; set; }
        public int STT { get; set; }
        public int CHISODAU { get; set; }
        public int CHISOCUOI { get; set; }
        public int KLTIEUTHU { get; set; }
        public string TTHAI { get; set; }
        public string TTHAIGHI { get; set; }
        public decimal TIENNUOC { get; set; }
        public decimal TIENTHUE { get; set; }
        public decimal TIENPHIMT { get; set; }
        public decimal TIENPHITN { get; set; }
        public decimal TIENPHITNMT { get; set; }
        public int M3TINHTIEN { get; set; }
        public decimal TONGTIEN { get; set; }
        public decimal M3MUC1 { get; set; }
        public decimal M3MUC2 { get; set; }
        public decimal M3MUC3 { get; set; }
        public decimal M3MUC4 { get; set; }
        public decimal M3MUC5 { get; set; }
        public decimal M3MUC6 { get; set; }
        public decimal M3MUC7 { get; set; }
        public decimal M3MUC8 { get; set; }
        public decimal M3MUC1_CU { get; set; }
        public decimal M3MUC2_CU { get; set; }
        public decimal M3MUC3_CU { get; set; }
        public decimal M3MUC4_CU { get; set; }
        public decimal M3MUC5_CU { get; set; }
        public decimal M3MUC6_CU { get; set; }
        public decimal M3MUC7_CU { get; set; }
        public decimal M3MUC8_CU { get; set; }
        public decimal GIAMUC1 { get; set; }
        public decimal GIAMUC2 { get; set; }
        public decimal GIAMUC3 { get; set; }
        public decimal GIAMUC4 { get; set; }
        public decimal GIAMUC5 { get; set; }
        public decimal GIAMUC6 { get; set; }
        public decimal GIAMUC7 { get; set; }
        public decimal GIAMUC8 { get; set; }

        public decimal GIAMUC1_CU { get; set; }
        public decimal GIAMUC2_CU { get; set; }
        public decimal GIAMUC3_CU { get; set; }
        public decimal GIAMUC4_CU { get; set; }
        public decimal GIAMUC5_CU { get; set; }
        public decimal GIAMUC6_CU { get; set; }
        public decimal GIAMUC7_CU { get; set; }
        public decimal GIAMUC8_CU { get; set; }
        public decimal TIENMUC1 { get; set; }
        public decimal TIENMUC2 { get; set; }
        public decimal TIENMUC3 { get; set; }
        public decimal TIENMUC4 { get; set; }
        public decimal TIENMUC5 { get; set; }
        public decimal TIENMUC6 { get; set; }
        public decimal TIENMUC7 { get; set; }
        public decimal TIENMUC8 { get; set; }
        public decimal TIENMUC1_CU { get; set; }
        public decimal TIENMUC2_CU { get; set; }
        public decimal TIENMUC3_CU { get; set; }
        public decimal TIENMUC4_CU { get; set; }
        public decimal TIENMUC5_CU { get; set; }
        public decimal TIENMUC6_CU { get; set; }
        public decimal TIENMUC7_CU { get; set; }
        public decimal TIENMUC8_CU { get; set; }
        public string TONGTIENTEXT { get; private set; }
        public string MALKHDB { get; set; }
        public int TLSH { get; set; }
        public string BARCODEINFO { get; set; }
        public string MAUHOADON { get; set; }        
        public string KIHIEUHOADON { get; set; }
        public string SOHOADON { get; set; }
        public byte[] HOADON_XML { get; set; }
        public DateTime NGAYKY { get; set; }
        public string NGUOIKY { get; set; }        
        public int LANKY { get; set; }
        public string GHICHU { get; set; }
        public string transactionUuid { get; set; }
        public int CSTR_SC { get; set; }
        public int CSSAU_SC { get; set; }

        #endregion properties

        public EI()
        {
        }
        public EI(string idkh, int thang, int nam)
        {
            IDKH = idkh;
            NAM = nam;
            KY = thang;
            using (var ebi = new EiBusinessImpl())
            {
                var dr = ebi.GetHoaDonDetail(idkh, thang, nam);
                if (dr.Read())
                {
                    MADP = dr[Constants.MADP].ToString();
                    NGAYNHAP_TT = Convert.ToDateTime(dr[Constants.NGAYNHAP_TT]);
                    NGAYNHAP = Convert.ToDateTime(dr[Constants.NGAYNHAP]);
                    TENKH = dr[Constants.TENKH].ToString();
                    DIACHI = dr[Constants.DIACHI].ToString(); ;
                    MST = dr[Constants.MST].ToString();
                    STK = dr[Constants.STK].ToString();
                    SDT = dr[Constants.SDT].ToString();
                    EMAIL = dr[Constants.EMAIL].ToString();
                    SOHO = (dr[Constants.SOHO] == System.DBNull.Value) ? 0 : Convert.ToInt16(dr[Constants.SOHO]);
                    SONK = (dr[Constants.SONK] == System.DBNull.Value) ? 0 : Convert.ToInt16(dr[Constants.SONK]);
                    SODB = dr[Constants.SODB].ToString();
                    STT = Convert.ToInt32(dr[Constants.STT]);                    
                    CHISODAU = Convert.ToInt32(dr[Constants.CHISODAU]);
                    CHISOCUOI = Convert.ToInt32(dr[Constants.CHISOCUOI]);
                    KLTIEUTHU = Convert.ToInt32(dr[Constants.KLTIEUTHU]);
                    TTHAI = dr[Constants.TTHAI].ToString();
                    TIENNUOC = Convert.ToDecimal(dr[Constants.TIENNUOC]);
                    TIENTHUE = Convert.ToDecimal(dr[Constants.TIENTHUE]);
                    TIENPHIMT = Convert.ToDecimal(dr[Constants.TIENPHIMT]);
                    TIENPHITN = Convert.ToDecimal(dr[Constants.TIENPHITN]);
                    TIENPHITNMT = Convert.ToDecimal(dr[Constants.TIENPHITNMT]);
                    M3TINHTIEN = Convert.ToInt32(dr[Constants.M3TINHTIEN]);
                    TONGTIEN = Convert.ToDecimal(dr[Constants.TONGTIEN]);

                    M3MUC1 = (dr[Constants.M3MUC1] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC1]);
                    M3MUC2 = (dr[Constants.M3MUC2] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC2]);
                    M3MUC3 = (dr[Constants.M3MUC3] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC3]);
                    M3MUC4 = (dr[Constants.M3MUC4] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC4]);
                    M3MUC5 = (dr[Constants.M3MUC5] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC5]);
                    M3MUC6 = (dr[Constants.M3MUC6] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC6]);
                    M3MUC7 = (dr[Constants.M3MUC7] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC7]);
                    M3MUC8 = (dr[Constants.M3MUC8] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC8]);

                    M3MUC1_CU = (dr[Constants.M3MUC1_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC1_CU]);
                    M3MUC2_CU = (dr[Constants.M3MUC2_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC2_CU]);
                    M3MUC3_CU = (dr[Constants.M3MUC3_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC3_CU]);
                    M3MUC4_CU = (dr[Constants.M3MUC4_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC4_CU]);
                    M3MUC5_CU = (dr[Constants.M3MUC5_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC5_CU]);
                    M3MUC6_CU = (dr[Constants.M3MUC6_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC6_CU]);
                    M3MUC7_CU = (dr[Constants.M3MUC7_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC7_CU]);
                    M3MUC8_CU = (dr[Constants.M3MUC8_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC8_CU]);

                    GIAMUC1 = (dr[Constants.GIAMUC1] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC1]);
                    GIAMUC2 = (dr[Constants.GIAMUC2] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC2]);
                    GIAMUC3 = (dr[Constants.GIAMUC3] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC3]);
                    GIAMUC4 = (dr[Constants.GIAMUC4] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC4]);
                    GIAMUC5 = (dr[Constants.GIAMUC5] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC5]);
                    GIAMUC6 = (dr[Constants.GIAMUC6] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC6]);
                    GIAMUC7 = (dr[Constants.GIAMUC7] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC7]);
                    GIAMUC8 = (dr[Constants.GIAMUC8] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC8]);

                    GIAMUC1_CU = (dr[Constants.GIAMUC1_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC1_CU]);
                    GIAMUC2_CU = (dr[Constants.GIAMUC2_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC2_CU]);
                    GIAMUC3_CU = (dr[Constants.GIAMUC3_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC3_CU]);
                    GIAMUC4_CU = (dr[Constants.GIAMUC4_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC4_CU]);
                    GIAMUC5_CU = (dr[Constants.GIAMUC5_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC5_CU]);
                    GIAMUC6_CU = (dr[Constants.GIAMUC6_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC6_CU]);
                    GIAMUC7_CU = (dr[Constants.GIAMUC7_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC7_CU]);
                    GIAMUC8_CU = (dr[Constants.GIAMUC8_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC8_CU]);

                    TIENMUC1 = (dr[Constants.TIENMUC1] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC1]);
                    TIENMUC2 = (dr[Constants.TIENMUC2] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC2]);
                    TIENMUC3 = (dr[Constants.TIENMUC3] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC3]);
                    TIENMUC4 = (dr[Constants.TIENMUC4] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC4]);
                    TIENMUC5 = (dr[Constants.TIENMUC5] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC5]);
                    TIENMUC6 = (dr[Constants.TIENMUC6] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC6]);
                    TIENMUC7 = (dr[Constants.TIENMUC7] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC7]);
                    TIENMUC8 = (dr[Constants.TIENMUC8] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC8]);

                    TIENMUC1_CU = (dr[Constants.TIENMUC1_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC1_CU]);
                    TIENMUC2_CU = (dr[Constants.TIENMUC2_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC2_CU]);
                    TIENMUC3_CU = (dr[Constants.TIENMUC3_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC3_CU]);
                    TIENMUC4_CU = (dr[Constants.TIENMUC4_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC4_CU]);
                    TIENMUC5_CU = (dr[Constants.TIENMUC5_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC5_CU]);
                    TIENMUC6_CU = (dr[Constants.TIENMUC6_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC6_CU]);
                    TIENMUC7_CU = (dr[Constants.TIENMUC7_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC7_CU]);
                    TIENMUC8_CU = (dr[Constants.TIENMUC8_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC8_CU]);

                    MALKHDB = dr[Constants.MALKHDB].ToString();
                    TLSH = Convert.ToInt32(dr[Constants.TLSH]);
                    BARCODEINFO = dr[Constants.BARCODEINFO].ToString();                    
                    
                    MAUHOADON = dr[Constants.MAUHOADON].ToString();                    
                    KIHIEUHOADON = dr[Constants.KIHIEUHOADON].ToString();
                    SOHOADON = dr[Constants.SOHOADON].ToString();                    
                    HOADON_XML = dr[Constants.HOADON_XML] as byte[];

                    NGAYKY = (DateTime)dr[Constants.NGAYKY];
                    NGUOIKY = dr[Constants.NGUOIKY].ToString(); // Không sử dụng trong khi In Hóa đơn
                    LANKY = Convert.ToInt32(dr[Constants.LANKY]); // Không sử dụng trong khi In Hóa đơn
                    GHICHU = dr[Constants.GHICHU].ToString();

                    TONGTIENTEXT = dr[Constants.TONGTIENTEXT].ToString();                    
                                                         
                }
            }
        }

        public XmlDocument CreateHoaDonXml(X509Certificate2 cer)
        {
            var xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("HDDT");
            XmlNode hoadon = xmlDoc.CreateElement("HOADON");
            XmlAttribute hoadonAttr;

            xmlDoc.AppendChild(rootNode);
            rootNode.AppendChild(hoadon);

            // Get property array
            var properties = SignUtil.GetProperties(this);

            foreach (var p in properties)
            {
                var name = p.Name;
                if (name != Constants.HOADON_XML)
                {
                    var value = p.GetValue(this, null);
                    // create xml attributes
                    hoadonAttr = xmlDoc.CreateAttribute(name);

                    if (value == null) hoadonAttr.Value = "";
                    else
                    {
                        // for date time, display with format dd/MM/yyyy
                        if (p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?))
                        {
                            value = ((DateTime)value).ToString("dd/MM/yyyy");
                        }

                        // display "" instead of 0
                        hoadonAttr.Value = value.ToString() == "0" ? "" : value.ToString();
                    }
                    hoadon.Attributes.Append(hoadonAttr);
                }
            }

            // add signer and signing date            
            hoadonAttr = xmlDoc.CreateAttribute("NGUOIKY");
            hoadonAttr.Value = SignUtil.GetSignName(cer.Subject);
            hoadon.Attributes.Append(hoadonAttr);
            //hoadonAttr = xmlDoc.CreateAttribute("NGAYKY");
            //hoadonAttr.Value = DateTime.Now.ToString("dd/MM/yyyy");
            //hoadon.Attributes.Append(hoadonAttr);
            return xmlDoc;

        }
        public bool IsSigned()
        {
            if (HOADON_XML != null) return true;
            return false;
        }

        public void PopulateData(DataRow dr)
        {
            IDKH = dr[Constants.IDKH].ToString();
            NAM = (dr[Constants.NAM] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.NAM]);
            KY = (dr[Constants.KY] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.KY]);
            MADP = dr[Constants.MADP].ToString();
            NGAYNHAP_TT = dr[Constants.NGAYNHAP_TT] == System.DBNull.Value ? (DateTime?) null : Convert.ToDateTime(dr[Constants.NGAYNHAP_TT]);
            NGAYNHAP = dr[Constants.NGAYNHAP] == System.DBNull.Value ? (DateTime?) null : Convert.ToDateTime(dr[Constants.NGAYNHAP]);
            TENKH = dr[Constants.TENKH].ToString();
            DIACHI = dr[Constants.DIACHI].ToString(); 
            MST = dr[Constants.MST].ToString();
            STK = dr[Constants.STK].ToString();
            SDT = dr[Constants.SDT].ToString();
            EMAIL = dr[Constants.EMAIL].ToString();
            SONK = (dr[Constants.SONK] == System.DBNull.Value) ? 0 : Convert.ToInt16(dr[Constants.SONK]);
            SOHO = (dr[Constants.SOHO] == System.DBNull.Value) ? 0 : Convert.ToInt16(dr[Constants.SOHO]);
            SODB = dr[Constants.SODB].ToString();
            STT = (dr[Constants.STT] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.STT]);
            CHISODAU = (dr[Constants.CHISODAU] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.CHISODAU]);
            CHISOCUOI = (dr[Constants.CHISOCUOI] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.CHISOCUOI]);
            KLTIEUTHU = (dr[Constants.KLTIEUTHU] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.KLTIEUTHU]);
            TTHAI = dr[Constants.TTHAI].ToString();

            TIENNUOC = (dr[Constants.TIENNUOC] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENNUOC]);
            TIENTHUE = (dr[Constants.TIENTHUE] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENTHUE]);
            TIENPHIMT = (dr[Constants.TIENPHIMT] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENPHIMT]);
            TIENPHITN = (dr[Constants.TIENPHITN] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENPHITN]);
            TIENPHITNMT = (dr[Constants.TIENPHITNMT] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENPHITNMT]);
            M3TINHTIEN = (dr[Constants.M3TINHTIEN] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.M3TINHTIEN]);
            TONGTIEN = (dr[Constants.TONGTIEN] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TONGTIEN]);

            M3MUC1 = (dr[Constants.M3MUC1] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC1]);
            M3MUC2 = (dr[Constants.M3MUC2] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC2]);
            M3MUC3 = (dr[Constants.M3MUC3] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC3]);
            M3MUC4 = (dr[Constants.M3MUC4] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC4]);
            M3MUC5 = (dr[Constants.M3MUC5] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC5]);
            M3MUC6 = (dr[Constants.M3MUC6] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC6]);
            M3MUC7 = (dr[Constants.M3MUC7] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC7]);
            M3MUC8 = (dr[Constants.M3MUC8] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC8]);

            M3MUC1_CU = (dr[Constants.M3MUC1_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC1_CU]);
            M3MUC2_CU = (dr[Constants.M3MUC2_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC2_CU]);
            M3MUC3_CU = (dr[Constants.M3MUC3_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC3_CU]);
            M3MUC4_CU = (dr[Constants.M3MUC4_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC4_CU]);
            M3MUC5_CU = (dr[Constants.M3MUC5_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC5_CU]);
            M3MUC6_CU = (dr[Constants.M3MUC6_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC6_CU]);
            M3MUC7_CU = (dr[Constants.M3MUC7_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC7_CU]);
            M3MUC8_CU = (dr[Constants.M3MUC8_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC8_CU]);

            GIAMUC1 = (dr[Constants.GIAMUC1] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC1]);
            GIAMUC2 = (dr[Constants.GIAMUC2] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC2]);
            GIAMUC3 = (dr[Constants.GIAMUC3] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC3]);
            GIAMUC4 = (dr[Constants.GIAMUC4] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC4]);
            GIAMUC5 = (dr[Constants.GIAMUC5] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC5]);
            GIAMUC6 = (dr[Constants.GIAMUC6] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC6]);
            GIAMUC7 = (dr[Constants.GIAMUC7] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC7]);
            GIAMUC8 = (dr[Constants.GIAMUC8] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC8]);

            GIAMUC1_CU = (dr[Constants.GIAMUC1_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC1_CU]);
            GIAMUC2_CU = (dr[Constants.GIAMUC2_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC2_CU]);
            GIAMUC3_CU = (dr[Constants.GIAMUC3_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC3_CU]);
            GIAMUC4_CU = (dr[Constants.GIAMUC4_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC4_CU]);
            GIAMUC5_CU = (dr[Constants.GIAMUC5_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC5_CU]);
            GIAMUC6_CU = (dr[Constants.GIAMUC6_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC6_CU]);
            GIAMUC7_CU = (dr[Constants.GIAMUC7_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC7_CU]);
            GIAMUC8_CU = (dr[Constants.GIAMUC8_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC8_CU]);

            TIENMUC1 = (dr[Constants.TIENMUC1] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC1]);
            TIENMUC2 = (dr[Constants.TIENMUC2] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC2]);
            TIENMUC3 = (dr[Constants.TIENMUC3] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC3]);
            TIENMUC4 = (dr[Constants.TIENMUC4] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC4]);
            TIENMUC5 = (dr[Constants.TIENMUC5] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC5]);
            TIENMUC6 = (dr[Constants.TIENMUC6] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC6]);
            TIENMUC7 = (dr[Constants.TIENMUC7] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC7]);
            TIENMUC8 = (dr[Constants.TIENMUC8] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC8]);

            TIENMUC1_CU = (dr[Constants.TIENMUC1_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC1_CU]);
            TIENMUC2_CU = (dr[Constants.TIENMUC2_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC2_CU]);
            TIENMUC3_CU = (dr[Constants.TIENMUC3_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC3_CU]);
            TIENMUC4_CU = (dr[Constants.TIENMUC4_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC4_CU]);
            TIENMUC5_CU = (dr[Constants.TIENMUC5_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC5_CU]);
            TIENMUC6_CU = (dr[Constants.TIENMUC6_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC6_CU]);
            TIENMUC7_CU = (dr[Constants.TIENMUC7_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC7_CU]);
            TIENMUC8_CU = (dr[Constants.TIENMUC8_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC8_CU]);

            TONGTIENTEXT = dr[Constants.TONGTIENTEXT].ToString();
            MALKHDB = dr[Constants.MALKHDB].ToString();
            TLSH = (dr[Constants.TLSH] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.TLSH]);
            BARCODEINFO = dr[Constants.BARCODEINFO].ToString();

            NGAYKY = Convert.ToDateTime(dr[Constants.NGAYKY]);
            GHICHU = dr[Constants.GHICHU].ToString();


            // LUY Y: THUOC TINH NAY CHI CO SAU KHI KY
            // NEN SE RAISE LOI KHI BIND LAN DAU
            //try
            //{
            //    HOADON_XML = dr[Constants.HOADON_XML] as byte[];
            //}
            //catch (Exception ex)
            //{
            //    // I know it and I dont handle it :)
            //}

        }
        public void PopulateDataInvoice(DataRow dr)
        {
            IDKH = dr[Constants.IDKH].ToString();
            NAM = (dr[Constants.NAM] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.NAM]);
            KY = (dr[Constants.KY] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.KY]);
            MADP = dr[Constants.MADP].ToString();
            NGAYNHAP_TT = dr[Constants.NGAYNHAP_TT] == System.DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr[Constants.NGAYNHAP_TT]);
            NGAYNHAP = dr[Constants.NGAYNHAP] == System.DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr[Constants.NGAYNHAP]);
            TENKH = dr[Constants.TENKH].ToString();
            DIACHI = dr[Constants.DIACHI].ToString();
            MST = dr[Constants.MST].ToString();
            STK = dr[Constants.STK].ToString();
            SDT = dr[Constants.SDT].ToString();
            EMAIL = dr[Constants.EMAIL].ToString();
            SONK = (dr[Constants.SONK] == System.DBNull.Value) ? 0 : Convert.ToInt16(dr[Constants.SONK]);
            SOHO = (dr[Constants.SOHO] == System.DBNull.Value) ? 0 : Convert.ToInt16(dr[Constants.SOHO]);
            SODB = dr[Constants.SODB].ToString();
            STT = (dr[Constants.STT] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.STT]);
            CHISODAU = (dr[Constants.CHISODAU] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.CHISODAU]);
            CHISOCUOI = (dr[Constants.CHISOCUOI] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.CHISOCUOI]);
            KLTIEUTHU = (dr[Constants.KLTIEUTHU] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.KLTIEUTHU]);
            TTHAI = dr[Constants.TTHAI].ToString();

            TIENNUOC = (dr[Constants.TIENNUOC] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENNUOC]);
            TIENTHUE = (dr[Constants.TIENTHUE] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENTHUE]);
            TIENPHIMT = (dr[Constants.TIENPHIMT] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENPHIMT]);
            TIENPHITN = (dr[Constants.TIENPHITN] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENPHITN]);
            TIENPHITNMT = (dr[Constants.TIENPHITNMT] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENPHITNMT]);
            M3TINHTIEN = (dr[Constants.M3TINHTIEN] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.M3TINHTIEN]);
            TONGTIEN = (dr[Constants.TONGTIEN] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TONGTIEN]);

            M3MUC1 = (dr[Constants.M3MUC1] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC1]);
            M3MUC2 = (dr[Constants.M3MUC2] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC2]);
            M3MUC3 = (dr[Constants.M3MUC3] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC3]);
            M3MUC4 = (dr[Constants.M3MUC4] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC4]);
            M3MUC5 = (dr[Constants.M3MUC5] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC5]);
            M3MUC6 = (dr[Constants.M3MUC6] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC6]);
            M3MUC7 = (dr[Constants.M3MUC7] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC7]);
            M3MUC8 = (dr[Constants.M3MUC8] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC8]);

            M3MUC1_CU = (dr[Constants.M3MUC1_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC1_CU]);
            M3MUC2_CU = (dr[Constants.M3MUC2_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC2_CU]);
            M3MUC3_CU = (dr[Constants.M3MUC3_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC3_CU]);
            M3MUC4_CU = (dr[Constants.M3MUC4_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC4_CU]);
            M3MUC5_CU = (dr[Constants.M3MUC5_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC5_CU]);
            M3MUC6_CU = (dr[Constants.M3MUC6_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC6_CU]);
            M3MUC7_CU = (dr[Constants.M3MUC7_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC7_CU]);
            M3MUC8_CU = (dr[Constants.M3MUC8_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.M3MUC8_CU]);

            GIAMUC1 = (dr[Constants.GIAMUC1] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC1]);
            GIAMUC2 = (dr[Constants.GIAMUC2] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC2]);
            GIAMUC3 = (dr[Constants.GIAMUC3] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC3]);
            GIAMUC4 = (dr[Constants.GIAMUC4] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC4]);
            GIAMUC5 = (dr[Constants.GIAMUC5] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC5]);
            GIAMUC6 = (dr[Constants.GIAMUC6] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC6]);
            GIAMUC7 = (dr[Constants.GIAMUC7] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC7]);
            GIAMUC8 = (dr[Constants.GIAMUC8] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC8]);

            GIAMUC1_CU = (dr[Constants.GIAMUC1_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC1_CU]);
            GIAMUC2_CU = (dr[Constants.GIAMUC2_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC2_CU]);
            GIAMUC3_CU = (dr[Constants.GIAMUC3_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC3_CU]);
            GIAMUC4_CU = (dr[Constants.GIAMUC4_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC4_CU]);
            GIAMUC5_CU = (dr[Constants.GIAMUC5_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC5_CU]);
            GIAMUC6_CU = (dr[Constants.GIAMUC6_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC6_CU]);
            GIAMUC7_CU = (dr[Constants.GIAMUC7_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC7_CU]);
            GIAMUC8_CU = (dr[Constants.GIAMUC8_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.GIAMUC8_CU]);

            TIENMUC1 = (dr[Constants.TIENMUC1] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC1]);
            TIENMUC2 = (dr[Constants.TIENMUC2] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC2]);
            TIENMUC3 = (dr[Constants.TIENMUC3] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC3]);
            TIENMUC4 = (dr[Constants.TIENMUC4] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC4]);
            TIENMUC5 = (dr[Constants.TIENMUC5] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC5]);
            TIENMUC6 = (dr[Constants.TIENMUC6] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC6]);
            TIENMUC7 = (dr[Constants.TIENMUC7] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC7]);
            TIENMUC8 = (dr[Constants.TIENMUC8] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC8]);

            TIENMUC1_CU = (dr[Constants.TIENMUC1_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC1_CU]);
            TIENMUC2_CU = (dr[Constants.TIENMUC2_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC2_CU]);
            TIENMUC3_CU = (dr[Constants.TIENMUC3_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC3_CU]);
            TIENMUC4_CU = (dr[Constants.TIENMUC4_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC4_CU]);
            TIENMUC5_CU = (dr[Constants.TIENMUC5_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC5_CU]);
            TIENMUC6_CU = (dr[Constants.TIENMUC6_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC6_CU]);
            TIENMUC7_CU = (dr[Constants.TIENMUC7_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC7_CU]);
            TIENMUC8_CU = (dr[Constants.TIENMUC8_CU] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dr[Constants.TIENMUC8_CU]);

            TONGTIENTEXT = dr[Constants.TONGTIENTEXT].ToString();
            MALKHDB = dr[Constants.MALKHDB].ToString();
            TLSH = (dr[Constants.TLSH] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.TLSH]);
            BARCODEINFO = dr[Constants.BARCODEINFO].ToString();

            NGAYKY = Convert.ToDateTime(dr[Constants.NGAYKY]);
            GHICHU = dr[Constants.GHICHU].ToString();
            transactionUuid = (dr[Constants.transactionUuid] == System.DBNull.Value) ? Guid.NewGuid().ToString() : Convert.ToString(dr[Constants.transactionUuid]);
            CSTR_SC = (dr[Constants.CSTR_SC] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.CSTR_SC]);
            CSSAU_SC = (dr[Constants.CSSAU_SC] == System.DBNull.Value) ? 0 : Convert.ToInt32(dr[Constants.CSSAU_SC]);
            TTHAIGHI = dr[Constants.TTHAIGHI].ToString();

                //dr[Constants.transactionUuid].ToString();

        }
    }
}
