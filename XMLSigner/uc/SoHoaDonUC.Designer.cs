namespace XMLSigner
{
    partial class SoHoaDonUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbKiHieu = new System.Windows.Forms.ComboBox();
            this.tbSoHoaDon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbHD = new System.Windows.Forms.Label();
            this.btnGetHD = new System.Windows.Forms.Button();
            this.lblMAU_SERY = new System.Windows.Forms.Label();
            this.txtMAU_SERY = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbKiHieu
            // 
            this.cbKiHieu.FormattingEnabled = true;
            this.cbKiHieu.Location = new System.Drawing.Point(100, 23);
            this.cbKiHieu.Name = "cbKiHieu";
            this.cbKiHieu.Size = new System.Drawing.Size(121, 21);
            this.cbKiHieu.TabIndex = 0;
            this.cbKiHieu.SelectedIndexChanged += new System.EventHandler(this.cbKiHieu_SelectedIndexChanged);
            // 
            // tbSoHoaDon
            // 
            this.tbSoHoaDon.Location = new System.Drawing.Point(100, 69);
            this.tbSoHoaDon.Name = "tbSoHoaDon";
            this.tbSoHoaDon.ReadOnly = true;
            this.tbSoHoaDon.Size = new System.Drawing.Size(121, 20);
            this.tbSoHoaDon.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kí hiệu HĐ";
            // 
            // lbHD
            // 
            this.lbHD.AutoSize = true;
            this.lbHD.Location = new System.Drawing.Point(50, 72);
            this.lbHD.Name = "lbHD";
            this.lbHD.Size = new System.Drawing.Size(39, 13);
            this.lbHD.TabIndex = 4;
            this.lbHD.Text = "Số HĐ";
            // 
            // btnGetHD
            // 
            this.btnGetHD.Image = global::XMLSigner.Properties.Resources.download;
            this.btnGetHD.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnGetHD.Location = new System.Drawing.Point(245, 21);
            this.btnGetHD.Name = "btnGetHD";
            this.btnGetHD.Size = new System.Drawing.Size(157, 23);
            this.btnGetHD.TabIndex = 1;
            this.btnGetHD.Text = "Lấy Số HĐ chưa dùng";
            this.btnGetHD.UseVisualStyleBackColor = true;
            this.btnGetHD.Click += new System.EventHandler(this.btnGetHD_Click);
            // 
            // lblMAU_SERY
            // 
            this.lblMAU_SERY.AutoSize = true;
            this.lblMAU_SERY.Location = new System.Drawing.Point(231, 72);
            this.lblMAU_SERY.Name = "lblMAU_SERY";
            this.lblMAU_SERY.Size = new System.Drawing.Size(52, 13);
            this.lblMAU_SERY.TabIndex = 8;
            this.lblMAU_SERY.Text = "Mẫu Sery";
            // 
            // txtMAU_SERY
            // 
            this.txtMAU_SERY.Location = new System.Drawing.Point(289, 69);
            this.txtMAU_SERY.Name = "txtMAU_SERY";
            this.txtMAU_SERY.ReadOnly = true;
            this.txtMAU_SERY.Size = new System.Drawing.Size(113, 20);
            this.txtMAU_SERY.TabIndex = 7;
            // 
            // SoHoaDonUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMAU_SERY);
            this.Controls.Add(this.txtMAU_SERY);
            this.Controls.Add(this.lbHD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSoHoaDon);
            this.Controls.Add(this.btnGetHD);
            this.Controls.Add(this.cbKiHieu);
            this.Name = "SoHoaDonUC";
            this.Size = new System.Drawing.Size(416, 105);
            this.Load += new System.EventHandler(this.SoHoaDonUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbKiHieu;
        private System.Windows.Forms.Button btnGetHD;
        private System.Windows.Forms.TextBox tbSoHoaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbHD;
        private System.Windows.Forms.Label lblMAU_SERY;
        private System.Windows.Forms.TextBox txtMAU_SERY;
    }
}
