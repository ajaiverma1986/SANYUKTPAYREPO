using SANYUKT.Datamodel.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SANYUKT.Database
{
    public interface ISANYUKTDatabase
    {
        Task<SqlConnection> CreateConnectionAsync();
        SqlCommand GetStoredProcCommand(string spName);
        SqlCommand GetInlineQuery(string Query);
        void AddInParameter(SqlCommand dbCommand, string parameterName, object value);
        void AddInParameter(SqlCommand dbCommand, string parameterName, DbType type, object value);
        void AddInParameter(SqlCommand dbCommand, string parameterName, SqlDbType type, object value);
        void AddOutParameter(SqlCommand dbCommand, string parameterName, int size);
        void AddOutParameter(SqlCommand dbCommand, string parameterName, DbType type, int size);
        void AddOutParameter(SqlCommand dbCommand, string parameterName, SqlDbType type, int size);
        object GetParameterValue(SqlCommand dbCommand, string parameterName);
        int ExecuteNonQuery(SqlCommand dbCommand);
        Task<int> ExecuteNonQueryAsync(SqlCommand dbCommand);
        Task<int> ExecuteNonQueryAsync(string Query);
        object ExecuteScalar(SqlCommand dbCommand);
        Task<object> ExecuteScalarAsync(SqlCommand dbCommand);
        Task<object> ExecuteScalarAsync(string Query);
        SqlDataReader ExecuteReader(SqlCommand dbCommand);
        Task<SqlDataReader> ExecuteReaderAsync(SqlCommand dbCommand);
        void SqlBulkCopyData(string tableName, DataTable dataTable);
        void AutoGenerateInputParams<T>(SqlCommand cmd, T request, ISANYUKTServiceUser FIAAPIUser, bool IsListRequest = false, bool IsAddEditRequest = false, bool IsIncludeApplicationID = false, bool IsIncludeOrganizationID = false);
        Task<int> SqlBulkCopyDataAsync(string tableName, DataTable messageTable);
        Task<DataSet> ExecuteDataSetAsync(SqlCommand cmd);
    }
}
