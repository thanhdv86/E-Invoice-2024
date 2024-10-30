using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using cskh.domain;
using XMLSigner.data;
using System.Xml;
using XMLSigner.util;
using System.IO;
namespace XMLSigner.ui
{
    public partial class frmSignIn : frmBase
    {
        public static User user;
        public const string DEFAULT_LOGIN_FILE = "DefaultLogin.xml";
        public frmSignIn()
            : base()
        {
            InitializeComponent();
            // set default login information to fields
            User user = getDefaultUser();
            tbUsername.Text = user.Username;
            tbPassword.Text = user.Password;
        }

        /// <summary>
        /// Khi login lam cac cong viec sau:
        /// - check login co thanh cong khong. Neu thanh cong thi luu session dong thoi lam viec sau:
        /// + Neu o ghi nho duoc check thi ghi thong tin username/password vao default login file
        /// + hoac: Neu o ghi nho khong duoc check va ton tai username dang login trong file default login form thi xoa thong tin username/password trong file default login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {            
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                showMessage("Vui lòng nhập tên đăng nhập!", MessageType.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                showMessage("Vui lòng nhập mật khẩu!", MessageType.Error);
                return;
            }

            try
            {
                using (EiBusinessImpl hdb = new EiBusinessImpl())
                {
                    bool isOk = hdb.CheckLogin2(tbUsername.Text, tbPassword.Text);
                    if (isOk)
                    {
                        user = new User(tbUsername.Text, tbPassword.Text);
                        if (ckbGhinho.Checked)
                        {
                            setDefaultUser(user);
                        }
                        else
                        {
                            setDefaultUser(new User());
                        }
                        Program.ShowMainForm = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập và/hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối DB :" + ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lkSetup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmConnectDb _frmConnectDb = new frmConnectDb();
            _frmConnectDb.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// get default username and password from DefaultLogin.xml, return ["",""]  if not fouund
        /// </summary>
        /// <returns>string array str[] include str[0]=username, str[1]=password</returns>
        private User getDefaultUser()
        {
            User user = new User();
            XmlDocument doc = new XmlDocument();
            try
            {
                //lbDebug.Text = Directory.GetCurrentDirectory();
                doc.Load(DEFAULT_LOGIN_FILE);
                XmlNodeList list = doc.DocumentElement.SelectNodes("USERNAME");
                if (list.Count > 0)
                {
                    XmlNode usernameNode = list[0];
                    user.Username = list[0].InnerText;
                }
                else
                {
                    user.Username = "";
                }
                list = doc.DocumentElement.SelectNodes("PASSWORD");
                if (list.Count > 0)
                {
                    XmlNode passwordNode = list[0];
                    user.Password = Cryp.Decrypt(list[0].InnerText);
                }
                else
                {
                    user.Password = "";
                }
            }
            catch (Exception ex)
            {
                showMessage(ex.Message,MessageType.Error);
            }
            return user;
        }
        /// <summary>
        /// set default username and password (set "" if not given)
        /// </summary>
        /// <param name="user"></param>
        private void setDefaultUser(User user)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(DEFAULT_LOGIN_FILE);
            XmlNodeList list = doc.DocumentElement.SelectNodes(string.Format("USERNAME"));
            if (list.Count > 0)
            {
                XmlNode usernameNode = list[0];
                usernameNode.InnerText = user.Username;
            }
            list = doc.DocumentElement.SelectNodes(string.Format("PASSWORD"));
            if (list.Count > 0)
            {
                XmlNode passwordNode = list[0];
                passwordNode.InnerText = (string.IsNullOrEmpty(user.Password) ? "" : Cryp.Encrypt(user.Password));
            }
            doc.Save(DEFAULT_LOGIN_FILE);
        }
    }
}
