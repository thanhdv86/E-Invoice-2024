using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using cskh.domain;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;

namespace XMLSigner.ui
{
    public partial class frmCertificateMngt : frmBase
    {
        public frmCertificateMngt()
        {
            InitializeComponent();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            var x509 = SignUtil.ChooseCerfromStore(StoreName.My);
            if (x509 == null) return;
            var mycer = new Certificate(x509)
            {
                NguoiTao = frmSignIn.user.Username,
                NgayTao = DateTime.Now,
                TrangThai = 1
            };

            try
            {
                using (var ebi = new EiBusinessImpl())
                {
                    ebi.InsertChungthu(mycer);
                }
                BindGrid();
            }
            catch (SqlException ex)
            {
                if (ex.Number == Constants.ERR_UNIQUE_VIOLATE)
                {
                    MessageBox.Show("Chứng thư số đã được đăng ký!", "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void frmCertificateMngt_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            using (var ebi = new EiBusinessImpl())
            {
                gridControl1.DataSource = ebi.GetAllChungthu();
            }
        }

        // called when edit form showing
        private void gridView1_ShowingPopupEditForm(object sender, DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs e)
        {
            //gridView1.
            foreach (Control control in e.EditForm.Controls)
            {

                if (control is EditFormContainer)
                {
                    foreach (Control nestedControl in control.Controls)
                    {
                        if (nestedControl is XtraScrollableControl)
                        {
                            foreach (Control l3 in nestedControl.Controls)
                            {
                                foreach (Control l4 in l3.Controls)
                                {
                                    if (l4 is DateEdit)
                                    {
                                        var dedit = l4 as DateEdit;
                                        dedit.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
                                    }

                                }
                            }
                        }
                        if (nestedControl is PanelControl)
                        {
                            foreach (Control button in nestedControl.Controls)
                            {
                                if (button is SimpleButton)
                                {
                                    var simpleButton = button as SimpleButton;
                                    if (simpleButton.Text == Constants.UPDATE)
                                    {
                                        simpleButton.Text = Constants.UPDATE_VN;
                                        simpleButton.Click += btnUpdateCer_Click;
                                    }
                                    else if (simpleButton.Text == Constants.CANCEL)
                                    {
                                        simpleButton.Text = Constants.CANCEL_VN;
                                    }

                                }
                            }
                        }

                    }
                }
            }

        }

        // event handler for updating ngay thu hoi chung thu
        private void btnUpdateCer_Click(object sender, EventArgs e)
        {
            var idKey = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Constants.ID_KEY).ToString());
            var ngaythuhoi = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Constants.NGAY_THU_HOI).ToString());
            using (var ebi = new EiBusinessImpl())
            {
                ebi.UpdateChungthu(idKey, frmSignIn.user.Username, DateTime.Now, ngaythuhoi);
            }
            BindGrid();
        }
        // update status of chung thu
        private void btnDel_Click(object sender, EventArgs e)
        {
            var idKey = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Constants.ID_KEY).ToString());
            var res = MessageBox.Show("Bạn có chắc là muốn xóa chứng thư khỏi hệ thống?\nHóa đơn sẽ xác thực không thành công nếu CTS dùng để ký HĐ bị xóa khỏi hệ thống.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes || res == DialogResult.OK)
            {
                using (var ebi = new EiBusinessImpl())
                {
                    ebi.updateChungthuStatus(idKey, frmSignIn.user.Username, DateTime.Now, 0);
                    BindGrid();
                }
            }
        }
    }
}
