namespace XMLSigner.ui
{
    partial class frmRegisterSery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaKiHieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKiHieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeryDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeryCuoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeryGanNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSuDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiSua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMau = new System.Windows.Forms.TextBox();
            this.gbAdd = new System.Windows.Forms.GroupBox();
            this.ckbSudung = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTenKyHieu = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancelAdd = new System.Windows.Forms.Button();
            this.btnSaveAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSeryCuoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSeryDau = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbKihieu = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.gbAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(961, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::XMLSigner.Properties.Resources.add1;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 22);
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 25);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(961, 360);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMau,
            this.colMaKiHieu,
            this.colTenKiHieu,
            this.colSeryDau,
            this.colSeryCuoi,
            this.colSeryGanNhat,
            this.colSuDung,
            this.colNgayTao,
            this.colNguoiTao,
            this.colNguoiSua,
            this.colNgaySua});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView1.OptionsEditForm.EditFormColumnCount = 2;
            this.gridView1.OptionsEditForm.FormCaptionFormat = "Cập nhật mấu sery {MAU_SERY} - {MAKIHIEU}";
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 500;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView1_EditFormPrepared);
            this.gridView1.ShowingPopupEditForm += new DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventHandler(this.gridView1_ShowingPopupEditForm);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            // 
            // colMau
            // 
            this.colMau.Caption = "Mẫu số";
            this.colMau.FieldName = "MAU_SERY";
            this.colMau.Name = "colMau";
            this.colMau.OptionsColumn.AllowEdit = false;
            this.colMau.OptionsColumn.ReadOnly = true;
            this.colMau.Visible = true;
            this.colMau.VisibleIndex = 0;
            // 
            // colMaKiHieu
            // 
            this.colMaKiHieu.Caption = "Mã kí hiệu";
            this.colMaKiHieu.FieldName = "MAKIHIEU";
            this.colMaKiHieu.Name = "colMaKiHieu";
            this.colMaKiHieu.OptionsColumn.AllowEdit = false;
            this.colMaKiHieu.OptionsColumn.ReadOnly = true;
            this.colMaKiHieu.Visible = true;
            this.colMaKiHieu.VisibleIndex = 1;
            // 
            // colTenKiHieu
            // 
            this.colTenKiHieu.Caption = "Tên ký hiệu";
            this.colTenKiHieu.FieldName = "TENKIHIEU";
            this.colTenKiHieu.Name = "colTenKiHieu";
            this.colTenKiHieu.OptionsColumn.AllowEdit = false;
            this.colTenKiHieu.OptionsColumn.ReadOnly = true;
            this.colTenKiHieu.Visible = true;
            this.colTenKiHieu.VisibleIndex = 2;
            // 
            // colSeryDau
            // 
            this.colSeryDau.Caption = "Sery đầu";
            this.colSeryDau.FieldName = "SERY_DAU";
            this.colSeryDau.Name = "colSeryDau";
            this.colSeryDau.OptionsColumn.AllowEdit = false;
            this.colSeryDau.OptionsColumn.ReadOnly = true;
            this.colSeryDau.Visible = true;
            this.colSeryDau.VisibleIndex = 3;
            // 
            // colSeryCuoi
            // 
            this.colSeryCuoi.Caption = "Sery cuối";
            this.colSeryCuoi.FieldName = "SERY_CUOI";
            this.colSeryCuoi.Name = "colSeryCuoi";
            this.colSeryCuoi.Visible = true;
            this.colSeryCuoi.VisibleIndex = 4;
            // 
            // colSeryGanNhat
            // 
            this.colSeryGanNhat.Caption = "Sery gần nhất";
            this.colSeryGanNhat.FieldName = "SERY_GANNHAT";
            this.colSeryGanNhat.Name = "colSeryGanNhat";
            this.colSeryGanNhat.OptionsColumn.AllowEdit = false;
            this.colSeryGanNhat.OptionsColumn.ReadOnly = true;
            this.colSeryGanNhat.Visible = true;
            this.colSeryGanNhat.VisibleIndex = 5;
            // 
            // colSuDung
            // 
            this.colSuDung.Caption = "Đang dùng";
            this.colSuDung.FieldName = "SUDUNG";
            this.colSuDung.Name = "colSuDung";
            this.colSuDung.Visible = true;
            this.colSuDung.VisibleIndex = 6;
            // 
            // colNgayTao
            // 
            this.colNgayTao.Caption = "Ngày tạo";
            this.colNgayTao.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayTao.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayTao.FieldName = "NGAY_TAO";
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.OptionsColumn.AllowEdit = false;
            this.colNgayTao.OptionsColumn.ReadOnly = true;
            this.colNgayTao.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colNgayTao.Visible = true;
            this.colNgayTao.VisibleIndex = 8;
            // 
            // colNguoiTao
            // 
            this.colNguoiTao.Caption = "Người tạo";
            this.colNguoiTao.FieldName = "NGUOI_TAO";
            this.colNguoiTao.Name = "colNguoiTao";
            this.colNguoiTao.OptionsColumn.AllowEdit = false;
            this.colNguoiTao.OptionsColumn.ReadOnly = true;
            this.colNguoiTao.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colNguoiTao.Visible = true;
            this.colNguoiTao.VisibleIndex = 7;
            // 
            // colNguoiSua
            // 
            this.colNguoiSua.Caption = "Người sửa";
            this.colNguoiSua.FieldName = "NGUOI_SUA";
            this.colNguoiSua.Name = "colNguoiSua";
            this.colNguoiSua.OptionsColumn.AllowEdit = false;
            this.colNguoiSua.OptionsColumn.ReadOnly = true;
            this.colNguoiSua.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colNguoiSua.Visible = true;
            this.colNguoiSua.VisibleIndex = 9;
            // 
            // colNgaySua
            // 
            this.colNgaySua.Caption = "Ngày sửa";
            this.colNgaySua.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgaySua.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgaySua.FieldName = "NGAY_SUA";
            this.colNgaySua.Name = "colNgaySua";
            this.colNgaySua.OptionsColumn.AllowEdit = false;
            this.colNgaySua.OptionsColumn.ReadOnly = true;
            this.colNgaySua.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colNgaySua.Visible = true;
            this.colNgaySua.VisibleIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mẫu";
            // 
            // tbMau
            // 
            this.tbMau.Location = new System.Drawing.Point(82, 31);
            this.tbMau.MaxLength = 11;
            this.tbMau.Name = "tbMau";
            this.tbMau.Size = new System.Drawing.Size(213, 20);
            this.tbMau.TabIndex = 1;
            // 
            // gbAdd
            // 
            this.gbAdd.Controls.Add(this.ckbSudung);
            this.gbAdd.Controls.Add(this.label6);
            this.gbAdd.Controls.Add(this.label5);
            this.gbAdd.Controls.Add(this.tbTenKyHieu);
            this.gbAdd.Controls.Add(this.btnReset);
            this.gbAdd.Controls.Add(this.btnCancelAdd);
            this.gbAdd.Controls.Add(this.btnSaveAdd);
            this.gbAdd.Controls.Add(this.label4);
            this.gbAdd.Controls.Add(this.tbSeryCuoi);
            this.gbAdd.Controls.Add(this.label3);
            this.gbAdd.Controls.Add(this.tbSeryDau);
            this.gbAdd.Controls.Add(this.label2);
            this.gbAdd.Controls.Add(this.tbKihieu);
            this.gbAdd.Controls.Add(this.label1);
            this.gbAdd.Controls.Add(this.tbMau);
            this.gbAdd.ForeColor = System.Drawing.Color.Black;
            this.gbAdd.Location = new System.Drawing.Point(0, 391);
            this.gbAdd.Name = "gbAdd";
            this.gbAdd.Size = new System.Drawing.Size(961, 155);
            this.gbAdd.TabIndex = 5;
            this.gbAdd.TabStop = false;
            this.gbAdd.Text = "Thêm mới mẫu sery";
            this.gbAdd.Visible = false;
            // 
            // ckbSudung
            // 
            this.ckbSudung.AutoSize = true;
            this.ckbSudung.Checked = true;
            this.ckbSudung.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbSudung.Location = new System.Drawing.Point(718, 65);
            this.ckbSudung.Name = "ckbSudung";
            this.ckbSudung.Size = new System.Drawing.Size(15, 14);
            this.ckbSudung.TabIndex = 6;
            this.ckbSudung.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(661, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Sử dụng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(650, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tên kí hiệu";
            // 
            // tbTenKyHieu
            // 
            this.tbTenKyHieu.Location = new System.Drawing.Point(718, 31);
            this.tbTenKyHieu.MaxLength = 50;
            this.tbTenKyHieu.Name = "tbTenKyHieu";
            this.tbTenKyHieu.Size = new System.Drawing.Size(213, 20);
            this.tbTenKyHieu.TabIndex = 3;
            // 
            // btnReset
            // 
            this.btnReset.Image = global::XMLSigner.Properties.Resources.back;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReset.Location = new System.Drawing.Point(757, 126);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(93, 23);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Làm trống";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCancelAdd
            // 
            this.btnCancelAdd.Image = global::XMLSigner.Properties.Resources.remove1;
            this.btnCancelAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelAdd.Location = new System.Drawing.Point(856, 126);
            this.btnCancelAdd.Name = "btnCancelAdd";
            this.btnCancelAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCancelAdd.TabIndex = 12;
            this.btnCancelAdd.Text = "Đóng";
            this.btnCancelAdd.UseVisualStyleBackColor = true;
            this.btnCancelAdd.Click += new System.EventHandler(this.btnCancelAdd_Click);
            // 
            // btnSaveAdd
            // 
            this.btnSaveAdd.Image = global::XMLSigner.Properties.Resources.accept1;
            this.btnSaveAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSaveAdd.Location = new System.Drawing.Point(676, 126);
            this.btnSaveAdd.Name = "btnSaveAdd";
            this.btnSaveAdd.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAdd.TabIndex = 11;
            this.btnSaveAdd.Text = "Lưu";
            this.btnSaveAdd.UseVisualStyleBackColor = true;
            this.btnSaveAdd.Click += new System.EventHandler(this.btnSaveAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sery cuối";
            // 
            // tbSeryCuoi
            // 
            this.tbSeryCuoi.Location = new System.Drawing.Point(396, 66);
            this.tbSeryCuoi.MaxLength = 15;
            this.tbSeryCuoi.Name = "tbSeryCuoi";
            this.tbSeryCuoi.Size = new System.Drawing.Size(213, 20);
            this.tbSeryCuoi.TabIndex = 5;
            this.tbSeryCuoi.TextChanged += new System.EventHandler(this.tbSeryCuoi_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sery đầu";
            // 
            // tbSeryDau
            // 
            this.tbSeryDau.Location = new System.Drawing.Point(82, 66);
            this.tbSeryDau.MaxLength = 15;
            this.tbSeryDau.Name = "tbSeryDau";
            this.tbSeryDau.Size = new System.Drawing.Size(213, 20);
            this.tbSeryDau.TabIndex = 4;
            this.tbSeryDau.TextChanged += new System.EventHandler(this.tbSeryDau_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ký hiệu";
            // 
            // tbKihieu
            // 
            this.tbKihieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbKihieu.Location = new System.Drawing.Point(396, 31);
            this.tbKihieu.MaxLength = 11;
            this.tbKihieu.Name = "tbKihieu";
            this.tbKihieu.Size = new System.Drawing.Size(213, 20);
            this.tbKihieu.TabIndex = 2;
            this.tbKihieu.TextChanged += new System.EventHandler(this.tbKihieu_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRegisterSery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 550);
            this.Controls.Add(this.gbAdd);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "frmRegisterSery";
            this.Text = "Đăng ký sery hóa đơn";
            this.Load += new System.EventHandler(this.frmRegisterSery_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.gbAdd.ResumeLayout(false);
            this.gbAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMau;
        private System.Windows.Forms.GroupBox gbAdd;
        private System.Windows.Forms.Button btnCancelAdd;
        private System.Windows.Forms.Button btnSaveAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSeryCuoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSeryDau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbKihieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTenKyHieu;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox ckbSudung;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Columns.GridColumn colMau;
        private DevExpress.XtraGrid.Columns.GridColumn colMaKiHieu;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKiHieu;
        private DevExpress.XtraGrid.Columns.GridColumn colSeryDau;
        private DevExpress.XtraGrid.Columns.GridColumn colSeryCuoi;
        private DevExpress.XtraGrid.Columns.GridColumn colSeryGanNhat;
        private DevExpress.XtraGrid.Columns.GridColumn colSuDung;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayTao;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiTao;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySua;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiSua;

    }
}