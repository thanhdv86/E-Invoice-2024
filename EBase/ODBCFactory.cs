using System;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
using System.IO;
using System.Text;

namespace EBase
{
    internal class ODBCFactory : AbstractDbFactory
    {
        private OdbcConnection conn = new OdbcConnection();

        public override IDbTransaction BeginTransaction()
        {
            return conn.BeginTransaction();
        }

        public override void Close()
        {
            try
            {
                conn.Close();
                conn = null;
            }
            catch
            {
            }
        }

        public override IDataReader getBLOB(string query, CommandType commandType)
        {
            var command = new OdbcCommand {
                CommandTimeout = 0,
                CommandType = commandType,
                CommandText = query,
                Connection = conn
            };
            return command.ExecuteReader(CommandBehavior.SequentialAccess);
        }

        public override bool open(string connectStr)
        {
            try
            {
                if (conn == null)
                {
                    conn = new OdbcConnection();
                }
                conn.ConnectionString = connectStr;
                conn.Open();
            }
            catch (OdbcException exception)
            {
                throw new DbException(exception.Message);
            }
            return true;
        }

        public override void runDynamicSqlNoQuery(string query, DbParameter[] parameters, CommandType commandType)
        {
            try
            {
                var command = new OdbcCommand {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
                };
                if (parameters != null)
                {
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.Add((OdbcParameter) parameters[i].Parameter);
                    }
                }
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (OdbcException exception)
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
                var command = new OdbcCommand {
                    CommandTimeout = 0,
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
                };
                if (paramNames == null)
                {
                    paramNames = generateParamNames(query);
                }
                if (paramNames != null)
                {
                    for (var i = 0; i < paramValues.Length; i++)
                    {
                        OdbcParameter parameter;
                        if (paramValues[i] != DBNull.Value)
                        {
                            if (paramValues[i] is StringBuilder)
                            {
                                parameter = new OdbcParameter {
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
                            else if (paramValues[i] is byte[])
                            {
                                var buffer = (byte[]) paramValues[i];
                                parameter = new OdbcParameter(paramNames[i], OdbcType.Image, buffer.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, buffer);
                            }
                            else
                            {
                                parameter = new OdbcParameter {
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
                            parameter = new OdbcParameter {
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
            catch (OdbcException exception)
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
                var adapter = new OdbcDataAdapter();
                var command = new OdbcCommand {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
                };
                adapter.SelectCommand = command;
                if (parameters != null)
                {
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.Add((OdbcParameter) parameters[i].Parameter);
                    }
                }
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                command.Parameters.Clear();
                set2 = dataSet;
            }
            catch (OdbcException exception)
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
                var command = new OdbcCommand {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
                };
                if (parameters != null)
                {
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.Add((OdbcParameter) parameters[i].Parameter);
                    }
                }
                IDataReader reader = command.ExecuteReader(behavior);
                command.Parameters.Clear();
                reader2 = reader;
            }
            catch (OdbcException exception)
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
                var adapter = new OdbcDataAdapter();
                var command = new OdbcCommand {
                    CommandTimeout = 0,
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
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
                        var parameter = new OdbcParameter(paramNames[i], paramValues[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                var dataSet = new DataSet("MyDataSet");
                adapter.Fill(dataSet, "MyTableName");
                set2 = dataSet;
            }
            catch (OdbcException exception)
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
                var adapter = new OdbcDataAdapter();
                var command = new OdbcCommand {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
                };
                adapter.SelectCommand = command;
                if (parameters != null)
                {
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.Add((OdbcParameter) parameters[i].Parameter);
                    }
                }
                var dataSet = new DataSet();
                adapter.Fill(dataSet, startIndex, maxRecords, "MyTableName");
                command.Parameters.Clear();
                set2 = dataSet;
            }
            catch (OdbcException exception)
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
                var command = new OdbcCommand {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
                };
                if (paramNames == null)
                {
                    paramNames = generateParamNames(query);
                }
                if (paramNames != null)
                {
                    for (var i = 0; i < paramValues.Length; i++)
                    {
                        var parameter = new OdbcParameter(paramNames[i], paramValues[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                reader = command.ExecuteReader(behavior);
            }
            catch (OdbcException exception)
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
                var adapter = new OdbcDataAdapter();
                var command = new OdbcCommand {
                    CommandTimeout = 0,
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
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
                        var parameter = new OdbcParameter(paramNames[i], paramValues[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                adapter.Fill(ds, tableName);
                set = ds;
            }
            catch (OdbcException exception)
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
                var adapter = new OdbcDataAdapter();
                var command = new OdbcCommand {
                    CommandTimeout = 0,
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
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
                        var parameter = new OdbcParameter(paramNames[i], paramValues[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                var dataSet = new DataSet("MyDataSet");
                adapter.Fill(dataSet, startIndex, maxRecords, "MyTableName");
                set2 = dataSet;
            }
            catch (OdbcException exception)
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
                var command = new OdbcCommand {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
                };
                if (parameters != null)
                {
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.Add((OdbcParameter) parameters[i].Parameter);
                    }
                }
                var obj2 = command.ExecuteScalar();
                command.Parameters.Clear();
                obj3 = obj2;
            }
            catch (OdbcException exception)
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
                var command = new OdbcCommand {
                    CommandTimeout = 0,
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
                };
                if (paramNames == null)
                {
                    paramNames = generateParamNames(query);
                }
                if (paramNames != null)
                {
                    for (var i = 0; i < paramValues.Length; i++)
                    {
                        var parameter = new OdbcParameter(paramNames[i], paramValues[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                obj2 = command.ExecuteScalar();
            }
            catch (OdbcException exception)
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
                num = new OdbcCommand(query, conn).ExecuteNonQuery();
            }
            catch (OdbcException exception)
            {
                throw new DbException(exception.Message);
            }
            return num;
        }

        public override int runSQLNoQuery(string query, CommandType commandType)
        {
            int num;
            try
            {
                num = new OdbcCommand(query, conn) { CommandType = commandType, CommandTimeout = 0 }.ExecuteNonQuery();
            }
            catch (OdbcException exception)
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
                var adapter = new OdbcDataAdapter();
                var command = new OdbcCommand(query, conn);
                adapter.SelectCommand = command;
                ds.Locale = new CultureInfo(0x42a, true);
                adapter.Fill(ds, tableName);
            }
            catch (OdbcException exception)
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
                var adapter = new OdbcDataAdapter();
                var command = new OdbcCommand(query, conn);
                adapter.SelectCommand = command;
                dataSet.Locale = new CultureInfo(0x42a, true);
                adapter.Fill(dataSet, tableName);
            }
            catch (OdbcException exception)
            {
                throw new DbException(exception.Message);
            }
            return dataSet;
        }

        public override DataSet runSQLQuery(string query, DataSet ds, string tableName, CommandType commandType)
        {
            try
            {
                var adapter = new OdbcDataAdapter();
                var command = new OdbcCommand(query, conn) {
                    CommandTimeout = 0,
                    CommandType = commandType
                };
                adapter.SelectCommand = command;
                ds.Locale = new CultureInfo(0x42a, true);
                adapter.Fill(ds, tableName);
            }
            catch (OdbcException exception)
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
                var adapter = new OdbcDataAdapter();
                var command = new OdbcCommand(query, conn) {
                    CommandTimeout = 0,
                    CommandType = commandType
                };
                adapter.SelectCommand = command;
                dataSet.Locale = new CultureInfo(1066, true);
                adapter.Fill(dataSet, tableName);
            }
            catch (OdbcException exception)
            {
                throw new DbException(exception.Message);
            }
            return dataSet;
        }

        public override DataSet runSQLQuery(string query, DataSet ds, string tableName, int startIndex, int maxRecords)
        {
            try
            {
                var adapter = new OdbcDataAdapter();
                var command = new OdbcCommand(query, conn);
                adapter.SelectCommand = command;
                ds.Locale = new CultureInfo(1066, true);
                adapter.Fill(ds, startIndex, maxRecords, tableName);
            }
            catch (OdbcException exception)
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
                var adapter = new OdbcDataAdapter();
                var command = new OdbcCommand(query, conn);
                adapter.SelectCommand = command;
                dataSet.Locale = new CultureInfo(1066, true);
                adapter.Fill(dataSet, startIndex, maxRecords, tableName);
            }
            catch (OdbcException exception)
            {
                throw new DbException(exception.Message);
            }
            return dataSet;
        }

        public override DataSet runSQLQuery(string query, DataSet ds, string tableName, int startIndex, int maxRecords, CommandType commandType)
        {
            try
            {
                var adapter = new OdbcDataAdapter();
                var command = new OdbcCommand(query, conn) {
                    CommandTimeout = 0,
                    CommandType = commandType
                };
                adapter.SelectCommand = command;
                ds.Locale = new CultureInfo(1066, true);
                adapter.Fill(ds, startIndex, maxRecords, tableName);
            }
            catch (OdbcException exception)
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
                var adapter = new OdbcDataAdapter();
                var command = new OdbcCommand(query, conn) {
                    CommandTimeout = 0,
                    CommandType = commandType
                };
                adapter.SelectCommand = command;
                dataSet.Locale = new CultureInfo(1066, true);
                adapter.Fill(dataSet, startIndex, maxRecords, tableName);
            }
            catch (OdbcException exception)
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
            var command = new OdbcCommand {
                CommandType = commandType,
                CommandText = query,
                Connection = conn
            };
            return command.ExecuteReader();
        }

        public override IDataReader runSQLReader(string query, CommandType commandType, CommandBehavior behavior)
        {
            var command = new OdbcCommand {
                CommandType = commandType,
                CommandText = query,
                Connection = conn
            };
            return command.ExecuteReader(behavior);
        }

        public override int updateBLOB(string tableName, string fieldName, string whereString, Stream fs)
        {
            throw new DbException("This Method is unsupported for ODBC connection.");
        }

        public override int updateBLOBData(string query, string paramName, byte[] b, CommandType commandType)
        {
            var command = new OdbcCommand {
                CommandTimeout = 0,
                CommandType = commandType,
                CommandText = query,
                Connection = conn
            };
            var parameter = new OdbcParameter(paramName, OdbcType.Image, b.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, b);
            command.Parameters.Add(parameter);
            return command.ExecuteNonQuery();
        }
    }
}

