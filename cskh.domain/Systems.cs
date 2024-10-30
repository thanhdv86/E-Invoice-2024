using System;

namespace cskh.domain
{
    public static class Systems
    {
        public static string AccountNumberValue { get; set; }
        public static string AddressValue { get; set; }
        public static string BankValue { get; set; }
        public static string CityValue { get; set; }
        public static string CompanyAbbreviatedValue { get; set; }
        public static string CompanyValue { get; set; }
        public static string CompanyValue1 { get; set; }
        public static string CompanyValue2 { get; set; }
        public static string EmailValue { get; set; }
        public static string EmailCskhValue { get; set; }
        public static string FaxValue { get; set; }
        public static string PasswordEmailValue { get; set; }
        public static string PhoneCCCValue { get; set; }
        public static string PhoneValue { get; set; }
        public static string ProvinceValue { get; set; }
        public static string StreetValue { get; set; }
        public static string TaxCodeValue { get; set; }
        public static string UserNameEmailValue { get; set; }
        public static string WardsValue { get; set; }
        public static int NamBatDau { get; set; }
        public static DateTime DateOfServer { get; set; }
        


        static Systems()
        {
            using (var ebi = new EiBusinessImpl())
            {
                AccountNumberValue = ebi.GetVariableValue("AccountNumberValue");
                AddressValue = ebi.GetVariableValue("AddressValue");
                BankValue = ebi.GetVariableValue("BankValue");
                CityValue = ebi.GetVariableValue("CityValue");
                CompanyAbbreviatedValue = ebi.GetVariableValue("CompanyAbbreviatedValue");
                CompanyValue = ebi.GetVariableValue("CompanyValue");
                CompanyValue2 = ebi.GetVariableValue("CompanyValue2");
                EmailValue = ebi.GetVariableValue("EmailValue");
                EmailCskhValue = ebi.GetVariableValue("EmailCskhValue");
                FaxValue = ebi.GetVariableValue("FaxValue");
                PasswordEmailValue = ebi.GetVariableValue("PasswordEmailValue");
                PhoneCCCValue = ebi.GetVariableValue("PhoneCCCValue");
                PhoneValue = ebi.GetVariableValue("PhoneValue");
                ProvinceValue = ebi.GetVariableValue("ProvinceValue");
                StreetValue = ebi.GetVariableValue("StreetValue");
                TaxCodeValue = ebi.GetVariableValue("TaxCodeValue");
                UserNameEmailValue = ebi.GetVariableValue("UserNameEmailValue");
                WardsValue = ebi.GetVariableValue("WardsValue");
                NamBatDau = int.Parse(ebi.GetVariableValue("NamBatDau"));
                var dt = ebi.GetDateOfServer();
                DateOfServer = Convert.ToDateTime(dt.Rows[0]["DateOfServer"]);                
            }
        }
       
    }
}
