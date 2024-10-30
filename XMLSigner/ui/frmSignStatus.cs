using System;
using System.Data;
using System.Windows.Forms;
using cskh.domain;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;
using XMLSigner.data;

namespace XMLSigner.ui
{
    public partial class frmSignStatus : frmBase
    {
        public frmSignStatus()
        {
            InitializeComponent();
            InitExportData();

            //bindKV(); // mac dinh la chon tat ca chi nhanh
            //bindKy(); // mac dinh la ky hien tai
            SignUtil.BindKv(cbKV, "Tất cả", "%");
            SignUtil.BindKy(cbKy, tbNam);
        }

        //private void bindKV()
        //{
        //    using (var ebi = new CrBusinessImpl())
        //    {
        //        var dt = ebi.GetKv();
        //        var dr = dt.NewRow();
        //        dr["MAKV"] = "%";
        //        dr["TENKV"] = "Tất cả";
        //        dt.Rows.InsertAt(dr, 0);
        //        cbKV.DataSource = dt;
        //        cbKV.ValueMember = "MAKV";
        //        cbKV.DisplayMember = "TENKV";
        //        cbKV.SelectedIndex = 0;
        //    }
        //}

        //// bind ky, nam textbox la ky hien tai
        //private void bindKy()
        //{
        //    using (var cr = new CrBusinessImpl())
        //    {
        //        var dt = cr.GetKyHd();
        //        cbKy.SelectedIndex = Convert.ToInt16(dt.Rows[0]["THANG"].ToString());
        //        tbNam.Text = dt.Rows[0]["NAM"].ToString();
        //    }
        //}

        void InitExportData()
        {
            for (int i = 0; i < exportData.GetLength(0); i++)
                cbExport.Properties.Items.Add(exportData.GetValue(i, 0));
            cbExport.SelectedIndex = 0;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cbKy.SelectedIndex == 0)
            {
                showMessage("Vui lòng chọn kỳ!", MessageType.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbNam.Text))
            {
                showMessage("Vui lòng chọn năm!", MessageType.Error);
                return;
            }
            if (cbKV.SelectedValue == null)
            {
                showMessage("Vui lòng chọn chi nhánh!", MessageType.Error);
                return;
            }
            string khuvuc = cbKV.SelectedValue.ToString();
            int ky = cbKy.SelectedIndex;
            int nam = Convert.ToInt16(tbNam.Text);
            SplashScreenManager.ShowForm(this, typeof(frmBaseWaitform));
            using (var cri = new CrBusinessImpl())
            {
                var dt1 = cri.getCountHD_byKV(khuvuc, ky, nam);

                using (var ebi = new EiBusinessImpl())
                {
                    var dt2 = ebi.getCountKyHuy_ByKy(nam, ky);
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        var dtResult = DataTableHelper.JoinTwoDataTablesOnOneColumn(dt1, dt2, "MADP", DataTableHelper.JoinType.Left);
                        dtResult.Columns.Add("SOHDCON", typeof(int), "SOHD - SOHDKY - SOHDHUY");
                        gridControl1.DataSource = dtResult;
                    }
                }
            }
            SplashScreenManager.CloseForm(false);
        }



        private void OpenFile(string fileName)
        {
            if (XtraMessageBox.Show("Bạn có muốn mở tệp bây giờ?", "Export To...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, "Không tìm thấy ứng dụng được cài đặt trên máy để mở tệp.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void ExportToEx(String filename, string ext, BaseView exportView)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            if (ext == "rtf") exportView.ExportToRtf(filename);
            if (ext == "pdf") exportView.ExportToPdf(filename);
            if (ext == "mht") exportView.ExportToMht(filename);
            if (ext == "htm") exportView.ExportToHtml(filename);
            if (ext == "txt") exportView.ExportToText(filename);
            if (ext == "xls") exportView.ExportToXls(filename);
            if (ext == "xlsx") exportView.ExportToXlsx(filename);
            Cursor.Current = currentCursor;
        }
        private string ShowSaveFileDialog(string title, string filter)
        {
            int ky = cbKy.SelectedIndex;
            int nam = Convert.ToInt16(tbNam.Text);
            string kv = cbKV.Text.ToString();
            SaveFileDialog dlg = new SaveFileDialog();
            string name = kv + "_ky" + ky + "_nam" + nam;
            int n = name.LastIndexOf(".") + 1;
            if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = "Export To " + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }

        string[,] exportData = new string[,] {{"HTML Document", "HTML Documents|*.html", "htm"}, 
            {"Microsoft Excel 2007 Document", "Microsoft Excel|*.xlsx", "xlsx"}, 
            {"Microsoft Excel Document", "Microsoft Excel|*.xls", "xls"}, 
            {"RTF Document", "RTF Files|*.rtf", "rtf"},
            {"PDF Document", "PDF Files|*.pdf", "pdf"},
            {"MHT Document", "MHT Files|*.mht", "mht"},
            {"Text Document", "Text Files|*.txt", "txt"}};

        private void sbExport_Click(object sender, EventArgs e)
        {
            int index = cbExport.SelectedIndex;
            if (index < 0) return;
            string fileName = ShowSaveFileDialog(exportData.GetValue(index, 0).ToString(), exportData.GetValue(index, 1).ToString());
            if (fileName == string.Empty) return;
            ExportToEx(fileName, exportData.GetValue(index, 2).ToString(), bandedGridView1);
            OpenFile(fileName);
        }
    }
}
