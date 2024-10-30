using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using cskh.domain;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using XMLSigner.data;
using XMLSigner.report;
using System.Threading;
using System.Globalization;
namespace XMLSigner.ui
{
    public partial class frmBCPXLSPKHL : frmBase
    {
        public frmBCPXLSPKHL()
        {
            InitializeComponent();
        }

        private void frmBCPXLSPKHL_Load(object sender, EventArgs e)
        {
            //bindKV();
            //bindKy();
            SignUtil.BindKv(cbKV, "Tất cả", "%");
            SignUtil.BindKy(cbKy, tbNam);
        }

        //private void bindKV()
        //{
        //    using (var ebi = new CrBusinessImpl())
        //    {
        //        var dt = ebi.GetKv();
        //        var dr = dt.NewRow();
        //        dr["MAKV"] = "%"; // tat ca chi nhanh
        //        dr["TENKV"] = "Tất cả";

        //        dt.Rows.InsertAt(dr, 0);

        //        cbKV.DataSource = dt;
        //        cbKV.ValueMember = "MAKV";
        //        cbKV.DisplayMember = "TENKV";

        //        cbKV.SelectedIndex = 0;
        //    }
        //}

        //private void bindKy()
        //{
        //    using (var ebi = new CrBusinessImpl())
        //    {
        //        var ds = ebi.GetKyHd();
        //        cbKy.SelectedIndex = Convert.ToInt16(ds.Rows[0]["THANG"].ToString());
        //        tbNam.Text = ds.Rows[0]["NAM"].ToString();
        //    }
        //}

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNam.Text))
            {
                showMessage("Vui lòng chọn năm", MessageType.Error);
                return;
            }
            if (cbKy.SelectedIndex == 0 || cbKy.SelectedIndex == -1)
            {
                showMessage("Vui lòng chọn kỳ", MessageType.Error);
                return;
            }
            if (cbKV.SelectedIndex == -1)
            {
                showMessage("Vui lòng chọn chi nhánh", MessageType.Error);
                return;
            }

            try
            {

                DataTable dtth;// danh sach tong hop, con thieu cot khu vuc (chi nhanh)
                DataTable dtdp;// danh sach dp co khu vuc

                SplashScreenManager.ShowForm(this, typeof(frmBaseWaitform));
                using (var ebi = new EiBusinessImpl())
                {
                    dtth = ebi.tonghop_PXLSPKHP(Convert.ToInt16(tbNam.Text), cbKy.SelectedIndex);
                }

                if (dtth != null && dtth.Rows.Count > 0)
                {
                    using (var cbi = new CrBusinessImpl())
                    {
                        var ds = cbi.getListDP_withKV();
                        dtdp = ds.Tables[0];
                    }
                    if (dtdp != null && dtdp.Rows.Count > 0)
                    {
                        var dtthkv = DataTableHelper.JoinTwoDataTablesOnOneColumn(dtth, dtdp, "MADP", DataTableHelper.JoinType.Inner);
                        if (dtthkv != null && dtthkv.Rows.Count > 0)
                        {
                            if (cbKV.SelectedValue.ToString() != "%")
                            {
                                var filteredByKv = from r in dtthkv.AsEnumerable()
                                                   where r.Field<string>("MAKV") == cbKV.SelectedValue.ToString()
                                                   select r;

                                dtthkv = filteredByKv.Any() ? filteredByKv.CopyToDataTable() : dtthkv.Clone();
                            }
                            SplashScreenManager.CloseForm(false);
                            var report = new rptPXLSPKHL { DataSource = dtthkv, DataMember = "" };
                            report.title(cbKy.Text, tbNam.Text, frmSignIn.user.RealName, cbKV.Text);
                            var tool = new ReportPrintTool(report);
                            tool.ShowPreview();
                            Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                    SplashScreenManager.CloseForm(false);
                    Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi DB:" + ex.Message, "Lỗi [" + ex.Number + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra:" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            finally 
            {

            }
        }

    }
}
