using System;
using System.Windows.Forms;
using cskh.domain;

namespace XMLSigner.ui
{
    public partial class frmMain : frmBase
    {        
        public frmMain()
        {
            InitializeComponent();
        }

        public void MenuList(MenuStrip mnu)
        {
            int a = 0;
            foreach (ToolStripItem item in mnu.Items)
            {
                var mnuItem = item as ToolStripMenuItem;

                if (mnuItem != null)
                {
                    a = a + 1;
                    GhiVoDMQuyen(a + "00", mnuItem.Text);
                    SubMenuList(mnuItem, a);
                }
            }
        }

        public void SubMenuList(ToolStripMenuItem mnuItem, int bi)
        {
            var i = 0;
            foreach (ToolStripItem item in mnuItem.DropDownItems)
            {
                var mi = item as ToolStripMenuItem;
                if (mi != null)
                {
                    i = i + 1;
                    using (var hbi = new EiBusinessImpl())
                    {
                        hbi.TaoDmPhanQuyen(bi + i.ToString().PadLeft(2, '0'), mi.Text);
                    }
                    //GhiVoDMQuyen(bi.ToString() + PadL(i.ToString(), '0', 2), mi.Text);
                }
            }
        }

        public void GhiVoDMQuyen(string bMuc, string bTenMenu)
        {
            using (var ebi = new EiBusinessImpl())
            {
                ebi.TaoDmPhanQuyen(bMuc, bTenMenu);
            }           
        }
        private void KhoaChucNang(string bQuyenSd)
        {
            switch (bQuyenSd)
            {
                case "*":
                    MenuList1(menuStrip1, "*");
                    break;
                case "-":
                    MenuList1(menuStrip1, "-");
                    break;
                default:
                    var bLen = bQuyenSd.Length;
                    while (bLen >= 3)
                    {
                        var bMuc = bQuyenSd.Substring(0, 3);
                        string bTenMenu;
                        using (var ebi = new EiBusinessImpl())
                        {
                            bTenMenu = ebi.GetTenMucFromMuc(bMuc);
                        }
                        MenuList1(menuStrip1, bTenMenu);
                        bQuyenSd = bQuyenSd.Substring(3);
                        bLen = bQuyenSd.Length;
                    }
                    break;
            }

        }
        private void MenuList1(MenuStrip mnu, string bTenMuc)
        {
            foreach (ToolStripItem item in mnu.Items)
            {
                var mnuItem = item as ToolStripMenuItem;
                if (mnuItem != null)
                {
                    if ((mnuItem.Text == bTenMuc | bTenMuc == "-") & mnuItem.Text != "Hệ thống")
                    {
                        mnuItem.Enabled = false;
                    }
                    if (bTenMuc == "*")
                    {
                        mnuItem.Enabled = true;
                    }
                    SubMenuList1(mnuItem, bTenMuc);
                }
            }
        }
        private void SubMenuList1(ToolStripMenuItem mnuItem, string bTenMuc)
        {
            foreach (ToolStripItem item in mnuItem.DropDownItems)
            {
                var mi = item as ToolStripMenuItem;
                if (mi != null)
                {
                    if ((mi.Text == bTenMuc | bTenMuc == "-") & !(mi.Text == "Đăng nhập" | mi.Text == "Kết thúc" | mi.Text == "Đăng xuất"))
                    {
                        mi.Enabled = false;
                    }
                    if (bTenMuc == "*")
                    {
                        mi.Enabled = true;
                    }
                }
            }
        }
        private void NL_DKHD_Click(object sender, EventArgs e)
        {
            //frmInvoiceNumMngt frmDKHD = new frmInvoiceNumMngt();
            var frmRegisterSery = new frmRegisterSery();
            frmRegisterSery.ShowDialog();
        }

        private void NL_KHD_Click(object sender, EventArgs e)
        {
            var frmKhd = new frmInvoiceSigner2();
            frmKhd.ShowDialog();
        }

        private void NL_HHD_Click(object sender, EventArgs e)
        {
            var frmHhd = new frmCancelResign();
            frmHhd.ShowDialog();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {            
            KhoaChucNang("*");
            string bQuyenHanTruyCap;
            //frmSignIn abc = new frmSignIn();
            //abc.ShowDialog();
            if (frmSignIn.user != null)
            {
                bQuyenHanTruyCap = frmSignIn.user.Privilege;
                slUser.Text = "Đang đăng nhập: " + frmSignIn.user.RealName;
            }
            else
            {
                bQuyenHanTruyCap = "-";
            }
            KhoaChucNang(bQuyenHanTruyCap);
         }

        private void TI_KY_Click(object sender, EventArgs e)
        {
            var frmXmlSigner = new frmXMLSigner();
            frmXmlSigner.ShowDialog();
        }

        private void DM_CTS_Click(object sender, EventArgs e)
        {
            var frmCerticateMngt = new frmCertificateMngt();
            frmCerticateMngt.ShowDialog();
        }

        private void abcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string bQuyenHanTruyCap;
            var frmSignIn = new frmSignIn();
            frmSignIn.ShowDialog();
            KhoaChucNang("*"); //Mở lại hết các quyền trước khi khóa chức năng   

            if (frmSignIn.user == null)
            {
                bQuyenHanTruyCap = "-";
            }
            else
            {
                bQuyenHanTruyCap = frmSignIn.user.Privilege;
                slUser.Text = "Đang đăng nhập: "+ frmSignIn.user.RealName;
            }

            KhoaChucNang(bQuyenHanTruyCap);
        }

        // DANG KY NGUOI DUNG
        private void DM_ND_Click(object sender, EventArgs e)
        {
            var frmDmNguoiDung = new frmDMNguoiDung();
            frmDmNguoiDung.ShowDialog();
        }

        // CAU HINH KET NOI
        private void HT_KN_Click(object sender, EventArgs e)
        {
            var frmConnectDb = new frmConnectDb();
            frmConnectDb.ShowDialog();
        }

        private void HT_EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HT_DX_Click(object sender, EventArgs e)
        {
            frmSignIn.user = null;
            slUser.Text = "Chưa đăng nhập";
            KhoaChucNang("-");
        }

        private void BC_TRACUUHD_Click(object sender, EventArgs e)
        {
            var frmSearchInvoice = new frmSearchInvoice(this);
            frmSearchInvoice.ShowDialog();
        }

        private void HT_PQuyen_Click(object sender, EventArgs e)
        {
            var frmPhanQuyen = new frmPhanQuyen();
            frmPhanQuyen.ShowDialog();
        }

        private void taoDMPQToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void taoDMPQToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var ebi = new EiBusinessImpl())
            {
                ebi.XoaDmpQuyen();
            }
            MenuList(menuStrip1);
        }

        private void BC26AC_Click(object sender, EventArgs e)
        {
            var frmBchdQuy = new frmBCHDQuy();
            frmBchdQuy.ShowDialog();
        }

        private void HT_DoiMK_Click(object sender, EventArgs e)
        {
            var frmChangePassword = new frmChangePassword();
            frmChangePassword.ShowDialog();
        }

        private void BC_TThaiKy_Click(object sender, EventArgs e)
        {
            var frmSignStatus = new frmSignStatus();
            frmSignStatus.ShowDialog();
        }

        private void BC_PXLSPKPH_Click(object sender, EventArgs e)
        {
            var frmBcpxlspkhl = new frmBCPXLSPKHL();
            frmBcpxlspkhl.ShowDialog();
        }


        private void thôngBáoCắtNướcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frmSms = new frmSmsCatNuoc())
            {
                Hide();
                frmSms.ShowDialog();
                Show();
            }
        }

        private void tạoMẫuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frmSms = new frmTaoMau())
            {
                Hide();
                frmSms.ShowDialog();
                Show();
            }
        }

        private void thôngBáoThúcNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frmSms = new frmSmsThucNo())
            {
                Hide();
                frmSms.ShowDialog();
                Show();
            }
        }

        private void mnEmail_Click(object sender, EventArgs e)
        {
            using (var frmEmailHddt = new frmEmailHDDT())
            {
                Hide();
                frmEmailHddt.ShowDialog();
                Show();
            }
        }

        private void mnuHDCD_Click(object sender, EventArgs e)
        {
            using (var frmHdcd = new frmHDCD())
            {
                Hide();
                frmHdcd.ShowDialog();
                Show();}
            //using (var frmHdcd = new frmHDCD())
            //{
            //    Hide();
            //    frmHdcd.ShowDialog();
            //    Show();
            //}
        }
    }
}
