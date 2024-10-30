namespace XMLSigner.ui
{
    partial class frmInvoiceNumMngt
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKyHieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoHoaDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSuDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHuyBo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStartPrefix = new System.Windows.Forms.TextBox();
            this.tbStartNo = new System.Windows.Forms.TextBox();
            this.tbStartSuf = new System.Windows.Forms.TextBox();
            this.tbEndNo = new System.Windows.Forms.TextBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.tbEndPre = new System.Windows.Forms.TextBox();
            this.tbEndSuf = new System.Windows.Forms.TextBox();
            this.lbEndNum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbKyHieu = new System.Windows.Forms.Label();
            this.tbKyHieu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(12, 88);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(723, 284);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});            
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKyHieu,
            this.colSoHoaDon,
            this.colSuDung,
            this.colHuyBo,
            this.colNgayTao});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colKyHieu
            // 
            this.colKyHieu.Caption = "Ký hiệu";
            this.colKyHieu.FieldName = "KIHIEU";
            this.colKyHieu.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colKyHieu.Name = "colKyHieu";
            this.colKyHieu.OptionsColumn.AllowEdit = false;
            this.colKyHieu.Visible = true;
            this.colKyHieu.VisibleIndex = 0;
            // 
            // colSoHoaDon
            // 
            this.colSoHoaDon.Caption = "Số hóa đơn";
            this.colSoHoaDon.FieldName = "SOHOADON";
            this.colSoHoaDon.Name = "colSoHoaDon";
            this.colSoHoaDon.OptionsColumn.AllowEdit = false;
            this.colSoHoaDon.Visible = true;
            this.colSoHoaDon.VisibleIndex = 1;
            // 
            // colSuDung
            // 
            this.colSuDung.Caption = "Đã sử dụng";
            this.colSuDung.FieldName = "SUDUNG";
            this.colSuDung.Name = "colSuDung";
            this.colSuDung.OptionsColumn.AllowEdit = false;
            this.colSuDung.Visible = true;
            this.colSuDung.VisibleIndex = 2;
            // 
            // colHuyBo
            // 
            this.colHuyBo.Caption = "Bị hủy bỏ";
            this.colHuyBo.FieldName = "HUYBO";
            this.colHuyBo.Name = "colHuyBo";
            this.colHuyBo.OptionsColumn.AllowEdit = false;
            this.colHuyBo.Visible = true;
            this.colHuyBo.VisibleIndex = 3;
            // 
            // colNgayTao
            // 
            this.colNgayTao.Caption = "Ngày tạo";
            this.colNgayTao.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayTao.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayTao.FieldName = "NGAYTAO";
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.OptionsColumn.AllowEdit = false;
            this.colNgayTao.Visible = true;
            this.colNgayTao.VisibleIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // tbStartPrefix
            // 
            this.tbStartPrefix.Location = new System.Drawing.Point(334, 53);
            this.tbStartPrefix.Multiline = true;
            this.tbStartPrefix.Name = "tbStartPrefix";
            this.tbStartPrefix.Size = new System.Drawing.Size(100, 20);
            this.tbStartPrefix.TabIndex = 2;
            this.tbStartPrefix.Visible = false;
            this.tbStartPrefix.TextChanged += new System.EventHandler(this.tbStartPrefix_TextChanged);
            // 
            // tbStartNo
            // 
            this.tbStartNo.Location = new System.Drawing.Point(232, 23);
            this.tbStartNo.Name = "tbStartNo";
            this.tbStartNo.Size = new System.Drawing.Size(126, 20);
            this.tbStartNo.TabIndex = 2;            
            this.tbStartNo.TextChanged += new System.EventHandler(this.tbStartNo_TextChanged);
            // 
            // tbStartSuf
            // 
            this.tbStartSuf.Location = new System.Drawing.Point(122, 53);
            this.tbStartSuf.Name = "tbStartSuf";
            this.tbStartSuf.Size = new System.Drawing.Size(100, 20);
            this.tbStartSuf.TabIndex = 4;
            this.tbStartSuf.Visible = false;
            this.tbStartSuf.TextChanged += new System.EventHandler(this.tbStartSuf_TextChanged);
            // 
            // tbEndNo
            // 
            this.tbEndNo.Location = new System.Drawing.Point(422, 23);
            this.tbEndNo.Name = "tbEndNo";
            this.tbEndNo.Size = new System.Drawing.Size(126, 20);
            this.tbEndNo.TabIndex = 3;
            this.tbEndNo.TextChanged += new System.EventHandler(this.tbEndNo_TextChanged);
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(610, 19);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(75, 23);
            this.btnGen.TabIndex = 7;
            this.btnGen.Text = "Đăng ký";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // tbEndPre
            // 
            this.tbEndPre.Location = new System.Drawing.Point(228, 53);
            this.tbEndPre.Name = "tbEndPre";
            this.tbEndPre.ReadOnly = true;
            this.tbEndPre.Size = new System.Drawing.Size(100, 20);
            this.tbEndPre.TabIndex = 8;
            this.tbEndPre.Visible = false;
            // 
            // tbEndSuf
            // 
            this.tbEndSuf.Location = new System.Drawing.Point(16, 53);
            this.tbEndSuf.Name = "tbEndSuf";
            this.tbEndSuf.ReadOnly = true;
            this.tbEndSuf.Size = new System.Drawing.Size(100, 20);
            this.tbEndSuf.TabIndex = 9;
            this.tbEndSuf.Visible = false;
            // 
            // lbEndNum
            // 
            this.lbEndNum.AutoSize = true;
            this.lbEndNum.Location = new System.Drawing.Point(373, 26);
            this.lbEndNum.Name = "lbEndNum";
            this.lbEndNum.Size = new System.Drawing.Size(41, 13);
            this.lbEndNum.TabIndex = 10;
            this.lbEndNum.Text = "Đến số";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Từ số";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lbKyHieu
            // 
            this.lbKyHieu.AutoSize = true;
            this.lbKyHieu.Location = new System.Drawing.Point(11, 26);
            this.lbKyHieu.Name = "lbKyHieu";
            this.lbKyHieu.Size = new System.Drawing.Size(42, 13);
            this.lbKyHieu.TabIndex = 12;
            this.lbKyHieu.Text = "Ký hiệu";
            // 
            // tbKyHieu
            // 
            this.tbKyHieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbKyHieu.Location = new System.Drawing.Point(59, 23);
            this.tbKyHieu.Name = "tbKyHieu";
            this.tbKyHieu.Size = new System.Drawing.Size(100, 20);
            this.tbKyHieu.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbKyHieu);
            this.groupBox1.Controls.Add(this.lbKyHieu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbEndNum);
            this.groupBox1.Controls.Add(this.btnGen);
            this.groupBox1.Controls.Add(this.tbEndNo);
            this.groupBox1.Controls.Add(this.tbStartNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 70);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // frmInvoiceNumMngt
            // 
            this.AcceptButton = this.btnGen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 523);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbEndSuf);
            this.Controls.Add(this.tbEndPre);
            this.Controls.Add(this.tbStartSuf);
            this.Controls.Add(this.tbStartPrefix);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmInvoiceNumMngt";
            this.Text = "Đăng ký hóa đơn sử dụng";
            this.Load += new System.EventHandler(this.frmInvoiceNumMngt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStartPrefix;
        private System.Windows.Forms.TextBox tbStartNo;
        private System.Windows.Forms.TextBox tbStartSuf;
        private System.Windows.Forms.TextBox tbEndNo;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.TextBox tbEndPre;
        private System.Windows.Forms.TextBox tbEndSuf;
        private System.Windows.Forms.Label lbEndNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraGrid.Columns.GridColumn colSoHoaDon;
        private DevExpress.XtraGrid.Columns.GridColumn colSuDung;
        private DevExpress.XtraGrid.Columns.GridColumn colHuyBo;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayTao;
        private System.Windows.Forms.TextBox tbKyHieu;
        private System.Windows.Forms.Label lbKyHieu;
        private DevExpress.XtraGrid.Columns.GridColumn colKyHieu;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}