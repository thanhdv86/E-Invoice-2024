using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cskh.domain;
using XMLSigner.data;

namespace XMLSigner
{
    public partial class SoHoaDonUC : UserControl
    {
        public string MauSery
        {
            get { return txtMAU_SERY.Text; }
        }
        public string Sohoadon
        {
            get { return tbSoHoaDon.Text; }
            set { tbSoHoaDon.Text = value; }
            
        }
        public string Kihieu
        {
            get { return cbKiHieu.SelectedValue.ToString(); }
        }
        public SoHoaDonUC()
        {
            InitializeComponent();
        }
        private void SoHoaDonUC_Load(object sender, EventArgs e)
        {
            using (var ebi = new EiBusinessImpl())
            {
                var dt = ebi.GetKihieuInUse();
                cbKiHieu.DataSource = dt;
                cbKiHieu.ValueMember = "MAKIHIEU";
                cbKiHieu.DisplayMember = "TENKIHIEU";
                txtMAU_SERY.Text = dt.Rows[0]["MAU_SERY"].ToString();
            }
        }
        private void btnGetHD_Click(object sender, EventArgs e)
        {
            if (cbKiHieu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mẫu kí hiệu sery!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var ei = new EiBusinessImpl())
            {
                string sohoadon = ei.GetStartInvoiceNum(cbKiHieu.SelectedValue.ToString());
                // neu khong con so hoa don nao chua su dung, proc tra ve -1
                if (sohoadon == "-1")
                {
                    MessageBox.Show("Các số sery trong mẫu sery "+cbKiHieu.Text+" đã được sử dụng hết. Vui lòng đăng ký thêm số sery để ký HĐ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else tbSoHoaDon.Text = sohoadon;
                OnSoHoaDonChanged(EventArgs.Empty);// put here so whenever we get sohd dau, so hd cuoi refreshed
            }
        }
        public event EventHandler SoHoaDonChanged;
        private void OnSoHoaDonChanged(EventArgs e)
        {
            if (this.SoHoaDonChanged != null)
                this.SoHoaDonChanged(this, e);
        }
        private void cbKiHieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tbSoHoaDon.Text = "";
            OnSoHoaDonChanged(EventArgs.Empty);
        }
        //private void tbSoHoaDon_TextChanged(object sender, EventArgs e)
        //{
        //    OnSoHoaDonChanged(EventArgs.Empty);
        //}
    }
}
