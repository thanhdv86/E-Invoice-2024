using System.Windows.Forms;
using DevExpress.XtraGrid.Localization;
using XMLSigner.util;
using System.Threading;
using System.Globalization;

namespace XMLSigner.ui
{
    public partial class frmBase : Form
    {
        public frmBase()
        {
            this.Icon = global::XMLSigner.Properties.Resources.hwcicon;
            GridLocalizer.Active = new XGridLocalizer();
            this.StartPosition = FormStartPosition.CenterScreen;            
            InitializeComponent();
        }

        protected enum MessageType { Error, Warning, Information, Other };
        protected void showMessage(string msg, MessageType type)
        {
            if (type == MessageType.Warning)
            {
                MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (type == MessageType.Error)
            {
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (type == MessageType.Information)
            {
                MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       
    }
}
