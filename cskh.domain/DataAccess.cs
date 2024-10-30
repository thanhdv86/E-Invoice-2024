using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EBase;

namespace cskh.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class DataAccess : System.IDisposable
    {
        public static string ConnectionString;
        private const string DbType = "mssql";
        // connect to hddt/cskh db (default). If intialize a DataAccess via DataAccess(), this connection will be used.
        public static ConnectionStringSettings EiConSettings = ConfigurationManager.ConnectionStrings[Constants.EI_CON_NAME];
        public static ConnectionStringSettings CrConSettings = ConfigurationManager.ConnectionStrings[Constants.CR_CON_NAME];
        public static string EiconString = EiConSettings.ConnectionString;        
        public static string CrconString = CrConSettings.ConnectionString;
        public AbstractDbFactory Db { get; set; }

        // initialize a DataAccess object with default connection 
        public DataAccess()
        {
            ConnectionString = ConvertConectionStringToPlainText(EiconString);
            Db = AbstractDbFactory.getFactory(DbType);
        }

        /// <summary>
        /// Initialize a DataAccess object with connection string given by the constring.
        /// Note that, the connection is password encrypted.
        /// </summary>
        /// <param name="conString"></param>
        public DataAccess(string conString)
        {
            ConnectionString = ConvertConectionStringToPlainText(conString);
            Db = AbstractDbFactory.getFactory(DbType);
        }

        public bool Open()
        {
            return Db.open(ConnectionString);
        }

        public void Close()
        {
            Db.Close();
        }

        // change encrypted password to plain text password in a connection string
        public static string ConvertConectionStringToPlainText(string passwordEncryptedConnectionString)
        {
            var conStringBuilder = new SqlConnectionStringBuilder(passwordEncryptedConnectionString);            
            conStringBuilder.Password = Cryp.Decrypt(conStringBuilder.Password);
            return conStringBuilder.ToString();
        }
        
        #region IDisposable Members

        public void Dispose()
        {
            Close();
            Db = null;
        }

        #endregion
    }
}
