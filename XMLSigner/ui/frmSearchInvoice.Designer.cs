
﻿namespace XMLSigner.ui
{
    partial class frmSearchInvoice
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
            this.tbKH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaDp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMauHoaDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoHoaDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLanKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbKy = new System.Windows.Forms.ComboBox();
            this.tbNam = new System.Windows.Forms.MaskedTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbMaDP = new System.Windows.Forms.ComboBox();
            this.btnChon = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbKH
            // 
            this.tbKH.Location = new System.Drawing.Point(187, 28);
            this.tbKH.Name = "tbKH";
            this.tbKH.Size = new System.Drawing.Size(246, 20);
            this.tbKH.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khách hàng (Tên/ID/Danh bộ)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã DP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kỳ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(481, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Năm";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::XMLSigner.Properties.Resources.search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(680, 89);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(101, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 166);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(813, 257);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDKH,
            this.colTenKH,
            this.colMaDp,
            this.colKy,
            this.colNam,
            this.colMauHoaDon,
            this.colSoHoaDon,
            this.colLanKy});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colIDKH
            // 
            this.colIDKH.Caption = "ID KH";
            this.colIDKH.FieldName = "IDKH";
            this.colIDKH.Name = "colIDKH";
            this.colIDKH.OptionsColumn.AllowEdit = false;
            this.colIDKH.Visible = true;
            this.colIDKH.VisibleIndex = 0;
            this.colIDKH.Width = 96;
            // 
            // colTenKH
            // 
            this.colTenKH.Caption = "Tên KH";
            this.colTenKH.FieldName = "TENKH";
            this.colTenKH.Name = "colTenKH";
            this.colTenKH.OptionsColumn.AllowEdit = false;
            this.colTenKH.Visible = true;
            this.colTenKH.VisibleIndex = 1;
            this.colTenKH.Width = 150;
            // 
            // colMaDp
            // 
            this.colMaDp.Caption = "Mã DP";
            this.colMaDp.FieldName = "MADP";
            this.colMaDp.Name = "colMaDp";
            this.colMaDp.OptionsColumn.AllowEdit = false;
            this.colMaDp.Visible = true;
            this.colMaDp.VisibleIndex = 2;
            this.colMaDp.Width = 86;
            // 
            // colKy
            // 
            this.colKy.Caption = "Kỳ";
            this.colKy.FieldName = "KY";
            this.colKy.Name = "colKy";
            this.colKy.OptionsColumn.AllowEdit = false;
            this.colKy.Visible = true;
            this.colKy.VisibleIndex = 3;
            this.colKy.Width = 86;
            // 
            // colNam
            // 
            this.colNam.Caption = "Năm";
            this.colNam.FieldName = "NAM";
            this.colNam.Name = "colNam";
            this.colNam.OptionsColumn.AllowEdit = false;
            this.colNam.Visible = true;
            this.colNam.VisibleIndex = 4;
            this.colNam.Width = 86;
            // 
            // colMauHoaDon
            // 
            this.colMauHoaDon.Caption = "Mẫu";
            this.colMauHoaDon.FieldName = "KIHIEUHOADON";
            this.colMauHoaDon.Name = "colMauHoaDon";
            this.colMauHoaDon.OptionsColumn.AllowEdit = false;
            this.colMauHoaDon.Visible = true;
            this.colMauHoaDon.VisibleIndex = 5;
            this.colMauHoaDon.Width = 86;
            // 
            // colSoHoaDon
            // 
            this.colSoHoaDon.Caption = "Số hóa đơn";
            this.colSoHoaDon.FieldName = "SOHOADON";
            this.colSoHoaDon.Name = "colSoHoaDon";
            this.colSoHoaDon.OptionsColumn.AllowEdit = false;
            this.colSoHoaDon.Visible = true;
            this.colSoHoaDon.VisibleIndex = 6;
            this.colSoHoaDon.Width = 86;
            // 
            // colLanKy
            // 
            this.colLanKy.Caption = "Lần ký";
            this.colLanKy.FieldName = "LANKY";
            this.colLanKy.Name = "colLanKy";
            this.colLanKy.OptionsColumn.AllowEdit = false;
            this.colLanKy.Visible = true;
            this.colLanKy.VisibleIndex = 7;
            this.colLanKy.Width = 96;
            // 
            // cbKy
            // 
            this.cbKy.FormattingEnabled = true;
            this.cbKy.Items.AddRange(new object[] {
            "Tất cả",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbKy.Location = new System.Drawing.Point(187, 64);
            this.cbKy.Name = "cbKy";
            this.cbKy.Size = new System.Drawing.Size(101, 21);
            this.cbKy.TabIndex = 3;
            // 
            // tbNam
            // 
            this.tbNam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNam.Location = new System.Drawing.Point(521, 65);
            this.tbNam.Mask = "0000";
            this.tbNam.Name = "tbNam";
            this.tbNam.Size = new System.Drawing.Size(101, 20);
            this.tbNam.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Location = new System.Drawing.Point(12, 144);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(816, 279);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(808, 253);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DS Hóa đơn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbMaDP);
            this.groupBox1.Controls.Add(this.tbKH);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbNam);
            this.groupBox1.Controls.Add(this.cbKy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(812, 124);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin tra cứu";
            // 
            // cbMaDP
            // 
            this.cbMaDP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMaDP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMaDP.FormattingEnabled = true;
            this.cbMaDP.Location = new System.Drawing.Point(521, 27);
            this.cbMaDP.Name = "cbMaDP";
            this.cbMaDP.Size = new System.Drawing.Size(262, 21);
            this.cbMaDP.TabIndex = 2;
            // 
            // btnChon
            // 
            this.btnChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChon.Image = global::XMLSigner.Properties.Resources.accept1;
            this.btnChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChon.Location = new System.Drawing.Point(557, 429);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(85, 23);
            this.btnChon.TabIndex = 15;
            this.btnChon.Text = "Chọn";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Image = global::XMLSigner.Properties.Resources.back;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(739, 429);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(85, 23);
            this.btnThoat.TabIndex = 16;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFile.Image = global::XMLSigner.Properties.Resources.Export_16x16;
            this.btnSaveFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveFile.Location = new System.Drawing.Point(648, 429);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(85, 23);
            this.btnSaveFile.TabIndex = 17;
            this.btnSaveFile.Text = "Lưu tệp";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // frmSearchInvoice
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 458);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmSearchInvoice";
            this.Text = "Tra cứu hóa đơn";
            this.Load += new System.EventHandler(this.frmSearchInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ComboBox cbKy;
        private System.Windows.Forms.MaskedTextBox tbNam;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbMaDP;
        private DevExpress.XtraGrid.Columns.GridColumn colIDKH;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKH;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDp;
        private DevExpress.XtraGrid.Columns.GridColumn colKy;
        private DevExpress.XtraGrid.Columns.GridColumn colNam;
        private DevExpress.XtraGrid.Columns.GridColumn colMauHoaDon;
        private DevExpress.XtraGrid.Columns.GridColumn colSoHoaDon;
        private DevExpress.XtraGrid.Columns.GridColumn colLanKy;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSaveFile;
    }
}
