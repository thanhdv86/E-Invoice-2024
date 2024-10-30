using System;
using System.Data;
using System.Windows.Forms;
using cskh.domain;

namespace XMLSigner.ui
{
    public partial class frmInvoiceNumMngt : frmBase
    {
        public frmInvoiceNumMngt():base()
        {
            InitializeComponent();
        }

        private void frmInvoiceNumMngt_Load(object sender, EventArgs e)
        {
            bindData();
            //gridControl1.MainView.
        }

        private void bindData() {
            using (var ebi = new EiBusinessImpl())
            {
                gridControl1.DataSource = ebi.GetAllInvoiceNums();
            }
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            if (!validate())
            {
                return;
            }
            int result = 0;
            try
            {
                using (var hdb = new EiBusinessImpl())
                {
                    result = hdb.GenInvoiceNums(tbStartPrefix.Text, tbStartSuf.Text, tbStartNo.Text, tbEndNo.Text, tbKyHieu.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message,"Lỗi");
            }
            finally
            {
                //MessageBox.Show("" + result);
            }
            if (result > 0)
            {
                MessageBox.Show(string.Format("Đã đăng ký thành công {0} số hóa đơn.", result));
                bindData();
            }
        }

        private void tbStartPrefix_TextChanged(object sender, EventArgs e)
        {
            tbEndPre.Text = tbStartPrefix.Text;
        }

        private void tbStartSuf_TextChanged(object sender, EventArgs e)
        {
            tbEndSuf.Text = tbStartSuf.Text;
        }

        private void tbStartNo_TextChanged(object sender, EventArgs e)
        {
            // Determine if the TextBox has a digit character.
            var text = tbStartNo.Text;
            var hasDigit = false;
            foreach (char letter in text)
            {
                if (char.IsDigit(letter))
                {
                    hasDigit = true;
                    break;
                }
            }
            // Call SetError or Clear on the ErrorProvider.
            if (!hasDigit)
            {
                errorProvider1.SetError(tbStartNo, "Vui lòng nhập số.");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void tbEndNo_TextChanged(object sender, EventArgs e)
        {
            // Determine if the TextBox has a digit character.
            var text = tbEndNo.Text;
            var hasDigit = false;
            foreach (char letter in text)
            {
                if (char.IsDigit(letter))
                {
                    hasDigit = true;
                    break;
                }
            }
            // Call SetError or Clear on the ErrorProvider.
            if (!hasDigit)
            {
                errorProvider1.SetError(tbEndNo, "Vui lòng nhập số.");
            }
            else
            {
                errorProvider1.Clear();
            }
        }


        private bool validate()
        {
            if (tbKyHieu.Text == string.Empty)
            {
                errorProvider1.SetError(tbKyHieu, "Vui lòng nhập mã ký hiệu hóa đơn");
                return false;
            }
            if (tbStartNo.Text == string.Empty)
            {
                errorProvider1.SetError(tbStartNo, "Vui lòng nhập số hóa đơn đầu");
                return false;
            }
            if (tbStartNo.Text == string.Empty)
            {
                errorProvider1.SetError(tbStartNo, "Vui lòng nhập số hóa đơn cuối");
                return false;
            }
            try
            {
                if (Convert.ToInt32(tbEndNo.Text) - Convert.ToInt32(tbStartNo.Text) < 0)
                {
                    MessageBox.Show("Vui lòng nhập số hóa đơn cuối lớn hơn số hóa đơn đầu!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu không hợp lệ!");
                return false;
            }
            return true;
        }

    }
}
