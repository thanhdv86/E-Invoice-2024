using System;
using System.Data;
using cskh.domain;

namespace cskh.huewaco.vn
{
    public class User
    {
        #region Operator
        private string _strUsername = "";
        private string _strContractNumber = "";
        private string _strCustomerName = "";
        private string _strMaLoTrinh = "";
        private string _strMaDanhBo = "";
        private string _strMaKhuVuc = "";
        private string _strDiaChi = "";
        private string _strSdt = "";
        private int intAdminLevel = -1;
        #endregion
        #region Property
        public string Username
        {
            get { return _strUsername; }
            set { _strUsername = value; }
        }
        public string ContractNumber
        {
            get { return _strContractNumber; }
            set { _strContractNumber = value; }
        }
        public string CustomerName
        {
            get { return _strCustomerName; }
            set { _strCustomerName = value; }
        }

        public string DiaChi
        {
            get { return _strDiaChi; }
            set { _strDiaChi = value; }
        }
        public string MaLoTrinh
        {
            get { return _strMaLoTrinh; }
            set { _strMaLoTrinh = value; }
        }
        public string MaDanhBo
        {
            get { return _strMaDanhBo; }
            set { _strMaDanhBo = value; }
        }

        public string MaKhuVuc
        {
            get { return _strMaKhuVuc; }
            set { _strMaKhuVuc = value; }
        }


        public bool IsSuperUser { get; set; }

        public bool IsAdminLevelBrand
        {
            get { return (intAdminLevel == 2); }
        }
        public bool IsNormalUser
        {
            get { return (intAdminLevel == 3); }
        }

        public string SDT 
        {
            get { return _strSdt; }
            set { _strSdt = value; }
        }

        #endregion
        public User(string _strUsername)
        {
            IsSuperUser = false;
            this._strUsername = _strUsername;
            using (var ei = new EiBusinessImpl())
            {
                IDataReader dr = ei.GetUser(this._strUsername);
                if (dr.Read())
                {
                    _strContractNumber = dr["IdKh"].ToString();
                    _strCustomerName = dr["TenKhachHang"].ToString();
                    _strMaLoTrinh = dr["MaLoTrinh"].ToString();
                    _strMaDanhBo = dr["MaDB"].ToString();
                    _strMaKhuVuc = dr["MaKV"].ToString();
                    _strDiaChi = dr["DiaChi"].ToString();
                    _strSdt = dr["SDT"].ToString();
                    IsSuperUser = Convert.ToBoolean(dr["IsSuperUser"]);
                    intAdminLevel = Convert.ToInt32(dr["AdminLevel"]);
                }
            }
        }
    }
}