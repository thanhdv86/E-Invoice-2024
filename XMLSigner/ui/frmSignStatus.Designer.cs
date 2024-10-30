namespace XMLSigner.ui
{
    partial class frmSignStatus
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
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTenKV = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colMaDP = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTenDP = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSoHD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ColSOHDKY = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSOHDHUY = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colSOHDCON = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.btnXem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNam = new System.Windows.Forms.MaskedTextBox();
            this.cbKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbKV = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbExport = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbExport.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 90);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(873, 318);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand4});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colTenKV,
            this.colMaDP,
            this.colTenDP,
            this.colSoHD,
            this.ColSOHDKY,
            this.colSOHDHUY,
            this.colSOHDCON});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, null, this.colSoHD, "")});
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsView.ShowFooter = true;
            // 
            // gridBand1
            // 
            this.gridBand1.Columns.Add(this.colTenKV);
            this.gridBand1.Columns.Add(this.colMaDP);
            this.gridBand1.Columns.Add(this.colTenDP);
            this.gridBand1.Columns.Add(this.colSoHD);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.ShowCaption = false;
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 900;
            // 
            // colTenKV
            // 
            this.colTenKV.Caption = "Chi nhánh";
            this.colTenKV.FieldName = "TENKV";
            this.colTenKV.Name = "colTenKV";
            this.colTenKV.OptionsColumn.AllowEdit = false;
            this.colTenKV.Visible = true;
            this.colTenKV.Width = 283;
            // 
            // colMaDP
            // 
            this.colMaDP.Caption = "Mã đường";
            this.colMaDP.FieldName = "MADP";
            this.colMaDP.Name = "colMaDP";
            this.colMaDP.OptionsColumn.AllowEdit = false;
            this.colMaDP.Visible = true;
            this.colMaDP.Width = 220;
            // 
            // colTenDP
            // 
            this.colTenDP.Caption = "Tên lộ trình";
            this.colTenDP.FieldName = "TENDP";
            this.colTenDP.Name = "colTenDP";
            this.colTenDP.OptionsColumn.AllowEdit = false;
            this.colTenDP.Visible = true;
            this.colTenDP.Width = 270;
            // 
            // colSoHD
            // 
            this.colSoHD.Caption = "Cần ký";
            this.colSoHD.FieldName = "SOHD";
            this.colSoHD.Name = "colSoHD";
            this.colSoHD.OptionsColumn.AllowEdit = false;
            this.colSoHD.Visible = true;
            this.colSoHD.Width = 127;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand2.Caption = "Đã ký";
            this.gridBand2.Columns.Add(this.ColSOHDKY);
            this.gridBand2.Columns.Add(this.colSOHDHUY);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 259;
            // 
            // ColSOHDKY
            // 
            this.ColSOHDKY.Caption = "Đang dùng";
            this.ColSOHDKY.FieldName = "SOHDKY";
            this.ColSOHDKY.Name = "ColSOHDKY";
            this.ColSOHDKY.Visible = true;
            this.ColSOHDKY.Width = 126;
            // 
            // colSOHDHUY
            // 
            this.colSOHDHUY.Caption = "Bị hủy";
            this.colSOHDHUY.FieldName = "SOHDHUY";
            this.colSOHDHUY.Name = "colSOHDHUY";
            this.colSOHDHUY.Visible = true;
            this.colSOHDHUY.Width = 133;
            // 
            // gridBand4
            // 
            this.gridBand4.Columns.Add(this.colSOHDCON);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.OptionsBand.ShowCaption = false;
            this.gridBand4.VisibleIndex = 2;
            this.gridBand4.Width = 137;
            // 
            // colSOHDCON
            // 
            this.colSOHDCON.Caption = "Chưa ký";
            this.colSOHDCON.FieldName = "SOHDCON";
            this.colSOHDCON.Name = "colSOHDCON";
            this.colSOHDCON.Visible = true;
            this.colSOHDCON.Width = 137;
            // 
            // btnXem
            // 
            this.btnXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXem.Location = new System.Drawing.Point(733, 29);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(127, 23);
            this.btnXem.TabIndex = 1;
            this.btnXem.Text = "Tổng hợp";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbNam);
            this.groupBox1.Controls.Add(this.cbKy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbKV);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(873, 72);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin tổng hợp báo cáo";
            // 
            // tbNam
            // 
            this.tbNam.Location = new System.Drawing.Point(189, 30);
            this.tbNam.Mask = "0000";
            this.tbNam.Name = "tbNam";
            this.tbNam.Size = new System.Drawing.Size(82, 20);
            this.tbNam.TabIndex = 9;
            // 
            // cbKy
            // 
            this.cbKy.FormattingEnabled = true;
            this.cbKy.Items.AddRange(new object[] {
            "--Chọn--",
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
            this.cbKy.Location = new System.Drawing.Point(44, 29);
            this.cbKy.Name = "cbKy";
            this.cbKy.Size = new System.Drawing.Size(75, 21);
            this.cbKy.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Chi nhánh";
            // 
            // cbKV
            // 
            this.cbKV.FormattingEnabled = true;
            this.cbKV.Location = new System.Drawing.Point(377, 29);
            this.cbKV.Name = "cbKV";
            this.cbKV.Size = new System.Drawing.Size(191, 21);
            this.cbKV.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Năm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kỳ";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(733, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.sbExport_Click);
            // 
            // cbExport
            // 
            this.cbExport.Location = new System.Drawing.Point(85, 30);
            this.cbExport.Name = "cbExport";
            this.cbExport.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cbExport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbExport.Properties.DropDownRows = 10;
            this.cbExport.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbExport.Size = new System.Drawing.Size(249, 20);
            this.cbExport.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.AllowHtmlString = true;
            this.labelControl1.Location = new System.Drawing.Point(9, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "<b>Export</b> to:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbExport);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.labelControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 421);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(873, 66);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Xuất báo cáo";
            // 
            // frmSignStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 499);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmSignStatus";
            this.Text = "Báo cáo tình trạng ký hóa đơn";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbExport.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox tbNam;
        private System.Windows.Forms.ComboBox cbKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbKV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTenKV;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMaDP;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTenDP;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSoHD;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColSOHDKY;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSOHDHUY;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSOHDCON;
        private DevExpress.XtraEditors.ComboBoxEdit cbExport;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}