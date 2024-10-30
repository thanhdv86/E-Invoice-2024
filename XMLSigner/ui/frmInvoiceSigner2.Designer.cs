namespace XMLSigner.ui
{
    partial class frmInvoiceSigner2
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoiceSigner2));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbMonth = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.clbDp = new System.Windows.Forms.CheckedListBox();
            this.cbKV = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bntLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbThang = new System.Windows.Forms.Label();
            this.tbYear = new System.Windows.Forms.MaskedTextBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdKh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongTine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKiHieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoHoaDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLanKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaDP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSign = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.tbMonth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.clbDp);
            this.groupBox1.Controls.Add(this.cbKV);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.bntLoad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbThang);
            this.groupBox1.Controls.Add(this.tbYear);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 576);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trích xuất HĐ mới";
            // 
            // tbMonth
            // 
            this.tbMonth.Location = new System.Drawing.Point(12, 45);
            this.tbMonth.Mask = "00";
            this.tbMonth.Name = "tbMonth";
            this.tbMonth.Size = new System.Drawing.Size(71, 20);
            this.tbMonth.TabIndex = 1;
            this.tbMonth.Leave += new System.EventHandler(this.tbMonth_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Chi nhánh";
            // 
            // clbDp
            // 
            this.clbDp.FormattingEnabled = true;
            this.clbDp.Location = new System.Drawing.Point(9, 148);
            this.clbDp.Name = "clbDp";
            this.clbDp.Size = new System.Drawing.Size(206, 364);
            this.clbDp.TabIndex = 4;
            this.clbDp.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbDp_ItemCheck);
            // 
            // cbKV
            // 
            this.cbKV.FormattingEnabled = true;
            this.cbKV.Location = new System.Drawing.Point(9, 96);
            this.cbKV.Name = "cbKV";
            this.cbKV.Size = new System.Drawing.Size(206, 21);
            this.cbKV.TabIndex = 3;
            this.cbKV.SelectedIndexChanged += new System.EventHandler(this.cbKV_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mã DP";
            // 
            // bntLoad
            // 
            this.bntLoad.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntLoad.Location = new System.Drawing.Point(9, 538);
            this.bntLoad.Name = "bntLoad";
            this.bntLoad.Size = new System.Drawing.Size(206, 32);
            this.bntLoad.TabIndex = 5;
            this.bntLoad.Text = "Trích xuất hóa đơn cần ký";
            this.bntLoad.UseVisualStyleBackColor = true;
            this.bntLoad.Click += new System.EventHandler(this.bntLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Năm";
            // 
            // lbThang
            // 
            this.lbThang.AutoSize = true;
            this.lbThang.Location = new System.Drawing.Point(9, 29);
            this.lbThang.Name = "lbThang";
            this.lbThang.Size = new System.Drawing.Size(38, 13);
            this.lbThang.TabIndex = 2;
            this.lbThang.Text = "Tháng";
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(89, 45);
            this.tbYear.Mask = "0000";
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(72, 20);
            this.tbYear.TabIndex = 2;
            this.tbYear.Leave += new System.EventHandler(this.tbYear_Leave);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(3, 16);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(839, 516);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdKh,
            this.colTenKH,
            this.colDiaChi,
            this.colTongTine,
            this.colKiHieu,
            this.colSoHoaDon,
            this.colNguoiKy,
            this.colNgayKy,
            this.colLanKy,
            this.colSTT,
            this.colMaDP});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(932, 527, 210, 172);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView1_EditFormPrepared);
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            // 
            // colIdKh
            // 
            this.colIdKh.Caption = "ID Khách hàng";
            this.colIdKh.FieldName = "IDKH";
            this.colIdKh.Name = "colIdKh";
            this.colIdKh.OptionsColumn.AllowEdit = false;
            this.colIdKh.Visible = true;
            this.colIdKh.VisibleIndex = 3;
            this.colIdKh.Width = 117;
            // 
            // colTenKH
            // 
            this.colTenKH.Caption = "Tên KH";
            this.colTenKH.FieldName = "TENKH";
            this.colTenKH.Name = "colTenKH";
            this.colTenKH.OptionsColumn.AllowEdit = false;
            this.colTenKH.Visible = true;
            this.colTenKH.VisibleIndex = 4;
            this.colTenKH.Width = 117;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Caption = "Địa chỉ";
            this.colDiaChi.FieldName = "DIACHI";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.OptionsColumn.AllowEdit = false;
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 5;
            this.colDiaChi.Width = 200;
            // 
            // colTongTine
            // 
            this.colTongTine.Caption = "Tổng tiền";
            this.colTongTine.DisplayFormat.FormatString = "n0";
            this.colTongTine.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTongTine.FieldName = "TONGTIEN";
            this.colTongTine.Name = "colTongTine";
            this.colTongTine.OptionsColumn.AllowEdit = false;
            this.colTongTine.Visible = true;
            this.colTongTine.VisibleIndex = 6;
            this.colTongTine.Width = 100;
            // 
            // colKiHieu
            // 
            this.colKiHieu.Caption = "Kí hiệu HĐ";
            this.colKiHieu.FieldName = "KIHIEUHOADON";
            this.colKiHieu.Name = "colKiHieu";
            this.colKiHieu.OptionsColumn.AllowEdit = false;
            this.colKiHieu.Visible = true;
            this.colKiHieu.VisibleIndex = 7;
            this.colKiHieu.Width = 100;
            // 
            // colSoHoaDon
            // 
            this.colSoHoaDon.Caption = "Số HĐ";
            this.colSoHoaDon.FieldName = "SOHOADON";
            this.colSoHoaDon.Name = "colSoHoaDon";
            this.colSoHoaDon.OptionsColumn.AllowEdit = false;
            this.colSoHoaDon.Visible = true;
            this.colSoHoaDon.VisibleIndex = 8;
            this.colSoHoaDon.Width = 100;
            // 
            // colNguoiKy
            // 
            this.colNguoiKy.Caption = "Người ký";
            this.colNguoiKy.FieldName = "NGUOIKY";
            this.colNguoiKy.Name = "colNguoiKy";
            this.colNguoiKy.OptionsColumn.AllowEdit = false;
            this.colNguoiKy.Visible = true;
            this.colNguoiKy.VisibleIndex = 9;
            this.colNguoiKy.Width = 100;
            // 
            // colNgayKy
            // 
            this.colNgayKy.Caption = "Ngày ký";
            this.colNgayKy.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colNgayKy.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayKy.FieldName = "NGAYKY";
            this.colNgayKy.Name = "colNgayKy";
            this.colNgayKy.OptionsColumn.AllowEdit = false;
            this.colNgayKy.Visible = true;
            this.colNgayKy.VisibleIndex = 10;
            this.colNgayKy.Width = 106;
            // 
            // colLanKy
            // 
            this.colLanKy.Caption = "Ký lần";
            this.colLanKy.FieldName = "LANKY";
            this.colLanKy.Name = "colLanKy";
            this.colLanKy.OptionsColumn.AllowEdit = false;
            this.colLanKy.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 2;
            // 
            // colMaDP
            // 
            this.colMaDP.Caption = "Mã DP";
            this.colMaDP.FieldName = "MADP";
            this.colMaDP.Name = "colMaDP";
            this.colMaDP.Visible = true;
            this.colMaDP.VisibleIndex = 1;
            // 
            // btnSign
            // 
            this.btnSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSign.Image = ((System.Drawing.Image)(resources.GetObject("btnSign.Image")));
            this.btnSign.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSign.Location = new System.Drawing.Point(1004, 554);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(68, 23);
            this.btnSign.TabIndex = 8;
            this.btnSign.Text = "Ký";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.gridControl1);
            this.groupBox2.Location = new System.Drawing.Point(242, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(845, 535);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hóa đơn cần ký";
            // 
            // frmInvoiceSigner2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 591);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInvoiceSigner2";
            this.Text = "Ký phát hành HĐ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInvoiceSigner2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox tbYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbThang;
        private System.Windows.Forms.Button bntLoad;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnSign;
        private DevExpress.XtraGrid.Columns.GridColumn colIdKh;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKH;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colTongTine;
        private DevExpress.XtraGrid.Columns.GridColumn colKiHieu;
        private DevExpress.XtraGrid.Columns.GridColumn colSoHoaDon;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiKy;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayKy;
        private DevExpress.XtraGrid.Columns.GridColumn colLanKy;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbKV;
        private System.Windows.Forms.CheckedListBox clbDp;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDP;
        private System.Windows.Forms.MaskedTextBox tbMonth;

    }
}