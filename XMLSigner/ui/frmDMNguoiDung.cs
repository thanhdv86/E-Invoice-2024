using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using cskh.domain;


namespace XMLSigner.ui
{
    public partial class frmDMNguoiDung : frmBase
    {
        private DataTable _dt;
        string _pTrangThai; //Biến dùng để kiểm tra trạng thái người dùng chọn nút Thêm hay là nút Sửa để ghi dữ liệu dạng insert hoặc update
        public frmDMNguoiDung()
        {
            InitializeComponent();
        }
        private void frmDMNguoiDung_Load(object sender, EventArgs e)
        {
            txtMaNguoiDung.MaxLength = 30;
            txtTenNguoiDung.MaxLength = 50;
            _pTrangThai = "";
            BoundGrid();
        }
        private void BoundGrid()
        {
            using (var ebi = new EiBusinessImpl())
            {
                _dt = ebi.GetDmNguoiDung("%");
                grid1.DataSource = _dt;
            }
        }
        private void cmdHuy_Click(object sender, EventArgs e)
        {
            SetControl(true);
            _pTrangThai = "";
            DocTuLuoi();
        }
        private void cmdIn_Click(object sender, EventArgs e)
        {

        }
        private void cmdLuu_Click(object sender, EventArgs e)
        {
            if (GhiDuLieu(txtMaNguoiDung.Text, txtTenNguoiDung.Text))
            {
                SetControl(true);
                _pTrangThai = "";
                BoundGrid();
                DocTuLuoi();
            }
        }

        private void cmdSetPass_Click(object sender, EventArgs e)
        {
            if (txtMaNguoiDung.Text.Trim() == Constants.ADMIN)
            {
                MessageBox.Show("Không thể reset mật khẩu user ADMIN ", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            try
            {
                using (var ebi = new EiBusinessImpl())
                {
                    if (ebi.ChangePassword(txtMaNguoiDung.Text.Trim(), Constants.DEFAULT_PASS) == 1)
                    {
                        showMessage("Reset mật khẩu thành công.", MessageType.Information);
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

        private void cmdSua_Click(object sender, EventArgs e)
        {

            if (txtMaNguoiDung.Text.Trim() == Constants.ADMIN)
            {
                MessageBox.Show("Không thể hiệu chỉnh user ADMIN ", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            _pTrangThai = Constants.REC_EDIT;
            SetControl(false);
            this.txtMaNguoiDung.Enabled = false;
            this.txtTenNguoiDung.Focus();
        }
        private void cmdThem_Click(object sender, EventArgs e)
        {
            _pTrangThai = Constants.REC_ADD;
            SetControl(false);
            LamTrong();
            txtMaNguoiDung.Focus();
        }
        private void cmdThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cmsXoa_Click(object sender, EventArgs e)
        {
            var bTraLoi = MessageBox.Show(string.Format("Bạn muốn xóa mã số {0}", txtMaNguoiDung.Text.Trim()), "Xác nhận", MessageBoxButtons.YesNo);
            if (txtMaNguoiDung.Text.Trim() == Constants.ADMIN)
            {
                MessageBox.Show("Không thể xóa user ADMIN ", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (bTraLoi == DialogResult.Yes && XoaDuLieu(txtMaNguoiDung.Text.Trim()))
            {
                MessageBox.Show("Xóa dữ liệu thành công ");
                BoundGrid();
            }
        }

        private void DocTuLuoi()
        {
            txtMaNguoiDung.Text = _dt.Rows[gridView1.FocusedRowHandle]["MaNguoiDung"].ToString();
            txtTenNguoiDung.Text = _dt.Rows[gridView1.FocusedRowHandle]["TenNguoiDung"].ToString();
        }


        public bool GhiDuLieu(string bMa, string bTen)
        {
            //Kiểm tra trước khi lưu dữ liệu
            if (txtMaNguoiDung.Text == Constants.ADMIN)
            {
                MessageBox.Show("Không cho phép thêm/sửa thông tin ADMIN !", "Thông báo");
                if (_pTrangThai == Constants.REC_ADD)
                {
                    txtMaNguoiDung.Focus();
                }
                else
                {
                    txtTenNguoiDung.Focus();
                }
                return false;
            }
            if (txtMaNguoiDung.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã số người dùng !", "Thông báo");
                txtMaNguoiDung.Focus();
                return false;
            }
            if (txtTenNguoiDung.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên người dùng !", "Thông báo");
                txtTenNguoiDung.Focus();
                return false;
            }
            if (_pTrangThai == "NEW")
            {
                try
                {
                    using (var ei = new EiBusinessImpl()) ei.InsertDmNguoiDung(bMa, bTen);
                    return true;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == Constants.ERR_UNIQUE_VIOLATE)
                    {
                        MessageBox.Show("Mã số người dùng đã đăng ký, kiểm tra lại!", "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
                }
            }

            try
            {
                using (var ei = new EiBusinessImpl()) ei.UpdateDmNguoiDung(bMa, bTen);
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == Constants.ERR_UNIQUE_VIOLATE)
                {
                    MessageBox.Show("Mã số người dùng đã đăng ký, kiểm tra lại!", "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DocTuLuoi();
        }
        private void LamTrong()
        {
            txtMaNguoiDung.Text = "";
            txtTenNguoiDung.Text = "";
        }
        private void SetControl(bool bSet)
        {
            cmdThem.Enabled = bSet;
            cmdSua.Enabled = bSet;
            cmdSetPass.Enabled = bSet;
            cmdIn.Enabled = bSet;
            cmsXoa.Enabled = bSet;
            cmdThoat.Enabled = bSet;
            cmdLuu.Enabled = !bSet;
            cmdHuy.Enabled = !bSet;
            grid1.Enabled = bSet;
            txtMaNguoiDung.Enabled = !bSet;
            txtTenNguoiDung.Enabled = !bSet;
        }

        public bool XoaDuLieu(string bMa)
        {

            //Kiểm tra trước khi xóa dữ liệu
            //if (txtMaNguoiDung.Text == Constants.ADMIN)
            //{
            //    MessageBox.Show("Không cho phép xóa ADMIN !", "Thông báo");
            //    return KetQua;
            //}
            try
            {
                using (var ebi = new EiBusinessImpl())
                {
                    // Xóa dữ liệu trên Table của CSDL
                    if (ebi.XoaDmNguoiDung(bMa) == 1)
                    {
                        // Xóa dữ liệu trên lưới
                        gridView1.DeleteSelectedRows();
                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
        }
    }
}
