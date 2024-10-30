namespace XMLSigner.ui
{
    partial class frmChangePassword
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
            this.tbPasswordOld = new System.Windows.Forms.TextBox();
            this.tbPasswordNew1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPasswordNew2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu hiện tại";
            // 
            // tbPasswordOld
            // 
            this.tbPasswordOld.Location = new System.Drawing.Point(122, 22);
            this.tbPasswordOld.Name = "tbPasswordOld";
            this.tbPasswordOld.Size = new System.Drawing.Size(172, 20);
            this.tbPasswordOld.TabIndex = 1;
            this.tbPasswordOld.UseSystemPasswordChar = true;
            // 
            // tbPasswordNew1
            // 
            this.tbPasswordNew1.Location = new System.Drawing.Point(122, 61);
            this.tbPasswordNew1.Name = "tbPasswordNew1";
            this.tbPasswordNew1.Size = new System.Drawing.Size(172, 20);
            this.tbPasswordNew1.TabIndex = 3;
            this.tbPasswordNew1.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu mới";
            // 
            // tbPasswordNew2
            // 
            this.tbPasswordNew2.Location = new System.Drawing.Point(122, 102);
            this.tbPasswordNew2.Name = "tbPasswordNew2";
            this.tbPasswordNew2.Size = new System.Drawing.Size(172, 20);
            this.tbPasswordNew2.TabIndex = 5;
            this.tbPasswordNew2.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lặp lại mật khẩu mới";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(138, 141);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 6;
            this.btnChange.Text = "OK";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(219, 141);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 176);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.tbPasswordNew2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPasswordNew1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPasswordOld);
            this.Controls.Add(this.label1);
            this.Name = "frmChangePassword";
            this.Text = "Đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPasswordOld;
        private System.Windows.Forms.TextBox tbPasswordNew1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPasswordNew2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnThoat;
    }
}