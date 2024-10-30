namespace XMLSigner.ui
{
    partial class frmSmsThucNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSmsThucNo));
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMauSms = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTaoMau = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdMang = new DevExpress.XtraEditors.RadioGroup();
            this.cmbLoTrinh = new System.Windows.Forms.ComboBox();
            this.cbKV = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grdSMS = new DevExpress.XtraGrid.GridControl();
            this.grdViewSMS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTinNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.M3TINHTIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TONGTIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DIADIEMTHU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDungSms = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNoDenKy = new DevExpress.XtraEditors.CheckEdit();
            this.cbQT = new System.Windows.Forms.ComboBox();
            this.lblQuayThu = new System.Windows.Forms.Label();
            this.tbNam = new System.Windows.Forms.MaskedTextBox();
            this.cbKy = new System.Windows.Forms.ComboBox();
            this.chkUNT = new DevExpress.XtraEditors.CheckEdit();
            this.btnKhoiTao = new DevExpress.XtraEditors.SimpleButton();
            this.lblNam = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdMang.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewSMS)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNoDenKy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUNT.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Chọn mẫu tin";
            // 
            // cmbMauSms
            // 
            this.cmbMauSms.FormattingEnabled = true;
            this.cmbMauSms.Location = new System.Drawing.Point(515, 28);
            this.cmbMauSms.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMauSms.Name = "cmbMauSms";
            this.cmbMauSms.Size = new System.Drawing.Size(601, 24);
            this.cmbMauSms.TabIndex = 11;
            this.cmbMauSms.SelectedIndexChanged += new System.EventHandler(this.cmbMauSms_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Chọn mẫu tin nhắn";
            // 
            // btnTaoMau
            // 
            this.btnTaoMau.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoMau.Image")));
            this.btnTaoMau.Location = new System.Drawing.Point(1125, 28);
            this.btnTaoMau.Margin = new System.Windows.Forms.Padding(4);
            this.btnTaoMau.Name = "btnTaoMau";
            this.btnTaoMau.Size = new System.Drawing.Size(33, 25);
            this.btnTaoMau.TabIndex = 8;
            this.btnTaoMau.Click += new System.EventHandler(this.btnTaoMau_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbMauSms);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnTaoMau);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1408, 62);
            this.panel1.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdMang);
            this.groupBox4.Location = new System.Drawing.Point(12, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(465, 105);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Loại nhà mạng";
            // 
            // rdMang
            // 
            this.rdMang.EditValue = ((short)(0));
            this.rdMang.Location = new System.Drawing.Point(15, 23);
            this.rdMang.Margin = new System.Windows.Forms.Padding(4);
            this.rdMang.Name = "rdMang";
            this.rdMang.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "All (NEO)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Viettel", false),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "Vinaphone", false),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(3)), "Mobifone", false),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(4)), "VietnamMobile", false),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(5)), "GMobile", false)});
            this.rdMang.Size = new System.Drawing.Size(443, 64);
            this.rdMang.TabIndex = 1;
            // 
            // cmbLoTrinh
            // 
            this.cmbLoTrinh.DisplayMember = "tendp";
            this.cmbLoTrinh.FormattingEnabled = true;
            this.cmbLoTrinh.Location = new System.Drawing.Point(890, 23);
            this.cmbLoTrinh.Margin = new System.Windows.Forms.Padding(4);
            this.cmbLoTrinh.Name = "cmbLoTrinh";
            this.cmbLoTrinh.Size = new System.Drawing.Size(226, 24);
            this.cmbLoTrinh.TabIndex = 9;
            this.cmbLoTrinh.ValueMember = "madp";
            // 
            // cbKV
            // 
            this.cbKV.FormattingEnabled = true;
            this.cbKV.Location = new System.Drawing.Point(555, 23);
            this.cbKV.Margin = new System.Windows.Forms.Padding(4);
            this.cbKV.Name = "cbKV";
            this.cbKV.Size = new System.Drawing.Size(242, 24);
            this.cbKV.TabIndex = 8;
            this.cbKV.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.grdSMS, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.21951F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.78049F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1416, 843);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSend);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 802);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1408, 37);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(4, 4);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 28);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Xuất file";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(112, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Đóng";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grdSMS
            // 
            this.grdSMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSMS.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdSMS.Location = new System.Drawing.Point(4, 390);
            this.grdSMS.MainView = this.grdViewSMS;
            this.grdSMS.Margin = new System.Windows.Forms.Padding(4);
            this.grdSMS.Name = "grdSMS";
            this.grdSMS.Size = new System.Drawing.Size(1408, 404);
            this.grdSMS.TabIndex = 0;
            this.grdSMS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewSMS});
            // 
            // grdViewSMS
            // 
            this.grdViewSMS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSDT,
            this.colTinNhan,
            this.M3TINHTIEN,
            this.TONGTIEN,
            this.DIADIEMTHU});
            this.grdViewSMS.GridControl = this.grdSMS;
            this.grdViewSMS.Name = "grdViewSMS";
            this.grdViewSMS.OptionsFind.FindNullPrompt = "Enter text to search...";
            this.grdViewSMS.OptionsPrint.PrintSelectedRowsOnly = true;
            this.grdViewSMS.OptionsSelection.InvertSelection = true;
            this.grdViewSMS.OptionsSelection.MultiSelect = true;
            this.grdViewSMS.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grdViewSMS.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
            this.grdViewSMS.OptionsSelection.UseIndicatorForSelection = false;
            this.grdViewSMS.OptionsView.ShowGroupPanel = false;
            // 
            // colSDT
            // 
            this.colSDT.Caption = "Số điện thoại";
            this.colSDT.FieldName = "DIDONG1";
            this.colSDT.Name = "colSDT";
            this.colSDT.Visible = true;
            this.colSDT.VisibleIndex = 1;
            this.colSDT.Width = 146;
            // 
            // colTinNhan
            // 
            this.colTinNhan.Caption = "Tin nhắn";
            this.colTinNhan.FieldName = "TinNhan";
            this.colTinNhan.Name = "colTinNhan";
            this.colTinNhan.Visible = true;
            this.colTinNhan.VisibleIndex = 2;
            this.colTinNhan.Width = 950;
            // 
            // M3TINHTIEN
            // 
            this.M3TINHTIEN.Caption = "M3TINHTIEN";
            this.M3TINHTIEN.FieldName = "M3TINHTIEN";
            this.M3TINHTIEN.Name = "M3TINHTIEN";
            // 
            // TONGTIEN
            // 
            this.TONGTIEN.Caption = "TONGTIEN";
            this.TONGTIEN.FieldName = "TONGTIEN";
            this.TONGTIEN.Name = "TONGTIEN";
            // 
            // DIADIEMTHU
            // 
            this.DIADIEMTHU.Caption = "DIADIEMTHU";
            this.DIADIEMTHU.FieldName = "DIADIEMTHU";
            this.DIADIEMTHU.Name = "DIADIEMTHU";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtNoiDungSms, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 74);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.22222F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.77778F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1408, 179);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nội dung sẽ gửi";
            // 
            // txtNoiDungSms
            // 
            this.txtNoiDungSms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNoiDungSms.Location = new System.Drawing.Point(4, 25);
            this.txtNoiDungSms.Margin = new System.Windows.Forms.Padding(4);
            this.txtNoiDungSms.Multiline = true;
            this.txtNoiDungSms.Name = "txtNoiDungSms";
            this.txtNoiDungSms.ReadOnly = true;
            this.txtNoiDungSms.Size = new System.Drawing.Size(1400, 150);
            this.txtNoiDungSms.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkNoDenKy);
            this.groupBox1.Controls.Add(this.cbQT);
            this.groupBox1.Controls.Add(this.lblQuayThu);
            this.groupBox1.Controls.Add(this.tbNam);
            this.groupBox1.Controls.Add(this.cbKy);
            this.groupBox1.Controls.Add(this.chkUNT);
            this.groupBox1.Controls.Add(this.btnKhoiTao);
            this.groupBox1.Controls.Add(this.lblNam);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.cmbLoTrinh);
            this.groupBox1.Controls.Add(this.cbKV);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 261);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1408, 111);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc dữ liệu";
            // 
            // chkNoDenKy
            // 
            this.chkNoDenKy.Enabled = false;
            this.chkNoDenKy.Location = new System.Drawing.Point(1122, 24);
            this.chkNoDenKy.Margin = new System.Windows.Forms.Padding(4);
            this.chkNoDenKy.Name = "chkNoDenKy";
            this.chkNoDenKy.Properties.Caption = "Nợ đến kỳ";
            this.chkNoDenKy.Size = new System.Drawing.Size(121, 21);
            this.chkNoDenKy.TabIndex = 19;
            // 
            // cbQT
            // 
            this.cbQT.FormattingEnabled = true;
            this.cbQT.Location = new System.Drawing.Point(890, 62);
            this.cbQT.Margin = new System.Windows.Forms.Padding(4);
            this.cbQT.Name = "cbQT";
            this.cbQT.Size = new System.Drawing.Size(335, 24);
            this.cbQT.TabIndex = 18;
            // 
            // lblQuayThu
            // 
            this.lblQuayThu.AutoSize = true;
            this.lblQuayThu.Location = new System.Drawing.Point(816, 67);
            this.lblQuayThu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuayThu.Name = "lblQuayThu";
            this.lblQuayThu.Size = new System.Drawing.Size(66, 17);
            this.lblQuayThu.TabIndex = 17;
            this.lblQuayThu.Text = "Quầy thu";
            // 
            // tbNam
            // 
            this.tbNam.Location = new System.Drawing.Point(711, 63);
            this.tbNam.Margin = new System.Windows.Forms.Padding(4);
            this.tbNam.Mask = "0000";
            this.tbNam.Name = "tbNam";
            this.tbNam.Size = new System.Drawing.Size(86, 22);
            this.tbNam.TabIndex = 16;
            // 
            // cbKy
            // 
            this.cbKy.FormattingEnabled = true;
            this.cbKy.Items.AddRange(new object[] {
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
            this.cbKy.Location = new System.Drawing.Point(555, 63);
            this.cbKy.Margin = new System.Windows.Forms.Padding(4);
            this.cbKy.Name = "cbKy";
            this.cbKy.Size = new System.Drawing.Size(99, 24);
            this.cbKy.TabIndex = 15;
            // 
            // chkUNT
            // 
            this.chkUNT.Enabled = false;
            this.chkUNT.Location = new System.Drawing.Point(1246, 23);
            this.chkUNT.Margin = new System.Windows.Forms.Padding(4);
            this.chkUNT.Name = "chkUNT";
            this.chkUNT.Properties.Caption = "Ủy nhiệm thu";
            this.chkUNT.Size = new System.Drawing.Size(121, 21);
            this.chkUNT.TabIndex = 14;
            // 
            // btnKhoiTao
            // 
            this.btnKhoiTao.Location = new System.Drawing.Point(1248, 57);
            this.btnKhoiTao.Margin = new System.Windows.Forms.Padding(4);
            this.btnKhoiTao.Name = "btnKhoiTao";
            this.btnKhoiTao.Size = new System.Drawing.Size(121, 28);
            this.btnKhoiTao.TabIndex = 1;
            this.btnKhoiTao.Text = "Khởi tạo số liệu";
            this.btnKhoiTao.Click += new System.EventHandler(this.btnKhoiTao_Click);
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(665, 73);
            this.lblNam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(37, 17);
            this.lblNam.TabIndex = 12;
            this.lblNam.Text = "Năm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(485, 71);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 17);
            this.label10.TabIndex = 10;
            this.label10.Text = "Tháng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 914);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Bắt đầu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(826, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lộ trình";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(485, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Khu vực";
            // 
            // frmSmsThucNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 843);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmSmsThucNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông báo thúc nợ";
            this.Load += new System.EventHandler(this.frmSMS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdMang.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewSMS)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNoDenKy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUNT.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMauSms;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnTaoMau;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbLoTrinh;
        private System.Windows.Forms.ComboBox cbKV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraGrid.GridControl grdSMS;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewSMS;
        private DevExpress.XtraGrid.Columns.GridColumn colSDT;
        private DevExpress.XtraGrid.Columns.GridColumn colTinNhan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiDungSms;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.RadioGroup rdMang;
        private DevExpress.XtraGrid.Columns.GridColumn M3TINHTIEN;
        private DevExpress.XtraGrid.Columns.GridColumn TONGTIEN;
        private DevExpress.XtraGrid.Columns.GridColumn DIADIEMTHU;
        private DevExpress.XtraEditors.SimpleButton btnKhoiTao;
        private DevExpress.XtraEditors.CheckEdit chkUNT;
        private System.Windows.Forms.MaskedTextBox tbNam;
        private System.Windows.Forms.ComboBox cbKy;
        private System.Windows.Forms.ComboBox cbQT;
        private System.Windows.Forms.Label lblQuayThu;
        private DevExpress.XtraEditors.CheckEdit chkNoDenKy;
    }
}