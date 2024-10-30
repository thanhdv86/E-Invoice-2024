using System;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using cskh.domain;
using XMLSigner.util;
namespace XMLSigner.ui
{
    public partial class frmXMLSigner : frmBase
    {
        string[] filenames;
        public frmXMLSigner()
            : base()
        {
            InitializeComponent();
        }

        void setDebugText(string text)
        {
            txtDebug.AppendText(text);
            txtDebug.AppendText(Environment.NewLine);
        }

        string signedXMLFilename = "";

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                filenames = openFileDialog1.FileNames;
                signedXMLFilename = openFileDialog1.FileNames[0];
                foreach (string filename in filenames)
                    setDebugText("Open: " + filename);
            }
        }
        private void btnSign_Click(object sender, EventArgs e)
        {

            // Open the X.509 "Current User" store in read only mode.
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            //X509Store store = new X509Store("MyStore", StoreLocation.CurrentUser);//
            store.Open(OpenFlags.ReadOnly);

            // Place all certificates in an X509Certificate2Collection object.            
            X509Certificate2Collection certCollection = X509Certificate2UI.SelectFromCollection(store.Certificates, "MyStore", "Store all installed certificate for current user.", X509SelectionFlag.SingleSelection);//(store.Certificates, null, null, X509SelectionFlag.SingleSelection);

            if (certCollection == null || certCollection.Count == 0)
            {
                return;
            }
            X509Certificate2 certificate = certCollection[0];

            // Neu tao tu file
            //X509Certificate2 certificate = new X509Certificate2("E:\\Workspace1\\DigitalSignature\\certificates\\Talisa.pfx","tuyen980171");
            RSACryptoServiceProvider privateKey = certificate.PrivateKey as RSACryptoServiceProvider;

            // Create a new XML document.
            XmlDocument xmlDoc = new XmlDocument();
            signedXMLFilename = filenames[0].Substring(0, filenames[0].ToLower().IndexOf(".xml")) + "_Signed.xml";

            SignXmlFile(filenames[0], signedXMLFilename, privateKey);
            setDebugText("Done --------------------------");
            setDebugText("Output: " + signedXMLFilename);
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (ckbHoaDon.Checked) verifyHoaDon();
            else verifyNormalXml();
        }

        private void verifyNormalXml()
        {
            try
            {
                signedXMLFilename = filenames[0];
                try
                {
                    if (SignUtil.VerifyXmlFile(signedXMLFilename))
                    {
                        setDebugText(signedXMLFilename + " --> Chữ ký hợp lệ!");
                    }
                    else
                    {
                        setDebugText(signedXMLFilename + "--> Chữ ký KHÔNG hợp lệ!");
                    }
                }
                catch (Exception ex)
                {
                    setDebugText("Error:" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                setDebugText("Error:" + ex.Message);
            }
        }
        private void verifyHoaDon()
        {
            try
            {
                signedXMLFilename = filenames[0];
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(signedXMLFilename);
                try
                {
                    if (SignUtil.VerifyXmlFile(xmlDoc))
                    {
                        if (isSignedWithHWCCertificate(xmlDoc))
                        {
                            setDebugText(signedXMLFilename + " --> Hóa đơn hợp lệ được ký bởi HueWACO!");
                        }
                        else
                        {
                            setDebugText(signedXMLFilename +" --> Hóa đơn không bị chỉnh sửa sau khi ký. Nhưng hóa đơn KHÔNG được ký bới HueWACO.");
                        }
                    }
                    else
                    {
                        setDebugText(signedXMLFilename + "--> Hóa đơn KHÔNG hợp lệ!");
                    }
                }
                catch (Exception ex)
                {
                    setDebugText("Error:" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                setDebugText("Error:" + ex.Message);
            }
        }

        private bool isSignedWithHWCCertificate(XmlDocument xmlDoc)
        {
            bool isValid = false;
            try
            {
                using (EiBusinessImpl hbi = new EiBusinessImpl())
                {
                    isValid = hbi.IsValidCertificate(SignUtil.GetPublicKey(xmlDoc));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi DB : " + ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isValid;
        }

        // Sign an XML file and save the signature in a new file. 
        public static void SignXmlFile(string FileName, string SignedFileName, RSA Key)
        {
            // Create a new XML document.
            XmlDocument doc = new XmlDocument();

            // Format the document to ignore white spaces.
            doc.PreserveWhitespace = false;

            // Load the passed XML file using its name.
            StreamReader reader = new System.IO.StreamReader(FileName, true);
            XmlTextReader xmlTextReader = new XmlTextReader(reader);
            //XmlTextReader xmlTextReader = new XmlTextReader(FileName);
            //Console.WriteLine("---------------------encoding:"+xmlTextReader);
            doc.Load(xmlTextReader);


            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(doc);

            // Add the key to the SignedXml document. 
            signedXml.SigningKey = Key;

            // Create a reference to be signed.
            Reference reference = new Reference();
            reference.Uri = "";

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);


            // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
            KeyInfo keyInfo = new KeyInfo();
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

            // Save the signed XML document to a file specified 
            // using the passed string.
            XmlTextWriter xmltw = new XmlTextWriter(SignedFileName, new UTF8Encoding(true));
            doc.WriteTo(xmltw);
            xmltw.Close();
        }

        // Verify the signature of an XML file and return the result. 
        public static Boolean VerifyXmlFile(String Name)
        {
            // Create a new XML document.
            XmlDocument xmlDocument = new XmlDocument();

            // Format using white spaces.
            xmlDocument.PreserveWhitespace = false;

            // Load the passed XML file into the document.
            StreamReader reader = new System.IO.StreamReader(Name, true);
            XmlTextReader xmlTextReader = new XmlTextReader(reader);
            xmlDocument.Load(xmlTextReader);


            // Create a new SignedXml object and pass it 
            // the XML document class.
            SignedXml signedXml = new SignedXml(xmlDocument);

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

            // if include the cer in signed doc
            //var x509data = signedXml.Signature.KeyInfo.OfType<KeyInfoX509Data>().First();
            //var verified = false;
            //if (x509data != null)
            //{
            //    var cert = x509data.Certificates[0] as X509Certificate2;
            //    Console.WriteLine(cert.Issuer);
            //    verified = cert != null && signedXml.CheckSignature(cert, false);// verifysignatureonly = false --> verify certificate
            //}
            //return verified;


            // Check the signature and return the result. 
            return signedXml.CheckSignature();

        }

    }

}
