using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Repository.Shared
{
    public class BaseRepository
    {
        protected const int OUTPARAMETER_SIZE = -1;
        protected const bool OUTPARAMETER_VALUE_BOOL = false;

        protected string GetStringValue(IDataReader dataReader, string columnName)
        {
            object value = dataReader[columnName];
            string valueToReturn = string.Empty;
            if (!(value is DBNull))
            {
                valueToReturn = value.ToString();
            }
            return valueToReturn;
        }

        protected Guid GetGuidValueNotNull(IDataReader dataReader, string columnName)
        {
            object value = dataReader[columnName];
            Guid valueToReturn = new Guid();
            if (!(value is DBNull))
            {
                valueToReturn = (Guid)value;
            }
            return valueToReturn;
        }

        protected byte[] GetByteValue(IDataReader dataReader, string columnName)
        {
            object value = dataReader[columnName];
            byte[] valueToReturn = null;

            if (!(value is DBNull))
            {
                valueToReturn = ((byte[])value);
            }
            return valueToReturn;
        }

        protected Int32? GetInt32Value(IDataReader dataReader, string columnName)
        {
            object value = dataReader[columnName];
            Int32? valueToReturn = null;
            if (!(value is DBNull))
            {
                valueToReturn = Convert.ToInt32(value);
            }
            return valueToReturn;
        }

        protected Int64? GetInt64Value(IDataReader dataReader, string columnName)
        {
            object value = dataReader[columnName];
            Int64? valueToReturn = null;
            if (!(value is DBNull))
            {
                valueToReturn = (Int64?)value;
            }
            return valueToReturn;
        }

        protected Int16? GetSmallIntegerValue(IDataReader dataReader, string columnName)
        {
            object value = dataReader[columnName];
            Int16? valueToReturn = null;
            if (!(value is DBNull))
            {
                valueToReturn = (Int16?)value;
            }
            return valueToReturn;
        }

        protected DateTime? GetDateValue(IDataReader dataReader, string columnName)
        {
            object value = dataReader[columnName];
            DateTime? valueToReturn = null;
            if (!(value is DBNull))
            {
                valueToReturn = (DateTime?)value;
            }
            return valueToReturn;
        }

        protected DateTimeOffset? GetDateTimeOffsetValue(IDataReader dataReader, string columnName)
        {
            object value = dataReader[columnName];
            DateTimeOffset? valueToReturn = null;
            if (!(value is DBNull))
            {
                valueToReturn = (DateTimeOffset?)value;
            }
            return valueToReturn;
        }

        protected bool GetBoolValue(IDataReader dataReader, string columnName)
        {
            object value = dataReader[columnName];
            bool valueToReturn = false;
            if (!(value is DBNull))
            {
                valueToReturn = (bool)value;
            }
            return valueToReturn;
        }

        protected decimal? GetDecimalValue(IDataReader dataReader, string columnName)
        {
            object value = dataReader[columnName];
            decimal? valueToReturn = null;
            if (!(value is DBNull))
            {
                valueToReturn = (decimal?)value;
            }
            return valueToReturn;
        }

        public int GetTotalRecordsParam(SqlCommand cmd)
        {
            object result = cmd.Parameters["@TotalRecords"].Value;
            if (result == null || result == DBNull.Value)
                return 0;
            else
                return Convert.ToInt32(result);
        }

        public long GetIDOutputLong(SqlCommand cmd)
        {
            object result = cmd.Parameters["@Out_ID"].Value;
            if (result == null || result == DBNull.Value)
                return 0;
            else
                return Convert.ToInt64(result);
        }

      
        public string GetIDOutputString(SqlCommand cmd)
        {
            object result = cmd.Parameters["@Out_ID"].Value;
            if (result == null || result == DBNull.Value)
                return null;
            else
                return Convert.ToString(result);
        }
        public string GetIDOutputStringOther(SqlCommand cmd)
        {
            object result = cmd.Parameters["@RequestCode"].Value;
            if (result == null || result == DBNull.Value)
                return null;
            else
                return Convert.ToString(result);
        }

        public int GetIDOutputInt(SqlCommand cmd)
        {
            object result = cmd.Parameters["@Out_ID"].Value;
            if (result == null || result == DBNull.Value)
                return 0;
            else
                return Convert.ToInt32(result);
        }
        public int GetIDOutputIntNew(SqlCommand cmd)
        {
            object result = cmd.Parameters["@transactionid"].Value;
            if (result == null || result == DBNull.Value)
                return 0;
            else
                return Convert.ToInt32(result);
        }

        public Guid? GetIDOutputGuid(SqlCommand cmd)
        {
            object result = cmd.Parameters["@Out_ID"].Value;
            if (result == null || result == DBNull.Value)
                return null;
            else
            {
                if (Guid.TryParse(Convert.ToString(result), out Guid UID))
                {
                    return UID;
                }
                return null;
            }
        }
    }
}
