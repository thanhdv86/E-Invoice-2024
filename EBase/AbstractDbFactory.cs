using System;
using System.Data;
using System.IO;

namespace EBase
{
    public abstract class AbstractDbFactory
    {
        internal static string system;

        public abstract IDbTransaction BeginTransaction();
        public abstract void Close();
        internal static string[] generateParamNames(string query)
        {
            var num = query.Split(new char[] { '@' }).Length - 1;
            if (num <= 0)
            {
                return null;
            }
            var strArray = new string[num];
            var strArray2 = query.Split(new char[] { '@' });
            for (var i = 1; i < strArray2.Length; i++)
            {
                strArray[i - 1] = "@";
                for (var j = 0; j < strArray2[i].Length; j++)
                {
                    string[] strArray4;
                    IntPtr ptr;
                    if (" ,)".IndexOf(strArray2[i].Substring(j, 1)) >= 0)
                    {
                        break;
                    }
                    (strArray4 = strArray)[(int) (ptr = (IntPtr) (i - 1))] = strArray4[(int) ptr] + strArray2[i].Substring(j, 1);
                }
            }
            return strArray;
        }

        public abstract IDataReader getBLOB(string query, CommandType commandType);
        public static AbstractDbFactory getFactory(string system)
        {
            AbstractDbFactory.system = system;
            if (system.ToLower().Equals("mssql"))
            {
                return getMSSQLDb();
            }
            if (system.ToLower().Equals("odbc"))
            {
                return getODBCDb();
            }
            if (system.ToLower().Equals("oledb"))
            {
                return getOLEDBDb();
            }
            return null;
        }

        private static AbstractDbFactory getMSSQLDb()
        {
            return new MSSQLFactory();
        }

        private static AbstractDbFactory getODBCDb()
        {
            return new ODBCFactory();
        }

        private static AbstractDbFactory getOLEDBDb()
        {
            return new OLEDBFactory();
        }

        public abstract bool open(string connectStr);
        public abstract void runDynamicSqlNoQuery(string query, DbParameter[] parameters, CommandType commandType);
        public abstract int runDynamicSqlNoQuery(string query, string[] paramNames, object[] paramValues, CommandType commandType);
        public abstract int runDynamicSqlNoQuery(string query, string[] paramNames, object[] paramValues, ParameterDirection[] paramDirections, CommandType commandType);
        public abstract DataSet runDynamicSqlQuery(string query, DbParameter[] parameters, CommandType commandType);
        public abstract IDataReader runDynamicSqlQuery(string query, DbParameter[] parameters, CommandType commandType, CommandBehavior behavior);
        public abstract DataSet runDynamicSqlQuery(string query, string[] paramNames, object[] paramValues, CommandType commandType);
        public abstract DataSet runDynamicSqlQuery(string query, DbParameter[] parameters, CommandType commandType, int startIndex, int maxRecords);
        public abstract IDataReader runDynamicSqlQuery(string query, string[] paramNames, object[] paramValues, CommandType commandType, CommandBehavior behavior);
        public abstract DataSet runDynamicSqlQuery(string query, string[] paramNames, object[] paramValues, CommandType commandType, DataSet ds, string tableName);
        public abstract DataSet runDynamicSqlQuery(string query, string[] paramNames, object[] paramValues, CommandType commandType, int startIndex, int maxRecords);
        public abstract object runDynamicSqlScalar(string query, DbParameter[] parameters, CommandType commandType);
        public abstract object runDynamicSqlScalar(string query, string[] paramNames, object[] paramValues, CommandType commandType);
        public abstract int runSQLNoQuery(string query);
        public abstract int runSQLNoQuery(string query, CommandType commandType);
        public abstract DataSet runSQLQuery(string query);
        public abstract DataSet runSQLQuery(string query, CommandType commandType);
        public abstract DataSet runSQLQuery(string query, DataSet ds, string tableName);
        public abstract DataSet runSQLQuery(string query, int startIndex, int maxRecords);
        public abstract DataSet runSQLQuery(string query, string datasetName, string tableName);
        public abstract DataSet runSQLQuery(string query, DataSet ds, string tableName, CommandType commandType);
        public abstract DataSet runSQLQuery(string query, int startIndex, int maxRecords, CommandType commandType);
        public abstract DataSet runSQLQuery(string query, string datasetName, string tableName, CommandType commandType);
        public abstract DataSet runSQLQuery(string query, DataSet ds, string tableName, int startIndex, int maxRecords);
        public abstract DataSet runSQLQuery(string query, string datasetName, string tableName, int startIndex, int maxRecords);
        public abstract DataSet runSQLQuery(string query, DataSet ds, string tableName, int startIndex, int maxRecords, CommandType commandType);
        public abstract DataSet runSQLQuery(string query, string datasetName, string tableName, int startIndex, int maxRecords, CommandType commandType);
        public abstract IDataReader runSQLReader(string query, CommandBehavior behavior);
        public abstract IDataReader runSQLReader(string query, CommandType commandType);
        public abstract IDataReader runSQLReader(string query, CommandType commandType, CommandBehavior behavior);
        public abstract int updateBLOB(string tableName, string fieldName, string whereString, Stream fs);
        public abstract int updateBLOBData(string query, string paramName, byte[] binary, CommandType commandType);
    }
}

