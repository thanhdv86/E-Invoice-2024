using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using cskh.domain;
using XMLSigner.util;

namespace XMLSigner.ui
{
    public partial class frmConnectDb : frmBase
    {
        public string passphrase = "using_this_to_encrypt_decrypt";
        public frmConnectDb():base()
        {
            InitializeComponent();
            SqlConnectionStringBuilder builder;
            // initital values from hddt connection string in app.config
            if (DataAccess.EiconString != null)
            {
                builder = new SqlConnectionStringBuilder(DataAccess.EiconString);
                txtServer.Text = builder.DataSource;
                txtDbname.Text = builder.InitialCatalog;
                txtUsername.Text = builder.UserID;
                txtPassword.Text = Cryp.Decrypt(builder.Password);
            }


            // initial values from crm (eoshue) connection string in app.config
            if (DataAccess.CrconString != null)
            {
                builder = new SqlConnectionStringBuilder(DataAccess.CrconString);
                tbserver2.Text = builder.DataSource;
                tbdbname2.Text = builder.InitialCatalog;
                tbusername2.Text = builder.UserID;
                tbpassword2.Text = Cryp.Decrypt(builder.Password);
            }

        }

        private void bntConnect_Click(object sender, EventArgs e)
        {
            var server = txtServer.Text;
            var dbname = txtDbname.Text;
            var username = txtUsername.Text;
            var password = Cryp.Encrypt(txtPassword.Text);

            var conString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", server, dbname, username, password);
            var da = new DataAccess(conString);
            if (da.Open())
            {
                MessageBox.Show("Kết nối CSDL HĐĐT thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Program.OpenInvoiceSignerOnClose = true;

            }
            else
            {
                MessageBox.Show("Kết nối CSDL HĐĐT không thành công!", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // CSDL HDDT
                var server = txtServer.Text;
                var dbname = txtDbname.Text;
                var username = txtUsername.Text;
                var password = Cryp.Encrypt(txtPassword.Text);
                DataAccess.EiconString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", server, dbname, username, password);
                Common.AddUpdateConnectionString(Constants.EI_CON_NAME, DataAccess.EiconString);
                // CSDL CRM (EOSHUE)
                var server2 = tbserver2.Text;
                var dbname2 = tbdbname2.Text;
                var username2 = tbusername2.Text;
                var password2= Cryp.Encrypt(tbpassword2.Text);
                DataAccess.CrconString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", server2, dbname2, username2, password2);
                Common.AddUpdateConnectionString(Constants.CR_CON_NAME, DataAccess.CrconString);
                MessageBox.Show("Đã lưu thông tin kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu không thành công : "+ ex.Message, "Lỗi...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkApplyBoth_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApplyBoth.Checked)
            {
                tbserver2.Text = txtServer.Text;                
                tbusername2.Text = txtUsername.Text;
                tbpassword2.Text = txtPassword.Text;
            }
            else
            {
                tbserver2.ResetText();
                tbdbname2.ResetText();
                tbusername2.ResetText();
                tbpassword2.ResetText();
            }
        }

        private void btnConnect2_Click(object sender, EventArgs e)
        {
            var server = tbserver2.Text;
            var dbname = tbdbname2.Text;
            var username = tbusername2.Text;
            var password = Cryp.Encrypt(tbpassword2.Text);

            var conString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", server, dbname, username, password);
            var da = new DataAccess(conString);
            if (da.Open())
            {
                MessageBox.Show("Kết nối CSDL CRM thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Program.OpenInvoiceSignerOnClose = true;
            }
            else
            {
                MessageBox.Show("Kết nối CSDL CRM không thành công!", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
    }
}
