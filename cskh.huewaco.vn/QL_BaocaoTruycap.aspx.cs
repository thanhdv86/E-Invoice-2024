using System;
using System.Configuration;
using System.Reflection;
using System.Resources;
using System.Web;
using System.Web.UI.WebControls;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public partial class QL_BaocaoTruycap : CsBaseControl
    {
        DataGridInterface FuncGrid = new DataGridInterface();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                User objUser = new User(HttpContext.Current.User.Identity.Name);
                if (!objUser.IsSuperUser) Response.Redirect("Default.aspx");
            }
            SetUI();
            
            if (!this.IsPostBack) BindCondition();
        }

        private void BindCondition()
        {
            datFrom.Date = DateTime.Now.AddDays(-30); datTo.Date = DateTime.Now;
            using (var obj = new EiBusinessImpl())
            {
                drlDonvi.DataSource = obj.get_DSDonvi();
                drlDonvi.DataTextField = "TEN_DVIQLY";
                drlDonvi.DataValueField = "MA_DVIQLY";
                drlDonvi.DataBind();
            }
            drlDonvi.Items.Insert(0, new ListItem(" -- Tất cả các đơn vị -- ", ""));
        }
        private void BindData(string MA_DVIQLY, string TUNGAY, string DENNGAY)
        {
            using (var obj = new EiBusinessImpl())
            {
                divResult.Visible = true;
                dgSchedule.DataSource = MA_DVIQLY == "" ? obj.getUSER_LOGIN(TUNGAY, DENNGAY) : obj.getUSER_LOGIN(MA_DVIQLY, TUNGAY, DENNGAY);
                dgSchedule.DataBind();
                dgSchedule.ShowFooter = (bool)(dgSchedule.Items.Count <= 0);
                FuncGrid.GetOutOverColor(dgSchedule, this, "DDDDDD");
                if (dgSchedule.Items.Count > 0) ProcessTotal(dgSchedule);
            }
        }
        private void RemoveCell(DataGrid dg, int index, int iCount)
        {
            dg.Items[index - iCount].Cells[0].RowSpan = iCount;
            dg.Items[index - iCount].Cells[0].HorizontalAlign = HorizontalAlign.Left;
            for (int i = 0; i < iCount - 1; i++)
            {
                dg.Items[index + 1 + i - iCount].Cells.RemoveAt(0);
                dg.Items[index + 1 + i - iCount].Cells[1].HorizontalAlign = HorizontalAlign.Right;
            }
        }
        private void ProcessTotal(DataGrid dg)
        {
            var myDg = (DataGrid)dg;
            var strFirstCode = myDg.Items[0].Cells[0].Text;
            var iIndex = 0;
            var intSubTotal = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var iCount = 0;
            for (var i = 0; i < myDg.Items.Count; i++)
            {
                bool flg;
                if (i == myDg.Items.Count - 1)
                {
                    flg = (myDg.Items[i].Cells[0].Text != strFirstCode);
                    if (!flg)
                    {
                        //for (int iCell = 0; iCell < 22; iCell++) try{intSubTotal[iCell] += Convert.ToInt16(myDg.Items[i].Cells[iCell + 3].Text);} catch { }
                        iCount++;
                    }
                    else
                    {
                        //AddSubTotal(myDg, intSubTotal, iIndex, i, iCount);
                        //intSubTotal = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        RemoveCell(myDg, i, iCount);
                        //for (int iCell = 0; iCell < 22; iCell++) try{intSubTotal[iCell] += Convert.ToInt16(myDg.Items[i].Cells[iCell + 3].Text);} catch { }
                        iCount = 1;
                        iIndex++;
                    }
                    //AddSubTotal(myDg, intSubTotal, iIndex, i + 1, iCount);
                    //intSubTotal = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    RemoveCell(myDg, i + 1, iCount);
                    //AddTotal(myDg, intTotal, iIndex + 1, i + 1);
                }
                else
                {
                    flg = (myDg.Items[i].Cells[0].Text != strFirstCode);
                    if (!flg)
                    {
                        //for (int iCell = 0; iCell < 22; iCell++) try{ intSubTotal[iCell] += Convert.ToInt16(myDg.Items[i].Cells[iCell + 3].Text);} catch { }
                        iCount++;
                    }
                    else
                    {
                        //Add Sub total
                        //AddSubTotal(myDg, intSubTotal, iIndex, i, iCount);
                        RemoveCell(myDg, i, iCount);
                        iIndex++;
                        iCount = 1;
                        //intSubTotal = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        //for (int iCell = 0; iCell < 22; iCell++) try{ intSubTotal[iCell] += Convert.ToInt16(myDg.Items[i].Cells[iCell + 3].Text);} catch { }
                        strFirstCode = myDg.Items[i].Cells[0].Text;
                    }
                }
            }
        }

        #region MultiLanguages
        public override void SetUI()
        {

        }
        #endregion
        #region RenderingEvent
        override protected void OnInit(EventArgs e)
        {
            Load += Page_Load;
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData(drlDonvi.SelectedValue, datFrom.Date.ToString("yyyyMMdd"), datTo.Date.ToString("yyyyMMdd"));
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void dgSchedule_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells.RemoveAt(1);
                e.Item.Cells.RemoveAt(1);
                e.Item.Cells[0].ColumnSpan = 3;
            }
        }
        protected void dgSchedule_DataBinding(object sender, EventArgs e)
        {
            var dg = (DataGrid)sender;
        }
    }
}