namespace XMLSigner.ui
{
    partial class frmBCHDQuy
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
            this.btnTongHop = new System.Windows.Forms.Button();
            this.lbQuy = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbYear = new System.Windows.Forms.MaskedTextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.cbQuarter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLoaiBC = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnTongHop
            // 
            this.btnTongHop.Location = new System.Drawing.Point(299, 64);
            this.btnTongHop.Name = "btnTongHop";
            this.btnTongHop.Size = new System.Drawing.Size(75, 23);
            this.btnTongHop.TabIndex = 4;
            this.btnTongHop.Text = "Tổng hợp";
            this.btnTongHop.UseVisualStyleBackColor = true;
            this.btnTongHop.Click += new System.EventHandler(this.btnTongHop_Click);
            // 
            // lbQuy
            // 
            this.lbQuy.AutoSize = true;
            this.lbQuy.Location = new System.Drawing.Point(194, 16);
            this.lbQuy.Name = "lbQuy";
            this.lbQuy.Size = new System.Drawing.Size(38, 13);
            this.lbQuy.TabIndex = 4;
            this.lbQuy.Text = "Tháng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Năm";
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(383, 12);
            this.tbYear.Mask = "0000";
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(72, 20);
            this.tbYear.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(380, 64);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cbQuarter
            // 
            this.cbQuarter.FormattingEnabled = true;
            this.cbQuarter.Location = new System.Drawing.Point(240, 12);
            this.cbQuarter.Name = "cbQuarter";
            this.cbQuarter.Size = new System.Drawing.Size(82, 21);
            this.cbQuarter.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(11, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(444, 2);
            this.label1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Loại báo cáo";
            // 
            // cbLoaiBC
            // 
            this.cbLoaiBC.FormattingEnabled = true;
            this.cbLoaiBC.Items.AddRange(new object[] {
            "Tháng",
            "Quý"});
            this.cbLoaiBC.Location = new System.Drawing.Point(88, 12);
            this.cbLoaiBC.Name = "cbLoaiBC";
            this.cbLoaiBC.Size = new System.Drawing.Size(76, 21);
            this.cbLoaiBC.TabIndex = 1;
            this.cbLoaiBC.SelectedIndexChanged += new System.EventHandler(this.cbLoaiBC_SelectedIndexChanged);
            // 
            // frmBCHDQuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 96);
            this.Controls.Add(this.cbLoaiBC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbQuarter);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbQuy);
            this.Controls.Add(this.btnTongHop);
            this.MaximizeBox = false;
            this.Name = "frmBCHDQuy";
            this.Text = "Báo cáo tình hình sử dụng hóa đơn";
            this.Load += new System.EventHandler(this.frmBCHDQuy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTongHop;
        private System.Windows.Forms.Label lbQuy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbYear;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox cbQuarter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLoaiBC;
    }
}