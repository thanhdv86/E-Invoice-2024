using System;
using System.Data;

namespace cskh.domain
{
    public class USER_LOGIN : DataAccess
    {
        #region Operator
        private string _SESSION_ID;
        private string _USER_NAME;
        private DateTime _DATE_CHECKIN;
        private DateTime _DATE_CHECKOUT;
        private string _HOST_ADDRESS;
        #endregion

        #region Property
        public string SESSION_ID
        {
            get { return _SESSION_ID; }
            set { _SESSION_ID = value; }
        }
        public string USER_NAME
        {
            get { return _USER_NAME; }
            set { _USER_NAME = value; }
        }
        public DateTime DATE_CHECKIN
        {
            get { return _DATE_CHECKIN; }
            set { _DATE_CHECKIN = value; }
        }
        public DateTime DATE_CHECKOUT
        {
            get { return _DATE_CHECKOUT; }
            set { _DATE_CHECKOUT = value; }
        }
        public string HOST_ADDRESS
        {
            get { return _HOST_ADDRESS; }
            set { _HOST_ADDRESS = value; }
        }
        #endregion

        #region Procedure
        public USER_LOGIN()
        {

        }
        public USER_LOGIN(string _bSESSION_ID, string _bUSER_NAME, string _bHOST_ADDRESS)
        {
            _SESSION_ID = _bSESSION_ID;
            _USER_NAME = _bUSER_NAME;
            _HOST_ADDRESS = _bHOST_ADDRESS;
        }
        public void setUSER_LOGIN(string strSessionID, string strUsername, string strUserHostAddress)
        {
            string strobjectname = "sp_setUSER_LOGIN";
            string[] names = new string[] { "@SESSION_ID", "@USER_NAME", "@HOST_ADDRESS" };
            object[] values = new object[] { strSessionID, strUsername, strUserHostAddress };
            base.Open();
            Db.runDynamicSqlNoQuery(strobjectname, names, values, CommandType.StoredProcedure);
            base.Close();
        }
        #endregion
    }
}