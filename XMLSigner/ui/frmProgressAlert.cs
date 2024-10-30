
namespace XMLSigner.ui
{
    public partial class frmProgressAlert : frmBase
    {
        public frmProgressAlert():base()
        {
            InitializeComponent();
        }

        #region PROPERTIES

        public string Message
        {
            set { label1.Text = value; }
        }

        public int ProgressValue
        {
            set { progressBar1.Value = value; }
        }

        #endregion
    }
}
