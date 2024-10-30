namespace XMLSigner.ui
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.HT_DNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.HT_DX = new System.Windows.Forms.ToolStripMenuItem();
            this.HT_DoiMK = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.HT_KN = new System.Windows.Forms.ToolStripMenuItem();
            this.HT_PQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.HT_EXIT = new System.Windows.Forms.ToolStripMenuItem();
            this.nothingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DM_CTS = new System.Windows.Forms.ToolStripMenuItem();
            this.DM_ND = new System.Windows.Forms.ToolStripMenuItem();
            this.NL = new System.Windows.Forms.ToolStripMenuItem();
            this.NL_DKHD = new System.Windows.Forms.ToolStripMenuItem();
            this.NL_KHD = new System.Windows.Forms.ToolStripMenuItem();
            this.NL_HHD = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BC26AC = new System.Windows.Forms.ToolStripMenuItem();
            this.BC_TRACUUHD = new System.Windows.Forms.ToolStripMenuItem();
            this.BC_TThaiKy = new System.Windows.Forms.ToolStripMenuItem();
            this.BC_PXLSPKPH = new System.Windows.Forms.ToolStripMenuItem();
            this.TI_KyXML = new System.Windows.Forms.ToolStripMenuItem();
            this.TI_KY = new System.Windows.Forms.ToolStripMenuItem();
            this.taoDMPQToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sendSMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tạoMẫuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngBáoCắtNướcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngBáoThúcNợToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHDCD = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.slDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.nothingToolStripMenuItem,
            this.NL,
            this.báoCáoToolStripMenuItem,
            this.TI_KyXML});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1032, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HT_DNhap,
            this.HT_DX,
            this.HT_DoiMK,
            this.toolStripSeparator1,
            this.HT_KN,
            this.HT_PQuyen,
            this.HT_EXIT});
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(85, 20);
            this.toolStripMenuItem1.Text = "Hệ thống";
            // 
            // HT_DNhap
            // 
            this.HT_DNhap.Image = global::XMLSigner.Properties.Resources.user;
            this.HT_DNhap.Name = "HT_DNhap";
            this.HT_DNhap.Size = new System.Drawing.Size(202, 22);
            this.HT_DNhap.Text = "Đăng nhập";
            this.HT_DNhap.Click += new System.EventHandler(this.abcToolStripMenuItem_Click);
            // 
            // HT_DX
            // 
            this.HT_DX.Image = global::XMLSigner.Properties.Resources.user_off;
            this.HT_DX.Name = "HT_DX";
            this.HT_DX.Size = new System.Drawing.Size(202, 22);
            this.HT_DX.Text = "Đăng xuất";
            this.HT_DX.Click += new System.EventHandler(this.HT_DX_Click);
            // 
            // HT_DoiMK
            // 
            this.HT_DoiMK.Image = global::XMLSigner.Properties.Resources.key;
            this.HT_DoiMK.Name = "HT_DoiMK";
            this.HT_DoiMK.Size = new System.Drawing.Size(202, 22);
            this.HT_DoiMK.Text = "Đổi mật khẩu";
            this.HT_DoiMK.Click += new System.EventHandler(this.HT_DoiMK_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // HT_KN
            // 
            this.HT_KN.Image = global::XMLSigner.Properties.Resources.database_process;
            this.HT_KN.Name = "HT_KN";
            this.HT_KN.Size = new System.Drawing.Size(202, 22);
            this.HT_KN.Text = "Cấu hình kết nối";
            this.HT_KN.Click += new System.EventHandler(this.HT_KN_Click);
            // 
            // HT_PQuyen
            // 
            this.HT_PQuyen.Image = global::XMLSigner.Properties.Resources._lock;
            this.HT_PQuyen.Name = "HT_PQuyen";
            this.HT_PQuyen.Size = new System.Drawing.Size(202, 22);
            this.HT_PQuyen.Text = "Phân quyền người dùng";
            this.HT_PQuyen.Click += new System.EventHandler(this.HT_PQuyen_Click);
            // 
            // HT_EXIT
            // 
            this.HT_EXIT.Image = global::XMLSigner.Properties.Resources.next;
            this.HT_EXIT.Name = "HT_EXIT";
            this.HT_EXIT.Size = new System.Drawing.Size(202, 22);
            this.HT_EXIT.Text = "Kết thúc";
            this.HT_EXIT.Click += new System.EventHandler(this.HT_EXIT_Click);
            // 
            // nothingToolStripMenuItem
            // 
            this.nothingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DM_CTS,
            this.DM_ND});
            this.nothingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nothingToolStripMenuItem.Image")));
            this.nothingToolStripMenuItem.Name = "nothingToolStripMenuItem";
            this.nothingToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.nothingToolStripMenuItem.Text = "Danh mục";
            // 
            // DM_CTS
            // 
            this.DM_CTS.Image = global::XMLSigner.Properties.Resources.certificate;
            this.DM_CTS.Name = "DM_CTS";
            this.DM_CTS.Size = new System.Drawing.Size(182, 22);
            this.DM_CTS.Text = "Đăng ký chứng thư";
            this.DM_CTS.Click += new System.EventHandler(this.DM_CTS_Click);
            // 
            // DM_ND
            // 
            this.DM_ND.Image = global::XMLSigner.Properties.Resources.users;
            this.DM_ND.Name = "DM_ND";
            this.DM_ND.Size = new System.Drawing.Size(182, 22);
            this.DM_ND.Text = "Đăng ký người dùng";
            this.DM_ND.Click += new System.EventHandler(this.DM_ND_Click);
            // 
            // NL
            // 
            this.NL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NL_DKHD,
            this.NL_KHD,
            this.NL_HHD});
            this.NL.Image = ((System.Drawing.Image)(resources.GetObject("NL.Image")));
            this.NL.Name = "NL";
            this.NL.Size = new System.Drawing.Size(86, 20);
            this.NL.Text = "Nhập liệu";
            // 
            // NL_DKHD
            // 
            this.NL_DKHD.Image = global::XMLSigner.Properties.Resources.note_add;
            this.NL_DKHD.Name = "NL_DKHD";
            this.NL_DKHD.Size = new System.Drawing.Size(183, 22);
            this.NL_DKHD.Text = "Đăng ký HĐ sử dụng";
            this.NL_DKHD.Click += new System.EventHandler(this.NL_DKHD_Click);
            // 
            // NL_KHD
            // 
            this.NL_KHD.Image = global::XMLSigner.Properties.Resources.pencil;
            this.NL_KHD.Name = "NL_KHD";
            this.NL_KHD.Size = new System.Drawing.Size(183, 22);
            this.NL_KHD.Text = "Ký phát hành HĐ";
            this.NL_KHD.Click += new System.EventHandler(this.NL_KHD_Click);
            // 
            // NL_HHD
            // 
            this.NL_HHD.Image = global::XMLSigner.Properties.Resources.penci_red;
            this.NL_HHD.Name = "NL_HHD";
            this.NL_HHD.Size = new System.Drawing.Size(183, 22);
            this.NL_HHD.Text = "Hủy - Lập lại HĐ";
            this.NL_HHD.Click += new System.EventHandler(this.NL_HHD_Click);
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BC26AC,
            this.BC_TRACUUHD,
            this.BC_TThaiKy,
            this.BC_PXLSPKPH});
            this.báoCáoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("báoCáoToolStripMenuItem.Image")));
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // BC26AC
            // 
            this.BC26AC.Image = global::XMLSigner.Properties.Resources.calendar;
            this.BC26AC.Name = "BC26AC";
            this.BC26AC.Size = new System.Drawing.Size(271, 22);
            this.BC26AC.Text = "Tình hình sử dụng hóa đơn";
            this.BC26AC.Click += new System.EventHandler(this.BC26AC_Click);
            // 
            // BC_TRACUUHD
            // 
            this.BC_TRACUUHD.Image = global::XMLSigner.Properties.Resources.search2;
            this.BC_TRACUUHD.Name = "BC_TRACUUHD";
            this.BC_TRACUUHD.Size = new System.Drawing.Size(271, 22);
            this.BC_TRACUUHD.Text = "Tra cứu hóa đơn đã ký";
            this.BC_TRACUUHD.Click += new System.EventHandler(this.BC_TRACUUHD_Click);
            // 
            // BC_TThaiKy
            // 
            this.BC_TThaiKy.Image = global::XMLSigner.Properties.Resources.progress;
            this.BC_TThaiKy.Name = "BC_TThaiKy";
            this.BC_TThaiKy.Size = new System.Drawing.Size(271, 22);
            this.BC_TThaiKy.Text = "Tinh hình ký hóa đơn";
            this.BC_TThaiKy.Click += new System.EventHandler(this.BC_TThaiKy_Click);
            // 
            // BC_PXLSPKPH
            // 
            this.BC_PXLSPKPH.Image = global::XMLSigner.Properties.Resources.rptHdHuy;
            this.BC_PXLSPKPH.Name = "BC_PXLSPKPH";
            this.BC_PXLSPKPH.Size = new System.Drawing.Size(271, 22);
            this.BC_PXLSPKPH.Text = "Phiếu xử lý sản phẩm không phù hợp";
            this.BC_PXLSPKPH.Click += new System.EventHandler(this.BC_PXLSPKPH_Click);
            // 
            // TI_KyXML
            // 
            this.TI_KyXML.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TI_KY,
            this.taoDMPQToolStripMenuItem1,
            this.sendSMSToolStripMenuItem,
            this.mnEmail,
            this.mnuHDCD});
            this.TI_KyXML.Image = ((System.Drawing.Image)(resources.GetObject("TI_KyXML.Image")));
            this.TI_KyXML.Name = "TI_KyXML";
            this.TI_KyXML.Size = new System.Drawing.Size(77, 20);
            this.TI_KyXML.Text = "Tiện ích";
            // 
            // TI_KY
            // 
            this.TI_KY.Image = global::XMLSigner.Properties.Resources.xml_file;
            this.TI_KY.Name = "TI_KY";
            this.TI_KY.Size = new System.Drawing.Size(182, 22);
            this.TI_KY.Text = "Ký và Xác thực XML";
            this.TI_KY.Click += new System.EventHandler(this.TI_KY_Click);
            // 
            // taoDMPQToolStripMenuItem1
            // 
            this.taoDMPQToolStripMenuItem1.Name = "taoDMPQToolStripMenuItem1";
            this.taoDMPQToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.taoDMPQToolStripMenuItem1.Text = "TaoDMPQ";
            this.taoDMPQToolStripMenuItem1.Click += new System.EventHandler(this.taoDMPQToolStripMenuItem1_Click);
            // 
            // sendSMSToolStripMenuItem
            // 
            this.sendSMSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tạoMẫuToolStripMenuItem,
            this.thôngBáoCắtNướcToolStripMenuItem,
            this.thôngBáoThúcNợToolStripMenuItem});
            this.sendSMSToolStripMenuItem.Name = "sendSMSToolStripMenuItem";
            this.sendSMSToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.sendSMSToolStripMenuItem.Text = "Gửi SMS";
            // 
            // tạoMẫuToolStripMenuItem
            // 
            this.tạoMẫuToolStripMenuItem.Name = "tạoMẫuToolStripMenuItem";
            this.tạoMẫuToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.tạoMẫuToolStripMenuItem.Text = "Tạo mẫu";
            this.tạoMẫuToolStripMenuItem.Click += new System.EventHandler(this.tạoMẫuToolStripMenuItem_Click);
            // 
            // thôngBáoCắtNướcToolStripMenuItem
            // 
            this.thôngBáoCắtNướcToolStripMenuItem.Name = "thôngBáoCắtNướcToolStripMenuItem";
            this.thôngBáoCắtNướcToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.thôngBáoCắtNướcToolStripMenuItem.Text = "Thông báo cắt nước";
            this.thôngBáoCắtNướcToolStripMenuItem.Click += new System.EventHandler(this.thôngBáoCắtNướcToolStripMenuItem_Click);
            // 
            // thôngBáoThúcNợToolStripMenuItem
            // 
            this.thôngBáoThúcNợToolStripMenuItem.Name = "thôngBáoThúcNợToolStripMenuItem";
            this.thôngBáoThúcNợToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.thôngBáoThúcNợToolStripMenuItem.Text = "Thông báo thúc nợ";
            this.thôngBáoThúcNợToolStripMenuItem.Click += new System.EventHandler(this.thôngBáoThúcNợToolStripMenuItem_Click);
            // 
            // mnEmail
            // 
            this.mnEmail.Name = "mnEmail";
            this.mnEmail.Size = new System.Drawing.Size(182, 22);
            this.mnEmail.Text = "Gửi Email HĐĐT";
            this.mnEmail.Click += new System.EventHandler(this.mnEmail_Click);
            // 
            // mnuHDCD
            // 
            this.mnuHDCD.Name = "mnuHDCD";
            this.mnuHDCD.Size = new System.Drawing.Size(182, 22);
            this.mnuHDCD.Text = "Hóa đơn chuyển đổi";
            this.mnuHDCD.Click += new System.EventHandler(this.mnuHDCD_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slUser,
            this.toolStripStatusLabel2,
            this.slDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 438);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1032, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slUser
            // 
            this.slUser.Name = "slUser";
            this.slUser.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(712, 17);
            this.toolStripStatusLabel2.Text = resources.GetString("toolStripStatusLabel2.Text");
            // 
            // slDate
            // 
            this.slDate.Name = "slDate";
            this.slDate.Size = new System.Drawing.Size(0, 17);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 460);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "E-Invoice HueWACO";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem HT_DNhap;
        private System.Windows.Forms.ToolStripMenuItem HT_DX;
        private System.Windows.Forms.ToolStripMenuItem nothingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DM_CTS;
        private System.Windows.Forms.ToolStripMenuItem DM_ND;
        private System.Windows.Forms.ToolStripMenuItem HT_KN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem HT_PQuyen;
        private System.Windows.Forms.ToolStripMenuItem HT_EXIT;
        private System.Windows.Forms.ToolStripMenuItem NL;
        private System.Windows.Forms.ToolStripMenuItem NL_DKHD;
        private System.Windows.Forms.ToolStripMenuItem NL_KHD;
        private System.Windows.Forms.ToolStripMenuItem NL_HHD;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BC26AC;
        private System.Windows.Forms.ToolStripMenuItem TI_KyXML;
        private System.Windows.Forms.ToolStripMenuItem TI_KY;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel slDate;
        private System.Windows.Forms.ToolStripMenuItem BC_TRACUUHD;
        private System.Windows.Forms.ToolStripMenuItem taoDMPQToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem HT_DoiMK;
        private System.Windows.Forms.ToolStripMenuItem BC_TThaiKy;
        private System.Windows.Forms.ToolStripMenuItem BC_PXLSPKPH;
        private System.Windows.Forms.ToolStripMenuItem sendSMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tạoMẫuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngBáoCắtNướcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngBáoThúcNợToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnEmail;
        private System.Windows.Forms.ToolStripMenuItem mnuHDCD;
    }
}