namespace XMLSigner.ui
{
    partial class frmDMNguoiDung
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
            this.grid1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmdThem = new System.Windows.Forms.Button();
            this.cmdLuu = new System.Windows.Forms.Button();
            this.cmdHuy = new System.Windows.Forms.Button();
            this.cmdSua = new System.Windows.Forms.Button();
            this.cmsXoa = new System.Windows.Forms.Button();
            this.cmdSetPass = new System.Windows.Forms.Button();
            this.cmdThoat = new System.Windows.Forms.Button();
            this.cmdIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaNguoiDung = new System.Windows.Forms.TextBox();
            this.txtTenNguoiDung = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grid1.Location = new System.Drawing.Point(29, 74);
            this.grid1.MainView = this.gridView1;
            this.grid1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(533, 351);
            this.grid1.TabIndex = 2;
            this.grid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.grid1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã người dùng";
            this.gridColumn1.FieldName = "MaNguoiDung";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên người dùng";
            this.gridColumn2.FieldName = "TenNguoiDung";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // cmdThem
            // 
            this.cmdThem.Location = new System.Drawing.Point(29, 432);
            this.cmdThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdThem.Name = "cmdThem";
            this.cmdThem.Size = new System.Drawing.Size(100, 28);
            this.cmdThem.TabIndex = 3;
            this.cmdThem.Text = "Thêm";
            this.cmdThem.UseVisualStyleBackColor = true;
            this.cmdThem.Click += new System.EventHandler(this.cmdThem_Click);
            // 
            // cmdLuu
            // 
            this.cmdLuu.Enabled = false;
            this.cmdLuu.Location = new System.Drawing.Point(317, 432);
            this.cmdLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdLuu.Name = "cmdLuu";
            this.cmdLuu.Size = new System.Drawing.Size(100, 28);
            this.cmdLuu.TabIndex = 5;
            this.cmdLuu.Text = "Lưu";
            this.cmdLuu.UseVisualStyleBackColor = true;
            this.cmdLuu.Click += new System.EventHandler(this.cmdLuu_Click);
            // 
            // cmdHuy
            // 
            this.cmdHuy.Enabled = false;
            this.cmdHuy.Location = new System.Drawing.Point(461, 432);
            this.cmdHuy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdHuy.Name = "cmdHuy";
            this.cmdHuy.Size = new System.Drawing.Size(100, 28);
            this.cmdHuy.TabIndex = 6;
            this.cmdHuy.Text = "Bỏ qua";
            this.cmdHuy.UseVisualStyleBackColor = true;
            this.cmdHuy.Click += new System.EventHandler(this.cmdHuy_Click);
            // 
            // cmdSua
            // 
            this.cmdSua.Location = new System.Drawing.Point(173, 432);
            this.cmdSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSua.Name = "cmdSua";
            this.cmdSua.Size = new System.Drawing.Size(100, 28);
            this.cmdSua.TabIndex = 4;
            this.cmdSua.Text = "Sửa";
            this.cmdSua.UseVisualStyleBackColor = true;
            this.cmdSua.Click += new System.EventHandler(this.cmdSua_Click);
            // 
            // cmsXoa
            // 
            this.cmsXoa.Location = new System.Drawing.Point(29, 469);
            this.cmsXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmsXoa.Name = "cmsXoa";
            this.cmsXoa.Size = new System.Drawing.Size(100, 28);
            this.cmsXoa.TabIndex = 7;
            this.cmsXoa.Text = "Xóa";
            this.cmsXoa.UseVisualStyleBackColor = true;
            this.cmsXoa.Click += new System.EventHandler(this.cmsXoa_Click);
            // 
            // cmdSetPass
            // 
            this.cmdSetPass.Location = new System.Drawing.Point(173, 468);
            this.cmdSetPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSetPass.Name = "cmdSetPass";
            this.cmdSetPass.Size = new System.Drawing.Size(100, 28);
            this.cmdSetPass.TabIndex = 8;
            this.cmdSetPass.Text = "Bỏ mật khẩu";
            this.cmdSetPass.UseVisualStyleBackColor = true;
            this.cmdSetPass.Click += new System.EventHandler(this.cmdSetPass_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Location = new System.Drawing.Point(461, 468);
            this.cmdThoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(100, 28);
            this.cmdThoat.TabIndex = 10;
            this.cmdThoat.Text = "Kết thúc";
            this.cmdThoat.UseVisualStyleBackColor = true;
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // cmdIn
            // 
            this.cmdIn.Location = new System.Drawing.Point(317, 466);
            this.cmdIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdIn.Name = "cmdIn";
            this.cmdIn.Size = new System.Drawing.Size(100, 28);
            this.cmdIn.TabIndex = 9;
            this.cmdIn.Text = "In";
            this.cmdIn.UseVisualStyleBackColor = true;
            this.cmdIn.Click += new System.EventHandler(this.cmdIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mã người dùng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tên người dùng";
            // 
            // txtMaNguoiDung
            // 
            this.txtMaNguoiDung.Enabled = false;
            this.txtMaNguoiDung.Location = new System.Drawing.Point(155, 6);
            this.txtMaNguoiDung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaNguoiDung.Name = "txtMaNguoiDung";
            this.txtMaNguoiDung.Size = new System.Drawing.Size(405, 22);
            this.txtMaNguoiDung.TabIndex = 0;
            // 
            // txtTenNguoiDung
            // 
            this.txtTenNguoiDung.Enabled = false;
            this.txtTenNguoiDung.Location = new System.Drawing.Point(155, 42);
            this.txtTenNguoiDung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenNguoiDung.Name = "txtTenNguoiDung";
            this.txtTenNguoiDung.Size = new System.Drawing.Size(405, 22);
            this.txtTenNguoiDung.TabIndex = 1;
            // 
            // frmDMNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 511);
            this.Controls.Add(this.txtTenNguoiDung);
            this.Controls.Add(this.txtMaNguoiDung);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdIn);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.cmdSetPass);
            this.Controls.Add(this.cmsXoa);
            this.Controls.Add(this.cmdSua);
            this.Controls.Add(this.cmdHuy);
            this.Controls.Add(this.cmdLuu);
            this.Controls.Add(this.cmdThem);
            this.Controls.Add(this.grid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDMNguoiDung";
            this.Text = "Danh sách người sử dụng chương trình";
            this.Load += new System.EventHandler(this.frmDMNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Button cmdThem;
        private System.Windows.Forms.Button cmdLuu;
        private System.Windows.Forms.Button cmdHuy;
        private System.Windows.Forms.Button cmdSua;
        private System.Windows.Forms.Button cmsXoa;
        private System.Windows.Forms.Button cmdSetPass;
        private System.Windows.Forms.Button cmdThoat;
        private System.Windows.Forms.Button cmdIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaNguoiDung;
        private System.Windows.Forms.TextBox txtTenNguoiDung;
    }
}