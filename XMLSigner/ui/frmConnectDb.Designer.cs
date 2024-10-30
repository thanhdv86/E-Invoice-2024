namespace XMLSigner.ui
{
    partial class frmConnectDb
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
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDbname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.bntConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkApplyBoth = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConnect2 = new System.Windows.Forms.Button();
            this.tbserver2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbdbname2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbusername2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbpassword2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database Server";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(128, 35);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(184, 20);
            this.txtServer.TabIndex = 1;
            this.txtServer.Text = "10.72.8.160";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database name";
            // 
            // txtDbname
            // 
            this.txtDbname.Location = new System.Drawing.Point(128, 64);
            this.txtDbname.Name = "txtDbname";
            this.txtDbname.Size = new System.Drawing.Size(184, 20);
            this.txtDbname.TabIndex = 3;
            this.txtDbname.Text = "cskh.huewaco.vn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(128, 89);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(184, 20);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.Text = "huewaco";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(128, 122);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(184, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.Text = "hue@123";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // bntConnect
            // 
            this.bntConnect.Location = new System.Drawing.Point(233, 194);
            this.bntConnect.Name = "bntConnect";
            this.bntConnect.Size = new System.Drawing.Size(75, 23);
            this.bntConnect.TabIndex = 8;
            this.bntConnect.Text = "Test kết nối";
            this.bntConnect.UseVisualStyleBackColor = true;
            this.bntConnect.Click += new System.EventHandler(this.bntConnect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(177, 457);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(96, 457);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkApplyBoth);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bntConnect);
            this.groupBox1.Controls.Add(this.txtDbname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Location = new System.Drawing.Point(26, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 231);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CSDL Hóa đơn điện tử";
            // 
            // chkApplyBoth
            // 
            this.chkApplyBoth.AutoSize = true;
            this.chkApplyBoth.Location = new System.Drawing.Point(128, 160);
            this.chkApplyBoth.Name = "chkApplyBoth";
            this.chkApplyBoth.Size = new System.Drawing.Size(180, 17);
            this.chkApplyBoth.TabIndex = 8;
            this.chkApplyBoth.Text = "Áp dụng kết nối cho CSDL CRM";
            this.chkApplyBoth.UseVisualStyleBackColor = true;
            this.chkApplyBoth.CheckedChanged += new System.EventHandler(this.chkApplyBoth_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConnect2);
            this.groupBox2.Controls.Add(this.tbserver2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbdbname2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbusername2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbpassword2);
            this.groupBox2.Location = new System.Drawing.Point(26, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 185);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CSDL CRM";
            // 
            // btnConnect2
            // 
            this.btnConnect2.Location = new System.Drawing.Point(233, 148);
            this.btnConnect2.Name = "btnConnect2";
            this.btnConnect2.Size = new System.Drawing.Size(75, 23);
            this.btnConnect2.TabIndex = 9;
            this.btnConnect2.Text = "Test kết nối";
            this.btnConnect2.UseVisualStyleBackColor = true;
            this.btnConnect2.Click += new System.EventHandler(this.btnConnect2_Click);
            // 
            // tbserver2
            // 
            this.tbserver2.Location = new System.Drawing.Point(128, 35);
            this.tbserver2.Name = "tbserver2";
            this.tbserver2.Size = new System.Drawing.Size(184, 20);
            this.tbserver2.TabIndex = 1;
            this.tbserver2.Text = "10.72.8.160";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Database Server";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Database name";
            // 
            // tbdbname2
            // 
            this.tbdbname2.Location = new System.Drawing.Point(128, 64);
            this.tbdbname2.Name = "tbdbname2";
            this.tbdbname2.Size = new System.Drawing.Size(184, 20);
            this.tbdbname2.TabIndex = 3;
            this.tbdbname2.Text = "cskh.huewaco.vn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Username";
            // 
            // tbusername2
            // 
            this.tbusername2.Location = new System.Drawing.Point(128, 89);
            this.tbusername2.Name = "tbusername2";
            this.tbusername2.Size = new System.Drawing.Size(184, 20);
            this.tbusername2.TabIndex = 5;
            this.tbusername2.Text = "huewaco";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Password";
            // 
            // tbpassword2
            // 
            this.tbpassword2.Location = new System.Drawing.Point(128, 122);
            this.tbpassword2.Name = "tbpassword2";
            this.tbpassword2.Size = new System.Drawing.Size(184, 20);
            this.tbpassword2.TabIndex = 7;
            this.tbpassword2.Text = "hue@123";
            this.tbpassword2.UseSystemPasswordChar = true;
            // 
            // frmConnectDb
            // 
            this.AcceptButton = this.bntConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 521);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.MaximizeBox = false;
            this.Name = "frmConnectDb";
            this.Text = "Kết nối CSDL";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDbname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button bntConnect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkApplyBoth;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConnect2;
        private System.Windows.Forms.TextBox tbserver2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbdbname2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbusername2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbpassword2;

    }
}