using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace EBase
{
    public sealed class DbParameter
    {
        private IDataParameter mParameter;

        public DbParameter()
        {
            var str = AbstractDbFactory.system.ToLower();

            if (str != "mssql")
            {
                if (str == "odbc")
                {
                    mParameter = new OdbcParameter();
                }
                else if (str == "oledb")
                {
                    mParameter = new OleDbParameter();
                }
            }
            else
            {
                mParameter = new SqlParameter();
            }

        }

        public DbParameter(string parameterName, SqlDbType dbType)
        {
            var str = AbstractDbFactory.system.ToLower();

            if (str != "mssql")
            {
                if (str == "odbc")
                {
                    mParameter = new OdbcParameter(parameterName, SqlDbType2OdbcType(dbType));
                }
                else if (str == "oledb")
                {
                    mParameter = new OleDbParameter(parameterName, SqlDbType2OleDbType(dbType));
                }
            }
            else
            {
                mParameter = new SqlParameter(parameterName, dbType);
            }

        }

        public DbParameter(string parameterName, object parameterValue)
        {
            var str = AbstractDbFactory.system.ToLower();
            if (str != "mssql")
            {
                if (str == "odbc")
                {
                    mParameter = new OdbcParameter(parameterName, parameterValue);
                }
                else if (str == "oledb")
                {
                    mParameter = new OleDbParameter(parameterName, parameterValue);
                }
            }
            else
            {
                mParameter = new SqlParameter(parameterName, parameterValue);
            }
        }

        public DbParameter(string parameterName, SqlDbType dbType, int size)
        {
            var str = AbstractDbFactory.system.ToLower();
            if (str != "mssql")
            {
                if (str == "odbc")
                {
                    mParameter = new OdbcParameter(parameterName, SqlDbType2OdbcType(dbType), size);
                }
                else if (str == "oledb")
                {
                    mParameter = new OleDbParameter(parameterName, SqlDbType2OleDbType(dbType), size);
                }
            }
            else
            {
                mParameter = new SqlParameter(parameterName, dbType, size);
            }
        }

        public DbParameter(string parameterName, SqlDbType dbType, int size, string sourceColumn)
        {
            var str = AbstractDbFactory.system.ToLower();
            if (str != "mssql")
            {
                if (str == "odbc")
                {
                    mParameter = new OdbcParameter(parameterName, SqlDbType2OdbcType(dbType), size, sourceColumn);
                }
                else if (str == "oledb")
                {
                    mParameter = new OleDbParameter(parameterName, SqlDbType2OleDbType(dbType), size, sourceColumn);
                }
            }
            else
            {
                mParameter = new SqlParameter(parameterName, dbType, size, sourceColumn);
            }
        }

        public DbParameter(string parameterName, SqlDbType dbType, int size, ParameterDirection direction, bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            var str = AbstractDbFactory.system.ToLower();
            if (str != "mssql")
            {
                if (str == "odbc")
                {
                    mParameter = new OdbcParameter(parameterName, SqlDbType2OdbcType(dbType), size, direction, isNullable, precision, scale, sourceColumn, sourceVersion, value);
                }
                else if (str == "oledb")
                {
                    mParameter = new OleDbParameter(parameterName, SqlDbType2OleDbType(dbType), size, direction, isNullable, precision, scale, sourceColumn, sourceVersion, value);
                }
            }
            else
            {
                mParameter = new SqlParameter(parameterName, dbType, size, direction, isNullable, precision, scale, sourceColumn, sourceVersion, value);
            }
        }

        private OdbcType SqlDbType2OdbcType(SqlDbType dbType)
        {
            switch (dbType)
            {
                case SqlDbType.BigInt:
                    return OdbcType.BigInt;

                case SqlDbType.Binary:
                    return OdbcType.Binary;

                case SqlDbType.Bit:
                    return OdbcType.Bit;

                case SqlDbType.Char:
                    return OdbcType.Char;

                case SqlDbType.DateTime:
                    return OdbcType.DateTime;

                case SqlDbType.Decimal:
                    return OdbcType.Decimal;

                case SqlDbType.Float:
                    return OdbcType.Double;

                case SqlDbType.Image:
                    return OdbcType.Image;

                case SqlDbType.Int:
                    return OdbcType.Int;

                case SqlDbType.Money:
                    return OdbcType.Numeric;

                case SqlDbType.NChar:
                    return OdbcType.NChar;

                case SqlDbType.NText:
                    return OdbcType.NText;

                case SqlDbType.NVarChar:
                    return OdbcType.NVarChar;

                case SqlDbType.Real:
                    return OdbcType.Real;

                case SqlDbType.UniqueIdentifier:
                    return OdbcType.UniqueIdentifier;

                case SqlDbType.SmallDateTime:
                    return OdbcType.SmallDateTime;

                case SqlDbType.SmallInt:
                    return OdbcType.SmallInt;

                case SqlDbType.SmallMoney:
                    return OdbcType.Numeric;

                case SqlDbType.Text:
                    return OdbcType.Text;

                case SqlDbType.Timestamp:
                    return OdbcType.DateTime;

                case SqlDbType.TinyInt:
                    return OdbcType.SmallInt;

                case SqlDbType.VarBinary:
                    return OdbcType.VarBinary;

                case SqlDbType.VarChar:
                    return OdbcType.VarChar;
            }
            return OdbcType.VarChar;
        }

        private OleDbType SqlDbType2OleDbType(SqlDbType dbType)
        {
            switch (dbType)
            {
                case SqlDbType.BigInt:
                    return OleDbType.BigInt;

                case SqlDbType.Binary:
                    return OleDbType.Binary;

                case SqlDbType.Bit:
                    return OleDbType.Boolean;

                case SqlDbType.Char:
                    return OleDbType.Char;

                case SqlDbType.DateTime:
                    return OleDbType.DBTimeStamp;

                case SqlDbType.Decimal:
                    return OleDbType.Decimal;

                case SqlDbType.Float:
                    return OleDbType.Double;

                case SqlDbType.Image:
                    return OleDbType.VarBinary;

                case SqlDbType.Int:
                    return OleDbType.Integer;

                case SqlDbType.Money:
                    return OleDbType.Decimal;

                case SqlDbType.NChar:
                    return OleDbType.WChar;

                case SqlDbType.NText:
                    return OleDbType.LongVarWChar;

                case SqlDbType.NVarChar:
                    return OleDbType.VarWChar;

                case SqlDbType.Real:
                    return OleDbType.Double;

                case SqlDbType.UniqueIdentifier:
                    return OleDbType.Guid;

                case SqlDbType.SmallDateTime:
                    return OleDbType.DBTimeStamp;

                case SqlDbType.SmallInt:
                    return OleDbType.SmallInt;

                case SqlDbType.SmallMoney:
                    return OleDbType.Numeric;

                case SqlDbType.Text:
                    return OleDbType.LongVarChar;

                case SqlDbType.Timestamp:
                    return OleDbType.Char;

                case SqlDbType.TinyInt:
                    return OleDbType.TinyInt;

                case SqlDbType.VarBinary:
                    return OleDbType.VarBinary;

                case SqlDbType.VarChar:
                    return OleDbType.VarChar;
            }
            return OleDbType.VarChar;
        }

        public SqlDbType DbType
        {
            get
            {
                return (SqlDbType)mParameter.DbType;
            }
            set
            {
                var str = AbstractDbFactory.system.ToLower();
                if (str != "mssql")
                {
                    if (str == "odbc")
                    {
                        ((OdbcParameter)mParameter).OdbcType = SqlDbType2OdbcType(value);
                    }
                    else if (str == "oledb")
                    {
                        ((OleDbParameter)mParameter).OleDbType = SqlDbType2OleDbType(value);
                    }
                }
                else
                {
                    ((SqlParameter)mParameter).SqlDbType = value;
                }
            }
        }

        public ParameterDirection Direction
        {
            get
            {
                return mParameter.Direction;
            }
            set
            {
                mParameter.Direction = value;
            }
        }

        public bool IsNullable
        {
            get
            {
                return mParameter.IsNullable;
            }
        }

        internal IDataParameter Parameter
        {
            get
            {
                return mParameter;
            }
        }

        public string ParameterName
        {
            get
            {
                return mParameter.ParameterName;
            }
            set
            {
                mParameter.ParameterName = value;
            }
        }

        public string SourceColumn
        {
            get
            {
                return mParameter.SourceColumn;
            }
            set
            {
                mParameter.SourceColumn = value;
            }
        }

        public DataRowVersion SourceVersion
        {
            get
            {
                return mParameter.SourceVersion;
            }
            set
            {
                mParameter.SourceVersion = value;
            }
        }

        public object Value
        {
            get
            {
                return mParameter.Value;
            }
            set
            {
                mParameter.Value = value;
            }
        }
    }
}

