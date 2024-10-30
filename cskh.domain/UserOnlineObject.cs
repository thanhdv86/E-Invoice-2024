using System.Data;

namespace cskh.domain
{
    public struct NumberUserOnlinesStruct
    {
        public int NumberUserOnlines;
        public int NumberAnynomousOnlines;
        public int NumberMemberOnlines;
        public int NumberMembers;
    }
    public class UserOnlineObject : DataAccess
    {
        public UserOnlineObject()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void UserOnlineAccess(string strSessionId, string strUserHostAddress, int intCurrentNumber)
        {
            base.Open();
            Db.runDynamicSqlNoQuery("procUserOnlineAccess", new string[] { "@strSessionId", "@strUserHostAddress", "@intCurrentNumber" }, new object[] { @strSessionId, @strUserHostAddress, @intCurrentNumber }, System.Data.CommandType.StoredProcedure);
            base.Close();
        }
        public void UserOnlineEnd(string strSessionId)
        {
            base.Open();
            Db.runDynamicSqlNoQuery("procUserOnlineEnd", new string[] { "@strSessionId" }, new object[] { @strSessionId }, System.Data.CommandType.StoredProcedure);
            base.Close();
        }
        public void UserOnlineLogin(string strSessionId, string strUserId)
        {
            base.Open();
            Db.runDynamicSqlNoQuery("procUserOnlineLogin", new string[] { "@strSessionId", "@strUserId" }, new object[] { @strSessionId, @strUserId }, System.Data.CommandType.StoredProcedure);
            base.Close();
        }
        public void UserOnlineLogoff(string strSessionId)
        {
            base.Open();
            Db.runDynamicSqlNoQuery("procUserOnlineLogOff", new string[] { "@strSessionId" }, new object[] { @strSessionId }, System.Data.CommandType.StoredProcedure);
            base.Close();
        }
        public NumberUserOnlinesStruct GetNumberUserOnlines()
        {
            base.Open();
            IDataReader dr = Db.runSQLReader("procGetNumberUserOnlines", System.Data.CommandType.StoredProcedure, System.Data.CommandBehavior.CloseConnection);
            NumberUserOnlinesStruct ret;
            ret.NumberAnynomousOnlines = 0;
            ret.NumberMemberOnlines = 0;
            ret.NumberUserOnlines = 0;
            ret.NumberMembers = 0;
            if (dr.Read())
            {
                ret.NumberUserOnlines = dr.GetInt32(0);
                if (dr.NextResult())
                {
                    if (dr.Read()) ret.NumberAnynomousOnlines = dr.GetInt32(0);
                    if (dr.NextResult())
                    {
                        if (dr.Read()) ret.NumberMembers = dr.GetInt32(0);

                    }
                }
                ret.NumberMemberOnlines = ret.NumberUserOnlines - ret.NumberAnynomousOnlines;
            }
            base.Close();
            return ret;
        }
        public string GetIdUserOnlines()
        {
            string str = "";
            base.Open();
            IDataReader dr = Db.runSQLReader("procGetIdUserOnlines", System.Data.CommandType.StoredProcedure, System.Data.CommandBehavior.CloseConnection);
            if (dr.Read())
            {
                str = dr.GetString(0);
                while (dr.Read())
                {
                    str += ";" + dr.GetString(0);
                }
            }
            base.Close();
            return str;
        }
    }
}