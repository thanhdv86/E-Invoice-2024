using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using cskh.domain;
using DevExpress.XtraEditors;
using XMLSigner.util;
using System.Data.SqlClient;

namespace XMLSigner.ui
{
    public partial class frmChangePassword : frmBase
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                using (EiBusinessImpl hbi = new EiBusinessImpl())
                {                    
                    if (frmSignIn.user.Password != tbPasswordOld.Text)
                    {
                        showMessage("Sai mật khẩu!", MessageType.Error);
                        return;
                    }
                    if (tbPasswordNew1.Text != tbPasswordNew2.Text)
                    {
                        showMessage("Lặp lại mật khẩu không đúng!", MessageType.Error);
                        return;
                    }
                    int res = hbi.ChangePassword(frmSignIn.user.Username, tbPasswordNew1.Text);
                    if (res == 1)
                    {
                        showMessage("Đổi mật khẩu thành công",MessageType.Information);
                        this.Close();
                    }
                    
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi DB " + ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                showMessage(ex.Message, MessageType.Error);
            }
        }
    }
}