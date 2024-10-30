using System;
using System.Data;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using cskh.domain;
using XMLSigner.util;

namespace XMLSigner.ui
{
    public partial class frmInvoiceSigner : Form
    {
        DataTable _dt;

        public frmInvoiceSigner()
        {
            InitializeComponent();

        }

        private void frmInvoiceSigner_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 1)
            {
                string idkh = dataGridView1.SelectedRows[0].Cells[Constants.IDKH].Value.ToString();
                int nam = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[Constants.NAM].Value.ToString());
                int thang = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[Constants.THANG].Value.ToString());
                MessageBox.Show("Xem nội dung hóa đơn khách hàng:" + idkh + "- năm:" + nam + "- kỳ:" + thang);
                string xmlcontent = null;
                using (var hdb = new EiBusinessImpl())
                {
                    byte[] xmlData = hdb.GetHoaDonXml(idkh, thang, nam);
                    if (xmlData == null)
                    {
                        MessageBox.Show("Tệp hóa đơn chưa được tạo. Vui lòng ký hóa đơn trước.");
                        return;
                    }
                    xmlcontent = Encoding.UTF8.GetString(xmlData);
                }

                treeXml.Nodes.Clear();
                var doc = new XmlDocument();
                doc.LoadXml(xmlcontent);
                XmlTreeDisplay.ConvertXmlNodeToTreeNode(doc, treeXml.Nodes);
                treeXml.Nodes[0].ExpandAll();
                textBox1.Text = xmlcontent;
            }
            else
            {
                MessageBox.Show("Hãy chọn một hóa đơn để xem nội dung!");
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                // Displays a SaveFileDialog 
                var saveFileDialog1 = new SaveFileDialog {Filter = "XML|*.xml", Title = "Ghi hóa đơn đã ký ra file"};
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    var idkh = dataGridView1.SelectedRows[0].Cells[Constants.IDKH].Value.ToString();
                    var nam = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[Constants.NAM].Value.ToString());
                    var thang = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[Constants.THANG].Value.ToString());

                    string xmlcontent;
                    using (var ebi = new EiBusinessImpl())
                    {
                        var xmlData = ebi.GetHoaDonXml(idkh, thang, nam);
                        if (xmlData == null)
                        {
                            MessageBox.Show("Tệp hóa đơn chưa được tạo. Vui lòng ký hóa đơn trước.");
                        }
                        xmlcontent = Encoding.UTF8.GetString(xmlData);
                    }

                    var doc = new XmlDocument();
                    doc.LoadXml(xmlcontent);
                    var xmltw = new XmlTextWriter(saveFileDialog1.FileName, new UTF8Encoding(true));
                    doc.WriteTo(xmltw);
                    xmltw.Close();
                    MessageBox.Show("File hóa đơn lưu thành công trên " + saveFileDialog1.FileName);
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một hóa đơn để ghi ra file!");
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            var frmVerify = new frmXMLSigner();
            frmVerify.Show();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            var store = new X509Store(StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            var certCollection = X509Certificate2UI.SelectFromCollection(store.Certificates, "Personal", "Store all installed certificate for current user.", X509SelectionFlag.SingleSelection);//(store.Certificates, null, null, X509SelectionFlag.SingleSelection);

            if (certCollection == null || certCollection.Count == 0)
            {
                return;
            }
            var certificate = certCollection[0];

            var privateKey = certificate.PrivateKey as RSACryptoServiceProvider;
            foreach (DataRow dr in _dt.Rows)
            {
                var idkh = dr[Constants.IDKH].ToString();
                var thang = Convert.ToInt32(dr[Constants.THANG]);
                var nam = Convert.ToInt32(dr[Constants.NAM]);
                var hd = new EI(idkh, thang, nam);
                XmlDocument xmlHd = hd.CreateHoaDonXml(certificate);
                XmlDocument xmlHdSigned = SignUtil.SignXmlFile(xmlHd, privateKey);
                byte[] bytesData = Encoding.UTF8.GetBytes(xmlHdSigned.OuterXml);
                using (var ebi = new EiBusinessImpl())
                {
                    ebi.UpdateHoaDonXml(idkh, thang, nam, bytesData);
                }
            }
            MessageBox.Show("Ký hoàn tất!");
        }

        private void btnSign2_Click(object sender, EventArgs e)
        {
            if (!IsAllHoadonUnsigned())
            {
                MessageBox.Show("Vui lòng bỏ chọn các hóa đơn đã được ký!");
                return;
            }

            var store = new X509Store(StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection certCollection = X509Certificate2UI.SelectFromCollection(store.Certificates, "Personal", "Store all installed certificate for current user.", X509SelectionFlag.SingleSelection);//(store.Certificates, null, null, X509SelectionFlag.SingleSelection);

            if (certCollection == null || certCollection.Count == 0)
            {
                return;
            }
            var certificate = certCollection[0];
            var privateKey = certificate.PrivateKey as RSACryptoServiceProvider;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                var isSelected = Convert.ToBoolean(dr.Cells["colCheck"].Value);
                if (isSelected)
                {
                    var idkh = dr.Cells[Constants.IDKH].Value.ToString();
                    var thang = Convert.ToInt32(dr.Cells[Constants.THANG].Value);
                    var nam = Convert.ToInt32(dr.Cells[Constants.NAM].Value);
                    var hd = new EI(idkh, thang, nam);
                    XmlDocument xmlHd = hd.CreateHoaDonXml(certificate);
                    XmlDocument xmlHdSigned = SignUtil.SignXmlFile(xmlHd, privateKey);
                    byte[] bytesData = Encoding.UTF8.GetBytes(xmlHdSigned.OuterXml);
                    using (var ebi = new EiBusinessImpl())
                    {
                        ebi.UpdateHoaDonXml(idkh, thang, nam, bytesData);
                    }
                }
            }

            MessageBox.Show("Ký hoàn tất!");
            BindGrid();
        }

        private bool IsAllHoadonUnsigned()
        {
            for (var i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                var row = dataGridView1.Rows[i];
                var isSelected = Convert.ToBoolean(row.Cells["colCheck"].Value);
                var signedFlag = Convert.ToInt32(row.Cells["issigned"].Value.ToString());
                if (signedFlag == 1 && isSelected) return false;
            }
            return true;
        }

        private void BindGrid()
        {
            using (var ebi = new EiBusinessImpl())
            {
                _dt = ebi.GetListHoaDon();
                dataGridView1.DataSource = _dt;
            }
        }

    }
}
