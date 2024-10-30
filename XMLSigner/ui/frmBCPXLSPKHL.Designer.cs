namespace XMLSigner.ui
{
    partial class frmBCPXLSPKHL
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbKy = new System.Windows.Forms.ComboBox();
            this.cbKV = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNam = new System.Windows.Forms.MaskedTextBox();
            this.btnTongHop = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kỳ";
            // 
            // cbKy
            // 
            this.cbKy.FormattingEnabled = true;
            this.cbKy.Items.AddRange(new object[] {
            "--Chọn kỳ--",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbKy.Location = new System.Drawing.Point(39, 21);
            this.cbKy.Name = "cbKy";
            this.cbKy.Size = new System.Drawing.Size(69, 21);
            this.cbKy.TabIndex = 1;
            // 
            // cbKV
            // 
            this.cbKV.FormattingEnabled = true;
            this.cbKV.Location = new System.Drawing.Point(303, 21);
            this.cbKV.Name = "cbKV";
            this.cbKV.Size = new System.Drawing.Size(158, 21);
            this.cbKV.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chi nhánh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Năm";
            // 
            // tbNam
            // 
            this.tbNam.Location = new System.Drawing.Point(149, 21);
            this.tbNam.Mask = "0000";
            this.tbNam.Name = "tbNam";
            this.tbNam.Size = new System.Drawing.Size(77, 20);
            this.tbNam.TabIndex = 2;
            this.tbNam.ValidatingType = typeof(int);
            // 
            // btnTongHop
            // 
            this.btnTongHop.Location = new System.Drawing.Point(303, 86);
            this.btnTongHop.Name = "btnTongHop";
            this.btnTongHop.Size = new System.Drawing.Size(75, 23);
            this.btnTongHop.TabIndex = 6;
            this.btnTongHop.Text = "Tổng hợp";
            this.btnTongHop.UseVisualStyleBackColor = true;
            this.btnTongHop.Click += new System.EventHandler(this.btnTongHop_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(386, 86);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(13, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(448, 2);
            this.label4.TabIndex = 8;
            // 
            // frmBCPXLSPKHL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 123);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTongHop);
            this.Controls.Add(this.tbNam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbKV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbKy);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmBCPXLSPKHL";
            this.Text = "Báo cáo phiếu xử lý sản phẩm không phù hợp";
            this.Load += new System.EventHandler(this.frmBCPXLSPKHL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKy;
        private System.Windows.Forms.ComboBox cbKV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tbNam;
        private System.Windows.Forms.Button btnTongHop;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label4;
    }
}