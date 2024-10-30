using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cskh.domain;
using DevExpress.XtraPrinting;

namespace XMLSigner.ui
{
    public partial class frmSmsCatNuoc : Form
    {
        public frmSmsCatNuoc()
        {
            InitializeComponent();

        }
        private void btnTaoMau_Click(object sender, EventArgs e)
        {
            using (var frmTaoMau = new frmTaoMau())
            {
                frmTaoMau.ShowDialog();
                frmTaoMau.Close();
                LoadDsMauSms();
            }
        }
        private void frmSMS_Load(object sender, EventArgs e)
        {
            LoadDsMauSms();
            //LoadDsKhuVuc();
            SignUtil.BindKv(cbKV,"Tất cả","%");

        }
        private void LoadDsMauSms()
        {
            using (var ebi = new EiBusinessImpl())
            {
                var dt = ebi.GetDsMauSms();
                cmbMauSms.DataSource = null;
                cmbMauSms.Items.Clear();                
                if (dt == null) return;
                var comboSource = dt.Select("IDLoaiSMS = 1").ToDictionary(row => row["MauND"].ToString(), row => row["TieuDe"].ToString());
                cmbMauSms.DisplayMember = "Value";
                cmbMauSms.ValueMember = "Key";
                cmbMauSms.DataSource = new BindingSource(comboSource, null);
            }
        }
        private void LoadDsLoTrinh()
        {
            using (var cbi = new CrBusinessImpl())
            {
                var dt = cbi.GetDsDuongPho(cbKV.SelectedValue.ToString());
                if (dt == null) return;
                var dr = dt.NewRow();
                dr[0] = "%";
                dr[1] = "Tất cả";
                dt.Rows.InsertAt(dr, 0);
                cmbLoTrinh.DataSource = dt;
            }
        }
        private void cmbMauSms_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbMauSms.DataSource != null && !string.IsNullOrEmpty(cmbMauSms.SelectedValue.ToString()))
            {
                txtNoiDungSms.Text = cmbMauSms.SelectedValue.ToString();
            }
        }
        private void cmbKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDsLoTrinh();
        }
        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            using (var cbi = new CrBusinessImpl())
            {
                btnSend.Enabled = true;
                //var dt = cbi.GetDsKhachHang(cbKV.SelectedValue.ToString(), cmbLoTrinh.SelectedValue.ToString().Trim(), Convert.ToInt16(rdMang.EditValue));
                var dt = cbi.GetDsKhachHangX(cbKV.SelectedValue.ToString(), cmbLoTrinh.SelectedValue.ToString().Trim(), Convert.ToInt16(rdMang.EditValue));
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show(@"Không có dữ liệu thỏa mãn điều kiện");
                    return;
                }
                dt.Columns.Add("TinNhan");
                foreach (DataRow row in dt.Rows)
                {
                    row["TinNhan"] = txtNoiDungSms.Text
                        .Replace("[[TenKH]]", row["TENKH"].ToString())
                        .Replace("[[MaKH]]", row["IDKH"].ToString())
                        .Replace("[[TuNgay]]", txtBatDau.Text)
                        .Replace("[[DenNgay]]", txtKetThuc.Text)
                        .Replace("[[LyDo]]", txtLydo.Text.Trim());
                }
                grdSMS.DataSource = dt;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Title = @"DanhSachCatNuoc",
                Filter = @"Excel(*.xls)|*.xls",
                FileName = "DanhSachCatNuoc"
            };
            var dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                var options = new XlsExportOptions
                {
                    TextExportMode = TextExportMode.Value,
                    ExportMode = XlsExportMode.SingleFile,
                    ShowGridLines = true
                };
                //ColumnFilterInfo filter = new ColumnFilterInfo("selecttion = 1");
                gridView1.ExportToXls(saveFileDialog.FileName, options);
                DevExpress.XtraEditors.XtraMessageBox.Show("Thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
