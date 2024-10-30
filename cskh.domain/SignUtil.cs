using System;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Windows.Forms;

namespace cskh.domain
{
    public class SignUtil
    {

        public static string Left(string str, int length)
        {
            str = (str ?? string.Empty);
            return str.Substring(0, Math.Min(length, str.Length));
        }

        public static string Right(string str, int length)
        {
            str = (str ?? string.Empty);
            return (str.Length >= length)
                ? str.Substring(str.Length - length, length)
                : str;
        }

        public static void BoundComboBox(ComboBox cb, DataTable dt, string strDisplayMember, string strValueMember)
        {
            cb.DataSource = dt;
            cb.DisplayMember = strDisplayMember;
            cb.ValueMember = strValueMember;
            cb.SelectedIndex = 0;
        }

        public static void BoundComboBox(ComboBox cb, DataTable dt, string strDisplayMember, string strValueMember, string strDisplayMember0, string strValueMember0)
        {
            var row = dt.NewRow();
            row[strDisplayMember] = strDisplayMember0;
            row[strValueMember] = strValueMember0;
            dt.Rows.InsertAt(row, 0);

            cb.DataSource = dt;
            cb.DisplayMember = strDisplayMember;
            cb.ValueMember = strValueMember;
            cb.SelectedIndex = 0;
        }

        public static void BoundComboBox(ComboBox cb, DataTable dt, string strDisplayMember, string strValueMember, string strDisplayMember0, Int32 strValueMember0)
        {
            var row = dt.NewRow();
            row[strDisplayMember] = strDisplayMember0;
            row[strValueMember] = strValueMember0;
            dt.Rows.InsertAt(row, 0);

            cb.DataSource = dt;
            cb.DisplayMember = strDisplayMember;
            cb.ValueMember = strValueMember;
            cb.SelectedIndex = 0;
        }

        public static void BindKv(ComboBox cb, string strDisplayMember0, Int32 strValueMember0)
        {
            try
            {
                using (var cr = new CrBusinessImpl())
                {
                    var dt = cr.GetDanhSachKhuVuc();
                    if (dt == null || dt.Rows.Count <= 0) return;
                    BoundComboBox(cb, dt, "TENKV", "MAKV", strDisplayMember0, strValueMember0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy xuất dữ liệu:" + ex.Message, "Lỗi [" + ex.InnerException + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public static void BindKv(ComboBox cb, string strDisplayMember0, string strValueMember0)
        //SignUtil.BindKv(cbKV, "--Chọn chi nhánh--", "");
        {
            try
            {
                using (var cbi = new CrBusinessImpl())
                {
                    var dt = cbi.GetDanhSachKhuVuc();
                    if (dt == null || dt.Rows.Count <= 0) return;
                    BoundComboBox(cb, dt, "TENKV", "MAKV", strDisplayMember0, strValueMember0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy xuất dữ liệu:" + ex.Message, "Lỗi [" + ex.InnerException + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public static void BindQt(ComboBox cb, string strDisplayMember0, string strValueMember0)
        {
            try
            {
                using (var cbi = new CrBusinessImpl())
                {
                    var dt = cbi.GetDanhSachQuayThu();
                    if (dt == null || dt.Rows.Count <= 0) return;
                    BoundComboBox(cb, dt, "TENQUAYTHU", "MAQUAYTHU", strDisplayMember0, strValueMember0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy xuất dữ liệu:" + ex.Message, "Lỗi [" + ex.InnerException + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public static void BindKvX(ComboBox cb, MaskedTextBox tbMonth, MaskedTextBox tbYear, string strDisplayMember0, string strValueMember0)
            //SignUtil.BindKv(cbKV, "--Chọn chi nhánh--", "");
        {
            try
            {
                using (var cbi = new CrBusinessImpl())
                {
                    var dt = cbi.GetDanhSachKhuVucX(int.Parse(tbMonth.Text), int.Parse(tbYear.Text));
                    if (dt == null || dt.Rows.Count <= 0) return;
                    BoundComboBox(cb, dt, "TENKV", "MAKV", strDisplayMember0, strValueMember0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy xuất dữ liệu:" + ex.Message, "Lỗi [" + ex.InnerException + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public static void BindKy(MaskedTextBox tbMonth, MaskedTextBox tbYear)
        {
            try
            {
                using (var cbi = new CrBusinessImpl())
                {
                    var dt = cbi.GetKyHd();
                    if ((dt == null) || (dt.Rows.Count <= 0)) return;
                    tbMonth.Text = dt.Rows[0]["THANG"].ToString();
                    tbYear.Text = dt.Rows[0]["NAM"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy xuất dữ liệu:" + ex.Message, "Lỗi [" + ex.InnerException + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }
        public static void BindKy(ComboBox cbKy, MaskedTextBox tbNam)
        {try
            {
                using (var cbi = new CrBusinessImpl())
                {
                    var dt = cbi.GetKyHd();
                    if ((dt == null) || (dt.Rows.Count <= 0)) return;
                    cbKy.SelectedIndex = Convert.ToInt16(dt.Rows[0]["THANG"].ToString()) - 1;  //thang 12 say ra loi cbKy.SelectedIndex=-1
                    //cbKy.SelectedText = dt.Rows[0]["THANG"].ToString();
                    tbNam.Text = dt.Rows[0]["NAM"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy xuất dữ liệu:" + ex.Message, "Lỗi [" + ex.InnerException + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        // Sign an XML file and save the signature in a new file. 
        public static XmlDocument SignXmlFile(XmlDocument doc, RSA Key)
        {
            // Create a SignedXml object.
            var signedXml = new SignedXml(doc) { SigningKey = Key };

            // Create a reference to be signed.
            var reference = new Reference { Uri = "" };

            // Add an enveloped transformation to the reference.
            var env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
            var keyInfo = new KeyInfo();
            //KeyInfoX509Data keyInfoData = new KeyInfoX509Data(Certificate);
            keyInfo.AddClause(new RSAKeyValue((RSA)Key));
            signedXml.KeyInfo = keyInfo;

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save 
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));


            if (doc.FirstChild is XmlDeclaration)
            {
                //doc.RemoveChild(doc.FirstChild);
            }

            return doc;
        }

        // Verify the signature of an XML file and return the result. 
        public static Boolean VerifyXmlFile(String Name)
        {
            // Create a new XML document.
            var xmlDocument = new XmlDocument { PreserveWhitespace = true };

            // Load the passed XML file into the document. 
            xmlDocument.Load(Name);

            // Create a new SignedXml object and pass it 
            // the XML document class.
            var signedXml = new SignedXml(xmlDocument);

            // Find the "Signature" node and create a new 
            // XmlNodeList object.
            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");
            // Throw an exception if no signature was found. 
            if (nodeList.Count <= 0)
            {
                throw new CryptographicException("Xac thuc that bai: Khong tim thay chu ky nao trong tai lieu xml");
            }

            // This example only supports one signature for 
            // the entire XML document.  Throw an exception  
            // if more than one signature was found. 
            if (nodeList.Count >= 2)
            {
                throw new CryptographicException("Xac thuc that bai: Co nhieu hon 1 chu ky trong tai lieu xml");
            }

            // Load the signature node.
            signedXml.LoadXml((XmlElement)nodeList[0]);
            /*
            var x509data = signedXml.Signature.KeyInfo.OfType<KeyInfoX509Data>().First();
            var verified = false;
            if (x509data != null)
            {
                var cert = x509data.Certificates[0] as X509Certificate2;
                Console.WriteLine(cert.Issuer);
                verified = cert != null && signedXml.CheckSignature(cert, false);
            }
            */
            // Check the signature and return the result. 
            return signedXml.CheckSignature();
        }


        public static Boolean VerifyXmlFile(XmlDocument xmlDocument)
        {
            // Format using white spaces.
            xmlDocument.PreserveWhitespace = true;

            // Create a new SignedXml object and pass it 
            // the XML document class.
            var signedXml = new SignedXml(xmlDocument);

            // Find the "Signature" node and create a new 
            // XmlNodeList object.
            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");
            // Throw an exception if no signature was found. 
            if (nodeList.Count <= 0)
            {
                throw new CryptographicException("Xac thuc that bai: Khong tim thay chu ky nao trong tai lieu xml");
            }

            // This example only supports one signature for 
            // the entire XML document.  Throw an exception  
            // if more than one signature was found. 
            if (nodeList.Count >= 2)
            {
                throw new CryptographicException("Xac thuc that bai: Co nhieu hon 1 chu ky trong tai lieu xml");
            }

            // Load the signature node.
            signedXml.LoadXml((XmlElement)nodeList[0]);
            /*
            var x509data = signedXml.Signature.KeyInfo.OfType<KeyInfoX509Data>().First();
            var verified = false;
            if (x509data != null)
            {
                var cert = x509data.Certificates[0] as X509Certificate2;
                Console.WriteLine(cert.Issuer);
                verified = cert != null && signedXml.CheckSignature(cert, false);
            }
            */
            // Check the signature and return the result. 
            return signedXml.CheckSignature();
        }
        public static XmlDocument SignXmlFile(XmlDocument doc, X509Certificate2 cer)
        {

            // Create a SignedXml object.
            var signedXml = new SignedXml(doc) { SigningKey = cer.PrivateKey };

            // Create a reference to be signed.
            var reference = new Reference { Uri = "" };

            // Add an enveloped transformation to the reference.
            var env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);


            // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
            var keyInfo = new KeyInfo();
            var keyInfoData = new KeyInfoX509Data(cer);
            //keyInfoData.SubjectNames.Add(cer.SubjectName);
            keyInfo.AddClause(keyInfoData);
            signedXml.KeyInfo = keyInfo;

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save 
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));


            if (doc.FirstChild is XmlDeclaration)
            {
                //doc.RemoveChild(doc.FirstChild);
            }

            return doc;
        }


        public static byte[] GetCertificateAsByteArray(X509Certificate2 cer)
        {
            return cer.GetRawCertData();
        }


        public static byte[] XmlToByteArray(XmlDocument xmlDoc)
        {
            return Encoding.UTF8.GetBytes(xmlDoc.OuterXml);
        }

        public static string XmlToString(XmlDocument xmlDoc)
        {
            return Encoding.UTF8.GetString(XmlToByteArray(xmlDoc));
        }

        public static string ByteArrayToString(byte[] byteArr)
        {
            return Encoding.UTF8.GetString(byteArr);
        }

        public static void XmlstringToFile(string fileName, string xmlContent)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xmlContent);
            var xmltw = new XmlTextWriter(fileName, new UTF8Encoding(true));
            doc.WriteTo(xmltw);
            xmltw.Close();
        }

        public string HashString(string text)
        {
            //create the MD5CryptoServiceProvider object we will use to encrypt the password
            var md5Hasher = new MD5CryptoServiceProvider();

            //Create a UTF8Encoding object we will use to convert our password string to a byte array
            var encoder = new UTF8Encoding();

            //create an array of bytes we will use to store the encrypted password
            //encrypt the password and store it in the hashedBytes byte array
            var hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(text));
            return ByteArrayToString(hashedBytes);
        }

        // trick to assign new value for a settings (unused)
        public static void ChangeConnectionStringValue(ConnectionStringSettings settings, string newValue)
        {
            var fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            fi.SetValue(settings, false);
            settings.ConnectionString = newValue;
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }

        // choose a certificate from a store identified by store name string
        public static X509Certificate2 ChooseCerfromStore(string storeName)
        {
            var store = new X509Store(storeName, StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certCollection = X509Certificate2UI.SelectFromCollection(store.Certificates, "", "Danh sách chứng thư được cài đặt.", X509SelectionFlag.SingleSelection);//(store.Certificates, null, null, X509SelectionFlag.SingleSelection);
            if (certCollection == null || certCollection.Count == 0)
            {
                return null;
            }
            X509Certificate2 certificate = certCollection[0];
            return certificate;
        }

        // choose a certificate from a store identified by store name enum
        public static X509Certificate2 ChooseCerfromStore(StoreName storeName)
        {
            var store = new X509Store(storeName, StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certCollection = X509Certificate2UI.SelectFromCollection(store.Certificates, "", "Danh sách chứng thư được cài đặt.", X509SelectionFlag.SingleSelection);//(store.Certificates, null, null, X509SelectionFlag.SingleSelection);
            if (certCollection == null || certCollection.Count == 0)
            {
                return null;
            }
            X509Certificate2 certificate = certCollection[0];
            return certificate;
        }

        // use to cut cn and ou from certificate subject name
        // note, partName must contains only 2 chars.
        public static string GetCerSubjectPart(string partName, string subject)
        {
            var pattern = partName + "=([^,]+)";
            var rgx = new Regex(pattern);
            var match = rgx.Match(subject);
            if (string.IsNullOrEmpty(match.Value)) return "";
            return match.Value.Substring(3);
        }

        // get sign name, sign name = cn + ou
        public static string GetSignName(string subject)
        {
            if (string.IsNullOrEmpty(GetCerSubjectPart("OU", subject)))
            {
                return GetCerSubjectPart("CN", subject);
            }
            return GetCerSubjectPart("CN", subject) + " - " + GetCerSubjectPart("OU", subject);
        }

        // get public key from a signed xml
        public static string GetPublicKey(XmlDocument xmlDoc)
        {
            string strpkey = "";
            XmlNodeList publickey = xmlDoc.GetElementsByTagName("RSAKeyValue", @"http://www.w3.org/2000/09/xmldsig#");
            if (publickey != null && publickey.Count == 1)
            {
                XmlNode pk = publickey[0];
                strpkey = pk.OuterXml;

                string ns = pk.NamespaceURI;
                string nsToRemove = " xmlns=\"" + ns + "\"";// note: a space before xmlns
                strpkey = strpkey.Replace(nsToRemove, "");
            }
            return strpkey;
        }
    }
}
