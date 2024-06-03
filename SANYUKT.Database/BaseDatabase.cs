using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using SANYUKT.Datamodel.Interfaces;
using SANYUKT.Datamodel.Library;
using SANYUKT.Datamodel.Common;
using SANYUKT.Datamodel.Shared;


namespace SANYUKT.Database
{
    public abstract class BaseDatabase : ISANYUKTDatabase
    {
        public virtual string ConnectionString { get; }

        protected SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }

        public async Task<SqlConnection> CreateConnectionAsync()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                await conn.OpenAsync();
            }
            return conn;
        }

        public void SqlBulkCopyData(string tableName, DataTable dataTable)
        {
            using (SqlConnection connection = CreateConnection())
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.CheckConstraints | SqlBulkCopyOptions.FireTriggers, null)
                {
                    DestinationTableName = tableName,
                    BulkCopyTimeout = 0
                };

                foreach (DataColumn column in dataTable.Columns)
                {
                    bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                }

                bulkCopy.WriteToServer(dataTable);
                connection.Close();
            }
        }

        public async Task<int> SqlBulkCopyDataAsync(string tableName, DataTable dataTable)
        {
            using (var conn = await CreateConnectionAsync())
            {

                SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.CheckConstraints | SqlBulkCopyOptions.FireTriggers, null);

                bulkCopy.DestinationTableName = tableName;
                bulkCopy.BulkCopyTimeout = 0;

                foreach (DataColumn column in dataTable.Columns)
                {
                    bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                }

                await bulkCopy.WriteToServerAsync(dataTable);
                Int32 roesAffected = dataTable.Rows.Count;
                conn.Close();
                return roesAffected;
            }
        }

        public SqlCommand GetStoredProcCommand(string spName)
        {
            SqlCommand cmd = new SqlCommand(spName)
            {
                CommandType = CommandType.StoredProcedure
            };
            return cmd;
        }

        public SqlCommand GetInlineQuery(string Query)
        {
            SqlCommand cmd = new SqlCommand(Query)
            {
                CommandType = CommandType.Text
            };
            return cmd;
        }

        public void AddInParameter(SqlCommand dbCommand, string parameterName, object value)
        {
            parameterName = ValidateParameterName(parameterName);
            object finalVal = value;

            if (value == null)
                finalVal = DBNull.Value;
            else
            {
                if (value.GetType() == typeof(string))
                {
                    if (string.IsNullOrEmpty((string)value))
                    {
                        finalVal = DBNull.Value;
                    }
                }
            }
            dbCommand.Parameters.AddWithValue(parameterName, finalVal);
        }

        public void AddInParameter(SqlCommand dbCommand, string parameterName, DbType type, object value)
        {
            parameterName = ValidateParameterName(parameterName);
            SqlParameter param = new SqlParameter(parameterName, type);
            param.Direction = ParameterDirection.Input;
            param.Value = (value == null ? DBNull.Value : value);
            dbCommand.Parameters.Add(param);
        }

        public void AddInParameter(SqlCommand dbCommand, string parameterName, SqlDbType type, object value)
        {
            parameterName = ValidateParameterName(parameterName);
            SqlParameter param = new SqlParameter(parameterName, type);
            param.Direction = ParameterDirection.Input;
            param.Value = (value == null ? DBNull.Value : value);
            dbCommand.Parameters.Add(param);
        }

        public void AddOutParameter(SqlCommand dbCommand, string parameterName, int size)
        {
            parameterName = ValidateParameterName(parameterName);
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.Direction = ParameterDirection.Output;
            param.Size = size;
            dbCommand.Parameters.Add(param);
        }

        public void AddOutParameter(SqlCommand dbCommand, string parameterName, DbType type, int size)
        {
            parameterName = ValidateParameterName(parameterName);
            SqlParameter param = new SqlParameter(parameterName, type);
            param.Direction = ParameterDirection.Output;
            param.Size = size;
            dbCommand.Parameters.Add(param);
        }

        public void AddOutParameter(SqlCommand dbCommand, string parameterName, SqlDbType type, int size)
        {
            parameterName = ValidateParameterName(parameterName);
            SqlParameter param = new SqlParameter(parameterName, type);
            param.Direction = ParameterDirection.Output;
            param.Size = size;
            dbCommand.Parameters.Add(param);
        }

        public object GetParameterValue(SqlCommand dbCommand, string parameterName)
        {
            parameterName = ValidateParameterName(parameterName);
            SqlParameter param = dbCommand.Parameters[parameterName] as SqlParameter;
            return param.Value;
        }

        public int ExecuteNonQuery(SqlCommand dbCommand)
        {
            using (var conn = CreateConnection())
            {
                dbCommand.Connection = conn;
                return dbCommand.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(SqlCommand dbCommand)
        {
            using (var conn = CreateConnection())
            {
                dbCommand.Connection = conn;
                return dbCommand.ExecuteScalar();
            }
        }

        public SqlDataReader ExecuteReader(SqlCommand dbCommand)
        {
            var conn = CreateConnection();
            dbCommand.Connection = conn;
            return dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public string ValidateParameterName(string parameterName)
        {
            if (!string.IsNullOrEmpty(parameterName))
            {
                if (!parameterName.Substring(0, 1).Equals("@"))
                {
                    parameterName = "@" + parameterName;
                }
            }
            return parameterName;
        }

        public async Task<SqlDataReader> ExecuteReaderAsync(SqlCommand dbCommand)
        {
            var conn = await CreateConnectionAsync();
            dbCommand.Connection = conn;
            return await dbCommand.ExecuteReaderAsync(CommandBehavior.CloseConnection);
        }

        public async Task<int> ExecuteNonQueryAsync(SqlCommand dbCommand)
        {
            using (var conn = await CreateConnectionAsync())
            {
                dbCommand.Connection = conn;
                return await dbCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> ExecuteNonQueryAsync(string Query)
        {
            using (var conn = await CreateConnectionAsync())
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = Query;
                return await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<object> ExecuteScalarAsync(SqlCommand dbCommand)
        {
            using (var conn = await CreateConnectionAsync())
            {
                dbCommand.Connection = conn;
                return await dbCommand.ExecuteScalarAsync();
            }
        }

        public async Task<object> ExecuteScalarAsync(string Query)
        {
            using (var conn = await CreateConnectionAsync())
            {
                SqlCommand cmd = GetInlineQuery(Query);
                cmd.Connection = conn;
                return await cmd.ExecuteScalarAsync();
            }
        }

        public void AutoGenerateInputParams<T>(SqlCommand cmd, T request, ISANYUKTServiceUser FIAAPIUser, bool IsListRequest = false, bool IsAddEditRequest = false, bool IsIncludeApplicationID = false, bool IsIncludeOrganizationID = false)
        {
            string s = "";
            foreach (PropertyInfo prop in request.GetType().GetProperties())
            {
                string name = prop.Name;
                SQLParam atSql = (SQLParam)prop.GetCustomAttribute<SQLParam>();

                if (atSql != null)
                {
                    if (atSql.Usage.HasFlag(SQLParamPlaces.None))
                        continue;

                    if (!atSql.Usage.HasFlag(SQLParamPlaces.Writer))
                        continue;

                    name = string.IsNullOrEmpty(atSql.InputParamName) ? prop.Name : atSql.InputParamName;
                }

                if (prop.PropertyType.IsEnum)
                    AddInParameter(cmd, name, (int)prop.GetValue(request));
                else
                    AddInParameter(cmd, name, prop.GetValue(request));
            }

            AddInParameter(cmd, "@LoggedInUserMasterID", FIAAPIUser.UserMasterID);

            if (IsListRequest)
            {
                ListRequest list = request as ListRequest;//JsonConvert.DeserializeObject<ListRequest>(request.ToString());
                cmd.Parameters.AddWithValue("@PageNo", list.PageNo);
                cmd.Parameters.AddWithValue("@PageSize", list.PageSize);
                cmd.Parameters.AddWithValue("@OrderBy", string.IsNullOrEmpty(list.OrderBy) ? null : list.OrderBy);

                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@out_TotalRec",
                    Direction = ParameterDirection.Output,
                    Size = -1
                };
                cmd.Parameters.Add(param);
            }

            if (IsAddEditRequest)
            {
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@Out_ID",
                    Direction = ParameterDirection.Output,
                    Size = -1
                };
                cmd.Parameters.Add(param);
            }

            if (IsIncludeApplicationID)
            {
                AddInParameter(cmd, "@ApplicationID", FIAAPIUser.ApplicationID);
            }

            if (IsIncludeOrganizationID)
            {
                AddInParameter(cmd, "@OrganizationID", FIAAPIUser.OrganizationID);
                AddInParameter(cmd, "@WorkOrganizationID", FIAAPIUser.WorkOrganizationID);
            }
        }

        public async Task<DataSet> ExecuteDataSetAsync(SqlCommand dbCommand)
        {
            DataSet ds = new DataSet();
            using (var conn = await CreateConnectionAsync())
            {
                dbCommand.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(dbCommand);
                da.Fill(ds);
            }
            return ds;
        }
    }
}
