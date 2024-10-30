using System;
using System.Web.UI.WebControls;
using cskh.domain;

namespace cskh.huewaco.vn.Control
{
    public partial class ctrlSearch : CsBaseUserControl
    {
        private string strSearchValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData(txtValue.Text, drlDonvi.SelectedValue);
        }
        
        protected void rb_CheckedChanged(object sender, EventArgs e)
        {
            var row = (DataGridItem)((RadioButton)sender).NamingContainer;
            foreach (DataGridItem r in dgResult.Items)
            {
                if (r != row)
                    ((RadioButton)r.FindControl("rb")).Checked = false;
            }
        }
        private void BindData(string Value, string DVIQLY)
        {
            using (var ebi = new EiBusinessImpl())
            {
                var dt = ebi.GetCustomerSearch(Value, DVIQLY);
                if (dt.Rows.Count > 0)
                {
                    divResult.Visible = true;
                    dgResult.DataSource = dt;
                    dgResult.DataBind();
                }
                else
                {
                    dgResult.DataSource = null;
                    dgResult.DataBind();    
                }
            }
        }
        #region MultiLanguages
        public override void SetUI()
        {
            strSearchValue = getString("strSearchValue");
            txtValue.Text = getString("strSampleMaKH");
            hddSample.Value = getString("strSampleMaKH") + "," + getString("strSampleTenKH") + "," + getString("strSampleTenAbv");
        }
        #endregion
        #region RenderingEvent
        override protected void OnInit(EventArgs e)
        {
            SetUI();
            Load += Page_Load;
            string strScript = @"<SCRIPT language='javascript'>
                                    function nulltext(objValue, objTieuchi, objSample) {
                                        var objHddSample = document.getElementById(objSample);                                        
                                        var objDrlTieuchi = document.getElementById(objTieuchi);
                                        Sample = objHddSample.value.split(',');
                                        if (objValue.value == Sample[objDrlTieuchi.selectedIndex]) objValue.value = '';
                                        else if (objValue.value == '') objValue.value = Sample[objDrlTieuchi.selectedIndex];                                        
                                    }
                                    function OnSelectedIndexChange(objTieuchi, objValue, objSample)
                                    {
                                        var objValue = document.getElementById(objValue);                                        
                                        var objHddSample = document.getElementById(objSample);
                                        Sample = objHddSample.value.split(',');
                                        objValue.value = Sample[objTieuchi.selectedIndex];

                                        //objValue.value = objDrlTieuchi.options[objTieuchi.selectedIndex].value;
                                    }
                                </script>";
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptFocus", strScript);
            txtValue.Attributes.Add("onfocus", "nulltext(this, '" + drlTieuchi.ClientID + "', '" + hddSample.ClientID + "');");
            txtValue.Attributes.Add("onblur", "nulltext(this, '" + drlTieuchi.ClientID + "', '" + hddSample.ClientID + "');");            
            drlTieuchi.Attributes.Add("onChange", "return OnSelectedIndexChange(this, '" + txtValue.ClientID + "', '" + hddSample.ClientID + "');");
        }
        #endregion                
    }
}