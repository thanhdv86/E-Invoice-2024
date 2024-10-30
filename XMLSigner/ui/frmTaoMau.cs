using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cskh.domain;
using DevExpress.Xpf.Scheduler.Drawing;

namespace XMLSigner.ui
{
    public partial class frmTaoMau : Form
    {
        public frmTaoMau()
        {
            InitializeComponent();
        }


        private void lbcDSThamso_DoubleClick(object sender, EventArgs e)
        {
            if (!lbcDSThamso.Enabled)
            {
                return;
            }

            if (lbcDSThamso.SelectedValue != null)
                txtNoidungSMS.Text = txtNoidungSMS.Text.Insert(txtNoidungSMS.SelectionStart, string.Format(@" [[{0}]] ", lbcDSThamso.SelectedValue));
        }

        private bool _isSua;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var hbi = new EiBusinessImpl())
                {
                    var iditem = grdDsMauSMS.GetRowCellValue(grdDsMauSMS.FocusedRowHandle, "ID");
                    if (iditem != null && _isSua)
                    {
                        var res = hbi.UpdateMauSms(iditem.ToString(), cmbLoaiSMS.SelectedValue.ToString(), txtTieuDe.EditValue.ToString().Trim(), txtNoidungSMS.Text.Trim());
                        if (res != 1)
                        {
                            MessageBox.Show(@"Tạo mẫu không thành công");
                            return;
                        }
                        MessageBox.Show(@"Cập nhật thành công");
                    }
                    else
                    {
                        var res = hbi.InsertMauSms(cmbLoaiSMS.SelectedValue.ToString(), txtTieuDe.EditValue.ToString().Trim(), txtNoidungSMS.Text.Trim());
                        if (res != 1)
                        {
                            MessageBox.Show(@"Tạo mẫu không thành công");
                            return;
                        }
                        MessageBox.Show(@"Cập nhật thành công");
                    }

                    LoadDsMauSms();
                    btnHuy.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Tạo mẫu không thành công");
            }

        }

        private void grdDsMauSMS_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!grdDsMauSMS.IsDataRow(grdDsMauSMS.FocusedRowHandle)) return;
            txtTieuDe.EditValue = grdDsMauSMS.GetRowCellValue(grdDsMauSMS.FocusedRowHandle, "TieuDe");
            txtNoidungSMS.Text = grdDsMauSMS.GetRowCellValue(grdDsMauSMS.FocusedRowHandle, "MauND").ToString();
            cmbLoaiSMS.SelectedValue = grdDsMauSMS.GetRowCellValue(grdDsMauSMS.FocusedRowHandle, "IDLoaiSMS").ToString();
        }

        private void frmTaoMau_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
            txtTieuDe.Enabled = false;
            txtNoidungSMS.Enabled = false;
            lbcDSThamso.Enabled = false;
            cmbLoaiSMS.Enabled = false;

            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            btnSave.Enabled = false;
        }

        private void LoadDuLieu()
        {
            using (var ebi = new EiBusinessImpl())
            {

                var dt = ebi.GetDsMauSms();
                if (dt != null)
                {
                    grdMauSms.DataSource = dt;
                }

                dt = ebi.GetDsLoaiSms();
                if (dt != null)
                {
                    cmbLoaiSMS.DataSource = dt;
                }
            }
        }

        private void LoadDsMauSms()
        {
            using (var ebi = new EiBusinessImpl())
            {
                var dt = ebi.GetDsMauSms();
                if (dt != null)
                {
                    grdMauSms.DataSource = dt;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtTieuDe.Enabled = true;
            txtNoidungSMS.Enabled = true;
            lbcDSThamso.Enabled = true;

            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            btnXoa.Enabled = true;
            btnSave.Enabled = true;
            cmbLoaiSMS.Enabled = true;
            _isSua = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnSave.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            txtNoidungSMS.Enabled = false;
            txtTieuDe.Enabled = false;
            lbcDSThamso.Enabled = false;
            cmbLoaiSMS.Enabled = false;
            _isSua = false;

            if (!grdDsMauSMS.IsDataRow(grdDsMauSMS.FocusedRowHandle)) return;
            txtTieuDe.EditValue = grdDsMauSMS.GetRowCellValue(grdDsMauSMS.FocusedRowHandle, "TieuDe");
            txtNoidungSMS.Text = grdDsMauSMS.GetRowCellValue(grdDsMauSMS.FocusedRowHandle, "MauND").ToString();
            cmbLoaiSMS.SelectedValue = grdDsMauSMS.GetRowCellValue(grdDsMauSMS.FocusedRowHandle, "IDLoaiSMS").ToString();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTieuDe.EditValue = string.Empty;
            txtTieuDe.Enabled = true;
            txtNoidungSMS.Enabled = true;
            txtNoidungSMS.Text = string.Empty;

            btnSave.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            lbcDSThamso.Enabled = true;
            cmbLoaiSMS.Enabled = true;
            _isSua = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Có muốn xóa không...?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                try
                {
                    using (var hbi = new EiBusinessImpl())
                    {
                        var idMau = grdDsMauSMS.GetRowCellValue(grdDsMauSMS.FocusedRowHandle, "ID");
                        var res = hbi.DeleteMauSms(idMau.ToString());
                        if (res != 1) MessageBox.Show(@"Xóa mẫu không thành công");

                    }
                    LoadDsMauSms();

                }
                catch (Exception)
                {
                    MessageBox.Show(@"Tạo mẫu không thành công");
                }
            }
            btnHuy.Enabled = false;
            btnSave.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            txtNoidungSMS.Enabled = false;
            txtTieuDe.Enabled = false;
            lbcDSThamso.Enabled = false;
            cmbLoaiSMS.Enabled = false;
            _isSua = false;
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbLoaiSMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var ebi = new EiBusinessImpl())
            {
                var dt = ebi.GetDsThamSoByLoaiSms(int.Parse(cmbLoaiSMS.SelectedValue.ToString()));
                if (dt == null) return;
                lbcDSThamso.Items.Clear();
                lbcDSThamso.DisplayMember = "Value";
                lbcDSThamso.ValueMember = "Key";
                var comboSource = dt.Rows.Cast<DataRow>().ToDictionary(row => row["TenThamSo"].ToString(), row => row["TenThamSo"].ToString() + " - " + row["MoTa"].ToString());
                lbcDSThamso.DataSource = new BindingSource(comboSource, null);
            }
        }
    }
}
