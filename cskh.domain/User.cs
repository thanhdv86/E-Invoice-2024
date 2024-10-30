namespace cskh.domain
{
    public class User
    {
        #region Properties
        public string Username { get; set; }
        public string Password { get; set; }
        public string RealName { get; private set; }
        public string Privilege { get; set; }

        #endregion Properties
        #region constructor
        public User() { }
        public User(string username, string password)
        {
            using (var ebi = new EiBusinessImpl())
            {
                this.Username = username;
                this.Password = password;
                var dt = ebi.CheckLogin(username, password);
                this.RealName = dt.Rows[0][Constants.TENNGUOIDUNG].ToString();
                this.Privilege = dt.Rows[0][Constants.QUYENHAN].ToString();

                // Tải tất cả các Thông tin Globals ở đây!
                Systems.AccountNumberValue = ebi.GetVariableValue("AccountNumberValue");
                Systems.AddressValue = ebi.GetVariableValue("AddressValue");
                Systems.BankValue = ebi.GetVariableValue("BankValue");
                Systems.CityValue = ebi.GetVariableValue("CityValue");
                Systems.CompanyAbbreviatedValue = ebi.GetVariableValue("CompanyAbbreviatedValue");
                Systems.CompanyValue = ebi.GetVariableValue("CompanyValue");
                Systems.CompanyValue1 = ebi.GetVariableValue("CompanyValue1");
                Systems.CompanyValue2 = ebi.GetVariableValue("CompanyValue2");
                Systems.EmailValue = ebi.GetVariableValue("EmailValue");
                Systems.FaxValue = ebi.GetVariableValue("FaxValue");
                Systems.PasswordEmailValue = ebi.GetVariableValue("PasswordEmailValue");
                Systems.PhoneCCCValue = ebi.GetVariableValue("PhoneCCCValue");
                Systems.PhoneValue = ebi.GetVariableValue("PhoneValue");
                Systems.ProvinceValue = ebi.GetVariableValue("ProvinceValue");
                Systems.StreetValue = ebi.GetVariableValue("StreetValue");
                Systems.TaxCodeValue = ebi.GetVariableValue("TaxCodeValue");
                Systems.UserNameEmailValue = ebi.GetVariableValue("UserNameEmailValue");
                Systems.WardsValue = ebi.GetVariableValue("WardsValue");  
            }
        }
        #endregion constructor


    }

    public class MauSms
    {
        private string _tieuDe;
        private string _mauNd;

        public MauSms(string tieuDe, string mauNd)
        {
            _tieuDe = tieuDe;
            _mauNd = mauNd;
        }
    }
}
