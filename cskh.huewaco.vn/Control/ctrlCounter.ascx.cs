using System;
using System.Configuration;
using System.Globalization;
using System.Web;
using System.Reflection;
using System.Resources;
using cskh.domain;

namespace cskh.huewaco.vn.Control
{
    public partial class ctrlCounter : CsBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var obj = new CounterObject())
            {
                lblCounter.Text = ReturnCounter(obj.GetCounter().ToString());
                lblGuest.Text = Application["OnlineVisitors"].ToString();
            }
            using (var obj = new EiBusinessImpl())
            {
                var dt = obj.getUSER_ONLINE();
                lblUserOnline.Text = (dt != null && dt.Rows.Count > 0)
                    ? dt.Rows.Count.ToString(CultureInfo.InvariantCulture)
                    : 1.ToString(CultureInfo.InvariantCulture);
            }
        }
        private string ReturnCounter(string strinput)
        {
            int len = strinput.Length;
            string strResult = "";
            for (int i = 0; i < 8 - len ; i++)
            {
                strResult += "0";
            }
            strResult += strinput;
            strResult = strResult.Replace("0", "0 ");
            strResult = strResult.Replace("1", "1 ");
            strResult = strResult.Replace("2", "2 ");
            strResult = strResult.Replace("3", "3 ");
            strResult = strResult.Replace("4", "4 ");
            strResult = strResult.Replace("5", "5 ");
            strResult = strResult.Replace("6", "6 ");
            strResult = strResult.Replace("7", "7 ");
            strResult = strResult.Replace("8", "8 ");
            strResult = strResult.Replace("9", "9 ");
            return strResult;
        }

        #region MultiLanguages

        #endregion
        #region RenderingEvent
        override protected void OnInit(EventArgs e)
        {
            Load += Page_Load;
        }
        #endregion
    }
}