namespace XMLSigner.ui
{
    partial class frmCertificateMngt
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSignName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValidFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValidTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayThuHoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoSery = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiSua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.btnInstall = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 28);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(972, 405);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colSignName,
            this.colValidFrom,
            this.colValidTo,
            this.colNgayThuHoi,
            this.colSoSery,
            this.colNguoiTao,
            this.colNgayTao,
            this.colNguoiSua,
            this.colNgaySua});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsEditForm.EditFormColumnCount = 1;
            this.gridView1.OptionsEditForm.FormCaptionFormat = "Cập nhật ngày thu hồi chứng thư";
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 350;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.ShowingPopupEditForm += new DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventHandler(this.gridView1_ShowingPopupEditForm);
            // 
            // colId
            // 
            this.colId.Caption = "ID";
            this.colId.FieldName = "ID_KEY";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            // 
            // colSignName
            // 
            this.colSignName.Caption = "Tên người ký";
            this.colSignName.FieldName = "SIGN_NAME";
            this.colSignName.Name = "colSignName";
            this.colSignName.OptionsColumn.AllowEdit = false;
            this.colSignName.OptionsColumn.ReadOnly = true;
            this.colSignName.Visible = true;
            this.colSignName.VisibleIndex = 1;
            // 
            // colValidFrom
            // 
            this.colValidFrom.Caption = "Ngày hiệu lực";
            this.colValidFrom.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colValidFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colValidFrom.FieldName = "VALID_FROM";
            this.colValidFrom.Name = "colValidFrom";
            this.colValidFrom.OptionsColumn.AllowEdit = false;
            this.colValidFrom.OptionsColumn.ReadOnly = true;
            this.colValidFrom.Visible = true;
            this.colValidFrom.VisibleIndex = 2;
            // 
            // colValidTo
            // 
            this.colValidTo.Caption = "Ngày hết hạn";
            this.colValidTo.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colValidTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colValidTo.FieldName = "VALID_TO";
            this.colValidTo.Name = "colValidTo";
            this.colValidTo.OptionsColumn.AllowEdit = false;
            this.colValidTo.OptionsColumn.ReadOnly = true;
            this.colValidTo.Visible = true;
            this.colValidTo.VisibleIndex = 3;
            // 
            // colNgayThuHoi
            // 
            this.colNgayThuHoi.Caption = "Ngày thu hồi";
            this.colNgayThuHoi.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayThuHoi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayThuHoi.FieldName = "NGAY_THU_HOI";
            this.colNgayThuHoi.Name = "colNgayThuHoi";
            this.colNgayThuHoi.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colNgayThuHoi.Visible = true;
            this.colNgayThuHoi.VisibleIndex = 4;
            // 
            // colSoSery
            // 
            this.colSoSery.Caption = "Số sery";
            this.colSoSery.FieldName = "SERY_NUMBER";
            this.colSoSery.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colSoSery.Name = "colSoSery";
            this.colSoSery.OptionsColumn.AllowEdit = false;
            this.colSoSery.OptionsColumn.ReadOnly = true;
            this.colSoSery.Visible = true;
            this.colSoSery.VisibleIndex = 0;
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
            this.colNguoiTao.VisibleIndex = 5;
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
            this.colNgayTao.VisibleIndex = 6;
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
            this.colNguoiSua.VisibleIndex = 7;
            // 
            // colNgaySua
            // 
            this.colNgaySua.Caption = "Ngày sửa";
            this.colNgaySua.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.colNgaySua.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgaySua.FieldName = "NGAY_SUA";
            this.colNgaySua.Name = "colNgaySua";
            this.colNgaySua.OptionsColumn.AllowEdit = false;
            this.colNgaySua.OptionsColumn.ReadOnly = true;
            this.colNgaySua.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colNgaySua.Visible = true;
            this.colNgaySua.VisibleIndex = 8;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // btnInstall
            // 
            this.btnInstall.Image = global::XMLSigner.Properties.Resources.add;
            this.btnInstall.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnInstall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(64, 22);
            this.btnInstall.Text = "Cài đặt";
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = global::XMLSigner.Properties.Resources.remove;
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(47, 22);
            this.btnDel.Text = "Xóa";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInstall,
            this.btnDel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(996, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // frmCertificateMngt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 445);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmCertificateMngt";
            this.Text = "Đăng ký chứng thư số";
            this.Load += new System.EventHandler(this.frmCertificateMngt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSignName;
        private DevExpress.XtraGrid.Columns.GridColumn colValidFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colValidTo;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayThuHoi;
        private DevExpress.XtraGrid.Columns.GridColumn colSoSery;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiTao;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayTao;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiSua;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySua;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private System.Windows.Forms.ToolStripButton btnInstall;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}