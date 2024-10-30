using System;
using System.Windows.Forms;

namespace XMLSigner
{
    static class Program
    {
        public static bool ShowMainForm { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //CultureInfo ci = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentUICulture = ci;
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ShowMainForm = false;
            Application.Run(new XMLSigner.ui.frmSignIn());
            if (ShowMainForm)
            {
                Application.Run(new XMLSigner.ui.frmMain());
            }      
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(@"E:\Workspace1\Huewaco\document\FileKy\122616.xml");
            //string str = XMLSigner.util.SignUtil.getPublicKey(xmlDoc);

            //string encryptstr = Cryp.Encrypt("123");
            //string decryptstr = Cryp.Decrypt(encryptstr);


            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"E:\Workspace1\Huewaco\document\FileKy\newbooks.xml");

            //// Create an XmlNamespaceManager to resolve the default namespace.
            //XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            //nsmgr.AddNamespace("bk", "urn:newbooks-schema");

            //// Select the first book written by an author whose last name is Atwood.
            //XmlNode book;
            //XmlElement root = doc.DocumentElement;
            //book = root.SelectSingleNode("descendant::bk:book[bk:author/bk:last-name='Atwood']", nsmgr);

            //Console.WriteLine(book.OuterXml);

            
        }
    }
}
