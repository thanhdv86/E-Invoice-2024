using System.Threading;
using System.Globalization;

namespace XMLSigner.ui
{
    partial class frmCancelResign
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
            this.btnXem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.row4 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbThucHien = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNoidung = new System.Windows.Forms.TextBox();
            this.btnDo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLyDoKhac = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbThaoTac = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLyDo = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grCtrlResults = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ctInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKyHieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clSoHoaDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClDatePublished = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTransactionUuid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numRowPerPage = new System.Windows.Forms.NumericUpDown();
            this.lbCurentPage = new System.Windows.Forms.Label();
            this.btnSaveInvoince = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbThucHien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grCtrlResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRowPerPage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXem
            // 
            this.btnXem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXem.Location = new System.Drawing.Point(821, 27);
            this.btnXem.Margin = new System.Windows.Forms.Padding(4);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(100, 26);
            this.btnXem.TabIndex = 3;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Đến ngày";
            // 
            // row4
            // 
            this.row4.Name = "row4";
            this.row4.Properties.Caption = "Mã ĐP";
            this.row4.Properties.FieldName = "MADP";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpDenNgay);
            this.groupBox1.Controls.Add(this.dtpTuNgay);
            this.groupBox1.Controls.Add(this.txtInvoiceNo);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1069, 79);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn thông tin để trích lọc hóa đơn";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(380, 31);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(140, 22);
            this.dtpDenNgay.TabIndex = 23;
            this.dtpDenNgay.Value = new System.DateTime(2022, 7, 10, 0, 0, 0, 0);
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(113, 31);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(140, 22);
            this.dtpTuNgay.TabIndex = 22;
            this.dtpTuNgay.Value = new System.DateTime(2022, 7, 10, 0, 0, 0, 0);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Location = new System.Drawing.Point(631, 31);
            this.txtInvoiceNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(130, 22);
            this.txtInvoiceNo.TabIndex = 12;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::XMLSigner.Properties.Resources.search1;
            this.btnSearch.Location = new System.Drawing.Point(1007, 22);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(43, 39);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Từ ngày";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(537, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Số hóa đơn";
            // 
            // gbThucHien
            // 
            this.gbThucHien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbThucHien.Controls.Add(this.label8);
            this.gbThucHien.Controls.Add(this.tbNoidung);
            this.gbThucHien.Controls.Add(this.btnDo);
            this.gbThucHien.Controls.Add(this.label4);
            this.gbThucHien.Controls.Add(this.tbLyDoKhac);
            this.gbThucHien.Controls.Add(this.label5);
            this.gbThucHien.Controls.Add(this.cbThaoTac);
            this.gbThucHien.Controls.Add(this.label3);
            this.gbThucHien.Controls.Add(this.cbLyDo);
            this.gbThucHien.Location = new System.Drawing.Point(16, 524);
            this.gbThucHien.Margin = new System.Windows.Forms.Padding(4);
            this.gbThucHien.Name = "gbThucHien";
            this.gbThucHien.Padding = new System.Windows.Forms.Padding(4);
            this.gbThucHien.Size = new System.Drawing.Size(1069, 254);
            this.gbThucHien.TabIndex = 16;
            this.gbThucHien.TabStop = false;
            this.gbThucHien.Text = "Hủy bỏ -Thay thế hóa đơn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 189);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Nội dung:";
            // 
            // tbNoidung
            // 
            this.tbNoidung.Location = new System.Drawing.Point(115, 184);
            this.tbNoidung.Margin = new System.Windows.Forms.Padding(4);
            this.tbNoidung.MaxLength = 150;
            this.tbNoidung.Name = "tbNoidung";
            this.tbNoidung.ReadOnly = true;
            this.tbNoidung.Size = new System.Drawing.Size(916, 22);
            this.tbNoidung.TabIndex = 21;
            // 
            // btnDo
            // 
            this.btnDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDo.Image = global::XMLSigner.Properties.Resources.pencil_red_16;
            this.btnDo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDo.Location = new System.Drawing.Point(905, 215);
            this.btnDo.Margin = new System.Windows.Forms.Padding(4);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(125, 28);
            this.btnDo.TabIndex = 9;
            this.btnDo.Text = "Thực hiện";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Lý do khác";
            // 
            // tbLyDoKhac
            // 
            this.tbLyDoKhac.Location = new System.Drawing.Point(113, 150);
            this.tbLyDoKhac.Margin = new System.Windows.Forms.Padding(4);
            this.tbLyDoKhac.MaxLength = 150;
            this.tbLyDoKhac.Name = "tbLyDoKhac";
            this.tbLyDoKhac.Size = new System.Drawing.Size(916, 22);
            this.tbLyDoKhac.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Thao tác";
            // 
            // cbThaoTac
            // 
            this.cbThaoTac.FormattingEnabled = true;
            this.cbThaoTac.Location = new System.Drawing.Point(113, 38);
            this.cbThaoTac.Margin = new System.Windows.Forms.Padding(4);
            this.cbThaoTac.Name = "cbThaoTac";
            this.cbThaoTac.Size = new System.Drawing.Size(339, 24);
            this.cbThaoTac.TabIndex = 5;
            this.cbThaoTac.SelectedIndexChanged += new System.EventHandler(this.cbThaoTac_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Lý do";
            // 
            // cbLyDo
            // 
            this.cbLyDo.FormattingEnabled = true;
            this.cbLyDo.Location = new System.Drawing.Point(113, 95);
            this.cbLyDo.Margin = new System.Windows.Forms.Padding(4);
            this.cbLyDo.Name = "cbLyDo";
            this.cbLyDo.Size = new System.Drawing.Size(339, 24);
            this.cbLyDo.TabIndex = 6;
            this.cbLyDo.SelectedIndexChanged += new System.EventHandler(this.cbLyDo_SelectedIndexChanged);
            // 
            // grCtrlResults
            // 
            this.grCtrlResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grCtrlResults.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grCtrlResults.Location = new System.Drawing.Point(16, 101);
            this.grCtrlResults.MainView = this.gridView1;
            this.grCtrlResults.Margin = new System.Windows.Forms.Padding(4);
            this.grCtrlResults.Name = "grCtrlResults";
            this.grCtrlResults.Size = new System.Drawing.Size(1069, 363);
            this.grCtrlResults.TabIndex = 17;
            this.grCtrlResults.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clTen,
            this.ctInvoiceNo,
            this.clmau,
            this.clKyHieu,
            this.clSoHoaDon,
            this.ClDatePublished,
            this.clTransactionUuid});
            this.gridView1.GridControl = this.grCtrlResults;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // clTen
            // 
            this.clTen.Caption = "Tên khách hàng";
            this.clTen.FieldName = "CustomerName";
            this.clTen.Name = "clTen";
            this.clTen.OptionsColumn.AllowEdit = false;
            this.clTen.Visible = true;
            this.clTen.VisibleIndex = 1;
            // 
            // ctInvoiceNo
            // 
            this.ctInvoiceNo.Caption = "Ký hiệu số hóa đơn";
            this.ctInvoiceNo.FieldName = "InvoiceNo";
            this.ctInvoiceNo.Name = "ctInvoiceNo";
            this.ctInvoiceNo.OptionsColumn.AllowEdit = false;
            this.ctInvoiceNo.Visible = true;
            this.ctInvoiceNo.VisibleIndex = 2;
            // 
            // clmau
            // 
            this.clmau.Caption = "Mẫu";
            this.clmau.CustomizationCaption = "Mẫu";
            this.clmau.FieldName = "invoiceType";
            this.clmau.Name = "clmau";
            this.clmau.OptionsColumn.AllowEdit = false;
            this.clmau.Visible = true;
            this.clmau.VisibleIndex = 3;
            // 
            // clKyHieu
            // 
            this.clKyHieu.Caption = "Ký hiệu";
            this.clKyHieu.CustomizationCaption = "Ký hiệu";
            this.clKyHieu.FieldName = "invoiceSeries";
            this.clKyHieu.Name = "clKyHieu";
            this.clKyHieu.OptionsColumn.AllowEdit = false;
            this.clKyHieu.Visible = true;
            this.clKyHieu.VisibleIndex = 4;
            // 
            // clSoHoaDon
            // 
            this.clSoHoaDon.Caption = "Số hóa đơn";
            this.clSoHoaDon.FieldName = "invoiceNumber";
            this.clSoHoaDon.Name = "clSoHoaDon";
            this.clSoHoaDon.Visible = true;
            this.clSoHoaDon.VisibleIndex = 5;
            // 
            // ClDatePublished
            // 
            this.ClDatePublished.Caption = "Ngày phát hành HD";
            this.ClDatePublished.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ClDatePublished.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ClDatePublished.FieldName = "DatePublished";
            this.ClDatePublished.Name = "ClDatePublished";
            this.ClDatePublished.OptionsColumn.AllowEdit = false;
            this.ClDatePublished.Visible = true;
            this.ClDatePublished.VisibleIndex = 6;
            // 
            // clTransactionUuid
            // 
            this.clTransactionUuid.Caption = "transactionUuid";
            this.clTransactionUuid.FieldName = "transactionUuid";
            this.clTransactionUuid.Name = "clTransactionUuid";
            this.clTransactionUuid.OptionsColumn.AllowEdit = false;
            this.clTransactionUuid.Visible = true;
            this.clTransactionUuid.VisibleIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.numRowPerPage);
            this.groupBox2.Controls.Add(this.lbCurentPage);
            this.groupBox2.Controls.Add(this.btnSaveInvoince);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnNext);
            this.groupBox2.Controls.Add(this.btnPrev);
            this.groupBox2.Location = new System.Drawing.Point(16, 471);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1069, 46);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // numRowPerPage
            // 
            this.numRowPerPage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numRowPerPage.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRowPerPage.Location = new System.Drawing.Point(311, 12);
            this.numRowPerPage.Margin = new System.Windows.Forms.Padding(4);
            this.numRowPerPage.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numRowPerPage.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numRowPerPage.Name = "numRowPerPage";
            this.numRowPerPage.Size = new System.Drawing.Size(89, 22);
            this.numRowPerPage.TabIndex = 21;
            this.numRowPerPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRowPerPage.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numRowPerPage.ValueChanged += new System.EventHandler(this.numRowPerPage_ValueChanged);
            // 
            // lbCurentPage
            // 
            this.lbCurentPage.AutoSize = true;
            this.lbCurentPage.Location = new System.Drawing.Point(128, 16);
            this.lbCurentPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCurentPage.Name = "lbCurentPage";
            this.lbCurentPage.Size = new System.Drawing.Size(16, 17);
            this.lbCurentPage.TabIndex = 13;
            this.lbCurentPage.Text = "0";
            // 
            // btnSaveInvoince
            // 
            this.btnSaveInvoince.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveInvoince.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveInvoince.Location = new System.Drawing.Point(840, 16);
            this.btnSaveInvoince.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveInvoince.Name = "btnSaveInvoince";
            this.btnSaveInvoince.Size = new System.Drawing.Size(221, 26);
            this.btnSaveInvoince.TabIndex = 11;
            this.btnSaveInvoince.Text = "Lưu thông tin số hóa đơn";
            this.btnSaveInvoince.UseVisualStyleBackColor = true;
            this.btnSaveInvoince.Click += new System.EventHandler(this.btnSaveInvoince_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(408, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "dòng/ trang";
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(163, 12);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 26);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = "Trang tiếp theo";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Enabled = false;
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.Location = new System.Drawing.Point(8, 12);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(100, 26);
            this.btnPrev.TabIndex = 12;
            this.btnPrev.Text = "Trang trước";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // frmCancelResign
            // 
            this.AcceptButton = this.btnXem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 783);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbThucHien);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grCtrlResults);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmCancelResign";
            this.Text = "Hủy - Thay thế hóa đơn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCancelResign_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbThucHien.ResumeLayout(false);
            this.gbThucHien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grCtrlResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRowPerPage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbThucHien;
        private System.Windows.Forms.ComboBox cbLyDo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLyDoKhac;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbThaoTac;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.XtraGrid.GridControl grCtrlResults;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clTen;
        private DevExpress.XtraGrid.Columns.GridColumn ctInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn clmau;
        private DevExpress.XtraGrid.Columns.GridColumn clKyHieu;
        private DevExpress.XtraGrid.Columns.GridColumn ClDatePublished;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbCurentPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private DevExpress.XtraGrid.Columns.GridColumn clTransactionUuid;
        private System.Windows.Forms.Button btnSaveInvoince;
        private System.Windows.Forms.NumericUpDown numRowPerPage;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.Columns.GridColumn clSoHoaDon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbNoidung;

    }
}