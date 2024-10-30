using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;

namespace EBase
{
    internal class OLEDBFactory : AbstractDbFactory
    {
        private OleDbConnection _conn = new OleDbConnection();

        public override IDbTransaction BeginTransaction()
        {
            return _conn.BeginTransaction();
        }

        public override void Close()
        {
            try
            {
                _conn.Close();
                _conn = null;
            }
            catch
            {
            }
        }

        public override IDataReader getBLOB(string query, CommandType commandType)
        {
            var command = new OleDbCommand {
                CommandTimeout = 0,
                CommandType = commandType,
                CommandText = query,
                Connection = _conn
            };
            return command.ExecuteReader(CommandBehavior.SequentialAccess);
        }

        private OleDbType getSqlType(object o)
        {
            if (o is long)
            {
                return OleDbType.BigInt;
            }
            if (o is byte[])
            {
                return OleDbType.Binary;
            }
            if (o is bool)
            {
                return OleDbType.Boolean;
            }
            if (o is DateTime)
            {
                return OleDbType.DBTimeStamp;
            }
            if (o is int)
            {
                return OleDbType.Integer;
            }
            if (o is short)
            {
                return OleDbType.SmallInt;
            }
            if (o is string)
            {
                return OleDbType.VarWChar;
            }
            if (o is StringBuilder)
            {
                return OleDbType.LongVarWChar;
            }
            if (o is decimal)
            {
                return OleDbType.Decimal;
            }
            if (o is double)
            {
                return OleDbType.Double;
            }
            if (o is float)
            {
                return OleDbType.Single;
            }
            if (o is sbyte)
            {
                return OleDbType.TinyInt;
            }
            if (o is byte)
            {
                return OleDbType.UnsignedTinyInt;
            }
            if (o is Guid)
            {
                return OleDbType.Guid;
            }
            return OleDbType.Variant;
        }

        public override bool open(string connectStr)
        {
            try
            {
                if (_conn == null)
                {
                    _conn = new OleDbConnection(connectStr);
                }
                else
                {
                    _conn.ConnectionString = connectStr;
                }
                _conn.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public override void runDynamicSqlNoQuery(string query, DbParameter[] parameters, CommandType commandType)
        {
            try
            {
                var command = new OleDbCommand {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = _conn
                };
                if (parameters != null)
                {
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.Add((OleDbParameter) parameters[i].Parameter);
                    }
                }
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
        }

        public override int runDynamicSqlNoQuery(string query, string[] paramNames, object[] paramValues, CommandType commandType)
        {
            return runDynamicSqlNoQuery(query, paramNames, paramValues, null, commandType);
        }

        public override int runDynamicSqlNoQuery(string query, string[] paramNames, object[] paramValues, ParameterDirection[] paramDirections, CommandType commandType)
        {
            int num2;
            try
            {
                var command = new OleDbCommand {
                    CommandTimeout = 0,
                    CommandType = commandType,
                    CommandText = query,
                    Connection = _conn
                };
                if (paramNames == null)
                {
                    paramNames = generateParamNames(query);
                }
                if (paramNames != null)
                {
                    for (var i = 0; i < paramValues.Length; i++)
                    {
                        OleDbParameter parameter;
                        if (paramValues[i] != DBNull.Value)
                        {
                            var type = getSqlType(paramValues[i]);
                            if (OleDbType.LongVarWChar == type)
                            {
                                parameter = new OleDbParameter {
                                    ParameterName = paramNames[i]
                                };
                                if (paramDirections != null)
                                {
                                    parameter.Direction = paramDirections[i];
                                }
                                if (parameter.Direction != ParameterDirection.Output)
                                {
                                    parameter.Value = ((StringBuilder) paramValues[i]).ToString();
                                }
                            }
                            else if (OleDbType.Binary == type)
                            {
                                var buffer = (byte[]) paramValues[i];
                                parameter = new OleDbParameter(paramNames[i], OleDbType.Binary, buffer.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, buffer);
                            }
                            else if (OleDbType.BigInt == type)
                            {
                                parameter = new OleDbParameter(paramNames[i], OleDbType.BigInt);
                                if (paramValues[i] != null)
                                {
                                    parameter.Value = paramValues[i];
                                }
                            }
                            else
                            {
                                parameter = new OleDbParameter {
                                    ParameterName = paramNames[i]
                                };
                                if (paramDirections != null)
                                {
                                    parameter.Direction = paramDirections[i];
                                }
                                if (paramValues[i] != null)
                                {
                                    parameter.Value = paramValues[i];
                                }
                            }
                        }
                        else
                        {
                            parameter = new OleDbParameter {
                                ParameterName = paramNames[i]
                            };
                            if (paramDirections != null)
                            {
                                parameter.Direction = paramDirections[i];
                            }
                            if (paramValues[i] != null)
                            {
                                parameter.Value = paramValues[i];
                            }
                        }
                        command.Parameters.Add(parameter);
                    }
                }
                num2 = command.ExecuteNonQuery();
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return num2;
        }

        public override DataSet runDynamicSqlQuery(string query, DbParameter[] parameters, CommandType commandType)
        {
            DataSet set2;
            try
            {
                var adapter = new OleDbDataAdapter();
                var command = new OleDbCommand {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = _conn
                };
                adapter.SelectCommand = command;
                if (parameters != null)
                {
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.Add((OleDbParameter) parameters[i].Parameter);
                    }
                }
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                command.Parameters.Clear();
                set2 = dataSet;
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return set2;
        }

        public override IDataReader runDynamicSqlQuery(string query, DbParameter[] parameters, CommandType commandType, CommandBehavior behavior)
        {
            IDataReader reader2;
            try
            {
                var command = new OleDbCommand {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = _conn
                };
                if (parameters != null)
                {
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.Add((OleDbParameter) parameters[i].Parameter);
                    }
                }
                IDataReader reader = command.ExecuteReader(behavior);
                command.Parameters.Clear();
                reader2 = reader;
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return reader2;
        }

        public override DataSet runDynamicSqlQuery(string query, string[] paramNames, object[] paramValues, CommandType commandType)
        {
            DataSet set2;
            try
            {
                var adapter = new OleDbDataAdapter();
                var command = new OleDbCommand {
                    CommandTimeout = 0,
                    CommandType = commandType,
                    CommandText = query,
                    Connection = _conn
                };
                adapter.SelectCommand = command;
                if (paramNames == null)
                {
                    paramNames = generateParamNames(query);
                }
                if (paramNames != null)
                {
                    for (var i = 0; i < paramValues.Length; i++)
                    {
                        var parameter = new OleDbParameter(paramNames[i], paramValues[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                var dataSet = new DataSet("MyDataSet");
                adapter.Fill(dataSet, "MyTableName");
                set2 = dataSet;
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return set2;
        }

        public override DataSet runDynamicSqlQuery(string query, DbParameter[] parameters, CommandType commandType, int startIndex, int maxRecords)
        {
            DataSet set2;
            try
            {
                var adapter = new OleDbDataAdapter();
                var command = new OleDbCommand {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = _conn
                };
                adapter.SelectCommand = command;
                if (parameters != null)
                {
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.Add((OleDbParameter) parameters[i].Parameter);
                    }
                }
                var dataSet = new DataSet();
                adapter.Fill(dataSet, startIndex, maxRecords, "MyTableName");
                command.Parameters.Clear();
                set2 = dataSet;
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return set2;
        }

        public override IDataReader runDynamicSqlQuery(string query, string[] paramNames, object[] paramValues, CommandType commandType, CommandBehavior behavior)
        {
            IDataReader reader;
            try
            {
                var command = new OleDbCommand {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = _conn
                };
                if (paramNames == null)
                {
                    paramNames = generateParamNames(query);
                }
                if (paramNames != null)
                {
                    for (var i = 0; i < paramValues.Length; i++)
                    {
                        var parameter = new OleDbParameter(paramNames[i], paramValues[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                reader = command.ExecuteReader(behavior);
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return reader;
        }

        public override DataSet runDynamicSqlQuery(string query, string[] paramNames, object[] paramValues, CommandType commandType, DataSet ds, string tableName)
        {
            DataSet set;
            try
            {
                var adapter = new OleDbDataAdapter();
                var command = new OleDbCommand {
                    CommandTimeout = 0,
                    CommandType = commandType,
                    CommandText = query,
                    Connection = _conn
                };
                adapter.SelectCommand = command;
                if (paramNames == null)
                {
                    paramNames = generateParamNames(query);
                }
                if (paramNames != null)
                {
                    for (var i = 0; i < paramValues.Length; i++)
                    {
                        var parameter = new OleDbParameter(paramNames[i], paramValues[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                adapter.Fill(ds, tableName);
                set = ds;
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return set;
        }

        public override DataSet runDynamicSqlQuery(string query, string[] paramNames, object[] paramValues, CommandType commandType, int startIndex, int maxRecords)
        {
            DataSet set2;
            try
            {
                var adapter = new OleDbDataAdapter();
                var command = new OleDbCommand {
                    CommandTimeout = 0,
                    CommandType = commandType,
                    CommandText = query,
                    Connection = _conn
                };
                adapter.SelectCommand = command;
                if (paramNames == null)
                {
                    paramNames = generateParamNames(query);
                }
                if (paramNames != null)
                {
                    for (var i = 0; i < paramValues.Length; i++)
                    {
                        var parameter = new OleDbParameter(paramNames[i], paramValues[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                var dataSet = new DataSet("MyDataSet");
                adapter.Fill(dataSet, startIndex, maxRecords, "MyTableName");
                set2 = dataSet;
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return set2;
        }

        public override object runDynamicSqlScalar(string query, DbParameter[] parameters, CommandType commandType)
        {
            object obj3;
            try
            {
                var command = new OleDbCommand {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = _conn
                };
                if (parameters != null)
                {
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.Add((OleDbParameter) parameters[i].Parameter);
                    }
                }
                var obj2 = command.ExecuteScalar();
                command.Parameters.Clear();
                obj3 = obj2;
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return obj3;
        }

        public override object runDynamicSqlScalar(string query, string[] paramNames, object[] paramValues, CommandType commandType)
        {
            object obj2;
            try
            {
                var command = new OleDbCommand {
                    CommandTimeout = 0,
                    CommandType = commandType,
                    CommandText = query,
                    Connection = _conn
                };
                if (paramNames == null)
                {
                    paramNames = generateParamNames(query);
                }
                if (paramNames != null)
                {
                    for (var i = 0; i < paramValues.Length; i++)
                    {
                        var parameter = new OleDbParameter(paramNames[i], paramValues[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                obj2 = command.ExecuteScalar();
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return obj2;
        }

        public override int runSQLNoQuery(string query)
        {
            int num;
            try
            {
                num = new OleDbCommand(query, _conn) { CommandType = CommandType.Text }.ExecuteNonQuery();
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message + "QUERY::=::" + query);
            }
            return num;
        }

        public override int runSQLNoQuery(string query, CommandType commandType)
        {
            int num;
            try
            {
                num = new OleDbCommand(query, _conn) { CommandType = commandType, CommandTimeout = 0 }.ExecuteNonQuery();
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return num;
        }

        public override DataSet runSQLQuery(string query)
        {
            return runSQLQuery(query, "MyDataSet", "MyTable");
        }

        public override DataSet runSQLQuery(string query, CommandType commandType)
        {
            return runSQLQuery(query, "MyDataSet", "MyTable", commandType);
        }

        public override DataSet runSQLQuery(string query, DataSet ds, string tableName)
        {
            try
            {
                var adapter = new OleDbDataAdapter();
                var command = new OleDbCommand(query, _conn);
                adapter.SelectCommand = command;
                adapter.Fill(ds, tableName);
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return ds;
        }

        public override DataSet runSQLQuery(string query, int startIndex, int maxRecords)
        {
            return runSQLQuery(query, "MyDataSet", "MyTable", startIndex, maxRecords);
        }

        public override DataSet runSQLQuery(string query, string datasetName, string tableName)
        {
            var dataSet = new DataSet(datasetName);
            try
            {
                var adapter = new OleDbDataAdapter();
                var command = new OleDbCommand(query, _conn);
                adapter.SelectCommand = command;
                adapter.Fill(dataSet, tableName);
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return dataSet;
        }

        public override DataSet runSQLQuery(string query, DataSet ds, string tableName, CommandType commandType)
        {
            try
            {
                var adapter = new OleDbDataAdapter();
                var command = new OleDbCommand(query, _conn) {
                    CommandTimeout = 0,
                    CommandType = commandType
                };
                adapter.SelectCommand = command;
                adapter.Fill(ds, tableName);
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return ds;
        }

        public override DataSet runSQLQuery(string query, int startIndex, int maxRecords, CommandType commandType)
        {
            return runSQLQuery(query, "MyDataSet", "MyTable", startIndex, maxRecords, commandType);
        }

        public override DataSet runSQLQuery(string query, string datasetName, string tableName, CommandType commandType)
        {
            var dataSet = new DataSet(datasetName);
            try
            {
                var adapter = new OleDbDataAdapter();
                var command = new OleDbCommand(query, _conn) {
                    CommandTimeout = 0,
                    CommandType = commandType
                };
                adapter.SelectCommand = command;
                adapter.Fill(dataSet, tableName);
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return dataSet;
        }

        public override DataSet runSQLQuery(string query, DataSet ds, string tableName, int startIndex, int maxRecords)
        {
            try
            {
                var adapter = new OleDbDataAdapter();
                var command = new OleDbCommand(query, _conn);
                adapter.SelectCommand = command;
                adapter.Fill(ds, startIndex, maxRecords, tableName);
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return ds;
        }

        public override DataSet runSQLQuery(string query, string datasetName, string tableName, int startIndex, int maxRecords)
        {
            var dataSet = new DataSet(datasetName);
            try
            {
                var adapter = new OleDbDataAdapter();
                var command = new OleDbCommand(query, _conn);
                adapter.SelectCommand = command;
                adapter.Fill(dataSet, startIndex, maxRecords, tableName);
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return dataSet;
        }

        public override DataSet runSQLQuery(string query, DataSet ds, string tableName, int startIndex, int maxRecords, CommandType commandType)
        {
            try
            {
                var adapter = new OleDbDataAdapter();
                var command = new OleDbCommand(query, _conn) {
                    CommandTimeout = 0,
                    CommandType = commandType
                };
                adapter.SelectCommand = command;
                adapter.Fill(ds, startIndex, maxRecords, tableName);
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return ds;
        }

        public override DataSet runSQLQuery(string query, string datasetName, string tableName, int startIndex, int maxRecords, CommandType commandType)
        {
            var dataSet = new DataSet(datasetName);
            try
            {
                var adapter = new OleDbDataAdapter();
                var command = new OleDbCommand(query, _conn) {
                    CommandTimeout = 0,
                    CommandType = commandType
                };
                adapter.SelectCommand = command;
                adapter.Fill(dataSet, startIndex, maxRecords, tableName);
            }
            catch (OleDbException exception)
            {
                throw new DbException(exception.Message);
            }
            return dataSet;
        }

        public override IDataReader runSQLReader(string query, CommandBehavior behavior)
        {
            return runSQLReader(query, CommandType.Text, behavior);
        }

        public override IDataReader runSQLReader(string query, CommandType commandType)
        {
            var command = new OleDbCommand {
                CommandType = commandType,
                CommandText = query,
                Connection = _conn
            };
            return command.ExecuteReader();
        }

        public override IDataReader runSQLReader(string query, CommandType commandType, CommandBehavior behavior)
        {
            var command = new OleDbCommand {
                CommandType = commandType,
                CommandText = query,
                Connection = _conn
            };
            return command.ExecuteReader(behavior);
        }

        public override int updateBLOB(string tableName, string fieldName, string whereString, Stream fs)
        {
            throw new DbException("This Method is unsupported for ODBC connection.");
        }

        public override int updateBLOBData(string query, string paramName, byte[] b, CommandType commandType)
        {
            var command = new OleDbCommand {
                CommandTimeout = 0,
                CommandType = commandType,
                CommandText = query,
                Connection = _conn
            };
            var parameter = new OleDbParameter(paramName, OleDbType.Binary, b.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, b);
            command.Parameters.Add(parameter);
            return command.ExecuteNonQuery();
        }
    }
}

