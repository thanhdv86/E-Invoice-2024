using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using cskh.domain;
using DevExpress.XtraSplashScreen;
using XMLSigner.data;

namespace XMLSigner.ui
{
    public partial class frmSearchInvoice : frmBase
    {
        private Form callingForm;

        public frmSearchInvoice(Form callingForm)
        {
            InitializeComponent();
            this.callingForm = callingForm;
            if (this.callingForm is frmMain)
            {
                btnChon.Visible = false;
            }
        }

        private void frmSearchInvoice_Load(object sender, EventArgs e)
        {
            bindMaDp();
            cbKy.SelectedIndex = 0;
        }

        private void bindMaDp()
        {
            try
            {
                using (var cbi = new CrBusinessImpl())
                {
                    var dt = cbi.GetDsDuongPho("%");
                    cbMaDP.DataSource = dt;
                    cbMaDP.DisplayMember = Constants.DP_TENDP;
                    cbMaDP.ValueMember = Constants.DP_MADP;

                    var dr = dt.NewRow();
                    dr[Constants.DP_TENDP] = "Tất cả";
                    dr[Constants.DP_MADP] = null;

                    dt.Rows.InsertAt(dr, 0);
                    cbMaDP.SelectedIndex = 0;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi DB:" + ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (EiBusinessImpl hbi = new EiBusinessImpl())
                {
                    string kh = String.IsNullOrEmpty(tbKH.Text) ? null : tbKH.Text;
                    int? thang,nam;                    
                    if (cbKy.SelectedItem == null || cbKy.Text == "Tất cả") 
                    {
                        thang = null;
                    }
                    else {
                        thang = Convert.ToInt16(cbKy.Text);
                    }
                    if ( String.IsNullOrEmpty(tbNam.Text))
                    {
                        nam = null;
                    }else{
                        nam = Convert.ToInt16(tbNam.Text);
                    }
                    string madp = (cbMaDP.SelectedItem == null || cbMaDP.Text == "Tất cả") ? null : cbMaDP.SelectedValue.ToString();                    
                    SplashScreenManager.ShowForm(this, typeof(frmBaseWaitform));
                    var dt = hbi.SearchHoaDon(kh, madp, thang, nam);
                    SplashScreenManager.CloseForm(false);                    
                    gridControl1.DataSource = dt;                    
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi DB:" + ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            selectAndFinish();            
        }


        
        private void selectAndFinish()
        {         
            if (callingForm is frmCancelResign)
            {
                if (gridView1.GetSelectedRows().Length <= 0)
                {
                    showMessage("Chưa chọn hóa đơn!",MessageType.Error);
                    return;
                }
                ((frmCancelResign)callingForm).LoadHoaDon(gridView1.GetFocusedRowCellValue(Constants.KIHIEUHOADON).ToString(),
                    gridView1.GetFocusedRowCellValue(Constants.SOHOADON).ToString());
                this.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount != 1)
            {
                showMessage("Vui lòng chọn một hóa đơn để lưu!", MessageType.Error);
                return;
            }
            string idkh = gridView1.GetFocusedRowCellValue(Constants.IDKH).ToString();
            int ky = Convert.ToInt16(gridView1.GetFocusedRowCellValue(Constants.KY).ToString());
            int nam = Convert.ToInt16(gridView1.GetFocusedRowCellValue(Constants.NAM).ToString());
            // Displays a SaveFileDialog 
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "KH"+idkh+"_Ky"+ky+"_Nam"+nam;
            saveFileDialog1.Filter = "XML|*.xml";
            saveFileDialog1.Title = "Ghi hóa đơn đã ký ra file";
            DialogResult result = saveFileDialog1.ShowDialog();            


            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "" && result == DialogResult.OK)
            {

                using (EiBusinessImpl hdb = new EiBusinessImpl())
                {
                    byte[] xmlData = hdb.GetHoaDonXml(idkh,ky,nam);
                    if (xmlData == null)
                    {
                        showMessage("Tệp hóa đơn chưa được tạo. Vui lòng ký hóa đơn trước.", MessageType.Error);
                    }
                    SignUtil.XmlstringToFile(saveFileDialog1.FileName,SignUtil.ByteArrayToString(xmlData));
                    showMessage("Tệp hóa đơn lưu thành công trên " + saveFileDialog1.FileName, MessageType.Information);
                }
            }
        }
    }
}
