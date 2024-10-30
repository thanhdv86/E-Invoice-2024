
using System.Configuration;    
using EBase;

namespace cskh.huewaco.vn
{
    public class ProjectData : System.IDisposable
    {
        private AbstractDbFactory dbConn;
        private string dbType;
        private string connectionString;
        public void Dispose()
        {
            Close();
            dbConn = null;
        }
        public ProjectData()
        {
            //dbType = ConfigurationSettings.AppSettings["dbType"];
            dbType = ConfigurationManager.AppSettings["dbType"];
            try
            {
                connectionString = string.Format("Data Source={0};Initial Catalog={1}; User ID={2};Password={3}", ConfigurationManager.AppSettings["DataSource"], ConfigurationManager.AppSettings["InitialCatalog"], ConfigurationManager.AppSettings["UserID"], ConfigurationManager.AppSettings["Password"]);
            }
            catch { }
            dbConn = AbstractDbFactory.getFactory(dbType);
        }
        public AbstractDbFactory Connection
        {
            get
            {
                return dbConn;
            }
        }
        public bool Open()
        {
            return dbConn.open(connectionString);
        }
        public void Close()
        {
            try
            {
                dbConn.Close();
            }
            catch
            {
            }
        }
    }
}