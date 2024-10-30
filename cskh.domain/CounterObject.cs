using cskh.domain;

namespace cskh.huewaco.vn
{
    public class CounterObject : DataAccess
    {
        private long _dblValue;

        #region Properties

        public int CounterId { get; set; }

        public long Value
        {
            get { return _dblValue; }
            set { _dblValue = value; }
        }

        #endregion

        #region Constructor
        public CounterObject()
        {
        }
        #endregion

        #region Method
        public void Update()
        {
            base.Open();
            Db.runDynamicSqlNoQuery("procUpdateCounter", new string[] { "@dblValue" }, new object[] { _dblValue }, System.Data.CommandType.StoredProcedure);
            base.Close();
        }

        public long GetCounter()
        {
            long result = 0;
            base.Open();
            result = (long) Db.runDynamicSqlScalar("procGetCounter", null, null, System.Data.CommandType.StoredProcedure);
            base.Close();
            return result;
        }
        #endregion
    }
}