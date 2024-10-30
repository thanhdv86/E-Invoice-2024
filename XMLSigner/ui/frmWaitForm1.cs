using System;
using DevExpress.XtraWaitForm;

namespace XMLSigner.ui
{
    public partial class frmWaitForm1 : WaitForm

    {
        public frmWaitForm1()
        {
            InitializeComponent();
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.ShowTitle = true;
            //this.label1.Text = description;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            //this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);            
            //this.progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            WaitFormCommand command = (WaitFormCommand)cmd;
            if (command == WaitFormCommand.SetProgress)
            {                
                progressBarControl1.EditValue = arg;
            }
            base.ProcessCommand(cmd, arg);
        }

        public void SetMoreDescription(string description)
        {
            this.label1.Text = description;
        }

        #endregion

       
        public enum WaitFormCommand
        {
            SetProgress
        }
    }
}