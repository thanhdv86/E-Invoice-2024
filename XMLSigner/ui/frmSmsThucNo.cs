using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cskh.domain;
using DevExpress.XtraPrinting;

namespace XMLSigner.ui
{
    public partial class frmSmsThucNo : frmBase
    {
        private DataTable _dtDsMauSms;
        private bool _uyNhiemThu;
        private bool _noDenKy;
        public frmSmsThucNo()
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
            SignUtil.BindKv(cbKV, "Tất cả", "%");
            SignUtil.BindKy(cbKy, tbNam);
            cbKy.Focus();
            SignUtil.BindQt(cbQT, "Tất cả", "%");
        }
        private void LoadDsMauSms()
        {
            try
            {
                using (var ebi = new EiBusinessImpl())
                {
                    var dt = ebi.GetDsMauSms();
                    cmbMauSms.DataSource = null;
                    cmbMauSms.Items.Clear();
                    if (dt == null) return;
                    //var comboSource = dt.Select("IDLoaiSMS = 2").ToDictionary(row => row["MauND"].ToString(), row => row["TieuDe"].ToString());
                    //cmbMauSms.DisplayMember = "Value";
                    //cmbMauSms.ValueMember = "Key";
                    //cmbMauSms.DataSource = new BindingSource(comboSource, null);

                    _dtDsMauSms = dt;
                    var comboSource = dt.Select("IDLoaiSMS = 2").ToDictionary(row => row["ID"].ToString(), row => row["TieuDe"].ToString());
                    cmbMauSms.DisplayMember = "Value";
                    cmbMauSms.ValueMember = "Key";
                    cmbMauSms.DataSource = new BindingSource(comboSource, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //private void LoadDsKhuVuc()
        //{
        //    using (var cr = new CrBusinessImpl())
        //    {
        //        var dt = cr.GetKv();
        //        if (dt == null) return;
        //        var dr = dt.NewRow();
        //        dr[0] = "%";
        //        dr[1] = "Tất cả";
        //        dt.Rows.InsertAt(dr, 0);
        //        cbKV.DataSource = dt;
        //    }
        //}

        private void cmbMauSms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMauSms.DataSource != null && !string.IsNullOrEmpty(cmbMauSms.SelectedValue.ToString()))
            {
                if (_dtDsMauSms != null && _dtDsMauSms.Rows.Count > 0)
                {
                    var dt = _dtDsMauSms.Select(string.Format("ID = {0}", cmbMauSms.SelectedValue)).CopyToDataTable();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        _uyNhiemThu = bool.Parse(dt.Rows[0]["UNT"].ToString());
                        chkUNT.EditValue = _uyNhiemThu;
                        _noDenKy = bool.Parse(dt.Rows[0]["NDK"].ToString());
                        chkNoDenKy.EditValue = _noDenKy;
                        txtNoiDungSms.Text = dt.Rows[0]["MauND"].ToString();
                    }
                }
                //txtNoiDungSms.Text = cmbMauSms.SelectedValue.ToString();
            }
        }
        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDsLoTrinh();
        }
        private void LoadDsLoTrinh()
        {
            using (var cr = new CrBusinessImpl())
            {
                var dt = cr.GetDsDuongPho(cbKV.SelectedValue.ToString());
                if (dt == null) return;
                var dr = dt.NewRow();
                dr[0] = "%";
                dr[1] = "Tất cả";dt.Rows.InsertAt(dr, 0);
                cmbLoTrinh.DataSource = dt;
            }
        }
        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            if (txtNoiDungSms.Text.Trim().Length == 0)
            {
                showMessage("Vui lòng chọn mẫu tin!", MessageType.Error);
                return;
            }
            using (var cbi = new CrBusinessImpl()){
                btnSend.Enabled = true;
                // Bổ sung chức năng thúc nợ nhiều kỳ khi chọn tháng = "Tất cả" năm Visible = true
                // var dt = cbi.GetDsThucNo(cbKV.SelectedValue.ToString(), cmbLoTrinh.SelectedValue.ToString(), int.Parse(cbbThang.SelectedItem.ToString()), int.Parse(cbbNam.SelectedItem.ToString()), Convert.ToInt16(rdMang.EditValue));
                // var dt = cbi.GetDsThucNoX(_uyNhiemThu, Convert.ToInt16(rdMang.EditValue), int.Parse(cbKy.SelectedItem.ToString()), int.Parse(tbNam.Text), cmbLoTrinh.SelectedValue.ToString(), cbKV.SelectedValue.ToString());
                var dt = chkNoDenKy.Checked == true ?
                    cbi.GetDsThucNoAllKy(_uyNhiemThu, Convert.ToInt16(rdMang.EditValue), int.Parse(cbKy.SelectedItem.ToString()), int.Parse(tbNam.Text), cmbLoTrinh.SelectedValue.ToString(), cbKV.SelectedValue.ToString(), cbQT.SelectedValue.ToString()) :  
                    cbi.GetDsThucNoX(_uyNhiemThu, Convert.ToInt16(rdMang.EditValue), int.Parse(cbKy.SelectedItem.ToString()), int.Parse(tbNam.Text), cmbLoTrinh.SelectedValue.ToString(), cbKV.SelectedValue.ToString());
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show(@"Không có dữ liệu thỏa mãn điều kiện");
                    grdSMS.DataSource = null;
                    return;
                }dt.Columns.Add("TinNhan");
                foreach (DataRow row in dt.Rows)
                {
                    var noidung = txtNoiDungSms.Text;
                    var tongtien = row["TONGTIEN"].ToString();
                    var tieuthu = row["KLTIEUTHU"].ToString();var diemthu = row["DIADIEMTHU"].ToString();
                    var idkh = row["IDKH"].ToString();
                    var tungay = row["TUNGAY"].ToString();
                    var thang = row["THANG"].ToString();
                    var nam = row["NAM"].ToString();
                    var danhbo = row["DANHBO"].ToString();
                    var tinnhan = txtNoiDungSms.Text
                        .Replace("[[MaKH]]", idkh)
                        .Replace("[[TieuThu]]", tieuthu)
                        .Replace("[[SoTien]]", tongtien)
                        .Replace("[[DiemThu]]", diemthu)
                        .Replace("[[TuNgay]]", tungay)
                        .Replace("[[Thang]]", thang)
                        .Replace("[[Nam]]", nam)
                        .Replace("[[DanhBo]]", danhbo);
                    if (tinnhan.Length > 160) //if (tinnhan.Length>160)
                    {
                        tinnhan = txtNoiDungSms.Text.Substring(0, txtNoiDungSms.Text.Length-18)
                            .Replace("[[MaKH]]", idkh)
                            .Replace("[[TieuThu]]", tieuthu)
                            .Replace("[[SoTien]]", tongtien)
                            .Replace("[[DiemThu]]", diemthu)
                            .Replace("[[TuNgay]]", tungay)
                            .Replace("[[Thang]]", thang)
                            .Replace("[[Nam]]", nam).Replace("[[DanhBo]]", danhbo);
                    }row["TinNhan"] = tinnhan;
                }grdSMS.DataSource = dt;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Title = @"DanhSachThucno",
                Filter = @"Excel(*.xlsx)|*.xlsx",FileName = "DanhSachThucno"
            };
            var dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                var options = new XlsxExportOptions()
                {
                    TextExportMode = TextExportMode.Value,
                    ExportMode = XlsxExportMode.SingleFile,ShowGridLines = true
                };
                //ColumnFilterInfo filter = new ColumnFilterInfo("selecttion = 1");
                grdViewSMS.ExportToXlsx(saveFileDialog.FileName, options);
                DevExpress.XtraEditors.XtraMessageBox.Show("Thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //var dialogResult = saveFileDialog.ShowDialog(this);
            //if (dialogResult == DialogResult.OK)
            //{
            //    var options = new XlsExportOptions
            //    {
            //        TextExportMode = TextExportMode.Value,
            //        ExportMode = XlsExportMode.SingleFile,
            //        ShowGridLines = true
            //    };
            //    //ColumnFilterInfo filter = new ColumnFilterInfo("selecttion = 1");
            //    grdViewSMS.ExportToXls(saveFileDialog.FileName, options);
            //    DevExpress.XtraEditors.XtraMessageBox.Show("Thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        //private void cbKy_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //tbNam.ReadOnly = cbKy.SelectedItem.ToString().Equals("Tất cả") ? true : false;
        //    tbNam.Visible = !cbKy.SelectedItem.ToString().Equals("Tất cả") ? true : false;
        //    lblNam.Visible = !cbKy.SelectedItem.ToString().Equals("Tất cả") ? true : false;
        //}
    }
}
