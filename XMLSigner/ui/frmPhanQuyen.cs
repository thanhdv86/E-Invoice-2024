using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using cskh.domain;

namespace XMLSigner.ui
{
    public partial class frmPhanQuyen : frmBase
    {
        private DataTable _dtPhanQuyen;
        public frmPhanQuyen()
        {
            InitializeComponent();
            BoundCombo();
            BoundGrid();
        }

        private void BoundCombo()
        {
            using (var ebi = new EiBusinessImpl())
            {
                var dt = ebi.GetDmNguoiDung("%");
                var dr = dt.NewRow();
                dr[Constants.TENNGUOIDUNG] = "--Chọn--";
                dr[Constants.MANGUOIDUNG] = null;
                dt.Rows.InsertAt(dr, 0);

                cbNguoiDung.DataSource = dt;
                cbNguoiDung.DisplayMember = Constants.TENNGUOIDUNG;
                cbNguoiDung.ValueMember = Constants.MANGUOIDUNG;

                cbNguoiDung.SelectedIndex = 0;
            }
            //Common.BoundComboBox(cbNguoiDung, EiBusinessImpl.DMNguoiDung(), "TenNguoiDung", "MaNguoiDung", "-- Chọn --", 0);
        }

        private void BoundGrid()
        {
            using (var ebi = new EiBusinessImpl())
            {
                _dtPhanQuyen = ebi.DmPhanQuyen();
                grid1.DataSource = _dtPhanQuyen;
            }
        }

        private void SetLuoi(bool bChon)
        {
            for (var i = 0; i <= (_dtPhanQuyen.Rows.Count - 1); i++)
            {
                _dtPhanQuyen.Rows[i]["Chon"] = bChon;
            }
        }

        private void SetControl(bool bSet)
        {
            CmdKetThuc.Enabled = bSet;
            CmdLuu.Enabled = bSet;
            CmdHuy.Enabled = bSet;
            chkAll.Enabled = bSet;
            grid1.Enabled = bSet;
        }
        private void cbNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            DocPhanQuyenRaLuoi();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                SetLuoi(true);
            }
            else
            {
                SetLuoi(false);
            }
        }

        private void CmdHuy_Click(object sender, EventArgs e)
        {
            DocPhanQuyenRaLuoi();
        }

        private void CmdKetThuc_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CmdLuu_Click(object sender, EventArgs e)
        {
            if (cbNguoiDung.SelectedValue.ToString() == "ADMIN")
            {
                MessageBox.Show("Không cần phân quyền cho ADMIN !", "Thông báo");
                DocPhanQuyenRaLuoi();
                return;
            }

            var quyenHan = "";
            for (var r = 0; r <= (_dtPhanQuyen.Rows.Count - 1); r++)
            {
                if (!Convert.ToBoolean(_dtPhanQuyen.Rows[r]["Chon"].ToString()))
                {
                    quyenHan = quyenHan + _dtPhanQuyen.Rows[r]["Muc"];
                }
            }
            if (quyenHan == "")
            {
                quyenHan = "*";
            }
            try
            {
                using (var ebi = new EiBusinessImpl())
                {
                    ebi.SetQuyenSd(cbNguoiDung.SelectedValue.ToString(), quyenHan);
                }
                showMessage("Lưu thành công", MessageType.Information);
            }
            catch (SqlException exception)
            {
                MessageBox.Show("Lỗi DB :" + exception.Message, "Lỗi [" + exception.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception exception2)
            {
                MessageBox.Show(exception2.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void DocPhanQuyenRaLuoi()
        {
            if (cbNguoiDung.SelectedIndex != 0)
            {
                bMaNguoiDung = cbNguoiDung.SelectedValue.ToString();
                using (var ebi = new EiBusinessImpl())
                {
                    var dt = ebi.GetDmNguoiDung(cbNguoiDung.SelectedValue.ToString());
                    var bQuyen = dt.Rows[0]["QuyenHan"].ToString();
                    DocRaLuoi(bQuyen);
                    switch (bQuyen)
                    {
                        case "*":
                            SetLuoi(true);
                            break;

                        case "-":
                            SetLuoi(false);
                            break;
                    }
                }
                SetControl(true);
            }
            else
            {
                SetControl(false);
            }
        }

        private void DocRaLuoi(string bQuyen)
        {
            SetLuoi(true);
            for (var i = bQuyen.Length; i >= 3; i = bQuyen.Length)
            {
                var str = bQuyen.Substring(0, 3);
                for (var j = 0; j <= (_dtPhanQuyen.Rows.Count - 1); j++)
                {
                    if (_dtPhanQuyen.Rows[j]["Muc"].ToString() == str)
                    {
                        _dtPhanQuyen.Rows[j]["Chon"] = false;
                        break;
                    }
                }
                bQuyen = bQuyen.Substring(3);
            }
        }
    }
}
