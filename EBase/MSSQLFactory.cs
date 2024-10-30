using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace EBase
{
    internal class MSSQLFactory : AbstractDbFactory
    {
        private SqlConnection conn = new SqlConnection();

        public override IDbTransaction BeginTransaction()
        {
            return conn.BeginTransaction();
        }

        public override void Close()
        {
            try
            {
                if (conn == null) return;
                if (conn.State != ConnectionState.Open) return;
                conn.Close();
                conn = null;
            }
            catch
            {
            }
        }

        public override IDataReader getBLOB(string query, CommandType commandType)
        {
            var command = new SqlCommand
            {
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
                    conn = new SqlConnection();
                }
                if (conn.State != ConnectionState.Open)
                {
                    conn.ConnectionString = connectStr;
                    conn.Open();
                }
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
                var command = new SqlCommand
                {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
                };
                if (parameters != null)
                {
                    foreach (DbParameter t in parameters)
                    {
                        command.Parameters.Add((SqlParameter)t.Parameter);
                    }
                }
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (SqlException exception)
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
            int rs;
            try
            {
                var command = new SqlCommand
                {
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
                        SqlParameter parameter;
                        if (paramValues[i] is StringBuilder)
                        {
                            parameter = new SqlParameter
                            {
                                ParameterName = paramNames[i]
                            };
                            if (paramDirections != null)
                            {
                                parameter.Direction = paramDirections[i];
                            }
                            if (parameter.Direction != ParameterDirection.Output)
                            {
                                parameter.Value = paramValues[i].ToString();
                            }
                        }
                        else if (paramValues[i] is byte[])
                        {
                            var buffer = (byte[])paramValues[i];
                            parameter = new SqlParameter(paramNames[i], SqlDbType.Image, buffer.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, buffer);
                        }
                        else
                        {
                            parameter = new SqlParameter
                            {
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
                rs = command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                throw new DbException(exception.Message);
            }
            return rs;
        }

        public override DataSet runDynamicSqlQuery(string query, DbParameter[] parameters, CommandType commandType)
        {
            var ds = new DataSet();
            try
            {
                var adapter = new SqlDataAdapter();
                var command = new SqlCommand
                {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
                };
                adapter.SelectCommand = command;
                if (parameters != null)
                {
                    foreach (DbParameter t in parameters)
                    {
                        command.Parameters.Add((SqlParameter)t.Parameter);
                    }
                }

                adapter.Fill(ds);
                command.Parameters.Clear();
            }
            catch (SqlException exception)
            {
                throw new DbException(exception.Message);
            }
            return ds;
        }

        public override IDataReader runDynamicSqlQuery(string query, DbParameter[] parameters, CommandType commandType, CommandBehavior behavior)
        {
            IDataReader dr;
            try
            {
                var command = new SqlCommand
                {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
                };
                if (parameters != null)
                {
                    foreach (DbParameter t in parameters)
                    {
                        command.Parameters.Add((SqlParameter)t.Parameter);
                    }
                }
                dr = command.ExecuteReader(behavior);
                command.Parameters.Clear();
            }
            catch (SqlException exception)
            {
                throw new DbException(exception.Message);
            }
            return dr;
        }

        public override DataSet runDynamicSqlQuery(string query, string[] paramNames, object[] paramValues, CommandType commandType)
        {
            var ds = new DataSet("MyDataSet");
            try
            {
                var adapter = new SqlDataAdapter();
                var command = new SqlCommand
                {
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
                        var parameter = new SqlParameter(paramNames[i], paramValues[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                adapter.Fill(ds, "MyTableName");
            }
            catch (SqlException exception)
            {
                throw new DbException(exception.Message);
            }
            return ds;
        }

        public override DataSet runDynamicSqlQuery(string query, DbParameter[] parameters, CommandType commandType, int startIndex, int maxRecords)
        {
            var ds = new DataSet();
            try
            {
                var adapter = new SqlDataAdapter();
                var command = new SqlCommand
                {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
                };
                adapter.SelectCommand = command;
                if (parameters != null)
                {
                    foreach (DbParameter t in parameters)
                    {
                        command.Parameters.Add((SqlParameter)t.Parameter);
                    }
                }
                adapter.Fill(ds, startIndex, maxRecords, "MyTableName");
                command.Parameters.Clear();
            }
            catch (SqlException exception)
            {
                throw new DbException(exception.Message);
            }
            return ds;
        }

        public override IDataReader runDynamicSqlQuery(string query, string[] paramNames, object[] paramValues, CommandType commandType, CommandBehavior behavior)
        {
            IDataReader dr;
            try
            {
                var command = new SqlCommand
                {
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
                        var parameter = new SqlParameter(paramNames[i], paramValues[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                dr = command.ExecuteReader(behavior);
            }
            catch (SqlException exception)
            {
                throw new DbException(exception.Message);
            }
            return dr;
        }

        public override DataSet runDynamicSqlQuery(string query, string[] paramNames, object[] paramValues, CommandType commandType, DataSet ds, string tableName)
        {
            var dts = new DataSet();
            try
            {
                var adapter = new SqlDataAdapter();
                var command = new SqlCommand
                {
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
                        var parameter = new SqlParameter(paramNames[i], paramValues[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                adapter.Fill(dts, tableName);
            }
            catch (SqlException exception)
            {
                throw new DbException(exception.Message);
            }
            return dts;
        }

        public override DataSet runDynamicSqlQuery(string query, string[] paramNames, object[] paramValues, CommandType commandType, int startIndex, int maxRecords)
        {
            var ds = new DataSet("MyDataSet");
            try
            {
                var adapter = new SqlDataAdapter();
                var command = new SqlCommand
                {
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
                        var parameter = new SqlParameter(paramNames[i], paramValues[i]);
                        command.Parameters.Add(parameter);
                    }
                }
                adapter.Fill(ds, startIndex, maxRecords, "MyTableName");
            }
            catch (SqlException exception)
            {
                throw new DbException(exception.Message);
            }
            return ds;
        }

        public override object runDynamicSqlScalar(string query, DbParameter[] parameters, CommandType commandType)
        {
            object obj;
            try
            {
                var command = new SqlCommand
                {
                    CommandType = commandType,
                    CommandText = query,
                    Connection = conn
                };
                if (parameters != null)
                {
                    foreach (DbParameter t in parameters)
                    {
                        command.Parameters.Add((SqlParameter)t.Parameter);
                    }
                }
                obj = command.ExecuteScalar();
                command.Parameters.Clear();
            }
            catch (SqlException exception)
            {
                throw new DbException(exception.Message);
            }
            return obj;
        }

        public override object runDynamicSqlScalar(string query, string[] paramNames, object[] paramValues, CommandType commandType)
        {
            object obj;
            try
            {
                var command = new SqlCommand
                {
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
                    for (var i = 0; i < paramNames.Length; i++)
                    {
                        SqlParameter parameter;
                        if (paramValues[i] is StringBuilder)
                        {
                            parameter = new SqlParameter
                            {
                                ParameterName = paramNames[i],
                                Value = paramValues[i].ToString()
                            };
                        }
                        else if (paramValues[i] is byte[])
                        {
                            var buffer = (byte[])paramValues[i];
                            parameter = new SqlParameter(paramNames[i], SqlDbType.Image, buffer.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, buffer);
                        }
                        else
                        {
                            parameter = new SqlParameter
                            {
                                ParameterName = paramNames[i]
                            };
                            if (paramValues[i] != null)
                            {
                                parameter.Value = paramValues[i];
                            }
                        }
                        command.Parameters.Add(parameter);
                    }
                }
                obj = command.ExecuteScalar();
            }
            catch (SqlException exception)
            {
                throw new DbException(exception.Message);
            }
            return obj;
        }

        public override int runSQLNoQuery(string query)
        {
            int num;
            try
            {
                num = new SqlCommand(query, conn) { CommandTimeout = 0 }.ExecuteNonQuery();
            }
            catch (SqlException exception)
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
                num = new SqlCommand(query, conn) { CommandType = commandType, CommandTimeout = 0 }.ExecuteNonQuery();
            }
            catch (SqlException exception)
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
            return runSQLQuery(query, ds, tableName, 0, 0);
        }

        public override DataSet runSQLQuery(string query, int startIndex, int maxRecords)
        {
            return runSQLQuery(query, "MyDataSet", "MyTable", startIndex, maxRecords);
        }

        public override DataSet runSQLQuery(string query, string datasetName, string tableName)
        {
            return runSQLQuery(query, new DataSet(datasetName), tableName, 0, 0);
        }

        public override DataSet runSQLQuery(string query, DataSet ds, string tableName, CommandType commandType)
        {
            return runSQLQuery(query, ds, tableName, 0, 0, commandType);
        }

        public override DataSet runSQLQuery(string query, int startIndex, int maxRecords, CommandType commandType)
        {
            return runSQLQuery(query, "MyDataSet", "MyTable", startIndex, maxRecords, commandType);
        }

        public override DataSet runSQLQuery(string query, string datasetName, string tableName, CommandType commandType)
        {
            return runSQLQuery(query, new DataSet(datasetName), tableName, 0, 0, commandType);
        }

        public override DataSet runSQLQuery(string query, DataSet ds, string tableName, int startIndex, int maxRecords)
        {
            try
            {
                var adapter = new SqlDataAdapter();
                var command = new SqlCommand(query, conn)
                {
                    CommandTimeout = 0
                };
                adapter.SelectCommand = command;
                if (maxRecords != 0)
                {
                    adapter.Fill(ds, startIndex, maxRecords, tableName);
                    return ds;
                }
                adapter.Fill(ds, tableName);
            }
            catch (SqlException exception)
            {
                throw new DbException(exception.Message);
            }
            return ds;
        }

        public override DataSet runSQLQuery(string query, string datasetName, string tableName, int startIndex, int maxRecords)
        {
            return runSQLQuery(query, new DataSet(datasetName), tableName, startIndex, maxRecords);
        }

        public override DataSet runSQLQuery(string query, DataSet ds, string tableName, int startIndex, int maxRecords, CommandType commandType)
        {
            try
            {
                var adapter = new SqlDataAdapter();
                var command = new SqlCommand(query, conn)
                {
                    CommandTimeout = 0,
                    CommandType = commandType
                };
                adapter.SelectCommand = command;
                if (maxRecords != 0)
                {
                    adapter.Fill(ds, startIndex, maxRecords, tableName);
                    return ds;
                }
                adapter.Fill(ds, tableName);
            }
            catch (SqlException exception)
            {
                throw new DbException(exception.Message);
            }
            return ds;
        }

        public override DataSet runSQLQuery(string query, string datasetName, string tableName, int startIndex, int maxRecords, CommandType commandType)
        {
            return runSQLQuery(query, new DataSet(datasetName), tableName, startIndex, maxRecords, commandType);
        }

        public override IDataReader runSQLReader(string query, CommandBehavior behavior)
        {
            return runSQLReader(query, CommandType.Text, behavior);
        }

        public override IDataReader runSQLReader(string query, CommandType commandType)
        {
            var command = new SqlCommand
            {
                CommandTimeout = 0,
                CommandType = commandType,
                CommandText = query,
                Connection = conn
            };
            return command.ExecuteReader();
        }

        public override IDataReader runSQLReader(string query, CommandType commandType, CommandBehavior behavior)
        {
            var command = new SqlCommand
            {
                CommandTimeout = 0,
                CommandType = commandType,
                CommandText = query,
                Connection = conn
            };
            return command.ExecuteReader(behavior);
        }

        public override int updateBLOB(string tableName, string fieldName, string whereString, Stream fs)
        {
            const int size = 32768;
            var cmd = new SqlCommand(string.Format("SET NOCOUNT ON;UPDATE {0} SET {1} = 0x0 {2};SELECT @Pointer=TEXTPTR({1}) FROM {0} {2}", tableName, fieldName, whereString), conn);
            var parameter = cmd.Parameters.Add("@Pointer", SqlDbType.VarBinary, 100);
            parameter.Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand(string.Format("UPDATETEXT {0}.{1} @Pointer @Offset @Delete WITH LOG @Bytes", tableName, fieldName), conn)
            {
                CommandTimeout = 0
            };
            var parameter2 = cmd.Parameters.Add("@Pointer", SqlDbType.Binary, 16);
            var parameter3 = cmd.Parameters.Add("@Offset", SqlDbType.Int);
            var parameter4 = cmd.Parameters.Add("@Delete", SqlDbType.Int);
            parameter4.Value = 1;
            var parameter5 = cmd.Parameters.Add("@Bytes", SqlDbType.Binary, size);
            var reader = new BinaryReader(fs);
            var offset = 0;
            parameter3.Value = offset;
            for (var buffer = reader.ReadBytes(size); buffer.Length > 0; buffer = reader.ReadBytes(size))
            {
                parameter2.Value = parameter.Value;
                parameter5.Value = buffer;
                cmd.ExecuteNonQuery();
                parameter4.Value = 0;
                offset += buffer.Length;
                parameter3.Value = offset;
            }
            reader.Close();
            return 0;
        }

        public override int updateBLOBData(string query, string paramName, byte[] b, CommandType commandType)
        {
            var command = new SqlCommand
            {
                CommandTimeout = 0,
                CommandType = commandType,
                CommandText = query,
                Connection = conn
            };
            var parameter = new SqlParameter(paramName, SqlDbType.Image, b.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, b);
            command.Parameters.Add(parameter);
            return command.ExecuteNonQuery();
        }
    }
}

