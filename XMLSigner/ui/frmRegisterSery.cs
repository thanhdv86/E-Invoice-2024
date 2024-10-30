using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using cskh.domain;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;
using DevExpress.XtraGrid.Views.Grid;
using XMLSigner.data;

namespace XMLSigner.ui
{
    public partial class frmRegisterSery : frmBase
    {
        private const int GridHeight = 350;
        private const int AddPanelHeight = 150;

        public frmRegisterSery()
        {
            InitializeComponent();
            HideAdd();
        }

        private void frmRegisterSery_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            using (var ebi = new EiBusinessImpl())
            {              
                gridControl1.DataSource = ebi.GetAllMauSery();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowAdd();
        }

   
        private void gridView1_ShowingPopupEditForm(object sender, DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs e)
        {
            bool sudung = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(Constants.KH_SUDUNG));
            foreach (Control control in e.EditForm.Controls)
            {

                if (control is EditFormContainer)
                {
                    foreach (Control nestedControl in control.Controls)
                    {
                        if (nestedControl is XtraScrollableControl)
                        {
                            
                            foreach (Control l3 in nestedControl.Controls)
                            {
                                if (l3 is TableLayoutPanel && !sudung) l3.Enabled = false;
                                else l3.Enabled = true;
                                foreach (Control l4 in l3.Controls)
                                {
                                    if (l4 is DateEdit)
                                    {
                                        DateEdit dedit = l4 as DateEdit;
                                        dedit.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
                                    }

                                }
                                //LabelControl lb = new LabelControl();
                                //lb.Text = "Nếu mẫu sery chuyển từ đang dùng sang không sử dụng nữa thì tất cả các số còn lại của mẫu sery sẽ bị hủy bỏ ";
                                //l3.Controls.Add(lb);
                            }
                        }
                        if (nestedControl is PanelControl)
                        {

                            foreach (Control button in nestedControl.Controls)
                            {

                                if (button is SimpleButton)
                                {
                                    var simpleButton = button as SimpleButton;
                                    if (simpleButton.Text == Constants.UPDATE_VN)
                                    {                                        
                                        simpleButton.Click += btnUpdate_Click;                                        
                                        if (!sudung)
                                        {
                                            simpleButton.Enabled = false;
                                        }
                                        else
                                        {
                                            simpleButton.Enabled = true;
                                        }
                                    }                                    
                                }
                            }
                        }

                    }
                }
            }

        }

        // update mau sery
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //if (!validateUpdate()) return;
            //else
            //{
            string mausery = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Constants.KH_MAU_SERY).ToString();
            string makihieu = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Constants.KH_MAKIHIEU).ToString();
            string tenkihieu = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Constants.KH_TENKIHIEU).ToString();
            bool sudung = Convert.ToBoolean(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Constants.KH_SUDUNG));
            string serycuoi = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Constants.KH_SERY_CUOI).ToString();
            string serygannhat = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Constants.KH_SERY_GANNHAT).ToString();

            /*
            int chuadung = Convert.ToInt32(serycuoi) - Convert.ToInt32(serygannhat);
            if (!sudung && chuadung > 0)
            {
                DialogResult res = MessageBox.Show(((SimpleButton)sender).Parent.Parent,"Mẫu sery " +mausery+ " còn số sery chưa sử dụng. Nếu ngưng sử dụng mẫu sery này các số hóa đơn chưa dùng sẽ bị hủy.\nBạn có muốn ngưng sử dụng mẫu sery "+mausery+"?","Xác nhận",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        using (HoaDonBusinessImpl hbi = new HoaDonBusinessImpl())
                        {

                            hbi.updateMauSery(makihieu, mausery, tenkihieu, sudung, serycuoi, frmSignIn.user.Username, DateTime.Now);
                            //showMessage("Cập nhật thành công thay đổi cho mã sery " + mausery + "-" + makihieu, MessageType.Information);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ((EditFormContainer)(((SimpleButton)sender).Parent.Parent)).Show();
                    }
                    catch (Exception ex)
                    {
                        showMessage(ex.Message, MessageType.Error);
                        ((EditFormContainer)(((SimpleButton)sender).Parent.Parent)).Show();
                    }
                }
                else if (res == DialogResult.Cancel)
                {
                    ((EditFormContainer)(((SimpleButton)sender).Parent.Parent)).Show();
                }
                else if (res == DialogResult.No)
                {
                    ((EditFormContainer)(((SimpleButton)sender).Parent.Parent)).Show();
                }
            }

            */
            try
            {
                using (var ebi = new EiBusinessImpl())
                {

                    ebi.UpdateMauSery(makihieu, mausery, tenkihieu, sudung, serycuoi, frmSignIn.user.Username, DateTime.Now);
                    //showMessage("Cập nhật thành công thay đổi cho mã sery " + mausery + "-" + makihieu, MessageType.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            catch (Exception ex)
            {
                showMessage(ex.Message, MessageType.Error);                
            }
            //}
        }

        // save add      
        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            if (!validateInsert()) return;
            try
            {
                using (var ebi = new EiBusinessImpl())
                {
                    var mausery = new MauSery(tbMau.Text.Trim(), tbKihieu.Text.Trim(), tbTenKyHieu.Text.Trim(), tbSeryDau.Text.Trim(), tbSeryCuoi.Text.Trim(), frmSignIn.user.Username, DateTime.Now, ckbSudung.Checked);
                    ebi.InsertMauSery(mausery);
                    showMessage("Tạo mới mẫu sery thành công!", MessageType.Information);
                    resetText();
                    BindGrid();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == Constants.ERR_UNIQUE_VIOLATE)
                {
                    MessageBox.Show("Mẫu sery đã được đăng ký.", "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show(ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // close add panel
        private void HideAdd()
        {
            gbAdd.Height = 0;
            gridControl1.Dock = DockStyle.Fill;
        }
        // show add panel
        private void ShowAdd()
        {
            gridControl1.Anchor = (AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right;
            gridControl1.Height = GridHeight;
            gbAdd.Height = AddPanelHeight;
            gbAdd.Show();
            tbMau.Focus();
        }

        // thoat add
        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            HideAdd();
        }

        // allow digit only
        private void tbSeryDau_TextChanged(object sender, EventArgs e)
        {
            var text = tbSeryDau.Text;
            bool hasDigit = false;
            foreach (char letter in text)
            {
                if (char.IsDigit(letter))
                {
                    hasDigit = true;
                    break;
                }
            }
            // Call SetError or Clear on the ErrorProvider.
            if (!hasDigit)
            {
                errorProvider1.SetError(tbSeryDau, "Vui lòng nhập số.");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        // allow digit only
        private void tbSeryCuoi_TextChanged(object sender, EventArgs e)
        {
            var text = tbSeryCuoi.Text;
            bool hasDigit = false;
            foreach (char letter in text)
            {
                if (char.IsDigit(letter))
                {
                    hasDigit = true;
                    break;
                }
            }
            // Call SetError or Clear on the ErrorProvider.
            if (!hasDigit)
            {
                errorProvider1.SetError(tbSeryCuoi, "Vui lòng nhập số.");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        // validate data before insert        
        private bool validateInsert()
        {
            if (string.IsNullOrEmpty(tbMau.Text))
            {
                showMessage("Vui lòng nhập mẫu số hóa đơn!", MessageType.Error);
                return false;
            }
            if (string.IsNullOrEmpty(tbKihieu.Text))
            {
                showMessage("Vui lòng nhập kí hiệu hóa đơn!", MessageType.Error);
                return false;
            }
            if (string.IsNullOrEmpty(tbTenKyHieu.Text))
            {
                showMessage("Vui lòng nhập tên kí hiệu hóa đơn!", MessageType.Error);
                return false;
            }
            if (string.IsNullOrEmpty(tbSeryDau.Text))
            {
                showMessage("Vui lòng nhập số sery đầu!", MessageType.Error);
                return false;
            }
            if (Convert.ToInt32(tbSeryDau.Text)==0)
            {
                showMessage("Sery đầu không thể là 0!", MessageType.Error);
                return false;
            }
            if (string.IsNullOrEmpty(tbSeryCuoi.Text))
            {
                showMessage("Vui lòng nhập số sery cuối!", MessageType.Error);
                return false;
            }
            if (tbSeryDau.Text.Trim().Length != tbSeryCuoi.Text.Trim().Length)
            {
                showMessage("Vui lòng nhập sery đầu và sery cuối có số chữ số bằng nhau!", MessageType.Error);
                return false;
            }
            try
            {
                var intSerydau = Convert.ToInt32(tbSeryDau.Text);
                var intSerycuoi = Convert.ToInt32(tbSeryCuoi.Text);
                if (intSerycuoi < intSerydau)
                {
                    showMessage("Vui lòng nhập số sery cuối lớn hơn hoặc bằng số sery đầu!", MessageType.Error);
                    return false;
                }
            }
            catch (Exception)
            {
                showMessage("Số sery hóa đơn không hợp lệ. Vui lòng kiểm tra lại!", MessageType.Error);
                return false;
            }
            return true;
        }

        // set default tenkyhieu based on typing makihieu
        private void tbKihieu_TextChanged(object sender, EventArgs e)
        {
            tbTenKyHieu.Text = tbKihieu.Text;
        }

        // reset controls in add panel
        private void resetText()
        {
            foreach (Control control in this.gbAdd.Controls)
            {
                if (control is TextBox && control.Name != "tbMau")
                {
                    var tb = (TextBox)control;
                    tb.ResetText();                    
                }
                if (control is CheckBox)
                {
                    var cb = (CheckBox)control;
                    cb.Checked = true;
                }
            }
            errorProvider1.Clear();
        }

        // click reset on add panel
        private void btnReset_Click(object sender, EventArgs e)
        {
            resetText();
        }

        // validate when update mau sery
        // user are allowed to update:
        // 1. So sery cuoi: >= so sery gan nhat
        // 2. Ten ky hieu
        // 3. Su dung
        // (unused)
        private bool validateUpdate()
        {
            try
            {
                var strSeryGannhat = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Constants.KH_SERY_GANNHAT).ToString().Trim();
                var strSeryCuoi = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Constants.KH_SERY_CUOI).ToString().Trim();
                var seryGannhat = Convert.ToInt32(strSeryGannhat);
                var seryCuoi = Convert.ToInt32(strSeryCuoi);
                if (strSeryGannhat.Length != strSeryCuoi.Length || seryCuoi < seryGannhat)
                {
                    showMessage("Số hóa đơn cuối không hợp lệ. Vui lòng kiểm tra lại!", MessageType.Error);
                    return false;
                }
            }
            catch (Exception)
            {
                showMessage("Số hóa đơn cuối không hợp lệ. Vui lòng kiểm tra lại!", MessageType.Error);
                return false;
            }
            return true;
        }

        // so sery cuoi duoc cap nhat khong the nho hon so sery cuoi cu
        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            var efe = (EditFormValidateEditorEventArgs)e;
            GridColumn col = efe.Column;
            if (col.Name != "colSeryCuoi") return;
            if (e.Value == null || e.Value.ToString().Trim() == "")
            {
                e.Valid = false;
                e.ErrorText = "Vui lòng nhập sery cuối";
                return;
            }
            int oldSerycuoi = Convert.ToInt32(gridView1.GetFocusedRowCellValue(col).ToString());
            int newSerycuoi = Convert.ToInt32(e.Value.ToString());

            if (newSerycuoi < oldSerycuoi)
            {
                e.Valid = false;
                e.ErrorText = "Vui lòng nhập sô sery cuối lớn hơn số sery cuối cũ";
            }
           
        }

        // khong thay duoc goi
        private void gridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "here";
            e.ErrorText = "";
            // Destroying the editor and discarding the changes made within the edited cell
            gridView1.HideEditor();
        }

        // validate row before update
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            
            var view = sender as GridView;
            var seryGannhat = view.Columns[Constants.KH_SERY_GANNHAT];
            var seryCuoi = view.Columns[Constants.KH_SERY_CUOI];
            var seryDau = view.Columns[Constants.KH_SERY_DAU];
            
            var strSeryGannhat = view.GetRowCellValue(e.RowHandle, seryGannhat).ToString();
            var strSeryCuoi = view.GetRowCellValue(e.RowHandle, seryCuoi).ToString();
            var strSeryDau = view.GetRowCellValue(e.RowHandle, seryDau).ToString();

            if (strSeryCuoi.Trim().Length != strSeryDau.Trim().Length)
            {
                e.Valid = false;
                view.SetColumnError(seryCuoi,"Độ dài của các số sery phải bằng nhau.");
                showMessage("Độ dài của các số sery phải bằng nhau.",MessageType.Information);
            }


            try
            {
                //Get the value of the first column
                var intSeryGannhat = Convert.ToInt32(strSeryGannhat);
                //Get the value of the second column
                var intSeryCuoi = Convert.ToInt32(strSeryCuoi);
                //Validity criterion
                if (intSeryGannhat > intSeryCuoi)
                {
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns                
                    view.SetColumnError(seryCuoi, "Số sery cuối phải lớn hơn hoặc bẳng số sery gần nhất.");
                }
                
            }catch (Exception){
                e.Valid = false;
                //Set errors with specific descriptions for the columns                
                view.SetColumnError(seryCuoi, "Số sery cuối không hợp lệ.");
            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;

        }

        private void gridView1_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

    }
}
